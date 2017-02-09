using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class LookupOptions
    {
        public static readonly LookupOptions Default = new LookupOptions();

        public LookupOptions(
            bool useBaseReferenceAccessibility = false,
            bool namespacesOrTypesOnly = false,
            bool mustBeInstance = false,
            bool mustNotBeInstance = false,
            bool mustNotBeNamespace = false)
        {
            this.UseBaseReferenceAccessibility = useBaseReferenceAccessibility;
            this.NamespacesOrTypesOnly = namespacesOrTypesOnly;
            this.MustBeInstance = mustBeInstance;
            this.MustNotBeInstance = mustNotBeInstance;
            this.MustNotBeNamespace = mustNotBeNamespace;
            this.ThrowIfInvalid();
        }

        /// <summary>
        /// Are these options valid in their current combination?
        /// </summary>
        /// <remarks>
        /// Some checks made here:
        /// 
        /// - Default is valid.
        /// - If LabelsOnly is set, it must be the only option.
        /// - If one of MustBeInstance or MustNotBeInstance are set, the other one must not be set.
        /// - If any of MustNotBeInstance, MustBeInstance, or MustNotBeNonInvocableMember are set,
        ///   the options are considered valid.
        /// - If MustNotBeNamespace is set, neither NamespaceAliasesOnly nor NamespacesOrTypesOnly must be set.
        /// - Otherwise, only one of NamespaceAliasesOnly, NamespacesOrTypesOnly, or AllMethodsOnArityZero must be set.
        /// </remarks>
        protected bool IsValid()
        {
            if (this == LookupOptions.Default)
            {
                return true;
            }

            if (this.MustBeInstance || this.MustNotBeInstance)
            {
                return false;
            }

            if (this.MustBeInstance && this.NamespacesOrTypesOnly)
            {
                return false;
            }

            return true;
        }

        public void ThrowIfInvalid()
        {
            if (!this.IsValid())
            {
                throw new ArgumentException("LookupOptions has an invalid combination of options");
            }
        }

        public bool UseBaseReferenceAccessibility { get; }
        public bool NamespacesOrTypesOnly { get; }
        public bool MustBeInstance { get; }
        public bool MustNotBeInstance { get; }
        public bool MustNotBeNamespace { get; }

        public virtual bool CanConsiderMembers()
        {
            return !this.NamespacesOrTypesOnly;
        }

        public virtual bool CanConsiderTypes()
        {
            return !this.MustBeInstance;
        }

        public virtual bool CanConsiderNamespaces()
        {
            return !(this.MustNotBeNamespace | this.MustBeInstance);
        }
    }
}
