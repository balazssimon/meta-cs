using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class Antlr4DefaultNameProvider : DefaultNameProvider
    {
        public override string GetName(object node)
        {
            IParseTree parseTree = node as IParseTree;
            if (parseTree == null) return null;
            string name = parseTree.GetText();
            if (name != null && name.StartsWith("@")) name = name.Substring(1);
            return name;
        }

        public override object GetValue(object node, Type type)
        {
            IParseTree parseTree = node as IParseTree;
            if (parseTree == null) return null;
            string text = parseTree.GetText();
            if (text.Length >= 3 && text.StartsWith("@\'") && text.EndsWith("\'"))
            {
                return text.Substring(2, text.Length - 3).Replace("\'\'", "\'");
            }
            else if (text.Length >= 2 && text.StartsWith("\'") && text.EndsWith("\'"))
            {
                return Regex.Unescape(text.Substring(1, text.Length - 2));
            }
            else if (text.Length >= 3 && text.StartsWith("@\"") && text.EndsWith("\""))
            {
                return text.Substring(2, text.Length - 3).Replace("\"\"", "\"");
            }
            else if (text.Length >= 2 && text.StartsWith("\"") && text.EndsWith("\""))
            {
                return Regex.Unescape(text.Substring(1, text.Length - 2));
            }
            return base.GetValue(text, type);
        }

        public override TextSpan GetTreeNodeTextSpan(object node)
        {
            return new Antlr4TextSpan(node);
        }
    }

    public class Antlr4DefaultTriviaProvider : DefaultTriviaProvider
    {
        private IAntlr4Compiler compiler;
        private int channel;

        public Antlr4DefaultTriviaProvider(IAntlr4Compiler compiler, int channel = -1)
        {
            this.compiler = compiler;
            this.channel = channel;
            this.CleanTrivia = true;
            this.TrimTriviaLines = true;
            this.ConcatTriviaLines = false;
            this.TriviaStartTokens = new List<string>();
            this.TriviaEndTokens = new List<string>();
            this.TriviaLineStartTokens = new List<string>();
            this.TriviaLineEndTokens = new List<string>();
            this.TriviaStartTokens.Add("///");
            this.TriviaStartTokens.Add("/**");
            this.TriviaStartTokens.Add("//");
            this.TriviaStartTokens.Add("/*");
            this.TriviaEndTokens.Add("*/");
            this.TriviaLineStartTokens.Add("*");
        }

        public bool CleanTrivia { get; set; }
        public bool TrimTriviaLines { get; set; }
        public bool ConcatTriviaLines { get; set; }
        public List<string> TriviaStartTokens { get; private set; }
        public List<string> TriviaEndTokens { get; private set; }
        public List<string> TriviaLineStartTokens { get; private set; }
        public List<string> TriviaLineEndTokens { get; private set; }

        protected virtual string CleanTriviaText(string text)
        {
            if (text == null) return text;
            text = text.Trim();
            foreach (var token in this.TriviaStartTokens)
            {
                if (text.StartsWith(token))
                {
                    text = text.Substring(token.Length);
                    break;
                }
            }
            foreach (var token in this.TriviaEndTokens)
            {
                if (text.EndsWith(token))
                {
                    text = text.Substring(0, text.Length - token.Length);
                    break;
                }
            }
            if (this.TrimTriviaLines)
            {
                text = text.Trim();
            }
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(stream))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        foreach (var token in this.TriviaLineStartTokens)
                        {
                            if (line.StartsWith(token))
                            {
                                line = line.Substring(token.Length);
                                break;
                            }
                        }
                        foreach (var token in this.TriviaLineEndTokens)
                        {
                            if (line.EndsWith(token))
                            {
                                line = line.Substring(token.Length);
                                break;
                            }
                        }
                        if (this.TrimTriviaLines)
                        {
                            line = line.Trim();
                        }
                        if (this.ConcatTriviaLines)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                if (sb.Length != 0)
                                {
                                    sb.Append(" ");
                                }
                                sb.Append(line);
                            }
                        }
                        else
                        {
                            if (sb.Length != 0)
                            {
                                sb.AppendLine();
                            }
                            sb.Append(line);
                        }
                    }
                }
            }
            string result = sb.ToString();
            if (string.IsNullOrWhiteSpace(result)) return null;
            else return result;
        }

        protected virtual string GetTriviaText(IList<IToken> triviaTokens)
        {
            if (triviaTokens.Count == 0) return null;
            StringBuilder builder = new StringBuilder();
            foreach (var token in triviaTokens)
            {
                builder.Append(token.Text);
            }
            string triviaText = builder.ToString();
            if (this.CleanTrivia)
            {
                triviaText = this.CleanTriviaText(triviaText);
            }
            return triviaText;
        }

        public override string GetLeadingTrivia(object node)
        {
            ParserRuleContext context = node as ParserRuleContext;
            if (context != null)
            {
                IList<IToken> triviaTokens = AnnotatedAntlr4Channels.GetLeadingTriviaTokens(context.Start, this.compiler.CommonTokenStream, this.channel);
                return this.GetTriviaText(triviaTokens);
            }
            IToken token = node as IToken;
            if (token != null)
            {
                IList<IToken> triviaTokens = AnnotatedAntlr4Channels.GetLeadingTriviaTokens(token, this.compiler.CommonTokenStream, this.channel);
                return this.GetTriviaText(triviaTokens);
            }
            ModelObject mo = node as ModelObject;
            if (mo != null)
            {
                IList<object> treeNodes = mo.MGet(MetaScopeEntryProperties.SymbolTreeNodesProperty) as IList<object>;
                if (treeNodes != null && treeNodes.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (var treeNode in treeNodes)
                    {
                        string trivia = this.GetLeadingTrivia(treeNode);
                        if (!string.IsNullOrWhiteSpace(trivia))
                        {
                            builder.Append(trivia);
                        }
                    }
                    string result = builder.ToString();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        return result;
                    }
                }
            }
            return base.GetLeadingTrivia(node);
        }

        public override string GetTrailingTrivia(object node)
        {
            ParserRuleContext context = node as ParserRuleContext;
            if (context != null)
            {
                IList<IToken> triviaTokens = AnnotatedAntlr4Channels.GetTrailingTriviaTokens(context.Stop, this.compiler.CommonTokenStream, this.channel);
                return this.GetTriviaText(triviaTokens);
            }
            IToken token = node as IToken;
            if (token != null)
            {
                IList<IToken> triviaTokens = AnnotatedAntlr4Channels.GetTrailingTriviaTokens(token, this.compiler.CommonTokenStream, this.channel);
                return this.GetTriviaText(triviaTokens);
            }
            ModelObject mo = node as ModelObject;
            if (mo != null)
            {
                IList<object> treeNodes = mo.MGet(MetaScopeEntryProperties.SymbolTreeNodesProperty) as IList<object>;
                if (treeNodes != null && treeNodes.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (var treeNode in treeNodes)
                    {
                        string trivia = this.GetTrailingTrivia(treeNode);
                        if (!string.IsNullOrWhiteSpace(trivia))
                        {
                            builder.Append(trivia);
                        }
                    }
                    string result = builder.ToString();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        return result;
                    }
                }
            }
            return base.GetTrailingTrivia(node);
        }
    }
}
