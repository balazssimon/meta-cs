using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class AnnotatedAntlr4Channels
    {
        public static int GetLeadingTriviaTokenStartIndex(IToken token, BufferedTokenStream tokenStream, int triviaChannel = -1)
        {
            IList<IToken> tokens = tokenStream.GetTokens();
            int lastNewLine = -1;
            int i = token.TokenIndex - 1;
            int lastTriviaToken = token.TokenIndex;
            int lastTriviaTokenBeforeNewLine = lastTriviaToken;
            while (i >= 0)
            {
                IToken t = tokens[i];
                string text = t.Text;
                if (t.Channel == 0)
                {
                    if (lastNewLine < 0) return lastTriviaToken;
                    else return lastTriviaTokenBeforeNewLine;
                }
                else if (string.IsNullOrWhiteSpace(text) && (text.Contains('\r') || text.Contains('\n')))
                {
                    lastTriviaTokenBeforeNewLine = lastTriviaToken;
                    lastNewLine = i;
                }
                else if (triviaChannel < 0 || t.Channel == triviaChannel)
                {
                    lastTriviaToken = i;
                }
                --i;
            }
            return lastTriviaToken;
        }

        public static int GetTrailingTriviaTokenEndIndex(IToken token, BufferedTokenStream tokenStream, int triviaChannel = -1)
        {
            IList<IToken> tokens = tokenStream.GetTokens();
            int i = token.TokenIndex + 1;
            int lastTriviaToken = token.TokenIndex;
            while (i < tokens.Count)
            {
                IToken t = tokens[i];
                string text = t.Text;
                if (t.Channel == 0)
                {
                    return lastTriviaToken;
                }
                else if (text.Contains('\r') || text.Contains('\n'))
                {
                    if (string.IsNullOrWhiteSpace(text)) return lastTriviaToken;
                    else return i;
                }
                else if (triviaChannel < 0 || t.Channel == triviaChannel)
                {
                    lastTriviaToken = i;
                }
                ++i;
            }
            return lastTriviaToken;
        }

        public static IList<IToken> GetLeadingTriviaTokens(IToken token, BufferedTokenStream tokenStream, int triviaChannel = -1)
        {
            int startIndex = GetLeadingTriviaTokenStartIndex(token, tokenStream, triviaChannel);
            int endIndex = token.TokenIndex - 1;
            if (startIndex >= 0 && startIndex <= endIndex && endIndex <= tokenStream.Size)
            {
                return tokenStream.GetTokens(startIndex, endIndex);
            }
            return new List<IToken>();
        }

        public static IList<IToken> GetTrailingTriviaTokens(IToken token, BufferedTokenStream tokenStream, int triviaChannel = -1)
        {
            int startIndex = token.TokenIndex + 1;
            int endIndex = GetTrailingTriviaTokenEndIndex(token, tokenStream, triviaChannel);
            if (startIndex >= 0 && startIndex <= endIndex && endIndex <= tokenStream.Size)
            {
                return tokenStream.GetTokens(startIndex, endIndex);
            }
            return new List<IToken>();
        }
    }
}
