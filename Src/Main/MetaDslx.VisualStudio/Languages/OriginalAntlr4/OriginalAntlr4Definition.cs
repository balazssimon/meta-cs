using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.OriginalAntlr4
{
    public sealed class OriginalAntlr4Definition
    {
        public const string ContentType = "OriginalAntlr4";
        public const string FileExtension = ".g4";

        /// <summary>
        /// Exports the OriginalAntlr4 content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(OriginalAntlr4Definition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition OriginalAntlr4ContentType { get; set; }

        /// <summary>
        /// Exports the OriginalAntlr4 file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(OriginalAntlr4Definition.ContentType)]
        [FileExtension(OriginalAntlr4Definition.FileExtension)]
        public FileExtensionToContentTypeDefinition OriginalAntlr4FileExtension { get; set; }

    }
}
