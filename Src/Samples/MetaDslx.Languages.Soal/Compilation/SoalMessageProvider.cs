using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal
{
    public sealed class SoalMessageProvider : MessageProvider
    {
        public static readonly SoalMessageProvider Instance = new SoalMessageProvider();

        private SoalMessageProvider()
        {
        }

        public override string CodePrefix
        {
            get
            {
                return "SOAL";
            }
        }

        public override string GetMessageFormat(int code)
        {
            return "{0}";
        }

        public override DiagnosticSeverity GetSeverity(int code)
        {
            return DiagnosticSeverity.Error;
        }

        public override int GetWarningLevel(int code)
        {
            return 0;
        }
    }

}
