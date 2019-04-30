// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis
{
    internal static class DiagnosticBagExtensions
    {
        internal static ErrorCode GetErrorCode(this DiagnosticInfo info)
        {
            var languageInfo = info as LanguageDiagnosticInfo;
            return languageInfo?.ErrorCode;
        }

        internal static Diagnostic ToDiagnostic(this DiagnosticInfo info, Location location)
        {
            var languageInfo = info as LanguageDiagnosticInfo;
            if (languageInfo != null)
            {
                return new LanguageDiagnostic(languageInfo, location);
            }
            else
            {
                return new DiagnosticWithInfo(info, location);
            }
        }

        /// <summary>
        /// Add a diagnostic to the bag.
        /// </summary>
        /// <param name="diagnostics"></param>
        /// <param name="code"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        internal static LanguageDiagnosticInfo Add(this DiagnosticBag diagnostics, Location location, ErrorCode code)
        {
            var info = new LanguageDiagnosticInfo(code);
            var diag = new LanguageDiagnostic(info, location);
            diagnostics.Add(diag);
            return info;
        }

        /// <summary>
        /// Add a diagnostic to the bag.
        /// </summary>
        /// <param name="diagnostics"></param>
        /// <param name="code"></param>
        /// <param name="location"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static LanguageDiagnosticInfo Add(this DiagnosticBag diagnostics, Location location, ErrorCode code, params object[] args)
        {
            var info = new LanguageDiagnosticInfo(code, args);
            var diag = new LanguageDiagnostic(info, location);
            diagnostics.Add(diag);
            return info;
        }

        /// <summary>
        /// Add a diagnostic to the bag.
        /// </summary>
        /// <param name="diagnostics"></param>
        /// <param name="code"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static LanguageDiagnosticInfo Add(this DiagnosticBag diagnostics, ErrorCode code, Location location, params object[] args)
        {
            var info = new LanguageDiagnosticInfo(code, args);
            var diag = new LanguageDiagnostic(info, location);
            diagnostics.Add(diag);
            return info;
        }

        internal static LanguageDiagnosticInfo Add(this DiagnosticBag diagnostics, ErrorCode code, params object[] args)
        {
            var info = new LanguageDiagnosticInfo(code, args);
            var diag = new LanguageDiagnostic(info, Location.None);
            diagnostics.Add(diag);
            return info;
        }

        internal static LanguageDiagnosticInfo Add(this DiagnosticBag diagnostics, Location location, ImmutableArray<ISymbol> symbols, ErrorCode code, params object[] args)
        {
            var info = new SymbolDiagnosticInfo(code, args, symbols, ImmutableArray<Location>.Empty);
            var diag = new LanguageDiagnostic(info, location);
            diagnostics.Add(diag);
            return info;
        }

        internal static void Add(this DiagnosticBag diagnostics, DiagnosticInfo info, Location location)
        {
            diagnostics.Add(info.ToDiagnostic(location));
        }

        /// <summary>
        /// Adds diagnostics from useSiteDiagnostics into diagnostics and returns True if there were any errors.
        /// </summary>
        internal static bool Add(
            this DiagnosticBag diagnostics,
            SyntaxNode node,
            HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return !useSiteDiagnostics.IsNullOrEmpty() && diagnostics.Add(node.Location, useSiteDiagnostics);
        }

        /// <summary>
        /// Adds diagnostics from useSiteDiagnostics into diagnostics and returns True if there were any errors.
        /// </summary>
        internal static bool Add(
            this DiagnosticBag diagnostics,
            SyntaxToken token,
            HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return !useSiteDiagnostics.IsNullOrEmpty() && diagnostics.Add(token.GetLocation(), useSiteDiagnostics);
        }

        internal static bool Add(
            this DiagnosticBag diagnostics,
            Location location,
            HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (useSiteDiagnostics.IsNullOrEmpty())
            {
                return false;
            }

            bool haveErrors = false;

            foreach (var info in useSiteDiagnostics)
            {
                if (info.Severity == DiagnosticSeverity.Error)
                {
                    haveErrors = true;
                }
                diagnostics.Add(info.ToDiagnostic(location));
            }
            return haveErrors;
        }
    }
}
