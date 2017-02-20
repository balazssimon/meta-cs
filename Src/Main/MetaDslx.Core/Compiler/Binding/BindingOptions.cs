using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
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

    public class BindingOptions
    {
        public static readonly BindingOptions None = new BindingOptions(LookupFlags.None, BindingFlags.None, null);
        public static readonly BindingOptions Default = new BindingOptions(LookupFlags.NamespacesOrTypesOrMembers, BindingFlags.None, null);

        private LookupFlags lookupFlags;
        private BindingFlags bindingFlags;
        private Type[] symbolTypes;

        protected BindingOptions(LookupFlags lookupFlags, BindingFlags bindingFlags, Type[] symbolTypes)
        {
            this.lookupFlags = lookupFlags;
            this.bindingFlags = bindingFlags;
            this.symbolTypes = symbolTypes;
        }

        public bool IsDefault
        {
            get { return this == BindingOptions.Default; }
        }

        public LookupFlags LookupFlags
        {
            get { return this.lookupFlags; }
        }

        public BindingFlags BindingFlags
        {
            get { return this.bindingFlags; }
        }

        public Type[] SymbolTypes
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

        protected virtual BindingOptions Update(LookupFlags lookupFlags, BindingFlags bindingFlags, Type[] symbolTypes)
        {
            if (this.lookupFlags != lookupFlags || this.bindingFlags != bindingFlags || this.symbolTypes != symbolTypes)
            {
                return new BindingOptions(lookupFlags, bindingFlags, symbolTypes);
            }
            return this;
        }

        public BindingOptions SetLookupFlags(LookupFlags flags)
        {
            return this.SetLookupFlagsCore(flags);
        }

        protected virtual BindingOptions SetLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(flags, this.bindingFlags, this.symbolTypes);
        }

        public BindingOptions AddLookupFlags(LookupFlags flags)
        {
            return this.AddLookupFlagsCore(flags);
        }

        protected virtual BindingOptions AddLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(this.lookupFlags | flags, this.bindingFlags, this.symbolTypes);
        }

        public BindingOptions RemoveLookupFlags(LookupFlags flags)
        {
            return this.RemoveLookupFlagsCore(flags);
        }

        protected virtual BindingOptions RemoveLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(this.lookupFlags & ~flags, this.bindingFlags, this.symbolTypes);
        }

        public BindingOptions SetBindingFlags(BindingFlags flags)
        {
            return this.SetBindingFlagsCore(flags);
        }

        protected virtual BindingOptions SetBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, flags, this.symbolTypes);
        }

        public BindingOptions AddBindingFlags(BindingFlags flags)
        {
            return this.AddBindingFlagsCore(flags);
        }

        protected virtual BindingOptions AddBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, this.bindingFlags | flags, this.symbolTypes);
        }

        public BindingOptions RemoveBindingFlags(BindingFlags flags)
        {
            return this.RemoveBindingFlagsCore(flags);
        }

        protected virtual BindingOptions RemoveBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, this.bindingFlags & ~flags, this.symbolTypes);
        }

        public BindingOptions WithSymbolTypes(Type[] symbolTypes)
        {
            return this.Update(this.lookupFlags, this.bindingFlags, symbolTypes);
        }
    }

}
