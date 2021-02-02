using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class ReflectionSymbolFacts : SymbolFacts
    {
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
            throw new NotImplementedException();
        }

        public override string GetName(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override object GetParent(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetProperties(Type modelObjectType)
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

        public override LanguageSymbolKind GetSymbolKind(Type modelObjectType)
        {
            throw new NotImplementedException();
        }

        public override string GetSymbolProperty(Type modelObjectType, object property)
        {
            throw new NotImplementedException();
        }

        public override void SetOrAddPropertyValue(object modelObject, object property, object value, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }
    }
}
