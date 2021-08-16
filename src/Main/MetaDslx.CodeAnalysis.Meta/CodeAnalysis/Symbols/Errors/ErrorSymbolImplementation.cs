using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public static class ErrorSymbolImplementation
    {
        public static DiagnosticInfo? MakeErrorInfo(IErrorSymbol errorSymbol)
        {
            var symbol = (Symbol)errorSymbol;
            if (errorSymbol.ErrorKind == ErrorKind.Missing)
            {
                AssemblySymbol containingAssembly = symbol.ContainingAssembly;

                // The Dev10 C# compiler produces errors based on what it was trying to do when 
                // the type could not be found. For example, if it could not resolve a base class
                // then it would report:
                //
                // error CS1714: The base class or interface of 'C' could not be resolved or is invalid
                //
                // Since we do not know what task was being performed, for now we just report a generic
                // "you must add a reference" error.

                if (containingAssembly.IsMissing)
                {
                    // error CS0012: The type 'Blah' is defined in an assembly that is not referenced. You must add a reference to assembly 'Goo'.
                    return new LanguageDiagnosticInfo(InternalErrorCode.ERR_NoTypeDef, symbol, containingAssembly.Identity);
                }
                else
                {
                    ModuleSymbol containingModule = symbol.ContainingModule;

                    if (containingModule.IsMissing)
                    {
                        // It looks like required module wasn't added to the compilation.
                        return new LanguageDiagnosticInfo(InternalErrorCode.ERR_NoTypeDefFromModule, symbol, containingModule.Name);
                    }

                    // Both the containing assembly and the module were resolved, but the type isn't.
                    //
                    // These are warnings in the native compiler, but they seem to always
                    // be accompanied by an error. It seems strange to make these warnings; something is
                    // seriously wrong in the program and it is unlikely that we'll be able to correctly
                    // generate metadata.

                    // NOTE: this is another case where we would like to base our decision on which compilation
                    // is the "current" compilation, but we don't want to force consumers of the API to specify.
                    if (containingAssembly.Dangerous_IsFromSomeCompilation)
                    {
                        // This scenario is quite tricky and involves a circular reference. Suppose we have
                        // assembly Alpha that has a type C. Assembly Beta refers to Alpha and uses type C.
                        // Now we create a new source assembly that replaces Alpha, and refers to Beta.
                        // The usage of C in Beta will be redirected to refer to the source assembly.
                        // If C is not in that source assembly then we give the following warning:

                        // CS7068: Reference to type 'C' claims it is defined in this assembly, but it is not defined in source or any added modules 
                        return new LanguageDiagnosticInfo(InternalErrorCode.ERR_MissingTypeInSource, symbol);
                    }
                    else
                    {
                        // The more straightforward scenario is that we compiled Beta against a version of Alpha
                        // that had C, and then added a reference to a different version of Alpha that
                        // lacks the type C:

                        // error CS7069: Reference to type 'C' claims it is defined in 'Alpha', but it could not be found
                        return new LanguageDiagnosticInfo(InternalErrorCode.ERR_MissingTypeInAssembly, symbol, containingAssembly.Name);
                    }
                }
            }
            return null;
        }

        public static ImmutableArray<Symbol> MakeCandidateSymbols(IErrorSymbol errorSymbol)
        {
            return ImmutableArray<Symbol>.Empty;
        }
    }
}
