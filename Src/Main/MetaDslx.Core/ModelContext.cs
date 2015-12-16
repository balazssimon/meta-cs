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

        public IEnumerable<ModelObject> InstancesCopy
        {
            get
            {
                return this.instances.ToList();
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

        public void EvalLazyValues()
        {
            int oldCount = -1;
            while (oldCount != this.instances.Count)
            {
                oldCount = this.instances.Count;
                foreach (var mo in this.InstancesCopy)
                {
                    mo.MEvalLazyValues();
                }
            }
        }
    }

    public class ModelContext
    {
        internal static Dictionary<Thread, List<ModelContext>> contextStacks = new Dictionary<Thread, List<ModelContext>>();

        private Model model;

        internal ModelContext(Model model)
        {
            this.model = model;
        }

        public static Model Current
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
                            return contextStack[contextStack.Count - 1].model;
                        }
                    }
                }
                return null;
            }
        }

        public static bool HasContext()
        {
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    return contextStack.Count > 0;
                }
            }
            return false;
        }

        public static void RequireContext()
        {
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    if (contextStack.Count <= 0)
                    {
                        throw new ModelException("ModelContext is missing. Try running this operation within a ModelContextScope.");
                    }
                }
            }
        }
    }

    public class ModelCompilerContext
    {
        internal static Dictionary<Thread, List<ModelCompilerContext>> contextStacks = new Dictionary<Thread, List<ModelCompilerContext>>();

        private static DefaultModelCompiler defaultCompiler = new DefaultModelCompiler();

        private IModelCompiler compiler;

        internal ModelCompilerContext(IModelCompiler compiler)
        {
            this.compiler = compiler;
        }

        public static IModelCompiler Current
        {
            get
            {
                lock (ModelCompilerContext.contextStacks)
                {
                    List<ModelCompilerContext> contextStack = null;
                    if (ModelCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                    {
                        if (contextStack.Count > 0)
                        {
                            return contextStack[contextStack.Count - 1].compiler;
                        }
                        else
                        {
                            return ModelCompilerContext.defaultCompiler;
                        }
                    }
                }
                return ModelCompilerContext.defaultCompiler;
            }
        }

        public static bool HasContext()
        {
            lock (ModelCompilerContext.contextStacks)
            {
                List<ModelCompilerContext> contextStack = null;
                if (ModelCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    return contextStack.Count > 0;
                }
            }
            return false;
        }

        public static void RequireContext()
        {
            lock (ModelCompilerContext.contextStacks)
            {
                List<ModelCompilerContext> contextStack = null;
                if (ModelCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    if (contextStack.Count <= 0)
                    {
                        throw new ModelException("ModelCompilerContext is missing. Try running this operation within a ModelCompilerContextScope.");
                    }
                }
            }
        }
    }

    public class ModelContextScope : IDisposable
    {
        public ModelContextScope(Model model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (!ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    contextStack = new List<ModelContext>();
                    ModelContext.contextStacks.Add(Thread.CurrentThread, contextStack);
                }
                contextStack.Add(new ModelContext(model));
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


    public class ModelCompilerContextScope : IDisposable
    {
        public ModelCompilerContextScope(IModelCompiler compiler)
        {
            if (compiler == null) throw new ArgumentNullException(nameof(compiler));
            lock (ModelCompilerContext.contextStacks)
            {
                List<ModelCompilerContext> contextStack = null;
                if (!ModelCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    contextStack = new List<ModelCompilerContext>();
                    ModelCompilerContext.contextStacks.Add(Thread.CurrentThread, contextStack);
                }
                contextStack.Add(new ModelCompilerContext(compiler));
            }
        }

        public void Dispose()
        {
            lock (ModelCompilerContext.contextStacks)
            {
                List<ModelCompilerContext> contextStack = null;
                if (ModelCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
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
