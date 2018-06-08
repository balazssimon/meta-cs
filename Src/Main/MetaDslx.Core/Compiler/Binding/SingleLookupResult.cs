using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// Represents a result of lookup operation over a 0 or 1 result (as opposed to a scope). The
    /// typical use is to represent that a particular symbol is good/bad/unavailable.
    /// 
    /// For more explanation of Kind, Result, Error - see LookupResult.
    /// </summary>
    public struct SingleLookupResult<TResult>
    {
        // the kind of result.
        public readonly LookupResultKind Kind;

        // the result or default value.
        public readonly TResult Result;

        // the error of the result, if it is NonViable or Inaccessible
        public readonly DiagnosticInfo Error;

        public SingleLookupResult(LookupResultKind kind, TResult result, DiagnosticInfo error)
        {
            this.Kind = kind;
            this.Result = result;
            this.Error = error;
        }
    }
}
