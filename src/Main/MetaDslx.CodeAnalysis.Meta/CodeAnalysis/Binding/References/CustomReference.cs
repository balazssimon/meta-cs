// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents an in-memory Portable-Executable image.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class CustomReference : MetadataReference
    {
        private readonly string _display;
        private readonly string _filePath;
        private readonly DocumentationProvider _documentation;
        private readonly bool _embedInCompilation;

        internal CustomReference(MetadataReferenceProperties properties, DocumentationProvider documentation, string filePath, string display, bool embedInCompilation)
            : base(properties)
        {
            _display = display;
            _filePath = filePath;
            _documentation = documentation ?? DocumentationProvider.Default;
            _embedInCompilation = embedInCompilation;
        }

        /// <summary>
        /// Display string used in error messages to identity the reference.
        /// </summary>
        public override string Display
        {
            get { return _display ?? _filePath; }
        }

        /// <summary>
        /// Path describing the location of the metadata, or null if the metadata have no location.
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
        }

        /// <summary>
        /// Indicates whether the metadata reference should be embedded into the compilation,
        /// i.e., its symbols are validated and emitted by the compilation.
        /// </summary>
        public bool EmbedInCompilation
        {
            get { return _embedInCompilation; }
        }

        /// <summary>
        /// XML documentation comments provider for the reference.
        /// </summary>
        public DocumentationProvider DocumentationProvider => _documentation;

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public new CustomReference WithAliases(IEnumerable<string> aliases)
        {
            return this.WithAliases(ImmutableArray.CreateRange(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public new CustomReference WithAliases(ImmutableArray<string> aliases)
        {
            return WithProperties(Properties.WithAliases(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified properties, or this instance if properties haven't changed.
        /// </summary>
        /// <param name="properties">The new properties for the reference.</param>
        /// <exception cref="ArgumentException">Specified values not valid for this reference.</exception> 
        public new CustomReference WithProperties(MetadataReferenceProperties properties)
        {
            if (properties == this.Properties)
            {
                return this;
            }

            return (CustomReference)Update(properties, this.EmbedInCompilation);
        }

        internal sealed override MetadataReference WithPropertiesImplReturningMetadataReference(MetadataReferenceProperties properties)
        {
            return Update(properties, this.EmbedInCompilation);
        }

        public CustomReference WithEmbedInCompilation(bool embed)
        {
            if (embed == this.EmbedInCompilation)
            {
                return this;
            }
            return Update(this.Properties, embed);
        }

        /// <summary>
        /// Returns an instance of the reference with specified properties.
        /// </summary>
        /// <param name="properties">The new properties for the reference.</param>
        /// <exception cref="NotSupportedException">Specified values not supported.</exception> 
        /// <remarks>Only invoked if the properties changed.</remarks>
        protected abstract CustomReference Update(MetadataReferenceProperties properties, bool embedInCompilation);

        /// <summary>
        /// Get metadata representation for the PE file.
        /// </summary>
        /// <exception cref="BadImageFormatException">If the PE image format is invalid.</exception>
        /// <exception cref="IOException">The metadata image content can't be read.</exception>
        /// <exception cref="FileNotFoundException">The metadata image is stored in a file that can't be found.</exception>
        /// <remarks>
        /// Called when the <see cref="Compilation"/> needs to read the reference metadata.
        /// 
        /// The listed exceptions are caught and converted to compilation diagnostics.
        /// Any other exception is considered an unexpected error in the implementation and is not caught.
        ///
        /// <see cref="Metadata"/> objects may cache information decoded from the PE image.
        /// Reusing <see cref="Metadata"/> instances across metadata references will result in better performance.
        /// 
        /// The calling <see cref="Compilation"/> doesn't take ownership of the <see cref="Metadata"/> objects returned by this method.
        /// The implementation needs to retrieve the object from a provider that manages their lifetime (such as metadata cache).
        /// The <see cref="Metadata"/> object is kept alive by the <see cref="Compilation"/> that called <see cref="GetMetadataNoCopy"/>
        /// and by all compilations created from it via calls to With- factory methods on <see cref="Compilation"/>, 
        /// other than <see cref="Compilation.WithReferences(MetadataReference[])"/> overloads. A compilation created using 
        /// <see cref="Compilation.WithReferences(MetadataReference[])"/> will call to <see cref="GetMetadataNoCopy"/> again.
        /// </remarks>
        protected abstract Metadata GetMetadataImpl();

        internal Metadata GetMetadataNoCopy()
        {
            return GetMetadataImpl();
        }

        /// <summary>
        /// Returns a copy of the <see cref="Metadata"/> object this <see cref="PortableExecutableReference"/>
        /// contains.  This copy does not need to be <see cref="IDisposable.Dispose"/>d.
        /// </summary>
        /// <exception cref="BadImageFormatException">If the PE image format is invalid.</exception>
        /// <exception cref="IOException">The metadata image content can't be read.</exception>
        /// <exception cref="FileNotFoundException">The metadata image is stored in a file that can't be found.</exception>
        public Metadata GetMetadata()
        {
            return GetMetadataNoCopy().Copy();
        }

        /// <summary>
        /// Returns the <see cref="MetadataId"/> for this reference's <see cref="Metadata"/>.
        /// This will be equivalent to calling <see cref="GetMetadata()"/>.<see cref="Metadata.Id"/>,
        /// but can be done more efficiently.
        /// </summary>
        /// <exception cref="BadImageFormatException">If the PE image format is invalid.</exception>
        /// <exception cref="IOException">The metadata image content can't be read.</exception>
        /// <exception cref="FileNotFoundException">The metadata image is stored in a file that can't be found.</exception>
        public MetadataId GetMetadataId()
        {
            return GetMetadataNoCopy().Id;
        }

        internal static Diagnostic ExceptionToDiagnostic(Exception e, CommonMessageProvider messageProvider, Location location, string display, MetadataImageKind kind)
        {
            if (e is BadImageFormatException)
            {
                int errorCode = (kind == MetadataImageKind.Assembly) ? messageProvider.ERR_InvalidAssemblyMetadata : messageProvider.ERR_InvalidModuleMetadata;
                return messageProvider.CreateDiagnostic(errorCode, location, display, e.Message);
            }

            var fileNotFound = e as FileNotFoundException;
            if (fileNotFound != null)
            {
                return messageProvider.CreateDiagnostic(messageProvider.ERR_MetadataFileNotFound, location, fileNotFound.FileName ?? string.Empty);
            }
            else
            {
                int errorCode = (kind == MetadataImageKind.Assembly) ? messageProvider.ERR_ErrorOpeningAssemblyFile : messageProvider.ERR_ErrorOpeningModuleFile;
                return messageProvider.CreateDiagnostic(errorCode, location, display, e.Message);
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
                sb.Append(" EmbedInteropTypes");
            }

            if (EmbedInCompilation)
            {
                sb.Append(" EmbedInCompilation");
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
