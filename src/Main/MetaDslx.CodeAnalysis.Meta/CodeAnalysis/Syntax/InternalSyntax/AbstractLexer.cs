﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

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
            _errors = null;
        }

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

        protected static SyntaxDiagnosticInfo MakeError(ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(code);
        }

        protected static SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(code, args);
        }

    }
}
