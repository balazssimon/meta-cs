// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Symbols;

using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationFactory : CompilationFactory
    {
        internal MetaCompilationFactory()
        {
        }

        /// <summary>
        /// Default compilation options for the Meta language
        /// </summary>
        public override LanguageCompilationOptions DefaultCompilationOptions => new MetaCompilationOptions(OutputKind.ConsoleApplication);

        /// <summary>
        /// Default compilation options for script submissions for the Meta language
        /// </summary>
        public override LanguageCompilationOptions DefaultSubmissionOptions => new MetaCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithReferencesSupersedeLowerVersions(true);

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public override LanguageCompilation CreateCompilation(
            string assemblyName,
            IEnumerable<SyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null)
        {
            return MetaCompilation.Create(assemblyName, syntaxTrees, references, (MetaCompilationOptions)options);
        }

        /// <summary>
        /// Creates a new compilation that can be used in scripting.
        /// </summary>
        /// <param name="assemblyName">Simple assembly name.</param>
        /// <param name="syntaxTree">The syntax tree with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <param name="previousScriptCompilation">The compilation of the previous state of the script.</param>
        /// <param name="returnType">The return type resulting from the script.</param>
        /// <param name="globalsType">The type from which the script can take the global variables.</param>
        /// <returns>A new compilation.</returns>
        public override LanguageCompilation CreateScriptCompilation(
            string assemblyName,
            SyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            LanguageCompilationOptions options = null,
            LanguageCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null)
        {
            return MetaCompilation.CreateScriptCompilation(assemblyName, syntaxTree, references, (MetaCompilationOptions)options, (MetaCompilation)previousScriptCompilation, returnType, globalsType);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new MetaBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new MetaBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new MetaIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return MetaDeclarationTreeBuilderVisitor.ForTree((MetaSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }
        public override Symbol CreateSpecialSymbol(ModuleSymbol module, object key)
        {
            if (module is MetaModuleSymbol metaModule && metaModule.Models.Contains(MetaInstance.MModel))
            {
                var specialType = MetaConstants.Types.FirstOrDefault(c => c.MName == key.ToString());
                if (specialType != null)
                {
                    var symbol = new MetaNamedTypeSymbol(specialType, module);
                    return symbol;
                }
            }
            return null;
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new MetaScriptCompilationInfo((MetaCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new MetaSymbolBuilder((MetaCompilation)compilation);
        }*/
    }
}

