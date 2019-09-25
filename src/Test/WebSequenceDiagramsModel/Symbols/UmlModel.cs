using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WebSequenceDiagramsModel.Symbols
{
	using global::WebSequenceDiagramsModel.Symbols.Internal;

	public class UmlInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return UmlInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaModel MetaModel;
		public static readonly global::MetaDslx.Modeling.ImmutableModel Model;
	
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Interaction;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Interaction_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Interaction_Declarations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Declaration;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Lifeline;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Lifeline_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Message;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Message_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Message_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Message_Source;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Message_Target;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Destroy;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Destroy_Lifeline;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Fragment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Fragment_Kind;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Fragment_Text;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Fragment_Declarations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass MultiFragment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty MultiFragment_Fragments;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass RefFragment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty RefFragment_Input;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty RefFragment_Output;
	
		static UmlInstance()
		{
			UmlBuilderInstance.instance.Create();
			UmlBuilderInstance.instance.EvaluateLazyValues();
			MetaModel = UmlBuilderInstance.instance.MetaModel.ToImmutable();
			Model = UmlBuilderInstance.instance.Model.ToImmutable();
	
	
			Interaction = UmlBuilderInstance.instance.Interaction.ToImmutable(Model);
			Interaction_Name = UmlBuilderInstance.instance.Interaction_Name.ToImmutable(Model);
			Interaction_Declarations = UmlBuilderInstance.instance.Interaction_Declarations.ToImmutable(Model);
			Declaration = UmlBuilderInstance.instance.Declaration.ToImmutable(Model);
			Lifeline = UmlBuilderInstance.instance.Lifeline.ToImmutable(Model);
			Lifeline_Name = UmlBuilderInstance.instance.Lifeline_Name.ToImmutable(Model);
			Message = UmlBuilderInstance.instance.Message.ToImmutable(Model);
			Message_Kind = UmlBuilderInstance.instance.Message_Kind.ToImmutable(Model);
			Message_Text = UmlBuilderInstance.instance.Message_Text.ToImmutable(Model);
			Message_Source = UmlBuilderInstance.instance.Message_Source.ToImmutable(Model);
			Message_Target = UmlBuilderInstance.instance.Message_Target.ToImmutable(Model);
			Destroy = UmlBuilderInstance.instance.Destroy.ToImmutable(Model);
			Destroy_Lifeline = UmlBuilderInstance.instance.Destroy_Lifeline.ToImmutable(Model);
			Fragment = UmlBuilderInstance.instance.Fragment.ToImmutable(Model);
			Fragment_Kind = UmlBuilderInstance.instance.Fragment_Kind.ToImmutable(Model);
			Fragment_Text = UmlBuilderInstance.instance.Fragment_Text.ToImmutable(Model);
			Fragment_Declarations = UmlBuilderInstance.instance.Fragment_Declarations.ToImmutable(Model);
			MultiFragment = UmlBuilderInstance.instance.MultiFragment.ToImmutable(Model);
			MultiFragment_Fragments = UmlBuilderInstance.instance.MultiFragment_Fragments.ToImmutable(Model);
			RefFragment = UmlBuilderInstance.instance.RefFragment.ToImmutable(Model);
			RefFragment_Input = UmlBuilderInstance.instance.RefFragment_Input.ToImmutable(Model);
			RefFragment_Output = UmlBuilderInstance.instance.RefFragment_Output.ToImmutable(Model);
	
			UmlInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class UmlFactory : global::MetaDslx.Modeling.ModelFactory
	{
		public UmlFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			UmlDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "Interaction": return this.Interaction();
				case "Declaration": return this.Declaration();
				case "Lifeline": return this.Lifeline();
				case "Message": return this.Message();
				case "Destroy": return this.Destroy();
				case "Fragment": return this.Fragment();
				case "MultiFragment": return this.MultiFragment();
				case "RefFragment": return this.RefFragment();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::Microsoft.CodeAnalysis.Location.None, new global::MetaDslx.CodeAnalysis.LanguageDiagnosticInfo(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Interaction.
		/// </summary>
		public InteractionBuilder Interaction()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new InteractionId());
			return (InteractionBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Declaration.
		/// </summary>
		public DeclarationBuilder Declaration()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new DeclarationId());
			return (DeclarationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Lifeline.
		/// </summary>
		public LifelineBuilder Lifeline()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new LifelineId());
			return (LifelineBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Message.
		/// </summary>
		public MessageBuilder Message()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MessageId());
			return (MessageBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Destroy.
		/// </summary>
		public DestroyBuilder Destroy()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new DestroyId());
			return (DestroyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Fragment.
		/// </summary>
		public FragmentBuilder Fragment()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new FragmentId());
			return (FragmentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of MultiFragment.
		/// </summary>
		public MultiFragmentBuilder MultiFragment()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new MultiFragmentId());
			return (MultiFragmentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of RefFragment.
		/// </summary>
		public RefFragmentBuilder RefFragment()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new RefFragmentId());
			return (RefFragmentBuilder)symbol;
		}
	}
	

	
	public enum MessageKind
	{
		Sync,
		Async,
		Return,
		Create
	}
	
	public static class MessageKindExtensions
	{
	}
	
	public enum FragmentKind
	{
		Loop,
		Opt,
		Alt,
		Else,
		Ref
	}
	
	public static class FragmentKindExtensions
	{
	}
	
	public interface Interaction : global::MetaDslx.Modeling.ImmutableSymbol
	{
		string Name { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations { get; }
	
	
		new InteractionBuilder ToMutable();
		new InteractionBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface InteractionBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations { get; }
	
		new Interaction ToImmutable();
		new Interaction ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Declaration : global::MetaDslx.Modeling.ImmutableSymbol
	{
	
	
		new DeclarationBuilder ToMutable();
		new DeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DeclarationBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
	
		new Declaration ToImmutable();
		new Declaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Lifeline : Declaration
	{
		string Name { get; }
	
	
		new LifelineBuilder ToMutable();
		new LifelineBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface LifelineBuilder : DeclarationBuilder
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new Lifeline ToImmutable();
		new Lifeline ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Message : Declaration
	{
		MessageKind Kind { get; }
		string Text { get; }
		Lifeline Source { get; }
		Lifeline Target { get; }
	
	
		new MessageBuilder ToMutable();
		new MessageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MessageBuilder : DeclarationBuilder
	{
		MessageKind Kind { get; set; }
		Func<MessageKind> KindLazy { get; set; }
		string Text { get; set; }
		Func<string> TextLazy { get; set; }
		LifelineBuilder Source { get; set; }
		Func<LifelineBuilder> SourceLazy { get; set; }
		LifelineBuilder Target { get; set; }
		Func<LifelineBuilder> TargetLazy { get; set; }
	
		new Message ToImmutable();
		new Message ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Destroy : Declaration
	{
		Lifeline Lifeline { get; }
	
	
		new DestroyBuilder ToMutable();
		new DestroyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DestroyBuilder : DeclarationBuilder
	{
		LifelineBuilder Lifeline { get; set; }
		Func<LifelineBuilder> LifelineLazy { get; set; }
	
		new Destroy ToImmutable();
		new Destroy ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Fragment : Declaration
	{
		FragmentKind Kind { get; }
		string Text { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations { get; }
	
	
		new FragmentBuilder ToMutable();
		new FragmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface FragmentBuilder : DeclarationBuilder
	{
		FragmentKind Kind { get; set; }
		Func<FragmentKind> KindLazy { get; set; }
		string Text { get; set; }
		Func<string> TextLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations { get; }
	
		new Fragment ToImmutable();
		new Fragment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface MultiFragment : Declaration
	{
		global::MetaDslx.Modeling.ImmutableModelList<Fragment> Fragments { get; }
	
	
		new MultiFragmentBuilder ToMutable();
		new MultiFragmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface MultiFragmentBuilder : DeclarationBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<FragmentBuilder> Fragments { get; }
	
		new MultiFragment ToImmutable();
		new MultiFragment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RefFragment : Fragment, Lifeline
	{
		Message Input { get; }
		Message Output { get; }
	
	
		new RefFragmentBuilder ToMutable();
		new RefFragmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RefFragmentBuilder : FragmentBuilder, LifelineBuilder
	{
		MessageBuilder Input { get; set; }
		Func<MessageBuilder> InputLazy { get; set; }
		MessageBuilder Output { get; set; }
		Func<MessageBuilder> OutputLazy { get; set; }
	
		new RefFragment ToImmutable();
		new RefFragment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class UmlDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static UmlDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			Interaction.Initialize();
			Declaration.Initialize();
			Lifeline.Initialize();
			Message.Initialize();
			Destroy.Initialize();
			Fragment.Initialize();
			MultiFragment.Initialize();
			RefFragment.Initialize();
			properties.Add(UmlDescriptor.Interaction.NameProperty);
			properties.Add(UmlDescriptor.Interaction.DeclarationsProperty);
			properties.Add(UmlDescriptor.Lifeline.NameProperty);
			properties.Add(UmlDescriptor.Message.KindProperty);
			properties.Add(UmlDescriptor.Message.TextProperty);
			properties.Add(UmlDescriptor.Message.SourceProperty);
			properties.Add(UmlDescriptor.Message.TargetProperty);
			properties.Add(UmlDescriptor.Destroy.LifelineProperty);
			properties.Add(UmlDescriptor.Fragment.KindProperty);
			properties.Add(UmlDescriptor.Fragment.TextProperty);
			properties.Add(UmlDescriptor.Fragment.DeclarationsProperty);
			properties.Add(UmlDescriptor.MultiFragment.FragmentsProperty);
			properties.Add(UmlDescriptor.RefFragment.InputProperty);
			properties.Add(UmlDescriptor.RefFragment.OutputProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "";
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.InteractionId), typeof(global::WebSequenceDiagramsModel.Symbols.Interaction), typeof(global::WebSequenceDiagramsModel.Symbols.InteractionBuilder))]
		public static class Interaction
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Interaction()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Interaction));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.Interaction; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Interaction), "Name",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Interaction_Name);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Interaction), "Declarations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Declaration), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::WebSequenceDiagramsModel.Symbols.Declaration>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.DeclarationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::WebSequenceDiagramsModel.Symbols.DeclarationBuilder>)),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Interaction_Declarations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.DeclarationId), typeof(global::WebSequenceDiagramsModel.Symbols.Declaration), typeof(global::WebSequenceDiagramsModel.Symbols.DeclarationBuilder))]
		public static class Declaration
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Declaration()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Declaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.Declaration; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.LifelineId), typeof(global::WebSequenceDiagramsModel.Symbols.Lifeline), typeof(global::WebSequenceDiagramsModel.Symbols.LifelineBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(UmlDescriptor.Declaration) })]
		public static class Lifeline
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Lifeline()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Lifeline));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.Lifeline; }
			}
			
			[global::MetaDslx.Modeling.NameAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Lifeline), "Name",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Lifeline_Name);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.MessageId), typeof(global::WebSequenceDiagramsModel.Symbols.Message), typeof(global::WebSequenceDiagramsModel.Symbols.MessageBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(UmlDescriptor.Declaration) })]
		public static class Message
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Message()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Message));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.Message; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Message), "Kind",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.MessageKind), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.MessageKind), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Message_Kind);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty TextProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Message), "Text",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Message_Text);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SourceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Message), "Source",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Lifeline), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.LifelineBuilder), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Message_Source);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty TargetProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Message), "Target",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Lifeline), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.LifelineBuilder), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Message_Target);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.DestroyId), typeof(global::WebSequenceDiagramsModel.Symbols.Destroy), typeof(global::WebSequenceDiagramsModel.Symbols.DestroyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(UmlDescriptor.Declaration) })]
		public static class Destroy
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Destroy()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Destroy));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.Destroy; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty LifelineProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Destroy), "Lifeline",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Lifeline), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.LifelineBuilder), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Destroy_Lifeline);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.FragmentId), typeof(global::WebSequenceDiagramsModel.Symbols.Fragment), typeof(global::WebSequenceDiagramsModel.Symbols.FragmentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(UmlDescriptor.Declaration) })]
		public static class Fragment
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Fragment()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Fragment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.Fragment; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty KindProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Fragment), "Kind",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.FragmentKind), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.FragmentKind), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Fragment_Kind);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty TextProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Fragment), "Text",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Fragment_Text);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Fragment), "Declarations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Declaration), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::WebSequenceDiagramsModel.Symbols.Declaration>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.DeclarationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::WebSequenceDiagramsModel.Symbols.DeclarationBuilder>)),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.Fragment_Declarations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.MultiFragmentId), typeof(global::WebSequenceDiagramsModel.Symbols.MultiFragment), typeof(global::WebSequenceDiagramsModel.Symbols.MultiFragmentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(UmlDescriptor.Declaration) })]
		public static class MultiFragment
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static MultiFragment()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(MultiFragment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MultiFragment; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty FragmentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(MultiFragment), "Fragments",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Fragment), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::WebSequenceDiagramsModel.Symbols.Fragment>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.FragmentBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::WebSequenceDiagramsModel.Symbols.FragmentBuilder>)),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.MultiFragment_Fragments);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::WebSequenceDiagramsModel.Symbols.Internal.RefFragmentId), typeof(global::WebSequenceDiagramsModel.Symbols.RefFragment), typeof(global::WebSequenceDiagramsModel.Symbols.RefFragmentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(UmlDescriptor.Fragment), typeof(UmlDescriptor.Lifeline) })]
		public static class RefFragment
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static RefFragment()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(RefFragment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.RefFragment; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InputProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(RefFragment), "Input",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Message), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.MessageBuilder), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.RefFragment_Input);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty OutputProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(RefFragment), "Output",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.Message), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::WebSequenceDiagramsModel.Symbols.MessageBuilder), null),
					() => global::WebSequenceDiagramsModel.Symbols.UmlInstance.RefFragment_Output);
		}
	}
}

