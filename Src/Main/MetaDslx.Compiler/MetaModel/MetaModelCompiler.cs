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
    public class ArgumentList { }
    public enum MetaOperatorKind
    {

    }


    public class TypeDefAnnotation
    {
        public TypeDefAnnotation()
        {
            this.Scope = true;
        }
        public Type SymbolType { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class NameDefAnnotation
    {
        public string NestingProperty { get; set; }
        public Type SymbolType { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class NameUseAnnotation
    {
        public NameUseAnnotation()
        {
            this.SymbolTypes = new List<Type>();
        }
        public List<Type> SymbolTypes { get; set; }
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
        }
        public Type SymbolType { get; set; }
    }

    public class NameCtrAnnotation
    {
        public NameCtrAnnotation()
        {
        }
        public Type SymbolType { get; set; }
    }

    public class ScopeAnnotation
    {
    }

    public class InheritScopeAnnotation
    {

    }

    public class IdentifierAnnotation
    {

    }

    public class NameAnnotation
    {

    }

    public class TypeAnnotation
    {

    }

    public class QualifiedNameAnnotation
    {

    }

    public class ExpressionAnnotation
    {

    }

    public class StatementAnnotation
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

    public class AutoSymbolAnnotation
    {

    }

    public class PropertyAnnotation
    {
        private object value;

        public List<Type> SymbolTypes { get; set; }
        public string Name { get; set; }
        public object Value
        {
            get { return this.value; }
            set { this.value = value; this.HasValue = true; }
        }
        public bool HasValue { get; set; }
    }

    public class MetaModelCompiler : MetaCompiler
    {
        public MetaModelCompiler(string source, string fileName = null)
            : base(source, fileName)
        {
        }

        public override void Compile()
        {
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
            MetaModelParserPropertyEvaluator propertyEvaluator = new MetaModelParserPropertyEvaluator(this);
            propertyEvaluator.Visit(this.ParseTree);

            var metamodels = this.Data.GetSymbols().OfType<MetaModel>().Distinct().ToList();
            MetaModelGenerator generator = new MetaModelGenerator(metamodels);
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

    public class MetaCompilerPhase
    {
        public static readonly Type[] ScopeBoundaryAnnotations =
            new Type[]
            { 
                typeof(TypeDefAnnotation),
                typeof(NameDefAnnotation),
                typeof(TypeCtrAnnotation),
                typeof(NameCtrAnnotation),
                typeof(TypeUseAnnotation),
                typeof(NameUseAnnotation),
                typeof(ScopeAnnotation),
                typeof(ExpressionAnnotation),
            };

        public static readonly Type[] SymbolBoundaryAnnotations =
            new Type[]
            { 
                typeof(TypeDefAnnotation),
                typeof(NameDefAnnotation),
                typeof(TypeCtrAnnotation),
                typeof(NameCtrAnnotation),
                typeof(ScopeAnnotation),
                typeof(SymbolAnnotation),
                typeof(PreDefSymbolAnnotation),
            };

        public static readonly Type[] NameKindAnnotations =
            new Type[]
            { 
                typeof(TypeDefAnnotation),
                typeof(NameDefAnnotation),
                typeof(TypeUseAnnotation),
                typeof(NameUseAnnotation),
                typeof(ScopeAnnotation),
                typeof(ExpressionAnnotation),
            };

        public static readonly Type[] VisitBoundaryAnnotations =
            new Type[]
            { 
                typeof(NameAnnotation),
                typeof(QualifiedNameAnnotation),
            };

        public MetaCompiler Compiler { get; private set; }
        protected ModelFactory ModelFactory { get; private set; }

        public MetaCompilerPhase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
            this.ModelFactory = new ModelFactory();
        }
        public virtual void VisitNode(IParseTree node)
        {
            try
            {
                this.VisitChildren(node);
            }
            catch(Exception ex)
            {
                this.Compiler.Diagnostics.AddError(ex.ToString(), this.Compiler.FileName, new TextSpan(node), true);
            }
        }

        public virtual void VisitChildren(IParseTree node)
        {
            for (int i = 0; i < node.ChildCount; ++i)
            {
                this.VisitNode(node.GetChild(i));
            }
        }

        protected virtual bool IsScopeBoundary(IParseTree node)
        {
            foreach (var type in MetaCompilerPhase.ScopeBoundaryAnnotations)
            {
                object annot = this.GetAnnotationFor(node, type);
                if (annot != null)
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual bool IsSymbolBoundary(IParseTree node)
        {
            foreach (var type in MetaCompilerPhase.SymbolBoundaryAnnotations)
            {
                object annot = this.GetAnnotationFor(node, type);
                if (annot != null)
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual bool IsVisitBoundary(IParseTree node)
        {
            foreach (var type in MetaCompilerPhase.VisitBoundaryAnnotations)
            {
                object annot = this.GetAnnotationFor(node, type);
                if (annot != null)
                {
                    return true;
                }
            }
            return false;
        }

        protected object GetAnnotationFor(IParseTree tree, Type annotationType)
        {
            if (tree == null) return null;
            if (annotationType == null) return null;
            return this.GetAnnotationsFor(tree, annotationType).FirstOrDefault();
        }

        protected T GetAnnotationFor<T>(IParseTree tree)
        {
            if (tree == null) return default(T);
            return this.GetAnnotationsFor<T>(tree).FirstOrDefault();
        }

        protected IEnumerable<object> GetAnnotationsFor(IParseTree tree, Type annotationType)
        {
            if (tree == null) return new object[0];
            if (annotationType == null) return new object[0];
            List<object> annotList;
            if (this.Compiler.TreeAnnotations.TryGetValue(tree, out annotList))
            {
                return annotList.Where(a => annotationType.IsAssignableFrom(a.GetType()));
            }
            return new object[0];
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

        protected List<IParseTree> GetPreDefSymbol(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            PreDefSymbolAnnotation pdsa = this.GetAnnotationFor<PreDefSymbolAnnotation>(tree);
            if (pdsa != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetPreDefSymbol(tree.GetChild(i)));
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
            this.ScopeRestoreStack = new List<int>();
            this.NameKindStack = new List<IParseTree>();
            this.NameKindRestoreStack = new List<int>();
        }

        protected MetaCompilerData Data
        {
            get { return this.Compiler.Data; }
        }

        protected List<int> ScopeRestoreStack { get; private set; }
        protected List<Scope> ScopeStack { get; private set; }
        protected List<int> NameKindRestoreStack { get; private set; }
        protected List<IParseTree> NameKindStack { get; private set; }

        protected int CurrentScopeRestoreCount
        {
            get
            {
                if (this.ScopeRestoreStack.Count > 0)
                {
                    return this.ScopeRestoreStack[this.ScopeRestoreStack.Count - 1];
                }
                else
                {
                    return 0;
                }
            }
        }
        
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

        protected int CurrentNameKindRestoreCount
        {
            get
            {
                if (this.NameKindRestoreStack.Count > 0)
                {
                    return this.NameKindRestoreStack[this.NameKindRestoreStack.Count - 1];
                }
                else
                {
                    return 0;
                }
            }
        }

        protected IParseTree CurrentNameKind
        {
            get
            {
                if (this.NameKindStack.Count > 0)
                {
                    return this.NameKindStack[this.NameKindStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public override void VisitNode(IParseTree node)
        {
            int previousScopeStackCount = this.ScopeStack.Count;
            bool scopeBoundary = this.IsScopeBoundary(node);
            bool visitBoundary = this.IsVisitBoundary(node);
            this.NameKindRestoreStack.Add(this.NameKindStack.Count);
            try
            {
                this.HandleNameKinds(node);
                this.HandleNames(node);
                if (scopeBoundary)
                {
                    this.ScopeRestoreStack.Add(previousScopeStackCount);
                }
                if (!visitBoundary)
                {
                    base.VisitNode(node);
                }
            }
            finally
            {
                int restoreCount = 0;
                if (scopeBoundary)
                {
                    restoreCount = this.CurrentScopeRestoreCount;
                    this.ScopeStack.RemoveRange(restoreCount, this.ScopeStack.Count - restoreCount);
                    this.ScopeRestoreStack.RemoveAt(this.ScopeRestoreStack.Count - 1);
                }
                restoreCount = this.CurrentNameKindRestoreCount;
                this.NameKindStack.RemoveRange(restoreCount, this.NameKindStack.Count - restoreCount);
                this.NameKindRestoreStack.RemoveAt(this.NameKindRestoreStack.Count - 1);
            }
        }

        protected virtual void HandleNameKinds(IParseTree node)
        {
            List<SymbolAnnotation> syal = this.GetAnnotationsFor<SymbolAnnotation>(node).ToList();
            foreach (var sya in syal)
            {
                ModelObject symbol = this.ModelFactory.Create(sya.SymbolType);
                if (symbol != null)
                {
                    this.Symbol(node, symbol);
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Could not create symbol: "+sya.SymbolType, this.Compiler.FileName, new TextSpan(node), true);
                }
            }

            int counter = 0;
            foreach (var type in MetaCompilerPhase.NameKindAnnotations)
            {
                object annot = this.GetAnnotationFor(node, type);
                if (annot != null)
                {
                    ++counter;
                }
            }
            if (counter == 0) return;
            if (counter > 1)
            {
                this.Compiler.Diagnostics.AddError("A node can have at most one of the following annotations: @TypeDef, @NameDef, @TypeUse, @NameUse, @Scope, @Expression.", this.Compiler.FileName, new TextSpan(node), true);
            }
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
            if (tda != null)
            {
                if (tda.SymbolType == null)
                {
                    this.Compiler.Diagnostics.AddError("The symbol type cannot be determined for the type definition.", this.Compiler.FileName, new TextSpan(node), true);
                }
                else
                {
                    if (tda.Scope)
                    {
                        this.ScopeStack.Add(new Scope(null));
                    }
                }
            }
            if (nda != null)
            {
                if (nda.SymbolType == null)
                {
                    this.Compiler.Diagnostics.AddError("The symbol type cannot be determined for the name definition.", this.Compiler.FileName, new TextSpan(node), true);
                }
                else
                {
                    if (nda.Scope)
                    {
                        this.ScopeStack.Add(new Scope(null));
                    }
                }
            }
            if (sa != null && (tda == null || tda.Scope == false) && (nda == null || nda.Scope == false))
            {
                Scope scope = new Scope(this.CurrentScope);
                this.Scope(node, scope);
            }
            this.NameKindStack.Add(node);
        }

        protected virtual bool HandleNames(IParseTree node)
        {
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null) return true;
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(this.CurrentNameKind);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(this.CurrentNameKind);
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(this.CurrentNameKind);
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(this.CurrentNameKind);
            if (tda != null)
            {
                if (qna != null)
                {
                    this.Compiler.Diagnostics.AddError("The type name cannot be a @QualifiedName.", this.Compiler.FileName, new TextSpan(node), true);
                }
                string name = this.GetName(node);
                if (name != null)
                {
                    TypeDef typeDef = new TypeDef(name, null);
                    if (tda.Scope)
                    {
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
                    this.TypeDef(tda, this.CurrentNameKind, node, typeDef, this.ParentScope, true);
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Could not get a name from the node.", this.Compiler.FileName, new TextSpan(node), true);
                }
            }
            if (nda != null)
            {
                if (nda.Scope)
                {
                    if (!nda.Scope)
                    {
                        this.Compiler.Diagnostics.AddError("A qualified name must define a scope.", this.Compiler.FileName, new TextSpan(node), true);
                    }
                    else
                    {
                        List<IParseTree> names = this.GetNames(node);
                        Scope innermostScope = null;
                        if (this.CurrentScope.Parent == null && this.CurrentScope.Owner == null)
                        {
                            innermostScope = this.CurrentScope;
                            this.ScopeStack.Remove(innermostScope);
                        }
                        else
                        {
                            this.Compiler.Diagnostics.AddError("The current scope should not have a parent scope or an owner.", this.Compiler.FileName, new TextSpan(node), true);
                        }
                        for (int i = 0; i < names.Count; ++i)
                        {
                            string currentName = this.GetName(names[i]);
                            if (currentName != null)
                            {
                                NameDef nameDef = new NameDef(currentName, null);
                                if (innermostScope != null && i == names.Count - 1)
                                {
                                    nameDef.Scope = innermostScope;
                                    nameDef.Scope.Owner = nameDef;
                                    this.Scope(names[i], nameDef.Scope);
                                    this.NameDef(nda, this.CurrentNameKind, names[i], nameDef, this.ParentScope, true);
                                }
                                else
                                {
                                    nameDef.Scope = new Scope(null);
                                    nameDef.Scope.Owner = nameDef;
                                    this.Scope(names[i], nameDef.Scope);
                                    this.NameDef(nda, this.CurrentNameKind, names[i], nameDef, this.ParentScope, false);
                                }
                            }
                            else
                            {
                                this.Compiler.Diagnostics.AddError("Could not get a name from the node.", this.Compiler.FileName, new TextSpan(node), true);
                            }
                        }
                    }
                }
                else
                {
                    if (qna != null)
                    {
                        this.Compiler.Diagnostics.AddError("A qualified name must define a scope.", this.Compiler.FileName, new TextSpan(node), true);
                    }
                    string name = this.GetName(node);
                    if (name != null)
                    {
                        NameDef nameDef = new NameDef(name, null);
                        this.NameDef(nda, this.CurrentNameKind, node, nameDef, this.CurrentScope, true);
                    }
                }
            }
            if (tua != null)
            {
                TypeUse typeUse = new TypeUse(null, null);
                this.TypeUse(node, typeUse, this.CurrentScope);
            }
            if (nua != null)
            {
                NameUse nameUse = new NameUse(null, null);
                this.NameUse(node, nameUse, this.CurrentScope);
            }
            this.NameKindStack.Add(node);
            return false;
        }

        protected virtual void Scope(IParseTree node, Scope scope)
        {
            this.ScopeStack.Add(scope);
            if (scope.Parent != null)
            {
                this.Compiler.Data.RegisterEntry(node, scope);
            }
        }

        protected virtual void TypeDef(TypeDefAnnotation typeDefAnnotation, IParseTree typeDefNode, IParseTree nameNode, TypeDef typeDef, Scope parentScope, bool registerSymbol)
        {
            TypeDef targetTypeDef = null;
            if (this.MergeTypeDef(typeDefAnnotation, typeDefNode, nameNode, typeDef, parentScope, out targetTypeDef))
            {
                targetTypeDef.CanMerge = true;
                if (targetTypeDef.Scope != null)
                {
                    this.ScopeStack.Remove(typeDef.Scope);
                    this.ScopeStack.Add(targetTypeDef.Scope);
                    targetTypeDef.Scope.Merge(typeDef.Scope);
                }
                else if (typeDef.Scope != null)
                {
                    targetTypeDef.Scope = typeDef.Scope;
                    targetTypeDef.Scope.Owner = targetTypeDef;
                }
                this.Compiler.Data.RegisterEntry(typeDefNode, targetTypeDef);
                if (registerSymbol)
                {
                    this.Compiler.Data.RegisterSymbol(typeDefNode, targetTypeDef.Symbol, targetTypeDef);
                }
            }
            else
            {
                typeDef.CanMerge = typeDefAnnotation.Merge;
                parentScope.AddEntry(typeDef);
                this.Compiler.Data.RegisterEntry(typeDefNode, typeDef);
                this.TypeDefSymbol(typeDefAnnotation, typeDefNode, nameNode, typeDef, registerSymbol);
            }
        }

        protected virtual void NameDef(NameDefAnnotation nameDefAnnotation, IParseTree nameDefNode, IParseTree nameNode, NameDef nameDef, Scope parentScope, bool registerSymbol)
        {
            NameDef targetNameDef = null;
            if (this.MergeNameDef(nameDefAnnotation, nameDefNode, nameNode, nameDef, parentScope, out targetNameDef))
            {
                targetNameDef.CanMerge = true;
                if (targetNameDef.Scope != null)
                {
                    this.ScopeStack.Remove(nameDef.Scope);
                    this.ScopeStack.Add(targetNameDef.Scope);
                    targetNameDef.Scope.Merge(nameDef.Scope);
                }
                else if (nameDef.Scope != null)
                {
                    targetNameDef.Scope = nameDef.Scope;
                    targetNameDef.Scope.Owner = targetNameDef;
                }
                this.Compiler.Data.RegisterEntry(nameDefNode, targetNameDef);
                if (registerSymbol)
                {
                    this.Compiler.Data.RegisterSymbol(nameDefNode, targetNameDef.Symbol, targetNameDef);
                }
            }
            else
            {
                nameDef.CanMerge = nameDefAnnotation.Merge;
                parentScope.AddEntry(nameDef);
                this.Compiler.Data.RegisterEntry(nameDefNode, nameDef);
                this.NameDefSymbol(nameDefAnnotation, nameDefNode, nameNode, nameDef, registerSymbol);
            }
        }

        protected virtual void TypeUse(IParseTree typeUseNode, TypeUse typeUse, Scope parentScope)
        {
            parentScope.AddEntry(typeUse);
            this.Compiler.Data.RegisterEntry(typeUseNode, typeUse);
        }

        protected virtual void NameUse(IParseTree nameUseNode, NameUse nameUse, Scope parentScope)
        {
            parentScope.AddEntry(nameUse);
            this.Compiler.Data.RegisterEntry(nameUseNode, nameUse);
        }

        protected virtual bool MergeTypeDef(TypeDefAnnotation typeDefAnnotation, IParseTree typeDefNode, IParseTree nameNode, TypeDef typeDef, Scope parentScope, out TypeDef targetTypeDef)
        {
            targetTypeDef = null;
            List<object> result = this.Compiler.ResolutionProvider.Resolve(new object[] { parentScope }, ResolveKind.Type, typeDef.Name, new ScopeResolutionInfo() { SymbolTypes = new Type[] { typeDef.SymbolType } }, ResolveFlags.Children).ToList();
            if (typeDefAnnotation.Merge && !typeDefAnnotation.Overload && result.Count == 1)
            {
                targetTypeDef = result[0] as TypeDef;
                return targetTypeDef != null && targetTypeDef.CanMerge;
            }
            return false;
        }

        protected virtual bool MergeNameDef(NameDefAnnotation nameDefAnnotation, IParseTree nameDefNode, IParseTree nameNode, NameDef nameDef, Scope parentScope, out NameDef targetNameDef)
        {
            targetNameDef = null;
            List<object> result = this.Compiler.ResolutionProvider.Resolve(new object[] { parentScope }, ResolveKind.Name, nameDef.Name, new ScopeResolutionInfo() { SymbolTypes = new Type[] { nameDef.SymbolType } }, ResolveFlags.Children).ToList();
            if (nameDefAnnotation.Merge && !nameDefAnnotation.Overload && result.Count == 1)
            {
                targetNameDef = result[0] as NameDef;
                return targetNameDef != null && targetNameDef.CanMerge;
            }
            return false;
        }

        protected virtual void TypeDefSymbol(TypeDefAnnotation typeDefAnnotation, IParseTree typeDefNode, IParseTree nameNode, TypeDef typeDef, bool registerSymbol)
        {
            if (typeDef == null) return;
            if (typeDefAnnotation == null || typeDefAnnotation.SymbolType == null) return;
            ModelObject symbol = this.ModelFactory.Create(typeDefAnnotation.SymbolType);
            if (symbol != null)
            {
                typeDef.Symbol = symbol;
                if (registerSymbol)
                {
                    this.Compiler.Data.RegisterSymbol(typeDefNode, symbol, typeDef);
                }
                else
                {
                    this.Compiler.Data.RegisterSymbol(null, symbol, typeDef);
                }
                string nameProperty = "Name";
                IEnumerable<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(nameNode);
                foreach (var pa in pas)
                {
                    if (pa.Name != null && !pa.HasValue && (pa.SymbolTypes == null || pa.SymbolTypes.Contains(typeDefAnnotation.SymbolType)))
                    {
                        nameProperty = pa.Name;
                    }
                }
                ModelProperty prop = symbol.MFindProperty(nameProperty);
                if (prop != null)
                {
                    symbol.MAdd(prop, typeDef.Name);
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Could not set the '" + nameProperty + "' property for the symbol '" + typeDef.SymbolType + "'.", this.Compiler.FileName, new TextSpan(nameNode));
                }
            }
        }

        protected virtual void NameDefSymbol(NameDefAnnotation nameDefAnnotation, IParseTree nameDefNode, IParseTree nameNode, NameDef nameDef, bool registerSymbol)
        {
            if (nameDef == null) return;
            if (nameDefAnnotation == null || nameDefAnnotation.SymbolType == null) return;
            ModelObject symbol = this.ModelFactory.Create(nameDefAnnotation.SymbolType);
            if (symbol != null)
            {
                nameDef.Symbol = symbol;
                if (registerSymbol)
                {
                    this.Compiler.Data.RegisterSymbol(nameDefNode, symbol, nameDef);
                }
                else
                {
                    this.Compiler.Data.RegisterSymbol(null, symbol, nameDef);
                }
                string nameProperty = "Name";
                IEnumerable<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(nameNode);
                foreach (var pa in pas)
                {
                    if (pa.Name != null && !pa.HasValue && (pa.SymbolTypes == null || pa.SymbolTypes.Contains(nameDef.SymbolType)))
                    {
                        nameProperty = pa.Name;
                    }
                }
                ModelProperty prop = symbol.MFindProperty(nameProperty);
                if (prop != null)
                {
                    symbol.MAdd(prop, nameDef.Name);
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Could not set the '" + nameProperty + "' property for the symbol '" + nameDef.SymbolType + "'.", this.Compiler.FileName, new TextSpan(nameNode));
                }
                if (nameDefAnnotation.NestingProperty != null && nameDef.Parent != null && nameDef.Parent.Owner != null && nameDef.Parent.Owner.Symbol != null)
                {
                    ModelObject mo = nameDef.Parent.Owner.Symbol as ModelObject;
                    if (mo != null)
                    {
                        prop = mo.MFindProperty(nameDefAnnotation.NestingProperty);
                        if (prop != null)
                        {
                            mo.MAdd(prop, symbol);
                        }
                    }
                }
            }
        }

        protected virtual void Symbol(IParseTree node, object symbol)
        {
            if (symbol != null)
            {
                this.Compiler.Data.RegisterSymbol(node, symbol, null);
            }
        }

        protected virtual string GetName(IParseTree node)
        {
            return this.Compiler.NameProvider.GetName(node);
        }
    }

    // TODO: properties, expressions, statements

    public class MetaCompilerReferencePhase : MetaCompilerPhase
    {
        private static List<object> emptySymbolList = new List<object>();

        public MetaCompilerReferencePhase(MetaCompiler compiler)
            : base(compiler)
        {
            this.RootSymbols = new List<object>();
            this.SymbolStack = new List<List<object>>();
            this.PropertyStack = new List<List<PropertyAnnotation>>();
            this.ConstructorSymbolStack = new List<object>();
        }

        public List<object> RootSymbols { get; private set; }
        protected List<List<object>> SymbolStack { get; private set; }
        protected List<List<PropertyAnnotation>> PropertyStack { get; private set; }
        protected List<object> ConstructorSymbolStack { get; private set; }

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
                    return this.RootSymbols;
                }
            }
        }

        protected List<object> ParentSymbols
        {
            get
            {
                if (this.SymbolStack.Count >= 2)
                {
                    return this.SymbolStack[this.SymbolStack.Count - 2];
                }
                else
                {
                    return this.RootSymbols;
                }
            }
        }

        protected List<PropertyAnnotation> CurrentProperties
        {
            get
            {
                if (this.PropertyStack.Count > 0)
                {
                    return this.PropertyStack[this.PropertyStack.Count - 1];
                }
                else
                {
                    return new List<PropertyAnnotation>();
                }
            }
        }

        protected List<PropertyAnnotation> ParentProperties
        {
            get
            {
                if (this.PropertyStack.Count >= 2)
                {
                    return this.PropertyStack[this.PropertyStack.Count - 2];
                }
                else
                {
                    return new List<PropertyAnnotation>();
                }
            }
        }

        protected object CurrentConstructorSymbol
        {
            get
            {
                if (this.ConstructorSymbolStack.Count > 0)
                {
                    return this.ConstructorSymbolStack[this.ConstructorSymbolStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public override void VisitNode(IParseTree node)
        {
            int previousPropertyStackCount = this.PropertyStack.Count;
            int previousConstructorSymbolStackCount = this.ConstructorSymbolStack.Count;
            bool visitBoundary = this.IsVisitBoundary(node);
            bool symbolBoundary = this.IsSymbolBoundary(node);
            try
            {
                if (symbolBoundary)
                {
                    this.SymbolStack.Add(new List<object>());
                }
                this.HandleSymbols(node);
                this.HandleConstructorSymbols(node);
                this.HandleUses(node);
                this.HandleProperties(node, symbolBoundary);
                if (!visitBoundary)
                {
                    base.VisitNode(node);
                }
                this.HandleConstructors(node);
                this.HandlePropertyValues(node, symbolBoundary);
            }
            finally
            {
                if (symbolBoundary)
                {
                    this.SymbolStack.RemoveAt(this.SymbolStack.Count - 1);
                }
                this.PropertyStack.RemoveRange(previousPropertyStackCount, this.PropertyStack.Count - previousPropertyStackCount);
                this.ConstructorSymbolStack.RemoveRange(previousConstructorSymbolStackCount, this.ConstructorSymbolStack.Count - previousConstructorSymbolStackCount);
            }
        }

        protected virtual void HandleSymbols(IParseTree node)
        {
            List<object> symbols = this.Compiler.Data.GetSymbols(node);
            foreach (var symbol in symbols)
            {
                if (!this.CurrentSymbols.Contains(symbol))
                {
                    this.CurrentSymbols.Add(symbol);
                }
            }
        }

        protected virtual void HandleConstructorSymbols(IParseTree node)
        {
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (tca != null && tda == null && nda == null)
            {
                object symbol = this.ModelFactory.Create(tca.SymbolType);
                if (symbol != null)
                {
                    this.CurrentSymbols.Add(symbol);
                    this.ConstructorSymbolStack.Add(symbol);
                }
                else
                {
                    this.ConstructorSymbolStack.Add(null);
                }
            }
            if (nca != null && tda == null && nda == null)
            {
                object symbol = this.ModelFactory.Create(nca.SymbolType);
                if (symbol != null)
                {
                    this.CurrentSymbols.Add(symbol);
                    this.ConstructorSymbolStack.Add(symbol);
                }
                else
                {
                    this.ConstructorSymbolStack.Add(null);
                }
            }
        }

        protected virtual void HandleProperties(IParseTree node, bool symbolBoundary)
        {
            ValueAnnotation va = this.GetAnnotationFor<ValueAnnotation>(node);
            if (va == null)
            {
                List<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(node).Where(pa => !pa.HasValue).ToList();
                if (pas.Count > 0)
                {
                    this.PropertyStack.Add(new List<PropertyAnnotation>());
                }
                foreach (var pa in pas)
                {
                    this.CurrentProperties.Add(pa);
                }
                if (pas.Count > 1)
                {
                    this.Compiler.Diagnostics.AddError("There are multiple properties defined for the node.", this.Compiler.FileName, new TextSpan(node), true);
                }
            }
            if (symbolBoundary)
            {
                this.PropertyStack.Add(new List<PropertyAnnotation>());
            }
        }

        protected virtual void HandlePropertyValues(IParseTree node, bool symbolBoundary)
        {
            List<object> targetSymbols = null;
            if (symbolBoundary || this.CurrentSymbols.Count == 0) targetSymbols = this.ParentSymbols;
            else targetSymbols = this.CurrentSymbols;

            List<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(node).ToList();
            ValueAnnotation va = this.GetAnnotationFor<ValueAnnotation>(node);
            foreach (var pa in pas)
            {
                if (pa.HasValue)
                {
                    object value = pa.Value;
                    IParseTree valueNode = value as IParseTree;
                    if (valueNode != null)
                    {
                        List<object> valueSymbols = this.Compiler.Data.GetSymbols(valueNode);
                        this.SetProperty(node, targetSymbols, pa, valueSymbols);
                    }
                    else
                    {
                        object eval = this.Evaluate(value);
                        this.SetProperty(node, targetSymbols, pa, new object[] { eval });
                    }
                }
                else if (va != null)
                {
                    if (va.HasValue)
                    {
                        object eval = this.Evaluate(va.Value);
                        this.SetProperty(node, targetSymbols, pa, new object[] { eval });
                    }
                    else
                    {
                        object eval = this.Evaluate(node);
                        this.SetProperty(node, targetSymbols, pa, new object[] { eval });
                    }
                }
                else if (symbolBoundary)
                {
                    List<object> valueSymbols = this.Compiler.Data.GetSymbols(node);
                    this.SetProperty(node, targetSymbols, pa, valueSymbols);
                }
            }

            List<PropertyAnnotation> spas = null;
            if (symbolBoundary) spas = this.ParentProperties;
            else spas = this.CurrentProperties;
            if (spas != null && spas.Count > 0)
            {
                if (va != null)
                {
                    if (va.HasValue)
                    {
                        object eval = this.Evaluate(va.Value);
                        foreach (var spa in spas)
                        {
                            this.SetProperty(node, targetSymbols, spa, new object[] { eval });
                        }
                    }
                    else
                    {
                        object eval = this.Evaluate(node);
                        foreach (var spa in spas)
                        {
                            this.SetProperty(node, targetSymbols, spa, new object[] { eval });
                        }
                    }
                }
                else if (symbolBoundary)
                {
                    List<object> valueSymbols = this.Compiler.Data.GetSymbols(node);
                    foreach (var spa in spas)
                    {
                        this.SetProperty(node, targetSymbols, spa, valueSymbols);
                    }
                }
                else
                {
                    List<object> valueSymbols = this.Compiler.Data.GetSymbols(node);
                    foreach (var spa in spas)
                    {
                        this.SetProperty(node, targetSymbols, spa, valueSymbols);
                    }
                }
            }
        }

        protected virtual void HandleUses(IParseTree node)
        {
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null) return;
            object preDefSymbol = null;
            if (na != null)
            {
                List<IParseTree> preDefSymbolNodes = this.GetPreDefSymbol(node);
                if (preDefSymbolNodes.Count == 1)
                {
                    PreDefSymbolAnnotation pdsa = this.GetAnnotationFor<PreDefSymbolAnnotation>(preDefSymbolNodes[0]);
                    if (pdsa != null)
                    {
                        preDefSymbol = pdsa.Value;
                        this.Compiler.Data.RegisterSymbol(node, preDefSymbol, null);
                    }
                }
                else if (preDefSymbolNodes.Count > 0)
                {
                    this.Compiler.Diagnostics.AddError("There are multiple predefined symbols for the node.", this.Compiler.FileName, new TextSpan(node));
                }
            }
            List<ScopeEntry> entries = this.Compiler.Data.GetEntries(node);
            foreach (var entry in entries)
            {
                NameUse nameUse = entry as NameUse;
                TypeUse typeUse = entry as TypeUse;
                if (nameUse != null)
                {
                    ScopeEntry currentEntry = entry;
                    Scope currentScope = entry.Parent;
                    List<IParseTree> names = this.GetNames(node);
                    if (names.Count == 1 && nameUse.Symbol == null && preDefSymbol != null)
                    {
                        nameUse.Name = this.GetName(names[0]);
                        nameUse.Symbol = preDefSymbol;
                        this.Compiler.Data.RegisterSymbol(node, nameUse.Symbol, null);
                        return;
                    }
                    for (int i = 0; i < names.Count; ++i)
                    {
                        string currentName = this.GetName(names[i]);
                        if (i == names.Count - 1)
                        {
                            nameUse.Name = currentName;
                        }
                        if (currentEntry != null && currentScope != null)
                        {
                            List<object> nameDefs = this.Compiler.ResolutionProvider.Resolve(new object[] { currentScope }, ResolveKind.NameOrType, currentName, new ScopeResolutionInfo() { Position = currentEntry.Position }, i == 0 ? ResolveFlags.All : ResolveFlags.Scope).ToList();
                            currentScope = null;
                            currentEntry = null;
                            if (nameDefs != null)
                            {
                                object boundSymbol = this.Compiler.BindingProvider.Bind(null, nameDefs, null);
                                if (boundSymbol != null)
                                {
                                    this.Compiler.Data.RegisterSymbol(names[i], boundSymbol, null);
                                    if (i == names.Count - 1)
                                    {
                                        nameUse.Symbol = boundSymbol;
                                        this.Compiler.Data.RegisterSymbol(node, nameUse.Symbol, null);
                                    }
                                    ScopeEntry boundEntry = this.Compiler.Data.GetEntry(boundSymbol);
                                    NameDef nameDef = boundEntry as NameDef;
                                    TypeDef typeDef = boundEntry as TypeDef;
                                    if (nameDef != null)
                                    {
                                        currentScope = nameDef.Scope;
                                    }
                                    if (typeDef != null)
                                    {
                                        currentScope = typeDef.Scope;
                                    }
                                    currentEntry = boundEntry;
                                }
                            }
                        }
                    }
                }
                if (typeUse != null)
                {
                    ScopeEntry currentEntry = entry;
                    Scope currentScope = entry.Parent;
                    List<IParseTree> names = this.GetNames(node);
                    if (names.Count == 1 && typeUse.Symbol == null && preDefSymbol != null)
                    {
                        typeUse.Name = this.GetName(names[0]);
                        typeUse.Symbol = preDefSymbol;
                        this.Compiler.Data.RegisterSymbol(node, typeUse.Symbol, null);
                        return;
                    }
                    for (int i = 0; i < names.Count; ++i)
                    {
                        string currentName = this.GetName(names[i]);
                        if (i == names.Count - 1)
                        {
                            typeUse.Name = currentName;
                        }
                        if (currentEntry != null && currentScope != null)
                        {
                            if (i == names.Count - 1)
                            {
                                List<object> typeDefs = this.Compiler.ResolutionProvider.Resolve(new object[] { currentScope }, ResolveKind.Type, currentName, new ScopeResolutionInfo() { Position = currentEntry.Position }, i == 0 ? ResolveFlags.All : ResolveFlags.Scope).ToList();
                                currentScope = null;
                                currentEntry = null;
                                if (typeDefs != null)
                                {
                                    object boundSymbol = this.Compiler.BindingProvider.Bind(null, typeDefs, null);
                                    if (boundSymbol != null)
                                    {
                                        this.Compiler.Data.RegisterSymbol(names[i], boundSymbol, null);
                                        typeUse.Symbol = boundSymbol;
                                        this.Compiler.Data.RegisterSymbol(node, typeUse.Symbol, null);
                                    }
                                }
                            }
                            else
                            {
                                List<object> nameDefs = this.Compiler.ResolutionProvider.Resolve(new object[] { currentScope }, ResolveKind.NameOrType, currentName, new ScopeResolutionInfo() { Position = currentEntry.Position }, i == 0 ? ResolveFlags.All : ResolveFlags.Scope).ToList();
                                currentScope = null;
                                currentEntry = null;
                                if (nameDefs != null)
                                {
                                    object boundSymbol = this.Compiler.BindingProvider.Bind(null, nameDefs, null);
                                    if (boundSymbol != null)
                                    {
                                        this.Compiler.Data.RegisterSymbol(names[i], boundSymbol, null);
                                        ScopeEntry boundEntry = this.Compiler.Data.GetEntry(boundSymbol);
                                        NameDef nameDef = boundEntry as NameDef;
                                        TypeDef typeDef = boundEntry as TypeDef;
                                        if (nameDef != null)
                                        {
                                            currentScope = nameDef.Scope;
                                        }
                                        if (typeDef != null)
                                        {
                                            currentScope = typeDef.Scope;
                                        }
                                        currentEntry = boundEntry;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return;
        }

        protected virtual void HandleConstructors(IParseTree node)
        {
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (nca != null && tda == null && nda == null)
            {
                object symbol = this.CurrentConstructorSymbol;
                this.ConstructorSymbolStack.RemoveAt(this.ConstructorSymbolStack.Count - 1);
                if (symbol != null)
                {
                    this.Compiler.Data.RegisterSymbol(node, symbol, null);
                }
            }
            if (tca != null && tda == null && nda == null)
            {
                object symbol = this.CurrentConstructorSymbol;
                this.ConstructorSymbolStack.RemoveAt(this.ConstructorSymbolStack.Count - 1);
                if (symbol != null)
                {
                    this.Compiler.Data.RegisterSymbol(node, symbol, null);
                }
            }
        }

        protected virtual void SetProperty(IParseTree node, List<object> symbols, PropertyAnnotation propertyAnnotation, IEnumerable<object> values)
        {
            if (symbols == null) return;
            if (values == null) return;
            foreach (var symbol in symbols)
            {
                bool symbolOK = symbol is ModelObject;
                if (symbolOK)
                {
                    symbolOK = false;
                    if (propertyAnnotation.SymbolTypes == null || propertyAnnotation.SymbolTypes.Count == 0)
                    {
                        symbolOK = true;
                    }
                    else
                    {
                        foreach (var symbolType in propertyAnnotation.SymbolTypes)
                        {
                            if (symbolType.IsAssignableFrom(symbol.GetType()))
                            {
                                symbolOK = true;
                                break;
                            }
                        }
                    }
                }
                if (symbolOK)
                {
                    ModelObject mo = symbol as ModelObject;
                    ModelProperty prop = mo.MFindProperty(propertyAnnotation.Name);
                    if (prop != null)
                    {
                        foreach (var value in values)
                        {
                            if (value != null)
                            {
                                if (prop.IsAssignableFrom(value.GetType()))
                                {
                                    if (!mo.MIsDefault(prop))
                                    {
                                        object oldValue = mo.MGetValue(prop);
                                        if (!value.Equals(oldValue))
                                        {
                                            this.Compiler.Diagnostics.AddWarning("Reassigning '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, new TextSpan(node), true);
                                        }
                                    }
                                    mo.MAdd(prop, value);
                                }
                                else
                                {
                                    this.Compiler.Diagnostics.AddError("Value '"+value+"' cannot be assigned to '"+mo+"."+prop.Name+"'.", this.Compiler.FileName, new TextSpan(node), true);
                                }
                            }
                            else if (prop.Type.IsClass)
                            {
                                if (!mo.MIsDefault(prop) && mo.MGetValue(prop) != null)
                                {
                                    this.Compiler.Diagnostics.AddWarning("Reassigning '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, new TextSpan(node), true);
                                }
                                mo.MAdd(prop, value);
                            }
                            else
                            {
                                this.Compiler.Diagnostics.AddError("Value '" + value + "' cannot be assigned to '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, new TextSpan(node), true);
                            }
                        }
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("Property '" + propertyAnnotation.Name + "' cannot be found in '" + mo + "'.", this.Compiler.FileName, new TextSpan(node), true);
                    }
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Symbol '" + symbol + "' cannot be assigned to '" + propertyAnnotation.SymbolTypes + "'.", this.Compiler.FileName, new TextSpan(node), true);
                }
            }
        }

        protected virtual object Evaluate(object value)
        {
            IParseTree node = value as IParseTree;
            if (node != null)
            {
                return node.GetText();
            }
            else
            {
                return value;
            }
        }

        protected virtual string GetName(IParseTree node)
        {
            return this.Compiler.NameProvider.GetName(node);
        }
    }


    public class MetaCompilerPropertyEvaluator : AbstractParseTreeVisitor<object>
    {
        public MetaCompiler Compiler { get; private set; }
        protected ModelFactory ModelFactory { get; private set; }

        public MetaCompilerPropertyEvaluator(MetaCompiler compiler)
        {
            this.Compiler = compiler;
            this.ModelFactory = new ModelFactory();
        }

        public virtual object Symbol(IParseTree node)
        {
            if (node == null) return null;
            List<object> symbols = this.Symbols(node);
            if (symbols.Count == 0)
            {
                this.Compiler.Diagnostics.AddError("Cannot resolve symbol. No symbols found for the node.", this.Compiler.FileName, new TextSpan(node), true);
            }
            else if (symbols.Count == 1)
            {
                return symbols[0];
            }
            else
            {
                this.Compiler.Diagnostics.AddError("Cannot resolve symbol. Multiple symbols found for the node.", this.Compiler.FileName, new TextSpan(node), true);
            }
            return null;
        }

        public virtual List<object> Symbols(IParseTree node)
        {
            return this.Compiler.Data.GetSymbols(node);
        }

        public virtual List<object> Bind(object scope, object info)
        {
            if (scope == null) return null;
            if (info == null) return null;
            return null;
        }

        public virtual object GetValue(IParseTree node, string property)
        {
            if (node == null) return null;
            if (property == null) return null;
            object symbol = this.Symbol(node);
            ModelObject mo = symbol as ModelObject;
            if (mo != null)
            {
                ModelProperty prop = mo.MFindProperty(property);
                if (prop != null)
                {
                    return mo.MGetValue(prop);
                }
            }
            return null;
        }

        public virtual void SetValue(IParseTree node, string property, Lazy<object> value)
        {
            if (node == null) return;
            if (property == null) return;
            if (value == null) return;
            object symbol = this.Symbol(node);
            ModelObject mo = symbol as ModelObject;
            if (mo != null)
            {
                ModelProperty prop = mo.MFindProperty(property);
                if (prop != null)
                {
                    if (prop.IsCollection)
                    {
                        mo.MAdd(prop, value.Value);
                    }
                    else
                    {
                        mo.MInitValue(prop, value);
                    }
                }
            }
        }

        public virtual object Valueof(object obj)
        {
            return null;
        }
    }

}