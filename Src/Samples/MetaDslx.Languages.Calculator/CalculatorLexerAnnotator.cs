using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

// The variable '...' is assigned but its value is never used
#pragma warning disable 0219

namespace MetaDslx.Languages.Calculator
{
    public class CalculatorLexerAnnotator
    {
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();
        private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();
        
        public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }
        
        
        public CalculatorLexerAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(CalculatorLexer.KPrint, annotList);
            KeywordsAnnotation __tmp1 = new KeywordsAnnotation();
            __tmp1.First = CalculatorLexer.KPrint;
            __tmp1.Last = CalculatorLexer.KPrint;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(CalculatorLexer.UTF8BOM, annotList);
            WhitespaceAnnotation __tmp2 = new WhitespaceAnnotation();
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(CalculatorLexer.WHITESPACE, annotList);
            WhitespaceAnnotation __tmp3 = new WhitespaceAnnotation();
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(CalculatorLexer.ENDL, annotList);
            WhitespaceAnnotation __tmp4 = new WhitespaceAnnotation();
            __tmp4.Eol = true;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(CalculatorLexer.COMMENT, annotList);
            CommentAnnotation __tmp5 = new CommentAnnotation();
            annotList.Add(__tmp5);
        }
        
        public object VisitTerminal(ITerminalNode node, Dictionary<object, List<object>> treeAnnotations)
        {
            IToken token = node.Symbol;
            if (token != null)
            {
                List<object> annotList = null;
                if (this.tokenAnnotations.TryGetValue(token.Type, out annotList))
                {
                    List<object> treeAnnotList = null;
                    if (!treeAnnotations.TryGetValue(node, out treeAnnotList))
                    {
                        treeAnnotList = new List<object>();
                        treeAnnotations.Add(node, treeAnnotList);
                    }
                    treeAnnotList.AddRange(annotList);
                }
            }
            return null;
        }
    }
}
