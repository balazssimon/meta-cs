using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public abstract class ParseOptionsAdapter : ParseOptions
    {
        public ParseOptionsAdapter(SourceCodeKind kind, DocumentationMode documentationMode) 
            : base(kind, documentationMode)
        {
        }

        public override string Language => this.LanguageCore.Name;

        public abstract Language LanguageCore { get; }

        public override IReadOnlyDictionary<string, string> Features => this.FeaturesCore;

        protected abstract IReadOnlyDictionary<string, string> FeaturesCore { get; set; }

    }
}
