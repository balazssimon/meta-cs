// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal partial class BoundDiscardPattern
    {
        private DiscardSymbol _lazyDiscardSymbol;

        public DiscardSymbol DiscardSymbol
        {
            get
            {
                if (_lazyDiscardSymbol is null)
                {
                    Debug.Assert(!(this.InputType is null));
                    _lazyDiscardSymbol = new DiscardSymbol(this.InputType);
                }

                return _lazyDiscardSymbol;
            }
        }
    }
}
