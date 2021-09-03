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

        public static ImmutableModel FromMetaModel(ImmutableModel metaModel)
        {
            return new MetaToEcoreConverter(metaModel).Convert();
        }
        /*
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
            else if (eprop.Unsettable) mprop.Kind = MetaPropertyKind.Readonly;
            else if (!eprop.Changeable) mprop.Kind = MetaPropertyKind.Lazy;
            mprop.DefaultValue = eprop.DefaultValueLiteral;
            if (eprop is EAttribute eattr)
            {
                if (eattr.ID && eattr.EType == EcoreInstance.EString)
                {
                    mprop.SymbolProperty = "Name";
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

    internal class MetaToEcoreConverter
    {
        private ImmutableModel _meta;
        private MutableModel _ecore;
        private EcoreFactory _factory;
        private DiagnosticBag _diagnostics;
        private Dictionary<ImmutableObject, MutableObject> _map;

        public MetaToEcoreConverter(ImmutableModel meta)
        {
            _meta = meta;
            _ecore = new MutableModel();
            _factory = new EcoreFactory(_ecore);
            _diagnostics = new DiagnosticBag();
            _map = new Dictionary<ImmutableObject, MutableObject>();
        }

        public ImmutableModel Convert()
        {
            foreach (var ns in _meta.Objects.OfType<MetaNamespace>().Where(ns => ns.Namespace == null))
            {
                ConvertNamespace(null, ns);
            }
            return _ecore.ToImmutable();
        }

        private void ConvertNamespace(EPackageBuilder parentEpkg, MetaNamespace mns)
        {
            var epkg = _factory.EPackage();
            epkg.Name = mns.Name.ToCamelCase();
            epkg.ESuperPackage = parentEpkg;
            _map.Add(mns, epkg);
            if (mns.DefinedMetaModel?.Uri != null)
            {
                epkg.NsPrefix = mns.DefinedMetaModel.Prefix;
                epkg.NsURI = mns.DefinedMetaModel.Uri;
            }
            foreach (var childNs in mns.Declarations.OfType<MetaNamespace>())
            {
                ConvertNamespace(epkg, childNs);
            }
            foreach (var mtype in mns.Declarations.OfType<MetaType>())
            {
                ConvertType(epkg, mtype);
            }
            BindSuperClasses();
            BindTypedElements(epkg);
            CreateAssociations();
            CreateConstantTypes(epkg, mns);
        }

        private void ConvertType(EPackageBuilder parentEpkg, MetaType mtype)
        {
            if (mtype is MetaClass mcls) ConvertClass(parentEpkg, mcls);
            else if (mtype is MetaEnum menm) ConvertEnum(parentEpkg, menm);
            else if (mtype is MetaPrimitiveType mpt) ConvertPrimitiveType(parentEpkg, mpt);
            else _diagnostics.Add(ModelErrorCode.ERR_ModelConversionError.ToDiagnosticWithNoLocation(string.Format("Unknown MetaType: {0}", mtype.GetType())));
        }

        private void ConvertPrimitiveType(EPackageBuilder parentEpkg, MetaPrimitiveType mpt)
        {
            var edt = _factory.EDataType();
            edt.Name = mpt.Name;
            parentEpkg.EClassifiers.Add(edt);
            _map.Add(mpt, edt);
        }

        private void ConvertEnum(EPackageBuilder parentEpkg, MetaEnum menm)
        {
            var eenm = _factory.EEnum();
            eenm.Name = menm.Name.ToPascalCase();
            parentEpkg.EClassifiers.Add(eenm);
            _map.Add(menm, eenm);
            foreach (var mlit in menm.EnumLiterals)
            {
                var elit = _factory.EEnumLiteral();
                elit.Name = mlit.Name.ToUpper();
                eenm.ELiterals.Add(elit);
                _map.Add(mlit, elit);
            }
        }

        private void ConvertClass(EPackageBuilder parentEpkg, MetaClass mcls)
        {
            var ecls = _factory.EClass();
            ecls.Name = mcls.Name.ToPascalCase();
            ecls.Abstract = mcls.IsAbstract;
            parentEpkg.EClassifiers.Add(ecls);
            _map.Add(mcls, ecls);
            foreach (var mprop in mcls.Properties)
            {
                ConvertProperty(parentEpkg, ecls, mprop);
            }
            foreach (var mop in mcls.Operations)
            {
                ConvertOperation(parentEpkg, ecls, mop);
            }
        }

        private void ConvertProperty(EPackageBuilder parentEpkg, EClassBuilder ecls, MetaProperty mprop)
        {
            EStructuralFeatureBuilder eprop;
            if (mprop.Type is MetaClass || mprop.Type is MetaCollectionType mcoll && mcoll.InnerType is MetaClass)
            {
                eprop = _factory.EReference();
                if (mprop.IsContainment)
                {
                    ((EReferenceBuilder)eprop).Containment = true;
                }
            }
            else
            {
                eprop = _factory.EAttribute();
                if (mprop.SymbolProperty == "Name")
                {
                    ((EAttributeBuilder)eprop).ID = true;
                    eprop.EType = EcoreInstance.EString.ToMutable();
                }
            }
            eprop.Name = mprop.Name.ToCamelCase();
            ecls.EStructuralFeatures.Add(eprop);
            _map.Add(mprop, eprop);
            if (mprop.Kind == MetaPropertyKind.Derived || mprop.Kind == MetaPropertyKind.DerivedUnion) eprop.Derived = true;
            else if (mprop.Kind == MetaPropertyKind.Readonly) eprop.Unsettable = true;
            else if (mprop.Kind == MetaPropertyKind.Lazy) eprop.Changeable = false;
            eprop.DefaultValueLiteral = mprop.DefaultValue;
        }

        private void ConvertOperation(EPackageBuilder parentEpkg, EClassBuilder ecls, MetaOperation mop)
        {
            var eop = _factory.EOperation();
            eop.Name = mop.Name.ToCamelCase();
            ecls.EOperations.Add(eop);
            _map.Add(mop, eop);
            foreach (var mparam in mop.Parameters)
            {
                var eparam = _factory.EParameter();
                eparam.Name = mparam.Name.ToCamelCase();
                eop.EParameters.Add(eparam);
                _map.Add(mparam, eparam);
            }
        }

        private void BindSuperClasses()
        {
            foreach (var entry in _map.Where(e => e.Key is MetaClass))
            {
                var mcls = (MetaClass)entry.Key;
                var ecls = (EClassBuilder)entry.Value;
                foreach (var msup in mcls.SuperClasses)
                {
                    if (_map.TryGetValue(msup, out var esup))
                    {
                        ecls.ESuperTypes.Add((EClassBuilder)esup);
                    }
                }
            }
        }

        private void BindTypedElements(EPackageBuilder parentEpkg)
        {
            foreach (var entry in _map.Where(e => e.Key is MetaTypedElement).ToList())
            {
                var mte = (MetaTypedElement)entry.Key;
                if (mte is MetaEnumLiteral mel) continue;
                SetType(parentEpkg, (ETypedElementBuilder)entry.Value, mte);
            }
        }

        private void SetType(EPackageBuilder parentEpkg, ETypedElementBuilder ete, MetaTypedElement mte)
        {
            if (mte.Type is MetaCollectionType mcoll)
            {
                var innerType = mcoll.InnerType;
                ete.EType = ResolveType(parentEpkg, innerType);
                if (innerType is MetaClass && ete is EReferenceBuilder eref)
                {
                    eref.EReferenceType = (EClassBuilder)ete.EType;
                }
                ete.Ordered = mcoll.Kind == MetaCollectionKind.List || mcoll.Kind == MetaCollectionKind.MultiList;
                ete.Unique = mcoll.Kind == MetaCollectionKind.List || mcoll.Kind == MetaCollectionKind.Set;
                ete.LowerBound = 0;
                ete.UpperBound = -1;
            }
            else 
            {
                ete.EType = ResolveType(parentEpkg, mte.Type);
                if (mte.Type is MetaClass && ete is EReferenceBuilder eref)
                {
                    eref.EReferenceType = (EClassBuilder)ete.EType;
                }
            }
        }

        private EClassifierBuilder ResolveType(EPackageBuilder parentEpkg, MetaType mtype)
        {
            if (_map.TryGetValue(mtype, out var etype))
            {
                return (EClassifierBuilder)etype;
            }
            else if (mtype is MetaPrimitiveType mpt)
            {
                var edt = _factory.EDataType();
                edt.Name = mpt.Name;
                parentEpkg.EClassifiers.Add(edt);
                _map.Add(mpt, edt);
                return edt;
            }
            else
            {
                _diagnostics.Add(ModelErrorCode.ERR_ModelConversionError.ToDiagnosticWithNoLocation(string.Format("Unknown MetaType: {0}", mtype.GetType())));
                return null;
            }
        }

        private EClassifierBuilder ResolveType(EPackageBuilder parentEpkg, string name)
        {
            var mtype = _meta.Objects.OfType<MetaNamedType>().Where(mpt => mpt.Name == name).FirstOrDefault();
            if (mtype != null)
            {
                return ResolveType(parentEpkg, mtype);
            }
            else
            {
                var existingEdt = _ecore.Objects.OfType<EClassifierBuilder>().Where(edt => edt.Name == name).FirstOrDefault();
                if (existingEdt != null) return existingEdt;
                var edt = _factory.EDataType();
                edt.Name = name;
                parentEpkg.EClassifiers.Add(edt);
                return edt;
            }
        }

        private void CreateAssociations()
        {
            var handled = new HashSet<MetaProperty>();
            foreach (var mprop in _meta.Objects.OfType<MetaProperty>())
            {
                if (!handled.Contains(mprop))
                {
                    handled.Add(mprop);
                    foreach (var mopp in mprop.OppositeProperties)
                    {
                        handled.Add(mopp);
                        if (_map.TryGetValue(mprop, out var mfirst) && _map.TryGetValue(mopp, out var msecond))
                        {
                            var mfirstProp = (EReferenceBuilder)mfirst;
                            var msecondProp = (EReferenceBuilder)msecond;
                            mfirstProp.EOpposite = msecondProp;
                            msecondProp.EOpposite = mfirstProp;
                        }
                    }
                }
            }
        }

        private void CreateConstantTypes(EPackageBuilder parentEpkg, MetaNamespace mns)
        {
            foreach (var mconst in mns.Declarations.OfType<MetaConstant>())
            {
                ResolveType(parentEpkg, mconst.Value.MName);
            }
        }
    }
}
