using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class SymbolResolution
    {
        private readonly ConcurrentDictionary<Declaration, IMetaSymbol> _cache;
        private readonly CompilationBase _compilation;

        public SymbolResolution(CompilationBase compilation)
        {
            _cache = new ConcurrentDictionary<Declaration, IMetaSymbol>();
            _compilation = compilation;
        }

        private Compilation Compilation
        {
            get { return _compilation; }
        }


        public virtual string GetName(RedNode node)
        {
            string valueStr = node.ToString();
            return valueStr;
        }

        public virtual object GetValue(RedNode node)
        {
            string valueStr = node.ToString();
            return this.GetValue(valueStr);
        }

        public virtual object GetValue(string value)
        {
            if (value == "null") return null;
            if (value.Length >= 3 && value.StartsWith("@\'") && value.EndsWith("\'"))
            {
                return value.Substring(2, value.Length - 3).Replace("\'\'", "\'");
            }
            else if (value.Length >= 2 && value.StartsWith("\'") && value.EndsWith("\'"))
            {
                return Regex.Unescape(value.Substring(1, value.Length - 2));
            }
            else if (value.Length >= 3 && value.StartsWith("@\"") && value.EndsWith("\""))
            {
                return value.Substring(2, value.Length - 3).Replace("\"\"", "\"");
            }
            else if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\""))
            {
                return Regex.Unescape(value.Substring(1, value.Length - 2));
            }
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

        public virtual object GetEnumLiteral(RedNode node, Type enumType)
        {
            string enumLiteralName = this.GetName(node);
            long enumLiteral;
            if (Enum.TryParse(enumLiteralName, out enumLiteral))
            {
                return enumLiteral;
            }
            return null;
        }

        public virtual IMetaSymbol GetWellKnownSymbol(string name)
        {
            return null;
        }

        public IEnumerable<IMetaSymbol> GetSymbolByQualifiedName(IMetaSymbol container, string qualifiedName, char separator = '.')
        {
            if (qualifiedName == null) return null;
            return this.GetSymbolByQualifiedName(container, qualifiedName.Split(separator));
        }

        /// <summary>
        /// Finds symbols described by a qualified name.
        /// </summary>
        /// <param name="qualifiedName">Sequence of simple plain names.</param>
        /// <returns>
        /// A set of symbols with given qualified name (might comprise of types with multiple generic arities), 
        /// or an empty set if the member can't be found (the qualified name is ambiguous or the symbol doesn't exist).
        /// </returns>
        /// <remarks>
        /// "C.D" matches C.D, C{T}.D, C{S,T}.D{U}, etc.
        /// </remarks>
        public virtual IEnumerable<IMetaSymbol> GetSymbolByQualifiedName(IMetaSymbol container, IEnumerable<string> qualifiedName)
        {
            if (qualifiedName == null) return null;
            IMetaSymbol namespaceOrType = container ?? _compilation.GlobalNamespace;
            IEnumerable<IMetaSymbol> symbols = null;
            foreach (string name in qualifiedName)
            {
                if (symbols != null)
                {
                    // there might be multiple types of different arity, prefer a non-generic type:
                    namespaceOrType = this.SelectSingleSymbolForName(symbols);
                    if ((object)namespaceOrType == null)
                    {
                        return EmptyCollections.Enumerable<IMetaSymbol>();
                    }
                }

                symbols = namespaceOrType.MChildren.Where(c => c.MName == name);
            }
            return symbols;

        }

        protected virtual IMetaSymbol SelectSingleSymbolForName(IEnumerable<IMetaSymbol> symbols)
        {
            return symbols.FirstOrDefault();
        }

        public IMetaSymbol GetSymbol(IMetaSymbol container, MergedDeclaration declaration)
        {
            if (container == null)
            {
                return _compilation.GlobalNamespace;
            }

            AddCache(container.MChildren.Where(child => child.MName == declaration.Name));

            return GetCachedSymbol(declaration);
        }

        public IEnumerable<IMetaSymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter, CancellationToken cancellationToken)
        {
            var result = new HashSet<IMetaSymbol>();
            var spine = new List<MergedDeclaration>();

            AppendSymbolsWithName(spine, _compilation.Declarations.MergedRoot, predicate, filter, result, cancellationToken);

            return result;
        }

        private void AppendSymbolsWithName(
            List<MergedDeclaration> spine, MergedDeclaration current,
            Func<string, bool> predicate, SymbolFilter filter, HashSet<IMetaSymbol> set, CancellationToken cancellationToken)
        {
            var includeNamespace = (filter & SymbolFilter.Namespace) == SymbolFilter.Namespace;
            var includeType = (filter & SymbolFilter.Type) == SymbolFilter.Type;
            var includeMember = (filter & SymbolFilter.Member) == SymbolFilter.Member;

            if (current.IsNamespace)
            {
                if (includeNamespace && predicate(current.Name))
                {
                    var container = GetSpineSymbol(spine);
                    var symbol = GetSymbol(container, current);
                    if (symbol != null)
                    {
                        set.Add(symbol);
                    }
                }
            }
            else
            {
                if (includeType && predicate(current.Name))
                {
                    var container = GetSpineSymbol(spine);
                    var symbol = GetSymbol(container, current);
                    if (symbol != null)
                    {
                        set.Add(symbol);
                    }
                }

                if (includeMember)
                {
                    AppendMemberSymbolsWithName(spine, current, predicate, set, cancellationToken);
                }
            }

            spine.Add(current);

            foreach (var child in current.Children.OfType<MergedDeclaration>())
            {
                if (includeMember || includeType)
                {
                    AppendSymbolsWithName(spine, child, predicate, filter, set, cancellationToken);
                    continue;
                }

                if (child.IsNamespace)
                {
                    AppendSymbolsWithName(spine, child, predicate, filter, set, cancellationToken);
                }
            }

            // pop last one
            spine.RemoveAt(spine.Count - 1);
        }

        private void AppendMemberSymbolsWithName(
            List<MergedDeclaration> spine, MergedDeclaration current,
            Func<string, bool> predicate, HashSet<IMetaSymbol> set, CancellationToken cancellationToken)
        {
            spine.Add(current);

            var container = GetSpineSymbol(spine);
            if (container != null)
            {
                foreach (var member in container.MChildren)
                {
                    if (member.MName != null && predicate(member.MName))
                    {
                        set.Add(member);
                    }
                }
            }

            spine.RemoveAt(spine.Count - 1);
        }

        private IMetaSymbol GetSpineSymbol(List<MergedDeclaration> spine)
        {
            if (spine.Count == 0)
            {
                return null;
            }

            var symbol = GetCachedSymbol(spine[spine.Count - 1]);
            if (symbol != null)
            {
                return symbol;
            }

            var current = _compilation.GlobalNamespace as IMetaSymbol;
            for (var i = 1; i < spine.Count; i++)
            {
                current = GetSymbol(current, spine[i]);
            }

            return current;
        }

        private IMetaSymbol GetCachedSymbol(MergedDeclaration declaration)
        {
            IMetaSymbol symbol;
            if (_cache.TryGetValue(declaration, out symbol))
            {
                return symbol;
            }

            return null;
        }

        private void AddCache(IEnumerable<IMetaSymbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                var mergedNamespace = (Declaration)symbol.MGet(CompilerAttachedProperties.MergedDeclarationProperty);
                if (mergedNamespace != null)
                {
                    _cache[mergedNamespace] = symbol;
                    continue;
                }
            }
        }

        public virtual IMetaSymbol GetNestedSymbol(IMetaSymbol symbol)
        {
            if (symbol == null) return null;
            foreach (var nested in symbol.MChildren)
            {
                if (nested.MName == symbol.MName) return nested;
            }
            return null;
        }
    }
}
