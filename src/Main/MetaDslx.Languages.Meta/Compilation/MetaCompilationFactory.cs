// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Binding;
using MetaDslx.Languages.Meta.Symbols;
using System.Diagnostics;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationFactory : CompilationFactory
    {
        internal MetaCompilationFactory()
        {
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
            if (module is MetaModuleSymbol metaModule && metaModule.Models.Contains(MetaAnnotations.Model))
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

