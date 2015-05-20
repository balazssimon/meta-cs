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

    public abstract class ScopeEntry
    {
        public ScopeEntry(string name, object kind, Scope parent)
        {
            this.Name = name;
            this.Kind = kind;
            this.TreeNodes = new HashSet<IParseTree>();
            this.Parent = parent;
            if (this.Parent != null)
            {
                this.Parent.children.Add(this);
                this.Position = this.Parent.children.Count;
            }
        }

        public string Name { get; private set; }
        public object Kind { get; private set; }
        public Scope Parent { get; internal set; }
        public int Position { get; internal set; }
        public NameAccessOrder AccessOrder { get; set; }

        public ModelObject ModelObject { get; set; }
        public HashSet<IParseTree> TreeNodes { get; private set; }

        public override string ToString()
        {
            if (this.Parent == null) return this.Name;
            else return this.Parent.ToString() + "." + this.Name;
        }
    }

    public class NameDefinition : ScopeEntry
    {
        public NameDefinition(string name, object kind, Scope parent)
            : base(name, kind, parent)
        {
        }

        public TypeDefinition Type { get; set; }
    }

    public class NameReference : ScopeEntry
    {
        public NameReference(string name, object kind, Scope parent)
            : base(name, kind, parent)
        {
        }
        public ScopeEntry NameDef { get; set; }
        public override string ToString()
        {
            if (this.NameDef != null)
            {
                return "NameRef:" + this.NameDef;
            }
            else
            {
                return base.ToString();
            }
        }
    }

    public class TypeDefinition : Scope
    {
        public TypeDefinition(string name, object kind, Scope parent)
            : base(name, kind, parent)
        {
        }

        public override bool Equals(object obj)
        {
            return obj != null && object.ReferenceEquals(this, obj);
        }
    }

    public class TypeReference : ScopeEntry
    {
        public TypeReference(string name, object kind, Scope parent)
            : base(name, kind, parent)
        {
        }

        public TypeDefinition TypeDef { get; set; }
        public override bool Equals(object obj)
        {
            TypeReference typeRef = obj as TypeReference;
            if (typeRef != null && this.TypeDef == typeRef.TypeDef) return true;
            TypeDefinition typeDef = obj as TypeDefinition;
            if (typeDef != null && this.TypeDef == typeDef) return true;
            return false;
        }
        public override string ToString()
        {
            if (this.TypeDef != null)
            {
                return "TypeRef:" + this.TypeDef;
            }
            else
            {
                return base.ToString();
            }
        }
    }

    public class Scope : ScopeEntry
    {
        internal List<ScopeEntry> children;

        public Scope(string name, object kind, Scope parent)
            : base(name, kind, parent)
        {
            this.children = new List<ScopeEntry>();
            this.Inherited = new List<Scope>();
            this.Imported = new List<Scope>();
        }

        public IEnumerable<ScopeEntry> Children 
        { 
            get
            {
                return this.children;
            }
        }
        public List<Scope> Inherited { get; private set; }
        public List<Scope> Imported { get; private set; }


        private TEntry Resolve<TEntry>(string name, object kinds, int position = 0, ResolveFlags flags = ResolveFlags.All)
            where TEntry : ScopeEntry
        {
            if (flags.HasFlag(ResolveFlags.Children))
            {
                foreach (var child in this.Children)
                {
                    bool positionOK = child.AccessOrder == NameAccessOrder.Random || position <= 0 || child.Position < position;
                    IEnumerable<object> kindsEnum = kinds as IEnumerable<object>;
                    bool kindOK = kinds == null || kinds.Equals(child.Kind) || (kindsEnum != null && kindsEnum.Contains(child.Kind));
                    if (positionOK && kindOK && child.Name == name)
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
                    TEntry result = inherited.Resolve<TEntry>(name, kinds, 0, flags);
                    if (result != null) return result;
                }
            }
            if (flags.HasFlag(ResolveFlags.Parent))
            {
                if (this.Parent != null) return this.Parent.Resolve<TEntry>(name, kinds, position <= 0 ? 0 : this.Position, flags);
            }
            if (flags.HasFlag(ResolveFlags.Imported))
            {
                foreach (var imported in this.Imported)
                {
                    TEntry result = imported.Resolve<TEntry>(name, kinds, 0, flags);
                    if (result != null) return result;
                }
            }
            return null;
        }

        public ScopeEntry ResolveName(string name, object kinds, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.Resolve<ScopeEntry>(name, kinds, position, flags);
        }

        public TypeDefinition ResolveType(string name, object kinds, int position = 0, ResolveFlags flags = ResolveFlags.All)
        {
            return this.Resolve<TypeDefinition>(name, kinds, position, flags);
        }

        public ScopeEntry GetName(string name, object kinds)
        {
            return this.Resolve<ScopeEntry>(name, kinds, -1, ResolveFlags.Children);
        }

        public TypeDefinition RegisterType(TypeDefinition typeDef)
        {
            TypeDefinition result = this.GetType(typeDef);
            if (result != null) return result;
            if (typeDef.Parent == null)
            {
                this.children.Add(typeDef);
                typeDef.Position = this.children.Count;
                typeDef.Parent = this;
                return typeDef;
            }
            return typeDef;
        }

        public TypeDefinition GetType(string name, object kinds)
        {
            return this.Resolve<TypeDefinition>(name, kinds, -1, ResolveFlags.Children);
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
                }
            }
            return null;
        }

        public ScopeEntry ResolveName(List<string> qualifiedName, object kinds, int position = 0)
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
                        index == qualifiedName.Count - 1 ? kinds : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                }
                else
                {
                    ScopeEntry resolved = null;
                    resolved = currentScope.Resolve<ScopeEntry>(
                        qualifiedName[index],
                        index == qualifiedName.Count - 1 ? kinds : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                    Scope scope = resolved as Scope;
                    TypeDefinition type = resolved as TypeDefinition;
                    NameDefinition name = resolved as NameDefinition;
                    if (scope != null)
                    {
                        currentScope = scope;
                    }
                    else if (name != null)
                    {
                        currentScope = name.Type;
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

        public TypeDefinition ResolveType(List<string> qualifiedName, object kinds, int position = 0)
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
                        index == qualifiedName.Count - 1 ? kinds : null,
                        index == 0 ? position : 0,
                        index == 0 ? ResolveFlags.All : ResolveFlags.ChildrenOrInheritedChildren);
                }
                else
                {
                    ScopeEntry resolved = null;
                    currentScope.Resolve<ScopeEntry>(
                        qualifiedName[index],
                        index == qualifiedName.Count - 1 ? kinds : null,
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
}
