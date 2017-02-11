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
            List<object> elemAnnotList = null;
            if (context.namespaceDeclaration() != null)
            {
                object elem = context.namespaceDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp2 = new PropertyAnnotation();
                __tmp2.Name = "Declarations";
                elemAnnotList.Add(__tmp2);
            }
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
            QualifiedNameAnnotation __tmp3 = new QualifiedNameAnnotation();
            treeAnnotList.Add(__tmp3);
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
            PropertyAnnotation __tmp4 = new PropertyAnnotation();
            __tmp4.Name = "Annotations";
            treeAnnotList.Add(__tmp4);
            SymbolAnnotation __tmp5 = new SymbolAnnotation();
            __tmp5.SymbolType = typeof(Annotation);
            treeAnnotList.Add(__tmp5);
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
            PropertyAnnotation __tmp6 = new PropertyAnnotation();
            __tmp6.Name = "Annotations";
            treeAnnotList.Add(__tmp6);
            SymbolAnnotation __tmp7 = new SymbolAnnotation();
            __tmp7.SymbolType = typeof(Annotation);
            treeAnnotList.Add(__tmp7);
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
                PropertyAnnotation __tmp8 = new PropertyAnnotation();
                __tmp8.Name = "Name";
                elemAnnotList.Add(__tmp8);
                ValueAnnotation __tmp9 = new ValueAnnotation();
                elemAnnotList.Add(__tmp9);
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
            PropertyAnnotation __tmp10 = new PropertyAnnotation();
            __tmp10.Name = "Properties";
            treeAnnotList.Add(__tmp10);
            SymbolAnnotation __tmp11 = new SymbolAnnotation();
            __tmp11.SymbolType = typeof(AnnotationProperty);
            treeAnnotList.Add(__tmp11);
            List<object> elemAnnotList = null;
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp12 = new PropertyAnnotation();
                __tmp12.Name = "Name";
                elemAnnotList.Add(__tmp12);
                ValueAnnotation __tmp13 = new ValueAnnotation();
                elemAnnotList.Add(__tmp13);
            }
            if (context.annotationPropertyValue() != null)
            {
                object elem = context.annotationPropertyValue();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp14 = new PropertyAnnotation();
                __tmp14.Name = "Value";
                elemAnnotList.Add(__tmp14);
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
            NameDefAnnotation __tmp15 = new NameDefAnnotation();
            __tmp15.SymbolType = typeof(Namespace);
            __tmp15.NestingProperty = "Declarations";
            __tmp15.Merge = true;
            treeAnnotList.Add(__tmp15);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp16 = new PropertyAnnotation();
                __tmp16.Name = "Prefix";
                elemAnnotList.Add(__tmp16);
                ValueAnnotation __tmp17 = new ValueAnnotation();
                elemAnnotList.Add(__tmp17);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp18 = new PropertyAnnotation();
                __tmp18.Name = "Uri";
                elemAnnotList.Add(__tmp18);
                ValueAnnotation __tmp19 = new ValueAnnotation();
                elemAnnotList.Add(__tmp19);
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
            PropertyAnnotation __tmp20 = new PropertyAnnotation();
            __tmp20.Name = "Declarations";
            treeAnnotList.Add(__tmp20);
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
            TypeDefAnnotation __tmp21 = new TypeDefAnnotation();
            __tmp21.SymbolType = typeof(Enum);
            treeAnnotList.Add(__tmp21);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp22 = new PropertyAnnotation();
                __tmp22.Name = "BaseType";
                elemAnnotList.Add(__tmp22);
                TypeUseAnnotation __tmp23 = new TypeUseAnnotation();
                __tmp23.SymbolTypes.Add(typeof(Enum));
                __tmp23.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp23);
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
            PropertyAnnotation __tmp24 = new PropertyAnnotation();
            __tmp24.Name = "EnumLiterals";
            treeAnnotList.Add(__tmp24);
            NameDefAnnotation __tmp25 = new NameDefAnnotation();
            __tmp25.SymbolType = typeof(EnumLiteral);
            treeAnnotList.Add(__tmp25);
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
            TypeDefAnnotation __tmp26 = new TypeDefAnnotation();
            __tmp26.SymbolType = typeof(Struct);
            treeAnnotList.Add(__tmp26);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp27 = new PropertyAnnotation();
                __tmp27.Name = "BaseType";
                elemAnnotList.Add(__tmp27);
                TypeUseAnnotation __tmp28 = new TypeUseAnnotation();
                __tmp28.SymbolTypes.Add(typeof(Struct));
                __tmp28.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp28);
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
            PropertyAnnotation __tmp29 = new PropertyAnnotation();
            __tmp29.Name = "Properties";
            treeAnnotList.Add(__tmp29);
            NameDefAnnotation __tmp30 = new NameDefAnnotation();
            __tmp30.SymbolType = typeof(Property);
            treeAnnotList.Add(__tmp30);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp31 = new PropertyAnnotation();
                __tmp31.Name = "Type";
                elemAnnotList.Add(__tmp31);
                TypeUseAnnotation __tmp32 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp32);
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
            TypeDefAnnotation __tmp33 = new TypeDefAnnotation();
            __tmp33.SymbolType = typeof(Database);
            treeAnnotList.Add(__tmp33);
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
            PropertyAnnotation __tmp34 = new PropertyAnnotation();
            __tmp34.Name = "Entities";
            treeAnnotList.Add(__tmp34);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp35 = new TypeUseAnnotation();
                __tmp35.SymbolTypes.Add(typeof(Struct));
                elemAnnotList.Add(__tmp35);
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
            TypeDefAnnotation __tmp36 = new TypeDefAnnotation();
            __tmp36.SymbolType = typeof(Interface);
            treeAnnotList.Add(__tmp36);
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
            PropertyAnnotation __tmp37 = new PropertyAnnotation();
            __tmp37.Name = "Operations";
            treeAnnotList.Add(__tmp37);
            NameDefAnnotation __tmp38 = new NameDefAnnotation();
            __tmp38.SymbolType = typeof(Operation);
            treeAnnotList.Add(__tmp38);
            List<object> elemAnnotList = null;
            if (context.qualifiedNameList() != null)
            {
                object elem = context.qualifiedNameList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp39 = new PropertyAnnotation();
                __tmp39.Name = "Exceptions";
                elemAnnotList.Add(__tmp39);
                TypeUseAnnotation __tmp40 = new TypeUseAnnotation();
                __tmp40.SymbolTypes.Add(typeof(Struct));
                elemAnnotList.Add(__tmp40);
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
            PropertyAnnotation __tmp41 = new PropertyAnnotation();
            __tmp41.Name = "Parameters";
            treeAnnotList.Add(__tmp41);
            NameDefAnnotation __tmp42 = new NameDefAnnotation();
            __tmp42.SymbolType = typeof(InputParameter);
            treeAnnotList.Add(__tmp42);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp43 = new PropertyAnnotation();
                __tmp43.Name = "Type";
                elemAnnotList.Add(__tmp43);
                TypeUseAnnotation __tmp44 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp44);
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
            PropertyAnnotation __tmp45 = new PropertyAnnotation();
            __tmp45.Name = "Result";
            treeAnnotList.Add(__tmp45);
            SymbolAnnotation __tmp46 = new SymbolAnnotation();
            __tmp46.SymbolType = typeof(OutputParameter);
            treeAnnotList.Add(__tmp46);
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
            TypeDefAnnotation __tmp47 = new TypeDefAnnotation();
            __tmp47.SymbolType = typeof(Component);
            treeAnnotList.Add(__tmp47);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                object elem = context.KAbstract();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp48 = new PropertyAnnotation();
                __tmp48.Name = "IsAbstract";
                __tmp48.Value = true;
                elemAnnotList.Add(__tmp48);
            }
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp49 = new PropertyAnnotation();
                __tmp49.Name = "BaseComponent";
                elemAnnotList.Add(__tmp49);
                TypeUseAnnotation __tmp50 = new TypeUseAnnotation();
                __tmp50.SymbolTypes.Add(typeof(Component));
                __tmp50.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp50);
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
            PropertyAnnotation __tmp51 = new PropertyAnnotation();
            __tmp51.Name = "Services";
            treeAnnotList.Add(__tmp51);
            NameDefAnnotation __tmp52 = new NameDefAnnotation();
            __tmp52.SymbolType = typeof(Service);
            treeAnnotList.Add(__tmp52);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp53 = new PropertyAnnotation();
                __tmp53.Name = "Interface";
                elemAnnotList.Add(__tmp53);
                TypeUseAnnotation __tmp54 = new TypeUseAnnotation();
                __tmp54.SymbolTypes.Add(typeof(Interface));
                elemAnnotList.Add(__tmp54);
            }
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp55 = new PropertyAnnotation();
                __tmp55.Name = "OptionalName";
                elemAnnotList.Add(__tmp55);
                ValueAnnotation __tmp56 = new ValueAnnotation();
                elemAnnotList.Add(__tmp56);
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
            PropertyAnnotation __tmp57 = new PropertyAnnotation();
            __tmp57.Name = "References";
            treeAnnotList.Add(__tmp57);
            NameDefAnnotation __tmp58 = new NameDefAnnotation();
            __tmp58.SymbolType = typeof(Reference);
            treeAnnotList.Add(__tmp58);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp59 = new PropertyAnnotation();
                __tmp59.Name = "Interface";
                elemAnnotList.Add(__tmp59);
                TypeUseAnnotation __tmp60 = new TypeUseAnnotation();
                __tmp60.SymbolTypes.Add(typeof(Interface));
                elemAnnotList.Add(__tmp60);
            }
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp61 = new PropertyAnnotation();
                __tmp61.Name = "OptionalName";
                elemAnnotList.Add(__tmp61);
                ValueAnnotation __tmp62 = new ValueAnnotation();
                elemAnnotList.Add(__tmp62);
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
                PropertyAnnotation __tmp63 = new PropertyAnnotation();
                __tmp63.Name = "Binding";
                elemAnnotList.Add(__tmp63);
                NameUseAnnotation __tmp64 = new NameUseAnnotation();
                __tmp64.SymbolTypes.Add(typeof(Binding));
                elemAnnotList.Add(__tmp64);
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
            PropertyAnnotation __tmp65 = new PropertyAnnotation();
            __tmp65.Name = "Properties";
            treeAnnotList.Add(__tmp65);
            NameDefAnnotation __tmp66 = new NameDefAnnotation();
            __tmp66.SymbolType = typeof(Property);
            treeAnnotList.Add(__tmp66);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp67 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp67);
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
            PropertyAnnotation __tmp68 = new PropertyAnnotation();
            __tmp68.Name = "Implementation";
            treeAnnotList.Add(__tmp68);
            NameDefAnnotation __tmp69 = new NameDefAnnotation();
            __tmp69.SymbolType = typeof(Implementation);
            treeAnnotList.Add(__tmp69);
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
            PropertyAnnotation __tmp70 = new PropertyAnnotation();
            __tmp70.Name = "Language";
            treeAnnotList.Add(__tmp70);
            NameDefAnnotation __tmp71 = new NameDefAnnotation();
            __tmp71.SymbolType = typeof(Language);
            treeAnnotList.Add(__tmp71);
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
            TypeDefAnnotation __tmp72 = new TypeDefAnnotation();
            __tmp72.SymbolType = typeof(Composite);
            treeAnnotList.Add(__tmp72);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp73 = new PropertyAnnotation();
                __tmp73.Name = "BaseComponent";
                elemAnnotList.Add(__tmp73);
                TypeUseAnnotation __tmp74 = new TypeUseAnnotation();
                __tmp74.SymbolTypes.Add(typeof(Component));
                __tmp74.SymbolTypes.Add(typeof(Composite));
                __tmp74.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp74);
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
            TypeDefAnnotation __tmp75 = new TypeDefAnnotation();
            __tmp75.SymbolType = typeof(Assembly);
            treeAnnotList.Add(__tmp75);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp76 = new PropertyAnnotation();
                __tmp76.Name = "BaseComponent";
                elemAnnotList.Add(__tmp76);
                TypeUseAnnotation __tmp77 = new TypeUseAnnotation();
                __tmp77.SymbolTypes.Add(typeof(Component));
                __tmp77.SymbolTypes.Add(typeof(Composite));
                __tmp77.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp77);
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
            PropertyAnnotation __tmp78 = new PropertyAnnotation();
            __tmp78.Name = "Components";
            treeAnnotList.Add(__tmp78);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp79 = new NameUseAnnotation();
                __tmp79.SymbolTypes.Add(typeof(Component));
                elemAnnotList.Add(__tmp79);
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
            PropertyAnnotation __tmp80 = new PropertyAnnotation();
            __tmp80.Name = "Wires";
            treeAnnotList.Add(__tmp80);
            SymbolAnnotation __tmp81 = new SymbolAnnotation();
            __tmp81.SymbolType = typeof(Wire);
            treeAnnotList.Add(__tmp81);
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
                PropertyAnnotation __tmp82 = new PropertyAnnotation();
                __tmp82.Name = "Source";
                elemAnnotList.Add(__tmp82);
                NameUseAnnotation __tmp83 = new NameUseAnnotation();
                __tmp83.SymbolTypes.Add(typeof(Port));
                elemAnnotList.Add(__tmp83);
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
                PropertyAnnotation __tmp84 = new PropertyAnnotation();
                __tmp84.Name = "Target";
                elemAnnotList.Add(__tmp84);
                NameUseAnnotation __tmp85 = new NameUseAnnotation();
                __tmp85.SymbolTypes.Add(typeof(Port));
                elemAnnotList.Add(__tmp85);
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
            NameDefAnnotation __tmp86 = new NameDefAnnotation();
            __tmp86.SymbolType = typeof(Deployment);
            treeAnnotList.Add(__tmp86);
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
            PropertyAnnotation __tmp87 = new PropertyAnnotation();
            __tmp87.Name = "Environments";
            treeAnnotList.Add(__tmp87);
            NameDefAnnotation __tmp88 = new NameDefAnnotation();
            __tmp88.SymbolType = typeof(Environment);
            treeAnnotList.Add(__tmp88);
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
            PropertyAnnotation __tmp89 = new PropertyAnnotation();
            __tmp89.Name = "Runtime";
            treeAnnotList.Add(__tmp89);
            NameDefAnnotation __tmp90 = new NameDefAnnotation();
            __tmp90.SymbolType = typeof(Runtime);
            treeAnnotList.Add(__tmp90);
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
            PropertyAnnotation __tmp91 = new PropertyAnnotation();
            __tmp91.Name = "Assemblies";
            treeAnnotList.Add(__tmp91);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp92 = new TypeUseAnnotation();
                __tmp92.SymbolTypes.Add(typeof(Assembly));
                elemAnnotList.Add(__tmp92);
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
            PropertyAnnotation __tmp93 = new PropertyAnnotation();
            __tmp93.Name = "Databases";
            treeAnnotList.Add(__tmp93);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp94 = new TypeUseAnnotation();
                __tmp94.SymbolTypes.Add(typeof(Database));
                elemAnnotList.Add(__tmp94);
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
            NameDefAnnotation __tmp95 = new NameDefAnnotation();
            __tmp95.SymbolType = typeof(Binding);
            treeAnnotList.Add(__tmp95);
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
            PropertyAnnotation __tmp96 = new PropertyAnnotation();
            __tmp96.Name = "Transport";
            treeAnnotList.Add(__tmp96);
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
            SymbolAnnotation __tmp97 = new SymbolAnnotation();
            __tmp97.SymbolType = typeof(HttpTransportBindingElement);
            treeAnnotList.Add(__tmp97);
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
            SymbolAnnotation __tmp98 = new SymbolAnnotation();
            __tmp98.SymbolType = typeof(RestTransportBindingElement);
            treeAnnotList.Add(__tmp98);
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
            SymbolAnnotation __tmp99 = new SymbolAnnotation();
            __tmp99.SymbolType = typeof(WebSocketTransportBindingElement);
            treeAnnotList.Add(__tmp99);
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
            PropertyAnnotation __tmp100 = new PropertyAnnotation();
            __tmp100.Name = "Ssl";
            treeAnnotList.Add(__tmp100);
            List<object> elemAnnotList = null;
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp101 = new ValueAnnotation();
                elemAnnotList.Add(__tmp101);
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
            PropertyAnnotation __tmp102 = new PropertyAnnotation();
            __tmp102.Name = "ClientAuthentication";
            treeAnnotList.Add(__tmp102);
            List<object> elemAnnotList = null;
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp103 = new ValueAnnotation();
                elemAnnotList.Add(__tmp103);
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
            PropertyAnnotation __tmp104 = new PropertyAnnotation();
            __tmp104.Name = "Encodings";
            treeAnnotList.Add(__tmp104);
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
            SymbolAnnotation __tmp105 = new SymbolAnnotation();
            __tmp105.SymbolType = typeof(SoapEncodingBindingElement);
            treeAnnotList.Add(__tmp105);
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
            SymbolAnnotation __tmp106 = new SymbolAnnotation();
            __tmp106.SymbolType = typeof(XmlEncodingBindingElement);
            treeAnnotList.Add(__tmp106);
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
            SymbolAnnotation __tmp107 = new SymbolAnnotation();
            __tmp107.SymbolType = typeof(JsonEncodingBindingElement);
            treeAnnotList.Add(__tmp107);
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
            PropertyAnnotation __tmp108 = new PropertyAnnotation();
            __tmp108.Name = "Version";
            treeAnnotList.Add(__tmp108);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                EnumValueAnnotation __tmp109 = new EnumValueAnnotation();
                __tmp109.EnumType = typeof(SoapVersion);
                elemAnnotList.Add(__tmp109);
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
            PropertyAnnotation __tmp110 = new PropertyAnnotation();
            __tmp110.Name = "Mtom";
            treeAnnotList.Add(__tmp110);
            List<object> elemAnnotList = null;
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp111 = new ValueAnnotation();
                elemAnnotList.Add(__tmp111);
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
            PropertyAnnotation __tmp112 = new PropertyAnnotation();
            __tmp112.Name = "Style";
            treeAnnotList.Add(__tmp112);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                EnumValueAnnotation __tmp113 = new EnumValueAnnotation();
                __tmp113.EnumType = typeof(SoapEncodingStyle);
                elemAnnotList.Add(__tmp113);
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
            PropertyAnnotation __tmp114 = new PropertyAnnotation();
            __tmp114.Name = "Protocols";
            treeAnnotList.Add(__tmp114);
            SymbolAnnotation __tmp115 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp115);
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
                SymbolTypeAnnotation __tmp116 = new SymbolTypeAnnotation();
                __tmp116.Name = "WsAddressing";
                __tmp116.SymbolType = typeof(WsAddressingBindingElement);
                elemAnnotList.Add(__tmp116);
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
            NameDefAnnotation __tmp117 = new NameDefAnnotation();
            __tmp117.SymbolType = typeof(Endpoint);
            treeAnnotList.Add(__tmp117);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp118 = new PropertyAnnotation();
                __tmp118.Name = "Interface";
                elemAnnotList.Add(__tmp118);
                TypeUseAnnotation __tmp119 = new TypeUseAnnotation();
                __tmp119.SymbolTypes.Add(typeof(Interface));
                elemAnnotList.Add(__tmp119);
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
                PropertyAnnotation __tmp120 = new PropertyAnnotation();
                __tmp120.Name = "Binding";
                elemAnnotList.Add(__tmp120);
                NameUseAnnotation __tmp121 = new NameUseAnnotation();
                __tmp121.SymbolTypes.Add(typeof(Binding));
                elemAnnotList.Add(__tmp121);
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
                PropertyAnnotation __tmp122 = new PropertyAnnotation();
                __tmp122.Name = "Address";
                elemAnnotList.Add(__tmp122);
                ValueAnnotation __tmp123 = new ValueAnnotation();
                elemAnnotList.Add(__tmp123);
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
                PropertyAnnotation __tmp124 = new PropertyAnnotation();
                __tmp124.Name = "Type";
                elemAnnotList.Add(__tmp124);
                TypeUseAnnotation __tmp125 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp125);
            }
            if (context.onewayType() != null)
            {
                object elem = context.onewayType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp126 = new PropertyAnnotation();
                __tmp126.Name = "Type";
                __tmp126.Value = SoalInstance.Void;
                elemAnnotList.Add(__tmp126);
                PropertyAnnotation __tmp127 = new PropertyAnnotation();
                __tmp127.Name = "IsOneway";
                __tmp127.Value = true;
                elemAnnotList.Add(__tmp127);
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
            TypeCtrAnnotation __tmp128 = new TypeCtrAnnotation();
            __tmp128.SymbolType = typeof(NullableType);
            treeAnnotList.Add(__tmp128);
            List<object> elemAnnotList = null;
            if (context.valueType() != null)
            {
                object elem = context.valueType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp129 = new PropertyAnnotation();
                __tmp129.Name = "InnerType";
                elemAnnotList.Add(__tmp129);
                TypeUseAnnotation __tmp130 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp130);
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
            TypeCtrAnnotation __tmp131 = new TypeCtrAnnotation();
            __tmp131.SymbolType = typeof(NonNullableType);
            treeAnnotList.Add(__tmp131);
            List<object> elemAnnotList = null;
            if (context.referenceType() != null)
            {
                object elem = context.referenceType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp132 = new PropertyAnnotation();
                __tmp132.Name = "InnerType";
                elemAnnotList.Add(__tmp132);
                TypeUseAnnotation __tmp133 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp133);
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
            TypeCtrAnnotation __tmp134 = new TypeCtrAnnotation();
            __tmp134.SymbolType = typeof(NonNullableType);
            treeAnnotList.Add(__tmp134);
            List<object> elemAnnotList = null;
            if (context.arrayType() != null)
            {
                object elem = context.arrayType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp135 = new PropertyAnnotation();
                __tmp135.Name = "InnerType";
                elemAnnotList.Add(__tmp135);
                TypeUseAnnotation __tmp136 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp136);
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
            TypeCtrAnnotation __tmp137 = new TypeCtrAnnotation();
            __tmp137.SymbolType = typeof(ArrayType);
            treeAnnotList.Add(__tmp137);
            List<object> elemAnnotList = null;
            if (context.simpleType() != null)
            {
                object elem = context.simpleType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp138 = new PropertyAnnotation();
                __tmp138.Name = "InnerType";
                elemAnnotList.Add(__tmp138);
                TypeUseAnnotation __tmp139 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp139);
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
            TypeCtrAnnotation __tmp140 = new TypeCtrAnnotation();
            __tmp140.SymbolType = typeof(ArrayType);
            treeAnnotList.Add(__tmp140);
            List<object> elemAnnotList = null;
            if (context.nulledType() != null)
            {
                object elem = context.nulledType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp141 = new PropertyAnnotation();
                __tmp141.Name = "InnerType";
                elemAnnotList.Add(__tmp141);
                TypeUseAnnotation __tmp142 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp142);
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
                TypeUseAnnotation __tmp143 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp143);
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
            NameAnnotation __tmp144 = new NameAnnotation();
            treeAnnotList.Add(__tmp144);
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
            NameAnnotation __tmp145 = new NameAnnotation();
            treeAnnotList.Add(__tmp145);
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
            IdentifierAnnotation __tmp146 = new IdentifierAnnotation();
            treeAnnotList.Add(__tmp146);
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
                ValueAnnotation __tmp147 = new ValueAnnotation();
                elemAnnotList.Add(__tmp147);
            }
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp148 = new ValueAnnotation();
                elemAnnotList.Add(__tmp148);
            }
            if (context.integerLiteral() != null)
            {
                object elem = context.integerLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp149 = new ValueAnnotation();
                elemAnnotList.Add(__tmp149);
            }
            if (context.decimalLiteral() != null)
            {
                object elem = context.decimalLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp150 = new ValueAnnotation();
                elemAnnotList.Add(__tmp150);
            }
            if (context.scientificLiteral() != null)
            {
                object elem = context.scientificLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp151 = new ValueAnnotation();
                elemAnnotList.Add(__tmp151);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp152 = new ValueAnnotation();
                elemAnnotList.Add(__tmp152);
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