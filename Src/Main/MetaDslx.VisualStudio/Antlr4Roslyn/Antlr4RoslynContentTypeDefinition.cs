using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Antlr4Roslyn
{
    public sealed class Antlr4RoslynContentTypeDefinition
    {
        public const string ContentType = "Antlr4Roslyn";

        /// <summary>
        /// Exports the Antlr4Roslyn content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(Antlr4RoslynContentTypeDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition Antlr4RoslynContentType { get; set; }

        /// <summary>
        /// Exports the Antlr4Roslyn file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(Antlr4RoslynContentTypeDefinition.ContentType)]
        [FileExtension(".ag4")]
        public FileExtensionToContentTypeDefinition Antlr4RoslynFileExtension { get; set; }

    }
}
