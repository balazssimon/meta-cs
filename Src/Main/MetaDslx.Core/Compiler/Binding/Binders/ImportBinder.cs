using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IImportBinder<TBinder>
        where TBinder : Binder<TBinder>
    {
        ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where);
        Imports GetImports(ConsList<ISymbol> basesBeingResolved);
    }

    public class ImportBinderPart<TBinder> : BinderPart<TBinder>, IImportBinder<TBinder>
        where TBinder : Binder<TBinder>
    {
        public ImportBinderPart(TBinder binder) 
            : base(binder)
        {
        }

        public virtual Imports GetImports(ConsList<ISymbol> basesBeingResolved)
        {
            throw new NotImplementedException();
        }

        public virtual ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where)
        {
            throw new NotImplementedException();
        }
    }
}
