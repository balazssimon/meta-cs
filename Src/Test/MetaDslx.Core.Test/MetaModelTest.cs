using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetaDslx.Core.Test
{
    [TestClass]
    public class MetaModelTest
    {
        [TestMethod]
        public void TestFactory()
        {
            MetaFactory f = MetaFactory.Instance;
            MetaNamespace ns = f.CreateMetaNamespace();
            MetaModel mm = f.CreateMetaModel();
            ns.Models.Add(mm);
            MetaClass mc = f.CreateMetaClass();
            mc.Model = mm;
            Assert.IsTrue(mm.Namespace == ns);
            Assert.IsTrue(ns.Models.Contains(mm));
            Assert.IsTrue(mm.Types.Contains(mc));
            Assert.IsTrue(mc.Model == mm);
            Assert.IsTrue(mc.Namespace == ns);
        }
    }
}
