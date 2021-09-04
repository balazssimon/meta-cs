using MetaDslx.Languages.Ecore;
using MetaDslx.Languages.Ecore.Model;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Model;
using System;
using System.IO;
using System.Linq;

namespace EcoreExample
{
    class Program
    {
        private const string RootDir = @"..\..\..\..\..\Languages\MetaDslx.Languages.Ecore\";

        static void Main(string[] args)
        {
            EcoreDescriptor.Initialize();
            var xmiSerializer = new EcoreXmiSerializer();
            var ecoreModel = xmiSerializer.ReadModelFromFile(RootDir+@"Ecore\Model\Ecore.ecore");
            var metaModel = EcoreModelConverter.ToMetaModel(ecoreModel);
            var metaGenerator = new MetaModelGenerator(metaModel.Objects);
            var metaModelObject = metaModel.Objects.OfType<MetaModel>().First();
            var metaCode = metaGenerator.Generate(metaModelObject);
            File.WriteAllText(RootDir + @"Ecore\Model\Ecore.mm0", metaCode);
        }
    }
}
