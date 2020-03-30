using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

namespace MetaDslx.VisualStudio.Classification
{
    public abstract class Antlr4CompilationTaggerProvider : CompilationTaggerProvider
    {
        public Antlr4CompilationTaggerProvider(ITableManagerProvider provider, ITextDocumentFactoryService textDocumentFactoryService, IClassificationTypeRegistryService classificationRegistryService) 
            : base(provider, textDocumentFactoryService, classificationRegistryService)
        {
        }

    }
}
