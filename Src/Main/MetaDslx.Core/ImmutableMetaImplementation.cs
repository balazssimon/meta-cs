using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    //*
    internal class MetaImplementation : MetaImplementationBase
    {
        public override void MetaBuilderInstance(MetaBuilderInstance _this, MutableModel model)
        {
            MetaFactory f = new Immutable.MetaFactory(model);
            _this.Object = f.MetaPrimitiveType();
            _this.Object.Name = "object";
            _this.String = f.MetaPrimitiveType();
            _this.String.Name = "string";
            _this.Int = f.MetaPrimitiveType();
            _this.Int.Name = "int";
            _this.Long = f.MetaPrimitiveType();
            _this.Long.Name = "long";
            _this.Float = f.MetaPrimitiveType();
            _this.Float.Name = "float";
            _this.Double = f.MetaPrimitiveType();
            _this.Double.Name = "double";
            _this.Byte = f.MetaPrimitiveType();
            _this.Byte.Name = "byte";
            _this.Bool = f.MetaPrimitiveType();
            _this.Bool.Name = "bool";
            _this.Void = f.MetaPrimitiveType();
            _this.Void.Name = "void";
        }
    }
    //*/
}
