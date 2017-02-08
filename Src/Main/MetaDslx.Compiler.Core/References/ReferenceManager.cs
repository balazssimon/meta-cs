using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.References
{
    public class ReferenceManager
    {
        internal void CreateSourceCompilationSymbol(Compilation compilation)
        {
            throw new NotImplementedException();
        }

        public ImmutableArray<ImmutableModel> ReferencedModels { get; }

        internal bool DeclarationsAccessibleWithoutAlias(int i)
        {
            return true;
        }
    }
}
