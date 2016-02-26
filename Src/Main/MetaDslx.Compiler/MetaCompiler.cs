using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class SyntaxAnnotation
    {
        public int First { get; set; }
        public int Last { get; set; }
        public int Kind { get; set; }
    }

    public class SyntaxKind
    {
        public const int Unknown = 0;
        public const int Text = 1;
        public const int Keyword = 2;
        public const int Identifier = 3;
        public const int String = 4;
        public const int Literal = 5;
        public const int Operator = 6;
        public const int Delimiter = 7;
        public const int WhiteSpace = 8;
        public const int LineComment = 9;
        public const int Comment = 10;
        public const int DocComment = 11;
        public const int Number = 12;
    }

    public abstract class SymbolBasedAnnotation
    {
        public Type SymbolType { get; set; }
        public bool OverrideSymbolType { get; set; }
    }

    public class TypeDefAnnotation : SymbolBasedAnnotation
    {
        public TypeDefAnnotation()
        {
            this.Scope = true;
        }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class NameDefAnnotation : SymbolBasedAnnotation
    {
        public string NestingProperty { get; set; }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class NameUseAnnotation
    {
        public NameUseAnnotation()
        {
            this.SymbolTypes = new List<Type>();
            this.Location = ResolutionLocation.All;
        }
        public List<Type> SymbolTypes { get; set; }
        public ResolutionLocation Location { get; set; }
    }

    public class TypeUseAnnotation
    {
        public TypeUseAnnotation()
        {
            this.SymbolTypes = new List<Type>();
            this.Location = ResolutionLocation.All;
        }
        public List<Type> SymbolTypes { get; set; }
        public ResolutionLocation Location { get; set; }
    }

    public class TypeCtrAnnotation : SymbolBasedAnnotation
    {
        public TypeCtrAnnotation()
        {
        }
    }

    public class NameCtrAnnotation : SymbolBasedAnnotation
    {
        public NameCtrAnnotation()
        {
        }
    }

    public class ScopeAnnotation : SymbolBasedAnnotation
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
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; this.HasName = true; }
        }
        public bool HasName { get; set; }

        private object value;
        public object Value
        {
            get { return this.value; }
            set { this.value = value; this.HasValue = true; }
        }
        public bool HasValue { get; set; }
        private Type type;
        public Type Type
        {
            get { return this.type; }
            set { this.type = value; this.HasType = true; }
        }
        public bool HasType { get; set; }
    }

    public enum EnumValueCase
    {
        Exact,
        Ignore,
        Upper,
        Lower,
        Pascal,
        Camel
    }

    public class EnumValueAnnotation
    {
        public EnumValueAnnotation()
        {
            this.Case = EnumValueCase.Exact;
        }
        public Type EnumType { get; set; }
        public EnumValueCase Case { get; set; }
    }

    public class PreDefSymbolAnnotation
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; this.HasName = true; }
        }
        public bool HasName { get; set; }

        private object value;
        public object Value
        {
            get { return this.value; }
            set { this.value = value; this.HasValue = true; }
        }
        public bool HasValue { get; set; }
    }

    public class SymbolAnnotation : SymbolBasedAnnotation
    {
        public bool NoScope { get; set; }
    }

    public class SymbolTypeAnnotation
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; this.HasName = true; }
        }
        public bool HasName { get; set; }

        public Type SymbolType { get; set; }
    }

    public class AutoSymbolAnnotation
    {

    }

    public class PropertyAnnotation
    {
        public PropertyAnnotation()
        {
            this.SymbolTypes = new List<Type>();
        }

        public List<Type> SymbolTypes { get; set; }
        public string Name { get; set; }
        private object value;
        public object Value
        {
            get { return this.value; }
            set { this.value = value; this.HasValue = true; }
        }
        public bool HasValue { get; set; }
    }

    public enum TriviaPosition
    {
        Any,
        Leading,
        Trailing
    }

    public class TriviaAnnotation
    {
        public TriviaAnnotation()
        {
            this.SymbolTypes = new List<Type>();
        }

        public List<Type> SymbolTypes { get; set; }

        private string property;
        public string Property
        {
            get { return this.property; }
            set { this.property = value; this.HasProperty = true; }
        }
        public bool HasProperty { get; set; }
        public TriviaPosition Position { get; set; }
    }



    public interface IAntlr4Compiler : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
    {
        CommonTokenStream CommonTokenStream { get; }
    }

    public abstract class MetaCompiler : IModelCompiler, IAntlr4Compiler
    {
        public ModelCompilerDiagnostics Diagnostics { get; private set; }
        public string FileName { get; private set; }
        public string Source { get; private set; }
        public string DefaultNamespace { get; set; }
        public RootScope GlobalScope { get; protected set; }
        public Model Model { get; protected set; }
        public ITriviaProvider TriviaProvider { get; protected set; }
        public INameProvider NameProvider { get; protected set; }
        public ITypeProvider TypeProvider { get; protected set; }
        public IResolutionProvider ResolutionProvider { get; protected set; }
        public IBindingProvider BindingProvider { get; protected set; }

        public MetaCompiler(string source, string fileName)
        {
            this.Diagnostics = new ModelCompilerDiagnostics();
            this.Source = source;
            this.FileName = fileName;
            this.GlobalScope = new RootScope();
            this.Model = new Model();
            this.Data = new MetaCompilerData(this);
            this.TriviaProvider = new Antlr4DefaultTriviaProvider(this);
            this.NameProvider = new Antlr4DefaultNameProvider();
            this.TypeProvider = new DefaultTypeProvider();
            this.ResolutionProvider = new DefaultResolutionProvider();
            this.BindingProvider = new DefaultBindingProvider();
        }

        public void Compile()
        {
            using (new ModelContextScope(this.Model))
            using (new ModelCompilerContextScope(this))
            {
                this.DoCompile();
            }
        }

        protected abstract void DoCompile();

        void IAntlrErrorListener<int>.SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IToken token = e.OffendingToken;
            if (token != null)
            {
                this.Diagnostics.AddError(msg, this.FileName, new Antlr4TextSpan(token));
            }
            else
            {
                this.Diagnostics.AddError(msg, this.FileName, new Antlr4TextSpan(line, charPositionInLine + 1, line, charPositionInLine + 1));
            }
        }

        void IAntlrErrorListener<IToken>.SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.Diagnostics.AddError(msg, this.FileName, new Antlr4TextSpan(offendingSymbol));
            }
            else
            {
                this.Diagnostics.AddError(msg, this.FileName, new Antlr4TextSpan(line, charPositionInLine + 1, line, charPositionInLine + 1));
            }
        }

        public MetaCompilerData Data { get; protected set; }
        public CommonTokenStream CommonTokenStream { get; protected set; }
        public List<object> LexerAnnotations { get; protected set; }
        public List<object> ParserAnnotations { get; protected set; }
        public Dictionary<int, List<object>> ModeAnnotations { get; protected set; }
        public Dictionary<int, List<object>> TokenAnnotations { get; protected set; }
        public Dictionary<Type, List<object>> RuleAnnotations { get; protected set; }
        public Dictionary<object, List<object>> TreeAnnotations { get; protected set; }

    }

    public class MetaCompilerData
    {
        private HashSet<ModelObject> symbols;

        public MetaCompilerData(MetaCompiler compiler)
        {
            this.Compiler = compiler;
            this.ModelFactory = new ModelFactory();
            this.symbols = new HashSet<ModelObject>();
            this.NodeToSymbol = new Dictionary<IParseTree, ModelObject>();
            this.LazyNodeToSymbol = new Dictionary<IParseTree, Lazy<object>>();
        }

        public MetaCompiler Compiler { get; private set; }
        public ModelFactory ModelFactory { get; private set; }
        public Dictionary<IParseTree, ModelObject> NodeToSymbol { get; private set; }
        public Dictionary<IParseTree, Lazy<object>> LazyNodeToSymbol { get; private set; }

        public void RegisterSymbol(IParseTree node, ModelObject symbol)
        {
            if (symbol == null) return;
            if (node != null)
            {
                this.NodeToSymbol[node] = symbol;
            }
            this.symbols.Add(symbol);
        }

        public void RegisterLazySymbol(IParseTree node, Lazy<object> symbol)
        {
            if (symbol == null) return;
            if (node != null)
            {
                this.LazyNodeToSymbol[node] = symbol;
            }
        }

        public void ReplaceSymbol(IParseTree node, ModelObject oldSymbol, ModelObject newSymbol)
        {
            if (oldSymbol == null) return;
            if (newSymbol == null) return;
            if (object.ReferenceEquals(oldSymbol, newSymbol)) return;
            if (node != null)
            {
                this.NodeToSymbol[node] = newSymbol;
            }
            this.symbols.Remove(oldSymbol);
            this.symbols.Add(newSymbol);
        }

        public ModelObject GetSymbol(IParseTree node)
        {
            ModelObject symbol = null;
            if (this.NodeToSymbol.TryGetValue(node, out symbol))
            {
                return symbol;
            }
            Lazy<object> lazySymbol = null;
            if (this.LazyNodeToSymbol.TryGetValue(node, out lazySymbol))
            {
                symbol = lazySymbol.Value as ModelObject;
                if (symbol != null)
                {
                    this.NodeToSymbol[node] = symbol;
                }
                return symbol;
            }
            return null;
        }

        public IEnumerable<ModelObject> GetSymbols()
        {
            return this.symbols;
        }
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
                typeof(SymbolAnnotation),
                typeof(PreDefSymbolAnnotation),
                typeof(ScopeAnnotation),
                typeof(PropertyAnnotation),
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
                typeof(PropertyAnnotation),
                typeof(ScopeAnnotation),
                typeof(ExpressionAnnotation),
            };

        public static readonly Type[] VisitBoundaryAnnotations =
            new Type[]
            {
                typeof(NameAnnotation),
                typeof(QualifiedNameAnnotation),
            };

        protected MetaCompiler Compiler { get; private set; }
        protected ModelFactory ModelFactory { get; private set; }

        public MetaCompilerPhase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
            this.ModelFactory = new ModelFactory();
            this.SymbolStack = new List<ModelObject>();
            this.PropertyStack = new List<PropertyAnnotation>();
            this.ScopeKindStack = new List<IParseTree>();
            this.ScopeKindRestoreStack = new List<int>();
            this.NameKindStack = new List<IParseTree>();
            this.NameKindRestoreStack = new List<int>();
        }

        protected MetaCompilerData Data
        {
            get { return this.Compiler.Data; }
        }

        protected List<ModelObject> SymbolStack { get; private set; }
        protected List<PropertyAnnotation> PropertyStack { get; private set; }
        protected List<int> ScopeKindRestoreStack { get; private set; }
        protected List<IParseTree> ScopeKindStack { get; private set; }
        protected List<int> NameKindRestoreStack { get; private set; }
        protected List<IParseTree> NameKindStack { get; private set; }

        protected ModelObject CurrentSymbol
        {
            get
            {
                if (this.SymbolStack.Count > 0)
                {
                    return this.SymbolStack[this.SymbolStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        protected ModelObject ActiveScopeSymbol
        {
            get
            {
                int index = this.SymbolStack.Count - 1;
                while (index >= 0 && (this.SymbolStack[index] == null || !this.SymbolStack[index].IsMetaScope())) --index;
                if (index >= 0)
                {
                    return this.SymbolStack[index];
                }
                else
                {
                    return null;
                }
            }
        }

        protected ModelObject ActiveSymbol
        {
            get
            {
                int index = this.SymbolStack.Count - 1;
                while (index >= 0 && this.SymbolStack[index] == null) --index;
                if (index >= 0)
                {
                    return this.SymbolStack[index];
                }
                else
                {
                    return null;
                }
            }
        }

        protected ModelObject ParentSymbol
        {
            get
            {
                int index = this.SymbolStack.Count - 1;
                while (index >= 0 && this.SymbolStack[index] == null) --index;
                ModelObject activeSymbol = null;
                if (index >= 0)
                {
                    activeSymbol = this.SymbolStack[index];
                }
                --index;
                while (index >= 0 && (this.SymbolStack[index] == null || this.SymbolStack[index] == activeSymbol)) --index;
                if (index >= 0)
                {
                    return this.SymbolStack[index];
                }
                else
                {
                    return null;
                }
            }
        }

        protected PropertyAnnotation CurrentProperty
        {
            get
            {
                if (this.PropertyStack.Count > 0)
                {
                    return this.PropertyStack[this.PropertyStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        protected PropertyAnnotation ActiveProperty
        {
            get
            {
                int index = this.PropertyStack.Count - 1;
                while (index >= 0 && this.PropertyStack[index] == null) --index;
                if (index >= 0)
                {
                    return this.PropertyStack[index];
                }
                else
                {
                    return null;
                }
            }
        }

        protected IParseTree CurrentScopeKind
        {
            get
            {
                if (this.ScopeKindStack.Count > 0)
                {
                    return this.ScopeKindStack[this.ScopeKindStack.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        protected int CurrentScopeKindRestoreCount
        {
            get
            {
                if (this.ScopeKindRestoreStack.Count > 0)
                {
                    return this.ScopeKindRestoreStack[this.ScopeKindRestoreStack.Count - 1];
                }
                else
                {
                    return 0;
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

        protected void AddSymbol(IParseTree node, ModelObject symbol)
        {
            if (symbol == null) return;
            if (this.SymbolStack.Count > 0)
            {
                if (this.SymbolStack[this.SymbolStack.Count - 1] == null)
                {
                    this.SymbolStack[this.SymbolStack.Count - 1] = symbol;
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("There are multiple symbols defined for this node.", this.Compiler.FileName, node, true);
                }
            }
        }

        protected void AddProperty(IParseTree node, PropertyAnnotation propertyAnnotation)
        {
            if (propertyAnnotation == null) return;
            if (this.PropertyStack.Count > 0)
            {
                if (this.PropertyStack[this.PropertyStack.Count - 1] == null)
                {
                    this.PropertyStack[this.PropertyStack.Count - 1] = propertyAnnotation;
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("There are multiple properties defined for this node.", this.Compiler.FileName, node, true);
                }
            }
        }

        public virtual void VisitNode(IParseTree node)
        {
            try
            {
                this.SymbolStack.Add(null);
                this.PropertyStack.Add(null);
                this.ScopeKindRestoreStack.Add(this.ScopeKindStack.Count);
                this.NameKindRestoreStack.Add(this.NameKindStack.Count);
                try
                {
                    this.HandleProperties(node);
                    this.HandleSymbols(node);
                    this.HandleNameKinds(node);
                    this.HandleScopeKinds(node);
                    this.HandleNode(node);
                }
                finally
                {
                    int restoreCount = 0;
                    restoreCount = this.CurrentScopeKindRestoreCount;
                    this.ScopeKindStack.RemoveRange(restoreCount, this.ScopeKindStack.Count - restoreCount);
                    this.ScopeKindRestoreStack.RemoveAt(this.ScopeKindRestoreStack.Count - 1);
                    restoreCount = this.CurrentNameKindRestoreCount;
                    this.NameKindStack.RemoveRange(restoreCount, this.NameKindStack.Count - restoreCount);
                    this.NameKindRestoreStack.RemoveAt(this.NameKindRestoreStack.Count - 1);
                    this.PropertyStack.RemoveAt(this.PropertyStack.Count - 1);
                    this.SymbolStack.RemoveAt(this.SymbolStack.Count - 1);
                }
            }
            catch (Exception ex)
            {
                this.Compiler.Diagnostics.AddError(ex.ToString(), this.Compiler.FileName, node, true);
            }
        }

        protected virtual void VisitChildren(IParseTree node)
        {
            if (!this.IsVisitBoundary(node))
            {
                for (int i = 0; i < node.ChildCount; ++i)
                {
                    this.VisitNode(node.GetChild(i));
                }
            }
        }

        protected virtual void HandleNode(IParseTree node)
        {
            this.VisitChildren(node);
        }

        protected virtual void HandleProperties(IParseTree node)
        {
            List<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(node).Where(pa => !string.IsNullOrEmpty(pa.Name) && !pa.HasValue).ToList();
            foreach (var pa in pas)
            {
                this.AddProperty(node, pa);
            }
        }

        protected virtual void HandleSymbols(IParseTree node)
        {
            ModelObject symbol = this.Compiler.Data.GetSymbol(node);
            if (symbol != null)
            {
                this.AddSymbol(node, symbol);
            }
        }

        protected virtual void HandleNameKinds(IParseTree node)
        {
            int counter = 0;
            foreach (var type in MetaCompilerPhase.NameKindAnnotations)
            {
                object annot = this.GetAnnotationFor(node, type);
                if (annot != null)
                {
                    PropertyAnnotation pa = annot as PropertyAnnotation;
                    if (pa != null)
                    {
                        if (string.IsNullOrEmpty(pa.Name))
                        {
                            ++counter;
                        }
                    }
                    else
                    {
                        ++counter;
                    }
                }
            }
            if (counter == 0) return;
            this.NameKindStack.Add(node);
        }

        protected virtual void HandleScopeKinds(IParseTree node)
        {
            if (this.IsScopeBoundary(node))
            {
                this.ScopeKindStack.Add(node);
            }
        }

        protected virtual bool IsScopeBoundary(IParseTree node)
        {
            foreach (var annot in this.GetAnnotationsFor<object>(node))
            {
                if (MetaCompilerPhase.ScopeBoundaryAnnotations.Any(a => a.Equals(annot.GetType())))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual bool IsSymbolBoundary(IParseTree node)
        {
            foreach (var annot in this.GetAnnotationsFor<object>(node))
            {
                if (MetaCompilerPhase.SymbolBoundaryAnnotations.Any(a => a.Equals(annot.GetType())))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual bool IsVisitBoundary(IParseTree node)
        {
            foreach (var annot in this.GetAnnotationsFor<object>(node))
            {
                if (MetaCompilerPhase.VisitBoundaryAnnotations.Any(a => a.Equals(annot.GetType())))
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

        protected virtual string GetName(IParseTree node)
        {
            return this.Compiler.NameProvider.GetName(node);
        }

        protected virtual bool SetProperty(IParseTree node, ModelObject symbol, PropertyAnnotation propertyAnnotation, object value)
        {
            if (symbol == null) return false;
            if (propertyAnnotation == null) return false;
            bool symbolOK = false;
            if (propertyAnnotation.SymbolTypes.Count == 0)
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
            if (symbolOK)
            {
                ModelObject mo = symbol;
                ModelProperty prop = mo.MFindProperties(propertyAnnotation.Name).FirstOrDefault();
                if (prop != null)
                {
                    if (value != null)
                    {
                        if (prop.IsAssignableFrom(value.GetType()))
                        {
                            if (!mo.MIsDefault(prop))
                            {
                                object oldValue = mo.MGet(prop);
                                if (!value.Equals(oldValue))
                                {
                                    this.Compiler.Diagnostics.AddWarning("Reassigning '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, node, true);
                                }
                            }
                            mo.MAdd(prop, value);
                            return true;
                        }
                        else
                        {
                            this.Compiler.Diagnostics.AddError("Value '" + value + "' cannot be assigned to '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, node, true);
                        }
                    }
                    else if (prop.Type.IsClass)
                    {
                        if (!mo.MIsDefault(prop) && mo.MGet(prop) != null)
                        {
                            this.Compiler.Diagnostics.AddWarning("Reassigning '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, node, true);
                        }
                        mo.MAdd(prop, value);
                        return true;
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("Value '" + value + "' cannot be assigned to '" + mo + "." + prop.Name + "'.", this.Compiler.FileName, node, true);
                    }
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Property '" + propertyAnnotation.Name + "' cannot be found in '" + mo + "'.", this.Compiler.FileName, node, true);
                }
            }
            else
            {
                this.Compiler.Diagnostics.AddError("Symbol '" + symbol + "' cannot be assigned to '" + propertyAnnotation.SymbolTypes + "'.", this.Compiler.FileName, node, true);
            }
            return false;
        }

        protected virtual bool SetLazyProperty(IParseTree node, ModelObject symbol, PropertyAnnotation propertyAnnotation, Lazy<object> value)
        {
            if (symbol == null) return false;
            if (propertyAnnotation == null) return false;
            if (value == null) return false;
            bool symbolOK = false;
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
            if (symbolOK)
            {
                ModelObject mo = symbol as ModelObject;
                ModelProperty prop = mo.MFindProperty(propertyAnnotation.Name);
                if (prop != null)
                {
                    mo.MLazyAdd(prop, value);
                    return true;
                }
            }
            return false;
        }

        protected virtual bool SetNameProperty(IParseTree node, ModelObject symbol, object value)
        {
            if (symbol == null) return false;
            bool success = false;
            foreach (var prop in symbol.MGetProperties())
            {
                if (prop.Annotations.Any(a => a is NameAttribute))
                {
                    symbol.MAdd(prop, value);
                    success = true;
                }
            }
            if (!success)
            {
                this.Compiler.Diagnostics.AddError("Could not find property with [Name] annotation in '" + symbol + "'.", this.Compiler.FileName, node, true);
            }
            return success;
        }

        protected virtual object GetNameProperty(IParseTree node, ModelObject symbol)
        {
            if (symbol == null) return false;
            int counter = 0;
            object result = null;
            foreach (var prop in symbol.MGetProperties())
            {
                if (prop.Annotations.Any(a => a is NameAttribute))
                {
                    object value = symbol.MGet(prop);
                    if (result == null && value != result)
                    {
                        result = value;
                        ++counter;
                    }
                }
            }
            if (counter == 0)
            {
                this.Compiler.Diagnostics.AddError("Could not find property with [Name] annotation in '" + symbol + "'.", this.Compiler.FileName, node, true);
            }
            else if (counter > 1)
            {
                this.Compiler.Diagnostics.AddError("There are multiple properties with [Name] annotation having different values in '" + symbol + "'.", this.Compiler.FileName, node, true);
            }
            return result;
        }

        protected virtual bool IsNameProperty(ModelObject symbol, PropertyAnnotation propertyAnnotation)
        {
            if (symbol == null) return false;
            if (propertyAnnotation == null) return false;
            ModelProperty prop = symbol.MFindProperty(propertyAnnotation.Name);
            if (prop == null) return false;
            return prop.IsMetaName();
        }
    }

    public class MetaCompilerDefinitionPhase : MetaCompilerPhase
    {
        public MetaCompilerDefinitionPhase(MetaCompiler compiler)
            : base(compiler)
        {
        }

        protected override void HandleNode(IParseTree node)
        {
            this.HandleNames(node);
            base.HandleNode(node);
        }

        protected override void HandleSymbols(IParseTree node)
        {
            int counter = 0;
            foreach (var annot in this.GetAnnotationsFor<object>(node))
            {
                if (MetaCompilerPhase.SymbolBoundaryAnnotations.Any(a => a.Equals(annot.GetType())))
                {
                    ++counter;
                }
            }
            if (counter == 0) return;
            if (counter > 1)
            {
                this.Compiler.Diagnostics.AddError("A node can have at most one of the following annotations: @TypeDef, @NameDef, @TypeCtr, @NameCtr, @Scope, @Symbol, @PreDefSymbol.", this.Compiler.FileName, node, true);
            }
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            if (tca != null)
            {
                this.CreateSymbol(node, tca.SymbolType);
            }
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (nca != null)
            {
                this.CreateSymbol(node, nca.SymbolType);
            }
            ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
            if (sa != null)
            {
                this.CreateSymbol(node, sa.SymbolType);
            }
            SymbolAnnotation sya = this.GetAnnotationFor<SymbolAnnotation>(node);
            if (sya != null)
            {
                this.CreateSymbol(node, sya.SymbolType);
            }
            PreDefSymbolAnnotation pdsa = this.GetAnnotationFor<PreDefSymbolAnnotation>(node);
            if (pdsa != null && pdsa.HasValue)
            {
                if (pdsa.HasName)
                {
                    string name = this.Compiler.NameProvider.GetName(node);
                    if (pdsa.Name == name)
                    {
                        ModelObject symbol = pdsa.Value as ModelObject;
                        if (symbol != null)
                        {
                            this.RegisterSymbol(node, symbol);
                        }
                        else
                        {
                            this.Compiler.Diagnostics.AddError("The predefined symbol must be a ModelObject.", this.Compiler.FileName, node, true);
                        }
                    }
                }
                else
                {
                    ModelObject symbol = pdsa.Value as ModelObject;
                    if (symbol != null)
                    {
                        this.RegisterSymbol(node, symbol);
                    }
                    else
                    {
                        this.Compiler.Diagnostics.AddError("The predefined symbol must be a ModelObject.", this.Compiler.FileName, node, true);
                    }
                }
            }
        }

        protected override void HandleNameKinds(IParseTree node)
        {
            int counter = 0;
            foreach (var type in MetaCompilerPhase.NameKindAnnotations)
            {
                object annot = this.GetAnnotationFor(node, type);
                if (annot != null)
                {
                    PropertyAnnotation pa = annot as PropertyAnnotation;
                    if (pa != null)
                    {
                        if (string.IsNullOrEmpty(pa.Name))
                        {
                            ++counter;
                        }
                    }
                    else
                    {
                        ++counter;
                    }
                }
            }
            if (counter == 0) return;
            if (counter > 1)
            {
                this.Compiler.Diagnostics.AddError("A node can have at most one of the following annotations: @TypeDef, @NameDef, @TypeUse, @NameUse, @Scope, @Expression and unnaped @Property.", this.Compiler.FileName, node, true);
            }
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            if (tda != null)
            {
                if (tda.SymbolType == null)
                {
                    this.Compiler.Diagnostics.AddError("The symbol type cannot be determined for the type definition.", this.Compiler.FileName, node, true);
                }
            }
            if (nda != null)
            {
                if (nda.SymbolType == null)
                {
                    this.Compiler.Diagnostics.AddError("The symbol type cannot be determined for the name definition.", this.Compiler.FileName, node, true);
                }
            }
            this.NameKindStack.Add(node);
        }

        protected virtual void HandleNames(IParseTree node)
        {
            if (this.CurrentNameKind != this.CurrentScopeKind) return;
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null) return;
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(this.CurrentNameKind);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(this.CurrentNameKind);
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(this.CurrentNameKind);
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(this.CurrentNameKind);
            PropertyAnnotation pa = this.GetAnnotationFor<PropertyAnnotation>(this.CurrentNameKind);
            if (tda != null)
            {
                if (qna != null)
                {
                    this.Compiler.Diagnostics.AddError("The type name cannot be a @QualifiedName.", this.Compiler.FileName, node, true);
                }
                string name = this.GetName(node);
                if (name != null)
                {
                    ModelObject typeDef = this.TypeDef(name, tda, this.CurrentNameKind, node, true);
                    if (typeDef != null)
                    {
                        if (!this.IsNameProperty(typeDef, this.ActiveProperty) || !this.SetProperty(node, typeDef, this.ActiveProperty, name))
                        {
                            this.SetNameProperty(node, typeDef, name);
                        }
                    }
                }
                else
                {
                    this.Compiler.Diagnostics.AddError("Could not get a name from the node.", this.Compiler.FileName, node, true);
                }
            }
            if (nda != null)
            {
                if (nda.SymbolType.IsMetaScope())
                {
                    List<IParseTree> names = this.GetNames(node);
                    for (int i = 0; i < names.Count; ++i)
                    {
                        string currentName = this.GetName(names[i]);
                        if (currentName != null)
                        {
                            ModelObject nameDef = this.NameDef(currentName, nda, this.CurrentNameKind, names[i], i == names.Count - 1);
                            if (nameDef != null)
                            {
                                if (!this.IsNameProperty(nameDef, this.ActiveProperty) || !this.SetProperty(node, nameDef, this.ActiveProperty, currentName))
                                {
                                    this.SetNameProperty(node, nameDef, currentName);
                                }
                            }
                        }
                        else
                        {
                            this.Compiler.Diagnostics.AddError("Could not get a name from the node.", this.Compiler.FileName, node, true);
                            break;
                        }
                    }
                }
                else
                {
                    if (qna != null)
                    {
                        this.Compiler.Diagnostics.AddError("A qualified name must define a scope.", this.Compiler.FileName, node, true);
                    }
                    string name = this.GetName(node);
                    if (name != null)
                    {
                        ModelObject nameDef = this.NameDef(name, nda, this.CurrentNameKind, node, true);
                        if (nameDef != null)
                        {
                            if (!this.IsNameProperty(nameDef, this.ActiveProperty) || !this.SetProperty(node, nameDef, this.ActiveProperty, name))
                            {
                                this.SetNameProperty(node, nameDef, name);
                            }
                        }
                    }
                }
            }
            if (pa != null && string.IsNullOrEmpty(pa.Name))
            {
                if (qna != null)
                {
                    this.Compiler.Diagnostics.AddError("A @Property cannot have a qualified name.", this.Compiler.FileName, node, true);
                }
                string name = this.GetName(node);
                if (name != null)
                {
                    pa.Name = name;
                }
            }
        }

        protected virtual ModelObject TypeDef(string name, TypeDefAnnotation typeDefAnnotation, IParseTree typeDefNode, IParseTree nameNode, bool registerSymbol)
        {
            ModelObject typeDef = this.CreateSymbol(nameNode, typeDefAnnotation.SymbolType);
            typeDef.MSet(MetaScopeEntryProperties.CanMergeProperty, typeDefAnnotation.Merge && !typeDefAnnotation.Overload);
            if (registerSymbol)
            {
                this.RegisterSymbol(typeDefNode, typeDef);
            }
            return typeDef;
        }

        protected virtual ModelObject NameDef(string name, NameDefAnnotation nameDefAnnotation, IParseTree nameDefNode, IParseTree nameNode, bool registerSymbol)
        {
            ModelObject nameDef = this.CreateSymbol(nameNode, nameDefAnnotation.SymbolType);
            nameDef.MSet(MetaScopeEntryProperties.CanMergeProperty, nameDefAnnotation.Merge && !nameDefAnnotation.Overload);
            if (registerSymbol)
            {
                this.RegisterSymbol(nameDefNode, nameDef);
            }
            return nameDef;
        }

        protected virtual ModelObject CreateSymbol(IParseTree node, Type symbolType)
        {
            if (symbolType == null) return null;
            ModelObject symbol = this.ModelFactory.Create(symbolType);
            if (symbol != null)
            {
                symbol.MSet(MetaScopeEntryProperties.NameTreeNodesProperty, new ModelList<object>(symbol, MetaScopeEntryProperties.NameTreeNodesProperty));
                symbol.MSet(MetaScopeEntryProperties.SymbolTreeNodesProperty, new ModelList<object>(symbol, MetaScopeEntryProperties.SymbolTreeNodesProperty));
                this.RegisterSymbol(node, symbol);
                return symbol;
            }
            else
            {
                this.Compiler.Diagnostics.AddError("Could not create symbol: " + symbolType, this.Compiler.FileName, node, true);
            }
            return null;
        }

        protected virtual void RegisterSymbol(IParseTree node, ModelObject symbol)
        {
            if (symbol == null) return;
            this.Compiler.Data.RegisterSymbol(node, symbol);
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null)
            {
                symbol.MAdd(MetaScopeEntryProperties.SymbolTreeNodesProperty, node);
            }
            else
            {
                symbol.MAdd(MetaScopeEntryProperties.NameTreeNodesProperty, node);
            }
        }
    }

    public class MetaCompilerMergePhase : MetaCompilerPhase
    {
        public MetaCompilerMergePhase(MetaCompiler compiler)
            : base(compiler)
        {
        }

        protected void ReplaceSymbol(IParseTree node, ModelObject oldSymbol, ModelObject newSymbol)
        {
            this.Data.ReplaceSymbol(node, oldSymbol, newSymbol);
            for (int i = 0; i < this.SymbolStack.Count; ++i)
            {
                if (object.ReferenceEquals(this.SymbolStack[i], oldSymbol))
                {
                    this.SymbolStack[i] = newSymbol;
                }
            }
            Model model = ModelContext.Current;
            if (model != null)
            {
                model.RemoveInstance(oldSymbol);
                model.AddInstance(newSymbol);
            }
        }

        protected override void HandleNode(IParseTree node)
        {
            this.HandleNames(node);
            base.HandleNode(node);
        }

        protected virtual void HandleNames(IParseTree node)
        {
            if (this.CurrentNameKind != this.CurrentScopeKind) return;
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null) return;
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(this.CurrentNameKind);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(this.CurrentNameKind);
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(this.CurrentNameKind);
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(this.CurrentNameKind);
            PropertyAnnotation pa = this.ActiveProperty;
            if (tda != null)
            {
                if (pa != null && !pa.HasValue)
                {
                    ModelObject typeDef = this.CurrentSymbol;
                    this.MergeNamedSymbols(this.CurrentNameKind, node, this.ParentSymbol, pa.Name, typeDef, tda.Merge && !tda.Overload);
                }
            }
            if (nda != null)
            {
                if (nda.SymbolType.IsMetaScope())
                {
                    string propertyName = null;
                    if (pa != null && !pa.HasValue)
                    {
                        propertyName = pa.Name;
                    }
                    ModelObject parentSymbol = this.ParentSymbol;
                    if (parentSymbol == null)
                    {
                        parentSymbol = this.Compiler.GlobalScope;
                        propertyName = RootScope.EntriesProperty.Name;
                    }
                    List<IParseTree> names = this.GetNames(node);
                    for (int i = 0; i < names.Count; ++i)
                    {
                        IParseTree nameNode = names[i];
                        ModelObject nameDef = this.Data.GetSymbol(nameNode);
                        ModelObject mergedNameDef;
                        mergedNameDef = this.MergeNamedSymbols(i == names.Count - 1 ? this.CurrentNameKind : null, nameNode, parentSymbol, propertyName, nameDef, nda.Merge && !nda.Overload);
                        parentSymbol = mergedNameDef;
                        propertyName = nda.NestingProperty;
                    }
                }
                else
                {
                    if (pa != null && !pa.HasValue)
                    {
                        ModelObject nameDef = this.CurrentSymbol;
                        this.MergeNamedSymbols(this.CurrentNameKind, node, this.ParentSymbol, pa.Name, nameDef, nda.Merge && !nda.Overload);
                    }
                }
            }
        }

        protected virtual ModelObject MergeNamedSymbols(IParseTree defNode, IParseTree nameNode, ModelObject parent, string propertyName, ModelObject symbol, bool merge)
        {
            if (parent == null) return symbol;
            if (propertyName == null) return symbol;
            if (symbol == null) return symbol;
            object name = this.GetNameProperty(nameNode, symbol);
            // TODO: if (propertyAnnotation.SymbolTypes)
            ModelProperty prop = parent.MFindProperty(propertyName);
            if (prop != null)
            {
                if (merge)
                {
                    if (prop.IsCollection)
                    {
                        object existingEntries = parent.MGet(prop);
                        IEnumerable<object> collection = existingEntries as IEnumerable<object>;
                        if (collection != null)
                        {
                            foreach (var entry in collection)
                            {
                                ModelObject mo = entry as ModelObject;
                                object existingName = this.GetNameProperty(null, mo);
                                if (existingName != null && existingName.Equals(name))
                                {
                                    this.ReplaceSymbol(nameNode, symbol, mo);
                                    this.ReplaceSymbol(defNode, symbol, mo);
                                    return mo;
                                }
                            }
                        }
                    }
                    else
                    {
                        object existingEntry = parent.MGet(prop);
                        if (existingEntry != null)
                        {
                            ModelObject mo = existingEntry as ModelObject;
                            object existingName = this.GetNameProperty(null, mo);
                            if (existingName != null && existingName.Equals(name))
                            {
                                this.ReplaceSymbol(nameNode, symbol, mo);
                                this.ReplaceSymbol(defNode, symbol, mo);
                                return mo;
                            }
                            else
                            {
                                this.Compiler.Diagnostics.AddError("Cannot replace existing value of the property '" + prop + "' in '" + existingEntry + "'.", this.Compiler.FileName, nameNode, true);
                                return symbol;
                            }
                        }
                    }
                }
                parent.MAdd(prop, symbol);
            }
            return symbol;
        }
    }

    public class MetaCompilerReferencePhase : MetaCompilerPhase
    {
        public MetaCompilerReferencePhase(MetaCompiler compiler)
            : base(compiler)
        {
        }

        protected override void HandleNode(IParseTree node)
        {
            this.HandleNames(node);
            this.HandlePropertyValues(node);
            this.HandleTrivia(node);
            base.HandleNode(node);
        }

        protected virtual void HandleNames(IParseTree node)
        {
            if (this.CurrentNameKind != this.CurrentScopeKind) return;
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (na == null && qna == null) return;
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(this.CurrentNameKind);
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(this.CurrentNameKind);
            ModelObject symbol = this.CurrentSymbol;
            if (symbol != null)
            {
                if (tua != null || nua != null)
                {
                    ModelObject parentSymbol = this.ParentSymbol;
                    PropertyAnnotation activeProperty = this.ActiveProperty;
                    this.SetProperty(node, parentSymbol, activeProperty, symbol);
                }
            }
            else
            {
                if (tua != null)
                {
                    List<IParseTree> names = this.GetNames(node);
                    ModelObject activeScopeSymbol = this.ActiveScopeSymbol;
                    ModelObject activeSymbol = this.ActiveSymbol;
                    PropertyAnnotation activeProperty = this.ActiveProperty;
                    ResolutionInfo ri = new ResolutionInfo();
                    ri.Kind = ResolveKind.Type;
                    ri.Scopes.Add(activeScopeSymbol);
                    ri.QualifiedNameNodes.AddRange(names);
                    ri.Location = tua.Location;
                    ri.SymbolTypes.AddRange(tua.SymbolTypes);
                    Func<ModelObject> lazySymbol =
                        () => this.Compiler.BindingProvider.Bind(null, this.Compiler.ResolutionProvider.Resolve(ri));
                    Lazy <object> lazyValue = new Lazy<object>(lazySymbol, LazyThreadSafetyMode.ExecutionAndPublication);
                    this.SetLazyProperty(node, activeSymbol, activeProperty, lazyValue);
                    this.Data.RegisterLazySymbol(node, lazyValue);
                }
                if (nua != null)
                {
                    List<IParseTree> names = this.GetNames(node);
                    ModelObject activeScopeSymbol = this.ActiveScopeSymbol;
                    ModelObject activeSymbol = this.ActiveSymbol;
                    PropertyAnnotation activeProperty = this.ActiveProperty;
                    ResolutionInfo ri = new ResolutionInfo();
                    ri.Kind = ResolveKind.Name;
                    ri.Scopes.Add(activeScopeSymbol);
                    ri.QualifiedNameNodes.AddRange(names);
                    ri.Location = nua.Location;
                    ri.SymbolTypes.AddRange(nua.SymbolTypes);
                    Func<ModelObject> lazySymbol =
                        () => this.Compiler.BindingProvider.Bind(null, this.Compiler.ResolutionProvider.Resolve(ri));
                    Lazy<object> lazyValue = new Lazy<object>(lazySymbol, LazyThreadSafetyMode.ExecutionAndPublication);
                    this.SetLazyProperty(node, activeSymbol, activeProperty, lazyValue);
                    this.Data.RegisterLazySymbol(node, lazyValue);
                }
            }
        }

        private IEnumerable<ModelObject> FilterByTypes(IEnumerable<ModelObject> mobjs, List<Type> types)
        {
            if (types.Count == 0) return mobjs;
            List<ModelObject> result = new List<ModelObject>();
            foreach (var mobj in mobjs)
            {
                bool valid = false;
                foreach (var type in types)
                {
                    if (type.IsAssignableFrom(mobj.GetType()))
                    {
                        valid = true;
                        break;
                    }
                }
                if (valid)
                {
                    result.Add(mobj);
                }
            }
            return result;
        }

        protected virtual void HandlePropertyValues(IParseTree node)
        {
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(node);
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(node);
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            NameAnnotation na = this.GetAnnotationFor<NameAnnotation>(node);
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(node);
            if (tda != null || nda != null || tua != null || nua != null) return;
            if ((na != null || qna != null) && this.CurrentSymbol != null) return;
            TypeCtrAnnotation tca = this.GetAnnotationFor<TypeCtrAnnotation>(node);
            NameCtrAnnotation nca = this.GetAnnotationFor<NameCtrAnnotation>(node);
            if (tca != null || nca != null)
            {
                ModelObject symbol = this.CurrentSymbol;
                if (symbol != null)
                {
                    ModelObject parent = this.ParentSymbol;
                    if (parent != null)
                    {
                        symbol.MParent = parent;
                    }
                    else
                    {
                        symbol.MParent = this.Compiler.GlobalScope;
                    }
                }
            }
            List<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(node).Where(p => p.HasValue).ToList();
            if (pas.Count > 0)
            {
                foreach (var pa in pas)
                {
                    this.SetProperty(node, this.ActiveSymbol, pa, pa.Value);
                }
            }
            else
            {
                PropertyAnnotation pa = this.CurrentProperty;
                if (pa != null)
                {
                    if (pa.HasValue)
                    {
                        this.SetProperty(node, this.ActiveSymbol, pa, pa.Value);
                        pa = null;
                    }
                }
                else
                {
                    pa = this.ActiveProperty;
                    if (pa != null && pa.HasValue)
                    {
                        pa = null;
                    }
                }
                if (pa != null)
                {
                    EnumValueAnnotation eva = this.GetAnnotationFor<EnumValueAnnotation>(node);
                    ValueAnnotation va = this.GetAnnotationFor<ValueAnnotation>(node);
                    if (va != null)
                    {
                        if (va.HasName)
                        {
                            string name = this.Compiler.NameProvider.GetName(node);
                            if (va.Name == name)
                            {
                                if (va.HasValue)
                                {
                                    this.SetProperty(node, this.ActiveSymbol, pa, va.Value);
                                }
                                else
                                {
                                    object value = this.Compiler.NameProvider.GetValue(node, va.Type);
                                    this.SetProperty(node, this.ActiveSymbol, pa, value);
                                }
                            }
                        }
                        else
                        {
                            if (va.HasValue)
                            {
                                this.SetProperty(node, this.ActiveSymbol, pa, va.Value);
                            }
                            else
                            {
                                object value = this.Compiler.NameProvider.GetValue(node, va.Type);
                                this.SetProperty(node, this.ActiveSymbol, pa, value);
                            }
                        }
                    }
                    else if (eva != null)
                    {
                        string name = this.Compiler.NameProvider.GetName(node);
                        object value = null;
                        if (name != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var enumValue in Enum.GetValues(eva.EnumType))
                            {
                                string enumName = enumValue.ToString();
                                if (sb.Length > 0) sb.Append(", ");
                                sb.Append("'");
                                switch (eva.Case)
                                {
                                    case EnumValueCase.Exact:
                                        if (name == enumName) value = enumValue;
                                        sb.Append(enumName);
                                        break;
                                    case EnumValueCase.Ignore:
                                        if (string.Equals(name, enumName, StringComparison.OrdinalIgnoreCase)) value = enumValue;
                                        sb.Append(enumName);
                                        break;
                                    case EnumValueCase.Upper:
                                        string upperName = enumName.ToUpper();
                                        if (name == upperName) value = enumValue;
                                        sb.Append(upperName);
                                        break;
                                    case EnumValueCase.Lower:
                                        string lowerName = enumName.ToLower();
                                        if (name == lowerName) value = enumValue;
                                        sb.Append(lowerName);
                                        break;
                                    case EnumValueCase.Pascal:
                                        string pascalName = enumName.Substring(0, 1).ToUpper() + enumName.Substring(1);
                                        if (name == pascalName) value = enumValue;
                                        sb.Append(pascalName);
                                        break;
                                    case EnumValueCase.Camel:
                                        string camelName = enumName.Substring(0, 1).ToLower() + enumName.Substring(1);
                                        if (name == camelName) value = enumValue;
                                        sb.Append(camelName);
                                        break;
                                    default:
                                        break;
                                }
                                sb.Append("'");
                                if (value != null)
                                {
                                    break;
                                }
                            }
                            if (value != null)
                            {
                                this.SetProperty(node, this.ActiveSymbol, pa, value);
                            }
                            else
                            {
                                this.Compiler.Diagnostics.AddError("Invalid name '" + name + "'. Valid names are: " + sb.ToString(), this.Compiler.FileName, node, false);
                            }
                        }
                    }
                    else
                    {
                        ModelObject symbol = this.CurrentSymbol;
                        if (symbol != null)
                        {
                            this.SetProperty(node, this.ParentSymbol, pa, symbol);
                        }
                    }
                }
            }
        }

        protected virtual void HandleTrivia(IParseTree node)
        {
            ModelObject symbol = this.CurrentSymbol;
            if (symbol != null)
            {
                bool retrievedTrivia = false;
                string leadingTrivia = null;
                string trailingTrivia = null;
                IEnumerable<TriviaAnnotation> tas = this.GetAnnotationsFor<TriviaAnnotation>(node);
                foreach (var ta in tas)
                {
                    if (ta.Property != null)
                    {
                        bool symbolOK = false;
                        if (ta.SymbolTypes == null || ta.SymbolTypes.Count == 0)
                        {
                            symbolOK = true;
                        }
                        else
                        {
                            foreach (var symbolType in ta.SymbolTypes)
                            {
                                if (symbolType.IsAssignableFrom(symbol.GetType()))
                                {
                                    symbolOK = true;
                                    break;
                                }
                            }
                        }
                        if (symbolOK)
                        {
                            ModelProperty prop = symbol.MFindProperty(ta.Property);
                            if (prop != null)
                            {

                                if (!retrievedTrivia)
                                {
                                    leadingTrivia = this.Compiler.TriviaProvider.GetLeadingTrivia(symbol);
                                    trailingTrivia = this.Compiler.TriviaProvider.GetTrailingTrivia(symbol);
                                    retrievedTrivia = true;
                                }
                                string trivia = null;
                                switch (ta.Position)
                                {
                                    case TriviaPosition.Any:
                                        trivia = leadingTrivia;
                                        if (trivia == null)
                                        {
                                            trivia = trailingTrivia;
                                        }
                                        break;
                                    case TriviaPosition.Leading:
                                        trivia = leadingTrivia;
                                        break;
                                    case TriviaPosition.Trailing:
                                        trivia = trailingTrivia;
                                        break;
                                    default:
                                        break;
                                }
                                if (!string.IsNullOrWhiteSpace(trivia))
                                {
                                    symbol.MAdd(prop, trivia);
                                }
                            }
                        }
                    }
                }
            }
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

        public override object Visit(IParseTree tree)
        {
            try
            {
                return base.Visit(tree);
            }
            catch (Exception ex)
            {
                this.Compiler.Diagnostics.AddError("Exception: " + ex, this.Compiler.FileName, tree, false);
            }
            return null;
        }

        public override object VisitChildren(IRuleNode node)
        {
            try
            {
                return base.VisitChildren(node);
            }
            catch (Exception ex)
            {
                this.Compiler.Diagnostics.AddError("Exception: " + ex, this.Compiler.FileName, node, false);
            }
            return null;
        }

        public virtual ModelObject Symbol(IParseTree node)
        {
            ModelObject symbol = this.Compiler.Data.GetSymbol(node);
            if (symbol == null)
            {
                this.Compiler.Diagnostics.AddError("Cannot resolve symbol. No symbols found for the node.", this.Compiler.FileName, node, true);
            }
            return symbol;
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
                    return mo.MGet(prop);
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
                        mo.MLazyAdd(prop, value);
                    }
                    else
                    {
                        mo.MLazySet(prop, value);
                    }
                }
            }
        }
    }

}
