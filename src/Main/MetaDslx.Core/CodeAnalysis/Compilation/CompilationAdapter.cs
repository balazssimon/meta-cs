using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationAdapter : Microsoft.CodeAnalysis.Compilation
    {
        internal CompilationAdapter(string name, ImmutableArray<Microsoft.CodeAnalysis.MetadataReference> references, IReadOnlyDictionary<string, string> features, bool isSubmission, AsyncQueue<CompilationEvent> eventQueue) 
            : base(name, references, features, isSubmission, eventQueue)
        {
        }

        public override string Language => LanguageCore.Name;

        protected abstract Language LanguageCore { get; }

        internal abstract DeclarationTable Declarations { get; }

        internal override IEnumerable<Microsoft.CodeAnalysis.ReferenceDirective> ReferenceDirectives
        {
            get { return this.Declarations.ReferenceDirectives.Select(d => d.ToMicrosoft()); }
        }

        protected abstract IEnumerable<MetaDslx.CodeAnalysis.Syntax.ReferenceDirective> ReferenceDirectivesCore { get; }
    }
}
