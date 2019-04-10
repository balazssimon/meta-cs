// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Represents compilation options common to C# and VB.
    /// </summary>
    public abstract class CompilationOptions
    {
        /// <summary>
        /// Name of the model, or null if a default name should be used.
        /// </summary>
        public string ModelName { get; protected set; }

        /// <summary>
        /// The full name of a global implicit class (script class). This class implicitly encapsulates top-level statements, 
        /// type declarations, and member declarations. Could be a namespace qualified name.
        /// </summary>
        public string ScriptClassName { get; protected set; }

        /// <summary>
        /// The full name of a type that declares static Main method. Must be a valid non-generic namespace-qualified name.
        /// Null if any static Main method is a candidate for an entry point.
        /// </summary>
        public string MainTypeName { get; protected set; }

        // Note that we avoid using default(ImmutableArray<byte>) for unspecified value since 
        // such value is currently not serializable by JSON serializer.

        /// <summary>
        /// Global warning report option
        /// </summary>
        public ReportDiagnostic GeneralDiagnosticOption { get; protected set; }

        /// <summary>
        /// Global warning level (from 0 to 4).
        /// </summary>
        public int WarningLevel { get; protected set; }

        /// <summary>
        /// Specifies whether building compilation may use multiple threads.
        /// </summary>
        public bool ConcurrentBuild { get; protected set; }

        /// <summary>
        /// Specifies whether the compilation should be deterministic.
        /// </summary>
        public bool Deterministic { get; protected set; }

        /// <summary>
        /// Used for time-based version generation when <see cref="System.Reflection.AssemblyVersionAttribute"/> contains a wildcard.
        /// If equal to default(<see cref="DateTime"/>) the actual current local time will be used.
        /// </summary>
        public DateTime CurrentLocalTime { get; protected set; }

        /// <summary>
        /// Apply additional disambiguation rules during resolution of referenced assemblies.
        /// </summary>
        public bool ReferencesSupersedeLowerVersions { get; protected set; }

        /// <summary>
        /// Modifies the incoming diagnostic, for example escalating its severity, or discarding it (returning null) based on the compilation options.
        /// </summary>
        /// <param name="diagnostic"></param>
        /// <returns>The modified diagnostic, or null</returns>
        public abstract Diagnostic FilterDiagnostic(Diagnostic diagnostic);

        /// <summary>
        /// Warning report option for each warning.
        /// </summary>
        public ImmutableDictionary<string, ReportDiagnostic> SpecificDiagnosticOptions { get; protected set; }

        /// <summary>
        /// Whether diagnostics suppressed in source, i.e. <see cref="Diagnostic.IsSuppressed"/> is true, should be reported.
        /// </summary>
        public bool ReportSuppressedDiagnostics { get; protected set; }

        /// <summary>
        /// Resolves paths to metadata references specified in source via #r directives.
        /// Null if the compilation can't contain references to metadata other than those explicitly passed to its factory (such as #r directives in sources). 
        /// </summary>
        public MetadataReferenceResolver MetadataReferenceResolver { get; protected set; }

        /// <summary>
        /// Gets the resolver for resolving source document references for the compilation.
        /// Null if the compilation is not allowed to contain source file references, such as #line pragmas and #load directives.
        /// </summary>
        public SourceReferenceResolver SourceReferenceResolver { get; protected set; }

        /// <summary>
        /// Used to compare assembly identities. May implement unification and portability policies specific to the target platform.
        /// <see cref="AssemblyIdentityComparer.Default"/> if not specified.
        /// </summary>
        public ModelIdentityComparer ModelIdentityComparer { get; protected set; }

        private readonly Lazy<ImmutableArray<Diagnostic>> _lazyErrors;

        // Expects correct arguments.
        internal CompilationOptions(
            bool reportSuppressedDiagnostics,
            string modelName,
            string mainTypeName,
            string scriptClassName,
            ReportDiagnostic generalDiagnosticOption,
            int warningLevel,
            ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions,
            bool concurrentBuild,
            bool deterministic,
            DateTime currentLocalTime,
            SourceReferenceResolver sourceReferenceResolver,
            MetadataReferenceResolver metadataReferenceResolver,
            ModelIdentityComparer modelIdentityComparer,
            bool referencesSupersedeLowerVersions)
        {
            this.ModelName = modelName;
            this.MainTypeName = mainTypeName;
            this.ScriptClassName = scriptClassName ?? WellKnownMemberNames.DefaultScriptClassName;
            this.GeneralDiagnosticOption = generalDiagnosticOption;
            this.WarningLevel = warningLevel;
            this.SpecificDiagnosticOptions = specificDiagnosticOptions;
            this.ReportSuppressedDiagnostics = reportSuppressedDiagnostics;
            this.ConcurrentBuild = concurrentBuild;
            this.Deterministic = deterministic;
            this.CurrentLocalTime = currentLocalTime;
            this.SourceReferenceResolver = sourceReferenceResolver;
            this.MetadataReferenceResolver = metadataReferenceResolver;
            this.ReferencesSupersedeLowerVersions = referencesSupersedeLowerVersions;

            _lazyErrors = new Lazy<ImmutableArray<Diagnostic>>(() =>
            {
                var builder = ArrayBuilder<Diagnostic>.GetInstance();
                ValidateOptions(builder);
                return builder.ToImmutableAndFree();
            });
        }

        internal bool CanReuseCompilationReferenceManager(CompilationOptions other)
        {
            // This condition has to include all options the Assembly Manager depends on when binding references.
            // In addition, the assembly name is determined based upon output kind. It is special for netmodules.
            // Can't reuse when file resolver or identity comparers change.
            // Can reuse even if StrongNameProvider changes. When resolving a cyclic reference only the simple name is considered, not the strong name.
            return this.ReferencesSupersedeLowerVersions == other.ReferencesSupersedeLowerVersions
                && object.Equals(this.MetadataReferenceResolver, other.MetadataReferenceResolver)
                && object.Equals(this.ModelIdentityComparer, other.ModelIdentityComparer);
        }

        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        public abstract Language Language { get; }

        internal abstract ImmutableArray<string> GetImports();

        /// <summary>
        /// Creates a new options instance with the specified general diagnostic option.
        /// </summary>
        public CompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value)
        {
            return CommonWithGeneralDiagnosticOption(value);
        }

        /// <summary>
        /// Creates a new options instance with the specified diagnostic-specific options.
        /// </summary>
        public CompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> value)
        {
            return CommonWithSpecificDiagnosticOptions(value);
        }

        /// <summary>
        /// Creates a new options instance with the specified diagnostic-specific options.
        /// </summary>
        public CompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> value)
        {
            return CommonWithSpecificDiagnosticOptions(value);
        }

        /// <summary>
        /// Creates a new options instance with the specified suppressed diagnostics reporting option.
        /// </summary>
        public CompilationOptions WithReportSuppressedDiagnostics(bool value)
        {
            return CommonWithReportSuppressedDiagnostics(value);
        }

        /// <summary>
        /// Creates a new options instance with the concurrent build property set accordingly.
        /// </summary>
        public CompilationOptions WithConcurrentBuild(bool concurrent)
        {
            return CommonWithConcurrentBuild(concurrent);
        }

        /// <summary>
        /// Creates a new options instance with the deterministic property set accordingly.
        /// </summary>
        public CompilationOptions WithDeterministic(bool deterministic)
        {
            return CommonWithDeterministic(deterministic);
        }

        public CompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            return CommonWithSourceReferenceResolver(resolver);
        }

        public CompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            return CommonWithMetadataReferenceResolver(resolver);
        }

        public CompilationOptions WithModelIdentityComparer(ModelIdentityComparer comparer)
        {
            return CommonWithModelIdentityComparer(comparer);
        }

        public CompilationOptions WithModelName(string modelName)
        {
            return CommonWithModelName(modelName);
        }

        public CompilationOptions WithMainTypeName(string mainTypeName)
        {
            return CommonWithMainTypeName(mainTypeName);
        }

        public CompilationOptions WithScriptClassName(string scriptClassName)
        {
            return CommonWithScriptClassName(scriptClassName);
        }

        protected abstract CompilationOptions CommonWithConcurrentBuild(bool concurrent);
        protected abstract CompilationOptions CommonWithDeterministic(bool deterministic);
        protected abstract CompilationOptions CommonWithSourceReferenceResolver(SourceReferenceResolver resolver);
        protected abstract CompilationOptions CommonWithMetadataReferenceResolver(MetadataReferenceResolver resolver);
        protected abstract CompilationOptions CommonWithModelIdentityComparer(ModelIdentityComparer comparer);
        protected abstract CompilationOptions CommonWithGeneralDiagnosticOption(ReportDiagnostic generalDiagnosticOption);
        protected abstract CompilationOptions CommonWithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions);
        protected abstract CompilationOptions CommonWithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions);
        protected abstract CompilationOptions CommonWithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics);
        protected abstract CompilationOptions CommonWithModelName(string modelName);
        protected abstract CompilationOptions CommonWithMainTypeName(string mainTypeName);
        protected abstract CompilationOptions CommonWithScriptClassName(string scriptClassName);

        /// <summary>
        /// Performs validation of options compatibilities and generates diagnostics if needed
        /// </summary>
        protected abstract void ValidateOptions(ArrayBuilder<Diagnostic> builder);

        /// <summary>
        /// Errors collection related to an incompatible set of compilation options
        /// </summary>
        public ImmutableArray<Diagnostic> Errors
        {
            get { return _lazyErrors.Value; }
        }

        public abstract override bool Equals(object obj);

        protected bool EqualsHelper(CompilationOptions other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            // NOTE: StringComparison.Ordinal is used for type name comparisons, even for VB.  That's because
            // a change in the canonical case should still change the option.
            bool equal =
                   this.ConcurrentBuild == other.ConcurrentBuild &&
                   this.Deterministic == other.Deterministic &&
                   this.CurrentLocalTime == other.CurrentLocalTime &&
                   this.GeneralDiagnosticOption == other.GeneralDiagnosticOption &&
                   string.Equals(this.MainTypeName, other.MainTypeName, StringComparison.Ordinal) &&
                   this.ReferencesSupersedeLowerVersions == other.ReferencesSupersedeLowerVersions &&
                   string.Equals(this.ModelName, other.ModelName, StringComparison.Ordinal) &&
                   this.ReportSuppressedDiagnostics == other.ReportSuppressedDiagnostics &&
                   string.Equals(this.ScriptClassName, other.ScriptClassName, StringComparison.Ordinal) &&
                   this.SpecificDiagnosticOptions.SequenceEqual(other.SpecificDiagnosticOptions, (left, right) => (left.Key == right.Key) && (left.Value == right.Value)) &&
                   this.WarningLevel == other.WarningLevel &&
                   object.Equals(this.MetadataReferenceResolver, other.MetadataReferenceResolver) &&
                   object.Equals(this.SourceReferenceResolver, other.SourceReferenceResolver) &&
                   object.Equals(this.ModelIdentityComparer, other.ModelIdentityComparer);

            return equal;
        }

        public abstract override int GetHashCode();

        protected int GetHashCodeHelper()
        {
            return Hash.Combine(this.ConcurrentBuild,
                   Hash.Combine(this.Deterministic,
                   Hash.Combine(this.CurrentLocalTime.GetHashCode(),
                   Hash.Combine((int)this.GeneralDiagnosticOption,
                   Hash.Combine(this.MainTypeName != null ? StringComparer.Ordinal.GetHashCode(this.MainTypeName) : 0,
                   Hash.Combine(this.ReferencesSupersedeLowerVersions,
                   Hash.Combine(this.ModelName != null ? StringComparer.Ordinal.GetHashCode(this.ModelName) : 0,
                   Hash.Combine(this.ReportSuppressedDiagnostics,
                   Hash.Combine(this.ScriptClassName != null ? StringComparer.Ordinal.GetHashCode(this.ScriptClassName) : 0,
                   Hash.Combine(Hash.CombineValues(this.SpecificDiagnosticOptions),
                   Hash.Combine(this.WarningLevel,
                   Hash.Combine(this.MetadataReferenceResolver,
                   Hash.Combine(this.SourceReferenceResolver,
                   Hash.Combine(this.ModelIdentityComparer, 0))))))))))))));
        }

        public static bool operator ==(CompilationOptions left, CompilationOptions right)
        {
            return object.Equals(left, right);
        }

        public static bool operator !=(CompilationOptions left, CompilationOptions right)
        {
            return !object.Equals(left, right);
        }
    }
}
