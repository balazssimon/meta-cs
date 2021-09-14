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
	
	
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass NamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty NamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Grammar;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Grammar_Rules;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Rule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass RuleElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty RuleElement_Multiplicity;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRule_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleAlternative;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleAlternative_Elements;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleReference;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleReference_Rule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleBlock;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleBlock_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_IsFragment;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_IsHidden;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleAlternative;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleAlternative_Elements;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleElement;
	
		static CompilerInstance()
		{
			CompilerBuilderInstance.instance.Create();
			CompilerBuilderInstance.instance.EvaluateLazyValues();
			MModel = CompilerBuilderInstance.instance.MModel.ToImmutable();
			MMetadata = MModel.Metadata;
	
	
			NamedElement = CompilerBuilderInstance.instance.NamedElement.ToImmutable(MModel);
			NamedElement_Name = CompilerBuilderInstance.instance.NamedElement_Name.ToImmutable(MModel);
			Grammar = CompilerBuilderInstance.instance.Grammar.ToImmutable(MModel);
			Grammar_Rules = CompilerBuilderInstance.instance.Grammar_Rules.ToImmutable(MModel);
			Rule = CompilerBuilderInstance.instance.Rule.ToImmutable(MModel);
			RuleElement = CompilerBuilderInstance.instance.RuleElement.ToImmutable(MModel);
			RuleElement_Multiplicity = CompilerBuilderInstance.instance.RuleElement_Multiplicity.ToImmutable(MModel);
			ParserRule = CompilerBuilderInstance.instance.ParserRule.ToImmutable(MModel);
			ParserRule_Alternatives = CompilerBuilderInstance.instance.ParserRule_Alternatives.ToImmutable(MModel);
			ParserRuleAlternative = CompilerBuilderInstance.instance.ParserRuleAlternative.ToImmutable(MModel);
			ParserRuleAlternative_Elements = CompilerBuilderInstance.instance.ParserRuleAlternative_Elements.ToImmutable(MModel);
			ParserRuleElement = CompilerBuilderInstance.instance.ParserRuleElement.ToImmutable(MModel);
			ParserRuleReference = CompilerBuilderInstance.instance.ParserRuleReference.ToImmutable(MModel);
			ParserRuleReference_Rule = CompilerBuilderInstance.instance.ParserRuleReference_Rule.ToImmutable(MModel);
			ParserRuleBlock = CompilerBuilderInstance.instance.ParserRuleBlock.ToImmutable(MModel);
			ParserRuleBlock_Alternatives = CompilerBuilderInstance.instance.ParserRuleBlock_Alternatives.ToImmutable(MModel);
			LexerRule = CompilerBuilderInstance.instance.LexerRule.ToImmutable(MModel);
			LexerRule_IsFragment = CompilerBuilderInstance.instance.LexerRule_IsFragment.ToImmutable(MModel);
			LexerRule_IsHidden = CompilerBuilderInstance.instance.LexerRule_IsHidden.ToImmutable(MModel);
			LexerRule_Alternatives = CompilerBuilderInstance.instance.LexerRule_Alternatives.ToImmutable(MModel);
			LexerRuleAlternative = CompilerBuilderInstance.instance.LexerRuleAlternative.ToImmutable(MModel);
			LexerRuleAlternative_Elements = CompilerBuilderInstance.instance.LexerRuleAlternative_Elements.ToImmutable(MModel);
			LexerRuleElement = CompilerBuilderInstance.instance.LexerRuleElement.ToImmutable(MModel);
	
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
				case "Grammar": return this.Grammar();
				case "ParserRule": return this.ParserRule();
				case "ParserRuleAlternative": return this.ParserRuleAlternative();
				case "ParserRuleReference": return this.ParserRuleReference();
				case "ParserRuleBlock": return this.ParserRuleBlock();
				case "LexerRule": return this.LexerRule();
				case "LexerRuleAlternative": return this.LexerRuleAlternative();
				case "LexerRuleElement": return this.LexerRuleElement();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
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
		/// Creates a new instance of ParserRule.
		/// </summary>
		public ParserRuleBuilder ParserRule()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleId());
			return (ParserRuleBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleAlternative.
		/// </summary>
		public ParserRuleAlternativeBuilder ParserRuleAlternative()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleAlternativeId());
			return (ParserRuleAlternativeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleReference.
		/// </summary>
		public ParserRuleReferenceBuilder ParserRuleReference()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleReferenceId());
			return (ParserRuleReferenceBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleBlock.
		/// </summary>
		public ParserRuleBlockBuilder ParserRuleBlock()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleBlockId());
			return (ParserRuleBlockBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRule.
		/// </summary>
		public LexerRuleBuilder LexerRule()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleId());
			return (LexerRuleBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleAlternative.
		/// </summary>
		public LexerRuleAlternativeBuilder LexerRuleAlternative()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleAlternativeId());
			return (LexerRuleAlternativeBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleElement.
		/// </summary>
		public LexerRuleElementBuilder LexerRuleElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleElementId());
			return (LexerRuleElementBuilder)obj;
		}
	}

	
	public enum Multiplicity
	{
		ExactlyOne,
		ZeroOrOne,
		ZeroOrMore,
		OneOrMore
	}
	
	public static class MultiplicityExtensions
	{
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
	
	public interface Rule : NamedElement
	{
	
	
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
	
	public interface RuleElement : NamedElement
	{
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
	
	public interface ParserRule : Rule
	{
		global::MetaDslx.Modeling.ImmutableModelList<ParserRuleAlternative> Alternatives { get; }
	
	
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
		global::MetaDslx.Modeling.MutableModelList<ParserRuleAlternativeBuilder> Alternatives { get; }
	
	
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
	
	public interface ParserRuleAlternative : global::MetaDslx.Modeling.ImmutableObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<ParserRuleElement> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleAlternative"/> object to a builder <see cref="ParserRuleAlternativeBuilder"/> object.
		/// </summary>
		new ParserRuleAlternativeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleAlternative"/> object to a builder <see cref="ParserRuleAlternativeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleAlternativeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleAlternativeBuilder : global::MetaDslx.Modeling.MutableObject
	{
		global::MetaDslx.Modeling.MutableModelList<ParserRuleElementBuilder> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleAlternativeBuilder"/> object to an immutable <see cref="ParserRuleAlternative"/> object.
		/// </summary>
		new ParserRuleAlternative ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleAlternativeBuilder"/> object to an immutable <see cref="ParserRuleAlternative"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleAlternative ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleElement : RuleElement
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleElement"/> object to a builder <see cref="ParserRuleElementBuilder"/> object.
		/// </summary>
		new ParserRuleElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleElement"/> object to a builder <see cref="ParserRuleElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleElementBuilder : RuleElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleElementBuilder"/> object to an immutable <see cref="ParserRuleElement"/> object.
		/// </summary>
		new ParserRuleElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleElementBuilder"/> object to an immutable <see cref="ParserRuleElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleReference : RuleElement
	{
		Rule Rule { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleReference"/> object to a builder <see cref="ParserRuleReferenceBuilder"/> object.
		/// </summary>
		new ParserRuleReferenceBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleReference"/> object to a builder <see cref="ParserRuleReferenceBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleReferenceBuilder : RuleElementBuilder
	{
		RuleBuilder Rule { get; set; }
		void SetRuleLazy(global::System.Func<RuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<ParserRuleReferenceBuilder, RuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<ParserRuleReference, Rule> immutableLazy, global::System.Func<ParserRuleReferenceBuilder, RuleBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleReferenceBuilder"/> object to an immutable <see cref="ParserRuleReference"/> object.
		/// </summary>
		new ParserRuleReference ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleReferenceBuilder"/> object to an immutable <see cref="ParserRuleReference"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleBlock : RuleElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<ParserRuleAlternative> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleBlock"/> object to a builder <see cref="ParserRuleBlockBuilder"/> object.
		/// </summary>
		new ParserRuleBlockBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleBlock"/> object to a builder <see cref="ParserRuleBlockBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleBlockBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleBlockBuilder : RuleElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<ParserRuleAlternativeBuilder> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleBlockBuilder"/> object to an immutable <see cref="ParserRuleBlock"/> object.
		/// </summary>
		new ParserRuleBlock ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleBlockBuilder"/> object to an immutable <see cref="ParserRuleBlock"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleBlock ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRule : Rule
	{
		bool IsFragment { get; }
		bool IsHidden { get; }
		global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> Alternatives { get; }
	
	
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
		global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeBuilder> Alternatives { get; }
	
	
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
	
	public interface LexerRuleAlternative : global::MetaDslx.Modeling.ImmutableObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<LexerRuleElement> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternative"/> object to a builder <see cref="LexerRuleAlternativeBuilder"/> object.
		/// </summary>
		new LexerRuleAlternativeBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternative"/> object to a builder <see cref="LexerRuleAlternativeBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleAlternativeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleAlternativeBuilder : global::MetaDslx.Modeling.MutableObject
	{
		global::MetaDslx.Modeling.MutableModelList<LexerRuleElementBuilder> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternativeBuilder"/> object to an immutable <see cref="LexerRuleAlternative"/> object.
		/// </summary>
		new LexerRuleAlternative ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternativeBuilder"/> object to an immutable <see cref="LexerRuleAlternative"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleAlternative ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleElement : RuleElement
	{
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleElement"/> object to a builder <see cref="LexerRuleElementBuilder"/> object.
		/// </summary>
		new LexerRuleElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleElement"/> object to a builder <see cref="LexerRuleElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleElementBuilder : RuleElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleElementBuilder"/> object to an immutable <see cref="LexerRuleElement"/> object.
		/// </summary>
		new LexerRuleElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleElementBuilder"/> object to an immutable <see cref="LexerRuleElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class CompilerDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static CompilerDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			NamedElement.Initialize();
			Grammar.Initialize();
			Rule.Initialize();
			RuleElement.Initialize();
			ParserRule.Initialize();
			ParserRuleAlternative.Initialize();
			ParserRuleElement.Initialize();
			ParserRuleReference.Initialize();
			ParserRuleBlock.Initialize();
			LexerRule.Initialize();
			LexerRuleAlternative.Initialize();
			LexerRuleElement.Initialize();
			properties.Add(CompilerDescriptor.NamedElement.NameProperty);
			properties.Add(CompilerDescriptor.Grammar.RulesProperty);
			properties.Add(CompilerDescriptor.RuleElement.MultiplicityProperty);
			properties.Add(CompilerDescriptor.ParserRule.AlternativesProperty);
			properties.Add(CompilerDescriptor.ParserRuleAlternative.ElementsProperty);
			properties.Add(CompilerDescriptor.ParserRuleReference.RuleProperty);
			properties.Add(CompilerDescriptor.ParserRuleBlock.AlternativesProperty);
			properties.Add(CompilerDescriptor.LexerRule.IsFragmentProperty);
			properties.Add(CompilerDescriptor.LexerRule.IsHiddenProperty);
			properties.Add(CompilerDescriptor.LexerRule.AlternativesProperty);
			properties.Add(CompilerDescriptor.LexerRuleAlternative.ElementsProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://MetaDslx.Languages.Compiler/1.0";
		public const string MPrefix = "";
	
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(NamedElement), name: "Name",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.NamedElement_Name,
					defaultValue: null);
		}
	
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
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty RulesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Grammar), name: "Rules",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Rule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Grammar_Rules,
					defaultValue: null);
		}
	
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
		}
	
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty MultiplicityProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(RuleElement), name: "Multiplicity",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.RuleElement_Multiplicity,
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
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRule), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlternative),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlternativeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRule_Alternatives,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleAlternativeId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlternative), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlternativeBuilder))]
		public static class ParserRuleAlternative
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleAlternative()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleAlternative));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleAlternative; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleAlternative), name: "Elements",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleAlternative_Elements,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.RuleElement) })]
		public static class ParserRuleElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleReferenceId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleReference), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleReferenceBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.RuleElement) })]
		public static class ParserRuleReference
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleReference()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleReference));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleReference; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty RuleProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleReference), name: "Rule",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Rule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleReference_Rule,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleBlockId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleBlock), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleBlockBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.RuleElement) })]
		public static class ParserRuleBlock
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleBlock()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleBlock));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleBlock; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleBlock), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlternative),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlternativeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleBlock_Alternatives,
					defaultValue: null);
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
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRule), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternative),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule_Alternatives,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleAlternativeId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternative), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeBuilder))]
		public static class LexerRuleAlternative
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleAlternative()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleAlternative));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternative; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleAlternative), name: "Elements",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternative_Elements,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.RuleElement) })]
		public static class LexerRuleElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleElement; }
			}
		}
	}
}

