﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class IncrementalInputStream : ICharStream, IIntStream
    {
        private const int DefaultWindowLength = 2048;

        private readonly SlidingTextWindow _textWindow;                 

        private Interval _minMaxLookahead = Interval.Of(0, 0);
        private Interval _overallMinMaxLookahead = Interval.Of(0, 0);
        private int _lastLA = 0;
        private bool _first = true;

        public IncrementalInputStream(SourceText text)
        {
            _textWindow = new SlidingTextWindow(text);
        }

        public int La(int i)
        {
            if (i != _lastLA)
            {
                _lastLA = i;
                _minMaxLookahead = _minMaxLookahead.Union(Interval.Of(i, i));
                _overallMinMaxLookahead = _overallMinMaxLookahead.Union(this._minMaxLookahead);
            }
            var pch = _textWindow.PeekChar(i-1);
            if (pch == SlidingTextWindow.InvalidCharacter) return -1;
            else return pch;
        }


        public Interval OverallMinMaxLookahead => _overallMinMaxLookahead;
        public Interval MinMaxLookahead => _minMaxLookahead;
        public int Index => _textWindow.Position;
        public int Size => _textWindow.Text.Length;
        public string SourceName => "<unknown>";

        public void ResetMinMaxLookahead() {
            _minMaxLookahead = Interval.Of(0, 0);
            _lastLA = 0;
        }

        [return: NotNull]
        public string GetText([NotNull] Interval interval)
        {
            return _textWindow.GetText(interval.a, interval.Length, false);
        }

        public void Consume()
        {
            _textWindow.NextChar();
        }

        public int Mark()
        {
            // do nothing: SlidingTextWindow does the buffering
            return -1;
        }

        public void Release(int marker)
        {
            // do nothing: SlidingTextWindow does the buffering
        }

        public void Seek(int index)
        {
            _textWindow.Reset(index);
        }
    }
}
