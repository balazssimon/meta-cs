using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Directory = System.IO.Directory;
using File = System.IO.File;
using FileAttributes = System.IO.FileAttributes;
using Path = System.IO.Path;
using StringBuilder = System.Text.StringBuilder;

namespace MetaDslx.BuildTools
{
    public class Antlr4BuildTool : Antlr4Tool
    {
        private List<string> _generatedCodeFiles = new List<string>();

        private string JavaHome
        {
            get
            {
                if (Directory.Exists(Environment.GetEnvironmentVariable("JAVA_HOME")))
                    return Environment.GetEnvironmentVariable("JAVA_HOME");

                throw new NotSupportedException("Could not locate a Java installation.");
            }
        }

        protected override bool DoExecute()
        {
            bool success = false;
            try
            {
                if (SourceCodeFiles.Count == 0)
                {
                    throw new FileNotFoundException("There is no input file.");
                }

                if (string.IsNullOrWhiteSpace(JavaExe))
                {
                    var javaHome = this.JavaHome;
                    if (!string.IsNullOrWhiteSpace(javaHome))
                    {
                        JavaExe = Path.Combine(javaHome, "bin", "java.exe");
                    }
                }
                //this.AddDiagnosticInfo($"JavaExe is '{JavaExe}'");
                if (string.IsNullOrWhiteSpace(JavaExe) || !File.Exists(JavaExe))
                {
                    throw new FileNotFoundException("Could not find 'java.exe'. Please, install a JRE and set the JAVA_HOME environment variable.");
                }

                if (string.IsNullOrWhiteSpace(ToolPath))
                {
                    string assemblyPath = Path.GetDirectoryName(typeof(Antlr4BuildTool).Assembly.Location);
                    ToolPath = Path.Combine(assemblyPath, "..", "..", Resources.Antlr4JarName.Trim());
                }

                if (string.IsNullOrWhiteSpace(ToolPath) || !File.Exists(ToolPath))
                {
                    throw new FileNotFoundException($"Could not find the ANTLR4 jar at '{ToolPath}'.");
                }

                // Because we're using the Java version of the Antlr tool,
                // we're going to execute this command twice: first with the
                // -depend option so as to get the list of generated files,
                // then a second time to actually generate the files.
                // The code that was here probably worked, but only for the C#
                // version of the Antlr tool chain.
                //
                // After collecting the output of the first command, convert the
                // output so as to get a clean list of files generated.
                List<string> arguments = new List<string>();

                arguments.Add("-cp");
                arguments.Add(ToolPath);
                arguments.Add("org.antlr.v4.Tool");

                arguments.Add("-depend");

                if (!string.IsNullOrEmpty(OutputPath))
                {
                    arguments.Add("-o");
                    arguments.Add(this.OutputPath);
                    Directory.CreateDirectory(OutputPath);
                }

                foreach (var src in SourceCodeFiles)
                {
                    if (string.IsNullOrWhiteSpace(src)) continue;
                    arguments.Add("-lib");
                    arguments.Add(Path.GetDirectoryName(src));
                }

                /*if (!string.IsNullOrEmpty(LibPath))
                {
                    var split = LibPath.Split(';');
                    foreach (var p in split)
                    {
                        if (string.IsNullOrEmpty(p))
                            continue;
                        if (string.IsNullOrWhiteSpace(p))
                            continue;
                        arguments.Add("-lib");
                        arguments.Add(p);
                    }
                }*/

                if (!string.IsNullOrEmpty(Encoding))
                {
                    arguments.Add("-encoding");
                    arguments.Add(Encoding);
                }

                if (GenerateListener)
                    arguments.Add("-listener");
                else
                    arguments.Add("-no-listener");

                if (GenerateVisitor)
                    arguments.Add("-visitor");
                else
                    arguments.Add("-no-visitor");

                if (!string.IsNullOrWhiteSpace(TargetNamespace))
                {
                    arguments.Add("-package");
                    arguments.Add(TargetNamespace);
                }

                arguments.Add("-Dlanguage=" + TargetLanguage);

                if (ForceAtn)
                    arguments.Add("-Xforce-atn");

                arguments.AddRange(SourceCodeFiles);

                ProcessStartInfo startInfo = new ProcessStartInfo(JavaExe, JoinArguments(arguments))
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                //this.AddDiagnosticInfo($"Executing command: '{startInfo.FileName}' {startInfo.Arguments}");

                Process process = new Process();
                process.StartInfo = startInfo;
                process.ErrorDataReceived += HandleErrorDataReceived;
                process.OutputDataReceived += HandleOutputDataReceivedFirstTime;
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.StandardInput.Dispose();
                process.WaitForExit();

                this.AddDiagnosticInfo($"The generated file list contains {_generatedCodeFiles.Count()} items.");

                if (process.ExitCode != 0) return false;

                // Add in tokens and interp files since Antlr Tool does not do that.
                var old_list = _generatedCodeFiles.ToList();
                _generatedCodeFiles.Clear();
                foreach (var s in old_list)
                {
                    if (Path.GetExtension(s) == ".tokens")
                    {
                        var interp = s.Replace(Path.GetExtension(s), ".interp");
                        _generatedCodeFiles.Add(interp);
                    }
                    _generatedCodeFiles.Add(s);
                }

                // Remove the -depend option from the second run
                arguments.Remove("-depend");

                startInfo = new ProcessStartInfo(JavaExe, JoinArguments(arguments))
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                this.AddDiagnosticInfo($"Executing command: '{startInfo.FileName}' {startInfo.Arguments}");

                process = new Process();
                process.StartInfo = startInfo;
                process.ErrorDataReceived += HandleErrorDataReceived;
                process.OutputDataReceived += HandleOutputDataReceived;
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.StandardInput.Dispose();
                process.WaitForExit();

                this.AddDiagnosticInfo($"The generated file list contains {_generatedCodeFiles.Count()} items.");

                // At this point, regenerate the entire _generatedCodeFiles list.
                // This is because (1) it contains duplicates; (2) it contains
                // files that really actually weren't generated. This can happen
                // if the grammar was a Lexer grammar. (Note, I don't think it
                // wise to look at the grammar file to figure out what it is, nor
                // do I think it wise to expose a switch to the user for him to
                // indicate what type of grammar it is.)
                var new_code_list = new List<string>();
                var new_all_list = new List<string>();
                foreach (var fn in _generatedCodeFiles.Distinct().ToList())
                {
                    if (File.Exists(fn))
                    {

                    }
                    var ext = Path.GetExtension(fn);
                    if (ext != ".g4")
                    {
                        AllGeneratedFiles.Add(fn);
                    }
                    if (ext == ".cs" || ext == ".java" || ext == ".cpp" || ext == ".php" || ext == ".js")
                    {
                        GeneratedCodeFiles.Add(fn);
                    }
                }
                success = process.ExitCode == 0;
            }
            catch (Exception exception)
            {
                ProcessException(exception);
                success = false;
            }

            if (!success)
            {
                AllGeneratedFiles.Clear();
                GeneratedCodeFiles.Clear();
            }

            return success;
        }

