using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Tests;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
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

        public ImmutableArray<Diagnostic> Antlr4Parse(SourceText text, bool assertEmptyDiagnostics = true)
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

        public LanguageSyntaxTree Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var tree = Language.ParseSyntaxTree(text);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            LogParseInfo(text, tree, antlr4Diagnostics);
            Assert.Equal(antlr4Diagnostics.Length, diagnostics.Length);
            return tree;
        }

        public LanguageSyntaxTree IncrementalParse(SourceText text, LanguageSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var options = Language.DefaultParseOptions.WithIncremental(true);
            var tree = oldTree != null ? (LanguageSyntaxTree)oldTree.WithChangedText(text) : Language.ParseSyntaxTree(text, options);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            LogParseInfo(text, tree, antlr4Diagnostics);
            //Assert.Equal(antlr4Diagnostics.Length, diagnostics.Length);
            Assert.True(antlr4Diagnostics.Length <= diagnostics.Length);
            return tree;
        }

        public (SourceText, LanguageSyntaxTree) IncrementalParseWithInsertedText((SourceText oldText, LanguageSyntaxTree oldTree) old, int position, string insertedText, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position), insertedText));
            var tree = IncrementalParse(text, old.oldTree, assertEmptyDiagnostics);
            return (text, tree);
        }

        public (SourceText, LanguageSyntaxTree) IncrementalParseWithDeletedText((SourceText oldText, LanguageSyntaxTree oldTree) old, int position, int length, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position + length), string.Empty));
            var tree = IncrementalParse(text, old.oldTree, assertEmptyDiagnostics);
            return (text, tree);
        }

        public (SourceText, LanguageSyntaxTree) SingleEdit(SourceText source, int start, int length)
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

        public (SourceText, LanguageSyntaxTree) SingleEdit((SourceText source, LanguageSyntaxTree tree) old, int start, int length)
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

        public LanguageCompilation Compile(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var st = Parse(text, assertEmptyDiagnostics);
            var options = this.Language.DefaultCompilationOptions.WithTopLevelBinderFlags((BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = this.Language.CreateCompilation("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        public LanguageCompilation IncrementalCompile(SourceText text, LanguageSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var st = IncrementalParse(text, oldTree, assertEmptyDiagnostics);
            var options = this.Language.DefaultCompilationOptions.WithTopLevelBinderFlags((BinderFlags)BinderFlags.IgnoreAccessibility);
            var comp = this.Language.CreateCompilation("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        public void Type(string source, int delta = 1)
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

        public void IncrementalType(string source, int delta = 1)
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

        public void AssertEmptyDiagnostics(IEnumerable<Diagnostic> diagnostics)
        {
            Assert.Null(diagnostics.FirstOrDefault());
        }


        public static void LogParseInfo(SourceText text, LanguageSyntaxTree tree, ImmutableArray<Diagnostic> antlr4Diagnostics)
        {
            CallLogger.Instance.Log("===========================================");
            CallLogger.Instance.Log("Text length: " + text.Length);
            CallLogger.Instance.Log("----");
            CallLogger.Instance.Log(text);
            CallLogger.Instance.Log("----");
            CallLogger.Instance.Log(PrintSyntaxTree(tree));
            CallLogger.Instance.Log("===========================================");
            var formatter = new DiagnosticFormatter();
            CallLogger.Instance.Log("Antlr4 diagnostics:");
            foreach (var diag in antlr4Diagnostics)
            {
                CallLogger.Instance.Log("  " + formatter.Format(diag));
            }
            CallLogger.Instance.Log("MetaDslx diagnostics:");
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            foreach (var diag in diagnostics)
            {
                CallLogger.Instance.Log("  " + formatter.Format(diag));
            }
            CallLogger.Instance.Log("----");
        }

        public static string PrintSyntaxTree(LanguageSyntaxTree tree)
        {
            StringBuilder buf = new StringBuilder();
            PrintSyntaxTreeRecursive((LanguageSyntaxNode)tree.GetRoot(), buf, 0);
            return buf.ToString();
        }

        private static void PrintSyntaxTreeRecursive(LanguageSyntaxNode node, StringBuilder buf, int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                buf.Append("  ");
            }
            var annot = SyntaxParser.GetNodeAnnotation(node.Green);
            if (annot != null)
            {
#if DEBUG
                buf.Append($"[{annot.Version} (startState={((Antlr4ParserState)annot.StartState).State},endState={((Antlr4ParserState)annot.EndState).State},ltb={annot.LookaheadTokensBefore},lta={annot.LookaheadTokensAfter},lb={annot.LookaheadBefore},la={annot.LookaheadAfter})] ");
#else
                buf.Append($"[(startState={((Antlr4ParserState)annot.StartState).State},endState={((Antlr4ParserState)annot.EndState).State},ltb={annot.LookaheadTokensBefore},lta={annot.LookaheadTokensAfter},lb={annot.LookaheadBefore},la={annot.LookaheadAfter})] ");
#endif
            }
            buf.Append(node.Kind);
            buf.AppendLine();
            foreach (var child in node.ChildNodesAndTokens())
            {
                if (child.IsToken)
                {
                    var token = child.AsToken();
                    var tokenAnnot = SyntaxLexer.GetTokenAnnotation(token.Node);
                    for (int i = 0; i < indent + 1; i++)
                    {
                        buf.Append("  ");
                    }
                    if (tokenAnnot != null)
                    {
                        buf.Append($"[(startMode={((Antlr4LexerMode)tokenAnnot.StartMode)?.Mode ?? 0},endState={((Antlr4LexerMode)tokenAnnot.EndMode)?.Mode ?? 0})] ");
                    }
                    else
                    {
                        buf.Append($"[(startMode=0,endState=0)] ");
                    }
                    buf.Append(child.GetKind());
                    buf.Append(": " + token.Text);
                    buf.AppendLine();
                }
                else
                {
                    PrintSyntaxTreeRecursive((LanguageSyntaxNode)child.AsNode(), buf, indent + 1);
                }
            }
        }

    }
}
