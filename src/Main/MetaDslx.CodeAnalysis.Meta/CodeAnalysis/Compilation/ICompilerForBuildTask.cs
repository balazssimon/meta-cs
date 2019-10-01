using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public interface ICompilerForBuildTask
    {
        void Compile();
        void Generate(bool forceOverwrite = false);
        bool HasErrors { get; }
        ImmutableArray<Diagnostic> GetDiagnostics();
        ImmutableArray<string> GetGeneratedFileList();
    }

}
