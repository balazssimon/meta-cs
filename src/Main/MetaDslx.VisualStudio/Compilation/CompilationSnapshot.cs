using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public class CompilationSnapshot
    {
        public static readonly CompilationSnapshot Default = new CompilationSnapshot(null, null, ImmutableDictionary<object, object>.Empty);
        
        private ITextSnapshot text;
        private ICompilation compilation;
        private ImmutableDictionary<object, object> compilationStepResults;

        public CompilationSnapshot(ITextSnapshot text, ICompilation compilation, ImmutableDictionary<object, object> compilationStepResults)
        {
            this.text = text;
            this.compilation = compilation;
            this.compilationStepResults = compilationStepResults;
        }

        public ITextSnapshot Text => text;

        public ICompilation Compilation => compilation;

        public ImmutableDictionary<object, object> CompilationStepResults => compilationStepResults;

        public T GetCompilationStepResult<T>(object key)
            where T: class
        {
            if (this.compilationStepResults.TryGetValue(key, out var value) && value is T tValue) return tValue;
            else return null;
        }

        public bool Changed(ITextSnapshot newText)
        {
            return this.text == null || newText != null && newText.Version != this.text.Version;
        }

        public CompilationSnapshot Update(ITextSnapshot text, ICompilation compilation, ImmutableDictionary<object, object> compilationStepResults)
        {
            if (this.text != text || this.compilation != compilation || this.compilationStepResults != compilationStepResults)
            {
                return new CompilationSnapshot(text, compilation, compilationStepResults);
            }
            return this;
        }
    }
}