        protected void AddDiagnosticInfo(string message)
        {
            this.AddDiagnostic(DiagnosticSeverity.Info, -1, null, -1, -1, message);
        }

        private void ProcessException(Exception ex)
        {
            this.AddDiagnostic(DiagnosticSeverity.Error, -1, null, -1, -1, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
        }

        internal static bool IsFatalException(Exception exception)
        {
            while (exception != null)
            {
                if (exception is OutOfMemoryException)
                {
                    return true;
                }

                if (!(exception is TypeInitializationException) && !(exception is TargetInvocationException))
                {
                    break;
                }

                exception = exception.InnerException;
            }

            return false;
        }


        private static string JoinArguments(IEnumerable<string> arguments)
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

        private static readonly Regex ErrorMessageFormat = new Regex(@"^(?<SEVERITY>[a-z]+)\((?<ERRORCODE>[0-9]+)\): (?<FILE>.*?):(?<LINE>[0-9]*?):(?<COLUMN>[0-9]*?): (?<MESSAGE>.*?)$", RegexOptions.Compiled);
        private static readonly Regex GeneratedFileMessageFormat = new Regex(@"^Generating file '(?<OUTPUT>.*?)' for grammar '(?<GRAMMAR>.*?)'$", RegexOptions.Compiled);
        private static readonly Regex DependFileMessageFormat = new Regex(@"^(?<OUTPUT>\S+)\s*:", RegexOptions.Compiled);

        private void HandleErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            HandleErrorDataReceived(e.Data);
        }

