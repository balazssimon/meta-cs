using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal abstract class MessageProvider : CommonMessageProvider
    {
        public static readonly MessageProvider Instance = null;
    }
}
