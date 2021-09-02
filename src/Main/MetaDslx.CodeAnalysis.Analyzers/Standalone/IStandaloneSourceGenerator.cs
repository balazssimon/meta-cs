using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Standalone
{
    public interface IStandaloneSourceGenerator
    {
        void Execute(StandaloneGeneratorExecutionContext context);
    }
}
