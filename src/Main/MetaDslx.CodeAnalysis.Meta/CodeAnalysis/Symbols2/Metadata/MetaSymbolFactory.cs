using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaSymbolFactory : SymbolFactory
    {
        public MetaSymbolFactory(MetaObjectFactory objectFactory)
            : base(objectFactory)
        {

        }

        public override LanguageSymbolKind GetSymbolKind(Type modelObjectType)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetSymbolKind(mdesc);
        }

        public override LanguageSymbolKind GetSymbolKind(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return GetSymbolKind(mobj.MId.Descriptor);
        }

        protected LanguageSymbolKind GetSymbolKind(ModelObjectDescriptor descriptor)
        {
            if (descriptor != null)
            {
                if (descriptor.IsNamespace) return LanguageSymbolKind.Namespace;
                else if (descriptor.IsNamedType) return LanguageSymbolKind.NamedType;
                else if (descriptor.IsName) return LanguageSymbolKind.Name;
            }
            return LanguageSymbolKind.None;
        }

        public override IEnumerable<object> GetProperties(Type modelObjectType, string symbolProperty)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetProperties(mdesc, symbolProperty);
        }

        public override IEnumerable<object> GetProperties(object modelObject, string symbolProperty)
        {
            var mobj = (IModelObject)modelObject;
            return GetProperties(mobj.MId.Descriptor, symbolProperty);
        }

        protected IEnumerable<object> GetProperties(ModelObjectDescriptor descriptor, string symbolProperty)
        {
            if (descriptor != null)
            {
                foreach (var prop in descriptor.Properties)
                {
                    var sprop = GetSymbolProperty(descriptor.ImmutableType, prop);
                    if (sprop == symbolProperty) yield return prop;
                }
            }
        }

        public override string GetSymbolProperty(Type modelObjectType, object property)
        {
            var mprop = (ModelProperty)property;
            if (mprop.IsName) return "Name";
            else if (mprop.IsBaseScope) return "DeclaredBaseTypes";
            else if (mprop.IsContainment) return "Members";
            else return null;
        }

    }
}
