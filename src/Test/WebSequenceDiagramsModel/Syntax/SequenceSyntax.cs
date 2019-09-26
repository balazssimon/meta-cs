// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;

namespace WebSequenceDiagramsModel.Syntax
{
    public abstract class SequenceSyntaxNode : LanguageSyntaxNode
    {
        protected SequenceSyntaxNode(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected SequenceSyntaxNode(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new SequenceLanguage Language => SequenceLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new SequenceSyntaxKind Kind => (SequenceSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return SequenceSyntaxTree.CreateWithoutClone(this);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is ISequenceSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is ISequenceSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is ISequenceSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(ISequenceSyntaxVisitor visitor);
    }

	
	public sealed class MainSyntax : SequenceSyntaxNode, ICompilationUnitSyntax
	{
	    private InteractionSyntax interaction;
	
	    public MainSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public InteractionSyntax Interaction 
		{ 
			get { return this.GetRed(ref this.interaction, 0); } 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.interaction, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.interaction;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithInteraction(InteractionSyntax interaction)
		{
			return this.Update(Interaction, this.EndOfFileToken);
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eof)
		{
			return this.Update(this.Interaction, EndOfFileToken);
		}
	
	    public MainSyntax Update(InteractionSyntax interaction, SyntaxToken eof)
	    {
	        if (this.Interaction != interaction ||
				this.EndOfFileToken != eof)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Main(interaction, eof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class InteractionSyntax : SequenceSyntaxNode
	{
	    private SyntaxNode line;
	
	    public InteractionSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InteractionSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<LineSyntax> Line 
		{ 
			get
			{
				var red = this.GetRed(ref this.line, 0);
				if (red != null) return new SyntaxList<LineSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.line, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.line;
				default: return null;
	        }
	    }
	
	    public InteractionSyntax WithLine(SyntaxList<LineSyntax> line)
		{
			return this.Update(Line);
		}
	
	    public InteractionSyntax AddLine(params LineSyntax[] line)
		{
			return this.WithLine(this.Line.AddRange(line));
		}
	
	    public InteractionSyntax Update(SyntaxList<LineSyntax> line)
	    {
	        if (this.Line != line)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Interaction(line);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InteractionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInteraction(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInteraction(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitInteraction(this);
	    }
	}
	
	public sealed class LineSyntax : SequenceSyntaxNode
	{
	    private DeclarationSyntax declaration;
	
	    public LineSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LineSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public DeclarationSyntax Declaration 
		{ 
			get { return this.GetRed(ref this.declaration, 0); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.LineGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.declaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.declaration;
				default: return null;
	        }
	    }
	
	    public LineSyntax WithDeclaration(DeclarationSyntax declaration)
		{
			return this.Update(Declaration, this.LCrLf);
		}
	
	    public LineSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.Declaration, LCrLf);
		}
	
	    public LineSyntax Update(DeclarationSyntax declaration, SyntaxToken lCrLf)
	    {
	        if (this.Declaration != declaration ||
				this.LCrLf != lCrLf)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Line(declaration, lCrLf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LineSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLine(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLine(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitLine(this);
	    }
	}
	
	public sealed class DeclarationSyntax : SequenceSyntaxNode
	{
	    private TitleSyntax title;
	    private DestroySyntax destroy;
	    private ArrowSyntax arrow;
	    private AltSyntax alt;
	    private OptSyntax opt;
	    private LoopSyntax loop;
	    private RefSyntax _ref;
	    private NoteSyntax note;
	
	    public DeclarationSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TitleSyntax Title 
		{ 
			get { return this.GetRed(ref this.title, 0); } 
		}
	    public DestroySyntax Destroy 
		{ 
			get { return this.GetRed(ref this.destroy, 1); } 
		}
	    public ArrowSyntax Arrow 
		{ 
			get { return this.GetRed(ref this.arrow, 2); } 
		}
	    public AltSyntax Alt 
		{ 
			get { return this.GetRed(ref this.alt, 3); } 
		}
	    public OptSyntax Opt 
		{ 
			get { return this.GetRed(ref this.opt, 4); } 
		}
	    public LoopSyntax Loop 
		{ 
			get { return this.GetRed(ref this.loop, 5); } 
		}
	    public RefSyntax Ref 
		{ 
			get { return this.GetRed(ref this._ref, 6); } 
		}
	    public NoteSyntax Note 
		{ 
			get { return this.GetRed(ref this.note, 7); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.title, 0);
				case 1: return this.GetRed(ref this.destroy, 1);
				case 2: return this.GetRed(ref this.arrow, 2);
				case 3: return this.GetRed(ref this.alt, 3);
				case 4: return this.GetRed(ref this.opt, 4);
				case 5: return this.GetRed(ref this.loop, 5);
				case 6: return this.GetRed(ref this._ref, 6);
				case 7: return this.GetRed(ref this.note, 7);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.title;
				case 1: return this.destroy;
				case 2: return this.arrow;
				case 3: return this.alt;
				case 4: return this.opt;
				case 5: return this.loop;
				case 6: return this._ref;
				case 7: return this.note;
				default: return null;
	        }
	    }
	
	    public DeclarationSyntax WithTitle(TitleSyntax title)
		{
			return this.Update(title);
		}
	
	    public DeclarationSyntax WithDestroy(DestroySyntax destroy)
		{
			return this.Update(destroy);
		}
	
	    public DeclarationSyntax WithArrow(ArrowSyntax arrow)
		{
			return this.Update(arrow);
		}
	
	    public DeclarationSyntax WithAlt(AltSyntax alt)
		{
			return this.Update(alt);
		}
	
	    public DeclarationSyntax WithOpt(OptSyntax opt)
		{
			return this.Update(opt);
		}
	
	    public DeclarationSyntax WithLoop(LoopSyntax loop)
		{
			return this.Update(loop);
		}
	
	    public DeclarationSyntax WithRef(RefSyntax _ref)
		{
			return this.Update(_ref);
		}
	
	    public DeclarationSyntax WithNote(NoteSyntax note)
		{
			return this.Update(note);
		}
	
	    public DeclarationSyntax Update(TitleSyntax title)
	    {
	        if (this.Title != title)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(title);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(DestroySyntax destroy)
	    {
	        if (this.Destroy != destroy)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(destroy);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(ArrowSyntax arrow)
	    {
	        if (this.Arrow != arrow)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(arrow);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(AltSyntax alt)
	    {
	        if (this.Alt != alt)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(alt);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(OptSyntax opt)
	    {
	        if (this.Opt != opt)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(opt);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(LoopSyntax loop)
	    {
	        if (this.Loop != loop)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(loop);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(RefSyntax _ref)
	    {
	        if (this.Ref != _ref)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(_ref);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(NoteSyntax note)
	    {
	        if (this.Note != note)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Declaration(note);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class TitleSyntax : SequenceSyntaxNode
	{
	    private TextSyntax text;
	
	    public TitleSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TitleSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTitle 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.TitleGreen)this.Green;
				var greenToken = green.KTitle;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Text 
		{ 
			get { return this.GetRed(ref this.text, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.text, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.text;
				default: return null;
	        }
	    }
	
	    public TitleSyntax WithKTitle(SyntaxToken kTitle)
		{
			return this.Update(KTitle, this.Text);
		}
	
	    public TitleSyntax WithText(TextSyntax text)
		{
			return this.Update(this.KTitle, Text);
		}
	
	    public TitleSyntax Update(SyntaxToken kTitle, TextSyntax text)
	    {
	        if (this.KTitle != kTitle ||
				this.Text != text)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Title(kTitle, text);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TitleSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTitle(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTitle(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitTitle(this);
	    }
	}
	
	public sealed class ArrowSyntax : SequenceSyntaxNode
	{
	    private LifeLineNameSyntax source;
	    private ArrowTypeSyntax type;
	    private LifeLineNameSyntax target;
	    private TextSyntax text;
	
	    public ArrowSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrowSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LifeLineNameSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 0); } 
		}
	    public ArrowTypeSyntax Type 
		{ 
			get { return this.GetRed(ref this.type, 1); } 
		}
	    public LifeLineNameSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.ArrowGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public TextSyntax Text 
		{ 
			get { return this.GetRed(ref this.text, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.source, 0);
				case 1: return this.GetRed(ref this.type, 1);
				case 2: return this.GetRed(ref this.target, 2);
				case 4: return this.GetRed(ref this.text, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.source;
				case 1: return this.type;
				case 2: return this.target;
				case 4: return this.text;
				default: return null;
	        }
	    }
	
	    public ArrowSyntax WithSource(LifeLineNameSyntax source)
		{
			return this.Update(Source, this.Type, this.Target, this.TColon, this.Text);
		}
	
	    public ArrowSyntax WithType(ArrowTypeSyntax type)
		{
			return this.Update(this.Source, Type, this.Target, this.TColon, this.Text);
		}
	
	    public ArrowSyntax WithTarget(LifeLineNameSyntax target)
		{
			return this.Update(this.Source, this.Type, Target, this.TColon, this.Text);
		}
	
	    public ArrowSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Source, this.Type, this.Target, TColon, this.Text);
		}
	
	    public ArrowSyntax WithText(TextSyntax text)
		{
			return this.Update(this.Source, this.Type, this.Target, this.TColon, Text);
		}
	
	    public ArrowSyntax Update(LifeLineNameSyntax source, ArrowTypeSyntax type, LifeLineNameSyntax target, SyntaxToken tColon, TextSyntax text)
	    {
	        if (this.Source != source ||
				this.Type != type ||
				this.Target != target ||
				this.TColon != tColon ||
				this.Text != text)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Arrow(source, type, target, tColon, text);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrowSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow(this);
	    }
	}
	
	public sealed class DestroySyntax : SequenceSyntaxNode
	{
	    private LifeLineNameSyntax lifeLineName;
	
	    public DestroySyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DestroySyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KDestroy 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.DestroyGreen)this.Green;
				var greenToken = green.KDestroy;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public LifeLineNameSyntax LifeLineName 
		{ 
			get { return this.GetRed(ref this.lifeLineName, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.lifeLineName, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.lifeLineName;
				default: return null;
	        }
	    }
	
	    public DestroySyntax WithKDestroy(SyntaxToken kDestroy)
		{
			return this.Update(KDestroy, this.LifeLineName);
		}
	
	    public DestroySyntax WithLifeLineName(LifeLineNameSyntax lifeLineName)
		{
			return this.Update(this.KDestroy, LifeLineName);
		}
	
	    public DestroySyntax Update(SyntaxToken kDestroy, LifeLineNameSyntax lifeLineName)
	    {
	        if (this.KDestroy != kDestroy ||
				this.LifeLineName != lifeLineName)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Destroy(kDestroy, lifeLineName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DestroySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDestroy(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDestroy(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitDestroy(this);
	    }
	}
	
	public sealed class AltSyntax : SequenceSyntaxNode
	{
	    private AltFragmentSyntax altFragment;
	    private SyntaxNode elseFragment;
	    private EndSyntax end;
	
	    public AltSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AltSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AltFragmentSyntax AltFragment 
		{ 
			get { return this.GetRed(ref this.altFragment, 0); } 
		}
	    public SyntaxList<ElseFragmentSyntax> ElseFragment 
		{ 
			get
			{
				var red = this.GetRed(ref this.elseFragment, 1);
				if (red != null) return new SyntaxList<ElseFragmentSyntax>(red);
				return default;
			} 
		}
	    public EndSyntax End 
		{ 
			get { return this.GetRed(ref this.end, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.altFragment, 0);
				case 1: return this.GetRed(ref this.elseFragment, 1);
				case 2: return this.GetRed(ref this.end, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.altFragment;
				case 1: return this.elseFragment;
				case 2: return this.end;
				default: return null;
	        }
	    }
	
	    public AltSyntax WithAltFragment(AltFragmentSyntax altFragment)
		{
			return this.Update(AltFragment, this.ElseFragment, this.End);
		}
	
	    public AltSyntax WithElseFragment(SyntaxList<ElseFragmentSyntax> elseFragment)
		{
			return this.Update(this.AltFragment, ElseFragment, this.End);
		}
	
	    public AltSyntax AddElseFragment(params ElseFragmentSyntax[] elseFragment)
		{
			return this.WithElseFragment(this.ElseFragment.AddRange(elseFragment));
		}
	
	    public AltSyntax WithEnd(EndSyntax end)
		{
			return this.Update(this.AltFragment, this.ElseFragment, End);
		}
	
	    public AltSyntax Update(AltFragmentSyntax altFragment, SyntaxList<ElseFragmentSyntax> elseFragment, EndSyntax end)
	    {
	        if (this.AltFragment != altFragment ||
				this.ElseFragment != elseFragment ||
				this.End != end)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Alt(altFragment, elseFragment, end);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AltSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAlt(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAlt(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitAlt(this);
	    }
	}
	
	public sealed class AltFragmentSyntax : SequenceSyntaxNode
	{
	    private TextSyntax condition;
	    private FragmentBodySyntax fragmentBody;
	
	    public AltFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AltFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAlt 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.AltFragmentGreen)this.Green;
				var greenToken = green.KAlt;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 1); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.AltFragmentGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public FragmentBodySyntax FragmentBody 
		{ 
			get { return this.GetRed(ref this.fragmentBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.condition, 1);
				case 3: return this.GetRed(ref this.fragmentBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.condition;
				case 3: return this.fragmentBody;
				default: return null;
	        }
	    }
	
	    public AltFragmentSyntax WithKAlt(SyntaxToken kAlt)
		{
			return this.Update(KAlt, this.Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public AltFragmentSyntax WithCondition(TextSyntax condition)
		{
			return this.Update(this.KAlt, Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public AltFragmentSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.KAlt, this.Condition, LCrLf, this.FragmentBody);
		}
	
	    public AltFragmentSyntax WithFragmentBody(FragmentBodySyntax fragmentBody)
		{
			return this.Update(this.KAlt, this.Condition, this.LCrLf, FragmentBody);
		}
	
	    public AltFragmentSyntax Update(SyntaxToken kAlt, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
	    {
	        if (this.KAlt != kAlt ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.AltFragment(kAlt, condition, lCrLf, fragmentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AltFragmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAltFragment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAltFragment(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitAltFragment(this);
	    }
	}
	
	public sealed class ElseFragmentSyntax : SequenceSyntaxNode
	{
	    private TextSyntax condition;
	    private FragmentBodySyntax fragmentBody;
	
	    public ElseFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElseFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KElse 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.ElseFragmentGreen)this.Green;
				var greenToken = green.KElse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 1); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.ElseFragmentGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public FragmentBodySyntax FragmentBody 
		{ 
			get { return this.GetRed(ref this.fragmentBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.condition, 1);
				case 3: return this.GetRed(ref this.fragmentBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.condition;
				case 3: return this.fragmentBody;
				default: return null;
	        }
	    }
	
	    public ElseFragmentSyntax WithKElse(SyntaxToken kElse)
		{
			return this.Update(KElse, this.Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public ElseFragmentSyntax WithCondition(TextSyntax condition)
		{
			return this.Update(this.KElse, Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public ElseFragmentSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.KElse, this.Condition, LCrLf, this.FragmentBody);
		}
	
	    public ElseFragmentSyntax WithFragmentBody(FragmentBodySyntax fragmentBody)
		{
			return this.Update(this.KElse, this.Condition, this.LCrLf, FragmentBody);
		}
	
	    public ElseFragmentSyntax Update(SyntaxToken kElse, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
	    {
	        if (this.KElse != kElse ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.ElseFragment(kElse, condition, lCrLf, fragmentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseFragmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElseFragment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElseFragment(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitElseFragment(this);
	    }
	}
	
	public sealed class LoopSyntax : SequenceSyntaxNode
	{
	    private LoopFragmentSyntax loopFragment;
	    private EndSyntax end;
	
	    public LoopSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LoopFragmentSyntax LoopFragment 
		{ 
			get { return this.GetRed(ref this.loopFragment, 0); } 
		}
	    public EndSyntax End 
		{ 
			get { return this.GetRed(ref this.end, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.loopFragment, 0);
				case 1: return this.GetRed(ref this.end, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.loopFragment;
				case 1: return this.end;
				default: return null;
	        }
	    }
	
	    public LoopSyntax WithLoopFragment(LoopFragmentSyntax loopFragment)
		{
			return this.Update(LoopFragment, this.End);
		}
	
	    public LoopSyntax WithEnd(EndSyntax end)
		{
			return this.Update(this.LoopFragment, End);
		}
	
	    public LoopSyntax Update(LoopFragmentSyntax loopFragment, EndSyntax end)
	    {
	        if (this.LoopFragment != loopFragment ||
				this.End != end)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Loop(loopFragment, end);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoop(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoop(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitLoop(this);
	    }
	}
	
	public sealed class LoopFragmentSyntax : SequenceSyntaxNode
	{
	    private TextSyntax condition;
	    private FragmentBodySyntax fragmentBody;
	
	    public LoopFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KLoop 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.LoopFragmentGreen)this.Green;
				var greenToken = green.KLoop;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 1); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.LoopFragmentGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public FragmentBodySyntax FragmentBody 
		{ 
			get { return this.GetRed(ref this.fragmentBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.condition, 1);
				case 3: return this.GetRed(ref this.fragmentBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.condition;
				case 3: return this.fragmentBody;
				default: return null;
	        }
	    }
	
	    public LoopFragmentSyntax WithKLoop(SyntaxToken kLoop)
		{
			return this.Update(KLoop, this.Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public LoopFragmentSyntax WithCondition(TextSyntax condition)
		{
			return this.Update(this.KLoop, Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public LoopFragmentSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.KLoop, this.Condition, LCrLf, this.FragmentBody);
		}
	
	    public LoopFragmentSyntax WithFragmentBody(FragmentBodySyntax fragmentBody)
		{
			return this.Update(this.KLoop, this.Condition, this.LCrLf, FragmentBody);
		}
	
	    public LoopFragmentSyntax Update(SyntaxToken kLoop, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
	    {
	        if (this.KLoop != kLoop ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.LoopFragment(kLoop, condition, lCrLf, fragmentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopFragmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopFragment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopFragment(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopFragment(this);
	    }
	}
	
	public sealed class OptSyntax : SequenceSyntaxNode
	{
	    private OptFragmentSyntax optFragment;
	    private EndSyntax end;
	
	    public OptSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OptSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OptFragmentSyntax OptFragment 
		{ 
			get { return this.GetRed(ref this.optFragment, 0); } 
		}
	    public EndSyntax End 
		{ 
			get { return this.GetRed(ref this.end, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.optFragment, 0);
				case 1: return this.GetRed(ref this.end, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.optFragment;
				case 1: return this.end;
				default: return null;
	        }
	    }
	
	    public OptSyntax WithOptFragment(OptFragmentSyntax optFragment)
		{
			return this.Update(OptFragment, this.End);
		}
	
	    public OptSyntax WithEnd(EndSyntax end)
		{
			return this.Update(this.OptFragment, End);
		}
	
	    public OptSyntax Update(OptFragmentSyntax optFragment, EndSyntax end)
	    {
	        if (this.OptFragment != optFragment ||
				this.End != end)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Opt(optFragment, end);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OptSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOpt(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOpt(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitOpt(this);
	    }
	}
	
	public sealed class OptFragmentSyntax : SequenceSyntaxNode
	{
	    private TextSyntax condition;
	    private FragmentBodySyntax fragmentBody;
	
	    public OptFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OptFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KOpt 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.OptFragmentGreen)this.Green;
				var greenToken = green.KOpt;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 1); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.OptFragmentGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public FragmentBodySyntax FragmentBody 
		{ 
			get { return this.GetRed(ref this.fragmentBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.condition, 1);
				case 3: return this.GetRed(ref this.fragmentBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.condition;
				case 3: return this.fragmentBody;
				default: return null;
	        }
	    }
	
	    public OptFragmentSyntax WithKOpt(SyntaxToken kOpt)
		{
			return this.Update(KOpt, this.Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public OptFragmentSyntax WithCondition(TextSyntax condition)
		{
			return this.Update(this.KOpt, Condition, this.LCrLf, this.FragmentBody);
		}
	
	    public OptFragmentSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.KOpt, this.Condition, LCrLf, this.FragmentBody);
		}
	
	    public OptFragmentSyntax WithFragmentBody(FragmentBodySyntax fragmentBody)
		{
			return this.Update(this.KOpt, this.Condition, this.LCrLf, FragmentBody);
		}
	
	    public OptFragmentSyntax Update(SyntaxToken kOpt, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
	    {
	        if (this.KOpt != kOpt ||
				this.Condition != condition ||
				this.LCrLf != lCrLf ||
				this.FragmentBody != fragmentBody)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.OptFragment(kOpt, condition, lCrLf, fragmentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OptFragmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOptFragment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOptFragment(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitOptFragment(this);
	    }
	}
	
	public sealed class RefSyntax : SequenceSyntaxNode
	{
	    private SimpleRefFragmentSyntax simpleRefFragment;
	    private MessageRefFragmentSyntax messageRefFragment;
	
	    public RefSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RefSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleRefFragmentSyntax SimpleRefFragment 
		{ 
			get { return this.GetRed(ref this.simpleRefFragment, 0); } 
		}
	    public MessageRefFragmentSyntax MessageRefFragment 
		{ 
			get { return this.GetRed(ref this.messageRefFragment, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleRefFragment, 0);
				case 1: return this.GetRed(ref this.messageRefFragment, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleRefFragment;
				case 1: return this.messageRefFragment;
				default: return null;
	        }
	    }
	
	    public RefSyntax WithSimpleRefFragment(SimpleRefFragmentSyntax simpleRefFragment)
		{
			return this.Update(simpleRefFragment);
		}
	
	    public RefSyntax WithMessageRefFragment(MessageRefFragmentSyntax messageRefFragment)
		{
			return this.Update(messageRefFragment);
		}
	
	    public RefSyntax Update(SimpleRefFragmentSyntax simpleRefFragment)
	    {
	        if (this.SimpleRefFragment != simpleRefFragment)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Ref(simpleRefFragment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public RefSyntax Update(MessageRefFragmentSyntax messageRefFragment)
	    {
	        if (this.MessageRefFragment != messageRefFragment)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Ref(messageRefFragment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRef(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitRef(this);
	    }
	}
	
	public sealed class SimpleRefFragmentSyntax : SequenceSyntaxNode
	{
	    private TextSyntax over;
	    private TextSyntax refText;
	    private SimpleBodySyntax simpleBody;
	
	    public SimpleRefFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleRefFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRef 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SimpleRefFragmentGreen)this.Green;
				var greenToken = green.KRef;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Over 
		{ 
			get { return this.GetRed(ref this.over, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SimpleRefFragmentGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TextSyntax RefText 
		{ 
			get { return this.GetRed(ref this.refText, 3); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SimpleRefFragmentGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public SimpleBodySyntax SimpleBody 
		{ 
			get { return this.GetRed(ref this.simpleBody, 5); } 
		}
	    public SyntaxToken KEndRef 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SimpleRefFragmentGreen)this.Green;
				var greenToken = green.KEndRef;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.over, 1);
				case 3: return this.GetRed(ref this.refText, 3);
				case 5: return this.GetRed(ref this.simpleBody, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.over;
				case 3: return this.refText;
				case 5: return this.simpleBody;
				default: return null;
	        }
	    }
	
	    public SimpleRefFragmentSyntax WithKRef(SyntaxToken kRef)
		{
			return this.Update(KRef, this.Over, this.TColon, this.RefText, this.LCrLf, this.SimpleBody, this.KEndRef);
		}
	
	    public SimpleRefFragmentSyntax WithOver(TextSyntax over)
		{
			return this.Update(this.KRef, Over, this.TColon, this.RefText, this.LCrLf, this.SimpleBody, this.KEndRef);
		}
	
	    public SimpleRefFragmentSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KRef, this.Over, TColon, this.RefText, this.LCrLf, this.SimpleBody, this.KEndRef);
		}
	
	    public SimpleRefFragmentSyntax WithRefText(TextSyntax refText)
		{
			return this.Update(this.KRef, this.Over, this.TColon, RefText, this.LCrLf, this.SimpleBody, this.KEndRef);
		}
	
	    public SimpleRefFragmentSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.KRef, this.Over, this.TColon, this.RefText, LCrLf, this.SimpleBody, this.KEndRef);
		}
	
	    public SimpleRefFragmentSyntax WithSimpleBody(SimpleBodySyntax simpleBody)
		{
			return this.Update(this.KRef, this.Over, this.TColon, this.RefText, this.LCrLf, SimpleBody, this.KEndRef);
		}
	
	    public SimpleRefFragmentSyntax WithKEndRef(SyntaxToken kEndRef)
		{
			return this.Update(this.KRef, this.Over, this.TColon, this.RefText, this.LCrLf, this.SimpleBody, KEndRef);
		}
	
	    public SimpleRefFragmentSyntax Update(SyntaxToken kRef, TextSyntax over, SyntaxToken tColon, TextSyntax refText, SyntaxToken lCrLf, SimpleBodySyntax simpleBody, SyntaxToken kEndRef)
	    {
	        if (this.KRef != kRef ||
				this.Over != over ||
				this.TColon != tColon ||
				this.RefText != refText ||
				this.LCrLf != lCrLf ||
				this.SimpleBody != simpleBody ||
				this.KEndRef != kEndRef)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.SimpleRefFragment(kRef, over, tColon, refText, lCrLf, simpleBody, kEndRef);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleRefFragmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleRefFragment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleRefFragment(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleRefFragment(this);
	    }
	}
	
	public sealed class MessageRefFragmentSyntax : SequenceSyntaxNode
	{
	    private RefInputSyntax refInput;
	    private SimpleBodySyntax simpleBody;
	    private RefOutputSyntax refOutput;
	
	    public MessageRefFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MessageRefFragmentSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public RefInputSyntax RefInput 
		{ 
			get { return this.GetRed(ref this.refInput, 0); } 
		}
	    public SimpleBodySyntax SimpleBody 
		{ 
			get { return this.GetRed(ref this.simpleBody, 1); } 
		}
	    public RefOutputSyntax RefOutput 
		{ 
			get { return this.GetRed(ref this.refOutput, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.refInput, 0);
				case 1: return this.GetRed(ref this.simpleBody, 1);
				case 2: return this.GetRed(ref this.refOutput, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.refInput;
				case 1: return this.simpleBody;
				case 2: return this.refOutput;
				default: return null;
	        }
	    }
	
	    public MessageRefFragmentSyntax WithRefInput(RefInputSyntax refInput)
		{
			return this.Update(RefInput, this.SimpleBody, this.RefOutput);
		}
	
	    public MessageRefFragmentSyntax WithSimpleBody(SimpleBodySyntax simpleBody)
		{
			return this.Update(this.RefInput, SimpleBody, this.RefOutput);
		}
	
	    public MessageRefFragmentSyntax WithRefOutput(RefOutputSyntax refOutput)
		{
			return this.Update(this.RefInput, this.SimpleBody, RefOutput);
		}
	
	    public MessageRefFragmentSyntax Update(RefInputSyntax refInput, SimpleBodySyntax simpleBody, RefOutputSyntax refOutput)
	    {
	        if (this.RefInput != refInput ||
				this.SimpleBody != simpleBody ||
				this.RefOutput != refOutput)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.MessageRefFragment(refInput, simpleBody, refOutput);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MessageRefFragmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMessageRefFragment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMessageRefFragment(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitMessageRefFragment(this);
	    }
	}
	
	public sealed class RefInputSyntax : SequenceSyntaxNode
	{
	    private LifeLineNameSyntax source;
	    private ArrowTypeSyntax sourceType;
	    private TextSyntax over;
	    private TextSyntax message;
	
	    public RefInputSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RefInputSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LifeLineNameSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 0); } 
		}
	    public ArrowTypeSyntax SourceType 
		{ 
			get { return this.GetRed(ref this.sourceType, 1); } 
		}
	    public SyntaxToken KRef 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.RefInputGreen)this.Green;
				var greenToken = green.KRef;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TextSyntax Over 
		{ 
			get { return this.GetRed(ref this.over, 3); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.RefInputGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public TextSyntax Message 
		{ 
			get { return this.GetRed(ref this.message, 5); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.RefInputGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.source, 0);
				case 1: return this.GetRed(ref this.sourceType, 1);
				case 3: return this.GetRed(ref this.over, 3);
				case 5: return this.GetRed(ref this.message, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.source;
				case 1: return this.sourceType;
				case 3: return this.over;
				case 5: return this.message;
				default: return null;
	        }
	    }
	
	    public RefInputSyntax WithSource(LifeLineNameSyntax source)
		{
			return this.Update(Source, this.SourceType, this.KRef, this.Over, this.TColon, this.Message, this.LCrLf);
		}
	
	    public RefInputSyntax WithSourceType(ArrowTypeSyntax sourceType)
		{
			return this.Update(this.Source, SourceType, this.KRef, this.Over, this.TColon, this.Message, this.LCrLf);
		}
	
	    public RefInputSyntax WithKRef(SyntaxToken kRef)
		{
			return this.Update(this.Source, this.SourceType, KRef, this.Over, this.TColon, this.Message, this.LCrLf);
		}
	
	    public RefInputSyntax WithOver(TextSyntax over)
		{
			return this.Update(this.Source, this.SourceType, this.KRef, Over, this.TColon, this.Message, this.LCrLf);
		}
	
	    public RefInputSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Source, this.SourceType, this.KRef, this.Over, TColon, this.Message, this.LCrLf);
		}
	
	    public RefInputSyntax WithMessage(TextSyntax message)
		{
			return this.Update(this.Source, this.SourceType, this.KRef, this.Over, this.TColon, Message, this.LCrLf);
		}
	
	    public RefInputSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.Source, this.SourceType, this.KRef, this.Over, this.TColon, this.Message, LCrLf);
		}
	
	    public RefInputSyntax Update(LifeLineNameSyntax source, ArrowTypeSyntax sourceType, SyntaxToken kRef, TextSyntax over, SyntaxToken tColon, TextSyntax message, SyntaxToken lCrLf)
	    {
	        if (this.Source != source ||
				this.SourceType != sourceType ||
				this.KRef != kRef ||
				this.Over != over ||
				this.TColon != tColon ||
				this.Message != message ||
				this.LCrLf != lCrLf)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.RefInput(source, sourceType, kRef, over, tColon, message, lCrLf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefInputSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRefInput(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRefInput(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitRefInput(this);
	    }
	}
	
	public sealed class RefOutputSyntax : SequenceSyntaxNode
	{
	    private TextSyntax ignored;
	    private ArrowTypeSyntax targetType;
	    private LifeLineNameSyntax target;
	    private TextSyntax message;
	
	    public RefOutputSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RefOutputSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEndRef 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.RefOutputGreen)this.Green;
				var greenToken = green.KEndRef;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Ignored 
		{ 
			get { return this.GetRed(ref this.ignored, 1); } 
		}
	    public ArrowTypeSyntax TargetType 
		{ 
			get { return this.GetRed(ref this.targetType, 2); } 
		}
	    public LifeLineNameSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.RefOutputGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public TextSyntax Message 
		{ 
			get { return this.GetRed(ref this.message, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.ignored, 1);
				case 2: return this.GetRed(ref this.targetType, 2);
				case 3: return this.GetRed(ref this.target, 3);
				case 5: return this.GetRed(ref this.message, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.ignored;
				case 2: return this.targetType;
				case 3: return this.target;
				case 5: return this.message;
				default: return null;
	        }
	    }
	
	    public RefOutputSyntax WithKEndRef(SyntaxToken kEndRef)
		{
			return this.Update(KEndRef, this.Ignored, this.TargetType, this.Target, this.TColon, this.Message);
		}
	
	    public RefOutputSyntax WithIgnored(TextSyntax ignored)
		{
			return this.Update(this.KEndRef, Ignored, this.TargetType, this.Target, this.TColon, this.Message);
		}
	
	    public RefOutputSyntax WithTargetType(ArrowTypeSyntax targetType)
		{
			return this.Update(this.KEndRef, this.Ignored, TargetType, this.Target, this.TColon, this.Message);
		}
	
	    public RefOutputSyntax WithTarget(LifeLineNameSyntax target)
		{
			return this.Update(this.KEndRef, this.Ignored, this.TargetType, Target, this.TColon, this.Message);
		}
	
	    public RefOutputSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KEndRef, this.Ignored, this.TargetType, this.Target, TColon, this.Message);
		}
	
	    public RefOutputSyntax WithMessage(TextSyntax message)
		{
			return this.Update(this.KEndRef, this.Ignored, this.TargetType, this.Target, this.TColon, Message);
		}
	
	    public RefOutputSyntax Update(SyntaxToken kEndRef, TextSyntax ignored, ArrowTypeSyntax targetType, LifeLineNameSyntax target, SyntaxToken tColon, TextSyntax message)
	    {
	        if (this.KEndRef != kEndRef ||
				this.Ignored != ignored ||
				this.TargetType != targetType ||
				this.Target != target ||
				this.TColon != tColon ||
				this.Message != message)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.RefOutput(kEndRef, ignored, targetType, target, tColon, message);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefOutputSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRefOutput(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRefOutput(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitRefOutput(this);
	    }
	}
	
	public sealed class FragmentBodySyntax : SequenceSyntaxNode
	{
	    private SyntaxNode line;
	
	    public FragmentBodySyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FragmentBodySyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<LineSyntax> Line 
		{ 
			get
			{
				var red = this.GetRed(ref this.line, 0);
				if (red != null) return new SyntaxList<LineSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.line, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.line;
				default: return null;
	        }
	    }
	
	    public FragmentBodySyntax WithLine(SyntaxList<LineSyntax> line)
		{
			return this.Update(Line);
		}
	
	    public FragmentBodySyntax AddLine(params LineSyntax[] line)
		{
			return this.WithLine(this.Line.AddRange(line));
		}
	
	    public FragmentBodySyntax Update(SyntaxList<LineSyntax> line)
	    {
	        if (this.Line != line)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.FragmentBody(line);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FragmentBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFragmentBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFragmentBody(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitFragmentBody(this);
	    }
	}
	
	public sealed class EndSyntax : SequenceSyntaxNode
	{
	    private TextSyntax text;
	
	    public EndSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.EndGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Text 
		{ 
			get { return this.GetRed(ref this.text, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.text, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.text;
				default: return null;
	        }
	    }
	
	    public EndSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(KEnd, this.Text);
		}
	
	    public EndSyntax WithText(TextSyntax text)
		{
			return this.Update(this.KEnd, Text);
		}
	
	    public EndSyntax Update(SyntaxToken kEnd, TextSyntax text)
	    {
	        if (this.KEnd != kEnd ||
				this.Text != text)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.End(kEnd, text);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnd(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitEnd(this);
	    }
	}
	
	public sealed class NoteSyntax : SequenceSyntaxNode
	{
	    private SingleLineNoteSyntax singleLineNote;
	    private MultiLineNoteSyntax multiLineNote;
	
	    public NoteSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NoteSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SingleLineNoteSyntax SingleLineNote 
		{ 
			get { return this.GetRed(ref this.singleLineNote, 0); } 
		}
	    public MultiLineNoteSyntax MultiLineNote 
		{ 
			get { return this.GetRed(ref this.multiLineNote, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.singleLineNote, 0);
				case 1: return this.GetRed(ref this.multiLineNote, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.singleLineNote;
				case 1: return this.multiLineNote;
				default: return null;
	        }
	    }
	
	    public NoteSyntax WithSingleLineNote(SingleLineNoteSyntax singleLineNote)
		{
			return this.Update(singleLineNote);
		}
	
	    public NoteSyntax WithMultiLineNote(MultiLineNoteSyntax multiLineNote)
		{
			return this.Update(multiLineNote);
		}
	
	    public NoteSyntax Update(SingleLineNoteSyntax singleLineNote)
	    {
	        if (this.SingleLineNote != singleLineNote)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Note(singleLineNote);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NoteSyntax)newNode;
	        }
	        return this;
	    }
	
	    public NoteSyntax Update(MultiLineNoteSyntax multiLineNote)
	    {
	        if (this.MultiLineNote != multiLineNote)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Note(multiLineNote);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NoteSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNote(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNote(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitNote(this);
	    }
	}
	
	public sealed class SingleLineNoteSyntax : SequenceSyntaxNode
	{
	    private TextSyntax position;
	    private TextSyntax noteText;
	
	    public SingleLineNoteSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SingleLineNoteSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNote 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SingleLineNoteGreen)this.Green;
				var greenToken = green.KNote;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TextSyntax Position 
		{ 
			get { return this.GetRed(ref this.position, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SingleLineNoteGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TextSyntax NoteText 
		{ 
			get { return this.GetRed(ref this.noteText, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.position, 1);
				case 3: return this.GetRed(ref this.noteText, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.position;
				case 3: return this.noteText;
				default: return null;
	        }
	    }
	
	    public SingleLineNoteSyntax WithKNote(SyntaxToken kNote)
		{
			return this.Update(KNote, this.Position, this.TColon, this.NoteText);
		}
	
	    public SingleLineNoteSyntax WithPosition(TextSyntax position)
		{
			return this.Update(this.KNote, Position, this.TColon, this.NoteText);
		}
	
	    public SingleLineNoteSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KNote, this.Position, TColon, this.NoteText);
		}
	
	    public SingleLineNoteSyntax WithNoteText(TextSyntax noteText)
		{
			return this.Update(this.KNote, this.Position, this.TColon, NoteText);
		}
	
	    public SingleLineNoteSyntax Update(SyntaxToken kNote, TextSyntax position, SyntaxToken tColon, TextSyntax noteText)
	    {
	        if (this.KNote != kNote ||
				this.Position != position ||
				this.TColon != tColon ||
				this.NoteText != noteText)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.SingleLineNote(kNote, position, tColon, noteText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleLineNoteSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSingleLineNote(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSingleLineNote(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitSingleLineNote(this);
	    }
	}
	
	public sealed class MultiLineNoteSyntax : SequenceSyntaxNode
	{
	    private SimpleBodySyntax simpleBody;
	
	    public MultiLineNoteSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MultiLineNoteSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNote 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.MultiLineNoteGreen)this.Green;
				var greenToken = green.KNote;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SimpleBodySyntax SimpleBody 
		{ 
			get { return this.GetRed(ref this.simpleBody, 1); } 
		}
	    public SyntaxToken KEndNote 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.MultiLineNoteGreen)this.Green;
				var greenToken = green.KEndNote;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.simpleBody, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.simpleBody;
				default: return null;
	        }
	    }
	
	    public MultiLineNoteSyntax WithKNote(SyntaxToken kNote)
		{
			return this.Update(KNote, this.SimpleBody, this.KEndNote);
		}
	
	    public MultiLineNoteSyntax WithSimpleBody(SimpleBodySyntax simpleBody)
		{
			return this.Update(this.KNote, SimpleBody, this.KEndNote);
		}
	
	    public MultiLineNoteSyntax WithKEndNote(SyntaxToken kEndNote)
		{
			return this.Update(this.KNote, this.SimpleBody, KEndNote);
		}
	
	    public MultiLineNoteSyntax Update(SyntaxToken kNote, SimpleBodySyntax simpleBody, SyntaxToken kEndNote)
	    {
	        if (this.KNote != kNote ||
				this.SimpleBody != simpleBody ||
				this.KEndNote != kEndNote)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.MultiLineNote(kNote, simpleBody, kEndNote);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiLineNoteSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMultiLineNote(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMultiLineNote(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitMultiLineNote(this);
	    }
	}
	
	public sealed class SimpleBodySyntax : SequenceSyntaxNode
	{
	    private SyntaxNode simpleLine;
	
	    public SimpleBodySyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleBodySyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<SimpleLineSyntax> SimpleLine 
		{ 
			get
			{
				var red = this.GetRed(ref this.simpleLine, 0);
				if (red != null) return new SyntaxList<SimpleLineSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleLine, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleLine;
				default: return null;
	        }
	    }
	
	    public SimpleBodySyntax WithSimpleLine(SyntaxList<SimpleLineSyntax> simpleLine)
		{
			return this.Update(SimpleLine);
		}
	
	    public SimpleBodySyntax AddSimpleLine(params SimpleLineSyntax[] simpleLine)
		{
			return this.WithSimpleLine(this.SimpleLine.AddRange(simpleLine));
		}
	
	    public SimpleBodySyntax Update(SyntaxList<SimpleLineSyntax> simpleLine)
	    {
	        if (this.SimpleLine != simpleLine)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.SimpleBody(simpleLine);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleBody(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleBody(this);
	    }
	}
	
	public sealed class SimpleLineSyntax : SequenceSyntaxNode
	{
	    private TextSyntax text;
	
	    public SimpleLineSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleLineSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextSyntax Text 
		{ 
			get { return this.GetRed(ref this.text, 0); } 
		}
	    public SyntaxToken LCrLf 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.SimpleLineGreen)this.Green;
				var greenToken = green.LCrLf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.text, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.text;
				default: return null;
	        }
	    }
	
	    public SimpleLineSyntax WithText(TextSyntax text)
		{
			return this.Update(Text, this.LCrLf);
		}
	
	    public SimpleLineSyntax WithLCrLf(SyntaxToken lCrLf)
		{
			return this.Update(this.Text, LCrLf);
		}
	
	    public SimpleLineSyntax Update(TextSyntax text, SyntaxToken lCrLf)
	    {
	        if (this.Text != text ||
				this.LCrLf != lCrLf)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.SimpleLine(text, lCrLf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleLineSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleLine(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleLine(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleLine(this);
	    }
	}
	
	public sealed class ArrowTypeSyntax : SequenceSyntaxNode
	{
	
	    public ArrowTypeSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrowTypeSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ArrowType 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.ArrowTypeGreen)this.Green;
				var greenToken = green.ArrowType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public ArrowTypeSyntax WithArrowType(SyntaxToken arrowType)
		{
			return this.Update(ArrowType);
		}
	
	    public ArrowTypeSyntax Update(SyntaxToken arrowType)
	    {
	        if (this.ArrowType != arrowType)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.ArrowType(arrowType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrowTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrowType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrowType(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitArrowType(this);
	    }
	}
	
	public sealed class LifeLineNameSyntax : SequenceSyntaxNode
	{
	    private NameSyntax name;
	
	    public LifeLineNameSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LifeLineNameSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				default: return null;
	        }
	    }
	
	    public LifeLineNameSyntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public LifeLineNameSyntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.LifeLineName(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LifeLineNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLifeLineName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLifeLineName(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitLifeLineName(this);
	    }
	}
	
	public sealed class NameSyntax : SequenceSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public NameSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public NameSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class IdentifierSyntax : SequenceSyntaxNode
	{
	    private TextSyntax text;
	
	    public IdentifierSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextSyntax Text 
		{ 
			get { return this.GetRed(ref this.text, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.text, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.text;
				default: return null;
	        }
	    }
	
	    public IdentifierSyntax WithText(TextSyntax text)
		{
			return this.Update(Text);
		}
	
	    public IdentifierSyntax Update(TextSyntax text)
	    {
	        if (this.Text != text)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Identifier(text);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class TextSyntax : SequenceSyntaxNode
	{
	    private SyntaxNode identifierPart;
	
	    public TextSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TextSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<IdentifierPartSyntax> IdentifierPart 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifierPart, 0);
				if (red != null) return new SyntaxList<IdentifierPartSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifierPart, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifierPart;
				default: return null;
	        }
	    }
	
	    public TextSyntax WithIdentifierPart(SyntaxList<IdentifierPartSyntax> identifierPart)
		{
			return this.Update(IdentifierPart);
		}
	
	    public TextSyntax AddIdentifierPart(params IdentifierPartSyntax[] identifierPart)
		{
			return this.WithIdentifierPart(this.IdentifierPart.AddRange(identifierPart));
		}
	
	    public TextSyntax Update(SyntaxList<IdentifierPartSyntax> identifierPart)
	    {
	        if (this.IdentifierPart != identifierPart)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.Text(identifierPart);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitText(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitText(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitText(this);
	    }
	}
	
	public sealed class IdentifierPartSyntax : SequenceSyntaxNode
	{
	
	    public IdentifierPartSyntax(InternalSyntaxNode green, SequenceSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierPartSyntax(InternalSyntaxNode green, SequenceSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LIdentifier 
		{ 
			get 
			{ 
				var green = (global::WebSequenceDiagramsModel.Syntax.InternalSyntax.IdentifierPartGreen)this.Green;
				var greenToken = green.LIdentifier;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public IdentifierPartSyntax WithLIdentifier(SyntaxToken lIdentifier)
		{
			return this.Update(LIdentifier);
		}
	
	    public IdentifierPartSyntax Update(SyntaxToken lIdentifier)
	    {
	        if (this.LIdentifier != lIdentifier)
	        {
	            var newNode = SequenceLanguage.Instance.SyntaxFactory.IdentifierPart(lIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierPartSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISequenceSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifierPart(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISequenceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifierPart(this);
	    }
	
	    public override void Accept(ISequenceSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifierPart(this);
	    }
	}
}

namespace WebSequenceDiagramsModel
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using WebSequenceDiagramsModel.Syntax;
    using WebSequenceDiagramsModel.Syntax.InternalSyntax;

	public interface ISequenceSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitInteraction(InteractionSyntax node);
		
		void VisitLine(LineSyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitTitle(TitleSyntax node);
		
		void VisitArrow(ArrowSyntax node);
		
		void VisitDestroy(DestroySyntax node);
		
		void VisitAlt(AltSyntax node);
		
		void VisitAltFragment(AltFragmentSyntax node);
		
		void VisitElseFragment(ElseFragmentSyntax node);
		
		void VisitLoop(LoopSyntax node);
		
		void VisitLoopFragment(LoopFragmentSyntax node);
		
		void VisitOpt(OptSyntax node);
		
		void VisitOptFragment(OptFragmentSyntax node);
		
		void VisitRef(RefSyntax node);
		
		void VisitSimpleRefFragment(SimpleRefFragmentSyntax node);
		
		void VisitMessageRefFragment(MessageRefFragmentSyntax node);
		
		void VisitRefInput(RefInputSyntax node);
		
		void VisitRefOutput(RefOutputSyntax node);
		
		void VisitFragmentBody(FragmentBodySyntax node);
		
		void VisitEnd(EndSyntax node);
		
		void VisitNote(NoteSyntax node);
		
		void VisitSingleLineNote(SingleLineNoteSyntax node);
		
		void VisitMultiLineNote(MultiLineNoteSyntax node);
		
		void VisitSimpleBody(SimpleBodySyntax node);
		
		void VisitSimpleLine(SimpleLineSyntax node);
		
		void VisitArrowType(ArrowTypeSyntax node);
		
		void VisitLifeLineName(LifeLineNameSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitText(TextSyntax node);
		
		void VisitIdentifierPart(IdentifierPartSyntax node);
	}
	
	public class SequenceSyntaxVisitor : SyntaxVisitor, ISequenceSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInteraction(InteractionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLine(LineSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTitle(TitleSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow(ArrowSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDestroy(DestroySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAlt(AltSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAltFragment(AltFragmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElseFragment(ElseFragmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoop(LoopSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopFragment(LoopFragmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOpt(OptSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOptFragment(OptFragmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRef(RefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleRefFragment(SimpleRefFragmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMessageRefFragment(MessageRefFragmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRefInput(RefInputSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRefOutput(RefOutputSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFragmentBody(FragmentBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnd(EndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNote(NoteSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSingleLineNote(SingleLineNoteSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMultiLineNote(MultiLineNoteSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleBody(SimpleBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleLine(SimpleLineSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrowType(ArrowTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLifeLineName(LifeLineNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitText(TextSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifierPart(IdentifierPartSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	//GenerateDetailedSyntaxVisitor()

	public interface ISequenceSyntaxVisitor<TArg, TResult> 
	{
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitInteraction(InteractionSyntax node, TArg argument);
		
		TResult VisitLine(LineSyntax node, TArg argument);
		
		TResult VisitDeclaration(DeclarationSyntax node, TArg argument);
		
		TResult VisitTitle(TitleSyntax node, TArg argument);
		
		TResult VisitArrow(ArrowSyntax node, TArg argument);
		
		TResult VisitDestroy(DestroySyntax node, TArg argument);
		
		TResult VisitAlt(AltSyntax node, TArg argument);
		
		TResult VisitAltFragment(AltFragmentSyntax node, TArg argument);
		
		TResult VisitElseFragment(ElseFragmentSyntax node, TArg argument);
		
		TResult VisitLoop(LoopSyntax node, TArg argument);
		
		TResult VisitLoopFragment(LoopFragmentSyntax node, TArg argument);
		
		TResult VisitOpt(OptSyntax node, TArg argument);
		
		TResult VisitOptFragment(OptFragmentSyntax node, TArg argument);
		
		TResult VisitRef(RefSyntax node, TArg argument);
		
		TResult VisitSimpleRefFragment(SimpleRefFragmentSyntax node, TArg argument);
		
		TResult VisitMessageRefFragment(MessageRefFragmentSyntax node, TArg argument);
		
		TResult VisitRefInput(RefInputSyntax node, TArg argument);
		
		TResult VisitRefOutput(RefOutputSyntax node, TArg argument);
		
		TResult VisitFragmentBody(FragmentBodySyntax node, TArg argument);
		
		TResult VisitEnd(EndSyntax node, TArg argument);
		
		TResult VisitNote(NoteSyntax node, TArg argument);
		
		TResult VisitSingleLineNote(SingleLineNoteSyntax node, TArg argument);
		
		TResult VisitMultiLineNote(MultiLineNoteSyntax node, TArg argument);
		
		TResult VisitSimpleBody(SimpleBodySyntax node, TArg argument);
		
		TResult VisitSimpleLine(SimpleLineSyntax node, TArg argument);
		
		TResult VisitArrowType(ArrowTypeSyntax node, TArg argument);
		
		TResult VisitLifeLineName(LifeLineNameSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitText(TextSyntax node, TArg argument);
		
		TResult VisitIdentifierPart(IdentifierPartSyntax node, TArg argument);
	}
	
	public class SequenceSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, ISequenceSyntaxVisitor<TArg, TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInteraction(InteractionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLine(LineSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTitle(TitleSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow(ArrowSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDestroy(DestroySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAlt(AltSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAltFragment(AltFragmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElseFragment(ElseFragmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoop(LoopSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopFragment(LoopFragmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOpt(OptSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOptFragment(OptFragmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRef(RefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleRefFragment(SimpleRefFragmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMessageRefFragment(MessageRefFragmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRefInput(RefInputSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRefOutput(RefOutputSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFragmentBody(FragmentBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnd(EndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNote(NoteSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSingleLineNote(SingleLineNoteSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMultiLineNote(MultiLineNoteSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleBody(SimpleBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleLine(SimpleLineSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrowType(ArrowTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLifeLineName(LifeLineNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitName(NameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitText(TextSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifierPart(IdentifierPartSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
	}

	public interface ISequenceSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitInteraction(InteractionSyntax node);
		
		TResult VisitLine(LineSyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitTitle(TitleSyntax node);
		
		TResult VisitArrow(ArrowSyntax node);
		
		TResult VisitDestroy(DestroySyntax node);
		
		TResult VisitAlt(AltSyntax node);
		
		TResult VisitAltFragment(AltFragmentSyntax node);
		
		TResult VisitElseFragment(ElseFragmentSyntax node);
		
		TResult VisitLoop(LoopSyntax node);
		
		TResult VisitLoopFragment(LoopFragmentSyntax node);
		
		TResult VisitOpt(OptSyntax node);
		
		TResult VisitOptFragment(OptFragmentSyntax node);
		
		TResult VisitRef(RefSyntax node);
		
		TResult VisitSimpleRefFragment(SimpleRefFragmentSyntax node);
		
		TResult VisitMessageRefFragment(MessageRefFragmentSyntax node);
		
		TResult VisitRefInput(RefInputSyntax node);
		
		TResult VisitRefOutput(RefOutputSyntax node);
		
		TResult VisitFragmentBody(FragmentBodySyntax node);
		
		TResult VisitEnd(EndSyntax node);
		
		TResult VisitNote(NoteSyntax node);
		
		TResult VisitSingleLineNote(SingleLineNoteSyntax node);
		
		TResult VisitMultiLineNote(MultiLineNoteSyntax node);
		
		TResult VisitSimpleBody(SimpleBodySyntax node);
		
		TResult VisitSimpleLine(SimpleLineSyntax node);
		
		TResult VisitArrowType(ArrowTypeSyntax node);
		
		TResult VisitLifeLineName(LifeLineNameSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitText(TextSyntax node);
		
		TResult VisitIdentifierPart(IdentifierPartSyntax node);
	}
	
	public class SequenceSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ISequenceSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInteraction(InteractionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLine(LineSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTitle(TitleSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow(ArrowSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDestroy(DestroySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAlt(AltSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAltFragment(AltFragmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElseFragment(ElseFragmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoop(LoopSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopFragment(LoopFragmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOpt(OptSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOptFragment(OptFragmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRef(RefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleRefFragment(SimpleRefFragmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMessageRefFragment(MessageRefFragmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRefInput(RefInputSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRefOutput(RefOutputSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFragmentBody(FragmentBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnd(EndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNote(NoteSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSingleLineNote(SingleLineNoteSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMultiLineNote(MultiLineNoteSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleBody(SimpleBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleLine(SimpleLineSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrowType(ArrowTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLifeLineName(LifeLineNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitName(NameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitText(TextSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifierPart(IdentifierPartSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class SequenceSyntaxRewriter : SyntaxRewriter, ISequenceSyntaxVisitor<SyntaxNode>
	{
	    public SequenceSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(SequenceLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var interaction = (InteractionSyntax)this.Visit(node.Interaction);
		    var eof = this.VisitToken(node.EndOfFileToken);
			return node.Update(interaction, eof);
		}
		
		public virtual SyntaxNode VisitInteraction(InteractionSyntax node)
		{
		    var line = this.VisitList(node.Line);
			return node.Update(line);
		}
		
		public virtual SyntaxNode VisitLine(LineSyntax node)
		{
		    var declaration = (DeclarationSyntax)this.Visit(node.Declaration);
		    var lCrLf = this.VisitToken(node.LCrLf);
			return node.Update(declaration, lCrLf);
		}
		
		public virtual SyntaxNode VisitDeclaration(DeclarationSyntax node)
		{
			var oldTitle = node.Title;
			if (oldTitle != null)
			{
			    var newTitle = (TitleSyntax)this.Visit(oldTitle);
				return node.Update(newTitle);
			}
			var oldDestroy = node.Destroy;
			if (oldDestroy != null)
			{
			    var newDestroy = (DestroySyntax)this.Visit(oldDestroy);
				return node.Update(newDestroy);
			}
			var oldArrow = node.Arrow;
			if (oldArrow != null)
			{
			    var newArrow = (ArrowSyntax)this.Visit(oldArrow);
				return node.Update(newArrow);
			}
			var oldAlt = node.Alt;
			if (oldAlt != null)
			{
			    var newAlt = (AltSyntax)this.Visit(oldAlt);
				return node.Update(newAlt);
			}
			var oldOpt = node.Opt;
			if (oldOpt != null)
			{
			    var newOpt = (OptSyntax)this.Visit(oldOpt);
				return node.Update(newOpt);
			}
			var oldLoop = node.Loop;
			if (oldLoop != null)
			{
			    var newLoop = (LoopSyntax)this.Visit(oldLoop);
				return node.Update(newLoop);
			}
			var oldRef = node.Ref;
			if (oldRef != null)
			{
			    var newRef = (RefSyntax)this.Visit(oldRef);
				return node.Update(newRef);
			}
			var oldNote = node.Note;
			if (oldNote != null)
			{
			    var newNote = (NoteSyntax)this.Visit(oldNote);
				return node.Update(newNote);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTitle(TitleSyntax node)
		{
		    var kTitle = this.VisitToken(node.KTitle);
		    var text = (TextSyntax)this.Visit(node.Text);
			return node.Update(kTitle, text);
		}
		
		public virtual SyntaxNode VisitArrow(ArrowSyntax node)
		{
		    var source = (LifeLineNameSyntax)this.Visit(node.Source);
		    var type = (ArrowTypeSyntax)this.Visit(node.Type);
		    var target = (LifeLineNameSyntax)this.Visit(node.Target);
		    var tColon = this.VisitToken(node.TColon);
		    var text = (TextSyntax)this.Visit(node.Text);
			return node.Update(source, type, target, tColon, text);
		}
		
		public virtual SyntaxNode VisitDestroy(DestroySyntax node)
		{
		    var kDestroy = this.VisitToken(node.KDestroy);
		    var lifeLineName = (LifeLineNameSyntax)this.Visit(node.LifeLineName);
			return node.Update(kDestroy, lifeLineName);
		}
		
		public virtual SyntaxNode VisitAlt(AltSyntax node)
		{
		    var altFragment = (AltFragmentSyntax)this.Visit(node.AltFragment);
		    var elseFragment = this.VisitList(node.ElseFragment);
		    var end = (EndSyntax)this.Visit(node.End);
			return node.Update(altFragment, elseFragment, end);
		}
		
		public virtual SyntaxNode VisitAltFragment(AltFragmentSyntax node)
		{
		    var kAlt = this.VisitToken(node.KAlt);
		    var condition = (TextSyntax)this.Visit(node.Condition);
		    var lCrLf = this.VisitToken(node.LCrLf);
		    var fragmentBody = (FragmentBodySyntax)this.Visit(node.FragmentBody);
			return node.Update(kAlt, condition, lCrLf, fragmentBody);
		}
		
		public virtual SyntaxNode VisitElseFragment(ElseFragmentSyntax node)
		{
		    var kElse = this.VisitToken(node.KElse);
		    var condition = (TextSyntax)this.Visit(node.Condition);
		    var lCrLf = this.VisitToken(node.LCrLf);
		    var fragmentBody = (FragmentBodySyntax)this.Visit(node.FragmentBody);
			return node.Update(kElse, condition, lCrLf, fragmentBody);
		}
		
		public virtual SyntaxNode VisitLoop(LoopSyntax node)
		{
		    var loopFragment = (LoopFragmentSyntax)this.Visit(node.LoopFragment);
		    var end = (EndSyntax)this.Visit(node.End);
			return node.Update(loopFragment, end);
		}
		
		public virtual SyntaxNode VisitLoopFragment(LoopFragmentSyntax node)
		{
		    var kLoop = this.VisitToken(node.KLoop);
		    var condition = (TextSyntax)this.Visit(node.Condition);
		    var lCrLf = this.VisitToken(node.LCrLf);
		    var fragmentBody = (FragmentBodySyntax)this.Visit(node.FragmentBody);
			return node.Update(kLoop, condition, lCrLf, fragmentBody);
		}
		
		public virtual SyntaxNode VisitOpt(OptSyntax node)
		{
		    var optFragment = (OptFragmentSyntax)this.Visit(node.OptFragment);
		    var end = (EndSyntax)this.Visit(node.End);
			return node.Update(optFragment, end);
		}
		
		public virtual SyntaxNode VisitOptFragment(OptFragmentSyntax node)
		{
		    var kOpt = this.VisitToken(node.KOpt);
		    var condition = (TextSyntax)this.Visit(node.Condition);
		    var lCrLf = this.VisitToken(node.LCrLf);
		    var fragmentBody = (FragmentBodySyntax)this.Visit(node.FragmentBody);
			return node.Update(kOpt, condition, lCrLf, fragmentBody);
		}
		
		public virtual SyntaxNode VisitRef(RefSyntax node)
		{
			var oldSimpleRefFragment = node.SimpleRefFragment;
			if (oldSimpleRefFragment != null)
			{
			    var newSimpleRefFragment = (SimpleRefFragmentSyntax)this.Visit(oldSimpleRefFragment);
				return node.Update(newSimpleRefFragment);
			}
			var oldMessageRefFragment = node.MessageRefFragment;
			if (oldMessageRefFragment != null)
			{
			    var newMessageRefFragment = (MessageRefFragmentSyntax)this.Visit(oldMessageRefFragment);
				return node.Update(newMessageRefFragment);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSimpleRefFragment(SimpleRefFragmentSyntax node)
		{
		    var kRef = this.VisitToken(node.KRef);
		    var over = (TextSyntax)this.Visit(node.Over);
		    var tColon = this.VisitToken(node.TColon);
		    var refText = (TextSyntax)this.Visit(node.RefText);
		    var lCrLf = this.VisitToken(node.LCrLf);
		    var simpleBody = (SimpleBodySyntax)this.Visit(node.SimpleBody);
		    var kEndRef = this.VisitToken(node.KEndRef);
			return node.Update(kRef, over, tColon, refText, lCrLf, simpleBody, kEndRef);
		}
		
		public virtual SyntaxNode VisitMessageRefFragment(MessageRefFragmentSyntax node)
		{
		    var refInput = (RefInputSyntax)this.Visit(node.RefInput);
		    var simpleBody = (SimpleBodySyntax)this.Visit(node.SimpleBody);
		    var refOutput = (RefOutputSyntax)this.Visit(node.RefOutput);
			return node.Update(refInput, simpleBody, refOutput);
		}
		
		public virtual SyntaxNode VisitRefInput(RefInputSyntax node)
		{
		    var source = (LifeLineNameSyntax)this.Visit(node.Source);
		    var sourceType = (ArrowTypeSyntax)this.Visit(node.SourceType);
		    var kRef = this.VisitToken(node.KRef);
		    var over = (TextSyntax)this.Visit(node.Over);
		    var tColon = this.VisitToken(node.TColon);
		    var message = (TextSyntax)this.Visit(node.Message);
		    var lCrLf = this.VisitToken(node.LCrLf);
			return node.Update(source, sourceType, kRef, over, tColon, message, lCrLf);
		}
		
		public virtual SyntaxNode VisitRefOutput(RefOutputSyntax node)
		{
		    var kEndRef = this.VisitToken(node.KEndRef);
		    var ignored = (TextSyntax)this.Visit(node.Ignored);
		    var targetType = (ArrowTypeSyntax)this.Visit(node.TargetType);
		    var target = (LifeLineNameSyntax)this.Visit(node.Target);
		    var tColon = this.VisitToken(node.TColon);
		    var message = (TextSyntax)this.Visit(node.Message);
			return node.Update(kEndRef, ignored, targetType, target, tColon, message);
		}
		
		public virtual SyntaxNode VisitFragmentBody(FragmentBodySyntax node)
		{
		    var line = this.VisitList(node.Line);
			return node.Update(line);
		}
		
		public virtual SyntaxNode VisitEnd(EndSyntax node)
		{
		    var kEnd = this.VisitToken(node.KEnd);
		    var text = (TextSyntax)this.Visit(node.Text);
			return node.Update(kEnd, text);
		}
		
		public virtual SyntaxNode VisitNote(NoteSyntax node)
		{
			var oldSingleLineNote = node.SingleLineNote;
			if (oldSingleLineNote != null)
			{
			    var newSingleLineNote = (SingleLineNoteSyntax)this.Visit(oldSingleLineNote);
				return node.Update(newSingleLineNote);
			}
			var oldMultiLineNote = node.MultiLineNote;
			if (oldMultiLineNote != null)
			{
			    var newMultiLineNote = (MultiLineNoteSyntax)this.Visit(oldMultiLineNote);
				return node.Update(newMultiLineNote);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSingleLineNote(SingleLineNoteSyntax node)
		{
		    var kNote = this.VisitToken(node.KNote);
		    var position = (TextSyntax)this.Visit(node.Position);
		    var tColon = this.VisitToken(node.TColon);
		    var noteText = (TextSyntax)this.Visit(node.NoteText);
			return node.Update(kNote, position, tColon, noteText);
		}
		
		public virtual SyntaxNode VisitMultiLineNote(MultiLineNoteSyntax node)
		{
		    var kNote = this.VisitToken(node.KNote);
		    var simpleBody = (SimpleBodySyntax)this.Visit(node.SimpleBody);
		    var kEndNote = this.VisitToken(node.KEndNote);
			return node.Update(kNote, simpleBody, kEndNote);
		}
		
		public virtual SyntaxNode VisitSimpleBody(SimpleBodySyntax node)
		{
		    var simpleLine = this.VisitList(node.SimpleLine);
			return node.Update(simpleLine);
		}
		
		public virtual SyntaxNode VisitSimpleLine(SimpleLineSyntax node)
		{
		    var text = (TextSyntax)this.Visit(node.Text);
		    var lCrLf = this.VisitToken(node.LCrLf);
			return node.Update(text, lCrLf);
		}
		
		public virtual SyntaxNode VisitArrowType(ArrowTypeSyntax node)
		{
		    var arrowType = this.VisitToken(node.ArrowType);
			return node.Update(arrowType);
		}
		
		public virtual SyntaxNode VisitLifeLineName(LifeLineNameSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitName(NameSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var text = (TextSyntax)this.Visit(node.Text);
			return node.Update(text);
		}
		
		public virtual SyntaxNode VisitText(TextSyntax node)
		{
		    var identifierPart = this.VisitList(node.IdentifierPart);
			return node.Update(identifierPart);
		}
		
		public virtual SyntaxNode VisitIdentifierPart(IdentifierPartSyntax node)
		{
		    var lIdentifier = this.VisitToken(node.LIdentifier);
			return node.Update(lIdentifier);
		}
	}

	public class SequenceSyntaxFactory : SyntaxFactory
	{
		internal SequenceSyntaxFactory(SequenceInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
		public new SequenceLanguage Language
		{
			get { return SequenceLanguage.Instance; }
		}
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public SequenceSyntaxTree SyntaxTree(SyntaxNode root, SequenceParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return SequenceSyntaxTree.Create((SequenceSyntaxNode)root, (SequenceParseOptions)options, path, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SequenceSyntaxTree ParseSyntaxTree(
			string text,
			SequenceParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (SequenceSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SequenceSyntaxTree ParseSyntaxTree(
			SourceText text,
			SequenceParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (SequenceSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return SequenceSyntaxTree.ParseText(text, (SequenceParseOptions)options, path, cancellationToken);
		}
	
	    public MainSyntax ParseMain(string text)
	    {
	        // note that we do not need a "consumeFullText" parameter, because parsing a compilation unit always must
	        // consume input until the end-of-file
	        using (var parser = MakeParser(text))
	        {
	            var node = parser.Parse();
	            if (node == null) return null;
	            // if (consumeFullText) node = parser.ConsumeUnexpectedTokens(node);
	            return (MainSyntax)node.CreateRed();
	        }
	    }
	
		public override SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes)
		{
		    return new SequenceSyntaxParser(text, (SequenceParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new SequenceSyntaxParser(SourceText.From(text, Encoding.UTF8), SequenceParseOptions.Default, null, null);
		}
	
	    public override SyntaxNode CreateStructure(SyntaxTrivia trivia)
	    {
	        throw new NotImplementedException();
	    }
	
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LCommentStart(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LCommentStart(text));
	    }
	
	    public SyntaxToken LCommentStart(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LCommentStart(text, value));
	    }
	
	    public SyntaxToken TCreate(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.TCreate(text));
	    }
	
	    public SyntaxToken TCreate(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.TCreate(text, value));
	    }
	
	    public SyntaxToken TReturn(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.TReturn(text));
	    }
	
	    public SyntaxToken TReturn(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.TReturn(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LIdentifier(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LIdentifier(text));
	    }
	
	    public SyntaxToken LIdentifier(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LIdentifier(text, value));
	    }
	
	    public SyntaxToken NoteWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.NoteWhiteSpace(text));
	    }
	
	    public SyntaxToken NoteWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.NoteWhiteSpace(text, value));
	    }
	
	    public SyntaxToken NoteLinesWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.NoteLinesWhiteSpace(text));
	    }
	
	    public SyntaxToken NoteLinesWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.NoteLinesWhiteSpace(text, value));
	    }
	
	    public SyntaxToken RefWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.RefWhiteSpace(text));
	    }
	
	    public SyntaxToken RefWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.RefWhiteSpace(text, value));
	    }
	
	    public SyntaxToken RefLinesWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.RefLinesWhiteSpace(text));
	    }
	
	    public SyntaxToken RefLinesWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.RefLinesWhiteSpace(text, value));
	    }
	
	    public SyntaxToken RefEndWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.RefEndWhiteSpace(text));
	    }
	
	    public SyntaxToken RefEndWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.RefEndWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LineEndWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LineEndWhiteSpace(text));
	    }
	
	    public SyntaxToken LineEndWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.LineEndWhiteSpace(text, value));
	    }
	
	    public SyntaxToken ArrowEndWhiteSpace(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.ArrowEndWhiteSpace(text));
	    }
	
	    public SyntaxToken ArrowEndWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.ArrowEndWhiteSpace(text, value));
	    }
	
	    public SyntaxToken TMinus(string text)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.TMinus(text));
	    }
	
	    public SyntaxToken TMinus(string text, object value)
	    {
	        return new SyntaxToken(SequenceLanguage.Instance.InternalSyntaxFactory.TMinus(text, value));
	    }
		
		public MainSyntax Main(InteractionSyntax interaction, SyntaxToken eof)
		{
		    if (interaction == null) throw new ArgumentNullException(nameof(interaction));
		    if (eof == null) throw new ArgumentNullException(nameof(eof));
		    if (eof.GetKind() != SequenceSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
		    return (MainSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Main((Syntax.InternalSyntax.InteractionGreen)interaction.Green, (InternalSyntaxToken)eof.Node).CreateRed();
		}
		
		public InteractionSyntax Interaction(SyntaxList<LineSyntax> line)
		{
		    return (InteractionSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Interaction(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<LineGreen>(line.Node)).CreateRed();
		}
		
		public InteractionSyntax Interaction()
		{
			return this.Interaction(default);
		}
		
		public LineSyntax Line(DeclarationSyntax declaration, SyntaxToken lCrLf)
		{
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    return (LineSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Line(declaration == null ? null : (Syntax.InternalSyntax.DeclarationGreen)declaration.Green, (InternalSyntaxToken)lCrLf.Node).CreateRed();
		}
		
		public LineSyntax Line(SyntaxToken lCrLf)
		{
			return this.Line(default, lCrLf);
		}
		
		public DeclarationSyntax Declaration(TitleSyntax title)
		{
		    if (title == null) throw new ArgumentNullException(nameof(title));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.TitleGreen)title.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(DestroySyntax destroy)
		{
		    if (destroy == null) throw new ArgumentNullException(nameof(destroy));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.DestroyGreen)destroy.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ArrowSyntax arrow)
		{
		    if (arrow == null) throw new ArgumentNullException(nameof(arrow));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ArrowGreen)arrow.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(AltSyntax alt)
		{
		    if (alt == null) throw new ArgumentNullException(nameof(alt));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.AltGreen)alt.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(OptSyntax opt)
		{
		    if (opt == null) throw new ArgumentNullException(nameof(opt));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.OptGreen)opt.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(LoopSyntax loop)
		{
		    if (loop == null) throw new ArgumentNullException(nameof(loop));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.LoopGreen)loop.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(RefSyntax _ref)
		{
		    if (_ref == null) throw new ArgumentNullException(nameof(_ref));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.RefGreen)_ref.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(NoteSyntax note)
		{
		    if (note == null) throw new ArgumentNullException(nameof(note));
		    return (DeclarationSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.NoteGreen)note.Green).CreateRed();
		}
		
		public TitleSyntax Title(SyntaxToken kTitle, TextSyntax text)
		{
		    if (kTitle == null) throw new ArgumentNullException(nameof(kTitle));
		    if (kTitle.GetKind() != SequenceSyntaxKind.KTitle) throw new ArgumentException(nameof(kTitle));
		    return (TitleSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Title((InternalSyntaxToken)kTitle.Node, text == null ? null : (Syntax.InternalSyntax.TextGreen)text.Green).CreateRed();
		}
		
		public TitleSyntax Title()
		{
			return this.Title(this.Token(SequenceSyntaxKind.KTitle), default);
		}
		
		public ArrowSyntax Arrow(LifeLineNameSyntax source, ArrowTypeSyntax type, LifeLineNameSyntax target, SyntaxToken tColon, TextSyntax text)
		{
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (type == null) throw new ArgumentNullException(nameof(type));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (ArrowSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Arrow((Syntax.InternalSyntax.LifeLineNameGreen)source.Green, (Syntax.InternalSyntax.ArrowTypeGreen)type.Green, (Syntax.InternalSyntax.LifeLineNameGreen)target.Green, (InternalSyntaxToken)tColon.Node, text == null ? null : (Syntax.InternalSyntax.TextGreen)text.Green).CreateRed();
		}
		
		public ArrowSyntax Arrow(LifeLineNameSyntax source, ArrowTypeSyntax type, LifeLineNameSyntax target)
		{
			return this.Arrow(source, type, target, this.Token(SequenceSyntaxKind.TColon), default);
		}
		
		public DestroySyntax Destroy(SyntaxToken kDestroy, LifeLineNameSyntax lifeLineName)
		{
		    if (kDestroy == null) throw new ArgumentNullException(nameof(kDestroy));
		    if (kDestroy.GetKind() != SequenceSyntaxKind.KDestroy) throw new ArgumentException(nameof(kDestroy));
		    return (DestroySyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Destroy((InternalSyntaxToken)kDestroy.Node, lifeLineName == null ? null : (Syntax.InternalSyntax.LifeLineNameGreen)lifeLineName.Green).CreateRed();
		}
		
		public DestroySyntax Destroy()
		{
			return this.Destroy(this.Token(SequenceSyntaxKind.KDestroy), default);
		}
		
		public AltSyntax Alt(AltFragmentSyntax altFragment, SyntaxList<ElseFragmentSyntax> elseFragment, EndSyntax end)
		{
		    if (altFragment == null) throw new ArgumentNullException(nameof(altFragment));
		    if (end == null) throw new ArgumentNullException(nameof(end));
		    return (AltSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Alt((Syntax.InternalSyntax.AltFragmentGreen)altFragment.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ElseFragmentGreen>(elseFragment.Node), (Syntax.InternalSyntax.EndGreen)end.Green).CreateRed();
		}
		
		public AltSyntax Alt(AltFragmentSyntax altFragment, EndSyntax end)
		{
			return this.Alt(altFragment, default, end);
		}
		
		public AltFragmentSyntax AltFragment(SyntaxToken kAlt, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
		    if (kAlt == null) throw new ArgumentNullException(nameof(kAlt));
		    if (kAlt.GetKind() != SequenceSyntaxKind.KAlt) throw new ArgumentException(nameof(kAlt));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
		    return (AltFragmentSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.AltFragment((InternalSyntaxToken)kAlt.Node, condition == null ? null : (Syntax.InternalSyntax.TextGreen)condition.Green, (InternalSyntaxToken)lCrLf.Node, (Syntax.InternalSyntax.FragmentBodyGreen)fragmentBody.Green).CreateRed();
		}
		
		public AltFragmentSyntax AltFragment(SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
			return this.AltFragment(this.Token(SequenceSyntaxKind.KAlt), default, lCrLf, fragmentBody);
		}
		
		public ElseFragmentSyntax ElseFragment(SyntaxToken kElse, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
		    if (kElse == null) throw new ArgumentNullException(nameof(kElse));
		    if (kElse.GetKind() != SequenceSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
		    return (ElseFragmentSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.ElseFragment((InternalSyntaxToken)kElse.Node, condition == null ? null : (Syntax.InternalSyntax.TextGreen)condition.Green, (InternalSyntaxToken)lCrLf.Node, (Syntax.InternalSyntax.FragmentBodyGreen)fragmentBody.Green).CreateRed();
		}
		
		public ElseFragmentSyntax ElseFragment(SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
			return this.ElseFragment(this.Token(SequenceSyntaxKind.KElse), default, lCrLf, fragmentBody);
		}
		
		public LoopSyntax Loop(LoopFragmentSyntax loopFragment, EndSyntax end)
		{
		    if (loopFragment == null) throw new ArgumentNullException(nameof(loopFragment));
		    if (end == null) throw new ArgumentNullException(nameof(end));
		    return (LoopSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Loop((Syntax.InternalSyntax.LoopFragmentGreen)loopFragment.Green, (Syntax.InternalSyntax.EndGreen)end.Green).CreateRed();
		}
		
		public LoopFragmentSyntax LoopFragment(SyntaxToken kLoop, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
		    if (kLoop == null) throw new ArgumentNullException(nameof(kLoop));
		    if (kLoop.GetKind() != SequenceSyntaxKind.KLoop) throw new ArgumentException(nameof(kLoop));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
		    return (LoopFragmentSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.LoopFragment((InternalSyntaxToken)kLoop.Node, condition == null ? null : (Syntax.InternalSyntax.TextGreen)condition.Green, (InternalSyntaxToken)lCrLf.Node, (Syntax.InternalSyntax.FragmentBodyGreen)fragmentBody.Green).CreateRed();
		}
		
		public LoopFragmentSyntax LoopFragment(SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
			return this.LoopFragment(this.Token(SequenceSyntaxKind.KLoop), default, lCrLf, fragmentBody);
		}
		
		public OptSyntax Opt(OptFragmentSyntax optFragment, EndSyntax end)
		{
		    if (optFragment == null) throw new ArgumentNullException(nameof(optFragment));
		    if (end == null) throw new ArgumentNullException(nameof(end));
		    return (OptSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Opt((Syntax.InternalSyntax.OptFragmentGreen)optFragment.Green, (Syntax.InternalSyntax.EndGreen)end.Green).CreateRed();
		}
		
		public OptFragmentSyntax OptFragment(SyntaxToken kOpt, TextSyntax condition, SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
		    if (kOpt == null) throw new ArgumentNullException(nameof(kOpt));
		    if (kOpt.GetKind() != SequenceSyntaxKind.KOpt) throw new ArgumentException(nameof(kOpt));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    if (fragmentBody == null) throw new ArgumentNullException(nameof(fragmentBody));
		    return (OptFragmentSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.OptFragment((InternalSyntaxToken)kOpt.Node, condition == null ? null : (Syntax.InternalSyntax.TextGreen)condition.Green, (InternalSyntaxToken)lCrLf.Node, (Syntax.InternalSyntax.FragmentBodyGreen)fragmentBody.Green).CreateRed();
		}
		
		public OptFragmentSyntax OptFragment(SyntaxToken lCrLf, FragmentBodySyntax fragmentBody)
		{
			return this.OptFragment(this.Token(SequenceSyntaxKind.KOpt), default, lCrLf, fragmentBody);
		}
		
		public RefSyntax Ref(SimpleRefFragmentSyntax simpleRefFragment)
		{
		    if (simpleRefFragment == null) throw new ArgumentNullException(nameof(simpleRefFragment));
		    return (RefSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Ref((Syntax.InternalSyntax.SimpleRefFragmentGreen)simpleRefFragment.Green).CreateRed();
		}
		
		public RefSyntax Ref(MessageRefFragmentSyntax messageRefFragment)
		{
		    if (messageRefFragment == null) throw new ArgumentNullException(nameof(messageRefFragment));
		    return (RefSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Ref((Syntax.InternalSyntax.MessageRefFragmentGreen)messageRefFragment.Green).CreateRed();
		}
		
		public SimpleRefFragmentSyntax SimpleRefFragment(SyntaxToken kRef, TextSyntax over, SyntaxToken tColon, TextSyntax refText, SyntaxToken lCrLf, SimpleBodySyntax simpleBody, SyntaxToken kEndRef)
		{
		    if (kRef == null) throw new ArgumentNullException(nameof(kRef));
		    if (kRef.GetKind() != SequenceSyntaxKind.KRef) throw new ArgumentException(nameof(kRef));
		    if (tColon != null && tColon.GetKind() != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    if (simpleBody == null) throw new ArgumentNullException(nameof(simpleBody));
		    if (kEndRef == null) throw new ArgumentNullException(nameof(kEndRef));
		    if (kEndRef.GetKind() != SequenceSyntaxKind.KEndRef) throw new ArgumentException(nameof(kEndRef));
		    return (SimpleRefFragmentSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.SimpleRefFragment((InternalSyntaxToken)kRef.Node, over == null ? null : (Syntax.InternalSyntax.TextGreen)over.Green, (InternalSyntaxToken)tColon.Node, refText == null ? null : (Syntax.InternalSyntax.TextGreen)refText.Green, (InternalSyntaxToken)lCrLf.Node, (Syntax.InternalSyntax.SimpleBodyGreen)simpleBody.Green, (InternalSyntaxToken)kEndRef.Node).CreateRed();
		}
		
		public SimpleRefFragmentSyntax SimpleRefFragment(SyntaxToken lCrLf, SimpleBodySyntax simpleBody)
		{
			return this.SimpleRefFragment(this.Token(SequenceSyntaxKind.KRef), default, default, default, lCrLf, simpleBody, this.Token(SequenceSyntaxKind.KEndRef));
		}
		
		public MessageRefFragmentSyntax MessageRefFragment(RefInputSyntax refInput, SimpleBodySyntax simpleBody, RefOutputSyntax refOutput)
		{
		    if (refInput == null) throw new ArgumentNullException(nameof(refInput));
		    if (simpleBody == null) throw new ArgumentNullException(nameof(simpleBody));
		    if (refOutput == null) throw new ArgumentNullException(nameof(refOutput));
		    return (MessageRefFragmentSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.MessageRefFragment((Syntax.InternalSyntax.RefInputGreen)refInput.Green, (Syntax.InternalSyntax.SimpleBodyGreen)simpleBody.Green, (Syntax.InternalSyntax.RefOutputGreen)refOutput.Green).CreateRed();
		}
		
		public RefInputSyntax RefInput(LifeLineNameSyntax source, ArrowTypeSyntax sourceType, SyntaxToken kRef, TextSyntax over, SyntaxToken tColon, TextSyntax message, SyntaxToken lCrLf)
		{
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
		    if (kRef == null) throw new ArgumentNullException(nameof(kRef));
		    if (kRef.GetKind() != SequenceSyntaxKind.KRef) throw new ArgumentException(nameof(kRef));
		    if (tColon != null && tColon.GetKind() != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    return (RefInputSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.RefInput((Syntax.InternalSyntax.LifeLineNameGreen)source.Green, (Syntax.InternalSyntax.ArrowTypeGreen)sourceType.Green, (InternalSyntaxToken)kRef.Node, over == null ? null : (Syntax.InternalSyntax.TextGreen)over.Green, (InternalSyntaxToken)tColon.Node, message == null ? null : (Syntax.InternalSyntax.TextGreen)message.Green, (InternalSyntaxToken)lCrLf.Node).CreateRed();
		}
		
		public RefInputSyntax RefInput(LifeLineNameSyntax source, ArrowTypeSyntax sourceType, SyntaxToken lCrLf)
		{
			return this.RefInput(source, sourceType, this.Token(SequenceSyntaxKind.KRef), default, default, default, lCrLf);
		}
		
		public RefOutputSyntax RefOutput(SyntaxToken kEndRef, TextSyntax ignored, ArrowTypeSyntax targetType, LifeLineNameSyntax target, SyntaxToken tColon, TextSyntax message)
		{
		    if (kEndRef == null) throw new ArgumentNullException(nameof(kEndRef));
		    if (kEndRef.GetKind() != SequenceSyntaxKind.KEndRef) throw new ArgumentException(nameof(kEndRef));
		    if (targetType == null) throw new ArgumentNullException(nameof(targetType));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (RefOutputSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.RefOutput((InternalSyntaxToken)kEndRef.Node, ignored == null ? null : (Syntax.InternalSyntax.TextGreen)ignored.Green, (Syntax.InternalSyntax.ArrowTypeGreen)targetType.Green, (Syntax.InternalSyntax.LifeLineNameGreen)target.Green, (InternalSyntaxToken)tColon.Node, message == null ? null : (Syntax.InternalSyntax.TextGreen)message.Green).CreateRed();
		}
		
		public RefOutputSyntax RefOutput(ArrowTypeSyntax targetType, LifeLineNameSyntax target)
		{
			return this.RefOutput(this.Token(SequenceSyntaxKind.KEndRef), default, targetType, target, this.Token(SequenceSyntaxKind.TColon), default);
		}
		
		public FragmentBodySyntax FragmentBody(SyntaxList<LineSyntax> line)
		{
		    return (FragmentBodySyntax)SequenceLanguage.Instance.InternalSyntaxFactory.FragmentBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<LineGreen>(line.Node)).CreateRed();
		}
		
		public FragmentBodySyntax FragmentBody()
		{
			return this.FragmentBody(default);
		}
		
		public EndSyntax End(SyntaxToken kEnd, TextSyntax text)
		{
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != SequenceSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    return (EndSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.End((InternalSyntaxToken)kEnd.Node, text == null ? null : (Syntax.InternalSyntax.TextGreen)text.Green).CreateRed();
		}
		
		public EndSyntax End()
		{
			return this.End(this.Token(SequenceSyntaxKind.KEnd), default);
		}
		
		public NoteSyntax Note(SingleLineNoteSyntax singleLineNote)
		{
		    if (singleLineNote == null) throw new ArgumentNullException(nameof(singleLineNote));
		    return (NoteSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Note((Syntax.InternalSyntax.SingleLineNoteGreen)singleLineNote.Green).CreateRed();
		}
		
		public NoteSyntax Note(MultiLineNoteSyntax multiLineNote)
		{
		    if (multiLineNote == null) throw new ArgumentNullException(nameof(multiLineNote));
		    return (NoteSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Note((Syntax.InternalSyntax.MultiLineNoteGreen)multiLineNote.Green).CreateRed();
		}
		
		public SingleLineNoteSyntax SingleLineNote(SyntaxToken kNote, TextSyntax position, SyntaxToken tColon, TextSyntax noteText)
		{
		    if (kNote == null) throw new ArgumentNullException(nameof(kNote));
		    if (kNote.GetKind() != SequenceSyntaxKind.KNote) throw new ArgumentException(nameof(kNote));
		    if (position == null) throw new ArgumentNullException(nameof(position));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != SequenceSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (noteText == null) throw new ArgumentNullException(nameof(noteText));
		    return (SingleLineNoteSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.SingleLineNote((InternalSyntaxToken)kNote.Node, (Syntax.InternalSyntax.TextGreen)position.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.TextGreen)noteText.Green).CreateRed();
		}
		
		public SingleLineNoteSyntax SingleLineNote(TextSyntax position, TextSyntax noteText)
		{
			return this.SingleLineNote(this.Token(SequenceSyntaxKind.KNote), position, this.Token(SequenceSyntaxKind.TColon), noteText);
		}
		
		public MultiLineNoteSyntax MultiLineNote(SyntaxToken kNote, SimpleBodySyntax simpleBody, SyntaxToken kEndNote)
		{
		    if (kNote == null) throw new ArgumentNullException(nameof(kNote));
		    if (kNote.GetKind() != SequenceSyntaxKind.KNote) throw new ArgumentException(nameof(kNote));
		    if (simpleBody == null) throw new ArgumentNullException(nameof(simpleBody));
		    if (kEndNote == null) throw new ArgumentNullException(nameof(kEndNote));
		    if (kEndNote.GetKind() != SequenceSyntaxKind.KEndNote) throw new ArgumentException(nameof(kEndNote));
		    return (MultiLineNoteSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.MultiLineNote((InternalSyntaxToken)kNote.Node, (Syntax.InternalSyntax.SimpleBodyGreen)simpleBody.Green, (InternalSyntaxToken)kEndNote.Node).CreateRed();
		}
		
		public MultiLineNoteSyntax MultiLineNote(SimpleBodySyntax simpleBody)
		{
			return this.MultiLineNote(this.Token(SequenceSyntaxKind.KNote), simpleBody, this.Token(SequenceSyntaxKind.KEndNote));
		}
		
		public SimpleBodySyntax SimpleBody(SyntaxList<SimpleLineSyntax> simpleLine)
		{
		    return (SimpleBodySyntax)SequenceLanguage.Instance.InternalSyntaxFactory.SimpleBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<SimpleLineGreen>(simpleLine.Node)).CreateRed();
		}
		
		public SimpleBodySyntax SimpleBody()
		{
			return this.SimpleBody(default);
		}
		
		public SimpleLineSyntax SimpleLine(TextSyntax text, SyntaxToken lCrLf)
		{
		    if (text == null) throw new ArgumentNullException(nameof(text));
		    if (lCrLf == null) throw new ArgumentNullException(nameof(lCrLf));
		    if (lCrLf.GetKind() != SequenceSyntaxKind.LCrLf) throw new ArgumentException(nameof(lCrLf));
		    return (SimpleLineSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.SimpleLine((Syntax.InternalSyntax.TextGreen)text.Green, (InternalSyntaxToken)lCrLf.Node).CreateRed();
		}
		
		public ArrowTypeSyntax ArrowType(SyntaxToken arrowType)
		{
		    if (arrowType == null) throw new ArgumentNullException(nameof(arrowType));
		    return (ArrowTypeSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.ArrowType((InternalSyntaxToken)arrowType.Node).CreateRed();
		}
		
		public LifeLineNameSyntax LifeLineName(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (LifeLineNameSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.LifeLineName((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public IdentifierSyntax Identifier(TextSyntax text)
		{
		    if (text == null) throw new ArgumentNullException(nameof(text));
		    return (IdentifierSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Identifier((Syntax.InternalSyntax.TextGreen)text.Green).CreateRed();
		}
		
		public TextSyntax Text(SyntaxList<IdentifierPartSyntax> identifierPart)
		{
		    if (identifierPart == null) throw new ArgumentNullException(nameof(identifierPart));
		    return (TextSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.Text(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<IdentifierPartGreen>(identifierPart.Node)).CreateRed();
		}
		
		public IdentifierPartSyntax IdentifierPart(SyntaxToken lIdentifier)
		{
		    if (lIdentifier == null) throw new ArgumentNullException(nameof(lIdentifier));
		    if (lIdentifier.GetKind() != SequenceSyntaxKind.LIdentifier) throw new ArgumentException(nameof(lIdentifier));
		    return (IdentifierPartSyntax)SequenceLanguage.Instance.InternalSyntaxFactory.IdentifierPart((InternalSyntaxToken)lIdentifier.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(InteractionSyntax),
				typeof(LineSyntax),
				typeof(DeclarationSyntax),
				typeof(TitleSyntax),
				typeof(ArrowSyntax),
				typeof(DestroySyntax),
				typeof(AltSyntax),
				typeof(AltFragmentSyntax),
				typeof(ElseFragmentSyntax),
				typeof(LoopSyntax),
				typeof(LoopFragmentSyntax),
				typeof(OptSyntax),
				typeof(OptFragmentSyntax),
				typeof(RefSyntax),
				typeof(SimpleRefFragmentSyntax),
				typeof(MessageRefFragmentSyntax),
				typeof(RefInputSyntax),
				typeof(RefOutputSyntax),
				typeof(FragmentBodySyntax),
				typeof(EndSyntax),
				typeof(NoteSyntax),
				typeof(SingleLineNoteSyntax),
				typeof(MultiLineNoteSyntax),
				typeof(SimpleBodySyntax),
				typeof(SimpleLineSyntax),
				typeof(ArrowTypeSyntax),
				typeof(LifeLineNameSyntax),
				typeof(NameSyntax),
				typeof(IdentifierSyntax),
				typeof(TextSyntax),
				typeof(IdentifierPartSyntax),
			};
		}
	}
}

