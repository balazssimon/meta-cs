using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// A Binder converts names to symbols and syntax nodes into bound trees. It is context
    /// dependent, relative to a location in source code.
    /// </summary>
    public abstract class Binder
    {
    }
}
