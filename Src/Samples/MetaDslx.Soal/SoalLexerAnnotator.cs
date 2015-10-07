using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

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
            this.modeAnnotations.Add(SoalLexer.MULTILINE_COMMENT, annotList);
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            __tmp1.Kind = SyntaxKind.Comment;
            __tmp1.First = SoalLexer.MULTILINE_COMMENT;
            __tmp1.Last = SoalLexer.MULTILINE_COMMENT;
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
            this.tokenAnnotations.Add(SoalLexer.IntegerLiteral, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.Kind = SyntaxKind.Number;
            __tmp7.First = SoalLexer.IntegerLiteral;
            __tmp7.Last = SoalLexer.IntegerLiteral;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.DecimalLiteral, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Number;
            __tmp8.First = SoalLexer.DecimalLiteral;
            __tmp8.Last = SoalLexer.DecimalLiteral;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.ScientificLiteral, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = SyntaxKind.Number;
            __tmp9.First = SoalLexer.ScientificLiteral;
            __tmp9.Last = SoalLexer.ScientificLiteral;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.DateTimeOffsetLiteral, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = SyntaxKind.Number;
            __tmp10.First = SoalLexer.DateTimeOffsetLiteral;
            __tmp10.Last = SoalLexer.DateTimeOffsetLiteral;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.DateTimeLiteral, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.Number;
            __tmp11.First = SoalLexer.DateTimeLiteral;
            __tmp11.Last = SoalLexer.DateTimeLiteral;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.DateLiteral, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.Number;
            __tmp12.First = SoalLexer.DateLiteral;
            __tmp12.Last = SoalLexer.DateLiteral;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.TimeLiteral, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            __tmp13.Kind = SyntaxKind.Number;
            __tmp13.First = SoalLexer.TimeLiteral;
            __tmp13.Last = SoalLexer.TimeLiteral;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.RegularStringLiteral, annotList);
            SyntaxAnnotation __tmp14 = new SyntaxAnnotation();
            __tmp14.Kind = SyntaxKind.String;
            __tmp14.First = SoalLexer.RegularStringLiteral;
            __tmp14.Last = SoalLexer.RegularStringLiteral;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.GuidLiteral, annotList);
            SyntaxAnnotation __tmp15 = new SyntaxAnnotation();
            __tmp15.Kind = SyntaxKind.String;
            __tmp15.First = SoalLexer.GuidLiteral;
            __tmp15.Last = SoalLexer.GuidLiteral;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp16 = new SyntaxAnnotation();
            __tmp16.Kind = SyntaxKind.Comment;
            __tmp16.First = SoalLexer.LINE_COMMENT;
            __tmp16.Last = SoalLexer.LINE_COMMENT;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.COMMENT, annotList);
            SyntaxAnnotation __tmp17 = new SyntaxAnnotation();
            __tmp17.Kind = SyntaxKind.Comment;
            __tmp17.First = SoalLexer.COMMENT;
            __tmp17.Last = SoalLexer.COMMENT;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.DoubleQuoteVerbatimStringLiteral, annotList);
            SyntaxAnnotation __tmp18 = new SyntaxAnnotation();
            __tmp18.Kind = SyntaxKind.String;
            __tmp18.First = SoalLexer.DoubleQuoteVerbatimStringLiteral;
            __tmp18.Last = SoalLexer.DoubleQuoteVerbatimStringLiteral;
            annotList.Add(__tmp18);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(SoalLexer.SingleQuoteVerbatimStringLiteral, annotList);
            SyntaxAnnotation __tmp19 = new SyntaxAnnotation();
            __tmp19.Kind = SyntaxKind.String;
            __tmp19.First = SoalLexer.SingleQuoteVerbatimStringLiteral;
            __tmp19.Last = SoalLexer.SingleQuoteVerbatimStringLiteral;
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
