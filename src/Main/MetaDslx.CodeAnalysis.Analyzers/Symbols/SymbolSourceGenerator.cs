extern alias msca;
using msca::Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Analyzers.Standalone;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    [Generator]
    public class SymbolSourceGenerator : ISourceGenerator
    {
        private const string DisableProperty = "MetaDslxDisableSymbolSourceGenerator";

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                if (context.GetMSBuildProperty(DisableProperty, "false") == "true")
                {
                    Debug.WriteLine($"Skipping symbol source generation because of the MSBuild property: {DisableProperty}=true");
                    return;
                }
                var generator = new StandaloneSymbolSourceGenerator();
                generator.Execute(StandaloneGeneratorExecutionContext.FromCSharp(context));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }

    }
}
