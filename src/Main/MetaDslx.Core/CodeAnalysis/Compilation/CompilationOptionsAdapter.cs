using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationOptionsAdapter : CompilationOptions
    {
        internal CompilationOptionsAdapter(OutputKind outputKind, bool reportSuppressedDiagnostics, string moduleName, string mainTypeName, string scriptClassName, string cryptoKeyContainer, string cryptoKeyFile, ImmutableArray<byte> cryptoPublicKey, bool? delaySign, bool publicSign, OptimizationLevel optimizationLevel, bool checkOverflow, Platform platform, ReportDiagnostic generalDiagnosticOption, int warningLevel, ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions, bool concurrentBuild, bool deterministic, DateTime currentLocalTime, bool debugPlusMode, XmlReferenceResolver xmlReferenceResolver, SourceReferenceResolver sourceReferenceResolver, MetadataReferenceResolver metadataReferenceResolver, AssemblyIdentityComparer assemblyIdentityComparer, StrongNameProvider strongNameProvider, MetadataImportOptions metadataImportOptions, bool referencesSupersedeLowerVersions) 
            : base(outputKind, reportSuppressedDiagnostics, moduleName, mainTypeName, scriptClassName, cryptoKeyContainer, cryptoKeyFile, cryptoPublicKey, delaySign, publicSign, optimizationLevel, checkOverflow, platform, generalDiagnosticOption, warningLevel, specificDiagnosticOptions, concurrentBuild, deterministic, currentLocalTime, debugPlusMode, xmlReferenceResolver, sourceReferenceResolver, metadataReferenceResolver, assemblyIdentityComparer, strongNameProvider, metadataImportOptions, referencesSupersedeLowerVersions)
        {
        }

        public sealed override string Language => LanguageCore.Name;

        protected abstract Language LanguageCore { get; }

    }
}
