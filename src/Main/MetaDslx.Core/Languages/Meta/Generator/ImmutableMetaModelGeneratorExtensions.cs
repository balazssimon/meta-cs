using Roslyn.Utilities;
using MetaDslx.Core;
using MetaDslx.Languages.Meta.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Meta.Generator
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
        Internal
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
        Implementation,
        ImmutableImpl,
        BuilderImpl
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
        public static string CoreNs = "global::MetaDslx.Core";
        public static string MetaNs = "global::MetaDslx.Languages.Meta.Symbols";

        public string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false)
        {
            if (mnamespace == null) return string.Empty;
            if (!fullName) return mnamespace.Name;
            string result = string.Empty;
            MetaNamespace currentNs = mnamespace;
            while (currentNs != null)
            {
                if (!string.IsNullOrEmpty(currentNs.Name))
                {
                    if (!string.IsNullOrEmpty(result)) result = "." + result;
                    result = currentNs.Name + result;
                }
                currentNs = currentNs.Namespace;
            }
            switch (kind)
            {
                case NamespaceKind.Internal:
                    result = result + ".Internal";
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
            if (mtype is MetaExternalType)
            {
                switch (kind)
                {
                    case ClassKind.ImmutableInstance:
                    case ClassKind.BuilderInstance:
                    case ClassKind.FactoryMethod:
                        result = mtype.Name;
                        break;
                    default:
                        return ((MetaExternalType)mtype).ExternalName;
                }
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
            if (mtype.Name == "symbol")
            {
                switch (kind)
                {
                    case ClassKind.Immutable:
                        return "global::MetaDslx.Core.ImmutableSymbol";
                    case ClassKind.Builder:
                        return "global::MetaDslx.Core.MutableSymbol";
                    case ClassKind.ImmutableInstance:
                        return "Symbol";
                    case ClassKind.BuilderInstance:
                        return "Symbol";
                    default:
                        return "symbol";
                }
            }
            else
            {
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
            }
            if (fullName)
            {
                if (kind == ClassKind.ImmutableInstance || kind == ClassKind.BuilderInstance || kind == ClassKind.FactoryMethod)
                {
                    //string fullNamePrefix = this.CSharpName(mmodel, this.ToModelKind(kind), !this.ContainsType(mmodel, mtype));
                    result = MetaNs + ".MetaInstance." + result;
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
                if (mpt.Name != "object" || mpt.Name != "string" || mpt.Name != "symbol")
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
                case ClassKind.ImmutableImpl:
                    result = result + "Impl";
                    break;
                case ClassKind.BuilderImpl:
                    result = result + "BuilderImpl";
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
                    case ClassKind.Descriptor:
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

        private string CSharpName(MetaDeclaration mdecl, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false)
        {
            if (mdecl is MetaType) return this.CSharpName((MetaType)mdecl, mmodel, kind, fullName);
            string result = mdecl.Name;
            if (fullName)
            {
                string fullNamePrefix;
                bool modelContainsDecl = this.ContainsDeclaration(mmodel, mdecl);
                switch (kind)
                {
                    case ClassKind.BuilderInstance:
                        fullNamePrefix = this.CSharpName(mdecl.MetaModel, this.ToModelKind(kind), !modelContainsDecl);
                        result = fullNamePrefix + ".instance." + result;
                        break;
                    case ClassKind.ImmutableInstance:
                    case ClassKind.FactoryMethod:
                    case ClassKind.Implementation:
                        fullNamePrefix = this.CSharpName(mdecl.MetaModel, this.ToModelKind(kind), !modelContainsDecl);
                        result = fullNamePrefix + "." + result;
                        break;
                    default:
                        if (!modelContainsDecl)
                        {
                            fullNamePrefix = this.CSharpName(mdecl.Namespace, this.ToNamespaceKind(kind), true);
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
                        fullNamePrefix = this.CSharpName(mmodel, this.ToModelKind(kind), !this.ContainsDeclaration(mmodel, mconst));
                        result = fullNamePrefix + ".instance." + result;
                        break;
                    case ClassKind.ImmutableInstance:
                    case ClassKind.FactoryMethod:
                    case ClassKind.Implementation:
                        fullNamePrefix = this.CSharpName(mmodel, this.ToModelKind(kind), !this.ContainsDeclaration(mmodel, mconst));
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
                case ModelKind.ImplementationProvider:
                case ModelKind.BuilderInstance:
                    return NamespaceKind.Internal;
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

        public bool IsMetaMetaModel(MetaModel mmodel)
        {
            if (mmodel == null) return false;
            string fullName = this.CSharpName(mmodel, ModelKind.None, true);
            return fullName == "global::MetaDslx.Languages.Meta.Symbols.Meta";
        }

        private bool IsSameModel(MetaModel m1, MetaModel m2)
        {
            return this.CSharpName(m1, ModelKind.None, true) == this.CSharpName(m2, ModelKind.None, true);
        }

        private bool ContainsType(MetaModel mmodel, MetaType mtype)
        {
            if (mmodel == null) return false;
            if (this.IsMetaMetaModel(mmodel)) return true;
            if (mtype is MetaDeclaration)
            {
                return mmodel.Namespace.Declarations.Contains((MetaDeclaration)mtype);
            }
            else if (mtype is MetaExternalType)
            {
                return mmodel.Namespace.Declarations.Contains((MetaExternalType)mtype);
            }
            else if (mtype is MetaPrimitiveType)
            {
                return mmodel.Namespace.Declarations.Any(d => d is MetaConstant && ((MetaConstant)d).Type == MetaInstance.MetaPrimitiveType && ((MetaConstant)d).Name == this.ToPascalCase(((MetaPrimitiveType)mtype).Name));
            }
            return false;
        }

        private bool ContainsDeclaration(MetaModel mmodel, MetaDeclaration mdecl)
        {
            if (mmodel == null) return false;
            if (this.IsMetaMetaModel(mmodel)) return true;
            return mmodel.Namespace.Declarations.Contains(mdecl);
        }

        public ImmutableList<ImmutableSymbol> GetSymbolInstances(MetaModel mmodel)
        {
            ImmutableList<ImmutableSymbol>.Builder result = ImmutableList.CreateBuilder<ImmutableSymbol>();
            var rootSymbols = mmodel.MModel.Symbols.Where(s => s.MParent == null);
            foreach (var item in rootSymbols)
            {
                this.CollectSymbolInstances(item, result);
            }
            foreach (var item in mmodel.MModel.Symbols)
            {
                if (!result.Contains(item) && !(item is MetaRootNamespace) && (!(item is MetaType) || !MetaConstants.Types.Contains((MetaType)item)))
                {
                    result.Add(item);
                }
            }
            return result.ToImmutable();
        }

        private void CollectSymbolInstances(ImmutableSymbol symbol, ImmutableList<ImmutableSymbol>.Builder result)
        {
            if (!(symbol is MetaRootNamespace))
            {
                result.Add(symbol);
            }
            foreach (var child in symbol.MChildren)
            {
                this.CollectSymbolInstances(child, result);
            }
        }

        public ImmutableDictionary<ImmutableSymbol, string> GetSymbolInstanceNames(MetaModel mmodel)
        {
            ImmutableDictionary<ImmutableSymbol, string>.Builder result = ImmutableDictionary.CreateBuilder<ImmutableSymbol, string>();
            int tmpCounter = 0;
            foreach (var item in mmodel.MModel.Symbols)
            {
                if (!(item is MetaRootNamespace))
                {
                    string name = null;
                    MetaProperty prop = item as MetaProperty;
                    MetaDeclaration decl = item as MetaDeclaration;
                    MetaType type = item as MetaType;
                    if (prop != null)
                    {
                        name = this.CSharpName(prop, mmodel, PropertyKind.BuilderInstance);
                    }
                    else if (decl != null && !(decl is MetaConstant) && !(decl is MetaNamespace))
                    {
                        name = this.CSharpName(decl, mmodel, ClassKind.BuilderInstance);
                    }
                    if (/*(decl == null || decl.Namespace == mmodel.Namespace) &&*/ (type == null || !MetaConstants.Types.Contains(type)))
                    {
                        if (name == null)
                        {
                            ++tmpCounter;
                            name = "__tmp" + tmpCounter;
                        }
                        result.Add(item, name);
                    }
                }
            }
            return result.ToImmutable();
        }

        public string GetEnumValueOf(Enum menum)
        {
            string result = "global::" + menum.GetType().FullName.Replace("+", ".") + "." + menum.ToString();
            return result;
        }

        public string EscapeText(string text)
        {
            if (text == null) return null;
            return StringUtilities.EscapeStringLiteralValue(text);
        }

        public string GetFieldName(MetaProperty mproperty, MetaClass mclass)
        {
            if (mproperty == null) return "";
            var allProps = mclass.GetAllProperties();
            int counter = 0;
            for (int i = 0; i < allProps.Count; i++)
            {
                if (allProps[i] == mproperty) break;
                if (allProps[i].Name == mproperty.Name)
                {
                    ++counter;
                }
            }
            return mproperty.Name.ToCamelCase() + counter;
        }

        public bool IsReferenceType(MetaType mtype)
        {
            if (mtype == null) return false;
            if (mtype is MetaCollectionType) return true;
            if (mtype is MetaNullableType) return true;
            if (mtype is MetaExternalType)
            {
                return !((MetaExternalType)mtype).IsValueType;
            }
            MetaPrimitiveType primitive = mtype as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name == "string" || primitive.Name == "object" || primitive.Name == "symbol";
            }
            if (mtype is MetaClass) return true;
            return false;
        }
    }
    //*/
}
