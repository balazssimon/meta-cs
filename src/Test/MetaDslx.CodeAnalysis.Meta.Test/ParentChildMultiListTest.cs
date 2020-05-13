using MetaDslx.CodeAnalysis.Meta.Test.Languages.PropertiesTest;
using MetaDslx.Modeling;
using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Meta.Test
{
    public class ParentChildMultiListTest : DebugAssertUnitTest
    {
        [Fact]
        public void TestChildToParent()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            child.Parent = parent;
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Equal(iparent, ichild.Parent);
            Assert.Contains(ichild, iparent.Children);
            Assert.True(iparent.Children.Count == 1);
            Assert.Equal(ichild, iparent.Children[0]);
        }

        [Fact]
        public void TestParentToChild()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            parent.Children.Add(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Equal(iparent, ichild.Parent);
            Assert.Contains(ichild, iparent.Children);
            Assert.True(iparent.Children.Count == 1);
            Assert.Equal(ichild, iparent.Children[0]);
        }

        [Fact]
        public void TestChildToParentReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            child.Parent = parent;
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            child.Parent = null;
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }

        [Fact]
        public void TestParentToChildReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            parent.Children.Add(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            parent.Children.Remove(child);
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }

        [Fact]
        public void TestChildToParentCrossReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            child.Parent = parent;
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            parent.Children.Remove(child);
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }

        [Fact]
        public void TestParentToChildCrossReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            parent.Children.Add(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            child.Parent = null;
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }

        [Fact]
        public void TestManyChildrenToParent()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            child.Parent = parent;
            child.Parent = parent;
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Equal(iparent, ichild.Parent);
            Assert.Contains(ichild, iparent.Children);
            Assert.True(iparent.Children.Count == 1);
            Assert.Equal(ichild, iparent.Children[0]);
        }

        [Fact]
        public void TestParentToManyChildren()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            parent.Children.Add(child);
            parent.Children.Add(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 2);
            Assert.Equal(child, parent.Children[0]);
            Assert.Equal(child, parent.Children[1]);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Equal(iparent, ichild.Parent);
            Assert.Contains(ichild, iparent.Children);
            Assert.True(iparent.Children.Count == 2);
            Assert.Equal(ichild, iparent.Children[0]);
            Assert.Equal(ichild, iparent.Children[1]);
        }

        [Fact]
        public void TestManyChildrenToParentReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            child.Parent = parent;
            child.Parent = parent;
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            child.Parent = null;
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }

        [Fact]
        public void TestParentToManyChildrenReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            parent.Children.Add(child);
            parent.Children.Add(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 2);
            Assert.Equal(child, parent.Children[0]);
            Assert.Equal(child, parent.Children[1]);
            parent.Children.Remove(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Equal(iparent, ichild.Parent);
            Assert.Contains(ichild, iparent.Children);
            Assert.True(iparent.Children.Count == 1);
            Assert.Equal(ichild, iparent.Children[0]);
        }

        [Fact]
        public void TestManyChildrenToParentCrossReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            child.Parent = parent;
            child.Parent = parent;
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 1);
            Assert.Equal(child, parent.Children[0]);
            parent.Children.Remove(child);
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }

        [Fact]
        public void TestParentToManyChildrenCrossReset()
        {
            var model = new MutableModel();
            var factory = new PropertiesTestFactory(model);
            var parent = factory.ParentMultiList();
            var child = factory.ChildMultiList();
            parent.Children.Add(child);
            parent.Children.Add(child);
            Assert.Equal(parent, child.Parent);
            Assert.Contains(child, parent.Children);
            Assert.True(parent.Children.Count == 2);
            Assert.Equal(child, parent.Children[0]);
            Assert.Equal(child, parent.Children[1]);
            child.Parent = null;
            Assert.Null(child.Parent);
            Assert.True(parent.Children.Count == 0);
            var imodel = model.ToImmutable();
            var iparent = parent.ToImmutable(imodel);
            var ichild = child.ToImmutable(imodel);
            Assert.Null(ichild.Parent);
            Assert.True(iparent.Children.Count == 0);
        }
    }
}
