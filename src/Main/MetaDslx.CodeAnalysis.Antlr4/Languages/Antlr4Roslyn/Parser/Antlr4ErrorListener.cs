using Antlr4.Runtime;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4ErrorListener : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
    {
        private string _filePath;
        private DiagnosticBag _diagnostics;

        public Antlr4ErrorListener(string filePath, DiagnosticBag diagnostics)
        {
            _filePath = filePath;
            _diagnostics = diagnostics;
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            --line;
            _diagnostics.Add(Languages.Antlr4Roslyn.Compilation.Antlr4RoslynErrorCode.ERR_SyntaxError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(recognizer.InputStream.Index, recognizer.InputStream.Index + 1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            --line;
            _diagnostics.Add(Languages.Antlr4Roslyn.Compilation.Antlr4RoslynErrorCode.ERR_SyntaxError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(offendingSymbol.StartIndex, offendingSymbol.StopIndex + 1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
        }
    }
}
