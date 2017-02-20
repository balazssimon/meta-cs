using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public abstract partial class SyntaxParser : IDisposable
    {
        protected readonly SourceText text;
        protected readonly Language language;
        protected readonly ParseOptions options;
        protected readonly CancellationToken cancellationToken;

        protected SyntaxParser(
            SourceText text,
            Language language,
            ParseOptions options,
            SyntaxNode oldTree,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            this.text = text;
            this.language = language;
            this.options = options;
            this.cancellationToken = cancellationToken;
        }

        public abstract GreenNode Parse();

        public void Dispose()
        {
        }

        public Language Language
        {
            get { return this.language; }
        }

        public ParseOptions Options
        {
            get { return this.options; }
        }

        public bool IsScript
        {
            get { return Options.Kind == SourceCodeKind.Script; }
        }

        public abstract DirectiveStack Directives { get; }

        protected SyntaxDiagnosticInfo MakeError(int offset, int width, int code)
        {
            return new SyntaxDiagnosticInfo(this.language.MessageProvider, offset, width, code);
        }

        protected SyntaxDiagnosticInfo MakeError(int offset, int width, int code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(this.language.MessageProvider, offset, width, code, args);
        }

        protected SyntaxDiagnosticInfo MakeError(InternalSyntaxNode node, int code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(this.language.MessageProvider, node.GetLeadingTriviaWidth(), node.Width, code, args);
        }

        protected SyntaxDiagnosticInfo MakeError(int code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(this.language.MessageProvider, code, args);
        }
    }
}
