// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents an in-memory MetaDslx model image.
    /// </summary>
    public sealed class ModelReference : CustomReference
    {
        private readonly Metadata _metadata;

        internal ModelReference(Metadata metadata, MetadataReferenceProperties properties, DocumentationProvider documentation, string filePath, string display)
            : base(properties, documentation ?? DocumentationProvider.Default, filePath, display)
        {
            Debug.Assert(metadata is ModelMetadata || metadata is ModelGroupMetadata);
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

        protected override CustomReference WithPropertiesImpl(MetadataReferenceProperties properties)
        {
            return new ModelReference(
                _metadata,
                properties,
                this.DocumentationProvider,
                this.FilePath,
                this.Display);
        }

        public override string Display
        {
            get
            {
                string result = base.Display;
                if (result == null)
                {
                    if (_metadata is ModelMetadata modelMetadata) return "ModelReference: " + modelMetadata.Model.ToString();
                    if (_metadata is ModelGroupMetadata modelGroupMetadata) return "ModelGroupReference: " + modelGroupMetadata.Name;
                }
                return result;
            }
        }
    }
}
