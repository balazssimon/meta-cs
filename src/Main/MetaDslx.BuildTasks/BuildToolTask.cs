using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace MetaDslx.BuildTasks
{
    public enum LogSeverity
    {
        Error,
        Warning,
        Info
    }

    public abstract class BuildToolTask : Task
    {
        private List<(LogSeverity, string)> _logs = new List<(LogSeverity, string)>();

        public BuildToolTask(string toolName)
        {
            ToolName = toolName;
            ForwardLogs = true;
        }

        public string ToolName { get; }
        public List<(LogSeverity, string)> SavedLogs { get; }
        public int TimeoutInSeconds { get; set; }
        public bool ForwardLogs { get; set; }
        public bool DebugBuildTool { get; set; }

        protected abstract void AddArguments(List<string> arguments);

        public override bool Execute()
        {
            var arguments = new List<string>();
            arguments.Add(ToolName);
            AddArguments(arguments);
            return RunTool(arguments);
        }

        protected bool RunTool(List<string> arguments)
        {
            try
            {
                if (DebugBuildTool)
                {
                    System.Diagnostics.Debugger.Launch();
                }

                var startInfo = new ProcessStartInfo("dotnet", JoinArguments(arguments))
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                Log.LogMessage(MessageImportance.High, "Executing: {0} {1}", startInfo.FileName, startInfo.Arguments);

                var process = new Process();
                process.StartInfo = startInfo;
                process.ErrorDataReceived += HandleErrorDataReceived;
                process.OutputDataReceived += HandleOutputDataReceived;
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.StandardInput.Dispose();
                if (TimeoutInSeconds <= 0) process.WaitForExit();
                else process.WaitForExit(TimeoutInSeconds * 1000);

                bool success = process.ExitCode == 0 && !Log.HasLoggedErrors;
                return success;
            }
            catch (Exception ex)
            {
                ProcessException(ex);
                return false;
            }
        }

        protected virtual bool HandleErrorData(string data)
        {
            return false;
        }

        protected virtual bool HandleOutputData(string data)
        {
            return false;
        }

        protected static readonly Regex MsBuildMessageFormat =
            new Regex(
                @"^((?<ORIGIN>([a-z]:)?[^\(\)\:]*)(\((?<LINE1>\d*)\s*(,\s*(?<COLUMN1>\d*))?(,\s*(?<LINE2>\d*))?(,\s*(?<COLUMN2>\d*))?\s*\)?)?\s*:\s*)?\s*(?<CATEGORY>(info|error|warning))\s*(?<CODE>\w+\d)?\s*:\s*(?<TEXT>.*$)",
                RegexOptions.IgnoreCase | RegexOptions.Compiled
            );

        protected void HandleErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            HandleErrorDataReceived(e.Data);
        }

        private void HandleErrorDataReceived(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                if (!HandleErrorData(data) && ForwardLogs)
                {
                    Match match = MsBuildMessageFormat.Match(data);
                    if (!match.Success)
                    {
                        Log.LogError(data);
                        return;
                    }
                    string origin = match.Groups["ORIGIN"].Value;
                    string subcategory = match.Groups["SUBCATEGORY"].Value;
                    string category = match.Groups["CATEGORY"].Value;
                    string code = match.Groups["CODE"].Value;
                    string text = match.Groups["TEXT"].Value;
                    string line1 = match.Groups["LINE1"].Value;
                    string column1 = match.Groups["COLUMN1"].Value;
                    string line2 = match.Groups["LINE2"].Value;
                    string column2 = match.Groups["COLUMN2"].Value;
                    int.TryParse(line1, out var l1);
                    int.TryParse(column1, out var c1);
                    int.TryParse(line2, out var l2);
                    int.TryParse(column2, out var c2);
                    switch (category)
                    {
                        case "error":
                            Log.LogError(subcategory, code, null, origin, l1, c1, l2, c2, text);
                            break;
                        case "warning":
                            Log.LogWarning(subcategory, code, null, origin, l1, c1, l2, c2, text);
                            break;
                        default:
                            Log.LogMessage(MessageImportance.High, subcategory, code, null, origin, l1, c1, l2, c2, text);
                            break;
                    }
                }
                else
                {
                    _logs.Add((LogSeverity.Info, data));
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void HandleOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            HandleOutputDataReceived(e.Data);
        }

        private void HandleOutputDataReceived(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                if (!HandleOutputData(data) && ForwardLogs)
                {
                    Log.LogMessage(MessageImportance.High, data);
                }
                else
                {
                    _logs.Add((LogSeverity.Info, data));
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        protected void ProcessException(Exception ex)
        {
            if (ForwardLogs) Log.LogError(ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
            else _logs.Add((LogSeverity.Error, ex.ToString().Replace('\r', ' ').Replace('\n', ' ')));
        }

    protected static string JoinArguments(IEnumerable<string> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException("arguments");

            StringBuilder builder = new StringBuilder();
            foreach (string argument in arguments)
            {
                if (builder.Length > 0)
                    builder.Append(' ');

                if (argument.IndexOfAny(new[] { '"', ' ' }) < 0)
                {
                    builder.Append(argument);
                    continue;
                }

                // escape a backslash appearing before a quote
                string arg = argument.Replace("\\\"", "\\\\\"");
                // escape double quotes
                arg = arg.Replace("\"", "\\\"");

                // wrap the argument in outer quotes
                builder.Append('"').Append(arg).Append('"');
            }

            return builder.ToString();
        }

    }
}
