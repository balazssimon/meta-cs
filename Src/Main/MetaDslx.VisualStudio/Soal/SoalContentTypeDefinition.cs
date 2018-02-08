using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Soal
{
    public sealed class SoalContentTypeDefinition
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
        [ContentType(SoalContentTypeDefinition.ContentType)]
        [FileExtension(".soal")]
        public FileExtensionToContentTypeDefinition SoalFileExtension { get; set; }

    }
}
