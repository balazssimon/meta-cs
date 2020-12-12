// NOTE: This is an auto-generated file. However, it will not be changed or regenerated unless you delete it.
using MetaDslx.Languages.MetaCompiler.Model;

namespace MetaDslx.Languages.MetaCompiler.Generator //1:1
{
    internal class SymbolGeneratorExtensions : ISymbolGeneratorExtensions
    {
        private readonly SymbolGenerator _generator;
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
            return typ.MName;
        }

        public string Start(Phase phase)
        {
            if (phase.IsLocked) return "Start" + phase.Name;
            else return phase.Name;
        }
    }
}

