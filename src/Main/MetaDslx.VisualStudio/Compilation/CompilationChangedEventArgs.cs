using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public class CompilationChangedEventArgs
    {
        public CompilationChangedEventArgs(CompilationSnapshot oldCompilation, CompilationSnapshot newCompilation)
        {
            this.OldCompilation = oldCompilation;
            this.NewCompilation = newCompilation;
        }

        public CompilationSnapshot OldCompilation { get; private set; }
        public CompilationSnapshot NewCompilation { get; private set; }
    }
}
