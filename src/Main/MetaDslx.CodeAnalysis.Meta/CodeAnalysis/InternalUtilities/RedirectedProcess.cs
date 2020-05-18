using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.InternalUtilities
{
    public class RedirectedProcess
    {
        public static (int ExitCode, bool TimedOut, string StandardOutput, string StandardError, Exception ex) Execute(string fileName, string arguments, int timeoutInMilliseconds = 0)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Arguments = arguments;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    int exitCode = -1;
                    bool timedOut = false;
                    StringBuilder output = new StringBuilder();
                    StringBuilder error = new StringBuilder();

                    using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                    using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                    {
                        try
                        {
                            process.OutputDataReceived += (sender, e) =>
                            {
                                if (e.Data == null)
                                {
                                    outputWaitHandle.Set();
                                }
                                else
                                {
                                    output.AppendLine(e.Data);
                                }
                            };
                            process.ErrorDataReceived += (sender, e) =>
                            {
                                if (e.Data == null)
                                {
                                    errorWaitHandle.Set();
                                }
                                else
                                {
                                    error.AppendLine(e.Data);
                                }
                            };

                            process.Start();

                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();

                            if (process.WaitForExit(timeoutInMilliseconds))
                            {
                                exitCode = process.ExitCode;
                            }
                            else
                            {
                                timedOut = true;
                                process.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            return (exitCode, timedOut, output.ToString(), error.ToString(), ex);
                        }
                        finally
                        {
                            outputWaitHandle.WaitOne(timeoutInMilliseconds);
                            errorWaitHandle.WaitOne(timeoutInMilliseconds);
                        }
                    }
                    return (exitCode, timedOut, output.ToString(), error.ToString(), null);
                }
            }
            catch (Exception ex)
            {
                return (-1, true, string.Empty, string.Empty, ex);
            }
        }
    }
}
