using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Meta.Generator
{
    internal class MetaModelGeneratorExtensions : IMetaModelGeneratorExtensions
    {
        private MetaModelGenerator _generator;

        public MetaModelGeneratorExtensions(MetaModelGenerator generator)
        {
            _generator = generator;
        }

        public string GenerateDefaultValue(MetaProperty property)
        {
            if (property.DefaultValue != null)
            {
                if (property.Type is MetaEnum enm) return string.Format(" = \"{0}.{1}\"", enm.Name.ToPascalCase(), property.DefaultValue);
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
    }
}
