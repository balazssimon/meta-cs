// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    using MessageProvider = Microsoft.CodeAnalysis.CSharp.MessageProvider;

    /// <summary>
    /// Represents various options that affect compilation, such as 
    /// whether to emit an executable or a library, whether to optimize
    /// generated code, and so on.
    /// </summary>
    public abstract class LanguageCompilationOptions : CompilationOptionsAdapter, IEquatable<LanguageCompilationOptions>
    {
        /// <summary>
        /// Allow unsafe regions (i.e. unsafe modifiers on members and unsafe blocks).
        /// </summary>
        public bool AllowUnsafe { get; private set; }

        /// <summary>
        /// Global namespace usings.
        /// </summary>
        public ImmutableArray<string> Usings { get; private set; }

        /// <summary>
        /// Flags applied to the top-level binder created for each syntax tree in the compilation 
        /// as well as for the binder of global imports.
        /// </summary>
        public BinderFlags TopLevelBinderFlags { get; private set; }

        /// <summary>
        /// Gets the source language.
        /// </summary>
        public new Language Language { get; private set; }

        protected override Language LanguageCore => this.Language;

        /// <summary>
        /// Global Nullable context options.
        /// </summary>
        public override NullableContextOptions NullableContextOptions { get; protected set; }

        // Defaults correspond to the compiler's defaults or indicate that the user did not specify when that is significant.
        // That's significant when one option depends on another's setting. SubsystemVersion depends on Platform and Target.
        public LanguageCompilationOptions(
            Language language,
            OutputKind outputKind,
            bool reportSuppressedDiagnostics = false,
            string? moduleName = null,
            string? mainTypeName = null,
            string? scriptClassName = null,
            IEnumerable<string>? usings = null,
            OptimizationLevel optimizationLevel = OptimizationLevel.Debug,
            bool checkOverflow = false,
            bool allowUnsafe = false,
            string? cryptoKeyContainer = null,
            string? cryptoKeyFile = null,
            ImmutableArray<byte> cryptoPublicKey = default,
            bool? delaySign = null,
            Platform platform = Platform.AnyCpu,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            int warningLevel = Diagnostic.DefaultWarningLevel,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>>? specificDiagnosticOptions = null,
            bool concurrentBuild = true,
            bool deterministic = false,
            XmlReferenceResolver? xmlReferenceResolver = null,
            SourceReferenceResolver? sourceReferenceResolver = null,
            MetadataReferenceResolver? metadataReferenceResolver = null,
            AssemblyIdentityComparer? assemblyIdentityComparer = null,
            StrongNameProvider? strongNameProvider = null,
            bool publicSign = false,
            MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public,
            NullableContextOptions nullableContextOptions = NullableContextOptions.Disable)
            : this(outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName,
                   usings, optimizationLevel, checkOverflow, allowUnsafe,
                   cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform,
                   generalDiagnosticOption, warningLevel,
                   specificDiagnosticOptions, concurrentBuild, deterministic,
                   currentLocalTime: default,
                   debugPlusMode: false,
                   xmlReferenceResolver: xmlReferenceResolver,
                   sourceReferenceResolver: sourceReferenceResolver,
                   syntaxTreeOptionsProvider: null,
                   metadataReferenceResolver: metadataReferenceResolver,
                   assemblyIdentityComparer: assemblyIdentityComparer,
                   strongNameProvider: strongNameProvider,
                   metadataImportOptions: metadataImportOptions,
                   referencesSupersedeLowerVersions: false,
                   publicSign: publicSign,
                   topLevelBinderFlags: BinderFlags.None,
                   nullableContextOptions: nullableContextOptions)
        {
        }

        // Expects correct arguments.
        private LanguageCompilationOptions(
            OutputKind outputKind,
            bool reportSuppressedDiagnostics,
            string? moduleName,
            string? mainTypeName,
            string? scriptClassName,
            IEnumerable<string>? usings,
            OptimizationLevel optimizationLevel,
            bool checkOverflow,
            bool allowUnsafe,
            string? cryptoKeyContainer,
            string? cryptoKeyFile,
            ImmutableArray<byte> cryptoPublicKey,
            bool? delaySign,
            Platform platform,
            ReportDiagnostic generalDiagnosticOption,
            int warningLevel,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>>? specificDiagnosticOptions,
            bool concurrentBuild,
            bool deterministic,
            DateTime currentLocalTime,
            bool debugPlusMode,
            XmlReferenceResolver? xmlReferenceResolver,
            SourceReferenceResolver? sourceReferenceResolver,
            SyntaxTreeOptionsProvider? syntaxTreeOptionsProvider,
            MetadataReferenceResolver? metadataReferenceResolver,
            AssemblyIdentityComparer? assemblyIdentityComparer,
            StrongNameProvider? strongNameProvider,
            MetadataImportOptions metadataImportOptions,
            bool referencesSupersedeLowerVersions,
            bool publicSign,
            BinderFlags topLevelBinderFlags,
            NullableContextOptions nullableContextOptions)
            : base(outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName,
                   cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, publicSign, optimizationLevel, checkOverflow,
                   platform, generalDiagnosticOption, warningLevel, specificDiagnosticOptions.ToImmutableDictionaryOrEmpty(),
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, syntaxTreeOptionsProvider, metadataReferenceResolver,
                   assemblyIdentityComparer, strongNameProvider, metadataImportOptions, referencesSupersedeLowerVersions)
        {
            this.Usings = usings.AsImmutableOrEmpty();
            this.AllowUnsafe = allowUnsafe;
            this.TopLevelBinderFlags = topLevelBinderFlags;
            this.NullableContextOptions = nullableContextOptions;
        }

        protected LanguageCompilationOptions(LanguageCompilationOptions other) : this(
            outputKind: other.OutputKind,
            moduleName: other.ModuleName,
            mainTypeName: other.MainTypeName,
            scriptClassName: other.ScriptClassName,
            usings: other.Usings,
            optimizationLevel: other.OptimizationLevel,
            checkOverflow: other.CheckOverflow,
            allowUnsafe: other.AllowUnsafe,
            cryptoKeyContainer: other.CryptoKeyContainer,
            cryptoKeyFile: other.CryptoKeyFile,
            cryptoPublicKey: other.CryptoPublicKey,
            delaySign: other.DelaySign,
            platform: other.Platform,
            generalDiagnosticOption: other.GeneralDiagnosticOption,
            warningLevel: other.WarningLevel,
            specificDiagnosticOptions: other.SpecificDiagnosticOptions,
            concurrentBuild: other.ConcurrentBuild,
            deterministic: other.Deterministic,
            currentLocalTime: other.CurrentLocalTime,
            debugPlusMode: other.DebugPlusMode,
            xmlReferenceResolver: other.XmlReferenceResolver,
            sourceReferenceResolver: other.SourceReferenceResolver,
            syntaxTreeOptionsProvider: other.SyntaxTreeOptionsProvider,
            metadataReferenceResolver: other.MetadataReferenceResolver,
            assemblyIdentityComparer: other.AssemblyIdentityComparer,
            strongNameProvider: other.StrongNameProvider,
            metadataImportOptions: other.MetadataImportOptions,
            referencesSupersedeLowerVersions: other.ReferencesSupersedeLowerVersions,
            reportSuppressedDiagnostics: other.ReportSuppressedDiagnostics,
            publicSign: other.PublicSign,
            topLevelBinderFlags: other.TopLevelBinderFlags,
            nullableContextOptions: other.NullableContextOptions)
        {
        }

        public Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions ToCSharp()
        {
            return new Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions(
                outputKind: this.OutputKind,
                moduleName: this.ModuleName,
                mainTypeName: this.MainTypeName,
                scriptClassName: this.ScriptClassName,
                usings: this.Usings,
                optimizationLevel: this.OptimizationLevel,
                checkOverflow: this.CheckOverflow,
                allowUnsafe: this.AllowUnsafe,
                cryptoKeyContainer: this.CryptoKeyContainer,
                cryptoKeyFile: this.CryptoKeyFile,
                cryptoPublicKey: this.CryptoPublicKey,
                delaySign: this.DelaySign,
                platform: this.Platform,
                generalDiagnosticOption: this.GeneralDiagnosticOption,
                warningLevel: this.WarningLevel,
                specificDiagnosticOptions: this.SpecificDiagnosticOptions,
                concurrentBuild: this.ConcurrentBuild,
                deterministic: this.Deterministic,
                currentLocalTime: this.CurrentLocalTime,
                debugPlusMode: this.DebugPlusMode,
                xmlReferenceResolver: this.XmlReferenceResolver,
                sourceReferenceResolver: this.SourceReferenceResolver,
                syntaxTreeOptionsProvider: this.SyntaxTreeOptionsProvider,
                metadataReferenceResolver: this.MetadataReferenceResolver,
                assemblyIdentityComparer: this.AssemblyIdentityComparer,
                strongNameProvider: this.StrongNameProvider,
                metadataImportOptions: this.MetadataImportOptions,
                referencesSupersedeLowerVersions: this.ReferencesSupersedeLowerVersions,
                reportSuppressedDiagnostics: this.ReportSuppressedDiagnostics,
                publicSign: this.PublicSign,
                topLevelBinderFlags: this.TopLevelBinderFlags.ToCSharp(),
                nullableContextOptions: this.NullableContextOptions);
        }


        protected abstract LanguageCompilationOptions Clone();

        public LanguageCompilationOptions WithTopLevelBinderFlags(BinderFlags flags)
        {
            if (flags == TopLevelBinderFlags)
            {
                return this;
            }
            var clone = this.Clone();
            clone.TopLevelBinderFlags = flags;
            return clone;
        }

        internal override ImmutableArray<string> GetImports() => Usings;

        public new LanguageCompilationOptions WithOutputKind(OutputKind kind)
        {
            if (kind == this.OutputKind)
            {
                return this;
            }
            var clone = this.Clone();
            clone.OutputKind = kind;
            return clone;
        }

        public new LanguageCompilationOptions WithModuleName(string? moduleName)
        {
            if (moduleName == this.ModuleName)
            {
                return this;
            }
            var clone = this.Clone();
            clone.ModuleName = moduleName;
            return clone;
        }

        public new LanguageCompilationOptions WithScriptClassName(string? name)
        {
            if (name == this.ScriptClassName)
            {
                return this;
            }
            var clone = this.Clone();
            clone.ScriptClassName = name;
            return clone;
        }

        public new LanguageCompilationOptions WithMainTypeName(string? name)
        {
            if (name == this.MainTypeName)
            {
                return this;
            }
            var clone = this.Clone();
            clone.MainTypeName = name;
            return clone;
        }

        public new LanguageCompilationOptions WithCryptoKeyContainer(string? name)
        {
            if (name == this.CryptoKeyContainer)
            {
                return this;
            }
            var clone = this.Clone();
            clone.CryptoKeyContainer = name;
            return clone;
        }

        public new LanguageCompilationOptions WithCryptoKeyFile(string? path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = null;
            }

            if (path == this.CryptoKeyFile)
            {
                return this;
            }

            var clone = this.Clone();
            clone.CryptoKeyFile = path;
            return clone;
        }

        public new LanguageCompilationOptions WithCryptoPublicKey(ImmutableArray<byte> value)
        {
            if (value.IsDefault)
            {
                value = ImmutableArray<byte>.Empty;
            }

            if (value == this.CryptoPublicKey)
            {
                return this;
            }

            var clone = this.Clone();
            clone.CryptoPublicKey = value;
            return clone;
        }

        public new LanguageCompilationOptions WithDelaySign(bool? value)
        {
            if (value == this.DelaySign)
            {
                return this;
            }

            var clone = this.Clone();
            clone.DelaySign = value;
            return clone;
        }

        public LanguageCompilationOptions WithUsings(ImmutableArray<string> usings)
        {
            if (this.Usings == usings)
            {
                return this;
            }

            var clone = this.Clone();
            clone.Usings = usings;
            return clone;
        }

        public LanguageCompilationOptions WithUsings(IEnumerable<string>? usings) => WithUsings(usings.AsImmutableOrEmpty());

        public LanguageCompilationOptions WithUsings(params string[]? usings) => WithUsings((IEnumerable<string>?)usings);

        public new LanguageCompilationOptions WithOptimizationLevel(OptimizationLevel value)
        {
            if (value == this.OptimizationLevel)
            {
                return this;
            }

            var clone = this.Clone();
            clone.OptimizationLevel = value;
            return clone;
        }

        public new LanguageCompilationOptions WithOverflowChecks(bool enabled)
        {
            if (enabled == this.CheckOverflow)
            {
                return this;
            }

            var clone = this.Clone();
            clone.CheckOverflow = enabled;
            return clone;
        }

        public LanguageCompilationOptions WithNullableContextOptions(NullableContextOptions options)
        {
            if (options == this.NullableContextOptions)
            {
                return this;
            }

            var clone = this.Clone();
            clone.NullableContextOptions = options;
            return clone;
        }

        public LanguageCompilationOptions WithAllowUnsafe(bool enabled)
        {
            if (enabled == this.AllowUnsafe)
            {
                return this;
            }

            var clone = this.Clone();
            clone.AllowUnsafe = enabled;
            return clone;
        }

        public new LanguageCompilationOptions WithPlatform(Platform platform)
        {
            if (this.Platform == platform)
            {
                return this;
            }

            var clone = this.Clone();
            clone.Platform = platform;
            return clone;
        }

        public new LanguageCompilationOptions WithPublicSign(bool publicSign)
        {
            if (this.PublicSign == publicSign)
            {
                return this;
            }

            var clone = this.Clone();
            clone.PublicSign = publicSign;
            return clone;
        }

        protected override CompilationOptions CommonWithGeneralDiagnosticOption(ReportDiagnostic value) => WithGeneralDiagnosticOption(value);

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic>? specificDiagnosticOptions) =>
            WithSpecificDiagnosticOptions(specificDiagnosticOptions);

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>>? specificDiagnosticOptions) =>
            WithSpecificDiagnosticOptions(specificDiagnosticOptions);

        protected override CompilationOptions CommonWithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics) =>
            WithReportSuppressedDiagnostics(reportSuppressedDiagnostics);

        public new LanguageCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value)
        {
            if (this.GeneralDiagnosticOption == value)
            {
                return this;
            }

            var clone = this.Clone();
            clone.GeneralDiagnosticOption = value;
            return clone;
        }

        public new LanguageCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic>? values)
        {
            if (values == null)
            {
                values = ImmutableDictionary<string, ReportDiagnostic>.Empty;
            }

            if (this.SpecificDiagnosticOptions == values)
            {
                return this;
            }

            var clone = this.Clone();
            clone.SpecificDiagnosticOptions = values;
            return clone;
        }

        public new LanguageCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>>? values) =>
            WithSpecificDiagnosticOptions(values.ToImmutableDictionaryOrEmpty());

        public new LanguageCompilationOptions WithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            if (reportSuppressedDiagnostics == this.ReportSuppressedDiagnostics)
            {
                return this;
            }

            var clone = this.Clone();
            clone.ReportSuppressedDiagnostics = reportSuppressedDiagnostics;
            return clone;
        }

        public LanguageCompilationOptions WithWarningLevel(int warningLevel)
        {
            if (warningLevel == this.WarningLevel)
            {
                return this;
            }

            var clone = this.Clone();
            clone.WarningLevel = warningLevel;
            return clone;
        }

        public new LanguageCompilationOptions WithConcurrentBuild(bool concurrentBuild)
        {
            if (concurrentBuild == this.ConcurrentBuild)
            {
                return this;
            }

            var clone = this.Clone();
            clone.ConcurrentBuild = concurrentBuild;
            return clone;
        }

        public new LanguageCompilationOptions WithDeterministic(bool deterministic)
        {
            if (deterministic == this.Deterministic)
            {
                return this;
            }

            var clone = this.Clone();
            clone.Deterministic = deterministic;
            return clone;
        }

        internal LanguageCompilationOptions WithCurrentLocalTime(DateTime value)
        {
            if (value == this.CurrentLocalTime)
            {
                return this;
            }

            var clone = this.Clone();
            clone.CurrentLocalTime = value;
            return clone;
        }

        internal LanguageCompilationOptions WithDebugPlusMode(bool debugPlusMode)
        {
            if (debugPlusMode == this.DebugPlusMode)
            {
                return this;
            }

            var clone = this.Clone();
            clone.DebugPlusMode = debugPlusMode;
            return clone;
        }

        public new LanguageCompilationOptions WithMetadataImportOptions(MetadataImportOptions value)
        {
            if (value == this.MetadataImportOptions)
            {
                return this;
            }

            var clone = this.Clone();
            clone.MetadataImportOptions = value;
            return clone;
        }

        public LanguageCompilationOptions WithReferencesSupersedeLowerVersions(bool value)
        {
            if (value == this.ReferencesSupersedeLowerVersions)
            {
                return this;
            }

            var clone = this.Clone();
            clone.ReferencesSupersedeLowerVersions = value;
            return clone;
        }

        public new LanguageCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver? resolver)
        {
            if (ReferenceEquals(resolver, this.XmlReferenceResolver))
            {
                return this;
            }

            var clone = this.Clone();
            clone.XmlReferenceResolver = resolver;
            return clone;
        }

        public new LanguageCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver? resolver)
        {
            if (ReferenceEquals(resolver, this.SourceReferenceResolver))
            {
                return this;
            }

            var clone = this.Clone();
            clone.SourceReferenceResolver = resolver;
            return clone;
        }

        public new LanguageCompilationOptions WithSyntaxTreeOptionsProvider(SyntaxTreeOptionsProvider? provider)
        {
            if (ReferenceEquals(provider, this.SyntaxTreeOptionsProvider))
            {
                return this;
            }

            var clone = this.Clone();
            clone.SyntaxTreeOptionsProvider = provider;
            return clone;
        }

        public new LanguageCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver? resolver)
        {
            if (ReferenceEquals(resolver, this.MetadataReferenceResolver))
            {
                return this;
            }

            var clone = this.Clone();
            clone.MetadataReferenceResolver = resolver;
            return clone;
        }

        public new LanguageCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer? comparer)
        {
            comparer = comparer ?? AssemblyIdentityComparer.Default;

            if (ReferenceEquals(comparer, this.AssemblyIdentityComparer))
            {
                return this;
            }

            var clone = this.Clone();
            clone.AssemblyIdentityComparer = comparer;
            return clone;
        }

        public new LanguageCompilationOptions WithStrongNameProvider(StrongNameProvider? provider)
        {
            if (ReferenceEquals(provider, this.StrongNameProvider))
            {
                return this;
            }

            var clone = this.Clone();
            clone.StrongNameProvider = provider;
            return clone;
        }

        protected override CompilationOptions CommonWithConcurrentBuild(bool concurrent) => WithConcurrentBuild(concurrent);
        protected override CompilationOptions CommonWithDeterministic(bool deterministic) => WithDeterministic(deterministic);

        protected override CompilationOptions CommonWithOutputKind(OutputKind kind) => WithOutputKind(kind);

        protected override CompilationOptions CommonWithPlatform(Platform platform) => WithPlatform(platform);

        protected override CompilationOptions CommonWithPublicSign(bool publicSign) => WithPublicSign(publicSign);

        protected override CompilationOptions CommonWithOptimizationLevel(OptimizationLevel value) => WithOptimizationLevel(value);

        protected override CompilationOptions CommonWithAssemblyIdentityComparer(AssemblyIdentityComparer? comparer) =>
            WithAssemblyIdentityComparer(comparer);

        protected override CompilationOptions CommonWithXmlReferenceResolver(XmlReferenceResolver? resolver) =>
            WithXmlReferenceResolver(resolver);

        protected override CompilationOptions CommonWithSourceReferenceResolver(SourceReferenceResolver? resolver) =>
            WithSourceReferenceResolver(resolver);

        protected override CompilationOptions CommonWithSyntaxTreeOptionsProvider(SyntaxTreeOptionsProvider? provider)
            => WithSyntaxTreeOptionsProvider(provider);

        protected override CompilationOptions CommonWithMetadataReferenceResolver(MetadataReferenceResolver? resolver) =>
            WithMetadataReferenceResolver(resolver);

        protected override CompilationOptions CommonWithStrongNameProvider(StrongNameProvider? provider) =>
            WithStrongNameProvider(provider);

        protected override CompilationOptions CommonWithMetadataImportOptions(MetadataImportOptions value) =>
            WithMetadataImportOptions(value);

        [Obsolete]
        protected override CompilationOptions CommonWithFeatures(ImmutableArray<string> features)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateOptionsCore(ArrayBuilder<Diagnostic> builder)
        {
            this.ValidateOptions(builder);
        }

        protected virtual void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            ValidateOptions(builder, MessageProvider.Instance);

            //  /main & /target:{library|netmodule|winmdobj}
            if (this.MainTypeName != null)
            {
                if (this.OutputKind.IsValid() && !this.OutputKind.IsApplication())
                {
                    builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_NoMainOnDLL));
                }

                if (!MainTypeName.IsValidClrTypeName())
                {
                    builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(MainTypeName), MainTypeName));
                }
            }

            if (!Platform.IsValid())
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadPlatformType, Platform.ToString()));
            }

            if (ModuleName != null)
            {
                MetadataHelpers.CheckAssemblyOrModuleName(ModuleName, MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadModuleName, builder);
            }

            if (!OutputKind.IsValid())
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(OutputKind), OutputKind.ToString()));
            }

            if (!OptimizationLevel.IsValid())
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(OptimizationLevel), OptimizationLevel.ToString()));
            }

            if (ScriptClassName == null || !ScriptClassName.IsValidClrTypeName())
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(ScriptClassName), ScriptClassName ?? "null"));
            }

            if (WarningLevel < 0)
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(WarningLevel), WarningLevel));
            }

            if (Usings != null && Usings.Any(u => !u.IsValidClrNamespaceName()))
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(Usings), Usings.Where(u => !u.IsValidClrNamespaceName()).First() ?? "null"));
            }

            if (Platform == Platform.AnyCpu32BitPreferred && OutputKind.IsValid() && !(OutputKind == OutputKind.ConsoleApplication || OutputKind == OutputKind.WindowsApplication || OutputKind == OutputKind.WindowsRuntimeApplication))
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadPrefer32OnLib));
            }

            if (!MetadataImportOptions.IsValid())
            {
                builder.Add(Diagnostic.Create(MessageProvider.Instance, (int)Microsoft.CodeAnalysis.CSharp.ErrorCode.ERR_BadCompilationOptionValue, nameof(MetadataImportOptions), MetadataImportOptions.ToString()));
            }

            // TODO: add check for 
            //          (kind == 'arm' || kind == 'appcontainer' || kind == 'winmdobj') &&
            //          (version >= "6.2")
        }

        public bool Equals(LanguageCompilationOptions? other)
        {
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (!base.EqualsHelper(other))
            {
                return false;
            }

            return this.AllowUnsafe == other.AllowUnsafe &&
                   this.TopLevelBinderFlags == other.TopLevelBinderFlags &&
                   (this.Usings == null ? other.Usings == null : this.Usings.SequenceEqual(other.Usings, StringComparer.Ordinal) &&
                   this.NullableContextOptions == other.NullableContextOptions);
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as LanguageCompilationOptions);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(base.GetHashCodeHelper(),
                   Hash.Combine(this.AllowUnsafe,
                   Hash.Combine(Hash.CombineValues(this.Usings, StringComparer.Ordinal),
                   Hash.Combine(TopLevelBinderFlags.GetHashCode(), this.NullableContextOptions.GetHashCode()))));
        }

        protected new virtual Diagnostic? FilterDiagnostic(Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            return LanguageDiagnosticFilter.Filter(
                diagnostic,
                WarningLevel,
                NullableContextOptions,
                GeneralDiagnosticOption,
                SpecificDiagnosticOptions,
                SyntaxTreeOptionsProvider,
                cancellationToken);
        }

        internal override Diagnostic? FilterDiagnosticCore(Diagnostic diagnostic, CancellationToken cancellationToken)
        {
            return this.FilterDiagnostic(diagnostic, cancellationToken);
        }

        protected override CompilationOptions CommonWithModuleName(string? moduleName)
        {
            return WithModuleName(moduleName);
        }

        protected override CompilationOptions CommonWithMainTypeName(string? mainTypeName)
        {
            return WithMainTypeName(mainTypeName);
        }

        protected override CompilationOptions CommonWithScriptClassName(string? scriptClassName)
        {
            return WithScriptClassName(scriptClassName);
        }

        protected override CompilationOptions CommonWithCryptoKeyContainer(string? cryptoKeyContainer)
        {
            return WithCryptoKeyContainer(cryptoKeyContainer);
        }

        protected override CompilationOptions CommonWithCryptoKeyFile(string? cryptoKeyFile)
        {
            return WithCryptoKeyFile(cryptoKeyFile);
        }

        protected override CompilationOptions CommonWithCryptoPublicKey(ImmutableArray<byte> cryptoPublicKey)
        {
            return WithCryptoPublicKey(cryptoPublicKey);
        }

        protected override CompilationOptions CommonWithDelaySign(bool? delaySign)
        {
            return WithDelaySign(delaySign);
        }

        protected override CompilationOptions CommonWithCheckOverflow(bool checkOverflow)
        {
            return WithOverflowChecks(checkOverflow);
        }

    }
}
