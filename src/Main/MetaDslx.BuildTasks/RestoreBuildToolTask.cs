using Microsoft.Build.Framework;
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
            Version = typeof(RestoreBuildToolTask).Assembly.GetName().Version.ToString();
        }

        public string Dll { get; set; }
        public string Version { get; set; }

        public override bool Execute()
        {
            ForwardLogs = false;
            var result = base.Execute();
            if (!result)
            {
                var arguments = new List<string>();
                arguments.Add("new");
                arguments.Add("tool-manifest");
                RunTool(arguments);

                arguments = new List<string>();
                arguments.Add("tool");
                arguments.Add("uninstall");
                arguments.Add(Dll);
                RunTool(arguments);

                arguments = new List<string>();
                arguments.Add("tool");
                arguments.Add("update");
                arguments.Add(Dll);
                arguments.Add("--version");
                arguments.Add(Version);
                result = RunTool(arguments);
            }
            if (result) Log.LogMessage(MessageImportance.High, ".NET core tool '{0}' version '{1}' is installed.", Dll, Version);
            else Log.LogError("Could not install .NET core tool '{0}' version '{1}'.", Dll, Version);
            return result;
        }

        protected override void AddArguments(List<string> arguments)
        {
            arguments.Add("update");
            arguments.Add(Dll);
            arguments.Add("--version");
            arguments.Add(Version);
        }
    }
}
