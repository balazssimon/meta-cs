﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Mof.Model.Internal
{
    class MofImplementation : MofImplementationBase
    {
        internal override void MofBuilderInstance(MofBuilderInstance _this)
        {
            MofFactory f = new MofFactory(_this.Model);
            _this.Boolean = f.PrimitiveType();
            _this.Boolean.Name = "Boolean";
            _this.String = f.PrimitiveType();
            _this.String.Name = "String";
            _this.Integer = f.PrimitiveType();
            _this.Integer.Name = "Integer";
            _this.Real = f.PrimitiveType();
            _this.Real.Name = "Real";
            _this.UnlimitedNatural = f.PrimitiveType();
            _this.UnlimitedNatural.Name = "UnlimitedNatural";
        }
    }
}
