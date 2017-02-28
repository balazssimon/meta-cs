using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Languages.Meta.Symbols.Internal;
using MetaDslx.Languages.Meta.Symbols;

namespace MetaDslx.Compiler
{

    [ModelSymbolDescriptor]
    public static class ModelCompilerAttachedProperties
    {
        public static readonly ModelProperty SymbolTreeNodesProperty =
            ModelProperty.Register(typeof(ModelCompilerAttachedProperties), "SymbolTreeNodes",
                new ModelPropertyTypeInfo(typeof(object), typeof(ImmutableModelList<object>)),
                new ModelPropertyTypeInfo(typeof(object), typeof(MutableModelList<object>)));

        public static readonly ModelProperty NameTreeNodesProperty =
            ModelProperty.Register(typeof(ModelCompilerAttachedProperties), "NameTreeNodes",
                new ModelPropertyTypeInfo(typeof(object), typeof(ImmutableModelList<object>)),
                new ModelPropertyTypeInfo(typeof(object), typeof(MutableModelList<object>)));

        public static readonly ModelProperty CanMergeProperty =
            ModelProperty.Register(typeof(ModelCompilerAttachedProperties), "CanMerge",
                new ModelPropertyTypeInfo(typeof(bool), null),
                new ModelPropertyTypeInfo(typeof(bool), null));
    }


    [Flags]
    public enum ResolutionLocation
    {
        Children = 1,
        Inherited = 2,
        Parent = 4,
        Imported = 8,
        ImportedScope = 16,
        Scope = Children | Inherited,
        All = Children | Inherited | Parent | Imported | ImportedScope
    }

    [Flags]
    public enum ResolveKind
    {
        Name = 1,
        Type = 2,
        NameOrType = Name | Type
    }

    public enum NameAccessOrder
    {
        Random,
        Serial,
    }

    public class ResolutionInfo
    {
        public ResolveKind Kind { get; set; }
        public List<MutableSymbol> Scopes { get; private set; }
        public List<object> QualifiedNameNodes { get; private set; }
        public int Position { get; set; }
        public ResolutionLocation Location { get; set; }
        public List<Type> SymbolTypes { get; private set; }

        public ResolutionInfo()
        {
            this.Kind = ResolveKind.NameOrType;
            this.Scopes = new List<MutableSymbol>();
            this.QualifiedNameNodes = new List<object>();
            this.Position = -1;
            this.Location = ResolutionLocation.All;
            this.SymbolTypes = new List<Type>();
        }

        public ResolutionInfo(IEnumerable<MutableSymbol> scopes, ResolveKind kind, IEnumerable<object> qualifiedNameNodes, int position, ResolutionLocation location, IEnumerable<Type> symbolTypes)
            : this()
        {
            this.Kind = kind;
            this.Scopes.AddRange(scopes);
            this.QualifiedNameNodes.AddRange(qualifiedNameNodes);
            this.Position = position;
            this.Location = location;
            this.SymbolTypes.AddRange(symbolTypes);
        }

        public ResolutionInfo(MutableSymbol scope, ResolveKind kind, Object nameNode, int position, ResolutionLocation location)
            : this()
        {
            this.Kind = kind;
            this.Scopes.Add(scope);
            this.QualifiedNameNodes.Add(nameNode);
            this.Position = position;
            this.Location = location;
        }

        public ResolutionInfo(MutableSymbol scope, ResolveKind kind, Object nameNode)
            : this()
        {
            this.Kind = kind;
            this.Scopes.Add(scope);
            this.QualifiedNameNodes.Add(nameNode);
        }
    }

    public class BindingInfo
    {
        public ResolutionInfo ResolutionInfo { get; private set; }
        public List<MutableSymbol> ResolvedObjects { get; private set; }
        public string Name { get; private set; }
        public object Node { get; private set; }
        public bool ResolutionError { get; private set; }

