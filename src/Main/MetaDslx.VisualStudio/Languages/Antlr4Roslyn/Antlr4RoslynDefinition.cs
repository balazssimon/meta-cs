using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Antlr4Roslyn
{
    public sealed class Antlr4RoslynDefinition
    {
        public const string ContentType = "Antlr4Roslyn";
        public const string FileExtension = ".ag4";

        public const string GeneratorServiceGuid = "97B8CE90-1F57-4B09-A798-D26B6EC4C540";
        public const string GeneratorServiceName = "Roslyn Code Generator for Annotated ANTLR4";
        public const string FilterList = "Annotated ANTLR4 Files (*.ag4)\n*.ag4";

        /// <summary>
        /// Exports the Antlr4Roslyn content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(Antlr4RoslynDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition Antlr4RoslynContentType { get; set; }

        /// <summary>
        /// Exports the Antlr4Roslyn file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(Antlr4RoslynDefinition.ContentType)]
        [FileExtension(Antlr4RoslynDefinition.FileExtension)]
        public FileExtensionToContentTypeDefinition Antlr4RoslynFileExtension { get; set; }

    }
}
