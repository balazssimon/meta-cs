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
        public const int Keyword = 1;
        public const int Identifier = 2;
        public const int String = 3;
        public const int Number = 4;
        public const int Comment = 5;
        public const int DocComment = 6;
    }

    public abstract class MetaCompiler : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
    {
        public MetaCompilerDiagnostics Diagnostics { get; private set; }
        public string FileName { get; private set; }
        public string Source { get; private set; }
        public RootScope GlobalScope
        {
            get;
            private set;
        }

        public MetaCompiler(string source, string fileName = null)
        {
            this.Diagnostics = new MetaCompilerDiagnostics();
            this.Source = source;
            this.FileName = fileName;
            this.GlobalScope = new RootScope();
            this.Data = new MetaCompilerData(this);
        }

        public abstract void Compile();

        void IAntlrErrorListener<int>.SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IToken token = e.OffendingToken;
            if (token != null)
            {
                this.Diagnostics.AddError(msg, this.FileName, new TextSpan(token));
            }
            else
            {
                this.Diagnostics.AddError(msg, this.FileName, new TextSpan(line, charPositionInLine+1, line, charPositionInLine+1));
            }
        }

        void IAntlrErrorListener<IToken>.SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.Diagnostics.AddError(msg, this.FileName, new TextSpan(offendingSymbol));
            }
            else
            {
                this.Diagnostics.AddError(msg, this.FileName, new TextSpan(line, charPositionInLine+1, line, charPositionInLine+1));
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
        public MetaCompilerData(MetaCompiler compiler)
        {
            this.Compiler = compiler;
            this.ModelFactory = new ModelFactory();
            this.NodeToEntry = new Dictionary<IParseTree, List<ScopeEntry>>();
            this.NodeToSymbol = new Dictionary<IParseTree, List<object>>();
            this.SymbolToEntry = new Dictionary<object, ScopeEntry>();
        }

        public MetaCompiler Compiler { get; private set; }
        public ModelFactory ModelFactory { get; private set; }
        public Dictionary<IParseTree, List<ScopeEntry>> NodeToEntry { get; private set; }
        public Dictionary<IParseTree, List<object>> NodeToSymbol { get; private set; }
        public Dictionary<object, ScopeEntry> SymbolToEntry { get; private set; }

        public void RegisterEntry(IParseTree node, ScopeEntry entry)
        {
            List<ScopeEntry> entries = null;
            if (!this.NodeToEntry.TryGetValue(node, out entries))
            {
                entries = new List<ScopeEntry>();
                this.NodeToEntry.Add(node, entries);
            }
            if (!entries.Contains(entry))
            {
                entries.Add(entry);
                entry.AddTreeNode(node);
            }
        }

        public void RegisterSymbol(IParseTree node, object symbol, ScopeEntry entry)
        {
            if (symbol == null) return;
            if (node != null)
            {
                List<object> symbols = null;
                if (!this.NodeToSymbol.TryGetValue(node, out symbols))
                {
                    symbols = new List<object>();
                    this.NodeToSymbol.Add(node, symbols);
                }
                if (!symbols.Contains(symbol))
                {
                    symbols.Add(symbol);
                }
            }
            if (entry != null)
            {
                ScopeEntry oldEntry = null;
                if (this.SymbolToEntry.TryGetValue(symbol, out oldEntry))
                {
                    if (entry != oldEntry)
                    {
                        throw new MetaCompilerException("Cannot register multiple entries to the same symbol.");
                    }
                }
                else
                {
                    this.SymbolToEntry.Add(symbol, entry);
                }
            }
        }

        public List<ScopeEntry> GetEntries(IParseTree node)
        {
            List<ScopeEntry> entries = null;
            if (this.NodeToEntry.TryGetValue(node, out entries))
            {
                return entries.ToList();
            }
            return new List<ScopeEntry>();
        }

        public List<object> GetSymbols(IParseTree node)
        {
            List<object> symbols = null;
            if (this.NodeToSymbol.TryGetValue(node, out symbols))
            {
                return symbols.ToList();
            }
            return new List<object>();
        }

    }

}
