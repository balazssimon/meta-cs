using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Immutable.Test
{
    using MetaDslx.Core.Immutable;

    [TestClass]
    public class ImmutableInheritanceTest
    {
        [TestMethod]
        public void TestPersonPetStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Pet t1 = f.Pet();
            t1.Owner = p1;
            Assert.AreEqual(p1, t1.Owner);
            Assert.AreEqual(1, p1.Pets.Count);
            Assert.AreEqual(t1, p1.Pets[0]);
        }

        [TestMethod]
        public void TestPersonPetStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Pet t1 = f.Pet();
            p1.Pets.Add(t1);
            Assert.AreEqual(p1, t1.Owner);
            Assert.AreEqual(1, p1.Pets.Count);
            Assert.AreEqual(t1, p1.Pets[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException))]
        public void TestPersonDogStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Dog d1 = f.Dog();
            d1.Owner = p1;
            Assert.AreEqual(p1, d1.Owner);
            Assert.AreEqual(1, p1.Pets.Count);
            Assert.AreEqual(d1, p1.Pets[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException))]
        public void TestPersonDogStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Dog d1 = f.Dog();
            p1.Pets.Add(d1);
            Assert.AreEqual(p1, d1.Owner);
            Assert.AreEqual(1, p1.Pets.Count);
            Assert.AreEqual(d1, p1.Pets[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException))]
        public void TestStudentPetStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Pet t1 = f.Pet();
            t1.Owner = s1;
            Assert.AreEqual(s1, t1.Owner);
            Assert.AreEqual(1, s1.Pets.Count);
            Assert.AreEqual(t1, s1.Pets[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException))]
        public void TestStudentPetStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Pet t1 = f.Pet();
            s1.Pets.Add(t1);
            Assert.AreEqual(s1, t1.Owner);
            Assert.AreEqual(1, s1.Pets.Count);
            Assert.AreEqual(t1, s1.Pets[0]);
        }

        [TestMethod]
        public void TestStudentDogStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            d1.Owner = s1;
            Assert.AreEqual(s1, d1.Owner);
            Assert.AreEqual(1, s1.Pets.Count);
            Assert.AreEqual(d1, s1.Pets[0]);
            Assert.AreEqual(s1, d1.Friend);
            Assert.AreEqual(1, s1.Dogs.Count);
            Assert.AreEqual(d1, s1.Dogs[0]);
        }

        [TestMethod]
        public void TestStudentDogStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            s1.Pets.Add(d1);
            Assert.AreEqual(s1, d1.Owner);
            Assert.AreEqual(1, s1.Pets.Count);
            Assert.AreEqual(d1, s1.Pets[0]);
            Assert.AreEqual(s1, d1.Friend);
            Assert.AreEqual(1, s1.Dogs.Count);
            Assert.AreEqual(d1, s1.Dogs[0]);
        }

        [TestMethod]
        public void TestStudentDogStatic3()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            d1.Friend = s1;
            Assert.AreEqual(s1, d1.Owner);
            Assert.AreEqual(1, s1.Pets.Count);
            Assert.AreEqual(d1, s1.Pets[0]);
            Assert.AreEqual(s1, d1.Friend);
            Assert.AreEqual(1, s1.Dogs.Count);
            Assert.AreEqual(d1, s1.Dogs[0]);
        }

        [TestMethod]
        public void TestStudentDogStatic4()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            s1.Dogs.Add(d1);
            Assert.AreEqual(s1, d1.Owner);
            Assert.AreEqual(1, s1.Pets.Count);
            Assert.AreEqual(d1, s1.Pets[0]);
            Assert.AreEqual(s1, d1.Friend);
            Assert.AreEqual(1, s1.Dogs.Count);
            Assert.AreEqual(d1, s1.Dogs[0]);
        }

    }

}
