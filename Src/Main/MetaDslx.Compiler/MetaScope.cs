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
    public class ScopeEntry
    {
        public ScopeEntry(Scope parent)
        {
            if (parent != null)
            {
                parent.AddEntry(this);
            }
        }

        private List<IParseTree> treeNodes;

        public Scope Parent { get; internal set; }
        public IEnumerable<IParseTree> TreeNodes
        {
            get
            {
                if (this.treeNodes == null)
                {
                    this.treeNodes = new List<IParseTree>();
                }
                return this.treeNodes;
            }
        }

        public void AddTreeNode(IParseTree node)
        {
            if (this.treeNodes == null)
            {
                this.treeNodes = new List<IParseTree>();
            }
            this.treeNodes.Add(node);
        }
    }

    public class Scope : ScopeEntry
    {
        public Scope(Scope parent)
            : base(parent)
        {
        }

        public ScopeEntry Owner { get; set; }

        private List<ScopeEntry> entries;

        public IEnumerable<ScopeEntry> Entries
        {
            get
            {
                if (this.entries == null)
                {
                    this.entries = new List<ScopeEntry>();
                }
                return this.entries;
            }
        }

        public void AddEntry(ScopeEntry entry)
        {
            if (this.entries == null)
            {
                this.entries = new List<ScopeEntry>();
            }
            entry.Parent = this;
            this.entries.Add(entry);
        }

        public List<TypeDef> GetType(string name, IEnumerable<Type> symbolTypes)
        {
            return new List<TypeDef>();
        }

        public List<NameDef> GetName(string name, IEnumerable<Type> symbolTypes)
        {
            return new List<NameDef>();
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
            : base(parent)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public Scope Scope { get; set; }
        public object Symbol { get; set; }
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
            return "TypeDef: " + this.Name;
        }
    }

    public class NameDef : ScopeEntry
    {
        public NameDef(string name, Scope parent)
            : base(parent)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public Scope Scope { get; set; }
        public object Symbol { get; set; }
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
            return "NameDef: " + this.Name;
        }
    }

    public class TypeUse : ScopeEntry
    {
        public TypeUse(string name, Scope parent)
            : base(parent)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public object Symbol { get; set; }

        public override string ToString()
        {
            return "TypeUse: " + this.Name;
        }
    }

    public class NameUse : ScopeEntry
    {
        public NameUse(string name, Scope parent)
            : base(parent)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public object Symbol { get; set; }

        public override string ToString()
        {
            return "NameUse: " + this.Name;
        }
    }
}


