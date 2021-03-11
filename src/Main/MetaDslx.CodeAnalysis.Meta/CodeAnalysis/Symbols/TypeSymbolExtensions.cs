using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public static class TypeSymbolExtensions
    {
        public static void AddUseSiteDiagnostics(
            this TypeSymbol type,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            DiagnosticInfo errorInfo = type.GetUseSiteDiagnostic();

            if ((object)errorInfo != null)
            {
                if (useSiteDiagnostics == null)
                {
                    useSiteDiagnostics = new HashSet<DiagnosticInfo>();
                }

                useSiteDiagnostics.Add(errorInfo);
            }
        }

        /// <summary>
        /// Add this instance to the set of checked types. Returns true
        /// if this was added, false if the type was already in the set.
        /// </summary>
        public static bool MarkCheckedIfNecessary(this TypeSymbol type, ref HashSet<TypeSymbol> checkedTypes)
        {
            if (checkedTypes == null)
            {
                checkedTypes = new HashSet<TypeSymbol>();
            }

            return checkedTypes.Add(type);
        }


        public static bool IsNamedType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.NamedType;
        }

        public static bool IsErrorType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.Kind == LanguageSymbolKind.ErrorType;
        }
        public static bool IsDynamic(this TypeSymbol type)
        {
            return type.TypeKind == TypeKind.Dynamic;
        }

        public static bool IsConstructed(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.Constructed;
        }


        /// <summary>
        /// Guess the non-error type that the given type was intended to represent.
        /// If the type itself is not an error type, then it will be returned.
        /// Otherwise, the underlying type (if any) of the error type will be
        /// returned.
        /// </summary>
        /// <remarks>
        /// Any non-null type symbol returned is guaranteed not to be an error type.
        /// 
        /// It is possible to pass in a constructed type and received back an 
        /// unconstructed type.  This can occur when the type passed in was
        /// constructed from an error type - the underlying definition will be
        /// available, but there won't be a good way to "re-substitute" back up
        /// to the level of the specified type.
        /// </remarks>
        internal static TypeSymbol GetNonErrorGuess(this TypeSymbol type)
        {
            var result = ExtendedErrorTypeSymbol.ExtractNonErrorType(type);
            Debug.Assert((object)result == null || !result.IsErrorType());
            return result;
        }
    }
}
