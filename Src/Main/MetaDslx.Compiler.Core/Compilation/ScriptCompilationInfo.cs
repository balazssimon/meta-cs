using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public abstract class ScriptCompilationInfo
    {
        public Type ReturnType { get; }
        public Type GlobalsType { get; }

        internal ScriptCompilationInfo(Type returnType, Type globalsType)
        {
            ReturnType = returnType ?? typeof(object);
            GlobalsType = globalsType;
        }

        public Compilation PreviousScriptCompilation => CommonPreviousScriptCompilation;
        internal abstract Compilation CommonPreviousScriptCompilation { get; }

        public ScriptCompilationInfo WithPreviousScriptCompilation(Compilation compilation) => CommonWithPreviousScriptCompilation(compilation);
        internal abstract ScriptCompilationInfo CommonWithPreviousScriptCompilation(Compilation compilation);
    }
}
