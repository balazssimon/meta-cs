using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification.Antlr4Tagging
{
    internal class CompilationSnapshot<TLexer, TParser>
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
    {
        public static readonly CompilationSnapshot<TLexer, TParser> Default = new CompilationSnapshot<TLexer, TParser>(null, null, new Dictionary<int, IClassificationTag>());
        
        private ITextSnapshot text;
        private Antlr4Compiler<TLexer, TParser> compilation;
        private Dictionary<int, IClassificationTag> symbolTokens;

        public CompilationSnapshot(ITextSnapshot text, Antlr4Compiler<TLexer, TParser> compilation, Dictionary<int, IClassificationTag> symbolTokens)
        {
            this.text = text;
            this.compilation = compilation;
            this.symbolTokens = symbolTokens;
        }

        public ITextSnapshot Text
        {
            get { return this.text; }
        }

        public Antlr4Compiler<TLexer, TParser> Compilation
        {
            get { return this.compilation; }
        }

        public Dictionary<int, IClassificationTag> SymbolTokens
        {
            get { return this.symbolTokens; }
        }

        public bool Changed(ITextSnapshot newText)
        {
            return this.text == null || newText != null && newText.Version != this.text.Version;
        }

        public CompilationSnapshot<TLexer, TParser> Update(ITextSnapshot text, Antlr4Compiler<TLexer, TParser> compilation, Dictionary<int, IClassificationTag> symbolTokens)
        {
            if (this.text != text || this.compilation != compilation)
            {
                return new CompilationSnapshot<TLexer, TParser>(text, compilation, symbolTokens);
            }
            return this;
        }
    }
}
