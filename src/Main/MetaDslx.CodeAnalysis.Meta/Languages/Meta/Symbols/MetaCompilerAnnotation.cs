using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Meta
{
    public static class MetaCompilerAnnotationInfo
    {
        public const string Id = "MetaDslx.MetaAnnotations";

        public const string Root = nameof(Root);

        public const string Attribute = nameof(Attribute);

        public const string Identifier = nameof(Identifier);
        public const string Qualifier = nameof(Qualifier);
        public const string Value = nameof(Value);
        public const string EnumValue = nameof(EnumValue);

        public const string Property = nameof(Property);
        public const string Name = nameof(Name);
        public const string Scope = nameof(Scope);

        public const string SymbolDef = nameof(SymbolDef);
        public const string SymbolUse = nameof(SymbolUse);

        public const string Token = nameof(Token);


        public static readonly string[] WellKnownAnnotations =
            {
                Root,
                Attribute,
                Identifier, Qualifier, Value, EnumValue,
                Property, Name, Scope,
                SymbolDef, SymbolUse, 
                Token
            };

        public static readonly string[] BinderAnnotations = WellKnownAnnotations;

        public static readonly string[] BoundNodeAnnotations = WellKnownAnnotations;

        public static readonly string[][] WellKnownAnnotationProperties =
        {
            new string[] { "type" },
            new string[] { "type" },
            new string[] { "name" },
            new string[] { "type", "types" },
            new string[] { "value" },
            new string[] { "enumType" },
            new string[] { "name", "value", "owner", "ownerType" },
            new string[] { },
            new string[] { "local" },
            new string[] { "type", "nestingProperty", "merge" },
            new string[] { "type", "types" },
            new string[] { "kind", "first", "last", "defaultSeparator", "defaultIdentifier", "defaultWhitespace", "defaultEndOfLine", "endOfLine" },
        };

        public static string GetDefaultProperty(string annotationType)
        {
            string result;
            DefaultProperties.TryGetValue(annotationType, out result);
            return result;
        }

        public static MetaAnnotationProperty CreateDefaultProperty(string annotationName, string value)
        {
            string propertyName = GetDefaultProperty(annotationName);
            return new MetaAnnotationProperty(propertyName, value);
        }

        public static MetaAnnotationProperty CreateDefaultProperty(string annotationName, ImmutableArray<string> values)
        {
            string propertyName = GetDefaultProperty(annotationName);
            return new MetaAnnotationProperty(propertyName, values);
        }

        private static readonly Dictionary<string, string> DefaultProperties = new Dictionary<string, string>();

        static MetaCompilerAnnotationInfo()
        {
            DefaultProperties.Add(Attribute, "type");
            DefaultProperties.Add(Root, "type");
            DefaultProperties.Add(SymbolDef, "type");
            DefaultProperties.Add(SymbolUse, "type");
            DefaultProperties.Add(Property, "name");
            DefaultProperties.Add(Identifier, "name");
            DefaultProperties.Add(Value, "value");
            DefaultProperties.Add(EnumValue, "enumType");
        }
    }

    [Serializable]
    public class MetaCompilerAnnotations
    {
        public static readonly MetaCompilerAnnotations Empty = new MetaCompilerAnnotations(ImmutableArray<MetaCompilerAnnotation>.Empty);

        public MetaCompilerAnnotations(IEnumerable<MetaCompilerAnnotation> annotations)
        {
            this.Annotations = new List<MetaCompilerAnnotation>(annotations);
        }

        public IReadOnlyList<MetaCompilerAnnotation> Annotations { get; }

        public IEnumerable<MetaCompilerAnnotation> BinderAnnotations
        {
            get
            {
                return this.Annotations;//.Where(a => MetaCompilerAnnotationInfo.WellKnownAnnotations.Contains(a.Name)).ToImmutableArray();
                //return this.Annotations.Where(a => MetaCompilerAnnotationInfo.BinderAnnotations.Contains(a.Name) || !MetaCompilerAnnotationInfo.WellKnownAnnotations.Contains(a.Name));
            }
        }

        public IEnumerable<MetaCompilerAnnotation> BoundNodeAnnotations
        {
            get
            {
                return this.Annotations;//.Where(a => MetaCompilerAnnotationInfo.WellKnownAnnotations.Contains(a.Name)).ToImmutableArray();
                //return this.Annotations.Where(a => MetaCompilerAnnotationInfo.BoundNodeAnnotations.Contains(a.Name) || !MetaCompilerAnnotationInfo.WellKnownAnnotations.Contains(a.Name));
            }
        }

        public ImmutableArray<MetaCompilerAnnotation> GetCustomAnnotations()
        {
            return this.Annotations.Where(a => !MetaCompilerAnnotationInfo.WellKnownAnnotations.Contains(a.Name)).ToImmutableArray();
        }

        public bool HasAnnotation(string name)
        {
            return this.Annotations.Any(a => a.Name == name);
        }

        public MetaCompilerAnnotation GetAnnotation(string name)
        {
            return this.Annotations.FirstOrDefault(a => a.Name == name);
        }

        public bool HasProperty(string property)
        {
            foreach (var annot in this.Annotations)
            {
                if (annot.Properties.Any(p => p.Name == property)) return true;
            }
            return false;
        }

        public bool HasProperty(string name, string property)
        {
            MetaCompilerAnnotation annot = this.Annotations.FirstOrDefault(a => a.Name == name);
            if (annot == null) return false;
            return annot.Properties.Any(p => p.Name == property);
        }

        public string GetPropertyValue(string name, string property)
        {
            MetaCompilerAnnotation annot = this.Annotations.FirstOrDefault(a => a.Name == name);
            if (annot == null) return null;
            return annot.Properties.First(p => p.Name == property)?.Value;
        }

        public IReadOnlyList<string> GetPropertyValues(string name, string property)
        {
            MetaCompilerAnnotation annot = this.Annotations.FirstOrDefault(a => a.Name == name);
            if (annot == null) return null;
            return annot.Properties.First(p => p.Name == property)?.Values;
        }

        public MetaCompilerAnnotations Add(MetaCompilerAnnotation annotation)
        {
            List<MetaCompilerAnnotation> newAnnotations = new List<Meta.MetaCompilerAnnotation>(this.Annotations);
            newAnnotations.Add(annotation);
            return new MetaCompilerAnnotations(newAnnotations);
        }

        public MetaCompilerAnnotations AddRange(IReadOnlyList<MetaCompilerAnnotation> annotations)
        {
            List<MetaCompilerAnnotation> newAnnotations = new List<Meta.MetaCompilerAnnotation>(this.Annotations);
            newAnnotations.AddRange(annotations);
            return new MetaCompilerAnnotations(newAnnotations);
        }

        public MetaCompilerAnnotations Merge(MetaCompilerAnnotations annotations)
        {
            List<MetaCompilerAnnotation> newAnnotations = new List<Meta.MetaCompilerAnnotation>(this.Annotations);
            newAnnotations.AddRange(annotations.Annotations);
            return new MetaCompilerAnnotations(newAnnotations);
        }

        public MetaCompilerAnnotations Filter(IEnumerable<string> annotationNames)
        {
            return new MetaCompilerAnnotations(this.Annotations.Where(a => annotationNames.Contains(a.Name)));
        }

        public string Serialize()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, this);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static MetaCompilerAnnotations Deserialize(string annotations)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] bytes = Convert.FromBase64String(annotations);
                    ms.Write(bytes, 0, bytes.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    BinaryFormatter bf = new BinaryFormatter();
                    return bf.Deserialize(ms) as MetaCompilerAnnotations;
                }
            }
            catch (Exception)
            {
                return MetaCompilerAnnotations.Empty;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            bool first = true;
            foreach (var annot in this.Annotations)
            {
                if (!first) sb.Append(", ");
                sb.Append(annot.ToString());
                first = false;
            }
            sb.Append("}");
            return sb.ToString();
        }

    }

    [Serializable]
    public class MetaCompilerAnnotation
    {
        public MetaCompilerAnnotation(string name, IEnumerable<MetaAnnotationProperty> properties)
        {
            this.Name = name;
            this.Properties = new List<MetaAnnotationProperty>(properties);
        }

        public string Name { get; }
        public IReadOnlyList<MetaAnnotationProperty> Properties { get; }

        public bool HasProperty(string propertyName)
        {
            return this.Properties.Any(p => p.Name == propertyName);
        }

        public string GetValue(string propertyName)
        {
            foreach (var prop in this.Properties)
            {
                if (prop.Name == propertyName)
                {
                    return prop.Value;
                }
            }
            return null;
        }

        public IEnumerable<string> GetValues(string propertyName)
        {
            foreach (var prop in this.Properties)
            {
                if (prop.Name == propertyName)
                {
                    return prop.Values;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string GetAnnotationParams()
        {
            string result = "";
            if (this.Name == MetaCompilerAnnotationInfo.SymbolDef)
            {
                if (this.HasProperty("type"))
                {
                    result = ", type: typeof(Symbols." + this.GetValue("type") + ")";
                }
                else
                {
                    result = ", type: null";
                }
                if (this.HasProperty("nestingProperty"))
                {
                    result = result + ", nestingProperty: \"" + this.GetValue("nestingProperty") + "\"";
                }
                if (this.HasProperty("merge"))
                {
                    result = result + ", merge: " + this.GetValue("merge");
                }
            }
            if (this.Name == MetaCompilerAnnotationInfo.Scope)
            {
                if (this.HasProperty("local"))
                {
                    result = ", local: " + this.GetValue("local");
                }
            }
            if (this.Name == MetaCompilerAnnotationInfo.SymbolUse || this.Name == MetaCompilerAnnotationInfo.Attribute)
            {
                if (this.HasProperty("type"))
                {
                    result = ", types: ImmutableArray.Create(typeof(Symbols." + this.GetValue("type") + "))";
                }
                else if (this.HasProperty("types"))
                {
                    result = ", types: ImmutableArray.Create(";
                    string comma = "";
                    foreach (var type in this.GetValues("types"))
                    {
                        result += comma + "typeof(Symbols." + type + ")";
                        comma = ", ";
                    }
                    result += ")";
                }
                else
                {
                    result = ", types: ImmutableArray<Type>.Empty";
                }
            }
            if (this.Name == MetaCompilerAnnotationInfo.Property)
            {
                result = ", name: \"" + this.GetValue("name") + "\"";
                if (this.HasProperty("value"))
                {
                    result = result + ", value: " + this.GetValue("value");
                }
                if (this.HasProperty("owner"))
                {
                    result = result + ", owner: SymbolPropertyOwner." + this.GetValue("owner");
                }
                if (this.HasProperty("ownerType"))
                {
                    result = result + ", ownerType: typeof(Symbols." + this.GetValue("ownerType") + ")";
                }
            }
            if (this.Name == MetaCompilerAnnotationInfo.Value && this.HasProperty("value"))
            {
                result = ", value: " + this.GetValue("value");
            }
            if (this.Name == MetaCompilerAnnotationInfo.EnumValue)
            {
                if (this.HasProperty("enumType"))
                {
                    result = ", enumType: typeof(Symbols." + this.GetValue("enumType") + ")";
                }
                else
                {
                    result = ", enumType: null";
                }
            }
            return result;
        }
    }

    [Serializable]
    public class MetaAnnotationProperty
    {
        public MetaAnnotationProperty(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Values = null;
        }

        public MetaAnnotationProperty(string name, IEnumerable<string> values)
        {
            this.Name = name;
            this.Value = null;
            this.Values = new List<string>(values);
        }

        public string Name { get; }
        public string Value { get; }
        public IReadOnlyList<string> Values { get; }

        public override string ToString()
        {
            if (this.Values != null) return this.Name;
            else return this.Name + "=" + this.Value;
        }
    }
}
