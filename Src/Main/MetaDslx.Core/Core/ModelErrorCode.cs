using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class ModelErrorCode : ErrorCode
    {
        public const string ModelCategory = "MetaDslx.Core";
        public static readonly ModelErrorCode ERR_SymbolAlreadyContainedByModelGroup = new ModelErrorCode(1, DiagnosticSeverity.Error, 0, "The symbol '{0}' is already contained by the model group.");
        public static readonly ModelErrorCode ERR_SymbolAlreadyContainedByModel = new ModelErrorCode(2, DiagnosticSeverity.Error, 0, "The symbol '{0}' is already contained by the model.");
        public static readonly ModelErrorCode ERR_CannotResolveModel = new ModelErrorCode(3, DiagnosticSeverity.Error, 0, "Cannot resolve the model based on the id '{0}'.");
        public static readonly ModelErrorCode ERR_CannotMergeSymbolsResolve = new ModelErrorCode(4, DiagnosticSeverity.Error, 0, "Cannot merge part symbol '{0}' into target symbol '{1}'. The target and the part symbols must be contained by this model or model group.");
        public static readonly ModelErrorCode ERR_CannotMergeSymbolsProperty = new ModelErrorCode(5, DiagnosticSeverity.Error, 0, "Cannot merge part symbol '{0}' into target symbol '{1}'. They have a different values for the property '{2}' (part value is '{3}', target value is '{4}').");
        public static readonly ModelErrorCode ERR_SymbolCannotBeAssignedToPropertyModelGroup = new ModelErrorCode(6, DiagnosticSeverity.Error, 0, "Symbol '{0}' cannot be assigned to property '{1}' of '{2}', since the symbol cannot be resolved within the model group. Either add the symbol to the model first, or make sure to reference the model which contains the symbol from the model group.");
        public static readonly ModelErrorCode ERR_SymbolCannotBeAssignedToPropertyModel = new ModelErrorCode(7, DiagnosticSeverity.Error, 0, "Symbol '{0}' cannot be assigned to property '{1}' of '{2}', since the symbol cannot be resolved within the model. Either add the symbol to the model first, or create a model group referencing the model which contains the symbol.");
        public static readonly ModelErrorCode ERR_SymbolCannotBeAddedToPropertyModelGroup = new ModelErrorCode(8, DiagnosticSeverity.Error, 0, "Symbol '{0}' cannot be added to property '{1}' of '{2}', since the symbol cannot be resolved within the model group. Either add the symbol to the model first, or make sure to reference the model which contains the symbol from the model group.");
        public static readonly ModelErrorCode ERR_SymbolCannotBeAddedToPropertyModel = new ModelErrorCode(9, DiagnosticSeverity.Error, 0, "Symbol '{0}' cannot be added to property '{1}' of '{2}', since the symbol cannot be resolved within the model. Either add the symbol to the model first, or create a model group referencing the model which contains the symbol.");
        public static readonly ModelErrorCode ERR_CannotReassignDerivedProperty = new ModelErrorCode(10, DiagnosticSeverity.Error, 0, "Cannot reassign derived property '{1}' of symbol '{2}'.");
        public static readonly ModelErrorCode ERR_CannotReassignReadOnlyProperty = new ModelErrorCode(11, DiagnosticSeverity.Error, 0, "Cannot reassign read-only property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotReassignLazyValuedProperty = new ModelErrorCode(12, DiagnosticSeverity.Error, 0, "Cannot reassign lazy-valued property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotAssignNullToProperty = new ModelErrorCode(13, DiagnosticSeverity.Error, 0, "Cannot assign null value to property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotAssignValueToProperty = new ModelErrorCode(14, DiagnosticSeverity.Error, 0, "Cannot assign value '{0}' of type '{1}' to property '{2}' of type '{3}' in symbol '{4}'.");
        public static readonly ModelErrorCode ERR_CannotChangeDerivedProperty = new ModelErrorCode(15, DiagnosticSeverity.Error, 0, "Cannot change derived property '{1}' of symbol '{2}'.");
        public static readonly ModelErrorCode ERR_CannotChangeReadOnlyProperty = new ModelErrorCode(16, DiagnosticSeverity.Error, 0, "Cannot change read-only property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotAddNullToProperty = new ModelErrorCode(17, DiagnosticSeverity.Error, 0, "Cannot add null value to property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotAddValueToProperty = new ModelErrorCode(18, DiagnosticSeverity.Error, 0, "Cannot add value '{0}' of type '{1}' to property '{2}' of type '{3}' in symbol '{4}'.");
        public static readonly ModelErrorCode ERR_InvalidContainment = new ModelErrorCode(19, DiagnosticSeverity.Error, 0, "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. The symbol is already contained by '{3}'.");
        public static readonly ModelErrorCode ERR_InvalidSelfContainment = new ModelErrorCode(20, DiagnosticSeverity.Error, 0, "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. The symbol cannot contain itself.");
        public static readonly ModelErrorCode ERR_InvalidModelContainment = new ModelErrorCode(21, DiagnosticSeverity.Error, 0, "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. The containing symbol and the contained symbol must be in the same model.");
        public static readonly ModelErrorCode ERR_CircularContainment = new ModelErrorCode(22, DiagnosticSeverity.Error, 0, "Cannot add symbol '{0}' to containing property '{1}' of '{2}'. This would result in circular containment.");
        public static readonly ModelErrorCode ERR_CircularLazyEvaluation = new ModelErrorCode(23, DiagnosticSeverity.Error, 0, "Circular dependency between lazy values.");
        public static readonly ModelErrorCode ERR_LazyEvaluationError = new ModelErrorCode(24, DiagnosticSeverity.Error, 0, "The lazy evaluator threw an exception: {0}");
        public static readonly ModelErrorCode ERR_UnknownTypeName = new ModelErrorCode(25, DiagnosticSeverity.Error, 0, "Uknown type name: '{0}'");
        public static readonly ModelErrorCode ERR_CannotReassignCollectionProperty = new ModelErrorCode(26, DiagnosticSeverity.Error, 0, "Cannot reassign collection property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotAddMultipleValuesToNonCollectionProperty = new ModelErrorCode(27, DiagnosticSeverity.Error, 0, "Cannot add multiple values to non-collection property '{0}' of symbol '{1}'.");
        public static readonly ModelErrorCode ERR_CannotMergeDifferentSymbols = new ModelErrorCode(28, DiagnosticSeverity.Error, 0, "Cannot merge part symbol '{0}' into target symbol '{1}'. The target and the part symbols must be of the same type (part symbol is of type '{2}', target symbol is of type '{3}').");

        internal ModelErrorCode(int id, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage) 
            : base(ModelCategory, id, defaultSeverity, warningLevel, defaultMessage)
        {
        }
    }
}
