using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLanguageAnnotations
{
    public abstract class UnitTestBase01 : LanguageAnnotationsTestBase
    {
        protected string TestId = "00";

        [Fact]
        public void File01()
        {
            var comp = Compile(TestId, "01");
            var model = comp.Model;
            var modelObjects = model.Objects.ToList();
            Assert.Equal(4, modelObjects.Count);
            var ns1 = Assert.IsAssignableFrom<Namespace>(modelObjects[0]);
            Assert.Equal($"Test{TestId}", ns1.Name);
            var ns1decls = ns1.Declarations;
            Assert.Equal(3, ns1decls.Count);
            var v1 = Assert.IsAssignableFrom<Vertex>(ns1decls[0]);
            Assert.Equal("V1", v1.Name);
            var v2 = Assert.IsAssignableFrom<Vertex>(ns1decls[1]);
            Assert.Equal("V2", v2.Name);
            var a1 = Assert.IsAssignableFrom<Arrow>(ns1decls[2]);
            Assert.Equal(v1, a1.Source);
            Assert.Equal(v2, a1.Target);
        }

        [Fact]
        public void File02()
        {
            var comp = Compile(TestId, "02");
            var model = comp.Model;
            var modelObjects = model.Objects.ToList();
            Assert.Equal(4, modelObjects.Count);
            var ns1 = Assert.IsAssignableFrom<Namespace>(modelObjects[0]);
            Assert.Equal($"Test{TestId}", ns1.Name);
            var ns1decls = ns1.Declarations;
            Assert.Equal(3, ns1decls.Count);
            var a1 = Assert.IsAssignableFrom<Arrow>(ns1decls[0]);
            var v1 = Assert.IsAssignableFrom<Vertex>(ns1decls[1]);
            Assert.Equal("V1", v1.Name);
            var v2 = Assert.IsAssignableFrom<Vertex>(ns1decls[2]);
            Assert.Equal("V2", v2.Name);
            Assert.Equal(v1, a1.Source);
            Assert.Equal(v2, a1.Target);
        }

        [Fact]
        public void File03()
        {
            var comp = Compile(TestId, "03");
            var model = comp.Model;
            var modelObjects = model.Objects.ToList();
            Assert.Equal(6, modelObjects.Count);
            var ns1 = Assert.IsAssignableFrom<Namespace>(modelObjects[0]);
            Assert.Equal($"Test{TestId}A", ns1.Name);
            var ns2 = Assert.IsAssignableFrom<Namespace>(modelObjects[1]);
            Assert.Equal($"Test{TestId}B", ns2.Name);
            var ns1decls = ns1.Declarations;
            Assert.Equal(2, ns1decls.Count);
            var ns2decls = ns2.Declarations;
            Assert.Equal(2, ns2decls.Count);
            var a1 = Assert.IsAssignableFrom<Arrow>(ns1decls[0]);
            var v1 = Assert.IsAssignableFrom<Vertex>(ns1decls[1]);
            Assert.Equal("V1", v1.Name);
            var a2 = Assert.IsAssignableFrom<Arrow>(ns2decls[1]);
            var v2 = Assert.IsAssignableFrom<Vertex>(ns2decls[0]);
            Assert.Equal("V2", v2.Name);
            Assert.Equal(v1, a1.Source);
            Assert.Equal(v2, a1.Target);
            Assert.Equal(v1, a2.Source);
            Assert.Equal(v2, a2.Target);
        }
    }

}
