using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.MetaGenerator.Compilation;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;
using MetaDslx.VisualStudio.Classification.Antlr4Tagging;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Classification
{
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(IErrorTag))]
    [TagType(typeof(IClassificationTag))]
    [ContentType(MetaGeneratorDefinition.ContentType)]
    public class MetaGeneratorTaggerProvider : CompilationTaggerProvider<MetaGeneratorLexer, MetaGeneratorParser>
    {
        [ImportingConstructor]
        internal MetaGeneratorTaggerProvider([Import] ITableManagerProvider provider, [Import] ITextDocumentFactoryService textDocumentFactoryService, [Import] IClassificationTypeRegistryService classificationRegistryService)
            : base(provider, textDocumentFactoryService, classificationRegistryService)
        {
        }

        public override string DisplayName => "MetaModel";

        protected override Antlr4Compiler<MetaGeneratorLexer, MetaGeneratorParser> CreateCompilation(string filePath, string sourceText, CancellationToken cancellationToken)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            var compilation = new MetaGeneratorCompiler(sourceText, string.Empty, directory, directory, fileName);
            compilation.GenerateOutput = false;
            return compilation;
        }

    }
}
