using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Meta
{
    public sealed class MetaContentTypeDefinition
    {
        public const string ContentType = "MetaModel";

        /// <summary>
        /// Exports the Meta content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(MetaContentTypeDefinition.ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition MetaContentType { get; set; }

        /// <summary>
        /// Exports the Meta file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(MetaContentTypeDefinition.ContentType)]
        [FileExtension(".mm")]
        public FileExtensionToContentTypeDefinition MetaFileExtension { get; set; }

    }
}
