// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;

namespace MetaDslx.Compiler
{
    [Flags]
    public enum ModelIdentityParts
    {
        Name = 1,
        Version = VersionMajor | VersionMinor | VersionBuild | VersionRevision,

        // version parts are assumed to be in order:
        VersionMajor = 1 << 1,
        VersionMinor = 1 << 2,
        VersionBuild = 1 << 3,
        VersionRevision = 1 << 4,

        Unknown = 1 << 5
    }
}
