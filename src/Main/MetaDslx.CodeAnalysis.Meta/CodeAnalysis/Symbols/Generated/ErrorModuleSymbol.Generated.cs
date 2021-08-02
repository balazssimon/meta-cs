using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Error
{
	public abstract partial class ErrorModuleSymbol : MetaDslx.CodeAnalysis.Symbols.ModuleSymbol
	{

        public sealed override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public sealed override string Name => string.Empty;

        public override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> Attributes => default;

    }
}
