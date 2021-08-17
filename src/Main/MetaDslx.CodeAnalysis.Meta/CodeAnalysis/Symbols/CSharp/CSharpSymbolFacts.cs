using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpSymbolFacts : SymbolFacts
    {
        private ImmutableArray<object> _specialTypes;

        public override bool ContainsObject(object model, object modelObject)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetChildren(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override object GetModel(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override Type GetModelObjectType(object modelObject)
        {
            return null;
        }

        public override string GetName(object modelObject)
        {
            return null;
        }

        public override string GetMetadataName(object modelObject)
        {
            return null;
        }

        public override object GetParent(object modelObject)
        {
            return null;
        }

        public override IEnumerable<object> GetProperties(Type modelObjectType)
        {
            throw new NotImplementedException();
        }

        public override object GetProperty(Type modelObjectType, string propertyName)
        {
            throw new NotImplementedException();
        }

        public override object GetProperty(object modelObject, string propertyName)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetPropertyValues(object modelObject, object property)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetRootObjects(object model)
        {
            throw new NotImplementedException();
        }

        public override string GetSymbolProperty(Type modelObjectType, object property)
        {
            throw new NotImplementedException();
        }

        public override Type GetSymbolType(Type modelObjectType)
        {
            return null;
        }

        public override bool IsContainmentProperty(object property)
        {
            throw new NotImplementedException();
        }

        public override void SetOrAddPropertyValue(object modelObject, object property, object value, Location location, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<object> SpecialSymbols
        {
            get
            {
                if (_specialTypes.IsDefault)
                {
                    var types = ArrayBuilder<object>.GetInstance();
                    foreach (var type in Enum.GetValues(typeof(SpecialType)))
                    {
                        if (!types.Any(t => (SpecialType)t == (SpecialType)type))
                        {
                            types.Add(type);
                        }
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _specialTypes, types.ToImmutableAndFree());
                }
                return _specialTypes;
            }
        }

        public override object? GetModelObjectOfSpecialSymbol(object specialSymbolId)
        {
            if (specialSymbolId is SpecialType) return specialSymbolId;
            else return null;
        }

        public override string? GetMetadataNameOfSpecialSymbol(object specialSymbolId)
        {
            if (specialSymbolId is SpecialType st) return st.GetMetadataName();
            else return null;
        }
    }
}
