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
        private Dictionary<object, object>? _specialModelObjectsToSpecialId;
        private Dictionary<string, object>? _specialMetadataNameToSpecialId;

        public virtual string AttributeNameSuffix => "Attribute";

        public abstract object GetModel(object modelObject);
        public abstract bool ContainsObject(object model, object modelObject);
        public abstract IEnumerable<object> GetRootObjects(object model);
        public abstract string GetName(object modelObject);
        public abstract string GetMetadataName(object modelObject);
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

        public virtual ImmutableArray<object> SpecialSymbols => ImmutableArray<object>.Empty;

        public virtual string? GetMetadataNameOfSpecialSymbol(object specialSymbolId)
        {
            return null;
        }

        public virtual object? GetModelObjectOfSpecialSymbol(object specialSymbolId)
        {
            return null;
        }

        public object? GetSpecialSymbolOfModelObject(object modelObject)
        {
            BuildSpecialSymbolMap();
            _specialModelObjectsToSpecialId.TryGetValue(modelObject, out var result);
            return result;
        }

        public object? GetSpecialSymbolOfMetadataName(string metadataName)
        {
            BuildSpecialSymbolMap();
            _specialMetadataNameToSpecialId.TryGetValue(metadataName, out var result);
            return result;
        }

        private void BuildSpecialSymbolMap()
        {
            if (_specialModelObjectsToSpecialId == null)
            {
                var dict = new Dictionary<object, object>();
                var names = new Dictionary<string, object>();
                foreach (var st in this.SpecialSymbols)
                {
                    var mobj = this.GetModelObjectOfSpecialSymbol(st);
                    if (mobj is not null)
                    {
                        dict.Add(mobj, st);
                    }
                    var metadataName = this.GetMetadataNameOfSpecialSymbol(st);
                    if (metadataName is not null)
                    {
                        names.Add(metadataName, st);
                    }
                }
                Interlocked.CompareExchange(ref _specialModelObjectsToSpecialId, dict, null);
                Interlocked.CompareExchange(ref _specialMetadataNameToSpecialId, names, null);
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
