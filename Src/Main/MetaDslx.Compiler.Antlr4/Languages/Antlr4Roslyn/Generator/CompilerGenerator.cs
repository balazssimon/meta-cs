using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler; //4:1
using MetaDslx.Compiler.MetaModel; //5:1
using MetaDslx.Languages.Antlr4Roslyn.Compilation; //6:1

namespace MetaDslx.Languages.Antlr4Roslyn.Generator //1:1
{
    using __Hidden_CompilerGenerator_985094061;
    namespace __Hidden_CompilerGenerator_985094061
    {
        internal static class __Extensions
        {
            internal static IEnumerator<T> GetEnumerator<T>(this T item)
            {
                if (item == null) return new List<T>().GetEnumerator();
                else return new List<T> { item }.GetEnumerator();
            }
        }
    }


    public class CompilerGenerator //2:1
    {
        private Antlr4Grammar Instances; //2:1

        public CompilerGenerator() //2:1
        {
            this.Properties = new __Properties();
        }

        public CompilerGenerator(Antlr4Grammar instances) : this() //2:1
        {
            this.Instances = instances;
        }

        private Stream __ToStream(string text)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)
        {
            while (items.MoveNext())
            {
                yield return items.Current;
            }
        }

        private int counter = 0;
        private int NextCounter()
        {
            return ++counter;
        }

        public __Properties Properties { get; private set; } //8:1

        public class __Properties //8:1
        {
            internal __Properties()
            {
            }
            public string DefaultNamespace { get; set; } //9:2
            public string LanguageName { get; set; } //10:2
        }

