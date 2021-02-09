using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbolKind = Microsoft.CodeAnalysis.SymbolKind;
    using CSharpTypeKind = Microsoft.CodeAnalysis.TypeKind;

    public abstract class SymbolFacts
    {
        public virtual string AttributeNameSuffix => "Attribute";

        public virtual bool IsEntryPointCandidate(MethodSymbol method)
        {
            return false;
        }

        public virtual CSharpSymbolKind ToCSharpKind(LanguageSymbolKind kind)
        {
            switch (kind.Switch())
            {
                case LanguageSymbolKind.Assembly:
                    return CSharpSymbolKind.Assembly;
                case LanguageSymbolKind.NetModule:
                    return CSharpSymbolKind.NetModule;
                case LanguageSymbolKind.Alias:
                    return CSharpSymbolKind.Alias;
                case LanguageSymbolKind.Namespace:
                    return CSharpSymbolKind.Namespace;
                case LanguageSymbolKind.NamedType:
                    return CSharpSymbolKind.NamedType;
                case LanguageSymbolKind.Property:
                    return CSharpSymbolKind.Property;
                case LanguageSymbolKind.Operation:
                    return CSharpSymbolKind.Method;
                case LanguageSymbolKind.ErrorType:
                    return CSharpSymbolKind.ErrorType;
                case LanguageSymbolKind.Name:
                    return CSharpSymbolKind.Namespace;
                case LanguageSymbolKind.DynamicType:
                    return CSharpSymbolKind.DynamicType;
                case LanguageSymbolKind.ConstructedType:
                    return CSharpSymbolKind.ArrayType;
                case LanguageSymbolKind.None:
                    return CSharpSymbolKind.ErrorType;
                default:
                    throw new ArgumentException("Unexpected symbol kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual LanguageSymbolKind FromCSharpKind(CSharpSymbolKind kind)
        {
            switch (kind)
            {
                case CSharpSymbolKind.Assembly:
                    return LanguageSymbolKind.Assembly;
                case CSharpSymbolKind.NetModule:
                    return LanguageSymbolKind.NetModule;
                case CSharpSymbolKind.Alias:
                    return LanguageSymbolKind.Alias;
                case CSharpSymbolKind.Namespace:
                    return LanguageSymbolKind.Namespace;
                case CSharpSymbolKind.NamedType:
                    return LanguageSymbolKind.NamedType;
                case CSharpSymbolKind.Field:
                case CSharpSymbolKind.Property:
                case CSharpSymbolKind.Event:
                    return LanguageSymbolKind.Property;
                case CSharpSymbolKind.Method:
                    return LanguageSymbolKind.Operation;
                case CSharpSymbolKind.ErrorType:
                    return LanguageSymbolKind.ErrorType;
                case CSharpSymbolKind.DynamicType:
                    return LanguageSymbolKind.DynamicType;
                case CSharpSymbolKind.ArrayType:
                case CSharpSymbolKind.PointerType:
                    return LanguageSymbolKind.ConstructedType;
                default:
                    throw new ArgumentException("Unexpected symbol kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual CSharpTypeKind ToCSharpKind(LanguageTypeKind kind)
        {
            switch (kind.Switch())
            {
                case LanguageTypeKind.None:
                    return CSharpTypeKind.Unknown;
                case LanguageTypeKind.Module:
                    return CSharpTypeKind.Module;
                case LanguageTypeKind.NamedType:
                    return CSharpTypeKind.Class;
                case LanguageTypeKind.Enum:
                    return CSharpTypeKind.Enum;
                case LanguageTypeKind.Error:
                    return CSharpTypeKind.Error;
                case LanguageTypeKind.Dynamic:
                    return CSharpTypeKind.Dynamic;
                case LanguageTypeKind.Constructed:
                    return CSharpTypeKind.Unknown;
                default:
                    throw new ArgumentException("Unexpected type kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual LanguageTypeKind FromCSharpKind(CSharpTypeKind kind)
        {
            switch (kind)
            {
                case CSharpTypeKind.Module:
                    return LanguageTypeKind.Module;
                case CSharpTypeKind.Class:
                case CSharpTypeKind.Interface:
                case CSharpTypeKind.Struct:
                    return LanguageTypeKind.NamedType;
                case CSharpTypeKind.Enum:
                    return LanguageTypeKind.Enum;
                case CSharpTypeKind.Error:
                    return LanguageTypeKind.Error;
                case CSharpTypeKind.Dynamic:
                    return LanguageTypeKind.Dynamic;
                case CSharpTypeKind.Array:
                case CSharpTypeKind.Pointer:
                    return LanguageTypeKind.Constructed;
                default:
                    throw new ArgumentException("Unexpected type kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual DeclarationKind ToDeclarationKind(LanguageSymbolKind kind)
        {
            switch (kind.Switch())
            {
                case LanguageSymbolKind.Assembly:
                    return DeclarationKind.None;
                case LanguageSymbolKind.NetModule:
                    return DeclarationKind.None;
                case LanguageSymbolKind.Alias:
                    return DeclarationKind.None;
                case LanguageSymbolKind.Namespace:
                    return DeclarationKind.Namespace;
                case LanguageSymbolKind.NamedType:
                    return DeclarationKind.Type;
                case LanguageSymbolKind.Property:
                    return DeclarationKind.None; 
                case LanguageSymbolKind.Operation:
                    return DeclarationKind.None;
                case LanguageSymbolKind.ErrorType:
                    return DeclarationKind.Type;
                case LanguageSymbolKind.Name:
                    return DeclarationKind.None;
                case LanguageSymbolKind.DynamicType:
                    return DeclarationKind.Type;
                case LanguageSymbolKind.ConstructedType:
                    return DeclarationKind.Type;
                case LanguageSymbolKind.None:
                    return DeclarationKind.None;
                default:
                    throw new ArgumentException("Unexpected symbol kind: " + kind.ToString(), nameof(kind));
            }
        }

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
        public abstract void SetOrAddPropertyValue(object modelObject, object property, object value, Location location, DiagnosticBag diagnostics);

        public virtual LanguageSymbolKind GetSymbolKind(object modelObject)
        {
            return GetSymbolKind(modelObject.GetType());
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

        public abstract LanguageSymbolKind GetSymbolKind(Type modelObjectType);

        public virtual IEnumerable<IModelObject> GetBuiltInObjects()
        {
            return ImmutableArray<IModelObject>.Empty;
        }
    }
}
