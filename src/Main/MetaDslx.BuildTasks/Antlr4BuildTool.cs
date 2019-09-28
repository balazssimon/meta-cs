using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
#if !NETSTANDARD
using RegistryKey = Microsoft.Win32.RegistryKey;
using RegistryHive = Microsoft.Win32.RegistryHive;
using RegistryView = Microsoft.Win32.RegistryView;
#endif

namespace MetaDslx.BuildTasks
{
    public class Antlr4BuildTool : Antlr4Tool
    {
        private string JavaHome
        {
            get
            {
#if !NETSTANDARD
                string javaHome;
                if (TryGetJavaHome(RegistryView.Default, JavaVendor, JavaInstallation, out javaHome))
                    return javaHome;

                if (TryGetJavaHome(RegistryView.Registry64, JavaVendor, JavaInstallation, out javaHome))
                    return javaHome;

                if (TryGetJavaHome(RegistryView.Registry32, JavaVendor, JavaInstallation, out javaHome))
                    return javaHome;
#endif

                if (Directory.Exists(Environment.GetEnvironmentVariable("JAVA_HOME")))
                    return Environment.GetEnvironmentVariable("JAVA_HOME");

                throw new NotSupportedException("Could not locate a Java installation.");
            }
        }

#if !NETSTANDARD
        private static bool TryGetJavaHome(RegistryView registryView, string vendor, string installation, out string javaHome)
        {
            javaHome = null;

            string javaKeyName = "SOFTWARE\\" + vendor + "\\" + installation;
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                using (RegistryKey javaKey = baseKey.OpenSubKey(javaKeyName))
                {
                    if (javaKey == null)
                        return false;

                    object currentVersion = javaKey.GetValue("CurrentVersion");
                    if (currentVersion == null)
                        return false;

                    using (var homeKey = javaKey.OpenSubKey(currentVersion.ToString()))
                    {
                        if (homeKey == null || homeKey.GetValue("JavaHome") == null)
                            return false;

                        javaHome = homeKey.GetValue("JavaHome").ToString();
                        return !string.IsNullOrEmpty(javaHome);
                    }
                }
            }
        }
#endif

        protected override bool DoExecute()
        {
            try
            {
                string executable = null;
                if (!UseCSharpGenerator)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(JavaExecutable))
                        {
                            executable = JavaExecutable;
                        }
                        else
                        {
                            string javaHome = JavaHome;
                            executable = Path.Combine(Path.Combine(javaHome, "bin"), "java.exe");
                            if (!File.Exists(executable))
                                executable = Path.Combine(Path.Combine(javaHome, "bin"), "java");
                        }
                    }
                    catch (NotSupportedException)
                    {
                        // Fall back to using the new code generation tools
                        UseCSharpGenerator = true;
                    }
                }

                if (!string.IsNullOrWhiteSpace(ToolPath) && UseCSharpGenerator)
                {
#if NETSTANDARD
                    string framework = "netstandard2.0";
                    string extension = ".dll";
#else
                    string framework = "net461";
                    string extension = ".exe";
#endif
                    executable = Path.Combine(Path.Combine(Path.GetDirectoryName(ToolPath), framework), "Antlr4" + extension);
                }

                List<string> arguments = new List<string>();

                if (!UseCSharpGenerator)
                {
                    arguments.Add("-cp");
                    arguments.Add(ToolPath);
                    arguments.Add("org.antlr.v4.CSharpTool");
                }

                arguments.Add("-o");
                arguments.Add(OutputPath);

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

                if (ForceAtn)
                    arguments.Add("-Xforce-atn");

                if (AbstractGrammar)
                    arguments.Add("-Dabstract=true");

                if (!string.IsNullOrEmpty(TargetLanguage))
                {
                    // Since the C# target currently produces the same code for all target framework versions, we can
                    // avoid bugs with support for newer frameworks by just passing CSharp as the language and allowing
                    // the tool to use a default.
                    arguments.Add("-Dlanguage=" + TargetLanguage);
                }

                if (!string.IsNullOrEmpty(TargetNamespace))
                {
                    arguments.Add("-package");
                    arguments.Add(TargetNamespace);
                }

                arguments.AddRange(SourceCodeFiles);

#if NETSTANDARD
                if (UseCSharpGenerator && string.IsNullOrWhiteSpace(ToolPath))
                {
                    var outWriter = new StringWriter();
                    var errorWriter = new StringWriter();
                    try
                    {
                        var antlr = new Antlr4.AntlrTool(arguments.ToArray())
                        {
                            ConsoleOut = outWriter,
                            ConsoleError = errorWriter
                        };

                        antlr.ProcessGrammarsOnCommandLine();

                        return antlr.errMgr.GetNumErrors() == 0;
                    }
                    finally
                    {
                        foreach (var line in outWriter.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            HandleOutputDataReceived(line);
                        }

                        foreach (var line in errorWriter.ToString().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            HandleErrorDataReceived(line);
                        }
                    }
                }
#endif

                ProcessStartInfo startInfo = new ProcessStartInfo(executable, JoinArguments(arguments))
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                this.AddDiagnostic(DiagnosticSeverity.Info, -1, null, -1, -1, "Executing command: \"" + startInfo.FileName + "\" " + startInfo.Arguments);

                Process process = new Process();
                process.StartInfo = startInfo;
                process.ErrorDataReceived += HandleErrorDataReceived;
                process.OutputDataReceived += HandleOutputDataReceived;
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.StandardInput.Dispose();
                if (this.TimeoutInSeconds < 0) process.WaitForExit();
                else process.WaitForExit(this.TimeoutInSeconds * 1000);

                return process.ExitCode == 0;
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException && e.InnerException != null)
                    e = e.InnerException;

                this.AddDiagnostic(DiagnosticSeverity.Error, -1, null, -1, -1, e.ToString().Replace('\r', ' ').Replace('\n', ' '));
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

        private void HandleErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            HandleErrorDataReceived(e.Data);
        }

        private void HandleErrorDataReceived(string data)
        {
            if (string.IsNullOrEmpty(data))
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
                int.TryParse(match.Groups["COLUMN"].Value, out int column);
                int.TryParse(match.Groups["LINE"].Value, out int line);
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
                this.AddDiagnostic(DiagnosticSeverity.Error, -1, null, -1, -1, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
            }
        }

        private void HandleOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            HandleOutputDataReceived(e.Data);
        }

        private void HandleOutputDataReceived(string data)
        {
            if (string.IsNullOrEmpty(data))
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
                    GeneratedCodeFiles.Add(match.Groups["OUTPUT"].Value);
            }
            catch (Exception ex)
            {
                this.AddDiagnostic(DiagnosticSeverity.Error, -1, null, -1, -1, ex.ToString().Replace('\r', ' ').Replace('\n', ' '));
            }
        }
    }
}
