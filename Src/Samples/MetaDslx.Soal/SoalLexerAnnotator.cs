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

namespace MetaDslx.Soal
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
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            __tmp1.Kind = SyntaxKind.Comment;
            __tmp1.First = SoalLexer.LMultilineComment;
            __tmp1.Last = SoalLexer.LMultilineComment;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(SoalLexer.DOUBLEQUOTE_VERBATIM_STRING, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            __tmp2.Kind = SyntaxKind.String;
            __tmp2.First = SoalLexer.DOUBLEQUOTE_VERBATIM_STRING;
            __tmp2.Last = SoalLexer.DOUBLEQUOTE_VERBATIM_STRING;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(SoalLexer.SINGLEQUOTE_VERBATIM_STRING, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            __tmp3.Kind = SyntaxKind.String;
            __tmp3.First = SoalLexer.SINGLEQUOTE_VERBATIM_STRING;
            __tmp3.Last = SoalLexer.SINGLEQUOTE_VERBATIM_STRING;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.KNamespace, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            __tmp4.Kind = SyntaxKind.Keyword;
            __tmp4.First = SoalLexer.KNamespace;
            __tmp4.Last = SoalLexer.KVoid;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.IdentifierNormal, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            __tmp5.Kind = SyntaxKind.Identifier;
            __tmp5.First = SoalLexer.IdentifierNormal;
            __tmp5.Last = SoalLexer.IdentifierNormal;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.IdentifierVerbatim, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            __tmp6.Kind = SyntaxKind.Identifier;
            __tmp6.First = SoalLexer.IdentifierVerbatim;
            __tmp6.Last = SoalLexer.IdentifierVerbatim;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LInteger, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.Kind = SyntaxKind.Number;
            __tmp7.First = SoalLexer.LInteger;
            __tmp7.Last = SoalLexer.LInteger;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDecimal, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Number;
            __tmp8.First = SoalLexer.LDecimal;
            __tmp8.Last = SoalLexer.LDecimal;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LScientific, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = SyntaxKind.Number;
            __tmp9.First = SoalLexer.LScientific;
            __tmp9.Last = SoalLexer.LScientific;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDateTimeOffset, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = SyntaxKind.Number;
            __tmp10.First = SoalLexer.LDateTimeOffset;
            __tmp10.Last = SoalLexer.LDateTimeOffset;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDateTime, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.Number;
            __tmp11.First = SoalLexer.LDateTime;
            __tmp11.Last = SoalLexer.LDateTime;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDate, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.Number;
            __tmp12.First = SoalLexer.LDate;
            __tmp12.Last = SoalLexer.LDate;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LTime, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            __tmp13.Kind = SyntaxKind.Number;
            __tmp13.First = SoalLexer.LTime;
            __tmp13.Last = SoalLexer.LTime;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LRegularString, annotList);
            SyntaxAnnotation __tmp14 = new SyntaxAnnotation();
            __tmp14.Kind = SyntaxKind.String;
            __tmp14.First = SoalLexer.LRegularString;
            __tmp14.Last = SoalLexer.LRegularString;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LGuid, annotList);
            SyntaxAnnotation __tmp15 = new SyntaxAnnotation();
            __tmp15.Kind = SyntaxKind.String;
            __tmp15.First = SoalLexer.LGuid;
            __tmp15.Last = SoalLexer.LGuid;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LSingleLineComment, annotList);
            SyntaxAnnotation __tmp16 = new SyntaxAnnotation();
            __tmp16.Kind = SyntaxKind.Comment;
            __tmp16.First = SoalLexer.LSingleLineComment;
            __tmp16.Last = SoalLexer.LSingleLineComment;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.COMMENT, annotList);
            SyntaxAnnotation __tmp17 = new SyntaxAnnotation();
            __tmp17.Kind = SyntaxKind.Comment;
            __tmp17.First = SoalLexer.COMMENT;
            __tmp17.Last = SoalLexer.COMMENT;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LDoubleQuoteVerbatimString, annotList);
            SyntaxAnnotation __tmp18 = new SyntaxAnnotation();
            __tmp18.Kind = SyntaxKind.String;
            __tmp18.First = SoalLexer.LDoubleQuoteVerbatimString;
            __tmp18.Last = SoalLexer.LDoubleQuoteVerbatimString;
            annotList.Add(__tmp18);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LSingleQuoteVerbatimString, annotList);
            SyntaxAnnotation __tmp19 = new SyntaxAnnotation();
            __tmp19.Kind = SyntaxKind.String;
            __tmp19.First = SoalLexer.LSingleQuoteVerbatimString;
            __tmp19.Last = SoalLexer.LSingleQuoteVerbatimString;
            annotList.Add(__tmp19);
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
