// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationOptions : CompilationOptions, IEquatable<MetaCompilationOptions>
    {
        // Defaults correspond to the compiler's defaults or indicate that the user did not specify when that is significant.
        // That's significant when one option depends on another's setting.
        public MetaCompilationOptions(
            bool reportSuppressedDiagnostics = false,
            string scriptClassName = null,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            int warningLevel = 4,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions = null,
            bool concurrentBuild = true,
            bool deterministic = false,
            SourceReferenceResolver sourceReferenceResolver = null,
            MetadataReferenceResolver metadataReferenceResolver = null)
            : this(reportSuppressedDiagnostics, scriptClassName,
                   generalDiagnosticOption, warningLevel,
                   specificDiagnosticOptions != null ? specificDiagnosticOptions.ToImmutableDictionary() : ImmutableDictionary<string, ReportDiagnostic>.Empty, 
                   concurrentBuild, deterministic,
                   sourceReferenceResolver: sourceReferenceResolver,
                   metadataReferenceResolver: metadataReferenceResolver,
                   referencesSupersedeLowerVersions: false)
        {
        }

        // Expects correct arguments.
        public MetaCompilationOptions(
            bool reportSuppressedDiagnostics,
            string scriptClassName,
            ReportDiagnostic generalDiagnosticOption,
            int warningLevel,
            ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions,
            bool concurrentBuild,
            bool deterministic,
            SourceReferenceResolver sourceReferenceResolver,
            MetadataReferenceResolver metadataReferenceResolver,
            bool referencesSupersedeLowerVersions)
            : base(reportSuppressedDiagnostics, 
                  scriptClassName,
                  generalDiagnosticOption,
                  warningLevel,
                  specificDiagnosticOptions,
                  concurrentBuild,
                  deterministic,
                  sourceReferenceResolver,
                  metadataReferenceResolver, 
                  referencesSupersedeLowerVersions)
        {
        }

        private MetaCompilationOptions(MetaCompilationOptions other) : this(
            scriptClassName: other.ScriptClassName,
            generalDiagnosticOption: other.GeneralDiagnosticOption,
            warningLevel: other.WarningLevel,
            specificDiagnosticOptions: other.SpecificDiagnosticOptions,
            concurrentBuild: other.ConcurrentBuild,
            deterministic: other.Deterministic,
            sourceReferenceResolver: other.SourceReferenceResolver,
            metadataReferenceResolver: other.MetadataReferenceResolver,
            reportSuppressedDiagnostics: other.ReportSuppressedDiagnostics,
            referencesSupersedeLowerVersions: other.ReferencesSupersedeLowerVersions)
        {
        }

        public new MetaCompilationOptions WithDeterministic(bool deterministic)
        {
            if (this.Deterministic == deterministic)
            {
                return this;
            }
            return new MetaCompilationOptions(this) { Deterministic = deterministic };
        }

        public new MetaCompilationOptions WithReferencesSupersedeLowerVersions(bool value)
        {
            if (this.ReferencesSupersedeLowerVersions == value)
            {
                return this;
            }
            return new MetaCompilationOptions(this) { ReferencesSupersedeLowerVersions = value };
        }

        public new MetaCompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic generalDiagnosticOption)
        {
            if (this.GeneralDiagnosticOption == generalDiagnosticOption)
            {
                return this;
            }
            return new MetaCompilationOptions(this) { GeneralDiagnosticOption = generalDiagnosticOption };
        }

        public new MetaCompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            if (this.MetadataReferenceResolver == resolver)
            {
                return this;
            }
            return new MetaCompilationOptions(this) { MetadataReferenceResolver = resolver };
        }

        public new MetaCompilationOptions WithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            if (this.ReportSuppressedDiagnostics == reportSuppressedDiagnostics)
            {
                return this;
            }
            return new MetaCompilationOptions(this) { ReportSuppressedDiagnostics = reportSuppressedDiagnostics };
        }

        public new MetaCompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            if (this.SourceReferenceResolver == resolver)
            {
                return this;
            }
            return new MetaCompilationOptions(this) { SourceReferenceResolver = resolver };
        }

        public new MetaCompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions)
        {
            return new MetaCompilationOptions(this) { SpecificDiagnosticOptions = specificDiagnosticOptions != null ? specificDiagnosticOptions.ToImmutableDictionary() : ImmutableDictionary<string, ReportDiagnostic>.Empty };
        }

        public new MetaCompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions)
        {
            if (specificDiagnosticOptions == null)
            {
                specificDiagnosticOptions = ImmutableDictionary<string, ReportDiagnostic>.Empty;
            }

            if (this.SpecificDiagnosticOptions == specificDiagnosticOptions)
            {
                return this;
            }

            return new MetaCompilationOptions(this) { SpecificDiagnosticOptions = specificDiagnosticOptions };
        }

        protected override CompilationOptions CommonWithDeterministic(bool deterministic)
        {
            return this.WithDeterministic(deterministic);
        }

        protected override CompilationOptions CommonWithReferencesSupersedeLowerVersions(bool value)
        {
            return this.CommonWithDeterministic(value);
        }

        protected override CompilationOptions CommonWithGeneralDiagnosticOption(ReportDiagnostic generalDiagnosticOption)
        {
            return this.WithGeneralDiagnosticOption(generalDiagnosticOption);
        }

        protected override CompilationOptions CommonWithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            return this.WithMetadataReferenceResolver(resolver);
        }

        protected override CompilationOptions CommonWithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            return this.WithReportSuppressedDiagnostics(reportSuppressedDiagnostics);
        }

        protected override CompilationOptions CommonWithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            return this.WithSourceReferenceResolver(resolver);
        }

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions)
        {
            return this.WithSpecificDiagnosticOptions(specificDiagnosticOptions);
        }

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions)
        {
            return this.WithSpecificDiagnosticOptions(specificDiagnosticOptions);
        }

        public override Diagnostic FilterDiagnostic(Diagnostic diagnostic)
        {
            return diagnostic;
        }

        protected override ImmutableArray<string> GetImports()
        {
            return ImmutableArray<string>.Empty;
        }

        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
        }

        public bool Equals(MetaCompilationOptions other)
        {
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (!base.EqualsHelper(other))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as MetaCompilationOptions);
        }

        public override int GetHashCode()
        {
            return base.GetHashCodeHelper();
        }
    }
}

