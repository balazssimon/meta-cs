using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;

namespace MetaDslx.Soal
{
    public static class SoalDescriptor
    {
        static SoalDescriptor()
        {
            Namespace.StaticInit();
        }
    
        internal static void StaticInit()
        {
        }
    
    	public const string Uri = "http://MetaDslx.Soal/1.0";
    
        
        public static class Namespace
        {
            internal static void StaticInit()
            {
            }
        
            static Namespace()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Namespace; }
            }
        
        }
    }
    
	public static class SoalInstance
	{
	    private static global::MetaDslx.Core.Model model;
	
	    public static global::MetaDslx.Core.Model Model
	    {
	        get { return SoalInstance.model; }
	    }
	
	    public static readonly global::MetaDslx.Core.MetaModel Meta;
	
	
		
		public static readonly global::MetaDslx.Core.MetaClass Namespace;
	
	
	    static SoalInstance()
	    {
			SoalDescriptor.StaticInit();
			SoalInstance.model = new global::MetaDslx.Core.Model();
	   		using (new ModelContextScope(SoalInstance.model))
			{
	
				global::MetaDslx.Core.MetaNamespace tmp1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaNamespace tmp2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaModel tmp3 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaModel();
				Meta = tmp3;
				Namespace = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
	
				
				
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty, new Lazy<object>(() => tmp2));
				
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "MetaDslx"));
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => null));
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => null));
				
				
				
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soal"));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => tmp1));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => tmp3));
				
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soal"));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty, new Lazy<object>(() => "http://MetaDslx.Soal/1.0"));
				
				
				
				
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
	
	            foreach (var mo in ModelContext.Current.Model.Instances)
	            {
	                mo.MEvalLazyValues();
	            }
			}
	    }
	}
    
    public interface Namespace
    {
    
    }
    
    internal class NamespaceImpl : ModelObject, global::MetaDslx.Soal.Namespace
    {
        static NamespaceImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Namespace; }
        }
    
        public NamespaceImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Namespace_Namespace(this);
            this.MMakeDefault();
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class SoalFactory : ModelFactory
    {
        private static SoalFactory instance = new SoalFactory();
    
    	private SoalFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static SoalFactory Instance
        {
            get { return SoalFactory.instance; }
        }
    
        /// <summary>
        /// Creates a new instance of Namespace.
        /// </summary>
        public Namespace CreateNamespace(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Namespace result = new global::MetaDslx.Soal.NamespaceImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    }
    
    internal static class SoalImplementationProvider
    {
        // If there is a compile error at this line, create a new class called SoalImplementation
    	// which is a subclass of SoalImplementationBase:
        private static SoalImplementation implementation = new SoalImplementation();
    
        public static SoalImplementation Implementation
        {
            get { return SoalImplementationProvider.implementation; }
        }
    }
    
    /// <summary>
    /// Base class for implementing the behavior of the model elements.
    /// This class has to be be overriden in SoalImplementation to provide custom
    /// implementation for the constructors, operations and property values.
    /// </summary>
    internal abstract class SoalImplementationBase
    {
        /// <summary>
    	/// Implements the constructor: Namespace()
        /// </summary>
        public virtual void Namespace_Namespace(Namespace @this)
        {
        }
    
    }
    
}
