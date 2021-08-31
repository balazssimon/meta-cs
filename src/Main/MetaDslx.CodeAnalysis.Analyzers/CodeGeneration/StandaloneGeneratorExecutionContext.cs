extern alias msca;
using msca::Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.CodeGeneration
{
    public abstract class StandaloneGeneratorExecutionContext
    {
        private readonly List<(string HintName, string Source)> _generatedSources;

        private StandaloneGeneratorExecutionContext()
        {
            _generatedSources = new List<(string HintName, string Source)>();
        }

        public static StandaloneGeneratorExecutionContext FromCSharp(GeneratorExecutionContext context)
        {
            return new CSharpGeneratorExecutionContext(context);
        }

        public static StandaloneGeneratorExecutionContext FromParams(Compilation compilation)
        {
            return new CustomGeneratorExecutionContext(compilation);
        }

        public abstract Compilation Compilation { get; }
        public List<(string HintName, string Source)> GeneratedSources => _generatedSources;

        public virtual void AddSource(string hintName, string source)
        {
            _generatedSources.Add((hintName, source));
        }

        private class CSharpGeneratorExecutionContext : StandaloneGeneratorExecutionContext
        {
            private readonly GeneratorExecutionContext _context;

            public CSharpGeneratorExecutionContext(GeneratorExecutionContext context)
            {
                _context = context;
            }

            public override Compilation Compilation => _context.Compilation;

            public override void AddSource(string hintName, string source)
            {
                base.AddSource(hintName, source);
                _context.AddSource(hintName, source);
            }
        }

        private class CustomGeneratorExecutionContext : StandaloneGeneratorExecutionContext
        {
            private readonly Compilation _compilation;

            public CustomGeneratorExecutionContext(Compilation compilation)
            {
                _compilation = compilation;
            }

            public override Compilation Compilation => _compilation;
        }
    }
}
