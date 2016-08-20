using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Soal
{
    public class SoalCompiler : SoalCompilerBase
    {
        public SoalCompiler(string source, string fileName)
            : base(source, fileName)
        {
            MutableModel soalInstance = SoalInstance.Model.ToMutable(true);
            this.ModelGroup.AddReference(soalInstance);
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Object.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.String.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Int.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Long.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Float.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Double.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Byte.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Bool.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.Void.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.DateTime.ToMutable(soalInstance));
            this.GlobalScope.BuiltInEntries.Add(SoalInstance.TimeSpan.ToMutable(soalInstance));
        }

    }
}
