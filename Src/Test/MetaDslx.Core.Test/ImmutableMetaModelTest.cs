using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Immutable.Test
{
    using MetaDslx.Core.Immutable;

    [TestClass]
    public class ImmutableMetaModelTest
    {
        [TestMethod]
        public void TestHusbandWifeStatic1()
        {
            MutableRedModel model = new MutableRedModel();
            TestModelFactory f = new TestModelFactory(model);
            Husband h1 = f.Husband();
            Wife w1 = f.Wife();
            h1.Name = "h1";
            h1.Wife = w1;
            w1.Name = "w1";
            Assert.AreEqual(w1, h1.Wife);
            Assert.AreEqual(h1, w1.Husband);
            Assert.AreEqual("h1", h1.Name);
            Assert.AreEqual("w1", w1.Name);
            Assert.AreEqual("w1", h1.Wife.Name);
            Assert.AreEqual("h1", w1.Husband.Name);

            ImmutableRedModel imodel = model.ToImmutable();
            ImmutableHusband ih1 = (ImmutableHusband)imodel.GetSymbol(h1);
            ImmutableWife iw1 = (ImmutableWife)imodel.GetSymbol(w1);
            Assert.AreEqual(iw1, ih1.Wife);
            Assert.AreEqual(ih1, iw1.Husband);
            Assert.AreEqual("h1", ih1.Name);
            Assert.AreEqual("w1", iw1.Name);
            Assert.AreEqual("w1", ih1.Wife.Name);
            Assert.AreEqual("h1", iw1.Husband.Name);
        }

        [TestMethod]
        public void TestListParentChildStatic1()
        {
            MutableRedModel model = new MutableRedModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.AreEqual(p1.Children[0], c1);
            Assert.AreEqual(p1.Children[1], c2);
        }

        [TestMethod]
        public void TestListParentChildStatic2()
        {
            MutableRedModel model = new MutableRedModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.AreEqual(p1.Children[0], c1);
            Assert.AreEqual(p1.Children[1], c2);
            c1.Parent = null;
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.AreEqual(p1.Children[0], c2);
        }
    }
}
