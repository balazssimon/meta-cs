using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class NameResolution
    {
        private readonly Binder _binder;

        public NameResolution(Binder binder)
        {
            _binder = binder;
        }

        private Compilation Compilation
        {
            get { return _binder.Compilation; }
        }

        public virtual IMetaSymbol GetNamespaceOrTypeByQualifiedName(string qualifiedName)
        {
            throw new NotImplementedException();
        }
    }
}
