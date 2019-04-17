// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// A binder that places the members of a symbol in scope.  If there is a container declaration
    /// with using directives, those are merged when looking up names.
    /// </summary>
    internal class InContainerBinder : Binder
    {
        protected InContainerBinder(Binder next) : base(next)
        {
        }

        protected InContainerBinder(Binder next, BinderFlags flags) : base(next, flags)
        {
        }
    }
}
