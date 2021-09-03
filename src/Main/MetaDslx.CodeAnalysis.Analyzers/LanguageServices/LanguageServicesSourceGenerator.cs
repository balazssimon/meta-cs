extern alias msca;
using msca::Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.LanguageServices
{
    //[Generator]
    public class LanguageServicesSourceGenerator : ISourceGenerator
    {
        private const string DisableProperty = "MetaDslxDisableLanguageServicesSourceGenerator";

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                if (context.GetMSBuildProperty(DisableProperty, "false") == "true")
                {
                    Debug.WriteLine($"Skipping language service source generation because of the MSBuild property: {DisableProperty}=true");
                    return;
                }
                foreach (var symbol in GeneratorUtils.GetSourceNamedTypeSymbols(context.Compilation))
                {
                    
                }
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
