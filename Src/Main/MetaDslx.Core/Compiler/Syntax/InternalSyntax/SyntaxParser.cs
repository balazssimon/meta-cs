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
        protected readonly InternalSyntaxFactory factory;

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
            this.factory = this.language.InternalSyntaxFactory;
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

        protected SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(offset, width, code);
        }

        protected SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(offset, width, code, args);
        }

        protected SyntaxDiagnosticInfo MakeError(InternalSyntaxNode node, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(node.GetLeadingTriviaWidth(), node.Width, code, args);
        }

        protected SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(code, args);
        }
    }
}
