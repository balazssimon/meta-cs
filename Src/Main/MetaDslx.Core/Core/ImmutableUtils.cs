using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class ImmutableUtils
    {
        static readonly IDictionary<string, string> specialChars = new Dictionary<string, string>();

        const string regexEscapes = @"[\a\b\f\n\r\t\v\\""]";

        public static string EscapeStringLiteral(string text)
        {
            return Regex.Replace(text, regexEscapes, match);
        }

        public static string EscapeCharLiteral(char c)
        {
            return c == '\'' ? @"'\''" : string.Format("'{0}'", c);
        }

        private static string match(Match m)
        {
            string match = m.ToString();
            if (specialChars.ContainsKey(match))
            {
                return specialChars[match];
            }

            throw new NotSupportedException();
        }

        static ImmutableUtils()
        {
            specialChars.Add("\a", @"\a");
            specialChars.Add("\b", @"\b");
            specialChars.Add("\f", @"\f");
            specialChars.Add("\n", @"\n");
            specialChars.Add("\r", @"\r");
            specialChars.Add("\t", @"\t");
            specialChars.Add("\v", @"\v");

            specialChars.Add("\\", @"\\");
            specialChars.Add("\0", @"\0");

            //The SO parser gets fooled by the verbatim version 
            //of the string to replace - @"\"""
            //so use the 'regular' version
            specialChars.Add("\"", "\\\"");
        }
    }
}
