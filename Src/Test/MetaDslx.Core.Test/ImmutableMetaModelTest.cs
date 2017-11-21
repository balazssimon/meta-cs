using System;
using Xunit;

namespace MetaDslx.Core.Immutable.Test
{
    public class ImmutableMetaModelTest
    {
        [Fact]
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
            Assert.Equal(w1, h1.Wife);
            Assert.Equal(h1, w1.Husband);
            Assert.Equal("h1", h1.Name);
            Assert.Equal("w1", w1.Name);
            Assert.Equal("w1", h1.Wife.Name);
            Assert.Equal("h1", w1.Husband.Name);
            w1.Husband = h2;
            Assert.Null(h1.Wife);
            Assert.Equal(w1, h2.Wife);
            Assert.Equal(h2, w1.Husband);
            Assert.Equal("h1", h1.Name);
            Assert.Equal("w1", w1.Name);
            Assert.Equal("w1", h2.Wife.Name);
            Assert.Equal("h2", w1.Husband.Name);
            w1.Husband = h1;
            Assert.Equal(w1, h1.Wife);
            Assert.Null(h2.Wife);
            Assert.Equal(h1, w1.Husband);
            Assert.Equal("h1", h1.Name);
            Assert.Equal("w1", w1.Name);
            Assert.Equal("w1", h1.Wife.Name);
            Assert.Equal("h1", w1.Husband.Name);

            ImmutableModel imodel = model.ToImmutable();
            ImmutableHusband ih1 = (ImmutableHusband)imodel.GetSymbol(h1);
            ImmutableWife iw1 = (ImmutableWife)imodel.GetSymbol(w1);
            Assert.Equal(iw1, ih1.Wife);
            Assert.Equal(ih1, iw1.Husband);
            Assert.Equal("h1", ih1.Name);
            Assert.Equal("w1", iw1.Name);
            Assert.Equal("w1", ih1.Wife.Name);
            Assert.Equal("h1", iw1.Husband.Name);

            Assert.Equal(iw1, w1.ToImmutable());
            Assert.Equal(ih1, h1.ToImmutable());
            ih1 = h1.ToImmutable();
            iw1 = w1.ToImmutable();
            Assert.Equal(iw1, ih1.Wife);
            Assert.Equal(ih1, iw1.Husband);
            Assert.Equal("h1", ih1.Name);
            Assert.Equal("w1", iw1.Name);
            Assert.Equal("w1", ih1.Wife.Name);
            Assert.Equal("h1", iw1.Husband.Name);

            Assert.Equal(w1, iw1.ToMutable());
            Assert.Equal(h1, ih1.ToMutable());
        }

        [Fact]
        public void TestListParentChildStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.Equal(p1, c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Equal(p1, c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Equal(2, p1.Children.Count);
            Assert.Equal(c1, p1.Children[0]);
            Assert.Equal(c2, p1.Children[1]);
            Assert.Equal(2, p1.MChildren.Count);
            Assert.Equal(c1, p1.MChildren[0]);
            Assert.Equal(c2, p1.MChildren[1]);
        }

        [Fact]
        public void TestListParentChildStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.Equal(p1, c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Equal(p1, c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Equal(2, p1.Children.Count);
            Assert.Equal(c1, p1.Children[0]);
            Assert.Equal(c2, p1.Children[1]);
            Assert.Equal(2, p1.MChildren.Count);
            Assert.Equal(c1, p1.MChildren[0]);
            Assert.Equal(c2, p1.MChildren[1]);
            c1.Parent = null;
            Assert.Null(c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Null(c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Single(p1.Children);
            Assert.Equal(c2, p1.Children[0]);
            Assert.Single(p1.MChildren);
            Assert.Equal(c2, p1.MChildren[0]);
        }

        [Fact]
        public void TestListChildParentStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.Equal(p1, c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Equal(p1, c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Equal(2, p1.Children.Count);
            Assert.Equal(c1, p1.Children[0]);
            Assert.Equal(c2, p1.Children[1]);
            Assert.Equal(2, p1.MChildren.Count);
            Assert.Equal(c1, p1.MChildren[0]);
            Assert.Equal(c2, p1.MChildren[1]);
        }

        [Fact]
        public void TestListChildParentStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            ListParent p1 = f.ListParent();
            ListChild c1 = f.ListChild();
            ListChild c2 = f.ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.Equal(p1, c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Equal(p1, c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Equal(2, p1.Children.Count);
            Assert.Equal(c1, p1.Children[0]);
            Assert.Equal(c2, p1.Children[1]);
            Assert.Equal(2, p1.MChildren.Count);
            Assert.Equal(c1, p1.MChildren[0]);
            Assert.Equal(c2, p1.MChildren[1]);
            p1.Children.Remove(c1);
            Assert.Null(c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Null(c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Single(p1.Children);
            Assert.Equal(c2, p1.Children[0]);
            Assert.Single(p1.MChildren);
            Assert.Equal(c2, p1.MChildren[0]);
            p1.Children.Add(c1);
            Assert.Equal(p1, c1.Parent);
            Assert.Equal(p1, c2.Parent);
            Assert.Equal(p1, c1.MParent);
            Assert.Equal(p1, c2.MParent);
            Assert.Equal(2, p1.Children.Count);
            Assert.Equal(c1, p1.Children[1]);
            Assert.Equal(c2, p1.Children[0]);
            Assert.Equal(2, p1.MChildren.Count);
            Assert.Equal(c1, p1.MChildren[1]);
            Assert.Equal(c2, p1.MChildren[0]);
            c1.Parent = null;
            p1.Children.Remove(c2);
            Assert.Null(c1.Parent);
            Assert.Null(c2.Parent);
            Assert.Null(c1.MParent);
            Assert.Null(c2.MParent);
            Assert.Empty(p1.Children);
            Assert.Empty(p1.MChildren);
        }
    }
}
