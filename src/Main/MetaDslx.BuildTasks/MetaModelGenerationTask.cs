using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class MetaModelGenerationTask : MetaDslxBuildTask
    {
        public MetaModelGenerationTask()
            : base("mm")
        {
        }

        public bool CompileMetaModelCore { get; set; }
        public string MetaModelCoreNamespace { get; set; }

        protected override void AddSubArguments(List<string> arguments)
        {
            if (CompileMetaModelCore)
            {
                arguments.Add("--is-core-model");
            }
            if (!string.IsNullOrWhiteSpace(MetaModelCoreNamespace))
            {
                arguments.Add("--core-namespace");
                arguments.Add(MetaModelCoreNamespace);
            }
        }
    }
}
