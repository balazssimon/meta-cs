using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    [Flags]
    public enum LookupFlags : uint
    {
        None = 0,
        UseBaseReferenceAccessibility = 1 << 1,
        Namespaces = 1 << 2,
        Types = 1 << 3,
        InstanceMembers = 1 << 4,
        StaticMembers = 1 << 5,

        NamespacesOrTypes = Namespaces | Types,
        Members = InstanceMembers | StaticMembers,
        Names = Namespaces | Members,
        NamespacesOrTypesOrMembers = NamespacesOrTypes | Members
    }

    [Flags]
    public enum BindingFlags : uint
    {
        None = 0,

        /// <summary>
        /// Indicates that this binder is being used to answer SemanticModel questions (i.e. not
        /// for batch compilation).
        /// </summary>
        /// <remarks>
        /// Imports touched by a binder with this flag set are not consider "used".
        /// </remarks>
        SemanticModel = 1 << 1,
    }

    public class SymbolBindingOptions
    {
        public static readonly SymbolBindingOptions None = new SymbolBindingOptions(LookupFlags.None, BindingFlags.None, ImmutableArray<Type>.Empty);
        public static readonly SymbolBindingOptions Default = new SymbolBindingOptions(LookupFlags.NamespacesOrTypesOrMembers, BindingFlags.None, ImmutableArray<Type>.Empty);

        private LookupFlags lookupFlags;
        private BindingFlags bindingFlags;
        private ImmutableArray<Type> symbolTypes;

        protected SymbolBindingOptions(LookupFlags lookupFlags, BindingFlags bindingFlags, ImmutableArray<Type> symbolTypes)
        {
            this.lookupFlags = lookupFlags;
            this.bindingFlags = bindingFlags;
            this.symbolTypes = symbolTypes;
        }

        public bool IsDefault
        {
            get { return this == SymbolBindingOptions.Default; }
        }

        public LookupFlags LookupFlags
        {
            get { return this.lookupFlags; }
        }

        public BindingFlags BindingFlags
        {
            get { return this.bindingFlags; }
        }

        public ImmutableArray<Type> SymbolTypes
        {
            get { return this.symbolTypes; }
        }

        public bool LookupUseBaseReferenceAccessibility
        {
            get { return (this.lookupFlags & LookupFlags.UseBaseReferenceAccessibility) != 0; }
        }

        public bool LookupNamespaces
        {
            get { return (this.lookupFlags & LookupFlags.Namespaces) != 0; }
        }

        public bool LookupTypes
        {
            get { return (this.lookupFlags & LookupFlags.Types) != 0; }
        }

        public bool LookupInstanceMembers
        {
            get { return (this.lookupFlags & LookupFlags.InstanceMembers) != 0; }
        }

        public bool LookupStaticMembers
        {
            get { return (this.lookupFlags & LookupFlags.StaticMembers) != 0; }
        }

        public bool BindSemanticModel
        {
            get { return (this.bindingFlags & BindingFlags.SemanticModel) != 0; }
        }

        protected virtual SymbolBindingOptions Update(LookupFlags lookupFlags, BindingFlags bindingFlags, ImmutableArray<Type> symbolTypes)
        {
            if (this.lookupFlags != lookupFlags || this.bindingFlags != bindingFlags || this.symbolTypes != symbolTypes)
            {
                return new SymbolBindingOptions(lookupFlags, bindingFlags, symbolTypes);
            }
            return this;
        }

        public SymbolBindingOptions SetLookupFlags(LookupFlags flags)
        {
            return this.SetLookupFlagsCore(flags);
        }

        protected virtual SymbolBindingOptions SetLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(flags, this.bindingFlags, this.symbolTypes);
        }

        public SymbolBindingOptions AddLookupFlags(LookupFlags flags)
        {
            return this.AddLookupFlagsCore(flags);
        }

        protected virtual SymbolBindingOptions AddLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(this.lookupFlags | flags, this.bindingFlags, this.symbolTypes);
        }

        public SymbolBindingOptions RemoveLookupFlags(LookupFlags flags)
        {
            return this.RemoveLookupFlagsCore(flags);
        }

        protected virtual SymbolBindingOptions RemoveLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(this.lookupFlags & ~flags, this.bindingFlags, this.symbolTypes);
        }

        public SymbolBindingOptions SetBindingFlags(BindingFlags flags)
        {
            return this.SetBindingFlagsCore(flags);
        }

        protected virtual SymbolBindingOptions SetBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, flags, this.symbolTypes);
        }

        public SymbolBindingOptions AddBindingFlags(BindingFlags flags)
        {
            return this.AddBindingFlagsCore(flags);
        }

        protected virtual SymbolBindingOptions AddBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, this.bindingFlags | flags, this.symbolTypes);
        }

        public SymbolBindingOptions RemoveBindingFlags(BindingFlags flags)
        {
            return this.RemoveBindingFlagsCore(flags);
        }

        protected virtual SymbolBindingOptions RemoveBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, this.bindingFlags & ~flags, this.symbolTypes);
        }

        public SymbolBindingOptions WithSymbolTypes(ImmutableArray<Type> symbolTypes)
        {
            return this.Update(this.lookupFlags, this.bindingFlags, symbolTypes);
        }
    }

}
