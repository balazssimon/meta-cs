﻿using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// Represents a diagnostic, such as a compiler error or a warning, along with the location where it occurred.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public sealed class Diagnostic : IEquatable<Diagnostic>
    {
        internal const string CompilerDiagnosticCategory = "Compiler";

        private readonly DiagnosticInfo _info;
        private readonly Location _location;
        private readonly bool _isSuppressed;

        private Diagnostic(Location location, DiagnosticInfo info, bool isSuppressed = false)
        {
            Debug.Assert(info != null);
            Debug.Assert(location != null);
            _info = info;
            _location = location;
            _isSuppressed = isSuppressed;
        }

        public static Diagnostic Create(Location location, ErrorCode errorCode)
        {
            return Create(location, new DiagnosticInfo(errorCode));
        }

        public static Diagnostic Create(Location location, ErrorCode errorCode, params object[] arguments)
        {
            return Create(location, new DiagnosticInfo(errorCode, arguments));
        }

        public static Diagnostic Create(Location location, DiagnosticInfo info)
        {
            return new Diagnostic(location, info);
        }

        public DiagnosticInfo Info { get { return _info; } }

        /// <summary>
        /// Gets the diagnostic code as an integer.
        /// </summary>
        public int Id { get { return _info.Id; } }

        /// <summary>
        /// Gets the category of diagnostic. For diagnostics generated by the compiler, the category will be "Compiler".
        /// </summary>
        public string Category { get { return _info.Category; } }

        /// <summary>
        /// Gets the default <see cref="DiagnosticSeverity"/> of the diagnostic's <see cref="DiagnosticDescriptor"/>.
        /// </summary>
        /// <remarks>
        /// To get the effective severity of the diagnostic, use <see cref="Severity"/>.
        /// </remarks>
        public DiagnosticSeverity DefaultSeverity { get { return _info.DefaultSeverity; } }

        /// <summary>
        /// Gets the effective <see cref="DiagnosticSeverity"/> of the diagnostic.
        /// </summary>
        /// <remarks>
        /// To get the default severity of diagnostic's <see cref="DiagnosticDescriptor"/>, use <see cref="DefaultSeverity"/>.
        /// To determine if this is a warning treated as an error, use <see cref="IsWarningAsError"/>.
        /// </remarks>
        public DiagnosticSeverity Severity { get { return _info.Severity; } }

        /// <summary>
        /// Gets the warning level. This is 0 for diagnostics with severity <see cref="DiagnosticSeverity.Error"/>,
        /// otherwise an integer between 1 and 4.
        /// </summary>
        public int WarningLevel { get { return _info.WarningLevel; } }

        /// <summary>
        /// Returns true if the diagnostic has a source suppression, i.e. an attribute or a pragma suppression.
        /// </summary>
        public bool IsSuppressed { get { return _isSuppressed; } }

        /// <summary>
        /// Returns true if this is a warning treated as an error; otherwise false.
        /// </summary>
        /// <remarks>
        /// True implies <see cref="DefaultSeverity"/> = <see cref="DiagnosticSeverity.Warning"/>
        /// and <see cref="Severity"/> = <see cref="DiagnosticSeverity.Error"/>.
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
        /// Gets the primary location of the diagnostic, or <see cref="Location.None"/> if no primary location.
        /// </summary>
        public Location Location { get { return _location; } }

        /// <summary>
        /// Gets an array of additional locations related to the diagnostic.
        /// Typically these are the locations of other items referenced in the message.
        /// </summary>
        public ImmutableArray<Location> AdditionalLocations { get { return _info.AdditionalLocations; } }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Location.GetHashCode(), this.Info.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Diagnostic);
        }

        public bool Equals(Diagnostic obj)
        {
            if (this == obj)
            {
                return true;
            }

            var other = obj as Diagnostic;

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
            return ToString();
        }

        /// <summary>
        /// Create a new instance of this diagnostic with the Location property changed.
        /// </summary>
        public Diagnostic WithLocation(Location location)
        {
            return new Diagnostic(location, _info, _isSuppressed);
        }

        /// <summary>
        /// Create a new instance of this diagnostic with the Severity property changed.
        /// </summary>
        public Diagnostic WithSeverity(DiagnosticSeverity severity)
        {
            return new Diagnostic(_location, _info.WithSeverity(severity), _isSuppressed);
        }

        /// <summary>
        /// Create a new instance of this diagnostic with the suppression info changed.
        /// </summary>
        public Diagnostic WithIsSuppressed(bool isSuppressed)
        {
            return new Diagnostics.Diagnostic(_location, _info, isSuppressed);
        }

        internal Diagnostic WithReportDiagnostic(ReportDiagnostic reportAction)
        {
            switch (reportAction)
            {
                case ReportDiagnostic.Suppress:
                    // Suppressed diagnostic.
                    return null;
                case ReportDiagnostic.Error:
                    return this.WithSeverity(DiagnosticSeverity.Error);
                case ReportDiagnostic.Default:
                    return this;
                case ReportDiagnostic.Warn:
                    return this.WithSeverity(DiagnosticSeverity.Warning);
                case ReportDiagnostic.Info:
                    return this.WithSeverity(DiagnosticSeverity.Info);
                case ReportDiagnostic.Hidden:
                    return this.WithSeverity(DiagnosticSeverity.Hidden);
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportAction), "Unexpected value: " + reportAction);
            }
        }

        internal static int GetDefaultWarningLevel(DiagnosticSeverity severity)
        {
            switch (severity)
            {
                case DiagnosticSeverity.Error:
                    return 0;

                case DiagnosticSeverity.Warning:
                    return 1;

                default:
                    return 1;
            }
        }

        /// <summary>
        /// Returns true if the diagnostic location (or any additional location) is within the given tree and intersects with the filterSpanWithinTree, if non-null.
        /// </summary>
        internal bool HasIntersectingLocation(SyntaxTree tree, TextSpan? filterSpanWithinTree = null)
        {
            var locations = this.GetDiagnosticLocationsWithinTree(tree);

            foreach (var location in locations)
            {
                if (!filterSpanWithinTree.HasValue || filterSpanWithinTree.Value.IntersectsWith(location.SourceSpan))
                {
                    return true;
                }
            }

            return false;
        }


        private IEnumerable<Location> GetDiagnosticLocationsWithinTree(SyntaxTree tree)
        {
            if (this.Location.SourceTree == tree)
            {
                yield return this.Location;
            }

            if (this.AdditionalLocations != null)
            {
                foreach (var additionalLocation in this.AdditionalLocations)
                {
                    if (additionalLocation.SourceTree == tree)
                    {
                        yield return additionalLocation;
                    }
                }
            }
        }

        public override string ToString()
        {
            return _info.ToString(_location, null);
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return _info.ToString(_location, formatProvider);
        }
    }
}
