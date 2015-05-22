using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Reserved annotations:
 *  @DynamicAnnotations on grammar
 *  @Map
 */

namespace MetaDslx.Compiler
{
    public class Antlr4SyntaxKind
    {
        public const int Action = 7;
        public const int Options = 8;
        public const int Tokens = 9;
    }

    public class AnnotatedAntlr4Compiler : MetaCompiler
    {
        public string CSharpNamespace { get; set; }

        public AnnotatedAntlr4Parser.GrammarSpecContext ParseTree { get; private set; }
        public AnnotatedAntlr4Lexer Lexer { get; private set; }
        public AnnotatedAntlr4Parser Parser { get; private set; }
        public CommonTokenStream CommonTokenStream { get; private set; }
        public string Antlr4Source { get; private set; }
        public string GeneratedSource { get; private set; }

        public List<object> LexerAnnotations { get; private set; }
        public Dictionary<int, List<object>> ModeAnnotations { get; private set; }
        public Dictionary<int, List<object>> TokenAnnotations { get; private set; }

        public AnnotatedAntlr4Compiler(string source, string fileName = null)
            : base(source, fileName)
        {

        }

        public override void Compile()
        {
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new AnnotatedAntlr4Lexer(inputStream);
            this.Lexer.AddErrorListener(this);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new AnnotatedAntlr4Parser(this.CommonTokenStream);
            this.Parser.AddErrorListener(this);
            this.ParseTree = this.Parser.grammarSpec();
            Antlr4AnnotationVisitor av = new Antlr4AnnotationVisitor(this);
            av.Visit(this.ParseTree);
            this.GeneratedSource = av.Generate(this.CSharpNamespace);
            Antlr4AnnotationRemover remover = new Antlr4AnnotationRemover(this.CommonTokenStream);
            remover.Visit(this.ParseTree);
            this.Antlr4Source = remover.GetText();
            AnnotatedAntlr4LexerAnnotator annotator = new AnnotatedAntlr4LexerAnnotator();
            this.LexerAnnotations = annotator.LexerAnnotations;
            this.ModeAnnotations = annotator.ModeAnnotations;
            this.TokenAnnotations = annotator.TokenAnnotations;
        }
    }

    public class Antlr4AnnotationRemover : AnnotatedAntlr4ParserBaseVisitor<object>
    {
        private TokenStreamRewriter rewriter;

        private List<TextSpan> removedText = new List<TextSpan>();

        public Antlr4AnnotationRemover(ITokenStream tokens)
        {
            rewriter = new TokenStreamRewriter(tokens);
        }

        public string GetText()
        {
            return this.rewriter.GetText();
        }

        public override object VisitAnnotation(AnnotatedAntlr4Parser.AnnotationContext context)
        {
            removedText.Add(new TextSpan(context));
            rewriter.Delete(context.Start, context.Stop);
            return null;
            //return base.VisitAnnotation(context);
        }
    }

    public class Antlr4AnnotationVisitor : AnnotatedAntlr4ParserBaseVisitor<object>
    {
        private AnnotatedAntlr4Compiler compiler;

        private StringBuilder sb;
        private string indent;
        private int tmpCounter;

        private string parserName;
        private string lexerName;
        private bool isParser;
        private bool isLexer;

        private List<AnnotationType> annotationTypes = new List<AnnotationType>();
        private List<string> dynamicAnnotations = new List<string>();
        private Grammar currentGrammar;
        private Mode currentMode;
        private LexerRule currentLexerRule;
        private ParserRule currentParserRule;
        private ParserRule currentParserRuleAlt;
        private ParserRuleElement currentElement;

        public Antlr4AnnotationVisitor(AnnotatedAntlr4Compiler compiler)
        {
            this.compiler = compiler;
        }

        protected string GetTmpVariable()
        {
            ++this.tmpCounter;
            return "__tmp" + this.tmpCounter;
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
            sb.Append(indent);
            sb.AppendLine(text);
        }

        protected void WriteLine(string format, params object[] args)
        {
            sb.Append(indent);
            sb.AppendLine(string.Format(format, args));
        }

