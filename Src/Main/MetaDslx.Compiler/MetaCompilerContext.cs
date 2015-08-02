using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class MetaCompilerContext
    {
        internal static Dictionary<Thread, List<MetaCompilerContext>> contextStacks = new Dictionary<Thread, List<MetaCompilerContext>>();

        internal MetaCompilerContext()
        {

        }

        public static MetaCompilerContext Current
        {
            get
            {
                lock (MetaCompilerContext.contextStacks)
                {
                    List<MetaCompilerContext> contextStack = null;
                    if (MetaCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
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

        public MetaCompiler Compiler { get; internal set; }

    }

    public class MetaCompilerContextScope : IDisposable
    {
        public MetaCompilerContextScope(MetaCompiler compiler)
        {
            lock (MetaCompilerContext.contextStacks)
            {
                List<MetaCompilerContext> contextStack = null;
                if (!MetaCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
                {
                    contextStack = new List<MetaCompilerContext>();
                    MetaCompilerContext.contextStacks.Add(Thread.CurrentThread, contextStack);
                }
                MetaCompilerContext ctx = new MetaCompilerContext();
                contextStack.Add(ctx);
                ctx.Compiler = compiler;
            }
        }

        public void Dispose()
        {
            lock (MetaCompilerContext.contextStacks)
            {
                List<MetaCompilerContext> contextStack = null;
                if (MetaCompilerContext.contextStacks.TryGetValue(Thread.CurrentThread, out contextStack))
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
