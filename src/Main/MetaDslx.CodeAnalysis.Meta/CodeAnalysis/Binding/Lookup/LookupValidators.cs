using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public static class LookupValidators
    {
        public static readonly MustBeInstanceLookupValidator MustBeInstance = new MustBeInstanceLookupValidator();
        public static readonly MustNotBeNamespaceLookupValidator MustNotBeNamespace = new MustNotBeNamespaceLookupValidator();
        public static readonly NamespaceOrTypeLookupValidator NamespaceOrType = new NamespaceOrTypeLookupValidator();
        public static readonly MustBeModelObjectLookupValidator MustBeModelObject = new MustBeModelObjectLookupValidator();

    }
}
