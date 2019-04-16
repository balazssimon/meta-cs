// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal static class ModifierUtils
    {
        internal static DeclarationModifiers MakeAndCheckNontypeMemberModifiers(
            SyntaxTokenList modifiers,
            DeclarationModifiers defaultAccess,
            DeclarationModifiers allowedModifiers,
            Location errorLocation,
            DiagnosticBag diagnostics,
            out bool modifierErrors)
        {
            var result = modifiers.ToDeclarationModifiers(diagnostics);
            result = CheckModifiers(result, allowedModifiers, errorLocation, diagnostics, modifiers, out modifierErrors);

            if ((result & DeclarationModifiers.AccessibilityMask) == 0)
            {
                result |= defaultAccess;
            }

            return result;
        }

        internal static DeclarationModifiers CheckModifiers(
            DeclarationModifiers modifiers,
            DeclarationModifiers allowedModifiers,
            Location errorLocation,
            DiagnosticBag diagnostics,
            SyntaxTokenList? modifierTokens,
            out bool modifierErrors)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static void ReportDefaultInterfaceImplementationModifiers(
            bool hasBody,
            DeclarationModifiers modifiers,
            DeclarationModifiers defaultInterfaceImplementationModifiers,
            Location errorLocation,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static DeclarationModifiers AdjustModifiersForAnInterfaceMember(DeclarationModifiers mods, bool hasBody, bool isExplicitInterfaceImplementation)
        {
            if ((mods & (DeclarationModifiers.Static | DeclarationModifiers.Private | DeclarationModifiers.Partial | DeclarationModifiers.Virtual | DeclarationModifiers.Abstract)) == 0 &&
                !isExplicitInterfaceImplementation)
            {
                if (hasBody || (mods & (DeclarationModifiers.Extern | DeclarationModifiers.Sealed)) != 0)
                {
                    if ((mods & DeclarationModifiers.Sealed) == 0)
                    {
                        mods |= DeclarationModifiers.Virtual;
                    }
                    else
                    {
                        mods &= ~DeclarationModifiers.Sealed;
                    }
                }
                else
                {
                    mods |= DeclarationModifiers.Abstract;
                }
            }

            if ((mods & DeclarationModifiers.AccessibilityMask) == 0)
            {
                if ((mods & DeclarationModifiers.Partial) == 0)
                {
                    mods |= isExplicitInterfaceImplementation ? DeclarationModifiers.Protected : DeclarationModifiers.Public;
                }
                else
                {
                    mods |= DeclarationModifiers.Private;
                }
            }

            return mods;
        }
        
        public static DeclarationModifiers ToDeclarationModifiers(
            this SyntaxTokenList modifiers, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static LanguageDiagnosticInfo CheckAccessibility(DeclarationModifiers modifiers, Symbol symbol, bool isExplicitInterfaceImplementation)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        // Returns declared accessibility.
        // In a case of bogus accessibility (i.e. "public private"), defaults to public.
        internal static Accessibility EffectiveAccessibility(DeclarationModifiers modifiers)
        {
            switch (modifiers & DeclarationModifiers.AccessibilityMask)
            {
                case DeclarationModifiers.None:
                    return Accessibility.NotApplicable; // for explicit interface implementation
                case DeclarationModifiers.Private:
                    return Accessibility.Private;
                case DeclarationModifiers.Protected:
                    return Accessibility.Protected;
                case DeclarationModifiers.Internal:
                    return Accessibility.Internal;
                case DeclarationModifiers.Public:
                    return Accessibility.Public;
                case DeclarationModifiers.ProtectedInternal:
                    return Accessibility.ProtectedOrInternal;
                case DeclarationModifiers.PrivateProtected:
                    return Accessibility.ProtectedAndInternal;
                default:
                    // This happens when you have a mix of accessibilities.
                    //
                    // i.e.: public private void Goo()
                    return Accessibility.Public;
            }
        }

        internal static bool IsValidAccessibility(DeclarationModifiers modifiers)
        {
            switch (modifiers & DeclarationModifiers.AccessibilityMask)
            {
                case DeclarationModifiers.None:
                case DeclarationModifiers.Private:
                case DeclarationModifiers.Protected:
                case DeclarationModifiers.Internal:
                case DeclarationModifiers.Public:
                case DeclarationModifiers.ProtectedInternal:
                case DeclarationModifiers.PrivateProtected:
                    return true;

                default:
                    // This happens when you have a mix of accessibilities.
                    //
                    // i.e.: public private void Goo()
                    return false;
            }
        }
    }
}
