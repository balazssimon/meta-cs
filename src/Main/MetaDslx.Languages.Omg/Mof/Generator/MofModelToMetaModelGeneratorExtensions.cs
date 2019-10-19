using MetaDslx.Languages.Mof.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Mof.Generator
{
    internal class MofModelToMetaModelGeneratorExtensions : IMofModelToMetaModelGeneratorExtensions
    {
        public MofModelToMetaModelGeneratorExtensions(MofModelToMetaModelGenerator generator)
        {

        }

        public string GenerateDefaultValue(Property property)
        {
            if (property.IsDerived || property.IsDerivedUnion) return string.Empty;
            var value = property.DefaultValue;
            if (value == null) return string.Empty;
            string result = null;
            if (value is LiteralBoolean lb) result = lb.Value.ToString().ToLower();
            if (value is LiteralInteger li) result = li.Value.ToString();
            if (value is LiteralNull) result = "null";
            if (value is LiteralReal lr) result = lr.Value.ToString();
            if (value is LiteralUnlimitedNatural lun) result = lun.Value.ToString();
            if (value is LiteralString ls) result = ls.Value.Replace("\\", "\\\\").Replace("\"", "\\\"");
            if (result != null) return " = \"" + result + "\"";
            else return "/* unhandled default value: " + value.MId.DisplayTypeName + " */";
        }

        public IEnumerable<string> CommentLines(string text, bool escapeHtml)
        {
            if (text == null) return new string[0];
            if (escapeHtml) text = text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");
            var result = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }
    }
}
