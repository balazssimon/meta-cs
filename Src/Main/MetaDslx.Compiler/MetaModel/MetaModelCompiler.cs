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
        public Type SymbolType { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool NoScope { get; set; }
    }

    public class NameCtrAnnotation
    {
        public Type SymbolType { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool NoScope { get; set; }
    }

    public class ScopeAnnotation
    {
    }

    public class IdentifierAnnotation
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
            MetaCompilerReferencePhase referencePhase = new MetaCompilerReferencePhase(this);
            referencePhase.VisitNode(this.ParseTree);
            /*MetaVisitorFirstPass firstPass = new MetaVisitorFirstPass(this);
            firstPass.Visit(this.ParseTree);*/
            MetaVisitorSecondPass secondPass = new MetaVisitorSecondPass(this);
            secondPass.Visit(this.ParseTree);

            /*MetaVisitorThirdPass thirdPass = new MetaVisitorThirdPass(this);
            thirdPass.Visit(this.ParseTree);
            MetaVisitorFourthPass fourthPass = new MetaVisitorFourthPass(this);
            fourthPass.Visit(this.ParseTree);*/

            var namespaces = this.GlobalScope.GetSymbols().OfType<MetaNamespace>().Distinct().ToList();
            MetaModelGenerator generator = new MetaModelGenerator(namespaces);
            this.GeneratedSource = generator.Generate();
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

    internal class MetaCompilerVisitor : MetaModelParserBaseVisitor<object>
    {
        protected MetaModelCompiler compiler;

        public MetaCompilerVisitor(MetaModelCompiler compiler)
        {
            this.compiler = compiler;
        }

        public Scope GetChildScope(Scope currentScope, IParseTree node)
        {
            if (currentScope == null) return null;
            if (node == null) return null;
            ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            if (sa != null || tda != null)
            {
                var nameDefNodes = this.GetNameDefs(node);
                if (nameDefNodes.Count != 1)
                {
                    return null;
                }
                else
                {
                    var qnameNodes = this.GetQualifiedNames(nameDefNodes[0]);
                    if (qnameNodes.Count != 1)
                    {
                        return null;
                    }
                    else
                    {
                        var names = this.GetIdentifiers(qnameNodes[0]);
                        Scope scope = currentScope;
                        for (int i = 0; i < names.Count; ++i)
                        {
                            scope = scope.GetScope(names[i]);
                            if (scope == null) return null;
                        }
                        return scope;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public List<IParseTree> GetNameDefs(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            for (int i = 0; i < tree.ChildCount; ++i)
            {
                IParseTree child = tree.GetChild(i);
                NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(child);
                if (nda != null)
                {
                    result.Add(child);
                }
            }
            return result;
        }

        public List<IParseTree> GetQualifiedNames(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(tree);
            IdentifierAnnotation ia = this.GetAnnotationFor<IdentifierAnnotation>(tree);
            if (qna != null || ia != null)
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

        public List<IParseTree> GetIdentifiers(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            IdentifierAnnotation ia = this.GetAnnotationFor<IdentifierAnnotation>(tree);
            if (ia != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetIdentifiers(tree.GetChild(i)));
                }
            }
            return result;
        }

        public List<IParseTree> GetTypeRefs(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            for (int i = 0; i < tree.ChildCount; ++i)
            {
                IParseTree child = tree.GetChild(i);
                TypeUseAnnotation tra = this.GetAnnotationFor<TypeUseAnnotation>(child);
                TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(child);
                if (tra != null || tca != null)
                {
                    result.Add(child);
                }
            }
            return result;
        }

        public T GetAnnotationFor<T>(IParseTree tree)
        {
            if (tree == null) return default(T);
            return this.GetAnnotationsFor<T>(tree).FirstOrDefault();
        }

        public IEnumerable<T> GetAnnotationsFor<T>(IParseTree tree)
        {
            if (tree == null) return new T[0];
            List<object> annotList;
            if (this.compiler.TreeAnnotations.TryGetValue(tree, out annotList))
            {
                return annotList.OfType<T>();
            }
            return new T[0];
        }
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
            IdentifierAnnotation ia = this.GetAnnotationFor<IdentifierAnnotation>(tree);
            if (qna != null || ia != null)
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

        protected List<IParseTree> GetIdentifiers(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            IdentifierAnnotation ia = this.GetAnnotationFor<IdentifierAnnotation>(tree);
            if (ia != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetIdentifiers(tree.GetChild(i)));
                }
            }
            return result;
        }
    }

    public class MetaCompilerDefinitionPhase : MetaCompilerPhase
    {
        public MetaCompilerDefinitionPhase(MetaCompiler compiler)
            : base(compiler)
        {
            this.ModelFactory = new ModelFactory();
            this.CurrentScope = this.Compiler.GlobalScope;
        }

        private int anonymousNameCounter = 0;
        private int anonymousTypeCounter = 0;

        protected Scope CurrentScope { get; set; }
        protected TypeConstructor CurrentTypeCtr { get; set; }
        protected IParseTree CurrentTypeCtrNode { get; set; }
        protected NameConstructor CurrentNameCtr { get; set; }
        protected IParseTree CurrentNameCtrNode { get; set; }
        protected Type CurrentSymbolType { get; set; }
        protected Type CurrentTypeSymbolType { get; set; }
        protected Type CurrentNameSymbolType { get; set; }
        protected List<object> CurrentSymbols { get; set; }
        protected List<object> CurrentTypeSymbols { get; set; }
        protected List<object> CurrentNameSymbols { get; set; }
        protected ModelFactory ModelFactory { get; private set; }

        public override void VisitNode(IParseTree node)
        {
            Scope previousScope = this.CurrentScope;
            Type previousSymbolType = this.CurrentSymbolType;
            Type previousTypeSymbolType = this.CurrentTypeSymbolType;
            Type previousNameSymbolType = this.CurrentNameSymbolType;
            List<object> previousSymbols = this.CurrentSymbols;
            List<object> previousTypeSymbols = this.CurrentTypeSymbols;
            List<object> previousNameSymbols = this.CurrentNameSymbols;
            TypeConstructor previousTypeCtr = this.CurrentTypeCtr;
            IParseTree previousTypeCtrNode = this.CurrentTypeCtrNode;
            NameConstructor previousNameCtr = this.CurrentNameCtr;
            IParseTree previousNameCtrNode = this.CurrentNameCtrNode;
            try
            {
                this.HandleSymbols(node);
                this.HandleScope(node);
                this.HandleNameUse(node);
                this.HandleTypeUse(node);
                this.HandleTypeDef(node);
                this.HandleNameDef(node);
                base.VisitNode(node);
                this.HandleAnonymousSymbols(node);
            }
            finally
            {
                this.CurrentNameCtrNode = previousNameCtrNode;
                this.CurrentNameCtr = previousNameCtr;
                this.CurrentTypeCtrNode = previousTypeCtrNode;
                this.CurrentTypeCtr = previousTypeCtr;
                this.CurrentNameSymbols = previousNameSymbols;
                this.CurrentTypeSymbols = previousTypeSymbols;
                this.CurrentSymbols = previousSymbols;
                this.CurrentSymbolType = previousSymbolType;
                this.CurrentNameSymbolType = previousNameSymbolType;
                this.CurrentTypeSymbolType = previousTypeSymbolType;
                this.CurrentScope = previousScope;
            }
        }

        protected virtual string GetAnonymousType()
        {
            ++this.anonymousTypeCounter;
            return "Type$" + this.anonymousTypeCounter;
        }

        protected virtual string GetAnonymousName()
        {
            ++this.anonymousNameCounter;
            return "Name$" + this.anonymousNameCounter;
        }

        protected virtual void HandleSymbols(IParseTree node)
        {
            PreDefSymbolAnnotation pdva = this.GetAnnotationFor<PreDefSymbolAnnotation>(node);
            if (pdva != null)
            {
                if (this.CurrentTypeCtr != null && this.CurrentTypeCtr.Symbol == null && pdva.HasValue)
                {
                    if (pdva.Value == null || this.CurrentTypeSymbolType.IsAssignableFrom(pdva.Value.GetType()))
                    {
                        this.TypeDef(node, node, null, pdva.Value);
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("Predefined value is not of type: " + this.CurrentTypeSymbolType.FullName, this.Compiler.FileName, new TextSpan(node), true);
                    }
                }
                if (this.CurrentNameCtr != null && this.CurrentNameCtr.Symbol == null && pdva.HasValue)
                {
                    if (pdva.Value == null || this.CurrentTypeSymbolType.IsAssignableFrom(pdva.Value.GetType()))
                    {
                        this.NameDef(node, node, null, pdva.Value);
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("Predefined value is not of type: " + this.CurrentTypeSymbolType.FullName, this.Compiler.FileName, new TextSpan(node), true);
                    }
                }
            }
            Type symbolType = null;
            SymbolAnnotation sa = this.GetAnnotationFor<SymbolAnnotation>(node);
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (sa != null || tca != null || nca != null)
            {
                this.CurrentSymbols = new List<object>();
                this.CurrentSymbolType = null;
                this.CurrentTypeSymbols = new List<object>();
                this.CurrentTypeSymbolType = null;
                this.CurrentNameSymbols = new List<object>();
                this.CurrentNameSymbolType = null;
                this.CurrentTypeCtr = null;
                this.CurrentNameCtr = null;
                this.CurrentTypeCtrNode = null;
                this.CurrentNameCtrNode = null;
            }
            if (sa != null)
            {
                symbolType = sa.SymbolType;
                this.CurrentSymbolType = symbolType;
            }
            if (tca != null)
            {
                if (tca.SymbolType != null)
                {
                    symbolType = tca.SymbolType;
                }
                if (symbolType != null)
                {
                    object symbol = this.Symbol(node, symbolType);
                    if (symbol != null)
                    {
                        this.CurrentTypeSymbols.Add(symbol);
                        if (tca != null)
                        {
                            this.CurrentTypeCtr = new TypeConstructor(null, symbolType, null);
                            this.CurrentTypeCtr.CanMerge = tca.Merge;
                            this.CurrentTypeCtr.CanOverload = tca.Overload;
                            this.CurrentTypeCtr.NoScope = tca.NoScope;
                            this.CurrentTypeCtrNode = node;
                            this.CurrentTypeSymbolType = symbolType;
                        }
                    }
                }
            }
            if (nca != null)
            {
                if (nca.SymbolType != null)
                {
                    symbolType = nca.SymbolType;
                }
                if (symbolType != null)
                {
                    object symbol = this.Symbol(node, symbolType);
                    if (symbol != null)
                    {
                        this.CurrentNameSymbols.Add(symbol);
                        if (nca != null)
                        {
                            this.CurrentNameCtr = new NameConstructor(null, symbolType, null);
                            this.CurrentNameCtr.CanMerge = nca.Merge;
                            this.CurrentNameCtr.CanOverload = nca.Overload;
                            this.CurrentNameCtr.NoScope = nca.NoScope;
                            this.CurrentNameCtrNode = node;
                            this.CurrentNameSymbolType = symbolType;
                        }
                    }
                }
            }
        }

        protected virtual void HandleScope(IParseTree node)
        {
            ScopeAnnotation sca = this.GetAnnotationFor<ScopeAnnotation>(node);
            if (sca != null)
            {
                Scope scope = null;
                if (this.CurrentNameCtr != null && !this.CurrentNameCtr.NoScope)
                {
                    scope = new Scope(null, null, this.CurrentNameCtr, this.CurrentScope);
                    this.CurrentNameCtr.Scope = scope;
                }
                if (this.CurrentTypeCtr != null && !this.CurrentTypeCtr.NoScope)
                {
                    if (scope != null)
                    {
                        this.Compiler.Diagnostics.AddError("Only one of the name and the type constructors can own the scope.", this.Compiler.FileName, new TextSpan(node), true);
                    }
                    else
                    {
                        scope = new Scope(null, null, this.CurrentTypeCtr, this.CurrentScope);
                        this.CurrentTypeCtr.Scope = scope;
                    }
                }
                if (scope == null)
                {
                    Type symbolType = null;
                    SymbolAnnotation sa = this.GetAnnotationFor<SymbolAnnotation>(node);
                    if (sa != null && !sa.NoScope)
                    {
                        symbolType = sa.SymbolType;
                        if (this.CurrentSymbols.Count != 1)
                        {
                            symbolType = null;
                        }
                        scope = new Scope(null, symbolType, null, this.CurrentScope);
                        if (this.CurrentSymbols.Count == 1)
                        {
                            scope.Symbol = this.CurrentSymbols[0];
                        }
                    }
                    else
                    {
                        scope = new Scope(null, null, null, this.CurrentScope);
                    }
                }
                if (scope != null)
                {
                    this.CurrentScope = scope;
                }
            }
        }

        protected virtual void HandleNameUse(IParseTree node)
        {
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(node);
            if (nua != null)
            {
                this.NameUse(node, nua);
            }
        }

        protected virtual void HandleTypeUse(IParseTree node)
        {
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(node);
            if (tua != null)
            {
                this.TypeUse(node, tua);
            }
        }

        protected virtual void HandleTypeDef(IParseTree node)
        {
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            if (tda != null)
            {
                var names = this.GetQualifiedNames(node);
                foreach (var name in names)
                {
                    var identifiers = this.GetIdentifiers(name);
                    if (identifiers.Count == 1)
                    {
                        this.TypeDef(identifiers[0], node, tda, null);
                    }
                    else if (identifiers.Count == 0)
                    {
                        this.TypeDef(null, node, tda, null);
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("The type definition name cannot be a qualified name: " + name.GetText(), this.Compiler.FileName, new TextSpan(name), true);
                    }
                }
            }
        }

        protected virtual void HandleNameDef(IParseTree node)
        {
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            if (nda != null)
            {
                var names = this.GetQualifiedNames(node);
                foreach (var name in names)
                {
                    this.NameDef(name, node, nda, null);
                }
            }
        }

        protected virtual object Symbol(IParseTree symbolNode, Type symbolType)
        {
            object symbol = null;
            try
            {
                symbol = this.ModelFactory.Create(symbolType);
                if (symbol == null)
                {
                    this.Compiler.Diagnostics.AddError("Could not create symbol: " + symbolType.FullName, this.Compiler.FileName, new TextSpan(symbolNode), true);
                }
            }
            catch (ModelException ex)
            {
                this.Compiler.Diagnostics.AddError("Could not create symbol: " + symbolType.FullName + ". " + ex.Message, this.Compiler.FileName, new TextSpan(symbolNode), true);
                symbol = null;
            }
            return symbol;
        }

        protected virtual void NameUse(IParseTree nameUseNode, NameUseAnnotation nameUseAnnotation)
        {
            this.CurrentScope.RegisterNameUse(GetNameUseName(nameUseNode, nameUseAnnotation), nameUseAnnotation.SymbolTypes, nameUseNode);
        }

        protected virtual void TypeUse(IParseTree typeUseNode, TypeUseAnnotation typeUseAnnotation)
        {
            this.CurrentScope.RegisterTypeUse(GetTypeUseName(typeUseNode, typeUseAnnotation), typeUseAnnotation.SymbolTypes, typeUseNode);
        }

        protected virtual void NameDef(IParseTree nameNode, IParseTree nameDefNode, NameDefAnnotation nameDefAnnotation, object preDefSymbol)
        {
            IParseTree targetNode = nameDefNode;
            if (nameNode != null)
            {
                targetNode = nameNode;
            }
            if (this.CurrentNameCtr == null)
            {
                this.Compiler.Diagnostics.AddError("The @NameCtr annotation is missing.", this.Compiler.FileName, new TextSpan(targetNode), true);
                return;
            }
            string name = GetNameDefName(nameNode, nameDefNode, nameDefAnnotation);
            ScopeEntry existingName = this.CurrentScope.GetName(name, this.CurrentNameSymbolType);
            NameDefinition nameDef = existingName as NameDefinition;
            object symbol = null;
            if (nameDef != null && this.MergeName(nameDef))
            {
                symbol = this.CurrentNameCtr.Symbol;
            }
            else
            {
                if (preDefSymbol == null)
                {
                    if (this.CurrentNameCtr.Symbol != null || this.CurrentNameSymbols.Count == 0)
                    {
                        symbol = this.Symbol(targetNode, this.CurrentNameSymbolType);
                        if (symbol != null)
                        {
                            this.CurrentNameSymbols.Add(symbol);
                        }
                    }
                    else
                    {
                        symbol = this.CurrentNameSymbols[0];
                    }
                    this.CurrentScope.RegisterNameDef(name, this.CurrentNameCtr, symbol, targetNode);
                }
                else
                {
                    symbol = preDefSymbol;
                    this.Compiler.GlobalScope.RegisterNameDef(name, this.CurrentNameCtr, symbol, targetNode);
                }
            }
        }

        protected virtual void TypeDef(IParseTree nameNode, IParseTree typeDefNode, TypeDefAnnotation typeDefAnnotation, object preDefSymbol)
        {
            IParseTree targetNode = typeDefNode;
            if (nameNode != null)
            {
                targetNode = nameNode;
            }
            if (this.CurrentTypeCtr == null)
            {
                this.Compiler.Diagnostics.AddError("The @TypeCtr annotation is missing.", this.Compiler.FileName, new TextSpan(targetNode), true);
                return;
            }
            string name = GetTypeDefName(nameNode, typeDefNode, typeDefAnnotation);
            TypeDefinition typeDef = this.CurrentScope.GetType(name, this.CurrentTypeSymbolType);
            object symbol = null;
            if (typeDef != null && this.MergeType(typeDef))
            {
                symbol = this.CurrentTypeCtr.Symbol;
            }
            else
            {
                if (preDefSymbol == null)
                {
                    if (this.CurrentTypeCtr.Symbol != null || this.CurrentTypeSymbols.Count == 0)
                    {
                        symbol = this.Symbol(targetNode, this.CurrentTypeSymbolType);
                        if (symbol != null)
                        {
                            this.CurrentTypeSymbols.Add(symbol);
                        }
                    }
                    else
                    {
                        symbol = this.CurrentTypeSymbols[0];
                    }
                    this.CurrentScope.RegisterTypeDef(name, this.CurrentTypeCtr, symbol, targetNode);
                }
                else
                {
                    symbol = preDefSymbol;
                    this.Compiler.GlobalScope.RegisterTypeDef(name, this.CurrentTypeCtr, symbol, targetNode);
                }
            }
        }

        protected virtual bool MergeName(NameDefinition nameDef)
        {
            if (this.CurrentNameCtr.CanOverload) return false;
            if (!this.CurrentNameCtr.CanMerge) return false;
            object symbol = null;
            Scope scope = null;
            foreach (var ctr in nameDef.Constructors)
            {
                if (!ctr.CanMerge)
                {
                    return false;
                }
                else
                {
                    if (ctr.Scope != null)
                    {
                        scope = ctr.Scope;
                    }
                    if (ctr.Symbol != null)
                    {
                        symbol = ctr.Symbol;
                    }
                }
            }
            if (scope != null)
            {
                this.CurrentNameCtr.Scope = scope;
            }
            else
            {
                scope = this.CurrentNameCtr.Scope;
            }
            if (symbol != null)
            {
                this.CurrentNameCtr.Symbol = symbol;
            }
            else
            {
                symbol = this.CurrentNameCtr.Symbol;
            }
            foreach (var ctr in nameDef.Constructors)
            {
                ctr.Scope = scope;
                ctr.Symbol = symbol;
            }
            return true;
        }

        protected virtual bool MergeType(TypeDefinition typeDef)
        {
            if (this.CurrentTypeCtr.CanOverload) return false;
            if (!this.CurrentTypeCtr.CanMerge) return false;
            object symbol = null;
            Scope scope = null;
            foreach (var ctr in typeDef.Constructors)
            {
                if (!ctr.CanMerge)
                {
                    return false;
                }
                else
                {
                    if (ctr.Scope != null)
                    {
                        scope = ctr.Scope;
                    }
                    if (ctr.Symbol != null)
                    {
                        symbol = ctr.Symbol;
                    }
                }
            }
            if (scope != null)
            {
                this.CurrentTypeCtr.Scope = scope;
            }
            else
            {
                scope = this.CurrentTypeCtr.Scope;
            }
            if (symbol != null)
            {
                this.CurrentTypeCtr.Symbol = symbol;
            }
            else
            {
                symbol = this.CurrentTypeCtr.Symbol;
            }
            foreach (var ctr in typeDef.Constructors)
            {
                ctr.Scope = scope;
                ctr.Symbol = symbol;
            }
            return true;
        }

        protected virtual string GetNameUseName(IParseTree nameUseNode, NameUseAnnotation nameUseAnnotation)
        {
            return nameUseNode.GetText();
        }

        protected virtual string GetTypeUseName(IParseTree typeUseNode, TypeUseAnnotation typeUseAnnotation)
        {
            return typeUseNode.GetText();
        }

        protected virtual string GetNameDefName(IParseTree nameNode, IParseTree nameDefNode, NameDefAnnotation nameDefAnnotation)
        {
            if (nameNode == null) return null;
            return nameNode.GetText();
        }

        protected virtual string GetTypeDefName(IParseTree nameNode, IParseTree typeDefNode, TypeDefAnnotation typeDefAnnotation)
        {
            if (nameNode == null) return null;
            return nameNode.GetText();
        }

        protected virtual void HandleAnonymousSymbols(IParseTree node)
        {
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (tca != null)
            {
                if (this.CurrentTypeCtr != null && this.CurrentTypeCtr.Symbol == null)
                {
                    this.TypeDef(null, node, null, null);
                }
            }
            if (nca != null)
            {
                if (this.CurrentNameCtr != null && this.CurrentNameCtr.Symbol == null)
                {
                    this.NameDef(null, node, null, null);
                }
            }
        }
    }

    public class MetaCompilerReferencePhase : MetaCompilerPhase
    {
        public MetaCompilerReferencePhase(MetaCompiler compiler)
            : base(compiler)
        {
            this.ModelFactory = new ModelFactory();
            this.CurrentScope = this.Compiler.GlobalScope;
            this.CurrentSymbols = new List<object>();
            this.CurrentProperties = new List<PropertyAnnotation>();
        }

        protected Scope CurrentScope { get; set; }
        protected List<object> CurrentSymbols { get; set; }
        protected ModelFactory ModelFactory { get; private set; }
        protected List<PropertyAnnotation> CurrentProperties { get; set; }

        public override void VisitNode(IParseTree node)
        {
            Scope previousScope = this.CurrentScope;
            List<object> previousSymbols = this.CurrentSymbols;
            List<PropertyAnnotation> previousProperties = this.CurrentProperties;
            try
            {
                this.HandleProperties(node);
                this.HandleValues(node);
                Scope scope = this.CurrentScope.GetScope(node);
                if (scope != null)
                {
                    this.CurrentScope = scope;
                }
                IEnumerable<object> symbols = this.Compiler.GlobalScope.GetSymbolByNode(node);
                if (symbols != null)
                {
                    this.CurrentSymbols = new List<object>(symbols);
                }
                base.VisitNode(node);
            }
            finally
            {
                this.CurrentProperties = previousProperties;
                this.CurrentSymbols = previousSymbols;
                this.CurrentScope = previousScope;
            }
        }

        protected virtual void HandleProperties(IParseTree node)
        {
            var pal = this.GetAnnotationsFor<PropertyAnnotation>(node).ToList();
            if (pal.Count > 0)
            {
                this.CurrentProperties = pal;
            }
        }

        protected virtual void HandleValues(IParseTree node)
        {
            ValueAnnotation va = this.GetAnnotationFor<ValueAnnotation>(node);
            if (va != null && va.HasValue)
            {
                foreach (var symbol in this.CurrentSymbols)
                {
                    ModelObject mo = symbol as ModelObject;
                    if (mo != null)
                    {
                        foreach (var pa in this.CurrentProperties)
                        {
                            if (pa.Name != null)
                            {
                                ModelProperty prop = mo.MFindProperty(pa.Name);
                                if (prop != null)
                                {
                                    mo.MAdd(prop, va.Value);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                IEnumerable<object> symbols = this.Compiler.GlobalScope.GetSymbolByNode(node);
                if (symbols != null)
                {
                    foreach (var symbol in this.CurrentSymbols)
                    {
                        ModelObject mo = symbol as ModelObject;
                        if (mo != null)
                        {
                            foreach (var pa in this.CurrentProperties)
                            {
                                if (pa.Name != null)
                                {
                                    ModelProperty prop = mo.MFindProperty(pa.Name);
                                    if (prop != null)
                                    {
                                        foreach (var sym in symbols)
                                        {
                                            mo.MAdd(prop, sym);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected virtual object ToValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            if (value.Length >= 2 && value.StartsWith("'") && value.EndsWith("'"))
            {
                StringBuilder sb = new StringBuilder();
                value = value.Substring(1, value.Length - 2);
                for (int i = 0; i < value.Length; ++i)
                {
                    if (i + 1 < value.Length && value[i] == '\\')
                    {
                        sb.Append(value[i]);
                        ++i;
                        sb.Append(value[i]);
                    }
                    else if (value[i] == '"')
                    {
                        sb.Append("\\" + value[i]);
                    }
                    else
                    {
                        sb.Append(value[i]);
                    }
                }
                value = '"' + sb.ToString() + '"';
                return this.Unescape(value);
            }
            else if (value == "true" || value == "false")
            {
                return value == "true";
            }
            else
            {
                bool isIdentifier = char.IsLetter(value[0]) || value[0] == '_';
                int dotCount = 0;
                int i = 1;
                while (isIdentifier && i < value.Length)
                {
                    isIdentifier = isIdentifier && (char.IsLetterOrDigit(value[i]) || value[i] == '_' || value[i] == '.');
                    if (value[i] == '.') ++dotCount;
                    ++i;
                }
                if (isIdentifier)
                {
                    return value;
                }
                else if (dotCount > 0)
                {
                    double d;
                    double.TryParse(value, out d);
                    return d;
                }
                else
                {
                    long l;
                    long.TryParse(value, out l);
                    return l;
                }
            }
        }

        protected string Unescape(string txt)
        {
            if (string.IsNullOrEmpty(txt)) { return txt; }
            StringBuilder retval = new StringBuilder(txt.Length);
            for (int ix = 0; ix < txt.Length; )
            {
                int jx = txt.IndexOf('\\', ix);
                if (jx < 0 || jx == txt.Length - 1) jx = txt.Length;
                retval.Append(txt, ix, jx - ix);
                if (jx >= txt.Length) break;
                switch (txt[jx + 1])
                {
                    case 'n': retval.Append('\n'); break;  // Line feed
                    case 'r': retval.Append('\r'); break;  // Carriage return
                    case 't': retval.Append('\t'); break;  // Tab
                    case '\\': retval.Append('\\'); break; // Don't escape
                    default:                                 // Unrecognized, copy as-is
                        retval.Append('\\').Append(txt[jx + 1]); break;
                }
                ix = jx + 2;
            }
            return retval.ToString();
        }
    }

    
    internal class MetaVisitorSecondPass : MetaCompilerVisitor
    {
        private Scope global;
        private Scope currentScope;

        public MetaVisitorSecondPass(MetaModelCompiler compiler)
            : base(compiler)
        {
            this.global = compiler.GlobalScope;
            this.currentScope = this.global;
        }

        public override object VisitChildren(IRuleNode node)
        {
            if (node == null) return null;
            /*
            Scope previousScope = currentScope;
            ScopeEntry entry = this.currentScope.GetEntryByNode(node);
            if (entry is Scope)
            {
                currentScope = entry as Scope;
            }
            if (entry is TypeConstructor)
            {
                this.compiler.Diagnostics.AddError("TODO: type constructor.", compiler.FileName, new TextSpan(node));
            }
            else if (entry is TypeReference)
            {
                TypeReference tr = entry as TypeReference;
                TypeDefinition td = currentScope.GetType(tr.Name, tr.SymbolType);
                if (td != null)
                {
                    tr.Symbol = td.Symbol;
                }
                else
                {
                    this.compiler.Diagnostics.AddError("Could not resolve type.", compiler.FileName, new TextSpan(node));
                }
            }
            else if (entry is NameReference)
            {
                NameReference nr = entry as NameReference;
                ScopeEntry se = currentScope.GetName(nr.Name, nr.SymbolType);
                if (se != null)
                {
                    nr.Symbol = se.Symbol;
                }
                else
                {
                    this.compiler.Diagnostics.AddError("Could not resolve name.", compiler.FileName, new TextSpan(node));
                }
            }
            base.VisitChildren(node);
            currentScope = previousScope;*/
            return null;
        }
    }
/*
    internal class MetaMofVisitorTypeRef : MetaModelParserBaseVisitor<TypeDefinition>
    {
        private MetaModelCompiler compiler;
        private Scope global;
        private Scope currentScope;
        private int position;
        private List<Type> kind;

        public MetaMofVisitorTypeRef(MetaModelCompiler compiler, Scope global, Scope currentScope, int position, List<Type> kind)
        {
            this.compiler = compiler;
            this.global = global;
            this.currentScope = currentScope;
            this.position = position;
            this.kind = kind;
        }

        public override TypeDefinition VisitTypeReference(MetaModelParser.TypeReferenceContext context)
        {
            var typeRef = base.VisitTypeReference(context);
            if (typeRef == null)
            {
                return null;
            }
            else
            {
                return this.global.RegisterType(typeRef);
            }
        }

        public override TypeDefinition VisitPrimitiveType(MetaModelParser.PrimitiveTypeContext context)
        {
            return this.global.GetType(context.GetText(), this.kind);
        }

        public override TypeDefinition VisitObjectType(MetaModelParser.ObjectTypeContext context)
        {
            return this.global.GetType(context.GetText(), this.kind);
        }

        public override TypeDefinition VisitVoidType(MetaModelParser.VoidTypeContext context)
        {
            return this.global.GetType(context.GetText(), this.kind);
        }

        public override TypeDefinition VisitNullableType(MetaModelParser.NullableTypeContext context)
        {
            var innerType = this.Visit(context.primitiveType());
            if (context.TQuestion() != null)
            {
                var result = new TypeConstructor(innerType.Name + "?", typeof(MetaNullableType), this.global);
                result.TreeNodes.Add(context);
                var symbol = MetaFactory.Instance.CreateMetaNullableType();
                symbol.InnerType = (MetaType)innerType.Symbol;
                this.compiler.SymbolTable.RegisterSymbol(result, symbol);
            }
            return innerType;
        }

        public override TypeDefinition VisitCollectionType(MetaModelParser.CollectionTypeContext context)
        {
            var innerType = this.Visit(context.simpleType());
            MetaCollectionKind kind = MetaCollectionKind.List;
            if (context.collectionKind().KSet() != null)
            {
                kind = MetaCollectionKind.Set;
            }
            var result = new TypeConstructor(kind + "<" + innerType.Name + ">", typeof(MetaCollectionType), this.global);
            result.TreeNodes.Add(context);
            var symbol = MetaFactory.Instance.CreateMetaCollectionType();
            symbol.InnerType = (MetaType)innerType.Symbol;
            symbol.Kind = kind;
            this.compiler.SymbolTable.RegisterSymbol(result, symbol);
            //result.SymbolType = typeof(MetaCollectionType);
            return result;
        }

        public override TypeDefinition VisitSimpleType(MetaModelParser.SimpleTypeContext context)
        {
            if (context.qualifiedName() != null)
            {
                return this.currentScope.ResolveType(context.qualifiedName().identifier().Select(i => i.GetText()).ToList(), this.kind, this.position);
            }
            else
            {
                return base.VisitSimpleType(context);
            }
        }

        public override TypeDefinition VisitQualifiedName(MetaModelParser.QualifiedNameContext context)
        {
            return this.currentScope.ResolveType(context.identifier().Select(i => i.GetText()).ToList(), this.kind, this.position);
        }

        public override TypeDefinition VisitIdentifier(MetaModelParser.IdentifierContext context)
        {
            return this.currentScope.ResolveType(context.GetText(), this.kind, this.position);
        }
    }
    */
    /*
    internal class MetaVisitorThirdPass : MetaCompilerVisitor
    {
        private ModelObject currentObject;
        private Scope currentScope;

        public MetaVisitorThirdPass(MetaModelCompiler compiler)
            : base(compiler)
        {
            this.currentObject = null;
            this.currentScope = compiler.GlobalScope;
        }

        public override object VisitChildren(IRuleNode node)
        {
            ModelObject prevObject = this.currentObject;
            List<ScopeEntry> entries = null;
            this.compiler.ScopeEntries.TryGetValue(node, out entries);
            foreach (var ma in this.GetAnnotationsFor<MapAnnotation>(node))
            {
                if (ma.Type != null && ma.Property == null)
                {
                    if (entries != null)
                    {
                        ModelObject obj = MetaFactory.Instance.Create(ma.Type);
                        this.compiler.ModelObjects.Add(node, obj);
                        this.currentObject = obj;
                        foreach (var entry in entries)
                        {
                            entry.ModelObject = obj;
                        }
                    }
                    else
                    {
                        ModelObject obj = null;
                        var nameDefNodes = this.GetNameDefs(node);
                        foreach (var nameDef in nameDefNodes)
                        {
                            if (this.compiler.ScopeEntries.TryGetValue(nameDef, out entries))
                            {
                                obj = MetaFactory.Instance.Create(ma.Type);
                                this.compiler.ModelObjects.Add(nameDef, obj);
                                this.currentObject = obj;
                                foreach (var entry in entries)
                                {
                                    entry.ModelObject = obj;
                                }
                            }
                        }
                        if (obj != null)
                        {
                            this.compiler.ModelObjects.Add(node, obj);
                        }
                    }
                }
            }
            return base.VisitChildren(node);
        }
    }

    internal class MetaVisitorFourthPass : MetaCompilerVisitor
    {
        private ModelObject currentObject;
        private ModelProperty currentProperty;
        private Scope currentScope;

        public MetaVisitorFourthPass(MetaModelCompiler compiler)
            : base(compiler)
        {
            this.currentObject = null;
            this.currentProperty = null;
            this.currentScope = compiler.GlobalScope;
        }

        public override object VisitChildren(IRuleNode node)
        {
            ModelObject prevObject = this.currentObject;
            ModelProperty prevProperty = this.currentProperty;

            ModelObject modelObject = null;
            this.compiler.ModelObjects.TryGetValue(node, out modelObject);
            
            foreach (var ma in this.GetAnnotationsFor<MapAnnotation>(node))
            {
                if (ma.Type == null)
                {
                    if (this.currentObject == null)
                    {
                        this.compiler.Diagnostics.AddWarning("There is no current model object. The @Map annotation is ignored.", this.compiler.FileName, new TextSpan(node));
                    }
                    else
                    {
                        if (ma.Object != null)
                        {
                            object obj = ma.Object;
                            IParseTree nodeValue = obj as IParseTree;
                            if (nodeValue != null)
                            {
                                obj = this.TreeNodeToModelObject(nodeValue);
                            }
                            ModelObject mobj = obj as ModelObject;
                            if (mobj != null)
                            {
                                this.currentObject = mobj;
                            }
                            else if (obj != null)
                            {
                                this.currentObject = null;
                                this.compiler.Diagnostics.AddError("The referenced object ("+obj.GetType()+") is not an instance of '" + typeof(ModelObject) + "'.", this.compiler.FileName, new TextSpan(node));
                            }
                            else
                            {
                                this.currentObject = null;
                            }
                        }
                        if (this.currentObject != null)
                        {
                            if (ma.Property != null)
                            {
                                ModelProperty prop = this.currentObject.MFindProperty(ma.Property);
                                this.currentProperty = prop;
                                if (prop == null)
                                {
                                    this.compiler.Diagnostics.AddWarning("Could not find property '" + ma.Property + "' for '" + this.currentObject + "'.", this.compiler.FileName, new TextSpan(node));
                                }
                            }
                            if (this.currentProperty != null)
                            {
                                if (ma.HasValue)
                                {
                                    object value = ma.Value;
                                    IParseTree nodeValue = value as IParseTree;
                                    if (nodeValue != null)
                                    {
                                        value = this.TreeNodeToModelObject(nodeValue);
                                    }
                                    this.currentObject.MAdd(this.currentProperty, value);
                                }
                                else if (this.currentProperty.Type.IsPrimitive || this.currentProperty.Type.IsValueType || this.currentProperty.Type.IsEnum || this.currentProperty.Type == typeof(string))
                                {
                                    string text = node.GetText();
                                    ScopeEntry entry = this.TreeNodeToScopeEntry(node);
                                    if (entry != null && entry.Name != null)
                                    {
                                        text = entry.Name;
                                    }
                                    this.currentObject.MAdd(this.currentProperty, text);
                                }
                                else if (modelObject != null)
                                {
                                    this.currentObject.MAdd(this.currentProperty, modelObject);
                                }
                                else
                                {
                                    ScopeEntry entry = this.TreeNodeToScopeEntry(node);
                                    if (entry != null && entry.ModelObject != null)
                                    {
                                        this.currentObject.MAdd(this.currentProperty, entry.ModelObject);
                                    }
                                }
                            }
                        }
                        if (ma.Object != null && ma.Property != null)
                        {
                            this.currentProperty = prevProperty;
                        }
                    }
                }
            }
            foreach (var ma in this.GetAnnotationsFor<MapAnnotation>(node))
            {
                ModelObject mobj = null;
                if (ma.Type != null && ma.Property == null && this.compiler.ModelObjects.TryGetValue(node, out mobj))
                {
                    this.currentObject = mobj;
                    base.VisitChildren(node);
                    this.currentObject = prevObject;
                    this.currentProperty = prevProperty;
                    return null;
                }
            }
            base.VisitChildren(node);
            this.currentObject = prevObject;
            this.currentProperty = prevProperty;
            return null;
        }

        private ScopeEntry TreeNodeToScopeEntry(IParseTree node)
        {
            List<ScopeEntry> entries = null;
            if (this.compiler.ScopeEntries.TryGetValue(node, out entries))
            {
                foreach (var entry in entries)
                {
                    NameReference nr = entry as NameReference;
                    if (nr != null && nr.NameDef != null)
                    {
                        return nr.NameDef;
                    }
                    TypeReference tr = entry as TypeReference;
                    if (tr != null && tr.TypeDef != null)
                    {
                        return tr.TypeDef;
                    }
                }
                return entries.FirstOrDefault();
            }
            return null;
        }

        private ModelObject TreeNodeToModelObject(IParseTree node)
        {
            ModelObject mobj = null;
            if (!this.compiler.ModelObjects.TryGetValue(node, out mobj))
            {
                List<ScopeEntry> entries = null;
                if (this.compiler.ScopeEntries.TryGetValue(node, out entries))
                {
                    List<ModelObject> mobjs = entries.Where(e => e.ModelObject != null).Select(e => e.ModelObject).ToList();
                    if (mobjs.Count == 0)
                    {
                        foreach (var entry in entries)
                        {
                            NameReference nr = entry as NameReference;
                            if (nr != null && nr.NameDef != null && nr.NameDef.ModelObject != null)
                            {
                                mobjs.Add(nr.NameDef.ModelObject);
                            }
                            TypeReference tr = entry as TypeReference;
                            if (tr != null && tr.TypeDef != null && tr.TypeDef.ModelObject != null)
                            {
                                mobjs.Add(tr.TypeDef.ModelObject);
                            }
                        }
                    }
                    if (mobjs.Count == 1)
                    {
                        return mobjs[0];
                    }
                    else if (mobjs.Count == 0)
                    {
                        this.compiler.Diagnostics.AddError("Could not map the tree node to a model object.", this.compiler.FileName, new TextSpan(node));
                    }
                    else
                    {
                        this.compiler.Diagnostics.AddError("There are multiple model objects that can be mapped from the tree node.", this.compiler.FileName, new TextSpan(node));
                    }
                }
                else
                {
                    this.compiler.Diagnostics.AddError("Could not map the tree node to a model object.", this.compiler.FileName, new TextSpan(node));
                }
            }
            return mobj;
        }
    }*/
}

/*
if (currentScope != null)
{
    TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(node);
    if (tua != null)
    {
        TypeReference typeRef = currentScope.GetChild(node) as TypeReference;
        if (typeRef != null)
        {
            MetaMofVisitorTypeRef typeUseVisitor = null;
            ScopeAnnotation psa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
            TypeDefAnnotation ptda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
            if (psa != null || ptda != null)
            {
                if (currentScope.Parent != null)
                {
                    typeUseVisitor = new MetaMofVisitorTypeRef(compiler, global, currentScope.Parent, currentScope.Position, tua.SymbolTypes);
                }
            }
            if (typeUseVisitor == null)
            {
                typeUseVisitor = new MetaMofVisitorTypeRef(compiler, global, currentScope, typeRef.Position, tua.SymbolTypes);
            }
            TypeDefinition typeDef = typeUseVisitor.Visit(node);
            if (typeDef == null)
            {
                this.compiler.Diagnostics.AddError("Could not resolve type.", compiler.FileName, new TextSpan(node));
            }
            else
            {
                typeRef.TypeDef = typeDef;
                ScopeAnnotation npsa = null;
                TypeDefAnnotation nptda = null;
                if (node.Parent != null)
                {
                    npsa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
                    nptda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
                }
                var nameDefNodes = this.GetNameDefs(node.Parent);
                if (currentScope != null && node.Parent != null && nameDefNodes.Count > 0 && npsa == null && nptda == null)
                {
                    foreach (var nameDefNode in nameDefNodes)
                    {
                        var qnameNodes = this.GetQualifiedNames(nameDefNode);
                        foreach (var qnameNode in qnameNodes)
                        {
                            var identifiers = this.GetIdentifiers(qnameNode);
                            if (identifiers.Count == 0)
                            {
                                this.compiler.Diagnostics.AddError("The element has no name.", compiler.FileName, new TextSpan(qnameNode));
                            }
                            else if (identifiers.Count == 1)
                            {
                                foreach (var identifier in identifiers)
                                {
                                    NameDefinition nameDef = currentScope.GetChild(qnameNode) as NameDefinition;
                                    if (nameDef == null)
                                    {
                                        this.compiler.Diagnostics.AddError("Could not resolve name in second pass.", compiler.FileName, new TextSpan(identifier));
                                    }
                                    else
                                    {
                                        nameDef.Type = typeDef;
                                    }
                                }
                            }
                            else
                            {
                                this.compiler.Diagnostics.AddError("Qualified names must be defined as scopes.", compiler.FileName, new TextSpan(qnameNode));
                            }
                        }
                    }
                }
            }
        }
        else
        {
            this.compiler.Diagnostics.AddError("Could not resolve type reference in second pass.", compiler.FileName, new TextSpan(node));
        }
    }
    NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(node);
    if (nua != null)
    {
        var names = this.GetQualifiedNames(node);
        foreach (var name in names)
        {
            NameReference nameRef = currentScope.GetChild(name) as NameReference;
            if (nameRef != null)
            {
                var identifiers = this.GetIdentifiers(name);
                foreach (var identifier in identifiers)
                {
                    var identifiersText = identifiers.Select(id => id.GetText()).ToList();
                    ScopeEntry nameDef = null;
                    if (currentScope != null)
                    {
                        ScopeAnnotation psa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
                        TypeDefAnnotation ptda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
                        if (psa != null || ptda != null)
                        {
                            if (currentScope.Parent != null)
                            {
                                nameDef = currentScope.Parent.ResolveName(identifiersText, nua.SymbolTypes, currentScope.Position);
                            }
                            else
                            {
                                nameDef = null;
                            }
                        }
                        else
                        {
                            nameDef = currentScope.ResolveName(identifiersText, nua.SymbolTypes, nameRef.Position);
                        }
                    }
                    if (nameDef != null)
                    {
                        nameRef.NameDef = nameDef;
                    }
                    else
                    {
                        this.compiler.Diagnostics.AddError("Could not resolve name.", compiler.FileName, new TextSpan(name));
                    }
                }
            }
            else
            {
                this.compiler.Diagnostics.AddError("Could not resolve name reference in second pass.", compiler.FileName, new TextSpan(node));
            }
        }
    }
}
ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
if (sa != null || tda != null)
{
    Scope previousScope = currentScope;
    Scope scope = this.GetChildScope(currentScope, node);
    if (scope != null)
    {
        currentScope = scope;
    }
    else
    {
        this.compiler.Diagnostics.AddError("Could not find scope in second pass.", compiler.FileName, new TextSpan(node));
    }
    base.VisitChildren(node);
    currentScope = previousScope;
}
else
{
    base.VisitChildren(node);
}*/
