using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class OneToOnePropertyTest
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
            h1.MSet(Husband.WifeProperty, w1);
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            h1.MSet(Husband.WifeProperty, null);
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
            w1.MSet(Wife.HusbandProperty, h1);
            Assert.AreEqual(h1.Wife, w1);
            Assert.AreEqual(w1.Husband, h1);
            w1.MSet(Wife.HusbandProperty, null);
            Assert.AreEqual(h1.Wife, null);
            Assert.AreEqual(w1.Husband, null);
        }

    }
}
