// NOTE: This is an auto-generated file. However, it will not be changed or regenerated unless you delete it.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MetaDslx.Languages.MetaCompiler.Model.Internal
{
	/// <summary>
	/// Class for implementing the behavior of the model elements.
	/// </summary>
	internal class MetaCompilerImplementation : MetaCompilerImplementationBase
	{
		/// <summary>
		/// Computes the value of the property: Declaration.FullName
		/// </summary>
		public override string Declaration_ComputeProperty_FullName(DeclarationBuilder _this)
		{
            return _this.Namespace != null ? _this.Namespace.FullName + "." + _this.Name : _this.Name;
        }
	
		/// <summary>
		/// Implements the operation: PrimitiveDataTypeBuilder.ConformsTo()
		/// </summary>
		public override bool PrimitiveType_ConformsTo(PrimitiveTypeBuilder _this, DataTypeBuilder type)
		{
			return default(bool);
		}
	
		/// <summary>
		/// Implements the operation: ClassBuilder.ConformsTo()
		/// </summary>
		public override bool Class_ConformsTo(ClassBuilder _this, DataTypeBuilder type)
		{
			return default(bool);
		}

        public override IReadOnlyList<ClassBuilder> Class_GetAllSuperClasses(ClassBuilder _this, bool includeSelf)
        {
            var result = new List<ClassBuilder>();
            result.Add(_this);
            int i = 0;
            while (i < result.Count)
            {
                ClassBuilder current = result[i];
                foreach (var sup in current.SuperClasses)
                {
                    if (!result.Contains(sup))
                    {
                        result.Add(sup);
                    }
                }
                ++i;
            }
            if (!includeSelf) result.RemoveAt(0);
            result.Reverse();
            return result;
        }

        public override IReadOnlyList<PropertyBuilder> Class_GetAllProperties(ClassBuilder _this, bool includeSelf)
        {
            var result = new List<PropertyBuilder>();
            var supers = _this.GetAllSuperClasses(includeSelf);
            foreach (var sup in supers)
            {
                foreach (var prop in sup.Properties)
                {
                    result.Add(prop);
                }
            }
            return result;
        }

        public override IReadOnlyList<OperationBuilder> Class_GetAllOperations(ClassBuilder _this, bool includeSelf)
        {
            var result = new List<OperationBuilder>();
            var supers = _this.GetAllSuperClasses(includeSelf);
            foreach (var sup in supers)
            {
                foreach (var op in sup.Operations)
                {
                    result.Add(op);
                }
            }
            return result;
        }

        public override IReadOnlyList<PropertyBuilder> Class_GetAllFinalProperties(ClassBuilder _this)
        {
            var props = _this.GetAllProperties(true);
            var result = new List<PropertyBuilder>(props);
            result.Reverse();
            int i = result.Count - 1;
            while (i >= 0)
            {
                var currentProp = result[i];
                PropertyBuilder prop = result.First(p => p.Name == currentProp.Name);
                if (prop != currentProp)
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return result;
        }

        public override IReadOnlyList<OperationBuilder> Class_GetAllFinalOperations(ClassBuilder _this)
        {
            var ops = _this.GetAllOperations(true);
            var result = new List<OperationBuilder>(ops);
            result.Reverse();
            int i = result.Count - 1;
            while (i >= 0)
            {
                var currentOp = result[i];
                OperationBuilder op = result.First(o => o.ConformsTo(currentOp));
                if (op != currentOp)
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return result;
        }

        public override bool DataType_ConformsTo(DataTypeBuilder _this, DataTypeBuilder type)
        {
            return type != null && _this == type;
        }

        /// <summary>
        /// Implements the operation: OperationBuilder.ConformsTo()
        /// </summary>
        public override bool Operation_ConformsTo(OperationBuilder _this, OperationBuilder operation)
		{
            if (operation == null) return false;
            if (_this.Name != operation.Name) return false;
            if (_this.Parameters.Count != operation.Parameters.Count) return false;
            if (_this.Class != null && !_this.Class.ConformsTo(operation.Class)) return false;
            if (_this.Enum != null && !_this.Enum.ConformsTo(operation.Enum)) return false;
            if (!_this.ReturnType.ConformsTo(operation.ReturnType)) return false;
            for (int i = 0; i < _this.Parameters.Count; i++)
            {
                var thisParam = _this.Parameters[i];
                var otherParam = operation.Parameters[i];
                if (!otherParam.Type.ConformsTo(thisParam.Type)) return false;
            }
            return true;
        }
	
		/// <summary>
		/// Implements the operation: PropertyBuilder.ConformsTo()
		/// </summary>
		public override bool Property_ConformsTo(PropertyBuilder _this, PropertyBuilder property)
		{
            if (property == null) return false;
            if (_this.Name != property.Name) return false;
            if (!_this.Class.ConformsTo(property.Class)) return false;
            if (!_this.Type.ConformsTo(property.Type) && !property.Type.ConformsTo(_this.Type)) return false;
            return true;
        }

        public override IReadOnlyList<PhaseBuilder> Symbol_GetPhases(SymbolBuilder _this)
        {
            return _this.Properties.Where(p => p.Phase != null).Select(p => p.Phase).Union(_this.Phases).ToList();
        }

        public override IReadOnlyList<PhaseBuilder> Symbol_GetAllPhases(SymbolBuilder _this, bool includeSelf)
        {
            return _this.GetAllSuperClasses(includeSelf).OfType<SymbolBuilder>().SelectMany(cls => cls.GetPhases()).Distinct().ToList();
        }
    }
}

