using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetaDslx.Core.Immutable.Test
{
    public class ImmutableInheritanceTest
    {
        [Fact]
        public void TestPersonPetStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Pet t1 = f.Pet();
            t1.Owner = p1;
            Assert.Equal(p1, t1.Owner);
            Assert.Single(p1.Pets);
            Assert.Equal(t1, p1.Pets[0]);
        }

        [Fact]
        public void TestPersonPetStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Pet t1 = f.Pet();
            p1.Pets.Add(t1);
            Assert.Equal(p1, t1.Owner);
            Assert.Single(p1.Pets);
            Assert.Equal(t1, p1.Pets[0]);
        }

        [Fact]
        public void TestPersonDogStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Dog d1 = f.Dog();
            Assert.Throws<ModelException>(() => d1.Owner = p1);
            Assert.Null(d1.Owner);
            Assert.Empty(p1.Pets);
        }

        [Fact]
        public void TestPersonDogStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Person p1 = f.Person();
            Dog d1 = f.Dog();
            Assert.Throws<ModelException>(() => p1.Pets.Add(d1));
            Assert.Null(d1.Owner);
            Assert.Empty(p1.Pets);
        }

        [Fact]
        public void TestStudentPetStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Pet t1 = f.Pet();
            Assert.Throws<ModelException>(() => t1.Owner = s1);
            Assert.Null(t1.Owner);
            Assert.Empty(s1.Pets);
        }

        [Fact]
        public void TestStudentPetStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Pet t1 = f.Pet();
            Assert.Throws<ModelException>(() => s1.Pets.Add(t1));
            Assert.Null(t1.Owner);
            Assert.Empty(s1.Pets);
        }

        [Fact]
        public void TestStudentDogStatic1()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            d1.Owner = s1;
            Assert.Equal(s1, d1.Owner);
            Assert.Single(s1.Pets);
            Assert.Equal(d1, s1.Pets[0]);
            Assert.Equal(s1, d1.Friend);
            Assert.Single(s1.Dogs);
            Assert.Equal(d1, s1.Dogs[0]);
        }

        [Fact]
        public void TestStudentDogStatic2()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            s1.Pets.Add(d1);
            Assert.Equal(s1, d1.Owner);
            Assert.Single(s1.Pets);
            Assert.Equal(d1, s1.Pets[0]);
            Assert.Equal(s1, d1.Friend);
            Assert.Single(s1.Dogs);
            Assert.Equal(d1, s1.Dogs[0]);
        }

        [Fact]
        public void TestStudentDogStatic3()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            d1.Friend = s1;
            Assert.Equal(s1, d1.Owner);
            Assert.Single(s1.Pets);
            Assert.Equal(d1, s1.Pets[0]);
            Assert.Equal(s1, d1.Friend);
            Assert.Single(s1.Dogs);
            Assert.Equal(d1, s1.Dogs[0]);
        }

        [Fact]
        public void TestStudentDogStatic4()
        {
            MutableModel model = new MutableModel();
            TestModelFactory f = new TestModelFactory(model);
            Student s1 = f.Student();
            Dog d1 = f.Dog();
            s1.Dogs.Add(d1);
            Assert.Equal(s1, d1.Owner);
            Assert.Single(s1.Pets);
            Assert.Equal(d1, s1.Pets[0]);
            Assert.Equal(s1, d1.Friend);
            Assert.Single(s1.Dogs);
            Assert.Equal(d1, s1.Dogs[0]);
        }

    }

}
