using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
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
    /// A DiagnosticInfo object has information about a diagnostic, but without any attached location information.
    /// </summary>
    /// <remarks>
    /// More specialized diagnostics with additional information (e.g., ambiguity errors) can derive from this class to
    /// provide access to additional information about the error, such as what symbols were involved in the ambiguity.
    /// </remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class DiagnosticInfo : IMessageSerializable
    {
        private readonly ErrorCode _errorCode;
        private readonly DiagnosticSeverity _effectiveSeverity;
        private readonly object[] _arguments;

        public DiagnosticInfo(ErrorCode errorCode)
        {
            _errorCode = errorCode;
            _effectiveSeverity = _errorCode.DefaultSeverity;
        }

        public DiagnosticInfo(ErrorCode errorCode, params object[] arguments)
        {
            AssertMessageSerializable(arguments);

            _errorCode = errorCode;
            _effectiveSeverity = _errorCode.DefaultSeverity;
            _arguments = arguments;
        }

        protected DiagnosticInfo(DiagnosticInfo original, DiagnosticSeverity overriddenSeverity)
        {
            _errorCode = original._errorCode;
            _arguments = original._arguments;

            _effectiveSeverity = overriddenSeverity;
        }

        [Conditional("DEBUG")]
        internal static void AssertMessageSerializable(object[] args)
        {
            foreach (var arg in args)
            {
                Debug.Assert(arg != null);

                if (arg is IMessageSerializable)
                {
                    continue;
                }

                var type = arg.GetType();
                if (type == typeof(string))
                {
                    continue;
                }
                if (type.IsPrimitive)
                {
                    continue;
                }

                throw new InvalidOperationException("Invalid diagnostic argument of type '" + type + "'. The argument is not serializable to string.");
            }
        }

        // Only the compiler creates instances.
        internal DiagnosticInfo(bool isWarningAsError, ErrorCode errorCode, params object[] arguments)
            : this(errorCode, arguments)
        {
            Debug.Assert(!isWarningAsError || _errorCode.DefaultSeverity == DiagnosticSeverity.Warning);

            if (isWarningAsError)
            {
                _effectiveSeverity = DiagnosticSeverity.Error;
            }
        }

        // Create a copy of this instance with a explicit overridden severity
        public virtual DiagnosticInfo WithSeverity(DiagnosticSeverity severity)
        {
            if (severity != this.Severity) return new DiagnosticInfo(this, severity);
            else return this;
        }

        /// <summary>
        /// The diagnostic code, as an integer.
        /// </summary>
        public int Id { get { return _errorCode.Id; } }

        /// <summary>
        /// The diagnostic code, as an integer.
        /// </summary>
        public ErrorCode Code { get { return _errorCode; } }

        /// <summary>
        /// Returns the effective severity of the diagnostic: whether this diagnostic is informational, warning, or error.
        /// If IsWarningsAsError is true, then this returns <see cref="DiagnosticSeverity.Error"/>, while <see cref="DefaultSeverity"/> returns <see cref="DiagnosticSeverity.Warning"/>.
        /// </summary>
        public DiagnosticSeverity Severity
        {
            get
            {
                return _effectiveSeverity;
            }
        }

        /// <summary>
        /// Returns whether this diagnostic is informational, warning, or error by default, based on the error code.
        /// To get diagnostic's effective severity, use <see cref="Severity"/>.
        /// </summary>
        public DiagnosticSeverity DefaultSeverity
        {
            get
            {
                return _errorCode.DefaultSeverity;
            }
        }

        /// <summary>
        /// Gets the warning level. This is 0 for diagnostics with severity <see cref="DiagnosticSeverity.Error"/>,
        /// otherwise an integer between 1 and 4.
        /// </summary>
        public int WarningLevel
        {
            get
            {
                return _errorCode.WarningLevel;
            }
        }

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
        public string Category
        {
            get
            {
                return _errorCode.Category;
            }
        }

        internal bool IsNotConfigurable()
        {
            // Only compiler errors are non-configurable.
            return _errorCode.DefaultSeverity == DiagnosticSeverity.Error;
        }

        /// <summary>
        /// If a derived class has additional information about other referenced symbols, it can
        /// expose the locations of those symbols in a general way, so they can be reported along
        /// with the error.
        /// </summary>
        public virtual ImmutableArray<Location> AdditionalLocations
        {
            get
            {
                return ImmutableArray<Location>.Empty;
            }
        }

        /// <summary>
        /// Get the text of the message in the given language.
        /// </summary>
        public virtual string GetMessage(IFormatProvider formatProvider = null)
        {
            // Get the message and fill in arguments.
            string message = _errorCode.DefaultMessage;
            if (string.IsNullOrEmpty(message))
            {
                return string.Empty;
            }

            if (_arguments == null || _arguments.Length == 0)
            {
                return message;
            }

            return String.Format(formatProvider, message, GetArgumentsToUse(formatProvider));
        }

        protected object[] GetArgumentsToUse(IFormatProvider formatProvider)
        {
            object[] argumentsToUse = null;
            for (int i = 0; i < _arguments.Length; i++)
            {
                var embedded = _arguments[i] as DiagnosticInfo;
                if (embedded != null)
                {
                    argumentsToUse = InitializeArgumentListIfNeeded(argumentsToUse);
                    argumentsToUse[i] = embedded.GetMessage(formatProvider);
                    continue;
                }
            }

            if (argumentsToUse != null) return argumentsToUse;
            else return _arguments;
        }

        private object[] InitializeArgumentListIfNeeded(object[] argumentsToUse)
        {
            if (argumentsToUse != null)
            {
                return argumentsToUse;
            }

            var newArguments = new object[_arguments.Length];
            for (int i = 0; i < _arguments.Length; i++)
            {
                newArguments[i] = _arguments[i];
            }
            return newArguments;
        }

        public string DefaultMessage
        {
            get { return _errorCode.DefaultMessage; }
        }

        public object[] Arguments
        {
            get { return _arguments; }
        }

        public override string ToString()
        {
            return ToString(Location.None, null);
        }

        public string ToString(Location location, IFormatProvider formatProvider)
        {
            return String.Format(formatProvider, "{0} at {1}: {2}", this.Severity, location, this.GetMessage(formatProvider));
        }

        public sealed override int GetHashCode()
        {
            int hashCode = _errorCode.GetHashCode();
            if (_arguments != null)
            {
                for (int i = 0; i < _arguments.Length; i++)
                {
                    hashCode = Hash.Combine(_arguments[i], hashCode);
                }
            }

            return hashCode;
        }

        public sealed override bool Equals(object obj)
        {
            DiagnosticInfo other = obj as DiagnosticInfo;

            bool result = false;

            if (other != null &&
                other._errorCode.Equals(_errorCode) &&
                this.GetType() == obj.GetType())
            {
                if (_arguments == null && other._arguments == null)
                {
                    result = true;
                }
                else if (_arguments != null && other._arguments != null && _arguments.Length == other._arguments.Length)
                {
                    result = true;
                    for (int i = 0; i < _arguments.Length; i++)
                    {
                        if (!object.Equals(_arguments[i], other._arguments[i]))
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
