using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// A LanguageDiagnosticInfo object has information about a diagnostic, but without any attached location information.
    /// </summary>
    /// <remarks>
    /// More specialized diagnostics with additional information (e.g., ambiguity errors) can derive from this class to
    /// provide access to additional information about the error, such as what symbols were involved in the ambiguity.
    /// </remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class LanguageDiagnosticInfo : MetaDslx.CodeAnalysis.Internal.DiagnosticInfoWithSymbols
    {
        public static readonly DiagnosticInfo EmptyErrorInfo = new LanguageDiagnosticInfo(InternalErrorCode.EmptyError);
        public static readonly DiagnosticInfo VoidDiagnosticInfo = new LanguageDiagnosticInfo(InternalErrorCode.Void);

        private readonly ErrorCode _errorCode;
        private readonly IReadOnlyList<Location> _additionalLocations;

        public LanguageDiagnosticInfo(ErrorCode code)
            : this(code, Array.Empty<object>(), ImmutableArray<Symbol>.Empty, ImmutableArray<Location>.Empty)
        {
        }

        public LanguageDiagnosticInfo(ErrorCode code, params object[] args)
            : this(code, args, ImmutableArray<Symbol>.Empty, ImmutableArray<Location>.Empty)
        {
        }

        public LanguageDiagnosticInfo(ErrorCode code, ImmutableArray<Symbol> symbols, object[] args)
            : this(code, args, symbols, ImmutableArray<Location>.Empty)
        {
        }

        public LanguageDiagnosticInfo(ErrorCode code, object[] args, ImmutableArray<Symbol> symbols, ImmutableArray<Location> additionalLocations)
            : base(code, args, symbols)
        {
            // Internal errors are abnormal and should not occur except where there are bugs in the compiler.
            Debug.Assert(code != InternalErrorCode.ERR_InternalError);
            _errorCode = code;
            _additionalLocations = additionalLocations.IsDefaultOrEmpty ? SpecializedCollections.EmptyReadOnlyList<Location>() : additionalLocations;
        }

        public override IReadOnlyList<Location> AdditionalLocations => _additionalLocations;

        public ErrorCode ErrorCode => _errorCode;

        public static bool IsEmpty(DiagnosticInfo info) => (object)info == EmptyErrorInfo;
    }
}
