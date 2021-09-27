// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Languages.Compiler.Model
{
	using global::MetaDslx.Languages.Compiler.Model.Internal;

	public class CompilerInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return CompilerInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Modeling.ModelMetadata MMetadata;
		public static readonly global::MetaDslx.Modeling.ImmutableModel MModel;
	
	
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Namespace_Members;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass NamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty NamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Grammar;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Grammar_Options;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Grammar_Rules;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass GrammarOptions;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty GrammarOptions_IsCaseInsensitive;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty GrammarOptions_IsWhitespaceIndented;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Rule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Rule_DefinedModelObject;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Rule_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass RuleAlternative;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleAlternative_Elements;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass RuleElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleElement_IsNegated;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleElement_Element;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleElement_AssignmentOperator;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleElement_Multiplicity;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Element;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass RuleReference;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleReference_Rule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass RuleBlock;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass EofElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass FixedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty FixedElement_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass WildcardElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass RangeElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RangeElement_Start;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RangeElement_End;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_IsFragment;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_IsHidden;
	
		static CompilerInstance()
		{
			CompilerBuilderInstance.instance.Create();
			CompilerBuilderInstance.instance.EvaluateLazyValues();
			MModel = CompilerBuilderInstance.instance.MModel.ToImmutable();
			MMetadata = MModel.Metadata;
	
	
			Namespace = CompilerBuilderInstance.instance.Namespace.ToImmutable(MModel);
			Namespace_Members = CompilerBuilderInstance.instance.Namespace_Members.ToImmutable(MModel);
			NamedElement = CompilerBuilderInstance.instance.NamedElement.ToImmutable(MModel);
			NamedElement_Name = CompilerBuilderInstance.instance.NamedElement_Name.ToImmutable(MModel);
			Grammar = CompilerBuilderInstance.instance.Grammar.ToImmutable(MModel);
			Grammar_Options = CompilerBuilderInstance.instance.Grammar_Options.ToImmutable(MModel);
			Grammar_Rules = CompilerBuilderInstance.instance.Grammar_Rules.ToImmutable(MModel);
			GrammarOptions = CompilerBuilderInstance.instance.GrammarOptions.ToImmutable(MModel);
			GrammarOptions_IsCaseInsensitive = CompilerBuilderInstance.instance.GrammarOptions_IsCaseInsensitive.ToImmutable(MModel);
			GrammarOptions_IsWhitespaceIndented = CompilerBuilderInstance.instance.GrammarOptions_IsWhitespaceIndented.ToImmutable(MModel);
			Rule = CompilerBuilderInstance.instance.Rule.ToImmutable(MModel);
			Rule_DefinedModelObject = CompilerBuilderInstance.instance.Rule_DefinedModelObject.ToImmutable(MModel);
			Rule_Alternatives = CompilerBuilderInstance.instance.Rule_Alternatives.ToImmutable(MModel);
			RuleAlternative = CompilerBuilderInstance.instance.RuleAlternative.ToImmutable(MModel);
			RuleAlternative_Elements = CompilerBuilderInstance.instance.RuleAlternative_Elements.ToImmutable(MModel);
			RuleElement = CompilerBuilderInstance.instance.RuleElement.ToImmutable(MModel);
			RuleElement_IsNegated = CompilerBuilderInstance.instance.RuleElement_IsNegated.ToImmutable(MModel);
			RuleElement_Element = CompilerBuilderInstance.instance.RuleElement_Element.ToImmutable(MModel);
			RuleElement_AssignmentOperator = CompilerBuilderInstance.instance.RuleElement_AssignmentOperator.ToImmutable(MModel);
			RuleElement_Multiplicity = CompilerBuilderInstance.instance.RuleElement_Multiplicity.ToImmutable(MModel);
			Element = CompilerBuilderInstance.instance.Element.ToImmutable(MModel);
			RuleReference = CompilerBuilderInstance.instance.RuleReference.ToImmutable(MModel);
			RuleReference_Rule = CompilerBuilderInstance.instance.RuleReference_Rule.ToImmutable(MModel);
			RuleBlock = CompilerBuilderInstance.instance.RuleBlock.ToImmutable(MModel);
			EofElement = CompilerBuilderInstance.instance.EofElement.ToImmutable(MModel);
			FixedElement = CompilerBuilderInstance.instance.FixedElement.ToImmutable(MModel);
			FixedElement_Value = CompilerBuilderInstance.instance.FixedElement_Value.ToImmutable(MModel);
			WildcardElement = CompilerBuilderInstance.instance.WildcardElement.ToImmutable(MModel);
			RangeElement = CompilerBuilderInstance.instance.RangeElement.ToImmutable(MModel);
			RangeElement_Start = CompilerBuilderInstance.instance.RangeElement_Start.ToImmutable(MModel);
			RangeElement_End = CompilerBuilderInstance.instance.RangeElement_End.ToImmutable(MModel);
			ParserRule = CompilerBuilderInstance.instance.ParserRule.ToImmutable(MModel);
			LexerRule = CompilerBuilderInstance.instance.LexerRule.ToImmutable(MModel);
			LexerRule_IsFragment = CompilerBuilderInstance.instance.LexerRule_IsFragment.ToImmutable(MModel);
			LexerRule_IsHidden = CompilerBuilderInstance.instance.LexerRule_IsHidden.ToImmutable(MModel);
	
			CompilerInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class CompilerFactory : global::MetaDslx.Modeling.ModelFactoryBase
	{
		public CompilerFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			CompilerDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Modeling.MutableObject Create(string type)
		{
			switch (type)
			{
				case "Namespace": return this.Namespace();
				case "NamedElement": return this.NamedElement();
				case "Grammar": return this.Grammar();
				case "GrammarOptions": return this.GrammarOptions();
				case "RuleAlternative": return this.RuleAlternative();
				case "RuleElement": return this.RuleElement();
				case "RuleReference": return this.RuleReference();
				case "RuleBlock": return this.RuleBlock();
				case "EofElement": return this.EofElement();
				case "FixedElement": return this.FixedElement();
				case "WildcardElement": return this.WildcardElement();
				case "RangeElement": return this.RangeElement();
				case "ParserRule": return this.ParserRule();
				case "LexerRule": return this.LexerRule();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Namespace.
		/// </summary>
		public NamespaceBuilder Namespace()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new NamespaceId());
			return (NamespaceBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of NamedElement.
		/// </summary>
		public NamedElementBuilder NamedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new NamedElementId());
			return (NamedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Grammar.
		/// </summary>
		public GrammarBuilder Grammar()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new GrammarId());
			return (GrammarBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of GrammarOptions.
		/// </summary>
		public GrammarOptionsBuilder GrammarOptions()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new GrammarOptionsId());
			return (GrammarOptionsBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of RuleAlternative.
		/// </summary>
		public RuleAlternativeBuilder RuleAlternative()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new RuleAlternativeId());
			return (RuleAlternativeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of RuleElement.
		/// </summary>
		public RuleElementBuilder RuleElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new RuleElementId());
			return (RuleElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of RuleReference.
		/// </summary>
		public RuleReferenceBuilder RuleReference()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new RuleReferenceId());
			return (RuleReferenceBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of RuleBlock.
		/// </summary>
		public RuleBlockBuilder RuleBlock()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new RuleBlockId());
			return (RuleBlockBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of EofElement.
		/// </summary>
		public EofElementBuilder EofElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new EofElementId());
			return (EofElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of FixedElement.
		/// </summary>
		public FixedElementBuilder FixedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new FixedElementId());
			return (FixedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of WildcardElement.
		/// </summary>
		public WildcardElementBuilder WildcardElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new WildcardElementId());
			return (WildcardElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of RangeElement.
		/// </summary>
		public RangeElementBuilder RangeElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new RangeElementId());
			return (RangeElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRule.
		/// </summary>
		public ParserRuleBuilder ParserRule()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleId());
			return (ParserRuleBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRule.
		/// </summary>
		public LexerRuleBuilder LexerRule()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleId());
			return (LexerRuleBuilder)obj;
		}
	}

	
	public enum Multiplicity
	{
		ExactlyOne,
		ZeroOrOne,
		ZeroOrMore,
		OneOrMore,
		NonGreedyZeroOrOne,
		NonGreedyZeroOrMore,
		NonGreedyOneOrMore
	}
	
	public static class MultiplicityExtensions
	{
	}
	
	public enum AssignmentOperator
	{
		Assign,
		QuestionAssign,
		NegatedAssign,
		PlusAssign
	}
	
	public static class AssignmentOperatorExtensions
	{
	}
	
	public interface Namespace : NamedElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<NamedElement> Members { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Namespace"/> object to a builder <see cref="NamespaceBuilder"/> object.
		/// </summary>
		new NamespaceBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Namespace"/> object to a builder <see cref="NamespaceBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new NamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NamespaceBuilder : NamedElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<NamedElementBuilder> Members { get; }
	
	
		/// <summary>
		/// Convert the <see cref="NamespaceBuilder"/> object to an immutable <see cref="Namespace"/> object.
		/// </summary>
		new Namespace ToImmutable();
		/// <summary>
		/// Convert the <see cref="NamespaceBuilder"/> object to an immutable <see cref="Namespace"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Namespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface NamedElement : global::MetaDslx.Modeling.ImmutableObject
	{
		string Name { get; }
	
	
		/// <summary>
		/// Convert the <see cref="NamedElement"/> object to a builder <see cref="NamedElementBuilder"/> object.
		/// </summary>
		new NamedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="NamedElement"/> object to a builder <see cref="NamedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new NamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NamedElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
		string Name { get; set; }
		void SetNameLazy(global::System.Func<string> lazy);
		void SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy);
		void SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="NamedElementBuilder"/> object to an immutable <see cref="NamedElement"/> object.
		/// </summary>
		new NamedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="NamedElementBuilder"/> object to an immutable <see cref="NamedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new NamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Grammar : NamedElement
	{
		GrammarOptions Options { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Rule> Rules { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Grammar"/> object to a builder <see cref="GrammarBuilder"/> object.
		/// </summary>
		new GrammarBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Grammar"/> object to a builder <see cref="GrammarBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new GrammarBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface GrammarBuilder : NamedElementBuilder
	{
		GrammarOptionsBuilder Options { get; set; }
		void SetOptionsLazy(global::System.Func<GrammarOptionsBuilder> lazy);
		void SetOptionsLazy(global::System.Func<GrammarBuilder, GrammarOptionsBuilder> lazy);
		void SetOptionsLazy(global::System.Func<Grammar, GrammarOptions> immutableLazy, global::System.Func<GrammarBuilder, GrammarOptionsBuilder> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<RuleBuilder> Rules { get; }
	
	
		/// <summary>
		/// Convert the <see cref="GrammarBuilder"/> object to an immutable <see cref="Grammar"/> object.
		/// </summary>
		new Grammar ToImmutable();
		/// <summary>
		/// Convert the <see cref="GrammarBuilder"/> object to an immutable <see cref="Grammar"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Grammar ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface GrammarOptions : global::MetaDslx.Modeling.ImmutableObject
	{
		bool IsCaseInsensitive { get; }
		bool IsWhitespaceIndented { get; }
	
	
		/// <summary>
		/// Convert the <see cref="GrammarOptions"/> object to a builder <see cref="GrammarOptionsBuilder"/> object.
		/// </summary>
		new GrammarOptionsBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="GrammarOptions"/> object to a builder <see cref="GrammarOptionsBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new GrammarOptionsBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface GrammarOptionsBuilder : global::MetaDslx.Modeling.MutableObject
	{
		bool IsCaseInsensitive { get; set; }
		void SetIsCaseInsensitiveLazy(global::System.Func<bool> lazy);
		void SetIsCaseInsensitiveLazy(global::System.Func<GrammarOptionsBuilder, bool> lazy);
		void SetIsCaseInsensitiveLazy(global::System.Func<GrammarOptions, bool> immutableLazy, global::System.Func<GrammarOptionsBuilder, bool> mutableLazy);
		bool IsWhitespaceIndented { get; set; }
		void SetIsWhitespaceIndentedLazy(global::System.Func<bool> lazy);
		void SetIsWhitespaceIndentedLazy(global::System.Func<GrammarOptionsBuilder, bool> lazy);
		void SetIsWhitespaceIndentedLazy(global::System.Func<GrammarOptions, bool> immutableLazy, global::System.Func<GrammarOptionsBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="GrammarOptionsBuilder"/> object to an immutable <see cref="GrammarOptions"/> object.
		/// </summary>
		new GrammarOptions ToImmutable();
		/// <summary>
		/// Convert the <see cref="GrammarOptionsBuilder"/> object to an immutable <see cref="GrammarOptions"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new GrammarOptions ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Rule : NamedElement
	{
		System.Type DefinedModelObject { get; }
		global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Rule"/> object to a builder <see cref="RuleBuilder"/> object.
		/// </summary>
		new RuleBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Rule"/> object to a builder <see cref="RuleBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RuleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RuleBuilder : NamedElementBuilder
	{
		System.Type DefinedModelObject { get; set; }
		void SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy);
		void SetDefinedModelObjectLazy(global::System.Func<RuleBuilder, System.Type> lazy);
		void SetDefinedModelObjectLazy(global::System.Func<Rule, System.Type> immutableLazy, global::System.Func<RuleBuilder, System.Type> mutableLazy);
		global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RuleBuilder"/> object to an immutable <see cref="Rule"/> object.
		/// </summary>
		new Rule ToImmutable();
		/// <summary>
		/// Convert the <see cref="RuleBuilder"/> object to an immutable <see cref="Rule"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Rule ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RuleAlternative : NamedElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<RuleElement> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RuleAlternative"/> object to a builder <see cref="RuleAlternativeBuilder"/> object.
		/// </summary>
		new RuleAlternativeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="RuleAlternative"/> object to a builder <see cref="RuleAlternativeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RuleAlternativeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RuleAlternativeBuilder : NamedElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<RuleElementBuilder> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RuleAlternativeBuilder"/> object to an immutable <see cref="RuleAlternative"/> object.
		/// </summary>
		new RuleAlternative ToImmutable();
		/// <summary>
		/// Convert the <see cref="RuleAlternativeBuilder"/> object to an immutable <see cref="RuleAlternative"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new RuleAlternative ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RuleElement : NamedElement
	{
		bool IsNegated { get; }
		Element Element { get; }
		AssignmentOperator AssignmentOperator { get; }
		Multiplicity Multiplicity { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RuleElement"/> object to a builder <see cref="RuleElementBuilder"/> object.
		/// </summary>
		new RuleElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="RuleElement"/> object to a builder <see cref="RuleElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RuleElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RuleElementBuilder : NamedElementBuilder
	{
		bool IsNegated { get; set; }
		void SetIsNegatedLazy(global::System.Func<bool> lazy);
		void SetIsNegatedLazy(global::System.Func<RuleElementBuilder, bool> lazy);
		void SetIsNegatedLazy(global::System.Func<RuleElement, bool> immutableLazy, global::System.Func<RuleElementBuilder, bool> mutableLazy);
		ElementBuilder Element { get; set; }
		void SetElementLazy(global::System.Func<ElementBuilder> lazy);
		void SetElementLazy(global::System.Func<RuleElementBuilder, ElementBuilder> lazy);
		void SetElementLazy(global::System.Func<RuleElement, Element> immutableLazy, global::System.Func<RuleElementBuilder, ElementBuilder> mutableLazy);
		AssignmentOperator AssignmentOperator { get; set; }
		void SetAssignmentOperatorLazy(global::System.Func<AssignmentOperator> lazy);
		void SetAssignmentOperatorLazy(global::System.Func<RuleElementBuilder, AssignmentOperator> lazy);
		void SetAssignmentOperatorLazy(global::System.Func<RuleElement, AssignmentOperator> immutableLazy, global::System.Func<RuleElementBuilder, AssignmentOperator> mutableLazy);
		Multiplicity Multiplicity { get; set; }
		void SetMultiplicityLazy(global::System.Func<Multiplicity> lazy);
		void SetMultiplicityLazy(global::System.Func<RuleElementBuilder, Multiplicity> lazy);
		void SetMultiplicityLazy(global::System.Func<RuleElement, Multiplicity> immutableLazy, global::System.Func<RuleElementBuilder, Multiplicity> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="RuleElementBuilder"/> object to an immutable <see cref="RuleElement"/> object.
		/// </summary>
		new RuleElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="RuleElementBuilder"/> object to an immutable <see cref="RuleElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new RuleElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Element : global::MetaDslx.Modeling.ImmutableObject
	{
	
	
		/// <summary>
		/// Convert the <see cref="Element"/> object to a builder <see cref="ElementBuilder"/> object.
		/// </summary>
		new ElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Element"/> object to a builder <see cref="ElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
	
	
		/// <summary>
		/// Convert the <see cref="ElementBuilder"/> object to an immutable <see cref="Element"/> object.
		/// </summary>
		new Element ToImmutable();
		/// <summary>
		/// Convert the <see cref="ElementBuilder"/> object to an immutable <see cref="Element"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Element ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RuleReference : Element
	{
		Rule Rule { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RuleReference"/> object to a builder <see cref="RuleReferenceBuilder"/> object.
		/// </summary>
		new RuleReferenceBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="RuleReference"/> object to a builder <see cref="RuleReferenceBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RuleReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RuleReferenceBuilder : ElementBuilder
	{
		RuleBuilder Rule { get; set; }
		void SetRuleLazy(global::System.Func<RuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<RuleReferenceBuilder, RuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<RuleReference, Rule> immutableLazy, global::System.Func<RuleReferenceBuilder, RuleBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="RuleReferenceBuilder"/> object to an immutable <see cref="RuleReference"/> object.
		/// </summary>
		new RuleReference ToImmutable();
		/// <summary>
		/// Convert the <see cref="RuleReferenceBuilder"/> object to an immutable <see cref="RuleReference"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new RuleReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RuleBlock : Rule, Element
	{
	
	
		/// <summary>
		/// Convert the <see cref="RuleBlock"/> object to a builder <see cref="RuleBlockBuilder"/> object.
		/// </summary>
		new RuleBlockBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="RuleBlock"/> object to a builder <see cref="RuleBlockBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RuleBlockBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RuleBlockBuilder : RuleBuilder, ElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="RuleBlockBuilder"/> object to an immutable <see cref="RuleBlock"/> object.
		/// </summary>
		new RuleBlock ToImmutable();
		/// <summary>
		/// Convert the <see cref="RuleBlockBuilder"/> object to an immutable <see cref="RuleBlock"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new RuleBlock ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EofElement : Element
	{
	
	
		/// <summary>
		/// Convert the <see cref="EofElement"/> object to a builder <see cref="EofElementBuilder"/> object.
		/// </summary>
		new EofElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="EofElement"/> object to a builder <see cref="EofElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new EofElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EofElementBuilder : ElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="EofElementBuilder"/> object to an immutable <see cref="EofElement"/> object.
		/// </summary>
		new EofElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="EofElementBuilder"/> object to an immutable <see cref="EofElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new EofElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface FixedElement : Element
	{
		string Value { get; }
	
	
		/// <summary>
		/// Convert the <see cref="FixedElement"/> object to a builder <see cref="FixedElementBuilder"/> object.
		/// </summary>
		new FixedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="FixedElement"/> object to a builder <see cref="FixedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new FixedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface FixedElementBuilder : ElementBuilder
	{
		string Value { get; set; }
		void SetValueLazy(global::System.Func<string> lazy);
		void SetValueLazy(global::System.Func<FixedElementBuilder, string> lazy);
		void SetValueLazy(global::System.Func<FixedElement, string> immutableLazy, global::System.Func<FixedElementBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="FixedElementBuilder"/> object to an immutable <see cref="FixedElement"/> object.
		/// </summary>
		new FixedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="FixedElementBuilder"/> object to an immutable <see cref="FixedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new FixedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface WildcardElement : Element
	{
	
	
		/// <summary>
		/// Convert the <see cref="WildcardElement"/> object to a builder <see cref="WildcardElementBuilder"/> object.
		/// </summary>
		new WildcardElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="WildcardElement"/> object to a builder <see cref="WildcardElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new WildcardElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface WildcardElementBuilder : ElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="WildcardElementBuilder"/> object to an immutable <see cref="WildcardElement"/> object.
		/// </summary>
		new WildcardElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="WildcardElementBuilder"/> object to an immutable <see cref="WildcardElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new WildcardElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RangeElement : Element
	{
		FixedElement Start { get; }
		FixedElement End { get; }
	
	
		/// <summary>
		/// Convert the <see cref="RangeElement"/> object to a builder <see cref="RangeElementBuilder"/> object.
		/// </summary>
		new RangeElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="RangeElement"/> object to a builder <see cref="RangeElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new RangeElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RangeElementBuilder : ElementBuilder
	{
		FixedElementBuilder Start { get; set; }
		void SetStartLazy(global::System.Func<FixedElementBuilder> lazy);
		void SetStartLazy(global::System.Func<RangeElementBuilder, FixedElementBuilder> lazy);
		void SetStartLazy(global::System.Func<RangeElement, FixedElement> immutableLazy, global::System.Func<RangeElementBuilder, FixedElementBuilder> mutableLazy);
		FixedElementBuilder End { get; set; }
		void SetEndLazy(global::System.Func<FixedElementBuilder> lazy);
		void SetEndLazy(global::System.Func<RangeElementBuilder, FixedElementBuilder> lazy);
		void SetEndLazy(global::System.Func<RangeElement, FixedElement> immutableLazy, global::System.Func<RangeElementBuilder, FixedElementBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="RangeElementBuilder"/> object to an immutable <see cref="RangeElement"/> object.
		/// </summary>
		new RangeElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="RangeElementBuilder"/> object to an immutable <see cref="RangeElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new RangeElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRule : Rule
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRule"/> object to a builder <see cref="ParserRuleBuilder"/> object.
		/// </summary>
		new ParserRuleBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRule"/> object to a builder <see cref="ParserRuleBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleBuilder : RuleBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleBuilder"/> object to an immutable <see cref="ParserRule"/> object.
		/// </summary>
		new ParserRule ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleBuilder"/> object to an immutable <see cref="ParserRule"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRule ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRule : Rule
	{
		bool IsFragment { get; }
		bool IsHidden { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRule"/> object to a builder <see cref="LexerRuleBuilder"/> object.
		/// </summary>
		new LexerRuleBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRule"/> object to a builder <see cref="LexerRuleBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleBuilder : RuleBuilder
	{
		bool IsFragment { get; set; }
		void SetIsFragmentLazy(global::System.Func<bool> lazy);
		void SetIsFragmentLazy(global::System.Func<LexerRuleBuilder, bool> lazy);
		void SetIsFragmentLazy(global::System.Func<LexerRule, bool> immutableLazy, global::System.Func<LexerRuleBuilder, bool> mutableLazy);
		bool IsHidden { get; set; }
		void SetIsHiddenLazy(global::System.Func<bool> lazy);
		void SetIsHiddenLazy(global::System.Func<LexerRuleBuilder, bool> lazy);
		void SetIsHiddenLazy(global::System.Func<LexerRule, bool> immutableLazy, global::System.Func<LexerRuleBuilder, bool> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleBuilder"/> object to an immutable <see cref="LexerRule"/> object.
		/// </summary>
		new LexerRule ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleBuilder"/> object to an immutable <see cref="LexerRule"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRule ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class CompilerDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static CompilerDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			Namespace.Initialize();
			NamedElement.Initialize();
			Grammar.Initialize();
			GrammarOptions.Initialize();
			Rule.Initialize();
			RuleAlternative.Initialize();
			RuleElement.Initialize();
			Element.Initialize();
			RuleReference.Initialize();
			RuleBlock.Initialize();
			EofElement.Initialize();
			FixedElement.Initialize();
			WildcardElement.Initialize();
			RangeElement.Initialize();
			ParserRule.Initialize();
			LexerRule.Initialize();
			properties.Add(CompilerDescriptor.Namespace.MembersProperty);
			properties.Add(CompilerDescriptor.NamedElement.NameProperty);
			properties.Add(CompilerDescriptor.Grammar.OptionsProperty);
			properties.Add(CompilerDescriptor.Grammar.RulesProperty);
			properties.Add(CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty);
			properties.Add(CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty);
			properties.Add(CompilerDescriptor.Rule.DefinedModelObjectProperty);
			properties.Add(CompilerDescriptor.Rule.AlternativesProperty);
			properties.Add(CompilerDescriptor.RuleAlternative.ElementsProperty);
			properties.Add(CompilerDescriptor.RuleElement.IsNegatedProperty);
			properties.Add(CompilerDescriptor.RuleElement.ElementProperty);
			properties.Add(CompilerDescriptor.RuleElement.AssignmentOperatorProperty);
			properties.Add(CompilerDescriptor.RuleElement.MultiplicityProperty);
			properties.Add(CompilerDescriptor.RuleReference.RuleProperty);
			properties.Add(CompilerDescriptor.FixedElement.ValueProperty);
			properties.Add(CompilerDescriptor.RangeElement.StartProperty);
			properties.Add(CompilerDescriptor.RangeElement.EndProperty);
			properties.Add(CompilerDescriptor.LexerRule.IsFragmentProperty);
			properties.Add(CompilerDescriptor.LexerRule.IsHiddenProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://MetaDslx.Languages.Compiler/1.0";
		public const string MPrefix = "";
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.NamespaceId), typeof(global::MetaDslx.Languages.Compiler.Model.Namespace), typeof(global::MetaDslx.Languages.Compiler.Model.NamespaceBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class Namespace
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Namespace()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Namespace));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Namespace; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty MembersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Namespace), name: "Members",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.NamedElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.NamedElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Namespace_Members,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.NamedElementId), typeof(global::MetaDslx.Languages.Compiler.Model.NamedElement), typeof(global::MetaDslx.Languages.Compiler.Model.NamedElementBuilder))]
		public static class NamedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static NamedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(NamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.NamedElement; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Name")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(NamedElement), name: "Name",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.NamedElement_Name,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.GrammarId), typeof(global::MetaDslx.Languages.Compiler.Model.Grammar), typeof(global::MetaDslx.Languages.Compiler.Model.GrammarBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class Grammar
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Grammar()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Grammar));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Grammar; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty OptionsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Grammar), name: "Options",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.GrammarOptions),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.GrammarOptionsBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Grammar_Options,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty RulesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Grammar), name: "Rules",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Rule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Grammar_Rules,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.GrammarOptionsId), typeof(global::MetaDslx.Languages.Compiler.Model.GrammarOptions), typeof(global::MetaDslx.Languages.Compiler.Model.GrammarOptionsBuilder))]
		public static class GrammarOptions
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static GrammarOptions()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(GrammarOptions));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.GrammarOptions; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsCaseInsensitiveProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(GrammarOptions), name: "IsCaseInsensitive",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.GrammarOptions_IsCaseInsensitive,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsWhitespaceIndentedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(GrammarOptions), name: "IsWhitespaceIndented",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.GrammarOptions_IsWhitespaceIndented,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.RuleId), typeof(global::MetaDslx.Languages.Compiler.Model.Rule), typeof(global::MetaDslx.Languages.Compiler.Model.RuleBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class Rule
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Rule()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Rule));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Rule; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefinedModelObjectProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Rule), name: "DefinedModelObject",
			        immutableType: typeof(System.Type),
			        mutableType: typeof(System.Type),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Rule_DefinedModelObject,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Rule), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleAlternative),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleAlternativeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Rule_Alternatives,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.RuleAlternativeId), typeof(global::MetaDslx.Languages.Compiler.Model.RuleAlternative), typeof(global::MetaDslx.Languages.Compiler.Model.RuleAlternativeBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class RuleAlternative
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static RuleAlternative()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(RuleAlternative));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleAlternative; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleAlternative), name: "Elements",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleAlternative_Elements,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.RuleElementId), typeof(global::MetaDslx.Languages.Compiler.Model.RuleElement), typeof(global::MetaDslx.Languages.Compiler.Model.RuleElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class RuleElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static RuleElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(RuleElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsNegatedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleElement), name: "IsNegated",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleElement_IsNegated,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleElement), name: "Element",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Element),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleElement_Element,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AssignmentOperatorProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleElement), name: "AssignmentOperator",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AssignmentOperator),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AssignmentOperator),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleElement_AssignmentOperator,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty MultiplicityProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleElement), name: "Multiplicity",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleElement_Multiplicity,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ElementId), typeof(global::MetaDslx.Languages.Compiler.Model.Element), typeof(global::MetaDslx.Languages.Compiler.Model.ElementBuilder))]
		public static class Element
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Element()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Element));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Element; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.RuleReferenceId), typeof(global::MetaDslx.Languages.Compiler.Model.RuleReference), typeof(global::MetaDslx.Languages.Compiler.Model.RuleReferenceBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Element) })]
		public static class RuleReference
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static RuleReference()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(RuleReference));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleReference; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty RuleProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleReference), name: "Rule",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Rule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleReference_Rule,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.RuleBlockId), typeof(global::MetaDslx.Languages.Compiler.Model.RuleBlock), typeof(global::MetaDslx.Languages.Compiler.Model.RuleBlockBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Rule), typeof(CompilerDescriptor.Element) })]
		public static class RuleBlock
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static RuleBlock()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(RuleBlock));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleBlock; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.EofElementId), typeof(global::MetaDslx.Languages.Compiler.Model.EofElement), typeof(global::MetaDslx.Languages.Compiler.Model.EofElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Element) })]
		public static class EofElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static EofElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(EofElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.EofElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.FixedElementId), typeof(global::MetaDslx.Languages.Compiler.Model.FixedElement), typeof(global::MetaDslx.Languages.Compiler.Model.FixedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Element) })]
		public static class FixedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static FixedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(FixedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.FixedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(FixedElement), name: "Value",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.FixedElement_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.WildcardElementId), typeof(global::MetaDslx.Languages.Compiler.Model.WildcardElement), typeof(global::MetaDslx.Languages.Compiler.Model.WildcardElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Element) })]
		public static class WildcardElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static WildcardElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(WildcardElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.WildcardElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.RangeElementId), typeof(global::MetaDslx.Languages.Compiler.Model.RangeElement), typeof(global::MetaDslx.Languages.Compiler.Model.RangeElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Element) })]
		public static class RangeElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static RangeElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(RangeElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RangeElement; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty StartProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RangeElement), name: "Start",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.FixedElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.FixedElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RangeElement_Start,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EndProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RangeElement), name: "End",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.FixedElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.FixedElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RangeElement_End,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRule), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Rule) })]
		public static class ParserRule
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRule()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRule));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRule; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRule), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.Rule) })]
		public static class LexerRule
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRule()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRule));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelObjectDescriptor MDescriptor
			{
				get { return descriptor; }
			}
		
			public static global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass
			{
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsFragmentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRule), name: "IsFragment",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule_IsFragment,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsHiddenProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRule), name: "IsHidden",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule_IsHidden,
					defaultValue: null);
		}
	}
}

