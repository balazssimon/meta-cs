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
	
	
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass AnnotatedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty AnnotatedElement_Annotations;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass Annotation;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty Annotation_Properties;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass AnnotationProperty;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty AnnotationProperty_Value;
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
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRule_DefinedModelObject;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleAlt;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleAlt_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleSimple;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleSimple_Elements;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleNamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleNamedElement_IsNegated;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleNamedElement_Element;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleNamedElement_AssignmentOperator;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleNamedElement_Multiplicity;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleReferenceElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleReferenceElement_Rule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleEofElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleFixedElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty ParserRuleFixedElement_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleWildcardElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass ParserRuleBlockElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_IsFragment;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_IsHidden;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_ValueType;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRule_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleAlternative;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleAlternative_Elements;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleAlternativeElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleAlternativeElement_IsNegated;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleAlternativeElement_Element;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleAlternativeElement_Multiplicity;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleReferenceElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleReferenceElement_Rule;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleFixedStringElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleFixedStringElement_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleFixedCharElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleFixedCharElement_Value;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleWildcardElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleBlockElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleBlockElement_Alternatives;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaClass LexerRuleRangeElement;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleRangeElement_Start;
		public static readonly global::MetaDslx.Languages.Meta.Model.MetaProperty LexerRuleRangeElement_End;
	
		static CompilerInstance()
		{
			CompilerBuilderInstance.instance.Create();
			CompilerBuilderInstance.instance.EvaluateLazyValues();
			MModel = CompilerBuilderInstance.instance.MModel.ToImmutable();
			MMetadata = MModel.Metadata;
	
	
			AnnotatedElement = CompilerBuilderInstance.instance.AnnotatedElement.ToImmutable(MModel);
			AnnotatedElement_Annotations = CompilerBuilderInstance.instance.AnnotatedElement_Annotations.ToImmutable(MModel);
			Annotation = CompilerBuilderInstance.instance.Annotation.ToImmutable(MModel);
			Annotation_Properties = CompilerBuilderInstance.instance.Annotation_Properties.ToImmutable(MModel);
			AnnotationProperty = CompilerBuilderInstance.instance.AnnotationProperty.ToImmutable(MModel);
			AnnotationProperty_Value = CompilerBuilderInstance.instance.AnnotationProperty_Value.ToImmutable(MModel);
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
			ParserRule = CompilerBuilderInstance.instance.ParserRule.ToImmutable(MModel);
			ParserRule_DefinedModelObject = CompilerBuilderInstance.instance.ParserRule_DefinedModelObject.ToImmutable(MModel);
			ParserRuleAlt = CompilerBuilderInstance.instance.ParserRuleAlt.ToImmutable(MModel);
			ParserRuleAlt_Alternatives = CompilerBuilderInstance.instance.ParserRuleAlt_Alternatives.ToImmutable(MModel);
			ParserRuleSimple = CompilerBuilderInstance.instance.ParserRuleSimple.ToImmutable(MModel);
			ParserRuleSimple_Elements = CompilerBuilderInstance.instance.ParserRuleSimple_Elements.ToImmutable(MModel);
			ParserRuleNamedElement = CompilerBuilderInstance.instance.ParserRuleNamedElement.ToImmutable(MModel);
			ParserRuleNamedElement_IsNegated = CompilerBuilderInstance.instance.ParserRuleNamedElement_IsNegated.ToImmutable(MModel);
			ParserRuleNamedElement_Element = CompilerBuilderInstance.instance.ParserRuleNamedElement_Element.ToImmutable(MModel);
			ParserRuleNamedElement_AssignmentOperator = CompilerBuilderInstance.instance.ParserRuleNamedElement_AssignmentOperator.ToImmutable(MModel);
			ParserRuleNamedElement_Multiplicity = CompilerBuilderInstance.instance.ParserRuleNamedElement_Multiplicity.ToImmutable(MModel);
			ParserRuleElement = CompilerBuilderInstance.instance.ParserRuleElement.ToImmutable(MModel);
			ParserRuleReferenceElement = CompilerBuilderInstance.instance.ParserRuleReferenceElement.ToImmutable(MModel);
			ParserRuleReferenceElement_Rule = CompilerBuilderInstance.instance.ParserRuleReferenceElement_Rule.ToImmutable(MModel);
			ParserRuleEofElement = CompilerBuilderInstance.instance.ParserRuleEofElement.ToImmutable(MModel);
			ParserRuleFixedElement = CompilerBuilderInstance.instance.ParserRuleFixedElement.ToImmutable(MModel);
			ParserRuleFixedElement_Value = CompilerBuilderInstance.instance.ParserRuleFixedElement_Value.ToImmutable(MModel);
			ParserRuleWildcardElement = CompilerBuilderInstance.instance.ParserRuleWildcardElement.ToImmutable(MModel);
			ParserRuleBlockElement = CompilerBuilderInstance.instance.ParserRuleBlockElement.ToImmutable(MModel);
			LexerRule = CompilerBuilderInstance.instance.LexerRule.ToImmutable(MModel);
			LexerRule_IsFragment = CompilerBuilderInstance.instance.LexerRule_IsFragment.ToImmutable(MModel);
			LexerRule_IsHidden = CompilerBuilderInstance.instance.LexerRule_IsHidden.ToImmutable(MModel);
			LexerRule_ValueType = CompilerBuilderInstance.instance.LexerRule_ValueType.ToImmutable(MModel);
			LexerRule_Value = CompilerBuilderInstance.instance.LexerRule_Value.ToImmutable(MModel);
			LexerRule_Alternatives = CompilerBuilderInstance.instance.LexerRule_Alternatives.ToImmutable(MModel);
			LexerRuleAlternative = CompilerBuilderInstance.instance.LexerRuleAlternative.ToImmutable(MModel);
			LexerRuleAlternative_Elements = CompilerBuilderInstance.instance.LexerRuleAlternative_Elements.ToImmutable(MModel);
			LexerRuleAlternativeElement = CompilerBuilderInstance.instance.LexerRuleAlternativeElement.ToImmutable(MModel);
			LexerRuleAlternativeElement_IsNegated = CompilerBuilderInstance.instance.LexerRuleAlternativeElement_IsNegated.ToImmutable(MModel);
			LexerRuleAlternativeElement_Element = CompilerBuilderInstance.instance.LexerRuleAlternativeElement_Element.ToImmutable(MModel);
			LexerRuleAlternativeElement_Multiplicity = CompilerBuilderInstance.instance.LexerRuleAlternativeElement_Multiplicity.ToImmutable(MModel);
			LexerRuleElement = CompilerBuilderInstance.instance.LexerRuleElement.ToImmutable(MModel);
			LexerRuleReferenceElement = CompilerBuilderInstance.instance.LexerRuleReferenceElement.ToImmutable(MModel);
			LexerRuleReferenceElement_Rule = CompilerBuilderInstance.instance.LexerRuleReferenceElement_Rule.ToImmutable(MModel);
			LexerRuleFixedStringElement = CompilerBuilderInstance.instance.LexerRuleFixedStringElement.ToImmutable(MModel);
			LexerRuleFixedStringElement_Value = CompilerBuilderInstance.instance.LexerRuleFixedStringElement_Value.ToImmutable(MModel);
			LexerRuleFixedCharElement = CompilerBuilderInstance.instance.LexerRuleFixedCharElement.ToImmutable(MModel);
			LexerRuleFixedCharElement_Value = CompilerBuilderInstance.instance.LexerRuleFixedCharElement_Value.ToImmutable(MModel);
			LexerRuleWildcardElement = CompilerBuilderInstance.instance.LexerRuleWildcardElement.ToImmutable(MModel);
			LexerRuleBlockElement = CompilerBuilderInstance.instance.LexerRuleBlockElement.ToImmutable(MModel);
			LexerRuleBlockElement_Alternatives = CompilerBuilderInstance.instance.LexerRuleBlockElement_Alternatives.ToImmutable(MModel);
			LexerRuleRangeElement = CompilerBuilderInstance.instance.LexerRuleRangeElement.ToImmutable(MModel);
			LexerRuleRangeElement_Start = CompilerBuilderInstance.instance.LexerRuleRangeElement_Start.ToImmutable(MModel);
			LexerRuleRangeElement_End = CompilerBuilderInstance.instance.LexerRuleRangeElement_End.ToImmutable(MModel);
	
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
				case "AnnotatedElement": return this.AnnotatedElement();
				case "Annotation": return this.Annotation();
				case "AnnotationProperty": return this.AnnotationProperty();
				case "Namespace": return this.Namespace();
				case "NamedElement": return this.NamedElement();
				case "Grammar": return this.Grammar();
				case "GrammarOptions": return this.GrammarOptions();
				case "ParserRule": return this.ParserRule();
				case "ParserRuleAlt": return this.ParserRuleAlt();
				case "ParserRuleSimple": return this.ParserRuleSimple();
				case "ParserRuleNamedElement": return this.ParserRuleNamedElement();
				case "ParserRuleReferenceElement": return this.ParserRuleReferenceElement();
				case "ParserRuleEofElement": return this.ParserRuleEofElement();
				case "ParserRuleFixedElement": return this.ParserRuleFixedElement();
				case "ParserRuleWildcardElement": return this.ParserRuleWildcardElement();
				case "ParserRuleBlockElement": return this.ParserRuleBlockElement();
				case "LexerRule": return this.LexerRule();
				case "LexerRuleAlternative": return this.LexerRuleAlternative();
				case "LexerRuleAlternativeElement": return this.LexerRuleAlternativeElement();
				case "LexerRuleReferenceElement": return this.LexerRuleReferenceElement();
				case "LexerRuleFixedStringElement": return this.LexerRuleFixedStringElement();
				case "LexerRuleFixedCharElement": return this.LexerRuleFixedCharElement();
				case "LexerRuleWildcardElement": return this.LexerRuleWildcardElement();
				case "LexerRuleBlockElement": return this.LexerRuleBlockElement();
				case "LexerRuleRangeElement": return this.LexerRuleRangeElement();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of AnnotatedElement.
		/// </summary>
		public AnnotatedElementBuilder AnnotatedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new AnnotatedElementId());
			return (AnnotatedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of Annotation.
		/// </summary>
		public AnnotationBuilder Annotation()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new AnnotationId());
			return (AnnotationBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of AnnotationProperty.
		/// </summary>
		public AnnotationPropertyBuilder AnnotationProperty()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new AnnotationPropertyId());
			return (AnnotationPropertyBuilder)obj;
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
		/// Creates a new instance of ParserRule.
		/// </summary>
		public ParserRuleBuilder ParserRule()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleId());
			return (ParserRuleBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleAlt.
		/// </summary>
		public ParserRuleAltBuilder ParserRuleAlt()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleAltId());
			return (ParserRuleAltBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleSimple.
		/// </summary>
		public ParserRuleSimpleBuilder ParserRuleSimple()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleSimpleId());
			return (ParserRuleSimpleBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleNamedElement.
		/// </summary>
		public ParserRuleNamedElementBuilder ParserRuleNamedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleNamedElementId());
			return (ParserRuleNamedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleReferenceElement.
		/// </summary>
		public ParserRuleReferenceElementBuilder ParserRuleReferenceElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleReferenceElementId());
			return (ParserRuleReferenceElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleEofElement.
		/// </summary>
		public ParserRuleEofElementBuilder ParserRuleEofElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleEofElementId());
			return (ParserRuleEofElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleFixedElement.
		/// </summary>
		public ParserRuleFixedElementBuilder ParserRuleFixedElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleFixedElementId());
			return (ParserRuleFixedElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleWildcardElement.
		/// </summary>
		public ParserRuleWildcardElementBuilder ParserRuleWildcardElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleWildcardElementId());
			return (ParserRuleWildcardElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of ParserRuleBlockElement.
		/// </summary>
		public ParserRuleBlockElementBuilder ParserRuleBlockElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new ParserRuleBlockElementId());
			return (ParserRuleBlockElementBuilder)obj;
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
		/// Creates a new instance of LexerRuleAlternativeElement.
		/// </summary>
		public LexerRuleAlternativeElementBuilder LexerRuleAlternativeElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleAlternativeElementId());
			return (LexerRuleAlternativeElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleReferenceElement.
		/// </summary>
		public LexerRuleReferenceElementBuilder LexerRuleReferenceElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleReferenceElementId());
			return (LexerRuleReferenceElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleFixedStringElement.
		/// </summary>
		public LexerRuleFixedStringElementBuilder LexerRuleFixedStringElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleFixedStringElementId());
			return (LexerRuleFixedStringElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleFixedCharElement.
		/// </summary>
		public LexerRuleFixedCharElementBuilder LexerRuleFixedCharElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleFixedCharElementId());
			return (LexerRuleFixedCharElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleWildcardElement.
		/// </summary>
		public LexerRuleWildcardElementBuilder LexerRuleWildcardElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleWildcardElementId());
			return (LexerRuleWildcardElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleBlockElement.
		/// </summary>
		public LexerRuleBlockElementBuilder LexerRuleBlockElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleBlockElementId());
			return (LexerRuleBlockElementBuilder)obj;
		}
	
		/// <summary>
		/// Creates a new instance of LexerRuleRangeElement.
		/// </summary>
		public LexerRuleRangeElementBuilder LexerRuleRangeElement()
		{
			global::MetaDslx.Modeling.MutableObject obj = this.CreateObject(new LexerRuleRangeElementId());
			return (LexerRuleRangeElementBuilder)obj;
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
	
	public interface AnnotatedElement : global::MetaDslx.Modeling.ImmutableObject
	{
		global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="AnnotatedElement"/> object to a builder <see cref="AnnotatedElementBuilder"/> object.
		/// </summary>
		new AnnotatedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="AnnotatedElement"/> object to a builder <see cref="AnnotatedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new AnnotatedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AnnotatedElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
		global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations { get; }
	
	
		/// <summary>
		/// Convert the <see cref="AnnotatedElementBuilder"/> object to an immutable <see cref="AnnotatedElement"/> object.
		/// </summary>
		new AnnotatedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="AnnotatedElementBuilder"/> object to an immutable <see cref="AnnotatedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new AnnotatedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Annotation : NamedElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<AnnotationProperty> Properties { get; }
	
	
		/// <summary>
		/// Convert the <see cref="Annotation"/> object to a builder <see cref="AnnotationBuilder"/> object.
		/// </summary>
		new AnnotationBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="Annotation"/> object to a builder <see cref="AnnotationBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new AnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AnnotationBuilder : NamedElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<AnnotationPropertyBuilder> Properties { get; }
	
	
		/// <summary>
		/// Convert the <see cref="AnnotationBuilder"/> object to an immutable <see cref="Annotation"/> object.
		/// </summary>
		new Annotation ToImmutable();
		/// <summary>
		/// Convert the <see cref="AnnotationBuilder"/> object to an immutable <see cref="Annotation"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new Annotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface AnnotationProperty : NamedElement
	{
		string Value { get; }
	
	
		/// <summary>
		/// Convert the <see cref="AnnotationProperty"/> object to a builder <see cref="AnnotationPropertyBuilder"/> object.
		/// </summary>
		new AnnotationPropertyBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="AnnotationProperty"/> object to a builder <see cref="AnnotationPropertyBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new AnnotationPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AnnotationPropertyBuilder : NamedElementBuilder
	{
		string Value { get; set; }
		void SetValueLazy(global::System.Func<string> lazy);
		void SetValueLazy(global::System.Func<AnnotationPropertyBuilder, string> lazy);
		void SetValueLazy(global::System.Func<AnnotationProperty, string> immutableLazy, global::System.Func<AnnotationPropertyBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="AnnotationPropertyBuilder"/> object to an immutable <see cref="AnnotationProperty"/> object.
		/// </summary>
		new AnnotationProperty ToImmutable();
		/// <summary>
		/// Convert the <see cref="AnnotationPropertyBuilder"/> object to an immutable <see cref="AnnotationProperty"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new AnnotationProperty ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
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
	
	public interface NamedElement : AnnotatedElement
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
	
	public interface NamedElementBuilder : AnnotatedElementBuilder
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
	
	public interface ParserRule : Rule
	{
		System.Type DefinedModelObject { get; }
	
	
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
		System.Type DefinedModelObject { get; set; }
		void SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy);
		void SetDefinedModelObjectLazy(global::System.Func<ParserRuleBuilder, System.Type> lazy);
		void SetDefinedModelObjectLazy(global::System.Func<ParserRule, System.Type> immutableLazy, global::System.Func<ParserRuleBuilder, System.Type> mutableLazy);
	
	
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
	
	public interface ParserRuleAlt : ParserRule
	{
		global::MetaDslx.Modeling.ImmutableModelList<ParserRule> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleAlt"/> object to a builder <see cref="ParserRuleAltBuilder"/> object.
		/// </summary>
		new ParserRuleAltBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleAlt"/> object to a builder <see cref="ParserRuleAltBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleAltBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleAltBuilder : ParserRuleBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<ParserRuleBuilder> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleAltBuilder"/> object to an immutable <see cref="ParserRuleAlt"/> object.
		/// </summary>
		new ParserRuleAlt ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleAltBuilder"/> object to an immutable <see cref="ParserRuleAlt"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleAlt ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleSimple : ParserRule
	{
		global::MetaDslx.Modeling.ImmutableModelList<ParserRuleNamedElement> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleSimple"/> object to a builder <see cref="ParserRuleSimpleBuilder"/> object.
		/// </summary>
		new ParserRuleSimpleBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleSimple"/> object to a builder <see cref="ParserRuleSimpleBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleSimpleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleSimpleBuilder : ParserRuleBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<ParserRuleNamedElementBuilder> Elements { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleSimpleBuilder"/> object to an immutable <see cref="ParserRuleSimple"/> object.
		/// </summary>
		new ParserRuleSimple ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleSimpleBuilder"/> object to an immutable <see cref="ParserRuleSimple"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleSimple ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleNamedElement : NamedElement
	{
		bool IsNegated { get; }
		ParserRuleElement Element { get; }
		AssignmentOperator AssignmentOperator { get; }
		Multiplicity Multiplicity { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleNamedElement"/> object to a builder <see cref="ParserRuleNamedElementBuilder"/> object.
		/// </summary>
		new ParserRuleNamedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleNamedElement"/> object to a builder <see cref="ParserRuleNamedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleNamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleNamedElementBuilder : NamedElementBuilder
	{
		bool IsNegated { get; set; }
		void SetIsNegatedLazy(global::System.Func<bool> lazy);
		void SetIsNegatedLazy(global::System.Func<ParserRuleNamedElementBuilder, bool> lazy);
		void SetIsNegatedLazy(global::System.Func<ParserRuleNamedElement, bool> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, bool> mutableLazy);
		ParserRuleElementBuilder Element { get; set; }
		void SetElementLazy(global::System.Func<ParserRuleElementBuilder> lazy);
		void SetElementLazy(global::System.Func<ParserRuleNamedElementBuilder, ParserRuleElementBuilder> lazy);
		void SetElementLazy(global::System.Func<ParserRuleNamedElement, ParserRuleElement> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, ParserRuleElementBuilder> mutableLazy);
		AssignmentOperator AssignmentOperator { get; set; }
		void SetAssignmentOperatorLazy(global::System.Func<AssignmentOperator> lazy);
		void SetAssignmentOperatorLazy(global::System.Func<ParserRuleNamedElementBuilder, AssignmentOperator> lazy);
		void SetAssignmentOperatorLazy(global::System.Func<ParserRuleNamedElement, AssignmentOperator> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, AssignmentOperator> mutableLazy);
		Multiplicity Multiplicity { get; set; }
		void SetMultiplicityLazy(global::System.Func<Multiplicity> lazy);
		void SetMultiplicityLazy(global::System.Func<ParserRuleNamedElementBuilder, Multiplicity> lazy);
		void SetMultiplicityLazy(global::System.Func<ParserRuleNamedElement, Multiplicity> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, Multiplicity> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleNamedElementBuilder"/> object to an immutable <see cref="ParserRuleNamedElement"/> object.
		/// </summary>
		new ParserRuleNamedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleNamedElementBuilder"/> object to an immutable <see cref="ParserRuleNamedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleNamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleElement : AnnotatedElement
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
	
	public interface ParserRuleElementBuilder : AnnotatedElementBuilder
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
	
	public interface ParserRuleReferenceElement : ParserRuleElement
	{
		Rule Rule { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleReferenceElement"/> object to a builder <see cref="ParserRuleReferenceElementBuilder"/> object.
		/// </summary>
		new ParserRuleReferenceElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleReferenceElement"/> object to a builder <see cref="ParserRuleReferenceElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleReferenceElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleReferenceElementBuilder : ParserRuleElementBuilder
	{
		RuleBuilder Rule { get; set; }
		void SetRuleLazy(global::System.Func<RuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<ParserRuleReferenceElementBuilder, RuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<ParserRuleReferenceElement, Rule> immutableLazy, global::System.Func<ParserRuleReferenceElementBuilder, RuleBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleReferenceElementBuilder"/> object to an immutable <see cref="ParserRuleReferenceElement"/> object.
		/// </summary>
		new ParserRuleReferenceElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleReferenceElementBuilder"/> object to an immutable <see cref="ParserRuleReferenceElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleReferenceElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleEofElement : ParserRuleElement
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleEofElement"/> object to a builder <see cref="ParserRuleEofElementBuilder"/> object.
		/// </summary>
		new ParserRuleEofElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleEofElement"/> object to a builder <see cref="ParserRuleEofElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleEofElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleEofElementBuilder : ParserRuleElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleEofElementBuilder"/> object to an immutable <see cref="ParserRuleEofElement"/> object.
		/// </summary>
		new ParserRuleEofElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleEofElementBuilder"/> object to an immutable <see cref="ParserRuleEofElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleEofElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleFixedElement : ParserRuleElement
	{
		string Value { get; }
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleFixedElement"/> object to a builder <see cref="ParserRuleFixedElementBuilder"/> object.
		/// </summary>
		new ParserRuleFixedElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleFixedElement"/> object to a builder <see cref="ParserRuleFixedElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleFixedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleFixedElementBuilder : ParserRuleElementBuilder
	{
		string Value { get; set; }
		void SetValueLazy(global::System.Func<string> lazy);
		void SetValueLazy(global::System.Func<ParserRuleFixedElementBuilder, string> lazy);
		void SetValueLazy(global::System.Func<ParserRuleFixedElement, string> immutableLazy, global::System.Func<ParserRuleFixedElementBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleFixedElementBuilder"/> object to an immutable <see cref="ParserRuleFixedElement"/> object.
		/// </summary>
		new ParserRuleFixedElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleFixedElementBuilder"/> object to an immutable <see cref="ParserRuleFixedElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleFixedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleWildcardElement : ParserRuleElement
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleWildcardElement"/> object to a builder <see cref="ParserRuleWildcardElementBuilder"/> object.
		/// </summary>
		new ParserRuleWildcardElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleWildcardElement"/> object to a builder <see cref="ParserRuleWildcardElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleWildcardElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleWildcardElementBuilder : ParserRuleElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleWildcardElementBuilder"/> object to an immutable <see cref="ParserRuleWildcardElement"/> object.
		/// </summary>
		new ParserRuleWildcardElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleWildcardElementBuilder"/> object to an immutable <see cref="ParserRuleWildcardElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleWildcardElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ParserRuleBlockElement : ParserRuleElement, ParserRuleSimple
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleBlockElement"/> object to a builder <see cref="ParserRuleBlockElementBuilder"/> object.
		/// </summary>
		new ParserRuleBlockElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleBlockElement"/> object to a builder <see cref="ParserRuleBlockElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new ParserRuleBlockElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ParserRuleBlockElementBuilder : ParserRuleElementBuilder, ParserRuleSimpleBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="ParserRuleBlockElementBuilder"/> object to an immutable <see cref="ParserRuleBlockElement"/> object.
		/// </summary>
		new ParserRuleBlockElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="ParserRuleBlockElementBuilder"/> object to an immutable <see cref="ParserRuleBlockElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new ParserRuleBlockElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRule : Rule
	{
		bool IsFragment { get; }
		bool IsHidden { get; }
		System.Type ValueType { get; }
		object Value { get; }
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
		System.Type ValueType { get; set; }
		void SetValueTypeLazy(global::System.Func<System.Type> lazy);
		void SetValueTypeLazy(global::System.Func<LexerRuleBuilder, System.Type> lazy);
		void SetValueTypeLazy(global::System.Func<LexerRule, System.Type> immutableLazy, global::System.Func<LexerRuleBuilder, System.Type> mutableLazy);
		object Value { get; set; }
		void SetValueLazy(global::System.Func<object> lazy);
		void SetValueLazy(global::System.Func<LexerRuleBuilder, object> lazy);
		void SetValueLazy(global::System.Func<LexerRule, object> immutableLazy, global::System.Func<LexerRuleBuilder, object> mutableLazy);
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
		global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternativeElement> Elements { get; }
	
	
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
		global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeElementBuilder> Elements { get; }
	
	
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
	
	public interface LexerRuleAlternativeElement : global::MetaDslx.Modeling.ImmutableObject
	{
		bool IsNegated { get; }
		LexerRuleElement Element { get; }
		Multiplicity Multiplicity { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternativeElement"/> object to a builder <see cref="LexerRuleAlternativeElementBuilder"/> object.
		/// </summary>
		new LexerRuleAlternativeElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternativeElement"/> object to a builder <see cref="LexerRuleAlternativeElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleAlternativeElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleAlternativeElementBuilder : global::MetaDslx.Modeling.MutableObject
	{
		bool IsNegated { get; set; }
		void SetIsNegatedLazy(global::System.Func<bool> lazy);
		void SetIsNegatedLazy(global::System.Func<LexerRuleAlternativeElementBuilder, bool> lazy);
		void SetIsNegatedLazy(global::System.Func<LexerRuleAlternativeElement, bool> immutableLazy, global::System.Func<LexerRuleAlternativeElementBuilder, bool> mutableLazy);
		LexerRuleElementBuilder Element { get; set; }
		void SetElementLazy(global::System.Func<LexerRuleElementBuilder> lazy);
		void SetElementLazy(global::System.Func<LexerRuleAlternativeElementBuilder, LexerRuleElementBuilder> lazy);
		void SetElementLazy(global::System.Func<LexerRuleAlternativeElement, LexerRuleElement> immutableLazy, global::System.Func<LexerRuleAlternativeElementBuilder, LexerRuleElementBuilder> mutableLazy);
		Multiplicity Multiplicity { get; set; }
		void SetMultiplicityLazy(global::System.Func<Multiplicity> lazy);
		void SetMultiplicityLazy(global::System.Func<LexerRuleAlternativeElementBuilder, Multiplicity> lazy);
		void SetMultiplicityLazy(global::System.Func<LexerRuleAlternativeElement, Multiplicity> immutableLazy, global::System.Func<LexerRuleAlternativeElementBuilder, Multiplicity> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternativeElementBuilder"/> object to an immutable <see cref="LexerRuleAlternativeElement"/> object.
		/// </summary>
		new LexerRuleAlternativeElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleAlternativeElementBuilder"/> object to an immutable <see cref="LexerRuleAlternativeElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleAlternativeElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleElement : global::MetaDslx.Modeling.ImmutableObject
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
	
	public interface LexerRuleElementBuilder : global::MetaDslx.Modeling.MutableObject
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
	
	public interface LexerRuleReferenceElement : LexerRuleElement
	{
		LexerRule Rule { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleReferenceElement"/> object to a builder <see cref="LexerRuleReferenceElementBuilder"/> object.
		/// </summary>
		new LexerRuleReferenceElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleReferenceElement"/> object to a builder <see cref="LexerRuleReferenceElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleReferenceElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleReferenceElementBuilder : LexerRuleElementBuilder
	{
		LexerRuleBuilder Rule { get; set; }
		void SetRuleLazy(global::System.Func<LexerRuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<LexerRuleReferenceElementBuilder, LexerRuleBuilder> lazy);
		void SetRuleLazy(global::System.Func<LexerRuleReferenceElement, LexerRule> immutableLazy, global::System.Func<LexerRuleReferenceElementBuilder, LexerRuleBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleReferenceElementBuilder"/> object to an immutable <see cref="LexerRuleReferenceElement"/> object.
		/// </summary>
		new LexerRuleReferenceElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleReferenceElementBuilder"/> object to an immutable <see cref="LexerRuleReferenceElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleReferenceElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleFixedStringElement : LexerRuleElement
	{
		string Value { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedStringElement"/> object to a builder <see cref="LexerRuleFixedStringElementBuilder"/> object.
		/// </summary>
		new LexerRuleFixedStringElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedStringElement"/> object to a builder <see cref="LexerRuleFixedStringElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleFixedStringElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleFixedStringElementBuilder : LexerRuleElementBuilder
	{
		string Value { get; set; }
		void SetValueLazy(global::System.Func<string> lazy);
		void SetValueLazy(global::System.Func<LexerRuleFixedStringElementBuilder, string> lazy);
		void SetValueLazy(global::System.Func<LexerRuleFixedStringElement, string> immutableLazy, global::System.Func<LexerRuleFixedStringElementBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedStringElementBuilder"/> object to an immutable <see cref="LexerRuleFixedStringElement"/> object.
		/// </summary>
		new LexerRuleFixedStringElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedStringElementBuilder"/> object to an immutable <see cref="LexerRuleFixedStringElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleFixedStringElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleFixedCharElement : LexerRuleElement
	{
		string Value { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedCharElement"/> object to a builder <see cref="LexerRuleFixedCharElementBuilder"/> object.
		/// </summary>
		new LexerRuleFixedCharElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedCharElement"/> object to a builder <see cref="LexerRuleFixedCharElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleFixedCharElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleFixedCharElementBuilder : LexerRuleElementBuilder
	{
		string Value { get; set; }
		void SetValueLazy(global::System.Func<string> lazy);
		void SetValueLazy(global::System.Func<LexerRuleFixedCharElementBuilder, string> lazy);
		void SetValueLazy(global::System.Func<LexerRuleFixedCharElement, string> immutableLazy, global::System.Func<LexerRuleFixedCharElementBuilder, string> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedCharElementBuilder"/> object to an immutable <see cref="LexerRuleFixedCharElement"/> object.
		/// </summary>
		new LexerRuleFixedCharElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleFixedCharElementBuilder"/> object to an immutable <see cref="LexerRuleFixedCharElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleFixedCharElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleWildcardElement : LexerRuleElement
	{
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleWildcardElement"/> object to a builder <see cref="LexerRuleWildcardElementBuilder"/> object.
		/// </summary>
		new LexerRuleWildcardElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleWildcardElement"/> object to a builder <see cref="LexerRuleWildcardElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleWildcardElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleWildcardElementBuilder : LexerRuleElementBuilder
	{
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleWildcardElementBuilder"/> object to an immutable <see cref="LexerRuleWildcardElement"/> object.
		/// </summary>
		new LexerRuleWildcardElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleWildcardElementBuilder"/> object to an immutable <see cref="LexerRuleWildcardElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleWildcardElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleBlockElement : LexerRuleElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleBlockElement"/> object to a builder <see cref="LexerRuleBlockElementBuilder"/> object.
		/// </summary>
		new LexerRuleBlockElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleBlockElement"/> object to a builder <see cref="LexerRuleBlockElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleBlockElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleBlockElementBuilder : LexerRuleElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeBuilder> Alternatives { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleBlockElementBuilder"/> object to an immutable <see cref="LexerRuleBlockElement"/> object.
		/// </summary>
		new LexerRuleBlockElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleBlockElementBuilder"/> object to an immutable <see cref="LexerRuleBlockElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleBlockElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface LexerRuleRangeElement : LexerRuleElement
	{
		LexerRuleFixedCharElement Start { get; }
		LexerRuleFixedCharElement End { get; }
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleRangeElement"/> object to a builder <see cref="LexerRuleRangeElementBuilder"/> object.
		/// </summary>
		new LexerRuleRangeElementBuilder ToMutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleRangeElement"/> object to a builder <see cref="LexerRuleRangeElementBuilder"/> object
		/// by taking the builder version from the given model.
		/// </summary>
		/// <param name="model">The mutable model from which the return value is taken from.</param>
		new LexerRuleRangeElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LexerRuleRangeElementBuilder : LexerRuleElementBuilder
	{
		LexerRuleFixedCharElementBuilder Start { get; set; }
		void SetStartLazy(global::System.Func<LexerRuleFixedCharElementBuilder> lazy);
		void SetStartLazy(global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> lazy);
		void SetStartLazy(global::System.Func<LexerRuleRangeElement, LexerRuleFixedCharElement> immutableLazy, global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> mutableLazy);
		LexerRuleFixedCharElementBuilder End { get; set; }
		void SetEndLazy(global::System.Func<LexerRuleFixedCharElementBuilder> lazy);
		void SetEndLazy(global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> lazy);
		void SetEndLazy(global::System.Func<LexerRuleRangeElement, LexerRuleFixedCharElement> immutableLazy, global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> mutableLazy);
	
	
		/// <summary>
		/// Convert the <see cref="LexerRuleRangeElementBuilder"/> object to an immutable <see cref="LexerRuleRangeElement"/> object.
		/// </summary>
		new LexerRuleRangeElement ToImmutable();
		/// <summary>
		/// Convert the <see cref="LexerRuleRangeElementBuilder"/> object to an immutable <see cref="LexerRuleRangeElement"/> object
		/// by taking the immutable version from the given model.
		/// </summary>
		/// <param name="model">The immutable model from which the return value is taken from.</param>
		new LexerRuleRangeElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class CompilerDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static CompilerDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			AnnotatedElement.Initialize();
			Annotation.Initialize();
			AnnotationProperty.Initialize();
			Namespace.Initialize();
			NamedElement.Initialize();
			Grammar.Initialize();
			GrammarOptions.Initialize();
			Rule.Initialize();
			ParserRule.Initialize();
			ParserRuleAlt.Initialize();
			ParserRuleSimple.Initialize();
			ParserRuleNamedElement.Initialize();
			ParserRuleElement.Initialize();
			ParserRuleReferenceElement.Initialize();
			ParserRuleEofElement.Initialize();
			ParserRuleFixedElement.Initialize();
			ParserRuleWildcardElement.Initialize();
			ParserRuleBlockElement.Initialize();
			LexerRule.Initialize();
			LexerRuleAlternative.Initialize();
			LexerRuleAlternativeElement.Initialize();
			LexerRuleElement.Initialize();
			LexerRuleReferenceElement.Initialize();
			LexerRuleFixedStringElement.Initialize();
			LexerRuleFixedCharElement.Initialize();
			LexerRuleWildcardElement.Initialize();
			LexerRuleBlockElement.Initialize();
			LexerRuleRangeElement.Initialize();
			properties.Add(CompilerDescriptor.AnnotatedElement.AnnotationsProperty);
			properties.Add(CompilerDescriptor.Annotation.PropertiesProperty);
			properties.Add(CompilerDescriptor.AnnotationProperty.ValueProperty);
			properties.Add(CompilerDescriptor.Namespace.MembersProperty);
			properties.Add(CompilerDescriptor.NamedElement.NameProperty);
			properties.Add(CompilerDescriptor.Grammar.OptionsProperty);
			properties.Add(CompilerDescriptor.Grammar.RulesProperty);
			properties.Add(CompilerDescriptor.GrammarOptions.IsCaseInsensitiveProperty);
			properties.Add(CompilerDescriptor.GrammarOptions.IsWhitespaceIndentedProperty);
			properties.Add(CompilerDescriptor.ParserRule.DefinedModelObjectProperty);
			properties.Add(CompilerDescriptor.ParserRuleAlt.AlternativesProperty);
			properties.Add(CompilerDescriptor.ParserRuleSimple.ElementsProperty);
			properties.Add(CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty);
			properties.Add(CompilerDescriptor.ParserRuleNamedElement.ElementProperty);
			properties.Add(CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty);
			properties.Add(CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty);
			properties.Add(CompilerDescriptor.ParserRuleReferenceElement.RuleProperty);
			properties.Add(CompilerDescriptor.ParserRuleFixedElement.ValueProperty);
			properties.Add(CompilerDescriptor.LexerRule.IsFragmentProperty);
			properties.Add(CompilerDescriptor.LexerRule.IsHiddenProperty);
			properties.Add(CompilerDescriptor.LexerRule.ValueTypeProperty);
			properties.Add(CompilerDescriptor.LexerRule.ValueProperty);
			properties.Add(CompilerDescriptor.LexerRule.AlternativesProperty);
			properties.Add(CompilerDescriptor.LexerRuleAlternative.ElementsProperty);
			properties.Add(CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty);
			properties.Add(CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty);
			properties.Add(CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty);
			properties.Add(CompilerDescriptor.LexerRuleReferenceElement.RuleProperty);
			properties.Add(CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty);
			properties.Add(CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty);
			properties.Add(CompilerDescriptor.LexerRuleBlockElement.AlternativesProperty);
			properties.Add(CompilerDescriptor.LexerRuleRangeElement.StartProperty);
			properties.Add(CompilerDescriptor.LexerRuleRangeElement.EndProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string MUri = "http://MetaDslx.Languages.Compiler/1.0";
		public const string MPrefix = "";
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.AnnotatedElementId), typeof(global::MetaDslx.Languages.Compiler.Model.AnnotatedElement), typeof(global::MetaDslx.Languages.Compiler.Model.AnnotatedElementBuilder))]
		public static class AnnotatedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static AnnotatedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(AnnotatedElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.AnnotatedElement; }
			}
			
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AnnotationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(AnnotatedElement), name: "Annotations",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Annotation),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AnnotationBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.AnnotatedElement_Annotations,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.AnnotationId), typeof(global::MetaDslx.Languages.Compiler.Model.Annotation), typeof(global::MetaDslx.Languages.Compiler.Model.AnnotationBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class Annotation
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static Annotation()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(Annotation));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Annotation; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(Annotation), name: "Properties",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AnnotationProperty),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AnnotationPropertyBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.Annotation_Properties,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.AnnotationPropertyId), typeof(global::MetaDslx.Languages.Compiler.Model.AnnotationProperty), typeof(global::MetaDslx.Languages.Compiler.Model.AnnotationPropertyBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class AnnotationProperty
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static AnnotationProperty()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(AnnotationProperty));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.AnnotationProperty; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(AnnotationProperty), name: "Value",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.AnnotationProperty_Value,
					defaultValue: null);
		}
	
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
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.NamedElementId), typeof(global::MetaDslx.Languages.Compiler.Model.NamedElement), typeof(global::MetaDslx.Languages.Compiler.Model.NamedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.AnnotatedElement) })]
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DefinedModelObjectProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRule), name: "DefinedModelObject",
			        immutableType: typeof(System.Type),
			        mutableType: typeof(System.Type),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRule_DefinedModelObject,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleAltId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAlt), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleAltBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRule) })]
		public static class ParserRuleAlt
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleAlt()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleAlt));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleAlt; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleAlt), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleAlt_Alternatives,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleSimpleId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleSimple), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleSimpleBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRule) })]
		public static class ParserRuleSimple
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleSimple()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleSimple));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleSimple; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleSimple), name: "Elements",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleNamedElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleNamedElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleSimple_Elements,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleNamedElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleNamedElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleNamedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.NamedElement) })]
		public static class ParserRuleNamedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleNamedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleNamedElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleNamedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsNegatedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleNamedElement), name: "IsNegated",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleNamedElement_IsNegated,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleNamedElement), name: "Element",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleNamedElement_Element,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AssignmentOperatorProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleNamedElement), name: "AssignmentOperator",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AssignmentOperator),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.AssignmentOperator),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleNamedElement_AssignmentOperator,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty MultiplicityProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleNamedElement), name: "Multiplicity",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleNamedElement_Multiplicity,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.AnnotatedElement) })]
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
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleReferenceElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleReferenceElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleReferenceElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRuleElement) })]
		public static class ParserRuleReferenceElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleReferenceElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleReferenceElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleReferenceElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty RuleProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleReferenceElement), name: "Rule",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Rule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.RuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleReferenceElement_Rule,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleEofElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleEofElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleEofElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRuleElement) })]
		public static class ParserRuleEofElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleEofElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleEofElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleEofElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleFixedElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleFixedElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleFixedElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRuleElement) })]
		public static class ParserRuleFixedElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleFixedElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleFixedElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleFixedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(ParserRuleFixedElement), name: "Value",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleFixedElement_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleWildcardElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleWildcardElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleWildcardElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRuleElement) })]
		public static class ParserRuleWildcardElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleWildcardElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleWildcardElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleWildcardElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.ParserRuleBlockElementId), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleBlockElement), typeof(global::MetaDslx.Languages.Compiler.Model.ParserRuleBlockElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.ParserRuleElement), typeof(CompilerDescriptor.ParserRuleSimple) })]
		public static class ParserRuleBlockElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static ParserRuleBlockElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(ParserRuleBlockElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.ParserRuleBlockElement; }
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
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRule), name: "ValueType",
			        immutableType: typeof(System.Type),
			        mutableType: typeof(System.Type),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule_ValueType,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRule), name: "Value",
			        immutableType: typeof(object),
			        mutableType: typeof(object),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule_Value,
					defaultValue: null);
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRule), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternative),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRule_Alternatives,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol))]
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
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleAlternative), name: "Elements",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternative_Elements,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleAlternativeElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeElementBuilder))]
		public static class LexerRuleAlternativeElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleAlternativeElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleAlternativeElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternativeElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsNegatedProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleAlternativeElement), name: "IsNegated",
			        immutableType: typeof(bool),
			        mutableType: typeof(bool),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternativeElement_IsNegated,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ElementProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleAlternativeElement), name: "Element",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternativeElement_Element,
					defaultValue: null);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty MultiplicityProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleAlternativeElement), name: "Multiplicity",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.Multiplicity),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleAlternativeElement_Multiplicity,
					defaultValue: null);
		}
	
		[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolAttribute(typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol))]
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleElementBuilder))]
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
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleReferenceElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleReferenceElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleReferenceElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.LexerRuleElement) })]
		public static class LexerRuleReferenceElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleReferenceElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleReferenceElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleReferenceElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty RuleProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleReferenceElement), name: "Rule",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRule),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleReferenceElement_Rule,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleFixedStringElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedStringElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedStringElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.LexerRuleElement) })]
		public static class LexerRuleFixedStringElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleFixedStringElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleFixedStringElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleFixedStringElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleFixedStringElement), name: "Value",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleFixedStringElement_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleFixedCharElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedCharElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedCharElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.LexerRuleElement) })]
		public static class LexerRuleFixedCharElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleFixedCharElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleFixedCharElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleFixedCharElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleFixedCharElement), name: "Value",
			        immutableType: typeof(string),
			        mutableType: typeof(string),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleFixedCharElement_Value,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleWildcardElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleWildcardElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleWildcardElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.LexerRuleElement) })]
		public static class LexerRuleWildcardElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleWildcardElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleWildcardElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleWildcardElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleBlockElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleBlockElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleBlockElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.LexerRuleElement) })]
		public static class LexerRuleBlockElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleBlockElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleBlockElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleBlockElement; }
			}
			
			[global::MetaDslx.CodeAnalysis.Symbols.ModelObjectSymbolPropertyAttribute("Members")]
			[global::MetaDslx.Modeling.CollectionAttribute]
			[global::MetaDslx.Modeling.OrderedAttribute]
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AlternativesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleBlockElement), name: "Alternatives",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternative),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleAlternativeBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleBlockElement_Alternatives,
					defaultValue: null);
		}
	
		[global::MetaDslx.Modeling.ModelObjectDescriptorAttribute(typeof(global::MetaDslx.Languages.Compiler.Model.Internal.LexerRuleRangeElementId), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleRangeElement), typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleRangeElementBuilder), BaseDescriptors = new global::System.Type[] { typeof(CompilerDescriptor.LexerRuleElement) })]
		public static class LexerRuleRangeElement
		{
			private static global::MetaDslx.Modeling.ModelObjectDescriptor descriptor;
		
			static LexerRuleRangeElement()
			{
				descriptor = global::MetaDslx.Modeling.ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof(LexerRuleRangeElement));
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
				get { return global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleRangeElement; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty StartProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleRangeElement), name: "Start",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedCharElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedCharElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleRangeElement_Start,
					defaultValue: null);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EndProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(declaringType: typeof(LexerRuleRangeElement), name: "End",
			        immutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedCharElement),
			        mutableType: typeof(global::MetaDslx.Languages.Compiler.Model.LexerRuleFixedCharElementBuilder),
					metaProperty: () => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.LexerRuleRangeElement_End,
					defaultValue: null);
		}
	}
}

