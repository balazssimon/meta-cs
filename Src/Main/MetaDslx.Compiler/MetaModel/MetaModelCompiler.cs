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
        public MetaModelCompiler(string source, string outputDirectory, string fileName)
            : base(source, outputDirectory, fileName)
        {
            this.GlobalScope.AddMetaBuiltInEntries();
        }

        protected override void DoCompile()
        {
            base.DoCompile();
            if (this.GenerateOutput && !this.Diagnostics.HasErrors())
            {
                MetaModelCSharpGenerator generator = new MetaModelCSharpGenerator(ModelContext.Current.Instances);
                this.GeneratedSource = generator.Generate();
            }
        }

        public string GeneratedSource { get; private set; }
    }


}