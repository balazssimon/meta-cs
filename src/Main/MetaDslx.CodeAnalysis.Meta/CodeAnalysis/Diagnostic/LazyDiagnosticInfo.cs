// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class LazyDiagnosticInfo : LanguageDiagnosticInfo
    {
        private DiagnosticInfo? _lazyInfo;

        protected LazyDiagnosticInfo()
            : base(InternalErrorCode.Unknown)
        {
        }

        internal sealed override DiagnosticInfo GetResolvedInfo()
        {
            if (_lazyInfo == null)
            {
                Interlocked.CompareExchange(ref _lazyInfo, ResolveInfo() ?? LanguageDiagnosticInfo.VoidDiagnosticInfo, null);
            }

            return _lazyInfo;
        }

        protected abstract DiagnosticInfo? ResolveInfo();
    }
}
