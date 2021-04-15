using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpSymbolFacts : SymbolFacts
    {
        public override SymbolKind FromCSharpKind(Microsoft.CodeAnalysis.SymbolKind kind)
        {
            switch (kind)
            {
                case Microsoft.CodeAnalysis.SymbolKind.Alias:
                    return SymbolKind.Alias;
                case Microsoft.CodeAnalysis.SymbolKind.ArrayType:
                    return SymbolKind.ConstructedType;
                case Microsoft.CodeAnalysis.SymbolKind.Assembly:
                    return SymbolKind.Assembly;
                case Microsoft.CodeAnalysis.SymbolKind.DynamicType:
                    return SymbolKind.DynamicType;
                case Microsoft.CodeAnalysis.SymbolKind.ErrorType:
                    return SymbolKind.ErrorType;
                case Microsoft.CodeAnalysis.SymbolKind.Event:
                    return SymbolKind.Member;
                case Microsoft.CodeAnalysis.SymbolKind.Field:
                    return SymbolKind.Member;
                case Microsoft.CodeAnalysis.SymbolKind.Label:
                    return SymbolKind.Local;
                case Microsoft.CodeAnalysis.SymbolKind.Local:
                    return SymbolKind.Local;
                case Microsoft.CodeAnalysis.SymbolKind.Method:
                    return SymbolKind.Member;
                case Microsoft.CodeAnalysis.SymbolKind.NetModule:
                    return SymbolKind.NetModule;
                case Microsoft.CodeAnalysis.SymbolKind.NamedType:
                    return SymbolKind.NamedType;
                case Microsoft.CodeAnalysis.SymbolKind.Namespace:
                    return SymbolKind.Namespace;
                case Microsoft.CodeAnalysis.SymbolKind.Parameter:
                    return SymbolKind.Local;
                case Microsoft.CodeAnalysis.SymbolKind.PointerType:
                    return SymbolKind.ConstructedType;
                case Microsoft.CodeAnalysis.SymbolKind.Property:
                    return SymbolKind.Member;
                case Microsoft.CodeAnalysis.SymbolKind.RangeVariable:
                    return SymbolKind.Local;
                case Microsoft.CodeAnalysis.SymbolKind.TypeParameter:
                    return SymbolKind.Local;
                case Microsoft.CodeAnalysis.SymbolKind.Preprocessing:
                    return SymbolKind.Local;
                case Microsoft.CodeAnalysis.SymbolKind.Discard:
                    return SymbolKind.Discard;
                default:
                    return SymbolKind.None;
            }
        }

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
            throw new NotImplementedException();
        }

        public override bool IsContainmentProperty(object property)
        {
            throw new NotImplementedException();
        }

        public override void SetOrAddPropertyValue(object modelObject, object property, object value, Location location, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

    }
}
