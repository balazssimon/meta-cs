using Microsoft.VisualStudio.Core.Imaging;
using Microsoft.VisualStudio.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Intellisense
{
    public static class StandardIcons
    {
        public static readonly ImageId ClassIcon = KnownMonikers.Class.ToImageId();
        public static readonly ImageId NamespaceIcon = KnownMonikers.Namespace.ToImageId();
        public static readonly ImageId PropertyIcon = KnownMonikers.Property.ToImageId();
    }
}
