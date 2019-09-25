// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Antlr4Roslyn.Parser;
namespace WebSequenceDiagramsModel.Syntax.InternalSyntax
{
    public class SequenceSyntaxParser : Antlr4SyntaxParser<SequenceLexer, SequenceParser>
    {
        public SequenceSyntaxParser(
            SourceText text,
            SequenceParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, SequenceLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override SequenceLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new SequenceLexer(inputStream);
        }
        protected override SequenceParser CreateParser(CommonTokenStream tokenStream)
        {
            return new SequenceParser(tokenStream);
        }
        public override GreenNode Parse()
        {
            return this.ParseMain();
        }
        internal MainGreen ParseMain()
        {
            Antlr4ToRoslynVisitor visitor = new Antlr4ToRoslynVisitor(this);
            var tree = this.Parser.main();
            return (MainGreen)visitor.Visit(tree);
        }
        private class Antlr4ToRoslynVisitor : SequenceParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.            private SequenceLanguage language;
			private SequenceInternalSyntaxFactory factory;
            private SequenceSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastTokenOrTrivia;
            public Antlr4ToRoslynVisitor(SequenceSyntaxParser syntaxParser)
            {
				this.factory = (SequenceInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastTokenOrTrivia = null;
            }
            private GreenNode VisitTerminal(ITerminalNode node, SequenceSyntaxKind kind)
            {
                return this.syntaxParser.VisitTerminal(node, kind, ref this.lastTokenOrTrivia);
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                return this.VisitTerminal(node, null);
            }
			
			public override GreenNode VisitMain(SequenceParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
				SequenceParser.InteractionContext interactionContext = context.interaction();
				InteractionGreen interaction = null;
				if (interactionContext != null)
				{
					interaction = (InteractionGreen)this.Visit(interactionContext);
				}
				else
				{
					interaction = InteractionGreen.__Missing;
				}
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), SequenceSyntaxKind.Eof);
				return this.factory.Main(interaction, eof);
			}
			
			public override GreenNode VisitInteraction(SequenceParser.InteractionContext context)
			{
				if (context == null) return InteractionGreen.__Missing;
			    SequenceParser.LineContext[] lineContext = context.line();
			    var lineBuilder = _pool.Allocate<LineGreen>();
			    for (int i = 0; i < lineContext.Length; i++)
			    {
			        lineBuilder.Add((LineGreen)this.Visit(lineContext[i]));
			    }
				var line = lineBuilder.ToList();
				_pool.Free(lineBuilder);
				return this.factory.Interaction(line);
			}
			
