// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents an in-memory Portable-Executable image.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public sealed class ModelReference : PortableExecutableReference
    {
        private readonly string _display;
        private readonly Metadata _metadata;

        internal ModelReference(Metadata metadata, MetadataReferenceProperties properties, DocumentationProvider documentation, string filePath, string display)
            : base(properties, filePath, documentation ?? DocumentationProvider.Default)
        {
            Debug.Assert(metadata is ModelMetadata || metadata is ModelGroupMetadata);
            _display = display;
            _metadata = metadata;
        }

        /// <summary>
        /// Create metadata reference from a MetaDslx model.
        /// </summary>
        /// <param name="model">A MetaDslx model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> is null.</exception>
        public static ModelReference CreateFromModel(ImmutableModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ModelReference(ModelMetadata.CreateFromModel(model), MetadataReferenceProperties.Module, DocumentationProvider.Default, null, null);
        }

        /// <summary>
        /// Create metadata reference from a MetaDslx model group.
        /// </summary>
        /// <param name="model">A MetaDslx model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelGroup"/> is null.</exception>
        public static ModelReference CreateFromModelGroup(ImmutableModelGroup modelGroup)
        {
            if (modelGroup == null)
            {
                throw new ArgumentNullException(nameof(modelGroup));
            }

            return new ModelReference(ModelGroupMetadata.CreateFromModelGroup(modelGroup), MetadataReferenceProperties.Module, DocumentationProvider.Default, null, null);
        }

        protected override Metadata GetMetadataImpl()
        {
            return _metadata;
        }

        protected override DocumentationProvider CreateDocumentationProvider()
        {
            // documentation provider is initialized in the constructor
            throw ExceptionUtilities.Unreachable;
        }

        protected override PortableExecutableReference WithPropertiesImpl(MetadataReferenceProperties properties)
        {
            return new ModelReference(
                _metadata,
                properties,
                this.DocumentationProvider,
                this.FilePath,
                _display);
        }

        public override string Display
        {
            get
            {
                return _display ?? FilePath ?? (_metadata as ModelMetadata)?.Model?.ToString() ?? "ModelReference";
            }
        }

        private string GetDebuggerDisplay()
        {
            var sb = new StringBuilder();
            sb.Append(Properties.Kind == MetadataImageKind.Module ? "Module" : "Assembly");
            if (!Properties.Aliases.IsEmpty)
            {
                sb.Append(" Aliases={");
                sb.Append(string.Join(", ", Properties.Aliases));
                sb.Append("}");
            }

            if (Properties.EmbedInteropTypes)
            {
                sb.Append(" Embed");
            }

            if (FilePath != null)
            {
                sb.Append(" Path='");
                sb.Append(FilePath);
                sb.Append("'");
            }

            if (_display != null)
            {
                sb.Append(" Display='");
                sb.Append(_display);
                sb.Append("'");
            }

            return sb.ToString();
        }
    }
}
