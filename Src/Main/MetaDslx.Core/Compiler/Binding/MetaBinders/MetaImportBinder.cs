using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.MetaBinders
{
    public class MetaImportBinder : MetaBinder
    {
        private ImportBinderPart<MetaBinder> _part;

        internal MetaImportBinder(MetaBinder next, RedNode node) : base(next, node)
        {
            _part = new ImportBinderPart<MetaBinder>(this);
        }

        public override Imports GetImports(ConsList<ISymbol> basesBeingResolved)
        {
            return _part.GetImports(basesBeingResolved);
        }

        public override ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where)
        {
            return _part.UnwrapAlias(alias, diagnostics, where);
        }
    }
}