        public BindingInfo(ResolutionInfo resolutionInfo, string name, object node, bool resolutionError)
        {
            this.ResolutionInfo = resolutionInfo;
            this.ResolutionError = resolutionError;
            this.ResolvedObjects = new List<MutableSymbol>();
        }

        public static BindingInfo CreateFromDefinitions(params MutableSymbol[] definitions)
        {
            BindingInfo result = new BindingInfo(new ResolutionInfo(), null, null, false);
            result.ResolvedObjects.AddRange(definitions);
            return result;
        }
    }

    public interface ITriviaProvider
    {
        string GetLeadingTrivia(object node);
        string GetTrailingTrivia(object node);
    }

    public interface INameProvider
    {
        string GetName(object node);
        string GetNameOf(MutableSymbol symbol);
        object GetValue(object node, Type type);
        IEnumerable<TextSpan> GetSymbolTextSpans(MutableSymbol symbol);
        TextSpan GetTreeNodeTextSpan(object node);
    }

    public interface ITypeProvider
    {
        MutableSymbol Balance(MutableSymbol left, MutableSymbol right);
        bool IsAssignableFrom(MutableSymbol left, MutableSymbol right);
        bool Equals(MutableSymbol left, MutableSymbol right);
        bool TypeCheck(MutableSymbol symbol);
        MetaTypeBuilder GetTypeOf(MutableSymbol symbol);
        MetaTypeBuilder GetTypeOf(object value);
        MetaTypeBuilder GetReturnTypeOf(MutableSymbol symbol);
    }

    public interface IResolutionProvider
    {
        MutableSymbol GetParentScope(MutableSymbol symbol);
        MutableSymbol GetCurrentScope(MutableSymbol symbol);
        MutableSymbol GetCurrentTypeScopeOf(MutableSymbol symbol);
        BindingInfo Resolve(ResolutionInfo info);
    }

    public interface IBindingProvider
    {
        MutableSymbol Bind(MutableSymbol context, BindingInfo info);
    }

    public interface IModelCompiler
    {
        ModelCompilerDiagnostics Diagnostics { get; }
        string FileName { get; }
        string Source { get; }
        MetaNamespaceBuilder GlobalScope { get; }
        MutableModelGroup ModelGroup { get; }
        MutableModel Model { get; }
        ITriviaProvider TriviaProvider { get; }
        INameProvider NameProvider { get; }
        ITypeProvider TypeProvider { get; }
        IResolutionProvider ResolutionProvider { get; }
        IBindingProvider BindingProvider { get; }
    }

    public class CompilerProviderBase
    {
        private IModelCompiler compiler;

        public CompilerProviderBase(IModelCompiler compiler)
        {
            if (compiler == null) throw new ArgumentNullException(nameof(compiler));
            this.compiler = compiler;
        }

        public IModelCompiler Compiler { get { return this.compiler; } }
    }

    [Flags]
    public enum Severity
    {
        Error = 1,
        Warning = 2,
        Info = 4,
        All = Error | Warning | Info
    }

    public class DiagnosticMessage : IComparable<DiagnosticMessage>, IEquatable<DiagnosticMessage>
    {
        public string FileName { get; internal set; }
        public TextSpan TextSpan { get; internal set; }
        public string Message { get; internal set; }
        public Severity Severity { get; internal set; }
        public bool IsLog { get; internal set; }

        internal DiagnosticMessage()
        {
        }

        public int CompareTo(DiagnosticMessage other)
        {
            if (other == this) return 0;
            if (other == null) return 1;
            if (this.FileName == null && other.FileName != null) return -1;
            if (this.FileName != null && other.FileName == null) return 1;
            int cmp;
            if (this.FileName != null && other.FileName != null)
            {
                cmp = this.FileName.CompareTo(other.FileName);
                if (cmp != 0) return cmp;
            }
            cmp = this.TextSpan.CompareTo(other.TextSpan);
            if (cmp != 0) return cmp;
            cmp = this.Severity.CompareTo(other.Severity);
            if (cmp != 0) return cmp;
            cmp = this.Message.CompareTo(other.Message);
            if (cmp != 0) return cmp;
            return cmp;
        }

