using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;

namespace MetaDslx.Languages.MetaGenerator.Generator
{
    internal class MetaGeneratorGenerator
    {
        private bool generated = false;
        private string generatedSource = null;
        public ParserRuleContext ParseTree { get; private set; }
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

        public MetaGeneratorGenerator(ParserRuleContext parseTree)
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
            cl.ExternFunctions = ul.ExternFunctions;
            cl.Visit(this.ParseTree);
            cl.Close();
            return sb.ToString();
        }
    }

    internal class ExternFunctionInfo
    {
        public string Name { get; set; }
        public MetaGeneratorParser.ExternFunctionDeclarationContext ExternFunction { get; set; }
    }

    internal class LoopInfo
    {
        public string Name { get; set; }
        public List<LoopItemInfo> Items { get; private set; }
        public MetaGeneratorParser.WhileStatementBeginContext While { get; set; }
        public MetaGeneratorParser.RepeatStatementEndContext Repeat { get; set; }
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
        public Dictionary<MetaGeneratorParser.ExternFunctionDeclarationContext, ExternFunctionInfo> ExternFunctions { get; set; }
        public Dictionary<MetaGeneratorParser.WhileStatementBeginContext, LoopInfo> Whiles { get; set; }
        public Dictionary<MetaGeneratorParser.RepeatStatementEndContext, LoopInfo> Repeats { get; set; }
        public Dictionary<MetaGeneratorParser.LoopStatementBeginContext, LoopInfo> Loops { get; set; }
        public Dictionary<MetaGeneratorParser.HasLoopExpressionContext, LoopInfo> HasLoops { get; set; }

        public MetaGenVisitor(StringBuilder sb)
        {
            this.sb = sb;
            this.indent = "";
            this.loopCounter = 0;
            this.ExternFunctions = new Dictionary<MetaGeneratorParser.ExternFunctionDeclarationContext, ExternFunctionInfo>();
            this.Whiles = new Dictionary<MetaGeneratorParser.WhileStatementBeginContext, LoopInfo>();
            this.Repeats = new Dictionary<MetaGeneratorParser.RepeatStatementEndContext, LoopInfo>();
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

        public override object VisitExternFunctionDeclaration([NotNull] MetaGeneratorParser.ExternFunctionDeclarationContext context)
        {
            this.ExternFunctions.Add(context, new ExternFunctionInfo() { Name = context.functionSignature().identifier().GetText(), ExternFunction = context });
            return base.VisitExternFunctionDeclaration(context);
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

        public override object VisitWhileStatementBegin([NotNull] MetaGeneratorParser.WhileStatementBeginContext context)
        {
            ++this.loopCounter;
            LoopInfo li = new LoopInfo();
            li.Name = "__loop" + this.loopCounter.ToString();
            li.While = context;
            this.Whiles.Add(context, li);
            return null;
        }

        public override object VisitRepeatStatementEnd([NotNull] MetaGeneratorParser.RepeatStatementEndContext context)
        {
            ++this.loopCounter;
            LoopInfo li = new LoopInfo();
            li.Name = "__loop" + this.loopCounter.ToString();
            li.Repeat = context;
            this.Repeats.Add(context, li);
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
        private bool processTemplateOutput = false;
        private List<SwitchInfo> switchStack = new List<SwitchInfo>();
        private HashSet<string> externFunctionNames = new HashSet<string>();

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

        private void GenerateExtensionsField(string generatorName)
        {
            if (this.ExternFunctions.Count > 0)
            {
                WriteLine("// If you see an error at this line, create a class called {0}Extensions", generatorName);
                WriteLine("// which implements the interface I{0}Extensions", generatorName);
                WriteLine("private I{0}Extensions extensionFunctions = new {0}Extensions();", generatorName);
            }
        }

        private void GenerateExtensionsInterface(string generatorName)
        {
            if (this.ExternFunctions.Count > 0)
            {
                AppendLine();
                WriteLine("internal interface I{0}Extensions", generatorName);
                WriteLine("{");
                IncIndent();
                var extensionFunctions = this.ExternFunctions.Values.OrderBy(v => v.ExternFunction.Start.TokenIndex);
                foreach (var extensionFunction in extensionFunctions)
                {
                    this.VisitFunctionSignatureExtension(extensionFunction.ExternFunction.functionSignature());
                }
                DecIndent();
                WriteLine("}");
                this.externFunctionNames.UnionWith(this.ExternFunctions.Values.Select(v => v.Name));
            }
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
            this.GenerateExtensionsInterface(name);
            AppendLine();
            string baseType = string.Empty;
            if (context.qualifiedName() != null)
            {
                this.processTemplateOutput = true;
                baseType = " : " + context.qualifiedName().GetText();
            }
            WriteLine("public class {0}{1} {2}", name, baseType, context.ToComment());
            WriteLine("{");
            this.IncIndent();
            this.GenerateExtensionsField(name);
            if (context.typeReference() != null)
            {
                string instancesType = context.typeReference().GetText();
                WriteLine("private {0} Instances; {1}", instancesType, context.ToComment());
                AppendLine();
            }
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
            if (context.typeReference() != null)
            {
                string instancesType = context.typeReference().GetText();
                WriteLine("public {0}({1} instances) : this() {2}", name, instancesType, context.ToComment());
                WriteLine("{");
                IncIndent();
                WriteLine("this.Instances = instances;");
                DecIndent();
                WriteLine("}");
                AppendLine();
            }
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
            WriteLine("private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)");
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
            if (this.processTemplateOutput)
            {
                WriteLine("protected override string ProcessTemplateOutput(object output) {0}", context.ToComment());
                WriteLine("{");
                IncIndent();
                WriteLine("return base.ProcessTemplateOutput(output);");
                DecIndent();
                WriteLine("}");
                AppendLine();
            }
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

        public override object VisitExternFunctionDeclaration([NotNull] MetaGeneratorParser.ExternFunctionDeclarationContext context)
        {
            VisitExternFunctionSignature(context.functionSignature());
            WriteLine("{");
            IncIndent();
            tmpCounter = 0;
            VisitExternFunctionCall(context.functionSignature());
            DecIndent();
            WriteLine("}");
            AppendLine();
            return null;
        }

        public object VisitExternFunctionSignature(MetaGeneratorParser.FunctionSignatureContext context)
        {
            WriteIndent();
            Write("internal {0} {1}", context.returnType().GetText(), context.identifier().GetText());
            if (context.typeArgumentList() != null)
            {
                Visit(context.typeArgumentList());
            }
            Write("(");
            if (context.paramList() != null)
            {
                Visit(context.paramList());
            }
            Write(") {0}", context.ToComment());
            AppendLine();
            return null;
        }

        public object VisitExternFunctionCall(MetaGeneratorParser.FunctionSignatureContext context)
        {
            WriteIndent();
            if (context.returnType().GetText() != "void") Write("return ");
            Write("this.extensionFunctions.{0}", context.identifier().GetText());
            if (context.typeArgumentList() != null)
            {
                Visit(context.typeArgumentList());
            }
            Write("(");
            if (context.paramList() != null)
            {
                VisitParamListCall(context.paramList());
            }
            Write("); {0}", context.ToComment());
            AppendLine();
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
            Write("public {0} {1}", context.returnType().GetText(), context.identifier().GetText());
            if (context.typeArgumentList() != null)
            {
                Visit(context.typeArgumentList());
            }
            Write("(");
            if (context.paramList() != null)
            {
                Visit(context.paramList());
            }
            Write(") {0}", context.ToComment());
            AppendLine();
            return null;
        }

        public object VisitFunctionSignatureExtension(MetaGeneratorParser.FunctionSignatureContext context)
        {
            WriteIndent();
            Write("{0} {1}", context.returnType().GetText(), context.identifier().GetText());
            if (context.typeArgumentList() != null)
            {
                Visit(context.typeArgumentList());
            }
            Write("(");
            if (context.paramList() != null)
            {
                Visit(context.paramList());
            }
            Write("); {0}", context.ToComment());
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

        public object VisitParamListCall(MetaGeneratorParser.ParamListContext context)
        {
            string comma = "";
            foreach (var param in context.parameter())
            {
                Write(comma);
                Write(param.identifier().GetText());
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
            Visit(context.variableDeclarationExpression());
            Write("; ");
            Write(context.ToComment());
            AppendLine();
            return null;
        }

        public override object VisitVariableDeclarationExpression([NotNull] MetaGeneratorParser.VariableDeclarationExpressionContext context)
        {
            Write(context.typeReference().GetText());
            Write(" ");
            var items = context.variableDeclarationItem();
            for (int i = 0; i < items.Length; ++i)
            {
                if (i > 0) Write(", ");
                Visit(items[i]);
            }
            return null;
        }

        public override object VisitVariableDeclarationItem([NotNull] MetaGeneratorParser.VariableDeclarationItemContext context)
        {
            Write(context.identifier().GetText());
            if (context.expression() != null)
            {
                Write(" = ");
                Visit(context.expression());
            }
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

        public override object VisitVoidStatement(MetaGeneratorParser.VoidStatementContext context)
        {
            WriteIndent();
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
            foreach (var expr in context.expression())
            {
                Write(comma);
                Visit(expr);
                comma = ", ";
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
            if (this.externFunctionNames.Count > 0)
            {
                if (context.expression() is MetaGeneratorParser.MemberAccessExpressionContext)
                {
                    MetaGeneratorParser.MemberAccessExpressionContext mac = (MetaGeneratorParser.MemberAccessExpressionContext)context.expression();
                    string name = mac.identifier().GetText();
                    if (this.externFunctionNames.Contains(name))
                    {
                        Write(name);
                        if (mac.typeArgumentList() != null)
                        {
                            Visit(mac.typeArgumentList());
                        }
                        Write("(");
                        Visit(mac.expression());
                        if (context.expressionList() != null)
                        {
                            Write(", ");
                            Visit(context.expressionList());
                        }
                        Write(")");
                        return null;
                    }
                }
            }
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
            foreach (var param in context.implicitParameter())
            {
                Write(comma);
                Visit(param);
                comma = ", ";
            }
            Write(")");
            return null;
        }

        public override object VisitExplicitAnonymousFunctionSignature(MetaGeneratorParser.ExplicitAnonymousFunctionSignatureContext context)
        {
            Write("(");
            string comma = "";
            foreach (var param in context.explicitParameter())
            {
                Write(comma);
                Visit(param);
                comma = ", ";
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
            int lastIndex = context.templateContent().Length - 1;
            int outputCount = 0;
            int nonWhitespaceOutputCount = 0;
            int outputExpressionCount = 0;
            int statementCount = 0;
            for (int i = 0; i <= lastIndex; ++i)
            {
                var child = context.templateContent()[i];
                if (child.templateOutput() != null)
                {
                    ++outputCount;
                    MetaGeneratorParser.TemplateOutputContext toc = child.templateOutput();
                    if (!string.IsNullOrWhiteSpace(toc.GetText()))
                    {
                        ++nonWhitespaceOutputCount;
                    }
                }
                if (child.templateStatementStartEnd() != null)
                {
                    MetaGeneratorParser.TemplateStatementStartEndContext tse = child.templateStatementStartEnd();
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
                        var child = context.templateContent()[i];
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
                    var child = context.templateContent()[i];
                    if (child.templateStatementStartEnd() != null)
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
                string outputWrittenTmp = NewTmp()+ "_outputWritten";
                if (!forceNewLine && !noNewLine)
                {
                    WriteLine("bool {0} = false;", outputWrittenTmp);
                }
                if (lastIndex >= 1)
                {
                    MetaGeneratorParser.TemplateOutputContext output;
                    output = context.templateContent()[0].templateOutput();
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
                    var child = context.templateContent()[i];
                    string tmp = NewTmp();
                    bool hasOutput = false;
                    bool closeBraces = false;
                    if (child.templateOutput() != null)
                    {
                        MetaGeneratorParser.TemplateOutputContext output = child.templateOutput();
                        WriteLine("string {0}_line = \"{1}\"; {2}", tmp, EscapeText(output.GetText()), output.ToComment());
                        hasOutput = true;
                    }
                    else if (child.templateStatementStartEnd() != null)
                    {
                        MetaGeneratorParser.TemplateStatementStartEndContext statement = child.templateStatementStartEnd();
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
                                WriteLine("bool {0}_last = {0}Reader.EndOfStream;", tmp);
                                WriteLine("while(!{0}_last)", tmp);
                                WriteLine("{");
                                IncIndent();
                                WriteLine("string {0}_line = {0}Reader.ReadLine();", tmp);
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
                        WriteLine("if (!string.IsNullOrEmpty({0}))", prefix);
                        WriteLine("{");
                        IncIndent();
                        WriteLine("__out.Append({0});", prefix);
                        if (!forceNewLine && !noNewLine)
                        {
                            WriteLine("{0} = true;", outputWrittenTmp);
                        }
                        DecIndent();
                        WriteLine("}");
                    }
                    if (hasOutput)
                    {
                        if (closeBraces)
                        {
                            WriteLine("if (({0}_last && !string.IsNullOrEmpty({0}_line)) || (!{0}_last && {0}_line != null))", tmp);
                        }
                        else
                        {
                            WriteLine("if (!string.IsNullOrEmpty({0}_line))", tmp);
                        }
                        WriteLine("{");
                        IncIndent();
                        WriteLine("__out.Append({0}_line);", tmp);
                        if (!forceNewLine && !noNewLine)
                        {
                            WriteLine("{0} = true;", outputWrittenTmp);
                        }
                        DecIndent();
                        WriteLine("}");
                    }
                    if (i == endIndex)
                    {
                        if (forceNewLine)
                        {
                            VisitTemplateLineEnd(context.templateLineEnd());
                        }
                        else if (!noNewLine)
                        {
                            if (closeBraces)
                            {
                                WriteLine("if (!{0}_last || {1}) __out.AppendLine(true);", tmp, outputWrittenTmp);
                            }
                            else
                            {
                                WriteLine("if ({0}) __out.AppendLine(true);", outputWrittenTmp);
                            }
                        }
                    }
                    else
                    {
                        if (hasOutput)
                        {
                            if (closeBraces)
                            {
                                WriteLine("if (!{0}_last) __out.AppendLine(true);", tmp);
                            }
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
                    if (i == endIndex)
                    {
                        if (forceNewLine)
                        {
                            VisitTemplateLineEnd(context.templateLineEnd());
                        }
                        else if (!noNewLine)
                        {
                            WriteLine("if ({0})", outputWrittenTmp);
                            WriteLine("{");
                            IncIndent();
                            VisitTemplateLineEnd(context.templateLineEnd());
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
            if (this.processTemplateOutput)
            {
                WriteLine("{0}.Append(this.ProcessTemplateOutput(\"{1}\")); {2}", output, EscapeText(context.TemplateOutput().GetText()), context.ToComment());
            }
            else
            {
                WriteLine("{0}.Append(\"{1}\"); {2}", output, EscapeText(context.TemplateOutput().GetText()), context.ToComment());
            }
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
                    if (this.processTemplateOutput)
                    {
                        Write("{0}.Append(this.ProcessTemplateOutput(", output);
                    }
                    else
                    {
                        Write("{0}.Append(", output);
                    }
                    Visit(expression);
                    if (this.processTemplateOutput)
                    {
                        Write("));");
                    }
                    else
                    {
                        Write(");");
                    }
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

        public override object VisitForStatementBegin([NotNull] MetaGeneratorParser.ForStatementBeginContext context)
        {
            WriteIndent();
            Write("for (");
            if (context.forInitStatement() != null)
            {
                Visit(context.forInitStatement());
            }
            Write("; ");
            if (context.endExpression != null)
            {
                Visit(context.endExpression);
            }
            Write("; ");
            if (context.stepExpression != null)
            {
                Visit(context.stepExpression);
            }
            Write(") " + context.ToComment());
            AppendLine();
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitForStatementEnd([NotNull] MetaGeneratorParser.ForStatementEndContext context)
        {
            DecIndent();
            WriteLine("} " + context.ToComment());
            return null;
        }

        public override object VisitWhileStatementBegin([NotNull] MetaGeneratorParser.WhileStatementBeginContext context)
        {
            WriteIndent();
            Write("while (");
            Visit(context.expression());
            Write(") " + context.ToComment());
            AppendLine();
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitWhileStatementEnd([NotNull] MetaGeneratorParser.WhileStatementEndContext context)
        {
            DecIndent();
            WriteLine("} " + context.ToComment());
            return null;
        }

        public override object VisitRepeatStatementBegin([NotNull] MetaGeneratorParser.RepeatStatementBeginContext context)
        {
            WriteLine("do " + context.ToComment());
            WriteLine("{");
            IncIndent();
            return null;
        }

        public override object VisitRepeatStatementEnd([NotNull] MetaGeneratorParser.RepeatStatementEndContext context)
        {
            DecIndent();
            WriteLine("}");
            WriteIndent();
            Write("while (!(");
            Visit(context.expression());
            Write(")); " + context.ToComment());
            AppendLine();
            return null;
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
            WriteLine("for (int {0}_iteration = 0; {0}_iteration < {0}_results.Count; ++{0}_iteration)", li.Name);
            WriteLine("{");
            IncIndent();
            if (context.loopRunExpression() != null && context.loopRunExpression().separatorStatement() != null)
            {
                var separatorStatement = context.loopRunExpression().separatorStatement();
                string separatorVariable = separatorStatement.identifier().GetText();
                WriteLine("string {0}; {1}", separatorVariable, separatorStatement.ToComment());
                WriteIndent();
                Write("if ({0}_iteration+1 < {0}_results.Count) {1} = ", li.Name, separatorVariable);
                Write(separatorStatement.stringLiteral().GetText());
                Write(";");
                AppendLine();
                WriteLine("else {0} = string.Empty;", separatorVariable);
            }
            WriteLine("var {1} = {0}_results[{0}_iteration];", li.Name, tmp1);
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
