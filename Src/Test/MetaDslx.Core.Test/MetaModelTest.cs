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
            //MetaFactory f = MetaFactory.Instance;
            MetaFactory f = MetaFactory.Instance;
            MetaNamespace ns = f.CreateMetaNamespace();
            MetaModel mm = f.CreateMetaModel();
            ns.MetaModel = mm;
            MetaClass mc = f.CreateMetaClass();
            mc.Namespace = ns;
            Assert.IsTrue(mm.Namespace == ns);
            Assert.IsTrue(ns.MetaModel == mm);
            Assert.IsTrue(mm.Namespace.Declarations.Contains(mc));
            Assert.IsTrue(mc.Model == mm);
            Assert.IsTrue(mc.Namespace == ns);
        }
    }
}
