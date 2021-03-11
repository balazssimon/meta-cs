﻿using System;
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
                case LanguageSymbolKind.Member:
                    return CSharpSymbolKind.Property;
                case LanguageSymbolKind.Local:
                    return CSharpSymbolKind.Local;
                case LanguageSymbolKind.ErrorType:
                    return CSharpSymbolKind.ErrorType;
                case LanguageSymbolKind.Expression:
                    return CSharpSymbolKind.ErrorType;
                case LanguageSymbolKind.Statement:
                    return CSharpSymbolKind.ErrorType;
                case LanguageSymbolKind.DynamicType:
                    return CSharpSymbolKind.DynamicType;
                case LanguageSymbolKind.ConstructedType:
                    return CSharpSymbolKind.ArrayType;
                case LanguageSymbolKind.None:
                    return CSharpSymbolKind.ErrorType;
                case LanguageSymbolKind.Discard:
                    return CSharpSymbolKind.Discard;
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
                case CSharpSymbolKind.Method:
                    return LanguageSymbolKind.Member;
                case CSharpSymbolKind.Label:
                case CSharpSymbolKind.Local:
                case CSharpSymbolKind.RangeVariable:
                case CSharpSymbolKind.Parameter:
                case CSharpSymbolKind.TypeParameter:
                    return LanguageSymbolKind.Local;
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

        public virtual MemberKind MemberKindFromCSharpKind(CSharpSymbolKind kind)
        {
            switch (kind)
            {
                case CSharpSymbolKind.Field:
                    return MemberKind.Field;
                case CSharpSymbolKind.Property:
                    return MemberKind.Property;
                case CSharpSymbolKind.Event:
                    return MemberKind.Event;
                case CSharpSymbolKind.Method:
                    return MemberKind.Method;
                default:
                    throw new ArgumentException("Unexpected symbol kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual CSharpTypeKind ToCSharpKind(TypeKind kind)
        {
            switch (kind.Switch())
            {
                case TypeKind.None:
                    return CSharpTypeKind.Unknown;
                case TypeKind.Module:
                    return CSharpTypeKind.Module;
                case TypeKind.NamedType:
                    return CSharpTypeKind.Class;
                case TypeKind.Enum:
                    return CSharpTypeKind.Enum;
                case TypeKind.Error:
                    return CSharpTypeKind.Error;
                case TypeKind.Dynamic:
                    return CSharpTypeKind.Dynamic;
                case TypeKind.Constructed:
                    return CSharpTypeKind.Unknown;
                default:
                    throw new ArgumentException("Unexpected type kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual TypeKind FromCSharpKind(CSharpTypeKind kind)
        {
            switch (kind)
            {
                case CSharpTypeKind.Module:
                    return TypeKind.Module;
                case CSharpTypeKind.Class:
                case CSharpTypeKind.Interface:
                case CSharpTypeKind.Struct:
                    return TypeKind.NamedType;
                case CSharpTypeKind.Enum:
                    return TypeKind.Enum;
                case CSharpTypeKind.Error:
                    return TypeKind.Error;
                case CSharpTypeKind.Dynamic:
                    return TypeKind.Dynamic;
                case CSharpTypeKind.Array:
                case CSharpTypeKind.Pointer:
                    return TypeKind.Constructed;
                default:
                    throw new ArgumentException("Unexpected type kind: " + kind.ToString(), nameof(kind));
            }
        }

        public virtual DeclarationKind ToDeclarationKind(Type symbolType)
        {
            if (typeof(NamespaceSymbol).IsAssignableFrom(symbolType)) return DeclarationKind.Namespace;
            if (typeof(TypeSymbol).IsAssignableFrom(symbolType)) return DeclarationKind.Type;
            return DeclarationKind.None;
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
        public abstract void SetOrAddPropertyValue(object modelObject, object property, object symbolValue, Location location, DiagnosticBag diagnostics);

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

        public virtual IEnumerable<IModelObject> GetBuiltInObjects()
        {
            return ImmutableArray<IModelObject>.Empty;
        }
    }
}
