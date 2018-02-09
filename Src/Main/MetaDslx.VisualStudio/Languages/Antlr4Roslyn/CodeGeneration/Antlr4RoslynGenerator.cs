using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Antlr4Roslyn.CodeGeneration
{
    public enum Antlr4RoslynGeneratorItemKind
    {
        External,
        Antlr4,
    }

    public class Antlr4RoslynGeneratorItem : MultipleFileItem
    {
        public Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind kind, string filePath, bool isDefault) 
            : base(filePath, isDefault)
        {
            this.Kind = kind;
        }

        public Antlr4RoslynGeneratorItemKind Kind { get; }
    }

    [ComVisible(true)]
    [Guid(Antlr4RoslynDefinition.GeneratorServiceGuid)]
    [CodeGeneratorRegistration(typeof(Antlr4RoslynGenerator), Antlr4RoslynDefinition.GeneratorServiceName, "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    [CodeGeneratorRegistration(typeof(Antlr4RoslynGenerator), Antlr4RoslynDefinition.GeneratorServiceName, "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}", GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(Antlr4RoslynGenerator))]
    public class Antlr4RoslynGenerator : MultipleFileGenerator<Antlr4RoslynGeneratorItem>
    {
        public const string DefaultExtension = ".g4";
        private Antlr4RoslynCompiler compiler;

        public Antlr4RoslynGenerator()
            : base()
        {
        }

        protected override IEnumerable<Antlr4RoslynGeneratorItem> Compile()
        {
            List<Antlr4RoslynGeneratorItem> result = new List<Antlr4RoslynGeneratorItem>();

            compiler = new Antlr4RoslynCompiler(this.InputFileContents, this.DefaultNamespace, this.InputFileDirectory, this.InputFileDirectory, this.InputFileName);
            compiler.GenerateOutput = true;
            compiler.Compile();
            compiler.Generate();
            if (compiler.HasErrors) return result;

            string barePath = this.FilePathWithoutExtension;
            Antlr4RoslynGeneratorItem antlr4Grammar = new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.Antlr4, barePath + ".g4", true);
            antlr4Grammar.Properties.Add("Visitor", "True");
            antlr4Grammar.Properties.Add("Listener", "True");
            antlr4Grammar.Properties.Add("TargetLanguage", "CSharp");
            result.Add(antlr4Grammar);
            if (compiler.HasAntlr4Errors) return result;

            result.Add(
                new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + ".cs", false)
                {
                    GeneratedExternally = true
                });
            if (compiler.IsParser)
            {
                result.Add(
                    new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + ".tokens", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + "Listener.cs", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + "Visitor.cs", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + "BaseListener.cs", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + "BaseVisitor.cs", false)
                    {
                        GeneratedExternally = true
                    });
            }
            else if (compiler.IsLexer)
            {
                result.Add(
                    new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, barePath + ".tokens", false)
                    {
                        GeneratedExternally = true
                    });
            }
            if (compiler.GeneratedRoslynFiles != null)
            {
                foreach (var roslynFilePath in compiler.GeneratedRoslynFiles)
                {
                    result.Add(
                        new Antlr4RoslynGeneratorItem(Antlr4RoslynGeneratorItemKind.External, roslynFilePath, false)
                        {
                            DependUponInputFile = false,
                            GeneratedExternally = true
                        });
                }
            }
            return result;
        }

        public override string GenerateStringContent(Antlr4RoslynGeneratorItem item)
        {
            return compiler.Antlr4Source;
        }

        protected override string GetDefaultExtension()
        {
            return DefaultExtension;
        }
    }
}
