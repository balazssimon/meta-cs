using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetaDslx.Core.Immutable;

namespace MetaDslx.Core.Test
{
    /*
    [TestClass]
    public class ImmutableMetaModelTest
    {
        [TestMethod]
        public void TestHusbandWifeStatic1()
        {
            ImmutableTestModelBuilderFactory bf = new ImmutableTestModelBuilderFactory();
            ImmutableHusbandBuilder h1 = bf.CreateHusband();
            ImmutableWifeBuilder w1 = bf.CreateWife();
            h1.Name = "h1";
            h1.Wife = w1;
            w1.Name = "w1";
            Assert.AreEqual(w1, h1.Wife);
            Assert.AreEqual(h1, w1.Husband);
            Assert.AreEqual("h1", h1.Name);
            Assert.AreEqual("w1", w1.Name);
            Assert.AreEqual("w1", h1.Wife.Name);
            Assert.AreEqual("h1", w1.Husband.Name);

            ImmutableModel model = bf.Builder.ToImmutable();
            ImmutableHusband ih1 = bf.GetHusband(model, h1);
            ImmutableWife iw1 = bf.GetWife(model, w1);
            Assert.AreEqual(iw1, ih1.Wife);
            Assert.AreEqual(ih1, iw1.Husband);
            Assert.AreEqual("h1", ih1.Name);
            Assert.AreEqual("w1", iw1.Name);
            Assert.AreEqual("w1", ih1.Wife.Name);
            Assert.AreEqual("h1", iw1.Husband.Name);
        }
    }
    */
}
