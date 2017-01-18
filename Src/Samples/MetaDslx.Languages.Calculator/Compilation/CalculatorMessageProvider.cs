using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Calculator
{
    public sealed class CalculatorMessageProvider : MessageProvider
    {
        public static readonly CalculatorMessageProvider Instance = new CalculatorMessageProvider();

        private CalculatorMessageProvider()
        {
        }

        public override string CodePrefix
        {
            get
            {
                return "CALC";
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
