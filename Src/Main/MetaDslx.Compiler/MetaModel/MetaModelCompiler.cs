using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{

    public class MetaModelCompiler : MetaModelCompilerBase
    {
        public MetaModelCompiler(string source, string fileName)
            : base(source, fileName)
        {
            this.GlobalScope.AddMetaBuiltInEntries();
        }

    }


}