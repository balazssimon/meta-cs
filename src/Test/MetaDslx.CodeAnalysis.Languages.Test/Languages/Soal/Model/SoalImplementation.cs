using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Languages.Test.Languages.Soal.Model
{
    using Internal;

    public class SoalAnnotations
    {
        public const string All = "All";
        public const string Choice = "Choice";
        public const string NoWrap = "NoWrap";
        public const string Rpc = "Rpc";
        public const string Enum = "Enum";
        public const string Type = "Type";
        public const string Element = "Element";
        public const string Attribute = "Attribute";
        public const string Restriction = "Restriction";
    }

    public class SoalAnnotationProperties
    {
        public const string Wrapped = "wrapped";
        public const string Items = "items";
        public const string Sap = "sap";
        public const string Name = "name";
        public const string Optional = "optional";
        public const string Required = "required";
        public const string Pattern = "pattern";
        public const string Length = "length";
        public const string MinLength = "minLength";
        public const string MaxLength = "maxLength";
        public const string MaxExclusive = "maxExclusive";
        public const string MinExclusive = "minExclusive";
        public const string MaxInclusive = "maxInclusive";
        public const string MinInclusive = "minInclusive";
        public const string TotalDigits = "totalDigits";
        public const string FractionDigits = "fractionDigits";

    }

    internal class SoalImplementation : SoalImplementationBase
    {
        internal override void SoalBuilderInstance(SoalBuilderInstance _this)
        {
            base.SoalBuilderInstance(_this);
            SoalFactory f = new SoalFactory(_this.MModel);
            _this.Object = f.PrimitiveType();
            _this.Object.Name = "object";
            _this.String = f.PrimitiveType();
            _this.String.Name = "string";
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
        }

        public override ImmutableModelList<string> DocumentedElement_GetDocumentationLines(DocumentedElement _this)
        {
            return ImmutableModelList<string>.Empty;
        }

        public override string Declaration_ComputeProperty_FullName(DeclarationBuilder _this)
        {
            if (_this.Namespace == null) return _this.Name;
            else return _this.Namespace.FullName + "." + _this.Name;
        }
    }

}
