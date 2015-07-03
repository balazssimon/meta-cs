using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    internal class AnnotatedAntlr4LexerAnnotator
    {
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();
        private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();
        
        public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }
        
        
        public AnnotatedAntlr4LexerAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.ArgAction, annotList);
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.DOC_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.OPTIONS, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.TOKENS, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.IMPORT, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.ID, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.INTEGER_LITERAL, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.DECIMAL_LITERAL, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.SCIENTIFIC_LITERAL, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.STRING_LITERAL, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.ACTION, annotList);
            SyntaxAnnotation __tmp14 = new SyntaxAnnotation();
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.DOC_COMMENT, annotList);
            SyntaxAnnotation __tmp15 = new SyntaxAnnotation();
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.BLOCK_COMMENT, annotList);
            SyntaxAnnotation __tmp16 = new SyntaxAnnotation();
            annotList.Add(__tmp16);
        }
        
        public object VisitTerminal(ITerminalNode node, Dictionary<object, List<object>> treeAnnotations)
        {
            IToken token = node.Symbol;
            if (token != null)
            {
                List<object> annotList = null;
                List<object> staticAnnotList = null;
                if (this.tokenAnnotations.TryGetValue(token.Type, out staticAnnotList))
                {
                    annotList = new List<object>(staticAnnotList);
                }
                switch (token.Type)
                {
                    default:
                        break;
                }
                if (annotList != null)
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

