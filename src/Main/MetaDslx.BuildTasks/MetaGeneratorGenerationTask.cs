//using MetaDslx.CodeAnalysis;
//using MetaDslx.Languages.Antlr4Roslyn.Compilation;
//using MetaDslx.Languages.MetaGenerator.Compilation;
//using Microsoft.Build.Framework;
//using Microsoft.Build.Utilities;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace MetaDslx.BuildTasks
//{
//    public class MetaGeneratorGenerationTask : Antlr4CompilerTask
//    {
//        public MetaGeneratorGenerationTask()
//            : base("MetaGenerator")
//        {
//        }

//        protected override ICompilerForBuildTask CreateCompiler(string filePath, string outputPath, string hiddenOutputPath)
//        {
//            return new MetaGeneratorCompiler(filePath, outputPath);
//        }

//    }
//}
