using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Languages.Test
{
    public class PilTest : PilTestBase
    {
        [Fact]
        public void Code01Test()
        {
            var comp = Compile(@"code01");
            var model = comp.Model;
            var modelSymbols = model.Objects.ToList();
            Assert.Equal(137, modelSymbols.Count);
        }
    }
}
