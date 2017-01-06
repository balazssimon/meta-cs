using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.MetaModel
{
    public static class MetaCompilerAnnotationInfo
    {
        public const string Id = "MetaDslx.MetaAnnotations";

        public const string Name = "Name";
        public const string QualifiedName = "QualifiedName";
        public const string NameDef = "NameDef";
        public const string TypeDef = "TypeDef";
        public const string NameCtr = "NameCtr";
        public const string TypeCtr = "TypeCtr";
        public const string NameUse = "NameUse";
        public const string TypeUse = "TypeUse";
        public const string Scope = "Scope";
        public const string Symbol = "Symbol";
        public const string SymbolType = "SymbolType";
        public const string PreDefSymbol = "PreDefSymbol";
        public const string Property = "Property";

        public static readonly string[] SemanticAnnotations = 
            {
                Name, QualifiedName, NameDef, TypeDef, NameCtr, TypeCtr,
                NameUse, TypeUse, Scope, Symbol, SymbolType, PreDefSymbol, Property
            };
        public static readonly string[] DeclarationTreeEntry = { NameDef, TypeDef };
        public static readonly string[] ScopeBoundary = { NameDef, TypeDef, NameCtr, TypeCtr, Symbol, PreDefSymbol, Scope };
        public static readonly string[] SymbolBoundary = { NameDef, TypeDef, NameCtr, TypeCtr, NameUse, TypeUse, Symbol, PreDefSymbol, Scope };
        public static readonly string[] VisitBoundary = { Name, QualifiedName };

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
            DefaultProperties.Add(NameDef, "symbolType");
            DefaultProperties.Add(TypeDef, "symbolType");
            DefaultProperties.Add(NameCtr, "symbolType");
            DefaultProperties.Add(TypeCtr, "symbolType");
            DefaultProperties.Add(NameUse, "symbolTypes");
            DefaultProperties.Add(TypeUse, "symbolTypes");
            DefaultProperties.Add(Scope, "symbolType");
            DefaultProperties.Add(Symbol, "symbolType");
            DefaultProperties.Add(SymbolType, "symbolType");
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

        public MetaCompilerAnnotations Add(MetaCompilerAnnotation annotation)
        {
            List<MetaCompilerAnnotation> newAnnotations = new List<MetaModel.MetaCompilerAnnotation>(this.Annotations);
            newAnnotations.Add(annotation);
            return new MetaCompilerAnnotations(newAnnotations);
        }

        public MetaCompilerAnnotations AddRange(IReadOnlyList<MetaCompilerAnnotation> annotations)
        {
            List<MetaCompilerAnnotation> newAnnotations = new List<MetaModel.MetaCompilerAnnotation>(this.Annotations);
            newAnnotations.AddRange(annotations);
            return new MetaCompilerAnnotations(newAnnotations);
        }

        public MetaCompilerAnnotations Merge(MetaCompilerAnnotations annotations)
        {
            List<MetaCompilerAnnotation> newAnnotations = new List<MetaModel.MetaCompilerAnnotation>(this.Annotations);
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

        public override string ToString()
        {
            return this.Name;
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
