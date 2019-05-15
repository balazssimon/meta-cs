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

namespace MetaDslx.CodeAnalysis
{
    using MessageProvider = Microsoft.CodeAnalysis.CSharp.MessageProvider;

    /// <summary>
    /// Represents various options that affect compilation, such as 
    /// whether to emit an executable or a library, whether to optimize
    /// generated code, and so on.
    /// </summary>
    public class LanguageCompilationOptions : CompilationOptionsAdapter, IEquatable<LanguageCompilationOptions>
    {
        private readonly Language _language;

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
        internal BinderFlags TopLevelBinderFlags { get; private set; }

        // Defaults correspond to the compiler's defaults or indicate that the user did not specify when that is significant.
        // That's significant when one option depends on another's setting. SubsystemVersion depends on Platform and Target.
        public LanguageCompilationOptions(
            Language language,
            OutputKind outputKind,
            bool reportSuppressedDiagnostics = false,
            string moduleName = null,
            string mainTypeName = null,
            string scriptClassName = null,
            IEnumerable<string> usings = null,
            OptimizationLevel optimizationLevel = OptimizationLevel.Debug,
            bool checkOverflow = false,
            bool allowUnsafe = false,
            string cryptoKeyContainer = null,
            string cryptoKeyFile = null,
            ImmutableArray<byte> cryptoPublicKey = default(ImmutableArray<byte>),
            bool? delaySign = null,
            Platform platform = Platform.AnyCpu,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            int warningLevel = 4,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions = null,
            bool concurrentBuild = true,
            bool deterministic = false,
            XmlReferenceResolver xmlReferenceResolver = null,
            SourceReferenceResolver sourceReferenceResolver = null,
            MetadataReferenceResolver metadataReferenceResolver = null,
            AssemblyIdentityComparer assemblyIdentityComparer = null,
            StrongNameProvider strongNameProvider = null,
            bool publicSign = false,
            MetadataImportOptions metadataImportOptions = MetadataImportOptions.Public)
            : this(language, outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName,
                   usings, optimizationLevel, checkOverflow, allowUnsafe,
                   cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, platform,
                   generalDiagnosticOption, warningLevel,
                   specificDiagnosticOptions, concurrentBuild, deterministic,
                   currentLocalTime: default(DateTime),
                   debugPlusMode: false,
                   xmlReferenceResolver: xmlReferenceResolver,
                   sourceReferenceResolver: sourceReferenceResolver,
                   metadataReferenceResolver: metadataReferenceResolver,
                   assemblyIdentityComparer: assemblyIdentityComparer,
                   strongNameProvider: strongNameProvider,
                   metadataImportOptions: metadataImportOptions,
                   referencesSupersedeLowerVersions: false,
                   publicSign: publicSign,
                   topLevelBinderFlags: BinderFlags.None)
        {
        }

        // Expects correct arguments.
        internal LanguageCompilationOptions(
            Language language,
            OutputKind outputKind,
            bool reportSuppressedDiagnostics,
            string moduleName,
            string mainTypeName,
            string scriptClassName,
            IEnumerable<string> usings,
            OptimizationLevel optimizationLevel,
            bool checkOverflow,
            bool allowUnsafe,
            string cryptoKeyContainer,
            string cryptoKeyFile,
            ImmutableArray<byte> cryptoPublicKey,
            bool? delaySign,
            Platform platform,
            ReportDiagnostic generalDiagnosticOption,
            int warningLevel,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions,
            bool concurrentBuild,
            bool deterministic,
            DateTime currentLocalTime,
            bool debugPlusMode,
            XmlReferenceResolver xmlReferenceResolver,
            SourceReferenceResolver sourceReferenceResolver,
            MetadataReferenceResolver metadataReferenceResolver,
            AssemblyIdentityComparer assemblyIdentityComparer,
            StrongNameProvider strongNameProvider,
            MetadataImportOptions metadataImportOptions,
            bool referencesSupersedeLowerVersions,
            bool publicSign,
            BinderFlags topLevelBinderFlags)
            : base(outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName,
                   cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, publicSign, optimizationLevel, checkOverflow,
                   platform, generalDiagnosticOption, warningLevel, specificDiagnosticOptions.ToImmutableDictionaryOrEmpty(),
                   concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver,
                   sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer,
                   strongNameProvider, metadataImportOptions, referencesSupersedeLowerVersions)
        {
            _language = language;
            this.Usings = usings.AsImmutableOrEmpty();
            this.AllowUnsafe = allowUnsafe;
            this.TopLevelBinderFlags = topLevelBinderFlags;
        }

