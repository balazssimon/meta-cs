// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    /// <summary>
    /// Represents a non-terminal node in the syntax tree.
    /// </summary>
    //The fact that this type implements IMessageSerializable
    //enables it to be used as an argument to a diagnostic. This allows diagnostics
    //to defer the realization of strings. Often diagnostics generated while binding
    //in service of a SemanticModel API are never realized. So this
    //deferral can result in meaningful savings of strings.
    public abstract partial class MetaModelSyntaxNode : LanguageSyntaxNode, IFormattable
    {
        internal MetaModelSyntaxNode(GreenNode green, MetaModelSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        /// <summary>
        /// Used by structured trivia which has "parent == null", and therefore must know its
        /// SyntaxTree explicitly when created.
        /// </summary>
        internal MetaModelSyntaxNode(GreenNode green, int position, MetaModelSyntaxTree syntaxTree)
            : base(green, position, syntaxTree)
        {
        }

        /// <summary>
        /// The node that contains this node in its Children collection.
        /// </summary>
        internal new MetaModelSyntaxNode Parent
        {
            get
            {
                return (MetaModelSyntaxNode)base.Parent;
            }
        }

        internal new MetaModelSyntaxNode ParentOrStructuredTriviaParent
        {
            get
            {
                return (MetaModelSyntaxNode)base.ParentOrStructuredTriviaParent;
            }
        }

        /// <summary>
        /// Returns the <see cref="SyntaxKind"/> of the node.
        /// </summary>
        public SyntaxKind Kind()
        {
            return (SyntaxKind)this.RawKind;
        }

        /// <summary>
        /// The language name that this node is syntax of.
        /// </summary>
        public override Language Language
        {
            get { return MetaModelLanguage.Instance; }
        }
    }
}
