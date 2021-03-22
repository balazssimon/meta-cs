using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpSymbolFacts : SymbolFacts
    {
        public override LanguageSymbolKind FromCSharpKind(SymbolKind kind)
        {
            switch (kind)
            {
                case SymbolKind.Alias:
                    return LanguageSymbolKind.Alias;
                case SymbolKind.ArrayType:
                    return LanguageSymbolKind.ConstructedType;
                case SymbolKind.Assembly:
                    return LanguageSymbolKind.Assembly;
                case SymbolKind.DynamicType:
                    return LanguageSymbolKind.DynamicType;
                case SymbolKind.ErrorType:
                    return LanguageSymbolKind.ErrorType;
                case SymbolKind.Event:
                    return LanguageSymbolKind.Member;
                case SymbolKind.Field:
                    return LanguageSymbolKind.Member;
                case SymbolKind.Label:
                    return LanguageSymbolKind.Local;
                case SymbolKind.Local:
                    return LanguageSymbolKind.Local;
                case SymbolKind.Method:
                    return LanguageSymbolKind.Member;
                case SymbolKind.NetModule:
                    return LanguageSymbolKind.NetModule;
                case SymbolKind.NamedType:
                    return LanguageSymbolKind.NamedType;
                case SymbolKind.Namespace:
                    return LanguageSymbolKind.Namespace;
                case SymbolKind.Parameter:
                    return LanguageSymbolKind.Local;
                case SymbolKind.PointerType:
                    return LanguageSymbolKind.ConstructedType;
                case SymbolKind.Property:
                    return LanguageSymbolKind.Member;
                case SymbolKind.RangeVariable:
                    return LanguageSymbolKind.Local;
                case SymbolKind.TypeParameter:
                    return LanguageSymbolKind.Local;
                case SymbolKind.Preprocessing:
                    return LanguageSymbolKind.Local;
                case SymbolKind.Discard:
                    return LanguageSymbolKind.Discard;
                default:
                    return LanguageSymbolKind.None;
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
