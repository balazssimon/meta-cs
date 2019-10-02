using MetaDslx.CodeAnalysis.Languages.Test.Languages.Soal.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public class SoalTest : SoalTestBase
    {
        [Fact]
        public void CinemaTest()
        {
            var comp = Compile("cinema");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(174, modelSymbols.Count);
        }


        [Fact(Skip = "TODO")]
        public void HelloWorldTest()
        {
            var comp = Compile("HelloWorld");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(-1, modelSymbols.Count);
        }

        [Fact]
        public void Wsdl00Test()
        {
            var comp = Compile("Wsdl00");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(5, modelSymbols.Count);
            var divideO = modelSymbols.OfType<Operation>().FirstOrDefault();
            Assert.NotNull(divideO?.Result);
            Assert.True(divideO.Result.IsOneway);
        }

        [Fact]
        public void Wsdl01Test()
        {
            var comp = Compile("Wsdl01");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(66, modelSymbols.Count);
        }

        [Fact]
        public void Wsdl02Test()
        {
            var comp = Compile("Wsdl02");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(67, modelSymbols.Count);
        }

        [Fact]
        public void Wsdl03Test()
        {
            var comp = Compile("Wsdl03");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(67, modelSymbols.Count);
        }

        [Fact]
        public void Xsd01Test()
        {
            var comp = Compile("Xsd01");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(5, modelSymbols.Count);
        }

        [Fact]
        public void Xsd02Test()
        {
            var comp = Compile("Xsd02");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(6, modelSymbols.Count);
        }

        [Fact]
        public void Xsd03Test()
        {
            var comp = Compile("Xsd03");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(6, modelSymbols.Count);
        }

        [Fact]
        public void Xsd04Test()
        {
            var comp = Compile("Xsd04");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(7, modelSymbols.Count);
        }

        [Fact]
        public void Xsd05Test()
        {
            var comp = Compile("Xsd05");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(8, modelSymbols.Count);
        }

        [Fact]
        public void Xsd06Test()
        {
            var comp = Compile("Xsd06");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(13, modelSymbols.Count);
        }

        [Fact]
        public void Xsd07Test()
        {
            var comp = Compile("Xsd07");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(5, modelSymbols.Count);
        }

        [Fact]
        public void Xsd08Test()
        {
            var comp = Compile("Xsd08");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(8, modelSymbols.Count);
        }

        [Fact]
        public void Xsd09Test()
        {
            var comp = Compile("Xsd09");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(9, modelSymbols.Count);
        }

        [Fact]
        public void Xsd10Test()
        {
            var comp = Compile("Xsd10");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(149, modelSymbols.Count);
        }

        [Fact]
        public void Xsd11Test()
        {
            var comp = Compile("Xsd11");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(7, modelSymbols.Count);
        }

        [Fact]
        public void Xsd12Test()
        {
            var comp = Compile("Xsd12");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(11, modelSymbols.Count);
        }

        [Fact]
        public void Xsd13Test()
        {
            var comp = Compile("Xsd13");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(13, modelSymbols.Count);
        }

        [Fact]
        public void Xsd14Test()
        {
            var comp = Compile("Xsd14");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(16, modelSymbols.Count);
        }

        [Fact]
        public void Xsd15Test()
        {
            var comp = Compile("Xsd15");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(22, modelSymbols.Count);
        }

        [Fact]
        public void Xsd16Test()
        {
            var comp = Compile("Xsd16");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(17, modelSymbols.Count);
        }

        [Fact]
        public void Xsd17Test()
        {
            var comp = Compile("Xsd17");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(25, modelSymbols.Count);
        }

        [Fact]
        public void Xsd18Test()
        {
            var comp = Compile("Xsd18");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(10, modelSymbols.Count);
        }
    }
}