        private LanguageCompilationOptions(LanguageCompilationOptions other) : this(
            language: other.Language,
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
            metadataReferenceResolver: other.MetadataReferenceResolver,
            assemblyIdentityComparer: other.AssemblyIdentityComparer,
            strongNameProvider: other.StrongNameProvider,
            metadataImportOptions: other.MetadataImportOptions,
            referencesSupersedeLowerVersions: other.ReferencesSupersedeLowerVersions,
            reportSuppressedDiagnostics: other.ReportSuppressedDiagnostics,
            publicSign: other.PublicSign,
            topLevelBinderFlags: other.TopLevelBinderFlags)
        {
        }

        public new Language Language => this.LanguageCore;

        protected override Language LanguageCore => _language;

        internal LanguageCompilationOptions WithTopLevelBinderFlags(BinderFlags flags)
        {
            return (flags == TopLevelBinderFlags) ? this : new LanguageCompilationOptions(this) { TopLevelBinderFlags = flags };
        }

        internal override ImmutableArray<string> GetImports() => Usings;

        public new LanguageCompilationOptions WithOutputKind(OutputKind kind)
        {
            if (kind == this.OutputKind)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { OutputKind = kind };
        }

        public new LanguageCompilationOptions WithModuleName(string moduleName)
        {
            if (moduleName == this.ModuleName)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { ModuleName = moduleName };
        }

        public new LanguageCompilationOptions WithScriptClassName(string name)
        {
            if (name == this.ScriptClassName)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { ScriptClassName = name };
        }

        public new LanguageCompilationOptions WithMainTypeName(string name)
        {
            if (name == this.MainTypeName)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { MainTypeName = name };
        }

        public new LanguageCompilationOptions WithCryptoKeyContainer(string name)
        {
            if (name == this.CryptoKeyContainer)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { CryptoKeyContainer = name };
        }

        public new LanguageCompilationOptions WithCryptoKeyFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = null;
            }

            if (path == this.CryptoKeyFile)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { CryptoKeyFile = path };
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