        public override object VisitGrammarSpec(AnnotatedAntlr4Parser.GrammarSpecContext context)
        {
            if (context.grammarType().PARSER() != null)
            {
                this.parserName = context.id().GetText();
                this.lexerName = this.parserName;
                isLexer = false;
                isParser = true;
            }
            else if (context.grammarType().LEXER() != null)
            {
                this.lexerName = context.id().GetText();
                isLexer = true;
                isParser = false;
            }
            else
            {
                this.parserName = context.id().GetText();
                this.lexerName = this.parserName;
                isLexer = true;
                isParser = true;
            }
            currentGrammar = new Grammar();
            currentGrammar.Name = context.id().GetText();
            currentMode = new Mode();
            currentMode.Name = "DEFAULT_MODE";
            currentGrammar.Modes.Add(currentMode);
            this.CollectAnnotations(context.annotation());

            this.dynamicAnnotations.Add("Map");
            foreach (var annot in currentGrammar.Annotations)
            {
                if (annot.Type.Name == "DynamicAnnotations")
                {
                    // TODO
                }
            }

            return base.VisitGrammarSpec(context);
        }

        public override object VisitOption(AnnotatedAntlr4Parser.OptionContext context)
        {
            if (context.id().GetText() == "tokenVocab")
            {
                this.lexerName = context.optionValue().GetText();
            }
            return base.VisitOption(context);
        }

        public override object VisitModeSpec(AnnotatedAntlr4Parser.ModeSpecContext context)
        {
            currentMode = new Mode();
            currentMode.Name = context.id().GetText();
            currentGrammar.Modes.Add(currentMode);
            this.CollectAnnotations(context.annotation());
            return base.VisitModeSpec(context);
        }

        public override object VisitLexerRule(AnnotatedAntlr4Parser.LexerRuleContext context)
        {
            if (context.FRAGMENT() == null)
            {
                this.currentLexerRule = new LexerRule();
                this.currentLexerRule.Name = context.TOKEN_REF().GetText();
                base.VisitLexerRule(context);
                if (this.currentLexerRule != null)
                {
                    this.currentGrammar.LexerRules.Add(this.currentLexerRule);
                    this.currentMode.LexerRules.Add(this.currentLexerRule);
                    this.CollectAnnotations(context.annotation());
                    this.currentLexerRule = null;
                }
            }
            return null;
        }

        public override object VisitLexerCommand(AnnotatedAntlr4Parser.LexerCommandContext context)
        {
            if (context.lexerCommandName().GetText() == "more")
            {
                this.currentLexerRule = null;
            }
            return null;
        }

        public override object VisitParserRuleSpec(AnnotatedAntlr4Parser.ParserRuleSpecContext context)
        {
            this.currentParserRule = new ParserRule();
            this.currentParserRule.Name = context.RULE_REF().GetText();
            base.VisitParserRuleSpec(context);
            if (this.currentParserRule != null)
            {
                this.currentGrammar.ParserRules.Add(this.currentParserRule);
                this.CollectAnnotations(context.annotation());
                this.currentParserRule = null;
            }
            return null;
        }

        public override object VisitLabeledAlt(AnnotatedAntlr4Parser.LabeledAltContext context)
        {
            if (context.id() != null)
            {
                this.currentParserRuleAlt = new ParserRule();
                this.currentParserRuleAlt.Name = context.id().GetText();
                this.currentParserRule.Alternatives.Add(this.currentParserRuleAlt);
                this.CollectAnnotations(context.annotation());
            }
            base.VisitLabeledAlt(context);
            this.currentParserRuleAlt = null;
            return null;
        }

