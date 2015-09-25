﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    [Flags]
    public enum ResolveFlags
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
        public ResolutionInfo()
        {
            this.Position = -1;
        }

        public object Node { get; set; }
        public int Position { get; set; }
        public IEnumerable<Type> SymbolTypes { get; set; }
    }

    public class BindingInfo
    {
        public object Node { get; set; }
    }

    public interface INameProvider
    {
        string GetName(object node);
        string GetNameOf(ModelObject symbol);
        object GetValue(object node);
        IEnumerable<TextSpan> GetSymbolTextSpans(ModelObject node);
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
        ModelObject GetParentScope(ModelObject obj);
        ModelObject GetCurrentScope(ModelObject obj);
        ModelObject GetCurrentTypeScopeOf(ModelObject obj);
        IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, List<string> qualifiedName, ResolutionInfo info, ResolveFlags flags);
        IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, string name, ResolutionInfo info, ResolveFlags flags);
    }

    public interface IBindingProvider
    {
        ModelObject Bind(ModelObject context, IEnumerable<ModelObject> alternatives, BindingInfo info);
    }

    public interface IModelCompiler
    {
        ModelCompilerDiagnostics Diagnostics { get; }
        string FileName { get; }
        string Source { get; }
        RootScope GlobalScope { get; }
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
        public string FileName { get; set; }
        public TextSpan TextSpan { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public bool IsLog { get; set; }

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

        public ModelCompilerDiagnostics()
        {
            this.messages = new List<DiagnosticMessage>();
        }

        public void AddMessage(Severity severity, string message, string fileName, ModelObject symbol, bool isLog = false)
        {
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                foreach (var textSpan in ctx.Compiler.NameProvider.GetSymbolTextSpans(symbol))
                {
                    this.AddMessage(severity, message, fileName, textSpan, isLog);
                }
            }
            else
            {
                this.AddMessage(severity, message, fileName, new TextSpan(), isLog);
            }
        }

        public void AddMessage(Severity severity, string message, string fileName, object node, bool isLog = false)
        {
            TextSpan textSpan = null;
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                textSpan = ctx.Compiler.NameProvider.GetTreeNodeTextSpan(node);
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

    public class DefaultNameProvider : INameProvider
    {
        public virtual string GetName(object node)
        {
            if (node == null) return null;
            return node.ToString();
        }

        public virtual object GetValue(object node)
        {
            if (node == null) return null;
            return node.ToString();
        }

        public string GetNameOf(ModelObject symbol)
        {
            if (symbol == null) return null;
            foreach (var prop in symbol.MGetAllProperties())
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
                foreach (var symbolTreeNode in symbolTreeNodeList)
                {
                    result.Add(this.GetTreeNodeTextSpan(symbolTreeNode));
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
                ModelContext ctx = ModelContext.Current;
                if (ctx != null)
                {
                    if (expr.ExpectedType == MetaInstance.None)
                    {
                        return true;
                    }
                    else  if (expr.ExpectedType == null)
                    {
                        ctx.Compiler.Diagnostics.AddError("The expression has no expected type.", ctx.Compiler.FileName, symbol);
                    }
                    else if (expr.Type == null)
                    {
                        ctx.Compiler.Diagnostics.AddError("The expression has no type.", ctx.Compiler.FileName, symbol);
                    }
                    else
                    {
                        ctx.Compiler.Diagnostics.AddError("'" + expr.ExpectedType + "' type expected, but expression has type '" + expr.Type + "'.", ctx.Compiler.FileName, symbol);
                    }
                }
            }
            return result;
        }
    }

    public class DefaultResolutionProvider : IResolutionProvider
    {
        public virtual ModelObject GetParentScope(ModelObject obj)
        {
            ModelContext ctx = ModelContext.Current;
            ModelObject result = null;
            if (ctx != null)
            {
                result = ModelContext.Current.Compiler.GlobalScope;
            }
            if (obj != null)
            {
                obj = obj.MParent;
            }
            while(obj != null && !obj.IsMetaScope())
            {
                obj = obj.MParent;
            }
            if (obj != null)
            {
                result = obj;
            }
            return result;
        }

        public virtual ModelObject GetCurrentScope(ModelObject obj)
        {
            ModelContext ctx = ModelContext.Current;
            ModelObject result = null;
            if (ctx != null)
            {
                result = ModelContext.Current.Compiler.GlobalScope;
            }
            while (obj != null && !obj.IsMetaScope())
            {
                obj = obj.MParent;
            }
            if (obj != null)
            {
                result = obj;
            }
            return result;
        }

        public virtual ModelObject GetCurrentTypeScopeOf(ModelObject obj)
        {
            ModelContext ctx = ModelContext.Current;
            ModelObject result = null;
            if (ctx != null)
            {
                result = ModelContext.Current.Compiler.GlobalScope;
            }
            while (obj != null && !obj.IsMetaScope() && !obj.IsMetaType())
            {
                obj = obj.MParent;
            }
            if (obj != null)
            {
                result = obj;
            }
            return result;
        }

        public virtual IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, List<string> qualifiedName, ResolutionInfo info, ResolveFlags flags)
        {
            if (qualifiedName.Count == 0)
            {
                return new ModelObject[0];
            }
            if (qualifiedName.Count == 1)
            {
                return this.Resolve(scopes, kind, qualifiedName[0], info, flags);
            }
            List<ModelObject> result = new List<ModelObject>();
            ResolutionInfo firstInfo =
                new ResolutionInfo()
                {
                    Node = info.Node,
                    Position = info.Position,
                    SymbolTypes = null
                };
            ResolutionInfo middleInfo =
                new ResolutionInfo()
                {
                    Node = info.Node,
                    Position = -1,
                    SymbolTypes = null
                };
            ResolutionInfo lastInfo =
                new ResolutionInfo()
                {
                    Node = info.Node,
                    Position = -1,
                    SymbolTypes = info.SymbolTypes
                };
            IEnumerable<ModelObject> currentResult = scopes;
            for (int i = 0; i < qualifiedName.Count; i++)
            {
                string name = qualifiedName[i];
                bool first = i == 0;
                bool last = i == qualifiedName.Count - 1;
                currentResult = this.Resolve(currentResult, last ? kind : ResolveKind.NameOrType, name, last ? lastInfo : (first ? firstInfo : middleInfo), first ? flags : ResolveFlags.Scope);
            }
            result.AddRange(currentResult);
            return result;
        }

        public virtual IEnumerable<ModelObject> Resolve(IEnumerable<ModelObject> scopes, ResolveKind kind, string name, ResolutionInfo info, ResolveFlags flags)
        {
            List<ModelObject> result = new List<ModelObject>();
            foreach (var scope in scopes)
            {
                if (flags.HasFlag(ResolveFlags.Children))
                {
                    result.AddRange(this.ResolveEntries(this.GetEntries<ScopeEntryAttribute>(scope), kind, name, info));
                }
                if (flags.HasFlag(ResolveFlags.Inherited))
                {
                    result.AddRange(this.Resolve(this.GetScopes<InheritedScopeAttribute>(scope), kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }, ResolveFlags.Scope));
                }
                if (flags.HasFlag(ResolveFlags.Imported))
                {
                    result.AddRange(this.Resolve(this.GetScopes<ImportedScopeAttribute>(scope), kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }, ResolveFlags.Scope));
                }
                if (flags.HasFlag(ResolveFlags.ImportedScope))
                {
                    result.AddRange(this.ResolveEntries(this.GetEntries<ImportedEntryAttribute>(scope), kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }));
                }
            }
            if (flags.HasFlag(ResolveFlags.Parent) && result.Count == 0)
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
                    result.AddRange(this.Resolve(parentScopes, kind, name, new ResolutionInfo() { Node = info.Node, SymbolTypes = info.SymbolTypes }, flags));
                }
            }
            return result;
        }

        protected virtual object GetName(ModelObject entry)
        {
            if (entry != null)
            {
                foreach (var prop in entry.MGetAllProperties())
                {
                    if (prop.Annotations.Any(a => a is NameAttribute))
                    {
                        return entry.MGet(prop);
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

        protected virtual IEnumerable<ModelObject> GetScopes<T>(ModelObject scope)
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

        protected virtual IEnumerable<ModelObject> GetEntries<T>(ModelObject scope)
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

        protected virtual IEnumerable<ModelObject> ResolveEntries(IEnumerable<ModelObject> entries, ResolveKind kind, string name, ResolutionInfo info)
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
                        result.Add(entryObject);
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
            ModelContext ctx = ModelContext.Current;
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
                            if (!ctx.Compiler.TypeProvider.IsAssignableFrom((ModelObject)paramType, (ModelObject)argType))
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
                            if (!ctx.Compiler.TypeProvider.Equals((ModelObject)paramType, (ModelObject)argType))
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

        public virtual ModelObject Bind(ModelObject context, IEnumerable<ModelObject> alternatives, BindingInfo info)
        {
            ModelContext ctx = ModelContext.Current;
            List<ModelObject> alternativeList = alternatives.ToList();
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
                if (ctx != null)
                {
                    if (info.Node != null)
                    {
                        ctx.Compiler.Diagnostics.AddError("Cannot resolve name or type.", ctx.Compiler.FileName, info.Node);
                    }
                    else
                    {
                        ctx.Compiler.Diagnostics.AddError("Cannot resolve name or type.", ctx.Compiler.FileName, context);
                    }
                }
                return null;
            }
            else if (alternativeList.Count > 1)
            {
                bool mustHaveUniqueDefinition = true;
                if (context != null)
                {
                    object mustHaveUniqueDefinitionObject = context.MGet(MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
                    if (mustHaveUniqueDefinitionObject != null)
                    {
                        mustHaveUniqueDefinition = (bool)mustHaveUniqueDefinitionObject;
                    }
                }
                if (mustHaveUniqueDefinition)
                {
                    if (ctx != null)
                    {
                        if (info.Node != null)
                        {
                            ctx.Compiler.Diagnostics.AddError("Ambiguous name or type.", ctx.Compiler.FileName, info.Node);
                        }
                        else
                        {
                            ctx.Compiler.Diagnostics.AddError("Ambiguous name or type.", ctx.Compiler.FileName, context);
                        }
                    }
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
                            ctx.Compiler.Diagnostics.AddError("The number of formal and actual parameters are different.", ctx.Compiler.FileName, context);
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
            this.NameProvider = new DefaultNameProvider();
            this.TypeProvider = new DefaultTypeProvider();
            this.ResolutionProvider = new DefaultResolutionProvider();
            this.BindingProvider = new DefaultBindingProvider();
        }

        public virtual ModelCompilerDiagnostics Diagnostics { get; protected set; }
        public virtual string FileName { get; protected set; }
        public virtual string Source { get; protected set; }
        public virtual RootScope GlobalScope { get; protected set; }
        public virtual INameProvider NameProvider { get; protected set; }
        public virtual ITypeProvider TypeProvider { get; protected set; }
        public virtual IResolutionProvider ResolutionProvider { get; protected set; }
        public virtual IBindingProvider BindingProvider { get; protected set; }
    }
}