using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class ModelPropertyTest
    {
        [TestMethod]
        public void TestHusbandWifeStatic1()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            h1.Wife = w1;
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
        }

        [TestMethod]
        public void TestHusbandWifeStatic2()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            Wife w2 = new Wife();
            h1.Wife = w1;
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            h1.Wife = w2;
            Assert.AreEqual(h1.Wife, w2);
            Assert.AreEqual(w1.Husband, null);
            Assert.AreEqual(w2.Husband, h1);
        }

        [TestMethod]
        public void TestHusbandWifeStatic3()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            h1.Wife = w1;
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            Wife w2 = new Wife();
            h1.Wife = w2;
            Assert.AreEqual(h1.Wife, w2);
            Assert.AreEqual(w1.Husband, null);
            Assert.AreEqual(w2.Husband, h1);
            h1.Wife = null;
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(w1.Husband, null);
            Assert.AreEqual(w2.Husband, null);
        }

        [TestMethod]
        public void TestHusbandWifeDynamic()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            h1.MSetValue(Husband.WifeProperty, w1);
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            h1.MSetValue(Husband.WifeProperty, null);
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(w1.Husband, null);
        }

        [TestMethod]
        public void TestWifeHusbandStatic1()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            w1.Husband = h1;
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
        }

        [TestMethod]
        public void TestWifeHusbandStatic2()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            w1.Husband = h1;
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            Husband h2 = new Husband();
            w1.Husband = h2;
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(h2.Wife, w1);
            Assert.AreEqual(w1.Husband, h2);
        }

        [TestMethod]
        public void TestWifeHusbandStatic3()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            w1.Husband = h1;
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            Husband h2 = new Husband();
            w1.Husband = h2;
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(h2.Wife, w1);
            Assert.AreEqual(w1.Husband, h2);
            w1.Husband = null;
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(h2.Wife, null);
            Assert.AreEqual(w1.Husband, null);
        }

        [TestMethod]
        public void TestWifeHusbandDynamic()
        {
            Husband h1 = new Husband();
            Wife w1 = new Wife();
            w1.MSetValue(Wife.HusbandProperty, h1);
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            w1.MSetValue(Wife.HusbandProperty, null);
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(w1.Husband, null);
        }

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

        [TestMethod]
        public void TestUserRoleStatic1()
        {
            User u1 = new User();
            User u2 = new User();
            Role r1 = new Role();
            Role r2 = new Role();
            u1.Roles.Add(r1);
            Assert.IsTrue(u1.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u1));
            r1.Users.Add(u2);
            Assert.IsTrue(u1.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u2));
            r2.Users.Add(u2);
            Assert.IsTrue(u1.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r2));
            Assert.IsTrue(r2.Users.Contains(u2));
            r1.Users.Remove(u1);
            Assert.IsTrue(!u1.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r2));
            Assert.IsTrue(r2.Users.Contains(u2));
            r1.Users.Remove(u2);
            Assert.IsTrue(!u1.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u1));
            Assert.IsTrue(!u2.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r2));
            Assert.IsTrue(r2.Users.Contains(u2));
            u2.Roles.Remove(r2);
            Assert.IsTrue(!u1.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u1));
            Assert.IsTrue(!u2.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(!u2.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u2));
        }

        [TestMethod]
        public void TestUserRoleStatic2()
        {
            User u1 = new User();
            User u2 = new User();
            Role r1 = new Role();
            Role r2 = new Role();
            u1.Roles.Add(r1);
            u1.Roles.Add(r1);
            Assert.IsTrue(u1.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u1));
            r1.Users.Add(u2);
            Assert.IsTrue(u1.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u2));
            r2.Users.Add(u2);
            Assert.IsTrue(u1.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r2));
            Assert.IsTrue(r2.Users.Contains(u2));
            r1.Users.Remove(u1);
            Assert.IsTrue(!u1.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r1));
            Assert.IsTrue(r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r2));
            Assert.IsTrue(r2.Users.Contains(u2));
            r1.Users.Remove(u2);
            Assert.IsTrue(!u1.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u1));
            Assert.IsTrue(!u2.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(u2.Roles.Contains(r2));
            Assert.IsTrue(r2.Users.Contains(u2));
            u2.Roles.Remove(r2);
            Assert.IsTrue(!u1.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u1));
            Assert.IsTrue(!u2.Roles.Contains(r1));
            Assert.IsTrue(!r1.Users.Contains(u2));
            Assert.IsTrue(!u1.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u1));
            Assert.IsTrue(!u2.Roles.Contains(r2));
            Assert.IsTrue(!r2.Users.Contains(u2));
        }
    }
}
