using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Errors
{
    internal class DefaultDiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor ERR_BadSourceCodeKind = new DiagnosticDescriptor("MC0002", "Bad source code kind", LanguageCompilerResources.ERR_BadSourceCodeKind, Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);
        public static readonly DiagnosticDescriptor ERR_BadDocumentationMode = new DiagnosticDescriptor("MC0003", "Bad documentation mode", LanguageCompilerResources.ERR_BadDocumentationMode, Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);
        public static readonly DiagnosticDescriptor ERR_NonInvocableMemberCalled = new DiagnosticDescriptor("MC0004", "Non-invocable member called", LanguageCompilerResources.ERR_NonInvocableMemberCalled, Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);
        public static readonly DiagnosticDescriptor ERR_BadSKknown = new DiagnosticDescriptor("MC0005", "Bad symbol kind", LanguageCompilerResources.ERR_BadSKknown, Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);

    }
}
