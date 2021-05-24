﻿using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public abstract class EditTest : LexerModeTestBase
    {
        private SourceText source;
        private Random rnd;
        private int incrementalSteps;

        public EditTest(string fileName, int incrementalSteps = 0)
        {
            source = LoadFile(fileName);
            rnd = new Random();
            this.incrementalSteps = incrementalSteps > 0 ? incrementalSteps : source.Length / 10;
        }


        [Fact]
        public void TypeSource()
        {
            IncrementalType(source, incrementalSteps);
        }


        [Fact]
        public void SerialEdits()
        {
            var src = (source, (LanguageSyntaxTree)null);
            for (int i = 0; i < source.Length; i += incrementalSteps)
            {
                var start = i;
                var length = 1;
                if (i > 0 && source[i - 1] == '\r') continue;
                src = SingleEdit(src, start, length);
            }
        }

        [Fact]
        public void RandomEdits()
        {
            var src = (source, (LanguageSyntaxTree)null);
            for (int i = 0; i < 10; i++)
            {
                var start = rnd.Next(src.source.Length);
                var length = rnd.Next(src.source.Length - start);
                if (start > 0 && source[start - 1] == '\r') continue;
                src = SingleEdit(src, start, length);
            }
        }

    }

}
