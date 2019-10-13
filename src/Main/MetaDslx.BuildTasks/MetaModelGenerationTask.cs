using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.Meta;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class MetaModelGenerationTask : Antlr4CompilerTask
    {
        public bool CompileMetaModelCore { get; set; }
        public string MetaModelCoreNamespace { get; set; }

        public MetaModelGenerationTask()
            : base("MetaModel")
        {
        }

        protected override ICompilerForBuildTask CreateCompiler(string filePath, string outputPath)
        {
            return new MetaCompilerForBuildTask(filePath, outputPath, this.CompileMetaModelCore, this.MetaModelCoreNamespace);
        }
    }
}
