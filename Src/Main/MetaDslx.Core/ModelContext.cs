using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class Model
    {
        private HashSet<ModelObject> instances = new HashSet<ModelObject>();

        public IEnumerable<ModelObject> Instances
        {
            get
            {
                return this.instances;
            }
        }

        public void AddInstance(ModelObject obj)
        {
            this.instances.Add(obj);
        }

        public void RemoveInstance(ModelObject obj)
        {
            this.instances.Remove(obj);
        }
    }

    public class ModelContext
    {
        internal static Dictionary<Thread, List<ModelContext>> contextStacks = new Dictionary<Thread, List<ModelContext>>();

        private Model model;
        private IModelCompiler compiler;

        internal ModelContext(Model model, IModelCompiler compiler)
        {
            this.model = model;
            this.compiler = compiler;
        }

        public static ModelContext Current
        {
            get
            {
                lock(ModelContext.contextStacks)
                {
                    List<ModelContext> contextStack = null;
                    if (ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                    {
                        if (contextStack.Count > 0)
                        {
                            return contextStack[contextStack.Count - 1];
                        }
                    }
                }
                return null;
            }
        }

        public Model Model
        {
            get { return this.model; }
        }

        public IModelCompiler Compiler
        {
            get { return this.compiler; }
        }
    }

    public class ModelContextScope : IDisposable
    {
        public ModelContextScope(Model model, IModelCompiler compiler = null)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (compiler == null)
            {
                compiler = new DefaultModelCompiler();
            }
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (!ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    contextStack = new List<ModelContext>();
                    ModelContext.contextStacks.Add(Thread.CurrentThread, contextStack);
                }
                contextStack.Add(new ModelContext(model, compiler));
            }
        }

        public ModelContextScope(IModelCompiler compiler)
        {
            if (compiler == null) throw new ArgumentNullException(nameof(compiler));
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (!ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    contextStack = new List<ModelContext>();
                    ModelContext.contextStacks.Add(Thread.CurrentThread, contextStack);
                }
                if (contextStack.Count == 0)
                {
                    contextStack.Add(new ModelContext(new Model(), compiler));
                }
                else
                {
                    contextStack.Add(new ModelContext(contextStack[contextStack.Count-1].Model, compiler));
                }
            }
        }

        public void Dispose()
        {
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    if (contextStack.Count > 0)
                    {
                        contextStack.RemoveAt(contextStack.Count - 1);
                    }
                }
            }
        }
    }
}
