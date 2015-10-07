using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    public class MetaGeneratorLexerAnnotator
    {
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();
        private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();
        
        public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }
        
        
        public MetaGeneratorLexerAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaGeneratorLexer.MULTILINE_COMMENT, annotList);
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            __tmp1.Kind = SyntaxKind.Comment;
            __tmp1.First = MetaGeneratorLexer.MULTILINE_COMMENT;
            __tmp1.Last = MetaGeneratorLexer.MULTILINE_COMMENT;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaGeneratorLexer.DOUBLEQUOTE_VERBATIM_STRING, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            __tmp2.Kind = SyntaxKind.String;
            __tmp2.First = MetaGeneratorLexer.DOUBLEQUOTE_VERBATIM_STRING;
            __tmp2.Last = MetaGeneratorLexer.DOUBLEQUOTE_VERBATIM_STRING;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaGeneratorLexer.TEMPLATE_OUTPUT, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            __tmp3.Kind = MetaGeneratorSyntaxKind.TemplateOutput;
            __tmp3.First = MetaGeneratorLexer.TEMPLATE_OUTPUT;
            __tmp3.Last = MetaGeneratorLexer.TEMPLATE_OUTPUT;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.modeAnnotations.Add(MetaGeneratorLexer.TEMPLATE_STATEMENT_COMMENT, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            __tmp4.Kind = SyntaxKind.Comment;
            __tmp4.First = MetaGeneratorLexer.TEMPLATE_STATEMENT_COMMENT;
            __tmp4.Last = MetaGeneratorLexer.TEMPLATE_STATEMENT_COMMENT;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.KNamespace, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            __tmp5.First = MetaGeneratorLexer.KNamespace;
            __tmp5.Last = MetaGeneratorLexer.KDefault;
            __tmp5.Kind = SyntaxKind.Keyword;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TSemicolon, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            __tmp6.Kind = SyntaxKind.Operator;
            __tmp6.First = MetaGeneratorLexer.TSemicolon;
            __tmp6.Last = MetaGeneratorLexer.TQuestionQuestion;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.IdentifierNormal, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.Kind = SyntaxKind.Identifier;
            __tmp7.First = MetaGeneratorLexer.IdentifierNormal;
            __tmp7.Last = MetaGeneratorLexer.IdentifierNormal;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.IntegerLiteral, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Number;
            __tmp8.First = MetaGeneratorLexer.IntegerLiteral;
            __tmp8.Last = MetaGeneratorLexer.IntegerLiteral;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.DecimalLiteral, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = SyntaxKind.Number;
            __tmp9.First = MetaGeneratorLexer.DecimalLiteral;
            __tmp9.Last = MetaGeneratorLexer.DecimalLiteral;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.ScientificLiteral, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = SyntaxKind.Number;
            __tmp10.First = MetaGeneratorLexer.ScientificLiteral;
            __tmp10.Last = MetaGeneratorLexer.ScientificLiteral;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.DateTimeOffsetLiteral, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.Number;
            __tmp11.First = MetaGeneratorLexer.DateTimeOffsetLiteral;
            __tmp11.Last = MetaGeneratorLexer.DateTimeOffsetLiteral;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.DateTimeLiteral, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.Number;
            __tmp12.First = MetaGeneratorLexer.DateTimeLiteral;
            __tmp12.Last = MetaGeneratorLexer.DateTimeLiteral;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.DateLiteral, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            __tmp13.Kind = SyntaxKind.Number;
            __tmp13.First = MetaGeneratorLexer.DateLiteral;
            __tmp13.Last = MetaGeneratorLexer.DateLiteral;
            annotList.Add(__tmp13);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TimeLiteral, annotList);
            SyntaxAnnotation __tmp14 = new SyntaxAnnotation();
            __tmp14.Kind = SyntaxKind.Number;
            __tmp14.First = MetaGeneratorLexer.TimeLiteral;
            __tmp14.Last = MetaGeneratorLexer.TimeLiteral;
            annotList.Add(__tmp14);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.CharLiteral, annotList);
            SyntaxAnnotation __tmp15 = new SyntaxAnnotation();
            __tmp15.Kind = SyntaxKind.String;
            __tmp15.First = MetaGeneratorLexer.CharLiteral;
            __tmp15.Last = MetaGeneratorLexer.CharLiteral;
            annotList.Add(__tmp15);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.RegularStringLiteral, annotList);
            SyntaxAnnotation __tmp16 = new SyntaxAnnotation();
            __tmp16.Kind = SyntaxKind.String;
            __tmp16.First = MetaGeneratorLexer.RegularStringLiteral;
            __tmp16.Last = MetaGeneratorLexer.RegularStringLiteral;
            annotList.Add(__tmp16);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.GuidLiteral, annotList);
            SyntaxAnnotation __tmp17 = new SyntaxAnnotation();
            __tmp17.Kind = SyntaxKind.Number;
            __tmp17.First = MetaGeneratorLexer.GuidLiteral;
            __tmp17.Last = MetaGeneratorLexer.GuidLiteral;
            annotList.Add(__tmp17);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp18 = new SyntaxAnnotation();
            __tmp18.Kind = SyntaxKind.Comment;
            __tmp18.First = MetaGeneratorLexer.LINE_COMMENT;
            __tmp18.Last = MetaGeneratorLexer.LINE_COMMENT;
            annotList.Add(__tmp18);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.COMMENT, annotList);
            SyntaxAnnotation __tmp19 = new SyntaxAnnotation();
            __tmp19.Kind = SyntaxKind.Comment;
            __tmp19.First = MetaGeneratorLexer.COMMENT;
            __tmp19.Last = MetaGeneratorLexer.COMMENT;
            annotList.Add(__tmp19);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TH_TCloseParenthesis, annotList);
            SyntaxAnnotation __tmp20 = new SyntaxAnnotation();
            __tmp20.Kind = SyntaxKind.Operator;
            __tmp20.First = MetaGeneratorLexer.TH_TCloseParenthesis;
            __tmp20.Last = MetaGeneratorLexer.TH_TCloseParenthesis;
            annotList.Add(__tmp20);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.KEndTemplate, annotList);
            SyntaxAnnotation __tmp21 = new SyntaxAnnotation();
            __tmp21.Kind = SyntaxKind.Keyword;
            __tmp21.First = MetaGeneratorLexer.KEndTemplate;
            __tmp21.Last = MetaGeneratorLexer.KEndTemplate;
            annotList.Add(__tmp21);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TemplateLineControl, annotList);
            SyntaxAnnotation __tmp22 = new SyntaxAnnotation();
            __tmp22.Kind = MetaGeneratorSyntaxKind.TemplateControl;
            __tmp22.First = MetaGeneratorLexer.TemplateLineControl;
            __tmp22.Last = MetaGeneratorLexer.TemplateLineControl;
            annotList.Add(__tmp22);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TemplateOutput, annotList);
            SyntaxAnnotation __tmp23 = new SyntaxAnnotation();
            __tmp23.Kind = MetaGeneratorSyntaxKind.TemplateOutput;
            __tmp23.First = MetaGeneratorLexer.TemplateOutput;
            __tmp23.Last = MetaGeneratorLexer.TemplateOutput;
            annotList.Add(__tmp23);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TemplateCrLf, annotList);
            SyntaxAnnotation __tmp24 = new SyntaxAnnotation();
            __tmp24.Kind = MetaGeneratorSyntaxKind.TemplateOutput;
            __tmp24.First = MetaGeneratorLexer.TemplateCrLf;
            __tmp24.Last = MetaGeneratorLexer.TemplateCrLf;
            annotList.Add(__tmp24);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TemplateLineBreak, annotList);
            SyntaxAnnotation __tmp25 = new SyntaxAnnotation();
            __tmp25.Kind = MetaGeneratorSyntaxKind.TemplateOutput;
            __tmp25.First = MetaGeneratorLexer.TemplateLineBreak;
            __tmp25.Last = MetaGeneratorLexer.TemplateLineBreak;
            annotList.Add(__tmp25);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TemplateStatementStart, annotList);
            SyntaxAnnotation __tmp26 = new SyntaxAnnotation();
            __tmp26.Kind = MetaGeneratorSyntaxKind.TemplateControl;
            __tmp26.First = MetaGeneratorLexer.TemplateStatementStart;
            __tmp26.Last = MetaGeneratorLexer.TemplateStatementStart;
            annotList.Add(__tmp26);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaGeneratorLexer.TemplateStatementEnd, annotList);
            SyntaxAnnotation __tmp27 = new SyntaxAnnotation();
            __tmp27.Kind = MetaGeneratorSyntaxKind.TemplateControl;
            __tmp27.First = MetaGeneratorLexer.TemplateStatementEnd;
            __tmp27.Last = MetaGeneratorLexer.TemplateStatementEnd;
            annotList.Add(__tmp27);
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

