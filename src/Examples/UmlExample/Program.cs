using MetaDslx.Languages.Uml.Model;
using System;
using System.Linq;

namespace UmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmiSerializer = new UmlXmiSerializer();
            var model = xmiSerializer.ReadModelFromFile("../../../PrimitiveTypes.xmi");
            foreach (var primitiveType in model.Objects.OfType<PrimitiveType>())
            {
                Console.WriteLine(primitiveType.MName);
            }
        }
    }
}