        private void HandleErrorDataReceived(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                Match match = ErrorMessageFormat.Match(data);
                if (!match.Success)
                {
                    this.AddDiagnostic(DiagnosticSeverity.Info, -1, null, -1, -1, data);
                    return;
                }

                string severity = match.Groups["SEVERITY"].Value;
                string fileName = match.Groups["FILE"].Value;
                int.TryParse(match.Groups["ERRORCODE"].Value, out int errorCode);
                int.TryParse(match.Groups["LINE"].Value, out int line);
                int.TryParse(match.Groups["COLUMN"].Value, out int column);
                string message = match.Groups["MESSAGE"].Value;

                string filePath = SourceCodeFiles.FirstOrDefault(f => f.EndsWith(fileName)) ?? fileName;
                switch (severity)
                {
                    case "error":
                    case "fatal":
                        this.AddDiagnostic(DiagnosticSeverity.Error, errorCode, filePath, line, column, message);
                        break;
                    case "warning":
                        this.AddDiagnostic(DiagnosticSeverity.Warning, errorCode, filePath, line, column, message);
                        break;
                    case "info":
                    default:
                        this.AddDiagnostic(DiagnosticSeverity.Info, errorCode, filePath, line, column, message);
                        break;
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void HandleOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            HandleOutputDataReceived(e.Data);
        }

        private void HandleOutputDataReceived(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                Match match = GeneratedFileMessageFormat.Match(data);
                if (!match.Success)
                {
                    this.AddDiagnostic(DiagnosticSeverity.Info, -1, null, -1, -1, data);
                    return;
                }

                string fileName = match.Groups["OUTPUT"].Value;
                if (LanguageSourceExtensions != null && LanguageSourceExtensions.Contains(Path.GetExtension(fileName), StringComparer.OrdinalIgnoreCase))
                {
                    _generatedCodeFiles.Add(match.Groups["OUTPUT"].Value);
                }
            }
            catch (Exception ex)
            {
                this.AddDiagnostic(DiagnosticSeverity.Error, -1, null, -1, -1, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
            }
        }

        private void HandleOutputDataReceivedFirstTime(object sender, DataReceivedEventArgs e)
        {
            string data = e.Data as string;
            if (string.IsNullOrEmpty(data))
                return;

            try
            {
                Match match = DependFileMessageFormat.Match(data);
                if (!match.Success)
                {
                    this.AddDiagnostic(DiagnosticSeverity.Info, -1, null, -1, -1, data);
                    return;
                }

                string fileName = match.Groups["OUTPUT"].Value;
                if (LanguageSourceExtensions != null && LanguageSourceExtensions.Contains(Path.GetExtension(fileName), StringComparer.OrdinalIgnoreCase))
                {
                    _generatedCodeFiles.Add(match.Groups["OUTPUT"].Value);
                }
            }
            catch (Exception ex)
            {
                this.AddDiagnostic(DiagnosticSeverity.Error, -1, null, -1, -1, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
            }
        }
    }
}
