using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class SimpleSymbolBindingOptions : BindingOptions
    {
        public static new readonly SimpleSymbolBindingOptions None = new SimpleSymbolBindingOptions(LookupFlags.None, BindingFlags.None, null);
        public static new readonly SimpleSymbolBindingOptions Default = new SimpleSymbolBindingOptions(LookupFlags.NamespacesOrTypesOrMembers, BindingFlags.None, null);
        public static readonly SimpleSymbolBindingOptions Names = new SimpleSymbolBindingOptions(LookupFlags.Names, BindingFlags.None, null);
        public static readonly SimpleSymbolBindingOptions Types = new SimpleSymbolBindingOptions(LookupFlags.Types, BindingFlags.None, null);

        private Type[] symbolTypes;

        public SimpleSymbolBindingOptions(LookupFlags lookupFlags, BindingFlags bindingFlags, Type[] symbolTypes)
            : base(lookupFlags, bindingFlags)
        {
            this.symbolTypes = symbolTypes;
        }

        protected override BindingOptions Update(LookupFlags lookupFlags, BindingFlags bindingFlags)
        {
            if (this.LookupFlags != lookupFlags || this.BindingFlags != bindingFlags)
            {
                return new SimpleSymbolBindingOptions(lookupFlags, bindingFlags, this.symbolTypes);
            }
            return this;
        }

        public SimpleSymbolBindingOptions WithSymbolTypes(Type[] symbolTypes)
        {
            return new SimpleSymbolBindingOptions(this.LookupFlags, this.BindingFlags, symbolTypes);
        }

        public Type[] SymbolTypes
        {
            get { return this.symbolTypes; }
        }
    }
}
