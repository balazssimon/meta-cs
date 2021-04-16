using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    using CSharpCompilationOptions = Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions;

    public abstract class CompilationOptionsAdapter : CompilationOptions
    {
        internal CompilationOptionsAdapter(OutputKind outputKind, bool reportSuppressedDiagnostics, string? moduleName, string? mainTypeName, string? scriptClassName, string? cryptoKeyContainer, string? cryptoKeyFile, ImmutableArray<byte> cryptoPublicKey, bool? delaySign, bool publicSign, OptimizationLevel optimizationLevel, bool checkOverflow, Platform platform, ReportDiagnostic generalDiagnosticOption, int warningLevel, ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions, bool concurrentBuild, bool deterministic, DateTime currentLocalTime, bool debugPlusMode, XmlReferenceResolver? xmlReferenceResolver, SourceReferenceResolver? sourceReferenceResolver, SyntaxTreeOptionsProvider? syntaxTreeOptionsProvider, MetadataReferenceResolver? metadataReferenceResolver, AssemblyIdentityComparer? assemblyIdentityComparer, StrongNameProvider? strongNameProvider, MetadataImportOptions metadataImportOptions, bool referencesSupersedeLowerVersions) 
            : base(outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, publicSign, optimizationLevel, checkOverflow, platform, generalDiagnosticOption, warningLevel, specificDiagnosticOptions, concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver, sourceReferenceResolver, syntaxTreeOptionsProvider, metadataReferenceResolver, assemblyIdentityComparer, strongNameProvider, metadataImportOptions, referencesSupersedeLowerVersions)
        {
        }

        public sealed override string Language => LanguageCore.Name;

        protected abstract Language LanguageCore { get; }

        internal override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            this.ValidateOptionsCore(builder);
        }

        protected abstract void ValidateOptionsCore(ArrayBuilder<Diagnostic> builder);
    }
}
