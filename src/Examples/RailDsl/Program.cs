using MetaDslx.Languages.Ecore;
using MetaDslx.Modeling;
using System;
using System.Linq;

namespace RailDsl
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmiSerializer = new EcoreXmiSerializer();
            var model = xmiSerializer.ReadModelFromFile("../../../Rail01.xmi", RailDslInstance.MMetaModel);
            foreach (var vertex in model.Objects.OfType<Vertex>())
            {
                Console.WriteLine(vertex.Name);
            }
            xmiSerializer.WriteModelToFile("../../../Rail02.xmi", model);
        }
    }
}
