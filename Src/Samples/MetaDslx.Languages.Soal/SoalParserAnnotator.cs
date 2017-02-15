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
        
        public override object VisitName(SoalParser.NameContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameAnnotation __tmp3 = new NameAnnotation();
            treeAnnotList.Add(__tmp3);
            this.HandleSymbolType(context);
            return base.VisitName(context);
        }
        
        public override object VisitQualifiedName(SoalParser.QualifiedNameContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameAnnotation __tmp4 = new NameAnnotation();
            treeAnnotList.Add(__tmp4);
            this.HandleSymbolType(context);
            return base.VisitQualifiedName(context);
        }
        
        public override object VisitQualifier(SoalParser.QualifierContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            QualifierAnnotation __tmp5 = new QualifierAnnotation();
            treeAnnotList.Add(__tmp5);
            this.HandleSymbolType(context);
            return base.VisitQualifier(context);
        }
        
        public override object VisitIdentifierList(SoalParser.IdentifierListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifierList(context);
        }
        
        public override object VisitQualifierList(SoalParser.QualifierListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitQualifierList(context);
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
            PropertyAnnotation __tmp6 = new PropertyAnnotation();
            __tmp6.Name = "Annotations";
            treeAnnotList.Add(__tmp6);
            SymbolAnnotation __tmp7 = new SymbolAnnotation();
            __tmp7.SymbolType = typeof(Annotation);
            treeAnnotList.Add(__tmp7);
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
            PropertyAnnotation __tmp8 = new PropertyAnnotation();
            __tmp8.Name = "Annotations";
            treeAnnotList.Add(__tmp8);
            SymbolAnnotation __tmp9 = new SymbolAnnotation();
            __tmp9.SymbolType = typeof(Annotation);
            treeAnnotList.Add(__tmp9);
            this.HandleSymbolType(context);
            return base.VisitReturnAnnotation(context);
        }
        
        public override object VisitAnnotationHead(SoalParser.AnnotationHeadContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationHead(context);
        }
        
        public override object VisitAnnotationBody(SoalParser.AnnotationBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp10 = new BodyAnnotation();
            treeAnnotList.Add(__tmp10);
            this.HandleSymbolType(context);
            return base.VisitAnnotationBody(context);
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
            PropertyAnnotation __tmp11 = new PropertyAnnotation();
            __tmp11.Name = "Properties";
            treeAnnotList.Add(__tmp11);
            SymbolAnnotation __tmp12 = new SymbolAnnotation();
            __tmp12.SymbolType = typeof(AnnotationProperty);
            treeAnnotList.Add(__tmp12);
            List<object> elemAnnotList = null;
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
            SymbolAnnotation __tmp14 = new SymbolAnnotation();
            __tmp14.SymbolType = typeof(Namespace);
            __tmp14.NestingProperty = node;
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
        
        public override object VisitNamespaceBody(SoalParser.NamespaceBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp19 = new BodyAnnotation();
            treeAnnotList.Add(__tmp19);
            this.HandleSymbolType(context);
            return base.VisitNamespaceBody(context);
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
            SymbolAnnotation __tmp21 = new SymbolAnnotation();
            __tmp21.SymbolType = typeof(Enum);
            treeAnnotList.Add(__tmp21);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp22 = new PropertyAnnotation();
                __tmp22.Name = "BaseType";
                elemAnnotList.Add(__tmp22);
                SymbolUseAnnotation __tmp23 = new SymbolUseAnnotation();
                __tmp23.Value = node;
                elemAnnotList.Add(__tmp23);
            }
            this.HandleSymbolType(context);
            return base.VisitEnumDeclaration(context);
        }
        
        public override object VisitEnumBody(SoalParser.EnumBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp24 = new BodyAnnotation();
            treeAnnotList.Add(__tmp24);
            this.HandleSymbolType(context);
            return base.VisitEnumBody(context);
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
            PropertyAnnotation __tmp25 = new PropertyAnnotation();
            __tmp25.Name = "EnumLiterals";
            treeAnnotList.Add(__tmp25);
            SymbolAnnotation __tmp26 = new SymbolAnnotation();
            __tmp26.SymbolType = typeof(EnumLiteral);
            treeAnnotList.Add(__tmp26);
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
            SymbolAnnotation __tmp27 = new SymbolAnnotation();
            __tmp27.SymbolType = typeof(Struct);
            treeAnnotList.Add(__tmp27);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp28 = new PropertyAnnotation();
                __tmp28.Name = "BaseType";
                elemAnnotList.Add(__tmp28);
                SymbolUseAnnotation __tmp29 = new SymbolUseAnnotation();
                __tmp29.Value = node;
                elemAnnotList.Add(__tmp29);
            }
            this.HandleSymbolType(context);
            return base.VisitStructDeclaration(context);
        }
        
        public override object VisitStructBody(SoalParser.StructBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp30 = new BodyAnnotation();
            treeAnnotList.Add(__tmp30);
            this.HandleSymbolType(context);
            return base.VisitStructBody(context);
        }
        
        public override object VisitPropertyDeclaration(SoalParser.PropertyDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp31 = new PropertyAnnotation();
            __tmp31.Name = "Properties";
            treeAnnotList.Add(__tmp31);
            SymbolAnnotation __tmp32 = new SymbolAnnotation();
            __tmp32.SymbolType = typeof(Property);
            treeAnnotList.Add(__tmp32);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp33 = new PropertyAnnotation();
                __tmp33.Name = "Type";
                elemAnnotList.Add(__tmp33);
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
            SymbolAnnotation __tmp34 = new SymbolAnnotation();
            __tmp34.SymbolType = typeof(Database);
            treeAnnotList.Add(__tmp34);
            this.HandleSymbolType(context);
            return base.VisitDatabaseDeclaration(context);
        }
        
        public override object VisitDatabaseBody(SoalParser.DatabaseBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp35 = new BodyAnnotation();
            treeAnnotList.Add(__tmp35);
            this.HandleSymbolType(context);
            return base.VisitDatabaseBody(context);
        }
        
        public override object VisitEntityReference(SoalParser.EntityReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp36 = new PropertyAnnotation();
            __tmp36.Name = "Entities";
            treeAnnotList.Add(__tmp36);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolUseAnnotation __tmp37 = new SymbolUseAnnotation();
                __tmp37.Value = node;
                elemAnnotList.Add(__tmp37);
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
            SymbolAnnotation __tmp38 = new SymbolAnnotation();
            __tmp38.SymbolType = typeof(Interface);
            treeAnnotList.Add(__tmp38);
            this.HandleSymbolType(context);
            return base.VisitInterfaceDeclaration(context);
        }
        
        public override object VisitInterfaceBody(SoalParser.InterfaceBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp39 = new BodyAnnotation();
            treeAnnotList.Add(__tmp39);
            this.HandleSymbolType(context);
            return base.VisitInterfaceBody(context);
        }
        
        public override object VisitOperationDeclaration(SoalParser.OperationDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp40 = new PropertyAnnotation();
            __tmp40.Name = "Operations";
            treeAnnotList.Add(__tmp40);
            SymbolAnnotation __tmp41 = new SymbolAnnotation();
            __tmp41.SymbolType = typeof(Operation);
            treeAnnotList.Add(__tmp41);
            this.HandleSymbolType(context);
            return base.VisitOperationDeclaration(context);
        }
        
        public override object VisitOperationHead(SoalParser.OperationHeadContext context)
        {
            List<object> elemAnnotList = null;
            if (context.qualifierList() != null)
            {
                object elem = context.qualifierList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp42 = new PropertyAnnotation();
                __tmp42.Name = "Exceptions";
                elemAnnotList.Add(__tmp42);
                SymbolUseAnnotation __tmp43 = new SymbolUseAnnotation();
                __tmp43.Value = node;
                elemAnnotList.Add(__tmp43);
            }
            this.HandleSymbolType(context);
            return base.VisitOperationHead(context);
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
            PropertyAnnotation __tmp44 = new PropertyAnnotation();
            __tmp44.Name = "Parameters";
            treeAnnotList.Add(__tmp44);
            SymbolAnnotation __tmp45 = new SymbolAnnotation();
            __tmp45.SymbolType = typeof(InputParameter);
            treeAnnotList.Add(__tmp45);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp46 = new PropertyAnnotation();
                __tmp46.Name = "Type";
                elemAnnotList.Add(__tmp46);
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
            PropertyAnnotation __tmp47 = new PropertyAnnotation();
            __tmp47.Name = "Result";
            treeAnnotList.Add(__tmp47);
            SymbolAnnotation __tmp48 = new SymbolAnnotation();
            __tmp48.SymbolType = typeof(OutputParameter);
            treeAnnotList.Add(__tmp48);
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
            SymbolAnnotation __tmp49 = new SymbolAnnotation();
            __tmp49.SymbolType = typeof(Component);
            treeAnnotList.Add(__tmp49);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                object elem = context.KAbstract();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp50 = new PropertyAnnotation();
                __tmp50.Name = "IsAbstract";
                __tmp50.Value = true;
                elemAnnotList.Add(__tmp50);
            }
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp51 = new PropertyAnnotation();
                __tmp51.Name = "BaseComponent";
                elemAnnotList.Add(__tmp51);
                SymbolUseAnnotation __tmp52 = new SymbolUseAnnotation();
                __tmp52.Value = node;
                elemAnnotList.Add(__tmp52);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentDeclaration(context);
        }
        
        public override object VisitComponentBody(SoalParser.ComponentBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp53 = new BodyAnnotation();
            treeAnnotList.Add(__tmp53);
            this.HandleSymbolType(context);
            return base.VisitComponentBody(context);
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
            PropertyAnnotation __tmp54 = new PropertyAnnotation();
            __tmp54.Name = "Services";
            treeAnnotList.Add(__tmp54);
            SymbolAnnotation __tmp55 = new SymbolAnnotation();
            __tmp55.SymbolType = typeof(Service);
            treeAnnotList.Add(__tmp55);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp56 = new PropertyAnnotation();
                __tmp56.Name = "Interface";
                elemAnnotList.Add(__tmp56);
                SymbolUseAnnotation __tmp57 = new SymbolUseAnnotation();
                __tmp57.Value = node;
                elemAnnotList.Add(__tmp57);
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
            PropertyAnnotation __tmp58 = new PropertyAnnotation();
            __tmp58.Name = "References";
            treeAnnotList.Add(__tmp58);
            SymbolAnnotation __tmp59 = new SymbolAnnotation();
            __tmp59.SymbolType = typeof(Reference);
            treeAnnotList.Add(__tmp59);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp60 = new PropertyAnnotation();
                __tmp60.Name = "Interface";
                elemAnnotList.Add(__tmp60);
                SymbolUseAnnotation __tmp61 = new SymbolUseAnnotation();
                __tmp61.Value = node;
                elemAnnotList.Add(__tmp61);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentReference(context);
        }
        
        public override object VisitComponentServiceOrReferenceEmptyBody(SoalParser.ComponentServiceOrReferenceEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp62 = new BodyAnnotation();
            treeAnnotList.Add(__tmp62);
            this.HandleSymbolType(context);
            return base.VisitComponentServiceOrReferenceEmptyBody(context);
        }
        
        public override object VisitComponentServiceOrReferenceNonEmptyBody(SoalParser.ComponentServiceOrReferenceNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp63 = new BodyAnnotation();
            treeAnnotList.Add(__tmp63);
            this.HandleSymbolType(context);
            return base.VisitComponentServiceOrReferenceNonEmptyBody(context);
        }
        
        public override object VisitComponentServiceOrReferenceElement(SoalParser.ComponentServiceOrReferenceElementContext context)
        {
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp64 = new PropertyAnnotation();
                __tmp64.Name = "Binding";
                elemAnnotList.Add(__tmp64);
                NameUseAnnotation __tmp65 = new NameUseAnnotation();
                __tmp65.SymbolTypes.Add(typeof(Binding));
                elemAnnotList.Add(__tmp65);
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
            PropertyAnnotation __tmp66 = new PropertyAnnotation();
            __tmp66.Name = "Properties";
            treeAnnotList.Add(__tmp66);
            SymbolAnnotation __tmp67 = new SymbolAnnotation();
            __tmp67.SymbolType = typeof(Property);
            treeAnnotList.Add(__tmp67);
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
            SymbolAnnotation __tmp69 = new SymbolAnnotation();
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
            SymbolAnnotation __tmp71 = new SymbolAnnotation();
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
            SymbolAnnotation __tmp72 = new SymbolAnnotation();
            __tmp72.SymbolType = typeof(Composite);
            treeAnnotList.Add(__tmp72);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp73 = new PropertyAnnotation();
                __tmp73.Name = "BaseComponent";
                elemAnnotList.Add(__tmp73);
                SymbolUseAnnotation __tmp74 = new SymbolUseAnnotation();
                __tmp74.Value = node;
                elemAnnotList.Add(__tmp74);
            }
            this.HandleSymbolType(context);
            return base.VisitCompositeDeclaration(context);
        }
        
        public override object VisitCompositeBody(SoalParser.CompositeBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp75 = new BodyAnnotation();
            treeAnnotList.Add(__tmp75);
            this.HandleSymbolType(context);
            return base.VisitCompositeBody(context);
        }
        
        public override object VisitAssemblyDeclaration(SoalParser.AssemblyDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp76 = new SymbolAnnotation();
            __tmp76.SymbolType = typeof(Assembly);
            treeAnnotList.Add(__tmp76);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp77 = new PropertyAnnotation();
                __tmp77.Name = "BaseComponent";
                elemAnnotList.Add(__tmp77);
                SymbolUseAnnotation __tmp78 = new SymbolUseAnnotation();
                __tmp78.Value = node;
                elemAnnotList.Add(__tmp78);
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
            PropertyAnnotation __tmp79 = new PropertyAnnotation();
            __tmp79.Name = "Components";
            treeAnnotList.Add(__tmp79);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp80 = new NameUseAnnotation();
                __tmp80.SymbolTypes.Add(typeof(Component));
                elemAnnotList.Add(__tmp80);
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
            PropertyAnnotation __tmp81 = new PropertyAnnotation();
            __tmp81.Name = "Wires";
            treeAnnotList.Add(__tmp81);
            SymbolAnnotation __tmp82 = new SymbolAnnotation();
            __tmp82.SymbolType = typeof(Wire);
            treeAnnotList.Add(__tmp82);
            this.HandleSymbolType(context);
            return base.VisitCompositeWire(context);
        }
        
        public override object VisitWireSource(SoalParser.WireSourceContext context)
        {
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp83 = new PropertyAnnotation();
                __tmp83.Name = "Source";
                elemAnnotList.Add(__tmp83);
                NameUseAnnotation __tmp84 = new NameUseAnnotation();
                __tmp84.SymbolTypes.Add(typeof(Port));
                elemAnnotList.Add(__tmp84);
            }
            this.HandleSymbolType(context);
            return base.VisitWireSource(context);
        }
        
        public override object VisitWireTarget(SoalParser.WireTargetContext context)
        {
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp85 = new PropertyAnnotation();
                __tmp85.Name = "Target";
                elemAnnotList.Add(__tmp85);
                NameUseAnnotation __tmp86 = new NameUseAnnotation();
                __tmp86.SymbolTypes.Add(typeof(Port));
                elemAnnotList.Add(__tmp86);
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
            SymbolAnnotation __tmp87 = new SymbolAnnotation();
            __tmp87.SymbolType = typeof(Deployment);
            treeAnnotList.Add(__tmp87);
            this.HandleSymbolType(context);
            return base.VisitDeploymentDeclaration(context);
        }
        
        public override object VisitDeploymentBody(SoalParser.DeploymentBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp88 = new BodyAnnotation();
            treeAnnotList.Add(__tmp88);
            this.HandleSymbolType(context);
            return base.VisitDeploymentBody(context);
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
            PropertyAnnotation __tmp89 = new PropertyAnnotation();
            __tmp89.Name = "Environments";
            treeAnnotList.Add(__tmp89);
            SymbolAnnotation __tmp90 = new SymbolAnnotation();
            __tmp90.SymbolType = typeof(Environment);
            treeAnnotList.Add(__tmp90);
            this.HandleSymbolType(context);
            return base.VisitEnvironmentDeclaration(context);
        }
        
        public override object VisitEnvironmentBody(SoalParser.EnvironmentBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp91 = new BodyAnnotation();
            treeAnnotList.Add(__tmp91);
            this.HandleSymbolType(context);
            return base.VisitEnvironmentBody(context);
        }
        
        public override object VisitRuntimeDeclaration(SoalParser.RuntimeDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp92 = new PropertyAnnotation();
            __tmp92.Name = "Runtime";
            treeAnnotList.Add(__tmp92);
            SymbolAnnotation __tmp93 = new SymbolAnnotation();
            __tmp93.SymbolType = typeof(Runtime);
            treeAnnotList.Add(__tmp93);
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
            PropertyAnnotation __tmp94 = new PropertyAnnotation();
            __tmp94.Name = "Assemblies";
            treeAnnotList.Add(__tmp94);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolUseAnnotation __tmp95 = new SymbolUseAnnotation();
                __tmp95.Value = node;
                elemAnnotList.Add(__tmp95);
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
            PropertyAnnotation __tmp96 = new PropertyAnnotation();
            __tmp96.Name = "Databases";
            treeAnnotList.Add(__tmp96);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolUseAnnotation __tmp97 = new SymbolUseAnnotation();
                __tmp97.Value = node;
                elemAnnotList.Add(__tmp97);
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
            SymbolAnnotation __tmp98 = new SymbolAnnotation();
            __tmp98.SymbolType = typeof(Binding);
            treeAnnotList.Add(__tmp98);
            this.HandleSymbolType(context);
            return base.VisitBindingDeclaration(context);
        }
        
        public override object VisitBindingBody(SoalParser.BindingBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp99 = new BodyAnnotation();
            treeAnnotList.Add(__tmp99);
            this.HandleSymbolType(context);
            return base.VisitBindingBody(context);
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
            PropertyAnnotation __tmp100 = new PropertyAnnotation();
            __tmp100.Name = "Transport";
            treeAnnotList.Add(__tmp100);
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
            SymbolAnnotation __tmp101 = new SymbolAnnotation();
            __tmp101.SymbolType = typeof(HttpTransportBindingElement);
            treeAnnotList.Add(__tmp101);
            this.HandleSymbolType(context);
            return base.VisitHttpTransportLayer(context);
        }
        
        public override object VisitHttpTransportLayerEmptyBody(SoalParser.HttpTransportLayerEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp102 = new BodyAnnotation();
            treeAnnotList.Add(__tmp102);
            this.HandleSymbolType(context);
            return base.VisitHttpTransportLayerEmptyBody(context);
        }
        
        public override object VisitHttpTransportLayerNonEmptyBody(SoalParser.HttpTransportLayerNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp103 = new BodyAnnotation();
            treeAnnotList.Add(__tmp103);
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
            SymbolAnnotation __tmp104 = new SymbolAnnotation();
            __tmp104.SymbolType = typeof(RestTransportBindingElement);
            treeAnnotList.Add(__tmp104);
            this.HandleSymbolType(context);
            return base.VisitRestTransportLayer(context);
        }
        
        public override object VisitRestTransportLayerEmptyBody(SoalParser.RestTransportLayerEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp105 = new BodyAnnotation();
            treeAnnotList.Add(__tmp105);
            this.HandleSymbolType(context);
            return base.VisitRestTransportLayerEmptyBody(context);
        }
        
        public override object VisitRestTransportLayerNonEmptyBody(SoalParser.RestTransportLayerNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp106 = new BodyAnnotation();
            treeAnnotList.Add(__tmp106);
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
            SymbolAnnotation __tmp107 = new SymbolAnnotation();
            __tmp107.SymbolType = typeof(WebSocketTransportBindingElement);
            treeAnnotList.Add(__tmp107);
            this.HandleSymbolType(context);
            return base.VisitWebSocketTransportLayer(context);
        }
        
        public override object VisitWebSocketTransportLayerEmptyBody(SoalParser.WebSocketTransportLayerEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp108 = new BodyAnnotation();
            treeAnnotList.Add(__tmp108);
            this.HandleSymbolType(context);
            return base.VisitWebSocketTransportLayerEmptyBody(context);
        }
        
        public override object VisitWebSocketTransportLayerNonEmptyBody(SoalParser.WebSocketTransportLayerNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp109 = new BodyAnnotation();
            treeAnnotList.Add(__tmp109);
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
            PropertyAnnotation __tmp110 = new PropertyAnnotation();
            __tmp110.Name = "Ssl";
            treeAnnotList.Add(__tmp110);
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
            PropertyAnnotation __tmp111 = new PropertyAnnotation();
            __tmp111.Name = "ClientAuthentication";
            treeAnnotList.Add(__tmp111);
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
            PropertyAnnotation __tmp112 = new PropertyAnnotation();
            __tmp112.Name = "Encodings";
            treeAnnotList.Add(__tmp112);
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
            SymbolAnnotation __tmp113 = new SymbolAnnotation();
            __tmp113.SymbolType = typeof(SoapEncodingBindingElement);
            treeAnnotList.Add(__tmp113);
            this.HandleSymbolType(context);
            return base.VisitSoapEncodingLayer(context);
        }
        
        public override object VisitSoapEncodingLayerEmptyBody(SoalParser.SoapEncodingLayerEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp114 = new BodyAnnotation();
            treeAnnotList.Add(__tmp114);
            this.HandleSymbolType(context);
            return base.VisitSoapEncodingLayerEmptyBody(context);
        }
        
        public override object VisitSoapEncodingLayerNonEmptyBody(SoalParser.SoapEncodingLayerNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp115 = new BodyAnnotation();
            treeAnnotList.Add(__tmp115);
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
            SymbolAnnotation __tmp116 = new SymbolAnnotation();
            __tmp116.SymbolType = typeof(XmlEncodingBindingElement);
            treeAnnotList.Add(__tmp116);
            this.HandleSymbolType(context);
            return base.VisitXmlEncodingLayer(context);
        }
        
        public override object VisitXmlEncodingLayerEmptyBody(SoalParser.XmlEncodingLayerEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp117 = new BodyAnnotation();
            treeAnnotList.Add(__tmp117);
            this.HandleSymbolType(context);
            return base.VisitXmlEncodingLayerEmptyBody(context);
        }
        
        public override object VisitXmlEncodingLayerNonEmptyBody(SoalParser.XmlEncodingLayerNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp118 = new BodyAnnotation();
            treeAnnotList.Add(__tmp118);
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
            SymbolAnnotation __tmp119 = new SymbolAnnotation();
            __tmp119.SymbolType = typeof(JsonEncodingBindingElement);
            treeAnnotList.Add(__tmp119);
            this.HandleSymbolType(context);
            return base.VisitJsonEncodingLayer(context);
        }
        
        public override object VisitJsonEncodingLayerEmptyBody(SoalParser.JsonEncodingLayerEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp120 = new BodyAnnotation();
            treeAnnotList.Add(__tmp120);
            this.HandleSymbolType(context);
            return base.VisitJsonEncodingLayerEmptyBody(context);
        }
        
        public override object VisitJsonEncodingLayerNonEmptyBody(SoalParser.JsonEncodingLayerNonEmptyBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp121 = new BodyAnnotation();
            treeAnnotList.Add(__tmp121);
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
            PropertyAnnotation __tmp122 = new PropertyAnnotation();
            __tmp122.Name = "Version";
            treeAnnotList.Add(__tmp122);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                EnumValueAnnotation __tmp123 = new EnumValueAnnotation();
                __tmp123.EnumType = typeof(SoapVersion);
                elemAnnotList.Add(__tmp123);
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
            PropertyAnnotation __tmp124 = new PropertyAnnotation();
            __tmp124.Name = "Mtom";
            treeAnnotList.Add(__tmp124);
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
            PropertyAnnotation __tmp125 = new PropertyAnnotation();
            __tmp125.Name = "Style";
            treeAnnotList.Add(__tmp125);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                EnumValueAnnotation __tmp126 = new EnumValueAnnotation();
                __tmp126.EnumType = typeof(SoapEncodingStyle);
                elemAnnotList.Add(__tmp126);
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
            PropertyAnnotation __tmp127 = new PropertyAnnotation();
            __tmp127.Name = "Protocols";
            treeAnnotList.Add(__tmp127);
            this.HandleSymbolType(context);
            return base.VisitProtocolLayer(context);
        }
        
        public override object VisitProtocolLayerKind(SoalParser.ProtocolLayerKindContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitProtocolLayerKind(context);
        }
        
        public override object VisitWsAddressing(SoalParser.WsAddressingContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp128 = new SymbolAnnotation();
            __tmp128.SymbolType = typeof(WsAddressingBindingElement);
            treeAnnotList.Add(__tmp128);
            this.HandleSymbolType(context);
            return base.VisitWsAddressing(context);
        }
        
        public override object VisitEndpointDeclaration(SoalParser.EndpointDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp129 = new SymbolAnnotation();
            __tmp129.SymbolType = typeof(Endpoint);
            treeAnnotList.Add(__tmp129);
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp130 = new PropertyAnnotation();
                __tmp130.Name = "Interface";
                elemAnnotList.Add(__tmp130);
                SymbolUseAnnotation __tmp131 = new SymbolUseAnnotation();
                __tmp131.Value = node;
                elemAnnotList.Add(__tmp131);
            }
            this.HandleSymbolType(context);
            return base.VisitEndpointDeclaration(context);
        }
        
        public override object VisitEndpointBody(SoalParser.EndpointBodyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            BodyAnnotation __tmp132 = new BodyAnnotation();
            treeAnnotList.Add(__tmp132);
            this.HandleSymbolType(context);
            return base.VisitEndpointBody(context);
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
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp133 = new PropertyAnnotation();
                __tmp133.Name = "Binding";
                elemAnnotList.Add(__tmp133);
                NameUseAnnotation __tmp134 = new NameUseAnnotation();
                __tmp134.SymbolTypes.Add(typeof(Binding));
                elemAnnotList.Add(__tmp134);
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
                PropertyAnnotation __tmp135 = new PropertyAnnotation();
                __tmp135.Name = "Address";
                elemAnnotList.Add(__tmp135);
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
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolUseAnnotation __tmp136 = new SymbolUseAnnotation();
                elemAnnotList.Add(__tmp136);
            }
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
            List<object> elemAnnotList = null;
            if (context.qualifier() != null)
            {
                object elem = context.qualifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolUseAnnotation __tmp137 = new SymbolUseAnnotation();
                elemAnnotList.Add(__tmp137);
            }
            this.HandleSymbolType(context);
            return base.VisitReferenceType(context);
        }
        
        public override object VisitObjectType(SoalParser.ObjectTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolUseAnnotation __tmp138 = new SymbolUseAnnotation();
            treeAnnotList.Add(__tmp138);
            this.HandleSymbolType(context);
            return base.VisitObjectType(context);
        }
        
        public override object VisitValueType(SoalParser.ValueTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolUseAnnotation __tmp139 = new SymbolUseAnnotation();
            treeAnnotList.Add(__tmp139);
            this.HandleSymbolType(context);
            return base.VisitValueType(context);
        }
        
        public override object VisitVoidType(SoalParser.VoidTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolUseAnnotation __tmp140 = new SymbolUseAnnotation();
            treeAnnotList.Add(__tmp140);
            this.HandleSymbolType(context);
            return base.VisitVoidType(context);
        }
        
        public override object VisitOnewayType(SoalParser.OnewayTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolUseAnnotation __tmp141 = new SymbolUseAnnotation();
            treeAnnotList.Add(__tmp141);
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
                PropertyAnnotation __tmp142 = new PropertyAnnotation();
                __tmp142.Name = "Type";
                elemAnnotList.Add(__tmp142);
            }
            if (context.onewayType() != null)
            {
                object elem = context.onewayType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp143 = new PropertyAnnotation();
                __tmp143.Name = "Type";
                __tmp143.Value = SoalInstance.Void;
                elemAnnotList.Add(__tmp143);
                PropertyAnnotation __tmp144 = new PropertyAnnotation();
                __tmp144.Name = "IsOneway";
                __tmp144.Value = true;
                elemAnnotList.Add(__tmp144);
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
            SymbolCtrAnnotation __tmp145 = new SymbolCtrAnnotation();
            __tmp145.Value = node;
            treeAnnotList.Add(__tmp145);
            List<object> elemAnnotList = null;
            if (context.valueType() != null)
            {
                object elem = context.valueType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp146 = new PropertyAnnotation();
                __tmp146.Name = "InnerType";
                elemAnnotList.Add(__tmp146);
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
            SymbolCtrAnnotation __tmp147 = new SymbolCtrAnnotation();
            __tmp147.Value = node;
            treeAnnotList.Add(__tmp147);
            List<object> elemAnnotList = null;
            if (context.referenceType() != null)
            {
                object elem = context.referenceType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp148 = new PropertyAnnotation();
                __tmp148.Name = "InnerType";
                elemAnnotList.Add(__tmp148);
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
            SymbolCtrAnnotation __tmp149 = new SymbolCtrAnnotation();
            __tmp149.Value = node;
            treeAnnotList.Add(__tmp149);
            List<object> elemAnnotList = null;
            if (context.arrayType() != null)
            {
                object elem = context.arrayType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp150 = new PropertyAnnotation();
                __tmp150.Name = "InnerType";
                elemAnnotList.Add(__tmp150);
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
            SymbolCtrAnnotation __tmp151 = new SymbolCtrAnnotation();
            __tmp151.Value = node;
            treeAnnotList.Add(__tmp151);
            List<object> elemAnnotList = null;
            if (context.simpleType() != null)
            {
                object elem = context.simpleType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp152 = new PropertyAnnotation();
                __tmp152.Name = "InnerType";
                elemAnnotList.Add(__tmp152);
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
            SymbolCtrAnnotation __tmp153 = new SymbolCtrAnnotation();
            __tmp153.Value = node;
            treeAnnotList.Add(__tmp153);
            List<object> elemAnnotList = null;
            if (context.nulledType() != null)
            {
                object elem = context.nulledType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp154 = new PropertyAnnotation();
                __tmp154.Name = "InnerType";
                elemAnnotList.Add(__tmp154);
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
            this.HandleSymbolType(context);
            return base.VisitTypeofValue(context);
        }
        
        public override object VisitIdentifier(SoalParser.IdentifierContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            IdentifierAnnotation __tmp155 = new IdentifierAnnotation();
            treeAnnotList.Add(__tmp155);
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
            this.HandleSymbolType(context);
            return base.VisitLiteral(context);
        }
        
        public override object VisitNullLiteral(SoalParser.NullLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ValueAnnotation __tmp156 = new ValueAnnotation();
            treeAnnotList.Add(__tmp156);
            this.HandleSymbolType(context);
            return base.VisitNullLiteral(context);
        }
        
        public override object VisitBooleanLiteral(SoalParser.BooleanLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ValueAnnotation __tmp157 = new ValueAnnotation();
            treeAnnotList.Add(__tmp157);
            this.HandleSymbolType(context);
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitIntegerLiteral(SoalParser.IntegerLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ValueAnnotation __tmp158 = new ValueAnnotation();
            treeAnnotList.Add(__tmp158);
            this.HandleSymbolType(context);
            return base.VisitIntegerLiteral(context);
        }
        
        public override object VisitDecimalLiteral(SoalParser.DecimalLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ValueAnnotation __tmp159 = new ValueAnnotation();
            treeAnnotList.Add(__tmp159);
            this.HandleSymbolType(context);
            return base.VisitDecimalLiteral(context);
        }
        
        public override object VisitScientificLiteral(SoalParser.ScientificLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ValueAnnotation __tmp160 = new ValueAnnotation();
            treeAnnotList.Add(__tmp160);
            this.HandleSymbolType(context);
            return base.VisitScientificLiteral(context);
        }
        
        public override object VisitStringLiteral(SoalParser.StringLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ValueAnnotation __tmp161 = new ValueAnnotation();
            treeAnnotList.Add(__tmp161);
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
        
        public virtual object VisitName(SoalParser.NameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedName(SoalParser.QualifiedNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifier(SoalParser.QualifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifierList(SoalParser.IdentifierListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifierList(SoalParser.QualifierListContext context)
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
        
        public virtual object VisitAnnotationHead(SoalParser.AnnotationHeadContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationBody(SoalParser.AnnotationBodyContext context)
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
        
        public virtual object VisitNamespaceBody(SoalParser.NamespaceBodyContext context)
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
        
        public virtual object VisitEnumBody(SoalParser.EnumBodyContext context)
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
        
        public virtual object VisitStructBody(SoalParser.StructBodyContext context)
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
        
        public virtual object VisitDatabaseBody(SoalParser.DatabaseBodyContext context)
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
        
        public virtual object VisitInterfaceBody(SoalParser.InterfaceBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOperationDeclaration(SoalParser.OperationDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOperationHead(SoalParser.OperationHeadContext context)
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
        
        public virtual object VisitComponentBody(SoalParser.ComponentBodyContext context)
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
        
        public virtual object VisitCompositeBody(SoalParser.CompositeBodyContext context)
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
        
        public virtual object VisitDeploymentBody(SoalParser.DeploymentBodyContext context)
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
        
        public virtual object VisitEnvironmentBody(SoalParser.EnvironmentBodyContext context)
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
        
        public virtual object VisitBindingBody(SoalParser.BindingBodyContext context)
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
        
        public virtual object VisitWsAddressing(SoalParser.WsAddressingContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointDeclaration(SoalParser.EndpointDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointBody(SoalParser.EndpointBodyContext context)
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