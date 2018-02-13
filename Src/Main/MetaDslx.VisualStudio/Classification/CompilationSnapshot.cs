using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class CompilationSnapshot
    {
        public static readonly CompilationSnapshot Default = new CompilationSnapshot(null, null, new Dictionary<SyntaxToken, IClassificationTag>());
        
        private ITextSnapshot text;
        private Compilation compilation;
        private Dictionary<SyntaxToken, IClassificationTag> symbolTokens;

        public CompilationSnapshot(ITextSnapshot text, Compilation compilation, Dictionary<SyntaxToken, IClassificationTag> symbolTokens)
        {
            this.text = text;
            this.compilation = compilation;
            this.symbolTokens = symbolTokens;
        }

        public ITextSnapshot Text
        {
            get { return this.text; }
        }

        public Compilation Compilation
        {
            get { return this.compilation; }
        }

        public Dictionary<SyntaxToken, IClassificationTag> SymbolTokens
        {
            get { return this.symbolTokens; }
        }

        public bool Changed(ITextSnapshot newText)
        {
            return this.text == null || newText != null && newText.Version != this.text.Version;
        }

        public CompilationSnapshot Update(ITextSnapshot text, Compilation compilation, Dictionary<SyntaxToken, IClassificationTag> symbolTokens)
        {
            if (this.text != text || this.compilation != compilation)
            {
                return new CompilationSnapshot(text, compilation, symbolTokens);
            }
            return this;
        }
    }
}
