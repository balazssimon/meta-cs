// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Roslyn.Utilities;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// A DiagnosticInfo object has information about a diagnostic, but without any attached location information.
    /// </summary>
    /// <remarks>
    /// More specialized diagnostics with additional information (e.g., ambiguity errors) can derive from this class to
    /// provide access to additional information about the error, such as what symbols were involved in the ambiguity.
    /// </remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class DiagnosticInfo : IFormattable, IObjectWritable
    {
        // Mark compiler errors as non-configurable to ensure they can never be suppressed or filtered.
        private static readonly ImmutableArray<string> s_compilerErrorCustomTags = ImmutableArray.Create(WellKnownDiagnosticTags.Compiler, WellKnownDiagnosticTags.Telemetry, WellKnownDiagnosticTags.NotConfigurable);
        private static readonly ImmutableArray<string> s_compilerNonErrorCustomTags = ImmutableArray.Create(WellKnownDiagnosticTags.Compiler, WellKnownDiagnosticTags.Telemetry);

        protected DiagnosticInfo()
        {
        }

        // Create a copy of this instance with a explicit overridden severity
        internal abstract DiagnosticInfo GetInstanceWithSeverity(DiagnosticSeverity severity);

        #region Serialization

        bool IObjectWritable.ShouldReuseInSerialization => false;

        void IObjectWritable.WriteTo(ObjectWriter writer)
        {
            this.WriteTo(writer);
        }

        protected virtual void WriteTo(ObjectWriter writer)
        {
        }

        protected DiagnosticInfo(ObjectReader reader)
        {
        }

        #endregion

        /// <summary>
        /// The error code, as an integer.
        /// </summary>
        public abstract int Code { get; }

        public abstract DiagnosticDescriptor Descriptor { get; }

        /// <summary>
        /// Returns the effective severity of the diagnostic: whether this diagnostic is informational, warning, or error.
        /// If IsWarningsAsError is true, then this returns <see cref="DiagnosticSeverity.Error"/>, while <see cref="DefaultSeverity"/> returns <see cref="DiagnosticSeverity.Warning"/>.
        /// </summary>
        public abstract DiagnosticSeverity Severity { get; }

        /// <summary>
        /// Returns whether this diagnostic is informational, warning, or error by default, based on the error code.
        /// To get diagnostic's effective severity, use <see cref="Severity"/>.
        /// </summary>
        public abstract DiagnosticSeverity DefaultSeverity { get; }

        /// <summary>
        /// Gets the warning level. This is 0 for diagnostics with severity <see cref="DiagnosticSeverity.Error"/>,
        /// otherwise an integer between 1 and 4.
        /// </summary>
        public abstract int WarningLevel { get; }

        /// <summary>
        /// Returns true if this is a warning treated as an error.
        /// </summary>
        /// <remarks>
        /// True implies <see cref="Severity"/> = <see cref="DiagnosticSeverity.Error"/> and
        /// <see cref="DefaultSeverity"/> = <see cref="DiagnosticSeverity.Warning"/>.
        /// </remarks>
        public bool IsWarningAsError
        {
            get
            {
                return this.DefaultSeverity == DiagnosticSeverity.Warning &&
                    this.Severity == DiagnosticSeverity.Error;
            }
        }

        /// <summary>
        /// Get the diagnostic category for the given diagnostic code.
        /// Default category is <see cref="Diagnostic.CompilerDiagnosticCategory"/>.
        /// </summary>
        public abstract string Category { get; }

        internal ImmutableArray<string> CustomTags
        {
            get
            {
                return GetCustomTags(this.DefaultSeverity);
            }
        }

        protected static ImmutableArray<string> GetCustomTags(DiagnosticSeverity defaultSeverity)
        {
            return defaultSeverity == DiagnosticSeverity.Error ?
                s_compilerErrorCustomTags :
                s_compilerNonErrorCustomTags;
        }

        internal bool IsNotConfigurable()
        {
            // Only compiler errors are non-configurable.
            return this.DefaultSeverity == DiagnosticSeverity.Error;
        }

        /// <summary>
        /// If a derived class has additional information about other referenced symbols, it can
        /// expose the locations of those symbols in a general way, so they can be reported along
        /// with the error.
        /// </summary>
        public virtual IReadOnlyList<Location> AdditionalLocations
        {
            get
            {
                return SpecializedCollections.EmptyReadOnlyList<Location>();
            }
        }

        /// <summary>
        /// Get the message id (for example "CS1001") for the message. This includes both the error number
        /// and a prefix identifying the source.
        /// </summary>
        public abstract string MessageIdentifier { get; }

        /// <summary>
        /// Get the text of the message in the given language.
        /// </summary>
        public abstract string GetMessage(IFormatProvider formatProvider = null);

        protected abstract object[] GetArgumentsToUse(IFormatProvider formatProvider);

        internal abstract object[] Arguments { get; }

        // TODO (tomat): remove
        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return this.ToFormattedString(formatProvider);
        }

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return this.ToFormattedString(formatProvider);
        }

        protected abstract string ToFormattedString(IFormatProvider formatProvider);

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        /// <summary>
        /// For a DiagnosticInfo that is lazily evaluated, this method evaluates it
        /// and returns a non-lazy DiagnosticInfo.
        /// </summary>
        internal virtual DiagnosticInfo GetResolvedInfo()
        {
            // We should never call GetResolvedInfo on a non-lazy DiagnosticInfo
            throw ExceptionUtilities.Unreachable;
        }
    }
}
