using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{

    /*public class MetaModelCompilerPropertyEvaluator : MetaCompilerPropertyEvaluator, IMetaModelParserVisitor<object>
    {
        public MetaModelCompilerPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }

        public override object VisitAssociationDeclaration(MetaModelParser.AssociationDeclarationContext context)
        {
            Lazy<object> value = new Lazy<object>(() => this.GetValue(context.source, "Opposites"));
            this.SetValue(context.source, "Opposites", new Lazy<object>(() => this.Symbol(context.target)));
            return null;
        }
    }*/
}
