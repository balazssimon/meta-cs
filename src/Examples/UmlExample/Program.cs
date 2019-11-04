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
            var model = umlSerializer.ReadModelFromFile("../../../Potyogos.uml", out var diagnostics);
            //var model = umlSerializer.ReadModelFromFile("../../../Async.uml", out var diagnostics);
            DiagnosticFormatter df = new DiagnosticFormatter();
            for (int i = 0; i < 10 && i < diagnostics.Length; i++)
            {
                Console.WriteLine(df.Format(diagnostics[i]));
            }
            Console.WriteLine(model);
            /*var wsdSerializer = new WebSequenceDiagramsSerializer();
            var wsdModel = wsdSerializer.ReadModelFromFile(new string[] { "../../../test2.wsd" }, model, out diagnostics);
            for (int i = 0; i < 10 && i < diagnostics.Length; i++)
            {
                Console.WriteLine(df.Format(diagnostics[i]));
            }
            Console.WriteLine(wsdModel);*/
            var xmiSerializer = new UmlXmiSerializer();
            //xmiSerializer.WriteModelToFile("../../../pacman.xmi", model);
            //xmiSerializer.WriteModelToFile("../../../Async.xmi", model);
            //xmiSerializer.WriteModelToFile("../../../Wsd.xmi", wsdModel);
            xmiSerializer.WriteModelToFile("../../../model.xmi", model);
            var check = xmiSerializer.ReadModelFromFile("../../../model.xmi");
            Console.WriteLine(check);
        }
    }
}
