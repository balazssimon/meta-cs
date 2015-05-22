using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class ManyToManyPropertyTest
    {
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
