using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.OriginalAntlr4.CodeGeneration
{
    public enum Antlr4GeneratorItemKind
    {
        External,
        CSharp,
    }

    public class Antlr4GeneratorItem : MultipleFileItem
    {
        public Antlr4GeneratorItem(Antlr4GeneratorItemKind kind, string filePath, bool isDefault)
            : base(filePath, isDefault)
        {
            this.Kind = kind;
        }

        public Antlr4GeneratorItemKind Kind { get; }
    }

    [ComVisible(true)]
    [Guid(OriginalAntlr4Definition.GeneratorServiceGuid)]
    [CodeGeneratorRegistration(typeof(Antlr4Generator), OriginalAntlr4Definition.GeneratorServiceName, "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    [CodeGeneratorRegistration(typeof(Antlr4Generator), OriginalAntlr4Definition.GeneratorServiceName, "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}", GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(Antlr4Generator))]
    public class Antlr4Generator : MultipleFileGenerator<Antlr4GeneratorItem>
    {
        public const string DefaultExtension = ".g4";
        private OriginalAntlr4Compiler compiler;

        public Antlr4Generator()
            : base()
        {
        }

        protected override IEnumerable<Antlr4GeneratorItem> Compile()
        {
            List<Antlr4GeneratorItem> result = new List<Antlr4GeneratorItem>();

            compiler = new OriginalAntlr4Compiler(this.InputFileContents, this.DefaultNamespace, this.InputFileDirectory, this.InputFileDirectory, this.InputFileName);
            compiler.GenerateOutput = true;
            compiler.Compile();
            compiler.Generate();
            if (compiler.HasErrors) return result;

            string barePath = this.FilePathWithoutExtension;
            Antlr4GeneratorItem antlr4Grammar = new Antlr4GeneratorItem(Antlr4GeneratorItemKind.CSharp, barePath + ".cs", true);
            result.Add(antlr4Grammar);

            if (compiler.IsParser)
            {
                result.Add(
                    new Antlr4GeneratorItem(Antlr4GeneratorItemKind.External, barePath + ".tokens", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4GeneratorItem(Antlr4GeneratorItemKind.External, barePath + "Listener.cs", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4GeneratorItem(Antlr4GeneratorItemKind.External, barePath + "Visitor.cs", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4GeneratorItem(Antlr4GeneratorItemKind.External, barePath + "BaseListener.cs", false)
                    {
                        GeneratedExternally = true
                    });
                result.Add(
                    new Antlr4GeneratorItem(Antlr4GeneratorItemKind.External, barePath + "BaseVisitor.cs", false)
                    {
                        GeneratedExternally = true
                    });
            }
            else if (compiler.IsLexer)
            {
                result.Add(
                    new Antlr4GeneratorItem(Antlr4GeneratorItemKind.External, barePath + ".tokens", false)
                    {
                        GeneratedExternally = true
                    });
            }
            return result;
        }

        public override string GenerateStringContent(Antlr4GeneratorItem item)
        {
            return compiler.CSharpSource;
        }

        protected override string GetDefaultExtension()
        {
            return DefaultExtension;
        }
    }

}
