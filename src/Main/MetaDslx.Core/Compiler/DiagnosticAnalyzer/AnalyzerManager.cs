// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading.Tasks;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// Manages properties of analyzers (such as registered actions, supported diagnostics) for analyzer host's lifetime
    /// and executes the callbacks into the analyzers.
    /// 
    /// It ensures the following for the lifetime of analyzer host:
    /// 1) <see cref="DiagnosticAnalyzer.Initialize(AnalysisContext)"/> is invoked only once per-analyzer.
    /// 2) <see cref="DiagnosticAnalyzer.SupportedDiagnostics"/> is invoked only once per-analyzer.
    /// 3) <see cref="CompilationStartAnalyzerAction"/> registered during Initialize are invoked only once per-compilation per-analyzer and analyzer options.
    /// </summary>
    internal partial class AnalyzerManager
    {
        internal static bool HasNotConfigurableTag(IEnumerable<string> customTags)
        {
            foreach (var customTag in customTags)
            {
                if (customTag == WellKnownDiagnosticTags.NotConfigurable)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
