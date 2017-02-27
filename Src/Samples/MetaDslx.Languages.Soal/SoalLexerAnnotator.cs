using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
/*
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219

namespace MetaDslx.Languages.Soal
{
    public class SoalLexerAnnotator
    {
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();
        private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();
        
        public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }
        
        
        public SoalLexerAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.modeAnnotations.Add(SoalLexer.LMultilineComment, annotList);
            TokenAnnotation __tmp1 = new TokenAnnotation();
            __tmp1.Kind = SoalLexer.Comment;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(SoalLexer.DOUBLEQUOTE_VERBATIM_STRING, annotList);
            TokenAnnotation __tmp2 = new TokenAnnotation();
            __tmp2.Kind = SoalLexer.String;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(SoalLexer.SINGLEQUOTE_VERBATIM_STRING, annotList);
            TokenAnnotation __tmp3 = new TokenAnnotation();
            __tmp3.Kind = SoalLexer.String;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.KNamespace, annotList);
            TokenAnnotation __tmp4 = new TokenAnnotation();
            __tmp4.Kind = SoalLexer.Keyword;
            __tmp4.First = SoalLexer.KNamespace;
            __tmp4.Last = SoalLexer.KVoid;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.IdentifierNormal, annotList);
            TokenAnnotation __tmp5 = new TokenAnnotation();
            __tmp5.Kind = SoalLexer.Identifier;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.IdentifierVerbatim, annotList);
            TokenAnnotation __tmp6 = new TokenAnnotation();
            __tmp6.Kind = SoalLexer.Identifier;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LInteger, annotList);
            TokenAnnotation __tmp7 = new TokenAnnotation();
            __tmp7.Kind = SoalLexer.Number;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDecimal, annotList);
            TokenAnnotation __tmp8 = new TokenAnnotation();
            __tmp8.Kind = SoalLexer.Number;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LScientific, annotList);
            TokenAnnotation __tmp9 = new TokenAnnotation();
            __tmp9.Kind = SoalLexer.Number;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDateTimeOffset, annotList);
            TokenAnnotation __tmp10 = new TokenAnnotation();
            __tmp10.Kind = SoalLexer.Number;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDateTime, annotList);
            TokenAnnotation __tmp11 = new TokenAnnotation();
            __tmp11.Kind = SoalLexer.Number;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDate, annotList);
            TokenAnnotation __tmp12 = new TokenAnnotation();
            __tmp12.Kind = SoalLexer.Number;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LTime, annotList);
            TokenAnnotation __tmp13 = new TokenAnnotation();
            __tmp13.Kind = SoalLexer.Number;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LRegularString, annotList);
            TokenAnnotation __tmp14 = new TokenAnnotation();
            __tmp14.Kind = SoalLexer.String;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LGuid, annotList);
            TokenAnnotation __tmp15 = new TokenAnnotation();
            __tmp15.Kind = SoalLexer.String;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LUtf8Bom, annotList);
            TokenAnnotation __tmp16 = new TokenAnnotation();
            __tmp16.Kind = SoalLexer.Whitespace;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LWhiteSpace, annotList);
            TokenAnnotation __tmp17 = new TokenAnnotation();
            __tmp17.Kind = SoalLexer.Whitespace;
            __tmp17.DefaultWhitespace = true;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LCrLf, annotList);
            TokenAnnotation __tmp18 = new TokenAnnotation();
            __tmp18.Kind = SoalLexer.Whitespace;
            __tmp18.EndOfLine = true;
            __tmp18.DefaultEndOfLine = true;
            annotList.Add(__tmp18);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LLineEnd, annotList);
            TokenAnnotation __tmp19 = new TokenAnnotation();
            __tmp19.Kind = SoalLexer.Whitespace;
            __tmp19.EndOfLine = true;
            annotList.Add(__tmp19);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LSingleLineComment, annotList);
            TokenAnnotation __tmp20 = new TokenAnnotation();
            __tmp20.Kind = SoalLexer.Comment;
            annotList.Add(__tmp20);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.COMMENT, annotList);
            TokenAnnotation __tmp21 = new TokenAnnotation();
            __tmp21.Kind = SoalLexer.Comment;
            annotList.Add(__tmp21);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDoubleQuoteVerbatimString, annotList);
            TokenAnnotation __tmp22 = new TokenAnnotation();
            __tmp22.Kind = SoalLexer.String;
            annotList.Add(__tmp22);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LSingleQuoteVerbatimString, annotList);
            TokenAnnotation __tmp23 = new TokenAnnotation();
            __tmp23.Kind = SoalLexer.String;
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
*/