			public override GreenNode VisitLine(SequenceParser.LineContext context)
			{
				if (context == null) return LineGreen.__Missing;
				SequenceParser.DeclarationContext declarationContext = context.declaration();
				DeclarationGreen declaration = null;
				if (declarationContext != null)
				{
					declaration = (DeclarationGreen)this.Visit(declarationContext);
				}
				else
				{
					declaration = DeclarationGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				return this.factory.Line(declaration, lCrLf);
			}
			
			public override GreenNode VisitDeclaration(SequenceParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
				SequenceParser.TitleContext titleContext = context.title();
				if (titleContext != null) 
				{
					return this.factory.Declaration((TitleGreen)this.Visit(titleContext));
				}
				SequenceParser.DestroyContext destroyContext = context.destroy();
				if (destroyContext != null) 
				{
					return this.factory.Declaration((DestroyGreen)this.Visit(destroyContext));
				}
				SequenceParser.ArrowContext arrowContext = context.arrow();
				if (arrowContext != null) 
				{
					return this.factory.Declaration((ArrowGreen)this.Visit(arrowContext));
				}
				SequenceParser.AltContext altContext = context.alt();
				if (altContext != null) 
				{
					return this.factory.Declaration((AltGreen)this.Visit(altContext));
				}
				SequenceParser.OptContext optContext = context.opt();
				if (optContext != null) 
				{
					return this.factory.Declaration((OptGreen)this.Visit(optContext));
				}
				SequenceParser.LoopContext loopContext = context.loop();
				if (loopContext != null) 
				{
					return this.factory.Declaration((LoopGreen)this.Visit(loopContext));
				}
				SequenceParser.RefContext _refContext = context.@ref();
				if (_refContext != null) 
				{
					return this.factory.Declaration((RefGreen)this.Visit(_refContext));
				}
				SequenceParser.NoteContext noteContext = context.note();
				if (noteContext != null) 
				{
					return this.factory.Declaration((NoteGreen)this.Visit(noteContext));
				}
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitTitle(SequenceParser.TitleContext context)
			{
				if (context == null) return TitleGreen.__Missing;
				InternalSyntaxToken kTitle = (InternalSyntaxToken)this.VisitTerminal(context.KTitle(), SequenceSyntaxKind.KTitle);
				SequenceParser.TextContext textContext = context.text();
				TextGreen text = null;
				if (textContext != null)
				{
					text = (TextGreen)this.Visit(textContext);
				}
				else
				{
					text = TextGreen.__Missing;
				}
				return this.factory.Title(kTitle, text);
			}
			
			public override GreenNode VisitArrow(SequenceParser.ArrowContext context)
			{
				if (context == null) return ArrowGreen.__Missing;
				SequenceParser.LifeLineNameContext sourceContext = context.source;
				LifeLineNameGreen source = null;
				if (sourceContext != null)
				{
					source = (LifeLineNameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = LifeLineNameGreen.__Missing;
				}
				SequenceParser.ArrowTypeContext typeContext = context.type;
				ArrowTypeGreen type = null;
				if (typeContext != null)
				{
					type = (ArrowTypeGreen)this.Visit(typeContext);
				}
				else
				{
					type = ArrowTypeGreen.__Missing;
				}
				SequenceParser.LifeLineNameContext targetContext = context.target;
				LifeLineNameGreen target = null;
				if (targetContext != null)
				{
					target = (LifeLineNameGreen)this.Visit(targetContext);
				}
				else
				{
					target = LifeLineNameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), SequenceSyntaxKind.TColon);
				SequenceParser.TextContext textContext = context.text();
				TextGreen text = null;
				if (textContext != null)
				{
					text = (TextGreen)this.Visit(textContext);
				}
				else
				{
					text = TextGreen.__Missing;
				}
				return this.factory.Arrow(source, type, target, tColon, text);
			}
			
			public override GreenNode VisitDestroy(SequenceParser.DestroyContext context)
			{
				if (context == null) return DestroyGreen.__Missing;
				InternalSyntaxToken kDestroy = (InternalSyntaxToken)this.VisitTerminal(context.KDestroy(), SequenceSyntaxKind.KDestroy);
				SequenceParser.LifeLineNameContext lifeLineNameContext = context.lifeLineName();
				LifeLineNameGreen lifeLineName = null;
				if (lifeLineNameContext != null)
				{
					lifeLineName = (LifeLineNameGreen)this.Visit(lifeLineNameContext);
				}
				else
				{
					lifeLineName = LifeLineNameGreen.__Missing;
				}
				return this.factory.Destroy(kDestroy, lifeLineName);
			}
			
			public override GreenNode VisitAlt(SequenceParser.AltContext context)
			{
				if (context == null) return AltGreen.__Missing;
				SequenceParser.AltFragmentContext altFragmentContext = context.altFragment();
				AltFragmentGreen altFragment = null;
				if (altFragmentContext != null)
				{
					altFragment = (AltFragmentGreen)this.Visit(altFragmentContext);
				}
				else
				{
					altFragment = AltFragmentGreen.__Missing;
				}
			    SequenceParser.ElseFragmentContext[] elseFragmentContext = context.elseFragment();
			    var elseFragmentBuilder = _pool.Allocate<ElseFragmentGreen>();
			    for (int i = 0; i < elseFragmentContext.Length; i++)
			    {
			        elseFragmentBuilder.Add((ElseFragmentGreen)this.Visit(elseFragmentContext[i]));
			    }
				var elseFragment = elseFragmentBuilder.ToList();
				_pool.Free(elseFragmentBuilder);
				SequenceParser.EndContext endContext = context.end();
				EndGreen end = null;
				if (endContext != null)
				{
					end = (EndGreen)this.Visit(endContext);
				}
				else
				{
					end = EndGreen.__Missing;
				}
				return this.factory.Alt(altFragment, elseFragment, end);
			}
			
			public override GreenNode VisitAltFragment(SequenceParser.AltFragmentContext context)
			{
				if (context == null) return AltFragmentGreen.__Missing;
				InternalSyntaxToken kAlt = (InternalSyntaxToken)this.VisitTerminal(context.KAlt(), SequenceSyntaxKind.KAlt);
				SequenceParser.TextContext conditionContext = context.condition;
				TextGreen condition = null;
				if (conditionContext != null)
				{
					condition = (TextGreen)this.Visit(conditionContext);
				}
				else
				{
					condition = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				SequenceParser.FragmentBodyContext fragmentBodyContext = context.fragmentBody();
				FragmentBodyGreen fragmentBody = null;
				if (fragmentBodyContext != null)
				{
					fragmentBody = (FragmentBodyGreen)this.Visit(fragmentBodyContext);
				}
				else
				{
					fragmentBody = FragmentBodyGreen.__Missing;
				}
				return this.factory.AltFragment(kAlt, condition, lCrLf, fragmentBody);
			}
			
			public override GreenNode VisitElseFragment(SequenceParser.ElseFragmentContext context)
			{
				if (context == null) return ElseFragmentGreen.__Missing;
				InternalSyntaxToken kElse = (InternalSyntaxToken)this.VisitTerminal(context.KElse(), SequenceSyntaxKind.KElse);
				SequenceParser.TextContext conditionContext = context.condition;
				TextGreen condition = null;
				if (conditionContext != null)
				{
					condition = (TextGreen)this.Visit(conditionContext);
				}
				else
				{
					condition = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				SequenceParser.FragmentBodyContext fragmentBodyContext = context.fragmentBody();
				FragmentBodyGreen fragmentBody = null;
				if (fragmentBodyContext != null)
				{
					fragmentBody = (FragmentBodyGreen)this.Visit(fragmentBodyContext);
				}
				else
				{
					fragmentBody = FragmentBodyGreen.__Missing;
				}
				return this.factory.ElseFragment(kElse, condition, lCrLf, fragmentBody);
			}
			
			public override GreenNode VisitLoop(SequenceParser.LoopContext context)
			{
				if (context == null) return LoopGreen.__Missing;
				SequenceParser.LoopFragmentContext loopFragmentContext = context.loopFragment();
				LoopFragmentGreen loopFragment = null;
				if (loopFragmentContext != null)
				{
					loopFragment = (LoopFragmentGreen)this.Visit(loopFragmentContext);
				}
				else
				{
					loopFragment = LoopFragmentGreen.__Missing;
				}
				SequenceParser.EndContext endContext = context.end();
				EndGreen end = null;
				if (endContext != null)
				{
					end = (EndGreen)this.Visit(endContext);
				}
				else
				{
					end = EndGreen.__Missing;
				}
				return this.factory.Loop(loopFragment, end);
			}
			
			public override GreenNode VisitLoopFragment(SequenceParser.LoopFragmentContext context)
			{
				if (context == null) return LoopFragmentGreen.__Missing;
				InternalSyntaxToken kLoop = (InternalSyntaxToken)this.VisitTerminal(context.KLoop(), SequenceSyntaxKind.KLoop);
				SequenceParser.TextContext conditionContext = context.condition;
				TextGreen condition = null;
				if (conditionContext != null)
				{
					condition = (TextGreen)this.Visit(conditionContext);
				}
				else
				{
					condition = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				SequenceParser.FragmentBodyContext fragmentBodyContext = context.fragmentBody();
				FragmentBodyGreen fragmentBody = null;
				if (fragmentBodyContext != null)
				{
					fragmentBody = (FragmentBodyGreen)this.Visit(fragmentBodyContext);
				}
				else
				{
					fragmentBody = FragmentBodyGreen.__Missing;
				}
				return this.factory.LoopFragment(kLoop, condition, lCrLf, fragmentBody);
			}
			
			public override GreenNode VisitOpt(SequenceParser.OptContext context)
			{
				if (context == null) return OptGreen.__Missing;
				SequenceParser.OptFragmentContext optFragmentContext = context.optFragment();
				OptFragmentGreen optFragment = null;
				if (optFragmentContext != null)
				{
					optFragment = (OptFragmentGreen)this.Visit(optFragmentContext);
				}
				else
				{
					optFragment = OptFragmentGreen.__Missing;
				}
				SequenceParser.EndContext endContext = context.end();
				EndGreen end = null;
				if (endContext != null)
				{
					end = (EndGreen)this.Visit(endContext);
				}
				else
				{
					end = EndGreen.__Missing;
				}
				return this.factory.Opt(optFragment, end);
			}
			
			public override GreenNode VisitOptFragment(SequenceParser.OptFragmentContext context)
			{
				if (context == null) return OptFragmentGreen.__Missing;
				InternalSyntaxToken kOpt = (InternalSyntaxToken)this.VisitTerminal(context.KOpt(), SequenceSyntaxKind.KOpt);
				SequenceParser.TextContext conditionContext = context.condition;
				TextGreen condition = null;
				if (conditionContext != null)
				{
					condition = (TextGreen)this.Visit(conditionContext);
				}
				else
				{
					condition = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				SequenceParser.FragmentBodyContext fragmentBodyContext = context.fragmentBody();
				FragmentBodyGreen fragmentBody = null;
				if (fragmentBodyContext != null)
				{
					fragmentBody = (FragmentBodyGreen)this.Visit(fragmentBodyContext);
				}
				else
				{
					fragmentBody = FragmentBodyGreen.__Missing;
				}
				return this.factory.OptFragment(kOpt, condition, lCrLf, fragmentBody);
			}
			
			public override GreenNode VisitRef(SequenceParser.RefContext context)
			{
				if (context == null) return RefGreen.__Missing;
				SequenceParser.SimpleRefFragmentContext simpleRefFragmentContext = context.simpleRefFragment();
				if (simpleRefFragmentContext != null) 
				{
					return this.factory.Ref((SimpleRefFragmentGreen)this.Visit(simpleRefFragmentContext));
				}
				SequenceParser.MessageRefFragmentContext messageRefFragmentContext = context.messageRefFragment();
				if (messageRefFragmentContext != null) 
				{
					return this.factory.Ref((MessageRefFragmentGreen)this.Visit(messageRefFragmentContext));
				}
				return RefGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleRefFragment(SequenceParser.SimpleRefFragmentContext context)
			{
				if (context == null) return SimpleRefFragmentGreen.__Missing;
				InternalSyntaxToken kRef = (InternalSyntaxToken)this.VisitTerminal(context.KRef(), SequenceSyntaxKind.KRef);
				SequenceParser.TextContext overContext = context.over;
				TextGreen over = null;
				if (overContext != null)
				{
					over = (TextGreen)this.Visit(overContext);
				}
				else
				{
					over = TextGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SequenceParser.TextContext refTextContext = context.refText;
				TextGreen refText = null;
				if (refTextContext != null)
				{
					refText = (TextGreen)this.Visit(refTextContext);
				}
				else
				{
					refText = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				SequenceParser.SimpleBodyContext simpleBodyContext = context.simpleBody();
				SimpleBodyGreen simpleBody = null;
				if (simpleBodyContext != null)
				{
					simpleBody = (SimpleBodyGreen)this.Visit(simpleBodyContext);
				}
				else
				{
					simpleBody = SimpleBodyGreen.__Missing;
				}
				InternalSyntaxToken kEndRef = (InternalSyntaxToken)this.VisitTerminal(context.KEndRef(), SequenceSyntaxKind.KEndRef);
				return this.factory.SimpleRefFragment(kRef, over, tColon, refText, lCrLf, simpleBody, kEndRef);
			}
			
			public override GreenNode VisitMessageRefFragment(SequenceParser.MessageRefFragmentContext context)
			{
				if (context == null) return MessageRefFragmentGreen.__Missing;
				SequenceParser.RefInputContext refInputContext = context.refInput();
				RefInputGreen refInput = null;
				if (refInputContext != null)
				{
					refInput = (RefInputGreen)this.Visit(refInputContext);
				}
				else
				{
					refInput = RefInputGreen.__Missing;
				}
				SequenceParser.SimpleBodyContext simpleBodyContext = context.simpleBody();
				SimpleBodyGreen simpleBody = null;
				if (simpleBodyContext != null)
				{
					simpleBody = (SimpleBodyGreen)this.Visit(simpleBodyContext);
				}
				else
				{
					simpleBody = SimpleBodyGreen.__Missing;
				}
				SequenceParser.RefOutputContext refOutputContext = context.refOutput();
				RefOutputGreen refOutput = null;
				if (refOutputContext != null)
				{
					refOutput = (RefOutputGreen)this.Visit(refOutputContext);
				}
				else
				{
					refOutput = RefOutputGreen.__Missing;
				}
				return this.factory.MessageRefFragment(refInput, simpleBody, refOutput);
			}
			
			public override GreenNode VisitRefInput(SequenceParser.RefInputContext context)
			{
				if (context == null) return RefInputGreen.__Missing;
				SequenceParser.LifeLineNameContext sourceContext = context.source;
				LifeLineNameGreen source = null;
				if (sourceContext != null)
				{
					source = (LifeLineNameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = LifeLineNameGreen.__Missing;
				}
				SequenceParser.ArrowTypeContext sourceTypeContext = context.sourceType;
				ArrowTypeGreen sourceType = null;
				if (sourceTypeContext != null)
				{
					sourceType = (ArrowTypeGreen)this.Visit(sourceTypeContext);
				}
				else
				{
					sourceType = ArrowTypeGreen.__Missing;
				}
				InternalSyntaxToken kRef = (InternalSyntaxToken)this.VisitTerminal(context.KRef(), SequenceSyntaxKind.KRef);
				SequenceParser.TextContext overContext = context.over;
				TextGreen over = null;
				if (overContext != null)
				{
					over = (TextGreen)this.Visit(overContext);
				}
				else
				{
					over = TextGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SequenceParser.TextContext messageContext = context.message;
				TextGreen message = null;
				if (messageContext != null)
				{
					message = (TextGreen)this.Visit(messageContext);
				}
				else
				{
					message = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				return this.factory.RefInput(source, sourceType, kRef, over, tColon, message, lCrLf);
			}
			
			public override GreenNode VisitRefOutput(SequenceParser.RefOutputContext context)
			{
				if (context == null) return RefOutputGreen.__Missing;
				InternalSyntaxToken kEndRef = (InternalSyntaxToken)this.VisitTerminal(context.KEndRef(), SequenceSyntaxKind.KEndRef);
				SequenceParser.TextContext ignoredContext = context.ignored;
				TextGreen ignored = null;
				if (ignoredContext != null)
				{
					ignored = (TextGreen)this.Visit(ignoredContext);
				}
				else
				{
					ignored = TextGreen.__Missing;
				}
				SequenceParser.ArrowTypeContext targetTypeContext = context.targetType;
				ArrowTypeGreen targetType = null;
				if (targetTypeContext != null)
				{
					targetType = (ArrowTypeGreen)this.Visit(targetTypeContext);
				}
				else
				{
					targetType = ArrowTypeGreen.__Missing;
				}
				SequenceParser.LifeLineNameContext targetContext = context.target;
				LifeLineNameGreen target = null;
				if (targetContext != null)
				{
					target = (LifeLineNameGreen)this.Visit(targetContext);
				}
				else
				{
					target = LifeLineNameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), SequenceSyntaxKind.TColon);
				SequenceParser.TextContext messageContext = context.message;
				TextGreen message = null;
				if (messageContext != null)
				{
					message = (TextGreen)this.Visit(messageContext);
				}
				else
				{
					message = TextGreen.__Missing;
				}
				return this.factory.RefOutput(kEndRef, ignored, targetType, target, tColon, message);
			}
			
			public override GreenNode VisitFragmentBody(SequenceParser.FragmentBodyContext context)
			{
				if (context == null) return FragmentBodyGreen.__Missing;
			    SequenceParser.LineContext[] lineContext = context.line();
			    var lineBuilder = _pool.Allocate<LineGreen>();
			    for (int i = 0; i < lineContext.Length; i++)
			    {
			        lineBuilder.Add((LineGreen)this.Visit(lineContext[i]));
			    }
				var line = lineBuilder.ToList();
				_pool.Free(lineBuilder);
				return this.factory.FragmentBody(line);
			}
			
			public override GreenNode VisitEnd(SequenceParser.EndContext context)
			{
				if (context == null) return EndGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), SequenceSyntaxKind.KEnd);
				SequenceParser.TextContext textContext = context.text();
				TextGreen text = null;
				if (textContext != null)
				{
					text = (TextGreen)this.Visit(textContext);
				}
				else
				{
					text = TextGreen.__Missing;
				}
				return this.factory.End(kEnd, text);
			}
			
			public override GreenNode VisitNote(SequenceParser.NoteContext context)
			{
				if (context == null) return NoteGreen.__Missing;
				SequenceParser.SingleLineNoteContext singleLineNoteContext = context.singleLineNote();
				if (singleLineNoteContext != null) 
				{
					return this.factory.Note((SingleLineNoteGreen)this.Visit(singleLineNoteContext));
				}
				SequenceParser.MultiLineNoteContext multiLineNoteContext = context.multiLineNote();
				if (multiLineNoteContext != null) 
				{
					return this.factory.Note((MultiLineNoteGreen)this.Visit(multiLineNoteContext));
				}
				return NoteGreen.__Missing;
			}
			
			public override GreenNode VisitSingleLineNote(SequenceParser.SingleLineNoteContext context)
			{
				if (context == null) return SingleLineNoteGreen.__Missing;
				InternalSyntaxToken kNote = (InternalSyntaxToken)this.VisitTerminal(context.KNote(), SequenceSyntaxKind.KNote);
				SequenceParser.TextContext positionContext = context.position;
				TextGreen position = null;
				if (positionContext != null)
				{
					position = (TextGreen)this.Visit(positionContext);
				}
				else
				{
					position = TextGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), SequenceSyntaxKind.TColon);
				SequenceParser.TextContext noteTextContext = context.noteText;
				TextGreen noteText = null;
				if (noteTextContext != null)
				{
					noteText = (TextGreen)this.Visit(noteTextContext);
				}
				else
				{
					noteText = TextGreen.__Missing;
				}
				return this.factory.SingleLineNote(kNote, position, tColon, noteText);
			}
			
			public override GreenNode VisitMultiLineNote(SequenceParser.MultiLineNoteContext context)
			{
				if (context == null) return MultiLineNoteGreen.__Missing;
				InternalSyntaxToken kNote = (InternalSyntaxToken)this.VisitTerminal(context.KNote(), SequenceSyntaxKind.KNote);
				SequenceParser.SimpleBodyContext simpleBodyContext = context.simpleBody();
				SimpleBodyGreen simpleBody = null;
				if (simpleBodyContext != null)
				{
					simpleBody = (SimpleBodyGreen)this.Visit(simpleBodyContext);
				}
				else
				{
					simpleBody = SimpleBodyGreen.__Missing;
				}
				InternalSyntaxToken kEndNote = (InternalSyntaxToken)this.VisitTerminal(context.KEndNote(), SequenceSyntaxKind.KEndNote);
				return this.factory.MultiLineNote(kNote, simpleBody, kEndNote);
			}
			
			public override GreenNode VisitSimpleBody(SequenceParser.SimpleBodyContext context)
			{
				if (context == null) return SimpleBodyGreen.__Missing;
			    SequenceParser.SimpleLineContext[] simpleLineContext = context.simpleLine();
			    var simpleLineBuilder = _pool.Allocate<SimpleLineGreen>();
			    for (int i = 0; i < simpleLineContext.Length; i++)
			    {
			        simpleLineBuilder.Add((SimpleLineGreen)this.Visit(simpleLineContext[i]));
			    }
				var simpleLine = simpleLineBuilder.ToList();
				_pool.Free(simpleLineBuilder);
				return this.factory.SimpleBody(simpleLine);
			}
			
			public override GreenNode VisitSimpleLine(SequenceParser.SimpleLineContext context)
			{
				if (context == null) return SimpleLineGreen.__Missing;
				SequenceParser.TextContext textContext = context.text();
				TextGreen text = null;
				if (textContext != null)
				{
					text = (TextGreen)this.Visit(textContext);
				}
				else
				{
					text = TextGreen.__Missing;
				}
				InternalSyntaxToken lCrLf = (InternalSyntaxToken)this.VisitTerminal(context.LCrLf(), SequenceSyntaxKind.LCrLf);
				return this.factory.SimpleLine(text, lCrLf);
			}
			
			public override GreenNode VisitArrowType(SequenceParser.ArrowTypeContext context)
			{
				if (context == null) return ArrowTypeGreen.__Missing;
				InternalSyntaxToken arrowType = null;
				if (context.TSync() != null)
				{
					arrowType = (InternalSyntaxToken)this.VisitTerminal(context.TSync());
				}
				else 	if (context.TAsync() != null)
				{
					arrowType = (InternalSyntaxToken)this.VisitTerminal(context.TAsync());
				}
				else 	if (context.TReturn() != null)
				{
					arrowType = (InternalSyntaxToken)this.VisitTerminal(context.TReturn());
				}
				else 	if (context.TCreate() != null)
				{
					arrowType = (InternalSyntaxToken)this.VisitTerminal(context.TCreate());
				}
				else
				{
					arrowType = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.ArrowType(arrowType);
			}
			
			public override GreenNode VisitLifeLineName(SequenceParser.LifeLineNameContext context)
			{
				if (context == null) return LifeLineNameGreen.__Missing;
				SequenceParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.LifeLineName(name);
			}
			
			public override GreenNode VisitName(SequenceParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				SequenceParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				else
				{
					identifier = IdentifierGreen.__Missing;
				}
				return this.factory.Name(identifier);
			}
			
			public override GreenNode VisitIdentifier(SequenceParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				SequenceParser.TextContext textContext = context.text();
				TextGreen text = null;
				if (textContext != null)
				{
					text = (TextGreen)this.Visit(textContext);
				}
				else
				{
					text = TextGreen.__Missing;
				}
				return this.factory.Identifier(text);
			}
			
			public override GreenNode VisitText(SequenceParser.TextContext context)
			{
				if (context == null) return TextGreen.__Missing;
			    SequenceParser.IdentifierPartContext[] identifierPartContext = context.identifierPart();
			    var identifierPartBuilder = _pool.Allocate<IdentifierPartGreen>();
			    for (int i = 0; i < identifierPartContext.Length; i++)
			    {
			        identifierPartBuilder.Add((IdentifierPartGreen)this.Visit(identifierPartContext[i]));
			    }
				var identifierPart = identifierPartBuilder.ToList();
				_pool.Free(identifierPartBuilder);
				return this.factory.Text(identifierPart);
			}
			
			public override GreenNode VisitIdentifierPart(SequenceParser.IdentifierPartContext context)
			{
				if (context == null) return IdentifierPartGreen.__Missing;
				InternalSyntaxToken lIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.LIdentifier(), SequenceSyntaxKind.LIdentifier);
				return this.factory.IdentifierPart(lIdentifier);
			}
        }
    }
}

