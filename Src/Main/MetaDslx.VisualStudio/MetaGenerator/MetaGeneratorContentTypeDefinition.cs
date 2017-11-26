using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.MetaGenerator
{
    public sealed class MetaGeneratorContentTypeDefinition
    {
        public const string ContentType = "MetaGenerator";

        /// <summary>
        /// Exports the MetaGenerator content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(MetaGeneratorContentTypeDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition MetaGeneratorContentType { get; set; }

        /// <summary>
        /// Exports the MetaGenerator file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(MetaGeneratorContentTypeDefinition.ContentType)]
        [FileExtension(".mgen")]
        public FileExtensionToContentTypeDefinition MetaGeneratorFileExtension { get; set; }

    }
}
