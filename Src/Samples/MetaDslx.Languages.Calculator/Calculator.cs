using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Languages.Calculator
{
	using global::MetaDslx.Languages.Calculator.Internal;

	public class CalculatorInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return CalculatorInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaModel MetaModel;
		public static readonly global::MetaDslx.Core.ImmutableModel Model;
	
	
	
		static CalculatorInstance()
		{
			CalculatorBuilderInstance.instance.Create();
			CalculatorBuilderInstance.instance.EvaluateLazyValues();
			MetaModel = CalculatorBuilderInstance.instance.MetaModel.ToImmutable();
			Model = CalculatorBuilderInstance.instance.Model.ToImmutable();
	
	
	
			CalculatorInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class CalculatorFactory : global::MetaDslx.Core.ModelFactory
	{
		public CalculatorFactory(global::MetaDslx.Core.MutableModel model, global::MetaDslx.Core.ModelFactoryFlags flags = global::MetaDslx.Core.ModelFactoryFlags.None)
			: base(model, flags)
		{
			CalculatorDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Core.MutableSymbol Create(string type)
		{
			switch (type)
			{
				default:
					throw new global::MetaDslx.Core.ModelException(global::MetaDslx.Compiler.Diagnostics.Location.None, new global::MetaDslx.Compiler.Diagnostics.DiagnosticInfo(global::MetaDslx.Core.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	}
	


	public static class CalculatorDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty> properties;
	
		static CalculatorDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty>();
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://MetaDslx.Languages.Calculator/1.0";
	}
}

namespace MetaDslx.Languages.Calculator.Internal
{

	internal class CalculatorBuilderInstance
	{
		internal static CalculatorBuilderInstance instance = new CalculatorBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder MetaModel;
		internal global::MetaDslx.Core.MutableModel Model;
		internal global::MetaDslx.Core.MutableModelGroup ModelGroup;
	
	
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder __tmp4;
	
		internal CalculatorBuilderInstance()
		{
			this.ModelGroup = new global::MetaDslx.Core.MutableModelGroup();
			this.ModelGroup.AddReference(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Model.ToMutable(true));
			this.Model = this.ModelGroup.CreateModel("Calculator");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			CalculatorImplementationProvider.Implementation.CalculatorBuilderInstance(this);
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
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Core.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaModel();
			MetaModel = __tmp4;
	
			// __tmp1.MetaModel = null;
			// __tmp1.Namespace = null;
			__tmp1.Documentation = null;
			__tmp1.Name = "MetaDslx";
			// __tmp1.MetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			// __tmp2.MetaModel = null;
			__tmp2.NamespaceLazy = () => __tmp1;
			__tmp2.Documentation = null;
			__tmp2.Name = "Languages";
			// __tmp2.MetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			// __tmp3.MetaModel = null;
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp3.Documentation = null;
			__tmp3.Name = "Calculator";
			__tmp3.MetaModelLazy = () => __tmp4;
			__tmp4.Name = "Calculator";
			__tmp4.Documentation = null;
			__tmp4.Uri = "http://MetaDslx.Languages.Calculator/1.0";
			__tmp4.NamespaceLazy = () => __tmp3;
	
			foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Languages.Calculator.Internal.CalculatorImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class CalculatorImplementationBase
	{
		/// <summary>
		/// Implements the constructor: CalculatorBuilderInstance()
		/// </summary>
		internal virtual void CalculatorBuilderInstance(CalculatorBuilderInstance _this)
		{
		}
	}

	internal class CalculatorImplementationProvider
	{
		// If there is a compile error at this line, create a new class called CalculatorImplementation
		// which is a subclass of global::MetaDslx.Languages.Calculator.Internal.CalculatorImplementationBase:
		private static CalculatorImplementation implementation = new CalculatorImplementation();
	
		public static CalculatorImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
