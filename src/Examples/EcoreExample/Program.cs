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
            var ecoreFile = @"Ecore\Model\Ecore";
            //var ecoreFile = @"Xbase\Model\Xbase";
            //var ecoreFile = @"Xcore\Model\Xcore";
            //var ecoreFile = @"Xtext\Model\Xtext";
            //var ecoreFile = @"Xtend\Model\Xtend";
            EcoreDescriptor.Initialize();
            var xmiSerializer = new EcoreXmiSerializer();
            //var options = new EcoreXmiReadOptions();
            //options.ReferencedModels.Add(MetaInstance.MModel);
            //options.IgnoredNamespaces.Add("http://www.eclipse.org/emf/2002/GenModel");
            var ecoreModel = xmiSerializer.ReadModelFromFile(RootDir + ecoreFile + ".ecore");
            var metaModel = EcoreModelConverter.ToMetaModel(ecoreModel);
            var metaGenerator = new MetaModelGenerator(metaModel.Objects);
            var metaModelObject = metaModel.Objects.OfType<MetaModel>().First();
            var metaCode = metaGenerator.Generate(metaModelObject);
            File.WriteAllText(RootDir + ecoreFile + ".mm0", metaCode);
        }
    }
}
