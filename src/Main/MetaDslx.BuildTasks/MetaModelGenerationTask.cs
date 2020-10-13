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
        public string OutputDirectory { get; set; }
        public string OutputLocation { get; set; }

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
            if (!string.IsNullOrWhiteSpace(OutputDirectory))
            {
                arguments.Add("--output-directory");
                arguments.Add(OutputDirectory);
            }
            else if (OutputLocation == "CurrentDirectory")
            {
                arguments.Add("--output-location");
                arguments.Add(OutputLocation);
            }
        }
    }
}
