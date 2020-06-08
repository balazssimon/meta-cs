using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace PilV2.Symbols
{
    public static class PilConstants
    {
        private static ImmutableList<IModelObject> types = ImmutableList<IModelObject>.Empty;

        public static ImmutableList<IModelObject> Types
        {
            get
            {
                if (PilConstants.types.Count == 0 && PilInstance.IsInitialized)
                {
                    ImmutableList<IModelObject>.Builder typesBuilder = ImmutableList.CreateBuilder<IModelObject>();
                    typesBuilder.Add(PilInstance.Object);
                    typesBuilder.Add(PilInstance.String);
                    typesBuilder.Add(PilInstance.Int);
                    typesBuilder.Add(PilInstance.Bool);
                    Interlocked.Exchange(ref PilConstants.types, typesBuilder.ToImmutable());
                }
                return PilConstants.types;
            }
        }
    }
}

namespace PilV2.Symbols.Internal
{
    class PilImplementation : PilImplementationBase
    {
        internal override void PilBuilderInstance(PilBuilderInstance _this)
        {
            base.PilBuilderInstance(_this);
            /*var factory = new PilFactory(_this.MModel);
            _this.Bool = factory.NamedType();
            _this.Bool.Name = "bool";
            _this.String = factory.NamedType();
            _this.String.Name = "string";
            _this.Int = factory.NamedType();
            _this.Int.Name = "int";
            _this.Object = factory.NamedType();
            _this.Object.Name = "object";*/
        }
    }
}