        public override object VisitAtom(AnnotatedAntlr4Parser.AtomContext context)
        {
            String name = null;
            if (context.terminal() != null)
            {
                if (context.terminal().TOKEN_REF() != null)
                {
                    name = context.terminal().TOKEN_REF().GetText();
                }
                /*if (context.terminal().STRING_LITERAL() != null)
                {
                    name = context.terminal().STRING_LITERAL().GetText();
                }*/
            }
            if (context.ruleref() != null)
            {
                name = context.ruleref().RULE_REF().GetText();
            }
            if (name != null)
            {
                AnnotatedAntlr4Parser.ElementContext element = context.Parent as AnnotatedAntlr4Parser.ElementContext;
                if (element != null)
                {
                    this.currentElement = new ParserRuleElement();
                    this.currentElement.Name = name;
                    this.currentElement.Type = name;
                }
                else
                {
                    AnnotatedAntlr4Parser.LabeledElementContext labeledElement = context.Parent as AnnotatedAntlr4Parser.LabeledElementContext;
                    if (labeledElement != null)
                    {
                        this.currentElement = new ParserRuleElement();
                        this.currentElement.Name = labeledElement.id().GetText();
                        this.currentElement.Type = labeledElement.atom().GetText();
                        element = labeledElement.Parent as AnnotatedAntlr4Parser.ElementContext;
                    }
                }
                if (this.currentElement != null)
                {
                    if (this.currentParserRuleAlt != null)
                    {
                        ParserRuleElement oldElement = this.currentParserRuleAlt.Elements.FirstOrDefault(e => e.Name == currentElement.Name);
                        if (oldElement != null)
                        {
                            this.currentElement = oldElement;
                        }
                        else
                        {
                            this.currentParserRuleAlt.Elements.Add(this.currentElement);
                        }
                    }
                    else if (this.currentParserRule != null)
                    {
                        ParserRuleElement oldElement = this.currentParserRule.Elements.FirstOrDefault(e => e.Name == currentElement.Name);
                        if (oldElement != null)
                        {
                            this.currentElement = oldElement;
                        }
                        else
                        {
                            this.currentParserRule.Elements.Add(this.currentElement);
                        }
                    }
                    if (element != null)
                    {
                        AnnotatedAntlr4Parser.AnnotatedElementContext annotatedElement = element.Parent as AnnotatedAntlr4Parser.AnnotatedElementContext;
                        if (annotatedElement != null)
                        {
                            this.CollectAnnotations(annotatedElement.annotation());
                        }
                    }
                }
            }
            base.VisitAtom(context);
            this.currentElement = null;
            return null;
        }

        private void CollectAnnotations(IEnumerable<AnnotatedAntlr4Parser.AnnotationContext> annotations)
        {
            foreach (var annot in annotations)
            {
                string name = annot.qualifiedName().GetText();
                AnnotationType annotationType = this.annotationTypes.FirstOrDefault(at => at.Name == name);
                if (annotationType == null)
                {
                    annotationType = new AnnotationType();
                    annotationType.Name = name;
                    this.annotationTypes.Add(annotationType);
                }
                if (this.dynamicAnnotations.Contains(name))
                {
                    annotationType.IsDynamic = true;
                }
                Annotation annotation = new Annotation();
                annotation.Type = annotationType;
                if (this.currentElement != null)
                {
                    this.currentElement.Annotations.Add(annotation);
                }
                else if (this.currentParserRuleAlt != null)
                {
                    this.currentParserRuleAlt.Annotations.Add(annotation);
                }
                else if (this.currentParserRule != null)
                {
                    this.currentParserRule.Annotations.Add(annotation);
                }
                else if (this.currentLexerRule != null)
                {
                    this.currentLexerRule.Annotations.Add(annotation);
                }
                else if (this.currentMode != null)
                {
                    this.currentMode.Annotations.Add(annotation);
                }
                else if (this.currentGrammar != null)
                {
                    this.currentGrammar.Annotations.Add(annotation);
                }
                else
                {
                    this.compiler.Diagnostics.AddWarning("No parent for annotation: " + annotation.Type.Name, null, new TextSpan(annot));
                }
                if (annot.annotationBody() != null && annot.annotationBody().annotationAttributeList() != null)
                {
                    foreach (var attr in annot.annotationBody().annotationAttributeList().annotationAttribute())
                    {
                        AnnotationProperty property = new AnnotationProperty();
                        property.Name = attr.identifier().GetText();
                        if (attr.annotationValue() != null)
                        {
                            string value = attr.annotationValue().GetText();
                            property.Value = value;
                        }
                        annotation.Properties.Add(property);
                        if (!annotationType.Properties.Contains(property.Name))
                        {
                            annotationType.Properties.Add(property.Name);
                        }
                    }
                }
            }
        }

        public string Generate(string targetNamespace)
        {
            this.sb = new StringBuilder();
            this.indent = "";

            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            WriteLine("using System.Linq;");
            WriteLine("using System.Text;");
            WriteLine("using System.Threading.Tasks;");
            WriteLine("using Antlr4.Runtime;");
            WriteLine("using Antlr4.Runtime.Tree;");
            WriteLine("");
            if (!string.IsNullOrWhiteSpace(targetNamespace))
            {
                WriteLine("namespace {0}", targetNamespace);
                WriteLine("{");
                IncIndent();
            }
            this.GenerateAnnotatorVisitor();
            if (!string.IsNullOrWhiteSpace(targetNamespace))
            {
                DecIndent();
                WriteLine("}");
            }
            return this.sb.ToString();
        }

