using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Binding;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;
using System.Collections.Immutable;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Binding.Binders;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationFactory : CompilationFactory
    {
        public static readonly SoalCompilationFactory Instance = new SoalCompilationFactory();

        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            return new SoalAnonymousTypeManager();
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SoalDeclarationTreeBuilderVisitor.ForTree((SoalSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SoalBinderFactoryVisitor(binderFactory);
        }

        public override IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, Binder rootBinder)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateGlobalNamespace(Compilation compilation, MutableModel modelBuilder, IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            var nsList = namespacesToMerge.ToList();
            string name = nsList.Count > 0 ? nsList[0].MName : string.Empty;
            SoalFactory f = new SoalFactory(modelBuilder);
            var result = f.Namespace();
            result.Name = name;
            if (compilation != null)
            {
                result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, compilation);
            }
            return result;

            /*
            var soalBuilder = modelBuilder.ModelGroup.GetReference(SoalInstance.Model.Id);
            var metaBuilder = modelBuilder.ModelGroup.GetReference(MetaInstance.Model.Id);
            MetaFactory metaFactory = new MetaFactory(modelBuilder);
            var rootScope = metaFactory.RootScope();
            rootScope.BuiltInEntries.Add(SoalInstance.Object.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.String.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Int.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Long.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Float.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Double.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Byte.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Bool.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Void.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Date.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.Time.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.DateTime.ToMutable(soalBuilder));
            rootScope.BuiltInEntries.Add(SoalInstance.TimeSpan.ToMutable(soalBuilder));

            var result = rootScope;
            */
        }

        public override IMetaSymbol CreateErrorSymbol(CompilationBase compilation, MutableModel modelBuilder)
        {
            SoalFactory f = new SoalFactory(modelBuilder);
            var result = f.PrimitiveType();
            result.Name = "error";
            if (compilation != null)
            {
                result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, compilation);
            }
            return result;
        }

        public override IMetaSymbol GetWellKnownSymbol(string name)
        {
            switch (name)
            {
                case "int":
                    return SoalInstance.Int;
                case "double":
                    return SoalInstance.Double;
                case "string":
                    return SoalInstance.String;
                case "void":
                    return SoalInstance.Void;
                default:
                    return null;
            }
        }

        public override ModelFactory CreateModelFactory(MutableModel modelBuilder, bool weak)
        {
            return new SoalFactory(modelBuilder, weak ? ModelFactoryFlags.CreateWeakSymbols : ModelFactoryFlags.CreateStrongSymbols);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SoalScriptCompilationInfo((SoalCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            return false;
        }
    }
}
