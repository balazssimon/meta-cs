using MetaDslx.VisualStudio.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Meta
{
    public sealed class MetaDefinition
    {
        public const string ContentType = "MetaModel";
        public const string FileExtension = ".mm";

        public const string GeneratorServiceGuid = "501C9EB8-3381-4D01-9D5C-A04D94734B58";
        public const string GeneratorServiceName = "C# Code Generator for MetaDslx Metamodel";
        public const string FilterList = "MetaDslx Metamodel Files (*.mm)\n*.mm";

        /// <summary>
        /// Exports the Meta content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(MetaDefinition.ContentType)]
        [BaseDefinition(MetaDslxDefinition.ContentType)]
        public ContentTypeDefinition MetaContentType { get; set; }

        /// <summary>
        /// Exports the Meta file extension
        /// </summary>
		[Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(MetaDefinition.ContentType)]
        [FileExtension(MetaDefinition.FileExtension)]
        public FileExtensionToContentTypeDefinition MetaFileExtension { get; set; }

    }
}
