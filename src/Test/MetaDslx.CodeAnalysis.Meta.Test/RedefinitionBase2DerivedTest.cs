using MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest;
using MetaDslx.Modeling;
using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Meta.Test
{
    public class RedefinitionBase2DerivedTest : DebugAssertUnitTest
    {
        [Fact]
        public void TestSingle2Single()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SingleDerived = derived1;
            Assert.Equal(derived1, redef.Single2SingleDerived);
            Assert.Equal(derived1, redef.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Equal(iderived1, iredef.Single2SingleDerived);
            Assert.Equal(iderived1, iredef.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Single2SingleBase = base1);
            Assert.Null(redef.Single2SingleDerived);
            Assert.Null(redef.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Null(iredef.Single2SingleDerived);
            Assert.Null(iredef.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SingleBase = derived1;
            Assert.Equal(derived1, redef.Single2SingleDerived);
            Assert.Equal(derived1, redef.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Equal(iderived1, iredef.Single2SingleDerived);
            Assert.Equal(iderived1, iredef.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SingleDerived = derived1;
            Assert.Equal(derived1, redef.Single2SingleDerived);
            Assert.Equal(derived1, redef.Single2SingleBase);
            redef.Single2SingleDerived = null;
            Assert.Null(redef.Single2SingleDerived);
            Assert.Null(redef.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Null(iredef.Single2SingleDerived);
            Assert.Null(iredef.Single2SingleBase);
        }

        [Fact]
        public void TestSingle2SingleResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SingleDerived = derived1;
            Assert.Equal(derived1, redef.Single2SingleDerived);
            Assert.Equal(derived1, redef.Single2SingleBase);
            redef.Single2SingleBase = null;
            Assert.Null(redef.Single2SingleDerived);
            Assert.Null(redef.Single2SingleBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Null(iredef.Single2SingleDerived);
            Assert.Null(iredef.Single2SingleBase);
        }


        [Fact]
        public void TestSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.Set2SetDerived);
            Assert.Contains(derived1, redef.Set2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Set2SetDerived);
            Assert.Contains(iderived1, iredef.Set2SetBase);
        }

        [Fact]
        public void TestSet2SetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Set2SetBase.Add(base1));
            Assert.True(redef.Set2SetDerived.Count == 0);
            Assert.True(redef.Set2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2SetDerived.Count == 0);
            Assert.True(iredef.Set2SetBase.Count == 0);
        }

        [Fact]
        public void TestSet2SetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SetBase.Add(derived1);
            Assert.Contains(derived1, redef.Set2SetDerived);
            Assert.Contains(derived1, redef.Set2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Set2SetDerived);
            Assert.Contains(iderived1, iredef.Set2SetBase);
        }

        [Fact]
        public void TestSet2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.Set2SetDerived);
            Assert.Contains(derived1, redef.Set2SetBase);
            redef.Set2SetDerived.Remove(derived1);
            Assert.True(redef.Set2SetDerived.Count == 0);
            Assert.True(redef.Set2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2SetDerived.Count == 0);
            Assert.True(iredef.Set2SetBase.Count == 0);
        }

        [Fact]
        public void TestSet2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.Set2SetDerived);
            Assert.Contains(derived1, redef.Set2SetBase);
            redef.Set2SetBase.Remove(derived1);
            Assert.True(redef.Set2SetDerived.Count == 0);
            Assert.True(redef.Set2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2SetDerived.Count == 0);
            Assert.True(iredef.Set2SetBase.Count == 0);
        }

        [Fact]
        public void TestList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.List2ListDerived);
            Assert.Contains(derived1, redef.List2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.List2ListDerived);
            Assert.Contains(iderived1, iredef.List2ListBase);
        }

        [Fact]
        public void TestList2ListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.List2ListBase.Add(base1));
            Assert.True(redef.List2ListDerived.Count == 0);
            Assert.True(redef.List2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2ListDerived.Count == 0);
            Assert.True(iredef.List2ListBase.Count == 0);
        }

        [Fact]
        public void TestList2ListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2ListBase.Add(derived1);
            Assert.Contains(derived1, redef.List2ListDerived);
            Assert.Contains(derived1, redef.List2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.List2ListDerived);
            Assert.Contains(iderived1, iredef.List2ListBase);
        }

        [Fact]
        public void TestList2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.List2ListDerived);
            Assert.Contains(derived1, redef.List2ListBase);
            redef.List2ListDerived.Remove(derived1);
            Assert.True(redef.List2ListDerived.Count == 0);
            Assert.True(redef.List2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2ListDerived.Count == 0);
            Assert.True(iredef.List2ListBase.Count == 0);
        }

        [Fact]
        public void TestList2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.List2ListDerived);
            Assert.Contains(derived1, redef.List2ListBase);
            redef.List2ListBase.Remove(derived1);
            Assert.True(redef.List2ListDerived.Count == 0);
            Assert.True(redef.List2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2ListDerived.Count == 0);
            Assert.True(iredef.List2ListBase.Count == 0);
        }


        [Fact]
        public void TestSingle2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.Single2SetDerived);
            Assert.Equal(derived1, redef.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Single2SetDerived);
            Assert.Equal(iderived1, iredef.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Single2SetBase = base1);
            Assert.True(redef.Single2SetDerived.Count == 0);
            Assert.Null(redef.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Single2SetDerived.Count == 0);
            Assert.Null(iredef.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SetBase = derived1;
            Assert.Contains(derived1, redef.Single2SetDerived);
            Assert.Equal(derived1, redef.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Single2SetDerived);
            Assert.Equal(iderived1, iredef.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.Single2SetDerived);
            Assert.Equal(derived1, redef.Single2SetBase);
            redef.Single2SetDerived.Remove(derived1);
            Assert.True(redef.Single2SetDerived.Count == 0);
            Assert.Null(redef.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Single2SetDerived.Count == 0);
            Assert.Null(iredef.Single2SetBase);
        }

        [Fact]
        public void TestSingle2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.Single2SetDerived);
            Assert.Equal(derived1, redef.Single2SetBase);
            redef.Single2SetBase = null;
            Assert.True(redef.Single2SetDerived.Count == 0);
            Assert.Null(redef.Single2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Single2SetDerived.Count == 0);
            Assert.Null(iredef.Single2SetBase);
        }

        [Fact]
        public void TestSet2Single()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SingleDerived = derived1;
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Set2SingleBase);
            Assert.Equal(iderived1, iredef.Set2SingleDerived);
        }

        [Fact]
        public void TestSet2SingleBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Set2SingleBase.Add(base1));
            Assert.True(redef.Set2SingleBase.Count == 0);
            Assert.Null(redef.Set2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2SingleBase.Count == 0);
            Assert.Null(iredef.Set2SingleDerived);
        }

        [Fact]
        public void TestSet2SingleBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SingleBase.Add(derived1);
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Set2SingleBase);
            Assert.Equal(iderived1, iredef.Set2SingleDerived);
        }

        [Fact]
        public void TestSet2SingleBaseMany()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var derived2 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SingleBase.Add(derived1);
            Assert.True(redef.Set2SingleBase.Count == 1);
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            redef.Set2SingleBase.Add(derived1);
            Assert.True(redef.Set2SingleBase.Count == 1);
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            Assert.Throws<ModelException>(() => redef.Set2SingleBase.Add(derived2));
            Assert.True(redef.Set2SingleBase.Count == 1);
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iderived2 = derived2.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(redef.Set2SingleBase.Count == 1);
            Assert.Contains(iderived1, iredef.Set2SingleBase);
            Assert.Equal(iderived1, iredef.Set2SingleDerived);
        }

        [Fact]
        public void TestSet2SingleReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SingleDerived = derived1;
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            redef.Set2SingleDerived = null;
            Assert.True(redef.Set2SingleBase.Count == 0);
            Assert.Null(redef.Set2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2SingleBase.Count == 0);
            Assert.Null(iredef.Set2SingleDerived);
        }

        [Fact]
        public void TestSet2SingleResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2SingleDerived = derived1;
            Assert.Contains(derived1, redef.Set2SingleBase);
            Assert.Equal(derived1, redef.Set2SingleDerived);
            redef.Set2SingleBase.Remove(derived1);
            Assert.True(redef.Set2SingleBase.Count == 0);
            Assert.Null(redef.Set2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2SingleBase.Count == 0);
            Assert.Null(iredef.Set2SingleDerived);
        }



        [Fact]
        public void TestSingle2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.Single2ListDerived);
            Assert.Equal(derived1, redef.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Single2ListDerived);
            Assert.Equal(iderived1, iredef.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Single2ListBase = base1);
            Assert.True(redef.Single2ListDerived.Count == 0);
            Assert.Null(redef.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Single2ListDerived.Count == 0);
            Assert.Null(iredef.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2ListBase = derived1;
            Assert.Contains(derived1, redef.Single2ListDerived);
            Assert.Equal(derived1, redef.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Single2ListDerived);
            Assert.Equal(iderived1, iredef.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.Single2ListDerived);
            Assert.Equal(derived1, redef.Single2ListBase);
            redef.Single2ListDerived.Remove(derived1);
            Assert.True(redef.Single2ListDerived.Count == 0);
            Assert.Null(redef.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Single2ListDerived.Count == 0);
            Assert.Null(iredef.Single2ListBase);
        }

        [Fact]
        public void TestSingle2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Single2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.Single2ListDerived);
            Assert.Equal(derived1, redef.Single2ListBase);
            redef.Single2ListBase = null;
            Assert.True(redef.Single2ListDerived.Count == 0);
            Assert.Null(redef.Single2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Single2ListDerived.Count == 0);
            Assert.Null(iredef.Single2ListBase);
        }

        [Fact]
        public void TestList2Single()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SingleDerived = derived1;
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.List2SingleBase);
            Assert.Equal(iderived1, iredef.List2SingleDerived);
        }

        [Fact]
        public void TestList2SingleBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.List2SingleBase.Add(base1));
            Assert.True(redef.List2SingleBase.Count == 0);
            Assert.Null(redef.List2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2SingleBase.Count == 0);
            Assert.Null(iredef.List2SingleDerived);
        }

        [Fact]
        public void TestList2SingleBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SingleBase.Add(derived1);
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.List2SingleBase);
            Assert.Equal(iderived1, iredef.List2SingleDerived);
        }

        [Fact]
        public void TestList2SingleBaseMany()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var derived2 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SingleBase.Add(derived1);
            Assert.True(redef.List2SingleBase.Count == 1);
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            redef.List2SingleBase.Add(derived1);
            Assert.True(redef.List2SingleBase.Count == 1);
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            Assert.Throws<ModelException>(() => redef.List2SingleBase.Add(derived2));
            Assert.True(redef.List2SingleBase.Count == 1);
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iderived2 = derived2.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(redef.List2SingleBase.Count == 1);
            Assert.Contains(iderived1, iredef.List2SingleBase);
            Assert.Equal(iderived1, iredef.List2SingleDerived);
        }

        [Fact]
        public void TestList2SingleReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SingleDerived = derived1;
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            redef.List2SingleDerived = null;
            Assert.True(redef.List2SingleBase.Count == 0);
            Assert.Null(redef.List2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2SingleBase.Count == 0);
            Assert.Null(iredef.List2SingleDerived);
        }

        [Fact]
        public void TestList2SingleResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SingleDerived = derived1;
            Assert.Contains(derived1, redef.List2SingleBase);
            Assert.Equal(derived1, redef.List2SingleDerived);
            redef.List2SingleBase.Remove(derived1);
            Assert.True(redef.List2SingleBase.Count == 0);
            Assert.Null(redef.List2SingleDerived);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2SingleBase.Count == 0);
            Assert.Null(iredef.List2SingleDerived);
        }


        [Fact]
        public void TestSet2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.Set2ListDerived);
            Assert.Contains(derived1, redef.Set2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Set2ListDerived);
            Assert.Contains(iderived1, iredef.Set2ListBase);
        }

        [Fact]
        public void TestSet2ListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Set2ListBase.Add(base1));
            Assert.True(redef.Set2ListDerived.Count == 0);
            Assert.True(redef.Set2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2ListDerived.Count == 0);
            Assert.True(iredef.Set2ListBase.Count == 0);
        }

        [Fact]
        public void TestSet2ListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2ListBase.Add(derived1);
            Assert.Contains(derived1, redef.Set2ListDerived);
            Assert.Contains(derived1, redef.Set2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.Set2ListDerived);
            Assert.Contains(iderived1, iredef.Set2ListBase);
        }

        [Fact]
        public void TestSet2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.Set2ListDerived);
            Assert.Contains(derived1, redef.Set2ListBase);
            redef.Set2ListDerived.Remove(derived1);
            Assert.True(redef.Set2ListDerived.Count == 0);
            Assert.True(redef.Set2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2ListDerived.Count == 0);
            Assert.True(iredef.Set2ListBase.Count == 0);
        }

        [Fact]
        public void TestSet2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2ListDerived.Add(derived1);
            Assert.Contains(derived1, redef.Set2ListDerived);
            Assert.Contains(derived1, redef.Set2ListBase);
            redef.Set2ListBase.Remove(derived1);
            Assert.True(redef.Set2ListDerived.Count == 0);
            Assert.True(redef.Set2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2ListDerived.Count == 0);
            Assert.True(iredef.Set2ListBase.Count == 0);
        }

        [Fact]
        public void TestList2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.List2SetDerived);
            Assert.Contains(derived1, redef.List2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.List2SetDerived);
            Assert.Contains(iderived1, iredef.List2SetBase);
        }

        [Fact]
        public void TestList2SetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.List2SetBase.Add(base1));
            Assert.True(redef.List2SetDerived.Count == 0);
            Assert.True(redef.List2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2SetDerived.Count == 0);
            Assert.True(iredef.List2SetBase.Count == 0);
        }

        [Fact]
        public void TestList2SetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SetBase.Add(derived1);
            Assert.Contains(derived1, redef.List2SetDerived);
            Assert.Contains(derived1, redef.List2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Contains(iderived1, iredef.List2SetDerived);
            Assert.Contains(iderived1, iredef.List2SetBase);
        }

        [Fact]
        public void TestList2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.List2SetDerived);
            Assert.Contains(derived1, redef.List2SetBase);
            redef.List2SetDerived.Remove(derived1);
            Assert.True(redef.List2SetDerived.Count == 0);
            Assert.True(redef.List2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2SetDerived.Count == 0);
            Assert.True(iredef.List2SetBase.Count == 0);
        }

        [Fact]
        public void TestList2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2SetDerived.Add(derived1);
            Assert.Contains(derived1, redef.List2SetDerived);
            Assert.Contains(derived1, redef.List2SetBase);
            redef.List2SetBase.Remove(derived1);
            Assert.True(redef.List2SetDerived.Count == 0);
            Assert.True(redef.List2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2SetDerived.Count == 0);
            Assert.True(iredef.List2SetBase.Count == 0);
        }


        [Fact]
        public void TestSet2MultiSet()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiSetDerived.Add(derived1);
            redef.Set2MultiSetDerived.Add(derived1);
            redef.Set2MultiSetDerived.Add(derived1);
            Assert.Single(redef.Set2MultiSetDerived);
            Assert.Single(redef.Set2MultiSetBase);
            Assert.Contains(derived1, redef.Set2MultiSetDerived);
            Assert.Contains(derived1, redef.Set2MultiSetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.Set2MultiSetDerived);
            Assert.Single(iredef.Set2MultiSetBase);
            Assert.Contains(iderived1, iredef.Set2MultiSetDerived);
            Assert.Contains(iderived1, iredef.Set2MultiSetBase);
        }

        [Fact]
        public void TestSet2MultiSetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Set2MultiSetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.Set2MultiSetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.Set2MultiSetBase.Add(base1));
            Assert.True(redef.Set2MultiSetDerived.Count == 0);
            Assert.True(redef.Set2MultiSetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2MultiSetDerived.Count == 0);
            Assert.True(iredef.Set2MultiSetBase.Count == 0);
        }

        [Fact]
        public void TestSet2MultiSetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiSetBase.Add(derived1);
            redef.Set2MultiSetBase.Add(derived1);
            redef.Set2MultiSetBase.Add(derived1);
            Assert.Single(redef.Set2MultiSetDerived);
            Assert.Single(redef.Set2MultiSetBase);
            Assert.Contains(derived1, redef.Set2MultiSetDerived);
            Assert.Contains(derived1, redef.Set2MultiSetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.Set2MultiSetDerived);
            Assert.Single(iredef.Set2MultiSetBase);
            Assert.Contains(iderived1, iredef.Set2MultiSetDerived);
            Assert.Contains(iderived1, iredef.Set2MultiSetBase);
        }

        [Fact]
        public void TestSet2MultiSetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiSetDerived.Add(derived1);
            redef.Set2MultiSetDerived.Add(derived1);
            redef.Set2MultiSetDerived.Add(derived1);
            Assert.Single(redef.Set2MultiSetDerived);
            Assert.Single(redef.Set2MultiSetBase);
            Assert.Contains(derived1, redef.Set2MultiSetDerived);
            Assert.Contains(derived1, redef.Set2MultiSetBase);
            redef.Set2MultiSetDerived.Remove(derived1);
            Assert.True(redef.Set2MultiSetDerived.Count == 0);
            Assert.True(redef.Set2MultiSetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2MultiSetDerived.Count == 0);
            Assert.True(iredef.Set2MultiSetBase.Count == 0);
        }

        [Fact]
        public void TestSet2MultiSetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiSetDerived.Add(derived1);
            redef.Set2MultiSetDerived.Add(derived1);
            redef.Set2MultiSetDerived.Add(derived1);
            Assert.Single(redef.Set2MultiSetDerived);
            Assert.Single(redef.Set2MultiSetBase);
            Assert.Contains(derived1, redef.Set2MultiSetDerived);
            Assert.Contains(derived1, redef.Set2MultiSetBase);
            redef.Set2MultiSetBase.Remove(derived1);
            Assert.True(redef.Set2MultiSetDerived.Count == 0);
            Assert.True(redef.Set2MultiSetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2MultiSetDerived.Count == 0);
            Assert.True(iredef.Set2MultiSetBase.Count == 0);
        }

        [Fact]
        public void TestSet2MultiList()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiListDerived.Add(derived1);
            redef.Set2MultiListDerived.Add(derived1);
            redef.Set2MultiListDerived.Add(derived1);
            Assert.Single(redef.Set2MultiListDerived);
            Assert.Single(redef.Set2MultiListBase);
            Assert.Contains(derived1, redef.Set2MultiListDerived);
            Assert.Contains(derived1, redef.Set2MultiListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.Set2MultiListDerived);
            Assert.Single(iredef.Set2MultiListBase);
            Assert.Contains(iderived1, iredef.Set2MultiListDerived);
            Assert.Contains(iderived1, iredef.Set2MultiListBase);
        }

        [Fact]
        public void TestSet2MultiListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.Set2MultiListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.Set2MultiListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.Set2MultiListBase.Add(base1));
            Assert.True(redef.Set2MultiListDerived.Count == 0);
            Assert.True(redef.Set2MultiListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2MultiListDerived.Count == 0);
            Assert.True(iredef.Set2MultiListBase.Count == 0);
        }

        [Fact]
        public void TestSet2MultiListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiListBase.Add(derived1);
            redef.Set2MultiListBase.Add(derived1);
            redef.Set2MultiListBase.Add(derived1);
            Assert.Single(redef.Set2MultiListDerived);
            Assert.Single(redef.Set2MultiListBase);
            Assert.Contains(derived1, redef.Set2MultiListDerived);
            Assert.Contains(derived1, redef.Set2MultiListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.Set2MultiListDerived);
            Assert.Single(iredef.Set2MultiListBase);
            Assert.Contains(iderived1, iredef.Set2MultiListDerived);
            Assert.Contains(iderived1, iredef.Set2MultiListBase);
        }

        [Fact]
        public void TestSet2MultiListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiListDerived.Add(derived1);
            redef.Set2MultiListDerived.Add(derived1);
            redef.Set2MultiListDerived.Add(derived1);
            Assert.Single(redef.Set2MultiListDerived);
            Assert.Single(redef.Set2MultiListBase);
            Assert.Contains(derived1, redef.Set2MultiListDerived);
            Assert.Contains(derived1, redef.Set2MultiListBase);
            redef.Set2MultiListDerived.Remove(derived1);
            Assert.True(redef.Set2MultiListDerived.Count == 0);
            Assert.True(redef.Set2MultiListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2MultiListDerived.Count == 0);
            Assert.True(iredef.Set2MultiListBase.Count == 0);
        }

        [Fact]
        public void TestSet2MultiListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.Set2MultiListDerived.Add(derived1);
            redef.Set2MultiListDerived.Add(derived1);
            redef.Set2MultiListDerived.Add(derived1);
            Assert.Single(redef.Set2MultiListDerived);
            Assert.Single(redef.Set2MultiListBase);
            Assert.Contains(derived1, redef.Set2MultiListDerived);
            Assert.Contains(derived1, redef.Set2MultiListBase);
            redef.Set2MultiListBase.Remove(derived1);
            Assert.True(redef.Set2MultiListDerived.Count == 0);
            Assert.True(redef.Set2MultiListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.Set2MultiListDerived.Count == 0);
            Assert.True(iredef.Set2MultiListBase.Count == 0);
        }

        [Fact]
        public void TestList2MultiSet()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiSetDerived.Add(derived1);
            redef.List2MultiSetDerived.Add(derived1);
            redef.List2MultiSetDerived.Add(derived1);
            Assert.Single(redef.List2MultiSetDerived);
            Assert.Single(redef.List2MultiSetBase);
            Assert.Contains(derived1, redef.List2MultiSetDerived);
            Assert.Contains(derived1, redef.List2MultiSetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.List2MultiSetDerived);
            Assert.Single(iredef.List2MultiSetBase);
            Assert.Contains(iderived1, iredef.List2MultiSetDerived);
            Assert.Contains(iderived1, iredef.List2MultiSetBase);
        }

        [Fact]
        public void TestList2MultiSetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.List2MultiSetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.List2MultiSetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.List2MultiSetBase.Add(base1));
            Assert.True(redef.List2MultiSetDerived.Count == 0);
            Assert.True(redef.List2MultiSetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2MultiSetDerived.Count == 0);
            Assert.True(iredef.List2MultiSetBase.Count == 0);
        }

        [Fact]
        public void TestList2MultiSetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiSetBase.Add(derived1);
            redef.List2MultiSetBase.Add(derived1);
            redef.List2MultiSetBase.Add(derived1);
            Assert.Single(redef.List2MultiSetDerived);
            Assert.Single(redef.List2MultiSetBase);
            Assert.Contains(derived1, redef.List2MultiSetDerived);
            Assert.Contains(derived1, redef.List2MultiSetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.List2MultiSetDerived);
            Assert.Single(iredef.List2MultiSetBase);
            Assert.Contains(iderived1, iredef.List2MultiSetDerived);
            Assert.Contains(iderived1, iredef.List2MultiSetBase);
        }

        [Fact]
        public void TestList2MultiSetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiSetDerived.Add(derived1);
            redef.List2MultiSetDerived.Add(derived1);
            redef.List2MultiSetDerived.Add(derived1);
            Assert.Single(redef.List2MultiSetDerived);
            Assert.Single(redef.List2MultiSetBase);
            Assert.Contains(derived1, redef.List2MultiSetDerived);
            Assert.Contains(derived1, redef.List2MultiSetBase);
            redef.List2MultiSetDerived.Remove(derived1);
            Assert.True(redef.List2MultiSetDerived.Count == 0);
            Assert.True(redef.List2MultiSetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2MultiSetDerived.Count == 0);
            Assert.True(iredef.List2MultiSetBase.Count == 0);
        }

        [Fact]
        public void TestList2MultiSetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiSetDerived.Add(derived1);
            redef.List2MultiSetDerived.Add(derived1);
            redef.List2MultiSetDerived.Add(derived1);
            Assert.Single(redef.List2MultiSetDerived);
            Assert.Single(redef.List2MultiSetBase);
            Assert.Contains(derived1, redef.List2MultiSetDerived);
            Assert.Contains(derived1, redef.List2MultiSetBase);
            redef.List2MultiSetBase.Remove(derived1);
            Assert.True(redef.List2MultiSetDerived.Count == 0);
            Assert.True(redef.List2MultiSetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2MultiSetDerived.Count == 0);
            Assert.True(iredef.List2MultiSetBase.Count == 0);
        }

        [Fact]
        public void TestList2MultiList()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiListDerived.Add(derived1);
            redef.List2MultiListDerived.Add(derived1);
            redef.List2MultiListDerived.Add(derived1);
            Assert.Single(redef.List2MultiListDerived);
            Assert.Single(redef.List2MultiListBase);
            Assert.Contains(derived1, redef.List2MultiListDerived);
            Assert.Contains(derived1, redef.List2MultiListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.List2MultiListDerived);
            Assert.Single(iredef.List2MultiListBase);
            Assert.Contains(iderived1, iredef.List2MultiListDerived);
            Assert.Contains(iderived1, iredef.List2MultiListBase);
        }

        [Fact]
        public void TestList2MultiListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.List2MultiListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.List2MultiListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.List2MultiListBase.Add(base1));
            Assert.True(redef.List2MultiListDerived.Count == 0);
            Assert.True(redef.List2MultiListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2MultiListDerived.Count == 0);
            Assert.True(iredef.List2MultiListBase.Count == 0);
        }

        [Fact]
        public void TestList2MultiListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiListBase.Add(derived1);
            redef.List2MultiListBase.Add(derived1);
            redef.List2MultiListBase.Add(derived1);
            Assert.Single(redef.List2MultiListDerived);
            Assert.Single(redef.List2MultiListBase);
            Assert.Contains(derived1, redef.List2MultiListDerived);
            Assert.Contains(derived1, redef.List2MultiListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.List2MultiListDerived);
            Assert.Single(iredef.List2MultiListBase);
            Assert.Contains(iderived1, iredef.List2MultiListDerived);
            Assert.Contains(iderived1, iredef.List2MultiListBase);
        }

        [Fact]
        public void TestList2MultiListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiListDerived.Add(derived1);
            redef.List2MultiListDerived.Add(derived1);
            redef.List2MultiListDerived.Add(derived1);
            Assert.Single(redef.List2MultiListDerived);
            Assert.Single(redef.List2MultiListBase);
            Assert.Contains(derived1, redef.List2MultiListDerived);
            Assert.Contains(derived1, redef.List2MultiListBase);
            redef.List2MultiListDerived.Remove(derived1);
            Assert.True(redef.List2MultiListDerived.Count == 0);
            Assert.True(redef.List2MultiListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2MultiListDerived.Count == 0);
            Assert.True(iredef.List2MultiListBase.Count == 0);
        }

        [Fact]
        public void TestList2MultiListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.List2MultiListDerived.Add(derived1);
            redef.List2MultiListDerived.Add(derived1);
            redef.List2MultiListDerived.Add(derived1);
            Assert.Single(redef.List2MultiListDerived);
            Assert.Single(redef.List2MultiListBase);
            Assert.Contains(derived1, redef.List2MultiListDerived);
            Assert.Contains(derived1, redef.List2MultiListBase);
            redef.List2MultiListBase.Remove(derived1);
            Assert.True(redef.List2MultiListDerived.Count == 0);
            Assert.True(redef.List2MultiListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.List2MultiListDerived.Count == 0);
            Assert.True(iredef.List2MultiListBase.Count == 0);
        }

        [Fact]
        public void TestMultiSet2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2SetDerived.Add(derived1);
            redef.MultiSet2SetDerived.Add(derived1);
            redef.MultiSet2SetDerived.Add(derived1);
            Assert.Single(redef.MultiSet2SetDerived);
            Assert.Single(redef.MultiSet2SetBase);
            Assert.Contains(derived1, redef.MultiSet2SetDerived);
            Assert.Contains(derived1, redef.MultiSet2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiSet2SetDerived);
            Assert.Single(iredef.MultiSet2SetBase);
            Assert.Contains(iderived1, iredef.MultiSet2SetDerived);
            Assert.Contains(iderived1, iredef.MultiSet2SetBase);
        }

        [Fact]
        public void TestMultiSet2SetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.MultiSet2SetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiSet2SetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiSet2SetBase.Add(base1));
            Assert.True(redef.MultiSet2SetDerived.Count == 0);
            Assert.True(redef.MultiSet2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiSet2SetDerived.Count == 0);
            Assert.True(iredef.MultiSet2SetBase.Count == 0);
        }

        [Fact]
        public void TestMultiSet2SetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2SetBase.Add(derived1);
            redef.MultiSet2SetBase.Add(derived1);
            redef.MultiSet2SetBase.Add(derived1);
            Assert.Single(redef.MultiSet2SetDerived);
            Assert.Single(redef.MultiSet2SetBase);
            Assert.Contains(derived1, redef.MultiSet2SetDerived);
            Assert.Contains(derived1, redef.MultiSet2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiSet2SetDerived);
            Assert.Single(iredef.MultiSet2SetBase);
            Assert.Contains(iderived1, iredef.MultiSet2SetDerived);
            Assert.Contains(iderived1, iredef.MultiSet2SetBase);
        }

        [Fact]
        public void TestMultiSet2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2SetDerived.Add(derived1);
            redef.MultiSet2SetDerived.Add(derived1);
            redef.MultiSet2SetDerived.Add(derived1);
            Assert.Single(redef.MultiSet2SetDerived);
            Assert.Single(redef.MultiSet2SetBase);
            Assert.Contains(derived1, redef.MultiSet2SetDerived);
            Assert.Contains(derived1, redef.MultiSet2SetBase);
            redef.MultiSet2SetDerived.Remove(derived1);
            Assert.True(redef.MultiSet2SetDerived.Count == 0);
            Assert.True(redef.MultiSet2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiSet2SetDerived.Count == 0);
            Assert.True(iredef.MultiSet2SetBase.Count == 0);
        }

        [Fact]
        public void TestMultiSet2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2SetDerived.Add(derived1);
            redef.MultiSet2SetDerived.Add(derived1);
            redef.MultiSet2SetDerived.Add(derived1);
            Assert.Single(redef.MultiSet2SetDerived);
            Assert.Single(redef.MultiSet2SetBase);
            Assert.Contains(derived1, redef.MultiSet2SetDerived);
            Assert.Contains(derived1, redef.MultiSet2SetBase);
            redef.MultiSet2SetBase.Remove(derived1);
            Assert.True(redef.MultiSet2SetDerived.Count == 0);
            Assert.True(redef.MultiSet2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiSet2SetDerived.Count == 0);
            Assert.True(iredef.MultiSet2SetBase.Count == 0);
        }

        [Fact]
        public void TestMultiList2Set()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2SetDerived.Add(derived1);
            redef.MultiList2SetDerived.Add(derived1);
            redef.MultiList2SetDerived.Add(derived1);
            Assert.Single(redef.MultiList2SetDerived);
            Assert.Single(redef.MultiList2SetBase);
            Assert.Contains(derived1, redef.MultiList2SetDerived);
            Assert.Contains(derived1, redef.MultiList2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiList2SetDerived);
            Assert.Single(iredef.MultiList2SetBase);
            Assert.Contains(iderived1, iredef.MultiList2SetDerived);
            Assert.Contains(iderived1, iredef.MultiList2SetBase);
        }

        [Fact]
        public void TestMultiList2SetBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.MultiList2SetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiList2SetBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiList2SetBase.Add(base1));
            Assert.True(redef.MultiList2SetDerived.Count == 0);
            Assert.True(redef.MultiList2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiList2SetDerived.Count == 0);
            Assert.True(iredef.MultiList2SetBase.Count == 0);
        }

        [Fact]
        public void TestMultiList2SetBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2SetBase.Add(derived1);
            redef.MultiList2SetBase.Add(derived1);
            redef.MultiList2SetBase.Add(derived1);
            Assert.Single(redef.MultiList2SetDerived);
            Assert.Single(redef.MultiList2SetBase);
            Assert.Contains(derived1, redef.MultiList2SetDerived);
            Assert.Contains(derived1, redef.MultiList2SetBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiList2SetDerived);
            Assert.Single(iredef.MultiList2SetBase);
            Assert.Contains(iderived1, iredef.MultiList2SetDerived);
            Assert.Contains(iderived1, iredef.MultiList2SetBase);
        }

        [Fact]
        public void TestMultiList2SetReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2SetDerived.Add(derived1);
            redef.MultiList2SetDerived.Add(derived1);
            redef.MultiList2SetDerived.Add(derived1);
            Assert.Single(redef.MultiList2SetDerived);
            Assert.Single(redef.MultiList2SetBase);
            Assert.Contains(derived1, redef.MultiList2SetDerived);
            Assert.Contains(derived1, redef.MultiList2SetBase);
            redef.MultiList2SetDerived.Remove(derived1);
            Assert.True(redef.MultiList2SetDerived.Count == 0);
            Assert.True(redef.MultiList2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiList2SetDerived.Count == 0);
            Assert.True(iredef.MultiList2SetBase.Count == 0);
        }

        [Fact]
        public void TestMultiList2SetResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2SetDerived.Add(derived1);
            redef.MultiList2SetDerived.Add(derived1);
            redef.MultiList2SetDerived.Add(derived1);
            Assert.Single(redef.MultiList2SetDerived);
            Assert.Single(redef.MultiList2SetBase);
            Assert.Contains(derived1, redef.MultiList2SetDerived);
            Assert.Contains(derived1, redef.MultiList2SetBase);
            redef.MultiList2SetBase.Remove(derived1);
            Assert.True(redef.MultiList2SetDerived.Count == 0);
            Assert.True(redef.MultiList2SetBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiList2SetDerived.Count == 0);
            Assert.True(iredef.MultiList2SetBase.Count == 0);
        }



        [Fact]
        public void TestMultiSet2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2ListDerived.Add(derived1);
            redef.MultiSet2ListDerived.Add(derived1);
            redef.MultiSet2ListDerived.Add(derived1);
            Assert.Single(redef.MultiSet2ListDerived);
            Assert.Single(redef.MultiSet2ListBase);
            Assert.Contains(derived1, redef.MultiSet2ListDerived);
            Assert.Contains(derived1, redef.MultiSet2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiSet2ListDerived);
            Assert.Single(iredef.MultiSet2ListBase);
            Assert.Contains(iderived1, iredef.MultiSet2ListDerived);
            Assert.Contains(iderived1, iredef.MultiSet2ListBase);
        }

        [Fact]
        public void TestMultiSet2ListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.MultiSet2ListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiSet2ListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiSet2ListBase.Add(base1));
            Assert.True(redef.MultiSet2ListDerived.Count == 0);
            Assert.True(redef.MultiSet2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiSet2ListDerived.Count == 0);
            Assert.True(iredef.MultiSet2ListBase.Count == 0);
        }

        [Fact]
        public void TestMultiSet2ListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2ListBase.Add(derived1);
            redef.MultiSet2ListBase.Add(derived1);
            redef.MultiSet2ListBase.Add(derived1);
            Assert.Single(redef.MultiSet2ListDerived);
            Assert.Single(redef.MultiSet2ListBase);
            Assert.Contains(derived1, redef.MultiSet2ListDerived);
            Assert.Contains(derived1, redef.MultiSet2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiSet2ListDerived);
            Assert.Single(iredef.MultiSet2ListBase);
            Assert.Contains(iderived1, iredef.MultiSet2ListDerived);
            Assert.Contains(iderived1, iredef.MultiSet2ListBase);
        }

        [Fact]
        public void TestMultiSet2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2ListDerived.Add(derived1);
            redef.MultiSet2ListDerived.Add(derived1);
            redef.MultiSet2ListDerived.Add(derived1);
            Assert.Single(redef.MultiSet2ListDerived);
            Assert.Single(redef.MultiSet2ListBase);
            Assert.Contains(derived1, redef.MultiSet2ListDerived);
            Assert.Contains(derived1, redef.MultiSet2ListBase);
            redef.MultiSet2ListDerived.Remove(derived1);
            Assert.True(redef.MultiSet2ListDerived.Count == 0);
            Assert.True(redef.MultiSet2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiSet2ListDerived.Count == 0);
            Assert.True(iredef.MultiSet2ListBase.Count == 0);
        }

        [Fact]
        public void TestMultiSet2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiSet2ListDerived.Add(derived1);
            redef.MultiSet2ListDerived.Add(derived1);
            redef.MultiSet2ListDerived.Add(derived1);
            Assert.Single(redef.MultiSet2ListDerived);
            Assert.Single(redef.MultiSet2ListBase);
            Assert.Contains(derived1, redef.MultiSet2ListDerived);
            Assert.Contains(derived1, redef.MultiSet2ListBase);
            redef.MultiSet2ListBase.Remove(derived1);
            Assert.True(redef.MultiSet2ListDerived.Count == 0);
            Assert.True(redef.MultiSet2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiSet2ListDerived.Count == 0);
            Assert.True(iredef.MultiSet2ListBase.Count == 0);
        }

        [Fact]
        public void TestMultiList2List()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2ListDerived.Add(derived1);
            redef.MultiList2ListDerived.Add(derived1);
            redef.MultiList2ListDerived.Add(derived1);
            Assert.Single(redef.MultiList2ListDerived);
            Assert.Single(redef.MultiList2ListBase);
            Assert.Contains(derived1, redef.MultiList2ListDerived);
            Assert.Contains(derived1, redef.MultiList2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiList2ListDerived);
            Assert.Single(iredef.MultiList2ListBase);
            Assert.Contains(iderived1, iredef.MultiList2ListDerived);
            Assert.Contains(iderived1, iredef.MultiList2ListBase);
        }

        [Fact]
        public void TestMultiList2ListBaseError()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            Assert.Throws<ModelException>(() => redef.MultiList2ListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiList2ListBase.Add(base1));
            Assert.Throws<ModelException>(() => redef.MultiList2ListBase.Add(base1));
            Assert.True(redef.MultiList2ListDerived.Count == 0);
            Assert.True(redef.MultiList2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiList2ListDerived.Count == 0);
            Assert.True(iredef.MultiList2ListBase.Count == 0);
        }

        [Fact]
        public void TestMultiList2ListBaseOk()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2ListBase.Add(derived1);
            redef.MultiList2ListBase.Add(derived1);
            redef.MultiList2ListBase.Add(derived1);
            Assert.Single(redef.MultiList2ListDerived);
            Assert.Single(redef.MultiList2ListBase);
            Assert.Contains(derived1, redef.MultiList2ListDerived);
            Assert.Contains(derived1, redef.MultiList2ListBase);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.Single(iredef.MultiList2ListDerived);
            Assert.Single(iredef.MultiList2ListBase);
            Assert.Contains(iderived1, iredef.MultiList2ListDerived);
            Assert.Contains(iderived1, iredef.MultiList2ListBase);
        }

        [Fact]
        public void TestMultiList2ListReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2ListDerived.Add(derived1);
            redef.MultiList2ListDerived.Add(derived1);
            redef.MultiList2ListDerived.Add(derived1);
            Assert.Single(redef.MultiList2ListDerived);
            Assert.Single(redef.MultiList2ListBase);
            Assert.Contains(derived1, redef.MultiList2ListDerived);
            Assert.Contains(derived1, redef.MultiList2ListBase);
            redef.MultiList2ListDerived.Remove(derived1);
            Assert.True(redef.MultiList2ListDerived.Count == 0);
            Assert.True(redef.MultiList2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiList2ListDerived.Count == 0);
            Assert.True(iredef.MultiList2ListBase.Count == 0);
        }

        [Fact]
        public void TestMultiList2ListResetBase()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var redef = factory.RedefinitionBase2Derived();
            redef.MultiList2ListDerived.Add(derived1);
            redef.MultiList2ListDerived.Add(derived1);
            redef.MultiList2ListDerived.Add(derived1);
            Assert.Single(redef.MultiList2ListDerived);
            Assert.Single(redef.MultiList2ListBase);
            Assert.Contains(derived1, redef.MultiList2ListDerived);
            Assert.Contains(derived1, redef.MultiList2ListBase);
            redef.MultiList2ListBase.Remove(derived1);
            Assert.True(redef.MultiList2ListDerived.Count == 0);
            Assert.True(redef.MultiList2ListBase.Count == 0);
            var imodel = model.ToImmutable();
            var ibase1 = base1.ToImmutable(imodel);
            var iderived1 = derived1.ToImmutable(imodel);
            var iredef = redef.ToImmutable(imodel);
            Assert.True(iredef.MultiList2ListDerived.Count == 0);
            Assert.True(iredef.MultiList2ListBase.Count == 0);
        }
    }
}
