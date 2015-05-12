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
            MetaModel mm = f.CreateMetaModel();
            MetaClass mc = f.CreateMetaClass();
            mc.Model = mm;
            Assert.IsTrue(mm.Types.Contains(mc));
            Assert.IsTrue(mc.Model == mm);
        }
    }
}
