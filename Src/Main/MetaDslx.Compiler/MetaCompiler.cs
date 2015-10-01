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

    public abstract class MetaCompiler : IModelCompiler, IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
    {
        public ModelCompilerDiagnostics Diagnostics { get; private set; }
        public string FileName { get; private set; }
        public string Source { get; private set; }
        public bool GenerateOutput { get; set; }
        public RootScope GlobalScope
        {
            get;
            private set;
        }
        public INameProvider NameProvider { get; set; }
        public ITypeProvider TypeProvider { get; set; }
        public IResolutionProvider ResolutionProvider { get; set; }
        public IBindingProvider BindingProvider { get; set; }

        public MetaCompiler(string source, string fileName = null)
        {
            this.Diagnostics = new ModelCompilerDiagnostics();
            this.Source = source;
            this.FileName = fileName;
            this.GenerateOutput = true;
            this.GlobalScope = new RootScope();
            this.Data = new MetaCompilerData(this);
            this.NameProvider = new Antlr4DefaultNameProvider();
            this.TypeProvider = new DefaultTypeProvider();
            this.ResolutionProvider = new DefaultResolutionProvider();
            this.BindingProvider = new DefaultBindingProvider();
        }

        public void Compile()
        {
            using (new ModelContextScope(this))
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
                this.Diagnostics.AddError(msg, this.FileName, new Antlr4TextSpan(line, charPositionInLine+1, line, charPositionInLine+1));
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
                this.Diagnostics.AddError(msg, this.FileName, new Antlr4TextSpan(line, charPositionInLine+1, line, charPositionInLine+1));
            }
        }

        public MetaCompilerData Data { get; protected set; }
        public abstract List<object> LexerAnnotations { get; protected set; }
        public abstract List<object> ParserAnnotations { get; protected set; }
        public abstract Dictionary<int, List<object>> ModeAnnotations { get; protected set; }
        public abstract Dictionary<int, List<object>> TokenAnnotations { get; protected set; }
        public abstract Dictionary<Type, List<object>> RuleAnnotations { get; protected set; }
        public abstract Dictionary<object, List<object>> TreeAnnotations { get; protected set; }

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

}
