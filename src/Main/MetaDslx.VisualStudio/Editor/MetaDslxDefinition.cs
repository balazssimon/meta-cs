using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Editor
{
    public sealed class MetaDslxDefinition
    {
        public const string ContentType = "MetaDslx";

        /// <summary>
        /// Exports the Antlr4Roslyn content type
        /// </summary>
        [Export(typeof(ContentTypeDefinition))]
        [Name(ContentType)]
        [BaseDefinition("code")]
        public ContentTypeDefinition MetaDslxContentType { get; set; }
    }
}
