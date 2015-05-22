using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    internal class MetaModelLexerAnnotator
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
            this.tokenAnnotations.Add(MetaModelLexer.KNamespace, annotList);
            SyntaxAnnotation __tmp1 = new SyntaxAnnotation();
            __tmp1.First = MetaModelLexer.KNamespace;
            __tmp1.Last = MetaModelLexer.KStatic;
            __tmp1.Kind = SyntaxKind.Keyword;
            annotList.Add(__tmp1);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.IdentifierNormal, annotList);
            SyntaxAnnotation __tmp2 = new SyntaxAnnotation();
            __tmp2.Kind = SyntaxKind.Identifier;
            annotList.Add(__tmp2);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.IntegerLiteral, annotList);
            SyntaxAnnotation __tmp3 = new SyntaxAnnotation();
            __tmp3.Kind = SyntaxKind.Number;
            annotList.Add(__tmp3);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.DecimalLiteral, annotList);
            SyntaxAnnotation __tmp4 = new SyntaxAnnotation();
            __tmp4.Kind = SyntaxKind.Number;
            annotList.Add(__tmp4);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.ScientificLiteral, annotList);
            SyntaxAnnotation __tmp5 = new SyntaxAnnotation();
            __tmp5.Kind = SyntaxKind.Number;
            annotList.Add(__tmp5);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.DateTimeOffsetLiteral, annotList);
            SyntaxAnnotation __tmp6 = new SyntaxAnnotation();
            __tmp6.Kind = SyntaxKind.Number;
            annotList.Add(__tmp6);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.DateTimeLiteral, annotList);
            SyntaxAnnotation __tmp7 = new SyntaxAnnotation();
            __tmp7.Kind = SyntaxKind.Number;
            annotList.Add(__tmp7);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.DateLiteral, annotList);
            SyntaxAnnotation __tmp8 = new SyntaxAnnotation();
            __tmp8.Kind = SyntaxKind.Number;
            annotList.Add(__tmp8);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.TimeLiteral, annotList);
            SyntaxAnnotation __tmp9 = new SyntaxAnnotation();
            __tmp9.Kind = SyntaxKind.Number;
            annotList.Add(__tmp9);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.RegularStringLiteral, annotList);
            SyntaxAnnotation __tmp10 = new SyntaxAnnotation();
            __tmp10.Kind = SyntaxKind.String;
            annotList.Add(__tmp10);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.GuidLiteral, annotList);
            SyntaxAnnotation __tmp11 = new SyntaxAnnotation();
            __tmp11.Kind = SyntaxKind.String;
            annotList.Add(__tmp11);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.LINE_COMMENT, annotList);
            SyntaxAnnotation __tmp12 = new SyntaxAnnotation();
            __tmp12.Kind = SyntaxKind.Comment;
            annotList.Add(__tmp12);
            
            annotList = new List<object>();
            this.tokenAnnotations.Add(MetaModelLexer.COMMENT, annotList);
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

