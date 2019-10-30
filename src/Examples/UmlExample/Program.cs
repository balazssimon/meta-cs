using MetaDslx.Languages.Uml.Model;
using MetaDslx.Languages.Uml.Serialization;
using Microsoft.CodeAnalysis;
using System;
using System.Linq;

namespace UmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var xmiSerializer = new UmlXmiSerializer();
            var model = xmiSerializer.ReadModelFromFile("../../../PrimitiveTypes.xmi");
            foreach (var primitiveType in model.Objects.OfType<PrimitiveType>())
            {
                Console.WriteLine(primitiveType.MName);
            }
            xmiSerializer.WriteModelToFile("../../../PrimitiveTypes2.xmi", model);*/
            UmlDescriptor.Initialize();
            var umlSerializer = new WhiteStarUmlSerializer();
            var model = umlSerializer.ReadModelFromFile("../../../pacman.uml", out var diagnostics);
            //var model = umlSerializer.ReadModelFromFile("../../../Async.uml", out var diagnostics);
            DiagnosticFormatter df = new DiagnosticFormatter();
            for (int i = 0; i < 10 && i < diagnostics.Length; i++)
            {
                Console.WriteLine(df.Format(diagnostics[i]));
            }
            Console.WriteLine(model);
            var xmiSerializer = new UmlXmiSerializer();
            xmiSerializer.WriteModelToFile("../../../pacman.xmi", model);
        }
    }
}
