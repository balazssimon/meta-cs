﻿using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Compilation
{
    public class MetaGeneratorCompilation : ICompilation
    {
        private readonly ImmutableArray<LanguageSyntaxTree> _syntaxTrees;
        private ImmutableArray<Diagnostic> _diagnostics;

        public MetaGeneratorCompilation(IEnumerable<LanguageSyntaxTree> syntaxTrees)
        {
            _syntaxTrees = syntaxTrees.ToImmutableArray();
        }

        public void ForceComplete(CancellationToken cancellationToken = default)
        {
            _diagnostics = _syntaxTrees.SelectMany(tree => tree.GetDiagnostics(cancellationToken)).ToImmutableArray();
        }

        public ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default)
        {
            return _diagnostics;
        }
    }
}
