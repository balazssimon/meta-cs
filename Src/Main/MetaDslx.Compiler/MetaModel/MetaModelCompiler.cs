using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    [Flags]
    public enum ScopeEntryKind
    {
        None = 0,
        Type = 1,
        Name = 2
    }

    public enum NameKind
    {
        Namespace,
        Metamodel,
        Class,
        Enum,
        EnumValue,
        Property,
        Const,
        Operation,
        Parameter
    }

    public class NameDefAnnotation
    {
        public NameKind? Kind { get; set; }
    }

    public class NameUseAnnotation
    {
        public NameKind? Kind { get; set; }
    }

    public class TypeDefAnnotation
    {
    }

    public class TypeUseAnnotation
    {
        public NameKind? Kind { get; set; }
    }

    public class ScopeAnnotation
    {

    }

    public class IdentifierAnnotation
    {

    }

    public class QualifiedNameAnnotation
    {

    }

    public class MetaModelCompiler : MetaCompiler
    {
        public MetaModelCompiler(string source, string fileName = null)
            : base(source, fileName)
        {
        }

        public override void Compile()
        {
            this.GlobalScope = new Scope(null, ScopeEntryKind.None, null);
            var voidType = new PrimitiveTypeDefinition("void", this.GlobalScope);
            var intType = new PrimitiveTypeDefinition("int", this.GlobalScope);
            var longType = new PrimitiveTypeDefinition("long", this.GlobalScope);
            var floatType = new PrimitiveTypeDefinition("float", this.GlobalScope);
            var doubleType = new PrimitiveTypeDefinition("double", this.GlobalScope);
            var byteType = new PrimitiveTypeDefinition("byte", this.GlobalScope);
            var boolType = new PrimitiveTypeDefinition("bool", this.GlobalScope);
            var stringType = new PrimitiveTypeDefinition("string", this.GlobalScope);
            var objectType = new PrimitiveTypeDefinition("object", this.GlobalScope);

            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new MetaModelLexer(inputStream);
            this.Lexer.AddErrorListener(this);
            CommonTokenStream commonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new MetaModelParser(commonTokenStream);
            this.Parser.AddErrorListener(this);
            this.ParseTree = this.Parser.main();
            MetaModelParserAnnotator annotator = new MetaModelParserAnnotator();
            annotator.Visit(this.ParseTree);
            this.LexerAnnotations = annotator.LexerAnnotations;
            this.ParserAnnotations = annotator.ParserAnnotations;
            this.ModeAnnotations = annotator.ModeAnnotations;
            this.TokenAnnotations = annotator.TokenAnnotations;
            this.RuleAnnotations = annotator.RuleAnnotations;
            this.TreeAnnotations = annotator.TreeAnnotations;
            MetaVisitorFirstPass firstPass = new MetaVisitorFirstPass(this);
            firstPass.Visit(this.ParseTree);
            MetaVisitorSecondPass secondPass = new MetaVisitorSecondPass(this);
            secondPass.Visit(this.ParseTree);
        }

        public Scope GlobalScope { get; private set; }
        public MetaModelParser.MainContext ParseTree { get; private set; }
        public MetaModelLexer Lexer { get; private set; }
        public MetaModelParser Parser { get; private set; }
        public CommonTokenStream CommonTokenStream { get; private set; }
        public string GeneratedSource { get; private set; }

        public List<object> LexerAnnotations { get; private set; }
        public List<object> ParserAnnotations { get; private set; }
        public Dictionary<int, List<object>> ModeAnnotations { get; private set; }
        public Dictionary<int, List<object>> TokenAnnotations { get; private set; }
        public Dictionary<Type, List<object>> RuleAnnotations { get; private set; }
        public Dictionary<object, List<object>> TreeAnnotations { get; private set; }
    }

    public class PrimitiveTypeDefinition : TypeDefinition
    {
        public PrimitiveTypeDefinition(string name, Scope parent)
            : base(name, ScopeEntryKind.Type, parent)
        {
        }

        public override bool Equals(object obj)
        {
            PrimitiveTypeDefinition rhs = obj as PrimitiveTypeDefinition;
            return rhs != null && this.Name == rhs.Name;
        }
    }

    public enum CollectionTypeKind
    {
        List,
        Set
    }

    public class CollectionTypeDefinition : TypeDefinition
    {
        public CollectionTypeDefinition(string name, CollectionTypeKind kind, Scope parent)
            : base(name, ScopeEntryKind.Type, parent)
        {
            this.CollectionKind = kind;
        }

        public CollectionTypeKind CollectionKind { get; private set; }
        public TypeDefinition InnerType { get; set; }

        public override bool Equals(object obj)
        {
            CollectionTypeDefinition rhs = obj as CollectionTypeDefinition;
            return rhs != null && this.Kind == rhs.Kind && this.InnerType != null && this.InnerType.Equals(rhs.InnerType);
        }
    }

    public class NullableTypeDefinition : TypeDefinition
    {
        public NullableTypeDefinition(string name, Scope parent)
            : base(name, ScopeEntryKind.Type, parent)
        {
        }

        public TypeDefinition InnerType { get; set; }

        public override bool Equals(object obj)
        {
            NullableTypeDefinition rhs = obj as NullableTypeDefinition;
            return rhs != null && this.InnerType != null && this.InnerType.Equals(rhs.InnerType);
        }
    }

    internal class MetaCompilerVisitor : MetaModelParserBaseVisitor<object>
    {
        private MetaModelCompiler compiler;

        public MetaCompilerVisitor(MetaModelCompiler compiler)
        {
            this.compiler = compiler;
        }

        public Scope GetChildScope(Scope currentScope, IParseTree node)
        {
            if (currentScope == null) return null;
            if (node == null) return null;
            ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            if (sa != null || tda != null)
            {
                var nameDefNodes = this.GetNameDefs(node);
                if (nameDefNodes.Count != 1)
                {
                    return null;
                }
                else
                {
                    var qnameNodes = this.GetQualifiedNames(nameDefNodes[0]);
                    if (qnameNodes.Count != 1)
                    {
                        return null;
                    }
                    else
                    {
                        var names = this.GetIdentifiers(qnameNodes[0]);
                        Scope scope = currentScope;
                        for (int i = 0; i < names.Count; ++i)
                        {
                            scope = scope.GetScope(names[i]);
                            if (scope == null) return null;
                        }
                        return scope;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        public List<IParseTree> GetNameDefs(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            for (int i = 0; i < tree.ChildCount; ++i)
            {
                IParseTree child = tree.GetChild(i);
                NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(child);
                if (nda != null)
                {
                    result.Add(child);
                }
            }
            return result;
        }

        public List<IParseTree> GetQualifiedNames(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            QualifiedNameAnnotation qna = this.GetAnnotationFor<QualifiedNameAnnotation>(tree);
            IdentifierAnnotation ia = this.GetAnnotationFor<IdentifierAnnotation>(tree);
            if (qna != null || ia != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetQualifiedNames(tree.GetChild(i)));
                }
            }
            return result;
        }

        public List<IParseTree> GetIdentifiers(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            IdentifierAnnotation ia = this.GetAnnotationFor<IdentifierAnnotation>(tree);
            if (ia != null)
            {
                result.Add(tree);
            }
            else
            {
                for (int i = 0; i < tree.ChildCount; ++i)
                {
                    result.AddRange(this.GetIdentifiers(tree.GetChild(i)));
                }
            }
            return result;
        }

        public List<IParseTree> GetTypeRefs(IParseTree tree)
        {
            List<IParseTree> result = new List<IParseTree>();
            if (tree == null) return result;
            for (int i = 0; i < tree.ChildCount; ++i)
            {
                IParseTree child = tree.GetChild(i);
                TypeUseAnnotation tra = this.GetAnnotationFor<TypeUseAnnotation>(child);
                if (tra != null)
                {
                    result.Add(child);
                }
            }
            return result;
        }

        public T GetAnnotationFor<T>(IParseTree tree)
        {
            if (tree == null) return default(T);
            return this.GetAnnotationsFor<T>(tree).FirstOrDefault();
        }

        public IEnumerable<T> GetAnnotationsFor<T>(IParseTree tree)
        {
            if (tree == null) return new T[0];
            List<object> annotList;
            if (this.compiler.TreeAnnotations.TryGetValue(tree, out annotList))
            {
                return annotList.OfType<T>();
            }
            return new T[0];
        }
    }

    internal class MetaVisitorFirstPass : MetaCompilerVisitor
    {
        private MetaModelCompiler compiler;
        private Scope global;
        private Scope currentScope;
        private TypeDefinition currentType;

        public MetaVisitorFirstPass(MetaModelCompiler compiler)
            : base(compiler)
        {
            this.compiler = compiler;
            this.global = compiler.GlobalScope;
            this.currentScope = this.global;
        }

        public override object VisitChildren(IRuleNode node)
        {
            NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(node);
            if (nua != null)
            {
                var names = this.GetQualifiedNames(node);
                foreach (var name in names)
                {
                    NameReference nameRef = new NameReference(null, nua.Kind, currentScope);
                    nameRef.TreeNodes.Add(name);
                }
            }
            TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(node);
            if (tua != null)
            {
                TypeReference typeRef = new TypeReference(null, null, currentScope);
                typeRef.TreeNodes.Add(node);
            }
            ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            NameDefAnnotation nda = this.GetAnnotationFor<NameDefAnnotation>(node);
            if (sa != null || tda != null)
            {
                object nameKind = null;
                if (nda != null)
                {
                    nameKind = nda.Kind;
                }
                Scope previousScope = currentScope;
                TypeDefinition previousType = currentType;
                Scope scope = currentScope;
                var nameDefNodes = this.GetNameDefs(node);
                if (nameDefNodes.Count == 0)
                {
                    if (tda != null)
                    {
                        currentType = new TypeDefinition(null, nameKind, scope);
                        scope = currentType;
                    }
                    else
                    {
                        scope = new Scope(null, nameKind, scope);
                    }
                }
                else
                {
                    foreach (var nameDefNode in nameDefNodes)
                    {
                        NameDefAnnotation cnda = this.GetAnnotationFor<NameDefAnnotation>(nameDefNode);
                        nameKind = null;
                        if (cnda != null)
                        {
                            nameKind = cnda.Kind;
                        }
                        var qnameNodes = this.GetQualifiedNames(nameDefNode);
                        if (qnameNodes.Count == 0)
                        {
                            if (tda != null)
                            {
                                currentType = new TypeDefinition(null, nameKind, scope);
                                scope = currentType;
                            }
                            else
                            {
                                scope = new Scope(null, nameKind, scope);
                            }
                        }
                        else if (qnameNodes.Count == 1)
                        {
                            Scope parentScope = currentScope;
                            foreach (var qnameNode in qnameNodes)
                            {
                                scope = parentScope;
                                var identifiers = this.GetIdentifiers(qnameNode);
                                if (identifiers.Count == 0)
                                {
                                    if (tda != null)
                                    {
                                        currentType = new TypeDefinition(null, nameKind, scope);
                                        scope = currentType;
                                    }
                                    else
                                    {
                                        scope = new Scope(null, nameKind, scope);
                                    }
                                    //this.compiler.Diagnostics.AddError("The scope element has no name.", compiler.FileName, new TextSpan(qnameNode));
                                }
                                else
                                {
                                    for (int i = 0; i < identifiers.Count; ++i)
                                    {
                                        if (tda != null && i == identifiers.Count - 1)
                                        {
                                            currentType = new TypeDefinition(identifiers[i].GetText(), nameKind, scope);
                                            scope = currentType;
                                        }
                                        else
                                        {
                                            scope = new Scope(identifiers[i].GetText(), nameKind, scope);
                                        }
                                        scope.TreeNodes.Add(identifiers[i]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.compiler.Diagnostics.AddError("Only one type name can be defined at a time.", compiler.FileName, new TextSpan(nameDefNode));
                        }
                    }
                }
                scope.TreeNodes.Add(node);
                currentScope = scope;
                base.VisitChildren(node);
                currentType = previousType;
                currentScope = previousScope;
            }
            else if (nda != null)
            {
                if (node.Parent != null)
                {
                    sa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
                    tda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
                }
                else
                {
                    sa = null;
                    tda = null;
                }
                if (sa == null && tda == null)
                {
                    var nameDefNodes = this.GetNameDefs(node.Parent);
                    foreach (var nameDefNode in nameDefNodes)
                    {
                        var qnameNodes = this.GetQualifiedNames(nameDefNode);
                        foreach (var qnameNode in qnameNodes)
                        {
                            var identifiers = this.GetIdentifiers(qnameNode);
                            if (identifiers.Count == 0)
                            {
                                this.compiler.Diagnostics.AddError("The named element has no name.", compiler.FileName, new TextSpan(qnameNode));
                            }
                            else if (identifiers.Count == 1)
                            {
                                for (int i = 0; i < identifiers.Count; ++i)
                                {
                                    var nameDef = new NameDefinition(identifiers[i].GetText(), nda.Kind, currentScope);
                                    nameDef.TreeNodes.Add(identifiers[i]);
                                    nameDef.TreeNodes.Add(qnameNode);
                                    if (tda == null)
                                    {
                                        var tras = this.GetTypeRefs(node.Parent);
                                        if (tras.Count == 0)
                                        {
                                            nameDef.Type = currentType;
                                        }
                                    }
                                    else
                                    {
                                        nameDef.Type = currentType;
                                    }
                                }
                            }
                            else
                            {
                                this.compiler.Diagnostics.AddError("Qualified names must be defined as scopes.", compiler.FileName, new TextSpan(qnameNode));
                            }
                        }
                    }
                }
                base.VisitChildren(node);
            }
            else
            {
                base.VisitChildren(node);
            }
            return null;
        }
    }

    internal class MetaVisitorSecondPass : MetaCompilerVisitor
    {
        private MetaModelCompiler compiler;
        private Scope global;
        private Scope currentScope;

        public MetaVisitorSecondPass(MetaModelCompiler compiler)
            : base(compiler)
        {
            this.compiler = compiler;
            this.global = compiler.GlobalScope;
            this.currentScope = this.global;
        }

        public override object VisitChildren(IRuleNode node)
        {
            if (node == null) return null;
            if (currentScope != null)
            {
                TypeUseAnnotation tua = this.GetAnnotationFor<TypeUseAnnotation>(node);
                if (tua != null)
                {
                    TypeReference typeRef = currentScope.GetChild(node) as TypeReference;
                    if (typeRef != null)
                    {
                        MetaMofVisitorTypeRef typeUseVisitor = null;
                        ScopeAnnotation psa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
                        TypeDefAnnotation ptda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
                        if (psa != null || ptda != null)
                        {
                            if (currentScope.Parent != null)
                            {
                                typeUseVisitor = new MetaMofVisitorTypeRef(compiler, global, currentScope.Parent, currentScope.Position, tua.Kind);
                            }
                        }
                        if (typeUseVisitor == null)
                        {
                            typeUseVisitor = new MetaMofVisitorTypeRef(compiler, global, currentScope, typeRef.Position, tua.Kind);
                        }
                        TypeDefinition typeDef = typeUseVisitor.Visit(node);
                        if (typeDef == null)
                        {
                            this.compiler.Diagnostics.AddError("Could not resolve type.", compiler.FileName, new TextSpan(node));
                        }
                        else
                        {
                            typeRef.TypeDef = typeDef;
                            ScopeAnnotation npsa = null;
                            TypeDefAnnotation nptda = null;
                            if (node.Parent != null)
                            {
                                npsa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
                                nptda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
                            }
                            var nameDefNodes = this.GetNameDefs(node.Parent);
                            if (currentScope != null && node.Parent != null && nameDefNodes.Count > 0 && npsa == null && nptda == null)
                            {
                                foreach (var nameDefNode in nameDefNodes)
                                {
                                    var qnameNodes = this.GetQualifiedNames(nameDefNode);
                                    foreach (var qnameNode in qnameNodes)
                                    {
                                        var identifiers = this.GetIdentifiers(qnameNode);
                                        if (identifiers.Count == 0)
                                        {
                                            this.compiler.Diagnostics.AddError("The element has no name.", compiler.FileName, new TextSpan(qnameNode));
                                        }
                                        else if (identifiers.Count == 1)
                                        {
                                            foreach (var identifier in identifiers)
                                            {
                                                NameDefinition nameDef = currentScope.GetChild(qnameNode) as NameDefinition;
                                                if (nameDef == null)
                                                {
                                                    this.compiler.Diagnostics.AddError("Could not resolve name in second pass.", compiler.FileName, new TextSpan(identifier));
                                                }
                                                else
                                                {
                                                    nameDef.Type = typeDef;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.compiler.Diagnostics.AddError("Qualified names must be defined as scopes.", compiler.FileName, new TextSpan(qnameNode));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.compiler.Diagnostics.AddError("Could not resolve type reference in second pass.", compiler.FileName, new TextSpan(node));
                    }
                }
                NameUseAnnotation nua = this.GetAnnotationFor<NameUseAnnotation>(node);
                if (nua != null)
                {
                    var names = this.GetQualifiedNames(node);
                    foreach (var name in names)
                    {
                        NameReference nameRef = currentScope.GetChild(name) as NameReference;
                        if (nameRef != null)
                        {
                            var identifiers = this.GetIdentifiers(name);
                            foreach (var identifier in identifiers)
                            {
                                var identifiersText = identifiers.Select(id => id.GetText()).ToList();
                                ScopeEntry nameDef = null;
                                if (currentScope != null)
                                {
                                    ScopeAnnotation psa = this.GetAnnotationFor<ScopeAnnotation>(node.Parent);
                                    TypeDefAnnotation ptda = this.GetAnnotationFor<TypeDefAnnotation>(node.Parent);
                                    if (psa != null || ptda != null)
                                    {
                                        if (currentScope.Parent != null)
                                        {
                                            nameDef = currentScope.Parent.ResolveName(identifiersText, nua.Kind, currentScope.Position);
                                        }
                                        else
                                        {
                                            nameDef = null;
                                        }
                                    }
                                    else
                                    {
                                        nameDef = currentScope.ResolveName(identifiersText, nua.Kind, nameRef.Position);
                                    }
                                }
                                if (nameDef != null)
                                {
                                    nameRef.NameDef = nameDef;
                                }
                                else
                                {
                                    this.compiler.Diagnostics.AddError("Could not resolve name.", compiler.FileName, new TextSpan(name));
                                }
                            }
                        }
                        else
                        {
                            this.compiler.Diagnostics.AddError("Could not resolve name reference in second pass.", compiler.FileName, new TextSpan(node));
                        }
                    }
                }
            }
            ScopeAnnotation sa = this.GetAnnotationFor<ScopeAnnotation>(node);
            TypeDefAnnotation tda = this.GetAnnotationFor<TypeDefAnnotation>(node);
            if (sa != null || tda != null)
            {
                Scope previousScope = currentScope;
                Scope scope = this.GetChildScope(currentScope, node);
                if (scope != null)
                {
                    currentScope = scope;
                }
                else
                {
                    this.compiler.Diagnostics.AddError("Could not find scope in second pass.", compiler.FileName, new TextSpan(node));
                }
                base.VisitChildren(node);
                currentScope = previousScope;
            }
            else
            {
                base.VisitChildren(node);
            }
            return null;
        }
    }


    internal class MetaMofVisitorTypeRef : MetaModelParserBaseVisitor<TypeDefinition>
    {
        private MetaModelCompiler compiler;
        private Scope global;
        private Scope currentScope;
        private int position;
        private NameKind? kind;

        public MetaMofVisitorTypeRef(MetaModelCompiler compiler, Scope global, Scope currentScope, int position, NameKind? kind)
        {
            this.compiler = compiler;
            this.global = global;
            this.currentScope = currentScope;
            this.position = position;
            this.kind = kind;
        }

        public override TypeDefinition VisitTypeReference(MetaModelParser.TypeReferenceContext context)
        {
            var typeRef = base.VisitTypeReference(context);
            if (typeRef == null)
            {
                return null;
            }
            else
            {
                return this.global.RegisterType(typeRef);
            }
        }

        public override TypeDefinition VisitPrimitiveType(MetaModelParser.PrimitiveTypeContext context)
        {
            return this.global.GetType(context.GetText(), this.kind);
        }

        public override TypeDefinition VisitObjectType(MetaModelParser.ObjectTypeContext context)
        {
            return this.global.GetType(context.GetText(), this.kind);
        }

        public override TypeDefinition VisitVoidType(MetaModelParser.VoidTypeContext context)
        {
            return this.global.GetType(context.GetText(), this.kind);
        }

        public override TypeDefinition VisitNullableType(MetaModelParser.NullableTypeContext context)
        {
            var innerType = this.Visit(context.primitiveType());
            if (context.TQuestion() != null)
            {
                var result = new NullableTypeDefinition(innerType.Name + "?", this.global);
                result.InnerType = innerType;
            }
            return innerType;
        }

        public override TypeDefinition VisitCollectionType(MetaModelParser.CollectionTypeContext context)
        {
            var innerType = this.Visit(context.simpleType());
            CollectionTypeKind kind = CollectionTypeKind.List;
            if (context.KSet() != null)
            {
                kind = CollectionTypeKind.Set;
            }
            return new CollectionTypeDefinition(context.GetText(), kind, this.global);
        }

        public override TypeDefinition VisitSimpleType(MetaModelParser.SimpleTypeContext context)
        {
            if (context.qualifiedName() != null)
            {
                return this.currentScope.ResolveType(context.qualifiedName().identifier().Select(i => i.GetText()).ToList(), this.kind, this.position);
            }
            else
            {
                return base.VisitSimpleType(context);
            }
        }

        public override TypeDefinition VisitQualifiedName(MetaModelParser.QualifiedNameContext context)
        {
            return this.currentScope.ResolveType(context.identifier().Select(i => i.GetText()).ToList(), this.kind, this.position);
        }

        public override TypeDefinition VisitIdentifier(MetaModelParser.IdentifierContext context)
        {
            return this.currentScope.ResolveType(context.GetText(), this.kind, this.position);
        }
    }

}
