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

namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    public class MetaModelLexerAnnotator
    {
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();
        private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();
        
        public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }
        
        
        public MetaModelLexerAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaModelLexer.LMultilineComment, annotList);
            TokenAnnotation __tmp1 = new TokenAnnotation();
            __tmp1.Kind = MetaModelLexer.Comment;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaModelLexer.DOUBLEQUOTE_VERBATIM_STRING, annotList);
            TokenAnnotation __tmp2 = new TokenAnnotation();
            __tmp2.Kind = MetaModelLexer.String;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaModelLexer.SINGLEQUOTE_VERBATIM_STRING, annotList);
            TokenAnnotation __tmp3 = new TokenAnnotation();
            __tmp3.Kind = MetaModelLexer.String;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.KNamespace, annotList);
            TokenAnnotation __tmp4 = new TokenAnnotation();
            __tmp4.First = MetaModelLexer.KNamespace;
            __tmp4.Last = MetaModelLexer.KStatic;
            __tmp4.Kind = MetaModelLexer.Keyword;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.IdentifierNormal, annotList);
            TokenAnnotation __tmp5 = new TokenAnnotation();
            __tmp5.Kind = MetaModelLexer.Identifier;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LInteger, annotList);
            TokenAnnotation __tmp6 = new TokenAnnotation();
            __tmp6.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LDecimal, annotList);
            TokenAnnotation __tmp7 = new TokenAnnotation();
            __tmp7.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LScientific, annotList);
            TokenAnnotation __tmp8 = new TokenAnnotation();
            __tmp8.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LDateTimeOffset, annotList);
            TokenAnnotation __tmp9 = new TokenAnnotation();
            __tmp9.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LDateTime, annotList);
            TokenAnnotation __tmp10 = new TokenAnnotation();
            __tmp10.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LDate, annotList);
            TokenAnnotation __tmp11 = new TokenAnnotation();
            __tmp11.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LTime, annotList);
            TokenAnnotation __tmp12 = new TokenAnnotation();
            __tmp12.Kind = MetaModelLexer.Number;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LRegularString, annotList);
            TokenAnnotation __tmp13 = new TokenAnnotation();
            __tmp13.Kind = MetaModelLexer.String;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LGuid, annotList);
            TokenAnnotation __tmp14 = new TokenAnnotation();
            __tmp14.Kind = MetaModelLexer.String;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LUtf8Bom, annotList);
            TokenAnnotation __tmp15 = new TokenAnnotation();
            __tmp15.Kind = MetaModelLexer.Whitespace;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LWhiteSpace, annotList);
            TokenAnnotation __tmp16 = new TokenAnnotation();
            __tmp16.Kind = MetaModelLexer.Whitespace;
            __tmp16.DefaultWhitespace = true;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LCrLf, annotList);
            TokenAnnotation __tmp17 = new TokenAnnotation();
            __tmp17.Kind = MetaModelLexer.Whitespace;
            __tmp17.EndOfLine = true;
            __tmp17.DefaultEndOfLine = true;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LLineEnd, annotList);
            TokenAnnotation __tmp18 = new TokenAnnotation();
            __tmp18.Kind = MetaModelLexer.Whitespace;
            __tmp18.EndOfLine = true;
            annotList.Add(__tmp18);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LSingleLineComment, annotList);
            TokenAnnotation __tmp19 = new TokenAnnotation();
            __tmp19.Kind = MetaModelLexer.Comment;
            annotList.Add(__tmp19);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LComment, annotList);
            TokenAnnotation __tmp20 = new TokenAnnotation();
            __tmp20.Kind = MetaModelLexer.Comment;
            annotList.Add(__tmp20);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LDoubleQuoteVerbatimString, annotList);
            TokenAnnotation __tmp21 = new TokenAnnotation();
            __tmp21.Kind = MetaModelLexer.String;
            annotList.Add(__tmp21);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LSingleQuoteVerbatimString, annotList);
            TokenAnnotation __tmp22 = new TokenAnnotation();
            __tmp22.Kind = MetaModelLexer.String;
            annotList.Add(__tmp22);
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

