using MetaDslx.Compiler;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class CompilationSnapshot
    {
        public static readonly CompilationSnapshot Default = new CompilationSnapshot(null, null);
        
        private ITextSnapshot text;
        private Compilation compilation;

        public CompilationSnapshot(ITextSnapshot text, Compilation compilation)
        {
            this.text = text;
            this.compilation = compilation;
        }

        public ITextSnapshot Text
        {
            get { return this.text; }
        }

        public Compilation Compilation
        {
            get { return this.compilation; }
        }

        public bool Changed(ITextSnapshot newText)
        {
            return this.text == null || newText != null && newText.Version != this.text.Version;
        }

        public CompilationSnapshot Update(ITextSnapshot text, Compilation compilation)
        {
            if (this.text != text || this.compilation != compilation)
            {
                return new CompilationSnapshot(text, compilation);
            }
            return this;
        }
    }
}
