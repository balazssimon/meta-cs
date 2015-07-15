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
    public enum NameAccessOrder
    {
        Random,
        Serial,
    }
    
    public class ScopeEntry
    {
        private static readonly List<IParseTree> EmptyNodeList = new List<IParseTree>();

        public ScopeEntry(string name, Scope parent)
        {
            this.Name = name;
            if (parent != null)
            {
                parent.AddEntry(this);
            }
        }

        private List<IParseTree> treeNodes;

        public string Name { get; set; }
        public object Symbol { get; set; }
        public int Position { get; set; }
        public Scope Parent { get; internal set; }
        public NameAccessOrder AccessOrder { get; set; }
        public IEnumerable<IParseTree> TreeNodes
        {
            get
            {
                if (this.treeNodes == null) return ScopeEntry.EmptyNodeList;
                else return this.treeNodes;
            }
        }

        public void AddTreeNode(IParseTree node)
        {
            if (node == null) return;
            if (this.treeNodes == null)
            {
                this.treeNodes = new List<IParseTree>();
            }
            this.treeNodes.Add(node);
        }
    }

    public class Scope : ScopeEntry
    {
        private static readonly ScopeEntry[] EmptyEntryList = new ScopeEntry[0];
        private static readonly Scope[] EmptyScopeList = new Scope[0];

        public Scope(Scope parent)
            : base(null, parent)
        {
        }

        public ScopeEntry Owner { get; set; }

        private List<ScopeEntry> entries;
        private List<ScopeEntry> inherited;
        private List<ScopeEntry> imported;

        public IEnumerable<ScopeEntry> Entries
        {
            get
            {
                if (this.entries == null) return Scope.EmptyEntryList;
                else return this.entries;
            }
        }

        public IEnumerable<ScopeEntry> InheritedEntries
        {
            get
            {
                if (this.inherited == null) return Scope.EmptyEntryList;
                else return this.inherited;
            }
        }

        public IEnumerable<ScopeEntry> ImportedEntries
        {
            get
            {
                if (this.imported == null) return Scope.EmptyEntryList;
                else return this.imported;
            }
        }

        public void AddEntry(ScopeEntry entry)
        {
            if (entry == null) return;
            if (this.entries == null)
            {
                this.entries = new List<ScopeEntry>();
            }
            entry.Parent = this;
            this.entries.Add(entry);
            entry.Position = this.entries.Count;
        }

        public void AddInheritedEntry(ScopeEntry entry)
        {
            if (entry == null) return;
            if (this.inherited == null)
            {
                this.inherited = new List<ScopeEntry>();
            }
            if (!this.inherited.Contains(entry))
            {
                this.inherited.Add(entry);
            }
        }

        public void AddImportedEntry(ScopeEntry entry)
        {
            if (entry == null) return;
            if (this.imported == null)
            {
                this.imported = new List<ScopeEntry>();
            }
            if (!this.imported.Contains(entry))
            {
                this.imported.Add(entry);
            }
        }

        public void Merge(Scope other)
        {
            foreach (var entry in other.Entries)
            {
                this.AddEntry(entry);
            }
            foreach (var entry in other.InheritedEntries)
            {
                this.AddInheritedEntry(entry);
            }
            foreach (var entry in other.ImportedEntries)
            {
                this.AddImportedEntry(entry);
            }
        }

        public List<TypeDef> ResolveType(string name, Type symbolType, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.ResolveEntry<TypeDef>(name, symbolType, position, flags);
        }

        public List<NameDef> ResolveName(string name, Type symbolType, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.ResolveEntry<NameDef>(name, symbolType, position, flags);
        }

        public List<TypeDef> ResolveType(string name, IEnumerable<Type> symbolTypes, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.ResolveEntry<TypeDef>(name, symbolTypes, position, flags);
        }

        public List<NameDef> ResolveName(string name, IEnumerable<Type> symbolTypes, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.ResolveEntry<NameDef>(name, symbolTypes, position, flags);
        }

        public List<TEntry> ResolveEntry<TEntry>(string name, Type symbolType, int position = 0, ResolveFlags flags = ResolveFlags.All)
            where TEntry : ScopeEntry
        {
            if (symbolType != null)
            {
                return this.ResolveEntry<TEntry>(name, new Type[] { symbolType }, position, flags);
            }
            else
            {
                return this.ResolveEntry<TEntry>(name, (IEnumerable<Type>)null, position, flags);
            }
        }

        public List<TEntry> ResolveEntry<TEntry>(string name, IEnumerable<Type> symbolTypes, int position = 0, ResolveFlags flags = ResolveFlags.All)
            where TEntry : ScopeEntry
        {
            List<TEntry> result = new List<TEntry>();
            if (this.entries != null && flags.HasFlag(ResolveFlags.Children))
            {
                int i = 0;
                foreach (var ent in this.entries)
                {
                    ++i;
                    TEntry entry = ent as TEntry;
                    if (entry != null && entry.Name == name)
                    {
                        NameDef nameDef = entry as NameDef;
                        TypeDef typeDef = entry as TypeDef;
                        if (nameDef != null || typeDef != null)
                        {
                            bool positionOK = entry.AccessOrder == NameAccessOrder.Random || position <= 0 || i < position;
                            bool symbolTypeOK = symbolTypes == null || symbolTypes.Any(st => (nameDef != null && st.IsAssignableFrom(nameDef.SymbolType)) || (typeDef != null && st.IsAssignableFrom(typeDef.SymbolType)));
                            if (positionOK && symbolTypeOK)
                            {
                                result.Add(entry);
                            }
                        }
                    }
                }
            }
            if (flags.HasFlag(ResolveFlags.Inherited) && this.inherited != null)
            {
                foreach (var entry in this.inherited)
                {
                    NameDef nameDef = entry as NameDef;
                    if (nameDef != null && nameDef.Scope != null)
                    {
                        List<TEntry> inheritedResults = nameDef.Scope.ResolveEntry<TEntry>(name, symbolTypes, 0, ResolveFlags.Scope);
                        result.AddRange(inheritedResults);
                    }
                    TypeDef typeDef = entry as TypeDef;
                    if (typeDef != null && typeDef.Scope != null)
                    {
                        List<TEntry> inheritedResults = typeDef.Scope.ResolveEntry<TEntry>(name, symbolTypes, 0, ResolveFlags.Scope);
                        result.AddRange(inheritedResults);
                    }
                }
            }
            if (result.Count == 0 && flags.HasFlag(ResolveFlags.Parent))
            {
                if (this.Parent != null)
                {
                    List<TEntry> parentResults = this.Parent.ResolveEntry<TEntry>(name, symbolTypes, position <= 0 ? 0 : this.Position, ResolveFlags.Scope | ResolveFlags.Parent);
                    result.AddRange(parentResults);
                }
                else if (this.Owner != null && this.Owner.Parent != null)
                {
                    List<TEntry> parentResults = this.Owner.Parent.ResolveEntry<TEntry>(name, symbolTypes, position <= 0 ? 0 : this.Position, ResolveFlags.Scope | ResolveFlags.Parent);
                    result.AddRange(parentResults);
                }
            }
            if (result.Count == 0)
            {
                if (flags.HasFlag(ResolveFlags.Imported) && this.imported != null)
                {
                    foreach (var ent in this.imported)
                    {
                        TEntry entry = ent as TEntry;
                        if (entry != null && entry.Name == name)
                        {
                            NameDef nameDef = entry as NameDef;
                            TypeDef typeDef = entry as TypeDef;
                            if (nameDef != null || typeDef != null)
                            {
                                bool symbolTypeOK = symbolTypes == null || symbolTypes.Any(st => (nameDef != null && st.IsAssignableFrom(nameDef.SymbolType)) || (typeDef != null && st.IsAssignableFrom(typeDef.SymbolType)));
                                if (symbolTypeOK)
                                {
                                    result.Add(entry);
                                }
                            }
                        }
                    }
                }
                if (flags.HasFlag(ResolveFlags.ImportedScope) && this.imported != null)
                {
                    foreach (var entry in this.imported)
                    {
                        NameDef nameDef = entry as NameDef;
                        TypeDef typeDef = entry as TypeDef;
                        if (nameDef != null && nameDef.Scope != null)
                        {
                            List<TEntry> inheritedResults = nameDef.Scope.ResolveEntry<TEntry>(name, symbolTypes, 0, ResolveFlags.Scope);
                            result.AddRange(inheritedResults);
                        }
                        if (typeDef != null && typeDef.Scope != null)
                        {
                            List<TEntry> inheritedResults = typeDef.Scope.ResolveEntry<TEntry>(name, symbolTypes, 0, ResolveFlags.Scope);
                            result.AddRange(inheritedResults);
                        }
                    }
                }
            }
            return result;
        }

        public List<TypeDef> GetTypeDef(string name, Type symbolType)
        {
            return this.ResolveEntry<TypeDef>(name, symbolType, 0, ResolveFlags.Children);
        }

        public List<NameDef> GetNameDef(string name, Type symbolType)
        {
            return this.ResolveEntry<NameDef>(name, symbolType, 0, ResolveFlags.Children);
        }

        public List<TypeDef> GetTypeDef(string name, IEnumerable<Type> symbolTypes)
        {
            return this.ResolveEntry<TypeDef>(name, symbolTypes, 0, ResolveFlags.Children);
        }

        public List<NameDef> GetNameDef(string name, IEnumerable<Type> symbolTypes)
        {
            return this.ResolveEntry<NameDef>(name, symbolTypes, 0, ResolveFlags.Children);
        }
    }

    public class RootScope : Scope
    {
        public RootScope()
            : base(null)
        {

        }
    }

    public class TypeDef : ScopeEntry
    {
        public TypeDef(string name, Scope parent)
            : base(name, parent)
        {
        }

        public bool CanMerge { get; set; }
        public Scope Scope { get; set; }
        public Type SymbolType
        {
            get
            {
                if (this.Symbol != null) return this.Symbol.GetType();
                else return null;
            }
        }

        public override string ToString()
        {
            return "TypeDef: " + this.Name + " => " + this.Symbol;
        }
    }

    public class NameDef : ScopeEntry
    {
        public NameDef(string name, Scope parent)
            : base(name, parent)
        {
        }

        public bool CanMerge { get; set; }
        public Scope Scope { get; set; }
        public Type SymbolType
        {
            get
            {
                if (this.Symbol != null) return this.Symbol.GetType();
                else return null;
            }
        }

        public override string ToString()
        {
            return "NameDef: " + this.Name + " => " + this.Symbol;
        }
    }

    public class TypeUse : ScopeEntry
    {
        public TypeUse(string name, Scope parent)
            : base(name, parent)
        {
        }

        public override string ToString()
        {
            return "TypeUse: " + this.Name + " => " + this.Symbol;
        }
    }

    public class NameUse : ScopeEntry
    {
        public NameUse(string name, Scope parent)
            : base(name, parent)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return "NameUse: " + this.Name + " => " + this.Symbol;
        }
    }
}


