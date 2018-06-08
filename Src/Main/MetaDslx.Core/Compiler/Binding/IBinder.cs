using MetaDslx.Compiler.Binding.SymbolBinding;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding
{
    public interface IBinder
    {
        CompilationBase Compilation { get; }
        IBinder Parent { get; }
        bool IsSemanticModelBinder { get; }
        RedNode RedNode { get; }
        BoundNode BoundNode { get; }
    }
}
