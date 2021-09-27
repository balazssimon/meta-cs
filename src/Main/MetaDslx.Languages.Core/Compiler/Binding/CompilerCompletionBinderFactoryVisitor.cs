// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Compiler;
using MetaDslx.Languages.Compiler.Syntax;
using MetaDslx.Languages.Compiler.Symbols;

using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler.Binding
{
    public class CompilerCompletionBinderFactoryVisitor : CompletionBinderFactoryVisitor, ICompilerSyntaxVisitor
    {
		public static object UnassignedUse = new object();
		public static object FinishedUse = new object();
		public static object Use_Main_NamespaceDeclaration = new object();
		public static object Use_NamespaceDeclaration_QualifiedName = new object();
		public static object Use_NamespaceDeclaration_NamespaceBody = new object();
		public static object Use_NamespaceBody_UsingDeclaration = new object();
		public static object Use_NamespaceBody_GrammarDeclaration = new object();
		public static object Use_GrammarDeclaration_Name = new object();
		public static object Use_GrammarDeclaration_RuleDeclarations = new object();
		public static object Use_UsingDeclaration_Name = new object();
		public static object Use_UsingDeclaration_Qualifier = new object();
		public static object Use_RuleDeclarations_RuleDeclaration = new object();
		public static object Use_RuleDeclaration_ParserRuleDeclaration = new object();
		public static object Use_RuleDeclaration_LexerRuleDeclaration = new object();
		public static object Use_ParserRuleDeclaration_ParserRuleName = new object();
		public static object Use_ParserRuleDeclaration_Qualifier = new object();
		public static object Use_ParserRuleDeclaration_ParserRuleAlternative = new object();
		public static object Use_ParserRuleAlternative_ParserRuleAlternativeElement = new object();
		public static object Use_ParserRuleAlternative_EofElement = new object();
		public static object Use_ParserRuleAlternativeElement_ParserMultiElement = new object();
		public static object Use_ParserRuleAlternativeElement_ParserNegatedElement = new object();
		public static object Use_ParserMultiElement_ElementName = new object();
		public static object Use_ParserMultiElement_Assign = new object();
		public static object Use_ParserMultiElement_ParserRuleElement = new object();
		public static object Use_ParserMultiElement_Multiplicity = new object();
		public static object Use_Assign_Assign = new object();
		public static object Use_Multiplicity_Multiplicity = new object();
		public static object Use_ParserNegatedElement_ParserRuleElement = new object();
		public static object Use_ParserRuleElement_FixedElement = new object();
		public static object Use_ParserRuleElement_ParserRuleReference = new object();
		public static object Use_ParserRuleElement_ParserRuleBlock = new object();
		public static object Use_FixedElement_StringLiteral = new object();
		public static object Use_ParserRuleReference_Identifier = new object();
		public static object Use_ParserRuleBlock_ParserRuleAlternative = new object();
		public static object Use_LexerRuleDeclaration_Modifier = new object();
		public static object Use_LexerRuleDeclaration_LexerRuleName = new object();
		public static object Use_LexerRuleDeclaration_LexerRuleAlternative = new object();
		public static object Use_LexerRuleAlternative_LexerRuleAlternativeElement = new object();
		public static object Use_LexerRuleAlternativeElement_LexerMultiElement = new object();
		public static object Use_LexerRuleAlternativeElement_LexerNegatedElement = new object();
		public static object Use_LexerRuleAlternativeElement_LexerRangeElement = new object();
		public static object Use_LexerMultiElement_LexerRuleElement = new object();
		public static object Use_LexerMultiElement_Multiplicity = new object();
		public static object Use_LexerNegatedElement_LexerRuleElement = new object();
		public static object Use_LexerRangeElement_Start = new object();
		public static object Use_LexerRangeElement_End = new object();
		public static object Use_LexerRuleElement_FixedElement = new object();
		public static object Use_LexerRuleElement_WildcardElement = new object();
		public static object Use_LexerRuleElement_LexerRuleReference = new object();
		public static object Use_LexerRuleElement_LexerRuleBlock = new object();
		public static object Use_LexerRuleReference_Identifier = new object();
		public static object Use_LexerRuleBlock_LexerRuleAlternative = new object();
		public static object Use_Name_Identifier = new object();
		public static object Use_QualifiedName_Qualifier = new object();
		public static object Use_Qualifier_Identifier = new object();
		public static object Use_Literal_NullLiteral = new object();
		public static object Use_Literal_BooleanLiteral = new object();
		public static object Use_Literal_IntegerLiteral = new object();
		public static object Use_Literal_DecimalLiteral = new object();
		public static object Use_Literal_ScientificLiteral = new object();
		public static object Use_Literal_StringLiteral = new object();

        private bool[] _visited = new bool[43];

        public CompilerCompletionBinderFactoryVisitor(BinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new CompilerBinderFactory BinderFactory => (CompilerBinderFactory)base.BinderFactory;

		
		public void VisitMain(MainSyntax parent) // 0
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.NamespaceDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.NamespaceDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NamespaceDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMain(Use_Main_NamespaceDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NamespaceDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NamespaceDeclaration == null || parent.NamespaceDeclaration.IsMissing) AddResultsForMain(Use_Main_NamespaceDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NamespaceDeclaration);
		        }
		    }
		    position += parent.NamespaceDeclaration.FullSpan.Length;
		    position += parent.EndOfFileToken.FullSpan.Length;
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax parent) // 1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KNamespace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNamespace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNamespace, operation);
		        }
		    }
		    position += parent.KNamespace.FullSpan.Length;
		    if (parent.QualifiedName.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.QualifiedName.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.QualifiedName);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_QualifiedName, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.QualifiedName);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.QualifiedName == null || parent.QualifiedName.IsMissing) AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_QualifiedName, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.QualifiedName);
		        }
		    }
		    position += parent.QualifiedName.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		    if (parent.NamespaceBody.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.NamespaceBody.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NamespaceBody);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_NamespaceBody, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NamespaceBody);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NamespaceBody == null || parent.NamespaceBody.IsMissing) AddResultsForNamespaceDeclaration(Use_NamespaceDeclaration_NamespaceBody, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NamespaceBody);
		        }
		    }
		    position += parent.NamespaceBody.FullSpan.Length;
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax parent) // 2
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.UsingDeclaration.Node == null || parent.UsingDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.UsingDeclaration.Node == null || !parent.UsingDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingDeclaration.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceBody(Use_NamespaceBody_UsingDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.UsingDeclaration)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.UsingDeclaration.FullSpan.Length;
		    if (parent.GrammarDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.GrammarDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.GrammarDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamespaceBody(Use_NamespaceBody_GrammarDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.GrammarDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.GrammarDeclaration == null || parent.GrammarDeclaration.IsMissing) AddResultsForNamespaceBody(Use_NamespaceBody_GrammarDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.GrammarDeclaration);
		        }
		    }
		    position += parent.GrammarDeclaration.FullSpan.Length;
		}
		
		public void VisitGrammarDeclaration(GrammarDeclarationSyntax parent) // 3
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KGrammar.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KGrammar);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KGrammar, operation);
		        }
		    }
		    position += parent.KGrammar.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForGrammarDeclaration(Use_GrammarDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForGrammarDeclaration(Use_GrammarDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		    if (parent.RuleDeclarations.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.RuleDeclarations.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.RuleDeclarations);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForGrammarDeclaration(Use_GrammarDeclaration_RuleDeclarations, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.RuleDeclarations);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.RuleDeclarations == null || parent.RuleDeclarations.IsMissing) AddResultsForGrammarDeclaration(Use_GrammarDeclaration_RuleDeclarations, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.RuleDeclarations);
		        }
		    }
		    position += parent.RuleDeclarations.FullSpan.Length;
		}
		
		public void VisitUsingDeclaration(UsingDeclarationSyntax parent) // 4
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KUsing.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KUsing);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KUsing, operation);
		        }
		    }
		    position += parent.KUsing.FullSpan.Length;
		    if (parent.Name == null || parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Name == null || !parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingDeclaration(Use_UsingDeclaration_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForUsingDeclaration(Use_UsingDeclaration_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    if (parent.Name != null) position += parent.Name.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingDeclaration(Use_UsingDeclaration_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForUsingDeclaration(Use_UsingDeclaration_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitRuleDeclarations(RuleDeclarationsSyntax parent) // 5
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.RuleDeclaration.Node == null || parent.RuleDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.RuleDeclaration.Node == null || !parent.RuleDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.RuleDeclaration.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRuleDeclarations(Use_RuleDeclarations_RuleDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.RuleDeclaration)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.RuleDeclaration.FullSpan.Length;
		}
		
		public void VisitRuleDeclaration(RuleDeclarationSyntax parent) // 6
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ParserRuleDeclaration == null || parent.ParserRuleDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserRuleDeclaration == null || !parent.ParserRuleDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRuleDeclaration(Use_RuleDeclaration_ParserRuleDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserRuleDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserRuleDeclaration == null || parent.ParserRuleDeclaration.IsMissing) AddResultsForRuleDeclaration(Use_RuleDeclaration_ParserRuleDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserRuleDeclaration);
		        }
		    }
		    if (parent.ParserRuleDeclaration != null) position += parent.ParserRuleDeclaration.FullSpan.Length;
		    if (parent.LexerRuleDeclaration == null || parent.LexerRuleDeclaration.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRuleDeclaration == null || !parent.LexerRuleDeclaration.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleDeclaration);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRuleDeclaration(Use_RuleDeclaration_LexerRuleDeclaration, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRuleDeclaration);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRuleDeclaration == null || parent.LexerRuleDeclaration.IsMissing) AddResultsForRuleDeclaration(Use_RuleDeclaration_LexerRuleDeclaration, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRuleDeclaration);
		        }
		    }
		    if (parent.LexerRuleDeclaration != null) position += parent.LexerRuleDeclaration.FullSpan.Length;
		}
		
		public void VisitParserRuleDeclaration(ParserRuleDeclarationSyntax parent) // 7
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ParserRuleName.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ParserRuleName.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleName);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleDeclaration(Use_ParserRuleDeclaration_ParserRuleName, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserRuleName);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserRuleName == null || parent.ParserRuleName.IsMissing) AddResultsForParserRuleDeclaration(Use_ParserRuleDeclaration_ParserRuleName, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserRuleName);
		        }
		    }
		    position += parent.ParserRuleName.FullSpan.Length;
		    if (parent.KDefines.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KDefines);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KDefines, operation);
		        }
		    }
		    position += parent.KDefines.FullSpan.Length;
		    if (parent.Qualifier == null || parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Qualifier == null || !parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleDeclaration(Use_ParserRuleDeclaration_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForParserRuleDeclaration(Use_ParserRuleDeclaration_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    if (parent.Qualifier != null) position += parent.Qualifier.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.ParserRuleAlternative.Node == null || parent.ParserRuleAlternative.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserRuleAlternative.Node == null || !parent.ParserRuleAlternative.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleAlternative.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleDeclaration(Use_ParserRuleDeclaration_ParserRuleAlternative, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ParserRuleAlternative.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.ParserRuleAlternative.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitParserRuleAlternative(ParserRuleAlternativeSyntax parent) // 8
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ParserRuleAlternativeElement.Node == null || parent.ParserRuleAlternativeElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserRuleAlternativeElement.Node == null || !parent.ParserRuleAlternativeElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleAlternativeElement.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleAlternative(Use_ParserRuleAlternative_ParserRuleAlternativeElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ParserRuleAlternativeElement)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.ParserRuleAlternativeElement.FullSpan.Length;
		    if (parent.EofElement == null || parent.EofElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.EofElement == null || !parent.EofElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EofElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleAlternative(Use_ParserRuleAlternative_EofElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.EofElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.EofElement == null || parent.EofElement.IsMissing) AddResultsForParserRuleAlternative(Use_ParserRuleAlternative_EofElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.EofElement);
		        }
		    }
		    if (parent.EofElement != null) position += parent.EofElement.FullSpan.Length;
		}
		
		public void VisitEofElement(EofElementSyntax parent) // 9
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KEof.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KEof);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KEof, operation);
		        }
		    }
		    position += parent.KEof.FullSpan.Length;
		}
		
		public void VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax parent) // 10
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ParserMultiElement == null || parent.ParserMultiElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserMultiElement == null || !parent.ParserMultiElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserMultiElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleAlternativeElement(Use_ParserRuleAlternativeElement_ParserMultiElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserMultiElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserMultiElement == null || parent.ParserMultiElement.IsMissing) AddResultsForParserRuleAlternativeElement(Use_ParserRuleAlternativeElement_ParserMultiElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserMultiElement);
		        }
		    }
		    if (parent.ParserMultiElement != null) position += parent.ParserMultiElement.FullSpan.Length;
		    if (parent.ParserNegatedElement == null || parent.ParserNegatedElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserNegatedElement == null || !parent.ParserNegatedElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserNegatedElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleAlternativeElement(Use_ParserRuleAlternativeElement_ParserNegatedElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserNegatedElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserNegatedElement == null || parent.ParserNegatedElement.IsMissing) AddResultsForParserRuleAlternativeElement(Use_ParserRuleAlternativeElement_ParserNegatedElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserNegatedElement);
		        }
		    }
		    if (parent.ParserNegatedElement != null) position += parent.ParserNegatedElement.FullSpan.Length;
		}
		
		public void VisitParserMultiElement(ParserMultiElementSyntax parent) // 11
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ElementName == null || parent.ElementName.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ElementName == null || !parent.ElementName.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ElementName);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserMultiElement(Use_ParserMultiElement_ElementName, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ElementName);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ElementName == null || parent.ElementName.IsMissing) AddResultsForParserMultiElement(Use_ParserMultiElement_ElementName, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ElementName);
		        }
		    }
		    if (parent.ElementName != null) position += parent.ElementName.FullSpan.Length;
		    if (parent.Assign == null || parent.Assign.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Assign == null || !parent.Assign.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Assign);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserMultiElement(Use_ParserMultiElement_Assign, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Assign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Assign == null || parent.Assign.IsMissing) AddResultsForParserMultiElement(Use_ParserMultiElement_Assign, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Assign);
		        }
		    }
		    if (parent.Assign != null) position += parent.Assign.FullSpan.Length;
		    if (parent.ParserRuleElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ParserRuleElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserMultiElement(Use_ParserMultiElement_ParserRuleElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserRuleElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserRuleElement == null || parent.ParserRuleElement.IsMissing) AddResultsForParserMultiElement(Use_ParserMultiElement_ParserRuleElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserRuleElement);
		        }
		    }
		    position += parent.ParserRuleElement.FullSpan.Length;
		    if (parent.Multiplicity == null || parent.Multiplicity.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Multiplicity == null || !parent.Multiplicity.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Multiplicity);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserMultiElement(Use_ParserMultiElement_Multiplicity, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Multiplicity);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Multiplicity == null || parent.Multiplicity.IsMissing) AddResultsForParserMultiElement(Use_ParserMultiElement_Multiplicity, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Multiplicity);
		        }
		    }
		    if (parent.Multiplicity != null) position += parent.Multiplicity.FullSpan.Length;
		}
		
		public void VisitAssign(AssignSyntax parent) // 12
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Assign.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Assign.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Assign);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAssign(Use_Assign_Assign, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Assign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForAssign(Use_Assign_Assign, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.Assign.FullSpan.Length;
		}
		
		public void VisitMultiplicity(MultiplicitySyntax parent) // 13
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Multiplicity.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Multiplicity.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Multiplicity);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMultiplicity(Use_Multiplicity_Multiplicity, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Multiplicity);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForMultiplicity(Use_Multiplicity_Multiplicity, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.Multiplicity.FullSpan.Length;
		}
		
		public void VisitParserNegatedElement(ParserNegatedElementSyntax parent) // 14
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TNegate.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TNegate);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TNegate, operation);
		        }
		    }
		    position += parent.TNegate.FullSpan.Length;
		    if (parent.ParserRuleElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ParserRuleElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserNegatedElement(Use_ParserNegatedElement_ParserRuleElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserRuleElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserRuleElement == null || parent.ParserRuleElement.IsMissing) AddResultsForParserNegatedElement(Use_ParserNegatedElement_ParserRuleElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserRuleElement);
		        }
		    }
		    position += parent.ParserRuleElement.FullSpan.Length;
		}
		
		public void VisitParserRuleElement(ParserRuleElementSyntax parent) // 15
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.FixedElement == null || parent.FixedElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FixedElement == null || !parent.FixedElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FixedElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleElement(Use_ParserRuleElement_FixedElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FixedElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FixedElement == null || parent.FixedElement.IsMissing) AddResultsForParserRuleElement(Use_ParserRuleElement_FixedElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FixedElement);
		        }
		    }
		    if (parent.FixedElement != null) position += parent.FixedElement.FullSpan.Length;
		    if (parent.ParserRuleReference == null || parent.ParserRuleReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserRuleReference == null || !parent.ParserRuleReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleElement(Use_ParserRuleElement_ParserRuleReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserRuleReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserRuleReference == null || parent.ParserRuleReference.IsMissing) AddResultsForParserRuleElement(Use_ParserRuleElement_ParserRuleReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserRuleReference);
		        }
		    }
		    if (parent.ParserRuleReference != null) position += parent.ParserRuleReference.FullSpan.Length;
		    if (parent.ParserRuleBlock == null || parent.ParserRuleBlock.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserRuleBlock == null || !parent.ParserRuleBlock.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleBlock);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleElement(Use_ParserRuleElement_ParserRuleBlock, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ParserRuleBlock);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ParserRuleBlock == null || parent.ParserRuleBlock.IsMissing) AddResultsForParserRuleElement(Use_ParserRuleElement_ParserRuleBlock, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ParserRuleBlock);
		        }
		    }
		    if (parent.ParserRuleBlock != null) position += parent.ParserRuleBlock.FullSpan.Length;
		}
		
		public void VisitFixedElement(FixedElementSyntax parent) // 16
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFixedElement(Use_FixedElement_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForFixedElement(Use_FixedElement_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitParserRuleReference(ParserRuleReferenceSyntax parent) // 17
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleReference(Use_ParserRuleReference_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForParserRuleReference(Use_ParserRuleReference_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitParserRuleBlock(ParserRuleBlockSyntax parent) // 18
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.ParserRuleAlternative.Node == null || parent.ParserRuleAlternative.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ParserRuleAlternative.Node == null || !parent.ParserRuleAlternative.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ParserRuleAlternative.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParserRuleBlock(Use_ParserRuleBlock_ParserRuleAlternative, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ParserRuleAlternative.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.ParserRuleAlternative.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax parent) // 19
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Modifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Modifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Modifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleDeclaration(Use_LexerRuleDeclaration_Modifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Modifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForLexerRuleDeclaration(Use_LexerRuleDeclaration_Modifier, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.Modifier.FullSpan.Length;
		    if (parent.LexerRuleName.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.LexerRuleName.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleName);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleDeclaration(Use_LexerRuleDeclaration_LexerRuleName, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRuleName);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRuleName == null || parent.LexerRuleName.IsMissing) AddResultsForLexerRuleDeclaration(Use_LexerRuleDeclaration_LexerRuleName, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRuleName);
		        }
		    }
		    position += parent.LexerRuleName.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.LexerRuleAlternative.Node == null || parent.LexerRuleAlternative.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRuleAlternative.Node == null || !parent.LexerRuleAlternative.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleAlternative.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleDeclaration(Use_LexerRuleDeclaration_LexerRuleAlternative, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.LexerRuleAlternative.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.LexerRuleAlternative.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitLexerRuleAlternative(LexerRuleAlternativeSyntax parent) // 20
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.LexerRuleAlternativeElement.Node == null || parent.LexerRuleAlternativeElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRuleAlternativeElement.Node == null || !parent.LexerRuleAlternativeElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleAlternativeElement.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleAlternative(Use_LexerRuleAlternative_LexerRuleAlternativeElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.LexerRuleAlternativeElement)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.LexerRuleAlternativeElement.FullSpan.Length;
		}
		
		public void VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax parent) // 21
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.LexerMultiElement == null || parent.LexerMultiElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerMultiElement == null || !parent.LexerMultiElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerMultiElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleAlternativeElement(Use_LexerRuleAlternativeElement_LexerMultiElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerMultiElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerMultiElement == null || parent.LexerMultiElement.IsMissing) AddResultsForLexerRuleAlternativeElement(Use_LexerRuleAlternativeElement_LexerMultiElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerMultiElement);
		        }
		    }
		    if (parent.LexerMultiElement != null) position += parent.LexerMultiElement.FullSpan.Length;
		    if (parent.LexerNegatedElement == null || parent.LexerNegatedElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerNegatedElement == null || !parent.LexerNegatedElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerNegatedElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleAlternativeElement(Use_LexerRuleAlternativeElement_LexerNegatedElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerNegatedElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerNegatedElement == null || parent.LexerNegatedElement.IsMissing) AddResultsForLexerRuleAlternativeElement(Use_LexerRuleAlternativeElement_LexerNegatedElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerNegatedElement);
		        }
		    }
		    if (parent.LexerNegatedElement != null) position += parent.LexerNegatedElement.FullSpan.Length;
		    if (parent.LexerRangeElement == null || parent.LexerRangeElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRangeElement == null || !parent.LexerRangeElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRangeElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleAlternativeElement(Use_LexerRuleAlternativeElement_LexerRangeElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRangeElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRangeElement == null || parent.LexerRangeElement.IsMissing) AddResultsForLexerRuleAlternativeElement(Use_LexerRuleAlternativeElement_LexerRangeElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRangeElement);
		        }
		    }
		    if (parent.LexerRangeElement != null) position += parent.LexerRangeElement.FullSpan.Length;
		}
		
		public void VisitLexerMultiElement(LexerMultiElementSyntax parent) // 22
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.LexerRuleElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.LexerRuleElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerMultiElement(Use_LexerMultiElement_LexerRuleElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRuleElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRuleElement == null || parent.LexerRuleElement.IsMissing) AddResultsForLexerMultiElement(Use_LexerMultiElement_LexerRuleElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRuleElement);
		        }
		    }
		    position += parent.LexerRuleElement.FullSpan.Length;
		    if (parent.Multiplicity == null || parent.Multiplicity.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Multiplicity == null || !parent.Multiplicity.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Multiplicity);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerMultiElement(Use_LexerMultiElement_Multiplicity, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Multiplicity);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Multiplicity == null || parent.Multiplicity.IsMissing) AddResultsForLexerMultiElement(Use_LexerMultiElement_Multiplicity, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Multiplicity);
		        }
		    }
		    if (parent.Multiplicity != null) position += parent.Multiplicity.FullSpan.Length;
		}
		
		public void VisitLexerNegatedElement(LexerNegatedElementSyntax parent) // 23
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TNegate.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TNegate);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TNegate, operation);
		        }
		    }
		    position += parent.TNegate.FullSpan.Length;
		    if (parent.LexerRuleElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.LexerRuleElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerNegatedElement(Use_LexerNegatedElement_LexerRuleElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRuleElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRuleElement == null || parent.LexerRuleElement.IsMissing) AddResultsForLexerNegatedElement(Use_LexerNegatedElement_LexerRuleElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRuleElement);
		        }
		    }
		    position += parent.LexerRuleElement.FullSpan.Length;
		}
		
		public void VisitLexerRangeElement(LexerRangeElementSyntax parent) // 24
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Start.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Start.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Start);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRangeElement(Use_LexerRangeElement_Start, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Start);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Start == null || parent.Start.IsMissing) AddResultsForLexerRangeElement(Use_LexerRangeElement_Start, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Start);
		        }
		    }
		    position += parent.Start.FullSpan.Length;
		    if (parent.TArrow.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TArrow);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TArrow, operation);
		        }
		    }
		    position += parent.TArrow.FullSpan.Length;
		    if (parent.End.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.End.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.End);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRangeElement(Use_LexerRangeElement_End, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.End);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.End == null || parent.End.IsMissing) AddResultsForLexerRangeElement(Use_LexerRangeElement_End, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.End);
		        }
		    }
		    position += parent.End.FullSpan.Length;
		}
		
		public void VisitLexerRuleElement(LexerRuleElementSyntax parent) // 25
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.FixedElement == null || parent.FixedElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FixedElement == null || !parent.FixedElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FixedElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleElement(Use_LexerRuleElement_FixedElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FixedElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FixedElement == null || parent.FixedElement.IsMissing) AddResultsForLexerRuleElement(Use_LexerRuleElement_FixedElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FixedElement);
		        }
		    }
		    if (parent.FixedElement != null) position += parent.FixedElement.FullSpan.Length;
		    if (parent.WildcardElement == null || parent.WildcardElement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.WildcardElement == null || !parent.WildcardElement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.WildcardElement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleElement(Use_LexerRuleElement_WildcardElement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.WildcardElement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.WildcardElement == null || parent.WildcardElement.IsMissing) AddResultsForLexerRuleElement(Use_LexerRuleElement_WildcardElement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.WildcardElement);
		        }
		    }
		    if (parent.WildcardElement != null) position += parent.WildcardElement.FullSpan.Length;
		    if (parent.LexerRuleReference == null || parent.LexerRuleReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRuleReference == null || !parent.LexerRuleReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleElement(Use_LexerRuleElement_LexerRuleReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRuleReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRuleReference == null || parent.LexerRuleReference.IsMissing) AddResultsForLexerRuleElement(Use_LexerRuleElement_LexerRuleReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRuleReference);
		        }
		    }
		    if (parent.LexerRuleReference != null) position += parent.LexerRuleReference.FullSpan.Length;
		    if (parent.LexerRuleBlock == null || parent.LexerRuleBlock.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRuleBlock == null || !parent.LexerRuleBlock.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleBlock);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleElement(Use_LexerRuleElement_LexerRuleBlock, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LexerRuleBlock);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LexerRuleBlock == null || parent.LexerRuleBlock.IsMissing) AddResultsForLexerRuleElement(Use_LexerRuleElement_LexerRuleBlock, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LexerRuleBlock);
		        }
		    }
		    if (parent.LexerRuleBlock != null) position += parent.LexerRuleBlock.FullSpan.Length;
		}
		
		public void VisitWildcardElement(WildcardElementSyntax parent) // 26
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TDot.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TDot);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TDot, operation);
		        }
		    }
		    position += parent.TDot.FullSpan.Length;
		}
		
		public void VisitLexerRuleReference(LexerRuleReferenceSyntax parent) // 27
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleReference(Use_LexerRuleReference_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForLexerRuleReference(Use_LexerRuleReference_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitLexerRuleBlock(LexerRuleBlockSyntax parent) // 28
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.LexerRuleAlternative.Node == null || parent.LexerRuleAlternative.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LexerRuleAlternative.Node == null || !parent.LexerRuleAlternative.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LexerRuleAlternative.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLexerRuleBlock(Use_LexerRuleBlock_LexerRuleAlternative, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.LexerRuleAlternative.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.LexerRuleAlternative.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitName(NameSyntax parent) // 29
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForName(Use_Name_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForName(Use_Name_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax parent) // 30
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifiedName(Use_QualifiedName_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForQualifiedName(Use_QualifiedName_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitQualifier(QualifierSyntax parent) // 31
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.Node == null || parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Identifier.Node == null || !parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifier(Use_Qualifier_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Identifier.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitIdentifier(IdentifierSyntax parent) // 32
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitLexerRuleName(LexerRuleNameSyntax parent) // 33
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LexerIdentifier.FullSpan.Length;
		}
		
		public void VisitParserRuleName(ParserRuleNameSyntax parent) // 34
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.ParserIdentifier.FullSpan.Length;
		}
		
		public void VisitElementName(ElementNameSyntax parent) // 35
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LexerIdentifier.FullSpan.Length;
		}
		
		public void VisitLiteral(LiteralSyntax parent) // 36
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.NullLiteral == null || parent.NullLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.NullLiteral == null || !parent.NullLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NullLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_NullLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NullLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NullLiteral == null || parent.NullLiteral.IsMissing) AddResultsForLiteral(Use_Literal_NullLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NullLiteral);
		        }
		    }
		    if (parent.NullLiteral != null) position += parent.NullLiteral.FullSpan.Length;
		    if (parent.BooleanLiteral == null || parent.BooleanLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.BooleanLiteral == null || !parent.BooleanLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.BooleanLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_BooleanLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.BooleanLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.BooleanLiteral == null || parent.BooleanLiteral.IsMissing) AddResultsForLiteral(Use_Literal_BooleanLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.BooleanLiteral);
		        }
		    }
		    if (parent.BooleanLiteral != null) position += parent.BooleanLiteral.FullSpan.Length;
		    if (parent.IntegerLiteral == null || parent.IntegerLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.IntegerLiteral == null || !parent.IntegerLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.IntegerLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_IntegerLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.IntegerLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.IntegerLiteral == null || parent.IntegerLiteral.IsMissing) AddResultsForLiteral(Use_Literal_IntegerLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.IntegerLiteral);
		        }
		    }
		    if (parent.IntegerLiteral != null) position += parent.IntegerLiteral.FullSpan.Length;
		    if (parent.DecimalLiteral == null || parent.DecimalLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.DecimalLiteral == null || !parent.DecimalLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DecimalLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_DecimalLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DecimalLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.DecimalLiteral == null || parent.DecimalLiteral.IsMissing) AddResultsForLiteral(Use_Literal_DecimalLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.DecimalLiteral);
		        }
		    }
		    if (parent.DecimalLiteral != null) position += parent.DecimalLiteral.FullSpan.Length;
		    if (parent.ScientificLiteral == null || parent.ScientificLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ScientificLiteral == null || !parent.ScientificLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ScientificLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_ScientificLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ScientificLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ScientificLiteral == null || parent.ScientificLiteral.IsMissing) AddResultsForLiteral(Use_Literal_ScientificLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ScientificLiteral);
		        }
		    }
		    if (parent.ScientificLiteral != null) position += parent.ScientificLiteral.FullSpan.Length;
		    if (parent.StringLiteral == null || parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.StringLiteral == null || !parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForLiteral(Use_Literal_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    if (parent.StringLiteral != null) position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitNullLiteral(NullLiteralSyntax parent) // 37
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KNull.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNull);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNull, operation);
		        }
		    }
		    position += parent.KNull.FullSpan.Length;
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax parent) // 38
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.BooleanLiteral.FullSpan.Length;
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax parent) // 39
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LInteger.FullSpan.Length;
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax parent) // 40
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LDecimal.FullSpan.Length;
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax parent) // 41
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LScientific.FullSpan.Length;
		}
		
		public void VisitStringLiteral(StringLiteralSyntax parent) // 42
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LString.FullSpan.Length;
		}

        public void VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node)
        {
        }

        
        public void AddResultsForMain(object use, CompletionSearchFlags operation, Binder parentBinder) // 0
        {
            if (_visited[0]) return;
            _visited[0] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Main_NamespaceDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForNamespaceDeclaration(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.Eof, operation);
                use = FinishedUse;
            }
            _visited[0] = false;
        }
        
        public void AddResultsForNamespaceDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 1
        {
            if (_visited[1]) return;
            _visited[1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(Namespace), nestingProperty: "Members", merge: true, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.KNamespace, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NamespaceDeclaration_QualifiedName)
            {
                var binder = ruleBinder;
                AddResultsForQualifiedName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NamespaceDeclaration_NamespaceBody)
            {
                var binder = ruleBinder;
                AddResultsForNamespaceBody(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[1] = false;
        }
        
        public void AddResultsForNamespaceBody(object use, CompletionSearchFlags operation, Binder parentBinder) // 2
        {
            if (_visited[2]) return;
            _visited[2] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateScopeBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_NamespaceBody_UsingDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForUsingDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_NamespaceBody_GrammarDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForGrammarDeclaration(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[2] = false;
        }
        
        public void AddResultsForGrammarDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 3
        {
            if (_visited[3]) return;
            _visited[3] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Members", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(Grammar), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.KGrammar, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_GrammarDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_GrammarDeclaration_RuleDeclarations)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateScopeBinder(binder, null, forCompletion: true);
                AddResultsForRuleDeclarations(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[3] = false;
        }
        
        public void AddResultsForUsingDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 4
        {
            if (_visited[4]) return;
            _visited[4] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateImportBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.KUsing, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_UsingDeclaration_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TAssign, operation);
            }
            if (use == UnassignedUse || use == Use_UsingDeclaration_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[4] = false;
        }
        
        public void AddResultsForRuleDeclarations(object use, CompletionSearchFlags operation, Binder parentBinder) // 5
        {
            if (_visited[5]) return;
            _visited[5] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_RuleDeclarations_RuleDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForRuleDeclaration(UnassignedUse, operation, binder);
            }
            _visited[5] = false;
        }
        
        public void AddResultsForRuleDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 6
        {
            if (_visited[6]) return;
            _visited[6] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Rules", forCompletion: true);
            if (use == UnassignedUse || use == Use_RuleDeclaration_ParserRuleDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleDeclaration(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_RuleDeclaration_LexerRuleDeclaration)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleDeclaration(UnassignedUse, operation, binder);
            }
            _visited[6] = false;
        }
        
        public void AddResultsForParserRuleDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 7
        {
            if (_visited[7]) return;
            _visited[7] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ParserRule), forCompletion: true);
            if (use == UnassignedUse || use == Use_ParserRuleDeclaration_ParserRuleName)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.KDefines, operation);
            }
            if (use == UnassignedUse || use == Use_ParserRuleDeclaration_Qualifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "DefinedModelObject", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(System.Type)), forCompletion: true);
                AddResultsForQualifier(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ParserRuleDeclaration_ParserRuleAlternative)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleAlternative(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[7] = false;
        }
        
        public void AddResultsForParserRuleAlternative(object use, CompletionSearchFlags operation, Binder parentBinder) // 8
        {
            if (_visited[8]) return;
            _visited[8] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Alternatives", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleAlternative), forCompletion: true);
            if (use == UnassignedUse || use == Use_ParserRuleAlternative_ParserRuleAlternativeElement)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleAlternativeElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ParserRuleAlternative_EofElement)
            {
                var binder = ruleBinder;
                AddResultsForEofElement(UnassignedUse, operation, binder);
            }
            _visited[8] = false;
        }
        
        public void AddResultsForEofElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 9
        {
            if (_visited[9]) return;
            _visited[9] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Elements", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleElement), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Element", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(EofElement), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.KEof, operation);
                use = FinishedUse;
            }
            _visited[9] = false;
        }
        
        public void AddResultsForParserRuleAlternativeElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 10
        {
            if (_visited[10]) return;
            _visited[10] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Elements", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleElement), forCompletion: true);
            if (use == UnassignedUse || use == Use_ParserRuleAlternativeElement_ParserMultiElement)
            {
                var binder = ruleBinder;
                AddResultsForParserMultiElement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ParserRuleAlternativeElement_ParserNegatedElement)
            {
                var binder = ruleBinder;
                AddResultsForParserNegatedElement(UnassignedUse, operation, binder);
            }
            _visited[10] = false;
        }
        
        public void AddResultsForParserMultiElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 11
        {
            if (_visited[11]) return;
            _visited[11] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ParserMultiElement_ElementName)
            {
                var binder = ruleBinder;
                AddResultsForElementName(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ParserMultiElement_Assign)
            {
                var binder = ruleBinder;
                AddResultsForAssign(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ParserMultiElement_ParserRuleElement)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ParserMultiElement_Multiplicity)
            {
                var binder = ruleBinder;
                AddResultsForMultiplicity(UnassignedUse, operation, binder);
            }
            _visited[11] = false;
        }
        
        public void AddResultsForAssign(object use, CompletionSearchFlags operation, Binder parentBinder) // 12
        {
            if (_visited[12]) return;
            _visited[12] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "AssignmentOperator", forCompletion: true);
            if (use == UnassignedUse || use == Use_Assign_Assign)
            {
                var binder = ruleBinder;
            	var TAssignBinder = binder;
            	TAssignBinder = this.BinderFactory.CreateValueBinder(TAssignBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TAssign), value: AssignmentOperator.Assign, forCompletion: true);
            	AddBinder(TAssignBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TAssign, operation);
            	var TQuestionAssignBinder = binder;
            	TQuestionAssignBinder = this.BinderFactory.CreateValueBinder(TQuestionAssignBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TQuestionAssign), value: AssignmentOperator.QuestionAssign, forCompletion: true);
            	AddBinder(TQuestionAssignBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TQuestionAssign, operation);
            	var TNegatedAssignBinder = binder;
            	TNegatedAssignBinder = this.BinderFactory.CreateValueBinder(TNegatedAssignBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TNegatedAssign), value: AssignmentOperator.NegatedAssign, forCompletion: true);
            	AddBinder(TNegatedAssignBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TNegatedAssign, operation);
            	var TPlusAssignBinder = binder;
            	TPlusAssignBinder = this.BinderFactory.CreateValueBinder(TPlusAssignBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TPlusAssign), value: AssignmentOperator.PlusAssign, forCompletion: true);
            	AddBinder(TPlusAssignBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TPlusAssign, operation);
                use = FinishedUse;
            }
            _visited[12] = false;
        }
        
        public void AddResultsForMultiplicity(object use, CompletionSearchFlags operation, Binder parentBinder) // 13
        {
            if (_visited[13]) return;
            _visited[13] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Multiplicity", forCompletion: true);
            if (use == UnassignedUse || use == Use_Multiplicity_Multiplicity)
            {
                var binder = ruleBinder;
            	var TNonGreedyZeroOrOneBinder = binder;
            	TNonGreedyZeroOrOneBinder = this.BinderFactory.CreateValueBinder(TNonGreedyZeroOrOneBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TNonGreedyZeroOrOne), value: Multiplicity.NonGreedyZeroOrOne, forCompletion: true);
            	AddBinder(TNonGreedyZeroOrOneBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TNonGreedyZeroOrOne, operation);
            	var TNonGreedyZeroOrMoreBinder = binder;
            	TNonGreedyZeroOrMoreBinder = this.BinderFactory.CreateValueBinder(TNonGreedyZeroOrMoreBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TNonGreedyZeroOrMore), value: Multiplicity.NonGreedyZeroOrMore, forCompletion: true);
            	AddBinder(TNonGreedyZeroOrMoreBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TNonGreedyZeroOrMore, operation);
            	var TNonGreedyOneOrMoreBinder = binder;
            	TNonGreedyOneOrMoreBinder = this.BinderFactory.CreateValueBinder(TNonGreedyOneOrMoreBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TNonGreedyOneOrMore), value: Multiplicity.NonGreedyOneOrMore, forCompletion: true);
            	AddBinder(TNonGreedyOneOrMoreBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TNonGreedyOneOrMore, operation);
            	var TZeroOrOneBinder = binder;
            	TZeroOrOneBinder = this.BinderFactory.CreateValueBinder(TZeroOrOneBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TZeroOrOne), value: Multiplicity.ZeroOrOne, forCompletion: true);
            	AddBinder(TZeroOrOneBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TZeroOrOne, operation);
            	var TZeroOrMoreBinder = binder;
            	TZeroOrMoreBinder = this.BinderFactory.CreateValueBinder(TZeroOrMoreBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TZeroOrMore), value: Multiplicity.ZeroOrMore, forCompletion: true);
            	AddBinder(TZeroOrMoreBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TZeroOrMore, operation);
            	var TOneOrMoreBinder = binder;
            	TOneOrMoreBinder = this.BinderFactory.CreateValueBinder(TOneOrMoreBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.TOneOrMore), value: Multiplicity.OneOrMore, forCompletion: true);
            	AddBinder(TOneOrMoreBinder, (CompilerSyntaxKind)CompilerSyntaxKind.TOneOrMore, operation);
                use = FinishedUse;
            }
            _visited[13] = false;
        }
        
        public void AddResultsForParserNegatedElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 14
        {
            if (_visited[14]) return;
            _visited[14] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "IsNegated", value: true, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TNegate, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ParserNegatedElement_ParserRuleElement)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[14] = false;
        }
        
        public void AddResultsForParserRuleElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 15
        {
            if (_visited[15]) return;
            _visited[15] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Element", forCompletion: true);
            if (use == UnassignedUse || use == Use_ParserRuleElement_FixedElement)
            {
                var binder = ruleBinder;
                AddResultsForFixedElement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ParserRuleElement_ParserRuleReference)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleReference(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ParserRuleElement_ParserRuleBlock)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleBlock(UnassignedUse, operation, binder);
            }
            _visited[15] = false;
        }
        
        public void AddResultsForFixedElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 16
        {
            if (_visited[16]) return;
            _visited[16] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(FixedElement), forCompletion: true);
            if (use == UnassignedUse || use == Use_FixedElement_StringLiteral)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[16] = false;
        }
        
        public void AddResultsForParserRuleReference(object use, CompletionSearchFlags operation, Binder parentBinder) // 17
        {
            if (_visited[17]) return;
            _visited[17] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleReference), forCompletion: true);
            if (use == UnassignedUse || use == Use_ParserRuleReference_Identifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Rule", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(Rule)), forCompletion: true);
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[17] = false;
        }
        
        public void AddResultsForParserRuleBlock(object use, CompletionSearchFlags operation, Binder parentBinder) // 18
        {
            if (_visited[18]) return;
            _visited[18] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleBlock), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ParserRuleBlock_ParserRuleAlternative)
            {
                var binder = ruleBinder;
                AddResultsForParserRuleAlternative(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[18] = false;
        }
        
        public void AddResultsForLexerRuleDeclaration(object use, CompletionSearchFlags operation, Binder parentBinder) // 19
        {
            if (_visited[19]) return;
            _visited[19] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(LexerRule), forCompletion: true);
            if (use == UnassignedUse || use == Use_LexerRuleDeclaration_Modifier)
            {
                var binder = ruleBinder;
            	var KHiddenBinder = binder;
            	KHiddenBinder = this.BinderFactory.CreatePropertyBinder(KHiddenBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.KHidden), name: "IsHidden", value: true, forCompletion: true);
            	AddBinder(KHiddenBinder, (CompilerSyntaxKind)CompilerSyntaxKind.KHidden, operation);
            	var KFragmentBinder = binder;
            	KFragmentBinder = this.BinderFactory.CreatePropertyBinder(KFragmentBinder, this.SyntaxFactory.MissingToken((CompilerSyntaxKind)CompilerSyntaxKind.KFragment), name: "IsFragment", value: true, forCompletion: true);
            	AddBinder(KFragmentBinder, (CompilerSyntaxKind)CompilerSyntaxKind.KFragment, operation);
            }
            if (use == UnassignedUse || use == Use_LexerRuleDeclaration_LexerRuleName)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_LexerRuleDeclaration_LexerRuleAlternative)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleAlternative(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[19] = false;
        }
        
        public void AddResultsForLexerRuleAlternative(object use, CompletionSearchFlags operation, Binder parentBinder) // 20
        {
            if (_visited[20]) return;
            _visited[20] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Alternatives", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleAlternative), forCompletion: true);
            if (use == UnassignedUse || use == Use_LexerRuleAlternative_LexerRuleAlternativeElement)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleAlternativeElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[20] = false;
        }
        
        public void AddResultsForLexerRuleAlternativeElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 21
        {
            if (_visited[21]) return;
            _visited[21] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Elements", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleElement), forCompletion: true);
            if (use == UnassignedUse || use == Use_LexerRuleAlternativeElement_LexerMultiElement)
            {
                var binder = ruleBinder;
                AddResultsForLexerMultiElement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LexerRuleAlternativeElement_LexerNegatedElement)
            {
                var binder = ruleBinder;
                AddResultsForLexerNegatedElement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LexerRuleAlternativeElement_LexerRangeElement)
            {
                var binder = ruleBinder;
                AddResultsForLexerRangeElement(UnassignedUse, operation, binder);
            }
            _visited[21] = false;
        }
        
        public void AddResultsForLexerMultiElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 22
        {
            if (_visited[22]) return;
            _visited[22] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_LexerMultiElement_LexerRuleElement)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_LexerMultiElement_Multiplicity)
            {
                var binder = ruleBinder;
                AddResultsForMultiplicity(UnassignedUse, operation, binder);
            }
            _visited[22] = false;
        }
        
        public void AddResultsForLexerNegatedElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 23
        {
            if (_visited[23]) return;
            _visited[23] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "IsNegated", value: true, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TNegate, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_LexerNegatedElement_LexerRuleElement)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[23] = false;
        }
        
        public void AddResultsForLexerRangeElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 24
        {
            if (_visited[24]) return;
            _visited[24] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RangeElement), forCompletion: true);
            if (use == UnassignedUse || use == Use_LexerRangeElement_Start)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Start", forCompletion: true);
                AddResultsForFixedElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TArrow, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_LexerRangeElement_End)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "End", forCompletion: true);
                AddResultsForFixedElement(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[24] = false;
        }
        
        public void AddResultsForLexerRuleElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 25
        {
            if (_visited[25]) return;
            _visited[25] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_LexerRuleElement_FixedElement)
            {
                var binder = ruleBinder;
                AddResultsForFixedElement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LexerRuleElement_WildcardElement)
            {
                var binder = ruleBinder;
                AddResultsForWildcardElement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LexerRuleElement_LexerRuleReference)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleReference(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LexerRuleElement_LexerRuleBlock)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleBlock(UnassignedUse, operation, binder);
            }
            _visited[25] = false;
        }
        
        public void AddResultsForWildcardElement(object use, CompletionSearchFlags operation, Binder parentBinder) // 26
        {
            if (_visited[26]) return;
            _visited[26] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(WildcardElement), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TDot, operation);
                use = FinishedUse;
            }
            _visited[26] = false;
        }
        
        public void AddResultsForLexerRuleReference(object use, CompletionSearchFlags operation, Binder parentBinder) // 27
        {
            if (_visited[27]) return;
            _visited[27] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleReference), forCompletion: true);
            if (use == UnassignedUse || use == Use_LexerRuleReference_Identifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Rule", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(LexerRule)), forCompletion: true);
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[27] = false;
        }
        
        public void AddResultsForLexerRuleBlock(object use, CompletionSearchFlags operation, Binder parentBinder) // 28
        {
            if (_visited[28]) return;
            _visited[28] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(RuleBlock), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_LexerRuleBlock_LexerRuleAlternative)
            {
                var binder = ruleBinder;
                AddResultsForLexerRuleAlternative(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[28] = false;
        }
        
        public void AddResultsForName(object use, CompletionSearchFlags operation, Binder parentBinder) // 29
        {
            if (_visited[29]) return;
            _visited[29] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_Name_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[29] = false;
        }
        
        public void AddResultsForQualifiedName(object use, CompletionSearchFlags operation, Binder parentBinder) // 30
        {
            if (_visited[30]) return;
            _visited[30] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_QualifiedName_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[30] = false;
        }
        
        public void AddResultsForQualifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 31
        {
            if (_visited[31]) return;
            _visited[31] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateQualifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_Qualifier_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[31] = false;
        }
        
        public void AddResultsForIdentifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 32
        {
            if (_visited[32]) return;
            _visited[32] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateIdentifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	var LexerIdentifierBinder = binder;
            	AddBinder(LexerIdentifierBinder, (CompilerSyntaxKind)CompilerSyntaxKind.LexerIdentifier, operation);
            	var ParserIdentifierBinder = binder;
            	AddBinder(ParserIdentifierBinder, (CompilerSyntaxKind)CompilerSyntaxKind.ParserIdentifier, operation);
                use = FinishedUse;
            }
            _visited[32] = false;
        }
        
        public void AddResultsForLexerRuleName(object use, CompletionSearchFlags operation, Binder parentBinder) // 33
        {
            if (_visited[33]) return;
            _visited[33] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateIdentifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.LexerIdentifier, operation);
                use = FinishedUse;
            }
            _visited[33] = false;
        }
        
        public void AddResultsForParserRuleName(object use, CompletionSearchFlags operation, Binder parentBinder) // 34
        {
            if (_visited[34]) return;
            _visited[34] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateIdentifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.ParserIdentifier, operation);
                use = FinishedUse;
            }
            _visited[34] = false;
        }
        
        public void AddResultsForElementName(object use, CompletionSearchFlags operation, Binder parentBinder) // 35
        {
            if (_visited[35]) return;
            _visited[35] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateIdentifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.LexerIdentifier, operation);
                use = FinishedUse;
            }
            _visited[35] = false;
        }
        
        public void AddResultsForLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 36
        {
            if (_visited[36]) return;
            _visited[36] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Literal_NullLiteral)
            {
                var binder = ruleBinder;
                AddResultsForNullLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_BooleanLiteral)
            {
                var binder = ruleBinder;
                AddResultsForBooleanLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_IntegerLiteral)
            {
                var binder = ruleBinder;
                AddResultsForIntegerLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_DecimalLiteral)
            {
                var binder = ruleBinder;
                AddResultsForDecimalLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_ScientificLiteral)
            {
                var binder = ruleBinder;
                AddResultsForScientificLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_StringLiteral)
            {
                var binder = ruleBinder;
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
            }
            _visited[36] = false;
        }
        
        public void AddResultsForNullLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 37
        {
            if (_visited[37]) return;
            _visited[37] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.KNull, operation);
                use = FinishedUse;
            }
            _visited[37] = false;
        }
        
        public void AddResultsForBooleanLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 38
        {
            if (_visited[38]) return;
            _visited[38] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	var KTrueBinder = binder;
            	AddBinder(KTrueBinder, (CompilerSyntaxKind)CompilerSyntaxKind.KTrue, operation);
            	var KFalseBinder = binder;
            	AddBinder(KFalseBinder, (CompilerSyntaxKind)CompilerSyntaxKind.KFalse, operation);
                use = FinishedUse;
            }
            _visited[38] = false;
        }
        
        public void AddResultsForIntegerLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 39
        {
            if (_visited[39]) return;
            _visited[39] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.LInteger, operation);
                use = FinishedUse;
            }
            _visited[39] = false;
        }
        
        public void AddResultsForDecimalLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 40
        {
            if (_visited[40]) return;
            _visited[40] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.LDecimal, operation);
                use = FinishedUse;
            }
            _visited[40] = false;
        }
        
        public void AddResultsForScientificLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 41
        {
            if (_visited[41]) return;
            _visited[41] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.LScientific, operation);
                use = FinishedUse;
            }
            _visited[41] = false;
        }
        
        public void AddResultsForStringLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 42
        {
            if (_visited[42]) return;
            _visited[42] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CompilerSyntaxKind)CompilerSyntaxKind.LString, operation);
                use = FinishedUse;
            }
            _visited[42] = false;
        }
    }
}

