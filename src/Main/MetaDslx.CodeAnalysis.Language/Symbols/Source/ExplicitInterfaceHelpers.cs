// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal static class ExplicitInterfaceHelpers
    {
        public static string GetMemberName(
            Binder binder,
            CSharpSyntaxNode explicitInterfaceSpecifierOpt,
            string name)
        {
            DiagnosticBag discardedDiagnostics = DiagnosticBag.GetInstance();
            TypeSymbol discardedExplicitInterfaceType;
            string discardedAliasOpt;
            string methodName = GetMemberNameAndInterfaceSymbol(binder, explicitInterfaceSpecifierOpt, name, discardedDiagnostics, out discardedExplicitInterfaceType, out discardedAliasOpt);
            discardedDiagnostics.Free();

            return methodName;
        }

        public static string GetMemberNameAndInterfaceSymbol(
            Binder binder,
            CSharpSyntaxNode explicitInterfaceSpecifierOpt,
            string name,
            DiagnosticBag diagnostics,
            out TypeSymbol explicitInterfaceTypeOpt,
            out string aliasQualifierOpt)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public static string GetMemberName(string name, TypeSymbol explicitInterfaceTypeOpt, string aliasQualifierOpt)
        {
            if ((object)explicitInterfaceTypeOpt == null)
            {
                return name;
            }

            // TODO: Revisit how explicit interface implementations are named.
            // CONSIDER (vladres): we should never generate identical names for different methods.

            string interfaceName = explicitInterfaceTypeOpt.ToDisplayString(SymbolDisplayFormat.ExplicitInterfaceImplementationFormat);

            PooledStringBuilder pooled = PooledStringBuilder.GetInstance();
            StringBuilder builder = pooled.Builder;

            if (!string.IsNullOrEmpty(aliasQualifierOpt))
            {
                builder.Append(aliasQualifierOpt);
                builder.Append("::");
            }

            foreach (char ch in interfaceName)
            {
                // trim spaces to match metadata name (more closely - could still be truncated)
                if (ch != ' ')
                {
                    builder.Append(ch);
                }
            }

            builder.Append(".");
            builder.Append(name);

            return pooled.ToStringAndFree();
        }

        public static string GetMethodNameWithoutInterfaceName(this MethodSymbol method)
        {
            if (method.MethodKind != MethodKind.ExplicitInterfaceImplementation)
            {
                return method.Name;
            }

            return GetMemberNameWithoutInterfaceName(method.Name);
        }

        public static string GetMemberNameWithoutInterfaceName(string fullName)
        {
            var idx = fullName.LastIndexOf('.');
            Debug.Assert(idx < fullName.Length);
            return (idx > 0) ? fullName.Substring(idx + 1) : fullName; //don't consider leading dots
        }

        public static ImmutableArray<T> SubstituteExplicitInterfaceImplementations<T>(ImmutableArray<T> unsubstitutedExplicitInterfaceImplementations, TypeMap map) where T : Symbol
        {
            var builder = ArrayBuilder<T>.GetInstance();
            foreach (var unsubstitutedPropertyImplemented in unsubstitutedExplicitInterfaceImplementations)
            {
                var unsubstitutedInterfaceType = unsubstitutedPropertyImplemented.ContainingType;
                Debug.Assert((object)unsubstitutedInterfaceType != null);
                var explicitInterfaceType = map.SubstituteNamedType(unsubstitutedInterfaceType);
                Debug.Assert((object)explicitInterfaceType != null);
                var name = unsubstitutedPropertyImplemented.Name; //should already be unqualified

                T substitutedMemberImplemented = null;
                foreach (var candidateMember in explicitInterfaceType.GetMembers(name))
                {
                    if (candidateMember.OriginalDefinition == unsubstitutedPropertyImplemented.OriginalDefinition)
                    {
                        substitutedMemberImplemented = (T)candidateMember;
                        break;
                    }
                }
                Debug.Assert((object)substitutedMemberImplemented != null); //if it was an explicit implementation before the substitution, it should still be after
                builder.Add(substitutedMemberImplemented);
            }

            return builder.ToImmutableAndFree();
        }

        internal static MethodSymbol FindExplicitlyImplementedMethod(
            this MethodSymbol implementingMethod,
            TypeSymbol explicitInterfaceType,
            string interfaceMethodName,
            CSharpSyntaxNode explicitInterfaceSpecifierSyntax,
            DiagnosticBag diagnostics)
        {
            return (MethodSymbol)FindExplicitlyImplementedMember(implementingMethod, explicitInterfaceType, interfaceMethodName, explicitInterfaceSpecifierSyntax, diagnostics);
        }

        internal static PropertySymbol FindExplicitlyImplementedProperty(
            this PropertySymbol implementingProperty,
            TypeSymbol explicitInterfaceType,
            string interfacePropertyName,
            CSharpSyntaxNode explicitInterfaceSpecifierSyntax,
            DiagnosticBag diagnostics)
        {
            return (PropertySymbol)FindExplicitlyImplementedMember(implementingProperty, explicitInterfaceType, interfacePropertyName, explicitInterfaceSpecifierSyntax, diagnostics);
        }

        internal static EventSymbol FindExplicitlyImplementedEvent(
            this EventSymbol implementingEvent,
            TypeSymbol explicitInterfaceType,
            string interfaceEventName,
            CSharpSyntaxNode explicitInterfaceSpecifierSyntax,
            DiagnosticBag diagnostics)
        {
            return (EventSymbol)FindExplicitlyImplementedMember(implementingEvent, explicitInterfaceType, interfaceEventName, explicitInterfaceSpecifierSyntax, diagnostics);
        }

        private static Symbol FindExplicitlyImplementedMember(
            Symbol implementingMember,
            TypeSymbol explicitInterfaceType,
            string interfaceMemberName,
            CSharpSyntaxNode explicitInterfaceSpecifierSyntax,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static void FindExplicitlyImplementedMemberVerification(
            this Symbol implementingMember,
            Symbol implementedMember,
            DiagnosticBag diagnostics)
        {
            if ((object)implementedMember == null)
            {
                return;
            }

            if (implementingMember.ContainsTupleNames() && MemberSignatureComparer.ConsideringTupleNamesCreatesDifference(implementingMember, implementedMember))
            {
                // it is ok to explicitly implement with no tuple names, for compatibility with C# 6, but otherwise names should match
                var memberLocation = implementingMember.Locations[0];
                diagnostics.Add(ErrorCode.ERR_ImplBadTupleNames, memberLocation, implementingMember, implementedMember);
            }

            // In constructed types, it is possible that two method signatures could differ by only ref/out
            // after substitution.  We look for this as part of explicit implementation because, if someone
            // tried to implement the ambiguous interface implicitly, we would separately raise an error about
            // the implicit implementation methods differing by only ref/out.
            FindExplicitImplementationCollisions(implementingMember, implementedMember, diagnostics);
        }

        /// <summary>
        /// Given a member, look for other members contained in the same type with signatures that will
        /// not be distinguishable by the runtime.
        /// </summary>
        private static void FindExplicitImplementationCollisions(Symbol implementingMember, Symbol implementedMember, DiagnosticBag diagnostics)
        {
            if ((object)implementedMember == null)
            {
                return;
            }

            NamedTypeSymbol explicitInterfaceType = implementedMember.ContainingType;
            bool explicitInterfaceTypeIsDefinition = explicitInterfaceType.IsDefinition; //no runtime ref/out ambiguities if this is true

            foreach (Symbol collisionCandidateMember in explicitInterfaceType.GetMembers(implementedMember.Name))
            {
                if (collisionCandidateMember.Kind == implementingMember.Kind && implementedMember != collisionCandidateMember)
                {
                    // NOTE: we are more precise than Dev10 - we will not generate a diagnostic if the return types differ 
                    // because that is enough to distinguish them in the runtime.
                    if (!explicitInterfaceTypeIsDefinition && MemberSignatureComparer.RuntimeSignatureComparer.Equals(implementedMember, collisionCandidateMember))
                    {
                        bool foundMismatchedRefKind = false;
                        ImmutableArray<ParameterSymbol> implementedMemberParameters = implementedMember.GetParameters();
                        ImmutableArray<ParameterSymbol> collisionCandidateParameters = collisionCandidateMember.GetParameters();
                        int numParams = implementedMemberParameters.Length;
                        for (int i = 0; i < numParams; i++)
                        {
                            if (implementedMemberParameters[i].RefKind != collisionCandidateParameters[i].RefKind)
                            {
                                foundMismatchedRefKind = true;
                                break;
                            }
                        }

                        if (foundMismatchedRefKind)
                        {
                            diagnostics.Add(ErrorCode.ERR_ExplicitImplCollisionOnRefOut, explicitInterfaceType.Locations[0], explicitInterfaceType, implementedMember);
                        }
                        else
                        {
                            //UNDONE: related locations for conflicting members - keep iterating to find others?
                            diagnostics.Add(ErrorCode.WRN_ExplicitImplCollision, implementingMember.Locations[0], implementingMember);
                        }
                        break;
                    }
                    else
                    {
                        if (MemberSignatureComparer.ExplicitImplementationComparer.Equals(implementedMember, collisionCandidateMember))
                        {
                            // NOTE: this is different from the same error code above.  Above, the diagnostic means that
                            // the runtime behavior is ambiguous because the runtime cannot distinguish between two or
                            // more interface members.  This diagnostic means that *C#* cannot distinguish between two
                            // or more interface members (because of custom modifiers).
                            diagnostics.Add(ErrorCode.WRN_ExplicitImplCollision, implementingMember.Locations[0], implementingMember);
                        }
                    }
                }
            }
        }
    }
}
