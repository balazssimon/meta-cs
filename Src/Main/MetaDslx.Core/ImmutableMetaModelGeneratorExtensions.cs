using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    internal enum ModelKind
    {
        None,
        ImmutableInstance,
        BuilderInstance,
        Descriptor,
        Factory
    }

    internal enum ClassKind
    {
        None,
        Immutable,
        Builder,
        Descriptor,
        ImmutableInstance,
        BuilderInstance,
        FactoryMethod
    }

    internal enum PropertyKind
    {
        None,
        Immutable,
        Builder,
        Descriptor,
        ImmutableInstance,
        BuilderInstance
    }

    //*
    internal class ImmutableMetaModelGeneratorExtensions : IImmutableMetaModelGeneratorExtensions
    {
        public string CSharpName(MetaNamespace mnamespace, bool fullName = false)
        {
            throw new NotImplementedException();
        }

        public string CSharpName(MetaType mtype, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            throw new NotImplementedException();
        }

        public string CSharpName(MetaProperty mproperty, PropertyKind kind = PropertyKind.None, bool fullName = false)
        {
            throw new NotImplementedException();
        }

        public string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false)
        {
            throw new NotImplementedException();
        }

        public string ToCamelCase(string identifier)
        {
            throw new NotImplementedException();
        }

        public string ToPascalCase(string identifier)
        {
            throw new NotImplementedException();
        }
    }
    //*/
}
