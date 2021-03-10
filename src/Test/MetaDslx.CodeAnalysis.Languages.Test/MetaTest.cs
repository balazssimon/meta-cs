using MetaDslx.Modeling;
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
            var comp = Compile(@"..\..\..\..\..\Main\MetaDslx.CodeAnalysis.Meta\Languages\Meta\Model\ImmutableMetaModel.mm");
            var model = ((MutableModel)comp.Model).ToImmutable();
            var modelSymbols = model.Objects.ToList();
            Assert.Equal(137, modelSymbols.Count);
        }

        [Fact]
        public void SoalTest()
        {
            var comp = Compile(@"..\..\..\Languages\Soal\Model\Soal.mm");
            var model = ((MutableModel)comp.Model).ToImmutable();
            var modelSymbols = model.Objects.ToList();
            Assert.Equal(155, modelSymbols.Count);
        }

        [Fact]
        public void TestLanguageAnnotationsTest()
        {
            var comp = Compile(@"..\..\..\..\MetaDslx.CodeAnalysis.Antlr4.Test\Languages\TestLanguageAnnotations\Model\TestLanguageAnnotations.mm");
            var model = ((MutableModel)comp.Model).ToImmutable();
            var modelSymbols = model.Objects.ToList();
            Assert.Equal(29, modelSymbols.Count);
        }

        [Fact]
        public void UmlModelTest()
        {
            var comp = Compile(@"..\..\..\Languages\WebSequenceDiagrams\Model\UmlModel.mm");
            var model = ((MutableModel)comp.Model).ToImmutable();
            var modelSymbols = model.Objects.ToList();
            Assert.Equal(47, modelSymbols.Count);
        }

    }
}
