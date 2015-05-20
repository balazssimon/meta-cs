using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    internal class MetaLexerAnnotator
    {
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();
        private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();
        
        public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }
        
        
        public MetaLexerAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.KNamespace, annotList);
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            __tmp1.First = MetaLexer.KNamespace;
            __tmp1.Last = MetaLexer.KStatic;
            __tmp1.Kind = SyntaxKind.Keyword;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.IdentifierNormal, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            __tmp2.Kind = SyntaxKind.Identifier;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.IntegerLiteral, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            __tmp3.Kind = SyntaxKind.Number;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.DecimalLiteral, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            __tmp4.Kind = SyntaxKind.Number;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.ScientificLiteral, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            __tmp5.Kind = SyntaxKind.Number;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.DateTimeOffsetLiteral, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            __tmp6.Kind = SyntaxKind.Number;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.DateTimeLiteral, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.Kind = SyntaxKind.Number;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.DateLiteral, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Number;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.TimeLiteral, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = SyntaxKind.Number;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.RegularStringLiteral, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = SyntaxKind.String;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.GuidLiteral, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.String;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.Comment;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaLexer.COMMENT, annotList);
            SyntaxAnnotation __tmp13 = new SyntaxAnnotation();
            __tmp13.Kind = SyntaxKind.Comment;
            annotList.Add(__tmp13);
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