namespace WebSequenceDiagramsModel.Symbols.Internal
{
	
	internal class InteractionId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new InteractionImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new InteractionBuilderImpl(this, model, creating);
		}
	}
	
	internal class InteractionImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Interaction
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Declaration> declarations0;
	
		internal InteractionImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Interaction; }
		}
	
		public new InteractionBuilder ToMutable()
		{
			return (InteractionBuilder)base.ToMutable();
		}
	
		public new InteractionBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (InteractionBuilder)base.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class InteractionBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, InteractionBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> declarations0;
	
		internal InteractionBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.Interaction(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Interaction; }
		}
	
		public new Interaction ToImmutable()
		{
			return (Interaction)base.ToImmutable();
		}
	
		public new Interaction ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Interaction)base.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.NameProperty); }
			set { this.SetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.NameProperty); }
			set { this.SetLazyReference(UmlDescriptor.Interaction.NameProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Interaction.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class DeclarationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Declaration.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeclarationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Declaration
	{
	
		internal DeclarationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Declaration; }
		}
	
		public new DeclarationBuilder ToMutable()
		{
			return (DeclarationBuilder)base.ToMutable();
		}
	
		public new DeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DeclarationBuilder)base.ToMutable(model);
		}
	}
	
	internal class DeclarationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, DeclarationBuilder
	{
	
		internal DeclarationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.Declaration(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Declaration; }
		}
	
		public new Declaration ToImmutable()
		{
			return (Declaration)base.ToImmutable();
		}
	
		public new Declaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Declaration)base.ToImmutable(model);
		}
	}
	
	internal class LifelineId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new LifelineImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new LifelineBuilderImpl(this, model, creating);
		}
	}
	
	internal class LifelineImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Lifeline
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal LifelineImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Lifeline; }
		}
	
		public new LifelineBuilder ToMutable()
		{
			return (LifelineBuilder)base.ToMutable();
		}
	
		public new LifelineBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (LifelineBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty, ref name0); }
		}
	}
	
	internal class LifelineBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, LifelineBuilder
	{
	
		internal LifelineBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.Lifeline(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Lifeline; }
		}
	
		public new Lifeline ToImmutable()
		{
			return (Lifeline)base.ToImmutable();
		}
	
		public new Lifeline ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Lifeline)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty); }
			set { this.SetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty); }
			set { this.SetLazyReference(UmlDescriptor.Lifeline.NameProperty, value); }
		}
	}
	
	internal class MessageId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MessageImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MessageBuilderImpl(this, model, creating);
		}
	}
	
	internal class MessageImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Message
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private MessageKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string text0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Lifeline source0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Lifeline target0;
	
		internal MessageImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Message; }
		}
	
		public new MessageBuilder ToMutable()
		{
			return (MessageBuilder)base.ToMutable();
		}
	
		public new MessageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MessageBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public MessageKind Kind
		{
		    get { return this.GetValue<MessageKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.KindProperty, ref kind0); }
		}
	
		
		public string Text
		{
		    get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TextProperty, ref text0); }
		}
	
		
		public Lifeline Source
		{
		    get { return this.GetReference<Lifeline>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.SourceProperty, ref source0); }
		}
	
		
		public Lifeline Target
		{
		    get { return this.GetReference<Lifeline>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TargetProperty, ref target0); }
		}
	}
	
	internal class MessageBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MessageBuilder
	{
	
		internal MessageBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.Message(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Message; }
		}
	
		public new Message ToImmutable()
		{
			return (Message)base.ToImmutable();
		}
	
		public new Message ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Message)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public MessageKind Kind
		{
			get { return this.GetValue<MessageKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.KindProperty); }
			set { this.SetValue<MessageKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.KindProperty, value); }
		}
		
		public Func<MessageKind> KindLazy
		{
			get { return this.GetLazyValue<MessageKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.KindProperty); }
			set { this.SetLazyValue(UmlDescriptor.Message.KindProperty, value); }
		}
	
		
		public string Text
		{
			get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TextProperty); }
			set { this.SetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TextProperty, value); }
		}
		
		public Func<string> TextLazy
		{
			get { return this.GetLazyReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TextProperty); }
			set { this.SetLazyReference(UmlDescriptor.Message.TextProperty, value); }
		}
	
		
		public LifelineBuilder Source
		{
			get { return this.GetReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.SourceProperty); }
			set { this.SetReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.SourceProperty, value); }
		}
		
		public Func<LifelineBuilder> SourceLazy
		{
			get { return this.GetLazyReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.SourceProperty); }
			set { this.SetLazyReference(UmlDescriptor.Message.SourceProperty, value); }
		}
	
		
		public LifelineBuilder Target
		{
			get { return this.GetReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TargetProperty); }
			set { this.SetReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TargetProperty, value); }
		}
		
		public Func<LifelineBuilder> TargetLazy
		{
			get { return this.GetLazyReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Message.TargetProperty); }
			set { this.SetLazyReference(UmlDescriptor.Message.TargetProperty, value); }
		}
	}
	
	internal class DestroyId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Destroy.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DestroyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DestroyBuilderImpl(this, model, creating);
		}
	}
	
	internal class DestroyImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Destroy
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Lifeline lifeline0;
	
		internal DestroyImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Destroy; }
		}
	
		public new DestroyBuilder ToMutable()
		{
			return (DestroyBuilder)base.ToMutable();
		}
	
		public new DestroyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DestroyBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public Lifeline Lifeline
		{
		    get { return this.GetReference<Lifeline>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Destroy.LifelineProperty, ref lifeline0); }
		}
	}
	
	internal class DestroyBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, DestroyBuilder
	{
	
		internal DestroyBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.Destroy(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Destroy; }
		}
	
		public new Destroy ToImmutable()
		{
			return (Destroy)base.ToImmutable();
		}
	
		public new Destroy ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Destroy)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public LifelineBuilder Lifeline
		{
			get { return this.GetReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Destroy.LifelineProperty); }
			set { this.SetReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Destroy.LifelineProperty, value); }
		}
		
		public Func<LifelineBuilder> LifelineLazy
		{
			get { return this.GetLazyReference<LifelineBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Destroy.LifelineProperty); }
			set { this.SetLazyReference(UmlDescriptor.Destroy.LifelineProperty, value); }
		}
	}
	
	internal class FragmentId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new FragmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new FragmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class FragmentImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Fragment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FragmentKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string text0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Declaration> declarations0;
	
		internal FragmentImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Fragment; }
		}
	
		public new FragmentBuilder ToMutable()
		{
			return (FragmentBuilder)base.ToMutable();
		}
	
		public new FragmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (FragmentBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public FragmentKind Kind
		{
		    get { return this.GetValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty, ref kind0); }
		}
	
		
		public string Text
		{
		    get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty, ref text0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class FragmentBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, FragmentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> declarations0;
	
		internal FragmentBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.Fragment(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.Fragment; }
		}
	
		public new Fragment ToImmutable()
		{
			return (Fragment)base.ToImmutable();
		}
	
		public new Fragment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Fragment)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public FragmentKind Kind
		{
			get { return this.GetValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty); }
			set { this.SetValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty, value); }
		}
		
		public Func<FragmentKind> KindLazy
		{
			get { return this.GetLazyValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty); }
			set { this.SetLazyValue(UmlDescriptor.Fragment.KindProperty, value); }
		}
	
		
		public string Text
		{
			get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty); }
			set { this.SetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty, value); }
		}
		
		public Func<string> TextLazy
		{
			get { return this.GetLazyReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty); }
			set { this.SetLazyReference(UmlDescriptor.Fragment.TextProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class MultiFragmentId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.MultiFragment.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new MultiFragmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new MultiFragmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class MultiFragmentImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, MultiFragment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Fragment> fragments0;
	
		internal MultiFragmentImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.MultiFragment; }
		}
	
		public new MultiFragmentBuilder ToMutable()
		{
			return (MultiFragmentBuilder)base.ToMutable();
		}
	
		public new MultiFragmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (MultiFragmentBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Fragment> Fragments
		{
		    get { return this.GetList<Fragment>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.MultiFragment.FragmentsProperty, ref fragments0); }
		}
	}
	
	internal class MultiFragmentBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, MultiFragmentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<FragmentBuilder> fragments0;
	
		internal MultiFragmentBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.MultiFragment(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.MultiFragment; }
		}
	
		public new MultiFragment ToImmutable()
		{
			return (MultiFragment)base.ToImmutable();
		}
	
		public new MultiFragment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (MultiFragment)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<FragmentBuilder> Fragments
		{
			get { return this.GetList<FragmentBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.MultiFragment.FragmentsProperty, ref fragments0); }
		}
	}
	
	internal class RefFragmentId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RefFragmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RefFragmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class RefFragmentImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, RefFragment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FragmentKind kind0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string text0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Declaration> declarations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Message input0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Message output0;
	
		internal RefFragmentImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.RefFragment; }
		}
	
		public new RefFragmentBuilder ToMutable()
		{
			return (RefFragmentBuilder)base.ToMutable();
		}
	
		public new RefFragmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RefFragmentBuilder)base.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		LifelineBuilder Lifeline.ToMutable()
		{
			return this.ToMutable();
		}
	
		LifelineBuilder Lifeline.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		FragmentBuilder Fragment.ToMutable()
		{
			return this.ToMutable();
		}
	
		FragmentBuilder Fragment.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty, ref name0); }
		}
	
		
		public FragmentKind Kind
		{
		    get { return this.GetValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty, ref kind0); }
		}
	
		
		public string Text
		{
		    get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty, ref text0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.DeclarationsProperty, ref declarations0); }
		}
	
		
		public Message Input
		{
		    get { return this.GetReference<Message>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.InputProperty, ref input0); }
		}
	
		
		public Message Output
		{
		    get { return this.GetReference<Message>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.OutputProperty, ref output0); }
		}
	}
	
	internal class RefFragmentBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, RefFragmentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> declarations0;
	
		internal RefFragmentBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			UmlImplementationProvider.Implementation.RefFragment(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::WebSequenceDiagramsModel.Symbols.UmlInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return UmlInstance.RefFragment; }
		}
	
		public new RefFragment ToImmutable()
		{
			return (RefFragment)base.ToImmutable();
		}
	
		public new RefFragment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RefFragment)base.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Lifeline LifelineBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Lifeline LifelineBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Fragment FragmentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Fragment FragmentBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty); }
			set { this.SetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Lifeline.NameProperty); }
			set { this.SetLazyReference(UmlDescriptor.Lifeline.NameProperty, value); }
		}
	
		
		public FragmentKind Kind
		{
			get { return this.GetValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty); }
			set { this.SetValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty, value); }
		}
		
		public Func<FragmentKind> KindLazy
		{
			get { return this.GetLazyValue<FragmentKind>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.KindProperty); }
			set { this.SetLazyValue(UmlDescriptor.Fragment.KindProperty, value); }
		}
	
		
		public string Text
		{
			get { return this.GetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty); }
			set { this.SetReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty, value); }
		}
		
		public Func<string> TextLazy
		{
			get { return this.GetLazyReference<string>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.TextProperty); }
			set { this.SetLazyReference(UmlDescriptor.Fragment.TextProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.Fragment.DeclarationsProperty, ref declarations0); }
		}
	
		
		public MessageBuilder Input
		{
			get { return this.GetReference<MessageBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.InputProperty); }
			set { this.SetReference<MessageBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.InputProperty, value); }
		}
		
		public Func<MessageBuilder> InputLazy
		{
			get { return this.GetLazyReference<MessageBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.InputProperty); }
			set { this.SetLazyReference(UmlDescriptor.RefFragment.InputProperty, value); }
		}
	
		
		public MessageBuilder Output
		{
			get { return this.GetReference<MessageBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.OutputProperty); }
			set { this.SetReference<MessageBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.OutputProperty, value); }
		}
		
		public Func<MessageBuilder> OutputLazy
		{
			get { return this.GetLazyReference<MessageBuilder>(global::WebSequenceDiagramsModel.Symbols.UmlDescriptor.RefFragment.OutputProperty); }
			set { this.SetLazyReference(UmlDescriptor.RefFragment.OutputProperty, value); }
		}
	}

	internal class UmlBuilderInstance
	{
		internal static UmlBuilderInstance instance = new UmlBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder MetaModel;
		internal global::MetaDslx.Modeling.MutableModel Model;
		internal global::MetaDslx.Modeling.MutableModelGroup ModelGroup;
	
	
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp2;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Interaction;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Interaction_Name;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Interaction_Declarations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Declaration;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Lifeline;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Lifeline_Name;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder MessageKind;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp11;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp12;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Message;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Message_Kind;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Message_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Message_Source;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Message_Target;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Destroy;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Destroy_Lifeline;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder FragmentKind;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp10;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Fragment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Fragment_Kind;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Fragment_Text;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Fragment_Declarations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder MultiFragment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder MultiFragment_Fragments;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder RefFragment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder RefFragment_Input;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder RefFragment_Output;
		private global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp15;
	
		internal UmlBuilderInstance()
		{
			this.ModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.ModelGroup.AddReference(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Model.ToMutable(true));
			this.Model = this.ModelGroup.CreateModel("Uml");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			UmlImplementationProvider.Implementation.UmlBuilderInstance(this);
			this.CreateSymbols();
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.Model.EvaluateLazyValues();
		}
	
		private void CreateSymbols()
		{
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			Interaction = factory.MetaClass();
			Interaction_Name = factory.MetaProperty();
			Interaction_Declarations = factory.MetaProperty();
			Declaration = factory.MetaClass();
			Lifeline = factory.MetaClass();
			Lifeline_Name = factory.MetaProperty();
			MessageKind = factory.MetaEnum();
			__tmp4 = factory.MetaEnumLiteral();
			__tmp5 = factory.MetaEnumLiteral();
			__tmp11 = factory.MetaEnumLiteral();
			__tmp12 = factory.MetaEnumLiteral();
			Message = factory.MetaClass();
			Message_Kind = factory.MetaProperty();
			Message_Text = factory.MetaProperty();
			Message_Source = factory.MetaProperty();
			Message_Target = factory.MetaProperty();
			Destroy = factory.MetaClass();
			Destroy_Lifeline = factory.MetaProperty();
			FragmentKind = factory.MetaEnum();
			__tmp6 = factory.MetaEnumLiteral();
			__tmp7 = factory.MetaEnumLiteral();
			__tmp8 = factory.MetaEnumLiteral();
			__tmp9 = factory.MetaEnumLiteral();
			__tmp10 = factory.MetaEnumLiteral();
			Fragment = factory.MetaClass();
			Fragment_Kind = factory.MetaProperty();
			Fragment_Text = factory.MetaProperty();
			Fragment_Declarations = factory.MetaProperty();
			MultiFragment = factory.MetaClass();
			MultiFragment_Fragments = factory.MetaProperty();
			RefFragment = factory.MetaClass();
			RefFragment_Input = factory.MetaProperty();
			RefFragment_Output = factory.MetaProperty();
			__tmp3 = factory.MetaModel();
			MetaModel = __tmp3;
			__tmp13 = factory.MetaCollectionType();
			__tmp14 = factory.MetaCollectionType();
			__tmp15 = factory.MetaCollectionType();
	
			// __tmp1.MetaModel = null;
			// __tmp1.Namespace = null;
			__tmp1.Documentation = null;
			__tmp1.Name = "WebSequenceDiagramsModel";
			// __tmp1.DefinedMetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			// __tmp2.MetaModel = null;
			__tmp2.NamespaceLazy = () => __tmp1;
			__tmp2.Documentation = null;
			__tmp2.Name = "Symbols";
			__tmp2.DefinedMetaModelLazy = () => __tmp3;
			__tmp2.Declarations.AddLazy(() => Interaction);
			__tmp2.Declarations.AddLazy(() => Declaration);
			__tmp2.Declarations.AddLazy(() => Lifeline);
			__tmp2.Declarations.AddLazy(() => MessageKind);
			__tmp2.Declarations.AddLazy(() => Message);
			__tmp2.Declarations.AddLazy(() => Destroy);
			__tmp2.Declarations.AddLazy(() => FragmentKind);
			__tmp2.Declarations.AddLazy(() => Fragment);
			__tmp2.Declarations.AddLazy(() => MultiFragment);
			__tmp2.Declarations.AddLazy(() => RefFragment);
			Interaction.MetaModelLazy = () => __tmp3;
			Interaction.NamespaceLazy = () => __tmp2;
			Interaction.Documentation = null;
			Interaction.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Interaction.Name = "Interaction";
			// Interaction.IsAbstract = null;
			Interaction.Properties.AddLazy(() => Interaction_Name);
			Interaction.Properties.AddLazy(() => Interaction_Declarations);
			Interaction_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Interaction_Name.Name = "Name";
			Interaction_Name.Documentation = null;
			// Interaction_Name.Kind = null;
			Interaction_Name.ClassLazy = () => Interaction;
			Interaction_Declarations.TypeLazy = () => __tmp14;
			Interaction_Declarations.Name = "Declarations";
			Interaction_Declarations.Documentation = null;
			Interaction_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Interaction_Declarations.ClassLazy = () => Interaction;
			Declaration.MetaModelLazy = () => __tmp3;
			Declaration.NamespaceLazy = () => __tmp2;
			Declaration.Documentation = null;
			Declaration.Name = "Declaration";
			// Declaration.IsAbstract = null;
			Lifeline.MetaModelLazy = () => __tmp3;
			Lifeline.NamespaceLazy = () => __tmp2;
			Lifeline.Documentation = null;
			Lifeline.Name = "Lifeline";
			// Lifeline.IsAbstract = null;
			Lifeline.SuperClasses.AddLazy(() => Declaration);
			Lifeline.Properties.AddLazy(() => Lifeline_Name);
			Lifeline_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Lifeline_Name.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.NameAttribute.ToMutable());
			Lifeline_Name.Name = "Name";
			Lifeline_Name.Documentation = null;
			// Lifeline_Name.Kind = null;
			Lifeline_Name.ClassLazy = () => Lifeline;
			MessageKind.MetaModelLazy = () => __tmp3;
			MessageKind.NamespaceLazy = () => __tmp2;
			MessageKind.Documentation = null;
			MessageKind.Name = "MessageKind";
			MessageKind.EnumLiterals.AddLazy(() => __tmp4);
			MessageKind.EnumLiterals.AddLazy(() => __tmp5);
			MessageKind.EnumLiterals.AddLazy(() => __tmp11);
			MessageKind.EnumLiterals.AddLazy(() => __tmp12);
			__tmp4.TypeLazy = () => MessageKind;
			__tmp4.Name = "Sync";
			__tmp4.Documentation = null;
			__tmp4.EnumLazy = () => MessageKind;
			__tmp5.TypeLazy = () => MessageKind;
			__tmp5.Name = "Async";
			__tmp5.Documentation = null;
			__tmp5.EnumLazy = () => MessageKind;
			__tmp11.TypeLazy = () => MessageKind;
			__tmp11.Name = "Return";
			__tmp11.Documentation = null;
			__tmp11.EnumLazy = () => MessageKind;
			__tmp12.TypeLazy = () => MessageKind;
			__tmp12.Name = "Create";
			__tmp12.Documentation = null;
			__tmp12.EnumLazy = () => MessageKind;
			Message.MetaModelLazy = () => __tmp3;
			Message.NamespaceLazy = () => __tmp2;
			Message.Documentation = null;
			Message.Name = "Message";
			// Message.IsAbstract = null;
			Message.SuperClasses.AddLazy(() => Declaration);
			Message.Properties.AddLazy(() => Message_Kind);
			Message.Properties.AddLazy(() => Message_Text);
			Message.Properties.AddLazy(() => Message_Source);
			Message.Properties.AddLazy(() => Message_Target);
			Message_Kind.TypeLazy = () => MessageKind;
			Message_Kind.Name = "Kind";
			Message_Kind.Documentation = null;
			// Message_Kind.Kind = null;
			Message_Kind.ClassLazy = () => Message;
			Message_Text.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Message_Text.Name = "Text";
			Message_Text.Documentation = null;
			// Message_Text.Kind = null;
			Message_Text.ClassLazy = () => Message;
			Message_Source.TypeLazy = () => Lifeline;
			Message_Source.Name = "Source";
			Message_Source.Documentation = null;
			// Message_Source.Kind = null;
			Message_Source.ClassLazy = () => Message;
			Message_Target.TypeLazy = () => Lifeline;
			Message_Target.Name = "Target";
			Message_Target.Documentation = null;
			// Message_Target.Kind = null;
			Message_Target.ClassLazy = () => Message;
			Destroy.MetaModelLazy = () => __tmp3;
			Destroy.NamespaceLazy = () => __tmp2;
			Destroy.Documentation = null;
			Destroy.Name = "Destroy";
			// Destroy.IsAbstract = null;
			Destroy.SuperClasses.AddLazy(() => Declaration);
			Destroy.Properties.AddLazy(() => Destroy_Lifeline);
			Destroy_Lifeline.TypeLazy = () => Lifeline;
			Destroy_Lifeline.Name = "Lifeline";
			Destroy_Lifeline.Documentation = null;
			// Destroy_Lifeline.Kind = null;
			Destroy_Lifeline.ClassLazy = () => Destroy;
			FragmentKind.MetaModelLazy = () => __tmp3;
			FragmentKind.NamespaceLazy = () => __tmp2;
			FragmentKind.Documentation = null;
			FragmentKind.Name = "FragmentKind";
			FragmentKind.EnumLiterals.AddLazy(() => __tmp6);
			FragmentKind.EnumLiterals.AddLazy(() => __tmp7);
			FragmentKind.EnumLiterals.AddLazy(() => __tmp8);
			FragmentKind.EnumLiterals.AddLazy(() => __tmp9);
			FragmentKind.EnumLiterals.AddLazy(() => __tmp10);
			__tmp6.TypeLazy = () => FragmentKind;
			__tmp6.Name = "Loop";
			__tmp6.Documentation = null;
			__tmp6.EnumLazy = () => FragmentKind;
			__tmp7.TypeLazy = () => FragmentKind;
			__tmp7.Name = "Opt";
			__tmp7.Documentation = null;
			__tmp7.EnumLazy = () => FragmentKind;
			__tmp8.TypeLazy = () => FragmentKind;
			__tmp8.Name = "Alt";
			__tmp8.Documentation = null;
			__tmp8.EnumLazy = () => FragmentKind;
			__tmp9.TypeLazy = () => FragmentKind;
			__tmp9.Name = "Else";
			__tmp9.Documentation = null;
			__tmp9.EnumLazy = () => FragmentKind;
			__tmp10.TypeLazy = () => FragmentKind;
			__tmp10.Name = "Ref";
			__tmp10.Documentation = null;
			__tmp10.EnumLazy = () => FragmentKind;
			Fragment.MetaModelLazy = () => __tmp3;
			Fragment.NamespaceLazy = () => __tmp2;
			Fragment.Documentation = null;
			Fragment.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Fragment.Name = "Fragment";
			// Fragment.IsAbstract = null;
			Fragment.SuperClasses.AddLazy(() => Declaration);
			Fragment.Properties.AddLazy(() => Fragment_Kind);
			Fragment.Properties.AddLazy(() => Fragment_Text);
			Fragment.Properties.AddLazy(() => Fragment_Declarations);
			Fragment_Kind.TypeLazy = () => FragmentKind;
			Fragment_Kind.Name = "Kind";
			Fragment_Kind.Documentation = null;
			// Fragment_Kind.Kind = null;
			Fragment_Kind.ClassLazy = () => Fragment;
			Fragment_Text.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Fragment_Text.Name = "Text";
			Fragment_Text.Documentation = null;
			// Fragment_Text.Kind = null;
			Fragment_Text.ClassLazy = () => Fragment;
			Fragment_Declarations.TypeLazy = () => __tmp15;
			Fragment_Declarations.Name = "Declarations";
			Fragment_Declarations.Documentation = null;
			Fragment_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Fragment_Declarations.ClassLazy = () => Fragment;
			MultiFragment.MetaModelLazy = () => __tmp3;
			MultiFragment.NamespaceLazy = () => __tmp2;
			MultiFragment.Documentation = null;
			MultiFragment.Name = "MultiFragment";
			// MultiFragment.IsAbstract = null;
			MultiFragment.SuperClasses.AddLazy(() => Declaration);
			MultiFragment.Properties.AddLazy(() => MultiFragment_Fragments);
			MultiFragment_Fragments.TypeLazy = () => __tmp13;
			MultiFragment_Fragments.Name = "Fragments";
			MultiFragment_Fragments.Documentation = null;
			MultiFragment_Fragments.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			MultiFragment_Fragments.ClassLazy = () => MultiFragment;
			RefFragment.MetaModelLazy = () => __tmp3;
			RefFragment.NamespaceLazy = () => __tmp2;
			RefFragment.Documentation = null;
			RefFragment.Name = "RefFragment";
			// RefFragment.IsAbstract = null;
			RefFragment.SuperClasses.AddLazy(() => Fragment);
			RefFragment.SuperClasses.AddLazy(() => Lifeline);
			RefFragment.Properties.AddLazy(() => RefFragment_Input);
			RefFragment.Properties.AddLazy(() => RefFragment_Output);
			RefFragment_Input.TypeLazy = () => Message;
			RefFragment_Input.Name = "Input";
			RefFragment_Input.Documentation = null;
			// RefFragment_Input.Kind = null;
			RefFragment_Input.ClassLazy = () => RefFragment;
			RefFragment_Output.TypeLazy = () => Message;
			RefFragment_Output.Name = "Output";
			RefFragment_Output.Documentation = null;
			// RefFragment_Output.Kind = null;
			RefFragment_Output.ClassLazy = () => RefFragment;
			__tmp3.Name = "Uml";
			__tmp3.Documentation = null;
			__tmp3.Uri = null;
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp13.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp13.InnerTypeLazy = () => Fragment;
			__tmp14.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp14.InnerTypeLazy = () => Declaration;
			__tmp15.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp15.InnerTypeLazy = () => Declaration;
	
			foreach (global::MetaDslx.Modeling.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::WebSequenceDiagramsModel.Symbols.Internal.UmlImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class UmlImplementationBase
	{
		/// <summary>
		/// Implements the constructor: UmlBuilderInstance()
		/// </summary>
		internal virtual void UmlBuilderInstance(UmlBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: Interaction()
		/// </summary>
		public virtual void Interaction(InteractionBuilder _this)
		{
			this.CallInteractionSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Interaction
		/// </summary>
		protected virtual void CallInteractionSuperConstructors(InteractionBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Declaration()
		/// </summary>
		public virtual void Declaration(DeclarationBuilder _this)
		{
			this.CallDeclarationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Declaration
		/// </summary>
		protected virtual void CallDeclarationSuperConstructors(DeclarationBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Lifeline()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Lifeline(LifelineBuilder _this)
		{
			this.CallLifelineSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Lifeline
		/// </summary>
		protected virtual void CallLifelineSuperConstructors(LifelineBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Message()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Message(MessageBuilder _this)
		{
			this.CallMessageSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Message
		/// </summary>
		protected virtual void CallMessageSuperConstructors(MessageBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Destroy()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Destroy(DestroyBuilder _this)
		{
			this.CallDestroySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Destroy
		/// </summary>
		protected virtual void CallDestroySuperConstructors(DestroyBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Fragment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Fragment(FragmentBuilder _this)
		{
			this.CallFragmentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Fragment
		/// </summary>
		protected virtual void CallFragmentSuperConstructors(FragmentBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: MultiFragment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void MultiFragment(MultiFragmentBuilder _this)
		{
			this.CallMultiFragmentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of MultiFragment
		/// </summary>
		protected virtual void CallMultiFragmentSuperConstructors(MultiFragmentBuilder _this)
		{
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: RefFragment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Fragment</li>
		///     <li>Lifeline</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>Declaration</li>
		///     <li>Lifeline</li>
		///     <li>Fragment</li>
		/// </ul>
		public virtual void RefFragment(RefFragmentBuilder _this)
		{
			this.CallRefFragmentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RefFragment
		/// </summary>
		protected virtual void CallRefFragmentSuperConstructors(RefFragmentBuilder _this)
		{
			this.Declaration(_this);
			this.Lifeline(_this);
			this.Fragment(_this);
		}
	
	
	
	}

	internal class UmlImplementationProvider
	{
		// If there is a compile error at this line, create a new class called UmlImplementation
		// which is a subclass of global::WebSequenceDiagramsModel.Symbols.Internal.UmlImplementationBase:
		private static UmlImplementation implementation = new UmlImplementation();
	
		public static UmlImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