namespace MetaDslx.Languages.Compiler.Model.Internal
{
	
	internal class AnnotatedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AnnotatedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AnnotatedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotatedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, AnnotatedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
	
		internal AnnotatedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.AnnotatedElement;
	
		public new AnnotatedElementBuilder ToMutable()
		{
			return (AnnotatedElementBuilder)base.ToMutable();
		}
	
		public new AnnotatedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AnnotatedElementBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class AnnotatedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, AnnotatedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal AnnotatedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.AnnotatedElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.AnnotatedElement;
	
		public new AnnotatedElement ToImmutable()
		{
			return (AnnotatedElement)base.ToImmutable();
		}
	
		public new AnnotatedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (AnnotatedElement)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class AnnotationId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Annotation.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AnnotationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AnnotationBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotationImpl : global::MetaDslx.Modeling.ImmutableObjectBase, Annotation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<AnnotationProperty> properties0;
	
		internal AnnotationImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Annotation;
	
		public new AnnotationBuilder ToMutable()
		{
			return (AnnotationBuilder)base.ToMutable();
		}
	
		public new AnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AnnotationBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<AnnotationProperty> Properties
		{
		    get { return this.GetList<AnnotationProperty>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Annotation.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class AnnotationBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, AnnotationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<AnnotationPropertyBuilder> properties0;
	
		internal AnnotationBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.Annotation(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.Annotation;
	
		public new Annotation ToImmutable()
		{
			return (Annotation)base.ToImmutable();
		}
	
		public new Annotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Annotation)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationPropertyBuilder> Properties
		{
			get { return this.GetList<AnnotationPropertyBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.Annotation.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class AnnotationPropertyId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotationProperty.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AnnotationPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AnnotationPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotationPropertyImpl : global::MetaDslx.Modeling.ImmutableObjectBase, AnnotationProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string value0;
	
		internal AnnotationPropertyImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.AnnotationProperty;
	
		public new AnnotationPropertyBuilder ToMutable()
		{
			return (AnnotationPropertyBuilder)base.ToMutable();
		}
	
		public new AnnotationPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AnnotationPropertyBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public string Value
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotationProperty.ValueProperty, ref value0); }
		}
	}
	
