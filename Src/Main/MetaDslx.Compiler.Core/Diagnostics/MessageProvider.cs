using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// Abstracts the ability to classify and load messages for error codes. Allows the error
    /// infrastructure to be reused between C# and VB.
    /// </summary>
    public abstract class MessageProvider
    {
        internal static readonly MessageProvider Default = new DefaultMessageProvider();

        /// <summary>
        /// Given an error code, get the severity (warning or error) of the code.
        /// </summary>
        public abstract DiagnosticSeverity GetSeverity(int code);

        /// <summary>
        /// Get an optional localizable title for the given diagnostic code.
        /// </summary>
        public virtual string GetTitle(int code)
        {
            return null;
        }

        /// <summary>
        /// Get an optional localizable description for the given diagnostic code.
        /// </summary>
        public virtual string GetDescription(int code)
        {
            return null;
        }

        /// <summary>
        /// Get a localizable message format string for the given diagnostic code.
        /// </summary>
        public abstract string GetMessageFormat(int code);

        /// <summary>
        /// Get an optional help link for the given diagnostic code.
        /// </summary>
        public virtual string GetHelpLink(int code)
        {
            return null;
        }

        /// <summary>
        /// Get the diagnostic category for the given diagnostic code.
        /// Default category is <see cref="Diagnostic.CompilerDiagnosticCategory"/>.
        /// </summary>
        public virtual string GetCategory(int code)
        {
            return Diagnostic.CompilerDiagnosticCategory;
        }

        /// <summary>
        /// Get the text prefix (e.g., "CS" for C#) used on error messages.
        /// </summary>
        public abstract string CodePrefix { get; }

        /// <summary>
        /// Get the warning level for warnings (e.g., 1 through 4 for C#). VB does not have warning
        /// levels and always uses 1. Errors should return 0.
        /// </summary>
        public abstract int GetWarningLevel(int code);

        /// <summary>
        /// Create a simple language specific diagnostic for given error code.
        /// </summary>
        public Diagnostic CreateDiagnostic(int code, Location location)
        {
            return CreateDiagnostic(code, location, EmptyCollections.ObjectArray);
        }

        /// <summary>
        /// Create a simple language specific diagnostic for given error code.
        /// </summary>
        public Diagnostic CreateDiagnostic(int code, Location location, params object[] args)
        {
            return Diagnostic.Create(this.CreateDiagnosticInfo(code, args), location);
        }

        /// <summary>
        /// Create a simple language specific diagnostic info for given error code.
        /// </summary>
        public virtual DiagnosticInfo CreateDiagnosticInfo(int code, params object[] args)
        {
            return new DefaultDiagnosticInfo(this, code, args);
        }

        // Given a message identifier (e.g., CS0219), location, severity, warning as error, 
        // get the entire prefix (e.g., "error CS0219:" for C#) used on error messages.
        public virtual string GetMessagePrefix(string id, Location location, DiagnosticSeverity severity, bool isWarningAsError)
        {
            return String.Format("{0} {1} at {2}",
                severity == DiagnosticSeverity.Error || isWarningAsError ? "error" : "warning",
                id,
                location);
        }


        /// <summary>
        /// convert given symbol to string representation based on given error code
        /// </summary>
        public virtual string ConvertSymbolToString(int errorCode, IMetaSymbol symbol)
        {
            return symbol.MName;
        }

        /// <summary>
        /// Given an error code (like 1234) return the identifier (CS1234 or BC1234).
        /// </summary>
        public virtual string GetIdForErrorCode(int errorCode)
        {
            return CodePrefix + errorCode.ToString("0000");
        }

        /// <summary>
        /// Produces the filtering action for the diagnostic based on the options passed in.
        /// </summary>
        /// <returns>
        /// A new <see cref="DiagnosticInfo"/> with new effective severity based on the options or null if the
        /// diagnostic has been suppressed.
        /// </returns>
        public virtual ReportDiagnostic GetDiagnosticReport(DiagnosticInfo diagnosticInfo, CompilationOptions options)
        {
            return ReportDiagnostic.Default;
        }

        /// <summary>
        /// Filter a <see cref="DiagnosticInfo"/> based on the compilation options so that /nowarn and /warnaserror etc. take effect.options
        /// </summary>
        /// <returns>A <see cref="DiagnosticInfo"/> with effective severity based on option or null if suppressed.</returns>
        public DiagnosticInfo FilterDiagnosticInfo(DiagnosticInfo diagnosticInfo, CompilationOptions options)
        {
            var report = this.GetDiagnosticReport(diagnosticInfo, options);
            switch (report)
            {
                case ReportDiagnostic.Error:
                    return diagnosticInfo.WithSeverity(DiagnosticSeverity.Error);
                case ReportDiagnostic.Warn:
                    return diagnosticInfo.WithSeverity(DiagnosticSeverity.Warning);
                case ReportDiagnostic.Info:
                    return diagnosticInfo.WithSeverity(DiagnosticSeverity.Info);
                case ReportDiagnostic.Hidden:
                    return diagnosticInfo.WithSeverity(DiagnosticSeverity.Hidden);
                case ReportDiagnostic.Suppress:
                    return null;
                default:
                    return diagnosticInfo;
            }
        }

    }

    internal sealed class DefaultMessageProvider : MessageProvider
    {
        public override string CodePrefix
        {
            get
            {
                return string.Empty;
            }
        }

        public override string GetMessageFormat(int code)
        {
            return string.Empty;
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
