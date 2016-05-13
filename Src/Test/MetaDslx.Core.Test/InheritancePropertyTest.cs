using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class InheritancePropertyTest
    {
        [TestMethod]
        public void TestPersonPetStatic1()
        {
            Person p1 = new Person();
            Pet t1 = new Pet();
            t1.Owner = p1;
            Assert.AreEqual(t1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestPersonPetStatic2()
        {
            Person p1 = new Person();
            Pet t1 = new Pet();
            p1.Pets.Add(t1);
            Assert.AreEqual(t1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestPersonDogStatic1()
        {
            Person p1 = new Person();
            Dog d1 = new Dog();
            d1.Owner = p1;
            Assert.AreEqual(d1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestPersonDogStatic2()
        {
            Person p1 = new Person();
            Dog d1 = new Dog();
            p1.Pets.Add(d1);
            Assert.AreEqual(p1, d1.Owner);
            Assert.IsTrue(p1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestStudentPetStatic1()
        {
            Student s1 = new Student();
            Pet t1 = new Pet();
            t1.Owner = s1;
            Assert.AreEqual(t1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestStudentPetStatic2()
        {
            Student s1 = new Student();
            Pet t1 = new Pet();
            s1.Pets.Add(t1);
            Assert.AreEqual(t1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestStudentDogStatic1()
        {
            Student s1 = new Student();
            Dog d1 = new Dog();
            d1.Owner = s1;
            Assert.AreEqual(d1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestStudentDogStatic2()
        {
            Student s1 = new Student();
            Dog d1 = new Dog();
            s1.Pets.Add(d1);
            Assert.AreEqual(d1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestStudentDogStatic3()
        {
            Student s1 = new Student();
            Dog d1 = new Dog();
            d1.Friend = s1;
            Assert.AreEqual(d1.Friend, s1);
            Assert.IsTrue(s1.Dogs.Contains(d1));
        }

        [TestMethod]
        public void TestStudentDogStatic4()
        {
            Student s1 = new Student();
            Dog d1 = new Dog();
            s1.Dogs.Add(d1);
            Assert.AreEqual(d1.Friend, s1);
            Assert.IsTrue(s1.Dogs.Contains(d1));
        }

    }
}
