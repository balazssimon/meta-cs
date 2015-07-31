using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{

    [Flags]
    public enum ResolveFlags
    {
        Children = 1,
        Inherited = 2,
        Parent = 4,
        Imported = 8,
        ImportedScope = 16,
        Scope = Children | Inherited,
        All = Children | Inherited | Parent | Imported | ImportedScope
    }

    [Flags]
    public enum ResolveKind
    {
        Name = 1,
        Type = 2,
        NameOrType = Name | Type
    }

    public enum NameAccessOrder
    {
        Random,
        Serial,
    }

    public class ResolutionInfo
    {
        public ResolutionInfo()
        {
            this.Position = -1;
        }

        public IParseTree Node { get; set; }
        public int Position { get; set; }
        public IEnumerable<Type> SymbolTypes { get; set; }
    }

    public class BindingInfo
    {
        public IParseTree Node { get; set; }
    }

    public interface INameProvider
    {
        string GetName(IParseTree node);
        object GetValue(IParseTree node);
    }

    public interface IResolutionProvider
    {
        IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, List<string> qualifiedName, ResolutionInfo info, ResolveFlags flags);
        IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, string name, ResolutionInfo info, ResolveFlags flags);
    }

    public interface IBindingProvider
    {
        ModelObject Bind(ModelObject context, IEnumerable<ModelObject> alternatives, BindingInfo info);
    }

    public abstract class NameProviderBase : INameProvider
    {
        public MetaCompiler Compiler { get; private set; }

        public NameProviderBase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
        }

        public abstract string GetName(IParseTree node);
        public abstract object GetValue(IParseTree node);
    }

    public class DefaultNameProvider : NameProviderBase
    {
        public DefaultNameProvider(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override string GetName(IParseTree node)
        {
            if (node == null) return null;
            return node.GetText();
        }

        public override object GetValue(IParseTree node)
        {
            if (node == null) return null;
            return node.GetText();
        }
    }

    public abstract class ResolutionProviderBase : IResolutionProvider
    {
        public MetaCompiler Compiler { get; private set; }

        public ResolutionProviderBase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
        }

        public abstract IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, List<string> qualifiedName, ResolutionInfo info, ResolveFlags flags);
        public abstract IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, string name, ResolutionInfo info, ResolveFlags flags);
    }

    public class DefaultResolutionProvider : ResolutionProviderBase
    {
        public DefaultResolutionProvider(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, List<string> qualifiedName, ResolutionInfo info, ResolveFlags flags)
        {
            if (qualifiedName.Count == 0)
            {
                return new ModelObject[0];
            }
            if (qualifiedName.Count == 1)
            {
                return this.Resolve(scopes, kind, qualifiedName[0], info, flags);
            }
            List<ModelObject> result = new List<ModelObject>();
            ResolutionInfo firstInfo =
                new ResolutionInfo()
                {
                    Node = info.Node,
                    Position = info.Position,
                    SymbolTypes = null
                };
            ResolutionInfo middleInfo =
                new ResolutionInfo()
                {
                    Node = info.Node,
                    Position = -1,
                    SymbolTypes = null
                };
            ResolutionInfo lastInfo =
                new ResolutionInfo()
                {
                    Node = info.Node,
                    Position = -1,
                    SymbolTypes = info.SymbolTypes
                };
            IEnumerable<ModelObject> currentResult = scopes;
            for (int i = 0; i < qualifiedName.Count; i++)
            {
                string name = qualifiedName[i];
                bool first = i == 0;
                bool last = i == qualifiedName.Count - 1;
                currentResult = this.Resolve(currentResult, last ? kind : ResolveKind.NameOrType, name, last ? lastInfo : (first ? firstInfo : middleInfo), first ? flags : ResolveFlags.Scope);
            }
            result.AddRange(currentResult);
            return result;
        }

        public override IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, string name, ResolutionInfo info, ResolveFlags flags)
        {
            List<ModelObject> result = new List<ModelObject>();
            foreach (var scope in scopes)
            {
                if (flags.HasFlag(ResolveFlags.Children))
                {
                    result.AddRange(this.ResolveEntries(this.GetEntries<ScopeEntryAttribute>(scope), kind, name, info));
                }
                if (flags.HasFlag(ResolveFlags.Inherited))
                {
                    result.AddRange(this.Resolve(this.GetScopes<InheritedScopeAttribute>(scope), kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }, ResolveFlags.Scope));
                }
                if (flags.HasFlag(ResolveFlags.Imported))
                {
                    result.AddRange(this.Resolve(this.GetScopes<ImportedScopeAttribute>(scope), kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }, ResolveFlags.Scope));
                }
                if (flags.HasFlag(ResolveFlags.ImportedScope))
                {
                    result.AddRange(this.ResolveEntries(this.GetEntries<ImportedEntryAttribute>(scope), kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }));
                }
            }
            if (flags.HasFlag(ResolveFlags.Parent) && result.Count == 0)
            {
                List<ModelObject> parentScopes = new List<ModelObject>();
                foreach (var scope in scopes)
                {
                    ModelObject parentScope = this.GetParentScope(scope);
                    if (parentScope != null)
                    {
                        parentScopes.Add(parentScope);
                    }
                }
                if (parentScopes.Count > 0)
                {
                    result.AddRange(this.Resolve(parentScopes, kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }, flags));
                }
            }
            return result;
        }

        private object GetName(ModelObject entry)
        {
            if (entry != null)
            {
                foreach (var prop in entry.MGetAllProperties())
                {
                    if (prop.Annotations.Any(a => a is NameAttribute))
                    {
                        return entry.MGet(prop);
                    }
                }
            }
            return null;
        }

        private ModelObject GetParentScope(ModelObject scope)
        {
            if (scope == null) return null;
            ModelObject parent = scope.MParent;
            while (parent != null && !parent.IsMetaScope())
            {
                parent = parent.MParent;
            }
            return parent;
        }

        private IEnumerable<ModelObject> GetScopes<T>(ModelObject scope)
            where T : Attribute
        {
            List<ModelObject> result = new List<ModelObject>();
            foreach (var prop in scope.MGetAllProperties())
            {
                if (prop.Annotations.Any(a => a is T))
                {
                    object entry = scope.MGet(prop);
                    ModelCollection scopeEntries = entry as ModelCollection;
                    if (scopeEntries != null)
                    {
                        IEnumerable<object> scopeEntryList = scopeEntries as IEnumerable<object>;
                        foreach (var scopeEntry in scopeEntryList)
                        {
                            ModelObject scopeEntryObject = scopeEntry as ModelObject;
                            if (scopeEntryObject != null)
                            {
                                result.Add(scopeEntryObject);
                            }
                        }
                    }
                    else
                    {
                        ModelObject entryObject = entry as ModelObject;
                        if (entryObject != null)
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }

        private IEnumerable<ModelObject> GetEntries<T>(ModelObject scope)
            where T : Attribute
        {
            List<ModelObject> result = new List<ModelObject>();
            foreach (var prop in scope.MGetAllProperties())
            {
                if (prop.Annotations.Any(a => a is T))
                {
                    object entry = scope.MGet(prop);
                    ModelCollection scopeEntries = entry as ModelCollection;
                    if (scopeEntries != null)
                    {
                        IEnumerable<object> scopeEntryList = scopeEntries as IEnumerable<object>;
                        foreach (var scopeEntry in scopeEntryList)
                        {
                            ModelObject scopeEntryObject = scopeEntry as ModelObject;
                            if (scopeEntryObject != null)
                            {
                                result.Add(scopeEntryObject);
                            }
                        }
                    }
                    else
                    {
                        ModelObject entryObject = entry as ModelObject;
                        if (entryObject != null)
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }

        private IEnumerable<ModelObject> ResolveEntries(IEnumerable<ModelObject> entries, ResolveKind kind, string name, ResolutionInfo info)
        {
            List<ModelObject> result = new List<ModelObject>();
            foreach (var entry in entries)
            {
                ModelObject entryObject = entry as ModelObject;
                if (entryObject != null && name.Equals(this.GetName(entryObject)))
                {
                    if ((kind.HasFlag(ResolveKind.Type) && entryObject.IsMetaType())
                        || (kind.HasFlag(ResolveKind.Name) && !entryObject.IsMetaType()))
                    {
                        result.Add(entryObject);
                    }
                }
            }
            return result;
        }
    }

    public abstract class BindingProviderBase : IBindingProvider
    {
        public MetaCompiler Compiler { get; private set; }

        public BindingProviderBase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
        }

        public abstract ModelObject Bind(ModelObject context, IEnumerable<ModelObject> alternatives, BindingInfo info);
    }

    public class DefaultBindingProvider : BindingProviderBase
    {
        public DefaultBindingProvider(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override ModelObject Bind(ModelObject context, IEnumerable<ModelObject> alternatives, BindingInfo info)
        {
            List<ModelObject> alternativeList = alternatives.ToList();
            if (alternativeList.Count == 0)
            {
                this.Compiler.Diagnostics.AddError("Cannot resolve name or type.", this.Compiler.FileName, new TextSpan(info.Node));
                return null;
            }
            else if (alternativeList.Count > 1)
            {
                this.Compiler.Diagnostics.AddError("Ambiguous name or type.", this.Compiler.FileName, new TextSpan(info.Node));
                return null;
            }
            else
            {
                ModelObject symbol = alternativeList[0];
                // TODO
                return symbol;
            }
        }
    }
}
