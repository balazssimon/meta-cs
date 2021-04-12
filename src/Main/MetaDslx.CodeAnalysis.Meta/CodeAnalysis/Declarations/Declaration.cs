// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
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
        private DeclarationKind kind;

        protected Declaration(string name, DeclarationKind kind, bool merge, bool hasUsings, bool isNestingParent)
        {
            this.name = name;
            if (merge) this.flags |= DeclarationFlags.Merge;
            if (hasUsings) this.flags |= DeclarationFlags.HasImports;
            if (isNestingParent) this.flags |= DeclarationFlags.IsNestingParent;
            this.kind = kind;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string MetadataName
        {
            get { return this.name; } // TODO:MetaDslx
        }

        public bool Merge
        {
            get { return this.flags.HasFlag(DeclarationFlags.Merge); }
        }

        public bool IsNestingParent
        {
            get { return this.flags.HasFlag(DeclarationFlags.IsNestingParent); }
        }

        public abstract Type SymbolType { get; }
        public abstract Type ModelObjectType { get; }

        public ImmutableArray<Declaration> Children
        {
            get
            {
                return GetDeclarationChildren();
            }
        }

        public abstract ImmutableArray<string> ChildNames { get; }

        protected abstract ImmutableArray<Declaration> GetDeclarationChildren();

        public DeclarationKind Kind => kind;

        public bool IsType => kind == DeclarationKind.Type;

        public bool IsNamespace => kind == DeclarationKind.Namespace;

        public bool IsScript => kind == DeclarationKind.Script;

        public bool IsSubmission => kind == DeclarationKind.Submission;

        public bool IsImplicit => kind == DeclarationKind.Implicit;

        public bool HasImports => this.flags.HasFlag(DeclarationFlags.HasImports);

        /*
        public DeclarationModifiers Modifiers
        {
            get { return DeclarationModifiers.Public; } // TODO:MetaDslx
        }*/

        [Flags]
        private enum DeclarationFlags : byte
        {
            Merge = 0x01,
            IsNestingParent = 0x02,
            HasImports = 0x04
        }

        public override string ToString()
        {
            return $"{ModelObjectType?.Name} {Name}";
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
                sb.AppendFormat("{0}{1} {2}: {3}", indent, declaration.Kind.ToString().ToLower(), declaration.Name, declaration.ModelObjectType.Name ?? "<root>");
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
