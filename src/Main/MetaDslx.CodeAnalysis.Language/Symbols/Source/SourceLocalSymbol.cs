// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Binding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents a local variable in a method body.
    /// </summary>
    internal class SourceLocalSymbol : LocalSymbol
    {
        private readonly Binder _scopeBinder;

        /// <summary>
        /// Might not be a method symbol.
        /// </summary>
        private readonly Symbol _containingSymbol;

        private readonly SyntaxToken _identifierToken;
        private readonly ImmutableArray<Location> _locations;
        private readonly RefKind _refKind;
        private readonly CSharpSyntaxNode _typeSyntax;
        private readonly LocalDeclarationKind _declarationKind;
        private TypeWithAnnotations.Builder _type;

        /// <summary>
        /// Scope to which the local can "escape" via aliasing/ref assignment.
        /// Not readonly because we can only know escape values after binding the initializer.
        /// </summary>
        protected uint _refEscapeScope;

        /// <summary>
        /// Scope to which the local's values can "escape" via ordinary assignments.
        /// Not readonly because we can only know escape values after binding the initializer.
        /// </summary>
        protected uint _valEscapeScope;

        private SourceLocalSymbol(
            Symbol containingSymbol,
            Binder scopeBinder,
            bool allowRefKind,
            CSharpSyntaxNode typeSyntax,
            SyntaxToken identifierToken,
            LocalDeclarationKind declarationKind)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Binder that owns the scope for the local, the one that returns it in its <see cref="Binder.Locals"/> array.
        /// </summary>
        internal Binder ScopeBinder
        {
            get { return _scopeBinder; }
        }

        internal override SyntaxNode ScopeDesignatorOpt
        {
            get { return _scopeBinder.ScopeDesignator; }
        }

        internal override uint RefEscapeScope => _refEscapeScope;

        internal override uint ValEscapeScope => _valEscapeScope;

        /// <summary>
        /// Binder that should be used to bind type syntax for the local.
        /// </summary>
        internal Binder TypeSyntaxBinder
        {
            get { return _scopeBinder; } // Scope binder should be good enough for this.
        }

        // When the variable's type has not yet been inferred,
        // don't let the debugger force inference.
        internal override string GetDebuggerDisplay()
        {
            return !_type.IsDefault
                ? base.GetDebuggerDisplay()
                : $"{this.Kind} <var> ${this.Name}";
        }

        internal override bool IsImportedFromMetadata
        {
            get { return false; }
        }

        internal override LocalDeclarationKind DeclarationKind
        {
            get { return _declarationKind; }
        }

        internal override SynthesizedLocalKind SynthesizedKind
        {
            get { return SynthesizedLocalKind.UserDefined; }
        }

        internal override LocalSymbol WithSynthesizedLocalKindAndSyntax(SynthesizedLocalKind kind, SyntaxNode syntax)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal override bool IsPinned
        {
            get
            {
                // even when dealing with "fixed" locals it is the underlying managed reference that gets pinned
                // the pointer variable itself is not pinned.
                return false;
            }
        }

        internal virtual void SetRefEscape(uint value)
        {
            _refEscapeScope = value;
        }

        internal virtual void SetValEscape(uint value)
        {
            _valEscapeScope = value;
        }

        public override Symbol ContainingSymbol
        {
            get { return _containingSymbol; }
        }

        /// <summary>
        /// Gets the name of the local variable.
        /// </summary>
        public override string Name
        {
            get
            {
                return _identifierToken.ValueText;
            }
        }

        // Get the identifier token that defined this local symbol. This is useful for robustly
        // checking if a local symbol actually matches a particular definition, even in the presence
        // of duplicates.
        internal override SyntaxToken IdentifierToken
        {
            get
            {
                return _identifierToken;
            }
        }

#if DEBUG
        // We use this to detect infinite recursion in type inference.
        private int concurrentTypeResolutions = 0;
#endif

        public override TypeWithAnnotations TypeWithAnnotations
        {
            get
            {
                if (_type.IsDefault)
                {
#if DEBUG
                    concurrentTypeResolutions++;
                    Debug.Assert(concurrentTypeResolutions < 50);
#endif
                    TypeWithAnnotations localType = GetTypeSymbol();
                    SetTypeWithAnnotations(localType);
                }

                return _type.ToType();
            }
        }

        public bool IsVar
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        private TypeWithAnnotations GetTypeSymbol()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected virtual TypeWithAnnotations InferTypeOfVarVariable(DiagnosticBag diagnostics)
        {
            // TODO: this method must be overridden for pattern variables to bind the
            // expression or statement that is the nearest enclosing to the pattern variable's
            // declaration. That will cause the type of the pattern variable to be set as a side-effect.
            return _type.ToType();
        }

        internal void SetTypeWithAnnotations(TypeWithAnnotations newType)
        {
            Debug.Assert(!(newType.Type is null));
            TypeSymbol originalType = _type.DefaultType;

            // In the event that we race to set the type of a local, we should
            // always deduce the same type, or deduce that the type is an error.

            Debug.Assert((object)originalType == null ||
                originalType.IsErrorType() && newType.Type.IsErrorType() ||
                TypeSymbol.Equals(originalType, newType.Type, TypeCompareKind.ConsiderEverything2));

            if ((object)originalType == null)
            {
                _type.InterlockedInitialize(newType);
            }
        }

        /// <summary>
        /// Gets the locations where the local symbol was originally defined in source.
        /// There should not be local symbols from metadata, and there should be only one local variable declared.
        /// TODO: check if there are multiple same name local variables - error symbol or local symbol?
        /// </summary>
        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _locations;
            }
        }

        internal sealed override SyntaxNode GetDeclaratorSyntax()
        {
            return _identifierToken.Parent;
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        internal override bool IsCompilerGenerated
        {
            get { return false; }
        }

        internal override ConstantValue GetConstantValue(SyntaxNode node, LocalSymbol inProgress, DiagnosticBag diagnostics)
        {
            return null;
        }

        internal override ImmutableArray<Diagnostic> GetConstantValueDiagnostics(BoundExpression boundInitValue)
        {
            return ImmutableArray<Diagnostic>.Empty;
        }

        public override RefKind RefKind
        {
            get { return _refKind; }
        }

        public sealed override bool Equals(object obj)
        {
            if (obj == (object)this)
            {
                return true;
            }

            var symbol = obj as SourceLocalSymbol;
            return (object)symbol != null
                && symbol._identifierToken.Equals(_identifierToken)
                && Equals(symbol._containingSymbol, _containingSymbol);
        }

        public sealed override int GetHashCode()
        {
            return Hash.Combine(_identifierToken.GetHashCode(), _containingSymbol.GetHashCode());
        }
    }
}
