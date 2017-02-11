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

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationFactory : CompilationFactory
    {
        public static readonly SoalCompilationFactory Instance = new SoalCompilationFactory();

        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            return new SoalAnonymousTypeManager();
        }

        public override IBinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateDeclarationSymbol(Compilation compilation, MutableModel modelBuilder, IMetaSymbol container, MergedDeclaration declaration)
        {
            SoalFactory f = new SoalFactory(modelBuilder);
            MutableSymbol result = f.Create(declaration.Kind.ImmutableType);
            result.MSet(result.MId.SymbolInfo.NameProperty, declaration.Name);
            MutableSymbol parent = container as MutableSymbol;
            if (parent != null)
            {
                ModelProperty parentProperty = result.MGetProperty(declaration.ParentPropertyToAddTo);
                if (parentProperty != null)
                {
                    parent.MAdd(parentProperty, result);
                }
            }
            else if (compilation != null)
            {
                result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, compilation);
            }
            result.MAttachProperty(CompilerAttachedProperties.MergedDeclarationProperty);
            result.MSet(CompilerAttachedProperties.MergedDeclarationProperty, declaration);
            result.MAttachProperty(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
            result.MSet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty, declaration.SyntaxReferences);
            if (declaration.Children.Length > 0)
            {
                result.MAttachProperty(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                result.MSetLazy(CompilerAttachedProperties.PropertiesToMembersMapProperty,
                    () =>
                    {
                        var map = new Dictionary<string, ImmutableArray<IMetaSymbol>>();
                        var cbp = declaration.ChildrenByParentProperties;
                        foreach (var kvp in cbp)
                        {
                            ArrayBuilder<IMetaSymbol> symbolsBuilder = ArrayBuilder<IMetaSymbol>.GetInstance();
                            try
                            {
                                foreach (var item in kvp.Value)
                                {
                                    var symbol = CreateDeclarationSymbol(compilation, modelBuilder, result, item);
                                    symbolsBuilder.Add(symbol);
                                }
                            }
                            finally
                            {
                                var symbols = symbolsBuilder.ToImmutableAndFree();
                                map.Add(kvp.Key, symbols);
                            }
                        };
                        return map;
                    });
                foreach (var kvp in declaration.ChildrenByParentProperties)
                {
                    ModelProperty parentProperty = result.MGetProperty(kvp.Key);
                    if (parentProperty != null)
                    {
                        if (parentProperty.IsCollection)
                        {
                            for (int i = 0; i < kvp.Value.Length; i++)
                            {
                                int index = i;
                                result.MAddLazy(parentProperty,
                                    () =>
                                    {
                                        var map = (Dictionary<string, ImmutableArray<IMetaSymbol>>)result.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                                        var symbols = map[kvp.Key];
                                        return symbols[index];
                                    });
                            }
                        }
                        else
                        {
                            result.MSetLazy(parentProperty,
                                () =>
                                {
                                    var map = (Dictionary<string, ImmutableArray<IMetaSymbol>>)result.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                                    return map[kvp.Key].FirstOrDefault();
                                });
                        }
                    }
                }
            }
            return result;
        }

        public override RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SoalDeclarationTreeBuilder.ForTree((SoalSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, InContainerBinder inContainerBinder)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateMergedNamespace(Compilation compilation, MutableModel modelBuilder, IMetaSymbol containingNamespace, IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            var nsList = namespacesToMerge.ToList();
            return this.CreateNamespace(compilation, modelBuilder, containingNamespace, nsList.Count > 0 ? nsList[0].MName : string.Empty);
        }

        public override IMetaSymbol CreateNamespace(Compilation compilation, MutableModel modelBuilder, IMetaSymbol containingNamespace, string name)
        {
            SoalFactory f = new SoalFactory(modelBuilder);
            var result = f.Namespace();
            result.Name = name;
            if (containingNamespace != null)
            {
                ((NamespaceBuilder)containingNamespace).Declarations.Add(result);
            }
            else if (compilation != null)
            {
                result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, compilation);
            }
            return result;
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
