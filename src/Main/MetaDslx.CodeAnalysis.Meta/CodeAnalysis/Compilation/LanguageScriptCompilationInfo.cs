// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;
using System;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis
{
    public sealed class LanguageScriptCompilationInfo : ScriptCompilationInfo
    {
        public new LanguageCompilation PreviousScriptCompilation { get; }

        internal LanguageScriptCompilationInfo(LanguageCompilation previousCompilationOpt, Type returnType, Type globalsType)
            : base(returnType, globalsType)
        {
            Debug.Assert(previousCompilationOpt == null || previousCompilationOpt.HostObjectType == globalsType);

            PreviousScriptCompilation = previousCompilationOpt;
        }

        internal override Compilation CommonPreviousScriptCompilation => PreviousScriptCompilation;

        public LanguageScriptCompilationInfo WithPreviousScriptCompilation(LanguageCompilation compilation) =>
            (compilation == PreviousScriptCompilation) ? this : new LanguageScriptCompilationInfo(compilation, ReturnTypeOpt, GlobalsType);

        internal override ScriptCompilationInfo CommonWithPreviousScriptCompilation(Compilation compilation) =>
            WithPreviousScriptCompilation((LanguageCompilation)compilation);
    }
}
