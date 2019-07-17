using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Soal.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal
{
    public class SoalGenerator
    {
        public static Namespace XsdNamespace { get; private set; }

        static SoalGenerator()
        {
            MutableModel xsdModel = new MutableModel("xmlschema");
            SoalFactory f = new SoalFactory(xsdModel);
            var xsNs = f.Namespace();
            xsNs.Prefix = "xs";
            xsNs.Uri = "http://www.w3.org/2001/XMLSchema";
            XsdNamespace = xsNs.ToImmutable();
        }
    }
}