namespace MetaDslx.Languages.Compiler.Model.Internal
{
	
	internal class NamespaceId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Namespace.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamespaceImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Namespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<NamedElement> members0;
	
		internal NamespaceImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Namespace;
	
		public new NamespaceBuilder ToMutable()
		{
			return (NamespaceBuilder)base.ToMutable();
		}
	
		public new NamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NamespaceBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<NamedElement> Members
		{
		    get { return this.GetList<NamedElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Namespace.MembersProperty, ref members0); }
		}
	}
	
	internal class NamespaceBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, NamespaceBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<NamedElementBuilder> members0;
	
		internal NamespaceBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.Namespace(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Namespace;
	
		public new Namespace ToImmutable()
		{
			return (Namespace)base.ToImmutable();
		}
	
		public new Namespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Namespace)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<NamedElementBuilder> Members
		{
			get { return this.GetList<NamedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Namespace.MembersProperty, ref members0); }
		}
	}
	
	internal class NamedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, NamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal NamedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.NamedElement;
	
		public new NamedElementBuilder ToMutable()
		{
			return (NamedElementBuilder)base.ToMutable();
		}
	
		public new NamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NamedElementBuilder)base.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class NamedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, NamedElementBuilder
	{
	
		internal NamedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.NamedElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.NamedElement;
	
		public new NamedElement ToImmutable()
		{
			return (NamedElement)base.ToImmutable();
		}
	
		public new NamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (NamedElement)base.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class GrammarId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new GrammarImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new GrammarBuilderImpl(this, model, creating);
		}
	}
	
	internal class GrammarImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Grammar
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private GrammarOptions options0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Rule> rules0;
	
		internal GrammarImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Grammar;
	
		public new GrammarBuilder ToMutable()
		{
			return (GrammarBuilder)base.ToMutable();
		}
	
		public new GrammarBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (GrammarBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public GrammarOptions Options
		{
		    get { return this.GetReference<GrammarOptions>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.OptionsProperty, ref options0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Rule> Rules
		{
		    get { return this.GetList<Rule>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.RulesProperty, ref rules0); }
		}
	}
	
	internal class GrammarBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, GrammarBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<RuleBuilder> rules0;
	
		internal GrammarBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.Grammar(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Grammar;
	
		public new Grammar ToImmutable()
		{
			return (Grammar)base.ToImmutable();
		}
	
		public new Grammar ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Grammar)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public GrammarOptionsBuilder Options
		{
			get { return this.GetReference<GrammarOptionsBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.OptionsProperty); }
			set { this.SetReference<GrammarOptionsBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.OptionsProperty, value); }
		}
		
		void GrammarBuilder.SetOptionsLazy(global::System.Func<GrammarOptionsBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Grammar.OptionsProperty, lazy);
		}
		
		void GrammarBuilder.SetOptionsLazy(global::System.Func<GrammarBuilder, GrammarOptionsBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Grammar.OptionsProperty, lazy);
		}
		
		void GrammarBuilder.SetOptionsLazy(global::System.Func<Grammar, GrammarOptions> immutableLazy, global::System.Func<GrammarBuilder, GrammarOptionsBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.Grammar.OptionsProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleBuilder> Rules
		{
			get { return this.GetList<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.RulesProperty, ref rules0); }
		}
	}
	
	internal class GrammarOptionsId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new GrammarOptionsImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new GrammarOptionsBuilderImpl(this, model, creating);
		}
	}
	
	internal class GrammarOptionsImpl : global::MetaDslx.Modeling.ImmutableObjectBase, GrammarOptions
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isCaseInsensitive0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isWhitespaceIndented0;
	
		internal GrammarOptionsImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.GrammarOptions;
	
		public new GrammarOptionsBuilder ToMutable()
		{
			return (GrammarOptionsBuilder)base.ToMutable();
		}
	
		public new GrammarOptionsBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (GrammarOptionsBuilder)base.ToMutable(model);
		}
	
		
		public bool IsCaseInsensitive
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty, ref isCaseInsensitive0); }
		}
	
		
		public bool IsWhitespaceIndented
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty, ref isWhitespaceIndented0); }
		}
	}
	
	internal class GrammarOptionsBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, GrammarOptionsBuilder
	{
	
		internal GrammarOptionsBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.GrammarOptions(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.GrammarOptions;
	
		public new GrammarOptions ToImmutable()
		{
			return (GrammarOptions)base.ToImmutable();
		}
	
		public new GrammarOptions ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (GrammarOptions)base.ToImmutable(model);
		}
	
		
		public bool IsCaseInsensitive
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty, value); }
		}
		
		void GrammarOptionsBuilder.SetIsCaseInsensitiveLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty, lazy);
		}
		
		void GrammarOptionsBuilder.SetIsCaseInsensitiveLazy(global::System.Func<GrammarOptionsBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty, lazy);
		}
		
		void GrammarOptionsBuilder.SetIsCaseInsensitiveLazy(global::System.Func<GrammarOptions, bool> immutableLazy, global::System.Func<GrammarOptionsBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsWhitespaceIndented
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty, value); }
		}
		
		void GrammarOptionsBuilder.SetIsWhitespaceIndentedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty, lazy);
		}
		
		void GrammarOptionsBuilder.SetIsWhitespaceIndentedLazy(global::System.Func<GrammarOptionsBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty, lazy);
		}
		
		void GrammarOptionsBuilder.SetIsWhitespaceIndentedLazy(global::System.Func<GrammarOptions, bool> immutableLazy, global::System.Func<GrammarOptionsBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class RuleId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RuleImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RuleBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuleImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Rule
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> alternatives0;
	
		internal RuleImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Rule;
	
		public new RuleBuilder ToMutable()
		{
			return (RuleBuilder)base.ToMutable();
		}
	
		public new RuleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RuleBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> Alternatives
		{
		    get { return this.GetList<RuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class RuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> alternatives0;
	
		internal RuleBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.Rule(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Rule;
	
		public new Rule ToImmutable()
		{
			return (Rule)base.ToImmutable();
		}
	
		public new Rule ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Rule)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public System.Type DefinedModelObject
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, value); }
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<RuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<Rule, System.Type> immutableLazy, global::System.Func<RuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<RuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class RuleAlternativeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleAlternative.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RuleAlternativeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RuleAlternativeBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuleAlternativeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, RuleAlternative
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<RuleElement> elements0;
	
		internal RuleAlternativeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleAlternative;
	
		public new RuleAlternativeBuilder ToMutable()
		{
			return (RuleAlternativeBuilder)base.ToMutable();
		}
	
		public new RuleAlternativeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RuleAlternativeBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<RuleElement> Elements
		{
		    get { return this.GetList<RuleElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class RuleAlternativeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleAlternativeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<RuleElementBuilder> elements0;
	
		internal RuleAlternativeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.RuleAlternative(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleAlternative;
	
		public new RuleAlternative ToImmutable()
		{
			return (RuleAlternative)base.ToImmutable();
		}
	
		public new RuleAlternative ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RuleAlternative)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleElementBuilder> Elements
		{
			get { return this.GetList<RuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class RuleElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RuleElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RuleElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuleElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, RuleElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isNegated0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Element element0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AssignmentOperator assignmentOperator0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
	
		internal RuleElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleElement;
	
		public new RuleElementBuilder ToMutable()
		{
			return (RuleElementBuilder)base.ToMutable();
		}
	
		public new RuleElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RuleElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public bool IsNegated
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.IsNegatedProperty, ref isNegated0); }
		}
	
		
		public Element Element
		{
		    get { return this.GetReference<Element>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.ElementProperty, ref element0); }
		}
	
		
		public AssignmentOperator AssignmentOperator
		{
		    get { return this.GetValue<AssignmentOperator>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.AssignmentOperatorProperty, ref assignmentOperator0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty, ref multiplicity0); }
		}
	}
	
	internal class RuleElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleElementBuilder
	{
	
		internal RuleElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.RuleElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleElement;
	
		public new RuleElement ToImmutable()
		{
			return (RuleElement)base.ToImmutable();
		}
	
		public new RuleElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RuleElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsNegated
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.IsNegatedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.IsNegatedProperty, value); }
		}
		
		void RuleElementBuilder.SetIsNegatedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.IsNegatedProperty, lazy);
		}
		
		void RuleElementBuilder.SetIsNegatedLazy(global::System.Func<RuleElementBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.IsNegatedProperty, lazy);
		}
		
		void RuleElementBuilder.SetIsNegatedLazy(global::System.Func<RuleElement, bool> immutableLazy, global::System.Func<RuleElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.IsNegatedProperty, immutableLazy, mutableLazy);
		}
	
		
		public ElementBuilder Element
		{
			get { return this.GetReference<ElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.ElementProperty); }
			set { this.SetReference<ElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.ElementProperty, value); }
		}
		
		void RuleElementBuilder.SetElementLazy(global::System.Func<ElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RuleElement.ElementProperty, lazy);
		}
		
		void RuleElementBuilder.SetElementLazy(global::System.Func<RuleElementBuilder, ElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RuleElement.ElementProperty, lazy);
		}
		
		void RuleElementBuilder.SetElementLazy(global::System.Func<RuleElement, Element> immutableLazy, global::System.Func<RuleElementBuilder, ElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.RuleElement.ElementProperty, immutableLazy, mutableLazy);
		}
	
		
		public AssignmentOperator AssignmentOperator
		{
			get { return this.GetValue<AssignmentOperator>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.AssignmentOperatorProperty); }
			set { this.SetValue<AssignmentOperator>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.AssignmentOperatorProperty, value); }
		}
		
		void RuleElementBuilder.SetAssignmentOperatorLazy(global::System.Func<AssignmentOperator> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.AssignmentOperatorProperty, lazy);
		}
		
		void RuleElementBuilder.SetAssignmentOperatorLazy(global::System.Func<RuleElementBuilder, AssignmentOperator> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.AssignmentOperatorProperty, lazy);
		}
		
		void RuleElementBuilder.SetAssignmentOperatorLazy(global::System.Func<RuleElement, AssignmentOperator> immutableLazy, global::System.Func<RuleElementBuilder, AssignmentOperator> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.AssignmentOperatorProperty, immutableLazy, mutableLazy);
		}
	
		
		public Multiplicity Multiplicity
		{
			get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty); }
			set { this.SetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty, value); }
		}
		
		void RuleElementBuilder.SetMultiplicityLazy(global::System.Func<Multiplicity> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.MultiplicityProperty, lazy);
		}
		
		void RuleElementBuilder.SetMultiplicityLazy(global::System.Func<RuleElementBuilder, Multiplicity> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.MultiplicityProperty, lazy);
		}
		
		void RuleElementBuilder.SetMultiplicityLazy(global::System.Func<RuleElement, Multiplicity> immutableLazy, global::System.Func<RuleElementBuilder, Multiplicity> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.RuleElement.MultiplicityProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class ElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Element.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Element
	{
	
		internal ElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Element;
	
		public new ElementBuilder ToMutable()
		{
			return (ElementBuilder)base.ToMutable();
		}
	
		public new ElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ElementBuilder)base.ToMutable(model);
		}
	}
	
	internal class ElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ElementBuilder
	{
	
		internal ElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.Element(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Element;
	
		public new Element ToImmutable()
		{
			return (Element)base.ToImmutable();
		}
	
		public new Element ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Element)base.ToImmutable(model);
		}
	}
	
	internal class RuleReferenceId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleReference.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RuleReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RuleReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuleReferenceImpl : global::MetaDslx.Modeling.ImmutableObjectBase, RuleReference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Rule rule0;
	
		internal RuleReferenceImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleReference;
	
		public new RuleReferenceBuilder ToMutable()
		{
			return (RuleReferenceBuilder)base.ToMutable();
		}
	
		public new RuleReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RuleReferenceBuilder)base.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public Rule Rule
		{
		    get { return this.GetReference<Rule>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleReference.RuleProperty, ref rule0); }
		}
	}
	
	internal class RuleReferenceBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleReferenceBuilder
	{
	
		internal RuleReferenceBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.RuleReference(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleReference;
	
		public new RuleReference ToImmutable()
		{
			return (RuleReference)base.ToImmutable();
		}
	
		public new RuleReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RuleReference)base.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public RuleBuilder Rule
		{
			get { return this.GetReference<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleReference.RuleProperty); }
			set { this.SetReference<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleReference.RuleProperty, value); }
		}
		
		void RuleReferenceBuilder.SetRuleLazy(global::System.Func<RuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RuleReference.RuleProperty, lazy);
		}
		
		void RuleReferenceBuilder.SetRuleLazy(global::System.Func<RuleReferenceBuilder, RuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RuleReference.RuleProperty, lazy);
		}
		
		void RuleReferenceBuilder.SetRuleLazy(global::System.Func<RuleReference, Rule> immutableLazy, global::System.Func<RuleReferenceBuilder, RuleBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.RuleReference.RuleProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class RuleBlockId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleBlock.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RuleBlockImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RuleBlockBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuleBlockImpl : global::MetaDslx.Modeling.ImmutableObjectBase, RuleBlock
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> alternatives0;
	
		internal RuleBlockImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleBlock;
	
		public new RuleBlockBuilder ToMutable()
		{
			return (RuleBlockBuilder)base.ToMutable();
		}
	
		public new RuleBlockBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RuleBlockBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleBuilder Rule.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleBuilder Rule.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> Alternatives
		{
		    get { return this.GetList<RuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class RuleBlockBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleBlockBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> alternatives0;
	
		internal RuleBlockBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.RuleBlock(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RuleBlock;
	
		public new RuleBlock ToImmutable()
		{
			return (RuleBlock)base.ToImmutable();
		}
	
		public new RuleBlock ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RuleBlock)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Rule RuleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Rule RuleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public System.Type DefinedModelObject
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, value); }
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<RuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<Rule, System.Type> immutableLazy, global::System.Func<RuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<RuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class EofElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.EofElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EofElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EofElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class EofElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, EofElement
	{
	
		internal EofElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.EofElement;
	
		public new EofElementBuilder ToMutable()
		{
			return (EofElementBuilder)base.ToMutable();
		}
	
		public new EofElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EofElementBuilder)base.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	}
	
	internal class EofElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, EofElementBuilder
	{
	
		internal EofElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.EofElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.EofElement;
	
		public new EofElement ToImmutable()
		{
			return (EofElement)base.ToImmutable();
		}
	
		public new EofElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EofElement)base.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	}
	
	internal class FixedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.FixedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new FixedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new FixedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class FixedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, FixedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string value0;
	
		internal FixedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.FixedElement;
	
		public new FixedElementBuilder ToMutable()
		{
			return (FixedElementBuilder)base.ToMutable();
		}
	
		public new FixedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (FixedElementBuilder)base.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Value
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.FixedElement.ValueProperty, ref value0); }
		}
	}
	
	internal class FixedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, FixedElementBuilder
	{
	
		internal FixedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.FixedElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.FixedElement;
	
		public new FixedElement ToImmutable()
		{
			return (FixedElement)base.ToImmutable();
		}
	
		public new FixedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (FixedElement)base.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.FixedElement.ValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.FixedElement.ValueProperty, value); }
		}
		
		void FixedElementBuilder.SetValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.FixedElement.ValueProperty, lazy);
		}
		
		void FixedElementBuilder.SetValueLazy(global::System.Func<FixedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.FixedElement.ValueProperty, lazy);
		}
		
		void FixedElementBuilder.SetValueLazy(global::System.Func<FixedElement, string> immutableLazy, global::System.Func<FixedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.FixedElement.ValueProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class WildcardElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.WildcardElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new WildcardElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new WildcardElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WildcardElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, WildcardElement
	{
	
		internal WildcardElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.WildcardElement;
	
		public new WildcardElementBuilder ToMutable()
		{
			return (WildcardElementBuilder)base.ToMutable();
		}
	
		public new WildcardElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (WildcardElementBuilder)base.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	}
	
	internal class WildcardElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, WildcardElementBuilder
	{
	
		internal WildcardElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.WildcardElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.WildcardElement;
	
		public new WildcardElement ToImmutable()
		{
			return (WildcardElement)base.ToImmutable();
		}
	
		public new WildcardElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (WildcardElement)base.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	}
	
	internal class RangeElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RangeElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RangeElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class RangeElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, RangeElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FixedElement start0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FixedElement end0;
	
		internal RangeElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RangeElement;
	
		public new RangeElementBuilder ToMutable()
		{
			return (RangeElementBuilder)base.ToMutable();
		}
	
		public new RangeElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RangeElementBuilder)base.ToMutable(model);
		}
	
		ElementBuilder Element.ToMutable()
		{
			return this.ToMutable();
		}
	
		ElementBuilder Element.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public FixedElement Start
		{
		    get { return this.GetReference<FixedElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.StartProperty, ref start0); }
		}
	
		
		public FixedElement End
		{
		    get { return this.GetReference<FixedElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.EndProperty, ref end0); }
		}
	}
	
	internal class RangeElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RangeElementBuilder
	{
	
		internal RangeElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.RangeElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.RangeElement;
	
		public new RangeElement ToImmutable()
		{
			return (RangeElement)base.ToImmutable();
		}
	
		public new RangeElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RangeElement)base.ToImmutable(model);
		}
	
		Element ElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Element ElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public FixedElementBuilder Start
		{
			get { return this.GetReference<FixedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.StartProperty); }
			set { this.SetReference<FixedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.StartProperty, value); }
		}
		
		void RangeElementBuilder.SetStartLazy(global::System.Func<FixedElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RangeElement.StartProperty, lazy);
		}
		
		void RangeElementBuilder.SetStartLazy(global::System.Func<RangeElementBuilder, FixedElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RangeElement.StartProperty, lazy);
		}
		
		void RangeElementBuilder.SetStartLazy(global::System.Func<RangeElement, FixedElement> immutableLazy, global::System.Func<RangeElementBuilder, FixedElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.RangeElement.StartProperty, immutableLazy, mutableLazy);
		}
	
		
		public FixedElementBuilder End
		{
			get { return this.GetReference<FixedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.EndProperty); }
			set { this.SetReference<FixedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RangeElement.EndProperty, value); }
		}
		
		void RangeElementBuilder.SetEndLazy(global::System.Func<FixedElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RangeElement.EndProperty, lazy);
		}
		
		void RangeElementBuilder.SetEndLazy(global::System.Func<RangeElementBuilder, FixedElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.RangeElement.EndProperty, lazy);
		}
		
		void RangeElementBuilder.SetEndLazy(global::System.Func<RangeElement, FixedElement> immutableLazy, global::System.Func<RangeElementBuilder, FixedElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.RangeElement.EndProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class ParserRuleId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRule
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> alternatives0;
	
		internal ParserRuleImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRule;
	
		public new ParserRuleBuilder ToMutable()
		{
			return (ParserRuleBuilder)base.ToMutable();
		}
	
		public new ParserRuleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleBuilder Rule.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleBuilder Rule.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> Alternatives
		{
		    get { return this.GetList<RuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class ParserRuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> alternatives0;
	
		internal ParserRuleBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRule(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRule;
	
		public new ParserRule ToImmutable()
		{
			return (ParserRule)base.ToImmutable();
		}
	
		public new ParserRule ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRule)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Rule RuleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Rule RuleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public System.Type DefinedModelObject
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, value); }
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<RuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<Rule, System.Type> immutableLazy, global::System.Func<RuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<RuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class LexerRuleId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRule
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> alternatives0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isFragment0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isHidden0;
	
		internal LexerRuleImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRule;
	
		public new LexerRuleBuilder ToMutable()
		{
			return (LexerRuleBuilder)base.ToMutable();
		}
	
		public new LexerRuleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleBuilder Rule.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleBuilder Rule.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<RuleAlternative> Alternatives
		{
		    get { return this.GetList<RuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	
		
		public bool IsFragment
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsFragmentProperty, ref isFragment0); }
		}
	
		
		public bool IsHidden
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsHiddenProperty, ref isHidden0); }
		}
	}
	
	internal class LexerRuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> alternatives0;
	
		internal LexerRuleBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRule(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRule;
	
		public new LexerRule ToImmutable()
		{
			return (LexerRule)base.ToImmutable();
		}
	
		public new LexerRule ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRule)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Rule RuleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Rule RuleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, value); }
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, lazy);
		}
		
		void NamedElementBuilder.SetNameLazy(global::System.Func<NamedElement, string> immutableLazy, global::System.Func<NamedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.NamedElement.NameProperty, immutableLazy, mutableLazy);
		}
	
		
		public System.Type DefinedModelObject
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.DefinedModelObjectProperty, value); }
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<RuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, lazy);
		}
		
		void RuleBuilder.SetDefinedModelObjectLazy(global::System.Func<Rule, System.Type> immutableLazy, global::System.Func<RuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.Rule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<RuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Rule.AlternativesProperty, ref alternatives0); }
		}
	
		
		public bool IsFragment
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsFragmentProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsFragmentProperty, value); }
		}
		
		void LexerRuleBuilder.SetIsFragmentLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRule.IsFragmentProperty, lazy);
		}
		
		void LexerRuleBuilder.SetIsFragmentLazy(global::System.Func<LexerRuleBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRule.IsFragmentProperty, lazy);
		}
		
		void LexerRuleBuilder.SetIsFragmentLazy(global::System.Func<LexerRule, bool> immutableLazy, global::System.Func<LexerRuleBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRule.IsFragmentProperty, immutableLazy, mutableLazy);
		}
	
		
		public bool IsHidden
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsHiddenProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsHiddenProperty, value); }
		}
		
		void LexerRuleBuilder.SetIsHiddenLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRule.IsHiddenProperty, lazy);
		}
		
		void LexerRuleBuilder.SetIsHiddenLazy(global::System.Func<LexerRuleBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRule.IsHiddenProperty, lazy);
		}
		
		void LexerRuleBuilder.SetIsHiddenLazy(global::System.Func<LexerRule, bool> immutableLazy, global::System.Func<LexerRuleBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRule.IsHiddenProperty, immutableLazy, mutableLazy);
		}
	}

	internal class CompilerBuilderInstance
	{
		internal static CompilerBuilderInstance instance = new CompilerBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Modeling.ModelMetadata MMetadata;
		internal global::MetaDslx.Modeling.MutableModel MModel;
		internal global::MetaDslx.Modeling.MutableModelGroup MModelGroup;
	
	
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Model.MetaNamespaceBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Model.MetaModelBuilder __tmp5;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Namespace;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Namespace_Members;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder NamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder NamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Grammar;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Grammar_Options;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Grammar_Rules;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder GrammarOptions;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder GrammarOptions_IsCaseInsensitive;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder GrammarOptions_IsWhitespaceIndented;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Rule;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Rule_DefinedModelObject;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Rule_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RuleAlternative;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleAlternative_Elements;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RuleElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleElement_IsNegated;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleElement_Element;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleElement_AssignmentOperator;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleElement_Multiplicity;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Element;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RuleReference;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleReference_Rule;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RuleBlock;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder EofElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder FixedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder FixedElement_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder WildcardElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RangeElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RangeElement_Start;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RangeElement_End;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRule;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRule;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_IsFragment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_IsHidden;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder Multiplicity;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp10;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp11;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp12;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp16;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder AssignmentOperator;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp17;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp18;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp19;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp9;
	
		internal CompilerBuilderInstance()
		{
			this.MModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.MModelGroup.AddReference(MetaDslx.Languages.Meta.Model.MetaInstance.MModel);
			this.MModel = this.MModelGroup.CreateModel(namespaceName: "MetaDslx.Languages.Compiler.Model", name: "Compiler", version: new global::MetaDslx.Modeling.ModelVersion(1, 0), uri: "http://MetaDslx.Languages.Compiler/1.0", prefix: "Compiler", factoryConstructor: (global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags) => new CompilerFactory(model, flags));
			this.MMetadata = this.MModel.Metadata;
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			this.CreateInstances();
			CompilerImplementationProvider.Implementation.CompilerBuilderInstance(this);
	        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)
	        {
	            obj.MMakeCreated();
	        }
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.MModel.EvaluateLazyValues();
		}
	
		private void CreateInstances()
		{
			global::MetaDslx.Languages.Meta.Model.MetaFactory factory = new global::MetaDslx.Languages.Meta.Model.MetaFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
			CompilerFactory constantFactory = new CompilerFactory(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);
	
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaModel();
			Namespace = factory.MetaClass();
			Namespace_Members = factory.MetaProperty();
			NamedElement = factory.MetaClass();
			NamedElement_Name = factory.MetaProperty();
			Grammar = factory.MetaClass();
			Grammar_Options = factory.MetaProperty();
			Grammar_Rules = factory.MetaProperty();
			GrammarOptions = factory.MetaClass();
			GrammarOptions_IsCaseInsensitive = factory.MetaProperty();
			GrammarOptions_IsWhitespaceIndented = factory.MetaProperty();
			Rule = factory.MetaClass();
			Rule_DefinedModelObject = factory.MetaProperty();
			Rule_Alternatives = factory.MetaProperty();
			RuleAlternative = factory.MetaClass();
			RuleAlternative_Elements = factory.MetaProperty();
			RuleElement = factory.MetaClass();
			RuleElement_IsNegated = factory.MetaProperty();
			RuleElement_Element = factory.MetaProperty();
			RuleElement_AssignmentOperator = factory.MetaProperty();
			RuleElement_Multiplicity = factory.MetaProperty();
			Element = factory.MetaClass();
			RuleReference = factory.MetaClass();
			RuleReference_Rule = factory.MetaProperty();
			RuleBlock = factory.MetaClass();
			EofElement = factory.MetaClass();
			FixedElement = factory.MetaClass();
			FixedElement_Value = factory.MetaProperty();
			WildcardElement = factory.MetaClass();
			RangeElement = factory.MetaClass();
			RangeElement_Start = factory.MetaProperty();
			RangeElement_End = factory.MetaProperty();
			ParserRule = factory.MetaClass();
			LexerRule = factory.MetaClass();
			LexerRule_IsFragment = factory.MetaProperty();
			LexerRule_IsHidden = factory.MetaProperty();
			Multiplicity = factory.MetaEnum();
			__tmp10 = factory.MetaEnumLiteral();
			__tmp11 = factory.MetaEnumLiteral();
			__tmp12 = factory.MetaEnumLiteral();
			__tmp13 = factory.MetaEnumLiteral();
			__tmp14 = factory.MetaEnumLiteral();
			__tmp15 = factory.MetaEnumLiteral();
			__tmp16 = factory.MetaEnumLiteral();
			AssignmentOperator = factory.MetaEnum();
			__tmp17 = factory.MetaEnumLiteral();
			__tmp18 = factory.MetaEnumLiteral();
			__tmp19 = factory.MetaEnumLiteral();
			__tmp20 = factory.MetaEnumLiteral();
			__tmp6 = factory.MetaCollectionType();
			__tmp7 = factory.MetaCollectionType();
			__tmp8 = factory.MetaCollectionType();
			__tmp9 = factory.MetaCollectionType();
	
			__tmp1.Documentation = null;
			__tmp1.Name = "MetaDslx";
			// __tmp1.Namespace = null;
			// __tmp1.DefinedMetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			__tmp2.Documentation = null;
			__tmp2.Name = "Languages";
			__tmp2.SetNamespaceLazy(() => __tmp1);
			// __tmp2.DefinedMetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			__tmp3.Documentation = null;
			__tmp3.Name = "Compiler";
			__tmp3.SetNamespaceLazy(() => __tmp2);
			// __tmp3.DefinedMetaModel = null;
			__tmp3.Declarations.AddLazy(() => __tmp4);
			__tmp4.Documentation = null;
			__tmp4.Name = "Model";
			__tmp4.SetNamespaceLazy(() => __tmp3);
			__tmp4.SetDefinedMetaModelLazy(() => __tmp5);
			__tmp4.Declarations.AddLazy(() => Namespace);
			__tmp4.Declarations.AddLazy(() => NamedElement);
			__tmp4.Declarations.AddLazy(() => Grammar);
			__tmp4.Declarations.AddLazy(() => GrammarOptions);
			__tmp4.Declarations.AddLazy(() => Rule);
			__tmp4.Declarations.AddLazy(() => RuleAlternative);
			__tmp4.Declarations.AddLazy(() => RuleElement);
			__tmp4.Declarations.AddLazy(() => Element);
			__tmp4.Declarations.AddLazy(() => RuleReference);
			__tmp4.Declarations.AddLazy(() => RuleBlock);
			__tmp4.Declarations.AddLazy(() => EofElement);
			__tmp4.Declarations.AddLazy(() => FixedElement);
			__tmp4.Declarations.AddLazy(() => WildcardElement);
			__tmp4.Declarations.AddLazy(() => RangeElement);
			__tmp4.Declarations.AddLazy(() => ParserRule);
			__tmp4.Declarations.AddLazy(() => LexerRule);
			__tmp4.Declarations.AddLazy(() => Multiplicity);
			__tmp4.Declarations.AddLazy(() => AssignmentOperator);
			__tmp5.Documentation = null;
			__tmp5.Name = "Compiler";
			__tmp5.MajorVersion = 1;
			__tmp5.MinorVersion = 0;
			__tmp5.Uri = "http://MetaDslx.Languages.Compiler/1.0";
			__tmp5.Prefix = null;
			__tmp5.SetNamespaceLazy(() => __tmp4);
			Namespace.Documentation = null;
			Namespace.Name = "Namespace";
			Namespace.SetNamespaceLazy(() => __tmp4);
			Namespace.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol);
			Namespace.IsAbstract = false;
			Namespace.SuperClasses.AddLazy(() => NamedElement);
			Namespace.Properties.AddLazy(() => Namespace_Members);
			Namespace_Members.SetTypeLazy(() => __tmp6);
			Namespace_Members.Documentation = null;
			Namespace_Members.Name = "Members";
			Namespace_Members.SymbolProperty = "Members";
			Namespace_Members.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Namespace_Members.SetClassLazy(() => Namespace);
			Namespace_Members.DefaultValue = null;
			Namespace_Members.IsContainment = true;
			NamedElement.Documentation = null;
			NamedElement.Name = "NamedElement";
			NamedElement.SetNamespaceLazy(() => __tmp4);
			NamedElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol);
			NamedElement.IsAbstract = false;
			NamedElement.Properties.AddLazy(() => NamedElement_Name);
			NamedElement_Name.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			NamedElement_Name.Documentation = null;
			NamedElement_Name.Name = "Name";
			NamedElement_Name.SymbolProperty = "Name";
			NamedElement_Name.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			NamedElement_Name.SetClassLazy(() => NamedElement);
			NamedElement_Name.DefaultValue = null;
			NamedElement_Name.IsContainment = false;
			Grammar.Documentation = null;
			Grammar.Name = "Grammar";
			Grammar.SetNamespaceLazy(() => __tmp4);
			Grammar.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			Grammar.IsAbstract = false;
			Grammar.SuperClasses.AddLazy(() => NamedElement);
			Grammar.Properties.AddLazy(() => Grammar_Options);
			Grammar.Properties.AddLazy(() => Grammar_Rules);
			Grammar_Options.SetTypeLazy(() => GrammarOptions);
			Grammar_Options.Documentation = null;
			Grammar_Options.Name = "Options";
			Grammar_Options.SymbolProperty = null;
			Grammar_Options.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Grammar_Options.SetClassLazy(() => Grammar);
			Grammar_Options.DefaultValue = null;
			Grammar_Options.IsContainment = true;
			Grammar_Rules.SetTypeLazy(() => __tmp7);
			Grammar_Rules.Documentation = null;
			Grammar_Rules.Name = "Rules";
			Grammar_Rules.SymbolProperty = "Members";
			Grammar_Rules.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Grammar_Rules.SetClassLazy(() => Grammar);
			Grammar_Rules.DefaultValue = null;
			Grammar_Rules.IsContainment = true;
			GrammarOptions.Documentation = null;
			GrammarOptions.Name = "GrammarOptions";
			GrammarOptions.SetNamespaceLazy(() => __tmp4);
			GrammarOptions.SymbolType = null;
			GrammarOptions.IsAbstract = false;
			GrammarOptions.Properties.AddLazy(() => GrammarOptions_IsCaseInsensitive);
			GrammarOptions.Properties.AddLazy(() => GrammarOptions_IsWhitespaceIndented);
			GrammarOptions_IsCaseInsensitive.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			GrammarOptions_IsCaseInsensitive.Documentation = null;
			GrammarOptions_IsCaseInsensitive.Name = "IsCaseInsensitive";
			GrammarOptions_IsCaseInsensitive.SymbolProperty = null;
			GrammarOptions_IsCaseInsensitive.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			GrammarOptions_IsCaseInsensitive.SetClassLazy(() => GrammarOptions);
			GrammarOptions_IsCaseInsensitive.DefaultValue = null;
			GrammarOptions_IsCaseInsensitive.IsContainment = false;
			GrammarOptions_IsWhitespaceIndented.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			GrammarOptions_IsWhitespaceIndented.Documentation = null;
			GrammarOptions_IsWhitespaceIndented.Name = "IsWhitespaceIndented";
			GrammarOptions_IsWhitespaceIndented.SymbolProperty = null;
			GrammarOptions_IsWhitespaceIndented.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			GrammarOptions_IsWhitespaceIndented.SetClassLazy(() => GrammarOptions);
			GrammarOptions_IsWhitespaceIndented.DefaultValue = null;
			GrammarOptions_IsWhitespaceIndented.IsContainment = false;
			Rule.Documentation = null;
			Rule.Name = "Rule";
			Rule.SetNamespaceLazy(() => __tmp4);
			Rule.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			Rule.IsAbstract = true;
			Rule.SuperClasses.AddLazy(() => NamedElement);
			Rule.Properties.AddLazy(() => Rule_DefinedModelObject);
			Rule.Properties.AddLazy(() => Rule_Alternatives);
			Rule_DefinedModelObject.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.SystemType.ToMutable());
			Rule_DefinedModelObject.Documentation = null;
			Rule_DefinedModelObject.Name = "DefinedModelObject";
			Rule_DefinedModelObject.SymbolProperty = null;
			Rule_DefinedModelObject.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Rule_DefinedModelObject.SetClassLazy(() => Rule);
			Rule_DefinedModelObject.DefaultValue = null;
			Rule_DefinedModelObject.IsContainment = false;
			Rule_Alternatives.SetTypeLazy(() => __tmp8);
			Rule_Alternatives.Documentation = null;
			Rule_Alternatives.Name = "Alternatives";
			Rule_Alternatives.SymbolProperty = "Members";
			Rule_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Rule_Alternatives.SetClassLazy(() => Rule);
			Rule_Alternatives.DefaultValue = null;
			Rule_Alternatives.IsContainment = true;
			RuleAlternative.Documentation = null;
			RuleAlternative.Name = "RuleAlternative";
			RuleAlternative.SetNamespaceLazy(() => __tmp4);
			RuleAlternative.SymbolType = null;
			RuleAlternative.IsAbstract = false;
			RuleAlternative.SuperClasses.AddLazy(() => NamedElement);
			RuleAlternative.Properties.AddLazy(() => RuleAlternative_Elements);
			RuleAlternative_Elements.SetTypeLazy(() => __tmp9);
			RuleAlternative_Elements.Documentation = null;
			RuleAlternative_Elements.Name = "Elements";
			RuleAlternative_Elements.SymbolProperty = null;
			RuleAlternative_Elements.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleAlternative_Elements.SetClassLazy(() => RuleAlternative);
			RuleAlternative_Elements.DefaultValue = null;
			RuleAlternative_Elements.IsContainment = true;
			RuleElement.Documentation = null;
			RuleElement.Name = "RuleElement";
			RuleElement.SetNamespaceLazy(() => __tmp4);
			RuleElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			RuleElement.IsAbstract = false;
			RuleElement.SuperClasses.AddLazy(() => NamedElement);
			RuleElement.Properties.AddLazy(() => RuleElement_IsNegated);
			RuleElement.Properties.AddLazy(() => RuleElement_Element);
			RuleElement.Properties.AddLazy(() => RuleElement_AssignmentOperator);
			RuleElement.Properties.AddLazy(() => RuleElement_Multiplicity);
			RuleElement_IsNegated.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			RuleElement_IsNegated.Documentation = null;
			RuleElement_IsNegated.Name = "IsNegated";
			RuleElement_IsNegated.SymbolProperty = null;
			RuleElement_IsNegated.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleElement_IsNegated.SetClassLazy(() => RuleElement);
			RuleElement_IsNegated.DefaultValue = null;
			RuleElement_IsNegated.IsContainment = false;
			RuleElement_Element.SetTypeLazy(() => Element);
			RuleElement_Element.Documentation = null;
			RuleElement_Element.Name = "Element";
			RuleElement_Element.SymbolProperty = "Members";
			RuleElement_Element.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleElement_Element.SetClassLazy(() => RuleElement);
			RuleElement_Element.DefaultValue = null;
			RuleElement_Element.IsContainment = false;
			RuleElement_AssignmentOperator.SetTypeLazy(() => AssignmentOperator);
			RuleElement_AssignmentOperator.Documentation = null;
			RuleElement_AssignmentOperator.Name = "AssignmentOperator";
			RuleElement_AssignmentOperator.SymbolProperty = null;
			RuleElement_AssignmentOperator.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleElement_AssignmentOperator.SetClassLazy(() => RuleElement);
			RuleElement_AssignmentOperator.DefaultValue = null;
			RuleElement_AssignmentOperator.IsContainment = false;
			RuleElement_Multiplicity.SetTypeLazy(() => Multiplicity);
			RuleElement_Multiplicity.Documentation = null;
			RuleElement_Multiplicity.Name = "Multiplicity";
			RuleElement_Multiplicity.SymbolProperty = null;
			RuleElement_Multiplicity.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleElement_Multiplicity.SetClassLazy(() => RuleElement);
			RuleElement_Multiplicity.DefaultValue = null;
			RuleElement_Multiplicity.IsContainment = false;
			Element.Documentation = null;
			Element.Name = "Element";
			Element.SetNamespaceLazy(() => __tmp4);
			Element.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol);
			Element.IsAbstract = true;
			RuleReference.Documentation = null;
			RuleReference.Name = "RuleReference";
			RuleReference.SetNamespaceLazy(() => __tmp4);
			RuleReference.SymbolType = null;
			RuleReference.IsAbstract = false;
			RuleReference.SuperClasses.AddLazy(() => Element);
			RuleReference.Properties.AddLazy(() => RuleReference_Rule);
			RuleReference_Rule.SetTypeLazy(() => Rule);
			RuleReference_Rule.Documentation = null;
			RuleReference_Rule.Name = "Rule";
			RuleReference_Rule.SymbolProperty = null;
			RuleReference_Rule.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleReference_Rule.SetClassLazy(() => RuleReference);
			RuleReference_Rule.DefaultValue = null;
			RuleReference_Rule.IsContainment = false;
			RuleBlock.Documentation = null;
			RuleBlock.Name = "RuleBlock";
			RuleBlock.SetNamespaceLazy(() => __tmp4);
			RuleBlock.SymbolType = null;
			RuleBlock.IsAbstract = false;
			RuleBlock.SuperClasses.AddLazy(() => Rule);
			RuleBlock.SuperClasses.AddLazy(() => Element);
			EofElement.Documentation = null;
			EofElement.Name = "EofElement";
			EofElement.SetNamespaceLazy(() => __tmp4);
			EofElement.SymbolType = null;
			EofElement.IsAbstract = false;
			EofElement.SuperClasses.AddLazy(() => Element);
			FixedElement.Documentation = null;
			FixedElement.Name = "FixedElement";
			FixedElement.SetNamespaceLazy(() => __tmp4);
			FixedElement.SymbolType = null;
			FixedElement.IsAbstract = false;
			FixedElement.SuperClasses.AddLazy(() => Element);
			FixedElement.Properties.AddLazy(() => FixedElement_Value);
			FixedElement_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			FixedElement_Value.Documentation = null;
			FixedElement_Value.Name = "Value";
			FixedElement_Value.SymbolProperty = null;
			FixedElement_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			FixedElement_Value.SetClassLazy(() => FixedElement);
			FixedElement_Value.DefaultValue = null;
			FixedElement_Value.IsContainment = false;
			WildcardElement.Documentation = null;
			WildcardElement.Name = "WildcardElement";
			WildcardElement.SetNamespaceLazy(() => __tmp4);
			WildcardElement.SymbolType = null;
			WildcardElement.IsAbstract = false;
			WildcardElement.SuperClasses.AddLazy(() => Element);
			RangeElement.Documentation = null;
			RangeElement.Name = "RangeElement";
			RangeElement.SetNamespaceLazy(() => __tmp4);
			RangeElement.SymbolType = null;
			RangeElement.IsAbstract = false;
			RangeElement.SuperClasses.AddLazy(() => Element);
			RangeElement.Properties.AddLazy(() => RangeElement_Start);
			RangeElement.Properties.AddLazy(() => RangeElement_End);
			RangeElement_Start.SetTypeLazy(() => FixedElement);
			RangeElement_Start.Documentation = null;
			RangeElement_Start.Name = "Start";
			RangeElement_Start.SymbolProperty = null;
			RangeElement_Start.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RangeElement_Start.SetClassLazy(() => RangeElement);
			RangeElement_Start.DefaultValue = null;
			RangeElement_Start.IsContainment = true;
			RangeElement_End.SetTypeLazy(() => FixedElement);
			RangeElement_End.Documentation = null;
			RangeElement_End.Name = "End";
			RangeElement_End.SymbolProperty = null;
			RangeElement_End.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RangeElement_End.SetClassLazy(() => RangeElement);
			RangeElement_End.DefaultValue = null;
			RangeElement_End.IsContainment = true;
			ParserRule.Documentation = null;
			ParserRule.Name = "ParserRule";
			ParserRule.SetNamespaceLazy(() => __tmp4);
			ParserRule.SymbolType = null;
			ParserRule.IsAbstract = false;
			ParserRule.SuperClasses.AddLazy(() => Rule);
			LexerRule.Documentation = null;
			LexerRule.Name = "LexerRule";
			LexerRule.SetNamespaceLazy(() => __tmp4);
			LexerRule.SymbolType = null;
			LexerRule.IsAbstract = false;
			LexerRule.SuperClasses.AddLazy(() => Rule);
			LexerRule.Properties.AddLazy(() => LexerRule_IsFragment);
			LexerRule.Properties.AddLazy(() => LexerRule_IsHidden);
			LexerRule_IsFragment.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			LexerRule_IsFragment.Documentation = null;
			LexerRule_IsFragment.Name = "IsFragment";
			LexerRule_IsFragment.SymbolProperty = null;
			LexerRule_IsFragment.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRule_IsFragment.SetClassLazy(() => LexerRule);
			LexerRule_IsFragment.DefaultValue = null;
			LexerRule_IsFragment.IsContainment = false;
			LexerRule_IsHidden.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			LexerRule_IsHidden.Documentation = null;
			LexerRule_IsHidden.Name = "IsHidden";
			LexerRule_IsHidden.SymbolProperty = null;
			LexerRule_IsHidden.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRule_IsHidden.SetClassLazy(() => LexerRule);
			LexerRule_IsHidden.DefaultValue = null;
			LexerRule_IsHidden.IsContainment = false;
			Multiplicity.Documentation = null;
			Multiplicity.Name = "Multiplicity";
			Multiplicity.SetNamespaceLazy(() => __tmp4);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp10);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp11);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp12);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp13);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp14);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp15);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp16);
			__tmp10.Documentation = null;
			__tmp10.Name = "ExactlyOne";
			__tmp10.SetEnumLazy(() => Multiplicity);
			__tmp11.Documentation = null;
			__tmp11.Name = "ZeroOrOne";
			__tmp11.SetEnumLazy(() => Multiplicity);
			__tmp12.Documentation = null;
			__tmp12.Name = "ZeroOrMore";
			__tmp12.SetEnumLazy(() => Multiplicity);
			__tmp13.Documentation = null;
			__tmp13.Name = "OneOrMore";
			__tmp13.SetEnumLazy(() => Multiplicity);
			__tmp14.Documentation = null;
			__tmp14.Name = "NonGreedyZeroOrOne";
			__tmp14.SetEnumLazy(() => Multiplicity);
			__tmp15.Documentation = null;
			__tmp15.Name = "NonGreedyZeroOrMore";
			__tmp15.SetEnumLazy(() => Multiplicity);
			__tmp16.Documentation = null;
			__tmp16.Name = "NonGreedyOneOrMore";
			__tmp16.SetEnumLazy(() => Multiplicity);
			AssignmentOperator.Documentation = null;
			AssignmentOperator.Name = "AssignmentOperator";
			AssignmentOperator.SetNamespaceLazy(() => __tmp4);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp17);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp18);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp19);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp20);
			__tmp17.Documentation = null;
			__tmp17.Name = "Assign";
			__tmp17.SetEnumLazy(() => AssignmentOperator);
			__tmp18.Documentation = null;
			__tmp18.Name = "QuestionAssign";
			__tmp18.SetEnumLazy(() => AssignmentOperator);
			__tmp19.Documentation = null;
			__tmp19.Name = "NegatedAssign";
			__tmp19.SetEnumLazy(() => AssignmentOperator);
			__tmp20.Documentation = null;
			__tmp20.Name = "PlusAssign";
			__tmp20.SetEnumLazy(() => AssignmentOperator);
			__tmp6.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp6.SetInnerTypeLazy(() => NamedElement);
			__tmp7.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp7.SetInnerTypeLazy(() => Rule);
			__tmp8.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp8.SetInnerTypeLazy(() => RuleAlternative);
			__tmp9.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp9.SetInnerTypeLazy(() => RuleElement);
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Languages.Compiler.Model.CompilerImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	public abstract class CompilerImplementationBase
	{
		/// <summary>
		/// Implements the constructor: CompilerBuilderInstance()
		/// </summary>
		internal virtual void CompilerBuilderInstance(CompilerBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: Namespace()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Namespace(NamespaceBuilder _this)
		{
			this.CallNamespaceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Namespace
		/// </summary>
		protected virtual void CallNamespaceSuperConstructors(NamespaceBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: NamedElement()
		/// </summary>
		public virtual void NamedElement(NamedElementBuilder _this)
		{
			this.CallNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NamedElement
		/// </summary>
		protected virtual void CallNamedElementSuperConstructors(NamedElementBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: Grammar()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Grammar(GrammarBuilder _this)
		{
			this.CallGrammarSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Grammar
		/// </summary>
		protected virtual void CallGrammarSuperConstructors(GrammarBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: GrammarOptions()
		/// </summary>
		public virtual void GrammarOptions(GrammarOptionsBuilder _this)
		{
			this.CallGrammarOptionsSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of GrammarOptions
		/// </summary>
		protected virtual void CallGrammarOptionsSuperConstructors(GrammarOptionsBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: Rule()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Rule(RuleBuilder _this)
		{
			this.CallRuleSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Rule
		/// </summary>
		protected virtual void CallRuleSuperConstructors(RuleBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: RuleAlternative()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void RuleAlternative(RuleAlternativeBuilder _this)
		{
			this.CallRuleAlternativeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RuleAlternative
		/// </summary>
		protected virtual void CallRuleAlternativeSuperConstructors(RuleAlternativeBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: RuleElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void RuleElement(RuleElementBuilder _this)
		{
			this.CallRuleElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RuleElement
		/// </summary>
		protected virtual void CallRuleElementSuperConstructors(RuleElementBuilder _this)
		{
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: Element()
		/// </summary>
		public virtual void Element(ElementBuilder _this)
		{
			this.CallElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Element
		/// </summary>
		protected virtual void CallElementSuperConstructors(ElementBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: RuleReference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		public virtual void RuleReference(RuleReferenceBuilder _this)
		{
			this.CallRuleReferenceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RuleReference
		/// </summary>
		protected virtual void CallRuleReferenceSuperConstructors(RuleReferenceBuilder _this)
		{
			this.Element(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: RuleBlock()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Rule</li>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Element</li>
		///     <li>Rule</li>
		/// </ul>
		public virtual void RuleBlock(RuleBlockBuilder _this)
		{
			this.CallRuleBlockSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RuleBlock
		/// </summary>
		protected virtual void CallRuleBlockSuperConstructors(RuleBlockBuilder _this)
		{
			this.NamedElement(_this);
			this.Element(_this);
			this.Rule(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: EofElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		public virtual void EofElement(EofElementBuilder _this)
		{
			this.CallEofElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EofElement
		/// </summary>
		protected virtual void CallEofElementSuperConstructors(EofElementBuilder _this)
		{
			this.Element(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: FixedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		public virtual void FixedElement(FixedElementBuilder _this)
		{
			this.CallFixedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of FixedElement
		/// </summary>
		protected virtual void CallFixedElementSuperConstructors(FixedElementBuilder _this)
		{
			this.Element(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: WildcardElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		public virtual void WildcardElement(WildcardElementBuilder _this)
		{
			this.CallWildcardElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of WildcardElement
		/// </summary>
		protected virtual void CallWildcardElementSuperConstructors(WildcardElementBuilder _this)
		{
			this.Element(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: RangeElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Element</li>
		/// </ul>
		public virtual void RangeElement(RangeElementBuilder _this)
		{
			this.CallRangeElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RangeElement
		/// </summary>
		protected virtual void CallRangeElementSuperConstructors(RangeElementBuilder _this)
		{
			this.Element(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRule()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Rule</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Rule</li>
		/// </ul>
		public virtual void ParserRule(ParserRuleBuilder _this)
		{
			this.CallParserRuleSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRule
		/// </summary>
		protected virtual void CallParserRuleSuperConstructors(ParserRuleBuilder _this)
		{
			this.NamedElement(_this);
			this.Rule(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRule()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Rule</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Rule</li>
		/// </ul>
		public virtual void LexerRule(LexerRuleBuilder _this)
		{
			this.CallLexerRuleSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRule
		/// </summary>
		protected virtual void CallLexerRuleSuperConstructors(LexerRuleBuilder _this)
		{
			this.NamedElement(_this);
			this.Rule(_this);
		}
	
	
	
	
	
	}

	public class CompilerImplementationProvider
	{
		// If there is a compile error at this line, create a new class called CompilerImplementation
		// which is a subclass of global::MetaDslx.Languages.Compiler.Model.CompilerImplementationBase:
		private static CompilerImplementation implementation = new CompilerImplementation();
	
		public static CompilerImplementation Implementation
		{
			get { return implementation; }
		}
	}
}

