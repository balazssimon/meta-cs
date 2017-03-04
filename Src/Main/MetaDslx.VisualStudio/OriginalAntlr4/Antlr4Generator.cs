using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    internal enum Antlr4GeneratorItemKind
    {
        External,
        Antlr4,
    }

    internal class Antlr4GeneratorItem
    {
        public Antlr4GeneratorItemKind Kind { get; set; }
        public string FileName { get; set; }
    }

    internal class Antlr4Generator : MultipleFileGenerator<object>
    {
        private OriginalAntlr4Compiler compiler;

        public Antlr4Generator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new OriginalAntlr4Compiler(this.InputFileContents, defaultNamespace, this.InputDirectory, this.InputDirectory, this.InputFileName);
                compiler.Generate();
            }
        }

        public static string DefaultExtension
        {
            get { return ".cs"; }
        }

        public override IEnumerable<MultipleFileItem<object>> GetFileItems()
        {
            List<MultipleFileItem<object>> result = new List<MultipleFileItem<object>>();
            if (compiler == null) return result;
            string bareFileName = Path.GetFileNameWithoutExtension(this.InputFileName);
            result.Add(
                new MultipleFileItem<object>()
                {
                    Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.Antlr4, FileName = bareFileName + ".cs" },
                });
            if (compiler.HasErrors) return result;
            if (compiler.IsParser)
            {
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.External, FileName = bareFileName + ".tokens" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.External, FileName = bareFileName + "Listener.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.External, FileName = bareFileName + "Visitor.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.External, FileName = bareFileName + "BaseListener.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.External, FileName = bareFileName + "BaseVisitor.cs" },
                        GeneratedExternally = true
                    });
            }
            else if (compiler.IsLexer)
            {
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4GeneratorItem() { Kind = Antlr4GeneratorItemKind.External, FileName = bareFileName + ".tokens" },
                        GeneratedExternally = true
                    });
            }
            return result;
        }

        public override string GetFileName(MultipleFileItem<object> element)
        {
            Antlr4GeneratorItem item = element.Info as Antlr4GeneratorItem;
            if (item != null)
            {
                return item.FileName;
            }
            return null;
        }

        public override string GenerateStringContent(MultipleFileItem<object> element)
        {
            Antlr4GeneratorItem item = element.Info as Antlr4GeneratorItem;
            if (item != null)
            {
                if (item.Kind == Antlr4GeneratorItemKind.Antlr4)
                {
                    if (compiler == null) return string.Empty;
                    else return this.compiler.CSharpSource;
                }
            }
            return base.GenerateStringContent(element);
        }
    }

}
