using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Calculator
{
    internal class WhitespaceAnnotation
    {
        public bool Eol { get; set; }
    }

    internal class KeywordsAnnotation
    {
        public int First { get; set; }
        public int Last { get; set; }
    }

    internal class CommentAnnotation
    {

    }
}
