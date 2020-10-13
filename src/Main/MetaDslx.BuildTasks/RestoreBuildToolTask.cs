using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.BuildTasks
{
    public class RestoreBuildToolTask : BuildToolTask
    {
        public RestoreBuildToolTask()
            : base("tool")
        {
        }

        public string Dll { get; set; }

        public override bool Execute()
        {
            var result = base.Execute();
            if (!result)
            {
                var arguments = new List<string>();
                arguments.Add("new");
                arguments.Add("tool-manifest");
                result = RunTool(arguments);

                if (!result) return result;

                arguments = new List<string>();
                arguments.Add("tool");
                arguments.Add("update");
                arguments.Add(Dll);
                arguments.Add("--version");
                var assembly = typeof(RestoreBuildToolTask).Assembly;
                var version = assembly.GetName().Version.ToString();
                arguments.Add(version);
                result = RunTool(arguments);
                return result;
            }
            return result;
        }

        protected override void AddArguments(List<string> arguments)
        {
            arguments.Add("update");
            arguments.Add(Dll);
            arguments.Add("--version");
            var assembly = typeof(RestoreBuildToolTask).Assembly;
            var version = assembly.GetName().Version.ToString();
            arguments.Add(version);
        }
    }
}
