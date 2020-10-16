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

        protected override void AddSubArguments(List<string> arguments)
        {
        }
    }
}
