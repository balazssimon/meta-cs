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

    public interface INameProvider
    {
        string GetName(IParseTree node);
    }

    public interface IResolutionProvider
    {
        IEnumerable<object> ResolveType(IEnumerable<object> scopes, string name, object info, ResolveFlags flags);
        IEnumerable<object> ResolveName(IEnumerable<object> scopes, string name, object info, ResolveFlags flags);
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

        public abstract IEnumerable<object> ResolveType(IEnumerable<object> scopes, string name, object info, ResolveFlags flags);

        public abstract IEnumerable<object> ResolveName(IEnumerable<object> scopes, string name, object info, ResolveFlags flags);
    }

    public class DefaultResolutionProvider : ResolutionProviderBase
    {
        public DefaultResolutionProvider(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override IEnumerable<object> ResolveType(IEnumerable<object> scopes, string name, object info, ResolveFlags flags)
        {
            return null;
        }

        public override IEnumerable<object> ResolveName(IEnumerable<object> scopes, string name, object info, ResolveFlags flags)
        {
            return null;
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
            return null;
        }
    }
}
