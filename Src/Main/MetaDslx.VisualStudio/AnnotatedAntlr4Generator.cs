using Antlr4.Runtime;
using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    internal enum AnnotatedAntlr4GeneratorItemKind
    {
        External,
        Antlr4,
        Antlr4GrammarInfo,
    }

    internal class AnnotatedAntlr4GeneratorItem
    {
        public AnnotatedAntlr4GeneratorItemKind Kind { get; set; }
        public string FileName { get; set; }
    }
    
    internal class AnnotatedAntlr4Generator : MultipleFileGenerator<object>
    {
        private AnnotatedAntlr4Compiler compiler;

        public AnnotatedAntlr4Generator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new AnnotatedAntlr4Compiler(this.InputFileContents, this.InputDirectory, this.InputFileName);
                compiler.DefaultNamespace = defaultNamespace;
                compiler.Compile();
            }
        }

        public static string DefaultExtension
        {
            get { return ".g4"; }
        }

        public override IEnumerable<MultipleFileItem<object>> GetFileItems()
        {
            List<MultipleFileItem<object>> result = new List<MultipleFileItem<object>>();
            if (compiler == null) return result;
            if (compiler.HasAnnotatedAntlr4Errors) return result;
            string bareFileName = Path.GetFileNameWithoutExtension(this.InputFileName);
            MultipleFileItem<object> antlr4Grammar =
                new MultipleFileItem<object>()
                {
                    Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.Antlr4, FileName = bareFileName + ".g4" },
                };
            antlr4Grammar.Properties.Add("Visitor", "True");
            antlr4Grammar.Properties.Add("Listener", "True");
            antlr4Grammar.Properties.Add("TargetLanguage", "CSharp");
            result.Add(antlr4Grammar);
            if (compiler.HasAntlr4Errors) return result;
            MultipleFileItem<object> antlr4GrammarInfo =
                new MultipleFileItem<object>()
                {
                    Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.Antlr4GrammarInfo, FileName = bareFileName + "Annotator.cs" }
                };
            result.Add(antlr4GrammarInfo);
            result.Add(
                new MultipleFileItem<object>()
                {
                    Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + ".cs" },
                    GeneratedExternally = true
                });
            if (compiler.IsParser)
            {
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + ".tokens" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + "Listener.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + "Visitor.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + "BaseListener.cs" },
                        GeneratedExternally = true
                    });
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + "BaseVisitor.cs" },
                        GeneratedExternally = true
                    });
            }
            else if (compiler.IsLexer)
            {
                result.Add(
                    new MultipleFileItem<object>()
                    {
                        Info = new AnnotatedAntlr4GeneratorItem() { Kind = AnnotatedAntlr4GeneratorItemKind.External, FileName = bareFileName + ".tokens" },
                        GeneratedExternally = true
                    });
            }
            return result;
        }

        public override string GetFileName(MultipleFileItem<object> element)
        {
            AnnotatedAntlr4GeneratorItem item = element.Info as AnnotatedAntlr4GeneratorItem;
            if (item != null)
            {
                return item.FileName;
            }
            return null;
        }

        public override string GenerateStringContent(MultipleFileItem<object> element)
        {
            AnnotatedAntlr4GeneratorItem item = element.Info as AnnotatedAntlr4GeneratorItem;
            if (item != null)
            {
                if (item.Kind == AnnotatedAntlr4GeneratorItemKind.Antlr4)
                {
                    if (compiler == null) return string.Empty;
                    else return this.compiler.Antlr4Source;
                }
                if (item.Kind == AnnotatedAntlr4GeneratorItemKind.Antlr4GrammarInfo)
                {
                    if (compiler == null) return string.Empty;
                    else return this.compiler.GeneratedSource;
                }
            }
            return base.GenerateStringContent(element);
        }
    }
}
