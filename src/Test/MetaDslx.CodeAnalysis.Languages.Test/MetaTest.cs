using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public class MetaTest : MetaTestBase
    {
        [Fact]
        public void ImmutableMetaModelTest()
        {
            var comp = Compile(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Symbols\ImmutableMetaModel.mm");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(115, modelSymbols.Count);
        }

        [Fact]
        public void SoalTest()
        {
            var comp = Compile(@"..\..\..\Languages\Soal\Symbols\Soal.mm");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(155, modelSymbols.Count);
        }

        [Fact]
        public void TestLangOneTest()
        {
            var comp = Compile(@"..\..\..\..\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLangOne\Symbols\TestLangOne.mm");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(29, modelSymbols.Count);
        }

        [Fact]
        public void UmlModelTest()
        {
            var comp = Compile(@"..\..\..\Languages\WebSequenceDiagrams\Symbols\UmlModel.mm");
            var model = comp.Model;
            var modelSymbols = model.Symbols.ToList();
            Assert.Equal(47, modelSymbols.Count);
        }

    }
}
