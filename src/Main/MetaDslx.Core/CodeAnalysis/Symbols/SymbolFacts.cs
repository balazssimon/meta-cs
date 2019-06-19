using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbolKind = Microsoft.CodeAnalysis.SymbolKind;
    using CSharpTypeKind = Microsoft.CodeAnalysis.TypeKind;

    public class SymbolFacts
    {
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
    }
}
