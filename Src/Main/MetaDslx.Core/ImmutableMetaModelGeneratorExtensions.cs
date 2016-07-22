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
        Factory,
        Implementation,
        ImplementationBase,
        ImplementationProvider
    }

    internal enum NamespaceKind
    {
        Public,
        Internal,
        Implementation
    }

    internal enum ClassKind
    {
        None,
        Id,
        Immutable,
        Builder,
        Descriptor,
        ImmutableInstance,
        BuilderInstance,
        FactoryMethod,
        Implementation
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
        public static string CoreNs = "global::MetaDslx.Core.Immutable";

        public string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false)
        {
            if (mnamespace == null) return string.Empty;
            if (!fullName) return mnamespace.Name;
            string result = string.Empty;
            MetaNamespace currentNs = mnamespace;
            while (currentNs != null)
            {
                if (!string.IsNullOrEmpty(result)) result = "." + result;
                result = currentNs.Name + result;
                currentNs = currentNs.Parent;
            }
            switch (kind)
            {
                case NamespaceKind.Internal:
                    result = result + ".Internal";
                    break;
                case NamespaceKind.Implementation:
                    result = result + ".Implementation";
                    break;
                default:
                    break;
            }
            return result;
        }

        public string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false)
        {
            if (mmodel == null) return string.Empty;
            string result;
            switch (kind)
            {
                case ModelKind.ImmutableInstance:
                    result = mmodel.Name + "Instance";
                    break;
                case ModelKind.BuilderInstance:
                    result = mmodel.Name + "BuilderInstance";
                    break;
                case ModelKind.Descriptor:
                    result = mmodel.Name + "Descriptor";
                    break;
                case ModelKind.Factory:
                    result = mmodel.Name + "Factory";
                    break;
                case ModelKind.Implementation:
                    result = mmodel.Name + "Implementation";
                    break;
                case ModelKind.ImplementationBase:
                    result = mmodel.Name + "ImplementationBase";
                    break;
                case ModelKind.ImplementationProvider:
                    result = mmodel.Name + "ImplementationProvider";
                    break;
                default:
                    result = mmodel.Name;
                    break;
            }
            if (fullName)
            {
                if (mmodel.Namespace == null) result = "global::" + result;
                else result = "global::" + this.CSharpName(mmodel.Namespace, this.ToNamespaceKind(kind), true) + "." + result;
            }
            return result;
        }

        public string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            if (mtype == null) return string.Empty;
            if (mtype is MetaPrimitiveType) return this.CSharpName((MetaPrimitiveType)mtype, mmodel, kind, fullName);
            if (mtype is MetaCollectionType) return this.CSharpName((MetaCollectionType)mtype, mmodel, kind, fullName);
            if (mtype is MetaNullableType) return this.CSharpName((MetaNullableType)mtype, mmodel, kind, fullName);
            if (mtype is MetaEnum) return this.CSharpName((MetaEnum)mtype, mmodel, kind, fullName);
            if (mtype is MetaClass) return this.CSharpName((MetaClass)mtype, mmodel, kind, fullName);
            return string.Empty;
        }

        private string CSharpName(MetaPrimitiveType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            string result;
            switch (kind)
            {
                case ClassKind.ImmutableInstance:
                    result = this.ToPascalCase(mtype.Name);
                    break;
                case ClassKind.BuilderInstance:
                    result = this.ToPascalCase(mtype.Name);
                    break;
                case ClassKind.FactoryMethod:
                    result = this.ToPascalCase(mtype.Name);
                    break;
                default:
                    result = mtype.Name;
                    break;
            }
            if (fullName)
            {
                if (kind == ClassKind.ImmutableInstance || kind == ClassKind.BuilderInstance || kind == ClassKind.FactoryMethod)
                {
                    string fullNamePrefix = this.CSharpName(mmodel, this.ToModelKind(kind), !this.ContainsType(mmodel, mtype));
                    result = "global::" + fullNamePrefix + "." + result;
                }
            }
            return result;
        }

        private string CSharpName(MetaCollectionType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            string result = this.CSharpName(mtype.InnerType, mmodel, kind, fullName);
            string collectionName;
            switch (mtype.Kind)
            {
                case MetaCollectionKind.List:
                case MetaCollectionKind.MultiList:
                    if (kind == ClassKind.Builder) collectionName = "MutableModelList";
                    else collectionName = "ImmutableModelList";
                    break;
                case MetaCollectionKind.Set:
                case MetaCollectionKind.MultiSet:
                    if (kind == ClassKind.Builder) collectionName = "MutableModelSet";
                    else collectionName = "ImmutableModelSet";
                    break;
                default:
                    collectionName = "";
                    break;
            }
            result = CoreNs + "." + collectionName + "<" + result + ">";
            return result;
        }

        private string CSharpName(MetaNullableType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            string result = this.CSharpName(mtype.InnerType, mmodel, kind, fullName);
            if (mtype.InnerType is MetaPrimitiveType)
            {
                MetaPrimitiveType mpt = (MetaPrimitiveType)mtype.InnerType;
                if (mpt.Name != "object" || mpt.Name != "string")
                {
                    result = result + "?";
                }
            }
            return result;
        }

        private string CSharpName(MetaEnum mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            string result = mtype.Name;
            if (fullName)
            {
                bool modelContainsType = this.ContainsType(mmodel, mtype);
                if (kind == ClassKind.Descriptor || kind == ClassKind.ImmutableInstance || kind == ClassKind.BuilderInstance || kind == ClassKind.FactoryMethod)
                {
                    string fullNamePrefix = this.CSharpName(mtype.MetaModel, this.ToModelKind(kind), !modelContainsType);
                    result = fullNamePrefix + "." + result;
                }
                else if (!modelContainsType)
                {
                    string fullNamePrefix = this.CSharpName(mtype.Namespace, this.ToNamespaceKind(kind), true);
                    result = "global::" + fullNamePrefix + "." + result;
                }
            }
            return result;
        }

        private string CSharpName(MetaClass mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            string result = mtype.Name;
            switch (kind)
            {
                case ClassKind.Id:
                    result = result + "Id";
                    break;
                case ClassKind.Builder:
                    result = result + "Builder";
                    break;
                case ClassKind.Implementation:
                    result = result + "Impl";
                    break;
                default:
                    break;
            }
            if (fullName)
            {
                string fullNamePrefix;
                bool modelContainsType = this.ContainsType(mmodel, mtype);
                switch (kind)
                {
                    case ClassKind.BuilderInstance:
                        fullNamePrefix = this.CSharpName(mtype.MetaModel, this.ToModelKind(kind), !modelContainsType);
                        result = fullNamePrefix + ".instance." + result;
                        break;
                    case ClassKind.ImmutableInstance:
                    case ClassKind.FactoryMethod:
                    case ClassKind.Implementation:
                        fullNamePrefix = this.CSharpName(mtype.MetaModel, this.ToModelKind(kind), !modelContainsType);
                        result = fullNamePrefix + "." + result;
                        break;
                    default:
                        if (!modelContainsType)
                        {
                            fullNamePrefix = this.CSharpName(mtype.Namespace, this.ToNamespaceKind(kind), true);
                            result = "global::" + fullNamePrefix + "." + result;
                        }
                        break;
                }
            }
            return result;
        }

        public string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false)
        {
            if (mproperty == null) return string.Empty;
            string result;
            switch (kind)
            {
                case PropertyKind.Descriptor:
                    result = mproperty.Name + "Property";
                    break;
                case PropertyKind.ImmutableInstance:
                    result = this.CSharpName(mproperty.Class, mmodel, ClassKind.ImmutableInstance, false) + "_" + mproperty.Name;
                    break;
                case PropertyKind.BuilderInstance:
                    result = this.CSharpName(mproperty.Class, mmodel, ClassKind.BuilderInstance, false) + "_" + mproperty.Name;
                    break;
                default:
                    result = mproperty.Name;
                    break;
            }
            if (fullName)
            {
                string fullNamePrefix;
                switch (kind)
                {
                    case PropertyKind.Immutable:
                    case PropertyKind.Builder:
                    case PropertyKind.Descriptor:
                        fullNamePrefix = this.CSharpName(mproperty.Class, mmodel, this.ToClassKind(kind), true) + ".";
                        break;
                    case PropertyKind.ImmutableInstance:
                        fullNamePrefix = this.CSharpName(mproperty.Class.MetaModel, ModelKind.ImmutableInstance, !this.ContainsType(mmodel, mproperty.Class)) + ".";
                        break;
                    case PropertyKind.BuilderInstance:
                        fullNamePrefix = this.CSharpName(mproperty.Class.MetaModel, ModelKind.BuilderInstance, !this.ContainsType(mmodel, mproperty.Class)) + ".instance.";
                        break;
                    default:
                        fullNamePrefix = string.Empty;
                        break;
                }
                result = fullNamePrefix + result;
            }
            return result;
        }

        public string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            string result = mconst.Name;
            if (fullName)
            {
                string fullNamePrefix;
                switch (kind)
                {
                    case ClassKind.BuilderInstance:
                        fullNamePrefix = this.CSharpName(mmodel, this.ToModelKind(kind), !this.ContainsConst(mmodel, mconst));
                        result = fullNamePrefix + ".instance." + result;
                        break;
                    case ClassKind.ImmutableInstance:
                    case ClassKind.FactoryMethod:
                    case ClassKind.Implementation:
                        fullNamePrefix = this.CSharpName(mmodel, this.ToModelKind(kind), !this.ContainsConst(mmodel, mconst));
                        result = fullNamePrefix + "." + result;
                        break;
                    default:
                        fullNamePrefix = this.CSharpName(mconst.Namespace, this.ToNamespaceKind(kind), fullName);
                        result = "global::" + fullNamePrefix + "." + result;
                        break;
                }
            }
            return result;
        }

        public string ToCamelCase(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            else return identifier[0].ToString().ToLower() + identifier.Substring(1);
        }

        public string ToPascalCase(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            else return identifier[0].ToString().ToUpper() + identifier.Substring(1);
        }

        private ModelKind ToModelKind(ClassKind kind)
        {
            switch (kind)
            {
                case ClassKind.Descriptor:
                    return ModelKind.Descriptor;
                case ClassKind.ImmutableInstance:
                    return ModelKind.ImmutableInstance;
                case ClassKind.BuilderInstance:
                    return ModelKind.BuilderInstance;
                case ClassKind.FactoryMethod:
                    return ModelKind.Factory;
                case ClassKind.Implementation:
                    return ModelKind.ImplementationProvider;
                default:
                    return ModelKind.None;
            }
        }

        private NamespaceKind ToNamespaceKind(ModelKind kind)
        {
            switch (kind)
            {
                case ModelKind.Implementation:
                case ModelKind.ImplementationBase:
                    return NamespaceKind.Internal;
                case ModelKind.BuilderInstance:
                case ModelKind.ImplementationProvider:
                    return NamespaceKind.Implementation;
                default:
                    return NamespaceKind.Public;
            }
        }

        private NamespaceKind ToNamespaceKind(ClassKind kind)
        {
            return this.ToNamespaceKind(this.ToModelKind(kind));
        }

        private ClassKind ToClassKind(PropertyKind kind)
        {
            switch (kind)
            {
                case PropertyKind.Immutable:
                    return ClassKind.Immutable;
                case PropertyKind.Builder:
                    return ClassKind.Builder;
                case PropertyKind.Descriptor:
                    return ClassKind.Descriptor;
                case PropertyKind.ImmutableInstance:
                    return ClassKind.ImmutableInstance;
                case PropertyKind.BuilderInstance:
                    return ClassKind.BuilderInstance;
                default:
                    return ClassKind.None;
            }
        }

        public bool IsCoreModel(MetaModel mmodel)
        {
            if (mmodel == null) return false;
            return this.CSharpName(mmodel, ModelKind.None, true) == "global::MetaDslx.Core.Meta";
        }

        private bool IsSameModel(MetaModel m1, MetaModel m2)
        {
            return this.CSharpName(m1, ModelKind.None, true) == this.CSharpName(m2, ModelKind.None, true);
        }

        private bool ContainsType(MetaModel mmodel, MetaType mtype)
        {
            if (mmodel == null) return false;
            if (this.IsCoreModel(mmodel)) return true;
            if (mtype is MetaDeclaration)
            {
                return mmodel.Namespace.Declarations.Contains((MetaDeclaration)mtype);
            }
            else if (mtype is MetaPrimitiveType)
            {
                return mmodel.Namespace.Declarations.Any(d => d is MetaConstant && ((MetaConstant)d).Type == MetaInstance.MetaPrimitiveType && ((MetaConstant)d).Name == this.ToPascalCase(((MetaPrimitiveType)mtype).Name));
            }
            return false;
        }

        private bool ContainsConst(MetaModel mmodel, MetaConstant mconst)
        {
            if (mmodel == null) return false;
            if (this.IsCoreModel(mmodel)) return true;
            return mmodel.Namespace.Declarations.Contains((MetaDeclaration)mconst);
        }
    }
    //*/
}