            return new LanguageCompilationOptions(this) { CryptoPublicKey = value };
        }

        public new LanguageCompilationOptions WithDelaySign(bool? value)
        {
            if (value == this.DelaySign)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { DelaySign = value };
        }

        public LanguageCompilationOptions WithUsings(ImmutableArray<string> usings)
        {
            if (this.Usings == usings)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { Usings = usings };
        }

        public LanguageCompilationOptions WithUsings(IEnumerable<string> usings) =>
            new LanguageCompilationOptions(this) { Usings = usings.AsImmutableOrEmpty() };

        public LanguageCompilationOptions WithUsings(params string[] usings) => WithUsings((IEnumerable<string>)usings);

        public new LanguageCompilationOptions WithOptimizationLevel(OptimizationLevel value)
        {
            if (value == this.OptimizationLevel)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { OptimizationLevel = value };
        }

        public new LanguageCompilationOptions WithOverflowChecks(bool enabled)
        {
            if (enabled == this.CheckOverflow)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { CheckOverflow = enabled };
        }

        public LanguageCompilationOptions WithAllowUnsafe(bool enabled)
        {
            if (enabled == this.AllowUnsafe)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { AllowUnsafe = enabled };
        }

        public new LanguageCompilationOptions WithPlatform(Platform platform)
        {
            if (this.Platform == platform)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { Platform = platform };
        }

        public new LanguageCompilationOptions WithPublicSign(bool publicSign)
        {
            if (this.PublicSign == publicSign)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { PublicSign = publicSign };
        }

        protected override CompilationOptions CommonWithGeneralDiagnosticOption(ReportDiagnostic value) => WithGeneralDiagnosticOption(value);

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions) =>
            WithSpecificDiagnosticOptions(specificDiagnosticOptions);

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions) =>
            WithSpecificDiagnosticOptions(specificDiagnosticOptions);

        protected override CompilationOptions CommonWithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics) =>
            WithReportSuppressedDiagnostics(reportSuppressedDiagnostics);

        public new LanguageCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic value)
        {
            if (this.GeneralDiagnosticOption == value)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { GeneralDiagnosticOption = value };
        }

        public new LanguageCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> values)
        {
            if (values == null)
            {
                values = ImmutableDictionary<string, ReportDiagnostic>.Empty;
            }

            if (this.SpecificDiagnosticOptions == values)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { SpecificDiagnosticOptions = values };
        }

        public new LanguageCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> values) =>
            new LanguageCompilationOptions(this) { SpecificDiagnosticOptions = values.ToImmutableDictionaryOrEmpty() };

        public new LanguageCompilationOptions WithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            if (reportSuppressedDiagnostics == this.ReportSuppressedDiagnostics)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { ReportSuppressedDiagnostics = reportSuppressedDiagnostics };
        }

        public LanguageCompilationOptions WithWarningLevel(int warningLevel)
        {
            if (warningLevel == this.WarningLevel)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { WarningLevel = warningLevel };
        }

        public new LanguageCompilationOptions WithConcurrentBuild(bool concurrentBuild)
        {
            if (concurrentBuild == this.ConcurrentBuild)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { ConcurrentBuild = concurrentBuild };
        }

        public new LanguageCompilationOptions WithDeterministic(bool deterministic)
        {
            if (deterministic == this.Deterministic)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { Deterministic = deterministic };
        }

        internal LanguageCompilationOptions WithCurrentLocalTime(DateTime value)
        {
            if (value == this.CurrentLocalTime)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { CurrentLocalTime_internal_protected_set = value };
        }

        internal LanguageCompilationOptions WithDebugPlusMode(bool debugPlusMode)
        {
            if (debugPlusMode == this.DebugPlusMode)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { DebugPlusMode_internal_protected_set = debugPlusMode };
        }

        public new LanguageCompilationOptions WithMetadataImportOptions(MetadataImportOptions value)
        {
            if (value == this.MetadataImportOptions)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { MetadataImportOptions = value };
        }

        internal LanguageCompilationOptions WithReferencesSupersedeLowerVersions(bool value)
        {
            if (value == this.ReferencesSupersedeLowerVersions)
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { ReferencesSupersedeLowerVersions_internal_protected_set = value };
        }

        public new LanguageCompilationOptions WithXmlReferenceResolver(XmlReferenceResolver resolver)
        {
            if (ReferenceEquals(resolver, this.XmlReferenceResolver))
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { XmlReferenceResolver = resolver };
        }

        public new LanguageCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            if (ReferenceEquals(resolver, this.SourceReferenceResolver))
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { SourceReferenceResolver = resolver };
        }

        public new LanguageCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            if (ReferenceEquals(resolver, this.MetadataReferenceResolver))
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { MetadataReferenceResolver = resolver };
        }

        public new LanguageCompilationOptions WithAssemblyIdentityComparer(AssemblyIdentityComparer comparer)
        {
            comparer = comparer ?? AssemblyIdentityComparer.Default;

            if (ReferenceEquals(comparer, this.AssemblyIdentityComparer))
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { AssemblyIdentityComparer = comparer };
        }

        public new LanguageCompilationOptions WithStrongNameProvider(StrongNameProvider provider)
        {
            if (ReferenceEquals(provider, this.StrongNameProvider))
            {
                return this;
            }

            return new LanguageCompilationOptions(this) { StrongNameProvider = provider };
        }

        protected override CompilationOptions CommonWithConcurrentBuild(bool concurrent) => WithConcurrentBuild(concurrent);
        protected override CompilationOptions CommonWithDeterministic(bool deterministic) => WithDeterministic(deterministic);

        protected override CompilationOptions CommonWithOutputKind(OutputKind kind) => WithOutputKind(kind);

        protected override CompilationOptions CommonWithPlatform(Platform platform) => WithPlatform(platform);

        protected override CompilationOptions CommonWithPublicSign(bool publicSign) => WithPublicSign(publicSign);

        protected override CompilationOptions CommonWithOptimizationLevel(OptimizationLevel value) => WithOptimizationLevel(value);

        protected override CompilationOptions CommonWithAssemblyIdentityComparer(AssemblyIdentityComparer comparer) =>
            WithAssemblyIdentityComparer(comparer);

        protected override CompilationOptions CommonWithXmlReferenceResolver(XmlReferenceResolver resolver) =>
            WithXmlReferenceResolver(resolver);

        protected override CompilationOptions CommonWithSourceReferenceResolver(SourceReferenceResolver resolver) =>
            WithSourceReferenceResolver(resolver);

        protected override CompilationOptions CommonWithMetadataReferenceResolver(MetadataReferenceResolver resolver) =>
            WithMetadataReferenceResolver(resolver);

        protected override CompilationOptions CommonWithStrongNameProvider(StrongNameProvider provider) =>
            WithStrongNameProvider(provider);

        protected override CompilationOptions CommonWithMetadataImportOptions(MetadataImportOptions value) =>
            WithMetadataImportOptions(value);

        [Obsolete]
        protected override CompilationOptions CommonWithFeatures(ImmutableArray<string> features)
        {
            throw new NotImplementedException();
        }

        internal override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
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
                    builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(MainTypeName), MainTypeName));
                }
            }

            if (!Platform.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadPlatformType, Platform.ToString()));
            }

            if (ModuleName != null)
            {
                MetadataHelpers.CheckAssemblyOrModuleName(ModuleName, MessageProvider.Instance, InternalErrorCode.ERR_BadModuleName.Code, builder);
            }

            if (!OutputKind.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(OutputKind), OutputKind.ToString()));
            }

            if (!OptimizationLevel.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(OptimizationLevel), OptimizationLevel.ToString()));
            }

            if (ScriptClassName == null || !ScriptClassName.IsValidClrTypeName())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(ScriptClassName), ScriptClassName ?? "null"));
            }

            if (WarningLevel < 0 || WarningLevel > 4)
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(WarningLevel), WarningLevel));
            }

            if (Usings != null && Usings.Any(u => !u.IsValidClrNamespaceName()))
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(Usings), Usings.Where(u => !u.IsValidClrNamespaceName()).First() ?? "null"));
            }

            if (Platform == Platform.AnyCpu32BitPreferred && OutputKind.IsValid() && !(OutputKind == OutputKind.ConsoleApplication || OutputKind == OutputKind.WindowsApplication || OutputKind == OutputKind.WindowsRuntimeApplication))
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadPrefer32OnLib));
            }

            if (!MetadataImportOptions.IsValid())
            {
                builder.Add(LanguageDiagnostic.Create(InternalErrorCode.ERR_BadCompilationOptionValue, nameof(MetadataImportOptions), MetadataImportOptions.ToString()));
            }

            // TODO: add check for 
            //          (kind == 'arm' || kind == 'appcontainer' || kind == 'winmdobj') &&
            //          (version >= "6.2")
        }

        public bool Equals(LanguageCompilationOptions other)
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
                   (this.Usings == null ? other.Usings == null : this.Usings.SequenceEqual(other.Usings, StringComparer.Ordinal));
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as LanguageCompilationOptions);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(base.GetHashCodeHelper(),
                   Hash.Combine(this.AllowUnsafe,
                   Hash.Combine(Hash.CombineValues(this.Usings, StringComparer.Ordinal), TopLevelBinderFlags.GetHashCode())));
        }

        internal override Diagnostic FilterDiagnostic(Diagnostic diagnostic)
        {
            return LanguageDiagnosticFilter.Filter(diagnostic, WarningLevel, GeneralDiagnosticOption, SpecificDiagnosticOptions);
        }

        protected override CompilationOptions CommonWithModuleName(string moduleName)
        {
            return WithModuleName(moduleName);
        }

        protected override CompilationOptions CommonWithMainTypeName(string mainTypeName)
        {
            return WithMainTypeName(mainTypeName);
        }

        protected override CompilationOptions CommonWithScriptClassName(string scriptClassName)
        {
            return WithScriptClassName(scriptClassName);
        }

        protected override CompilationOptions CommonWithCryptoKeyContainer(string cryptoKeyContainer)
        {
            return WithCryptoKeyContainer(cryptoKeyContainer);
        }

        protected override CompilationOptions CommonWithCryptoKeyFile(string cryptoKeyFile)
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
