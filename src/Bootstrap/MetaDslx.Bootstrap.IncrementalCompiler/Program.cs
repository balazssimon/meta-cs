using MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.Tests;
using System;
using System.IO;

namespace MetaDslx.Bootstrap.IncrementalCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var assertions = new DebugAssertUnitTestTraceListener())
            {
                try
                {
                    CallLogger.Enabled = true;
                    EditTest.InputFileDirectory = @"c:\Users\Balazs\source\repos\meta-cs\src\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\IncrementalCompilation";
                    var test = new EditTest();
                    test.SerialEdits();
                    foreach (var assertion in assertions.AssertionFailures)
                    {
                        Console.WriteLine(assertion);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    File.WriteAllText(@"..\..\..\CallLog.txt", CallLogger.Instance.GetLog());
                }
            }
        }
    }
}
