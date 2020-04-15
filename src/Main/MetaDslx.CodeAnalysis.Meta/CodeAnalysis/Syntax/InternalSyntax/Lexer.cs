using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class Lexer
    {
        private readonly SourceText _text;
        private readonly Language _language;
        private List<SyntaxDiagnosticInfo> _errors;

        public Lexer(SourceText text, Language language)
        {
            _language = language;
            _text = text;
        }

        public Language Language => _language;

        public SourceText SourceText => _text;

        public abstract int Index { get; }

        public abstract InternalSyntaxToken Lex();

        protected bool HasErrors
        {
            get { return _errors != null; }
        }

        protected SyntaxDiagnosticInfo[] GetErrors(int leadingTriviaWidth)
        {
            if (_errors != null)
            {
                if (leadingTriviaWidth > 0)
                {
                    var array = new SyntaxDiagnosticInfo[_errors.Count];
                    for (int i = 0; i < _errors.Count; i++)
                    {
                        // fixup error positioning to account for leading trivia
                        array[i] = _errors[i].WithOffset(_errors[i].Offset + leadingTriviaWidth);
                    }

                    return array;
                }
                else
                {
                    return _errors.ToArray();
                }
            }
            else
            {
                return null;
            }
        }

        protected void AddError(int position, int width, ErrorCode code)
        {
            this.AddError(this.MakeError(position, width, code));
        }

        protected void AddError(int position, int width, ErrorCode code, params object[] args)
        {
            this.AddError(this.MakeError(position, width, code, args));
        }

        protected void AddError(ErrorCode code)
        {
            this.AddError(MakeError(code));
        }

        protected void AddError(ErrorCode code, params object[] args)
        {
            this.AddError(MakeError(code, args));
        }

        protected void AddError(SyntaxDiagnosticInfo error)
        {
            if (error != null)
            {
                if (_errors == null)
                {
                    _errors = new List<SyntaxDiagnosticInfo>(8);
                }

                _errors.Add(error);
            }
        }

        protected static SyntaxDiagnosticInfo MakeError(ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(code);
        }

        protected static SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(code, args);
        }

        protected SyntaxDiagnosticInfo MakeError(int position, int width, ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(position, width, code);
        }

        protected SyntaxDiagnosticInfo MakeError(int position, int width, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(position, width, code, args);
        }

    }
}