	internal class AnnotationPropertyBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, AnnotationPropertyBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal AnnotationPropertyBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.AnnotationProperty(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.AnnotationProperty;
	
		public new AnnotationProperty ToImmutable()
		{
			return (AnnotationProperty)base.ToImmutable();
		}
	
		public new AnnotationProperty ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (AnnotationProperty)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotationProperty.ValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotationProperty.ValueProperty, value); }
		}
		
		void AnnotationPropertyBuilder.SetValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.AnnotationProperty.ValueProperty, lazy);
		}
		
		void AnnotationPropertyBuilder.SetValueLazy(global::System.Func<AnnotationPropertyBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.AnnotationProperty.ValueProperty, lazy);
		}
		
		void AnnotationPropertyBuilder.SetValueLazy(global::System.Func<AnnotationProperty, string> immutableLazy, global::System.Func<AnnotationPropertyBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.AnnotationProperty.ValueProperty, immutableLazy, mutableLazy);
		}
	}
	
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class NamedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, NamedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class RuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, RuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
	
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
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
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	}
	
	internal class ParserRuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, value); }
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRule, System.Type> immutableLazy, global::System.Func<ParserRuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class ParserRuleAltId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleAlt.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleAltImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleAltBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleAltImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleAlt
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ParserRule> alternatives0;
	
		internal ParserRuleAltImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleAlt;
	
		public new ParserRuleAltBuilder ToMutable()
		{
			return (ParserRuleAltBuilder)base.ToMutable();
		}
	
		public new ParserRuleAltBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleAltBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
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
	
		ParserRuleBuilder ParserRule.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleBuilder ParserRule.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ParserRule> Alternatives
		{
		    get { return this.GetList<ParserRule>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleAlt.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class ParserRuleAltBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleAltBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<ParserRuleBuilder> alternatives0;
	
		internal ParserRuleAltBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleAlt(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleAlt;
	
		public new ParserRuleAlt ToImmutable()
		{
			return (ParserRuleAlt)base.ToImmutable();
		}
	
		public new ParserRuleAlt ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleAlt)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		ParserRule ParserRuleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRule ParserRuleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, value); }
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRule, System.Type> immutableLazy, global::System.Func<ParserRuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ParserRuleBuilder> Alternatives
		{
			get { return this.GetList<ParserRuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleAlt.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class ParserRuleSimpleId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleSimple.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleSimpleImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleSimpleBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleSimpleImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleSimple
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ParserRuleNamedElement> elements0;
	
		internal ParserRuleSimpleImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleSimple;
	
		public new ParserRuleSimpleBuilder ToMutable()
		{
			return (ParserRuleSimpleBuilder)base.ToMutable();
		}
	
		public new ParserRuleSimpleBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleSimpleBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
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
	
		ParserRuleBuilder ParserRule.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleBuilder ParserRule.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ParserRuleNamedElement> Elements
		{
		    get { return this.GetList<ParserRuleNamedElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleSimple.ElementsProperty, ref elements0); }
		}
	}
	
	internal class ParserRuleSimpleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleSimpleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<ParserRuleNamedElementBuilder> elements0;
	
		internal ParserRuleSimpleBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleSimple(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleSimple;
	
		public new ParserRuleSimple ToImmutable()
		{
			return (ParserRuleSimple)base.ToImmutable();
		}
	
		public new ParserRuleSimple ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleSimple)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		ParserRule ParserRuleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRule ParserRuleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, value); }
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRule, System.Type> immutableLazy, global::System.Func<ParserRuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ParserRuleNamedElementBuilder> Elements
		{
			get { return this.GetList<ParserRuleNamedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleSimple.ElementsProperty, ref elements0); }
		}
	}
	
	internal class ParserRuleNamedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleNamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleNamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleNamedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleNamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isNegated0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ParserRuleElement element0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AssignmentOperator assignmentOperator0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
	
		internal ParserRuleNamedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleNamedElement;
	
		public new ParserRuleNamedElementBuilder ToMutable()
		{
			return (ParserRuleNamedElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleNamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleNamedElementBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public bool IsNegated
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty, ref isNegated0); }
		}
	
		
		public ParserRuleElement Element
		{
		    get { return this.GetReference<ParserRuleElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.ElementProperty, ref element0); }
		}
	
		
		public AssignmentOperator AssignmentOperator
		{
		    get { return this.GetValue<AssignmentOperator>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty, ref assignmentOperator0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty, ref multiplicity0); }
		}
	}
	
	internal class ParserRuleNamedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleNamedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal ParserRuleNamedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleNamedElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleNamedElement;
	
		public new ParserRuleNamedElement ToImmutable()
		{
			return (ParserRuleNamedElement)base.ToImmutable();
		}
	
		public new ParserRuleNamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleNamedElement)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty, value); }
		}
		
		void ParserRuleNamedElementBuilder.SetIsNegatedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetIsNegatedLazy(global::System.Func<ParserRuleNamedElementBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetIsNegatedLazy(global::System.Func<ParserRuleNamedElement, bool> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.IsNegatedProperty, immutableLazy, mutableLazy);
		}
	
		
		public ParserRuleElementBuilder Element
		{
			get { return this.GetReference<ParserRuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.ElementProperty); }
			set { this.SetReference<ParserRuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.ElementProperty, value); }
		}
		
		void ParserRuleNamedElementBuilder.SetElementLazy(global::System.Func<ParserRuleElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleNamedElement.ElementProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetElementLazy(global::System.Func<ParserRuleNamedElementBuilder, ParserRuleElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleNamedElement.ElementProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetElementLazy(global::System.Func<ParserRuleNamedElement, ParserRuleElement> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, ParserRuleElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleNamedElement.ElementProperty, immutableLazy, mutableLazy);
		}
	
		
		public AssignmentOperator AssignmentOperator
		{
			get { return this.GetValue<AssignmentOperator>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty); }
			set { this.SetValue<AssignmentOperator>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty, value); }
		}
		
		void ParserRuleNamedElementBuilder.SetAssignmentOperatorLazy(global::System.Func<AssignmentOperator> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetAssignmentOperatorLazy(global::System.Func<ParserRuleNamedElementBuilder, AssignmentOperator> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetAssignmentOperatorLazy(global::System.Func<ParserRuleNamedElement, AssignmentOperator> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, AssignmentOperator> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.AssignmentOperatorProperty, immutableLazy, mutableLazy);
		}
	
		
		public Multiplicity Multiplicity
		{
			get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty); }
			set { this.SetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty, value); }
		}
		
		void ParserRuleNamedElementBuilder.SetMultiplicityLazy(global::System.Func<Multiplicity> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetMultiplicityLazy(global::System.Func<ParserRuleNamedElementBuilder, Multiplicity> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty, lazy);
		}
		
		void ParserRuleNamedElementBuilder.SetMultiplicityLazy(global::System.Func<ParserRuleNamedElement, Multiplicity> immutableLazy, global::System.Func<ParserRuleNamedElementBuilder, Multiplicity> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.ParserRuleNamedElement.MultiplicityProperty, immutableLazy, mutableLazy);
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
	
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class ParserRuleElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class ParserRuleReferenceElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReferenceElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleReferenceElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleReferenceElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleReferenceElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleReferenceElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Rule rule0;
	
		internal ParserRuleReferenceElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleReferenceElement;
	
		public new ParserRuleReferenceElementBuilder ToMutable()
		{
			return (ParserRuleReferenceElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleReferenceElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleReferenceElementBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public Rule Rule
		{
		    get { return this.GetReference<Rule>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReferenceElement.RuleProperty, ref rule0); }
		}
	}
	
	internal class ParserRuleReferenceElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleReferenceElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal ParserRuleReferenceElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleReferenceElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleReferenceElement;
	
		public new ParserRuleReferenceElement ToImmutable()
		{
			return (ParserRuleReferenceElement)base.ToImmutable();
		}
	
		public new ParserRuleReferenceElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleReferenceElement)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public RuleBuilder Rule
		{
			get { return this.GetReference<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReferenceElement.RuleProperty); }
			set { this.SetReference<RuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleReferenceElement.RuleProperty, value); }
		}
		
		void ParserRuleReferenceElementBuilder.SetRuleLazy(global::System.Func<RuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleReferenceElement.RuleProperty, lazy);
		}
		
		void ParserRuleReferenceElementBuilder.SetRuleLazy(global::System.Func<ParserRuleReferenceElementBuilder, RuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleReferenceElement.RuleProperty, lazy);
		}
		
		void ParserRuleReferenceElementBuilder.SetRuleLazy(global::System.Func<ParserRuleReferenceElement, Rule> immutableLazy, global::System.Func<ParserRuleReferenceElementBuilder, RuleBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleReferenceElement.RuleProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class ParserRuleEofElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleEofElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleEofElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleEofElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleEofElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleEofElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
	
		internal ParserRuleEofElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleEofElement;
	
		public new ParserRuleEofElementBuilder ToMutable()
		{
			return (ParserRuleEofElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleEofElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleEofElementBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class ParserRuleEofElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleEofElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal ParserRuleEofElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleEofElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleEofElement;
	
		public new ParserRuleEofElement ToImmutable()
		{
			return (ParserRuleEofElement)base.ToImmutable();
		}
	
		public new ParserRuleEofElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleEofElement)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class ParserRuleFixedElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleFixedElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleFixedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleFixedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleFixedElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleFixedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string value0;
	
		internal ParserRuleFixedElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleFixedElement;
	
		public new ParserRuleFixedElementBuilder ToMutable()
		{
			return (ParserRuleFixedElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleFixedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleFixedElementBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Value
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleFixedElement.ValueProperty, ref value0); }
		}
	}
	
	internal class ParserRuleFixedElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleFixedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal ParserRuleFixedElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleFixedElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleFixedElement;
	
		public new ParserRuleFixedElement ToImmutable()
		{
			return (ParserRuleFixedElement)base.ToImmutable();
		}
	
		public new ParserRuleFixedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleFixedElement)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleFixedElement.ValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleFixedElement.ValueProperty, value); }
		}
		
		void ParserRuleFixedElementBuilder.SetValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleFixedElement.ValueProperty, lazy);
		}
		
		void ParserRuleFixedElementBuilder.SetValueLazy(global::System.Func<ParserRuleFixedElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleFixedElement.ValueProperty, lazy);
		}
		
		void ParserRuleFixedElementBuilder.SetValueLazy(global::System.Func<ParserRuleFixedElement, string> immutableLazy, global::System.Func<ParserRuleFixedElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRuleFixedElement.ValueProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class ParserRuleWildcardElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleWildcardElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleWildcardElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleWildcardElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleWildcardElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleWildcardElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
	
		internal ParserRuleWildcardElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleWildcardElement;
	
		public new ParserRuleWildcardElementBuilder ToMutable()
		{
			return (ParserRuleWildcardElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleWildcardElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleWildcardElementBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class ParserRuleWildcardElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleWildcardElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal ParserRuleWildcardElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleWildcardElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleWildcardElement;
	
		public new ParserRuleWildcardElement ToImmutable()
		{
			return (ParserRuleWildcardElement)base.ToImmutable();
		}
	
		public new ParserRuleWildcardElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleWildcardElement)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class ParserRuleBlockElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleBlockElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ParserRuleBlockElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ParserRuleBlockElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParserRuleBlockElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, ParserRuleBlockElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type definedModelObject0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ParserRuleNamedElement> elements0;
	
		internal ParserRuleBlockElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleBlockElement;
	
		public new ParserRuleBlockElementBuilder ToMutable()
		{
			return (ParserRuleBlockElementBuilder)base.ToMutable();
		}
	
		public new ParserRuleBlockElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ParserRuleBlockElementBuilder)base.ToMutable(model);
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
	
		ParserRuleBuilder ParserRule.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleBuilder ParserRule.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ParserRuleSimpleBuilder ParserRuleSimple.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleSimpleBuilder ParserRuleSimple.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ParserRuleElementBuilder ParserRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public System.Type DefinedModelObject
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, ref definedModelObject0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ParserRuleNamedElement> Elements
		{
		    get { return this.GetList<ParserRuleNamedElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleSimple.ElementsProperty, ref elements0); }
		}
	}
	
	internal class ParserRuleBlockElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, ParserRuleBlockElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<ParserRuleNamedElementBuilder> elements0;
	
		internal ParserRuleBlockElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.ParserRuleBlockElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.ParserRuleBlockElement;
	
		public new ParserRuleBlockElement ToImmutable()
		{
			return (ParserRuleBlockElement)base.ToImmutable();
		}
	
		public new ParserRuleBlockElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ParserRuleBlockElement)base.ToImmutable(model);
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
	
		ParserRule ParserRuleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRule ParserRuleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ParserRuleSimple ParserRuleSimpleBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRuleSimple ParserRuleSimpleBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ParserRuleElement ParserRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
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
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRule.DefinedModelObjectProperty, value); }
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, lazy);
		}
		
		void ParserRuleBuilder.SetDefinedModelObjectLazy(global::System.Func<ParserRule, System.Type> immutableLazy, global::System.Func<ParserRuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.ParserRule.DefinedModelObjectProperty, immutableLazy, mutableLazy);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ParserRuleNamedElementBuilder> Elements
		{
			get { return this.GetList<ParserRuleNamedElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.ParserRuleSimple.ElementsProperty, ref elements0); }
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
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isFragment0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isHidden0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private System.Type valueType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object value0;
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
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
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
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public System.Type ValueType
		{
		    get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.ValueTypeProperty, ref valueType0); }
		}
	
		
		public object Value
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.ValueProperty, ref value0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> Alternatives
		{
		    get { return this.GetList<LexerRuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class LexerRuleBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
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
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
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
	
		
		public System.Type ValueType
		{
			get { return this.GetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.ValueTypeProperty); }
			set { this.SetReference<System.Type>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.ValueTypeProperty, value); }
		}
		
		void LexerRuleBuilder.SetValueTypeLazy(global::System.Func<System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRule.ValueTypeProperty, lazy);
		}
		
		void LexerRuleBuilder.SetValueTypeLazy(global::System.Func<LexerRuleBuilder, System.Type> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRule.ValueTypeProperty, lazy);
		}
		
		void LexerRuleBuilder.SetValueTypeLazy(global::System.Func<LexerRule, System.Type> immutableLazy, global::System.Func<LexerRuleBuilder, System.Type> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRule.ValueTypeProperty, immutableLazy, mutableLazy);
		}
	
		
		public object Value
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.ValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRule.ValueProperty, value); }
		}
		
		void LexerRuleBuilder.SetValueLazy(global::System.Func<object> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRule.ValueProperty, lazy);
		}
		
		void LexerRuleBuilder.SetValueLazy(global::System.Func<LexerRuleBuilder, object> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRule.ValueProperty, lazy);
		}
		
		void LexerRuleBuilder.SetValueLazy(global::System.Func<LexerRule, object> immutableLazy, global::System.Func<LexerRuleBuilder, object> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRule.ValueProperty, immutableLazy, mutableLazy);
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
		private global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternativeElement> elements0;
	
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
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternativeElement> Elements
		{
		    get { return this.GetList<LexerRuleAlternativeElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class LexerRuleAlternativeBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleAlternativeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeElementBuilder> elements0;
	
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
	
		
		public global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeElementBuilder> Elements
		{
			get { return this.GetList<LexerRuleAlternativeElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternative.ElementsProperty, ref elements0); }
		}
	}
	
	internal class LexerRuleAlternativeElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleAlternativeElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleAlternativeElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleAlternativeElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleAlternativeElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isNegated0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LexerRuleElement element0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Multiplicity multiplicity0;
	
		internal LexerRuleAlternativeElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleAlternativeElement;
	
		public new LexerRuleAlternativeElementBuilder ToMutable()
		{
			return (LexerRuleAlternativeElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleAlternativeElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleAlternativeElementBuilder)base.ToMutable(model);
		}
	
		
		public bool IsNegated
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty, ref isNegated0); }
		}
	
		
		public LexerRuleElement Element
		{
		    get { return this.GetReference<LexerRuleElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty, ref element0); }
		}
	
		
		public Multiplicity Multiplicity
		{
		    get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty, ref multiplicity0); }
		}
	}
	
	internal class LexerRuleAlternativeElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleAlternativeElementBuilder
	{
	
		internal LexerRuleAlternativeElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleAlternativeElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleAlternativeElement;
	
		public new LexerRuleAlternativeElement ToImmutable()
		{
			return (LexerRuleAlternativeElement)base.ToImmutable();
		}
	
		public new LexerRuleAlternativeElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleAlternativeElement)base.ToImmutable(model);
		}
	
		
		public bool IsNegated
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty, value); }
		}
		
		void LexerRuleAlternativeElementBuilder.SetIsNegatedLazy(global::System.Func<bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty, lazy);
		}
		
		void LexerRuleAlternativeElementBuilder.SetIsNegatedLazy(global::System.Func<LexerRuleAlternativeElementBuilder, bool> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty, lazy);
		}
		
		void LexerRuleAlternativeElementBuilder.SetIsNegatedLazy(global::System.Func<LexerRuleAlternativeElement, bool> immutableLazy, global::System.Func<LexerRuleAlternativeElementBuilder, bool> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRuleAlternativeElement.IsNegatedProperty, immutableLazy, mutableLazy);
		}
	
		
		public LexerRuleElementBuilder Element
		{
			get { return this.GetReference<LexerRuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty); }
			set { this.SetReference<LexerRuleElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty, value); }
		}
		
		void LexerRuleAlternativeElementBuilder.SetElementLazy(global::System.Func<LexerRuleElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty, lazy);
		}
		
		void LexerRuleAlternativeElementBuilder.SetElementLazy(global::System.Func<LexerRuleAlternativeElementBuilder, LexerRuleElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty, lazy);
		}
		
		void LexerRuleAlternativeElementBuilder.SetElementLazy(global::System.Func<LexerRuleAlternativeElement, LexerRuleElement> immutableLazy, global::System.Func<LexerRuleAlternativeElementBuilder, LexerRuleElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleAlternativeElement.ElementProperty, immutableLazy, mutableLazy);
		}
	
		
		public Multiplicity Multiplicity
		{
			get { return this.GetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty); }
			set { this.SetValue<Multiplicity>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty, value); }
		}
		
		void LexerRuleAlternativeElementBuilder.SetMultiplicityLazy(global::System.Func<Multiplicity> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty, lazy);
		}
		
		void LexerRuleAlternativeElementBuilder.SetMultiplicityLazy(global::System.Func<LexerRuleAlternativeElementBuilder, Multiplicity> lazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty, lazy);
		}
		
		void LexerRuleAlternativeElementBuilder.SetMultiplicityLazy(global::System.Func<LexerRuleAlternativeElement, Multiplicity> immutableLazy, global::System.Func<LexerRuleAlternativeElementBuilder, Multiplicity> mutableLazy)
		{
			this.SetLazyValue(CompilerDescriptor.LexerRuleAlternativeElement.MultiplicityProperty, immutableLazy, mutableLazy);
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
	}
	
	internal class LexerRuleReferenceElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleReferenceElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleReferenceElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleReferenceElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleReferenceElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleReferenceElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LexerRule rule0;
	
		internal LexerRuleReferenceElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleReferenceElement;
	
		public new LexerRuleReferenceElementBuilder ToMutable()
		{
			return (LexerRuleReferenceElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleReferenceElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleReferenceElementBuilder)base.ToMutable(model);
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public LexerRule Rule
		{
		    get { return this.GetReference<LexerRule>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleReferenceElement.RuleProperty, ref rule0); }
		}
	}
	
	internal class LexerRuleReferenceElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleReferenceElementBuilder
	{
	
		internal LexerRuleReferenceElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleReferenceElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleReferenceElement;
	
		public new LexerRuleReferenceElement ToImmutable()
		{
			return (LexerRuleReferenceElement)base.ToImmutable();
		}
	
		public new LexerRuleReferenceElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleReferenceElement)base.ToImmutable(model);
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public LexerRuleBuilder Rule
		{
			get { return this.GetReference<LexerRuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleReferenceElement.RuleProperty); }
			set { this.SetReference<LexerRuleBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleReferenceElement.RuleProperty, value); }
		}
		
		void LexerRuleReferenceElementBuilder.SetRuleLazy(global::System.Func<LexerRuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleReferenceElement.RuleProperty, lazy);
		}
		
		void LexerRuleReferenceElementBuilder.SetRuleLazy(global::System.Func<LexerRuleReferenceElementBuilder, LexerRuleBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleReferenceElement.RuleProperty, lazy);
		}
		
		void LexerRuleReferenceElementBuilder.SetRuleLazy(global::System.Func<LexerRuleReferenceElement, LexerRule> immutableLazy, global::System.Func<LexerRuleReferenceElementBuilder, LexerRuleBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleReferenceElement.RuleProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class LexerRuleFixedStringElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedStringElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleFixedStringElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleFixedStringElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleFixedStringElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleFixedStringElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string value0;
	
		internal LexerRuleFixedStringElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleFixedStringElement;
	
		public new LexerRuleFixedStringElementBuilder ToMutable()
		{
			return (LexerRuleFixedStringElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleFixedStringElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleFixedStringElementBuilder)base.ToMutable(model);
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Value
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty, ref value0); }
		}
	}
	
	internal class LexerRuleFixedStringElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleFixedStringElementBuilder
	{
	
		internal LexerRuleFixedStringElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleFixedStringElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleFixedStringElement;
	
		public new LexerRuleFixedStringElement ToImmutable()
		{
			return (LexerRuleFixedStringElement)base.ToImmutable();
		}
	
		public new LexerRuleFixedStringElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleFixedStringElement)base.ToImmutable(model);
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty, value); }
		}
		
		void LexerRuleFixedStringElementBuilder.SetValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty, lazy);
		}
		
		void LexerRuleFixedStringElementBuilder.SetValueLazy(global::System.Func<LexerRuleFixedStringElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty, lazy);
		}
		
		void LexerRuleFixedStringElementBuilder.SetValueLazy(global::System.Func<LexerRuleFixedStringElement, string> immutableLazy, global::System.Func<LexerRuleFixedStringElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleFixedStringElement.ValueProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class LexerRuleFixedCharElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedCharElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleFixedCharElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleFixedCharElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleFixedCharElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleFixedCharElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string value0;
	
		internal LexerRuleFixedCharElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleFixedCharElement;
	
		public new LexerRuleFixedCharElementBuilder ToMutable()
		{
			return (LexerRuleFixedCharElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleFixedCharElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleFixedCharElementBuilder)base.ToMutable(model);
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Value
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty, ref value0); }
		}
	}
	
	internal class LexerRuleFixedCharElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleFixedCharElementBuilder
	{
	
		internal LexerRuleFixedCharElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleFixedCharElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleFixedCharElement;
	
		public new LexerRuleFixedCharElement ToImmutable()
		{
			return (LexerRuleFixedCharElement)base.ToImmutable();
		}
	
		public new LexerRuleFixedCharElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleFixedCharElement)base.ToImmutable(model);
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Value
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty, value); }
		}
		
		void LexerRuleFixedCharElementBuilder.SetValueLazy(global::System.Func<string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty, lazy);
		}
		
		void LexerRuleFixedCharElementBuilder.SetValueLazy(global::System.Func<LexerRuleFixedCharElementBuilder, string> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty, lazy);
		}
		
		void LexerRuleFixedCharElementBuilder.SetValueLazy(global::System.Func<LexerRuleFixedCharElement, string> immutableLazy, global::System.Func<LexerRuleFixedCharElementBuilder, string> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleFixedCharElement.ValueProperty, immutableLazy, mutableLazy);
		}
	}
	
	internal class LexerRuleWildcardElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleWildcardElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleWildcardElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleWildcardElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleWildcardElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleWildcardElement
	{
	
		internal LexerRuleWildcardElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleWildcardElement;
	
		public new LexerRuleWildcardElementBuilder ToMutable()
		{
			return (LexerRuleWildcardElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleWildcardElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleWildcardElementBuilder)base.ToMutable(model);
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	}
	
	internal class LexerRuleWildcardElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleWildcardElementBuilder
	{
	
		internal LexerRuleWildcardElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleWildcardElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleWildcardElement;
	
		public new LexerRuleWildcardElement ToImmutable()
		{
			return (LexerRuleWildcardElement)base.ToImmutable();
		}
	
		public new LexerRuleWildcardElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleWildcardElement)base.ToImmutable(model);
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	}
	
	internal class LexerRuleBlockElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleBlockElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleBlockElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleBlockElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleBlockElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleBlockElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> alternatives0;
	
		internal LexerRuleBlockElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleBlockElement;
	
		public new LexerRuleBlockElementBuilder ToMutable()
		{
			return (LexerRuleBlockElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleBlockElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleBlockElementBuilder)base.ToMutable(model);
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<LexerRuleAlternative> Alternatives
		{
		    get { return this.GetList<LexerRuleAlternative>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleBlockElement.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class LexerRuleBlockElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleBlockElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeBuilder> alternatives0;
	
		internal LexerRuleBlockElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleBlockElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleBlockElement;
	
		public new LexerRuleBlockElement ToImmutable()
		{
			return (LexerRuleBlockElement)base.ToImmutable();
		}
	
		public new LexerRuleBlockElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleBlockElement)base.ToImmutable(model);
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<LexerRuleAlternativeBuilder> Alternatives
		{
			get { return this.GetList<LexerRuleAlternativeBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleBlockElement.AlternativesProperty, ref alternatives0); }
		}
	}
	
	internal class LexerRuleRangeElementId : global::MetaDslx.Modeling.ObjectId
	{
		public override global::MetaDslx.Modeling.ModelObjectDescriptor Descriptor { get { return global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.MDescriptor; } }
	
		public override global::MetaDslx.Modeling.ImmutableObjectBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LexerRuleRangeElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableObjectBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LexerRuleRangeElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class LexerRuleRangeElementImpl : global::MetaDslx.Modeling.ImmutableObjectBase, LexerRuleRangeElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LexerRuleFixedCharElement start0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private LexerRuleFixedCharElement end0;
	
		internal LexerRuleRangeElementImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleRangeElement;
	
		public new LexerRuleRangeElementBuilder ToMutable()
		{
			return (LexerRuleRangeElementBuilder)base.ToMutable();
		}
	
		public new LexerRuleRangeElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LexerRuleRangeElementBuilder)base.ToMutable(model);
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		LexerRuleElementBuilder LexerRuleElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public LexerRuleFixedCharElement Start
		{
		    get { return this.GetReference<LexerRuleFixedCharElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.StartProperty, ref start0); }
		}
	
		
		public LexerRuleFixedCharElement End
		{
		    get { return this.GetReference<LexerRuleFixedCharElement>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.EndProperty, ref end0); }
		}
	}
	
	internal class LexerRuleRangeElementBuilderImpl : global::MetaDslx.Modeling.MutableObjectBase, LexerRuleRangeElementBuilder
	{
	
		internal LexerRuleRangeElementBuilderImpl(global::MetaDslx.Modeling.ObjectId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			CompilerImplementationProvider.Implementation.LexerRuleRangeElement(this);
		}
	
		public override global::MetaDslx.Modeling.ModelMetadata MMetadata => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.MMetadata;
	
		public override global::MetaDslx.Languages.Meta.Model.MetaClass MMetaClass => CompilerInstance.LexerRuleRangeElement;
	
		public new LexerRuleRangeElement ToImmutable()
		{
			return (LexerRuleRangeElement)base.ToImmutable();
		}
	
		public new LexerRuleRangeElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (LexerRuleRangeElement)base.ToImmutable(model);
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		LexerRuleElement LexerRuleElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public LexerRuleFixedCharElementBuilder Start
		{
			get { return this.GetReference<LexerRuleFixedCharElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.StartProperty); }
			set { this.SetReference<LexerRuleFixedCharElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.StartProperty, value); }
		}
		
		void LexerRuleRangeElementBuilder.SetStartLazy(global::System.Func<LexerRuleFixedCharElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleRangeElement.StartProperty, lazy);
		}
		
		void LexerRuleRangeElementBuilder.SetStartLazy(global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleRangeElement.StartProperty, lazy);
		}
		
		void LexerRuleRangeElementBuilder.SetStartLazy(global::System.Func<LexerRuleRangeElement, LexerRuleFixedCharElement> immutableLazy, global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleRangeElement.StartProperty, immutableLazy, mutableLazy);
		}
	
		
		public LexerRuleFixedCharElementBuilder End
		{
			get { return this.GetReference<LexerRuleFixedCharElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.EndProperty); }
			set { this.SetReference<LexerRuleFixedCharElementBuilder>(global::MetaDslx.Languages.Compiler.Model.CompilerDescriptor.LexerRuleRangeElement.EndProperty, value); }
		}
		
		void LexerRuleRangeElementBuilder.SetEndLazy(global::System.Func<LexerRuleFixedCharElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleRangeElement.EndProperty, lazy);
		}
		
		void LexerRuleRangeElementBuilder.SetEndLazy(global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> lazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleRangeElement.EndProperty, lazy);
		}
		
		void LexerRuleRangeElementBuilder.SetEndLazy(global::System.Func<LexerRuleRangeElement, LexerRuleFixedCharElement> immutableLazy, global::System.Func<LexerRuleRangeElementBuilder, LexerRuleFixedCharElementBuilder> mutableLazy)
		{
			this.SetLazyReference(CompilerDescriptor.LexerRuleRangeElement.EndProperty, immutableLazy, mutableLazy);
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
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder AnnotatedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder AnnotatedElement_Annotations;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder Annotation;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder Annotation_Properties;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder AnnotationProperty;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder AnnotationProperty_Value;
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
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRule;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRule_DefinedModelObject;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleAlt;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleAlt_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleSimple;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleSimple_Elements;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleNamedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleNamedElement_IsNegated;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleNamedElement_Element;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleNamedElement_AssignmentOperator;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleNamedElement_Multiplicity;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleReferenceElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleReferenceElement_Rule;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleEofElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleFixedElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder ParserRuleFixedElement_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleWildcardElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder ParserRuleBlockElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRule;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_IsFragment;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_IsHidden;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_ValueType;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRule_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleAlternative;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleAlternative_Elements;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleAlternativeElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleAlternativeElement_IsNegated;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleAlternativeElement_Element;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleAlternativeElement_Multiplicity;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleReferenceElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleReferenceElement_Rule;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleFixedStringElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleFixedStringElement_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleFixedCharElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleFixedCharElement_Value;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleWildcardElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleBlockElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleBlockElement_Alternatives;
		internal global::MetaDslx.Languages.Meta.Model.MetaClassBuilder LexerRuleRangeElement;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleRangeElement_Start;
		internal global::MetaDslx.Languages.Meta.Model.MetaPropertyBuilder LexerRuleRangeElement_End;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder Multiplicity;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp16;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp17;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp18;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp19;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp21;
		internal global::MetaDslx.Languages.Meta.Model.MetaEnumBuilder AssignmentOperator;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp22;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Model.MetaEnumLiteralBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp10;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp11;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp12;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Model.MetaCollectionTypeBuilder __tmp14;
	
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
			AnnotatedElement = factory.MetaClass();
			AnnotatedElement_Annotations = factory.MetaProperty();
			Annotation = factory.MetaClass();
			Annotation_Properties = factory.MetaProperty();
			AnnotationProperty = factory.MetaClass();
			AnnotationProperty_Value = factory.MetaProperty();
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
			ParserRule = factory.MetaClass();
			ParserRule_DefinedModelObject = factory.MetaProperty();
			ParserRuleAlt = factory.MetaClass();
			ParserRuleAlt_Alternatives = factory.MetaProperty();
			ParserRuleSimple = factory.MetaClass();
			ParserRuleSimple_Elements = factory.MetaProperty();
			ParserRuleNamedElement = factory.MetaClass();
			ParserRuleNamedElement_IsNegated = factory.MetaProperty();
			ParserRuleNamedElement_Element = factory.MetaProperty();
			ParserRuleNamedElement_AssignmentOperator = factory.MetaProperty();
			ParserRuleNamedElement_Multiplicity = factory.MetaProperty();
			ParserRuleElement = factory.MetaClass();
			ParserRuleReferenceElement = factory.MetaClass();
			ParserRuleReferenceElement_Rule = factory.MetaProperty();
			ParserRuleEofElement = factory.MetaClass();
			ParserRuleFixedElement = factory.MetaClass();
			ParserRuleFixedElement_Value = factory.MetaProperty();
			ParserRuleWildcardElement = factory.MetaClass();
			ParserRuleBlockElement = factory.MetaClass();
			LexerRule = factory.MetaClass();
			LexerRule_IsFragment = factory.MetaProperty();
			LexerRule_IsHidden = factory.MetaProperty();
			LexerRule_ValueType = factory.MetaProperty();
			LexerRule_Value = factory.MetaProperty();
			LexerRule_Alternatives = factory.MetaProperty();
			LexerRuleAlternative = factory.MetaClass();
			LexerRuleAlternative_Elements = factory.MetaProperty();
			LexerRuleAlternativeElement = factory.MetaClass();
			LexerRuleAlternativeElement_IsNegated = factory.MetaProperty();
			LexerRuleAlternativeElement_Element = factory.MetaProperty();
			LexerRuleAlternativeElement_Multiplicity = factory.MetaProperty();
			LexerRuleElement = factory.MetaClass();
			LexerRuleReferenceElement = factory.MetaClass();
			LexerRuleReferenceElement_Rule = factory.MetaProperty();
			LexerRuleFixedStringElement = factory.MetaClass();
			LexerRuleFixedStringElement_Value = factory.MetaProperty();
			LexerRuleFixedCharElement = factory.MetaClass();
			LexerRuleFixedCharElement_Value = factory.MetaProperty();
			LexerRuleWildcardElement = factory.MetaClass();
			LexerRuleBlockElement = factory.MetaClass();
			LexerRuleBlockElement_Alternatives = factory.MetaProperty();
			LexerRuleRangeElement = factory.MetaClass();
			LexerRuleRangeElement_Start = factory.MetaProperty();
			LexerRuleRangeElement_End = factory.MetaProperty();
			Multiplicity = factory.MetaEnum();
			__tmp15 = factory.MetaEnumLiteral();
			__tmp16 = factory.MetaEnumLiteral();
			__tmp17 = factory.MetaEnumLiteral();
			__tmp18 = factory.MetaEnumLiteral();
			__tmp19 = factory.MetaEnumLiteral();
			__tmp20 = factory.MetaEnumLiteral();
			__tmp21 = factory.MetaEnumLiteral();
			AssignmentOperator = factory.MetaEnum();
			__tmp22 = factory.MetaEnumLiteral();
			__tmp23 = factory.MetaEnumLiteral();
			__tmp24 = factory.MetaEnumLiteral();
			__tmp25 = factory.MetaEnumLiteral();
			__tmp6 = factory.MetaCollectionType();
			__tmp7 = factory.MetaCollectionType();
			__tmp8 = factory.MetaCollectionType();
			__tmp9 = factory.MetaCollectionType();
			__tmp10 = factory.MetaCollectionType();
			__tmp11 = factory.MetaCollectionType();
			__tmp12 = factory.MetaCollectionType();
			__tmp13 = factory.MetaCollectionType();
			__tmp14 = factory.MetaCollectionType();
	
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
			__tmp4.Declarations.AddLazy(() => AnnotatedElement);
			__tmp4.Declarations.AddLazy(() => Annotation);
			__tmp4.Declarations.AddLazy(() => AnnotationProperty);
			__tmp4.Declarations.AddLazy(() => Namespace);
			__tmp4.Declarations.AddLazy(() => NamedElement);
			__tmp4.Declarations.AddLazy(() => Grammar);
			__tmp4.Declarations.AddLazy(() => GrammarOptions);
			__tmp4.Declarations.AddLazy(() => Rule);
			__tmp4.Declarations.AddLazy(() => ParserRule);
			__tmp4.Declarations.AddLazy(() => ParserRuleAlt);
			__tmp4.Declarations.AddLazy(() => ParserRuleSimple);
			__tmp4.Declarations.AddLazy(() => ParserRuleNamedElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleReferenceElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleEofElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleFixedElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleWildcardElement);
			__tmp4.Declarations.AddLazy(() => ParserRuleBlockElement);
			__tmp4.Declarations.AddLazy(() => LexerRule);
			__tmp4.Declarations.AddLazy(() => LexerRuleAlternative);
			__tmp4.Declarations.AddLazy(() => LexerRuleAlternativeElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleReferenceElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleFixedStringElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleFixedCharElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleWildcardElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleBlockElement);
			__tmp4.Declarations.AddLazy(() => LexerRuleRangeElement);
			__tmp4.Declarations.AddLazy(() => Multiplicity);
			__tmp4.Declarations.AddLazy(() => AssignmentOperator);
			__tmp5.Documentation = null;
			__tmp5.Name = "Compiler";
			__tmp5.MajorVersion = 1;
			__tmp5.MinorVersion = 0;
			__tmp5.Uri = "http://MetaDslx.Languages.Compiler/1.0";
			__tmp5.Prefix = null;
			__tmp5.SetNamespaceLazy(() => __tmp4);
			AnnotatedElement.Documentation = null;
			AnnotatedElement.Name = "AnnotatedElement";
			AnnotatedElement.SetNamespaceLazy(() => __tmp4);
			AnnotatedElement.SymbolType = null;
			AnnotatedElement.IsAbstract = false;
			AnnotatedElement.Properties.AddLazy(() => AnnotatedElement_Annotations);
			AnnotatedElement_Annotations.SetTypeLazy(() => __tmp6);
			AnnotatedElement_Annotations.Documentation = null;
			AnnotatedElement_Annotations.Name = "Annotations";
			AnnotatedElement_Annotations.SymbolProperty = null;
			AnnotatedElement_Annotations.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			AnnotatedElement_Annotations.SetClassLazy(() => AnnotatedElement);
			AnnotatedElement_Annotations.DefaultValue = null;
			AnnotatedElement_Annotations.IsContainment = true;
			Annotation.Documentation = null;
			Annotation.Name = "Annotation";
			Annotation.SetNamespaceLazy(() => __tmp4);
			Annotation.SymbolType = null;
			Annotation.IsAbstract = false;
			Annotation.SuperClasses.AddLazy(() => NamedElement);
			Annotation.Properties.AddLazy(() => Annotation_Properties);
			Annotation_Properties.SetTypeLazy(() => __tmp7);
			Annotation_Properties.Documentation = null;
			Annotation_Properties.Name = "Properties";
			Annotation_Properties.SymbolProperty = "Members";
			Annotation_Properties.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			Annotation_Properties.SetClassLazy(() => Annotation);
			Annotation_Properties.DefaultValue = null;
			Annotation_Properties.IsContainment = true;
			AnnotationProperty.Documentation = null;
			AnnotationProperty.Name = "AnnotationProperty";
			AnnotationProperty.SetNamespaceLazy(() => __tmp4);
			AnnotationProperty.SymbolType = null;
			AnnotationProperty.IsAbstract = false;
			AnnotationProperty.SuperClasses.AddLazy(() => NamedElement);
			AnnotationProperty.Properties.AddLazy(() => AnnotationProperty_Value);
			AnnotationProperty_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			AnnotationProperty_Value.Documentation = null;
			AnnotationProperty_Value.Name = "Value";
			AnnotationProperty_Value.SymbolProperty = null;
			AnnotationProperty_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			AnnotationProperty_Value.SetClassLazy(() => AnnotationProperty);
			AnnotationProperty_Value.DefaultValue = null;
			AnnotationProperty_Value.IsContainment = false;
			Namespace.Documentation = null;
			Namespace.Name = "Namespace";
			Namespace.SetNamespaceLazy(() => __tmp4);
			Namespace.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamespaceSymbol);
			Namespace.IsAbstract = false;
			Namespace.SuperClasses.AddLazy(() => NamedElement);
			Namespace.Properties.AddLazy(() => Namespace_Members);
			Namespace_Members.SetTypeLazy(() => __tmp8);
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
			NamedElement.SuperClasses.AddLazy(() => AnnotatedElement);
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
			Grammar_Rules.SetTypeLazy(() => __tmp9);
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
			ParserRule.Documentation = null;
			ParserRule.Name = "ParserRule";
			ParserRule.SetNamespaceLazy(() => __tmp4);
			ParserRule.SymbolType = null;
			ParserRule.IsAbstract = false;
			ParserRule.SuperClasses.AddLazy(() => Rule);
			ParserRule.Properties.AddLazy(() => ParserRule_DefinedModelObject);
			ParserRule_DefinedModelObject.SetTypeLazy(() => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.SystemType.ToMutable());
			ParserRule_DefinedModelObject.Documentation = null;
			ParserRule_DefinedModelObject.Name = "DefinedModelObject";
			ParserRule_DefinedModelObject.SymbolProperty = null;
			ParserRule_DefinedModelObject.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRule_DefinedModelObject.SetClassLazy(() => ParserRule);
			ParserRule_DefinedModelObject.DefaultValue = null;
			ParserRule_DefinedModelObject.IsContainment = false;
			ParserRuleAlt.Documentation = null;
			ParserRuleAlt.Name = "ParserRuleAlt";
			ParserRuleAlt.SetNamespaceLazy(() => __tmp4);
			ParserRuleAlt.SymbolType = null;
			ParserRuleAlt.IsAbstract = false;
			ParserRuleAlt.SuperClasses.AddLazy(() => ParserRule);
			ParserRuleAlt.Properties.AddLazy(() => ParserRuleAlt_Alternatives);
			ParserRuleAlt_Alternatives.SetTypeLazy(() => __tmp10);
			ParserRuleAlt_Alternatives.Documentation = null;
			ParserRuleAlt_Alternatives.Name = "Alternatives";
			ParserRuleAlt_Alternatives.SymbolProperty = "Members";
			ParserRuleAlt_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleAlt_Alternatives.SetClassLazy(() => ParserRuleAlt);
			ParserRuleAlt_Alternatives.DefaultValue = null;
			ParserRuleAlt_Alternatives.IsContainment = true;
			ParserRuleSimple.Documentation = null;
			ParserRuleSimple.Name = "ParserRuleSimple";
			ParserRuleSimple.SetNamespaceLazy(() => __tmp4);
			ParserRuleSimple.SymbolType = null;
			ParserRuleSimple.IsAbstract = false;
			ParserRuleSimple.SuperClasses.AddLazy(() => ParserRule);
			ParserRuleSimple.Properties.AddLazy(() => ParserRuleSimple_Elements);
			ParserRuleSimple_Elements.SetTypeLazy(() => __tmp11);
			ParserRuleSimple_Elements.Documentation = null;
			ParserRuleSimple_Elements.Name = "Elements";
			ParserRuleSimple_Elements.SymbolProperty = "Members";
			ParserRuleSimple_Elements.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleSimple_Elements.SetClassLazy(() => ParserRuleSimple);
			ParserRuleSimple_Elements.DefaultValue = null;
			ParserRuleSimple_Elements.IsContainment = true;
			ParserRuleNamedElement.Documentation = null;
			ParserRuleNamedElement.Name = "ParserRuleNamedElement";
			ParserRuleNamedElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleNamedElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol);
			ParserRuleNamedElement.IsAbstract = false;
			ParserRuleNamedElement.SuperClasses.AddLazy(() => NamedElement);
			ParserRuleNamedElement.Properties.AddLazy(() => ParserRuleNamedElement_IsNegated);
			ParserRuleNamedElement.Properties.AddLazy(() => ParserRuleNamedElement_Element);
			ParserRuleNamedElement.Properties.AddLazy(() => ParserRuleNamedElement_AssignmentOperator);
			ParserRuleNamedElement.Properties.AddLazy(() => ParserRuleNamedElement_Multiplicity);
			ParserRuleNamedElement_IsNegated.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			ParserRuleNamedElement_IsNegated.Documentation = null;
			ParserRuleNamedElement_IsNegated.Name = "IsNegated";
			ParserRuleNamedElement_IsNegated.SymbolProperty = null;
			ParserRuleNamedElement_IsNegated.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleNamedElement_IsNegated.SetClassLazy(() => ParserRuleNamedElement);
			ParserRuleNamedElement_IsNegated.DefaultValue = null;
			ParserRuleNamedElement_IsNegated.IsContainment = false;
			ParserRuleNamedElement_Element.SetTypeLazy(() => ParserRuleElement);
			ParserRuleNamedElement_Element.Documentation = null;
			ParserRuleNamedElement_Element.Name = "Element";
			ParserRuleNamedElement_Element.SymbolProperty = "Members";
			ParserRuleNamedElement_Element.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleNamedElement_Element.SetClassLazy(() => ParserRuleNamedElement);
			ParserRuleNamedElement_Element.DefaultValue = null;
			ParserRuleNamedElement_Element.IsContainment = true;
			ParserRuleNamedElement_AssignmentOperator.SetTypeLazy(() => AssignmentOperator);
			ParserRuleNamedElement_AssignmentOperator.Documentation = null;
			ParserRuleNamedElement_AssignmentOperator.Name = "AssignmentOperator";
			ParserRuleNamedElement_AssignmentOperator.SymbolProperty = null;
			ParserRuleNamedElement_AssignmentOperator.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleNamedElement_AssignmentOperator.SetClassLazy(() => ParserRuleNamedElement);
			ParserRuleNamedElement_AssignmentOperator.DefaultValue = null;
			ParserRuleNamedElement_AssignmentOperator.IsContainment = false;
			ParserRuleNamedElement_Multiplicity.SetTypeLazy(() => Multiplicity);
			ParserRuleNamedElement_Multiplicity.Documentation = null;
			ParserRuleNamedElement_Multiplicity.Name = "Multiplicity";
			ParserRuleNamedElement_Multiplicity.SymbolProperty = null;
			ParserRuleNamedElement_Multiplicity.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleNamedElement_Multiplicity.SetClassLazy(() => ParserRuleNamedElement);
			ParserRuleNamedElement_Multiplicity.DefaultValue = null;
			ParserRuleNamedElement_Multiplicity.IsContainment = false;
			ParserRuleElement.Documentation = null;
			ParserRuleElement.Name = "ParserRuleElement";
			ParserRuleElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol);
			ParserRuleElement.IsAbstract = true;
			ParserRuleElement.SuperClasses.AddLazy(() => AnnotatedElement);
			ParserRuleReferenceElement.Documentation = null;
			ParserRuleReferenceElement.Name = "ParserRuleReferenceElement";
			ParserRuleReferenceElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleReferenceElement.SymbolType = null;
			ParserRuleReferenceElement.IsAbstract = false;
			ParserRuleReferenceElement.SuperClasses.AddLazy(() => ParserRuleElement);
			ParserRuleReferenceElement.Properties.AddLazy(() => ParserRuleReferenceElement_Rule);
			ParserRuleReferenceElement_Rule.SetTypeLazy(() => Rule);
			ParserRuleReferenceElement_Rule.Documentation = null;
			ParserRuleReferenceElement_Rule.Name = "Rule";
			ParserRuleReferenceElement_Rule.SymbolProperty = null;
			ParserRuleReferenceElement_Rule.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleReferenceElement_Rule.SetClassLazy(() => ParserRuleReferenceElement);
			ParserRuleReferenceElement_Rule.DefaultValue = null;
			ParserRuleReferenceElement_Rule.IsContainment = false;
			ParserRuleEofElement.Documentation = null;
			ParserRuleEofElement.Name = "ParserRuleEofElement";
			ParserRuleEofElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleEofElement.SymbolType = null;
			ParserRuleEofElement.IsAbstract = false;
			ParserRuleEofElement.SuperClasses.AddLazy(() => ParserRuleElement);
			ParserRuleFixedElement.Documentation = null;
			ParserRuleFixedElement.Name = "ParserRuleFixedElement";
			ParserRuleFixedElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleFixedElement.SymbolType = null;
			ParserRuleFixedElement.IsAbstract = false;
			ParserRuleFixedElement.SuperClasses.AddLazy(() => ParserRuleElement);
			ParserRuleFixedElement.Properties.AddLazy(() => ParserRuleFixedElement_Value);
			ParserRuleFixedElement_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			ParserRuleFixedElement_Value.Documentation = null;
			ParserRuleFixedElement_Value.Name = "Value";
			ParserRuleFixedElement_Value.SymbolProperty = null;
			ParserRuleFixedElement_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			ParserRuleFixedElement_Value.SetClassLazy(() => ParserRuleFixedElement);
			ParserRuleFixedElement_Value.DefaultValue = null;
			ParserRuleFixedElement_Value.IsContainment = false;
			ParserRuleWildcardElement.Documentation = null;
			ParserRuleWildcardElement.Name = "ParserRuleWildcardElement";
			ParserRuleWildcardElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleWildcardElement.SymbolType = null;
			ParserRuleWildcardElement.IsAbstract = false;
			ParserRuleWildcardElement.SuperClasses.AddLazy(() => ParserRuleElement);
			ParserRuleBlockElement.Documentation = null;
			ParserRuleBlockElement.Name = "ParserRuleBlockElement";
			ParserRuleBlockElement.SetNamespaceLazy(() => __tmp4);
			ParserRuleBlockElement.SymbolType = null;
			ParserRuleBlockElement.IsAbstract = false;
			ParserRuleBlockElement.SuperClasses.AddLazy(() => ParserRuleElement);
			ParserRuleBlockElement.SuperClasses.AddLazy(() => ParserRuleSimple);
			LexerRule.Documentation = null;
			LexerRule.Name = "LexerRule";
			LexerRule.SetNamespaceLazy(() => __tmp4);
			LexerRule.SymbolType = null;
			LexerRule.IsAbstract = false;
			LexerRule.SuperClasses.AddLazy(() => Rule);
			LexerRule.Properties.AddLazy(() => LexerRule_IsFragment);
			LexerRule.Properties.AddLazy(() => LexerRule_IsHidden);
			LexerRule.Properties.AddLazy(() => LexerRule_ValueType);
			LexerRule.Properties.AddLazy(() => LexerRule_Value);
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
			LexerRule_ValueType.SetTypeLazy(() => global::MetaDslx.Languages.Compiler.Model.CompilerInstance.SystemType.ToMutable());
			LexerRule_ValueType.Documentation = null;
			LexerRule_ValueType.Name = "ValueType";
			LexerRule_ValueType.SymbolProperty = null;
			LexerRule_ValueType.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRule_ValueType.SetClassLazy(() => LexerRule);
			LexerRule_ValueType.DefaultValue = null;
			LexerRule_ValueType.IsContainment = false;
			LexerRule_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Object.ToMutable());
			LexerRule_Value.Documentation = null;
			LexerRule_Value.Name = "Value";
			LexerRule_Value.SymbolProperty = null;
			LexerRule_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRule_Value.SetClassLazy(() => LexerRule);
			LexerRule_Value.DefaultValue = null;
			LexerRule_Value.IsContainment = false;
			LexerRule_Alternatives.SetTypeLazy(() => __tmp12);
			LexerRule_Alternatives.Documentation = null;
			LexerRule_Alternatives.Name = "Alternatives";
			LexerRule_Alternatives.SymbolProperty = "Members";
			LexerRule_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRule_Alternatives.SetClassLazy(() => LexerRule);
			LexerRule_Alternatives.DefaultValue = null;
			LexerRule_Alternatives.IsContainment = true;
			LexerRuleAlternative.Documentation = null;
			LexerRuleAlternative.Name = "LexerRuleAlternative";
			LexerRuleAlternative.SetNamespaceLazy(() => __tmp4);
			LexerRuleAlternative.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol);
			LexerRuleAlternative.IsAbstract = false;
			LexerRuleAlternative.Properties.AddLazy(() => LexerRuleAlternative_Elements);
			LexerRuleAlternative_Elements.SetTypeLazy(() => __tmp13);
			LexerRuleAlternative_Elements.Documentation = null;
			LexerRuleAlternative_Elements.Name = "Elements";
			LexerRuleAlternative_Elements.SymbolProperty = "Members";
			LexerRuleAlternative_Elements.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleAlternative_Elements.SetClassLazy(() => LexerRuleAlternative);
			LexerRuleAlternative_Elements.DefaultValue = null;
			LexerRuleAlternative_Elements.IsContainment = true;
			LexerRuleAlternativeElement.Documentation = null;
			LexerRuleAlternativeElement.Name = "LexerRuleAlternativeElement";
			LexerRuleAlternativeElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleAlternativeElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol);
			LexerRuleAlternativeElement.IsAbstract = false;
			LexerRuleAlternativeElement.Properties.AddLazy(() => LexerRuleAlternativeElement_IsNegated);
			LexerRuleAlternativeElement.Properties.AddLazy(() => LexerRuleAlternativeElement_Element);
			LexerRuleAlternativeElement.Properties.AddLazy(() => LexerRuleAlternativeElement_Multiplicity);
			LexerRuleAlternativeElement_IsNegated.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.Bool.ToMutable());
			LexerRuleAlternativeElement_IsNegated.Documentation = null;
			LexerRuleAlternativeElement_IsNegated.Name = "IsNegated";
			LexerRuleAlternativeElement_IsNegated.SymbolProperty = null;
			LexerRuleAlternativeElement_IsNegated.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleAlternativeElement_IsNegated.SetClassLazy(() => LexerRuleAlternativeElement);
			LexerRuleAlternativeElement_IsNegated.DefaultValue = null;
			LexerRuleAlternativeElement_IsNegated.IsContainment = false;
			LexerRuleAlternativeElement_Element.SetTypeLazy(() => LexerRuleElement);
			LexerRuleAlternativeElement_Element.Documentation = null;
			LexerRuleAlternativeElement_Element.Name = "Element";
			LexerRuleAlternativeElement_Element.SymbolProperty = null;
			LexerRuleAlternativeElement_Element.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleAlternativeElement_Element.SetClassLazy(() => LexerRuleAlternativeElement);
			LexerRuleAlternativeElement_Element.DefaultValue = null;
			LexerRuleAlternativeElement_Element.IsContainment = false;
			LexerRuleAlternativeElement_Multiplicity.SetTypeLazy(() => Multiplicity);
			LexerRuleAlternativeElement_Multiplicity.Documentation = null;
			LexerRuleAlternativeElement_Multiplicity.Name = "Multiplicity";
			LexerRuleAlternativeElement_Multiplicity.SymbolProperty = null;
			LexerRuleAlternativeElement_Multiplicity.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleAlternativeElement_Multiplicity.SetClassLazy(() => LexerRuleAlternativeElement);
			LexerRuleAlternativeElement_Multiplicity.DefaultValue = null;
			LexerRuleAlternativeElement_Multiplicity.IsContainment = false;
			LexerRuleElement.Documentation = null;
			LexerRuleElement.Name = "LexerRuleElement";
			LexerRuleElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleElement.SymbolType = typeof(MetaDslx.CodeAnalysis.Symbols.MemberSymbol);
			LexerRuleElement.IsAbstract = true;
			LexerRuleReferenceElement.Documentation = null;
			LexerRuleReferenceElement.Name = "LexerRuleReferenceElement";
			LexerRuleReferenceElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleReferenceElement.SymbolType = null;
			LexerRuleReferenceElement.IsAbstract = false;
			LexerRuleReferenceElement.SuperClasses.AddLazy(() => LexerRuleElement);
			LexerRuleReferenceElement.Properties.AddLazy(() => LexerRuleReferenceElement_Rule);
			LexerRuleReferenceElement_Rule.SetTypeLazy(() => LexerRule);
			LexerRuleReferenceElement_Rule.Documentation = null;
			LexerRuleReferenceElement_Rule.Name = "Rule";
			LexerRuleReferenceElement_Rule.SymbolProperty = null;
			LexerRuleReferenceElement_Rule.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleReferenceElement_Rule.SetClassLazy(() => LexerRuleReferenceElement);
			LexerRuleReferenceElement_Rule.DefaultValue = null;
			LexerRuleReferenceElement_Rule.IsContainment = false;
			LexerRuleFixedStringElement.Documentation = null;
			LexerRuleFixedStringElement.Name = "LexerRuleFixedStringElement";
			LexerRuleFixedStringElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleFixedStringElement.SymbolType = null;
			LexerRuleFixedStringElement.IsAbstract = false;
			LexerRuleFixedStringElement.SuperClasses.AddLazy(() => LexerRuleElement);
			LexerRuleFixedStringElement.Properties.AddLazy(() => LexerRuleFixedStringElement_Value);
			LexerRuleFixedStringElement_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			LexerRuleFixedStringElement_Value.Documentation = null;
			LexerRuleFixedStringElement_Value.Name = "Value";
			LexerRuleFixedStringElement_Value.SymbolProperty = null;
			LexerRuleFixedStringElement_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleFixedStringElement_Value.SetClassLazy(() => LexerRuleFixedStringElement);
			LexerRuleFixedStringElement_Value.DefaultValue = null;
			LexerRuleFixedStringElement_Value.IsContainment = false;
			LexerRuleFixedCharElement.Documentation = null;
			LexerRuleFixedCharElement.Name = "LexerRuleFixedCharElement";
			LexerRuleFixedCharElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleFixedCharElement.SymbolType = null;
			LexerRuleFixedCharElement.IsAbstract = false;
			LexerRuleFixedCharElement.SuperClasses.AddLazy(() => LexerRuleElement);
			LexerRuleFixedCharElement.Properties.AddLazy(() => LexerRuleFixedCharElement_Value);
			LexerRuleFixedCharElement_Value.SetTypeLazy(() => global::MetaDslx.Languages.Meta.Model.MetaInstance.String.ToMutable());
			LexerRuleFixedCharElement_Value.Documentation = null;
			LexerRuleFixedCharElement_Value.Name = "Value";
			LexerRuleFixedCharElement_Value.SymbolProperty = null;
			LexerRuleFixedCharElement_Value.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleFixedCharElement_Value.SetClassLazy(() => LexerRuleFixedCharElement);
			LexerRuleFixedCharElement_Value.DefaultValue = null;
			LexerRuleFixedCharElement_Value.IsContainment = false;
			LexerRuleWildcardElement.Documentation = null;
			LexerRuleWildcardElement.Name = "LexerRuleWildcardElement";
			LexerRuleWildcardElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleWildcardElement.SymbolType = null;
			LexerRuleWildcardElement.IsAbstract = false;
			LexerRuleWildcardElement.SuperClasses.AddLazy(() => LexerRuleElement);
			LexerRuleBlockElement.Documentation = null;
			LexerRuleBlockElement.Name = "LexerRuleBlockElement";
			LexerRuleBlockElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleBlockElement.SymbolType = null;
			LexerRuleBlockElement.IsAbstract = false;
			LexerRuleBlockElement.SuperClasses.AddLazy(() => LexerRuleElement);
			LexerRuleBlockElement.Properties.AddLazy(() => LexerRuleBlockElement_Alternatives);
			LexerRuleBlockElement_Alternatives.SetTypeLazy(() => __tmp14);
			LexerRuleBlockElement_Alternatives.Documentation = null;
			LexerRuleBlockElement_Alternatives.Name = "Alternatives";
			LexerRuleBlockElement_Alternatives.SymbolProperty = "Members";
			LexerRuleBlockElement_Alternatives.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleBlockElement_Alternatives.SetClassLazy(() => LexerRuleBlockElement);
			LexerRuleBlockElement_Alternatives.DefaultValue = null;
			LexerRuleBlockElement_Alternatives.IsContainment = true;
			LexerRuleRangeElement.Documentation = null;
			LexerRuleRangeElement.Name = "LexerRuleRangeElement";
			LexerRuleRangeElement.SetNamespaceLazy(() => __tmp4);
			LexerRuleRangeElement.SymbolType = null;
			LexerRuleRangeElement.IsAbstract = false;
			LexerRuleRangeElement.SuperClasses.AddLazy(() => LexerRuleElement);
			LexerRuleRangeElement.Properties.AddLazy(() => LexerRuleRangeElement_Start);
			LexerRuleRangeElement.Properties.AddLazy(() => LexerRuleRangeElement_End);
			LexerRuleRangeElement_Start.SetTypeLazy(() => LexerRuleFixedCharElement);
			LexerRuleRangeElement_Start.Documentation = null;
			LexerRuleRangeElement_Start.Name = "Start";
			LexerRuleRangeElement_Start.SymbolProperty = null;
			LexerRuleRangeElement_Start.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleRangeElement_Start.SetClassLazy(() => LexerRuleRangeElement);
			LexerRuleRangeElement_Start.DefaultValue = null;
			LexerRuleRangeElement_Start.IsContainment = true;
			LexerRuleRangeElement_End.SetTypeLazy(() => LexerRuleFixedCharElement);
			LexerRuleRangeElement_End.Documentation = null;
			LexerRuleRangeElement_End.Name = "End";
			LexerRuleRangeElement_End.SymbolProperty = null;
			LexerRuleRangeElement_End.Kind = global::MetaDslx.Languages.Meta.Model.MetaPropertyKind.Normal;
			LexerRuleRangeElement_End.SetClassLazy(() => LexerRuleRangeElement);
			LexerRuleRangeElement_End.DefaultValue = null;
			LexerRuleRangeElement_End.IsContainment = true;
			Multiplicity.Documentation = null;
			Multiplicity.Name = "Multiplicity";
			Multiplicity.SetNamespaceLazy(() => __tmp4);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp15);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp16);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp17);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp18);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp19);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp20);
			Multiplicity.EnumLiterals.AddLazy(() => __tmp21);
			__tmp15.Documentation = null;
			__tmp15.Name = "ExactlyOne";
			__tmp15.SetEnumLazy(() => Multiplicity);
			__tmp16.Documentation = null;
			__tmp16.Name = "ZeroOrOne";
			__tmp16.SetEnumLazy(() => Multiplicity);
			__tmp17.Documentation = null;
			__tmp17.Name = "ZeroOrMore";
			__tmp17.SetEnumLazy(() => Multiplicity);
			__tmp18.Documentation = null;
			__tmp18.Name = "OneOrMore";
			__tmp18.SetEnumLazy(() => Multiplicity);
			__tmp19.Documentation = null;
			__tmp19.Name = "NonGreedyZeroOrOne";
			__tmp19.SetEnumLazy(() => Multiplicity);
			__tmp20.Documentation = null;
			__tmp20.Name = "NonGreedyZeroOrMore";
			__tmp20.SetEnumLazy(() => Multiplicity);
			__tmp21.Documentation = null;
			__tmp21.Name = "NonGreedyOneOrMore";
			__tmp21.SetEnumLazy(() => Multiplicity);
			AssignmentOperator.Documentation = null;
			AssignmentOperator.Name = "AssignmentOperator";
			AssignmentOperator.SetNamespaceLazy(() => __tmp4);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp22);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp23);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp24);
			AssignmentOperator.EnumLiterals.AddLazy(() => __tmp25);
			__tmp22.Documentation = null;
			__tmp22.Name = "Assign";
			__tmp22.SetEnumLazy(() => AssignmentOperator);
			__tmp23.Documentation = null;
			__tmp23.Name = "QuestionAssign";
			__tmp23.SetEnumLazy(() => AssignmentOperator);
			__tmp24.Documentation = null;
			__tmp24.Name = "NegatedAssign";
			__tmp24.SetEnumLazy(() => AssignmentOperator);
			__tmp25.Documentation = null;
			__tmp25.Name = "PlusAssign";
			__tmp25.SetEnumLazy(() => AssignmentOperator);
			__tmp6.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp6.SetInnerTypeLazy(() => Annotation);
			__tmp7.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp7.SetInnerTypeLazy(() => AnnotationProperty);
			__tmp8.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp8.SetInnerTypeLazy(() => NamedElement);
			__tmp9.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp9.SetInnerTypeLazy(() => Rule);
			__tmp10.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp10.SetInnerTypeLazy(() => ParserRule);
			__tmp11.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp11.SetInnerTypeLazy(() => ParserRuleNamedElement);
			__tmp12.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp12.SetInnerTypeLazy(() => LexerRuleAlternative);
			__tmp13.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp13.SetInnerTypeLazy(() => LexerRuleAlternativeElement);
			__tmp14.Kind = global::MetaDslx.Languages.Meta.Model.MetaCollectionKind.List;
			__tmp14.SetInnerTypeLazy(() => LexerRuleAlternative);
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
		/// Implements the constructor: AnnotatedElement()
		/// </summary>
		public virtual void AnnotatedElement(AnnotatedElementBuilder _this)
		{
			this.CallAnnotatedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of AnnotatedElement
		/// </summary>
		protected virtual void CallAnnotatedElementSuperConstructors(AnnotatedElementBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: Annotation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Annotation(AnnotationBuilder _this)
		{
			this.CallAnnotationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Annotation
		/// </summary>
		protected virtual void CallAnnotationSuperConstructors(AnnotationBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: AnnotationProperty()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void AnnotationProperty(AnnotationPropertyBuilder _this)
		{
			this.CallAnnotationPropertySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of AnnotationProperty
		/// </summary>
		protected virtual void CallAnnotationPropertySuperConstructors(AnnotationPropertyBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
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
		///     <li>AnnotatedElement</li>
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
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: NamedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		/// </ul>
		public virtual void NamedElement(NamedElementBuilder _this)
		{
			this.CallNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NamedElement
		/// </summary>
		protected virtual void CallNamedElementSuperConstructors(NamedElementBuilder _this)
		{
			this.AnnotatedElement(_this);
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
		///     <li>AnnotatedElement</li>
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
			this.AnnotatedElement(_this);
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
		///     <li>AnnotatedElement</li>
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
			this.AnnotatedElement(_this);
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
		///     <li>AnnotatedElement</li>
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
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Rule(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleAlt()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRule</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Rule</li>
		///     <li>ParserRule</li>
		/// </ul>
		public virtual void ParserRuleAlt(ParserRuleAltBuilder _this)
		{
			this.CallParserRuleAltSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleAlt
		/// </summary>
		protected virtual void CallParserRuleAltSuperConstructors(ParserRuleAltBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Rule(_this);
			this.ParserRule(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleSimple()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRule</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Rule</li>
		///     <li>ParserRule</li>
		/// </ul>
		public virtual void ParserRuleSimple(ParserRuleSimpleBuilder _this)
		{
			this.CallParserRuleSimpleSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleSimple
		/// </summary>
		protected virtual void CallParserRuleSimpleSuperConstructors(ParserRuleSimpleBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Rule(_this);
			this.ParserRule(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleNamedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void ParserRuleNamedElement(ParserRuleNamedElementBuilder _this)
		{
			this.CallParserRuleNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleNamedElement
		/// </summary>
		protected virtual void CallParserRuleNamedElementSuperConstructors(ParserRuleNamedElementBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
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
			this.AnnotatedElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleReferenceElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>ParserRuleElement</li>
		/// </ul>
		public virtual void ParserRuleReferenceElement(ParserRuleReferenceElementBuilder _this)
		{
			this.CallParserRuleReferenceElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleReferenceElement
		/// </summary>
		protected virtual void CallParserRuleReferenceElementSuperConstructors(ParserRuleReferenceElementBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.ParserRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleEofElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>ParserRuleElement</li>
		/// </ul>
		public virtual void ParserRuleEofElement(ParserRuleEofElementBuilder _this)
		{
			this.CallParserRuleEofElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleEofElement
		/// </summary>
		protected virtual void CallParserRuleEofElementSuperConstructors(ParserRuleEofElementBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.ParserRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleFixedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>ParserRuleElement</li>
		/// </ul>
		public virtual void ParserRuleFixedElement(ParserRuleFixedElementBuilder _this)
		{
			this.CallParserRuleFixedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleFixedElement
		/// </summary>
		protected virtual void CallParserRuleFixedElementSuperConstructors(ParserRuleFixedElementBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.ParserRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleWildcardElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>ParserRuleElement</li>
		/// </ul>
		public virtual void ParserRuleWildcardElement(ParserRuleWildcardElementBuilder _this)
		{
			this.CallParserRuleWildcardElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleWildcardElement
		/// </summary>
		protected virtual void CallParserRuleWildcardElementSuperConstructors(ParserRuleWildcardElementBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.ParserRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: ParserRuleBlockElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ParserRuleElement</li>
		///     <li>ParserRuleSimple</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Rule</li>
		///     <li>ParserRule</li>
		///     <li>AnnotatedElement</li>
		///     <li>ParserRuleSimple</li>
		///     <li>ParserRuleElement</li>
		/// </ul>
		public virtual void ParserRuleBlockElement(ParserRuleBlockElementBuilder _this)
		{
			this.CallParserRuleBlockElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ParserRuleBlockElement
		/// </summary>
		protected virtual void CallParserRuleBlockElementSuperConstructors(ParserRuleBlockElementBuilder _this)
		{
			this.NamedElement(_this);
			this.Rule(_this);
			this.ParserRule(_this);
			this.AnnotatedElement(_this);
			this.ParserRuleSimple(_this);
			this.ParserRuleElement(_this);
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
		///     <li>AnnotatedElement</li>
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
			this.AnnotatedElement(_this);
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
		/// Implements the constructor: LexerRuleAlternativeElement()
		/// </summary>
		public virtual void LexerRuleAlternativeElement(LexerRuleAlternativeElementBuilder _this)
		{
			this.CallLexerRuleAlternativeElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleAlternativeElement
		/// </summary>
		protected virtual void CallLexerRuleAlternativeElementSuperConstructors(LexerRuleAlternativeElementBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleElement()
		/// </summary>
		public virtual void LexerRuleElement(LexerRuleElementBuilder _this)
		{
			this.CallLexerRuleElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleElement
		/// </summary>
		protected virtual void CallLexerRuleElementSuperConstructors(LexerRuleElementBuilder _this)
		{
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleReferenceElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		public virtual void LexerRuleReferenceElement(LexerRuleReferenceElementBuilder _this)
		{
			this.CallLexerRuleReferenceElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleReferenceElement
		/// </summary>
		protected virtual void CallLexerRuleReferenceElementSuperConstructors(LexerRuleReferenceElementBuilder _this)
		{
			this.LexerRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleFixedStringElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		public virtual void LexerRuleFixedStringElement(LexerRuleFixedStringElementBuilder _this)
		{
			this.CallLexerRuleFixedStringElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleFixedStringElement
		/// </summary>
		protected virtual void CallLexerRuleFixedStringElementSuperConstructors(LexerRuleFixedStringElementBuilder _this)
		{
			this.LexerRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleFixedCharElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		public virtual void LexerRuleFixedCharElement(LexerRuleFixedCharElementBuilder _this)
		{
			this.CallLexerRuleFixedCharElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleFixedCharElement
		/// </summary>
		protected virtual void CallLexerRuleFixedCharElementSuperConstructors(LexerRuleFixedCharElementBuilder _this)
		{
			this.LexerRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleWildcardElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		public virtual void LexerRuleWildcardElement(LexerRuleWildcardElementBuilder _this)
		{
			this.CallLexerRuleWildcardElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleWildcardElement
		/// </summary>
		protected virtual void CallLexerRuleWildcardElementSuperConstructors(LexerRuleWildcardElementBuilder _this)
		{
			this.LexerRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleBlockElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		public virtual void LexerRuleBlockElement(LexerRuleBlockElementBuilder _this)
		{
			this.CallLexerRuleBlockElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleBlockElement
		/// </summary>
		protected virtual void CallLexerRuleBlockElementSuperConstructors(LexerRuleBlockElementBuilder _this)
		{
			this.LexerRuleElement(_this);
		}
	
	
	
	
		/// <summary>
		/// Implements the constructor: LexerRuleRangeElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>LexerRuleElement</li>
		/// </ul>
		public virtual void LexerRuleRangeElement(LexerRuleRangeElementBuilder _this)
		{
			this.CallLexerRuleRangeElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of LexerRuleRangeElement
		/// </summary>
		protected virtual void CallLexerRuleRangeElementSuperConstructors(LexerRuleRangeElementBuilder _this)
		{
			this.LexerRuleElement(_this);
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

