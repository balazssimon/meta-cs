using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class OneToManyPropertyTest
    {
        [TestMethod]
        public void TestListParentChildStatic1()
        {
            ListParent p1 = new ListParent();
            ListChild c1 = new ListChild();
            ListChild c2 = new ListChild();
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
            ListParent p1 = new ListParent();
            ListChild c1 = new ListChild();
            ListChild c2 = new ListChild();
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

        [TestMethod]
        public void TestListParentChildStatic3()
        {
            ListParent p1 = new ListParent();
            ListChild c1 = new ListChild();
            ListChild c2 = new ListChild();
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
            c2.Parent = null;
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, null);
            Assert.AreEqual(p1.Children.Count, 0);
        }

        [TestMethod]
        public void TestListChildParentStatic1()
        {
            ListParent p1 = new ListParent();
            ListChild c1 = new ListChild();
            ListChild c2 = new ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.AreEqual(p1.Children[0], c1);
            Assert.AreEqual(p1.Children[1], c2);
        }

        [TestMethod]
        public void TestListChildParentStatic2()
        {
            ListParent p1 = new ListParent();
            ListChild c1 = new ListChild();
            ListChild c2 = new ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.AreEqual(p1.Children[0], c1);
            Assert.AreEqual(p1.Children[1], c2);
            p1.Children.Remove(c1);
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.AreEqual(p1.Children[0], c2);
        }

        [TestMethod]
        public void TestListChildParentStatic3()
        {
            ListParent p1 = new ListParent();
            ListChild c1 = new ListChild();
            ListChild c2 = new ListChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.AreEqual(p1.Children[0], c1);
            Assert.AreEqual(p1.Children[1], c2);
            p1.Children.Remove(c1);
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.AreEqual(p1.Children[0], c2);
            p1.Children.Remove(c2);
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, null);
            Assert.AreEqual(p1.Children.Count, 0);
        }

        [TestMethod]
        public void TestSetParentChildStatic1()
        {
            SetParent p1 = new SetParent();
            SetChild c1 = new SetChild();
            SetChild c2 = new SetChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.IsTrue(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
        }

        [TestMethod]
        public void TestSetParentChildStatic2()
        {
            SetParent p1 = new SetParent();
            SetChild c1 = new SetChild();
            SetChild c2 = new SetChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.IsTrue(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
            c1.Parent = null;
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.IsFalse(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
        }

        [TestMethod]
        public void TestSetParentChildStatic3()
        {
            SetParent p1 = new SetParent();
            SetChild c1 = new SetChild();
            SetChild c2 = new SetChild();
            c1.Parent = p1;
            c2.Parent = p1;
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.IsTrue(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
            c1.Parent = null;
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.IsFalse(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
            c2.Parent = null;
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, null);
            Assert.AreEqual(p1.Children.Count, 0);
        }

        [TestMethod]
        public void TestSetChildParentStatic1()
        {
            SetParent p1 = new SetParent();
            SetChild c1 = new SetChild();
            SetChild c2 = new SetChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.IsTrue(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
        }

        [TestMethod]
        public void TestSetChildParentStatic2()
        {
            SetParent p1 = new SetParent();
            SetChild c1 = new SetChild();
            SetChild c2 = new SetChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.IsTrue(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
            p1.Children.Remove(c1);
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.IsFalse(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
        }

        [TestMethod]
        public void TestSetChildParentStatic3()
        {
            SetParent p1 = new SetParent();
            SetChild c1 = new SetChild();
            SetChild c2 = new SetChild();
            p1.Children.Add(c1);
            p1.Children.Add(c2);
            Assert.AreEqual(c1.Parent, p1);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 2);
            Assert.IsTrue(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
            p1.Children.Remove(c1);
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, p1);
            Assert.AreEqual(p1.Children.Count, 1);
            Assert.IsFalse(p1.Children.Contains(c1));
            Assert.IsTrue(p1.Children.Contains(c2));
            p1.Children.Remove(c2);
            Assert.AreEqual(c1.Parent, null);
            Assert.AreEqual(c2.Parent, null);
            Assert.AreEqual(p1.Children.Count, 0);
        }


    }
}
