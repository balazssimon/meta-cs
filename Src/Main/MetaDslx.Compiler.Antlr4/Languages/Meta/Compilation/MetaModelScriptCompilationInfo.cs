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
    public class MetaModelScriptCompilationInfo : ScriptCompilationInfo
    {
        public new MetaModelCompilation PreviousScriptCompilation { get; }

        internal MetaModelScriptCompilationInfo(MetaModelCompilation previousCompilationOpt, Type returnType, Type globalsType)
            : base(returnType, globalsType)
        {
            Debug.Assert(previousCompilationOpt == null || previousCompilationOpt.HostObjectType == globalsType);

            PreviousScriptCompilation = previousCompilationOpt;
        }

        protected override Compilation CommonPreviousScriptCompilation => PreviousScriptCompilation;

        public MetaModelScriptCompilationInfo WithPreviousScriptCompilation(MetaModelCompilation compilation) =>
            (compilation == PreviousScriptCompilation) ? this : new MetaModelScriptCompilationInfo(compilation, ReturnType, GlobalsType);

        protected override ScriptCompilationInfo CommonWithPreviousScriptCompilation(Compilation compilation) =>
            WithPreviousScriptCompilation((MetaModelCompilation)compilation);
    }
}

