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
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.ActionMode, annotList);
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            __tmp1.Kind = Antlr4SyntaxKind.Action;
            __tmp1.First = AnnotatedAntlr4Lexer.ActionMode;
            __tmp1.Last = AnnotatedAntlr4Lexer.ActionMode;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.Options, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            __tmp2.Kind = Antlr4SyntaxKind.Options;
            __tmp2.First = AnnotatedAntlr4Lexer.Options;
            __tmp2.Last = AnnotatedAntlr4Lexer.Options;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.Tokens, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            __tmp3.Kind = Antlr4SyntaxKind.Options;
            __tmp3.First = AnnotatedAntlr4Lexer.Tokens;
            __tmp3.Last = AnnotatedAntlr4Lexer.Tokens;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.Channels, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            __tmp4.Kind = Antlr4SyntaxKind.Options;
            __tmp4.First = AnnotatedAntlr4Lexer.Channels;
            __tmp4.Last = AnnotatedAntlr4Lexer.Channels;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.DOC_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            __tmp5.Kind = SyntaxKind.DocComment;
            __tmp5.First = AnnotatedAntlr4Lexer.DOC_COMMENT_MODE;
            __tmp5.Last = AnnotatedAntlr4Lexer.DOC_COMMENT_MODE;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            __tmp6.Kind = SyntaxKind.Comment;
            __tmp6.First = AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE;
            __tmp6.Last = AnnotatedAntlr4Lexer.BLOCK_COMMENT_MODE;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.ACTION_DOC_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.Kind = SyntaxKind.DocComment;
            __tmp7.First = AnnotatedAntlr4Lexer.ACTION_DOC_COMMENT_MODE;
            __tmp7.Last = AnnotatedAntlr4Lexer.ACTION_DOC_COMMENT_MODE;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(AnnotatedAntlr4Lexer.ACTION_BLOCK_COMMENT_MODE, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Comment;
            __tmp8.First = AnnotatedAntlr4Lexer.ACTION_BLOCK_COMMENT_MODE;
            __tmp8.Last = AnnotatedAntlr4Lexer.ACTION_BLOCK_COMMENT_MODE;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.TOKEN_REF, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = Antlr4SyntaxKind.Token;
            __tmp9.First = AnnotatedAntlr4Lexer.TOKEN_REF;
            __tmp9.Last = AnnotatedAntlr4Lexer.TOKEN_REF;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.RULE_REF, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = Antlr4SyntaxKind.Rule;
            __tmp10.First = AnnotatedAntlr4Lexer.RULE_REF;
            __tmp10.Last = AnnotatedAntlr4Lexer.RULE_REF;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.LEXER_CHAR_SET, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.Operator;
            __tmp11.First = AnnotatedAntlr4Lexer.LEXER_CHAR_SET;
            __tmp11.Last = AnnotatedAntlr4Lexer.LEXER_CHAR_SET;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.Comment;
            __tmp12.First = AnnotatedAntlr4Lexer.LINE_COMMENT;
            __tmp12.Last = AnnotatedAntlr4Lexer.LINE_COMMENT;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.INT, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            __tmp13.Kind = SyntaxKind.Number;
            __tmp13.First = AnnotatedAntlr4Lexer.INT;
            __tmp13.Last = AnnotatedAntlr4Lexer.INT;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.STRING_LITERAL, annotList);
            SyntaxAnnotation __tmp14 = new SyntaxAnnotation();
            __tmp14.Kind = SyntaxKind.String;
            __tmp14.First = AnnotatedAntlr4Lexer.STRING_LITERAL;
            __tmp14.Last = AnnotatedAntlr4Lexer.STRING_LITERAL;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL, annotList);
            SyntaxAnnotation __tmp15 = new SyntaxAnnotation();
            __tmp15.Kind = SyntaxKind.String;
            __tmp15.First = AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL;
            __tmp15.Last = AnnotatedAntlr4Lexer.UNTERMINATED_STRING_LITERAL;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.BEGIN_ACTION, annotList);
            SyntaxAnnotation __tmp16 = new SyntaxAnnotation();
            __tmp16.Kind = Antlr4SyntaxKind.Action;
            __tmp16.First = AnnotatedAntlr4Lexer.BEGIN_ACTION;
            __tmp16.Last = AnnotatedAntlr4Lexer.BEGIN_ACTION;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.OPTIONS, annotList);
            SyntaxAnnotation __tmp17 = new SyntaxAnnotation();
            __tmp17.Kind = Antlr4SyntaxKind.Options;
            __tmp17.First = AnnotatedAntlr4Lexer.OPTIONS;
            __tmp17.Last = AnnotatedAntlr4Lexer.OPTIONS;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.TOKENS, annotList);
            SyntaxAnnotation __tmp18 = new SyntaxAnnotation();
            __tmp18.Kind = Antlr4SyntaxKind.Options;
            __tmp18.First = AnnotatedAntlr4Lexer.TOKENS;
            __tmp18.Last = AnnotatedAntlr4Lexer.TOKENS;
            annotList.Add(__tmp18);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.CHANNELS, annotList);
            SyntaxAnnotation __tmp19 = new SyntaxAnnotation();
            __tmp19.Kind = Antlr4SyntaxKind.Options;
            __tmp19.First = AnnotatedAntlr4Lexer.CHANNELS;
            __tmp19.Last = AnnotatedAntlr4Lexer.CHANNELS;
            annotList.Add(__tmp19);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.IMPORT, annotList);
            SyntaxAnnotation __tmp20 = new SyntaxAnnotation();
            __tmp20.First = AnnotatedAntlr4Lexer.IMPORT;
            __tmp20.Last = AnnotatedAntlr4Lexer.NULL;
            __tmp20.Kind = SyntaxKind.Keyword;
            annotList.Add(__tmp20);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.ID, annotList);
            SyntaxAnnotation __tmp21 = new SyntaxAnnotation();
            __tmp21.Kind = SyntaxKind.Identifier;
            __tmp21.First = AnnotatedAntlr4Lexer.ID;
            __tmp21.Last = AnnotatedAntlr4Lexer.ID;
            annotList.Add(__tmp21);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.DOC_COMMENT, annotList);
            SyntaxAnnotation __tmp22 = new SyntaxAnnotation();
            __tmp22.Kind = SyntaxKind.Comment;
            __tmp22.First = AnnotatedAntlr4Lexer.DOC_COMMENT;
            __tmp22.Last = AnnotatedAntlr4Lexer.DOC_COMMENT;
            annotList.Add(__tmp22);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(AnnotatedAntlr4Lexer.BLOCK_COMMENT, annotList);
            SyntaxAnnotation __tmp23 = new SyntaxAnnotation();
            __tmp23.Kind = SyntaxKind.Comment;
            __tmp23.First = AnnotatedAntlr4Lexer.BLOCK_COMMENT;
            __tmp23.Last = AnnotatedAntlr4Lexer.BLOCK_COMMENT;
            annotList.Add(__tmp23);
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
