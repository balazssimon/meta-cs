using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class ModelContext
    {
        internal static Dictionary<Thread, List<ModelContext>> contextStacks = new Dictionary<Thread, List<ModelContext>>();

        private HashSet<ModelObject> instances = new HashSet<ModelObject>();

        internal ModelContext()
        {

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

    public class ModelContextScope : IDisposable
    {
        public ModelContextScope()
        {
            lock (ModelContext.contextStacks)
            {
                List<ModelContext> contextStack = null;
                if (!ModelContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    contextStack = new List<ModelContext>();
                    ModelContext.contextStacks.Add(Thread.CurrentThread, contextStack);
                }
                contextStack.Add(new ModelContext());
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
