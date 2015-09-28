using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    public class AnnotatedAntlr4LexerAnnotator
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
            __tmp1.Kind = Antlr4SyntaxKind.Action;
            __tmp1.First = AnnotatedAntlr4Lexer.ArgAction;
            __tmp1.Last = AnnotatedAntlr4Lexer.ArgAction;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.DOC_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            __tmp2.Kind = SyntaxKind.DocComment;
            __tmp2.First = AnnotatedAntlr4Lexer.DOC_COMMENT_MODE;
            __tmp2.Last = AnnotatedAntlr4Lexer.DOC_COMMENT_MODE;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            __tmp3.Kind = SyntaxKind.Comment;
            __tmp3.First = AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE;
            __tmp3.Last = AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            __tmp4.Kind = SyntaxKind.Comment;
            __tmp4.First = AnnotatedAntlr4Lexer.LINE_COMMENT;
            __tmp4.Last = AnnotatedAntlr4Lexer.LINE_COMMENT;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.OPTIONS, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            __tmp5.Kind = Antlr4SyntaxKind.Options;
            __tmp5.First = AnnotatedAntlr4Lexer.OPTIONS;
            __tmp5.Last = AnnotatedAntlr4Lexer.OPTIONS;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.TOKENS, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            __tmp6.Kind = Antlr4SyntaxKind.Tokens;
            __tmp6.First = AnnotatedAntlr4Lexer.TOKENS;
            __tmp6.Last = AnnotatedAntlr4Lexer.TOKENS;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.IMPORT, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.First = AnnotatedAntlr4Lexer.IMPORT;
            __tmp7.Last = AnnotatedAntlr4Lexer.NULL;
            __tmp7.Kind = SyntaxKind.Keyword;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.ID, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Identifier;
            __tmp8.First = AnnotatedAntlr4Lexer.ID;
            __tmp8.Last = AnnotatedAntlr4Lexer.ID;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.INTEGER_LITERAL, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = SyntaxKind.Number;
            __tmp9.First = AnnotatedAntlr4Lexer.INTEGER_LITERAL;
            __tmp9.Last = AnnotatedAntlr4Lexer.INTEGER_LITERAL;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.DECIMAL_LITERAL, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = SyntaxKind.Number;
            __tmp10.First = AnnotatedAntlr4Lexer.DECIMAL_LITERAL;
            __tmp10.Last = AnnotatedAntlr4Lexer.DECIMAL_LITERAL;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.SCIENTIFIC_LITERAL, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.Number;
            __tmp11.First = AnnotatedAntlr4Lexer.SCIENTIFIC_LITERAL;
            __tmp11.Last = AnnotatedAntlr4Lexer.SCIENTIFIC_LITERAL;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.STRING_LITERAL, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.String;
            __tmp12.First = AnnotatedAntlr4Lexer.STRING_LITERAL;
            __tmp12.Last = AnnotatedAntlr4Lexer.STRING_LITERAL;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            __tmp13.Kind = SyntaxKind.String;
            __tmp13.First = AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL;
            __tmp13.Last = AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.ACTION, annotList);
            SyntaxAnnotation __tmp14 = new SyntaxAnnotation();
            __tmp14.Kind = Antlr4SyntaxKind.Action;
            __tmp14.First = AnnotatedAntlr4Lexer.ACTION;
            __tmp14.Last = AnnotatedAntlr4Lexer.ACTION;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.ARG_ACTION, annotList);
            SyntaxAnnotation __tmp15 = new SyntaxAnnotation();
            __tmp15.Kind = Antlr4SyntaxKind.Action;
            __tmp15.First = AnnotatedAntlr4Lexer.ARG_ACTION;
            __tmp15.Last = AnnotatedAntlr4Lexer.ARG_ACTION;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.UNTERMINATED_ARG_ACTION, annotList);
            SyntaxAnnotation __tmp16 = new SyntaxAnnotation();
            __tmp16.Kind = Antlr4SyntaxKind.Action;
            __tmp16.First = AnnotatedAntlr4Lexer.UNTERMINATED_ARG_ACTION;
            __tmp16.Last = AnnotatedAntlr4Lexer.UNTERMINATED_ARG_ACTION;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.DOC_COMMENT, annotList);
            SyntaxAnnotation __tmp17 = new SyntaxAnnotation();
            __tmp17.Kind = SyntaxKind.Comment;
            __tmp17.First = AnnotatedAntlr4Lexer.DOC_COMMENT;
            __tmp17.Last = AnnotatedAntlr4Lexer.DOC_COMMENT;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.BLOCK_COMMENT, annotList);
            SyntaxAnnotation __tmp18 = new SyntaxAnnotation();
            __tmp18.Kind = SyntaxKind.Comment;
            __tmp18.First = AnnotatedAntlr4Lexer.BLOCK_COMMENT;
            __tmp18.Last = AnnotatedAntlr4Lexer.BLOCK_COMMENT;
            annotList.Add(__tmp18);
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

