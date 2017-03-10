using MetaDslx.Languages.Soal.Symbols.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Symbols
{
    public class SoalAnnotations
    {
        public const string All = "All";
        public const string Choice = "Choice";
        public const string NoWrap = "NoWrap";
        public const string Rpc = "Rpc";
        public const string Enum = "Enum";
        public const string Type = "Type";
        public const string Element = "Element";
        public const string Attribute = "Attribute";
        public const string Restriction = "Restriction";
    }

    public class SoalAnnotationProperties
    {
        public const string Wrapped = "wrapped";
        public const string Items = "items";
        public const string Sap = "sap";
        public const string Name = "name";
        public const string Optional = "optional";
        public const string Required = "required";
        public const string Pattern = "pattern";
        public const string Length = "length";
        public const string MinLength = "minLength";
        public const string MaxLength = "maxLength";
        public const string MaxExclusive = "maxExclusive";
        public const string MinExclusive = "minExclusive";
        public const string MaxInclusive = "maxInclusive";
        public const string MinInclusive = "minInclusive";
        public const string TotalDigits = "totalDigits";
        public const string FractionDigits = "fractionDigits";

    }

    internal class SoalImplementation : SoalImplementationBase
    {
        internal override void SoalBuilderInstance(SoalBuilderInstance _this)
        {
            base.SoalBuilderInstance(_this);
            SoalFactory f = new SoalFactory(_this.Model);
            _this.Object = f.PrimitiveType();
            _this.Object.Name = "object";
            _this.Object.Nullable = true;
            _this.String = f.PrimitiveType();
            _this.String.Name = "string";
            _this.String.Nullable = true;
            _this.Int = f.PrimitiveType();
            _this.Int.Name = "int";
            _this.Long = f.PrimitiveType();
            _this.Long.Name = "long";
            _this.Float = f.PrimitiveType();
            _this.Float.Name = "float";
            _this.Double = f.PrimitiveType();
            _this.Double.Name = "double";
            _this.Byte = f.PrimitiveType();
            _this.Byte.Name = "byte";
            _this.Bool = f.PrimitiveType();
            _this.Bool.Name = "bool";
            _this.Void = f.PrimitiveType();
            _this.Void.Name = "void";
            _this.Date = f.PrimitiveType();
            _this.Date.Name = "Date";
            _this.Time = f.PrimitiveType();
            _this.Time.Name = "Time";
            _this.DateTime = f.PrimitiveType();
            _this.DateTime.Name = "DateTime";
            _this.TimeSpan = f.PrimitiveType();
            _this.TimeSpan.Name = "TimeSpan";
        }

        public override void Declaration(DeclarationBuilder _this)
        {
            base.Declaration(_this);
            _this.FullNameLazy =
                () =>
                {
                    if (_this.Namespace == null) return _this.Name;
                    else return _this.Namespace.FullName + "." + _this.Name;
                };
        }

        public override void Operation(OperationBuilder _this)
        {
            base.Operation(_this);
            SoalFactory f = new SoalFactory(_this.MModel);
            _this.Result = f.OutputParameter();
        }
    }

    internal static class SoalExtensions
    {
        public static string FullName(this Declaration declaration)
        {
            if (declaration == null) return string.Empty;
            if (declaration.Namespace == null) return declaration.Name;
            return declaration.Namespace.FullName + "." + declaration.Name;
        }

        public static bool IsIdentifier(this string name)
        {
            return Regex.IsMatch(name, @"[a-zA-Z\_][0-9a-zA-Z\_]*");
        }

        public static bool IsArrayType(this SoalType type)
        {
            if (type == null) return false;
            if (type is NonNullableType) return ((NonNullableType)type).InnerType.IsArrayType();
            if (type is NullableType) return ((NullableType)type).InnerType.IsArrayType();
            if (type is ArrayType) return true;
            return false;
        }

        public static bool IsArrayType(this SoalTypeBuilder type)
        {
            if (type == null) return false;
            if (type is NonNullableTypeBuilder) return ((NonNullableTypeBuilder)type).InnerType.IsArrayType();
            if (type is NullableTypeBuilder) return ((NullableTypeBuilder)type).InnerType.IsArrayType();
            if (type is ArrayTypeBuilder) return true;
            return false;
        }

        public static SoalType GetCoreType(this SoalType type)
        {
            if (type == null) return null;
            if (type is NonNullableType) return ((NonNullableType)type).InnerType.GetCoreType();
            if (type is NullableType) return ((NullableType)type).InnerType.GetCoreType();
            if (type is ArrayType) return ((ArrayType)type).InnerType.GetCoreType();
            return type;
        }

        public static SoalTypeBuilder GetCoreType(this SoalTypeBuilder type)
        {
            if (type == null) return null;
            if (type is NonNullableTypeBuilder) return ((NonNullableTypeBuilder)type).InnerType.GetCoreType();
            if (type is NullableTypeBuilder) return ((NullableTypeBuilder)type).InnerType.GetCoreType();
            if (type is ArrayTypeBuilder) return ((ArrayTypeBuilder)type).InnerType.GetCoreType();
            return type;
        }

        public static string UriWithSlash(this Namespace ns)
        {
            string uri = ns.Uri;
            if (uri == null) return uri;
            if (!uri.EndsWith("/")) return uri + "/";
            else return uri;
        }

        public static bool HasAnnotation(this AnnotatedElement annotatedElement, string annotationName)
        {
            return annotatedElement.Annotations.Any(a => a.Name == annotationName);
        }

        public static bool HasAnnotation(this AnnotatedElementBuilder annotatedElement, string annotationName)
        {
            return annotatedElement.Annotations.Any(a => a.Name == annotationName);
        }

        public static Annotation GetAnnotation(this AnnotatedElement annotatedElement, string annotationName)
        {
            return annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
        }

        public static AnnotationBuilder GetAnnotation(this AnnotatedElementBuilder annotatedElement, string annotationName)
        {
            return annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
        }

        public static AnnotationBuilder AddAnnotation(this AnnotatedElementBuilder annotatedElement, string annotationName)
        {
            AnnotationBuilder result = annotatedElement.GetAnnotation(annotationName);
            if (result == null)
            {
                SoalFactory f = new Symbols.SoalFactory(annotatedElement.MModel);
                result = f.Annotation();
                result.Name = annotationName;
                annotatedElement.Annotations.Add(result);
            }
            return result;
        }

        public static bool HasAnnotationProperty(this AnnotatedElement annotatedElement, string annotationName, string propertyName)
        {
            var annot = annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
            if (annot != null)
            {
                return annot.HasProperty(propertyName);
            }
            return false;
        }

        public static bool HasAnnotationProperty(this AnnotatedElementBuilder annotatedElement, string annotationName, string propertyName)
        {
            var annot = annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
            if (annot != null)
            {
                return annot.HasProperty(propertyName);
            }
            return false;
        }

        public static object GetAnnotationPropertyValue(this AnnotatedElement annotatedElement, string annotationName, string propertyName)
        {
            var annot = annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
            if (annot != null)
            {
                return annot.GetPropertyValue(propertyName);
            }
            return null;
        }

        public static object GetAnnotationPropertyValue(this AnnotatedElementBuilder annotatedElement, string annotationName, string propertyName)
        {
            var annot = annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
            if (annot != null)
            {
                return annot.GetPropertyValue(propertyName);
            }
            return null;
        }

        public static void SetAnnotationPropertyValue(this AnnotatedElementBuilder annotatedElement, string annotationName, string propertyName, object value)
        {
            var annot = annotatedElement.Annotations.FirstOrDefault(a => a.Name == annotationName);
            if (annot == null)
            {
                SoalFactory f = new SoalFactory(annotatedElement.MModel);
                annot = f.Annotation();
                annot.Name = annotationName;
                annotatedElement.Annotations.Add(annot);
            }
            annot.SetPropertyValue(propertyName, value);
        }

        public static bool HasProperty(this Annotation annotation, string propertyName)
        {
            return annotation.Properties.Any(p => p.Name == propertyName);
        }

        public static bool HasProperty(this AnnotationBuilder annotation, string propertyName)
        {
            return annotation.Properties.Any(p => p.Name == propertyName);
        }

        public static object GetPropertyValue(this Annotation annotation, string propertyName)
        {
            var prop = annotation.Properties.FirstOrDefault(p => p.Name == propertyName);
            if (prop != null) return prop.Value;
            else return null;
        }

        public static object GetPropertyValue(this AnnotationBuilder annotation, string propertyName)
        {
            var prop = annotation.Properties.FirstOrDefault(p => p.Name == propertyName);
            if (prop != null) return prop.Value;
            else return null;
        }

        public static void SetPropertyValue(this AnnotationBuilder annotation, string propertyName, object value)
        {
            var prop = annotation.Properties.FirstOrDefault(p => p.Name == propertyName);
            if (prop == null)
            {
                SoalFactory f = new Symbols.SoalFactory(annotation.MModel);
                prop = f.AnnotationProperty();
                prop.Name = propertyName;
                annotation.Properties.Add(prop);
            }
            prop.Value = value;
        }


        public static string GetXsdName(this SoalType type)
        {
            if (type is PrimitiveType)
            {
                string name = ((PrimitiveType)type).Name;
                switch (name)
                {
                    case "int":
                    case "long":
                    case "float":
                    case "double":
                    case "string":
                    case "byte":
                        return name;
                    case "object":
                        return "anyType";
                    case "bool":
                        return "boolean";
                    case "Date":
                        return "date";
                    case "Time":
                        return "time";
                    case "DateTime":
                        return "dateTime";
                    case "TimeSpan":
                        return "duration";
                    default:
                        break;
                }
            }
            if (type is NullableType) return GetXsdName(((NullableType)type).InnerType);
            if (type is NonNullableType) return GetXsdName(((NonNullableType)type).InnerType);
            if (type is ArrayType)
            {
                if (((ArrayType)type).InnerType == SoalInstance.Byte) return "base64Binary";
                else return (GetXsdName(((ArrayType)type).InnerType) + "List").ToPascalCase();
            }
            if (type is Enum)
            {
                Enum etype = (Enum)type;
                string newName = etype.GetAnnotationPropertyValue(SoalAnnotations.Type, SoalAnnotationProperties.Name) as string;
                return newName ?? etype.Name;
            }
            if (type is Struct)
            {
                Struct stype = (Struct)type;
                string newName = stype.GetAnnotationPropertyValue(SoalAnnotations.Type, SoalAnnotationProperties.Name) as string;
                return newName ?? stype.Name;
            }
            return null;
        }

        public static string ToPascalCase(this string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            return identifier.Substring(0, 1).ToUpper() + identifier.Substring(1);
        }

        public static string ToCamelCase(this string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            return identifier.Substring(0, 1).ToLower() + identifier.Substring(1);
        }

        public static bool HasXsdNamespace(this SoalType type)
        {
            if (type is PrimitiveType) return true;
            if (type is NullableType) return HasXsdNamespace(((NullableType)type).InnerType);
            if (type is NonNullableType) return HasXsdNamespace(((NonNullableType)type).InnerType);
            if (type is ArrayType) return HasXsdNamespace(((ArrayType)type).InnerType);
            if (type is Enum)
            {
                Enum etype = (Enum)type;
                return etype.Namespace != null && etype.Namespace.Uri != null;
            }
            if (type is Struct)
            {
                Struct stype = (Struct)type;
                return stype.Namespace != null && stype.Namespace.Uri != null;
            }
            return false;
        }

        public static bool IsNullable(this SoalType type)
        {
            if (type is NonNullableType) return false;
            if (type is NullableType) return true;
            if (type is PrimitiveType) return ((PrimitiveType)type).Nullable;
            if (type is ArrayType) return true;
            if (type is Enum) return false;
            if (type is Struct) return true;
            return false;
        }

        public static string IsNullableXsd(this SoalType type)
        {
            return type.IsNullable().ToString().ToLower();
        }

        public static List<Struct> GetInterfaceExceptions(this Interface intf)
        {
            List<Struct> result = new List<Struct>();
            foreach (var op in intf.Operations)
            {
                foreach (var ex in op.Exceptions)
                {
                    if (!result.Contains(ex))
                    {
                        result.Add(ex);
                    }
                }
            }
            return result;
        }

        public static List<Struct> GetInterfaceExceptions(this Namespace ns)
        {
            List<Struct> result = new List<Struct>();
            foreach (var intf in ns.Declarations.OfType<Interface>())
            {
                foreach (var op in intf.Operations)
                {
                    foreach (var ex in op.Exceptions)
                    {
                        if (!result.Contains(ex))
                        {
                            result.Add(ex);
                        }
                    }
                }
            }
            return result;
        }

        public static string GetSoapPrefix(this Binding binding)
        {
            foreach (var enc in binding.Encodings)
            {
                SoapEncodingBindingElement soap = enc as SoapEncodingBindingElement;
                if (soap != null)
                {
                    if (soap.Version == SoapVersion.Soap12) return "soap12";
                    else return "soap";
                }
            }
            return null;
        }

        public static bool HasPolicy(this Binding binding)
        {
            HttpTransportBindingElement http = binding.Transport as HttpTransportBindingElement;
            if (http != null && http.Ssl) return true;
            foreach (var enc in binding.Encodings)
            {
                SoapEncodingBindingElement soap = enc as SoapEncodingBindingElement;
                if (soap != null && soap.Mtom) return true;
            }
            foreach (var prot in binding.Protocols)
            {
                if (prot is WsAddressingBindingElement) return true;
            }
            return false;
        }

        public static bool HasOperationPolicy(this Binding binding)
        {
            foreach (var prot in binding.Protocols)
            {
                //if (prot is WsSecurityBindingElement) return true;
            }
            return false;
        }

        public static string GetWsdlSoapDocRpcStyle(this Binding binding)
        {
            if (binding != null)
            {
                SoapEncodingBindingElement enc = binding.Encodings.OfType<SoapEncodingBindingElement>().FirstOrDefault();
                if (enc != null)
                {
                    if (enc.Style == SoapEncodingStyle.RpcEncoded || enc.Style == SoapEncodingStyle.RpcLiteral) return "rpc";
                }
            }
            return "document";
        }

        public static string GetWsdlSoapEncLitStyle(this Binding binding)
        {
            if (binding != null)
            {
                SoapEncodingBindingElement enc = binding.Encodings.OfType<SoapEncodingBindingElement>().FirstOrDefault();
                if (enc != null)
                {
                    if (enc.Style == SoapEncodingStyle.RpcEncoded) return "encoded";
                }
            }
            return "literal";
        }
    }

}
