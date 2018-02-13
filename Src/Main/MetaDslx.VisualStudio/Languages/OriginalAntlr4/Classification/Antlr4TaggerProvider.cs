using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.MetaGenerator.Compilation;
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

namespace MetaDslx.VisualStudio.Languages.OriginalAntlr4.Classification
{
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(IErrorTag))]
    [TagType(typeof(IClassificationTag))]
    [ContentType(OriginalAntlr4Definition.ContentType)]
    public class Antlr4TaggerProvider : CompilationTaggerProvider<Antlr4RoslynLexer, Antlr4RoslynParser>
    {
        [ImportingConstructor]
        internal Antlr4TaggerProvider([Import] ITableManagerProvider provider, [Import] ITextDocumentFactoryService textDocumentFactoryService, [Import] IClassificationTypeRegistryService classificationRegistryService)
            : base(provider, textDocumentFactoryService, classificationRegistryService)
        {
        }

        public override string DisplayName => "MetaModel";

        protected override Antlr4Compiler<Antlr4RoslynLexer, Antlr4RoslynParser> CreateCompilation(string filePath, string sourceText, CancellationToken cancellationToken)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            var compilation = new OriginalAntlr4Compiler(sourceText, string.Empty, directory, directory, fileName);
            compilation.GenerateOutput = false;
            return compilation;
        }

    }
}
