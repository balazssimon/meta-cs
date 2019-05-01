using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public static class TypeSymbolExtensions
    {
        internal static void AddUseSiteDiagnostics(
            this TypeSymbol type,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            DiagnosticInfo errorInfo = type.GetUseSiteDiagnostic();

            if ((object)errorInfo != null)
            {
                if (useSiteDiagnostics == null)
                {
                    useSiteDiagnostics = new HashSet<DiagnosticInfo>();
                }

                useSiteDiagnostics.Add(errorInfo);
            }
        }
    }
}
