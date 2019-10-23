using MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Meta.Test
{
    public class UnionTest
    {
        [Fact]
        public void TestAddToSubset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var base2 = factory.BaseClass();
            var base3 = factory.BaseClass();
            var base4 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var derived2 = factory.DerivedClass();
            var derived3 = factory.DerivedClass();
            var derived4 = factory.DerivedClass();
            var subs = factory.UnionSet();
            Assert.Throws<ModelException>(() => subs.Union1.Add(base1));
            subs.Subset1.Add(base1);
            Assert.Single(subs.Union1);
            Assert.Contains(base1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(base1, subs.Subset1);
            subs.Subset1.Add(base1);
            Assert.Single(subs.Union1);
            Assert.Contains(base1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(base1, subs.Subset1);
            subs.Subset2.Add(base1);
            Assert.Single(subs.Union1);
            Assert.Contains(base1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(base1, subs.Subset1);
            Assert.Single(subs.Subset2);
            Assert.Contains(base1, subs.Subset2);
            subs.Subset3.Add(base1);
            Assert.Single(subs.Union1);
            Assert.Contains(base1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(base1, subs.Subset1);
            Assert.Single(subs.Subset2);
            Assert.Contains(base1, subs.Subset2);
            Assert.Single(subs.Subset3);
            Assert.Contains(base1, subs.Subset3);
            subs.Subset3.Add(base2);
            Assert.True(subs.Union1.Count == 2);
            Assert.Contains(base1, subs.Union1);
            Assert.Contains(base2, subs.Union1);
            Assert.True(subs.Subset1.Count == 2);
            Assert.Contains(base1, subs.Subset1);
            Assert.Contains(base2, subs.Subset1);
            Assert.Single(subs.Subset2);
            Assert.Contains(base1, subs.Subset2);
            Assert.True(subs.Subset3.Count == 2);
            Assert.Contains(base1, subs.Subset3);
            Assert.Contains(base2, subs.Subset3);
            subs.Subset4.Add(derived1);
            Assert.True(subs.Union1.Count == 3);
            Assert.Contains(base1, subs.Union1);
            Assert.Contains(base2, subs.Union1);
            Assert.True(subs.Subset1.Count == 3);
            Assert.Contains(base1, subs.Subset1);
            Assert.Contains(base2, subs.Subset1);
            Assert.Contains(derived1, subs.Subset1);
            Assert.Single(subs.Subset2);
            Assert.Contains(base1, subs.Subset2);
            Assert.True(subs.Subset3.Count == 2);
            Assert.Contains(base1, subs.Subset3);
            Assert.Contains(base2, subs.Subset3);
            Assert.Single(subs.Subset4);
            Assert.Contains(derived1, subs.Subset4);
            Assert.Throws<ModelException>(() => subs.Union1.Add(base1));
        }

        [Fact]
        public void TestAddToSubsetSingle()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var base1 = factory.BaseClass();
            var base2 = factory.BaseClass();
            var base3 = factory.BaseClass();
            var base4 = factory.BaseClass();
            var derived1 = factory.DerivedClass();
            var derived2 = factory.DerivedClass();
            var derived3 = factory.DerivedClass();
            var derived4 = factory.DerivedClass();
            var subs = factory.UnionSingle();
            subs.Subset4 = base1;
            Assert.Equal(base1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(base1, subs.Subset1);
            Assert.Equal(base1, subs.Subset4);
            Assert.Throws<ModelException>(() => subs.Subset1.Add(base2));
            Assert.Equal(base1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(base1, subs.Subset1);
            Assert.Equal(base1, subs.Subset4);
            subs.Subset5 = derived1;
            Assert.Equal(derived1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(derived1, subs.Subset1);
            Assert.Equal(derived1, subs.Subset4);
            Assert.Equal(derived1, subs.Subset5);
            Assert.Throws<ModelException>(() => subs.Subset1.Add(base2));
            subs.Subset5 = derived1;
            Assert.Equal(derived1, subs.Union1);
            Assert.Single(subs.Subset1);
            Assert.Contains(derived1, subs.Subset1);
            Assert.Equal(derived1, subs.Subset4);
            Assert.Equal(derived1, subs.Subset5);
        }
    }
}
