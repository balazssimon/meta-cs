using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.OriginalAntlr4
{
    public sealed class OriginalAntlr4ContentTypeDefinition
    {
        public const string ContentType = "OriginalAntlr4";

        /// <summary>
        /// Exports the OriginalAntlr4 content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(OriginalAntlr4ContentTypeDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition OriginalAntlr4ContentType { get; set; }

        /// <summary>
        /// Exports the OriginalAntlr4 file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(OriginalAntlr4ContentTypeDefinition.ContentType)]
        [FileExtension(".g4")]
        public FileExtensionToContentTypeDefinition OriginalAntlr4FileExtension { get; set; }

    }
}
