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
    public class SymbolTypedAnnotation
    {
        public Type SymbolType { get; set; }
        public bool OverrideSymbolType { get; set; }
    }

    public class TypeDefAnnotation : SymbolTypedAnnotation
    {
        public TypeDefAnnotation()
        {
            this.Scope = true;
        }
        public bool Merge { get; set; }
        public bool Overload { get; set; }
        public bool Scope { get; set; }
    }

    public class NameDefAnnotation : SymbolTypedAnnotation
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

    public class TypeCtrAnnotation : SymbolTypedAnnotation
    {
        public TypeCtrAnnotation()
        {
        }
    }

    public class NameCtrAnnotation : SymbolTypedAnnotation
    {
        public NameCtrAnnotation()
        {
        }
    }

    public class ScopeAnnotation : SymbolTypedAnnotation
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

    public class SymbolAnnotation : SymbolTypedAnnotation
    {
        public bool NoScope { get; set; }
    }

    public class SymbolTypeAnnotation
    {
        public Type SymbolType { get; set; }
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

        protected override void DoCompile()
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
            MetaCompilerMergePhase mergePhase = new MetaCompilerMergePhase(this);
            mergePhase.VisitNode(this.ParseTree);
            MetaCompilerReferencePhase referencePhase = new MetaCompilerReferencePhase(this);
            referencePhase.VisitNode(this.ParseTree);
            MetaModelParserPropertyEvaluator propertyEvaluator = new MetaModelParserPropertyEvaluator(this);
            propertyEvaluator.Visit(this.ParseTree);

            foreach (var symbol in this.Data.GetSymbols())
            {
                symbol.MEvalLazyValues();
            }
            foreach (var symbol in this.Data.GetSymbols())
            {
                if (symbol.MHasUninitializedValue())
                {
                    this.Diagnostics.AddError("The symbol '"+symbol+"' has uninitialized lazy values.", this.FileName, new TextSpan(), true);
                }
            }

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
                typeof(SymbolAnnotation),
                typeof(PreDefSymbolAnnotation),
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

        public virtual void VisitChildren(IParseTree node)
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
            //ValueAnnotation va = this.GetAnnotationFor<ValueAnnotation>(node);
            //if (va == null)
            {
                List<PropertyAnnotation> pas = this.GetAnnotationsFor<PropertyAnnotation>(node).Where(pa => !pa.HasValue).ToList();
                foreach (var pa in pas)
                {
                    this.AddProperty(node, pa);
                }
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
                    ++counter;
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
            foreach (var prop in symbol.MGetAllProperties())
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
            foreach (var prop in symbol.MGetAllProperties())
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
            return prop.Annotations.Any(a => a is NameAttribute);
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

        protected override void HandleNameKinds(IParseTree node)
        {
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
                this.Compiler.Diagnostics.AddError("A node can have at most one of the following annotations: @TypeDef, @NameDef, @TypeUse, @NameUse, @Scope, @Expression.", this.Compiler.FileName, node, true);
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
            for(int i = 0; i < this.SymbolStack.Count; ++i)
            {
                if (object.ReferenceEquals(this.SymbolStack[i], oldSymbol))
                {
                    this.SymbolStack[i] = newSymbol;
                }
            }
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                ctx.Model.RemoveInstance(oldSymbol);
                ctx.Model.AddInstance(newSymbol);
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
                    this.MergeNamedSymbols(this.CurrentNameKind, node, this.ParentSymbol, pa.Name, typeDef);
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
                        ModelObject mergedNameDef = this.MergeNamedSymbols(i == names.Count - 1 ? this.CurrentNameKind : null, nameNode, parentSymbol, propertyName, nameDef);
                        parentSymbol = mergedNameDef;
                        propertyName = nda.NestingProperty;
                    }
                }
                else
                {
                    if (pa != null && !pa.HasValue)
                    {
                        ModelObject nameDef = this.CurrentSymbol;
                        this.MergeNamedSymbols(this.CurrentNameKind, node, this.ParentSymbol, pa.Name, nameDef);
                    }
                }
            }
        }

        protected virtual ModelObject MergeNamedSymbols(IParseTree defNode, IParseTree nameNode, ModelObject parent, string propertyName, ModelObject symbol)
        {
            if (parent == null) return symbol;
            if (propertyName == null) return symbol;
            if (symbol == null) return symbol;
            object name = this.GetNameProperty(nameNode, symbol);
            // TODO: if (propertyAnnotation.SymbolTypes)
            ModelProperty prop = parent.MFindProperty(propertyName);
            if (prop != null)
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
                            this.Compiler.Diagnostics.AddError("Cannot replace existing value of the property '"+prop+"' in '"+existingEntry+"'.", this.Compiler.FileName, nameNode, true);
                            return symbol;
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
                    List<string> nameStrings = names.Select(n => this.GetName(n)).ToList();
                    ModelObject activeScopeSymbol = this.ActiveScopeSymbol;
                    ModelObject activeSymbol = this.ActiveSymbol;
                    PropertyAnnotation activeProperty = this.ActiveProperty;
                    Func<ModelObject> lazySymbol =
                        () =>
                            this.Compiler.BindingProvider.Bind(null,
                            this.Compiler.ResolutionProvider.Resolve(new ModelObject[] { activeScopeSymbol }, ResolveKind.Type, nameStrings, new ResolutionInfo() { Node = node }, ResolveFlags.All),
                            new BindingInfo() { Node = node });
                    this.SetLazyProperty(node, activeSymbol, activeProperty, new Lazy<object>(lazySymbol, false));
                    this.Data.RegisterLazySymbol(node, new Lazy<object>(lazySymbol, false));
                }
                if (nua != null)
                {
                    List<IParseTree> names = this.GetNames(node);
                    List<string> nameStrings = names.Select(n => this.GetName(n)).ToList();
                    ModelObject activeScopeSymbol = this.ActiveScopeSymbol;
                    ModelObject activeSymbol = this.ActiveSymbol;
                    PropertyAnnotation activeProperty = this.ActiveProperty;
                    Func<ModelObject> lazySymbol =
                        () =>
                            this.Compiler.BindingProvider.Bind(null,
                            this.Compiler.ResolutionProvider.Resolve(new ModelObject[] { activeScopeSymbol }, ResolveKind.Name, nameStrings, new ResolutionInfo() { Node = node }, ResolveFlags.All),
                            new BindingInfo() { Node = node });
                    this.SetLazyProperty(node, activeSymbol, activeProperty, new Lazy<object>(lazySymbol, false));
                    this.Data.RegisterLazySymbol(node, new Lazy<object>(lazySymbol, false));
                }
            }
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
                ValueAnnotation va = this.GetAnnotationFor<ValueAnnotation>(node);
                if (va != null)
                {
                    if (va.HasValue)
                    {
                        this.SetProperty(node, this.ActiveSymbol, pa, va.Value);
                    }
                    else
                    {
                        object value = this.Compiler.NameProvider.GetValue(node);
                        this.SetProperty(node, this.ActiveSymbol, pa, value);
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

    public class MetaCompilerPropertyEvaluator : AbstractParseTreeVisitor<object>
    {
        public MetaCompiler Compiler { get; private set; }
        protected ModelFactory ModelFactory { get; private set; }

        public MetaCompilerPropertyEvaluator(MetaCompiler compiler)
        {
            this.Compiler = compiler;
            this.ModelFactory = new ModelFactory();
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

        public virtual List<object> Bind(object scope, object info)
        {
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

        public virtual object Valueof(object obj)
        {
            return null;
        }
    }

}