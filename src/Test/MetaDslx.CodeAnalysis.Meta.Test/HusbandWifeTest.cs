using MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest;
using MetaDslx.Modeling;
using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Meta.Test
{
    public class HusbandWifeTest : DebugAssertUnitTest
    {
        [Fact]
        public void TestHusbandToWife()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var husband = factory.Husband();
            var wife = factory.Wife();
            husband.Wife = wife;
            Assert.Equal(wife, husband.Wife);
            Assert.Equal(husband, wife.Husband);
            var imodel = model.ToImmutable();
            var ihusband = husband.ToImmutable(imodel);
            var iwife = wife.ToImmutable(imodel);
            Assert.Equal(iwife, ihusband.Wife);
            Assert.Equal(ihusband, iwife.Husband);
        }

        [Fact]
        public void TestWifeToHusband()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var husband = factory.Husband();
            var wife = factory.Wife();
            wife.Husband = husband;
            Assert.Equal(wife, husband.Wife);
            Assert.Equal(husband, wife.Husband);
            var imodel = model.ToImmutable();
            var ihusband = husband.ToImmutable(imodel);
            var iwife = wife.ToImmutable(imodel);
            Assert.Equal(iwife, ihusband.Wife);
            Assert.Equal(ihusband, iwife.Husband);
        }

        [Fact]
        public void TestHusbandToWifeReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var husband = factory.Husband();
            var wife = factory.Wife();
            husband.Wife = wife;
            Assert.Equal(wife, husband.Wife);
            Assert.Equal(husband, wife.Husband);
            husband.Wife = null;
            Assert.Null(husband.Wife);
            Assert.Null(wife.Husband);
            var imodel = model.ToImmutable();
            var ihusband = husband.ToImmutable(imodel);
            var iwife = wife.ToImmutable(imodel);
            Assert.Null(ihusband.Wife);
            Assert.Null(iwife.Husband);
        }

        [Fact]
        public void TestWifeToHusbandReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var husband = factory.Husband();
            var wife = factory.Wife();
            wife.Husband = husband;
            Assert.Equal(wife, husband.Wife);
            Assert.Equal(husband, wife.Husband);
            wife.Husband = null;
            Assert.Null(husband.Wife);
            Assert.Null(wife.Husband);
            var imodel = model.ToImmutable();
            var ihusband = husband.ToImmutable(imodel);
            var iwife = wife.ToImmutable(imodel);
            Assert.Null(ihusband.Wife);
            Assert.Null(iwife.Husband);
        }

        [Fact]
        public void TestHusbandToWifeCrossReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var husband = factory.Husband();
            var wife = factory.Wife();
            husband.Wife = wife;
            Assert.Equal(wife, husband.Wife);
            Assert.Equal(husband, wife.Husband);
            wife.Husband = null;
            Assert.Null(husband.Wife);
            Assert.Null(wife.Husband);
            var imodel = model.ToImmutable();
            var ihusband = husband.ToImmutable(imodel);
            var iwife = wife.ToImmutable(imodel);
            Assert.Null(ihusband.Wife);
            Assert.Null(iwife.Husband);
        }

        [Fact]
        public void TestWifeToHusbandCrossReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var husband = factory.Husband();
            var wife = factory.Wife();
            wife.Husband = husband;
            Assert.Equal(wife, husband.Wife);
            Assert.Equal(husband, wife.Husband);
            husband.Wife = null;
            Assert.Null(husband.Wife);
            Assert.Null(wife.Husband);
            var imodel = model.ToImmutable();
            var ihusband = husband.ToImmutable(imodel);
            var iwife = wife.ToImmutable(imodel);
            Assert.Null(ihusband.Wife);
            Assert.Null(iwife.Husband);
        }
    }
}
