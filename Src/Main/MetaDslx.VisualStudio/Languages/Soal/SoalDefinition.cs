using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Soal
{
    public sealed class SoalDefinition
    {
        public const string ContentType = "Soal";

        /// <summary>
        /// Exports the Soal content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition SoalContentType { get; set; }

        /// <summary>
        /// Exports the Soal file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(SoalDefinition.ContentType)]
        [FileExtension(".soal")]
        public FileExtensionToContentTypeDefinition SoalFileExtension { get; set; }

    }
}
