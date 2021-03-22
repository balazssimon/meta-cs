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
    public class DiagnosticInfoWithMessageProvider : DiagnosticInfo, IFormattable, IObjectWritable
    {
        private readonly CommonMessageProvider _messageProvider;
        private readonly int _errorCode;
        private readonly DiagnosticSeverity _defaultSeverity;
        private readonly DiagnosticSeverity _effectiveSeverity;
        private readonly object[] _arguments;

        private static ImmutableDictionary<int, DiagnosticDescriptor> s_errorCodeToDescriptorMap = ImmutableDictionary<int, DiagnosticDescriptor>.Empty;

        static DiagnosticInfoWithMessageProvider()
        {
            ObjectBinder.RegisterTypeReader(typeof(DiagnosticInfoWithMessageProvider), r => new DiagnosticInfoWithMessageProvider(r));
        }

        // Only the compiler creates instances.
        internal DiagnosticInfoWithMessageProvider(CommonMessageProvider messageProvider, int errorCode)
        {
            _messageProvider = messageProvider;
            _errorCode = errorCode;
            _defaultSeverity = messageProvider.GetSeverity(errorCode);
            _effectiveSeverity = _defaultSeverity;
        }

        // Only the compiler creates instances.
        internal DiagnosticInfoWithMessageProvider(CommonMessageProvider messageProvider, int errorCode, params object[] arguments)
            : this(messageProvider, errorCode)
        {
            AssertMessageSerializable(arguments);

            _arguments = arguments;
        }

        private DiagnosticInfoWithMessageProvider(DiagnosticInfoWithMessageProvider original, DiagnosticSeverity overriddenSeverity)
        {
            _messageProvider = original.MessageProvider;
            _errorCode = original._errorCode;
            _defaultSeverity = original.DefaultSeverity;
            _arguments = original._arguments;

            _effectiveSeverity = overriddenSeverity;
        }

        internal static DiagnosticDescriptor GetDescriptor(int errorCode, CommonMessageProvider messageProvider)
        {
            var defaultSeverity = messageProvider.GetSeverity(errorCode);
            return GetOrCreateDescriptor(errorCode, defaultSeverity, messageProvider);
        }

        private static DiagnosticDescriptor GetOrCreateDescriptor(int errorCode, DiagnosticSeverity defaultSeverity, CommonMessageProvider messageProvider)
        {
            return ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, errorCode, code => CreateDescriptor(code, defaultSeverity, messageProvider));
        }

        private static DiagnosticDescriptor CreateDescriptor(int errorCode, DiagnosticSeverity defaultSeverity, CommonMessageProvider messageProvider)
        {
            var id = messageProvider.GetIdForErrorCode(errorCode);
            var title = messageProvider.GetTitle(errorCode);
            var description = messageProvider.GetDescription(errorCode);
            var messageFormat = messageProvider.GetMessageFormat(errorCode);
            var helpLink = messageProvider.GetHelpLink(errorCode);
            var category = messageProvider.GetCategory(errorCode);
            var customTags = GetCustomTags(defaultSeverity);
            return new DiagnosticDescriptor(id, title, messageFormat, category, defaultSeverity,
                isEnabledByDefault: true, description: description, helpLinkUri: helpLink, customTags: customTags);
        }

        [Conditional("DEBUG")]
        internal static void AssertMessageSerializable(object[] args)
        {
            foreach (var arg in args)
            {
                Debug.Assert(arg != null);

                if (arg is IFormattable)
                {
                    continue;
                }

                var type = arg.GetType();
                if (type == typeof(string) || type == typeof(AssemblyIdentity))
                {
                    continue;
                }

                var info = type.GetTypeInfo();
                if (info.IsPrimitive)
                {
                    continue;
                }

                throw ExceptionUtilities.UnexpectedValue(type);
            }
        }

        // Only the compiler creates instances.
        internal DiagnosticInfoWithMessageProvider(CommonMessageProvider messageProvider, bool isWarningAsError, int errorCode, params object[] arguments)
            : this(messageProvider, errorCode, arguments)
        {
            Debug.Assert(!isWarningAsError || _defaultSeverity == DiagnosticSeverity.Warning);

            if (isWarningAsError)
            {
                _effectiveSeverity = DiagnosticSeverity.Error;
            }
        }

        // Create a copy of this instance with a explicit overridden severity
        internal override DiagnosticInfo GetInstanceWithSeverity(DiagnosticSeverity severity)
        {
            return new DiagnosticInfoWithMessageProvider(this, severity);
        }

        #region Serialization

        bool IObjectWritable.ShouldReuseInSerialization => false;

        void IObjectWritable.WriteTo(ObjectWriter writer)
        {
            this.WriteTo(writer);
        }

        protected override void WriteTo(ObjectWriter writer)
        {
            writer.WriteValue(_messageProvider);
            writer.WriteUInt32((uint)_errorCode);
            writer.WriteInt32((int)_effectiveSeverity);
            writer.WriteInt32((int)_defaultSeverity);

            int count = _arguments?.Length ?? 0;
            writer.WriteUInt32((uint)count);

            if (count > 0)
            {
                foreach (var arg in _arguments)
                {
                    writer.WriteString(arg.ToString());
                }
            }
        }

        protected DiagnosticInfoWithMessageProvider(ObjectReader reader)
        {
            _messageProvider = (CommonMessageProvider)reader.ReadValue();
            _errorCode = (int)reader.ReadUInt32();
            _effectiveSeverity = (DiagnosticSeverity)reader.ReadInt32();
            _defaultSeverity = (DiagnosticSeverity)reader.ReadInt32();

            var count = (int)reader.ReadUInt32();
            if (count == 0)
            {
                _arguments = Array.Empty<object>();
            }
            else if (count > 0)
            {
                _arguments = new string[count];
                for (int i = 0; i < count; i++)
                {
                    _arguments[i] = reader.ReadString();
                }
            }
        }

        #endregion

        /// <summary>
        /// The error code, as an integer.
        /// </summary>
        public override int Code { get { return _errorCode; } }

        public override DiagnosticDescriptor Descriptor
        {
            get
            {
                return GetOrCreateDescriptor(_errorCode, _defaultSeverity, _messageProvider);
            }
        }

        /// <summary>
        /// Returns the effective severity of the diagnostic: whether this diagnostic is informational, warning, or error.
        /// If IsWarningsAsError is true, then this returns <see cref="DiagnosticSeverity.Error"/>, while <see cref="DefaultSeverity"/> returns <see cref="DiagnosticSeverity.Warning"/>.
        /// </summary>
        public override DiagnosticSeverity Severity
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
        public override DiagnosticSeverity DefaultSeverity
        {
            get
            {
                return _defaultSeverity;
            }
        }

        /// <summary>
        /// Gets the warning level. This is 0 for diagnostics with severity <see cref="DiagnosticSeverity.Error"/>,
        /// otherwise an integer between 1 and 4.
        /// </summary>
        public override int WarningLevel
        {
            get
            {
                if (_effectiveSeverity != _defaultSeverity)
                {
                    return Diagnostic.GetDefaultWarningLevel(_effectiveSeverity);
                }

                return _messageProvider.GetWarningLevel(_errorCode);
            }
        }

        /// <summary>
        /// Get the diagnostic category for the given diagnostic code.
        /// Default category is <see cref="Diagnostic.CompilerDiagnosticCategory"/>.
        /// </summary>
        public override string Category
        {
            get
            {
                return _messageProvider.GetCategory(_errorCode);
            }
        }

        /// <summary>
        /// Get the message id (for example "CS1001") for the message. This includes both the error number
        /// and a prefix identifying the source.
        /// </summary>
        public override string MessageIdentifier
        {
            get
            {
                return _messageProvider.GetIdForErrorCode(_errorCode);
            }
        }

        /// <summary>
        /// Get the text of the message in the given language.
        /// </summary>
        public override string GetMessage(IFormatProvider formatProvider = null)
        {
            // Get the message and fill in arguments.
            string message = _messageProvider.LoadMessage(_errorCode, formatProvider as CultureInfo);
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

        protected override object[] GetArgumentsToUse(IFormatProvider formatProvider)
        {
            object[] argumentsToUse = null;
            for (int i = 0; i < _arguments.Length; i++)
            {
                var embedded = _arguments[i] as DiagnosticInfoWithMessageProvider;
                if (embedded != null)
                {
                    argumentsToUse = InitializeArgumentListIfNeeded(argumentsToUse);
                    argumentsToUse[i] = embedded.GetMessage(formatProvider);
                    continue;
                }

                var symbol = _arguments[i] as ISymbol;
                if (symbol != null)
                {
                    argumentsToUse = InitializeArgumentListIfNeeded(argumentsToUse);
                    argumentsToUse[i] = _messageProvider.GetErrorDisplayString(symbol);
                }
            }

            return argumentsToUse ?? _arguments;
        }

        private object[] InitializeArgumentListIfNeeded(object[] argumentsToUse)
        {
            if (argumentsToUse != null)
            {
                return argumentsToUse;
            }

            var newArguments = new object[_arguments.Length];
            Array.Copy(_arguments, newArguments, newArguments.Length);

            return newArguments;
        }

        internal override object[] Arguments
        {
            get { return _arguments; }
        }

        internal CommonMessageProvider MessageProvider
        {
            get { return _messageProvider; }
        }

        protected override string ToFormattedString(IFormatProvider formatProvider)
        {
            return String.Format(formatProvider, "{0}: {1}",
                _messageProvider.GetMessagePrefix(this.MessageIdentifier, this.Severity, this.IsWarningAsError, formatProvider as CultureInfo),
                this.GetMessage(formatProvider));
        }

        public sealed override int GetHashCode()
        {
            int hashCode = _errorCode;
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
            DiagnosticInfoWithMessageProvider other = obj as DiagnosticInfoWithMessageProvider;

            bool result = false;

            if (other != null &&
                other._errorCode == _errorCode &&
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
            // There aren't message resources for our internal error codes, so make
            // sure we don't call ToString for those.
            switch (Code)
            {
                case InternalDiagnosticErrorCode.Unknown:
                    return "Unresolved DiagnosticInfoWithMessageProvider";

                case InternalDiagnosticErrorCode.Void:
                    return "Void DiagnosticInfoWithMessageProvider";

                default:
                    return ToString();
            }
        }
    }
}
