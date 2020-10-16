using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MetaDslx.BuildTasks
{
    public abstract class MetaDslxBuildTask : BuildToolTask
    {
        private List<string> _generatedCodeFiles = new List<string>();
        private List<string> _generatedIntermediateCodeFiles = new List<string>();

        public MetaDslxBuildTask(string subToolName)
            : base("metadslx")
        {
            SubToolName = subToolName;
        }

        public string SubToolName { get; }
        public string IntermediateDirectory { get; set; }
        public string Encoding { get; set; }
        public bool ContinueOnError { get; set; }

        public string ManualOutputDirectory { get; set; }
        public string AutomaticOutputDirectory { get; set; }
        public string AutomaticOutputLocation { get; set; }

        public ITaskItem[] SourceCodeFiles { get; set; }

        [Output]
        public ITaskItem[] GeneratedCodeFiles => this._generatedCodeFiles.Select(f => new TaskItem(f)).ToArray();

        [Output]
        public ITaskItem[] GeneratedIntermediateCodeFiles => this._generatedIntermediateCodeFiles.Select(f => new TaskItem(f)).ToArray();

        protected abstract void AddSubArguments(List<string> arguments);

        protected override void AddArguments(List<string> arguments)
        {
            arguments.Add(SubToolName);
            foreach (var sourceCodeFile in SourceCodeFiles)
            {
                arguments.Add("--input");
                arguments.Add(sourceCodeFile.ItemSpec);
            }
            if (!string.IsNullOrWhiteSpace(ManualOutputDirectory))
            {
                arguments.Add("--manual-output-directory");
                arguments.Add(ManualOutputDirectory);
            }
            if (!string.IsNullOrWhiteSpace(AutomaticOutputDirectory))
            {
                arguments.Add("--automatic-output-directory");
                arguments.Add(AutomaticOutputDirectory);
            }
            else if (AutomaticOutputLocation == "ManualOutputDirectory")
            {
                if (!string.IsNullOrWhiteSpace(ManualOutputDirectory))
                {
                    arguments.Add("--automatic-output-directory");
                    arguments.Add(ManualOutputDirectory);
                }
            }
            else
            {
                arguments.Add("--automatic-output-directory");
                arguments.Add(IntermediateDirectory);
            }
            AddSubArguments(arguments);
        }

        private static Regex GeneratedFileMessageFormat =
            new Regex(@"^\s*generated\s*file\s*:\s*(?<FILEPATH>.*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        protected override bool HandleOutputData(string data)
        {
            Match match = GeneratedFileMessageFormat.Match(data);
            if (!match.Success) return false;

            string filePath = match.Groups["FILEPATH"].Value?.Trim();
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath) && Path.GetExtension(filePath) == ".cs")
            {
                if (!string.IsNullOrEmpty(IntermediateDirectory) && filePath.StartsWith(IntermediateDirectory))
                {
                    _generatedIntermediateCodeFiles.Add(filePath);
                }
                else
                {
                    _generatedCodeFiles.Add(filePath);
                }
            }
            return true;
        }
    }
}
