// NOTE: This is an auto-generated file. However, it will not be changed or regenerated unless you delete it.
using MetaDslx.Languages.MetaCompiler.Model;
using System.Linq;
using System.Text;

namespace MetaDslx.Languages.MetaCompiler.Generator //1:1
{
    internal class SymbolGeneratorExtensions : ISymbolGeneratorExtensions
    {
        private readonly SymbolGenerator _generator;
        private string _symbolNamespace;

        public SymbolGeneratorExtensions(SymbolGenerator generator)
        {
            _generator = generator;
        }

        public string Finish(Phase phase)
        {
            if (phase.IsLocked) return "Finish" + phase.Name;
            else return phase.Name;
        }

        public string GenerateDefaultValue(Property property) //9:8
        {
            return default(string);
        }

        public string GenerateType(DataType typ) //10:8
        {
            if (typ is GenericType gt)
            {
                var sb = new StringBuilder();
                sb.Append(GenerateType(gt.Type));
                sb.Append("<");
                var comma = "";
                foreach (var arg in gt.TypeArguments)
                {
                    sb.Append(comma);
                    sb.Append(GenerateType(arg));
                    comma = ",";
                }
                sb.Append(">");
                return sb.ToString();
            }
            if (typ is ArrayType at)
            {
                return $"ImmutableArray<{GenerateType(at.InnerType)}>";
            }
            if (typ is DictionaryType dt)
            {
                return $"ImmutableDictionary<{GenerateType(dt.KeyType)}, {GenerateType(dt.ValueType)}>";
            }
            return typ.MName;
        }

        public string Start(Phase phase)
        {
            if (phase.IsLocked) return "Start" + phase.Name;
            else return phase.Name;
        }

        public string SymbolNamespace()
        {
            if (_symbolNamespace == null)
            {
                _symbolNamespace = _generator.Instances.OfType<Class>().Where(cls => cls.Kind == ClassKind.Symbol).FirstOrDefault()?.Namespace?.FullName;
            }
            return _symbolNamespace;
        }

        public string TrimSymbolSuffix(string name)
        {
            if (name == null) return null;
            if (name.EndsWith("Symbol")) return name.Substring(0, name.Length - 6);
            return name;
        }

        public string VirtualModifier(MemberDeclaration member, string defaultValue)
        {
            var result = new StringBuilder();
            if (member.IsNew) result.Append("new ");
            if (member.IsStatic) result.Append("static ");
            if (member.IsSealed) result.Append("sealed ");
            if (member.IsOverride) result.Append("override ");
            if (member.IsVirtual) result.Append("virtual ");
            if (member.IsAbstract) result.Append("abstract ");
            if (result.Length == 0 && defaultValue.Length > 0)
            {
                result.Append(defaultValue);
                result.Append(" ");
            }
            return result.ToString();
        }

        public string Visibility(MemberDeclaration member, string defaultValue)
        {
            return member.Visibility == VisibilityKind.None ? defaultValue + " " : member.Visibility.ToString()?.ToLower() + " ";
        }
    }
}

