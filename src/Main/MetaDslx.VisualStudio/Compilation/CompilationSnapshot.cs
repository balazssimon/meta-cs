using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
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
        public static readonly CompilationSnapshot Default = new CompilationSnapshot(null, null, null, ImmutableDictionary<object, object>.Empty);
        
        private ITextSnapshot text;
        private SyntaxParser parser;
        private ICompilation compilation;
        private ImmutableDictionary<object, object> compilationStepResults;

        public CompilationSnapshot(ITextSnapshot text, SyntaxParser parser, ICompilation compilation, ImmutableDictionary<object, object> compilationStepResults)
        {
            this.text = text;
            this.parser = parser;
            this.compilation = compilation;
            this.compilationStepResults = compilationStepResults;
        }

        public ITextSnapshot Text => text;

        public SyntaxParser Parser => parser;

        public ICompilation Compilation => compilation;

        public ImmutableDictionary<object, object> CompilationStepResults => compilationStepResults;

        public T GetCompilationStepResult<T>(object key = null)
            where T: class
        {
            if (key == null) key = typeof(T);
            if (this.compilationStepResults.TryGetValue(key, out var value) && value is T tValue) return tValue;
            else return null;
        }

        public bool Changed(ITextSnapshot newText)
        {
            return this.text == null || newText != null && newText.Version != this.text.Version;
        }

        public CompilationSnapshot Update(ITextSnapshot text, SyntaxParser parser, ICompilation compilation, ImmutableDictionary<object, object> compilationStepResults)
        {
            if (this.text != text || this.parser != parser || this.compilation != compilation || this.compilationStepResults != compilationStepResults)
            {
                return new CompilationSnapshot(text, parser, compilation, compilationStepResults);
            }
            return this;
        }
    }
}