        public override string ToString()
        {
            return string.Format("{0} in '{1}' ({2},{3}): {6}", this.Severity, this.FileName, this.TextSpan.StartLine, this.TextSpan.StartPosition, this.TextSpan.EndLine, this.TextSpan.EndPosition, this.Message);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DiagnosticMessage);
        }

        public bool Equals(DiagnosticMessage other)
        {
            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            int fileNameHash = this.FileName == null ? 0 : this.FileName.GetHashCode();
            int textSpanHash = this.TextSpan.GetHashCode();
            int messageHash = this.Message.GetHashCode();
            int severityHash = this.Severity.GetHashCode();
            return fileNameHash ^ textSpanHash ^ messageHash ^ severityHash;
        }
    }

    public class TextSpan : IComparable<TextSpan>
    {
        public TextSpan()
            : this(0, 0, 0, 0)
        {

        }

        public TextSpan(int startLine, int startPosition, int endLine, int endPosition)
        {
            this.StartLine = startLine;
            this.StartPosition = startPosition;
            this.EndLine = endLine;
            this.EndPosition = endPosition;
        }

        public int StartLine { get; protected set; }
        public int StartPosition { get; protected set; }
        public int EndLine { get; protected set; }
        public int EndPosition { get; protected set; }

        public int CompareTo(TextSpan other)
        {
            int cmp;
            cmp = this.StartLine.CompareTo(other.StartLine);
            if (cmp != 0) return cmp;
            cmp = this.StartPosition.CompareTo(other.StartPosition);
            if (cmp != 0) return cmp;
            cmp = this.EndLine.CompareTo(other.EndLine);
            if (cmp != 0) return cmp;
            cmp = this.EndPosition.CompareTo(other.EndPosition);
            if (cmp != 0) return cmp;
            return 0;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.StartLine, this.StartPosition, this.EndLine, this.EndPosition);
        }

        public override int GetHashCode()
        {
            return this.StartLine.GetHashCode() ^ this.StartPosition.GetHashCode() ^ this.EndLine.GetHashCode() ^ this.EndPosition.GetHashCode();
        }
    }

    public class ModelCompilerDiagnostics : CompilerProviderBase
    {
        private List<DiagnosticMessage> messages;

        private bool sorted = false;
        private bool logsIncluded = false;
        private bool hasErrors = false;
        private bool hasWarnings = false;
        private List<DiagnosticMessage> sortedMessages;

        public ModelCompilerDiagnostics(IModelCompiler compiler)
            : base(compiler)
        {
            this.messages = new List<DiagnosticMessage>();
        }

        public bool HasErrors()
        {
            return this.hasErrors;
        }

        public bool HasWarnings()
        {
            return this.hasWarnings;
        }

        public IEnumerable<DiagnosticMessage> GetMessages(bool includeLog = false)
        {
            if (!this.sorted || this.logsIncluded != includeLog)
            {
                this.sortedMessages =
                    this.messages.Where(m => !m.IsLog || includeLog).OrderBy(m => m.FileName).ThenBy(m => m.TextSpan).ToList();
                this.sortedMessages = this.sortedMessages.Distinct().ToList();
                this.logsIncluded = includeLog;
                this.sorted = true;
            }
            return this.sortedMessages;
        }

        public IEnumerable<DiagnosticMessage> GetMessages(Severity severity, bool includeLog = false)
        {
            this.GetMessages(includeLog);
            return this.sortedMessages.Where(m => (m.Severity | severity) == m.Severity && (!m.IsLog || includeLog));
        }

        public void AddMessage(Severity severity, string message, string fileName, MutableSymbol symbol, bool isLog = false)
        {
            bool added = false;
            foreach (var textSpan in this.Compiler.NameProvider.GetSymbolTextSpans(symbol))
            {
                this.AddMessage(severity, message, fileName, textSpan, isLog);
                added = true;
            }
            if (!added)
            {
                this.AddMessage(severity, message, fileName, new TextSpan(), isLog);
            }
        }

        public void AddMessage(Severity severity, string message, string fileName, object node, bool isLog = false)
        {
            TextSpan textSpan = null;
            textSpan = this.Compiler.NameProvider.GetTreeNodeTextSpan(node);
            this.AddMessage(severity, message, fileName, textSpan, isLog);
        }

        public void AddMessage(Severity severity, string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            if (severity == Severity.Error)
            {
                this.hasErrors = true;
            }
            if (severity == Severity.Warning)
            {
                this.hasWarnings = true;
            }
            this.messages.Add(
                new DiagnosticMessage()
                {
                    Message = message,
                    FileName = fileName,
                    TextSpan = textSpan,
                    Severity = severity,
                    IsLog = isLog
                });
            this.sorted = false;
        }

        public void AddError(string message, string fileName, MutableSymbol symbol, bool isLog = false)
        {
            this.AddMessage(Severity.Error, message, fileName, symbol, isLog);
        }

        public void AddWarning(string message, string fileName, MutableSymbol symbol, bool isLog = false)
        {
            this.AddMessage(Severity.Warning, message, fileName, symbol, isLog);
        }

        public void AddInfo(string message, string fileName, MutableSymbol symbol, bool isLog = false)
        {
            this.AddMessage(Severity.Info, message, fileName, symbol, isLog);
        }

        public void AddError(string message, string fileName, object node, bool isLog = false)
        {
            this.AddMessage(Severity.Error, message, fileName, node, isLog);
        }

        public void AddWarning(string message, string fileName, object node, bool isLog = false)
        {
            this.AddMessage(Severity.Warning, message, fileName, node, isLog);
        }

        public void AddInfo(string message, string fileName, object node, bool isLog = false)
        {
            this.AddMessage(Severity.Info, message, fileName, node, isLog);
        }

        public void AddError(string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            this.AddMessage(Severity.Error, message, fileName, textSpan, isLog);
        }

        public void AddWarning(string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            this.AddMessage(Severity.Warning, message, fileName, textSpan, isLog);
        }

        public void AddInfo(string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            this.AddMessage(Severity.Info, message, fileName, textSpan, isLog);
        }
    }

    public class DefaultTriviaProvider : CompilerProviderBase, ITriviaProvider
    {
        public DefaultTriviaProvider(IModelCompiler compiler)
            : base(compiler)
        {

        }

        public virtual string GetLeadingTrivia(object node)
        {
            return null;
        }

        public virtual string GetTrailingTrivia(object node)
        {
            return null;
        }
    }

    public class DefaultNameProvider : CompilerProviderBase, INameProvider
    {
        public DefaultNameProvider(IModelCompiler compiler)
            : base(compiler)
        {

        }

        public virtual string GetName(object node)
        {
            if (node == null) return null;
            return node.ToString();
        }

        public string GetNameOf(MutableSymbol symbol)
        {
            if (symbol == null) return null;
            return symbol.MName;
        }

        public virtual object GetValue(object node, Type type)
        {
            if (node == null) return null;
            string value = node.ToString();
            if (type == null)
            {
                if (value == "null") return null;
                bool boolValue;
                if (bool.TryParse(value, out boolValue))
                {
                    return boolValue;
                }
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    return intValue;
                }
                long longValue;
                if (long.TryParse(value, out longValue))
                {
                    return longValue;
                }
                float floatValue;
                if (float.TryParse(value, out floatValue))
                {
                    return floatValue;
                }
                double doubleValue;
                if (double.TryParse(value, out doubleValue))
                {
                    return doubleValue;
                }
                return value;
            }
            else
            {
                TypeConverter converter = TypeDescriptor.GetConverter(type);
                if (converter != null)
                {
                    try
                    {
                        object result = converter.ConvertFromInvariantString(value);
                        return result;
                    }
                    catch (Exception)
                    {
                        return value;
                    }
                }
            }
            return value;
        }

        public virtual IEnumerable<TextSpan> GetSymbolTextSpans(MutableSymbol symbol)
        {
            List<TextSpan> result = new List<TextSpan>();
            object nameTreeNodes = symbol.MGet(ModelCompilerAttachedProperties.NameTreeNodesProperty);
            IList<object> nameTreeNodeList = nameTreeNodes as IList<object>;
            if (nameTreeNodeList != null && nameTreeNodeList.Count > 0)
            {
                foreach (var nameTreeNode in nameTreeNodeList)
                {
                    result.Add(this.GetTreeNodeTextSpan(nameTreeNode));
                }
            }
            else
            {
                object symbolTreeNodes = symbol.MGet(ModelCompilerAttachedProperties.SymbolTreeNodesProperty);
                IList<object> symbolTreeNodeList = symbolTreeNodes as IList<object>;
                if (symbolTreeNodes != null)
                {
                    foreach (var symbolTreeNode in symbolTreeNodeList)
                    {
                        result.Add(this.GetTreeNodeTextSpan(symbolTreeNode));
                    }
                }
            }
            return result;
        }

        public virtual TextSpan GetTreeNodeTextSpan(object node)
        {
            return new TextSpan();
        }
    }

    public class DefaultTypeProvider : CompilerProviderBase, ITypeProvider
    {
        public DefaultTypeProvider(IModelCompiler compiler)
            : base(compiler)
        {

        }

        public MutableSymbol Balance(MutableSymbol left, MutableSymbol right)
        {
            throw new NotImplementedException();
        }

        public bool IsAssignableFrom(MutableSymbol left, MutableSymbol right)
        {
            throw new NotImplementedException();
        }

        public bool Equals(MutableSymbol left, MutableSymbol right)
        {
            throw new NotImplementedException();
        }

        public MetaTypeBuilder GetTypeOf(MutableSymbol symbol)
        {
            if (symbol == null) return null;
            MetaTypedElementBuilder mte = symbol as MetaTypedElementBuilder;
            if (mte != null) return mte.Type;
            MetaTypeBuilder mt = symbol as MetaTypeBuilder;
            if (mt != null) return mt;
            return null;
        }

        public MetaTypeBuilder GetTypeOf(object value)
        {
            if (value == null) return MetaInstance.Object.ToMutable();
            MutableSymbol mutableSymbol = value as MutableSymbol;
            if (mutableSymbol != null) return this.GetTypeOf(mutableSymbol);
            if (value is string) return MetaInstance.String.ToMutable();
            if (value is bool) return MetaInstance.Bool.ToMutable();
            if (value is byte) return MetaInstance.Byte.ToMutable();
            if (value is int) return MetaInstance.Int.ToMutable();
            if (value is long) return MetaInstance.Long.ToMutable();
            if (value is float) return MetaInstance.Float.ToMutable();
            if (value is double) return MetaInstance.Double.ToMutable();
            return null;
        }

        public MetaTypeBuilder GetReturnTypeOf(MutableSymbol symbol)
        {
            if (symbol == null) return null;
            MetaFunctionBuilder mf = symbol as MetaFunctionBuilder;
            if (mf != null) return mf.ReturnType;
            return null;
        }

        public bool TypeCheck(MutableSymbol symbol)
        {
            throw new NotImplementedException();
        }
    }

    public class DefaultResolutionProvider : CompilerProviderBase, IResolutionProvider
    {
        public DefaultResolutionProvider(IModelCompiler compiler)
            : base(compiler)
        {

        }

        public virtual MutableSymbol GetParentScope(MutableSymbol symbol)
        {
            MutableSymbol result = null;
            result = this.Compiler.GlobalScope;
            if (symbol != null)
            {
                symbol = symbol.MParent;
            }
            while(symbol != null && !symbol.MIsScope)
            {
                symbol = symbol.MParent;
            }
            if (symbol != null)
            {
                result = symbol;
            }
            return result;
        }

        public virtual MutableSymbol GetCurrentScope(MutableSymbol symbol)
        {
            MutableSymbol result = null;
            result = this.Compiler.GlobalScope;
            while (symbol != null && !symbol.MIsScope)
            {
                symbol = symbol.MParent;
            }
            if (symbol != null)
            {
                result = symbol;
            }
            return result;
        }

        public virtual MutableSymbol GetCurrentTypeScopeOf(MutableSymbol symbol)
        {
            MutableSymbol result = null;
            result = this.Compiler.GlobalScope;
            while (symbol != null && !symbol.MIsScope && !symbol.MIsType)
            {
                symbol = symbol.MParent;
            }
            if (symbol != null)
            {
                result = symbol;
            }
            return result;
        }

        public virtual BindingInfo Resolve(ResolutionInfo resolutionInfo)
        {
            if (resolutionInfo == null || resolutionInfo.QualifiedNameNodes.Count == 0) new BindingInfo(resolutionInfo, null, null, true);
            List<MutableSymbol> currentResult = resolutionInfo.Scopes;
            string name = null;
            object node = null;
            bool first = true;
            bool last = true;
            for (int i = 0; i < resolutionInfo.QualifiedNameNodes.Count; i++)
            {
                node = resolutionInfo.QualifiedNameNodes[i];
                if (node is string)
                {
                    name = (string)node;
                }
                else
                {
                    name = this.Compiler.NameProvider.GetName(node);
                }
                first = i == 0;
                last = i == resolutionInfo.QualifiedNameNodes.Count - 1;
                currentResult = this.Resolve(currentResult, last ? resolutionInfo.Kind : ResolveKind.NameOrType, name, first ? resolutionInfo.Position : -1, first ? resolutionInfo.Location : ResolutionLocation.Scope, last ? resolutionInfo.SymbolTypes : null);
            }
            if (currentResult.Count == 0 && resolutionInfo.QualifiedNameNodes.Count == 1)
            {
                node = resolutionInfo.QualifiedNameNodes[0];
                if (node is string)
                {
                    name = (string)node;
                }
                else
                {
                    name = this.Compiler.NameProvider.GetName(node);
                }
                foreach (var primitiveType in MetaConstants.Types)
                {
                    if (primitiveType.Name == name)
                    {
                        currentResult.Add((MutableSymbol)primitiveType.ToMutable());
                    }
                }
            }
            if (currentResult.Count == 0)
            {
                string nameKind = null;
                switch (last ? resolutionInfo.Kind : ResolveKind.NameOrType)
                {
                    case ResolveKind.Name:
                        nameKind = "name";
                        break;
                    case ResolveKind.Type:
                        nameKind = "type";
                        break;
                    default:
                        nameKind = "name or type";
                        break;
                }
                this.Compiler.Diagnostics.AddError("Could not resolve " + nameKind + " '" + name + "'.", this.Compiler.FileName, node);
            }
            BindingInfo result = new BindingInfo(resolutionInfo, name, node, currentResult.Count == 0);
            result.ResolvedObjects.AddRange(currentResult);
            return result;
        }

        protected virtual List<MutableSymbol> Resolve(List<MutableSymbol> scopes, ResolveKind kind, string name, int position, ResolutionLocation location, List<Type> symbolTypes)
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            foreach (var scope in scopes)
            {
                if (location.HasFlag(ResolutionLocation.Children))
                {
                    result.AddRange(this.ResolveEntries(this.GetEntries<ScopeEntryAttribute>(scope), kind, name, position, symbolTypes));
                }
                if (location.HasFlag(ResolutionLocation.Inherited))
                {
                    result.AddRange(this.Resolve(this.GetScopes<InheritedScopeAttribute>(scope), kind, name, -1, ResolutionLocation.Scope, symbolTypes));
                }
                if (location.HasFlag(ResolutionLocation.Imported))
                {
                    result.AddRange(this.Resolve(this.GetScopes<ImportedScopeAttribute>(scope), kind, name, -1, ResolutionLocation.Scope, symbolTypes));
                }
                if (location.HasFlag(ResolutionLocation.ImportedScope))
                {
                    result.AddRange(this.ResolveEntries(this.GetEntries<ImportedScopeEntryAttribute>(scope), kind, name, -1, symbolTypes));
                }
            }
            if (location.HasFlag(ResolutionLocation.Parent) && result.Count == 0)
            {
                List<MutableSymbol> parentScopes = new List<MutableSymbol>();
                foreach (var scope in scopes)
                {
                    MutableSymbol parentScope = this.GetParentOrNullScope(scope);
                    if (parentScope != null)
                    {
                        parentScopes.Add(parentScope);
                    }
                }
                if (parentScopes.Count > 0)
                {
                    result.AddRange(this.Resolve(parentScopes, kind, name, -1, ResolutionLocation.All, symbolTypes));
                }
            }
            return result;
        }

        protected virtual object GetName(MutableSymbol entry)
        {
            if (entry != null)
            {
                return entry.MName;
            }
            return null;
        }

        protected virtual MutableSymbol GetParentOrNullScope(MutableSymbol scope)
        {
            if (scope == null) return null;
            MutableSymbol parent = scope.MParent;
            while (parent != null && !parent.MIsScope)
            {
                parent = parent.MParent;
            }
            return parent;
        }

        protected virtual List<MutableSymbol> GetScopes<T>(MutableSymbol scope)
            where T : Attribute
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            if (scope == null) return result;
            foreach (var prop in scope.MAllProperties)
            {
                if (prop.Annotations.Any(a => a is T))
                {
                    object entry = scope.MGet(prop);
                    IMutableModelCollection<object> scopeEntries = entry as IMutableModelCollection<object>;
                    if (scopeEntries != null)
                    {
                        foreach (var scopeEntry in scopeEntries)
                        {
                            MutableSymbol scopeEntryObject = scopeEntry as MutableSymbol;
                            if (scopeEntryObject != null && scopeEntryObject.MIsScope)
                            {
                                result.Add(scopeEntryObject);
                            }
                        }
                    }
                    else
                    {
                        MutableSymbol entryObject = entry as MutableSymbol;
                        if (entryObject != null && entryObject.MIsScope)
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }

        protected virtual List<MutableSymbol> GetEntries<T>(MutableSymbol scope)
            where T : Attribute
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            if (scope == null) return result;
            foreach (var prop in scope.MAllProperties)
            {
                if (prop.Annotations.Any(a => a is T))
                {
                    object entry = scope.MGet(prop);
                    IMutableModelCollection<object> scopeEntries = entry as IMutableModelCollection<object>;
                    if (scopeEntries != null)
                    {
                        IEnumerable<object> scopeEntryList = scopeEntries as IEnumerable<object>;
                        foreach (var scopeEntry in scopeEntryList)
                        {
                            MutableSymbol scopeEntryObject = scopeEntry as MutableSymbol;
                            if (scopeEntryObject != null)
                            {
                                result.Add(scopeEntryObject);
                            }
                        }
                    }
                    else
                    {
                        MutableSymbol entryObject = entry as MutableSymbol;
                        if (entryObject != null)
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }

        protected virtual List<MutableSymbol> ResolveEntries(IEnumerable<MutableSymbol> entries, ResolveKind kind, string name, int position, List<Type> symbolTypes)
        {
            List<MutableSymbol> result = new List<MutableSymbol>();
            if (name == null) return result;
            foreach (var entry in entries)
            {
                MutableSymbol entryObject = entry as MutableSymbol;
                if (entryObject != null && name.Equals(this.GetName(entryObject)))
                {
                    if ((kind.HasFlag(ResolveKind.Type) && entryObject.MIsType)
                        || (kind.HasFlag(ResolveKind.Name) && !entryObject.MIsType))
                    {
                        bool typeOK = false;
                        if (symbolTypes != null && symbolTypes.Count > 0)
                        {
                            foreach (var symbolType in symbolTypes)
                            {
                                if (symbolType.IsAssignableFrom(entryObject.MId.SymbolInfo.ImmutableType) ||
                                    symbolType.IsAssignableFrom(entryObject.MId.SymbolInfo.MutableType))
                                {
                                    typeOK = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            typeOK = true;
                        }
                        if (typeOK)
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }
    }

    public class DefaultBindingProvider : CompilerProviderBase, IBindingProvider
    {
        public DefaultBindingProvider(IModelCompiler compiler)
            : base(compiler)
        {

        }

        protected virtual string GetKindName(ResolutionInfo resolutionInfo)
        {
            if (resolutionInfo == null) return "name or type";
            switch (resolutionInfo.Kind)
            {
                case ResolveKind.Name:
                    return "name";
                case ResolveKind.Type:
                    return "type";
                default:
                    return "name or type";
            }
        }

        public virtual MutableSymbol Bind(MutableSymbol context, BindingInfo bindingInfo)
        {
            if (bindingInfo == null) return null;
            if (bindingInfo.ResolutionError) return null;
            List<MutableSymbol> alternativeList = bindingInfo.ResolvedObjects;
            if (alternativeList.Count == 0)
            {
                this.Compiler.Diagnostics.AddError("Cannot resolve " + this.GetKindName(bindingInfo.ResolutionInfo) + " '"+bindingInfo.Name+"'.", this.Compiler.FileName, bindingInfo.Node ?? context);
                return null;
            }
            else if (alternativeList.Count > 1)
            {
                this.Compiler.Diagnostics.AddError("Ambiguous " + this.GetKindName(bindingInfo.ResolutionInfo) + " '" + bindingInfo.Name + "'.", this.Compiler.FileName, bindingInfo.Node ?? context);
                return null;
            }
            else
            {
                MutableSymbol symbol = alternativeList[0];
                return symbol;
            }
        }
    }


    public class DefaultModelCompiler : IModelCompiler
    {
        public DefaultModelCompiler()
        {
            this.ModelGroup = new MutableModelGroup();
            this.Model = this.ModelGroup.CreateModel();
            MetaFactory factory = new MetaFactory(this.Model);
            this.GlobalScope = factory.MetaNamespace();
            this.Diagnostics = new ModelCompilerDiagnostics(this);
            this.TriviaProvider = new DefaultTriviaProvider(this);
            this.NameProvider = new DefaultNameProvider(this);
            this.TypeProvider = new DefaultTypeProvider(this);
            this.ResolutionProvider = new DefaultResolutionProvider(this);
            this.BindingProvider = new DefaultBindingProvider(this);
        }

        public virtual ModelCompilerDiagnostics Diagnostics { get; protected set; }
        public virtual string FileName { get; protected set; }
        public virtual string Source { get; protected set; }
        public virtual MetaNamespaceBuilder GlobalScope { get; protected set; }
        public virtual MutableModelGroup ModelGroup { get; protected set; }
        public virtual MutableModel Model { get; protected set; }
        public virtual ITriviaProvider TriviaProvider { get; protected set; }
        public virtual INameProvider NameProvider { get; protected set; }
        public virtual ITypeProvider TypeProvider { get; protected set; }
        public virtual IResolutionProvider ResolutionProvider { get; protected set; }
        public virtual IBindingProvider BindingProvider { get; protected set; }
    }
}
