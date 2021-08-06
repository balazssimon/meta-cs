using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbolKind = Microsoft.CodeAnalysis.SymbolKind;
    using CSharpTypeKind = Microsoft.CodeAnalysis.TypeKind;

    public abstract class SymbolFacts
    {
        private Dictionary<object, object> _specialModelObjectsToSpecialId;
        private Dictionary<string, object> _metadataNameToSpecialModelObject;

        public virtual string AttributeNameSuffix => "Attribute";

        public abstract object GetModel(object modelObject);
        public abstract bool ContainsObject(object model, object modelObject);
        public abstract IEnumerable<object> GetRootObjects(object model);
        public abstract string GetName(object modelObject);
        public abstract object GetParent(object modelObject);
        public abstract Type GetModelObjectType(object modelObject);
        public abstract IEnumerable<object> GetChildren(object modelObject);
        public abstract IEnumerable<object> GetProperties(Type modelObjectType);
        public virtual IEnumerable<object> GetProperties(object modelObject)
        {
            return GetProperties(modelObject.GetType());
        }
        public abstract object GetProperty(Type modelObjectType, string propertyName);
        public abstract object GetProperty(object modelObject, string propertyName);
        public abstract bool IsContainmentProperty(object property);
        public abstract IEnumerable<object> GetPropertyValues(object modelObject, object property);
        public abstract void SetOrAddPropertyValue(object modelObject, object property, object symbolValue, Location location, DiagnosticBag diagnostics, CancellationToken cancellationToken);

        public virtual ImmutableArray<object> SpecialTypes => ImmutableArray<object>.Empty;

        public virtual string? GetSpecialSymbolMetadataName(object specialSymbolId)
        {
            return null;
        }

        public virtual object? GetSpecialModelObject(object specialSymbolId)
        {
            return null;
        }

        public object? GetSpecialSymbol(object modelObject)
        {
            BuildSpecialSymbolMap();
            _specialModelObjectsToSpecialId.TryGetValue(modelObject, out var result);
            return result;
        }

        private void BuildSpecialSymbolMap()
        {
            if (_specialModelObjectsToSpecialId == null)
            {
                var dict = new Dictionary<object, object>();
                foreach (var st in this.SpecialTypes)
                {
                    var mobj = this.GetSpecialModelObject(st);
                    if (mobj is not null)
                    {
                        dict.Add(mobj, st);
                    }
                }
                Interlocked.CompareExchange(ref _specialModelObjectsToSpecialId, dict, null);
            }
        }

        public virtual Type GetSymbolType(object modelObject)
        {
            return GetSymbolType(modelObject.GetType());
        }

        public virtual IEnumerable<object> GetPropertiesForSymbol(object modelObject, string symbolProperty)
        {
            return GetPropertiesForSymbol(modelObject.GetType(), symbolProperty);
        }

        public virtual IEnumerable<object> GetPropertiesForSymbol(Type modelObjectType, string symbolProperty)
        {
            foreach (var prop in GetProperties(modelObjectType))
            {
                var sprop = GetSymbolProperty(modelObjectType, prop);
                if (sprop == symbolProperty) yield return prop;
            }
        }

        public abstract string GetSymbolProperty(Type modelObjectType, object property);

        public abstract Type GetSymbolType(Type modelObjectType);

    }
}
