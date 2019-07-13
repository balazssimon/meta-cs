/*/
using MetaDslx.Languages.Soal.Symbols.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Soal.Symbols
{

    internal class SoalImplementation : SoalImplementationBase
    {
        internal override void SoalBuilderInstance(SoalBuilderInstance _this)
        {
            base.SoalBuilderInstance(_this);
            SoalFactory f = new SoalFactory(_this.Model);
            _this.Object = f.PrimitiveType();
            _this.Object.Name = "object";
            _this.Object.Nullable = true;
            _this.String = f.PrimitiveType();
            _this.String.Name = "string";
            _this.String.Nullable = true;
            _this.Int = f.PrimitiveType();
            _this.Int.Name = "int";
            _this.Long = f.PrimitiveType();
            _this.Long.Name = "long";
            _this.Float = f.PrimitiveType();
            _this.Float.Name = "float";
            _this.Double = f.PrimitiveType();
            _this.Double.Name = "double";
            _this.Byte = f.PrimitiveType();
            _this.Byte.Name = "byte";
            _this.Bool = f.PrimitiveType();
            _this.Bool.Name = "bool";
            _this.Void = f.PrimitiveType();
            _this.Void.Name = "void";
            _this.Date = f.PrimitiveType();
            _this.Date.Name = "Date";
            _this.Time = f.PrimitiveType();
            _this.Time.Name = "Time";
            _this.DateTime = f.PrimitiveType();
            _this.DateTime.Name = "DateTime";
            _this.TimeSpan = f.PrimitiveType();
            _this.TimeSpan.Name = "TimeSpan";
        }

        public override void Declaration(DeclarationBuilder _this)
        {
            base.Declaration(_this);
            _this.FullNameLazy =
                () =>
                {
                    if (_this.Namespace == null) return _this.Name;
                    else return _this.Namespace.FullName + "." + _this.Name;
                };
        }

        public override void Operation(OperationBuilder _this)
        {
            base.Operation(_this);
            SoalFactory f = new SoalFactory(_this.MModel);
            _this.Result = f.OutputParameter();
        }
    }
}
//*/
