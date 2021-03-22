// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    // separate out text windowing implementation (keeps scanning & lexing functions from abusing details)
    public abstract class AbstractLexer : IDisposable
    {
        internal protected readonly Language Language;
        protected readonly SlidingTextWindow TextWindow;
        private List<SyntaxDiagnosticInfo> _errors;

        protected AbstractLexer(Language language, SourceText text)
        {
            this.Language = language;
            this.TextWindow = new SlidingTextWindow(text);
        }

        public abstract int Position { get; }
        internal protected SourceText Text => TextWindow.Text;
        public int MinLookahead => TextWindow.MinLookahead;
        public int MaxLookahead => TextWindow.MaxLookahead;

        public virtual void Dispose()
        {
            this.TextWindow.Dispose();
        }

        protected void Start()
        {
            TextWindow.Start();
            //_errors = null;
        }

        protected bool HasErrors
        {
            get { return _errors != null; }
        }

        protected SyntaxDiagnosticInfo[] GetAndClearErrors(int leadingTriviaWidth)
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
                    _errors = null;
                    return array;
                }
                else
                {
                    var result = _errors;
                    _errors = null;
                    return result.ToArray();
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

        protected SyntaxDiagnosticInfo MakeError(int position, int width, ErrorCode code)
        {
            int offset = GetLexemeOffsetFromPosition(position);
            return new SyntaxDiagnosticInfo(offset, width, code);
        }

        protected SyntaxDiagnosticInfo MakeError(int position, int width, ErrorCode code, params object[] args)
        {
            int offset = GetLexemeOffsetFromPosition(position);
            return new SyntaxDiagnosticInfo(offset, width, code, args);
        }

        private int GetLexemeOffsetFromPosition(int position)
        {
            return position >= TextWindow.LexemeStartPosition ? position - TextWindow.LexemeStartPosition : position;
        }

        protected SyntaxDiagnosticInfo MakeError(ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(TextWindow.LexemeStartPosition - this.Position, TextWindow.Width, code);
        }

        protected SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(TextWindow.LexemeStartPosition - this.Position, TextWindow.Width, code, args);
        }

    }
}
