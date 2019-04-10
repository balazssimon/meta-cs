// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Text;
using System.Security.Cryptography;

namespace MetaDslx.Compiler.Emit
{
    internal abstract class CommonSymbolBuilder 
    {
        public CommonSymbolBuilder(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        public void CompilationFinished()
        {
            throw new NotImplementedException();
        }
    }
}
