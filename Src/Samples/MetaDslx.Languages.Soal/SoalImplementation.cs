using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Symbols.Internal
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

        public override void Namespace(NamespaceBuilder _this)
        {
            base.Namespace(_this);
            _this.FullNameLazy = () => _this.Namespace == null ? _this.Name : _this.Namespace.FullName + "." + _this.Name;
        }

        public override void PrimitiveType(PrimitiveTypeBuilder _this)
        {
            base.PrimitiveType(_this);
            _this.Nullable = false;
        }

        public override void Operation(OperationBuilder _this)
        {
            base.Operation(_this);
            //_this.ResultLazy = () => new SoalFactory(_this.MModel).OutputParameter();
        }

        public override void Port(PortBuilder _this)
        {
            base.Port(_this);
            _this.NameLazy = () => _this.OptionalName != null ? _this.OptionalName : (_this.MHasConcreteValue(_this.MGetProperty("Interface")) ? _this.Interface.Name : string.Empty);
        }

        public override ImmutableModelList<Annotation> AnnotatedElement_GetAnnotations(AnnotatedElement _this, string name)
        {
            List<Annotation> result = new List<Annotation>();
            if (_this == null) return ImmutableModelList<Annotation>.Empty;
            foreach (var annot in _this.Annotations)
            {
                if (annot.Name == name)
                {
                    result.Add(annot);
                }
            }
            return ImmutableModelList<Annotation>.CreateNonUnique(result);
        }

        public override Annotation AnnotatedElement_GetAnnotation(AnnotatedElement _this, string name)
        {
            return _this.GetAnnotations(name).FirstOrDefault();
        }

        public override bool AnnotatedElement_HasAnnotation(AnnotatedElement _this, string name)
        {
            return _this.GetAnnotation(name) != null;
        }

        public override bool AnnotatedElement_HasAnnotationProperty(AnnotatedElement _this, string annotationName, string propertyName)
        {
            if (_this == null) return false;
            Annotation annot = _this.GetAnnotation(annotationName);
            if (annot != null)
            {
                return annot.HasProperty(propertyName);
            }
            return false;
        }

        public override object AnnotatedElement_GetAnnotationPropertyValue(AnnotatedElement _this, string annotationName, string propertyName)
        {
            if (_this == null) return null;
            Annotation annot = _this.GetAnnotation(annotationName);
            if (annot != null)
            {
                return annot.GetPropertyValue(propertyName);
            }
            return null;
        }

        public override AnnotationProperty Annotation_GetProperty(Annotation _this, string name)
        {
            if (_this == null) return null;
            foreach (var prop in _this.Properties)
            {
                if (prop.Name == name) return prop;
            }
            return null;
        }

        public override bool Annotation_HasProperty(Annotation _this, string name)
        {
            return _this.GetProperty(name) != null;
        }

        public override object Annotation_GetPropertyValue(Annotation _this, string name)
        {
            if (_this == null) return null;
            AnnotationProperty prop = _this.GetProperty(name);
            if (prop != null)
            {
                return prop.Value;
            }
            return null;
        }

    }
}
