// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;
using Microsoft.CodeAnalysis.CodeGen;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents an attribute applied to a Symbol.
    /// </summary>
    internal abstract partial class CSharpAttributeData : AttributeData
    {
        private ThreeState _lazyIsSecurityAttribute = ThreeState.Unknown;

        /// <summary>
        /// Gets the attribute class being applied.
        /// </summary>
        public new abstract NamedTypeSymbol AttributeClass { get; }

        /// <summary>
        /// Gets the constructor used in this application of the attribute.
        /// </summary>
        public new abstract MethodSymbol AttributeConstructor { get; }

        /// <summary>
        /// Gets a reference to the source for this application of the attribute. Returns null for applications of attributes on metadata Symbols.
        /// </summary>
        public new abstract SyntaxReference ApplicationSyntaxReference { get; }

        /// <summary>
        /// Gets the list of constructor arguments specified by this application of the attribute.  This list contains both positional arguments
        /// and named arguments that are formal parameters to the constructor.
        /// </summary>
        public new IEnumerable<TypedConstant> ConstructorArguments
        {
            get { return this.CommonConstructorArguments; }
        }

        /// <summary>
        /// Gets the list of named field or property value arguments specified by this application of the attribute.
        /// </summary>
        public new IEnumerable<KeyValuePair<string, TypedConstant>> NamedArguments
        {
            get { return this.CommonNamedArguments; }
        }

        /// <summary>
        /// Compares the namespace and type name with the attribute's namespace and type name.
        /// Returns true if they are the same.
        /// </summary>
        internal virtual bool IsTargetAttribute(string namespaceName, string typeName)
        {
            if (!this.AttributeClass.Name.Equals(typeName))
            {
                return false;
            }

            if (this.AttributeClass.IsErrorType() && !(this.AttributeClass is MissingMetadataTypeSymbol))
            {
                // Can't guarantee complete name information.
                return false;
            }

            return this.AttributeClass.HasNameQualifier(namespaceName);
        }

        internal bool IsTargetAttribute(Symbol targetSymbol, AttributeDescription description)
        {
            return GetTargetAttributeSignatureIndex(targetSymbol, description) != -1;
        }

        internal abstract int GetTargetAttributeSignatureIndex(Symbol targetSymbol, AttributeDescription description);

        /// <summary>
        /// Checks if an applied attribute with the given attributeType matches the namespace name and type name of the given early attribute's description
        /// and the attribute description has a signature with parameter count equal to the given attribute syntax's argument list count.
        /// NOTE: We don't allow early decoded attributes to have optional parameters.
        /// </summary>
        internal static bool IsTargetEarlyAttribute(NamedTypeSymbol attributeType, CSharpSyntaxNode attributeSyntax, AttributeDescription description)
        {
            Debug.Assert(!attributeType.IsErrorType());
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        // Security attributes, i.e. attributes derived from well-known SecurityAttribute, are matched by type, not constructor signature.
        internal bool IsSecurityAttribute(CSharpCompilation compilation)
        {
            if (_lazyIsSecurityAttribute == ThreeState.Unknown)
            {
                Debug.Assert(!this.HasErrors);

                // CLI spec (Partition II Metadata), section 21.11 "DeclSecurity : 0x0E" states:
                // SPEC:    If the attribute's type is derived (directly or indirectly) from System.Security.Permissions.SecurityAttribute then
                // SPEC:    it is a security custom attribute and requires special treatment.

                // NOTE:    The native C# compiler violates the above and considers only those attributes whose type derives from
                // NOTE:    System.Security.Permissions.CodeAccessSecurityAttribute as security custom attributes.
                // NOTE:    We will follow the specification.
                // NOTE:    See Devdiv Bug #13762 "Custom security attributes deriving from SecurityAttribute are not treated as security attributes" for details.

                // Well-known type SecurityAttribute is optional.
                // Native compiler doesn't generate a use-site error if it is not found, we do the same.
                var wellKnownType = compilation.GetWellKnownType(WellKnownType.System_Security_Permissions_SecurityAttribute);
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                _lazyIsSecurityAttribute = AttributeClass.IsDerivedFrom(wellKnownType, TypeCompareKind.ConsiderEverything, useSiteDiagnostics: ref useSiteDiagnostics).ToThreeState();
            }

            return _lazyIsSecurityAttribute.Value();
        }

        // for testing and debugging only

        /// <summary>
        /// Returns the <see cref="System.String"/> that represents the current AttributeData.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current AttributeData.</returns>
        public override string ToString()
        {
            if ((object)this.AttributeClass != null)
            {
                string className = this.AttributeClass.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat);

                if (!this.CommonConstructorArguments.Any() & !this.CommonNamedArguments.Any())
                {
                    return className;
                }

                var pooledStrbuilder = PooledStringBuilder.GetInstance();
                StringBuilder stringBuilder = pooledStrbuilder.Builder;

                stringBuilder.Append(className);
                stringBuilder.Append("(");

                bool first = true;

                foreach (var constructorArgument in this.CommonConstructorArguments)
                {
                    if (!first)
                    {
                        stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(constructorArgument.ToCSharpString());
                    first = false;
                }

                foreach (var namedArgument in this.CommonNamedArguments)
                {
                    if (!first)
                    {
                        stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(namedArgument.Key);
                    stringBuilder.Append(" = ");
                    stringBuilder.Append(namedArgument.Value.ToCSharpString());
                    first = false;
                }

                stringBuilder.Append(")");

                return pooledStrbuilder.ToStringAndFree();
            }

            return base.ToString();
        }

        #region AttributeData Implementation

        /// <summary>
        /// Gets the attribute class being applied as an <see cref="INamedTypeSymbol"/>
        /// </summary>
        protected override INamedTypeSymbol CommonAttributeClass
        {
            get { return this.AttributeClass; }
        }

        /// <summary>
        /// Gets the constructor used in this application of the attribute as an <see cref="IMethodSymbol"/>.
        /// </summary>
        protected override IMethodSymbol CommonAttributeConstructor
        {
            get { return this.AttributeConstructor; }
        }

        /// <summary>
        /// Gets a reference to the source for this application of the attribute. Returns null for applications of attributes on metadata Symbols.
        /// </summary>
        protected override SyntaxReference CommonApplicationSyntaxReference
        {
            get { return this.ApplicationSyntaxReference; }
        }
        #endregion

        #region Attribute Decoding

        internal void DecodeSecurityAttribute<T>(Symbol targetSymbol, CSharpCompilation compilation, ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
            where T : WellKnownAttributeData, ISecurityAttributeTarget, new()
        {
            Debug.Assert(!this.HasErrors);

            bool hasErrors;
            DeclarativeSecurityAction action = DecodeSecurityAttributeAction(targetSymbol, compilation, arguments.AttributeSyntaxOpt, out hasErrors, arguments.Diagnostics);

            if (!hasErrors)
            {
                T data = arguments.GetOrCreateData<T>();
                SecurityWellKnownAttributeData securityData = data.GetOrCreateData();
                securityData.SetSecurityAttribute(arguments.Index, action, arguments.AttributesCount);

                if (this.IsTargetAttribute(targetSymbol, AttributeDescription.PermissionSetAttribute))
                {
                    string resolvedPathForFixup = DecodePermissionSetAttribute(compilation, arguments.AttributeSyntaxOpt, arguments.Diagnostics);
                    if (resolvedPathForFixup != null)
                    {
                        securityData.SetPathForPermissionSetAttributeFixup(arguments.Index, resolvedPathForFixup, arguments.AttributesCount);
                    }
                }
            }
        }

        private DeclarativeSecurityAction DecodeSecurityAttributeAction(Symbol targetSymbol, CSharpCompilation compilation, CSharpSyntaxNode nodeOpt, out bool hasErrors, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Decodes PermissionSetAttribute applied in source to determine if it needs any fixup during codegen.
        /// </summary>
        /// <remarks>
        /// PermissionSetAttribute needs fixup when it contains an assignment to the 'File' property as a single named attribute argument.
        /// Fixup performed is ported from SecurityAttributes::FixUpPermissionSetAttribute.
        /// It involves following steps:
        ///  1) Verifying that the specified file name resolves to a valid path.
        ///  2) Reading the contents of the file into a byte array.
        ///  3) Convert each byte in the file content into two bytes containing hexadecimal characters.
        ///  4) Replacing the 'File = fileName' named argument with 'Hex = hexFileContent' argument, where hexFileContent is the converted output from step 3) above.
        ///
        /// Step 1) is performed in this method, i.e. during binding.
        /// Remaining steps are performed during serialization as we want to avoid retaining the entire file contents throughout the binding/codegen pass.
        /// See <see cref="Microsoft.CodeAnalysis.CodeGen.PermissionSetAttributeWithFileReference"/> for remaining fixup steps.
        /// </remarks>
        /// <returns>String containing the resolved file path if PermissionSetAttribute needs fixup during codegen, null otherwise.</returns>
        private string DecodePermissionSetAttribute(CSharpCompilation compilation, CSharpSyntaxNode nodeOpt, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal void DecodeClassInterfaceAttribute(CSharpSyntaxNode nodeOpt, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal void DecodeInterfaceTypeAttribute(CSharpSyntaxNode node, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal string DecodeGuidAttribute(CSharpSyntaxNode nodeOpt, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        #endregion

        /// <summary>
        /// This method determines if an applied attribute must be emitted.
        /// Some attributes appear in symbol model to reflect the source code,
        /// but should not be emitted.
        /// </summary>
        internal bool ShouldEmitAttribute(Symbol target, bool isReturnType, bool emittingAssemblyAttributesInNetModule)
        {
            Debug.Assert(target is SourceAssemblySymbol || target.ContainingAssembly is SourceAssemblySymbol);

            if (HasErrors)
            {
                throw ExceptionUtilities.Unreachable;
            }

            // Attribute type is conditionally omitted if both the following are true:
            //  (a) It has at least one applied/inherited conditional attribute AND
            //  (b) None of conditional symbols are defined in the source file where the given attribute was defined.
            if (this.IsConditionallyOmitted)
            {
                return false;
            }

            switch (target.Kind)
            {
                case SymbolKind.Assembly:
                    if ((!emittingAssemblyAttributesInNetModule &&
                            (IsTargetAttribute(target, AttributeDescription.AssemblyCultureAttribute) ||
                             IsTargetAttribute(target, AttributeDescription.AssemblyVersionAttribute) ||
                             IsTargetAttribute(target, AttributeDescription.AssemblyFlagsAttribute) ||
                             IsTargetAttribute(target, AttributeDescription.AssemblyAlgorithmIdAttribute))) ||
                        IsTargetAttribute(target, AttributeDescription.TypeForwardedToAttribute) ||
                        IsSecurityAttribute(target.DeclaringCompilation))
                    {
                        return false;
                    }

                    break;

                case SymbolKind.Event:
                    if (IsTargetAttribute(target, AttributeDescription.SpecialNameAttribute))
                    {
                        return false;
                    }

                    break;

                case SymbolKind.Field:
                    if (IsTargetAttribute(target, AttributeDescription.SpecialNameAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.NonSerializedAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.FieldOffsetAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.MarshalAsAttribute))
                    {
                        return false;
                    }

                    break;

                case SymbolKind.Method:
                    if (isReturnType)
                    {
                        if (IsTargetAttribute(target, AttributeDescription.MarshalAsAttribute))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (IsTargetAttribute(target, AttributeDescription.SpecialNameAttribute) ||
                            IsTargetAttribute(target, AttributeDescription.MethodImplAttribute) ||
                            IsTargetAttribute(target, AttributeDescription.DllImportAttribute) ||
                            IsTargetAttribute(target, AttributeDescription.PreserveSigAttribute) ||
                            IsTargetAttribute(target, AttributeDescription.DynamicSecurityMethodAttribute) ||
                            IsSecurityAttribute(target.DeclaringCompilation))
                        {
                            return false;
                        }
                    }

                    break;

                case SymbolKind.NetModule:
                    // Note that DefaultCharSetAttribute is emitted to metadata, although it's also decoded and used when emitting P/Invoke
                    break;

                case SymbolKind.NamedType:
                    if (IsTargetAttribute(target, AttributeDescription.SpecialNameAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.ComImportAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.SerializableAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.StructLayoutAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.WindowsRuntimeImportAttribute) ||
                        IsSecurityAttribute(target.DeclaringCompilation))
                    {
                        return false;
                    }

                    break;

                case SymbolKind.Parameter:
                    if (IsTargetAttribute(target, AttributeDescription.OptionalAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.DefaultParameterValueAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.InAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.OutAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.MarshalAsAttribute))
                    {
                        return false;
                    }

                    break;

                case SymbolKind.Property:
                    if (IsTargetAttribute(target, AttributeDescription.IndexerNameAttribute) ||
                        IsTargetAttribute(target, AttributeDescription.SpecialNameAttribute))
                    {
                        return false;
                    }

                    break;
            }

            return true;
        }
    }

    internal static class AttributeDataExtensions
    {
        internal static int IndexOfAttribute(this ImmutableArray<CSharpAttributeData> attributes, Symbol targetSymbol, AttributeDescription description)
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].IsTargetAttribute(targetSymbol, description))
                {
                    return i;
                }
            }

            return -1;
        }

        internal static CSharpSyntaxNode GetAttributeArgumentSyntax(this AttributeData attribute, int parameterIndex, CSharpSyntaxNode attributeSyntax)
        {
            Debug.Assert(attribute is SourceAttributeData);
            return ((SourceAttributeData)attribute).GetAttributeArgumentSyntax(parameterIndex, attributeSyntax);
        }

        internal static Location GetAttributeArgumentSyntaxLocation(this AttributeData attribute, int parameterIndex, CSharpSyntaxNode attributeSyntaxOpt)
        {
            if (attributeSyntaxOpt == null)
            {
                return NoLocation.Singleton;
            }

            Debug.Assert(attribute is SourceAttributeData);
            return ((SourceAttributeData)attribute).GetAttributeArgumentSyntax(parameterIndex, attributeSyntaxOpt).Location;
        }
    }
}
