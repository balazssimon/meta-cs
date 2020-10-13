using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class MetaGeneratorGenerationTask : MetaDslxBuildTask
    {
        public MetaGeneratorGenerationTask()
            : base("mgen")
        {
        }

        public string OutputDirectory { get; set; }
        public string OutputLocation { get; set; }

        protected override void AddSubArguments(List<string> arguments)
        {
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
