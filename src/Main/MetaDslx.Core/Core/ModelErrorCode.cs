using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public sealed class ModelErrorCode : ErrorCode
    {
        private static ImmutableDictionary<int, ModelErrorCode> s_errorCodeToDescriptorMap = ImmutableDictionary<int, ModelErrorCode>.Empty;

        public const string ModelCategory = "MetaDslx.Core";
        public const string Prefix = "MM";

        public ModelErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            ModelErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        public ModelErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(code, Prefix, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
            ModelErrorCode old = ImmutableInterlocked.GetOrAdd(ref s_errorCodeToDescriptorMap, code, c => this);
            Debug.Assert(old == null);
        }

        static ModelErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(ModelErrorCode), r => ResolveErrorCode(r));
        }

        private static ModelErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            s_errorCodeToDescriptorMap.TryGetValue(errorCode, out ModelErrorCode result);
            return result ?? ERR_InvalidErrorCode;
        }

        public static readonly ModelErrorCode ERR_InvalidErrorCode = new ModelErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly ModelErrorCode ERR_SymbolAlreadyContainedByModelGroup = new ModelErrorCode(1, "Symbol already contained by model group", "The symbol '{0}' is already contained by the model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_SymbolAlreadyContainedByModel = new ModelErrorCode(2, "Symbol already contained by model", "The symbol '{0}' is already contained by the model.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotResolveModel = new ModelErrorCode(3, "Cannot resolve model", "Cannot resolve the model based on the id '{0}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotMergeSymbolsResolve = new ModelErrorCode(4, "Cannot merge symbols", "Cannot merge part symbol '{0}' into target symbol '{1}'. The target and the part symbols must be contained by this model or model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotMergeSymbolsProperty = new ModelErrorCode(5, "Cannot merge symbols", "Cannot merge part symbol '{0}' into target symbol '{1}'. They have a different values for the property '{2}' (part value is '{3}', target value is '{4}').", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_SymbolCannotBeAssignedToPropertyModelGroup = new ModelErrorCode(6, "Symbol cannot be assigned to property", "Symbol '{0}' cannot be assigned to property '{1}' of '{2}', since the symbol cannot be resolved within the model group. Either add the symbol to the model first, or make sure to reference the model which contains the symbol from the model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_SymbolCannotBeAssignedToPropertyModel = new ModelErrorCode(7, "Symbol cannot be assigned to property", "Symbol '{0}' cannot be assigned to property '{1}' of '{2}', since the symbol cannot be resolved within the model. Either add the symbol to the model first, or create a model group referencing the model which contains the symbol.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_SymbolCannotBeAddedToPropertyModelGroup = new ModelErrorCode(8, "Symbol cannot be added to property", "Symbol '{0}' cannot be added to property '{1}' of '{2}', since the symbol cannot be resolved within the model group. Either add the symbol to the model first, or make sure to reference the model which contains the symbol from the model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_SymbolCannotBeAddedToPropertyModel = new ModelErrorCode(9, "Symbol cannot be added to property", "Symbol '{0}' cannot be added to property '{1}' of '{2}', since the symbol cannot be resolved within the model. Either add the symbol to the model first, or create a model group referencing the model which contains the symbol.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignDerivedProperty = new ModelErrorCode(10, "Cannot reassign a derived property", "Cannot reassign derived property '{1}' of symbol '{2}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignReadOnlyProperty = new ModelErrorCode(11, "Cannot reassign a read-only property", "Cannot reassign read-only property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignLazyValuedProperty = new ModelErrorCode(12, "Cannot reassign a lazy-valued property", "Cannot reassign lazy-valued property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAssignNullToProperty = new ModelErrorCode(13, "Cannot assign null to property", "Cannot assign null value to property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAssignValueToProperty = new ModelErrorCode(14, "Cannot assign value to property", "Cannot assign value '{0}' of type '{1}' to property '{2}' of type '{3}' in symbol '{4}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotChangeDerivedProperty = new ModelErrorCode(15, "Cannot change derived property", "Cannot change derived property '{1}' of symbol '{2}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotChangeReadOnlyProperty = new ModelErrorCode(16, "Cannot change read-only property", "Cannot change read-only property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddNullToProperty = new ModelErrorCode(17, "Cannot add null value to property", "Cannot add null value to property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddValueToProperty = new ModelErrorCode(18, "Cannot add value to property", "Cannot add value '{0}' of type '{1}' to property '{2}' of type '{3}' in symbol '{4}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidContainment = new ModelErrorCode(19, "Invalid containment", "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. The symbol is already contained by '{3}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidSelfContainment = new ModelErrorCode(20, "Invalid self-containment", "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. The symbol cannot contain itself.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidModelContainment = new ModelErrorCode(21, "Invalid model containment", "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. The containing symbol and the contained symbol must be in the same model.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CircularContainment = new ModelErrorCode(22, "Circular containment", "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. This would result in circular containment.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CircularLazyEvaluation = new ModelErrorCode(23, "Circular lazy evaluation", "Circular dependency between lazy values.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_LazyEvaluationError = new ModelErrorCode(24, "Lazy evaluation error", "The lazy evaluator threw an exception: {0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_UnknownTypeName = new ModelErrorCode(25, "Uknown type name", "Uknown type name: '{0}'", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignCollectionProperty = new ModelErrorCode(26, "Cannot reassign collection property", "Cannot reassign collection property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddMultipleValuesToNonCollectionProperty = new ModelErrorCode(27, "Cannot add multiple values to non-collection property", "Cannot add multiple values to non-collection property '{0}' of symbol '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotMergeDifferentSymbols = new ModelErrorCode(28, "Cannot merge different symbols", "Cannot merge part symbol '{0}' into target symbol '{1}'. The target and the part symbols must be of the same type (part symbol is of type '{2}', target symbol is of type '{3}').", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_Exception = new ModelErrorCode(29, "Unexpected exception", "Unexpected exception: {0}", DiagnosticSeverity.Error);
    }
}
