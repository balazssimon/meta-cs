using System;
using System.Collections.Generic;
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
        public static readonly BindingOptions None = new BindingOptions(LookupFlags.None, BindingFlags.None);
        public static readonly BindingOptions Default = new BindingOptions(LookupFlags.NamespacesOrTypesOrMembers, BindingFlags.None);

        private LookupFlags lookupFlags;
        private BindingFlags bindingFlags;

        protected BindingOptions(LookupFlags lookupFlags, BindingFlags bindingFlags)
        {
            this.lookupFlags = lookupFlags;
            this.bindingFlags = bindingFlags;
        }

        public bool IsDefault
        {
            get { return this == BindingOptions.Default; }
        }

        protected LookupFlags LookupFlags
        {
            get { return this.lookupFlags; }
        }

        protected BindingFlags BindingFlags
        {
            get { return this.bindingFlags; }
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

        protected virtual BindingOptions Update(LookupFlags lookupFlags, BindingFlags bindingFlags)
        {
            if (this.lookupFlags != lookupFlags || this.bindingFlags != bindingFlags)
            {
                return new BindingOptions(lookupFlags, bindingFlags);
            }
            return this;
        }

        protected BindingOptions SetLookupFlags(LookupFlags flags)
        {
            return this.SetLookupFlagsCore(flags);
        }

        protected virtual BindingOptions SetLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(flags, this.bindingFlags);
        }

        protected BindingOptions AddLookupFlags(LookupFlags flags)
        {
            return this.AddLookupFlagsCore(flags);
        }

        protected virtual BindingOptions AddLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(this.lookupFlags | flags, this.bindingFlags);
        }

        protected BindingOptions RemoveLookupFlags(LookupFlags flags)
        {
            return this.RemoveLookupFlagsCore(flags);
        }

        protected virtual BindingOptions RemoveLookupFlagsCore(LookupFlags flags)
        {
            return this.Update(this.lookupFlags & ~flags, this.bindingFlags);
        }

        protected BindingOptions SetBindingFlags(BindingFlags flags)
        {
            return this.SetBindingFlagsCore(flags);
        }

        protected virtual BindingOptions SetBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, flags);
        }

        protected BindingOptions AddBindingFlags(BindingFlags flags)
        {
            return this.AddBindingFlagsCore(flags);
        }

        protected virtual BindingOptions AddBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, this.bindingFlags | flags);
        }

        protected BindingOptions RemoveBindingFlags(BindingFlags flags)
        {
            return this.RemoveBindingFlagsCore(flags);
        }

        protected virtual BindingOptions RemoveBindingFlagsCore(BindingFlags flags)
        {
            return this.Update(this.lookupFlags, this.bindingFlags & ~flags);
        }

        public BindingOptions WithLookupUseBaseReferenceAccessibility(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.UseBaseReferenceAccessibility);
            else return this.RemoveLookupFlags(LookupFlags.UseBaseReferenceAccessibility);
        }

        public BindingOptions WithLookupNamespacesOrTypesOrMembers(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.NamespacesOrTypesOrMembers);
            else return this.RemoveLookupFlags(LookupFlags.NamespacesOrTypesOrMembers);
        }

        public BindingOptions WithLookupNamespacesOrTypes(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.NamespacesOrTypes);
            else return this.RemoveLookupFlags(LookupFlags.NamespacesOrTypes);
        }

        public BindingOptions WithLookupNamespaces(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.Namespaces);
            else return this.RemoveLookupFlags(LookupFlags.Namespaces);
        }

        public BindingOptions WithLookupTypes(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.Types);
            else return this.RemoveLookupFlags(LookupFlags.Types);
        }

        public BindingOptions WithLookupMembers(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.Members);
            else return this.RemoveLookupFlags(LookupFlags.Members);
        }

        public BindingOptions WithLookupInstanceMembers(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.InstanceMembers);
            else return this.RemoveLookupFlags(LookupFlags.InstanceMembers);
        }

        public BindingOptions WithLookupStaticMembers(bool value)
        {
            if (value) return this.AddLookupFlags(LookupFlags.StaticMembers);
            else return this.RemoveLookupFlags(LookupFlags.StaticMembers);
        }

        public BindingOptions WithBindSemanticModel(bool value)
        {
            if (value) return this.AddBindingFlags(BindingFlags.SemanticModel);
            else return this.RemoveBindingFlags(BindingFlags.SemanticModel);
        }
    }

    public class SpeculativeBindingOptions : BindingOptions
    {
        public static new readonly SpeculativeBindingOptions None = new SpeculativeBindingOptions(LookupFlags.None, BindingFlags.None);
        public static new readonly SpeculativeBindingOptions Default = new SpeculativeBindingOptions(LookupFlags.NamespacesOrTypesOrMembers, BindingFlags.None);

        public SpeculativeBindingOptions(LookupFlags lookupFlags, BindingFlags bindingFlags) 
            : base(lookupFlags, bindingFlags)
        {
        }

        protected override BindingOptions Update(LookupFlags lookupFlags, BindingFlags bindingFlags)
        {
            if (this.LookupFlags != lookupFlags || this.BindingFlags != bindingFlags)
            {
                return new SpeculativeBindingOptions(lookupFlags, bindingFlags);
            }
            return this;
        }
    }
}
