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

    public class ScopeResolutionInfo
    {
        public int Position { get; set; }
        public IEnumerable<Type> SymbolTypes { get; set; }
    }

    public interface INameProvider
    {
        string GetName(IParseTree node);
    }

    public interface IResolutionProvider
    {
        IEnumerable<object> Resolve(IEnumerable<object> scopes, ResolveKind kind, string name, object info, ResolveFlags flags);
    }

    public interface IBindingProvider
    {
        object Bind(object context, IEnumerable<object> alternatives, object info);
    }

    public abstract class NameProviderBase : INameProvider
    {
        public MetaCompiler Compiler { get; private set; }

        public NameProviderBase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
        }

        public abstract string GetName(IParseTree node);
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
    }

    public abstract class ResolutionProviderBase : IResolutionProvider
    {
        public MetaCompiler Compiler { get; private set; }

        public ResolutionProviderBase(MetaCompiler compiler)
        {
            this.Compiler = compiler;
        }

        public abstract IEnumerable<object> Resolve(IEnumerable<object> scopes, ResolveKind kind, string name, object info, ResolveFlags flags);
    }

    public class DefaultResolutionProvider : ResolutionProviderBase
    {
        public DefaultResolutionProvider(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override IEnumerable<object> Resolve(IEnumerable<object> scopes, ResolveKind kind, string name, object info, ResolveFlags flags)
        {
            List<object> result = new List<object>();
            ScopeResolutionInfo sri = info as ScopeResolutionInfo;
            foreach (var scopeObj in scopes)
            {
                Scope scope = scopeObj as Scope;
                if (scope != null)
                {
                    if (scope.Entries != null && flags.HasFlag(ResolveFlags.Children))
                    {
                        int i = 0;
                        foreach (var ent in scope.Entries)
                        {
                            ++i;
                            ScopeEntry entry = ent as ScopeEntry;
                            if (entry != null && entry.Name == name)
                            {
                                NameDef nameDef = null;
                                if (kind.HasFlag(ResolveKind.Name))
                                {
                                    nameDef = entry as NameDef;
                                }
                                TypeDef typeDef = null;
                                if (kind.HasFlag(ResolveKind.Type))
                                {
                                    typeDef = entry as TypeDef;
                                }
                                if (nameDef != null || typeDef != null)
                                {
                                    bool positionOK = entry.AccessOrder == NameAccessOrder.Random || sri == null || sri.Position <= 0 || i < sri.Position;
                                    bool symbolTypeOK = sri == null || sri.SymbolTypes == null || sri.SymbolTypes.Any(st => (typeDef != null && st.IsAssignableFrom(typeDef.SymbolType)) || (nameDef != null && st.IsAssignableFrom(nameDef.SymbolType)));
                                    if (positionOK && symbolTypeOK)
                                    {
                                        result.Add(entry);
                                    }
                                }
                            }
                        }
                    }
                    if (flags.HasFlag(ResolveFlags.Inherited) && scope.InheritedEntries != null)
                    {
                        foreach (var entry in scope.InheritedEntries)
                        {
                            Scope inheritedScope = null;
                            if (kind.HasFlag(ResolveKind.Name))
                            {
                                NameDef nameDef = entry as NameDef;
                                if (nameDef != null && nameDef.Scope != null)
                                {
                                    inheritedScope = nameDef.Scope;
                                }
                            }
                            if (kind.HasFlag(ResolveKind.Type))
                            {
                                TypeDef typeDef = entry as TypeDef;
                                if (typeDef != null && typeDef.Scope != null)
                                {
                                    inheritedScope = typeDef.Scope;
                                }
                            }
                            if (inheritedScope != null)
                            {
                                ScopeResolutionInfo inheritedInfo = null;
                                if (sri != null)
                                {
                                    inheritedInfo = new ScopeResolutionInfo()
                                    {
                                        Position = 0,
                                        SymbolTypes = sri.SymbolTypes
                                    };
                                }
                                IEnumerable<object> inheritedResults = this.Resolve(new object[] { inheritedScope }, kind, name, inheritedInfo, ResolveFlags.Scope);
                                result.AddRange(inheritedResults);
                            }
                        }
                    }
                    if (result.Count == 0 && flags.HasFlag(ResolveFlags.Parent))
                    {
                        Scope parentScope = null;
                        if (scope.Parent != null)
                        {
                            parentScope = scope.Parent;
                        }
                        else if (scope.Owner != null && scope.Owner.Parent != null)
                        {
                            parentScope = scope.Owner.Parent;
                        }
                        ScopeResolutionInfo parentInfo = null;
                        if (sri != null)
                        {
                            parentInfo = new ScopeResolutionInfo()
                            {
                                Position = sri.Position <= 0 ? 0 : scope.Position,
                                SymbolTypes = sri.SymbolTypes
                            };
                        }
                        IEnumerable<object> parentResults = this.Resolve(new object[] { parentScope }, kind, name, parentInfo, ResolveFlags.Scope | ResolveFlags.Parent);
                        result.AddRange(parentResults);
                    }
                    if (flags.HasFlag(ResolveFlags.Imported) && scope.ImportedEntries != null)
                    {
                        foreach (var entry in scope.ImportedEntries)
                        {
                            if (entry.Name == name)
                            {
                                NameDef nameDef = null;
                                if (kind.HasFlag(ResolveKind.Name))
                                {
                                    nameDef = entry as NameDef;
                                }
                                TypeDef typeDef = null;
                                if (kind.HasFlag(ResolveKind.Name))
                                {
                                    typeDef = entry as TypeDef;
                                }
                                if (nameDef != null || typeDef != null)
                                {
                                    bool symbolTypeOK = sri == null || sri.SymbolTypes == null || sri.SymbolTypes.Any(st => (nameDef != null && st.IsAssignableFrom(nameDef.SymbolType)) || (typeDef != null && st.IsAssignableFrom(typeDef.SymbolType)));
                                    if (symbolTypeOK)
                                    {
                                        result.Add(entry);
                                    }
                                }
                            }
                        }
                    }
                    if (flags.HasFlag(ResolveFlags.ImportedScope) && scope.ImportedEntries != null)
                    {
                        foreach (var entry in scope.ImportedEntries)
                        {
                            Scope importedScope = null;
                            NameDef nameDef = null;
                            if (kind.HasFlag(ResolveKind.Name))
                            {
                                nameDef = entry as NameDef;
                            }
                            TypeDef typeDef = null;
                            if (kind.HasFlag(ResolveKind.Name))
                            {
                                typeDef = entry as TypeDef;
                            }
                            if (nameDef != null)
                            {
                                importedScope = nameDef.Scope;
                            }
                            if (typeDef != null)
                            {
                                importedScope = typeDef.Scope;
                            }
                            if (importedScope != null)
                            {
                                ScopeResolutionInfo importedInfo = null;
                                if (sri != null)
                                {
                                    importedInfo = new ScopeResolutionInfo()
                                    {
                                        Position = 0,
                                        SymbolTypes = sri.SymbolTypes
                                    };
                                }
                                IEnumerable<object> importedResults = this.Resolve(new object[] { importedScope }, kind, name, importedInfo, ResolveFlags.Scope);
                                result.AddRange(importedResults);
                            }
                        }
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

        public abstract object Bind(object context, IEnumerable<object> alternatives, object info);
    }

    public class DefaultBindingProvider : BindingProviderBase
    {
        public DefaultBindingProvider(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override object Bind(object context, IEnumerable<object> alternatives, object info)
        {
            List<object> alternativeList = alternatives.ToList();
            if (alternativeList.Count == 0)
            {
                //this.Compiler.Diagnostics.AddError("Could not resolve name or type.", this.Compiler.FileName, new TextSpan());
                // TODO
                return null;
            }
            else if (alternativeList.Count > 1)
            {
                // TODO
                return null;
            }
            else
            {
                object symbol = alternativeList[0];
                TypeDef typeDef = symbol as TypeDef;
                if (typeDef != null)
                {
                    return typeDef.Symbol;
                }
                NameDef nameDef = symbol as NameDef;
                if (nameDef != null)
                {
                    return nameDef.Symbol;
                }
                return symbol;
            }
        }
    }
}