        private string ToAnnotationName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return name;
            if (!name.EndsWith("Annotation")) return name + "Annotation";
            else return name;
        }

        private string ToPascalCase(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return name[0].ToString().ToUpper() + name.Substring(1);
        }

        private string ToCamelCase(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return name[0].ToString().ToLower() + name.Substring(1);
        }

        private string ToContextType(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName)) return ruleName;
            return this.parserName + "." + ToPascalCase(ruleName) + "Context";
        }

        private string ToValue(string value, bool dynamic)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            if (value.Length >= 2 && value.StartsWith("'") && value.EndsWith("'"))
            {
                StringBuilder sb = new StringBuilder();
                value = value.Substring(1, value.Length - 2);
                for (int i = 0; i < value.Length; ++i)
                {
                    if (i+1 < value.Length && value[i] == '\\')
                    {
                        sb.Append(value[i]);
                        ++i;
                        sb.Append(value[i]);
                    }
                    else if (value[i] == '"')
                    {
                        sb.Append("\\"+value[i]);
                    }
                    else
                    {
                        sb.Append(value[i]);
                    }
                }
                value = '"' + sb.ToString() + '"';
                return value;
            }
            else if (value == "true" || value == "false")
            {
                return value;
            }
            else
            {
                bool isIdentifier = char.IsLetter(value[0]) || value[0] == '_';
                int dotCount = 0;
                int i = 1;
                while (isIdentifier && i < value.Length)
                {
                    isIdentifier = isIdentifier && (char.IsLetterOrDigit(value[i]) || value[i] == '_' || value[i] == '.');
                    if (value[i] == '.') ++dotCount;
                    ++i;
                }
                if (isIdentifier)
                {
                    if (dotCount == 0)
                    {
                        if (char.IsUpper(value[0]))
                        {
                            if (dynamic)
                            {
                                value = string.Format("node", ToContextType(value));
                            }
                            else
                            {
                                value = string.Format("{0}.{1}", this.lexerName, value);
                            }
                        }
                        else
                        {
                            if (dynamic)
                            {
                                value = string.Format("context", ToContextType(value));
                            }
                            else
                            {
                                value = string.Format("typeof({0})", ToContextType(value));
                            }
                        }
                    }
                    else if (dotCount == 1 && char.IsLower(value[0]))
                    {
                        if (this.parserName != null)
                        {
                            string[] values = value.Split('.');
                            ParserRule pr = null;
                            ParserRuleElement pre = null;
                            foreach (var rule in this.currentGrammar.ParserRules)
                            {
                                if (rule.Name == values[0])
                                {
                                    pr = rule;
                                    break;
                                }
                                foreach (var alt in rule.Alternatives)
                                {
                                    if (alt.Name == values[0])
                                    {
                                        pr = alt;
                                        break;
                                    }
                                }
                                if (pr != null) break;
                            }
                            if (pr != null)
                            {
                                foreach (var elem in pr.Elements)
                                {
                                    if (elem.Name == values[1])
                                    {
                                        pre = elem;
                                        break;
                                    }
                                }
                                if (pre != null)
                                {
                                    if (dynamic)
                                    {
                                        value = string.Format("context.{0}", pre.GetAccessorName());
                                    }
                                    else
                                    {
                                        value = string.Format("typeof({0})", ToContextType(pre.Type));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return value;
        }

        private void GenerateAnnotatorVisitor()
        {
            if (this.isParser)
            {
                WriteLine("internal class {0}Annotator : {0}BaseVisitor<object>", this.parserName);
            }
            else
            {
                WriteLine("internal class {0}Annotator", this.lexerName);
            }
            WriteLine("{");
            IncIndent();
            if (this.isParser && !this.isLexer)
            {
                WriteLine("private {0}Annotator lexerAnnotator = new {0}Annotator();", this.lexerName);
            }
            WriteLine("private List<object> grammarAnnotations = new List<object>();");
            if (this.isLexer)
            {
                WriteLine("private Dictionary<int, List<object>> tokenAnnotations = new Dictionary<int, List<object>>();");
                WriteLine("private Dictionary<int, List<object>> modeAnnotations = new Dictionary<int, List<object>>();");
            }
            if (this.isParser)
            {
                WriteLine("private Dictionary<Type, List<object>> ruleAnnotations = new Dictionary<Type, List<object>>();");
                WriteLine("private Dictionary<object, List<object>> treeAnnotations = new Dictionary<object, List<object>>();");
            }

            WriteLine();
            if (this.isParser)
            {
                WriteLine("public List<object> ParserAnnotations { get { return this.grammarAnnotations; } }");
                if (this.isLexer)
                {
                    WriteLine("public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }");
                    WriteLine("public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }");
                    WriteLine("public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }");
                }
                else
                {
                    WriteLine("public List<object> LexerAnnotations { get { return this.lexerAnnotator.LexerAnnotations; } }");
                    WriteLine("public Dictionary<int, List<object>> TokenAnnotations { get { return this.lexerAnnotator.TokenAnnotations; } }");
                    WriteLine("public Dictionary<int, List<object>> ModeAnnotations { get { return this.lexerAnnotator.ModeAnnotations; } }");
                }
                WriteLine("public Dictionary<Type, List<object>> RuleAnnotations { get { return this.ruleAnnotations; } }");
                WriteLine("public Dictionary<object, List<object>> TreeAnnotations { get { return this.treeAnnotations; } }");
            }
            else
            {
                WriteLine("public List<object> LexerAnnotations { get { return this.grammarAnnotations; } }");
                WriteLine("public Dictionary<int, List<object>> TokenAnnotations { get { return this.tokenAnnotations; } }");
                WriteLine("public Dictionary<int, List<object>> ModeAnnotations { get { return this.modeAnnotations; } }");
            }
            
            WriteLine();
            foreach (var rule in currentGrammar.ParserRules)
            {
                foreach (var annot in rule.Annotations)
                {
                    if (!annot.Type.IsDynamic)
                    {
                        WriteLine("private {2} {0}_{1};", ToCamelCase(rule.Name), annot.Type.Name, ToAnnotationName(annot.Type.Name));
                    }
                }
                foreach (var elem in rule.Elements)
                {
                    foreach (var annot in elem.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            WriteLine("private {3} {0}_{1}_{2};", ToCamelCase(rule.Name), ToPascalCase(elem.Name), annot.Type.Name, ToAnnotationName(annot.Type.Name));
                        }
                    }
                }
                foreach (var alt in rule.Alternatives)
                {
                    foreach (var annot in rule.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            WriteLine("private {2} {0}_{1};", ToCamelCase(alt.Name), annot.Type.Name, ToAnnotationName(annot.Type.Name));
                        }
                    }
                    foreach (var elem in alt.Elements)
                    {
                        foreach (var annot in elem.Annotations)
                        {
                            if (!annot.Type.IsDynamic)
                            {
                                WriteLine("private {3} {0}_{1}_{2};", ToCamelCase(alt.Name), ToPascalCase(elem.Name), annot.Type.Name, ToAnnotationName(annot.Type.Name));
                            }
                        }
                    }
                }
            }
            WriteLine();
            if (this.isParser)
            {
                WriteLine("public {0}Annotator()", this.parserName);
            }
            else
            {
                WriteLine("public {0}Annotator()", this.lexerName);
            }
            WriteLine("{");
            IncIndent();
            WriteLine("List<object> annotList = null;");
            foreach (var annot in currentGrammar.Annotations)
            {
                string tmp = this.GetTmpVariable();
                this.GenerateAnnotationCreation(annot, tmp, true);
                WriteLine("this.grammarAnnotations.Add({0});", tmp);
            }
            if (this.isLexer)
            {
                foreach (var mode in currentGrammar.Modes)
                {
                    if (mode.Annotations.Count > 0)
                    {
                        WriteLine();
                        WriteLine("annotList = new List<object>();");
                        WriteLine("this.modeAnnotations.Add({0}.{1}, annotList);", this.lexerName, mode.Name);
                    }
                    foreach (var annot in mode.Annotations)
                    {
                        string tmp = this.GetTmpVariable();
                        this.GenerateAnnotationCreation(annot, tmp, true);
                        WriteLine("annotList.Add({0});", tmp);
                    }
                }
                foreach (var token in currentGrammar.LexerRules)
                {
                    if (token.Annotations.Count(a => !a.Type.IsDynamic) > 0)
                    {
                        WriteLine();
                        WriteLine("annotList = new List<object>();");
                        WriteLine("this.tokenAnnotations.Add({0}.{1}, annotList);", this.lexerName, token.Name);
                    }
                    foreach (var annot in token.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            string tmp = this.GetTmpVariable();
                            this.GenerateAnnotationCreation(annot, tmp, true);
                            WriteLine("annotList.Add({0});", tmp);
                        }
                    }
                }
            }
            foreach (var rule in currentGrammar.ParserRules)
            {
                if (rule.Annotations.Count(a => !a.Type.IsDynamic) > 0 || rule.Elements.Count(e => e.Annotations.Count(a => !a.Type.IsDynamic) > 0) > 0)
                {
                    WriteLine();
                }
                if (rule.Annotations.Count(a => !a.Type.IsDynamic) > 0)
                {
                    WriteLine("annotList = new List<object>();");
                    WriteLine("this.ruleAnnotations.Add(typeof({0}), annotList);", ToContextType(rule.Name));
                }
                foreach (var annot in rule.Annotations)
                {
                    if (!annot.Type.IsDynamic)
                    {
                        string tmp = string.Format("this.{0}_{1}", ToCamelCase(rule.Name), annot.Type.Name);
                        this.GenerateAnnotationCreation(annot, tmp, false);
                        WriteLine("annotList.Add({0});", tmp);
                    }
                }
                foreach (var elem in rule.Elements)
                {
                    foreach (var annot in elem.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            string tmp = string.Format("this.{0}_{1}_{2}", ToCamelCase(rule.Name), ToPascalCase(elem.Name), annot.Type.Name);
                            this.GenerateAnnotationCreation(annot, tmp, false);
                        }
                    }
                }
                foreach (var alt in rule.Alternatives)
                {
                    if (rule.Annotations.Count(a => !a.Type.IsDynamic) > 0 || alt.Annotations.Count(a => !a.Type.IsDynamic) > 0 || alt.Elements.Count(e => e.Annotations.Count(a => !a.Type.IsDynamic) > 0) > 0)
                    {
                        WriteLine();
                    }
                    if (rule.Annotations.Count(a => !a.Type.IsDynamic) > 0 || alt.Annotations.Count(a => !a.Type.IsDynamic) > 0)
                    {
                        WriteLine("annotList = new List<object>();");
                        WriteLine("this.ruleAnnotations.Add(typeof({0}), annotList);", ToContextType(alt.Name));
                    }
                    foreach (var annot in rule.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            WriteLine("annotList.Add(this.{0}_{1});", ToCamelCase(rule.Name), annot.Type.Name);
                        }
                    }
                    foreach (var annot in rule.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            string tmp = string.Format("this.{0}_{1}", ToCamelCase(alt.Name), annot.Type.Name);
                            this.GenerateAnnotationCreation(annot, tmp, false);
                            WriteLine("annotList.Add({0});", tmp);
                        }
                    }
                    foreach (var elem in alt.Elements)
                    {
                        foreach (var annot in elem.Annotations)
                        {
                            if (!annot.Type.IsDynamic)
                            {
                                string tmp = string.Format("this.{0}_{1}_{2}", ToCamelCase(alt.Name), ToPascalCase(elem.Name), annot.Type.Name);
                                this.GenerateAnnotationCreation(annot, tmp, false);
                            }
                        }
                    }
                }
            }
            DecIndent();
            WriteLine("}");
            WriteLine();
            if (isParser)
            {
                WriteLine("public override object VisitTerminal(ITerminalNode node)");
            }
            else
            {
                WriteLine("public object VisitTerminal(ITerminalNode node, Dictionary<object, List<object>> treeAnnotations)");
            }
            WriteLine("{");
            IncIndent();
            if (this.isLexer)
            {
                WriteLine("IToken token = node.Symbol;");
                WriteLine("if (token != null)");
                WriteLine("{");
                IncIndent();
                WriteLine("List<object> annotList = null;");
                if (this.dynamicAnnotations.Count > 0)
                {
                    WriteLine("List<object> staticAnnotList = null;");
                    WriteLine("if (this.tokenAnnotations.TryGetValue(token.Type, out staticAnnotList))");
                    WriteLine("{");
                    IncIndent();
                    WriteLine("annotList = new List<object>(staticAnnotList);");
                    DecIndent();
                    WriteLine("}");
                    WriteLine("switch (token.Type)");
                    WriteLine("{");
                    IncIndent();
                    foreach (var token in currentGrammar.LexerRules)
                    {
                        if (token.Annotations.Count(a => a.Type.IsDynamic) > 0)
                        {
                            WriteLine("case {0}.{1}:", this.lexerName, token.Name);
                            IncIndent();
                            WriteLine("if (annotList == null) annotList = new List<object>();");
                            foreach (var annot in token.Annotations)
                            {
                                if (annot.Type.IsDynamic)
                                {
                                    string tmp = this.GetTmpVariable();
                                    this.GenerateAnnotationCreation(annot, tmp, true);
                                    WriteLine("annotList.Add({0});", tmp);
                                }
                            }
                            WriteLine("break;");
                            DecIndent();
                        }
                    }
                    WriteLine("default:");
                    IncIndent();
                    WriteLine("break;");
                    DecIndent();
                    DecIndent();
                    WriteLine("}");
                    WriteLine("if (annotList != null)");
                }
                else
                {
                    WriteLine("if (this.tokenAnnotations.TryGetValue(token.Type, out annotList))");
                }
                WriteLine("{");
                IncIndent();
                WriteLine("List<object> treeAnnotList = null;");
                WriteLine("if (!treeAnnotations.TryGetValue(node, out treeAnnotList))");
                WriteLine("{");
                IncIndent();
                WriteLine("treeAnnotList = new List<object>();");
                WriteLine("treeAnnotations.Add(node, treeAnnotList);");
                DecIndent();
                WriteLine("}");
                WriteLine("treeAnnotList.AddRange(annotList);");
                DecIndent();
                WriteLine("}");
                DecIndent();
                WriteLine("}");
                WriteLine("return null;");
            }
            else
            {
                WriteLine("return this.lexerAnnotator.VisitTerminal(node, treeAnnotations);");
            }
            DecIndent();
            WriteLine("}");

            if (isParser)
            {
                this.GenerateAnnotatorVisitMethods();
            }

            DecIndent();
            WriteLine("}");
        }

        private void GenerateAnnotatorVisitMethods()
        {
            foreach (var rule in currentGrammar.ParserRules)
            {
                if (rule.Alternatives.Count == 0)
                {
                    this.GenerateAnnotatorVisitMethod(rule, null);
                }
                else
                {
                    foreach (var alt in rule.Alternatives)
                    {
                        this.GenerateAnnotatorVisitMethod(alt, rule);
                    }
                }
            }
        }

        private void GenerateAnnotatorVisitMethod(ParserRule rule, ParserRule parentRule)
        {
            WriteLine();
            WriteLine("public override object Visit{0}({1} context)", ToPascalCase(rule.Name), ToContextType(rule.Name));
            WriteLine("{");
            IncIndent();
            if (rule.Annotations.Count > 0 || (parentRule != null && parentRule.Annotations.Count > 0))
            {
                WriteLine("List<object> treeAnnotList = null;");
                WriteLine("if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))");
                WriteLine("{");
                IncIndent();
                WriteLine("treeAnnotList = new List<object>();");
                WriteLine("this.treeAnnotations.Add(context, treeAnnotList);");
                DecIndent();
                WriteLine("}");
                if (parentRule != null)
                {
                    foreach (var annot in parentRule.Annotations)
                    {
                        if (!annot.Type.IsDynamic)
                        {
                            WriteLine("treeAnnotList.Add(this.{0}_{1});", ToCamelCase(parentRule.Name), annot.Type.Name);
                        }
                        else
                        {
                            string tmp = this.GetTmpVariable();
                            this.GenerateAnnotationCreation(annot, tmp, true);
                            WriteLine("treeAnnotList.Add({0});", tmp);
                        }
                    }
                }
                foreach (var annot in rule.Annotations)
                {
                    if (!annot.Type.IsDynamic)
                    {
                        WriteLine("treeAnnotList.Add(this.{0}_{1});", ToCamelCase(rule.Name), annot.Type.Name);
                    }
                    else
                    {
                        string tmp = this.GetTmpVariable();
                        this.GenerateAnnotationCreation(annot, tmp, true);
                        WriteLine("treeAnnotList.Add({0});", tmp);
                    }
                }
            }
            if (rule.HasElementAnnotations())
            {
                WriteLine("List<object> elemAnnotList = null;");
                foreach (var elem in rule.Elements)
                {
                    if (elem.Annotations.Count > 0)
                    {
                        WriteLine("if (context.{0} != null)", elem.GetAccessorName());
                        WriteLine("{");
                        IncIndent();
                        WriteLine("if (!this.treeAnnotations.TryGetValue(context.{0}, out elemAnnotList))", elem.GetAccessorName());
                        WriteLine("{");
                        IncIndent();
                        WriteLine("elemAnnotList = new List<object>();");
                        WriteLine("this.treeAnnotations.Add(context.{0}, elemAnnotList);", elem.GetAccessorName());
                        DecIndent();
                        WriteLine("}");
                        foreach (var annot in elem.Annotations)
                        {
                            if (!annot.Type.IsDynamic)
                            {
                                WriteLine("elemAnnotList.Add(this.{0}_{1}_{2});", ToCamelCase(rule.Name), ToPascalCase(elem.Name), annot.Type.Name);
                            }
                            else
                            {
                                string tmp = this.GetTmpVariable();
                                this.GenerateAnnotationCreation(annot, tmp, true);
                                WriteLine("elemAnnotList.Add({0});", tmp);
                            }
                        }
                        DecIndent();
                        WriteLine("}");
                    }
                }
            }
            this.WriteLine("return base.Visit{0}(context);", ToPascalCase(rule.Name));
            DecIndent();
            WriteLine("}");
        }

        private void GenerateAnnotationCreation(Annotation annot, string variableName, bool createVariable)
        {
            string annotName = this.ToAnnotationName(annot.Type.Name);
            if (createVariable)
            {
                WriteLine("{1} {0} = new {1}();", variableName, annotName);
            }
            else
            {
                WriteLine("{0} = new {1}();", variableName, annotName);
            }
            foreach (var prop in annot.Properties)
            {
                string propName = this.ToPascalCase(prop.Name);
                string propValue = this.ToValue(prop.Value, annot.Type.IsDynamic);
                WriteLine("{0}.{1} = {2};", variableName, propName, propValue);
            }
        }

        public class AnnotationType
        {
            public AnnotationType()
            {
                this.Properties = new List<string>();
            }
            public string Name { get; set; }
            public List<string> Properties { get; private set; }
            public bool IsDynamic { get; set; }
        }
        public class Annotation
        {
            public Annotation()
            {
                this.Properties = new List<AnnotationProperty>();
            }
            public AnnotationType Type { get; set; }
            public List<AnnotationProperty> Properties { get; private set; }
        }
        public class AnnotationProperty
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public class Grammar
        {
            public Grammar()
            {
                this.Annotations = new List<Annotation>();
                this.ParserRules = new List<ParserRule>();
                this.LexerRules = new List<LexerRule>();
                this.Modes = new List<Mode>();
            }
            public string Name { get; set; }
            public List<Annotation> Annotations { get; private set; }
            public List<ParserRule> ParserRules { get; private set; }
            public List<LexerRule> LexerRules { get; private set; }
            public List<Mode> Modes { get; private set; }
        }
        public class ParserRule
        {
            public ParserRule()
            {
                this.Annotations = new List<Annotation>();
                this.Elements = new List<ParserRuleElement>();
                this.Alternatives = new List<ParserRule>();
            }
            public string Name { get; set; }
            public List<Annotation> Annotations { get; private set; }
            public List<ParserRuleElement> Elements { get; private set; }
            public List<ParserRule> Alternatives { get; private set; }
            public bool HasElementAnnotations()
            {
                foreach (var elem in this.Elements)
                {
                    if (elem.Annotations.Count > 0) return true;
                }
                return false;
            }
        }
        public class ParserRuleElement
        {
            public ParserRuleElement()
            {
                this.Annotations = new List<Annotation>();
            }
            public string Name { get; set; }
            public string Type { get; set; }
            public List<Annotation> Annotations { get; private set; }
            public bool IsToken { get { return !this.IsParserRule; } }
            public bool IsParserRule { get { return !string.IsNullOrEmpty(this.Type) && char.IsLower(this.Type[0]); } }
            public string GetAccessorName()
            {
                if (this.Name != this.Type)
                {
                    return this.Name;
                }
                else
                {
                    return this.Type + "()";
                }
            }
        }
        public class Mode
        {
            public Mode()
            {
                this.Annotations = new List<Annotation>();
                this.LexerRules = new List<LexerRule>();
            }
            public string Name { get; set; }
            public List<Annotation> Annotations { get; private set; }
            public List<LexerRule> LexerRules { get; private set; }
        }
        public class LexerRule
        {
            public LexerRule()
            {
                this.Annotations = new List<Annotation>();
            }
            public string Name { get; set; }
            public List<Annotation> Annotations { get; private set; }
        }
    }
}
