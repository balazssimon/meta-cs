﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// Specifies the kind of location (source vs. metadata).
    /// </summary>
    public enum LocationKind : byte
    {
        /// <summary>
        /// Unspecified location.
        /// </summary>
        None = 0,

        /// <summary>
        /// The location represents a position in a source file.
        /// </summary>
        SourceFile = 1,

        /// <summary>
        /// The location represents a metadata file.
        /// </summary>
        MetadataFile = 2,

        /// <summary>
        /// The location in some external file.
        /// </summary>
        ExternalFile = 3
    }
}
