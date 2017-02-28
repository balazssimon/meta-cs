using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Meta.Binding
{
    internal class OppositeBinder : Binder, ICustomBinder
    {
        public OppositeBinder(Binder next, RedNode node)
            : base(next, node)
        {

        }

        public void CustomBind()
        {
            AssociationDeclarationSyntax assocSyntax = this.Node as AssociationDeclarationSyntax;
            if (assocSyntax != null)
            {
                var sourceBinder = this.GetBinder(assocSyntax.Source) as IValueBinder;
                var targetBinder = this.GetBinder(assocSyntax.Target) as IValueBinder;
                if (sourceBinder != null && targetBinder != null)
                {
                    var sourceProperty = sourceBinder.Symbol as MetaPropertyBuilder;
                    var targetProperty = targetBinder.Symbol as MetaPropertyBuilder;
                    if (sourceProperty != null && targetProperty != null)
                    {
                        sourceProperty.OppositeProperties.Add(targetProperty);
                    }
                }
            }
        }
    }
}
