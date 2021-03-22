// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents an immutable snapshot of module CLI metadata.
    /// </summary>
    /// <remarks>This object may allocate significant resources or lock files depending upon how it is constructed.</remarks>
    public sealed partial class ModelGroupMetadata : Metadata
    {
        private readonly ImmutableModelGroup _modelGroup;
        private string _lazyName;

        private ModelGroupMetadata(ImmutableModelGroup modelGroup)
            : base(isImageOwner: true, id: MetadataId.CreateNewId())
        {
            _modelGroup = modelGroup;
        }

        // creates a copy
        private ModelGroupMetadata(ModelGroupMetadata metadata)
            : base(isImageOwner: false, id: metadata.Id)
        {
            _modelGroup = metadata.ModelGroup;
        }

        /// <summary>
        /// Create metadata module from a MetaDslx model.
        /// </summary>
        /// <param name="model">A MetaDslx model.</param>
        /// <exception cref="ArgumentNullException"><paramref name="modelGroup"/> is null.</exception>
        public static ModelGroupMetadata CreateFromModelGroup(ImmutableModelGroup modelGroup)
        {
            if (modelGroup == null)
            {
                throw new ArgumentNullException(nameof(modelGroup));
            }

            return new ModelGroupMetadata(modelGroup);
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
        internal new ModelGroupMetadata Copy()
        {
            return new ModelGroupMetadata(this);
        }

        protected override Metadata CommonCopy()
        {
            return Copy();
        }

        internal ImmutableModelGroup ModelGroup
        {
            get
            {
                return _modelGroup;
            }
        }

        /// <summary>
        /// Returns the <see cref="MetadataImageKind"/> for this instance.
        /// </summary>
        public override MetadataImageKind Kind
        {
            get { return MetadataImageKind.Module; }
        }

        public string Name
        {
            get
            {
                if (_lazyName == null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var model in _modelGroup.Models)
                    {
                        if (sb.Length > 0) sb.Append(", ");
                        sb.Append(model.ToString());
                    }
                    Interlocked.CompareExchange(ref _lazyName, sb.ToString(), null);
                }
                return _lazyName;
            }
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
        public PortableExecutableReference GetReference(DocumentationProvider documentation = null, string filePath = null, string display = null)
        {
            return new MetadataImageReference(this, MetadataReferenceProperties.Module, documentation, filePath, display);
        }

        public override void Dispose()
        {
        }
    }
}
