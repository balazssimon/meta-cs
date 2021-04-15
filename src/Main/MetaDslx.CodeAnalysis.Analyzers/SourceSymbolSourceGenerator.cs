using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols.CodeGeneration;
using System.IO;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Analyzers.Symbols;
using MetaDslx.CodeAnalysis.Analyzers.CodeGeneration;

namespace MetaDslx.CodeAnalysis.Analyzers
{
    [Generator]
    public class SourceSymbolSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                var generator = new StandaloneSourceSymbolSourceGenerator();
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
