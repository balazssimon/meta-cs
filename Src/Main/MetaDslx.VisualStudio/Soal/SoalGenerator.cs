using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Soal
{
    public class SoalGenerator : SingleFileGenerator
    {
        public SoalGenerator(string inputFilePath, string inputFileContents, string defaultNamespace) 
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
        }

        public const string DefaultExtension = ".cs";
    }
}
