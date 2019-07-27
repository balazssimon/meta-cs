using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Generator
{
    public class SoalGeneratorErrorCode : ErrorCode
    {
        private static ImmutableDictionary<int, SoalGeneratorErrorCode> s_errorCodeToDescriptorMap = ImmutableDictionary<int, SoalGeneratorErrorCode>.Empty;

        public const string ModelCategory = "SoalGenerator";
        public const string Prefix = "SG";

        private SoalGeneratorErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
        }

        private SoalGeneratorErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
        }

        static SoalGeneratorErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(SoalGeneratorErrorCode), r => ResolveErrorCode(r));
        }

        private static SoalGeneratorErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            s_errorCodeToDescriptorMap.TryGetValue(errorCode, out SoalGeneratorErrorCode result);
            return result ?? ERR_InvalidErrorCode;
        }
        public const string SoalGeneratorCategory = "SoalGenerator";

        public static readonly SoalGeneratorErrorCode ERR_InvalidErrorCode = new SoalGeneratorErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly SoalGeneratorErrorCode XsdTypeDefinedMultipleTimes = new SoalGeneratorErrorCode(1, "XSD type defined multiple times", "XSD type named '{0}' is defined multiple times.", DiagnosticSeverity.Error);
        public static readonly SoalGeneratorErrorCode TypeHasNoXsdNamespace = new SoalGeneratorErrorCode(2, "Missing XSD namespace", "The type of this element has no XSD namespace.", DiagnosticSeverity.Error);
    }
}
