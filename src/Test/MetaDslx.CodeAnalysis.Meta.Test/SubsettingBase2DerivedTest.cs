using MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Meta.Test
{
    public class SubsettingBase2DerivedTest
    {
        [Fact]
        public void TestSingle2Single()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SingleDerived = derived1;
            Assert.Equal(derived1, subs.Single2SingleDerived);
            Assert.Equal(derived1, subs.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Equal(iderived1, isubs.Single2SingleDerived);
            Assert.Equal(iderived1, isubs.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SingleBase = base1;
            Assert.Null(subs.Single2SingleDerived);
            Assert.Equal(base1, subs.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Null(isubs.Single2SingleDerived);
            Assert.Equal(ibase1, isubs.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SingleBase = derived1;
            Assert.Null(subs.Single2SingleDerived);
            Assert.Equal(derived1, subs.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Null(isubs.Single2SingleDerived);
            Assert.Equal(iderived1, isubs.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SingleDerived = derived1;
            Assert.Equal(derived1, subs.Single2SingleDerived);
            Assert.Equal(derived1, subs.Single2SingleBase);
            subs.Single2SingleDerived = null;
            Assert.Null(subs.Single2SingleDerived);
            Assert.Null(subs.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Null(isubs.Single2SingleDerived);
            Assert.Null(isubs.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SingleDerived = derived1;
            Assert.Equal(derived1, subs.Single2SingleDerived);
            Assert.Equal(derived1, subs.Single2SingleBase);
            subs.Single2SingleBase = null;
            Assert.Null(subs.Single2SingleDerived);
            Assert.Null(subs.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Null(isubs.Single2SingleDerived);
            Assert.Null(isubs.Single2SingleBase);
        }


        [Fact]
        public void TestSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.Set2SetDerived);
            Assert.Contains(derived1, subs.Set2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Contains(iderived1, isubs.Set2SetDerived);
            Assert.Contains(iderived1, isubs.Set2SetBase);
        }

        [Fact]
        public void TestSet2SetBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2SetBase.Add(base1);
            Assert.True(subs.Set2SetDerived.Count == 0);
            Assert.Contains(base1, subs.Set2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2SetDerived.Count == 0);
            Assert.Contains(ibase1, isubs.Set2SetBase);
        }

        [Fact]
        public void TestSet2SetBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2SetBase.Add(derived1);
            Assert.True(subs.Set2SetDerived.Count == 0);
            Assert.Contains(derived1, subs.Set2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2SetDerived.Count == 0);
            Assert.Contains(iderived1, isubs.Set2SetBase);
        }

        [Fact]
        public void TestSet2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.Set2SetDerived);
            Assert.Contains(derived1, subs.Set2SetBase);
            subs.Set2SetDerived.Remove(derived1);
            Assert.True(subs.Set2SetDerived.Count == 0);
            Assert.Contains(derived1, subs.Set2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2SetDerived.Count == 0);
            Assert.Contains(iderived1, isubs.Set2SetBase);
        }

        [Fact]
        public void TestSet2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.Set2SetDerived);
            Assert.Contains(derived1, subs.Set2SetBase);
            subs.Set2SetBase.Remove(derived1);
            Assert.True(subs.Set2SetDerived.Count == 0);
            Assert.True(subs.Set2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2SetDerived.Count == 0);
            Assert.True(isubs.Set2SetBase.Count == 0);
        }

        [Fact]
        public void TestList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.List2ListDerived);
            Assert.Contains(derived1, subs.List2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Contains(iderived1, isubs.List2ListDerived);
            Assert.Contains(iderived1, isubs.List2ListBase);
        }

        [Fact]
        public void TestList2ListBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2ListBase.Add(base1);
            Assert.True(subs.List2ListDerived.Count == 0);
            Assert.Contains(base1, subs.List2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2ListDerived.Count == 0);
            Assert.Contains(ibase1, isubs.List2ListBase);
        }

        [Fact]
        public void TestList2ListBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2ListBase.Add(derived1);
            Assert.True(subs.List2ListDerived.Count == 0);
            Assert.Contains(derived1, subs.List2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2ListDerived.Count == 0);
            Assert.Contains(iderived1, isubs.List2ListBase);
        }

        [Fact]
        public void TestList2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.List2ListDerived);
            Assert.Contains(derived1, subs.List2ListBase);
            subs.List2ListDerived.Remove(derived1);
            Assert.True(subs.List2ListDerived.Count == 0);
            Assert.Contains(derived1, subs.List2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2ListDerived.Count == 0);
            Assert.Contains(iderived1, isubs.List2ListBase);
        }

        [Fact]
        public void TestList2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.List2ListDerived);
            Assert.Contains(derived1, subs.List2ListBase);
            subs.List2ListBase.Remove(derived1);
            Assert.True(subs.List2ListDerived.Count == 0);
            Assert.True(subs.List2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2ListDerived.Count == 0);
            Assert.True(isubs.List2ListBase.Count == 0);
        }


        [Fact]
        public void TestSingle2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.Single2SetDerived);
            Assert.Equal(derived1, subs.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Contains(iderived1, isubs.Single2SetDerived);
            Assert.Equal(iderived1, isubs.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SetBase = base1;
            Assert.True(subs.Single2SetDerived.Count == 0);
            Assert.Equal(base1, subs.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2SetDerived.Count == 0);
            Assert.Equal(ibase1, isubs.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SetBase = derived1;
            Assert.True(subs.Single2SetDerived.Count == 0);
            Assert.Equal(derived1, subs.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2SetDerived.Count == 0);
            Assert.Equal(iderived1, isubs.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.Single2SetDerived);
            Assert.Equal(derived1, subs.Single2SetBase);
            subs.Single2SetDerived.Remove(derived1);
            Assert.True(subs.Single2SetDerived.Count == 0);
            Assert.Equal(derived1, subs.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2SetDerived.Count == 0);
            Assert.Equal(iderived1, isubs.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.Single2SetDerived);
            Assert.Equal(derived1, subs.Single2SetBase);
            subs.Single2SetBase = null;
            Assert.True(subs.Single2SetDerived.Count == 0);
            Assert.Null(subs.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2SetDerived.Count == 0);
            Assert.Null(isubs.Single2SetBase);
        }

        [Fact]
        public void TestSingle2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.Single2ListDerived);
            Assert.Equal(derived1, subs.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Contains(iderived1, isubs.Single2ListDerived);
            Assert.Equal(iderived1, isubs.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2ListBase = base1;
            Assert.True(subs.Single2ListDerived.Count == 0);
            Assert.Equal(base1, subs.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2ListDerived.Count == 0);
            Assert.Equal(ibase1, isubs.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2ListBase = derived1;
            Assert.True(subs.Single2ListDerived.Count == 0);
            Assert.Equal(derived1, subs.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2ListDerived.Count == 0);
            Assert.Equal(iderived1, isubs.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.Single2ListDerived);
            Assert.Equal(derived1, subs.Single2ListBase);
            subs.Single2ListDerived.Remove(derived1);
            Assert.True(subs.Single2ListDerived.Count == 0);
            Assert.Equal(derived1, subs.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2ListDerived.Count == 0);
            Assert.Equal(iderived1, isubs.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Single2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.Single2ListDerived);
            Assert.Equal(derived1, subs.Single2ListBase);
            subs.Single2ListBase = null;
            Assert.True(subs.Single2ListDerived.Count == 0);
            Assert.Null(subs.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Single2ListDerived.Count == 0);
            Assert.Null(isubs.Single2ListBase);
        }

        [Fact]
        public void TestSet2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.Set2ListDerived);
            Assert.Contains(derived1, subs.Set2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Contains(iderived1, isubs.Set2ListDerived);
            Assert.Contains(iderived1, isubs.Set2ListBase);
        }

        [Fact]
        public void TestSet2ListBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2ListBase.Add(base1);
            Assert.True(subs.Set2ListDerived.Count == 0);
            Assert.Contains(base1, subs.Set2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2ListDerived.Count == 0);
            Assert.Contains(ibase1, isubs.Set2ListBase);
        }

        [Fact]
        public void TestSet2ListBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2ListBase.Add(derived1);
            Assert.True(subs.Set2ListDerived.Count == 0);
            Assert.Contains(derived1, subs.Set2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2ListDerived.Count == 0);
            Assert.Contains(iderived1, isubs.Set2ListBase);
        }

        [Fact]
        public void TestSet2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.Set2ListDerived);
            Assert.Contains(derived1, subs.Set2ListBase);
            subs.Set2ListDerived.Remove(derived1);
            Assert.True(subs.Set2ListDerived.Count == 0);
            Assert.Contains(derived1, subs.Set2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2ListDerived.Count == 0);
            Assert.Contains(iderived1, isubs.Set2ListBase);
        }

        [Fact]
        public void TestSet2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.Set2ListDerived.Add(derived1);
            Assert.Contains(derived1, subs.Set2ListDerived);
            Assert.Contains(derived1, subs.Set2ListBase);
            subs.Set2ListBase.Remove(derived1);
            Assert.True(subs.Set2ListDerived.Count == 0);
            Assert.True(subs.Set2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.Set2ListDerived.Count == 0);
            Assert.True(isubs.Set2ListBase.Count == 0);
        }

        [Fact]
        public void TestList2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.List2SetDerived);
            Assert.Contains(derived1, subs.List2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.Contains(iderived1, isubs.List2SetDerived);
            Assert.Contains(iderived1, isubs.List2SetBase);
        }

        [Fact]
        public void TestList2SetBaseBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2SetBase.Add(base1);
            Assert.True(subs.List2SetDerived.Count == 0);
            Assert.Contains(base1, subs.List2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2SetDerived.Count == 0);
            Assert.Contains(ibase1, isubs.List2SetBase);
        }

        [Fact]
        public void TestList2SetBaseDerived()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2SetBase.Add(derived1);
            Assert.True(subs.List2SetDerived.Count == 0);
            Assert.Contains(derived1, subs.List2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2SetDerived.Count == 0);
            Assert.Contains(iderived1, isubs.List2SetBase);
        }

        [Fact]
        public void TestList2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.List2SetDerived);
            Assert.Contains(derived1, subs.List2SetBase);
            subs.List2SetDerived.Remove(derived1);
            Assert.True(subs.List2SetDerived.Count == 0);
            Assert.Contains(derived1, subs.List2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2SetDerived.Count == 0);
            Assert.Contains(iderived1, isubs.List2SetBase);
        }

        [Fact]
        public void TestList2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var subs = factory.SubsettingBase2Derived();
            subs.List2SetDerived.Add(derived1);
            Assert.Contains(derived1, subs.List2SetDerived);
            Assert.Contains(derived1, subs.List2SetBase);
            subs.List2SetBase.Remove(derived1);
            Assert.True(subs.List2SetDerived.Count == 0);
            Assert.True(subs.List2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var isubs = subs.ToImmutable(imodel);
            Assert.True(isubs.List2SetDerived.Count == 0);
            Assert.True(isubs.List2SetBase.Count == 0);
        }
    }
}
