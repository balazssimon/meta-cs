// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;

namespace MetaDslx.Languages.Meta
{
    public class MetaScriptCompilationInfo : ScriptCompilationInfo
    {
        public new MetaCompilation PreviousScriptCompilation { get; }

        internal MetaScriptCompilationInfo(MetaCompilation previousCompilationOpt, Type returnType, Type globalsType)
            : base(returnType, globalsType)
        {
            Debug.Assert(previousCompilationOpt == null || previousCompilationOpt.HostObjectType == globalsType);

            PreviousScriptCompilation = previousCompilationOpt;
        }

        protected override Compilation CommonPreviousScriptCompilation => PreviousScriptCompilation;

        public MetaScriptCompilationInfo WithPreviousScriptCompilation(MetaCompilation compilation) =>
            (compilation == PreviousScriptCompilation) ? this : new MetaScriptCompilationInfo(compilation, ReturnType, GlobalsType);

        protected override ScriptCompilationInfo CommonWithPreviousScriptCompilation(Compilation compilation) =>
            WithPreviousScriptCompilation((MetaCompilation)compilation);
    }
}

