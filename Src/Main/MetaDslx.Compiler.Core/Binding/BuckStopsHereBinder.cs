using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// A binder that knows no symbols and will not delegate further.
    /// </summary>
    public sealed class BuckStopsHereBinder : Binder
    {
        internal BuckStopsHereBinder(Compilation compilation)
            : base(compilation)
        {
        }

        public override IMetaSymbol ContainingSymbol
        {
            get
            {
                return null;
            }
        }
    }
}
