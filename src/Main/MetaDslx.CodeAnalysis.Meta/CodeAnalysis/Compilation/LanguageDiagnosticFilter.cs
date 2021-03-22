// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Applies C#-specific modification and filtering of <see cref="Diagnostic"/>s.
    /// </summary>
    internal static class LanguageDiagnosticFilter
    {
        /// <summary>
        /// Modifies an input <see cref="Diagnostic"/> per the given options. For example, the
        /// severity may be escalated, or the <see cref="Diagnostic"/> may be filtered out entirely
        /// (by returning null).
        /// </summary>
        /// <param name="d">The input diagnostic</param>
        /// <param name="warningLevelOption">The maximum warning level to allow. Diagnostics with a higher warning level will be filtered out.</param>
        /// <param name="generalDiagnosticOption">How warning diagnostics should be reported</param>
        /// <param name="nullableOption">Whether Nullable Reference Types feature is enabled globally</param>
        /// <param name="specificDiagnosticOptions">How specific diagnostics should be reported</param>
        /// <returns>A diagnostic updated to reflect the options, or null if it has been filtered out</returns>
        public static Diagnostic Filter(Diagnostic d, int warningLevelOption, ReportDiagnostic generalDiagnosticOption, IDictionary<string, ReportDiagnostic> specificDiagnosticOptions)
        {
            if (d == null)
            {
                return d;
            }
            else if (d.IsNotConfigurable())
            {
                if (d.IsEnabledByDefault)
                {
                    // Enabled NotConfigurable should always be reported as it is.
                    return d;
                }
                else
                {
                    // Disabled NotConfigurable should never be reported.
                    return null;
                }
            }
            else if (d.Severity == InternalDiagnosticSeverity.Void)
            {
                return null;
            }

            ReportDiagnostic reportAction;
            bool hasPragmaSuppression;
            reportAction = GetDiagnosticReport(d.Severity, d.IsEnabledByDefault, d.Id, d.WarningLevel, d.Location as Location,
                d.Category, warningLevelOption, generalDiagnosticOption, specificDiagnosticOptions, out hasPragmaSuppression);
            if (hasPragmaSuppression)
            {
                d = d.WithIsSuppressed(true);
            }
            return d.WithReportDiagnostic(reportAction);
        }

        // Take a warning and return the final deposition of the given warning,
        // based on both command line options and pragmas.
        internal static ReportDiagnostic GetDiagnosticReport(
            DiagnosticSeverity severity,
            bool isEnabledByDefault,
            string id,
            int diagnosticWarningLevel,
            Location location,
            string category,
            int warningLevelOption,
            ReportDiagnostic generalDiagnosticOption,
            IDictionary<string, ReportDiagnostic> specificDiagnosticOptions,
            out bool hasPragmaSuppression)
        {
            hasPragmaSuppression = false;

            // Read options (e.g., /nowarn or /warnaserror)
            ReportDiagnostic report = ReportDiagnostic.Default;
            var isSpecified = specificDiagnosticOptions.TryGetValue(id, out report);
            if (!isSpecified)
            {
                report = isEnabledByDefault ? ReportDiagnostic.Default : ReportDiagnostic.Suppress;
            }

            // Compute if the reporting should be suppressed.
            if (diagnosticWarningLevel > warningLevelOption)  // honor the warning level
            {
                return ReportDiagnostic.Suppress;
            }

            if (report == ReportDiagnostic.Suppress)
            {
                return ReportDiagnostic.Suppress;
            }

            var pragmaWarningState = Syntax.PragmaWarningState.Default;

            // If location is available, check out pragmas
            if (location != null &&
                location.SourceTree != null &&
                (pragmaWarningState = location.SourceTree.GetPragmaDirectiveWarningState(id, location.SourceSpan.Start)) == Syntax.PragmaWarningState.Disabled)
            {
                hasPragmaSuppression = true;
            }

            if (pragmaWarningState == Syntax.PragmaWarningState.Enabled)
            {
                switch (report)
                {
                    case ReportDiagnostic.Error:
                    case ReportDiagnostic.Hidden:
                    case ReportDiagnostic.Info:
                    case ReportDiagnostic.Warn:
                        // No need to adjust the current report state, it already means "enabled"
                        return report;

                    case ReportDiagnostic.Suppress:
                        // Enable the warning
                        return ReportDiagnostic.Default;

                    case ReportDiagnostic.Default:
                        if (generalDiagnosticOption == ReportDiagnostic.Error && promoteToAnError())
                        {
                            return ReportDiagnostic.Error;
                        }

                        return ReportDiagnostic.Default;

                    default:
                        throw ExceptionUtilities.UnexpectedValue(report);
                }
            }
            else if (report == ReportDiagnostic.Suppress) // check options (/nowarn)
            {
                return ReportDiagnostic.Suppress;
            }

            // Unless specific warning options are defined (/warnaserror[+|-]:<n> or /nowarn:<n>, 
            // follow the global option (/warnaserror[+|-] or /nowarn).
            if (report == ReportDiagnostic.Default)
            {
                switch (generalDiagnosticOption)
                {
                    case ReportDiagnostic.Error:
                        if (promoteToAnError())
                        {
                            return ReportDiagnostic.Error;
                        }
                        break;
                    case ReportDiagnostic.Suppress:
                        // When doing suppress-all-warnings, don't lower severity for anything other than warning and info.
                        // We shouldn't suppress hidden diagnostics here because then features that use hidden diagnostics to
                        // display a lightbulb would stop working if someone has suppress-all-warnings (/nowarn) specified in their project.
                        if (severity == DiagnosticSeverity.Warning || severity == DiagnosticSeverity.Info)
                        {
                            return ReportDiagnostic.Suppress;
                        }
                        break;
                    default:
                        break;
                }
            }

            return report;

            bool promoteToAnError()
            {
                Debug.Assert(report == ReportDiagnostic.Default);
                Debug.Assert(generalDiagnosticOption == ReportDiagnostic.Error);

                // If we've been asked to do warn-as-error then don't raise severity for anything below warning (info or hidden).
                return severity == DiagnosticSeverity.Warning &&
                       // In the case where /warnaserror+ is followed by /warnaserror-:<n> on the command line,
                       // do not promote the warning specified in <n> to an error.
                       !isSpecified;

            }
        }
    }
}
