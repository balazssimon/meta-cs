using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Model.Internal;
using MetaDslx.Modeling;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Meta.Generator
{
    internal class MetaModelGeneratorExtensions : IMetaModelGeneratorExtensions
    {
        private static readonly string[] s_reservedNames = 
            new string[] 
            {
                "object", "bool", "string", "byte", "int", "long", "float", "double",
                "class", "enum", "list", "set", "multi_list", "multi_set", "redefines",
                "subsets", "association", "with", "lazy", "derived", "union", "containment"
            };
        private MetaModelGenerator _generator;

        public MetaModelGeneratorExtensions(MetaModelGenerator generator)
        {
            _generator = generator;
        }

        public string EscapeName(string name)
        {
            if (s_reservedNames.Contains(name)) return "@" + name;
            else return name;
        }

        public string GenerateDefaultValue(MetaProperty property)
        {
            if (property.DefaultValue != null)
            {
                if (GetType(property) is MetaEnum enm) return string.Format(" = \"{0}.{1}\"", enm.Name.ToPascalCase(), property.DefaultValue);
                else return string.Format(" = \"{0}\"", property.DefaultValue);
            }
            return string.Empty;
        }

        public IEnumerable<(MetaProperty, MetaProperty)> GetAssociations(IEnumerable<ImmutableObject> objects)
        {
            var result = new List<(MetaProperty, MetaProperty)>();
            foreach (var prop in objects.OfType<MetaProperty>())
            {
                foreach (var opposite in prop.OppositeProperties)
                {
                    if (!result.Contains((prop, opposite)) && !result.Contains((opposite, prop)))
                    {
                        result.Add((prop, opposite));
                    }
                }
            }
            return result;
        }

        public MetaElement GetType(MetaTypedElement melem)
        {
            //return MetaImplementation.GetMetaType(melem);
            return (MetaElement)melem.MGet(MetaDescriptor.MetaTypedElement.TypeProperty);
        }

        public string ToCSharpAlias(string name)
        {
            switch (name)
            {
                case "System.Object":
                    return "object";
                case "System.String":
                    return "string";
                case "System.Int32":
                    return "int";
                case "System.Int64":
                    return "long";
                case "System.Single":
                    return "float";
                case "System.Double":
                    return "double";
                case "System.Byte":
                    return "byte";
                case "System.Boolean":
                    return "bool";
                case "System.Void":
                    return "void";
                default:
                    return name ?? "ERROR";
            }
        }
    }
}
