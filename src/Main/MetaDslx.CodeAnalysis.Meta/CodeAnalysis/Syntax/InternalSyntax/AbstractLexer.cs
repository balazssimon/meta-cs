// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    // separate out text windowing implementation (keeps scanning & lexing functions from abusing details)
    public abstract class AbstractLexer : IDisposable
    {
        public readonly Language Language;
        protected readonly SlidingTextWindow TextWindow;
        private readonly List<SyntaxDiagnosticInfo> Errors;

        protected AbstractLexer(Language language, SourceText text)
        {
            this.Language = language;
            this.TextWindow = new SlidingTextWindow(text);
            Errors = new List<SyntaxDiagnosticInfo>();
        }

        public SourceText SourceText => TextWindow.SourceText;

        public virtual void Dispose()
        {
            this.TextWindow.Dispose();
        }

        protected bool HasErrors
        {
            get { return Errors.Count > 0; }
        }

        protected SyntaxDiagnosticInfo[] GetAndClearErrors(int leadingTriviaWidth)
        {
            if (Errors.Count > 0)
            {
                if (leadingTriviaWidth > 0)
                {
                    var array = new SyntaxDiagnosticInfo[Errors.Count];
                    for (int i = 0; i < Errors.Count; i++)
                    {
                        // fixup error positioning to account for leading trivia
                        array[i] = Errors[i].WithOffset(Errors[i].Offset + leadingTriviaWidth);
                    }
                    Errors.Clear();
                    return array;
                }
                else
                {
                    var result = Errors;
                    Errors.Clear();
                    return result.ToArray();
                }
            }
            else
            {
                return null;
            }
        }

        protected void ClearErrors()
        {
            Errors.Clear();
        }

        protected void AddError(int position, int width, ErrorCode code, params object[] args)
        {
            this.AddError(this.MakeError(position, width, code, args));
        }

        protected void AddError(ErrorCode code, params object[] args)
        {
            this.AddError(MakeError(code, args));
        }

        protected void AddError(SyntaxDiagnosticInfo error)
        {
            if (error != null)
            {
                if (Errors.Any(err => error.Equals(err) && err.ErrorCode == error.ErrorCode && err.Offset == error.Offset && err.Width == error.Width)) return;
                Errors.Add(error);
            }
        }

        protected SyntaxDiagnosticInfo MakeError(int position, int width, ErrorCode code, params object[] args)
        {
            int offset = position - TextWindow.LexemeStartPosition;
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(position), $"Position {position} must be between {TextWindow.LexemeStartPosition} and {TextWindow.LexemeStartPosition + TextWindow.Width}.");
            return new SyntaxDiagnosticInfo(position - TextWindow.LexemeStartPosition, width, code, args);
        }

        protected SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return MakeError(TextWindow.LexemeStartPosition, TextWindow.Width, code, args);
        }

    }
}