        public string GenerateLanguage() //13:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //25:1
            __out.AppendLine(true); //31:1
            __out.AppendLine(true); //33:1
            __out.AppendLine(true); //37:1
            __out.AppendLine(true); //42:1
            __out.AppendLine(true); //47:1
            __out.AppendLine(true); //52:1
            __out.AppendLine(true); //57:1
            __out.AppendLine(true); //62:1
            __out.AppendLine(true); //67:1
            __out.AppendLine(true); //72:1
            __out.AppendLine(true); //77:1
            return __out.ToString();
        }

        public string GenerateParseOptions() //86:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //99:1
            __out.AppendLine(true); //111:1
            __out.AppendLine(true); //113:1
            __out.AppendLine(true); //118:1
            __out.AppendLine(true); //136:1
            __out.AppendLine(true); //150:1
            __out.AppendLine(true); //157:1
            __out.AppendLine(true); //164:1
            __out.AppendLine(true); //169:1
            __out.AppendLine(true); //172:1
            __out.AppendLine(true); //179:1
            __out.AppendLine(true); //184:1
            __out.AppendLine(true); //187:1
            __out.AppendLine(true); //194:1
            __out.AppendLine(true); //199:1
            __out.AppendLine(true); //202:1
            __out.AppendLine(true); //207:1
            __out.AppendLine(true); //212:1
            __out.AppendLine(true); //217:1
            __out.AppendLine(true); //227:1
            __out.AppendLine(true); //255:1
            __out.AppendLine(true); //270:1
            return __out.ToString();
        }

        public string GenerateFeature() //281:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //290:1
            __out.AppendLine(true); //297:1
            __out.AppendLine(true); //308:1
            __out.AppendLine(true); //321:1
            return __out.ToString();
        }

        public string GenerateLanguageVersion() //325:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //330:1
            __out.AppendLine(true); //343:1
            __out.AppendLine(true); //350:1
            __out.AppendLine(true); //355:1
            return __out.ToString();
        }

        public string GenerateCompilation() //371:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //391:1
            __out.AppendLine(true); //412:1
            __out.AppendLine(true); //417:1
            __out.AppendLine(true); //422:1
            __out.AppendLine(true); //427:1
            __out.AppendLine(true); //432:1
            __out.AppendLine(true); //437:1
            __out.AppendLine(true); //442:1
            __out.AppendLine(true); //447:1
            __out.AppendLine(true); //452:1
            __out.AppendLine(true); //470:1
            __out.AppendLine(true); //488:1
            __out.AppendLine(true); //493:1
            __out.AppendLine(true); //496:1
            __out.AppendLine(true); //522:1
            __out.AppendLine(true); //536:1
            __out.AppendLine(true); //547:1
            __out.AppendLine(true); //560:1
            __out.AppendLine(true); //562:1
            __out.AppendLine(true); //578:1
            __out.AppendLine(true); //583:1
            __out.AppendLine(true); //586:1
            __out.AppendLine(true); //591:1
            __out.AppendLine(true); //596:1
            __out.AppendLine(true); //601:1
            __out.AppendLine(true); //606:1
            __out.AppendLine(true); //611:1
            __out.AppendLine(true); //616:1
            __out.AppendLine(true); //621:1
            __out.AppendLine(true); //626:1
            __out.AppendLine(true); //631:1
            __out.AppendLine(true); //636:1
            __out.AppendLine(true); //641:1
            __out.AppendLine(true); //646:1
            __out.AppendLine(true); //651:1
            __out.AppendLine(true); //656:1
            __out.AppendLine(true); //677:1
            __out.AppendLine(true); //682:1
            __out.AppendLine(true); //701:1
            __out.AppendLine(true); //706:1
            __out.AppendLine(true); //716:1
            __out.AppendLine(true); //735:1
            __out.AppendLine(true); //740:1
            __out.AppendLine(true); //756:1
            __out.AppendLine(true); //769:1
            __out.AppendLine(true); //774:1
            __out.AppendLine(true); //784:1
            __out.AppendLine(true); //786:1
            __out.AppendLine(true); //799:1
            __out.AppendLine(true); //804:1
            __out.AppendLine(true); //808:1
            __out.AppendLine(true); //817:1
            __out.AppendLine(true); //820:1
            __out.AppendLine(true); //824:1
            __out.AppendLine(true); //831:1
            __out.AppendLine(true); //837:1
            __out.AppendLine(true); //840:1
            __out.AppendLine(true); //845:1
            return __out.ToString();
        }

        public string GenerateCompilationFactory() //854:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //871:1
            __out.AppendLine(true); //877:1
            __out.AppendLine(true); //881:1
            __out.AppendLine(true); //886:1
            __out.AppendLine(true); //891:1
            __out.AppendLine(true); //896:1
            return __out.ToString();
        }

        public string GenerateCompilationOptions() //905:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //919:1
            __out.AppendLine(true); //945:1
            __out.AppendLine(true); //970:1
            __out.AppendLine(true); //984:1
            __out.AppendLine(true); //993:1
            __out.AppendLine(true); //1002:1
            __out.AppendLine(true); //1011:1
            __out.AppendLine(true); //1020:1
            __out.AppendLine(true); //1029:1
            __out.AppendLine(true); //1038:1
            __out.AppendLine(true); //1043:1
            __out.AppendLine(true); //1050:1
            __out.AppendLine(true); //1055:1
            __out.AppendLine(true); //1058:1
            __out.AppendLine(true); //1063:1
            __out.AppendLine(true); //1068:1
            __out.AppendLine(true); //1073:1
            __out.AppendLine(true); //1078:1
            __out.AppendLine(true); //1083:1
            __out.AppendLine(true); //1088:1
            __out.AppendLine(true); //1093:1
            __out.AppendLine(true); //1098:1
            __out.AppendLine(true); //1103:1
            __out.AppendLine(true); //1108:1
            __out.AppendLine(true); //1112:1
            __out.AppendLine(true); //1119:1
            __out.AppendLine(true); //1124:1
            __out.AppendLine(true); //1127:1
            __out.AppendLine(true); //1132:1
            return __out.ToString();
        }

        public string GenerateScriptCompilationInfo() //1141:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1152:1
            __out.AppendLine(true); //1158:1
            __out.AppendLine(true); //1163:1
            __out.AppendLine(true); //1166:1
            __out.AppendLine(true); //1168:1
            __out.AppendLine(true); //1171:1
            return __out.ToString();
        }

        public string GenerateErrorCode() //1179:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1188:1
            return __out.ToString();
        }

        public string GenerateSyntaxParser() //1198:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateAntlr4ToRoslynVisitorRule(Antlr4ParserRule rule, Antlr4ParserRule superRule) //1296:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1302:1
            return __out.ToString();
        }

        public string GenerateSyntaxTree() //1401:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateInternalSyntax() //1817:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1835:1
            __out.AppendLine(true); //1844:1
            __out.AppendLine(true); //1849:1
            __out.AppendLine(true); //1855:1
            __out.AppendLine(true); //1862:1
            __out.AppendLine(true); //1867:1
            __out.AppendLine(true); //1872:1
            __out.AppendLine(true); //1877:1
            __out.AppendLine(true); //1882:1
            __out.AppendLine(true); //1888:1
            __out.AppendLine(true); //1893:1
            return __out.ToString();
        }

        public string GetCompilationUnitInternal(Antlr4ParserRule rule) //1899:1
        {
            return ""; //1903:3
        }

        public string GetCompilationUnit(Antlr4ParserRule rule) //1907:1
        {
            if (rule.HasEof()) //1908:2
            {
                return ", ICompilationUnitSyntax"; //1909:3
            }
            else //1910:2
            {
                return ""; //1911:3
            }
        }

        public string GetInternalElemTypedParamList(Antlr4ParserRule rule, TypeKind kind, bool leadingComma = false, bool trailingComma = false) //1915:1
        {
            string result = ""; //1916:2
            if (rule.AllElements.Count == 0) //1917:2
            {
                return result; //1918:3
            }
            if (leadingComma) //1920:2
            {
                result = ", "; //1921:3
            }
            var __loop7_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //1923:7
                select new { elem = elem}
                ).ToList(); //1923:2
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                string delim; //1923:28
                if (__loop7_iteration+1 < __loop7_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop7_results[__loop7_iteration];
                var elem = __tmp1.elem;
                result += elem.GreenType(kind) + " " + elem.FieldName() + delim; //1924:3
            }
            if (trailingComma) //1926:2
            {
                result += ", "; //1927:3
            }
            return result; //1929:2
        }

        public string GetRoslynVisitorElemParamList(Antlr4ParserRule rule, bool leadingComma = false, bool trailingComma = false) //1932:1
        {
            string result = ""; //1933:2
            if (rule.AllElements.Count == 0) //1934:2
            {
                return result; //1935:3
            }
            if (leadingComma) //1937:2
            {
                result = ", "; //1938:3
            }
            var __loop8_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //1940:7
                select new { elem = elem}
                ).ToList(); //1940:2
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                string delim; //1940:28
                if (__loop8_iteration+1 < __loop8_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop8_results[__loop8_iteration];
                var elem = __tmp1.elem;
                result += elem.FieldName(); //1941:3
                if (elem.IsList && elem.IsSeparated && elem.IsSimplified) //1942:3
                {
                    result += "?." + elem.Grammar.FindParserRule(elem.OriginalType).Elements[0].GreenName(); //1943:4
                }
                result += delim; //1945:3
            }
            if (trailingComma) //1947:2
            {
                result += ", "; //1948:3
            }
            return result; //1950:2
        }

        public string GetElemTypedParamList(Antlr4ParserRule rule, bool leadingComma = false, bool trailingComma = false, bool optional = false) //1953:1
        {
            string result = ""; //1954:2
            if (rule.AllElements.Count == 0) //1955:2
            {
                return result; //1956:3
            }
            if (leadingComma) //1958:2
            {
                result = ", "; //1959:3
            }
            var __loop9_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //1961:7
                where !optional || !(elem.IsOptional || (elem.IsToken && elem.IsFixedToken && !elem.IsList)) //1961:29
                select new { elem = elem}
                ).ToList(); //1961:2
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                string delim; //1961:121
                if (__loop9_iteration+1 < __loop9_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop9_results[__loop9_iteration];
                var elem = __tmp1.elem;
                result += elem.RedType() + " " + elem.FieldName() + delim; //1962:3
            }
            if (trailingComma) //1964:2
            {
                result += ", "; //1965:3
            }
            return result; //1967:2
        }

        public string GetInternalElemParamList(Antlr4ParserRule rule, bool listAsNode = false, bool leadingComma = false, bool trailingComma = false, string prefix = "this.", Antlr4ParserRuleElement skip = null) //1970:1
        {
            string result = ""; //1971:2
            if (rule.AllElements.Count == 0) //1972:2
            {
                return result; //1973:3
            }
            if (leadingComma) //1975:2
            {
                result = ", "; //1976:3
            }
            var __loop10_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //1978:7
                select new { elem = elem}
                ).ToList(); //1978:2
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                string delim; //1978:28
                if (__loop10_iteration+1 < __loop10_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop10_results[__loop10_iteration];
                var elem = __tmp1.elem;
                string fieldName = elem.FieldName(); //1979:3
                if (elem.IsList && listAsNode) //1980:3
                {
                    fieldName = fieldName; //1981:4
                }
                if (elem == skip) //1983:3
                {
                    result += fieldName + delim; //1984:4
                }
                else //1985:3
                {
                    result += prefix + fieldName + delim; //1986:4
                }
            }
            if (trailingComma) //1989:2
            {
                result += ", "; //1990:3
            }
            return result; //1992:2
        }

        public string GetElemNullParamList(Antlr4ParserRule rule, bool leadingComma = false, bool trailingComma = false) //1995:1
        {
            string result = ""; //1996:2
            if (rule.AllElements.Count == 0) //1997:2
            {
                return result; //1998:3
            }
            if (leadingComma) //2000:2
            {
                result = ", "; //2001:3
            }
            var __loop11_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //2003:7
                select new { elem = elem}
                ).ToList(); //2003:2
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                string delim; //2003:28
                if (__loop11_iteration+1 < __loop11_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop11_results[__loop11_iteration];
                var elem = __tmp1.elem;
                result += "null" + delim; //2004:3
            }
            if (trailingComma) //2006:2
            {
                result += ", "; //2007:3
            }
            return result; //2009:2
        }

        public string GetElemParamList(Antlr4ParserRule rule, bool leadingComma = false, bool trailingComma = false, string prefix = "this.", Antlr4ParserRuleElement skip = null) //2012:1
        {
            string result = ""; //2013:2
            if (rule.AllElements.Count == 0) //2014:2
            {
                return result; //2015:3
            }
            if (leadingComma) //2017:2
            {
                result = ", "; //2018:3
            }
            var __loop12_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //2020:7
                select new { elem = elem}
                ).ToList(); //2020:2
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                string delim; //2020:28
                if (__loop12_iteration+1 < __loop12_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop12_results[__loop12_iteration];
                var elem = __tmp1.elem;
                if (elem == skip) //2021:3
                {
                    result += elem.RedName() + delim; //2022:4
                }
                else //2023:3
                {
                    result += prefix + elem.RedName() + delim; //2024:4
                }
            }
            if (trailingComma) //2027:2
            {
                result += ", "; //2028:3
            }
            return result; //2030:2
        }

        public string GetGreenConstructorSimpleAltParamList(Antlr4ParserRule rule, bool leadingComma = false, bool trailingComma = false, Antlr4ParserRuleElement include = null) //2033:1
        {
            string result = ""; //2034:2
            if (rule.AllElements.Count == 0) //2035:2
            {
                return result; //2036:3
            }
            if (leadingComma) //2038:2
            {
                result = ", "; //2039:3
            }
            var __loop13_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //2041:7
                select new { elem = elem}
                ).ToList(); //2041:2
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                string delim; //2041:28
                if (__loop13_iteration+1 < __loop13_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop13_results[__loop13_iteration];
                var elem = __tmp1.elem;
                if (elem == include) //2042:3
                {
                    result += elem.FieldName(); //2043:4
                    if (elem.IsList) //2044:4
                    {
                    }
                }
                else //2047:3
                {
                    result += "null"; //2048:4
                }
                result += delim; //2050:3
            }
            if (trailingComma) //2052:2
            {
                result += ", "; //2053:3
            }
            return result; //2055:2
        }

        public string GetRedToGreenParamElem(Antlr4ParserRuleElement elem, string delim = "") //2058:1
        {
            string result = ""; //2059:2
            if (elem.IsOptional) //2060:2
            {
                result += elem.FieldName() + " == null ? null : "; //2061:3
            }
            if (elem.IsList) //2063:2
            {
                if (elem.IsToken) //2064:3
                {
                    result += elem.FieldName() + ".Green" + delim; //2065:4
                }
                else //2066:3
                {
                    if (elem.IsSeparated) //2067:4
                    {
                        result += elem.FieldName() + ".Green" + delim; //2068:5
                    }
                    else //2069:4
                    {
                        result += elem.FieldName() + ".Green" + delim; //2070:5
                    }
                }
            }
            else //2073:2
            {
                if (elem.IsToken || (elem.IsBlock && elem.IsFixedTokenAltBlock)) //2074:3
                {
                    result += "(InternalSyntaxToken)" + elem.FieldName() + ".Green" + delim; //2075:4
                }
                else //2076:3
                {
                    result += "(Syntax.InternalSyntax." + elem.GreenType(TypeKind.Public) + ")" + elem.FieldName() + ".Green" + delim; //2077:4
                }
            }
            return result; //2080:2
        }

        public string GetRedToGreenParamList(Antlr4ParserRule rule, bool leadingComma = false, bool trailingComma = false, bool optional = false) //2083:1
        {
            string result = ""; //2084:2
            if (rule.AllElements.Count == 0) //2085:2
            {
                return result; //2086:3
            }
            if (leadingComma) //2088:2
            {
                result = ", "; //2089:3
            }
            var __loop14_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //2091:7
                select new { elem = elem}
                ).ToList(); //2091:2
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                string delim; //2091:28
                if (__loop14_iteration+1 < __loop14_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop14_results[__loop14_iteration];
                var elem = __tmp1.elem;
                if (optional && (elem.IsOptional || (elem.IsToken && elem.IsFixedToken && !elem.IsList))) //2092:3
                {
                    if (elem.IsToken && elem.IsFixedToken && !elem.IsOptional) //2093:4
                    {
                        result += "this.Token(" + Properties.LanguageName + "SyntaxKind." + elem.SyntaxKind() + ")" + delim; //2094:5
                    }
                    else //2095:4
                    {
                        result += "null" + delim; //2096:5
                    }
                }
                else //2098:3
                {
                    if (optional) //2099:4
                    {
                        result += elem.FieldName() + delim; //2100:5
                    }
                    else //2101:4
                    {
                        result += GetRedToGreenParamElem(elem, delim); //2102:5
                    }
                }
            }
            if (trailingComma) //2106:2
            {
                result += ", "; //2107:3
            }
            return result; //2109:2
        }

        public string GetInternalElemUpdateList(Antlr4ParserRule rule) //2112:1
        {
            string result = ""; //2113:2
            var __loop15_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //2114:7
                select new { elem = elem}
                ).ToList(); //2114:2
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                string delim; //2114:28
                if (__loop15_iteration+1 < __loop15_results.Count) delim = " ||\n\t\t\t";
                else delim = string.Empty;
                var __tmp1 = __loop15_results[__loop15_iteration];
                var elem = __tmp1.elem;
                if (elem.IsList) //2115:3
                {
                    result += "this." + elem.FieldName() + " != " + elem.FieldName() + delim; //2116:4
                }
                else //2117:3
                {
                    result += "this." + elem.FieldName() + " != " + elem.FieldName() + delim; //2118:4
                }
            }
            return result; //2121:2
        }

        public string GetElemUpdateList(Antlr4ParserRule rule) //2124:1
        {
            string result = ""; //2125:2
            var __loop16_results = 
                (from elem in __Enumerate((rule.AllElements).GetEnumerator()) //2126:7
                select new { elem = elem}
                ).ToList(); //2126:2
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                string delim; //2126:28
                if (__loop16_iteration+1 < __loop16_results.Count) delim = " ||\n\t\t\t";
                else delim = string.Empty;
                var __tmp1 = __loop16_results[__loop16_iteration];
                var elem = __tmp1.elem;
                if (elem.IsList && !elem.IsToken) //2127:3
                {
                    result += "this." + elem.RedName() + ".Node != " + elem.FieldName() + ".Node" + delim; //2128:4
                }
                else //2129:3
                {
                    result += "this." + elem.RedName() + " != " + elem.FieldName() + delim; //2130:4
                }
            }
            return result; //2133:2
        }

        public string GenerateInternalSyntaxRule(Antlr4ParserRule rule, Antlr4ParserRule superRule) //2136:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2138:1
            __out.AppendLine(true); //2141:1
            __out.AppendLine(true); //2151:1
            __out.AppendLine(true); //2161:1
            __out.AppendLine(true); //2173:1
            __out.AppendLine(true); //2185:1
            __out.AppendLine(true); //2187:1
            __out.AppendLine(true); //2191:1
            __out.AppendLine(true); //2196:1
            __out.AppendLine(true); //2207:1
            __out.AppendLine(true); //2212:1
            __out.AppendLine(true); //2219:1
            __out.AppendLine(true); //2237:1
            return __out.ToString();
        }

        public string GenerateInternalSyntaxFactory() //2258:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2262:1
            __out.AppendLine(true); //2267:1
            __out.AppendLine(true); //2272:1
            __out.AppendLine(true); //2277:1
            __out.AppendLine(true); //2282:1
            __out.AppendLine(true); //2287:1
            __out.AppendLine(true); //2292:1
            __out.AppendLine(true); //2297:1
            __out.AppendLine(true); //2302:1
            __out.AppendLine(true); //2307:1
            __out.AppendLine(true); //2312:1
            __out.AppendLine(true); //2317:1
            __out.AppendLine(true); //2322:1
            __out.AppendLine(true); //2331:1
            __out.AppendLine(true); //2336:1
            __out.AppendLine(true); //2345:1
            __out.AppendLine(true); //2350:1
            __out.AppendLine(true); //2359:1
            __out.AppendLine(true); //2364:1
            __out.AppendLine(true); //2369:1
            __out.AppendLine(true); //2371:1
            __out.AppendLine(true); //2376:1
            __out.AppendLine(true); //2391:1
            return __out.ToString();
        }

        public string GenerateInternalSyntaxFactoryCreate(Antlr4ParserRule rule) //2409:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2412:1
            __out.AppendLine(true); //2453:1
            return __out.ToString();
        }

        public string GenerateSyntaxKind() //2494:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2508:1
            __out.AppendLine(true); //2517:1
            __out.AppendLine(true); //2523:1
            return __out.ToString();
        }

        public string GenerateSyntax() //2538:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2552:1
            __out.AppendLine(true); //2561:1
            __out.AppendLine(true); //2566:1
            __out.AppendLine(true); //2571:1
            __out.AppendLine(true); //2581:1
            __out.AppendLine(true); //2583:1
            __out.AppendLine(true); //2595:1
            __out.AppendLine(true); //2602:1
            __out.AppendLine(true); //2608:1
            __out.AppendLine(true); //2615:1
            __out.AppendLine(true); //2620:1
            __out.AppendLine(true); //2625:1
            __out.AppendLine(true); //2635:1
            __out.AppendLine(true); //2643:1
            __out.AppendLine(true); //2645:1
            __out.AppendLine(true); //2647:1
            __out.AppendLine(true); //2649:1
            __out.AppendLine(true); //2651:1
            return __out.ToString();
        }

        public string GenerateSyntaxRule(Antlr4ParserRule rule, Antlr4ParserRule superRule) //2656:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2658:1
            __out.AppendLine(true); //2665:1
            __out.AppendLine(true); //2675:1
            __out.AppendLine(true); //2687:1
            __out.AppendLine(true); //2692:1
            __out.AppendLine(true); //2697:1
            __out.AppendLine(true); //2740:1
            __out.AppendLine(true); //2753:1
            __out.AppendLine(true); //2767:1
            __out.AppendLine(true); //2777:1
            __out.AppendLine(true); //2786:1
            __out.AppendLine(true); //2801:1
            __out.AppendLine(true); //2815:1
            __out.AppendLine(true); //2820:1
            return __out.ToString();
        }

        public string GenerateSyntaxFacts() //2829:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //2834:1
            __out.AppendLine(true); //2844:1
            __out.AppendLine(true); //2852:1
            __out.AppendLine(true); //2856:1
            __out.AppendLine(true); //2861:1
            __out.AppendLine(true); //2866:1
            __out.AppendLine(true); //2871:1
            __out.AppendLine(true); //2885:1
            __out.AppendLine(true); //2890:1
            __out.AppendLine(true); //2904:1
            __out.AppendLine(true); //2909:1
            __out.AppendLine(true); //2922:1
            __out.AppendLine(true); //2935:1
            __out.AppendLine(true); //2940:1
            __out.AppendLine(true); //2945:1
            __out.AppendLine(true); //2950:1
            __out.AppendLine(true); //2973:1
            __out.AppendLine(true); //2979:1
            __out.AppendLine(true); //3001:1
            __out.AppendLine(true); //3006:1
            __out.AppendLine(true); //3027:1
            __out.AppendLine(true); //3032:1
            return __out.ToString();
        }

        public string GenerateSyntaxVisitor() //3050:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3063:1
            return __out.ToString();
        }

        public string GenerateSyntaxVisitorVisit(Antlr4ParserRule rule, bool intf) //3078:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3079:1
            return __out.ToString();
        }

        public string GenerateSyntaxTypedVisitor() //3090:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3103:1
            return __out.ToString();
        }

        public string GenerateSyntaxTypedVisitorVisit(Antlr4ParserRule rule, bool intf) //3118:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3119:1
            return __out.ToString();
        }

        public string GenerateDetailedSyntaxVisitor() //3130:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDetailedSyntaxVisitorVisit(Antlr4ParserRule rule) //3149:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3150:1
            return __out.ToString();
        }

        public string GenerateSyntaxRewriter() //3181:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateSyntaxRewriterVisit(Antlr4ParserRule rule) //3200:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3201:1
            return __out.ToString();
        }

        public string GenerateSyntaxFactory() //3239:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3243:1
            __out.AppendLine(true); //3258:1
            __out.AppendLine(true); //3263:1
            __out.AppendLine(true); //3268:1
            __out.AppendLine(true); //3280:1
            __out.AppendLine(true); //3291:1
            __out.AppendLine(true); //3302:1
            __out.AppendLine(true); //3313:1
            __out.AppendLine(true); //3318:1
            __out.AppendLine(true); //3323:1
            __out.AppendLine(true); //3328:1
            __out.AppendLine(true); //3333:1
            __out.AppendLine(true); //3344:1
            __out.AppendLine(true); //3349:1
            __out.AppendLine(true); //3357:1
            __out.AppendLine(true); //3370:1
            __out.AppendLine(true); //3382:1
            __out.AppendLine(true); //3391:1
            __out.AppendLine(true); //3404:1
            __out.AppendLine(true); //3409:1
            __out.AppendLine(true); //3416:1
            __out.AppendLine(true); //3421:1
            __out.AppendLine(true); //3437:1
            return __out.ToString();
        }

        public string GenerateSyntaxFactoryCreate(Antlr4ParserRule rule) //3455:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3458:1
            __out.AppendLine(true); //3475:1
            __out.AppendLine(true); //3493:1
            return __out.ToString();
        }

        public string GenerateGreenToken() //3503:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //3510:1
            __out.AppendLine(true); //3515:1
            __out.AppendLine(true); //3520:1
            __out.AppendLine(true); //3525:1
            __out.AppendLine(true); //3533:1
            __out.AppendLine(true); //3538:1
            __out.AppendLine(true); //3543:1
            __out.AppendLine(true); //3548:1
            __out.AppendLine(true); //3553:1
            __out.AppendLine(true); //3558:1
            __out.AppendLine(true); //3563:1
            __out.AppendLine(true); //3572:1
            __out.AppendLine(true); //3575:1
            __out.AppendLine(true); //3578:1
            __out.AppendLine(true); //3587:1
            __out.AppendLine(true); //3590:1
            __out.AppendLine(true); //3606:1
            __out.AppendLine(true); //3611:1
            __out.AppendLine(true); //3614:1
            __out.AppendLine(true); //3619:1
            __out.AppendLine(true); //3622:1
            __out.AppendLine(true); //3628:1
            __out.AppendLine(true); //3639:1
            __out.AppendLine(true); //3649:1
            __out.AppendLine(true); //3657:1
            __out.AppendLine(true); //3665:1
            __out.AppendLine(true); //3674:1
            __out.AppendLine(true); //3679:1
            __out.AppendLine(true); //3693:1
            __out.AppendLine(true); //3696:1
            __out.AppendLine(true); //3703:1
            __out.AppendLine(true); //3706:1
            __out.AppendLine(true); //3711:1
            __out.AppendLine(true); //3716:1
            __out.AppendLine(true); //3721:1
            __out.AppendLine(true); //3736:1
            __out.AppendLine(true); //3741:1
            __out.AppendLine(true); //3746:1
            __out.AppendLine(true); //3751:1
            __out.AppendLine(true); //3756:1
            __out.AppendLine(true); //3761:1
            __out.AppendLine(true); //3767:1
            __out.AppendLine(true); //3775:1
            __out.AppendLine(true); //3780:1
            __out.AppendLine(true); //3785:1
            __out.AppendLine(true); //3790:1
            __out.AppendLine(true); //3795:1
            __out.AppendLine(true); //3800:1
            __out.AppendLine(true); //3806:1
            __out.AppendLine(true); //3810:1
            __out.AppendLine(true); //3816:1
            __out.AppendLine(true); //3821:1
            __out.AppendLine(true); //3826:1
            __out.AppendLine(true); //3831:1
            __out.AppendLine(true); //3836:1
            __out.AppendLine(true); //3841:1
            __out.AppendLine(true); //3846:1
            __out.AppendLine(true); //3852:1
            __out.AppendLine(true); //3856:1
            __out.AppendLine(true); //3862:1
            __out.AppendLine(true); //3867:1
            __out.AppendLine(true); //3872:1
            __out.AppendLine(true); //3877:1
            __out.AppendLine(true); //3882:1
            __out.AppendLine(true); //3887:1
            __out.AppendLine(true); //3893:1
            __out.AppendLine(true); //3897:1
            __out.AppendLine(true); //3907:1
            __out.AppendLine(true); //3912:1
            __out.AppendLine(true); //3917:1
            __out.AppendLine(true); //3922:1
            __out.AppendLine(true); //3927:1
            __out.AppendLine(true); //3933:1
            __out.AppendLine(true); //3938:1
            __out.AppendLine(true); //3960:1
            __out.AppendLine(true); //3965:1
            __out.AppendLine(true); //3970:1
            __out.AppendLine(true); //3975:1
            __out.AppendLine(true); //3980:1
            __out.AppendLine(true); //3985:1
            __out.AppendLine(true); //3991:1
            __out.AppendLine(true); //3996:1
            __out.AppendLine(true); //4003:1
            __out.AppendLine(true); //4011:1
            __out.AppendLine(true); //4019:1
            __out.AppendLine(true); //4027:1
            __out.AppendLine(true); //4032:1
            __out.AppendLine(true); //4037:1
            __out.AppendLine(true); //4042:1
            __out.AppendLine(true); //4048:1
            __out.AppendLine(true); //4053:1
            __out.AppendLine(true); //4075:1
            __out.AppendLine(true); //4080:1
            __out.AppendLine(true); //4085:1
            __out.AppendLine(true); //4090:1
            __out.AppendLine(true); //4095:1
            __out.AppendLine(true); //4100:1
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilder() //4110:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //4122:1
            __out.AppendLine(true); //4131:1
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderVisit(Antlr4ParserRule rule) //4154:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //4155:1
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderVisitBody(Antlr4ParserRule rule) //4162:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderVisitElementBody(Antlr4ParserRuleElement elem) //4176:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderDeclaration(MetaCompilerAnnotations annots, string name, string body) //4193:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderQualifier(MetaCompilerAnnotations annots, string name, string body) //4211:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderName(MetaCompilerAnnotations annots, string name, string body) //4223:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderProperty(MetaCompilerAnnotations annots, string name, string body) //4235:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateDeclarationTreeBuilderIdentifier(MetaCompilerAnnotations annots, string name, string body) //4247:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GetDeclarationTreeBuilderVisitBody(Antlr4ParserRule rule) //4252:1
        {
            string body = GenerateDeclarationTreeBuilderVisitBody(rule); //4253:2
            if (rule.Annotations.IsIdentifier()) //4254:2
            {
                body = GenerateDeclarationTreeBuilderIdentifier(rule.Annotations, "node", body); //4255:3
            }
            if (rule.Annotations.IsQualifier()) //4257:2
            {
                body = GenerateDeclarationTreeBuilderQualifier(rule.Annotations, "node", body); //4258:3
            }
            if (rule.Annotations.IsName()) //4260:2
            {
                body = GenerateDeclarationTreeBuilderName(rule.Annotations, "node", body); //4261:3
            }
            if (rule.Annotations.IsDeclaration()) //4263:2
            {
                body = GenerateDeclarationTreeBuilderDeclaration(rule.Annotations, "node", body); //4264:3
            }
            if (rule.Annotations.IsPropertyWithNoValue()) //4266:2
            {
                body = GenerateDeclarationTreeBuilderProperty(rule.Annotations, "node", body); //4267:3
            }
            return body; //4269:2
        }

        public string GetDeclarationTreeBuilderVisitElement(Antlr4ParserRule rule, Antlr4ParserRuleElement elem) //4272:1
        {
            string body = GenerateDeclarationTreeBuilderVisitElementBody(elem); //4273:2
            if (elem.Annotations.IsIdentifier()) //4274:2
            {
                body = GenerateDeclarationTreeBuilderIdentifier(elem.Annotations, "node." + elem.RedName(), body); //4275:3
            }
            if (elem.Annotations.IsQualifier()) //4277:2
            {
                body = GenerateDeclarationTreeBuilderQualifier(elem.Annotations, "node." + elem.RedName(), body); //4278:3
            }
            if (elem.Annotations.IsName()) //4280:2
            {
                body = GenerateDeclarationTreeBuilderName(elem.Annotations, "node." + elem.RedName(), body); //4281:3
            }
            if (elem.Annotations.IsPropertyWithNoValue()) //4283:2
            {
                body = GenerateDeclarationTreeBuilderProperty(elem.Annotations, "node." + elem.RedName(), body); //4284:3
            }
            return body; //4286:2
        }

        public string GenerateDeclarationTreeBuilderVisitElement(Antlr4ParserRule rule, Antlr4ParserRuleElement elem) //4289:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateBinderFactoryVisitor() //4309:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //4328:1
            __out.AppendLine(true); //4336:1
            __out.AppendLine(true); //4340:1
            __out.AppendLine(true); //4343:1
            __out.AppendLine(true); //4348:1
            return __out.ToString();
        }

        public string GenerateBinderFactoryVisit(Antlr4ParserRule rule) //4368:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //4369:1
            return __out.ToString();
        }

        public string GetAnnotationParams(MetaCompilerAnnotation annot) //4393:1
        {
            string result = ""; //4394:5
            if (annot.Name == MetaCompilerAnnotationInfo.SymbolDef || annot.Name == MetaCompilerAnnotationInfo.SymbolCtr) //4395:2
            {
                if (annot.HasProperty("symbolType")) //4396:3
                {
                    result = ", typeof(Symbols." + annot.GetValue("symbolType") + ")"; //4397:4
                }
                else //4398:3
                {
                    result = ", null"; //4399:4
                }
            }
            if (annot.Name == MetaCompilerAnnotationInfo.SymbolUse) //4402:2
            {
                if (annot.HasProperty("symbolType")) //4403:3
                {
                    result = ", ImmutableArray.Create(typeof(Symbols." + annot.GetValue("symbolType") + "))"; //4404:4
                }
                else //4405:3
                {
                    result = ", ImmutableArray<Type>.Empty"; //4406:4
                }
            }
            if (annot.Name == MetaCompilerAnnotationInfo.Property) //4409:2
            {
                result = ", \"" + annot.GetValue("name") + "\""; //4410:6
                if (annot.HasProperty("value")) //4411:3
                {
                    result = result + ", " + annot.GetValue("value"); //4412:7
                }
            }
            if (annot.Name == MetaCompilerAnnotationInfo.Value && annot.HasProperty("value")) //4415:2
            {
                result = ", " + annot.GetValue("value"); //4416:6
            }
            if (annot.Name == MetaCompilerAnnotationInfo.EnumValue) //4418:2
            {
                if (annot.HasProperty("enumType")) //4419:3
                {
                    result = ", typeof(Symbols." + annot.GetValue("enumType") + ")"; //4420:4
                }
                else //4421:3
                {
                    result = ", null"; //4422:4
                }
            }
            return result; //4425:2
        }

        public string GenerateBinderFactoryVisitBody(Antlr4ParserRule rule) //4429:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateBinderFactoryVisitElementBody(Antlr4ParserRule rule, Antlr4ParserRuleElement elem) //4443:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateBinderFactoryVisitTokenAltBody(Antlr4ParserRule rule, Antlr4ParserRuleElement elem) //4459:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateBinderFactoryVisitElemUses(Antlr4ParserRule rule) //4480:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateBinderFactoryVisitElement(Antlr4ParserRule rule, Antlr4ParserRuleElement elem) //4505:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateSymbolBuilder() //4514:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //4528:1
            __out.AppendLine(true); //4536:1
            __out.AppendLine(true); //4538:1
            __out.AppendLine(true); //4550:1
            return __out.ToString();
        }

        private class StringBuilder
        {
            private bool newLine;
            private System.Text.StringBuilder builder = new System.Text.StringBuilder();
            
            public StringBuilder()
            {
                this.newLine = true;
            }
            
            public void Append(string str)
            {
                if (str == null) return;
                if (!string.IsNullOrEmpty(str))
                {
                    this.newLine = false;
                }
                builder.Append(str);
            }
            
            public void Append(object obj)
            {
                if (obj == null) return;
                string text = obj.ToString();
                this.Append(text);
            }
            
            public void AppendLine(bool force = false)
            {
                if (force || !this.newLine)
                {
                    builder.AppendLine();
                    this.newLine = true;
                }
            }
            
            public override string ToString()
            {
                return builder.ToString();
            }
        }
    }
}
