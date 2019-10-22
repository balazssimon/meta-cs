using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Modeling
{
    public class ModelException : Exception
    {
        private Diagnostic diagnostic;

        public ModelException(Diagnostic diagnostic)
            : this(diagnostic, null)
        {
        }

        public ModelException(Diagnostic diagnostic, Exception innerException)
            : base(diagnostic.GetMessage(), innerException)
        {
            this.diagnostic = diagnostic;
        }

        public Diagnostic Diagnostic
        {
            get { return this.diagnostic; }
        }
    }

    public class LazyEvaluationException : ModelException
    {
        public LazyEvaluationException(Diagnostic diagnostic) : base(diagnostic)
        {
        }

        public LazyEvaluationException(Diagnostic diagnostic, Exception innerException) : base(diagnostic, innerException)
        {
        }
    }
}
