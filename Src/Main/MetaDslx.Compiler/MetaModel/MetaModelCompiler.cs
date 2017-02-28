﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using MetaDslx.Languages.Meta.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{

    public class MetaModelCompiler : MetaModelCompilerBase
    {
        public MetaModelCompiler(string source, string fileName)
            : base(source, fileName)
        {
            MutableModel metaInstance = MetaInstance.Model.ToMutable(true);
            this.ModelGroup.AddReference(metaInstance);
            foreach (var type in MetaConstants.Types)
            {
                this.GlobalScope.Declarations.Add(type.ToMutable(metaInstance));
            }
        }

    }


}