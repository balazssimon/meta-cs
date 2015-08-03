using System;
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
        object GetValue(object node);
        TextSpan GetTextSpan(object node);
    }

    public interface IResolutionProvider
    {
        ModelObject GetParentScope(ModelObject obj);
        ModelObject GetCurrentScope(ModelObject obj);
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

    public class DiagnosticMessage : IComparable<DiagnosticMessage>
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
            return cmp;
        }

        public override string ToString()
        {
            return string.Format("{0} in '{1}' ({2},{3}): {4}", this.Severity, this.FileName, this.TextSpan.StartLine, this.TextSpan.StartPosition, this.Message);
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
            return string.Format("({0},{1})", this.StartLine, this.StartPosition);
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

        public void AddMessage(Severity severity, string message, string fileName, object node, bool isLog = false)
        {
            if (severity == Severity.Error)
            {
                this.hasErrors = true;
            }
            if (severity == Severity.Warning)
            {
                this.hasWarnings = true;
            }
            TextSpan textSpan = null;
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                textSpan = ctx.Compiler.NameProvider.GetTextSpan(node);
            }
            else
            {
                textSpan = new TextSpan();
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

        public virtual TextSpan GetTextSpan(object node)
        {
            return new TextSpan();
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
        public virtual ModelObject Bind(ModelObject context, IEnumerable<ModelObject> alternatives, BindingInfo info)
        {
            ModelContext ctx = ModelContext.Current;
            List<ModelObject> alternativeList = alternatives.ToList();
            if (alternativeList.Count == 0)
            {
                if (ctx != null)
                {
                    ctx.Compiler.Diagnostics.AddError("Cannot resolve name or type.", ctx.Compiler.FileName, info.Node);
                }
                return null;
            }
            else if (alternativeList.Count > 1)
            {
                if (ctx != null)
                {
                    ctx.Compiler.Diagnostics.AddError("Ambiguous name or type.", ctx.Compiler.FileName, info.Node);
                }
                return null;
            }
            else
            {
                ModelObject symbol = alternativeList[0];
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
            this.ResolutionProvider = new DefaultResolutionProvider();
            this.BindingProvider = new DefaultBindingProvider();
        }

        public virtual ModelCompilerDiagnostics Diagnostics { get; protected set; }
        public virtual string FileName { get; protected set; }
        public virtual string Source { get; protected set; }
        public virtual RootScope GlobalScope { get; protected set; }
        public virtual INameProvider NameProvider { get; protected set; }
        public virtual IResolutionProvider ResolutionProvider { get; protected set; }
        public virtual IBindingProvider BindingProvider { get; protected set; }
    }
}
