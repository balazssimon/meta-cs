using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImmutableModelPrototypeTest
{
    using ImmutableModelPrototype;

    [TestClass]
    public class ImmutableMetaModelTest
    {
        [TestMethod]
        public void TestHusbandWifeStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Husband h1 = f.Husband();
            Husband h2 = f.Husband();
            Wife w1 = f.Wife();
            h1.Name = "h1";
            h1.Wife = w1;
            w1.Name = "w1";
            h2.Name = "h2";
            Assert.AreEqual(w1, h1.Wife);
            Assert.AreEqual(h1, w1.Husband);
            Assert.AreEqual("h1", h1.Name);
            Assert.AreEqual("w1", w1.Name);
            Assert.AreEqual("w1", h1.Wife.Name);
            Assert.AreEqual("h1", w1.Husband.Name);
            w1.Husband = h2;
            Assert.AreEqual(null, h1.Wife);
            Assert.AreEqual(w1, h2.Wife);
            Assert.AreEqual(h2, w1.Husband);
            Assert.AreEqual("h1", h1.Name);
            Assert.AreEqual("w1", w1.Name);
            Assert.AreEqual("w1", h2.Wife.Name);
            Assert.AreEqual("h2", w1.Husband.Name);
            w1.Husband = h1;
            Assert.AreEqual(w1, h1.Wife);
            Assert.AreEqual(null, h2.Wife);
            Assert.AreEqual(h1, w1.Husband);
            Assert.AreEqual("h1", h1.Name);
            Assert.AreEqual("w1", w1.Name);
            Assert.AreEqual("w1", h1.Wife.Name);
            Assert.AreEqual("h1", w1.Husband.Name);

            ImmutableModel imodel = model.ToImmutable();
            ImmutableHusband ih1 = (ImmutableHusband)imodel.GetSymbol(h1);
            ImmutableWife iw1 = (ImmutableWife)imodel.GetSymbol(w1);
            Assert.AreEqual(iw1, ih1.Wife);
            Assert.AreEqual(ih1, iw1.Husband);
            Assert.AreEqual("h1", ih1.Name);
            Assert.AreEqual("w1", iw1.Name);
            Assert.AreEqual("w1", ih1.Wife.Name);
            Assert.AreEqual("h1", iw1.Husband.Name);

            Assert.AreEqual(iw1, w1.ToImmutable());
            Assert.AreEqual(ih1, h1.ToImmutable());
            ih1 = h1.ToImmutable();
            iw1 = w1.ToImmutable();
            Assert.AreEqual(iw1, ih1.Wife);
            Assert.AreEqual(ih1, iw1.Husband);
            Assert.AreEqual("h1", ih1.Name);
            Assert.AreEqual("w1", iw1.Name);
            Assert.AreEqual("w1", ih1.Wife.Name);
            Assert.AreEqual("h1", iw1.Husband.Name);

            Assert.AreEqual(w1, iw1.ToMutable());
            Assert.AreEqual(h1, ih1.ToMutable());
        }

        [TestMethod]
        public void TestListParentChildStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(p1, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(p1, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(2, p1.Children.Count);
            Assert.AreEqual(c1, p1.Children[0]);
            Assert.AreEqual(c2, p1.Children[1]);
            Assert.AreEqual(2, p1.MChildren.Count);
            Assert.AreEqual(c1, p1.MChildren[0]);
            Assert.AreEqual(c2, p1.MChildren[1]);
        }

        [TestMethod]
        public void TestListParentChildStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(p1, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(p1, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(2, p1.Children.Count);
            Assert.AreEqual(c1, p1.Children[0]);
            Assert.AreEqual(c2, p1.Children[1]);
            Assert.AreEqual(2, p1.MChildren.Count);
            Assert.AreEqual(c1, p1.MChildren[0]);
            Assert.AreEqual(c2, p1.MChildren[1]);
            c1.Parent = null;
            Assert.AreEqual(null, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(null, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(1, p1.Children.Count);
            Assert.AreEqual(c2, p1.Children[0]);
            Assert.AreEqual(1, p1.MChildren.Count);
            Assert.AreEqual(c2, p1.MChildren[0]);
        }

        [TestMethod]
        public void TestListChildParentStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(p1, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(p1, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(2, p1.Children.Count);
            Assert.AreEqual(c1, p1.Children[0]);
            Assert.AreEqual(c2, p1.Children[1]);
            Assert.AreEqual(2, p1.MChildren.Count);
            Assert.AreEqual(c1, p1.MChildren[0]);
            Assert.AreEqual(c2, p1.MChildren[1]);
        }

        [TestMethod]
        public void TestListChildParentStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(p1, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(p1, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(2, p1.Children.Count);
            Assert.AreEqual(c1, p1.Children[0]);
            Assert.AreEqual(c2, p1.Children[1]);
            Assert.AreEqual(2, p1.MChildren.Count);
            Assert.AreEqual(c1, p1.MChildren[0]);
            Assert.AreEqual(c2, p1.MChildren[1]);
            p1.Children.Remove(c1);
            Assert.AreEqual(null, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(null, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(1, p1.Children.Count);
            Assert.AreEqual(c2, p1.Children[0]);
            Assert.AreEqual(1, p1.MChildren.Count);
            Assert.AreEqual(c2, p1.MChildren[0]);
            p1.Children.Add(c1);
            Assert.AreEqual(p1, c1.Parent);
            Assert.AreEqual(p1, c2.Parent);
            Assert.AreEqual(p1, c1.MParent);
            Assert.AreEqual(p1, c2.MParent);
            Assert.AreEqual(2, p1.Children.Count);
            Assert.AreEqual(c1, p1.Children[1]);
            Assert.AreEqual(c2, p1.Children[0]);
            Assert.AreEqual(2, p1.MChildren.Count);
            Assert.AreEqual(c1, p1.MChildren[1]);
            Assert.AreEqual(c2, p1.MChildren[0]);
            c1.Parent = null;
            p1.Children.Remove(c2);
            Assert.AreEqual(null, c1.Parent);
            Assert.AreEqual(null, c2.Parent);
            Assert.AreEqual(null, c1.MParent);
            Assert.AreEqual(null, c2.MParent);
            Assert.AreEqual(0, p1.Children.Count);
            Assert.AreEqual(0, p1.MChildren.Count);
        }
    }
}
