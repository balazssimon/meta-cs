using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeGeneration
{
    public ref struct CodeReader
    {
        private ReadOnlySpan<char> _code;

        public CodeReader(string code)
        {
            _code = code.AsSpan();
            int lastNonEndlineIndex = _code.Length - 1;
            while (lastNonEndlineIndex >= 0 && (_code[lastNonEndlineIndex] == '\r' || _code[lastNonEndlineIndex] == '\n'))
            {
                --lastNonEndlineIndex;
            }
            _code = _code.Slice(0, lastNonEndlineIndex + 1);
        }

        public bool EndOfStream => _code.Length == 0;
        
        public ReadOnlySpan<char> ReadLine()
        {
            int indexR = _code.IndexOf('\r');
            int indexN = _code.IndexOf('\n');
            int lineLength = _code.Length;
            int nextLineStartIndex = _code.Length;
            if (indexR >= 0)
            {
                if (indexN == indexR + 1)
                {
                    lineLength = indexR;
                    nextLineStartIndex = indexN + 1;
                }
                else if (indexN >= 0 && indexN < indexR)
                {
                    lineLength = indexN;
                    nextLineStartIndex = indexN + 1;
                }
                else
                {
                    lineLength = indexR;
                    nextLineStartIndex = indexR + 1;
                }
            }
            else if (indexN >= 0)
            {
                lineLength = indexN;
                nextLineStartIndex = indexN + 1;
            }
            var result = _code.Slice(0, lineLength);
            _code = _code.Slice(nextLineStartIndex);
            return result;
        }
    }
}
