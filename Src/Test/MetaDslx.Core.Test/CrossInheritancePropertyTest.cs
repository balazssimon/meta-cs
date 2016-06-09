using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class CrossInheritancePropertyTest
    {
        [TestMethod]
        public void TestPersonPetStatic1()
        {
            IPersonX p1 = new PersonX();
            IPetX t1 = new PetX();
            t1.Owner = p1;
            Assert.AreEqual(t1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestPersonPetStatic2()
        {
            IPersonX p1 = new PersonX();
            IPetX t1 = new PetX();
            p1.Pets.Add(t1);
            Assert.AreEqual(t1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestPersonDogStatic1()
        {
            IPersonX p1 = new PersonX();
            IDogX d1 = new DogX();
            d1.Owner = p1;
            Assert.AreEqual(d1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(d1));
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException))]
        public void TestPersonDogStatic2()
        {
            IPersonX p1 = new PersonX();
            IDogX d1 = new DogX();
            p1.Pets.Add(d1);
            Assert.AreEqual(d1.Owner, p1);
            Assert.IsTrue(p1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestStudentPetStatic1()
        {
            IStudentX s1 = new StudentX();
            IPetX t1 = new PetX();
            t1.Owner = s1;
            Assert.AreEqual(t1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestStudentPetStatic2()
        {
            IStudentX s1 = new StudentX();
            IPetX t1 = new PetX();
            s1.Pets.Add(t1);
            Assert.AreEqual(t1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(t1));
        }

        [TestMethod]
        public void TestStudentDogStatic1()
        {
            IStudentX s1 = new StudentX();
            IDogX d1 = new DogX();
            d1.Owner = s1;
            Assert.AreEqual(d1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestStudentDogStatic2()
        {
            IStudentX s1 = new StudentX();
            IDogX d1 = new DogX();
            s1.Pets.Add(d1);
            Assert.AreEqual(d1.Owner, s1);
            Assert.IsTrue(s1.Pets.Contains(d1));
        }

        [TestMethod]
        public void TestStudentDogStatic3()
        {
            IStudentX s1 = new StudentX();
            IDogX d1 = new DogX();
            d1.Friend = s1;
            Assert.AreEqual(d1.Friend, s1);
            Assert.IsTrue(s1.Dogs.Contains(d1));
        }

        [TestMethod]
        public void TestStudentDogStatic4()
        {
            IStudentX s1 = new StudentX();
            IDogX d1 = new DogX();
            s1.Dogs.Add(d1);
            Assert.AreEqual(d1.Friend, s1);
            Assert.IsTrue(s1.Dogs.Contains(d1));
        }

    }
}
