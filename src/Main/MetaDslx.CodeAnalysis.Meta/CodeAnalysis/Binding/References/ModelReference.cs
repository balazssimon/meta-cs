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

        internal ModelReference(Metadata metadata, MetadataReferenceProperties properties, DocumentationProvider documentation, string filePath, string display, bool embedInCompilation)
            : base(properties, documentation ?? DocumentationProvider.Default, filePath, display, embedInCompilation)
        {
            Debug.Assert(metadata is ModelReferenceMetadata || metadata is ModelGroupReferenceMetadata);
            _metadata = metadata;
        }

        /// <summary>
        /// Create metadata reference from a MetaDslx model.
        /// </summary>
        /// <param name="model">A MetaDslx model.</param>
        /// <param name="embedInCompilation">Indicates whether the metadata reference should be embedded into the compilation, i.e., its symbols are validated and emitted by the compilation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> is null.</exception>
        public static ModelReference CreateFromModel(ImmutableModel model, bool embedInCompilation = false)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ModelReference(ModelReferenceMetadata.CreateFromModel(model), MetadataReferenceProperties.Module, DocumentationProvider.Default, null, null, embedInCompilation);
        }

        /// <summary>
        /// Create metadata reference from a MetaDslx model group.
        /// </summary>
        /// <param name="modelGroup">A MetaDslx model group.</param>
        /// <param name="embedInCompilation">Indicates whether the metadata reference should be embedded into the compilation, i.e., its symbols are validated and emitted by the compilation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelGroup"/> is null.</exception>
        public static ModelReference CreateFromModelGroup(ImmutableModelGroup modelGroup, bool embedInCompilation = false)
        {
            if (modelGroup == null)
            {
                throw new ArgumentNullException(nameof(modelGroup));
            }

            return new ModelReference(ModelGroupReferenceMetadata.CreateFromModelGroup(modelGroup), MetadataReferenceProperties.Module, DocumentationProvider.Default, null, null, embedInCompilation);
        }

        protected override Metadata GetMetadataImpl()
        {
            return _metadata;
        }

        protected override CustomReference Update(MetadataReferenceProperties properties, bool embedInCompilation)
        {
            return new ModelReference(
                _metadata,
                properties,
                this.DocumentationProvider,
                this.FilePath,
                this.Display,
                embedInCompilation);
        }

        public override string Display
        {
            get
            {
                string result = base.Display;
                if (result == null)
                {
                    if (_metadata is ModelReferenceMetadata modelMetadata) return "ModelReference: " + modelMetadata.Model.ToString();
                    if (_metadata is ModelGroupReferenceMetadata modelGroupMetadata) return "ModelGroupReference: " + modelGroupMetadata.Name;
                }
                return result;
            }
        }
    }
}