namespace MetaDslx.Languages.Compiler.Model.Internal
{
	
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<RuleBuilder> Rules
		{
			get { return this.GetList<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Grammar.RulesProperty, ref rules0); }
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
	}
	
	internal class RuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleBuilder
	{
	
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
		private global::MetaDslx.Modeling.ImmutableModelList<ParserRuleAlternative> alternatives0;
	
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
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ParserRuleAlternative> Alternatives
		{
		    get { return this.GetList<ParserRuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class ParserRuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<ParserRuleAlternativeBuilder> alternatives0;
	
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<ParserRuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<ParserRuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class ParserRuleAlternativeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleAlternative.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleAlternativeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleAlternativeBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleAlternativeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleAlternative
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ParserRuleElement> elements0;
	
		internal ParserRuleAlternativeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleAlternative;
	
		public new ParserRuleAlternativeBuilder ToMutable()
		{
			return (ParserRuleAlternativeBuilder)base.ToMutable();
		}
	
		public new ParserRuleAlternativeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleAlternativeBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ParserRuleElement> Elements
		{
		    get { return this.GetList<ParserRuleElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class ParserRuleAlternativeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleAlternativeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<ParserRuleElementBuilder> elements0;
	
		internal ParserRuleAlternativeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleAlternative(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleAlternative;
	
		public new ParserRuleAlternative ToImmutable()
		{
			return (ParserRuleAlternative)base.ToImmutable();
		}
	
		public new ParserRuleAlternative ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleAlternative)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ParserRuleElementBuilder> Elements
		{
			get { return this.GetList<ParserRuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class ParserRuleElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
	
		internal ParserRuleElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleElement;
	
		public new ParserRuleElementBuilder ToMutable()
		{
			return (ParserRuleElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleElementBuilder RuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleElementBuilder RuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty, ref multiplicity0); }
		}
	}
	
	internal class ParserRuleElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleElementBuilder
	{
	
		internal ParserRuleElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleElement;
	
		public new ParserRuleElement ToImmutable()
		{
			return (ParserRuleElement)base.ToImmutable();
		}
	
		public new ParserRuleElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RuleElement RuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RuleElement RuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
	internal class ParserRuleReferenceId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReference.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleReferenceImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleReference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Rule rule0;
	
		internal ParserRuleReferenceImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleReference;
	
		public new ParserRuleReferenceBuilder ToMutable()
		{
			return (ParserRuleReferenceBuilder)base.ToMutable();
		}
	
		public new ParserRuleReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleReferenceBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleElementBuilder RuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleElementBuilder RuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty, ref multiplicity0); }
		}
	
		
		public Rule Rule
		{
		    get { return this.GetReference<Rule>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReference.RuleProperty, ref rule0); }
		}
	}
	
	internal class ParserRuleReferenceBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleReferenceBuilder
	{
	
		internal ParserRuleReferenceBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleReference(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleReference;
	
		public new ParserRuleReference ToImmutable()
		{
			return (ParserRuleReference)base.ToImmutable();
		}
	
		public new ParserRuleReference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleReference)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RuleElement RuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RuleElement RuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		
		public RuleBuilder Rule
		{
			get { return this.GetReference<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReference.RuleProperty); }
			set { this.SetReference<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReference.RuleProperty, value); }
		}
		
		void ParserRuleReferenceBuilder.SetRuleLazy(global::System.Func<RuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleReference.RuleProperty, lazy);
		}
		
		void ParserRuleReferenceBuilder.SetRuleLazy(global::System.Func<ParserRuleReferenceBuilder, RuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleReference.RuleProperty, lazy);
		}
		
		void ParserRuleReferenceBuilder.SetRuleLazy(global::System.Func<ParserRuleReference, Rule> immutableLazy, global::System.Func<ParserRuleReferenceBuilder, RuleBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleReference.RuleProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class ParserRuleBlockId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleBlock.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleBlockImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleBlockBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleBlockImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleBlock
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ParserRuleAlternative> alternatives0;
	
		internal ParserRuleBlockImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleBlock;
	
		public new ParserRuleBlockBuilder ToMutable()
		{
			return (ParserRuleBlockBuilder)base.ToMutable();
		}
	
		public new ParserRuleBlockBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleBlockBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleElementBuilder RuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleElementBuilder RuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty, ref multiplicity0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ParserRuleAlternative> Alternatives
		{
		    get { return this.GetList<ParserRuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleBlock.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class ParserRuleBlockBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleBlockBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<ParserRuleAlternativeBuilder> alternatives0;
	
		internal ParserRuleBlockBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleBlock(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleBlock;
	
		public new ParserRuleBlock ToImmutable()
		{
			return (ParserRuleBlock)base.ToImmutable();
		}
	
		public new ParserRuleBlock ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleBlock)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RuleElement RuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RuleElement RuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<ParserRuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<ParserRuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleBlock.AlternativesProperty, ref alternatives0); }
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
		private bool isFragment0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isHidden0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> alternatives0;
	
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
	
		
		public bool IsFragment
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsFragmentProperty, ref isFragment0); }
		}
	
		
		public bool IsHidden
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.IsHiddenProperty, ref isHidden0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> Alternatives
		{
		    get { return this.GetList<LexerRuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class LexerRuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeBuilder> alternatives0;
	
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<LexerRuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class LexerRuleAlternativeId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternative.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleAlternativeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleAlternativeBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleAlternativeImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleAlternative
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<LexerRuleElement> elements0;
	
		internal LexerRuleAlternativeImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleAlternative;
	
		public new LexerRuleAlternativeBuilder ToMutable()
		{
			return (LexerRuleAlternativeBuilder)base.ToMutable();
		}
	
		public new LexerRuleAlternativeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleAlternativeBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<LexerRuleElement> Elements
		{
		    get { return this.GetList<LexerRuleElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class LexerRuleAlternativeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleAlternativeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<LexerRuleElementBuilder> elements0;
	
		internal LexerRuleAlternativeBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleAlternative(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleAlternative;
	
		public new LexerRuleAlternative ToImmutable()
		{
			return (LexerRuleAlternative)base.ToImmutable();
		}
	
		public new LexerRuleAlternative ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleAlternative)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<LexerRuleElementBuilder> Elements
		{
			get { return this.GetList<LexerRuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class LexerRuleElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
	
		internal LexerRuleElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleElement;
	
		public new LexerRuleElementBuilder ToMutable()
		{
			return (LexerRuleElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		RuleElementBuilder RuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		RuleElementBuilder RuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.RuleElement.MultiplicityProperty, ref multiplicity0); }
		}
	}
	
	internal class LexerRuleElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleElementBuilder
	{
	
		internal LexerRuleElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleElement;
	
		public new LexerRuleElement ToImmutable()
		{
			return (LexerRuleElement)base.ToImmutable();
		}
	
		public new LexerRuleElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		RuleElement RuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		RuleElement RuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder NamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder NamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Grammar;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Grammar_Rules;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Rule;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder RuleElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder RuleElement_Multiplicity;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRule;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRule_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleAlternative;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleAlternative_Elements;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleReference;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleReference_Rule;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleBlock;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleBlock_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRule;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_IsFragment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_IsHidden;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleAlternative;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleAlternative_Elements;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder Multiplicity;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp12;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp10;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp11;
	
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
			NamedElement = factory.MetaClass();
			NamedElement_Name = factory.MetaProperty();
			Grammar = factory.MetaClass();
			Grammar_Rules = factory.MetaProperty();
			Rule = factory.MetaClass();
			RuleElement = factory.MetaClass();
			RuleElement_Multiplicity = factory.MetaProperty();
			ParserRule = factory.MetaClass();
			ParserRule_Alternatives = factory.MetaProperty();
			ParserRuleAlternative = factory.MetaClass();
			ParserRuleAlternative_Elements = factory.MetaProperty();
			ParserRuleElement = factory.MetaClass();
			ParserRuleReference = factory.MetaClass();
			ParserRuleReference_Rule = factory.MetaProperty();
			ParserRuleBlock = factory.MetaClass();
			ParserRuleBlock_Alternatives = factory.MetaProperty();
			LexerRule = factory.MetaClass();
			LexerRule_IsFragment = factory.MetaProperty();
			LexerRule_IsHidden = factory.MetaProperty();
			LexerRule_Alternatives = factory.MetaProperty();
			LexerRuleAlternative = factory.MetaClass();
			LexerRuleAlternative_Elements = factory.MetaProperty();
			LexerRuleElement = factory.MetaClass();
			Multiplicity = factory.MetaEnum();
			__tmp12 = factory.MetaEnumLiteral();
			__tmp13 = factory.MetaEnumLiteral();
			__tmp14 = factory.MetaEnumLiteral();
			__tmp15 = factory.MetaEnumLiteral();
			__tmp6 = factory.MetaCollectionType();
			__tmp7 = factory.MetaCollectionType();
			__tmp8 = factory.MetaCollectionType();
			__tmp9 = factory.MetaCollectionType();
			__tmp10 = factory.MetaCollectionType();
			__tmp11 = factory.MetaCollectionType();
	
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
			__tmp4.Declarations.AddLazy(() => NamedElement);
			__tmp4.Declarations.AddLazy(() => Grammar);
			__tmp4.Declarations.AddLazy(() => Rule);
			__tmp4.Declarations.AddLazy(() => RuleElement);
			__tmp4.Declarations.AddLazy(() => ParserRule);
			__tmp4.Declarations.AddLazy(() => ParserRuleAlternative);
			__tmp4.Declarations.AddLazy(() => ParserRuleElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleReference);
			__tmp4.Declarations.AddLazy(() => ParserRuleBlock);
			__tmp4.Declarations.AddLazy(() => LexerRule);
			__tmp4.Declarations.AddLazy(() => LexerRuleAlternative);
			__tmp4.Declarations.AddLazy(() => LexerRuleElement);
			__tmp4.Declarations.AddLazy(() => Multiplicity);
			__tmp5.Documentation = null;
			__tmp5.Name = "Compiler";
			__tmp5.MajorVersion = 1;
			__tmp5.MinorVersion = 0;
			__tmp5.Uri = "http://MetaDslx.Languages.Compiler/1.0";
			__tmp5.Prefix = null;
			__tmp5.SetNamespaceLazy(() => __tmp4);
			NamedElement.Documentation = null;
			NamedElement.Name = "NamedElement";
			NamedElement.SetNamespaceLazy(() => __tmp4);
			NamedElement.SymbolType = null;
			NamedElement.IsAbstract = true;
			NamedElement.Properties.AddLazy(() => NamedElement_Name);
			NamedElement_Name.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			NamedElement_Name.Documentation = null;
			NamedElement_Name.Name = "Name";
			NamedElement_Name.SymbolProperty = null;
			NamedElement_Name.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			NamedElement_Name.SetClassLazy(() => NamedElement);
			NamedElement_Name.DefaultValue = null;
			NamedElement_Name.IsContainment = false;
			Grammar.Documentation = null;
			Grammar.Name = "Grammar";
			Grammar.SetNamespaceLazy(() => __tmp4);
			Grammar.SymbolType = null;
			Grammar.IsAbstract = false;
			Grammar.SuperClasses.AddLazy(() => NamedElement);
			Grammar.Properties.AddLazy(() => Grammar_Rules);
			Grammar_Rules.SetTypeLazy(() => __tmp6);
			Grammar_Rules.Documentation = null;
			Grammar_Rules.Name = "Rules";
			Grammar_Rules.SymbolProperty = null;
			Grammar_Rules.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Grammar_Rules.SetClassLazy(() => Grammar);
			Grammar_Rules.DefaultValue = null;
			Grammar_Rules.IsContainment = false;
			Rule.Documentation = null;
			Rule.Name = "Rule";
			Rule.SetNamespaceLazy(() => __tmp4);
			Rule.SymbolType = null;
			Rule.IsAbstract = true;
			Rule.SuperClasses.AddLazy(() => NamedElement);
			RuleElement.Documentation = null;
			RuleElement.Name = "RuleElement";
			RuleElement.SetNamespaceLazy(() => __tmp4);
			RuleElement.SymbolType = null;
			RuleElement.IsAbstract = true;
			RuleElement.SuperClasses.AddLazy(() => NamedElement);
			RuleElement.Properties.AddLazy(() => RuleElement_Multiplicity);
			RuleElement_Multiplicity.SetTypeLazy(() => Multiplicity);
			RuleElement_Multiplicity.Documentation = null;
			RuleElement_Multiplicity.Name = "Multiplicity";
			RuleElement_Multiplicity.SymbolProperty = null;
			RuleElement_Multiplicity.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			RuleElement_Multiplicity.SetClassLazy(() => RuleElement);
			RuleElement_Multiplicity.DefaultValue = null;
			RuleElement_Multiplicity.IsContainment = false;
			ParserRule.Documentation = null;
			ParserRule.Name = "ParserRule";
			ParserRule.SetNamespaceLazy(() => __tmp4);
			ParserRule.SymbolType = null;
			ParserRule.IsAbstract = false;
			ParserRule.SuperClasses.AddLazy(() => Rule);
			ParserRule.Properties.AddLazy(() => ParserRule_Alternatives);
			ParserRule_Alternatives.SetTypeLazy(() => __tmp7);
			ParserRule_Alternatives.Documentation = null;
			ParserRule_Alternatives.Name = "Alternatives";
			ParserRule_Alternatives.SymbolProperty = null;
			ParserRule_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRule_Alternatives.SetClassLazy(() => ParserRule);
			ParserRule_Alternatives.DefaultValue = null;
			ParserRule_Alternatives.IsContainment = false;
			ParserRuleAlternative.Documentation = null;
			ParserRuleAlternative.Name = "ParserRuleAlternative";
			ParserRuleAlternative.SetNamespaceLazy(() => __tmp4);
			ParserRuleAlternative.SymbolType = null;
			ParserRuleAlternative.IsAbstract = false;
			ParserRuleAlternative.Properties.AddLazy(() => ParserRuleAlternative_Elements);
			ParserRuleAlternative_Elements.SetTypeLazy(() => __tmp8);
			ParserRuleAlternative_Elements.Documentation = null;
			ParserRuleAlternative_Elements.Name = "Elements";
			ParserRuleAlternative_Elements.SymbolProperty = null;
			ParserRuleAlternative_Elements.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleAlternative_Elements.SetClassLazy(() => ParserRuleAlternative);
			ParserRuleAlternative_Elements.DefaultValue = null;
			ParserRuleAlternative_Elements.IsContainment = false;
			ParserRuleElement.Documentation = null;
			ParserRuleElement.Name = "ParserRuleElement";
			ParserRuleElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleElement.SymbolType = null;
			ParserRuleElement.IsAbstract = true;
			ParserRuleElement.SuperClasses.AddLazy(() => RuleElement);
			ParserRuleReference.Documentation = null;
			ParserRuleReference.Name = "ParserRuleReference";
			ParserRuleReference.SetNamespaceLazy(() => __tmp4);
			ParserRuleReference.SymbolType = null;
			ParserRuleReference.IsAbstract = false;
			ParserRuleReference.SuperClasses.AddLazy(() => RuleElement);
			ParserRuleReference.Properties.AddLazy(() => ParserRuleReference_Rule);
			ParserRuleReference_Rule.SetTypeLazy(() => Rule);
			ParserRuleReference_Rule.Documentation = null;
			ParserRuleReference_Rule.Name = "Rule";
			ParserRuleReference_Rule.SymbolProperty = null;
			ParserRuleReference_Rule.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleReference_Rule.SetClassLazy(() => ParserRuleReference);
			ParserRuleReference_Rule.DefaultValue = null;
			ParserRuleReference_Rule.IsContainment = false;
			ParserRuleBlock.Documentation = null;
			ParserRuleBlock.Name = "ParserRuleBlock";
			ParserRuleBlock.SetNamespaceLazy(() => __tmp4);
			ParserRuleBlock.SymbolType = null;
			ParserRuleBlock.IsAbstract = false;
			ParserRuleBlock.SuperClasses.AddLazy(() => RuleElement);
			ParserRuleBlock.Properties.AddLazy(() => ParserRuleBlock_Alternatives);
			ParserRuleBlock_Alternatives.SetTypeLazy(() => __tmp9);
			ParserRuleBlock_Alternatives.Documentation = null;
			ParserRuleBlock_Alternatives.Name = "Alternatives";
			ParserRuleBlock_Alternatives.SymbolProperty = null;
			ParserRuleBlock_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleBlock_Alternatives.SetClassLazy(() => ParserRuleBlock);
			ParserRuleBlock_Alternatives.DefaultValue = null;
			ParserRuleBlock_Alternatives.IsContainment = false;
			LexerRule.Documentation = null;
			LexerRule.Name = "LexerRule";
			LexerRule.SetNamespaceLazy(() => __tmp4);
			LexerRule.SymbolType = null;
			LexerRule.IsAbstract = false;
			LexerRule.SuperClasses.AddLazy(() => Rule);
			LexerRule.Properties.AddLazy(() => LexerRule_IsFragment);
			LexerRule.Properties.AddLazy(() => LexerRule_IsHidden);
			LexerRule.Properties.AddLazy(() => LexerRule_Alternatives);
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
			LexerRule_Alternatives.SetTypeLazy(() => __tmp10);
			LexerRule_Alternatives.Documentation = null;
			LexerRule_Alternatives.Name = "Alternatives";
			LexerRule_Alternatives.SymbolProperty = null;
			LexerRule_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRule_Alternatives.SetClassLazy(() => LexerRule);
			LexerRule_Alternatives.DefaultValue = null;
			LexerRule_Alternatives.IsContainment = false;
			LexerRuleAlternative.Documentation = null;
			LexerRuleAlternative.Name = "LexerRuleAlternative";
			LexerRuleAlternative.SetNamespaceLazy(() => __tmp4);
			LexerRuleAlternative.SymbolType = null;
			LexerRuleAlternative.IsAbstract = false;
			LexerRuleAlternative.Properties.AddLazy(() => LexerRuleAlternative_Elements);
			LexerRuleAlternative_Elements.SetTypeLazy(() => __tmp11);
			LexerRuleAlternative_Elements.Documentation = null;
			LexerRuleAlternative_Elements.Name = "Elements";
			LexerRuleAlternative_Elements.SymbolProperty = null;
			LexerRuleAlternative_Elements.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleAlternative_Elements.SetClassLazy(() => LexerRuleAlternative);
			LexerRuleAlternative_Elements.DefaultValue = null;
			LexerRuleAlternative_Elements.IsContainment = false;
			LexerRuleElement.Documentation = null;
			LexerRuleElement.Name = "LexerRuleElement";
			LexerRuleElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleElement.SymbolType = null;
			LexerRuleElement.IsAbstract = false;
			LexerRuleElement.SuperClasses.AddLazy(() => RuleElement);
			Multiplicity.Documentation = null;
			Multiplicity.Name = "Multiplicity";
			Multiplicity.SetNamespaceLazy(() => __tmp4);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp12);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp13);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp14);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp15);
			__tmp12.Documentation = null;
			__tmp12.Name = "ExactlyOne";
			__tmp12.SetEnumLazy(() => Multiplicity);
			__tmp13.Documentation = null;
			__tmp13.Name = "ZeroOrOne";
			__tmp13.SetEnumLazy(() => Multiplicity);
			__tmp14.Documentation = null;
			__tmp14.Name = "ZeroOrMore";
			__tmp14.SetEnumLazy(() => Multiplicity);
			__tmp15.Documentation = null;
			__tmp15.Name = "OneOrMore";
			__tmp15.SetEnumLazy(() => Multiplicity);
			__tmp6.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp6.SetInnerTypeLazy(() => Rule);
			__tmp7.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp7.SetInnerTypeLazy(() => ParserRuleAlternative);
			__tmp8.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp8.SetInnerTypeLazy(() => ParserRuleElement);
			__tmp9.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp9.SetInnerTypeLazy(() => ParserRuleAlternative);
			__tmp10.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp10.SetInnerTypeLazy(() => LexerRuleAlternative);
			__tmp11.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp11.SetInnerTypeLazy(() => LexerRuleElement);
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
		/// Implements the constructor: ParserRuleAlternative()
		/// </summary>
		public virtual void ParserRuleAlternative(ParserRuleAlternativeBuilder _this)
		{
			this.CallParserRuleAlternativeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleAlternative
		/// </summary>
		protected virtual void CallParserRuleAlternativeSuperConstructors(ParserRuleAlternativeBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>RuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RuleElement</li>
		/// </ul>
		public virtual void ParserRuleElement(ParserRuleElementBuilder _this)
		{
			this.CallParserRuleElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleElement
		/// </summary>
		protected virtual void CallParserRuleElementSuperConstructors(ParserRuleElementBuilder _this)
		{
			this.NamedElement(_this);
			this.RuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleReference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>RuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RuleElement</li>
		/// </ul>
		public virtual void ParserRuleReference(ParserRuleReferenceBuilder _this)
		{
			this.CallParserRuleReferenceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleReference
		/// </summary>
		protected virtual void CallParserRuleReferenceSuperConstructors(ParserRuleReferenceBuilder _this)
		{
			this.NamedElement(_this);
			this.RuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleBlock()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>RuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RuleElement</li>
		/// </ul>
		public virtual void ParserRuleBlock(ParserRuleBlockBuilder _this)
		{
			this.CallParserRuleBlockSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleBlock
		/// </summary>
		protected virtual void CallParserRuleBlockSuperConstructors(ParserRuleBlockBuilder _this)
		{
			this.NamedElement(_this);
			this.RuleElement(_this);
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
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleAlternative()
		/// </summary>
		public virtual void LexerRuleAlternative(LexerRuleAlternativeBuilder _this)
		{
			this.CallLexerRuleAlternativeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleAlternative
		/// </summary>
		protected virtual void CallLexerRuleAlternativeSuperConstructors(LexerRuleAlternativeBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>RuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>RuleElement</li>
		/// </ul>
		public virtual void LexerRuleElement(LexerRuleElementBuilder _this)
		{
			this.CallLexerRuleElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleElement
		/// </summary>
		protected virtual void CallLexerRuleElementSuperConstructors(LexerRuleElementBuilder _this)
		{
			this.NamedElement(_this);
			this.RuleElement(_this);
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

