// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Declarations
{
    /// <summary>
    /// A Declaration summarizes the declaration structure of a source file. Each entity declaration
    /// in the program that is a container (specifically namespaces, classes, interfaces, structs,
    /// and delegate declarations) is represented by a node in this tree.  At the top level, the
    /// compilation unit is treated as a declaration of the unnamed namespace.
    /// 
    /// Special treatment is required for namespace declarations, because a single namespace
    /// declaration can declare more than one namespace.  For example, in the declaration
    /// 
    ///     namespace A.B.C {}
    ///     
    /// we see that namespaces A and B and C are declared.  This declaration is represented as three
    /// declarations. All three of these ContainerDeclaration objects contain a reference to the
    /// syntax tree for the declaration.
    /// 
    /// A "single" declaration represents a specific namespace or type declaration at a point in
    /// source code. A "root" declaration is a special single declaration which summarizes the
    /// contents of an entire file's types and namespaces.  Each source file is represented as a tree
    /// of single declarations.
    /// 
    /// A "merged" declaration merges together one or more declarations for the same symbol.  For
    /// example, the root namespace has multiple single declarations (one in each source file) but
    /// there is a single merged declaration for them all.  Similarly partial classes may have
    /// multiple declarations, grouped together under the umbrella of a merged declaration.  In the
    /// common trivial case, a merged declaration for a single declaration contains only that single
    /// declaration.  The whole program, consisting of the set of all declarations in all of the
    /// source files, is represented by a tree of merged declarations.
    /// </summary>
    public abstract class Declaration
    {
        private readonly string name;
        private readonly DeclarationFlags flags;
        private readonly string parentPropertyToAddTo;

        protected Declaration(string name, bool canMerge, bool isConstructedSymbol, string parentPropertyToAddTo)
        {
            this.name = name;
            if (canMerge) this.flags |= DeclarationFlags.CanMerge;
            if (isConstructedSymbol) this.flags |= DeclarationFlags.IsConstructedSymbol;
            this.parentPropertyToAddTo = parentPropertyToAddTo;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string MetadataName
        {
            get { return this.name; } // TODO:MetaDslx
        }

        public bool CanMerge
        {
            get { return this.flags.HasFlag(DeclarationFlags.CanMerge); }
        }

        public bool IsConstructedSymbol
        {
            get { return this.flags.HasFlag(DeclarationFlags.IsConstructedSymbol); }
        }

        public string ParentPropertyToAddTo
        {
            get { return this.parentPropertyToAddTo; }
        }

        public abstract ModelSymbolInfo Kind { get; }

        public ImmutableArray<Declaration> Children
        {
            get
            {
                return GetDeclarationChildren();
            }
        }

        public abstract ImmutableArray<string> ChildNames { get; }

        protected abstract ImmutableArray<Declaration> GetDeclarationChildren();

        public bool IsType
        {
            get { return this.Kind?.IsType ?? false; }
        }

        public bool IsNamespace
        {
            get { return this.Kind?.IsNamespace ?? false; }
        }

        public bool IsName
        {
            get { return this.Kind?.IsName ?? false; }
        }

        public bool IsScript
        {
            get { return false; } // TODO:MetaDslx - for scripts, submissions and implicit classes
        }

        public bool IsSubmission
        {
            get { return false; } // TODO:MetaDslx - for scripts, submissions and implicit classes
        }

        public bool IsImplicit
        {
            get { return false; } // TODO:MetaDslx - for scripts, submissions and implicit classes
        }

        public bool HasUsings
        {
            get { return false; } // TODO:MetaDslx 
        }

        public bool HasExternAliases
        {
            get { return false; } // TODO:MetaDslx
        }
        /*
        public DeclarationModifiers Modifiers
        {
            get { return DeclarationModifiers.Public; } // TODO:MetaDslx
        }*/

        [Flags]
        private enum DeclarationFlags : byte
        {
            CanMerge = 1,
            IsConstructedSymbol = 2
        }

#if DEBUG
        private class DeclarationTreeDumper
        {
            private DeclarationTreeDumper() : base() { }

            public static string Dump(Declaration declaration)
            {
                StringBuilder sb = new StringBuilder();
                Dump(sb, string.Empty, declaration);
                return sb.ToString();
            }

            private static void Dump(StringBuilder sb, string indent, Declaration declaration)
            {
                if (declaration == null) return;
                string kind;
                if (declaration.IsNamespace) kind = "namespace";
                else if (declaration.IsType) kind = "type";
                else if (declaration.IsName) kind = "name";
                else kind = "unknown";
                sb.AppendFormat("{0}{1} ({2}): {3}", indent, declaration.Name, kind, declaration.Kind?.ImmutableType.Name ?? "<root>");
                sb.AppendLine();
                foreach (var child in declaration.GetDeclarationChildren())
                {
                    Dump(sb, indent + "  ", child);
                }
            }
        }

        public virtual string Dump()
        {
            return DeclarationTreeDumper.Dump(this);
        }
#endif
    }
}
