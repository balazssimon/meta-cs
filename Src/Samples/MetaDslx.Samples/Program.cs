using MetaDslx.Soal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string source = "";
                string fileName = @"SoalTest1.soal";
                using (StreamReader reader = new StreamReader(@"..\..\" + fileName))
                {
                    source = reader.ReadToEnd();
                }
                SoalCompiler compiler = new SoalCompiler(source, ".", fileName);
                compiler.Compile();
                foreach (var msg in compiler.Diagnostics.GetMessages())
                {
                    Console.WriteLine(msg);
                }
                Console.WriteLine("----");
                foreach (var symbol in compiler.Data.GetSymbols())
                {
                    Declaration decl = symbol as Declaration;
                    if (decl != null)
                    {
                        Console.WriteLine(decl.Name);
                    }
                    Property prop = symbol as Property;
                    if (prop != null)
                    {
                        Console.WriteLine("{0}: {1}", prop.Name, prop.Type);
                    }
                }
            }
            catch(System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
