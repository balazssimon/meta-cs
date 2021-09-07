using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Modeling
{
    public sealed class ModelErrorCode : ErrorCode
    {
        private static ErrorCodeMessageProvider s_messageProvider = new ErrorCodeMessageProvider("MM", typeof(ModelErrorCode));

        public const string ModelCategory = "MetaDslx.Core";

        private ModelErrorCode(int code, string title, string messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(s_messageProvider, code, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }

        private ModelErrorCode(int code, LocalizableString title, LocalizableString messageFormat, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault, LocalizableString description = null, string helpLinkUri = null, params string[] customTags)
            : base(s_messageProvider, code, title, messageFormat, ModelCategory, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }

        static ModelErrorCode()
        {
            ObjectBinder.RegisterTypeReader(typeof(ModelErrorCode), r => ResolveErrorCode(r));
        }

        private static ModelErrorCode ResolveErrorCode(ObjectReader reader)
        {
            int errorCode = reader.ReadInt32();
            return (ModelErrorCode)s_messageProvider.GetErrorCode(errorCode);
        }

        public static readonly ModelErrorCode ERR_InvalidErrorCode = new ModelErrorCode(0, "Invalid error code", "Invalid error code. This should not happen. There is an error in the compiler.", DiagnosticSeverity.Error, false);
        public static readonly ModelErrorCode ERR_ObjectAlreadyContainedByModelGroup = new ModelErrorCode(1, "Object is already contained by model group", "The object '{0}' is already contained by the model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ObjectAlreadyContainedByModel = new ModelErrorCode(2, "Object is already contained by model", "The object '{0}' is already contained by the model.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotResolveModelById = new ModelErrorCode(3, "Cannot resolve model", "Cannot resolve the model based on the id '{0}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotMergeObjectsResolve = new ModelErrorCode(4, "Cannot merge objects", "Cannot merge object part '{0}' into '{1}'. Both object parts must be contained by this model or model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotMergeObjectsProperty = new ModelErrorCode(5, "Cannot merge objects", "Cannot merge object part '{0}' into '{1}'. They have a different values for the property '{2}' (source value is '{3}', target value is '{4}').", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ObjectCannotBeAssignedToPropertyModelGroup = new ModelErrorCode(6, "Object cannot be assigned to property", "Object '{0}' cannot be assigned to property '{1}' of '{2}', since the model object cannot be resolved within the model group. Either add the object to the model first, or make sure to reference the model which contains the object from the model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ObjectCannotBeAssignedToPropertyModel = new ModelErrorCode(7, "Object cannot be assigned to property", "Object '{0}' cannot be assigned to property '{1}' of '{2}', since the model object cannot be resolved within the model. Either add the object to the model first, or create a model group referencing the model which contains the object.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ObjectCannotBeAddedToPropertyModelGroup = new ModelErrorCode(8, "Object cannot be added to property", "Object '{0}' cannot be added to property '{1}' of '{2}', since the model object cannot be resolved within the model group. Either add the object to the model first, or make sure to reference the model which contains the object from the model group.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ObjectCannotBeAddedToPropertyModel = new ModelErrorCode(9, "Object cannot be added to property", "Object '{0}' cannot be added to property '{1}' of '{2}', since the model object cannot be resolved within the model. Either add the object to the model first, or create a model group referencing the model which contains the object.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignDerivedProperty = new ModelErrorCode(10, "Cannot reassign a derived property", "Cannot reassign derived property '{1}' of object '{2}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignReadOnlyProperty = new ModelErrorCode(11, "Cannot reassign a read-only property", "Cannot reassign read-only property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignLazyValuedProperty = new ModelErrorCode(12, "Cannot reassign a lazy-valued property", "Cannot reassign lazy-valued property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAssignNullToProperty = new ModelErrorCode(13, "Cannot assign null to property", "Cannot assign null value to property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAssignValueToProperty = new ModelErrorCode(14, "Cannot assign value to property", "Cannot assign value '{0}' of type '{1}' to property '{2}' of type '{3}' in object '{4}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotChangeDerivedProperty = new ModelErrorCode(15, "Cannot change derived property", "Cannot change derived property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotChangeReadOnlyProperty = new ModelErrorCode(16, "Cannot change read-only property", "Cannot change read-only property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddNullToProperty = new ModelErrorCode(17, "Cannot add null value to property", "Cannot add null value to property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddValueToProperty = new ModelErrorCode(18, "Cannot add value to property", "Cannot add value '{0}' of type '{1}' to property '{2}' of type '{3}' in object '{4}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidContainment = new ModelErrorCode(19, "Invalid containment", "Cannot add object '{0}' to containing property '{1}' of '{2}'. The object is already contained by '{3}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidSelfContainment = new ModelErrorCode(20, "Invalid self-containment", "Cannot add object '{0}' to containing property '{1}' of '{2}'. The object cannot contain itself.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidModelContainment = new ModelErrorCode(21, "Invalid model containment", "Cannot add object '{0}' to containing property '{1}' of '{2}'. The containing object and the contained object must be in the same model.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CircularContainment = new ModelErrorCode(22, "Circular containment", "Cannot add object '{0}' to containing property '{1}' of '{2}'. This would result in circular containment.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CircularLazyEvaluation = new ModelErrorCode(23, "Circular lazy evaluation", "Circular dependency between lazy values.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_LazyEvaluationError = new ModelErrorCode(24, "Lazy evaluation error", "The lazy evaluator threw an exception: {0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_UnknownTypeName = new ModelErrorCode(25, "Uknown type name", "Uknown type name: '{0}'", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotReassignCollectionProperty = new ModelErrorCode(26, "Cannot reassign collection property", "Cannot reassign collection property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddMultipleValuesToNonCollectionProperty = new ModelErrorCode(27, "Cannot add multiple values to non-collection property", "Cannot add multiple values to non-collection property '{0}' of object '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotMergeDifferentObjects = new ModelErrorCode(28, "Cannot merge different objects", "Cannot merge object part '{0}' into '{1}'. Both parts must be of the same type (source object is of type '{2}', target object is of type '{3}').", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_Exception = new ModelErrorCode(29, "Unexpected exception", "Unexpected exception: {0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_FileReadError = new ModelErrorCode(30, "Cannot read file", "File read error: {0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ValueIsNotSymbol = new ModelErrorCode(31, "Value is not a symbol", "Value '{0}' cannot be used as a symbol", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_DeclarationHasNoName = new ModelErrorCode(32, "Declaration has no name", "Declaration has no name", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidBaseType = new ModelErrorCode(33, "Invalid base type", "Invalid base type: '{0}'. A base type symbol must be a NamedTypeSymbol.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_InvalidImport = new ModelErrorCode(34, "Invalid import", "Invalid import: '{0}'. An import symbol must be a NamespaceOrTypeSymbol.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_BadModelObject = new ModelErrorCode(35, "Invalid model object", "Unexpected {1} '{0}'. Expected model objects are: {2}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotSetOppositeProperty = new ModelErrorCode(36, "Cannot set opposite property", "Cannot set opposite property between '{0}' and '{1}'", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_PropertyDoesNotExist = new ModelErrorCode(37, "Invalid property", "Model object '{0}' has no property with name '{1}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_DefinedSymbolNotFound = new ModelErrorCode(38, "Defined symbol not found", "Internal error in the compiler. {0} '{1}' was not found in {2} '{3}'. Either {2} '{3}' should be defined as a [Scope] or {0} '{1}' should be resolved by $SymbolUse instead of $SymbolDef.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode WRN_QualifierNotFound = new ModelErrorCode(39, "Qualifier not found", "Internal error in the compiler. The $Qualifier annotation of '{1}' was not found under the $SymbolUse annotation of '{2}'. Make sure the $Qualifier annotation is available directly under the $SymbolUse annotation.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotSetValueToProperty = new ModelErrorCode(40, "Cannot add value to property", "Cannot set value to property '{0}' in object '{1}': {2}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotAddValuesToProperty = new ModelErrorCode(41, "Cannot add values to property", "Cannot add values to property '{0}' in object '{1}': {2}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ModelObjectDescriptorNotFound = new ModelErrorCode(42, "Object descriptor not found", "Could not find descriptor for model object type '{0}'. Try initializing the model descriptor by calling [ModelName]Descriptor.Initialize().", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_XmiError = new ModelErrorCode(43, "XMI error", "XMI error: {0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_ImportError = new ModelErrorCode(44, "Import error", "{0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode WRN_ImportWarning = new ModelErrorCode(45, "Import warning", "{0}", DiagnosticSeverity.Warning);
        public static readonly ModelErrorCode INF_ImportInfo = new ModelErrorCode(46, "Import info", "{0}", DiagnosticSeverity.Warning);
        public static readonly ModelErrorCode ERR_ModelConversionError = new ModelErrorCode(47, "Model conversion error", "Model conversion error: {0}", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_NotContainmentProperty = new ModelErrorCode(48, "Not a containment property", "Property '{0}' of the object '{1}' is not a containment property.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_MustBeSymbolDefBound = new ModelErrorCode(49, "Must be SymbolDef bound", "Values of the containment property '{0}' must be bound by a SymbolDef binder.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotCreateSourceDeclaredSymbol = new ModelErrorCode(50, "Source declared symbol creation error", "Could not create declared source symbol '{0}' named '{1}' of type '{2}'", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotSetSymbolProperty = new ModelErrorCode(51, "Cannot set value to property", "Cannot assign value '{0}' to property '{1}' in symbol '{2}'. The expected type is '{3}'. The actual type is '{4}'.", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotResolveModelObject = new ModelErrorCode(52, "Cannot resolve model object", "Cannot resolve the model object '{0}' within the model or model group '{1}'. Are you missing a reference to the model '{2}'?", DiagnosticSeverity.Error);
        public static readonly ModelErrorCode ERR_CannotResolveModelByUri = new ModelErrorCode(53, "Cannot resolve model", "Cannot resolve the model based on the uri '{0}'. Are you missing a reference to the model?", DiagnosticSeverity.Error);
    }
}
