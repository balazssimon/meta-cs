using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /*
    public class SymbolTable
    {
        private ModelFactory factory = new ModelFactory();
        private Scope globalScope = new Scope(null, null, null);
        private Dictionary<IParseTree, HashSet<ScopeEntry>> nodeToEntry = new Dictionary<IParseTree, HashSet<ScopeEntry>>();
        private Dictionary<object, HashSet<ScopeEntry>> symbolToEntry = new Dictionary<object, HashSet<ScopeEntry>>();
        private HashSet<TypeConstructor> typeConstructors = new HashSet<TypeConstructor>();

        public void Clear()
        {
            globalScope = new Scope(null, null, null);
            nodeToEntry = new Dictionary<IParseTree, HashSet<ScopeEntry>>();
            symbolToEntry = new Dictionary<object, HashSet<ScopeEntry>>();
            typeConstructors = new HashSet<TypeConstructor>();
        }

        public MetaCompiler Compiler { get; set; }

        public Scope GlobalScope
        {
            get { return this.globalScope; }
        }

        public void RegisterEntry(ScopeEntry entry)
        {
            if (entry == null) throw new ArgumentNullException("entry");
            foreach (var node in entry.TreeNodes)
            {
                HashSet<ScopeEntry> entries = null;
                if (!nodeToEntry.TryGetValue(node, out entries))
                {
                    entries = new HashSet<ScopeEntry>();
                    nodeToEntry.Add(node, entries);
                }
                entries.Add(entry);
            }
        }

        public object RegisterSymbol(ScopeEntry entry, object symbol)
        {
            if (entry == null) throw new ArgumentNullException("entry");
            if (symbol == null) throw new ArgumentNullException("symbol");
            if (entry.Symbol != null)
            {
                if (!object.ReferenceEquals(entry.Symbol, symbol))
                {
                    throw new MetaCompilerException("The scope entry '" + entry + "' already has a different symbol." + entry.GetTextSpan());
                }
                return entry.Symbol;
            }
            if (entry is TypeConstructor)
            {
                foreach (var ctr in this.typeConstructors)
                {
                    if (ctr.Equals(entry))
                    {
                        symbol = ctr.Symbol;
                    }
                }
            }
            entry.Symbol = symbol;
            this.RegisterEntry(entry);
            HashSet<ScopeEntry> entries = null;
            if (!symbolToEntry.TryGetValue(symbol, out entries))
            {
                entries = new HashSet<ScopeEntry>();
                symbolToEntry.Add(symbol, entries);
            }
            entries.Add(entry);
            if (entry is TypeConstructor)
            {
                this.typeConstructors.Add(entry as TypeConstructor);
            }
            return symbol;
        }

        public void CreateSymbols()
        {
            var entriesList = nodeToEntry.Values.ToList();
            foreach (var entries in entriesList)
            {
                var entryList = entries.ToList();
                foreach (var entry in entryList)
                {
                    this.CreateSymbol(entry);
                }
            }
        }

        private object CreateSymbol(ScopeEntry entry)
        {
            if (entry == null) throw new ArgumentNullException("entry");
            if (entry.Symbol != null)
            {
                return entry.Symbol;
            }
            Type symbolType = entry.SymbolType as Type;
            if (!(entry.GetType() == typeof(Scope) || entry.GetType() == typeof(TypeDefinition) || entry.GetType() == typeof(NameDefinition)))
            {
                return null;
            }
            if (symbolType == null)
            {
                throw new MetaCompilerException("The definition '" + entry + "' has no symbol type. " + entry.GetTextSpan());
                //return null;
            }
            List<ScopeEntry> entries = new List<ScopeEntry>();
            bool mergeAllowed = true;
            HashSet<object> symbols = new HashSet<object>();
            foreach (var e in entry.Parent.Children)
            {
                if (e.Name == entry.Name && e.SymbolType == entry.SymbolType)
                {
                    entries.Add(e);
                    Scope scope = e as Scope;
                    if (scope != null)
                    {
                        if (!scope.CanMerge)
                        {
                            mergeAllowed = false;
                        }
                    }
                    if (e.Symbol != null)
                    {
                        symbols.Add(e.Symbol);
                    }
                }
            }
            if (entries.Count > 1 && !mergeAllowed)
            {
                if (this.Compiler != null)
                {
                    foreach (var e in entries)
                    {
                        this.Compiler.Diagnostics.AddError("'" + symbolType.Name + "' '" + e.Name + "' is already defined." + entry.GetTextSpan(), this.Compiler.FileName, e.GetTextSpan());
                    }
                }
                return null;
            }
            if (symbols.Count > 1)
            {
                throw new MetaCompilerException("The scope entry '" + entry + "' has multiple symbol candidates." + entry.GetTextSpan());
            }
            object symbol = symbols.FirstOrDefault();
            if (symbol == null)
            {
                symbol = factory.Create(symbolType);
            }
            foreach (var e in entries)
            {
                this.RegisterSymbol(e, symbol);
            }
            return symbol;
        }

        public IEnumerable<IParseTree> SymbolToNodes(object symbol)
        {
            if (symbol == null) return new IParseTree[0];
            HashSet<ScopeEntry> entries = null;
            if (symbolToEntry.TryGetValue(symbol, out entries))
            {
                return entries.SelectMany(e => e.TreeNodes).Distinct().ToList();
            }
            else
            {
                return new IParseTree[0];
            }
        }

        public IEnumerable<ScopeEntry> SymbolToEntries(object symbol)
        {
            if (symbol == null) return new ScopeEntry[0];
            HashSet<ScopeEntry> entries = null;
            if (symbolToEntry.TryGetValue(symbol, out entries))
            {
                return entries;
            }
            else
            {
                return new ScopeEntry[0];
            }
        }

        public IEnumerable<object> NodeToSymbols(IParseTree node)
        {
            if (node == null) return null;
            HashSet<ScopeEntry> entries = null;
            if (nodeToEntry.TryGetValue(node, out entries))
            {
                return entries.Select(e => e.Symbol);
            }
            else
            {
                return new object[0];
            }
        }

        public IEnumerable<object> GetSymbols()
        {
            return symbolToEntry.Keys;
        }

    }*/
}
