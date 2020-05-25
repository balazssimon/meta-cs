using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.Tests
{
    public abstract class Antlr4RoslynTestBase : DebugAssertUnitTest
    {
        public abstract Language Language { get; }
        public abstract Lexer CreateAntlr4Lexer(ICharStream stream);
        public abstract Parser CreateAntlr4Parser(ITokenStream stream);
        public abstract ParserRuleContext Antlr4MainRule(Parser parser);

        protected ImmutableArray<Diagnostic> Antlr4Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = CreateAntlr4Lexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = CreateAntlr4Parser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            Antlr4MainRule(parser);
            var result = diagnostics.ToReadOnlyAndFree();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(result);
            return result;
        }

        protected LanguageSyntaxTree Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var tree = Language.ParseSyntaxTree(text);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            Assert.Equal(antlr4Diagnostics.Length, diagnostics.Length);
            return tree;
        }

        protected LanguageSyntaxTree IncrementalParse(SourceText text, LanguageSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var options = Language.DefaultParseOptions.WithIncremental(true);
            var tree = oldTree != null ? (LanguageSyntaxTree)oldTree.WithChangedText(text) : Language.ParseSyntaxTree(text, options);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            //Assert.Equal(antlr4Diagnostics.Length, diagnostics.Length);
            return tree;
        }

        protected (SourceText, LanguageSyntaxTree) IncrementalParseWithInsertedText((SourceText oldText, LanguageSyntaxTree oldTree) old, int position, string insertedText, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position), insertedText));
            var tree = IncrementalParse(text, old.oldTree, assertEmptyDiagnostics);
            return (text, tree);
        }

        protected (SourceText, LanguageSyntaxTree) IncrementalParseWithDeletedText((SourceText oldText, LanguageSyntaxTree oldTree) old, int position, int length, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position + length), string.Empty));
            var tree = IncrementalParse(text, old.oldTree, assertEmptyDiagnostics);
            return (text, tree);
        }

        protected (SourceText, LanguageSyntaxTree) SingleEdit(SourceText source, int start, int length)
        {
            var deletedText = source.GetSubText(new TextSpan(start, length)).ToString();
            var editedSource = source.WithChanges(new TextChange(new TextSpan(start, length), string.Empty));
            bool deleted = false;
            try
            {
                (var source1, var tree1) = IncrementalParseWithDeletedText((source, null), start, length, false);
                deleted = true;
                return IncrementalParseWithInsertedText((source1, tree1), start, deletedText, false);
            }
            catch (Exception ex)
            {
                string operation = deleted ? "while inserting" : "while deleting";
                throw new WrappedXunitException($"Edit failed {operation} at position {start} with deleted text of length {length}:\r\n----\r\n{deletedText}\r\n----\r\nEdited source is:\r\n----\r\n{editedSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
            }
        }

        protected (SourceText, LanguageSyntaxTree) SingleEdit((SourceText source, LanguageSyntaxTree tree) old, int start, int length)
        {
            var deletedText = old.source.GetSubText(new TextSpan(start, length)).ToString();
            var editedSource = old.source.WithChanges(new TextChange(new TextSpan(start, length), string.Empty));
            bool deleted = false;
            try
            {
                (var source1, var tree1) = IncrementalParseWithDeletedText(old, start, length, false);
                deleted = true;
                (var source2, var tree2) = IncrementalParseWithInsertedText((source1, tree1), start, deletedText, false);
                return (source2, tree2);
            }
            catch (Exception ex)
            {
                string operation = deleted ? "while inserting" : "while deleting";
                throw new WrappedXunitException($"Edit failed {operation} at position {start} with deleted text of length {length}:\r\n----\r\n{deletedText}\r\n----\r\nEdited source is:\r\n----\r\n{editedSource}\r\n----\r\nOriginal source is:\r\n----\r\n{old.source}\r\n----\r\n", ex);
            }
        }

        protected LanguageCompilation Compile(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var st = Parse(text, assertEmptyDiagnostics);
            var options = this.Language.DefaultCompilationOptions.WithTopLevelBinderFlags((BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = this.Language.CreateCompilation("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        protected LanguageCompilation IncrementalCompile(SourceText text, LanguageSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var st = IncrementalParse(text, oldTree, assertEmptyDiagnostics);
            var options = this.Language.DefaultCompilationOptions.WithTopLevelBinderFlags((BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = this.Language.CreateCompilation("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        protected void Type(string source, int delta = 1)
        {
            bool last = false;
            int i = 0;
            while (i <= source.Length && !last)
            {
                if (i >= source.Length)
                {
                    i = source.Length;
                    last = true;
                }
                string currentSource = source.Substring(0, i);
                try
                {
                    Parse(SourceText.From(currentSource), false);
                }
                catch (Exception ex)
                {
                    throw new WrappedXunitException($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                }
                i += delta;
            }
        }

        protected void IncrementalType(string source, int delta = 1)
        {
            SourceText oldText = null;
            LanguageSyntaxTree oldTree = null;
            bool reachedEnd = false;
            for (int i = 0; !reachedEnd; i += delta)
            {
                var currentDelta = delta;
                if (i >= source.Length)
                {
                    currentDelta = source.Length - (i - delta);
                    i = source.Length;
                }
                string currentSource = source.Substring(0, i);
                try
                {
                    if (i == 0)
                    {
                        oldText = SourceText.From(currentSource);
                        oldTree = IncrementalParse(oldText, assertEmptyDiagnostics: false);
                    }
                    else
                    {
                        (oldText, oldTree) = IncrementalParseWithInsertedText((oldText, oldTree), i - currentDelta, source.Substring(i - currentDelta, currentDelta), assertEmptyDiagnostics: false);
                    }
                }
                catch (Exception ex)
                {
                    //throw;
                    throw new WrappedXunitException($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                }
                if (i == source.Length) reachedEnd = true;
            }
        }

        protected void AssertEmptyDiagnostics(IEnumerable<Diagnostic> diagnostics)
        {
            Assert.Null(diagnostics.FirstOrDefault());
        }

        private class Antlr4ErrorListener : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        {
            private string _filePath;
            private DiagnosticBag _diagnostics;

            public Antlr4ErrorListener(string filePath, DiagnosticBag diagnostics)
            {
                _filePath = filePath;
                _diagnostics = diagnostics;
            }

            public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
            {
                _diagnostics.Add(Antlr4RoslynErrorCode.ERR_SyntaxError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(recognizer.InputStream.Index, recognizer.InputStream.Index + 1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
            }

            public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
            {
                _diagnostics.Add(Antlr4RoslynErrorCode.ERR_SyntaxError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(offendingSymbol.StartIndex, offendingSymbol.StopIndex + 1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
            }
        }

    }
}
