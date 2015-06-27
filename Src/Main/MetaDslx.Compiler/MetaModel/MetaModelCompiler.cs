using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class NameDefAnnotation
    {
        public Type SymbolType { get; set; }
    }

    public class NameUseAnnotation
    {
        public NameUseAnnotation()
        {
            this.SymbolTypes = new List<Type>();
        }
        public List<Type> SymbolTypes { get; set; }
    }

    public class TypeDefAnnotation
    {
        public Type SymbolType { get; set; }
    }

    public class TypeUseAnnotation
    {
        public TypeUseAnnotation()
        {
            this.SymbolTypes = new List<Type>();
        }
        public List<Type> SymbolTypes { get; set; }
    }

    public class TypeCtrAnnotation
    {
        public TypeCtrAnnotation()
        {
            this.Scope = true;
        }
        public Type SymbolType { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class NameCtrAnnotation
    {
        public Type SymbolType { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class ScopeAnnotation
    {
    }

    public class IdentifierAnnotation
    {

    }

    public class NameAnnotation
    {

    }

    public class QualifiedNameAnnotation
    {

    }

    public class ValueAnnotation
    {
        private object value;
        public object Value
        {
            get { return this.value; }
            set { this.value = value; this.HasValue = true; }
        }
        public bool HasValue { get; set; }
    }

    public class PreDefSymbolAnnotation
    {
        private object value;
        public object Value
        {
            get { return this.value; }
            set { this.value = value; this.HasValue = true; }
        }
        public bool HasValue { get; set; }
    }

    public class SymbolAnnotation
    {
        public Type SymbolType { get; set; }
        public bool NoScope { get; set; }
    }

    public class PropertyAnnotation
    {
        public string Name { get; set; }
    }

    public class MetaModelCompiler : MetaCompiler
    {
        public MetaModelCompiler(string source, string fileName = null)
            : base(source, fileName)
        {
        }

        public override void Compile()
        {
            /*foreach (var type in MetaBuiltInType.Types)
            {
                this.GlobalScope.RegisterTypeDef(type.Name, type);
            }*/

            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new MetaModelLexer(inputStream);
            this.Lexer.AddErrorListener(this);
            CommonTokenStream commonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new MetaModelParser(commonTokenStream);
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
            /*MetaCompilerReferencePhase referencePhase = new MetaCompilerReferencePhase(this);
            referencePhase.VisitNode(this.ParseTree);*/
            /*MetaVisitorFirstPass firstPass = new MetaVisitorFirstPass(this);
            firstPass.Visit(this.ParseTree);*/
            /*MetaVisitorSecondPass secondPass = new MetaVisitorSecondPass(this);
            secondPass.Visit(this.ParseTree);*/

            /*MetaVisitorThirdPass thirdPass = new MetaVisitorThirdPass(this);
            thirdPass.Visit(this.ParseTree);
            MetaVisitorFourthPass fourthPass = new MetaVisitorFourthPass(this);
            fourthPass.Visit(this.ParseTree);*/

            /*var namespaces = this.GlobalScope.GetSymbols().OfType<MetaNamespace>().Distinct().ToList();
            MetaModelGenerator generator = new MetaModelGenerator(namespaces);
            this.GeneratedSource = generator.Generate();*/
        }

        public MetaModelParser.MainContext ParseTree { get; private set; }
        public MetaModelLexer Lexer { get; private set; }
        public MetaModelParser Parser { get; private set; }
        public CommonTokenStream CommonTokenStream { get; private set; }
        public string GeneratedSource { get; private set; }

        public override List<object> LexerAnnotations { get; protected set; }
        public override List<object> ParserAnnotations { get; protected set; }
        public override Dictionary<int, List<object>> ModeAnnotations { get; protected set; }
        public override Dictionary<int, List<object>> TokenAnnotations { get; protected set; }
        public override Dictionary<Type, List<object>> RuleAnnotations { get; protected set; }
        public override Dictionary<object, List<object>> TreeAnnotations { get; protected set; }
    }


    public class MetaCompilerPhase
    {
        public MetaCompiler Compiler { get; private set; }

        public MetaCompilerPhase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
        }
        public virtual void VisitNode(IParseTree node)
        {
            this.VisitChildren(node);
        }

        public virtual void VisitChildren(IParseTree node)
        {
            for (int i = 0; i < node.ChildCount; ++i)
            {
                this.VisitNode(node.GetChild(i));
            }
        }

        protected T GetAnnotationFor<T>(IParseTree tree)
        {
            if (tree == null) return default(T);
            return this.GetAnnotationsFor<T>(tree).FirstOrDefault();
        }

        protected IEnumerable<T> GetAnnotationsFor<T>(IParseTree tree)
        {
            if (tree == null) return new T[0];
            List<object> annotList;
            if (this.Compiler.TreeAnnotations.TryGetValue(tree, out annotList))
            {
                return annotList.OfType<T>();
            }
            return new T[0];
        }

        protected List<IParseTree> GetQualifiedNames(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(tree);
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(tree);
            if (qna != null || na != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetQualifiedNames(tree.GetChild(i)));
                }
            }
            return result;
        }

        protected List<IParseTree> GetNames(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            NameAnnotation ia = this.GetAnnotationFor<NameAnnotation>(tree);
            if (ia != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetNames(tree.GetChild(i)));
                }
            }
            return result;
        }
    }

    public class MetaCompilerDefinitionPhase : MetaCompilerPhase
    {
        private static List<object> emptySymbolList = new List<object>();

        public MetaCompilerDefinitionPhase(MetaCompiler compiler)
            : base(compiler)
        {
            this.ScopeStack = new List<Scope>();
            this.SymbolStack = new List<List<object>>();
            this.TypeCtrStack = new List<IParseTree>();
            this.NameCtrStack = new List<IParseTree>();
        }

        protected MetaCompilerData Data
        {
            get { return this.Compiler.Data; }
        }
        protected List<Scope> ScopeStack { get; private set; }
        protected List<List<object>> SymbolStack { get; private set; }
        protected List<IParseTree> TypeCtrStack { get; private set; }
        protected List<IParseTree> NameCtrStack { get; private set; }

        protected Scope CurrentScope
        {
            get
            {
                if (this.ScopeStack.Count > 0)
                {
                    return this.ScopeStack[this.ScopeStack.Count - 1];
                }
                else
                {
                    return this.Compiler.GlobalScope;
                }
            }
        }

        protected Scope ParentScope
        {
            get
            {
                if (this.ScopeStack.Count >= 2)
                {
                    return this.ScopeStack[this.ScopeStack.Count - 2];
                }
                else
                {
                    return this.Compiler.GlobalScope;
                }
            }
        }

        protected List<object> CurrentSymbols
        {
            get
            {
                if (this.SymbolStack.Count > 0)
                {
                    return this.SymbolStack[this.SymbolStack.Count - 1];
                }
                else
                {
                    return MetaCompilerDefinitionPhase.emptySymbolList;
                }
            }
        }

        protected IParseTree CurrentTypeCtr
        {
            get
            {
                if (this.TypeCtrStack.Count > 0)
                {
                    return this.TypeCtrStack[this.TypeCtrStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        protected IParseTree CurrentNameCtr
        {
            get
            {
                if (this.NameCtrStack.Count > 0)
                {
                    return this.NameCtrStack[this.NameCtrStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public override void VisitNode(IParseTree node)
        {
            Scope previousScope = this.CurrentScope;
            List<object> previousSymbols = this.CurrentSymbols;
            IParseTree previousTypeCtr = this.CurrentTypeCtr;
            IParseTree previousNameCtr = this.CurrentNameCtr;
            try
            {
                this.HandleConstructors(node);
                this.HandleScope(node);
                this.HandleDefinitions(node);
                this.HandleUses(node);
                base.VisitNode(node);
            }
            finally
            {
                if (this.CurrentScope != previousScope) this.ScopeStack.RemoveAt(this.ScopeStack.Count - 1);
                if (this.CurrentSymbols != previousSymbols) this.SymbolStack.RemoveAt(this.SymbolStack.Count - 1);
                if (this.CurrentTypeCtr != previousTypeCtr) this.TypeCtrStack.RemoveAt(this.TypeCtrStack.Count - 1);
                if (this.CurrentNameCtr != previousNameCtr) this.NameCtrStack.RemoveAt(this.NameCtrStack.Count - 1);
            }
        }

        protected virtual void HandleConstructors(IParseTree node)
        {
            SymbolAnnotation sa = this.GetAnnotationFor<SymbolAnnotation>(node);
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (tca != null || nca != null)
            {
                this.SymbolStack.Add(new List<object>());
            }
            Type symbolType = null;
            if (sa != null)
            {
                if (sa.SymbolType != null)
                {
                    symbolType = sa.SymbolType;
                }
            }
            if (tca != null && tca.SymbolType == null && nca != null && nca.SymbolType == null)
            {
                tca.SymbolType = symbolType;
                nca.SymbolType = symbolType;
            }
            else if (tca != null && tca.SymbolType == null)
            {
                if (nca != null)
                {
                    tca.SymbolType = nca.SymbolType;
                }
                else
                {
                    tca.SymbolType = symbolType;
                }
            }
            else if (nca != null && nca.SymbolType == null)
            {
                if (tca != null)
                {
                    nca.SymbolType = tca.SymbolType;
                }
                else
                {
                    nca.SymbolType = symbolType;
                }
            }
            if (tca != null)
            {
                if (tca.SymbolType == null)
                {
                    this.Compiler.Diagnostics.AddError("The symbol type cannot be determined for the type constructor.", this.Compiler.FileName, new TextSpan(node), true);
                }
                else
                {
                    this.TypeCtrStack.Add(node);
                }
            }
            if (nca != null)
            {
                if (nca.SymbolType == null)
                {
                    this.Compiler.Diagnostics.AddError("The symbol type cannot be determined for the name constructor.", this.Compiler.FileName, new TextSpan(node), true);
                }
                else
                {
                    this.NameCtrStack.Add(node);
                }
            }
            if (tca != null && tca.Scope && nca != null && nca.Scope && tca.SymbolType != nca.SymbolType)
            {
                this.Compiler.Diagnostics.AddError("If the type and name constructor have different symbol types then only one of them can be a scope. The scope will be assigned to the type.", this.Compiler.FileName, new TextSpan(node), true);
            }
            else if ((tca != null && tca.Scope) || (nca != null && nca.Scope))
            {
                this.ScopeStack.Add(new Scope(null));
            }
        }

        protected virtual void HandleScope(IParseTree node)
        {
            ScopeAnnotation sca = this.GetAnnotationFor<ScopeAnnotation>(node);
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (sca != null && (tca == null || tca.Scope == false) && (nca == null || nca.Scope == false))
            {
                this.ScopeStack.Add(new Scope(this.CurrentScope));
            }
        }

        protected virtual void HandleDefinitions(IParseTree node)
        {
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(this.CurrentTypeCtr);
            if (tda != null && tca == null)
            {
                this.Compiler.Diagnostics.AddError("The type constructor annotation is missing.", this.Compiler.FileName, new TextSpan(node), true);
            }
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(this.CurrentNameCtr);
            if (nda != null && nca == null)
            {
                this.Compiler.Diagnostics.AddError("The name constructor annotation is missing.", this.Compiler.FileName, new TextSpan(node), true);
            }
            if (tda == null && nda == null) return;
            string name = this.GetName(node);
            TypeDef typeDef = null;
            if (tda != null && tca != null && tca.Scope)
            {
                typeDef = new TypeDef(name, null);
                if (this.CurrentScope.Parent == null && this.ParentScope != this.CurrentScope)
                {
                    if (this.CurrentScope.Owner == null)
                    {
                        typeDef.Scope = this.CurrentScope;
                        typeDef.Scope.Owner = typeDef;
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("The current scope should not have an owner.", this.Compiler.FileName, new TextSpan(node), true);
                    }
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("The current scope should not have a parent scope.", this.Compiler.FileName, new TextSpan(node), true);
                }
            }
            NameDef nameDef = null;
            if (typeDef == null && nda != null && nca != null && nca.Scope)
            {
                nameDef = new NameDef(name, null);
                if (this.CurrentScope.Parent == null && this.ParentScope != this.CurrentScope)
                {
                    if (this.CurrentScope.Owner == null)
                    {
                        nameDef.Scope = this.CurrentScope;
                        nameDef.Scope.Owner = nameDef;
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("The current scope should not have an owner.", this.Compiler.FileName, new TextSpan(node), true);
                    }
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("The current scope should not have a parent scope.", this.Compiler.FileName, new TextSpan(node), true);
                }
            }
            if (tda != null && tca != null && (typeDef == null || typeDef.Scope == null))
            {
                if (typeDef == null)
                {
                    typeDef = new TypeDef(name, null);
                }
                if (nameDef != null && nameDef.Scope != null)
                {
                    this.TypeDef(this.CurrentTypeCtr, node, typeDef, this.ParentScope);
                }
                else
                {
                    this.TypeDef(this.CurrentTypeCtr, node, typeDef, this.CurrentScope);
                }
            }
            if (nda != null && nca != null && (nameDef == null || nameDef.Scope == null))
            {
                if (nameDef == null)
                {
                    nameDef = new NameDef(name, null);
                }
                if (typeDef != null && typeDef.Scope != null)
                {
                    this.NameDef(this.CurrentNameCtr, node, nameDef, this.ParentScope);
                }
                else
                {
                    this.NameDef(this.CurrentNameCtr, node, nameDef, this.CurrentScope);
                }
            }
            if (typeDef != null && typeDef.Scope != null)
            {
                this.TypeDef(this.CurrentTypeCtr, node, typeDef, this.ParentScope);
            }
            if (nameDef != null && nameDef.Scope != null)
            {
                this.NameDef(this.CurrentNameCtr, node, nameDef, this.ParentScope);
            }
        }

        protected virtual void HandleUses(IParseTree node)
        {
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null) return;
            string name = this.GetName(node);
            if (name == null) return;
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(node);
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(node);
            if (nua != null)
            {
                NameUse nameUse = new NameUse(name, null);
                this.NameUse(node, nameUse, this.CurrentScope);
            }
            else if (tua != null)
            {
                TypeUse typeUse = new TypeUse(name, null);
                this.TypeUse(node, typeUse, this.CurrentScope);
            }
        }

        protected virtual TypeDef TypeDef(IParseTree typeCtrNode, IParseTree typeDefNode, TypeDef typeDef, Scope parentScope)
        {
            parentScope.AddEntry(typeDef);
            return typeDef;
        }

        protected virtual NameDef NameDef(IParseTree nameCtrNode, IParseTree nameDefNode, NameDef nameDef, Scope parentScope)
        {
            parentScope.AddEntry(nameDef);
            return nameDef;
        }

        protected virtual TypeUse TypeUse(IParseTree typeUseNode, TypeUse typeUse, Scope parentScope)
        {
            parentScope.AddEntry(typeUse);
            return typeUse;
        }

        protected virtual NameUse NameUse(IParseTree nameUseNode, NameUse nameUse, Scope parentScope)
        {
            parentScope.AddEntry(nameUse);
            return nameUse;
        }

        private string GetName(IParseTree node)
        {
            if (node == null) return null;
            return node.GetText();
        }
    }
}