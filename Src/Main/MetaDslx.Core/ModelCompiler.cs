using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
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
        public List<ModelObject> Scopes { get; private set; }
        public List<object> QualifiedNameNodes { get; private set; }
        public int Position { get; set; }
        public ResolutionLocation Location { get; set; }
        public List<Type> SymbolTypes { get; private set; }

        public ResolutionInfo()
        {
            this.Kind = ResolveKind.NameOrType;
            this.Scopes = new List<ModelObject>();
            this.QualifiedNameNodes = new List<object>();
            this.Position = -1;
            this.Location = ResolutionLocation.All;
            this.SymbolTypes = new List<Type>();
        }

        public ResolutionInfo(IEnumerable<ModelObject> scopes, ResolveKind kind, IEnumerable<object> qualifiedNameNodes, int position, ResolutionLocation location, IEnumerable<Type> symbolTypes)
            : this()
        {
            this.Kind = kind;
            this.Scopes.AddRange(scopes);
            this.QualifiedNameNodes.AddRange(qualifiedNameNodes);
            this.Position = position;
            this.Location = location;
            this.SymbolTypes.AddRange(symbolTypes);
        }

        public ResolutionInfo(ModelObject scope, ResolveKind kind, Object nameNode, int position, ResolutionLocation location)
            : this()
        {
            this.Kind = kind;
            this.Scopes.Add(scope);
            this.QualifiedNameNodes.Add(nameNode);
            this.Position = position;
            this.Location = location;
        }

        public ResolutionInfo(ModelObject scope, ResolveKind kind, Object nameNode)
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
        public List<ModelObject> ResolvedObjects { get; private set; }
        public string Name { get; private set; }
        public object Node { get; private set; }
        public bool ResolutionError { get; private set; }

        public BindingInfo(ResolutionInfo resolutionInfo, string name, object node, bool resolutionError)
        {
            this.ResolutionInfo = resolutionInfo;
            this.ResolutionError = resolutionError;
            this.ResolvedObjects = new List<ModelObject>();
        }

        public static BindingInfo CreateFromDefinitions(params ModelObject[] definitions)
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
        string GetNameOf(ModelObject symbol);
        object GetValue(object node, Type type);
        IEnumerable<TextSpan> GetSymbolTextSpans(ModelObject symbol);
        TextSpan GetTreeNodeTextSpan(object node);
    }

    public interface ITypeProvider
    {
        ModelObject Balance(ModelObject left, ModelObject right);
        bool IsAssignableFrom(ModelObject left, ModelObject right);
        bool Equals(ModelObject left, ModelObject right);
        bool TypeCheck(ModelObject symbol);
        MetaType GetTypeOf(ModelObject symbol);
        MetaType GetTypeOf(object value);
        MetaType GetReturnTypeOf(ModelObject symbol);
    }

    public interface IResolutionProvider
    {
        ModelObject GetParentScope(ModelObject symbol);
        ModelObject GetCurrentScope(ModelObject symbol);
        ModelObject GetCurrentTypeScopeOf(ModelObject symbol);
        BindingInfo Resolve(ResolutionInfo info);
    }

    public interface IBindingProvider
    {
        ModelObject Bind(ModelObject context, BindingInfo info);
    }

    public interface IModelCompiler
    {
        ModelCompilerDiagnostics Diagnostics { get; }
        string FileName { get; }
        string Source { get; }
        RootScope GlobalScope { get; }
        Model Model { get; }
        ITriviaProvider TriviaProvider { get; }
        INameProvider NameProvider { get; }
        ITypeProvider TypeProvider { get; }
        IResolutionProvider ResolutionProvider { get; }
        IBindingProvider BindingProvider { get; }
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

    public class ModelCompilerDiagnostics
    {
        private List<DiagnosticMessage> messages;

        private bool sorted = false;
        private bool logsIncluded = false;
        private bool hasErrors = false;
        private bool hasWarnings = false;
        private List<DiagnosticMessage> sortedMessages;

        public ModelCompilerDiagnostics()
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

        public void AddMessage(Severity severity, string message, string fileName, ModelObject symbol, bool isLog = false)
        {
            bool added = false;
            IModelCompiler compiler = ModelCompilerContext.Current;
            if (compiler != null)
            {
                foreach (var textSpan in compiler.NameProvider.GetSymbolTextSpans(symbol))
                {
                    this.AddMessage(severity, message, fileName, textSpan, isLog);
                    added = true;
                }
            }
            if (!added)
            {
                this.AddMessage(severity, message, fileName, new TextSpan(), isLog);
            }
        }

        public void AddMessage(Severity severity, string message, string fileName, object node, bool isLog = false)
        {
            TextSpan textSpan = null;
            IModelCompiler compiler = ModelCompilerContext.Current;
            if (compiler != null)
            {
                textSpan = compiler.NameProvider.GetTreeNodeTextSpan(node);
            }
            else
            {
                textSpan = new TextSpan();
            }
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

        public void AddError(string message, string fileName, ModelObject symbol, bool isLog = false)
        {
            this.AddMessage(Severity.Error, message, fileName, symbol, isLog);
        }

        public void AddWarning(string message, string fileName, ModelObject symbol, bool isLog = false)
        {
            this.AddMessage(Severity.Warning, message, fileName, symbol, isLog);
        }

        public void AddInfo(string message, string fileName, ModelObject symbol, bool isLog = false)
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

    public class DefaultTriviaProvider : ITriviaProvider
    {
        public virtual string GetLeadingTrivia(object node)
        {
            return null;
        }

        public virtual string GetTrailingTrivia(object node)
        {
            return null;
        }
    }

    public class DefaultNameProvider : INameProvider
    {
        public virtual string GetName(object node)
        {
            if (node == null) return null;
            return node.ToString();
        }

        public string GetNameOf(ModelObject symbol)
        {
            if (symbol == null) return null;
            foreach (var prop in symbol.MGetProperties())
            {
                if (prop.IsMetaName())
                {
                    object value = symbol.MGet(prop);
                    if (value == null) return null;
                    else if (value is string) return (string)value;
                    else return value.ToString();
                }
            }
            return null;
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

        public virtual IEnumerable<TextSpan> GetSymbolTextSpans(ModelObject symbol)
        {
            List<TextSpan> result = new List<TextSpan>();
            object nameTreeNodes = symbol.MGet(MetaScopeEntryProperties.NameTreeNodesProperty);
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
                object symbolTreeNodes = symbol.MGet(MetaScopeEntryProperties.SymbolTreeNodesProperty);
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

    public class DefaultTypeProvider : ITypeProvider
    {
        public ModelObject Balance(ModelObject left, ModelObject right)
        {
            if (left == right) return left;
            if (left == MetaInstance.Error) return (ModelObject)MetaInstance.Error;
            if (right == MetaInstance.Error) return (ModelObject)MetaInstance.Error;
            if (left == MetaInstance.None) return (ModelObject)MetaInstance.None;
            if (right == MetaInstance.None) return (ModelObject)MetaInstance.None;
            if (left == MetaInstance.Object) return (ModelObject)MetaInstance.Object;
            if (right == MetaInstance.Object) return (ModelObject)MetaInstance.Object;
            if (left == MetaInstance.Any) return right;
            if (right == MetaInstance.Any) return left;
            MetaPrimitiveType primLeft = left as MetaPrimitiveType;
            MetaPrimitiveType primRight = right as MetaPrimitiveType;
            if (primLeft != null && primRight != null)
            {
                if (primLeft == MetaInstance.Byte && primRight == MetaInstance.Int) return (ModelObject)MetaInstance.Int;
                if (primLeft == MetaInstance.Byte && primRight == MetaInstance.Long) return (ModelObject)MetaInstance.Long;
                if (primLeft == MetaInstance.Int && primRight == MetaInstance.Byte) return (ModelObject)MetaInstance.Int;
                if (primLeft == MetaInstance.Int && primRight == MetaInstance.Long) return (ModelObject)MetaInstance.Long;
                if (primLeft == MetaInstance.Long && primRight == MetaInstance.Byte) return (ModelObject)MetaInstance.Long;
                if (primLeft == MetaInstance.Long && primRight == MetaInstance.Int) return (ModelObject)MetaInstance.Long;
                if (primLeft == MetaInstance.Byte && primRight == MetaInstance.Float) return (ModelObject)MetaInstance.Float;
                if (primLeft == MetaInstance.Byte && primRight == MetaInstance.Double) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Int && primRight == MetaInstance.Float) return (ModelObject)MetaInstance.Float;
                if (primLeft == MetaInstance.Int && primRight == MetaInstance.Double) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Long && primRight == MetaInstance.Float) return (ModelObject)MetaInstance.Float;
                if (primLeft == MetaInstance.Long && primRight == MetaInstance.Double) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Byte) return (ModelObject)MetaInstance.Float;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Byte) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Int) return (ModelObject)MetaInstance.Float;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Int) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Long) return (ModelObject)MetaInstance.Float;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Long) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Double) return (ModelObject)MetaInstance.Double;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Float) return (ModelObject)MetaInstance.Double;
                return (ModelObject)MetaInstance.Error;
            }
            MetaFactory factory = MetaFactory.Instance;
            MetaNullableType nullLeft = left as MetaNullableType;
            MetaNullableType nullRight = right as MetaNullableType;
            if (nullLeft != null && nullRight != null)
            {
                ModelObject balancedInnerTypeObject = this.Balance((ModelObject)nullLeft.InnerType, (ModelObject)nullRight.InnerType);
                MetaType balancedInnerType = balancedInnerTypeObject as MetaType;
                if (balancedInnerType != null && balancedInnerType != MetaInstance.Error)
                {
                    MetaNullableType nullResult = factory.CreateMetaNullableType();
                    nullResult.InnerType = balancedInnerType as MetaType;
                    return (ModelObject)nullResult;
                }
                else
                {
                    balancedInnerTypeObject = this.Balance((ModelObject)nullLeft.InnerType, right);
                    balancedInnerType = balancedInnerTypeObject as MetaType;
                    if (balancedInnerType != null && balancedInnerType != MetaInstance.Error)
                    {
                        MetaNullableType nullResult = factory.CreateMetaNullableType();
                        nullResult.InnerType = balancedInnerType as MetaType;
                        return (ModelObject)nullResult;
                    }
                    else
                    {
                        balancedInnerTypeObject = this.Balance(left, (ModelObject)nullRight.InnerType);
                        balancedInnerType = balancedInnerTypeObject as MetaType;
                        if (balancedInnerType != null && balancedInnerType != MetaInstance.Error)
                        {
                            MetaNullableType nullResult = factory.CreateMetaNullableType();
                            nullResult.InnerType = balancedInnerType as MetaType;
                            return (ModelObject)nullResult;
                        }
                        else
                        {
                            return (ModelObject)MetaInstance.Error;
                        }
                    }
                }
            }
            MetaCollectionType collLeft = left as MetaCollectionType;
            MetaCollectionType collRight = right as MetaCollectionType;
            if (collLeft != null && collRight != null)
            {
                if (collLeft.Kind == collRight.Kind && this.Equals((ModelObject)collLeft.InnerType, (ModelObject)collRight.InnerType))
                {
                    ModelObject balancedInnerTypeObject = this.Balance((ModelObject)collLeft.InnerType, (ModelObject)collLeft.InnerType);
                    MetaType balancedInnerType = balancedInnerTypeObject as MetaType;
                    if (balancedInnerType != null && balancedInnerType != MetaInstance.Error)
                    {
                        MetaCollectionType collResult = factory.CreateMetaCollectionType();
                        collResult.Kind = collLeft.Kind;
                        collResult.InnerType = balancedInnerType as MetaType;
                        return (ModelObject)collResult;
                    }
                    else
                    {
                        return (ModelObject)MetaInstance.Error;
                    }
                }
                else
                {
                    return (ModelObject)MetaInstance.Error;
                }
            }
            MetaClass clsLeft = left as MetaClass;
            MetaClass clsRight = right as MetaClass;
            if (clsLeft != null && clsRight != null)
            {
                if (clsRight.GetAllSuperClasses(false).Contains(clsLeft))
                {
                    return left;
                }
                if (clsLeft.GetAllSuperClasses(false).Contains(clsRight))
                {
                    return right;
                }
                return (ModelObject)MetaInstance.Error;
            }
            return (ModelObject)MetaInstance.Error;
        }

        public bool IsAssignableFrom(ModelObject left, ModelObject right)
        {
            if (this.Equals(left, right)) return true;
            if (left == MetaInstance.Error) return false;
            if (right == MetaInstance.Error) return false;
            if (left == MetaInstance.None) return false;
            if (right == MetaInstance.None) return false;
            if (left == MetaInstance.Any) return true;
            if (left == MetaInstance.Object) return true;
            if (right == MetaInstance.Any) return true;
            if (right == MetaInstance.Object) return false;
            if (left == MetaInstance.ModelObject) return (right is ModelObject) || (right == MetaInstance.ModelObject);
            if (left == MetaDescriptor.MetaType.MetaClass) return (right is MetaType) || (right == MetaDescriptor.MetaType.MetaClass);
            if (right == MetaInstance.ModelObject) return (left is ModelObject) || (left == MetaInstance.ModelObject);
            if (right == MetaDescriptor.MetaType.MetaClass) return (left is MetaType) || (left == MetaDescriptor.MetaType.MetaClass);
            MetaPrimitiveType primLeft = left as MetaPrimitiveType;
            MetaPrimitiveType primRight = right as MetaPrimitiveType;
            if (primLeft != null && primRight != null)
            {
                if (primLeft == MetaInstance.Int && primRight == MetaInstance.Byte) return true;
                if (primLeft == MetaInstance.Long && primRight == MetaInstance.Byte) return true;
                if (primLeft == MetaInstance.Long && primRight == MetaInstance.Int) return true;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Byte) return true;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Byte) return true;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Int) return true;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Int) return true;
                if (primLeft == MetaInstance.Float && primRight == MetaInstance.Long) return true;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Long) return true;
                if (primLeft == MetaInstance.Double && primRight == MetaInstance.Float) return true;
                return false;
            }
            MetaFactory factory = MetaFactory.Instance;
            MetaNullableType nullLeft = left as MetaNullableType;
            MetaNullableType nullRight = right as MetaNullableType;
            if (nullLeft != null && nullRight != null)
            {
                return this.IsAssignableFrom((ModelObject)nullLeft.InnerType, (ModelObject)nullRight.InnerType)
                    || this.IsAssignableFrom((ModelObject)nullLeft.InnerType, right);
            }
            MetaCollectionType collLeft = left as MetaCollectionType;
            MetaCollectionType collRight = right as MetaCollectionType;
            if (collLeft != null && collRight != null)
            {
                return collLeft.Kind == collRight.Kind && this.Equals((ModelObject)collLeft.InnerType, (ModelObject)collRight.InnerType);
            }
            MetaClass clsLeft = left as MetaClass;
            MetaClass clsRight = right as MetaClass;
            if (clsLeft != null && clsRight != null)
            {
                return clsRight.GetAllSuperClasses(false).Contains(clsLeft);
            }
            return false;
        }

        public bool Equals(ModelObject left, ModelObject right)
        {
            if (left == right) return true;
            if (left == MetaInstance.Error) return false;
            if (right == MetaInstance.Error) return false;
            if (left == MetaInstance.None) return false;
            if (right == MetaInstance.None) return false;
            if (left == MetaInstance.Any) return true;
            if (right == MetaInstance.Any) return true;
            if (left == MetaInstance.Object) return right == MetaInstance.Object;
            if (right == MetaInstance.Object) return false;
            if (left == MetaInstance.ModelObject) return right == MetaInstance.ModelObject;
            if (right == MetaInstance.ModelObject) return false;
            if (left == MetaDescriptor.MetaType.MetaClass) return right == MetaDescriptor.MetaType.MetaClass;
            if (right == MetaDescriptor.MetaType.MetaClass) return false;
            if (left == MetaInstance.ModelObjectList)
            {
                if (right == MetaInstance.ModelObjectList) return true;
                MetaCollectionType cr = right as MetaCollectionType;
                if (cr != null)
                {
                    return cr.Kind == MetaCollectionKind.List && this.Equals((ModelObject)cr.InnerType, (ModelObject)MetaInstance.ModelObject);
                }
                else
                {
                    return false;
                }
            }
            if (right == MetaInstance.ModelObjectList)
            {
                if (left == MetaInstance.ModelObjectList) return true;
                MetaCollectionType cl = left as MetaCollectionType;
                if (cl != null)
                {
                    return cl.Kind == MetaCollectionKind.List && this.Equals((ModelObject)cl.InnerType, (ModelObject)MetaInstance.ModelObject);
                }
                else
                {
                    return false;
                }
            }
            MetaPrimitiveType primLeft = left as MetaPrimitiveType;
            MetaPrimitiveType primRight = right as MetaPrimitiveType;
            if (primLeft != null && primRight != null)
            {
                return false;
            }
            MetaFactory factory = MetaFactory.Instance;
            MetaNullableType nullLeft = left as MetaNullableType;
            MetaNullableType nullRight = right as MetaNullableType;
            if (nullLeft != null && nullRight != null)
            {
                return this.Equals((ModelObject)nullLeft.InnerType, (ModelObject)nullRight.InnerType);
            }
            MetaCollectionType collLeft = left as MetaCollectionType;
            MetaCollectionType collRight = right as MetaCollectionType;
            if (collLeft != null && collRight != null)
            {
                return collLeft.Kind == collRight.Kind && this.Equals((ModelObject)collLeft.InnerType, (ModelObject)collRight.InnerType);
            }
            MetaFunctionType funLeft = left as MetaFunctionType;
            MetaFunctionType funRight = right as MetaFunctionType;
            if (funLeft != null && funRight != null)
            {
                if (funLeft.ParameterTypes.Count != funRight.ParameterTypes.Count) return false;
                // TODO
                if (!this.Equals((ModelObject)funLeft.ReturnType, (ModelObject)funRight.ReturnType))
                {
                    if (funLeft.ReturnType.ToString() == funRight.ReturnType.ToString()) return true;
                    else return false;
                }
                //if (!this.Equals((ModelObject)funLeft.ReturnType, (ModelObject)funRight.ReturnType)) return false;
                for (int i = 0; i < funLeft.ParameterTypes.Count; i++)
                {
                    if (!this.Equals((ModelObject)funLeft.ParameterTypes[i], (ModelObject)funRight.ParameterTypes[i]))
                    {
                        if (funLeft.ParameterTypes[i].ToString() == funRight.ParameterTypes[i].ToString()) return true;
                        else return false;
                    }
                }
                return true;
            }
            return false;
        }

        public MetaType GetTypeOf(ModelObject symbol)
        {
            if (symbol == null) return MetaInstance.None;
            MetaTypedElement mte = symbol as MetaTypedElement;
            if (mte != null) return mte.Type;
            MetaType mt = symbol as MetaType;
            if (mt != null) return mt;
            return MetaInstance.None;
        }

        public MetaType GetTypeOf(object value)
        {
            if (value == null) return MetaInstance.Object;
            ModelObject symbol = value as ModelObject;
            if (symbol != null) return this.GetTypeOf(symbol);
            if (value is string) return MetaInstance.String;
            if (value is bool) return MetaInstance.Bool;
            if (value is byte) return MetaInstance.Byte;
            if (value is int) return MetaInstance.Int;
            if (value is long) return MetaInstance.Long;
            if (value is float) return MetaInstance.Float;
            if (value is double) return MetaInstance.Double;
            return MetaInstance.None;
        }

        public MetaType GetReturnTypeOf(ModelObject symbol)
        {
            if (symbol == null) return MetaInstance.None;
            MetaFunction mf = symbol as MetaFunction;
            if (mf != null) return mf.ReturnType;
            return MetaInstance.None;
        }

        public bool TypeCheck(ModelObject symbol)
        {
            MetaExpression expr = symbol as MetaExpression;
            if (expr == null) return true;
            bool result = this.IsAssignableFrom((ModelObject)expr.ExpectedType, (ModelObject)expr.Type);
            if (!result)
            {
                IModelCompiler compiler = ModelCompilerContext.Current;
                if (compiler != null)
                {
                    if (expr.ExpectedType == MetaInstance.None)
                    {
                        return true;
                    }
                    else  if (expr.ExpectedType == null)
                    {
                        compiler.Diagnostics.AddError("The expression has no expected type.", compiler.FileName, symbol);
                    }
                    else if (expr.Type == null)
                    {
                        compiler.Diagnostics.AddError("The expression has no type.", compiler.FileName, symbol);
                    }
                    else
                    {
                        compiler.Diagnostics.AddError("'" + expr.ExpectedType + "' type expected, but expression has type '" + expr.Type + "'.", compiler.FileName, symbol);
                    }
                }
            }
            return result;
        }
    }

    public class DefaultResolutionProvider : IResolutionProvider
    {
        public virtual ModelObject GetParentScope(ModelObject symbol)
        {
            IModelCompiler compiler = ModelCompilerContext.Current;
            ModelObject result = null;
            if (compiler != null)
            {
                result = compiler.GlobalScope;
            }
            if (symbol != null)
            {
                symbol = symbol.MParent;
            }
            while(symbol != null && !symbol.IsMetaScope())
            {
                symbol = symbol.MParent;
            }
            if (symbol != null)
            {
                result = symbol;
            }
            return result;
        }

        public virtual ModelObject GetCurrentScope(ModelObject symbol)
        {
            IModelCompiler compiler = ModelCompilerContext.Current;
            ModelObject result = null;
            if (compiler != null)
            {
                result = compiler.GlobalScope;
            }
            while (symbol != null && !symbol.IsMetaScope())
            {
                symbol = symbol.MParent;
            }
            if (symbol != null)
            {
                result = symbol;
            }
            return result;
        }

        public virtual ModelObject GetCurrentTypeScopeOf(ModelObject symbol)
        {
            IModelCompiler compiler = ModelCompilerContext.Current;
            ModelObject result = null;
            if (compiler != null)
            {
                result = compiler.GlobalScope;
            }
            while (symbol != null && !symbol.IsMetaScope() && !symbol.IsMetaType())
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
            List<ModelObject> currentResult = resolutionInfo.Scopes;
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
                    name = ModelCompilerContext.Current.NameProvider.GetName(node);
                }
                first = i == 0;
                last = i == resolutionInfo.QualifiedNameNodes.Count - 1;
                currentResult = this.Resolve(currentResult, last ? resolutionInfo.Kind : ResolveKind.NameOrType, name, first ? resolutionInfo.Position : -1, first ? resolutionInfo.Location : ResolutionLocation.Scope, last ? resolutionInfo.SymbolTypes : null);
            }
            if (currentResult.Count == 0)
            {
                IModelCompiler compiler = ModelCompilerContext.Current;
                if (compiler != null)
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
                    compiler.Diagnostics.AddError("Could not resolve " + nameKind + " '" + name + "'.", compiler.FileName, node);
                }
            }
            BindingInfo result = new BindingInfo(resolutionInfo, name, node, currentResult.Count == 0);
            result.ResolvedObjects.AddRange(currentResult);
            return result;
        }

        protected virtual List<ModelObject> Resolve(List<ModelObject> scopes, ResolveKind kind, string name, int position, ResolutionLocation location, List<Type> symbolTypes)
        {
            List<ModelObject> result = new List<ModelObject>();
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
                    result.AddRange(this.ResolveEntries(this.GetEntries<ImportedEntryAttribute>(scope), kind, name, -1, symbolTypes));
                }
            }
            if (location.HasFlag(ResolutionLocation.Parent) && result.Count == 0)
            {
                List<ModelObject> parentScopes = new List<ModelObject>();
                foreach (var scope in scopes)
                {
                    ModelObject parentScope = this.GetParentOrNullScope(scope);
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

        protected virtual object GetName(ModelObject entry)
        {
            if (entry != null)
            {
                foreach (var prop in entry.MGetProperties())
                {
                    if (prop.IsMetaName())
                    {
                        if (entry.MIsValueCreated(prop))
                        {
                            return entry.MGet(prop);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        protected virtual ModelObject GetParentOrNullScope(ModelObject scope)
        {
            if (scope == null) return null;
            ModelObject parent = scope.MParent;
            while (parent != null && !parent.IsMetaScope())
            {
                parent = parent.MParent;
            }
            return parent;
        }

        protected virtual List<ModelObject> GetScopes<T>(ModelObject scope)
            where T : Attribute
        {
            List<ModelObject> result = new List<ModelObject>();
            if (scope == null) return result;
            foreach (var prop in scope.MGetAllProperties())
            {
                if (prop.Annotations.Any(a => a is T))
                {
                    object entry = scope.MGet(prop);
                    ModelCollection scopeEntries = entry as ModelCollection;
                    if (scopeEntries != null)
                    {
                        IEnumerable<object> scopeEntryList = scopeEntries as IEnumerable<object>;
                        foreach (var scopeEntry in scopeEntryList)
                        {
                            ModelObject scopeEntryObject = scopeEntry as ModelObject;
                            if (scopeEntryObject != null && scopeEntryObject.IsMetaScope())
                            {
                                result.Add(scopeEntryObject);
                            }
                        }
                    }
                    else
                    {
                        ModelObject entryObject = entry as ModelObject;
                        if (entryObject != null && entryObject.IsMetaScope())
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }

        protected virtual List<ModelObject> GetEntries<T>(ModelObject scope)
            where T : Attribute
        {
            List<ModelObject> result = new List<ModelObject>();
            if (scope == null) return result;
            foreach (var prop in scope.MGetAllProperties())
            {
                if (prop.Annotations.Any(a => a is T))
                {
                    object entry = scope.MGet(prop);
                    ModelCollection scopeEntries = entry as ModelCollection;
                    if (scopeEntries != null)
                    {
                        IEnumerable<object> scopeEntryList = scopeEntries as IEnumerable<object>;
                        foreach (var scopeEntry in scopeEntryList)
                        {
                            ModelObject scopeEntryObject = scopeEntry as ModelObject;
                            if (scopeEntryObject != null)
                            {
                                result.Add(scopeEntryObject);
                            }
                        }
                    }
                    else
                    {
                        ModelObject entryObject = entry as ModelObject;
                        if (entryObject != null)
                        {
                            result.Add(entryObject);
                        }
                    }
                }
            }
            return result;
        }

        protected virtual List<ModelObject> ResolveEntries(IEnumerable<ModelObject> entries, ResolveKind kind, string name, int position, List<Type> symbolTypes)
        {
            List<ModelObject> result = new List<ModelObject>();
            if (name == null) return result;
            foreach (var entry in entries)
            {
                ModelObject entryObject = entry as ModelObject;
                if (entryObject != null && name.Equals(this.GetName(entryObject)))
                {
                    if ((kind.HasFlag(ResolveKind.Type) && entryObject.IsMetaType())
                        || (kind.HasFlag(ResolveKind.Name) && !entryObject.IsMetaType()))
                    {
                        bool typeOK = false;
                        if (symbolTypes != null && symbolTypes.Count > 0)
                        {
                            foreach (var symbolType in symbolTypes)
                            {
                                if (symbolType.IsAssignableFrom(entryObject.GetType()))
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

    public class DefaultBindingProvider : IBindingProvider
    {
        // TODO
        protected virtual void SelectBestAlternative(List<ModelObject> alternativeList, MetaFunctionCallExpression call)
        {
            if (alternativeList.Count <= 1) return;
            IModelCompiler compiler = ModelCompilerContext.Current;
            for (int i = 0; i < alternativeList.Count; i++)
            {
                ModelObject alternative = alternativeList[i];
                MetaTypedElement mte = alternative as MetaTypedElement;
                if (mte != null && mte.Type is MetaFunctionType)
                {
                    MetaFunctionType ft = mte.Type as MetaFunctionType;
                    bool goodAlternative = false;
                    if (ft.ParameterTypes.Count == call.Arguments.Count)
                    {
                        goodAlternative = true;
                        for (int j = 0; j < call.Arguments.Count; j++)
                        {
                            MetaType paramType = ft.ParameterTypes[j];
                            MetaType argType = call.Arguments[j].Type;
                            if (!compiler.TypeProvider.IsAssignableFrom((ModelObject)paramType, (ModelObject)argType))
                            {
                                goodAlternative = false;
                            }
                        }
                    }
                    if (!goodAlternative && alternativeList.Count > 1)
                    {
                        alternativeList.RemoveAt(i);
                        --i;
                    }
                }
            }
            if (alternativeList.Count <= 1) return;
            for (int i = 0; i < alternativeList.Count; i++)
            {
                ModelObject alternative = alternativeList[i];
                MetaTypedElement mte = alternative as MetaTypedElement;
                if (mte != null && mte.Type is MetaFunctionType)
                {
                    MetaFunctionType ft = mte.Type as MetaFunctionType;
                    bool goodAlternative = false;
                    if (ft.ParameterTypes.Count == call.Arguments.Count)
                    {
                        goodAlternative = true;
                        for (int j = 0; j < call.Arguments.Count; j++)
                        {
                            MetaType paramType = ft.ParameterTypes[j];
                            MetaType argType = call.Arguments[j].Type;
                            if (!compiler.TypeProvider.Equals((ModelObject)paramType, (ModelObject)argType))
                            {
                                goodAlternative = false;
                            }
                        }
                    }
                    if (!goodAlternative && alternativeList.Count > 1)
                    {
                        alternativeList.RemoveAt(i);
                        --i;
                    }
                }
            }
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

        public virtual ModelObject Bind(ModelObject context, BindingInfo bindingInfo)
        {
            if (bindingInfo == null) return null;
            if (bindingInfo.ResolutionError) return null;
            IModelCompiler compiler = ModelCompilerContext.Current;
            List<ModelObject> alternativeList = bindingInfo.ResolvedObjects;
            MetaFunctionCallExpression fce = context as MetaFunctionCallExpression;
            if (fce != null)
            {
                for (int i = 0; i < alternativeList.Count; i++)
                {
                    bool goodAlternative = false;
                    ModelObject alternative = alternativeList[i];
                    MetaTypedElement mte = alternative as MetaTypedElement;
                    if (mte != null && mte.Type is MetaFunctionType)
                    {
                        goodAlternative = true;
                    }
                    if (!goodAlternative)
                    {
                        alternativeList.RemoveAt(i);
                        --i;
                    }
                }
                this.SelectBestAlternative(alternativeList, fce);
            }
            if (alternativeList.Count == 0)
            {
                if (compiler != null)
                {
                    compiler.Diagnostics.AddError("Cannot resolve " + this.GetKindName(bindingInfo.ResolutionInfo) + " '"+bindingInfo.Name+"'.", compiler.FileName, bindingInfo.Node ?? context);
                }
                return null;
            }
            else if (alternativeList.Count > 1)
            {
                if (compiler != null)
                {
                    compiler.Diagnostics.AddError("Ambiguous " + this.GetKindName(bindingInfo.ResolutionInfo) + " '" + bindingInfo.Name + "'.", compiler.FileName, bindingInfo.Node ?? context);
                }
                return null;
            }
            else
            {
                ModelObject symbol = alternativeList[0];
                if (fce != null)
                {
                    MetaTypedElement mte = symbol as MetaTypedElement;
                    if (mte != null && mte.Type is MetaFunctionType)
                    {
                        MetaFunctionType ft = mte.Type as MetaFunctionType;
                        if (ft.ParameterTypes.Count == fce.Arguments.Count)
                        {
                            for (int i = 0; i < fce.Arguments.Count; i++)
                            {
                                MetaType paramType = ft.ParameterTypes[i];
                                ((ModelObject)fce.Arguments[i]).MLazySet(MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => paramType));
                            }
                        }
                        else
                        {
                            compiler.Diagnostics.AddError("The number of formal and actual parameters are different.", compiler.FileName, context);
                        }
                    }
                }
                // TODO
                return symbol;
            }
        }
    }

    public class DefaultModelCompiler : IModelCompiler
    {
        public DefaultModelCompiler()
        {
            this.Diagnostics = new ModelCompilerDiagnostics();
            this.GlobalScope = new RootScope();
            this.Model = new Model();
            this.TriviaProvider = new DefaultTriviaProvider();
            this.NameProvider = new DefaultNameProvider();
            this.TypeProvider = new DefaultTypeProvider();
            this.ResolutionProvider = new DefaultResolutionProvider();
            this.BindingProvider = new DefaultBindingProvider();
        }

        public virtual ModelCompilerDiagnostics Diagnostics { get; protected set; }
        public virtual string FileName { get; protected set; }
        public virtual string Source { get; protected set; }
        public virtual RootScope GlobalScope { get; protected set; }
        public virtual Model Model { get; protected set; }
        public virtual ITriviaProvider TriviaProvider { get; protected set; }
        public virtual INameProvider NameProvider { get; protected set; }
        public virtual ITypeProvider TypeProvider { get; protected set; }
        public virtual IResolutionProvider ResolutionProvider { get; protected set; }
        public virtual IBindingProvider BindingProvider { get; protected set; }
    }
}
