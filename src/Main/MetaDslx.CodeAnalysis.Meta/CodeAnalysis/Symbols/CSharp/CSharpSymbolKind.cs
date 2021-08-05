using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public static class CSharpSymbolKind
    {
        public static Type ToMetaDslx(this SymbolKind kind)
        {
            switch (kind)
            {
                case SymbolKind.Alias:
                    return typeof(AliasSymbol);
                case SymbolKind.ArrayType:
                    return typeof(ArrayTypeSymbol);
                case SymbolKind.Assembly:
                    return typeof(AssemblySymbol);
                case SymbolKind.DynamicType:
                    return typeof(DynamicTypeSymbol);
                case SymbolKind.ErrorType:
                    return typeof(ErrorTypeSymbol);
                case SymbolKind.Event:
                    return typeof(ErrorTypeSymbol); // TODO:MetaDslx
                case SymbolKind.Field:
                    return typeof(FieldSymbol);
                case SymbolKind.Label:
                    return typeof(LabelSymbol);
                case SymbolKind.Local:
                    return typeof(VariableSymbol);
                case SymbolKind.Method:
                    return typeof(MethodSymbol);
                case SymbolKind.NetModule:
                    return typeof(ModuleSymbol);
                case SymbolKind.NamedType:
                    return typeof(NamedTypeSymbol);
                case SymbolKind.Namespace:
                    return typeof(NamespaceSymbol);
                case SymbolKind.Parameter:
                    return typeof(ParameterSymbol);
                case SymbolKind.PointerType:
                    return typeof(ErrorTypeSymbol); // TODO:MetaDslx
                case SymbolKind.Property:
                    return typeof(PropertySymbol);
                case SymbolKind.RangeVariable:
                    return typeof(ErrorTypeSymbol); // TODO:MetaDslx
                case SymbolKind.TypeParameter:
                    return typeof(TypeParameterSymbol);
                case SymbolKind.Preprocessing:
                    return typeof(ErrorTypeSymbol); // TODO:MetaDslx
                case SymbolKind.Discard:
                    return typeof(DiscardExpressionSymbol);
                case SymbolKind.FunctionPointerType:
                    return typeof(DelegateTypeSymbol);
                default:
                    return typeof(ErrorTypeSymbol);
            }
        }

        internal static Type? ToMetaDslxType(this Microsoft.CodeAnalysis.CSharp.Symbol symbol)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Alias:
                    return typeof(AliasSymbol);
                case SymbolKind.ArrayType:
                    return typeof(ArrayTypeSymbol);
                case SymbolKind.Assembly:
                    return typeof(AssemblySymbol);
                case SymbolKind.DynamicType:
                    return typeof(DynamicTypeSymbol);
                case SymbolKind.ErrorType:
                    return null;
                case SymbolKind.Event:
                    break; // TODO:MetaDslx
                case SymbolKind.Field:
                    return typeof(FieldSymbol);
                case SymbolKind.Label:
                    return typeof(LabelSymbol);
                case SymbolKind.Local:
                    return typeof(VariableSymbol);
                case SymbolKind.Method:
                    var method = (CSharpSymbols.MethodSymbol)symbol;
                    switch (method.MethodKind)
                    {
                        case MethodKind.LambdaMethod:
                            return typeof(LambdaSymbol);
                        case MethodKind.Constructor:
                            return typeof(ConstructorSymbol);
                        case MethodKind.Conversion:
                            return typeof(ConversionOperatorSymbol);
                        case MethodKind.DelegateInvoke:
                            break;
                        case MethodKind.Destructor:
                            return typeof(DestructorSymbol);
                        case MethodKind.EventAdd:
                            break;
                        case MethodKind.EventRaise:
                            break;
                        case MethodKind.EventRemove:
                            break;
                        case MethodKind.ExplicitInterfaceImplementation:
                            break;
                        case MethodKind.UserDefinedOperator:
                            break;
                        case MethodKind.Ordinary:
                            return typeof(MethodSymbol);
                        case MethodKind.PropertyGet:
                            return typeof(MethodSymbol);
                        case MethodKind.PropertySet:
                            return typeof(MethodSymbol);
                        case MethodKind.ReducedExtension:
                            break;
                        case MethodKind.StaticConstructor:
                            return typeof(ConstructorSymbol);
                        case MethodKind.BuiltinOperator:
                            break;
                        case MethodKind.DeclareMethod:
                            break;
                        case MethodKind.LocalFunction:
                            break;
                        case MethodKind.FunctionPointerSignature:
                            break;
                        default:
                            break;
                    }
                    return typeof(MethodSymbol);
                case SymbolKind.NetModule:
                    return typeof(ModuleSymbol);
                case SymbolKind.NamedType:
                    var namedType = (CSharpSymbols.NamedTypeSymbol)symbol;
                    switch (namedType.TypeKind)
                    {
                        case TypeKind.Unknown:
                            return typeof(NamedTypeSymbol);
                        case TypeKind.Array:
                            return typeof(ArrayTypeSymbol);
                        case TypeKind.Class:
                            return typeof(ClassTypeSymbol);
                        case TypeKind.Delegate:
                            return typeof(DelegateTypeSymbol);
                        case TypeKind.Dynamic:
                            return typeof(DynamicTypeSymbol);
                        case TypeKind.Enum:
                            return typeof(EnumTypeSymbol);
                        case TypeKind.Error:
                            return null;
                        case TypeKind.Interface:
                            return typeof(InterfaceTypeSymbol);
                        case TypeKind.Module:
                            break; // TODO:MetaDslx
                        case TypeKind.Pointer:
                            break; // TODO:MetaDslx
                        case TypeKind.Struct:
                            return typeof(StructTypeSymbol);
                        case TypeKind.TypeParameter:
                            return typeof(TypeParameterSymbol);
                        case TypeKind.Submission:
                            return typeof(SubmissionSymbol);
                        case TypeKind.FunctionPointer:
                            return typeof(DelegateTypeSymbol);
                        default:
                            break;
                    }
                    return typeof(NamedTypeSymbol);
                case SymbolKind.Namespace:
                    return typeof(NamespaceSymbol);
                case SymbolKind.Parameter:
                    return typeof(ParameterSymbol);
                case SymbolKind.PointerType:
                    break; // TODO:MetaDslx
                case SymbolKind.Property:
                    return typeof(PropertySymbol);
                case SymbolKind.RangeVariable:
                    break; // TODO:MetaDslx
                case SymbolKind.TypeParameter:
                    return typeof(TypeParameterSymbol);
                case SymbolKind.Preprocessing:
                    break; // TODO:MetaDslx
                case SymbolKind.Discard:
                    return typeof(DiscardExpressionSymbol);
                case SymbolKind.FunctionPointerType:
                    return typeof(DelegateTypeSymbol);
                default:
                    break;
            }
            return typeof(NamedTypeSymbol);
        }
    }
}
