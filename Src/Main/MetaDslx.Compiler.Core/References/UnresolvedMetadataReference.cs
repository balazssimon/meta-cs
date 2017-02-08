// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace MetaDslx.Compiler.References
{
    /// <summary>
    /// Represents a metadata reference that can't be or is not yet resolved.
    /// </summary>
    /// <remarks>
    /// For error reporting only, can't be used to reference a metadata file.
    /// </remarks>
    public sealed class UnresolvedMetadataReference : MetadataReference
    {
        public string Reference { get; }

        internal UnresolvedMetadataReference(string reference)
        {
            this.Reference = reference;
        }

        public override string Display
        {
            get
            {
                return "Unresolved: " + Reference;
            }
        }

        internal override bool IsUnresolved
        {
            get { return true; }
        }
    }
}
