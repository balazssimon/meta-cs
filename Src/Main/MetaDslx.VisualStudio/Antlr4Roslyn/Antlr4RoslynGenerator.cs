using Antlr4.Runtime;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    /*
    internal class Antlr4RoslynGenerator : SingleFileGenerator
    {
        public const string DefaultExtension = ".g4";
        private Antlr4RoslynCompiler compiler;

        public Antlr4RoslynGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new Antlr4RoslynCompiler(this.InputFileContents, defaultNamespace, this.InputDirectory, this.InputDirectory, this.InputFileName);
                compiler.GenerateAntlr4 = false;
                compiler.Compile();
            }
        }

        public override string GenerateStringContent()
        {
            if (compiler == null)
            {
                return string.Empty;
            }
            else
            {
                compiler.Generate();
                return compiler.Antlr4Source;
            }
        }
    }
    */
    
    internal enum Antlr4RoslynGeneratorItemKind
    {
        External,
        Antlr4,
        Antlr4CSharp
    }

    internal class Antlr4RoslynGeneratorItem
    {
        public Antlr4RoslynGeneratorItemKind Kind { get; set; }
        public string FileName { get; set; }
    }
    
    internal class Antlr4RoslynGenerator : MultipleFileGenerator<object>
    {
        private Antlr4RoslynCompiler compiler;

        public Antlr4RoslynGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new Antlr4RoslynCompiler(this.InputFileContents, defaultNamespace, this.InputDirectory, this.InputDirectory, this.InputFileName);
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
            if (compiler.HasErrors) return result;
            if (compiler.GenerateCompiler)
            {
                compiler.Generate();
            }
            string bareFileName = Path.GetFileNameWithoutExtension(this.InputFileName);
            result.Add(
                new MultipleFileItem<object>()
                {
                    Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.Antlr4, FileName = bareFileName + ".og4" },
                });
            result.Add(
                new MultipleFileItem<object>()
                {
                    Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.Antlr4CSharp, FileName = bareFileName + ".cs" },
                });
            if (compiler.HasAntlr4Errors) return result;
            if (compiler.IsParser)
            {
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.External, FileName = bareFileName + ".tokens" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.External, FileName = bareFileName + "Listener.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.External, FileName = bareFileName + "Visitor.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.External, FileName = bareFileName + "BaseListener.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.External, FileName = bareFileName + "BaseVisitor.cs" },
                        GeneratedExternally = true
                    });
            }
            else if (compiler.IsLexer)
            {
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new Antlr4RoslynGeneratorItem() { Kind = Antlr4RoslynGeneratorItemKind.External, FileName = bareFileName + ".tokens" },
                        GeneratedExternally = true
                    });
            }
            return result;
        }

        public override string GetFileName(MultipleFileItem<object> element)
        {
            Antlr4RoslynGeneratorItem item = element.Info as Antlr4RoslynGeneratorItem;
            if (item != null)
            {
                return item.FileName;
            }
            return null;
        }

        public override string GenerateStringContent(MultipleFileItem<object> element)
        {
            Antlr4RoslynGeneratorItem item = element.Info as Antlr4RoslynGeneratorItem;
            if (item != null)
            {
                if (item.Kind == Antlr4RoslynGeneratorItemKind.Antlr4)
                {
                    if (compiler == null) return string.Empty;
                    else return this.compiler.Antlr4Source;
                }
                else if (item.Kind == Antlr4RoslynGeneratorItemKind.Antlr4CSharp)
                {
                    if (compiler == null) return string.Empty;
                    else return this.compiler.Antlr4CSharpSource;
                }
            }
            return base.GenerateStringContent(element);
        }
    }
}
