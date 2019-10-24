using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Languages.Ecore.Model
{
    /// <summary>
    /// Conversion between Ecore models and other models.
    /// </summary>
    public static class EcoreModelConverter
    {
        public static ImmutableModel ToMetaModel(ImmutableModel ecoreModel)
        {
            return new EcoreToMetaConverter(ecoreModel).Convert();
        }

        /*public ImmutableModel FromMetaModel(ImmutableModel metaModel)
        {

        }

        public ImmutableModel ToMofModel(ImmutableModel model)
        {

        }

        public ImmutableModel FromMofModel(ImmutableModel model)
        {

        }

        public ImmutableModel ToUmlModel(ImmutableModel model)
        {

        }

        public ImmutableModel FromUmlModel(ImmutableModel model)
        {

        }*/
    }

    internal class EcoreToMetaConverter
    {
        private ImmutableModel _ecore;
        private MutableModel _meta;
        private MetaFactory _factory;
        private DiagnosticBag _diagnostics;
        private Dictionary<ImmutableObject, MutableObject> _map;

        public EcoreToMetaConverter(ImmutableModel ecore)
        {
            _ecore = ecore;
            _meta = new MutableModel();
            _factory = new MetaFactory(_meta);
            _diagnostics = new DiagnosticBag();
            _map = new Dictionary<ImmutableObject, MutableObject>();
        }

        public ImmutableModel Convert()
        {
            foreach (var epkg in _ecore.Objects.OfType<EPackage>().Where(p => p.ESuperPackage == null))
            {
                ConvertPackage(null, epkg);
            }
            return _meta.ToImmutable();
        }

        private void ConvertPackage(MetaNamespaceBuilder parentNs, EPackage epkg)
        {
            var mns = _factory.MetaNamespace();
            mns.Name = epkg.Name.ToPascalCase();
            mns.Namespace = parentNs;
            _map.Add(epkg, mns);
            if (epkg.NsURI != null)
            {
                var metaModel = _factory.MetaModel();
                metaModel.Name = epkg.Name.ToPascalCase();
                metaModel.Prefix = epkg.NsPrefix;
                metaModel.Uri = epkg.NsURI;
                mns.DefinedMetaModel = metaModel;
            }
            foreach (var childEpgk in epkg.ESubPackages)
            {
                ConvertPackage(mns, childEpgk);
            }
            foreach (var childClsf in epkg.EClassifiers)
            {
                ConvertClassifier(mns, childClsf);
            }
            BindSuperClasses();
            BindTypedElements();
            CreateAssociations();
        }

        private void ConvertClassifier(MetaNamespaceBuilder parentNs, EClassifier eclsf)
        {
            if (eclsf is EClass ecls) ConvertClass(parentNs, ecls);
            else if (eclsf is EEnum eenm) ConvertEnum(parentNs, eenm);
            else if (eclsf is EDataType edt) ConvertDataType(parentNs, edt);
            else _diagnostics.Add(ModelErrorCode.ERR_ModelConversionError.ToDiagnosticWithNoLocation(string.Format("Unknown EClassifier type: {0}", eclsf.GetType())));
        }

        private void ConvertDataType(MetaNamespaceBuilder parentNs, EDataType edt)
        {
            /*var mcst = _factory.MetaConstant();
            parentNs.Declarations.Add(mcst);
            _map.Add(edt, mcst);*/
            var mpt = _factory.MetaPrimitiveType();
            mpt.Name = edt.Name;
            parentNs.Declarations.Add(mpt);
            _map.Add(edt, mpt);
        }

        private void ConvertEnum(MetaNamespaceBuilder parentNs, EEnum eenm)
        {
            var menm = _factory.MetaEnum();
            menm.Name = eenm.Name.ToPascalCase();
            parentNs.Declarations.Add(menm);
            _map.Add(eenm, menm);
            foreach (var elit in eenm.ELiterals)
            {
                var mlit = _factory.MetaEnumLiteral();
                mlit.Name = elit.Name.ToPascalCase();
                menm.EnumLiterals.Add(mlit);
                _map.Add(elit, mlit);
            }
        }

        private void ConvertClass(MetaNamespaceBuilder parentNs, EClass ecls)
        {
            var mcls = _factory.MetaClass();
            mcls.Name = ecls.Name.ToPascalCase();
            mcls.IsAbstract = ecls.Abstract || ecls.Interface;
            parentNs.Declarations.Add(mcls);
            _map.Add(ecls, mcls);
            foreach (var eprop in ecls.EStructuralFeatures)
            {
                ConvertProperty(mcls, eprop);
            }
            foreach (var eop in ecls.EOperations)
            {
                ConvertOperation(mcls, eop);
            }
        }

        private void ConvertProperty(MetaClassBuilder mcls, EStructuralFeature eprop)
        {
            var mprop = _factory.MetaProperty();
            mprop.Name = eprop.Name.ToPascalCase();
            mcls.Properties.Add(mprop);
            _map.Add(eprop, mprop);
            if (eprop.Derived) mprop.Kind = MetaPropertyKind.Derived;
            else if (eprop.Unsettable || !eprop.Changeable) mprop.Kind = MetaPropertyKind.Readonly;
            mprop.DefaultValue = eprop.DefaultValueLiteral;
            if (eprop is EAttribute eattr)
            {
                if (eattr.ID && eattr.EType == EcoreInstance.EString)
                {
                    mprop.Attributes.Add(MetaInstance.NameAttribute.ToMutable());
                }
            }
            else if (eprop is EReference eref)
            {
                mprop.IsContainment = eref.Containment;
            }
        }

        private void ConvertOperation(MetaClassBuilder mcls, EOperation eop)
        {
            var mop = _factory.MetaOperation();
            mop.Name = eop.Name.ToPascalCase();
            mcls.Operations.Add(mop);
            _map.Add(eop, mop);
            foreach (var eparam in eop.EParameters)
            {
                var mparam = _factory.MetaParameter();
                mparam.Name = eparam.Name.ToCamelCase();
                mop.Parameters.Add(mparam);
                _map.Add(eparam, mparam);
            }
        }

        private void BindSuperClasses()
        {
            foreach (var entry in _map.Where(e => e.Key is EClass))
            {
                var ecls = (EClass)entry.Key;
                var mcls = (MetaClassBuilder)entry.Value;
                foreach (var esup in ecls.ESuperTypes)
                {
                    if (_map.TryGetValue(esup, out var msup))
                    {
                        mcls.SuperClasses.Add((MetaClassBuilder)msup);
                    }
                }
            }
        }

        private void BindTypedElements()
        {
            foreach (var entry in _map.Where(e => e.Key is ETypedElement).ToList())
            {
                var ete = (ETypedElement)entry.Key;
                var mtype = GetType(ete);
                if (entry.Value is MetaPropertyBuilder mprop)
                {
                    mprop.Type = mtype;
                }
                else if (entry.Value is MetaParameterBuilder mparam)
                {
                    mparam.Type = mtype;
                }
                else if (entry.Value is MetaOperationBuilder mop)
                {
                    mop.ReturnType = mtype;
                }
            }
        }

        private MetaTypeBuilder GetType(ETypedElement ete)
        {
            if (_map.TryGetValue(ete.EType, out var mobj))
            {
                var mtype = (MetaTypeBuilder)mobj;
                if (ete.UpperBound < 0 || ete.UpperBound > 1)
                {
                    MetaCollectionKind kind;
                    if (ete.Unique)
                    {
                        if (ete.Ordered) kind = MetaCollectionKind.List;
                        else kind = MetaCollectionKind.Set;
                    }
                    else
                    {
                        if (ete.Ordered) kind = MetaCollectionKind.MultiList;
                        else kind = MetaCollectionKind.MultiSet;
                    }
                    var mcoll = _factory.MetaCollectionType();
                    mcoll.InnerType = mtype;
                    mcoll.Kind = kind;
                    return mcoll;
                }
                else
                {
                    return mtype;
                }
            }
            else if (ete.EType is EDataType edataType)
            {
                var mpt = _factory.MetaPrimitiveType();
                mpt.Name = edataType.Name;
                _map.Add(edataType, mpt);
                return mpt;
            }
            return null;
        }

        private void CreateAssociations()
        {
            var handled = new HashSet<EReference>();
            foreach (var eref in _ecore.Objects.OfType<EReference>())
            {
                if (!handled.Contains(eref))
                {
                    handled.Add(eref);
                    var eopp = eref.EOpposite;
                    if (eopp != null)
                    {
                        handled.Add(eopp);
                        if (_map.TryGetValue(eref, out var mfirst) && _map.TryGetValue(eopp, out var msecond))
                        {
                            var mfirstProp = (MetaPropertyBuilder)mfirst;
                            var msecondProp = (MetaPropertyBuilder)msecond;
                            mfirstProp.OppositeProperties.Add(msecondProp);
                        }
                    }
                }
            }
        }
    }
}
