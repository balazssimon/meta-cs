using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Importer
{
    public class SoalImporterErrorCode : ErrorCode
    {
        private static ImmutableDictionary<int, SoalImporterErrorCode> s_errorCodeToDescriptorMap = ImmutableDictionary<int, SoalImporterErrorCode>.Empty;

        public const string ModelCategory = "SoalImporter";
        public const string Prefix = "SG";

        private SoalImporterErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
        }

        private SoalImporterErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
        }

        static SoalImporterErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(SoalImporterErrorCode), r => ResolveErrorCode(r));
        }

        private static SoalImporterErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            s_errorCodeToDescriptorMap.TryGetValue(errorCode, out SoalImporterErrorCode result);
            return result ?? ERR_InvalidErrorCode;
        }

        public const string SoalImporterCategory = "SoalImporter";

        public static readonly SoalImporterErrorCode ERR_InvalidErrorCode = new SoalImporterErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly SoalImporterErrorCode Error = new SoalImporterErrorCode(1, "Error", "{0}", DiagnosticSeverity.Error);
        public static readonly SoalImporterErrorCode Warning = new SoalImporterErrorCode(2, "Warning", "{0}", DiagnosticSeverity.Warning);
        public static readonly SoalImporterErrorCode Info = new SoalImporterErrorCode(3, "Info", "{0}", DiagnosticSeverity.Info);


    }
}
