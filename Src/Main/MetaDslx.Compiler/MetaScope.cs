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

    [Flags]
    public enum ResolveFlags
    {
        Children = 1,
        Inherited = 2,
        Parent = 4,
        Imported = 8,
        ChildrenOrInheritedChildren = Children | Inherited,
        All = Children | Inherited | Parent | Imported
    }

    public interface IHasScope
    {
        Scope Scope { get; }
    }

    public abstract class ScopeEntry
    {
        private List<IParseTree> treeNodes = null;

        public ScopeEntry(string name, object symbolType, Scope parent)
        {
            this.Name = name;
            this.SymbolType = symbolType;
            this.Parent = parent;
            if (this.Parent != null)
            {
                this.Parent.children.Add(this);
                this.Position = this.Parent.children.Count;
            }
        }

        public string Name { get; private set; }
        public object SymbolType { get; private set; }
        public Scope Parent { get; internal set; }
        public int Position { get; internal set; }
        public NameAccessOrder AccessOrder { get; set; }
        public RootScope RootScope
        {
            get
            {
                if (this.Parent == null) return this as RootScope;
                else return this.Parent.RootScope;
            }
        }

        public object Symbol { get; internal set; }
        public IEnumerable<IParseTree> TreeNodes
        {
            get
            {
                if (this.treeNodes == null) return new IParseTree[0];
                else return this.treeNodes;
            }
        }

        internal void AddTreeNode(IParseTree node)
        {
            if (this.treeNodes == null)
            {
                this.treeNodes = new List<IParseTree>();
            }
            this.treeNodes.Add(node);
        }

        public TextSpan GetTextSpan()
        {
            IParseTree node = this.TreeNodes.FirstOrDefault();
            if (node != null)
            {
                return new TextSpan(node);
            }
            else
            {
                return new TextSpan();
            }
        }

        public override string ToString()
        {
            if (this.Parent == null) return this.Name;
            else return this.Parent.ToString() + "." + this.Name;
        }
    }

    public class NameDefinition : ScopeEntry
    {
        public NameDefinition(string name, object symbolType, Scope parent)
            : base(name, symbolType, parent)
        {
            this.Constructors = new List<NameConstructor>();
        }

        public List<NameConstructor> Constructors { get; private set; }
        public TypeReference Type { get; set; }
    }

    public class NameReference : ScopeEntry
    {
        public NameReference(string name, object symbolType, Scope parent)
            : base(name, symbolType, parent)
        {
        }

        public NameDefinition Definition { get; set; }

        public override string ToString()
        {
            if (this.Symbol != null)
            {
                return "NameUse:" + this.Symbol;
            }
            else
            {
                return base.ToString();
            }
        }
    }

    public class TypeDefinition : ScopeEntry
    {
        public TypeDefinition(string name, object symbolType, Scope parent)
            : base(name, symbolType, parent)
        {
            this.Constructors = new List<TypeConstructor>();
        }

        public List<TypeConstructor> Constructors { get; private set; }

        public override bool Equals(object obj)
        {
            if (this.Symbol == null) return false;
            TypeReference typeRef = obj as TypeReference;
            if (typeRef != null && this.Symbol == typeRef.Symbol) return true;
            TypeDefinition typeDef = obj as TypeDefinition;
            if (typeDef != null && this.Symbol == typeDef.Symbol) return true;
            return false;
        }

        public override string ToString()
        {
            if (this.Symbol != null)
            {
                return "TypeDef:" + this.Symbol;
            }
            else
            {
                return base.ToString();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class TypeReference : ScopeEntry
    {
        public TypeReference(string name, object symbolType, Scope parent)
            : base(name, symbolType, parent)
        {
        }

        public TypeDefinition Definition { get; set; }

        public override bool Equals(object obj)
        {
            if (this.Symbol == null) return false;
            TypeReference typeRef = obj as TypeReference;
            if (typeRef != null && this.Symbol == typeRef.Symbol) return true;
            TypeDefinition typeDef = obj as TypeDefinition;
            if (typeDef != null && this.Symbol == typeDef.Symbol) return true;
            return false;
        }

        public override string ToString()
        {
            if (this.Symbol != null)
            {
                return "TypeUse:" + this.Symbol;
            }
            else
            {
                return base.ToString();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class NameConstructor : ScopeEntry, IHasScope
    {
        public NameConstructor(string name, object symbolType, Scope parent)
            : base(name, symbolType, parent)
        {
        }

        public bool CanMerge { get; set; }
        public bool CanOverload { get; set; }
        public bool NoScope { get; set; }
        public Scope Scope { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            NameConstructor nc = obj as NameConstructor;
            if (nc == null) return false;
            if (this.Symbol == null || nc.Symbol == null) return false;
            return this.Symbol.Equals(nc.Symbol);
        }

        public override string ToString()
        {
            if (this.Symbol != null)
            {
                return "NameCtr:" + this.Symbol;
            }
            else
            {
                return base.ToString();
            }
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class TypeConstructor : ScopeEntry, IHasScope
    {
        public TypeConstructor(string name, object symbolType, Scope parent)
            : base(name, symbolType, parent)
        {
        }

        public bool CanMerge { get; set; }
        public bool CanOverload { get; set; }
        public bool NoScope { get; set; }
        public Scope Scope { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TypeConstructor tc = obj as TypeConstructor;
            if (tc == null) return false;
            if (this.Symbol == null || tc.Symbol == null) return false;
            return this.Symbol.Equals(tc.Symbol);
        }

        public override string ToString()
        {
            if (this.Symbol != null)
            {
                return "TypeCtr:" + this.Symbol;
            }
            else
            {
                return base.ToString();
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class Scope : ScopeEntry
    {
        internal List<ScopeEntry> children;

        public Scope(string name, object symbolType, ScopeEntry ownerEntry, Scope parent)
            : base(name, symbolType, parent)
        {
            this.OwnerEntry = ownerEntry;
            this.children = new List<ScopeEntry>();
            this.Inherited = new List<Scope>();
            this.Imported = new List<Scope>();
        }

        public ScopeEntry OwnerEntry { get; private set; }

        public IEnumerable<ScopeEntry> Children 
        { 
            get
            {
                return this.children;
            }
        }
        public List<Scope> Inherited { get; private set; }
        public List<Scope> Imported { get; private set; }

        public void Merge(Scope from)
        {
            if (from == null) return;
            List<ScopeEntry> entries = from.children.ToList();
            foreach (var entry in entries)
            {
                entry.Parent = this;
                this.children.Add(entry);
                entry.Position = this.children.Count;
            }
            from.children.Clear();
        }

        private TEntry Resolve<TEntry>(string name, object symbolTypes, int position = 0, ResolveFlags flags = ResolveFlags.All)
            where TEntry : ScopeEntry
        {
            if (flags.HasFlag(ResolveFlags.Children))
            {
                IEnumerable<object> symbolTypesEnum = symbolTypes as IEnumerable<object>;
                if (symbolTypesEnum != null && symbolTypesEnum.FirstOrDefault() == null)
                {
                    symbolTypes = null;
                }
                foreach (var child in this.Children)
                {
                    bool positionOK = child.AccessOrder == NameAccessOrder.Random || position <= 0 || child.Position < position;
                    bool symbolTypeOK = true;
                    Type childType = child.SymbolType as Type;
                    //symbolTypes == null || symbolTypes.IsAs(child.SymbolType) || (symbolTypesEnum != null && symbolTypesEnum.Contains(child.SymbolType));
                    if (symbolTypes == null)
                    {
                        symbolTypeOK = false;
                    }
                    if (symbolTypeOK)
                    {
                        Type symbolType = symbolTypes as Type;
                        if (symbolType != null && childType != null)
                        {
                            symbolTypeOK = symbolType.IsAssignableFrom(childType);
                        }
                        else
                        {
                            symbolTypeOK = symbolTypes == child.SymbolType;
                        }
                    }
                    if (symbolTypeOK && childType != null && symbolTypesEnum != null)
                    {
                        bool found = false;
                        foreach (var item in symbolTypesEnum)
                        {
                            Type symbolType = item as Type;
                            if (symbolType != null)
                            {
                                if (symbolType.IsAssignableFrom(childType))
                                {
                                    found = true;
                                }
                                else if (item == child.SymbolType)
                                {
                                    found = true;
                                }
                            }
                        }
                    }
                    if (positionOK && symbolTypeOK && child.Name == name)
                    {
                        TEntry entry = child as TEntry;
                        if (entry != null) return entry;
                    }
                }
            }
            if (flags.HasFlag(ResolveFlags.Inherited))
            {
                foreach (var inherited in this.Inherited)
                {
                    TEntry result = inherited.Resolve<TEntry>(name, symbolTypes, 0, flags);
                    if (result != null) return result;
                }
            }
            if (flags.HasFlag(ResolveFlags.Parent))
            {
                if (this.Parent != null) return this.Parent.Resolve<TEntry>(name, symbolTypes, position <= 0 ? 0 : this.Position, flags);
            }
            if (flags.HasFlag(ResolveFlags.Imported))
            {
                foreach (var imported in this.Imported)
                {
                    TEntry result = imported.Resolve<TEntry>(name, symbolTypes, 0, flags);
                    if (result != null) return result;
                }
            }
            return null;
        }

        public ScopeEntry ResolveName(string name, object symbolTypes, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.Resolve<ScopeEntry>(name, symbolTypes, position, flags);
        }

        public TypeDefinition ResolveType(string name, object symbolTypes, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.Resolve<TypeDefinition>(name, symbolTypes, position, flags);
        }

        public NameDefinition RegisterNameDef(string name, NameConstructor nameConstructor, object symbol, IParseTree node)
        {
            NameDefinition result = new NameDefinition(name, symbol.GetType(), this);
            if (!result.Constructors.Contains(nameConstructor))
            {
                result.Constructors.Add(nameConstructor);
            }
            RootScope rootScope = this.RootScope;
            if (!rootScope.children.Contains(nameConstructor))
            {
                nameConstructor.Parent = this.RootScope;
                this.RootScope.children.Add(nameConstructor);
                nameConstructor.Position = this.RootScope.children.Count;
                nameConstructor.Symbol = symbol;
            }
            this.RootScope.RegisterSymbol(node, result, symbol);
            return result;
        }

        public NameReference RegisterNameUse(string name, object symbolTypes, IParseTree node)
        {
            NameReference result = new NameReference(name, symbolTypes, this);
            this.RootScope.RegisterSymbol(node, result, null);
            return result;
        }

        public ScopeEntry GetName(string name, object symbolTypes)
        {
            return this.Resolve<ScopeEntry>(name, symbolTypes, -1, ResolveFlags.Children);
        }

        public TypeDefinition RegisterTypeDef(string name, TypeConstructor typeConstructor, object symbol, IParseTree node)
        {
            TypeDefinition result = new TypeDefinition(name, symbol.GetType(), this);
            if (!result.Constructors.Contains(typeConstructor))
            {
                result.Constructors.Add(typeConstructor);
            }
            RootScope rootScope = this.RootScope;
            if (!rootScope.children.Contains(typeConstructor))
            {
                typeConstructor.Parent = this.RootScope;
                this.RootScope.children.Add(typeConstructor);
                typeConstructor.Position = this.RootScope.children.Count;
                typeConstructor.Symbol = symbol;
            }
            this.RootScope.RegisterSymbol(node, result, symbol);
            return result;
        }

        /*public TypeDefinition RegisterTypeDef(string name, object symbol)
        {
            TypeDefinition result = null;
            if (name != null)
            {
                result = this.GetType(name, symbol.GetType());
            }
            if (result == null)
            {
                result = new TypeDefinition(name, symbol.GetType(), this);
            }
            this.RootScope.RegisterSymbol(null, result, symbol);
            return result;
        }*/

        public TypeReference RegisterTypeUse(string name, object symbolTypes, IParseTree node)
        {
            TypeReference result = new TypeReference(name, symbolTypes, this);
            this.RootScope.RegisterSymbol(node, result, null);
            return result;
        }

        public TypeDefinition GetType(string name, object symbolTypes)
        {
            return this.Resolve<TypeDefinition>(name, symbolTypes, -1, ResolveFlags.Children);
        }

        public TypeDefinition GetType(TypeDefinition typeDef)
        {
            foreach (var child in this.Children)
            {
                TypeDefinition childTypeDef = child as TypeDefinition;
                if (childTypeDef != null && childTypeDef.Equals(typeDef))
                {
                    return childTypeDef;
                }
            }
            return null;
        }

        public ScopeEntry GetChild(IParseTree context)
        {
            foreach (var child in this.Children)
            {
                if (child.TreeNodes.Contains(context))
                {
                    return child as ScopeEntry;
                }
            }
            return null;
        }

        public Scope GetScope(IParseTree context)
        {
            foreach (var child in this.Children)
            {
                if (child.TreeNodes.Contains(context))
                {
                    Scope scope = child as Scope;
                    if (scope != null) return scope;
                    IHasScope hasScope = child as IHasScope;
                    if (hasScope != null) return hasScope.Scope;
                }
            }
            return null;
        }

        public ScopeEntry ResolveName(List<string> qualifiedName, object symbolTypes, int position = 0)
        {
            if (qualifiedName.Count == 0) return null;
            int index = 0;
            Scope currentScope = this;
            while (currentScope != null && index < qualifiedName.Count)
            {
                if (index == qualifiedName.Count-1)
                {
                    return currentScope.ResolveName(
                        qualifiedName[index],
                        index == qualifiedName.Count - 1 ? symbolTypes : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                }
                else
                {
                    ScopeEntry resolved = null;
                    resolved = currentScope.Resolve<ScopeEntry>(
                        qualifiedName[index],
                        index == qualifiedName.Count - 1 ? symbolTypes : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                    Scope scope = resolved as Scope;
                    TypeDefinition type = resolved as TypeDefinition;
                    NameDefinition name = resolved as NameDefinition;
                    if (scope != null)
                    {
                        currentScope = scope;
                    }
                    else if (name != null && name.Type != null && name.Type.Definition != null)
                    {
                        TypeConstructor ctr = name.Type.Definition.Constructors.FirstOrDefault();
                        if (ctr != null)
                        {
                            currentScope = ctr.Scope;
                        }
                        else
                        {
                            currentScope = null;
                        }
                    }
                    else
                    {
                        currentScope = null;
                    }
                }
                ++index;
            }
            return null;
        }

        public TypeDefinition ResolveType(List<string> qualifiedName, object symbolTypes, int position = 0)
        {
            if (qualifiedName.Count == 0) return null;
            int index = 0;
            Scope currentScope = this;
            while (currentScope != null && index < qualifiedName.Count)
            {
                if (index == qualifiedName.Count - 1)
                {
                    return currentScope.ResolveType(
                        qualifiedName[index],
                        index == qualifiedName.Count - 1 ? symbolTypes : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                }
                else
                {
                    ScopeEntry resolved = null;
                    currentScope.Resolve<ScopeEntry>(
                        qualifiedName[index],
                        index == qualifiedName.Count - 1 ? symbolTypes : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                    Scope scope = resolved as Scope;
                    TypeDefinition type = resolved as TypeDefinition;
                    if (scope != null) 
                    {
                        currentScope = scope;
                    }
                    else
                    {
                        currentScope = null;
                    }
                }
                ++index;
            }
            return null;
        }
    }

    public class RootScope : Scope
    {
        private static ModelFactory factory = new ModelFactory();
        private Dictionary<object, HashSet<ScopeEntry>> symbolToEntry;
        private Dictionary<IParseTree, HashSet<ScopeEntry>> nodeToEntry;
        private Dictionary<IParseTree, HashSet<object>> nodeToSymbol;

        public RootScope()
            : base(null, null, null, null)
        {
            this.symbolToEntry = new Dictionary<object, HashSet<ScopeEntry>>();
            this.nodeToEntry = new Dictionary<IParseTree, HashSet<ScopeEntry>>();
            this.nodeToSymbol = new Dictionary<IParseTree, HashSet<object>>();
        }

        public void RegisterSymbol(IParseTree node, ScopeEntry entry, object symbol)
        {
            if (symbol != null && entry != null)
            {
                HashSet<ScopeEntry> entries = null;
                if (!this.symbolToEntry.TryGetValue(symbol, out entries))
                {
                    entries = new HashSet<ScopeEntry>();
                    this.symbolToEntry.Add(symbol, entries);
                }
                entries.Add(entry);
                entry.Symbol = symbol;
            }
            if (node != null && entry != null)
            {
                HashSet<ScopeEntry> entries = null;
                if (!this.nodeToEntry.TryGetValue(node, out entries))
                {
                    entries = new HashSet<ScopeEntry>();
                    this.nodeToEntry.Add(node, entries);
                }
                entries.Add(entry);
                entry.AddTreeNode(node);
            }
            if (node != null && symbol != null)
            {
                HashSet<object> entries = null;
                if (!this.nodeToSymbol.TryGetValue(node, out entries))
                {
                    entries = new HashSet<object>();
                    this.nodeToSymbol.Add(node, entries);
                }
                entries.Add(symbol);
            }
        }

        public IEnumerable<object> GetSymbols()
        {
            return this.symbolToEntry.Keys.ToList();
        }

        public IEnumerable<ScopeEntry> GetEntryBySymbol(object symbol)
        {
            if (symbol == null) return null;
            HashSet<ScopeEntry> result = null;
            this.symbolToEntry.TryGetValue(symbol, out result);
            return result;
        }

        public IEnumerable<object> GetSymbolByNode(IParseTree node)
        {
            if (node == null) return null;
            HashSet<object> result = null;
            this.nodeToSymbol.TryGetValue(node, out result);
            return result;
        }

        public IEnumerable<ScopeEntry> GetEntryByNode(IParseTree node)
        {
            if (node == null) return null;
            HashSet<ScopeEntry> result = null;
            this.nodeToEntry.TryGetValue(node, out result);
            return result;
        }

    }
}
