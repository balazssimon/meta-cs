using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace MetaDslx.Compiler
{
    public class MetaGeneratorSyntaxKind
    {
        public const int TemplateOutput = 13;
        public const int TemplateControl = 14;
    }

    public class MetaGeneratorCompiler : MetaCompiler
    {
        public MetaGeneratorCompiler(string source, string fileName)
            : base(source, fileName)
        {
        }

        protected override void DoCompile()
        {
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new MetaGeneratorLexer(inputStream);
            this.Lexer.AddErrorListener(this);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new MetaGeneratorParser(this.CommonTokenStream);
            this.Parser.AddErrorListener(this);
            this.ParseTree = this.Parser.main();
        }

        public MetaGeneratorParser.MainContext ParseTree { get; private set; }
        public MetaGeneratorLexer Lexer { get; private set; }
        public MetaGeneratorParser Parser { get; private set; }
    }

    public class MetaGeneratorGenerator
    {
        private bool generated = false;
        private string generatedSource = null;
        public MetaGeneratorParser.MainContext ParseTree { get; private set; }
        public string GeneratedSource
        {
            get
            {
                if (!this.generated)
                {
                    this.generatedSource = this.Generate();
                    this.generated = true;
                }
                return this.generatedSource;
            }
        }

        public MetaGeneratorGenerator(MetaGeneratorParser.MainContext parseTree)
        {
            this.ParseTree = parseTree;
        }

        public string Generate()
        {
            StringBuilder sb = new StringBuilder();
            var ul = new MetaGenCSharpUsingVisitor(sb);
            ul.Visit(this.ParseTree);
            ul.Close();
            var cl = new MetaGenCSharpClassVisitor(sb);
            cl.Loops = ul.Loops;
            cl.HasLoops = ul.HasLoops;
            cl.Visit(this.ParseTree);
            cl.Close();
            return sb.ToString();
        }
    }

    internal class LoopInfo
    {
        public string Name { get; set; }
        public List<LoopItemInfo> Items { get; private set; }
        public MetaGeneratorParser.LoopStatementBeginContext Loop { get; set; }
        public MetaGeneratorParser.HasLoopExpressionContext HasLoop { get; set; }
        public LoopInfo()
        {
            this.Items = new List<LoopItemInfo>();
        }
    }

    internal class LoopItemInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public MetaGeneratorParser.LoopChainItemContext ChainItem { get; set; }
    }

    internal class SwitchInfo
    {
        public string TmpName { get; set; }
        public int CaseCount { get; set; }
        public string IdentifierName { get; set; }
        public bool AllowTypeAs { get; set; }
        public MetaGeneratorParser.TypeReferenceContext TypeAsContext { get; set; }
    }

    internal static class ContextExtensions
    {
        public static string ToComment(this ParserRuleContext prc)
        {
            if (prc == null || prc.Start == null) return string.Empty;
            return string.Format("//{0}:{1}", prc.Start.Line, prc.Start.Column+1);
        }
    }

    internal abstract class MetaGenVisitor : MetaGeneratorParserBaseVisitor<object>
    {
        private StringBuilder sb;
        private string indent;
        private int loopCounter;
        public Dictionary<MetaGeneratorParser.LoopStatementBeginContext, LoopInfo> Loops { get; set; }
        public Dictionary<MetaGeneratorParser.HasLoopExpressionContext, LoopInfo> HasLoops { get; set; }

        public MetaGenVisitor(StringBuilder sb)
        {
            this.sb = sb;
            this.indent = "";
            this.loopCounter = 0;
            this.Loops = new Dictionary<MetaGeneratorParser.LoopStatementBeginContext, LoopInfo>();
            this.HasLoops = new Dictionary<MetaGeneratorParser.HasLoopExpressionContext, LoopInfo>();
        }

        protected void IncIndent()
        {
            indent += "    ";
        }

        protected void DecIndent()
        {
            indent = indent.Substring(4);
        }

        protected void WriteIndent()
        {
            sb.Append(indent);
        }

        protected void Write(string text)
        {
            sb.Append(text);
        }

        protected void Write(string format, params object[] args)
        {
            sb.Append(string.Format(format, args));
        }

        protected void AppendLine()
        {
            sb.AppendLine();
        }

        protected void WriteLine(string text = "")
        {
            this.WriteIndent();
            this.Write(text);
            this.AppendLine();
        }

        protected void WriteLine(string format, params object[] args)
        {
            this.WriteIndent();
            this.Write(format, args);
            this.AppendLine();
        }

        public virtual void Close()
        {

        }

        protected string GetLoopChainItemName(MetaGeneratorParser.LoopChainExpressionContext context)
        {
            if (context is MetaGeneratorParser.LoopChainIdentifierExpressionContext)
            {
                return ((MetaGeneratorParser.LoopChainIdentifierExpressionContext)context).identifier().GetText();
            }
            if (context is MetaGeneratorParser.LoopChainMemberAccessExpressionContext)
            {
                return ((MetaGeneratorParser.LoopChainMemberAccessExpressionContext)context).identifier().GetText();
            }
            if (context is MetaGeneratorParser.LoopChainMethodCallExpressionContext)
            {
                return GetLoopChainItemName(((MetaGeneratorParser.LoopChainMethodCallExpressionContext)context).loopChainExpression());
            }
            return null;
        }

        public override object VisitLoopStatementBegin(MetaGeneratorParser.LoopStatementBeginContext context)
        {
            ++this.loopCounter;
            LoopInfo li = new LoopInfo();
            li.Name = "__loop" + this.loopCounter.ToString();
            li.Loop = context;
            int varCounter = 0;
            foreach (var child in context.loopChain().children)
            {
                var item = child as MetaGeneratorParser.LoopChainItemContext;
                if (item != null)
                {
                    LoopItemInfo lii = new LoopItemInfo();
                    string name = this.GetLoopChainItemName(item.loopChainExpression());
                    if (item.identifier() != null) name = item.identifier().GetText();
                    else if (li.Items.Count == 0)
                    {
                        ++varCounter;
                        name = li.Name + "_var" + varCounter.ToString();
                    }
                    if (name == null)
                    {
                        ++varCounter;
                        name = li.Name + "_var" + varCounter.ToString();
                    }
                    lii.Name = name;
                    string type = "Object";
                    if (item.typeReference() != null) type = item.typeReference().GetText();
                    lii.Type = type;
                    lii.ChainItem = item;
                    li.Items.Add(lii);
                }
            }
            this.Loops.Add(context, li);
            return null;
        }

        public override object VisitHasLoopExpression(MetaGeneratorParser.HasLoopExpressionContext context)
        {
            ++this.loopCounter;
            LoopInfo li = new LoopInfo();
            li.Name = "__loop" + this.loopCounter.ToString();
            li.HasLoop = context;
            int varCounter = 0;
            foreach (var child in context.loopChain().children)
            {
                var item = child as MetaGeneratorParser.LoopChainItemContext;
                if (item != null)
                {
                    LoopItemInfo lii = new LoopItemInfo();
                    string name = this.GetLoopChainItemName(item.loopChainExpression());
                    if (item.identifier() != null) name = item.identifier().GetText();
                    else if (li.Items.Count == 0)
                    {
                        ++varCounter;
                        name = li.Name + "_var" + varCounter.ToString();
                    }
                    if (name == null)
                    {
                        ++varCounter;
                        name = li.Name + "_var" + varCounter.ToString();
                    }
                    lii.Name = name;
                    string type = "Object";
                    if (item.typeReference() != null) type = item.typeReference().GetText();
                    lii.Type = type;
                    lii.ChainItem = item;
                    li.Items.Add(lii);
                }
            }
            this.HasLoops.Add(context, li);
            return null;
        }
    }

    internal class MetaGenCSharpUsingVisitor : MetaGenVisitor
    {
        public MetaGenCSharpUsingVisitor(StringBuilder sb)
            : base(sb)
        {
        }

        public override void Close()
        {
            WriteLine();
        }

        public override object VisitMain(MetaGeneratorParser.MainContext context)
        {
            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            WriteLine("using System.IO;");
            WriteLine("using System.Linq;");
            WriteLine("using System.Text;");
            WriteLine("using System.Threading.Tasks;");
            VisitChildren(context);
            return null;
        }

        public override object VisitUsingNamespaceDeclaration(MetaGeneratorParser.UsingNamespaceDeclarationContext context)
        {
            WriteLine("using {0}; {1}", context.qualifiedName().GetText(), context.ToComment());
            return null;
        }

    }

    internal class MetaGenCSharpClassVisitor : MetaGenVisitor
    {
        private int tmpCounter = 0;
        private List<SwitchInfo> switchStack = new List<SwitchInfo>();

        public MetaGenCSharpClassVisitor(StringBuilder sb)
            : base(sb)
        {
        }

        private string EscapeText(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in text)
            {
                if (ch == '"' || ch == '\\') sb.Append("\\" + ch);
                else sb.Append(ch);
            }
            return sb.ToString();
        }

        private string NewTmp()
        {
            ++tmpCounter;
            return "__tmp" + tmpCounter;
        }

        public override void Close()
        {
            WriteLine("private class StringBuilder");
            WriteLine("{");
            IncIndent();
            WriteLine("private bool newLine;");
            WriteLine("private System.Text.StringBuilder builder = new System.Text.StringBuilder();");
            WriteLine("");
            WriteLine("public StringBuilder()");
            WriteLine("{");
            IncIndent();
            WriteLine("this.newLine = true;");
            DecIndent();
            WriteLine("}");
            WriteLine("");
            WriteLine("public void Append(string str)");
            WriteLine("{");
            IncIndent();
            WriteLine("if (str == null) return;");
            WriteLine("if (!string.IsNullOrEmpty(str))");
            WriteLine("{");
            IncIndent();
            WriteLine("this.newLine = false;");
            DecIndent();
            WriteLine("}");
            WriteLine("builder.Append(str);");
            DecIndent();
            WriteLine("}");
            WriteLine("");
            WriteLine("public void Append(object obj)");
            WriteLine("{");
            IncIndent();
            WriteLine("if (obj == null) return;");
            WriteLine("string text = obj.ToString();");
            WriteLine("this.Append(text);");
            DecIndent();
            WriteLine("}");
            WriteLine("");
            WriteLine("public void AppendLine(bool force = false)");
            WriteLine("{");
            IncIndent();
            WriteLine("if (force || !this.newLine)");
            WriteLine("{");
            IncIndent();
            WriteLine("builder.AppendLine();");
            WriteLine("this.newLine = true;");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
            WriteLine("");
            WriteLine("public override string ToString()");
            WriteLine("{");
            IncIndent();
            WriteLine("return builder.ToString();");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
        }

        public override object VisitNamespaceDeclaration(MetaGeneratorParser.NamespaceDeclarationContext context)
        {
            WriteLine("namespace {0} {1}", context.qualifiedName().GetText(), context.ToComment());
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitGeneratorDeclaration(MetaGeneratorParser.GeneratorDeclarationContext context)
        {
            string name = context.identifier().GetText();
            Random rnd = new Random();
            int randomInt = rnd.Next(int.MaxValue);
            WriteLine("using __Hidden_{0}_{1};", name, randomInt);
            WriteLine("namespace __Hidden_{0}_{1}", name, randomInt);
            WriteLine("{");
            IncIndent();
            WriteLine("internal static class __Extensions");
            WriteLine("{");
            IncIndent();
            WriteLine("internal static IEnumerator<T> GetEnumerator<T>(this T item)");
            WriteLine("{");
            IncIndent();
            WriteLine("if (item == null) return new List<T>().GetEnumerator();");
            WriteLine("else return new List<T> { item }.GetEnumerator();");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
            AppendLine();
            WriteLine("public class {0} {1}", name, context.ToComment());
            WriteLine("{");
            this.IncIndent();
            string instancesType = "object";
            if (context.typeReference() != null)
            {
                instancesType = context.typeReference().GetText();
            }
            WriteLine("private {0} Instances; {1}", instancesType, context.ToComment());
            AppendLine();
            WriteLine("public {0}() {1}", name, context.ToComment());
            WriteLine("{");
            IncIndent();
            var config = ((MetaGeneratorParser.MainContext)context.Parent).configDeclaration();
            if (config != null)
            {
                string propertiesName = "Properties";
                if (config.identifier() != null) propertiesName = config.identifier().GetText();
                WriteLine("this.{0} = new __{0}();", propertiesName);
            }
            DecIndent();
            WriteLine("}");
            AppendLine();
            WriteLine("public {0}({1} instances) : this() {2}", name, instancesType, context.ToComment());
            WriteLine("{");
            IncIndent();
            WriteLine("this.Instances = instances;");
            DecIndent();
            WriteLine("}");
            AppendLine();
            WriteLine("private Stream __ToStream(string text)");
            WriteLine("{");
            IncIndent();
            WriteLine("MemoryStream stream = new MemoryStream();");
            WriteLine("StreamWriter writer = new StreamWriter(stream);");
            WriteLine("writer.Write(text);");
            WriteLine("writer.Flush();");
            WriteLine("stream.Position = 0;");
            WriteLine("return stream;");
            DecIndent();
            WriteLine("}");
            AppendLine();
            WriteLine("private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)", name, instancesType);
            WriteLine("{");
            IncIndent();
            WriteLine("while (items.MoveNext())");
            WriteLine("{");
            IncIndent();
            WriteLine("yield return items.Current;");
            DecIndent();
            WriteLine("}");
            DecIndent();
            WriteLine("}");
            AppendLine();
            WriteLine("private int counter = 0;");
            WriteLine("private int NextCounter()");
            WriteLine("{");
            IncIndent();
            WriteLine("return ++counter;");
            DecIndent();
            WriteLine("}");
            AppendLine();
            return null;
        }

        public override object VisitUsingGeneratorDeclaration(MetaGeneratorParser.UsingGeneratorDeclarationContext context)
        {
            var qn = context.qualifiedName();
            string type = qn.GetText();
            string name = "";
            if (context.identifier() == null)
            {
                name = qn.children[qn.ChildCount - 1].GetText();
            }
            else
            {
                name = context.identifier().GetText();
            }
            WriteLine("private {0} {1} = new {0}(); {2}", type, name, context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitConfigDeclaration(MetaGeneratorParser.ConfigDeclarationContext context)
        {
            string name = "Properties";
            if (context.identifier() != null) name = context.identifier().GetText();
            WriteLine("public __{0} {0} {1} get; private set; {2} {3}", name, "{", "}", context.ToComment());
            AppendLine();
            WriteLine("public class __{0} {1}", name, context.ToComment());
            WriteLine("{");
            IncIndent();
            WriteLine("internal __{0}()", name);
            WriteLine("{");
            IncIndent();
            foreach (var child in context.children)
            {
                if (child is MetaGeneratorParser.ConfigPropertyDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyDeclarationContext;
                    if (prop.expression() != null)
                    {
                        WriteIndent();
                        Write("this.{0} = ", prop.identifier().GetText());
                        Visit(prop.expression());
                        Write("; {0}", prop.expression().ToComment());
                        AppendLine();
                    }
                }
                if (child is MetaGeneratorParser.ConfigPropertyGroupDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyGroupDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyGroupDeclarationContext;
                    WriteLine("this.{0} = new __{0}();", prop.identifier().GetText());
                }
            }
            DecIndent();
            WriteLine("}");
            foreach (var child in context.children)
            {
                if (child is MetaGeneratorParser.ConfigPropertyDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyDeclarationContext;
                    WriteLine("public {0} {1} {2} get; set; {3} {4}", prop.typeReference().GetText(), prop.identifier().GetText(), "{", "}", prop.ToComment());
                }
                if (child is MetaGeneratorParser.ConfigPropertyGroupDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyGroupDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyGroupDeclarationContext;
                    WriteLine("public __{0} {0} {1} get; private set; {2} {3}", prop.identifier().GetText(), "{", "}", prop.ToComment());
                }
            }
            DecIndent();
            WriteLine("}");
            AppendLine();
            foreach (var child in context.children)
            {
                if (child is MetaGeneratorParser.ConfigPropertyGroupDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyGroupDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyGroupDeclarationContext;
                    Visit(prop);
                }
            }
            return null;
        }

        public override object VisitConfigPropertyGroupDeclaration(MetaGeneratorParser.ConfigPropertyGroupDeclarationContext context)
        {
            string name = context.identifier().GetText();
            WriteLine("public class __{0} {1}", name, context.ToComment());
            WriteLine("{");
            IncIndent();
            WriteLine("internal __{0}()", name);
            WriteLine("{");
            IncIndent();
            foreach (var child in context.children)
            {
                if (child is MetaGeneratorParser.ConfigPropertyDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyDeclarationContext;
                    if (prop.expression() != null)
                    {
                        WriteIndent();
                        Write("this.{0} = ", prop.identifier().GetText());
                        Visit(prop.expression());
                        Write("; {0}", prop.expression().ToComment());
                        AppendLine();
                    }
                }
                if (child is MetaGeneratorParser.ConfigPropertyGroupDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyGroupDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyGroupDeclarationContext;
                    WriteLine("this.{0} = new __{0}();", prop.identifier().GetText());
                }
            }
            DecIndent();
            WriteLine("}");
            foreach (var child in context.children)
            {
                if (child is MetaGeneratorParser.ConfigPropertyDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyDeclarationContext;
                    WriteLine("public {0} {1} {2} get; set; {3} {4}", prop.typeReference().GetText(), prop.identifier().GetText(), "{", "}", prop.ToComment());
                }
                if (child is MetaGeneratorParser.ConfigPropertyGroupDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyGroupDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyGroupDeclarationContext;
                    WriteLine("public __{0} {0} {1} get; private set; {2} {3}", prop.identifier().GetText(), "{", "}", prop.ToComment());
                }
            }
            DecIndent();
            WriteLine("}");
            AppendLine();
            foreach (var child in context.children)
            {
                if (child is MetaGeneratorParser.ConfigPropertyGroupDeclarationContext)
                {
                    MetaGeneratorParser.ConfigPropertyGroupDeclarationContext prop = child as MetaGeneratorParser.ConfigPropertyGroupDeclarationContext;
                    Visit(prop);
                }
            }
            return null;
        }

        public override object VisitFunctionDeclaration(MetaGeneratorParser.FunctionDeclarationContext context)
        {
            Visit(context.functionSignature());
            WriteLine("{");
            IncIndent();
            tmpCounter = 0;
            Visit(context.body());
            DecIndent();
            WriteLine("}");
            AppendLine();
            return null;
        }

        public override object VisitFunctionSignature(MetaGeneratorParser.FunctionSignatureContext context)
        {
            WriteIndent();
            Write("public {0} {1}(", context.returnType().GetText(), context.identifier().GetText());
            if (context.paramList() != null)
            {
                Visit(context.paramList());
            }
            Write(") {0}", context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitTemplateDeclaration(MetaGeneratorParser.TemplateDeclarationContext context)
        {
            Visit(context.templateSignature());
            WriteLine("{");
            IncIndent();
            WriteLine("StringBuilder __out = new StringBuilder();");
            tmpCounter = 0;
            Visit(context.templateBody());
            WriteLine("return __out.ToString();");
            DecIndent();
            WriteLine("}");
            AppendLine();
            return null;
        }

        public override object VisitTemplateSignature(MetaGeneratorParser.TemplateSignatureContext context)
        {
            WriteIndent();
            Write("public string {0}(", context.identifier().GetText());
            if (context.paramList() != null)
            {
                Visit(context.paramList());
            }
            Write(") {0}", context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitParamList(MetaGeneratorParser.ParamListContext context)
        {
            string comma = "";
            foreach (var param in context.parameter())
            {
                Write(comma);
                Visit(param);
                comma = ", ";
            }
            return null;
        }

        public override object VisitParameter(MetaGeneratorParser.ParameterContext context)
        {
            Write("{0} {1}", context.typeReference().GetText(), context.identifier().GetText());
            if (context.expression() != null)
            {
                Write(" = ");
                Visit(context.expression());
            }
            return null;
        }

        public override object VisitVariableDeclarationStatement(MetaGeneratorParser.VariableDeclarationStatementContext context)
        {
            WriteIndent();
            Write("{0} {1}", context.typeReference().GetText(), context.identifier().GetText());
            if (context.expression() != null)
            {
                Write(" = ");
                Visit(context.expression());
            }
            Write("; " + context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitReturnStatement(MetaGeneratorParser.ReturnStatementContext context)
        {
            WriteIndent();
            Write("return ");
            Visit(context.expression());
            Write("; " + context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitExpressionStatement(MetaGeneratorParser.ExpressionStatementContext context)
        {
            WriteIndent();
            Visit(context.expression());
            Write("; " + context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitIfStatementBegin(MetaGeneratorParser.IfStatementBeginContext context)
        {
            WriteIndent();
            Write("if (");
            Visit(context.expression());
            Write(") " + context.ToComment());
            AppendLine();
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitElseIfStatement(MetaGeneratorParser.ElseIfStatementContext context)
        {
            DecIndent();
            WriteLine("}");
            WriteIndent();
            Write("else if (");
            Visit(context.expression());
            Write(") " + context.ToComment());
            AppendLine();
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitIfStatementElse(MetaGeneratorParser.IfStatementElseContext context)
        {
            DecIndent();
            WriteLine("}");
            WriteLine("else " + context.ToComment());
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitIfStatementEnd(MetaGeneratorParser.IfStatementEndContext context)
        {
            DecIndent();
            WriteLine("}");
            return null;
        }

        public override object VisitExpressionList(MetaGeneratorParser.ExpressionListContext context)
        {
            string comma = "";
            foreach (var expr in context.children)
            {
                if (expr is MetaGeneratorParser.ExpressionContext)
                {
                    Write(comma);
                    Visit(expr);
                    comma = ", ";
                }
            }
            return null;
        }

        public override object VisitThisExpression(MetaGeneratorParser.ThisExpressionContext context)
        {
            Write("this");
            return null;
        }

        public override object VisitLiteral(MetaGeneratorParser.LiteralContext context)
        {
            Write(context.GetText());
            return null;
        }

        public override object VisitTypeofVoidExpression(MetaGeneratorParser.TypeofVoidExpressionContext context)
        {
            Write(context.GetText());
            return null;
        }

        public override object VisitTypeofUnboundTypeExpression(MetaGeneratorParser.TypeofUnboundTypeExpressionContext context)
        {
            Write(context.GetText());
            return null;
        }

        public override object VisitTypeofTypeExpression(MetaGeneratorParser.TypeofTypeExpressionContext context)
        {
            Write(context.GetText());
            return null;
        }

        public override object VisitDefaultValueExpression(MetaGeneratorParser.DefaultValueExpressionContext context)
        {
            Write(context.GetText());
            return null;
        }

        /*
        public override object VisitNewObjectOrCollectionExpression(MetaGeneratorParser.NewObjectOrCollectionExpressionContext context)
        {
            Write("new ");
            Write(context.typeReference().GetText());
            if (context.objectOrCollectionInitializer() != null)
            {
                throw new NotSupportedException();
            }
            return null;
        }
         */

        public override object VisitNewObjectOrCollectionWithConstructorExpression(MetaGeneratorParser.NewObjectOrCollectionWithConstructorExpressionContext context)
        {
            Write("new ");
            Write(context.typeReference().GetText());
            Write("(");
            if (context.expressionList() != null)
            {
                Visit(context.expressionList());
            }
            Write(")");
            /*if (context.objectOrCollectionInitializer() != null)
            {
                throw new NotSupportedException();
            }*/
            return null;
        }

        private string ResolveIdentifier(string name)
        {
            StringBuilder result = new StringBuilder();
            if (this.switchStack.Count > 0)
            {
                List<MetaGeneratorParser.TypeReferenceContext> casts = new List<MetaGeneratorParser.TypeReferenceContext>();
                for (int i = this.switchStack.Count - 1; i >= 0; i--)
                {
                    SwitchInfo switchInfo = this.switchStack[i];
                    if (switchInfo.IdentifierName == name)
                    {
                        if (switchInfo.AllowTypeAs && switchInfo.TypeAsContext != null)
                        {
                            casts.Add(switchInfo.TypeAsContext);
                        }
                    }
                }
                if (casts.Count > 0)
                {
                    result.Append("(");
                    for (int i = 0; i < casts.Count; i++)
                    {
                        result.Append("(");
                        result.Append(casts[i].GetText());
                        result.Append(")");
                    }
                    result.Append(name);
                    result.Append(")");
                }
                else
                {
                    result.Append(name);
                }
            }
            else
            {
                result.Append(name);
            }
            return result.ToString();
        }

        public override object VisitIdentifierExpression(MetaGeneratorParser.IdentifierExpressionContext context)
        {
            Write(ResolveIdentifier(context.GetText()));
            return null;
        }

        public override object VisitParenthesizedExpression(MetaGeneratorParser.ParenthesizedExpressionContext context)
        {
            Write("(");
            VisitChildren(context);
            Write(")");
            return null;
        }

        public override object VisitElementAccessExpression(MetaGeneratorParser.ElementAccessExpressionContext context)
        {
            Visit(context.expression());
            Write("[");
            Visit(context.expressionList());
            Write("]");
            return null;
        }

        public override object VisitFunctionCallExpression(MetaGeneratorParser.FunctionCallExpressionContext context)
        {
            Visit(context.expression());
            Write("(");
            if (context.expressionList() != null)
            {
                Visit(context.expressionList());
            }
            Write(")");
            return null;
        }

        public override object VisitPredefinedTypeMemberAccessExpression(MetaGeneratorParser.PredefinedTypeMemberAccessExpressionContext context)
        {
            Write(context.GetText());
            return null;
        }

        public override object VisitMemberAccessExpression(MetaGeneratorParser.MemberAccessExpressionContext context)
        {
            Visit(context.expression());
            Write(".");
            Write(context.identifier().GetText());
            if (context.typeArgumentList() != null)
            {
                Write(context.typeArgumentList().GetText());
            }
            return null;
        }

        public override object VisitTypecastExpression(MetaGeneratorParser.TypecastExpressionContext context)
        {
            Write("(");
            Write(context.typeReference().GetText());
            Write(")");
            Visit(context.expression());
            return null;
        }

        public override object VisitUnaryExpression(MetaGeneratorParser.UnaryExpressionContext context)
        {
            Write(context.GetChild(0).GetText());
            Visit(context.expression());
            return null;
        }

        public override object VisitPostExpression(MetaGeneratorParser.PostExpressionContext context)
        {
            Visit(context.expression());
            Write(context.GetChild(1).GetText());
            return null;
        }

        public override object VisitMultiplicationExpression(MetaGeneratorParser.MultiplicationExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitAdditionExpression(MetaGeneratorParser.AdditionExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitRelationalExpression(MetaGeneratorParser.RelationalExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitTypecheckExpression(MetaGeneratorParser.TypecheckExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Write(context.GetChild(2).GetText());
            return null;
        }

        public override object VisitEqualityExpression(MetaGeneratorParser.EqualityExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitBitwiseAndExpression(MetaGeneratorParser.BitwiseAndExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitBitwiseXorExpression(MetaGeneratorParser.BitwiseXorExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitBitwiseOrExpression(MetaGeneratorParser.BitwiseOrExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitLogicalAndExpression(MetaGeneratorParser.LogicalAndExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitLogicalXorExpression(MetaGeneratorParser.LogicalXorExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitLogicalOrExpression(MetaGeneratorParser.LogicalOrExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitConditionalExpression(MetaGeneratorParser.ConditionalExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            Write(" {0} ", context.GetChild(3).GetText());
            Visit(context.GetChild(4));
            return null;
        }

        public override object VisitAssignmentExpression(MetaGeneratorParser.AssignmentExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" {0} ", context.GetChild(1).GetText());
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitLambdaExpression(MetaGeneratorParser.LambdaExpressionContext context)
        {
            Visit(context.GetChild(0));
            Write(" => ");
            Visit(context.GetChild(2));
            return null;
        }

        public override object VisitImplicitAnonymousFunctionSignature(MetaGeneratorParser.ImplicitAnonymousFunctionSignatureContext context)
        {
            Write("(");
            string comma = "";
            foreach (var param in context.children)
            {
                if (param is MetaGeneratorParser.ImplicitParameterContext)
                {
                    Write(comma);
                    Visit(param);
                    comma = ", ";
                }
            }
            Write(")");
            return null;
        }

        public override object VisitExplicitAnonymousFunctionSignature(MetaGeneratorParser.ExplicitAnonymousFunctionSignatureContext context)
        {
            Write("(");
            string comma = "";
            foreach (var param in context.children)
            {
                if (param is MetaGeneratorParser.ExplicitParameterContext)
                {
                    Write(comma);
                    Visit(param);
                    comma = ", ";
                }
            }
            Write(")");
            return null;
        }

        public override object VisitSingleParamAnonymousFunctionSignature(MetaGeneratorParser.SingleParamAnonymousFunctionSignatureContext context)
        {
            Visit(context.implicitParameter());
            return null;
        }

        public override object VisitImplicitParameter(MetaGeneratorParser.ImplicitParameterContext context)
        {
            Write(context.identifier().GetText());
            return null;
        }

        public override object VisitExplicitParameter(MetaGeneratorParser.ExplicitParameterContext context)
        {
            Write("{0} {1}", context.typeReference().GetText(), context.identifier().GetText());
            return null;
        }

        private bool IsTemplateOutputExpression(MetaGeneratorParser.TemplateStatementStartEndContext statementStartEnd)
        {
            MetaGeneratorParser.TemplateStatementContext statement = statementStartEnd.templateStatement();
            if (statement != null && statement.expressionStatement() != null)
            {
                MetaGeneratorParser.ExpressionContext expression = statement.expressionStatement().expression();
                return !(expression is MetaGeneratorParser.LambdaExpressionContext || expression is MetaGeneratorParser.AssignmentExpressionContext);
            }
            return false;
        }

        private bool ForceNewLine(MetaGeneratorParser.TemplateContentLineContext context)
        {
            string lineEndText = context.templateLineEnd().GetText();
            return lineEndText.StartsWith("^");
        }

        private bool NoNewLine(MetaGeneratorParser.TemplateContentLineContext context)
        {
            string lineEndText = context.templateLineEnd().GetText();
            return lineEndText.StartsWith("\\");
        }

        public override object VisitTemplateContentLine(MetaGeneratorParser.TemplateContentLineContext context)
        {
            bool forceNewLine = this.ForceNewLine(context);
            bool noNewLine = this.NoNewLine(context);
            int lastIndex = context.ChildCount - 2;
            int outputCount = 0;
            int nonWhitespaceOutputCount = 0;
            int outputExpressionCount = 0;
            int statementCount = 0;
            for (int i = 0; i <= lastIndex; ++i)
            {
                var child = context.children[i];
                if (child is MetaGeneratorParser.TemplateOutputContext)
                {
                    ++outputCount;
                    MetaGeneratorParser.TemplateOutputContext toc = child as MetaGeneratorParser.TemplateOutputContext;
                    if (!string.IsNullOrWhiteSpace(toc.GetText()))
                    {
                        ++nonWhitespaceOutputCount;
                    }
                }
                if (child is MetaGeneratorParser.TemplateStatementStartEndContext)
                {
                    MetaGeneratorParser.TemplateStatementStartEndContext tse = child as MetaGeneratorParser.TemplateStatementStartEndContext;
                    if (tse.templateStatement() != null)
                    {
                        if (IsTemplateOutputExpression(tse))
                        {
                            ++outputExpressionCount;
                        }
                        else
                        {
                            ++statementCount;
                        }
                    }
                }
            }
            if (statementCount == 0 && outputExpressionCount == 0)
            {
                if (nonWhitespaceOutputCount > 0)
                {
                    for (int i = 0; i <= lastIndex; ++i)
                    {
                        var child = context.children[i];
                        Visit(child);
                    }
                    if (forceNewLine || !noNewLine)
                    {
                        VisitTemplateLineEnd(context.templateLineEnd());
                    }
                }
                else
                {
                    if (forceNewLine)
                    {
                        VisitTemplateLineEnd(context.templateLineEnd());
                    }
                }
            }
            else if (statementCount > 0 && (outputExpressionCount == 0 && nonWhitespaceOutputCount == 0))
            {
                for (int i = 0; i <= lastIndex; ++i)
                {
                    var child = context.children[i];
                    if (child is MetaGeneratorParser.TemplateStatementStartEndContext)
                    {
                        Visit(child);
                    }
                }
                if (forceNewLine)
                {
                    VisitTemplateLineEnd(context.templateLineEnd());
                }
            }
            else if (outputExpressionCount > 0)
            {
                int startIndex = 0;
                int endIndex = lastIndex;
                string prefix = NewTmp() + "Prefix";
                string prefixText = null;
                if (lastIndex >= 1)
                {
                    MetaGeneratorParser.TemplateOutputContext output;
                    output = context.children[0] as MetaGeneratorParser.TemplateOutputContext;
                    if (output != null)
                    {
                        prefixText = output.GetText();
                    }
                    if (prefixText != null && string.IsNullOrWhiteSpace(prefixText))
                    {
                        WriteLine("string {0} = \"{1}\"; {2}", prefix, EscapeText(prefixText), output.ToComment());
                        startIndex = 1;
                    }
                }
                for (int i = startIndex; i <= endIndex; ++i)
                {
                    var child = context.children[i];
                    string tmp = NewTmp();
                    bool hasOutput = false;
                    bool closeBraces = false;
                    if (child is MetaGeneratorParser.TemplateOutputContext)
                    {
                        MetaGeneratorParser.TemplateOutputContext output = child as MetaGeneratorParser.TemplateOutputContext;
                        WriteLine("string {0}Line = \"{1}\"; {2}", tmp, EscapeText(output.GetText()), output.ToComment());
                        hasOutput = true;
                    }
                    else if (child is MetaGeneratorParser.TemplateStatementStartEndContext)
                    {
                        MetaGeneratorParser.TemplateStatementStartEndContext statement = child as MetaGeneratorParser.TemplateStatementStartEndContext;
                        if (statement.templateStatement() != null)
                        {
                            if (IsTemplateOutputExpression(statement))
                            {
                                closeBraces = true;
                                WriteLine("StringBuilder {0} = new StringBuilder();", tmp);
                                VisitTemplateStatement(statement.templateStatement(), tmp);
                                WriteLine("using(StreamReader {0}Reader = new StreamReader(this.__ToStream({0}.ToString())))", tmp);
                                WriteLine("{");
                                IncIndent();
                                WriteLine("bool {0}_first = true;", tmp);
                                WriteLine("bool {0}_last = {0}Reader.EndOfStream;", tmp);
                                WriteLine("while({0}_first || !{0}_last)", tmp);
                                WriteLine("{");
                                IncIndent();
                                WriteLine("{0}_first = false;", tmp);
                                WriteLine("string {0}Line = {0}Reader.ReadLine();", tmp);
                                WriteLine("{0}_last = {0}Reader.EndOfStream;", tmp);
                                hasOutput = true;
                            }
                            else
                            {
                                Visit(statement);
                            }
                        }
                    }
                    if (startIndex > 0 && i == startIndex)
                    {
                        WriteLine("__out.Append({0});", prefix);
                    }
                    if (hasOutput)
                    {
                        WriteLine("if ({0}Line != null) __out.Append({0}Line);", tmp);
                        if (closeBraces)
                        {
                            WriteLine("if (!{0}_last) __out.AppendLine(true);", tmp);
                        }
                    }
                    if (i == endIndex)
                    {
                        if (forceNewLine || !noNewLine)
                        {
                            VisitTemplateLineEnd(context.templateLineEnd());
                        }
                    }
                    if (hasOutput)
                    {
                        if (closeBraces)
                        {
                            DecIndent();
                            WriteLine("}");
                            DecIndent();
                            WriteLine("}");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= lastIndex; ++i)
                {
                    var child = context.children[i];
                    Visit(child);
                }
                if (forceNewLine || !noNewLine)
                {
                    VisitTemplateLineEnd(context.templateLineEnd());
                }
            }
            return null;
        }

        public object VisitTemplateOutput(MetaGeneratorParser.TemplateOutputContext context, string output)
        {
            WriteLine("{0}.Append(\"{1}\"); {2}", output, EscapeText(context.TemplateOutput().GetText()), context.ToComment());
            return null;
        }

        public override object VisitTemplateOutput(MetaGeneratorParser.TemplateOutputContext context)
        {
            return VisitTemplateOutput(context, "__out");
        }

        public object VisitTemplateLineEnd(MetaGeneratorParser.TemplateLineEndContext context, string output)
        {
            if (context.TemplateCrLf() != null)
            {
                string lineBreakText = context.TemplateCrLf().GetText();
                string force = lineBreakText.StartsWith("^") ? "true" : "false";
                if (!lineBreakText.StartsWith("\\"))
                {
                    WriteLine("{0}.AppendLine({2}); {1}", output, context.ToComment(), force);
                }
            }
            else if (context.TemplateLineBreak() != null)
            {
                string lineBreakText = context.TemplateLineBreak().GetText();
                string force = lineBreakText.StartsWith("^") ? "true" : "false";
                if (!context.TemplateLineBreak().GetText().StartsWith("\\"))
                {
                    WriteLine("{0}.AppendLine({2}); {1}", output, context.ToComment(), force);
                }
            }
            else if (context.TemplateLineControl() != null)
            {
                string lineBreakText = context.TemplateLineControl().GetText();
                string force = lineBreakText.StartsWith("^") ? "true" : "false";
                if (!context.TemplateLineControl().GetText().StartsWith("\\"))
                {
                    WriteLine("{0}.AppendLine({2}); {1}", output, context.ToComment(), force);
                }
            }
            return null;
        }

        public override object VisitTemplateLineEnd(MetaGeneratorParser.TemplateLineEndContext context)
        {
            return VisitTemplateLineEnd(context, "__out");
        }

        public object VisitTemplateStatement(MetaGeneratorParser.TemplateStatementContext context, string output)
        {
            if (context.expressionStatement() != null)
            {
                MetaGeneratorParser.ExpressionContext expression = context.expressionStatement().expression();
                if (expression is MetaGeneratorParser.LambdaExpressionContext || expression is MetaGeneratorParser.AssignmentExpressionContext)
                {
                    WriteIndent();
                    Visit(expression);
                    Write(";");
                    AppendLine();
                }
                else
                {
                    WriteIndent();
                    Write("{0}.Append(", output);
                    Visit(expression);
                    Write(");");
                    AppendLine();
                }
            }
            else
            {
                VisitChildren(context);
            }
            return null;
        }

        public override object VisitTemplateStatement(MetaGeneratorParser.TemplateStatementContext context)
        {
            return VisitTemplateStatement(context, "__out");
        }

        public override object VisitLoopStatementBegin(MetaGeneratorParser.LoopStatementBeginContext context)
        {
            LoopInfo li = this.Loops[context];
            WriteLine("var {0}_results = ", li.Name);
            IncIndent();
            for (int i = 0; i < li.Items.Count; i++)
            {
                LoopItemInfo lii = li.Items[i];
                MetaGeneratorParser.LoopChainItemContext lci = lii.ChainItem;
                if (lci.loopChainExpression() is MetaGeneratorParser.LoopChainTypeofExpressionContext)
                {
                    MetaGeneratorParser.LoopChainTypeofExpressionContext expression = (MetaGeneratorParser.LoopChainTypeofExpressionContext)lci.loopChainExpression();
                    WriteIndent();
                    Write("from {0} in __Enumerate(({1}).GetEnumerator()).OfType<{2}>() {3}", lii.Name, i > 0 ? ResolveIdentifier(li.Items[i - 1].Name) : "", expression.typeReference().GetText(), lci.ToComment());
                    AppendLine();
                }
                else if (i == 0)
                {
                    WriteIndent();
                    Write("(from {0} in __Enumerate((", lii.Name);
                    Visit(lci);
                    Write(").GetEnumerator()) {0}", lci.ToComment());
                    AppendLine();
                }
                else
                {
                    WriteIndent();
                    Write("from {0} in __Enumerate(({1}.", lii.Name, ResolveIdentifier(li.Items[i - 1].Name));
                    Visit(lci);
                    Write(").GetEnumerator()) {0}", lci.ToComment());
                    AppendLine();
                }
            }
            if (context.loopWhereExpression() != null)
            {
                WriteIndent();
                Write("where ");
                Visit(context.loopWhereExpression().expression());
                Write(" {0}", context.loopWhereExpression().ToComment());
                AppendLine();
            }
            WriteIndent();
            Write("select new { ");
            for (int i = 0; i < li.Items.Count; i++)
            {
                LoopItemInfo lii = li.Items[i];
                if (i > 0) Write(", ");
                Write("{0} = {0}", lii.Name);
            }
            Write("}");
            AppendLine();
            WriteLine(").ToList(); {0}", context.ToComment());
            DecIndent();
            string tmp1 = NewTmp();
            WriteLine("int {0}_iteration = 0;", li.Name);
            if (context.loopRunExpression() != null)
            {
                var lrl = context.loopRunExpression().children[1] as MetaGeneratorParser.LoopRunListContext;
                Visit(lrl);
            }
            WriteLine("foreach (var {1} in {0}_results)", li.Name, tmp1);
            WriteLine("{");
            IncIndent();
            WriteLine("++{0}_iteration;", li.Name);
            if (context.loopRunExpression() != null)
            {
                var lre = context.loopRunExpression();
                for (int i = lre.ChildCount - 1; i >= 2; --i)
                {
                    MetaGeneratorParser.LoopRunListContext lrl = lre.children[i] as MetaGeneratorParser.LoopRunListContext;
                    if (lrl != null)
                    {
                        if (i == lre.ChildCount - 1) WriteIndent();
                        Write("if ({0}_iteration >= {1}) {2}", li.Name, i / 2 + 1, lrl.ToComment());
                        AppendLine();
                        WriteLine("{");
                        IncIndent();
                        Visit(lrl);
                        DecIndent();
                        WriteLine("}");
                        if (i >= 5)
                        {
                            WriteIndent();
                            Write("else ");
                        }
                    }
                }
            }
            foreach (var lii in li.Items)
            {
                WriteLine("var {1} = {0}.{1};", tmp1, lii.Name);
            }
            return null;
        }

        public override object VisitLoopStatementEnd(MetaGeneratorParser.LoopStatementEndContext context)
        {
            DecIndent();
            WriteLine("}");
            return null;
        }

        public override object VisitHasLoopExpression(MetaGeneratorParser.HasLoopExpressionContext context)
        {
            LoopInfo li = this.HasLoops[context];
            for (int i = 0; i < li.Items.Count; i++)
            {
                LoopItemInfo lii = li.Items[i];
                MetaGeneratorParser.LoopChainItemContext lci = lii.ChainItem;
                if (lci.loopChainExpression() is MetaGeneratorParser.LoopChainTypeofExpressionContext)
                {
                    MetaGeneratorParser.LoopChainTypeofExpressionContext expression = (MetaGeneratorParser.LoopChainTypeofExpressionContext)lci.loopChainExpression();
                    WriteIndent();
                    Write("from {0} in __Enumerate(({1}).GetEnumerator()).OfType<{2}>() {3}", lii.Name, i > 0 ? ResolveIdentifier(li.Items[i - 1].Name) : "", expression.typeReference().GetText(), lci.ToComment());
                    AppendLine();
                }
                else if (i == 0)
                {
                    Write("(from {0} in __Enumerate((", lii.Name);
                    Visit(lci);
                    Write(").GetEnumerator()) {0}", lci.ToComment());
                    AppendLine();
                }
                else
                {
                    WriteIndent();
                    Write("from {0} in __Enumerate(({1}.", lii.Name, ResolveIdentifier(li.Items[i - 1].Name));
                    Visit(lci);
                    Write(").GetEnumerator()) {0}", lci.ToComment());
                    AppendLine();
                }
            }
            if (context.loopWhereExpression() != null)
            {
                WriteIndent();
                Write("where ");
                Visit(context.loopWhereExpression().expression());
                Write(" {0}", context.loopWhereExpression().ToComment());
                AppendLine();
            }
            WriteIndent();
            Write("select new { ");
            for (int i = 0; i < li.Items.Count; i++)
            {
                LoopItemInfo lii = li.Items[i];
                if (i > 0) Write(", ");
                Write("{0} = {0}", lii.Name);
            }
            Write("}");
            AppendLine();
            WriteIndent();
            Write(").GetEnumerator().MoveNext()");
            return null;
        }

        public override object VisitLoopChainIdentifierExpression(MetaGeneratorParser.LoopChainIdentifierExpressionContext context)
        {
            Write(ResolveIdentifier(context.identifier().GetText()));
            if (context.typeArgumentList() != null)
            {
                Write(context.typeArgumentList().GetText());
            }
            return null;
        }

        public override object VisitLoopChainMemberAccessExpression(MetaGeneratorParser.LoopChainMemberAccessExpressionContext context)
        {
            Visit(context.loopChainExpression());
            Write(".");
            Write(context.identifier().GetText());
            if (context.typeArgumentList() != null)
            {
                Write(context.typeArgumentList().GetText());
            }
            return null;
        }

        public override object VisitLoopChainMethodCallExpression(MetaGeneratorParser.LoopChainMethodCallExpressionContext context)
        {
            Visit(context.loopChainExpression());
            Write("(");
            if (context.expressionList() != null)
            {
                Visit(context.expressionList());
            }
            Write(")");
            return null;
        }


        public override object VisitSwitchStatementBegin([NotNull] MetaGeneratorParser.SwitchStatementBeginContext context)
        {
            string tmp1 = NewTmp();
            SwitchInfo switchInfo =
                new SwitchInfo()
                {
                    TmpName = tmp1
                };
            this.switchStack.Add(switchInfo);
            WriteIndent();
            Write("var {0} = ", tmp1);
            MetaGeneratorParser.IdentifierExpressionContext id = context.expression() as MetaGeneratorParser.IdentifierExpressionContext;
            if (id != null && id.typeArgumentList() == null)
            {
                switchInfo.AllowTypeAs = true;
                switchInfo.IdentifierName = id.identifier().GetText();
            }
            this.Visit(context.expression());
            Write("; {0}", context.expression().ToComment());
            AppendLine();
            return null;
        }

        public override object VisitSwitchStatementEnd([NotNull] MetaGeneratorParser.SwitchStatementEndContext context)
        {
            if (this.switchStack.Count > 0)
            {
                this.switchStack.RemoveAt(this.switchStack.Count - 1);
            }
            DecIndent();
            WriteIndent();
            Write("}");
            Write("{0}", context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitSwitchBranchHeadStatement([NotNull] MetaGeneratorParser.SwitchBranchHeadStatementContext context)
        {
            SwitchInfo switchInfo = null;
            if (this.switchStack.Count > 0)
            {
                switchInfo = this.switchStack[this.switchStack.Count - 1];
            }
            else
            {
                switchInfo = new SwitchInfo();
            }
            if (switchInfo.CaseCount > 0)
            {
                DecIndent();
                WriteLine("}");
                WriteIndent();
                Write("else ");
            }
            else
            {
                WriteIndent();
            }
            switchInfo.CaseCount = switchInfo.CaseCount + 1;
            switchInfo.TypeAsContext = null;
            if (context.switchTypeAsHeadStatement() != null)
            {
                if (switchInfo.AllowTypeAs)
                {
                    switchInfo.TypeAsContext = context.switchTypeAsHeadStatement().typeReference();
                }
                else
                {
                    // TODO: error message
                }
                Write("if ({0} is ", switchInfo.IdentifierName);
                Write(context.switchTypeAsHeadStatement().typeReference().GetText());
                Write(") {0}", context.ToComment());
            }
            else
            {
                Write("if (");
                MetaGeneratorParser.SwitchCaseOrTypeIsHeadStatementContext currentCase = null;
                for (int i = 0; i < context.switchCaseOrTypeIsHeadStatement().Length; i++)
                {
                    currentCase = context.switchCaseOrTypeIsHeadStatement()[i];
                    if (i == 0)
                    {
                        IncIndent();
                    }
                    else
                    {
                        WriteIndent();
                    }
                    Visit(currentCase);
                    if (i == context.switchCaseOrTypeIsHeadStatement().Length - 1)
                    {
                        Write(") {0}", currentCase.ToComment());
                        DecIndent();
                    }
                    else
                    {
                        Write(" || {0}", currentCase.ToComment());
                        AppendLine();
                    }
                }
            }
            AppendLine();
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitSwitchCaseHeadStatement([NotNull] MetaGeneratorParser.SwitchCaseHeadStatementContext context)
        {
            SwitchInfo switchInfo = null;
            if (this.switchStack.Count > 0)
            {
                switchInfo = this.switchStack[this.switchStack.Count - 1];
            }
            else
            {
                switchInfo = new SwitchInfo();
            }
            string delim = "";
            for (int i = 0; i < context.expressionList().expression().Length; i++)
            {
                Write("{0}{1} == ", delim, switchInfo.TmpName);
                Visit(context.expressionList().expression()[i]);
                delim = " || ";
            }
            return null;
        }

        public override object VisitSwitchTypeIsHeadStatement([NotNull] MetaGeneratorParser.SwitchTypeIsHeadStatementContext context)
        {
            SwitchInfo switchInfo = null;
            if (this.switchStack.Count > 0)
            {
                switchInfo = this.switchStack[this.switchStack.Count - 1];
            }
            else
            {
                switchInfo = new SwitchInfo();
            }
            Write("{0} is ", switchInfo.TmpName);
            string delim = "";
            for (int i = 0; i < context.typeReferenceList().typeReference().Length; i++)
            {
                Write("{0}{1} == ", delim, switchInfo.TmpName);
                Write(context.typeReferenceList().typeReference()[i].GetText());
                delim = " || ";
            }
            return null;
        }

        public override object VisitSwitchDefaultHeadStatement([NotNull] MetaGeneratorParser.SwitchDefaultHeadStatementContext context)
        {
            SwitchInfo switchInfo = null;
            if (this.switchStack.Count > 0)
            {
                switchInfo = this.switchStack[this.switchStack.Count - 1];
            }
            else
            {
                switchInfo = new SwitchInfo();
            }
            DecIndent();
            WriteLine("}");
            WriteLine("else {0}", context.ToComment());
            WriteLine("{");
            IncIndent();
            switchInfo.CaseCount = switchInfo.CaseCount + 1;
            switchInfo.TypeAsContext = null;
            return null;
        }
    }

}
