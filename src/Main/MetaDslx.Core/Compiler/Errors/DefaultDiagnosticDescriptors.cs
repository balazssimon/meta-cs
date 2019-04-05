using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Errors
{
    internal class DefaultDiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor ERR_BadSourceCodeKind = new DiagnosticDescriptor("MC0002", "Bad source code kind", "Invalid source code kind: {0}", Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);
        public static readonly DiagnosticDescriptor ERR_BadDocumentationMode = new DiagnosticDescriptor("MC0003", "Bad documentation mode", "Invalid documentation mode: {0}", Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);

    }
}
