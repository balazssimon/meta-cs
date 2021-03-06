﻿using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLanguageAnnotations
{
    public abstract class UnitTestBase02 : LanguageAnnotationsTestBase
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
            var a1 = Assert.IsAssignableFrom<Arrow>(ns1decls[2]);
            var v1 = Assert.IsAssignableFrom<Vertex>(ns1decls[0]);
            Assert.Equal("V1", v1.Name);
            var v2 = Assert.IsAssignableFrom<Vertex>(ns1decls[1]);
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
            Assert.Equal(8, modelObjects.Count);
            var ns1 = Assert.IsAssignableFrom<Namespace>(modelObjects[0]);
            Assert.Equal($"Test{TestId}A", ns1.Name);
            var ns2 = Assert.IsAssignableFrom<Namespace>(modelObjects[1]);
            Assert.Equal($"Test{TestId}B", ns2.Name);
            var ns1decls = ns1.Declarations;
            Assert.Equal(3, ns1decls.Count);
            var ns2decls = ns2.Declarations;
            Assert.Equal(3, ns2decls.Count);
            var a1a = Assert.IsAssignableFrom<Arrow>(ns1decls[2]);
            var v1a = Assert.IsAssignableFrom<Vertex>(ns1decls[0]);
            Assert.Equal("V1", v1a.Name);
            var v2a = Assert.IsAssignableFrom<Vertex>(ns1decls[1]);
            Assert.Equal("V2", v2a.Name);
            Assert.Equal(v1a, a1a.Source);
            Assert.Equal(v2a, a1a.Target);
            var a1b = Assert.IsAssignableFrom<Arrow>(ns2decls[2]);
            var v1b = Assert.IsAssignableFrom<Vertex>(ns2decls[1]);
            Assert.Equal("V1", v1b.Name);
            var v2b = Assert.IsAssignableFrom<Vertex>(ns2decls[0]);
            Assert.Equal("V2", v2b.Name);
            Assert.Equal(v1b, a1b.Source);
            Assert.Equal(v2b, a1b.Target);
        }


        [Fact]
        public void File04()
        {
            var comp = Compile(TestId, "04");
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
        public void File05()
        {
            var comp = Compile(TestId, "05");
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
        public void File06()
        {
            var comp = Compile(TestId, "06");
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
        public void File07()
        {
            var comp = Compile(TestId, "07");
            var model = comp.Model;
            var modelObjects = model.Objects.ToList();
            Assert.Equal(8, modelObjects.Count);
            var ns1 = Assert.IsAssignableFrom<Namespace>(modelObjects[0]);
            Assert.Equal($"Test{TestId}", ns1.Name);
            var ns1decls = ns1.Declarations;
            Assert.Equal(7, ns1decls.Count);
            var v1 = Assert.IsAssignableFrom<Vertex>(ns1decls[0]);
            Assert.Equal("V1", v1.Name);
            var v2 = Assert.IsAssignableFrom<Vertex>(ns1decls[1]);
            Assert.Equal("V2", v2.Name);
            var a1 = Assert.IsAssignableFrom<Arrow>(ns1decls[2]);
            Assert.Equal(v1, a1.Source);
            Assert.Equal(v2, a1.Target);
            var v3 = Assert.IsAssignableFrom<Vertex>(ns1decls[3]);
            Assert.Equal("V3", v3.Name);
            var a2 = Assert.IsAssignableFrom<Arrow>(ns1decls[4]);
            Assert.Equal(v2, a2.Source);
            Assert.Equal(v3, a2.Target);
            var v4 = Assert.IsAssignableFrom<Vertex>(ns1decls[5]);
            Assert.Equal("V4", v4.Name);
            var a3 = Assert.IsAssignableFrom<Arrow>(ns1decls[6]);
            Assert.Equal(v3, a3.Source);
            Assert.Equal(v4, a3.Target);
        }
    }
}
