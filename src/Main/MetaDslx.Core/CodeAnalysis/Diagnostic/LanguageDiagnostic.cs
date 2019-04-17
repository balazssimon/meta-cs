using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// A diagnostic (such as a compiler error or a warning), along with the location where it occurred.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class LanguageDiagnostic : Diagnostic
    {
        private readonly LanguageDiagnosticInfo _info;
        private readonly Location _location;
        private readonly bool _isSuppressed;

        internal LanguageDiagnostic(LanguageDiagnosticInfo info, Location location, bool isSuppressed = false)
        {
            Debug.Assert(info != null);
            Debug.Assert(location != null);
            _info = info;
            _location = location;
            _isSuppressed = isSuppressed;
        }
        /// <summary>
        /// Creates a <see cref="Diagnostic"/> instance.
        /// </summary>
        /// <param name="descriptor">A <see cref="DiagnosticDescriptor"/> describing the diagnostic</param>
        /// <param name="location">An optional primary location of the diagnostic. If null, <see cref="Location"/> will return <see cref="Location.None"/>.</param>
        /// <param name="messageArgs">Arguments to the message of the diagnostic</param>
        /// <returns>The <see cref="Diagnostic"/> instance.</returns>
        public static Diagnostic Create(
            ErrorCode errorCode,
            Location location,
            params object[] messageArgs)
        {
            return Create(errorCode.DiagnosticDescriptor, location, null, null, messageArgs);
        }

        /// <summary>
        /// Creates a <see cref="Diagnostic"/> instance.
        /// </summary>
        /// <param name="descriptor">A <see cref="DiagnosticDescriptor"/> describing the diagnostic.</param>
        /// <param name="location">An optional primary location of the diagnostic. If null, <see cref="Location"/> will return <see cref="Location.None"/>.</param>
        /// <param name="properties">
        /// An optional set of name-value pairs by means of which the analyzer that creates the diagnostic
        /// can convey more detailed information to the fixer. If null, <see cref="Properties"/> will return
        /// <see cref="ImmutableDictionary{TKey, TValue}.Empty"/>.
        /// </param>
        /// <param name="messageArgs">Arguments to the message of the diagnostic.</param>
        /// <returns>The <see cref="Diagnostic"/> instance.</returns>
        public static Diagnostic Create(
            ErrorCode errorCode,
            Location location,
            ImmutableDictionary<string, string> properties,
            params object[] messageArgs)
        {
            return Create(errorCode.DiagnosticDescriptor, location, null, properties, messageArgs);
        }

        /// <summary>
        /// Creates a <see cref="Diagnostic"/> instance.
        /// </summary>
        /// <param name="descriptor">A <see cref="DiagnosticDescriptor"/> describing the diagnostic.</param>
        /// <param name="location">An optional primary location of the diagnostic. If null, <see cref="Location"/> will return <see cref="Location.None"/>.</param>
        /// <param name="additionalLocations">
        /// An optional set of additional locations related to the diagnostic.
        /// Typically, these are locations of other items referenced in the message.
        /// If null, <see cref="AdditionalLocations"/> will return an empty list.
        /// </param>
        /// <param name="messageArgs">Arguments to the message of the diagnostic.</param>
        /// <returns>The <see cref="Diagnostic"/> instance.</returns>
        public static Diagnostic Create(
            ErrorCode errorCode,
            Location location,
            IEnumerable<Location> additionalLocations,
            params object[] messageArgs)
        {
            return Create(errorCode.DiagnosticDescriptor, location, additionalLocations, properties: null, messageArgs: messageArgs);
        }

        /// <summary>
        /// Creates a <see cref="Diagnostic"/> instance.
        /// </summary>
        /// <param name="descriptor">A <see cref="DiagnosticDescriptor"/> describing the diagnostic.</param>
        /// <param name="location">An optional primary location of the diagnostic. If null, <see cref="Location"/> will return <see cref="Location.None"/>.</param>
        /// <param name="additionalLocations">
        /// An optional set of additional locations related to the diagnostic.
        /// Typically, these are locations of other items referenced in the message.
        /// If null, <see cref="AdditionalLocations"/> will return an empty list.
        /// </param>
        /// <param name="properties">
        /// An optional set of name-value pairs by means of which the analyzer that creates the diagnostic
        /// can convey more detailed information to the fixer. If null, <see cref="Properties"/> will return
        /// <see cref="ImmutableDictionary{TKey, TValue}.Empty"/>.
        /// </param>
        /// <param name="messageArgs">Arguments to the message of the diagnostic.</param>
        /// <returns>The <see cref="Diagnostic"/> instance.</returns>
        public static Diagnostic Create(
            ErrorCode errorCode,
            Location location,
            IEnumerable<Location> additionalLocations,
            ImmutableDictionary<string, string> properties,
            params object[] messageArgs)
        {
            return Create(errorCode.DiagnosticDescriptor, location, effectiveSeverity: errorCode.DefaultSeverity, additionalLocations, properties, messageArgs);
        }

        /// <summary>
        /// Creates a <see cref="Diagnostic"/> instance.
        /// </summary>
        /// <param name="descriptor">A <see cref="DiagnosticDescriptor"/> describing the diagnostic.</param>
        /// <param name="location">An optional primary location of the diagnostic. If null, <see cref="Location"/> will return <see cref="Location.None"/>.</param>
        /// <param name="effectiveSeverity">Effective severity of the diagnostic.</param>
        /// <param name="additionalLocations">
        /// An optional set of additional locations related to the diagnostic.
        /// Typically, these are locations of other items referenced in the message.
        /// If null, <see cref="AdditionalLocations"/> will return an empty list.
        /// </param>
        /// <param name="properties">
        /// An optional set of name-value pairs by means of which the analyzer that creates the diagnostic
        /// can convey more detailed information to the fixer. If null, <see cref="Properties"/> will return
        /// <see cref="ImmutableDictionary{TKey, TValue}.Empty"/>.
        /// </param>
        /// <param name="messageArgs">Arguments to the message of the diagnostic.</param>
        /// <returns>The <see cref="Diagnostic"/> instance.</returns>
        public static Diagnostic Create(
            ErrorCode errorCode,
            Location location,
            DiagnosticSeverity effectiveSeverity,
            IEnumerable<Location> additionalLocations,
            ImmutableDictionary<string, string> properties,
            params object[] messageArgs)
        {
            return Create(errorCode.DiagnosticDescriptor, location, effectiveSeverity, additionalLocations, properties, messageArgs);
        }

        public static Diagnostic Create(ErrorCode errorCode)
        {
            return Create(new LanguageDiagnosticInfo(errorCode));
        }

        public static Diagnostic Create(ErrorCode errorCode, params object[] arguments)
        {
            return Create(new LanguageDiagnosticInfo(errorCode, arguments));
        }

        public static Diagnostic Create(LanguageDiagnosticInfo info)
        {
            return new DiagnosticWithInfo(info, Location.None);
        }

        public override Location Location
        {
            get { return _location; }
        }

        public override IReadOnlyList<Location> AdditionalLocations
        {
            get { return this.Info.AdditionalLocations; }
        }

        internal override IReadOnlyList<string> CustomTags
        {
            get
            {
                return this.Info.CustomTags;
            }
        }

        public override DiagnosticDescriptor Descriptor
        {
            get
            {
                return this.Info.ErrorCode.DiagnosticDescriptor;
            }
        }

        public override string Id
        {
            get { return this.Info.MessageIdentifier; }
        }

        internal override string Category
        {
            get { return this.Info.Category; }
        }

        internal sealed override int Code
        {
            get { return this.Info.Code; }
        }

        public sealed override DiagnosticSeverity Severity
        {
            get { return this.Info.Severity; }
        }

        public sealed override DiagnosticSeverity DefaultSeverity
        {
            get { return this.Info.DefaultSeverity; }
        }

        internal sealed override bool IsEnabledByDefault
        {
            // All compiler errors and warnings are enabled by default.
            get { return true; }
        }

        public override bool IsSuppressed
        {
            get { return _isSuppressed; }
        }

        public sealed override int WarningLevel
        {
            get { return this.Info.WarningLevel; }
        }

        public override string GetMessage(IFormatProvider formatProvider = null)
        {
            return this.Info.GetMessage(formatProvider);
        }

        internal override IReadOnlyList<object> Arguments
        {
            get { return this.Info.Arguments; }
        }

        /// <summary>
        /// Get the information about the diagnostic: the code, severity, message, etc.
        /// </summary>
        public LanguageDiagnosticInfo Info
        {
            get
            {
                if (_info.Severity == InternalDiagnosticSeverity.Unknown)
                {
                    return (LanguageDiagnosticInfo)_info.GetResolvedInfo();
                }

                return _info;
            }
        }

        /// <summary>
        /// True if the LanguageDiagnosticInfo for this diagnostic requires (or required - this property
        /// is immutable) resolution.
        /// </summary>
        internal bool HasLazyInfo
        {
            get
            {
                return _info.Severity == InternalDiagnosticSeverity.Unknown ||
                    _info.Severity == InternalDiagnosticSeverity.Void;
            }
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Location.GetHashCode(), this.Info.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Diagnostic);
        }

        public override bool Equals(Diagnostic obj)
        {
            if (this == obj)
            {
                return true;
            }

            var other = obj as LanguageDiagnostic;

            if (other == null || this.GetType() != other.GetType())
            {
                return false;
            }

            return
                this.Location.Equals(other._location) &&
                this.Info.Equals(other.Info) &&
                this.AdditionalLocations.SequenceEqual(other.AdditionalLocations);
        }

        private string GetDebuggerDisplay()
        {
            switch (_info.Severity)
            {
                case InternalDiagnosticSeverity.Unknown:
                    // If we called ToString before the diagnostic was resolved,
                    // we would risk infinite recursion (e.g. if we were still computing
                    // member lists).
                    return "Unresolved diagnostic at " + this.Location;

                case InternalDiagnosticSeverity.Void:
                    // If we called ToString on a void diagnostic, the MessageProvider
                    // would complain about the code.
                    return "Void diagnostic at " + this.Location;

                default:
                    return ToString();
            }
        }

        internal override Diagnostic WithLocation(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            if (location != _location)
            {
                return new LanguageDiagnostic(_info, location, _isSuppressed);
            }

            return this;
        }

        internal override Diagnostic WithSeverity(DiagnosticSeverity severity)
        {
            if (this.Severity != severity)
            {
                return new LanguageDiagnostic((LanguageDiagnosticInfo)this.Info.GetInstanceWithSeverity(severity), _location, _isSuppressed);
            }

            return this;
        }

        internal override Diagnostic WithIsSuppressed(bool isSuppressed)
        {
            if (this.IsSuppressed != isSuppressed)
            {
                return new LanguageDiagnostic(this.Info, _location, isSuppressed);
            }

            return this;
        }

        internal sealed override bool IsNotConfigurable()
        {
            return this.Info.IsNotConfigurable();
        }
    }
}
