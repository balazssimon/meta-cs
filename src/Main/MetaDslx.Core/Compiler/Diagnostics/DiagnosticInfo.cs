// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.
// Changed for MetaDslx.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using MetaDslx.Compiler.Utilities;
using System.Threading;
using MetaDslx.Core;
using MetaDslx.Compiler.Diagnostics;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// A DiagnosticInfo object has information about a diagnostic, but without any attached location information.
    /// </summary>
    /// <remarks>
    /// More specialized diagnostics with additional information (e.g., ambiguity errors) can derive from this class to
    /// provide access to additional information about the error, such as what symbols were involved in the ambiguity.
    /// </remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public class DiagnosticInfo : IFormattable, IObjectWritable
    {
        private readonly DiagnosticDescriptor _descriptor;
        private readonly DiagnosticSeverity _effectiveSeverity;
        private readonly object[] _arguments;

        // Mark compiler errors as non-configurable to ensure they can never be suppressed or filtered.
        private static readonly ImmutableArray<string> s_compilerErrorCustomTags = ImmutableArray.Create(WellKnownDiagnosticTags.Compiler, WellKnownDiagnosticTags.Telemetry, WellKnownDiagnosticTags.NotConfigurable);
        private static readonly ImmutableArray<string> s_compilerNonErrorCustomTags = ImmutableArray.Create(WellKnownDiagnosticTags.Compiler, WellKnownDiagnosticTags.Telemetry);

        static DiagnosticInfo()
        {
            ObjectBinder.RegisterTypeReader(typeof(DiagnosticInfo), r => new DiagnosticInfo(r));
        }

        // Only the compiler creates instances.
        internal DiagnosticInfo(DiagnosticDescriptor descriptor)
        {
            _descriptor = descriptor;
            _effectiveSeverity = descriptor.DefaultSeverity;
        }

        // Only the compiler creates instances.
        internal DiagnosticInfo(DiagnosticDescriptor errorCode, params object[] arguments)
            : this(errorCode)
        {
            AssertMessageSerializable(arguments);

            _arguments = arguments;
        }

        private DiagnosticInfo(DiagnosticInfo original, DiagnosticSeverity overriddenSeverity)
        {
            _descriptor = original._descriptor;
            _arguments = original._arguments;

            _effectiveSeverity = overriddenSeverity;
        }

        public DiagnosticDescriptor Descriptor
        {
            get { return _descriptor; }
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
                if (type == typeof(string))
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
        internal DiagnosticInfo(bool isWarningAsError, DiagnosticDescriptor errorCode, params object[] arguments)
            : this(errorCode, arguments)
        {
            Debug.Assert(!isWarningAsError);

            if (isWarningAsError)
            {
                _effectiveSeverity = DiagnosticSeverity.Error;
            }
        }

        // Create a copy of this instance with a explicit overridden severity
        internal DiagnosticInfo GetInstanceWithSeverity(DiagnosticSeverity severity)
        {
            return new DiagnosticInfo(this, severity);
        }

        #region Serialization

        bool IObjectWritable.ShouldReuseInSerialization => false;

        void IObjectWritable.WriteTo(ObjectWriter writer)
        {
            this.WriteTo(writer);
        }

        protected virtual void WriteTo(ObjectWriter writer)
        {
            writer.WriteValue(_descriptor);
            writer.WriteInt32((int)_effectiveSeverity);

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

        protected DiagnosticInfo(ObjectReader reader)
        {
            _descriptor = (DiagnosticDescriptor)reader.ReadValue();
            _effectiveSeverity = (DiagnosticSeverity)reader.ReadInt32();

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
                return _descriptor.DefaultSeverity;
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
                return Diagnostic.GetDefaultWarningLevel(_effectiveSeverity);
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
                return _descriptor.Category;
            }
        }

        internal ImmutableArray<string> CustomTags
        {
            get
            {
                return _descriptor.CustomTags;
            }
        }

        private static ImmutableArray<string> GetCustomTags(DiagnosticSeverity defaultSeverity)
        {
            return defaultSeverity == DiagnosticSeverity.Error ?
                s_compilerErrorCustomTags :
                s_compilerNonErrorCustomTags;
        }

        internal bool IsNotConfigurable()
        {
            // Only compiler errors are non-configurable.
            return _descriptor.DefaultSeverity == DiagnosticSeverity.Error;
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
        public string MessageIdentifier
        {
            get
            {
                return _descriptor.Id;
            }
        }

        /// <summary>
        /// Get the text of the message in the given language.
        /// </summary>
        public virtual string GetMessage(IFormatProvider formatProvider = null)
        {
            // Get the message and fill in arguments.
            LocalizableString message = _descriptor.MessageFormat;
            if (message == null)
            {
                return string.Empty;
            }

            if (_arguments == null || _arguments.Length == 0)
            {
                return message.ToString(formatProvider);
            }

            return String.Format(message.ToString(formatProvider), GetArgumentsToUse(formatProvider));
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

                var symbol = _arguments[i] as ISymbol;
                if (symbol != null)
                {
                    argumentsToUse = InitializeArgumentListIfNeeded(argumentsToUse);
                    argumentsToUse[i] = symbol.ToString(); // TODO:MetaDslx:format error symbol
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

        internal object[] Arguments
        {
            get { return _arguments; }
        }

        // TODO (tomat): remove
        public override string ToString()
        {
            return ToString(null);
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return ((IFormattable)this).ToString(null, formatProvider);
        }

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return String.Format(formatProvider, "{0}: {1}",
                _descriptor.Id,
                this.GetMessage(formatProvider));
        }

        public sealed override int GetHashCode()
        {
            int hashCode = _descriptor.GetHashCode();
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
                other._descriptor == _descriptor &&
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
