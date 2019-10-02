using MetaDslx.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public class WebSequenceDiagramsTest : WebSequenceDiagramsTestBase
    {
        [Fact]
        public void EverythingTest()
        {
            var comp = Compile("Everything");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(25, modelSymbols.Count);
        }

        [Fact]
        public void Logistics01Test()
        {
            var comp = Compile("Logistics01");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(7, modelSymbols.Count);
        }

        [Fact]
        public void Logistics02Test()
        {
            var comp = Compile("Logistics02");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(27, modelSymbols.Count);
        }

        [Fact]
        public void Logistics03Test()
        {
            var comp = Compile("Logistics03");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(14, modelSymbols.Count);
        }

        [Fact]
        public void Logistics04Test()
        {
            var comp = Compile("Logistics04");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(20, modelSymbols.Count);
        }

        [Fact]
        public void Logistics05Test()
        {
            var comp = Compile("Logistics05");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(21, modelSymbols.Count);
        }

        [Fact]
        public void Logistics06Test()
        {
            var comp = Compile("Logistics06");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(6, modelSymbols.Count);
        }

        [Fact]
        public void Logistics07Test()
        {
            var comp = Compile("Logistics07");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(47, modelSymbols.Count);
        }

        [Fact]
        public void Logistics08Test()
        {
            var comp = Compile("Logistics08");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(19, modelSymbols.Count);
        }

        [Fact]
        public void Logistics09Test()
        {
            var comp = Compile("Logistics09");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(25, modelSymbols.Count);
        }

        [Fact]
        public void Logistics10Test()
        {
            var comp = Compile("Logistics10");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(24, modelSymbols.Count);
        }

        [Fact]
        public void Logistics11Test()
        {
            var comp = Compile("Logistics11");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(14, modelSymbols.Count);
        }

        [Fact]
        public void Logistics12Test()
        {
            var comp = Compile("Logistics01");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(7, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign01Test()
        {
            var comp = Compile("OoDesign01");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(9, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign02Test()
        {
            var comp = Compile("OoDesign02");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(18, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign03Test()
        {
            var comp = Compile("OoDesign03");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(37, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign04Test()
        {
            var comp = Compile("OoDesign04");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(30, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign05Test()
        {
            var comp = Compile("OoDesign05");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(28, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign06Test()
        {
            var comp = Compile("OoDesign06");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(41, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign07Test()
        {
            var comp = Compile("OoDesign07");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(22, modelSymbols.Count);
        }

        [Fact]
        public void OoDesign08Test()
        {
            var comp = Compile("OoDesign08");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(20, modelSymbols.Count);
        }

        [Fact]
        public void Test1Test()
        {
            var comp = Compile("test1");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(5, modelSymbols.Count);
        }

        [Fact]
        public void Test2Test()
        {
            var comp = Compile("test2");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(27, modelSymbols.Count);
        }

        [Fact]
        public void Test3Test()
        {
            var comp = Compile("test3");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(11, modelSymbols.Count);
        }
    }
}
