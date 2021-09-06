// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents an immutable snapshot of module CLI metadata.
    /// </summary>
    /// <remarks>This object may allocate significant resources or lock files depending upon how it is constructed.</remarks>
    public sealed partial class ModelReferenceMetadata : Metadata
    {

        private readonly ImmutableModel _model;

        private ModelReferenceMetadata(ImmutableModel model)
            : base(isImageOwner: true, id: MetadataId.CreateNewId())
        {
            _model = model;
        }

        // creates a copy
        private ModelReferenceMetadata(ModelReferenceMetadata metadata)
            : base(isImageOwner: false, id: metadata.Id)
        {
            _model = metadata.Model;
        }

        /// <summary>
        /// Create metadata module from a MetaDslx model.
        /// </summary>
        /// <param name="model">A MetaDslx model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> is null.</exception>
        public static ModelReferenceMetadata CreateFromModel(ImmutableModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ModelReferenceMetadata(model);
        }

        /// <summary>
        /// Creates a shallow copy of this object.
        /// </summary>
        /// <remarks>
        /// The resulting copy shares the metadata image and metadata information read from it with the original.
        /// It doesn't own the underlying metadata image and is not responsible for its disposal.
        /// 
        /// This is used, for example, when a metadata cache needs to return the cached metadata to its users
        /// while keeping the ownership of the cached metadata object.
        /// </remarks>
        internal new ModelReferenceMetadata Copy()
        {
            return new ModelReferenceMetadata(this);
        }

        protected override Metadata CommonCopy()
        {
            return Copy();
        }

        internal ImmutableModel Model
        {
            get
            {
                return _model;
            }
        }

        /// <summary>
        /// Name of the module.
        /// </summary>
        /// <exception cref="BadImageFormatException">Invalid metadata.</exception>
        /// <exception cref="ObjectDisposedException">Module has been disposed.</exception>
        public string Name
        {
            get { return Model.Metadata.Name; }
        }

        /// <summary>
        /// Version of the module content.
        /// </summary>
        /// <exception cref="BadImageFormatException">Invalid metadata.</exception>
        /// <exception cref="ObjectDisposedException">Module has been disposed.</exception>
        public Guid GetModuleVersionId()
        {
            return Guid.Parse(Model.Id.Guid);
        }

        /// <summary>
        /// Returns the <see cref="MetadataImageKind"/> for this instance.
        /// </summary>
        public override MetadataImageKind Kind
        {
            get { return MetadataImageKind.Module; }
        }

        /// <summary>
        /// Returns the file names of linked managed modules.
        /// </summary>
        /// <exception cref="BadImageFormatException">When an invalid module name is encountered.</exception>
        /// <exception cref="ObjectDisposedException">Module has been disposed.</exception>
        public ImmutableArray<string> GetModuleNames()
        {
            return ImmutableArray<string>.Empty;
        }

        /// <summary>
        /// Creates a reference to the module metadata.
        /// </summary>
        /// <param name="documentation">Provider of XML documentation comments for the metadata symbols contained in the module.</param>
        /// <param name="filePath">Path describing the location of the metadata, or null if the metadata have no location.</param>
        /// <param name="display">Display string used in error messages to identity the reference.</param>
        /// <returns>A reference to the module metadata.</returns>
        /*public PortableExecutableReference GetReference(DocumentationProvider documentation = null, string filePath = null, string display = null)
        {
            return new ModelReference(this, MetadataReferenceProperties.Module, documentation, filePath, display);
        }*/

        public override void Dispose()
        {
        }
    }
}
