using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
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
        
        public readonly ITextSnapshot Text;
        public readonly LanguageSyntaxTree SyntaxTree;
        public readonly ICompilation Compilation;
        public readonly ImmutableDictionary<object, object> CompilationStepResults;

        public CompilationSnapshot(ITextSnapshot text, LanguageSyntaxTree syntaxTree, ICompilation compilation, ImmutableDictionary<object, object> compilationStepResults)
        {
            this.Text = text;
            this.SyntaxTree = syntaxTree;
            this.Compilation = compilation;
            this.CompilationStepResults = compilationStepResults;
        }

        public T GetCompilationStepResult<T>(object key = null)
            where T: class
        {
            if (key == null) key = typeof(T);
            if (this.CompilationStepResults.TryGetValue(key, out var value) && value is T tValue) return tValue;
            else return null;
        }

        public bool Changed(ITextSnapshot newText)
        {
            return this.Text == null || newText != null && newText.Version != this.Text.Version;
        }

        public CompilationSnapshot Update(ITextSnapshot text, LanguageSyntaxTree syntaxTree, ICompilation compilation, ImmutableDictionary<object, object> compilationStepResults)
        {
            if (this.Text != text || this.SyntaxTree != syntaxTree || this.Compilation != compilation || this.CompilationStepResults != compilationStepResults)
            {
                return new CompilationSnapshot(text, syntaxTree, compilation, compilationStepResults);
            }
            return this;
        }
    }
}
