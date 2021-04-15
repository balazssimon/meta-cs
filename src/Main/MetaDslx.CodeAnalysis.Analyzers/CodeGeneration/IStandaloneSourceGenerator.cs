using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.CodeGeneration
{
    public interface IStandaloneSourceGenerator
    {
        void Execute(StandaloneGeneratorExecutionContext context);
    }
}
