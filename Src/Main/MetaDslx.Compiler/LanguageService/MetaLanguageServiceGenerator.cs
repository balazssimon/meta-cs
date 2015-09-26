using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_1498418133;
    namespace __Hidden_MetaLanguageServiceGenerator_1498418133
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

    public class MetaLanguageServiceGenerator //2:1
    {
        private object Instances; //2:1
        public MetaLanguageServiceGenerator(object instances) //2:1
        {
            this.Properties = new __Properties();
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

        public __Properties Properties { get; private set; } //4:1

        public class __Properties //4:1
        {
            internal __Properties()
            {
                this.LanguageServiceNamespace = null; //5:36
                this.LanguageClassName = null; //6:29
                this.LanguageFullName = null; //7:28
                this.GenerateMultipleFiles = false; //8:31
            }
            public string LanguageServiceNamespace { get; set; } //5:2
            public string LanguageClassName { get; set; } //6:2
            public string LanguageFullName { get; set; } //7:2
            public bool GenerateMultipleFiles { get; set; } //8:2
        }

        public string Generate() //11:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //12:1
            __out.AppendLine(); //12:14
            __out.Append("using System.Collections.Generic;"); //13:1
            __out.AppendLine(); //13:34
            __out.Append("using System.ComponentModel;"); //14:1
            __out.AppendLine(); //14:29
            __out.Append("using System.Diagnostics;"); //15:1
            __out.AppendLine(); //15:26
            __out.Append("using System.IO;"); //16:1
            __out.AppendLine(); //16:17
            __out.Append("using System.Linq;"); //17:1
            __out.AppendLine(); //17:19
            __out.Append("using System.Runtime.InteropServices;"); //18:1
            __out.AppendLine(); //18:38
            __out.Append("using System.Text;"); //19:1
            __out.AppendLine(); //19:19
            __out.Append("using System.Threading.Tasks;"); //20:1
            __out.AppendLine(); //20:30
            __out.Append("using Microsoft.VisualStudio.OLE.Interop;"); //21:1
            __out.AppendLine(); //21:42
            __out.Append("using Microsoft.VisualStudio.Package;"); //22:1
            __out.AppendLine(); //22:38
            __out.Append("using Microsoft.VisualStudio.Shell.Interop;"); //23:1
            __out.AppendLine(); //23:44
            __out.Append("using Microsoft.VisualStudio.TextManager.Interop;"); //24:1
            __out.AppendLine(); //24:50
            __out.Append("using Antlr4.Runtime;"); //25:1
            __out.AppendLine(); //25:22
            __out.Append("using MetaDslx.Compiler;"); //26:1
            __out.AppendLine(); //26:25
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //28:1
            __out.AppendLine(); //28:70
            string __tmp1Prefix = "namespace "; //30:1
            string __tmp2Suffix = string.Empty; 
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(Properties.LanguageServiceNamespace);
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_first = true;
                while(__tmp3_first || !__tmp3Reader.EndOfStream)
                {
                    __tmp3_first = false;
                    string __tmp3Line = __tmp3Reader.ReadLine();
                    if (__tmp3Line == null)
                    {
                        __tmp3Line = "";
                    }
                    __out.Append(__tmp1Prefix);
                    __out.Append(__tmp3Line);
                    __out.Append(__tmp2Suffix);
                    __out.AppendLine(); //30:48
                }
            }
            __out.Append("{"); //31:1
            __out.AppendLine(); //31:2
            string __tmp4Prefix = "    public class "; //32:1
            string __tmp5Suffix = "LanguageAuthoringScope : AuthoringScope"; //32:48
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.LanguageClassName);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_first = true;
                while(__tmp6_first || !__tmp6Reader.EndOfStream)
                {
                    __tmp6_first = false;
                    string __tmp6Line = __tmp6Reader.ReadLine();
                    if (__tmp6Line == null)
                    {
                        __tmp6Line = "";
                    }
                    __out.Append(__tmp4Prefix);
                    __out.Append(__tmp6Line);
                    __out.Append(__tmp5Suffix);
                    __out.AppendLine(); //32:87
                }
            }
            __out.Append("    {"); //33:1
            __out.AppendLine(); //33:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //34:1
            __out.AppendLine(); //34:84
            __out.Append("        {"); //35:1
            __out.AppendLine(); //35:10
            __out.Append("            span = new TextSpan();"); //36:1
            __out.AppendLine(); //36:35
            __out.Append("            return null;"); //37:1
            __out.AppendLine(); //37:25
            __out.Append("        }"); //38:1
            __out.AppendLine(); //38:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //40:1
            __out.AppendLine(); //40:126
            __out.Append("        {"); //41:1
            __out.AppendLine(); //41:10
            __out.Append("            return null;"); //42:1
            __out.AppendLine(); //42:25
            __out.Append("        }"); //43:1
            __out.AppendLine(); //43:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //45:1
            __out.AppendLine(); //45:75
            __out.Append("        {"); //46:1
            __out.AppendLine(); //46:10
            __out.Append("            return null;"); //47:1
            __out.AppendLine(); //47:25
            __out.Append("        }"); //48:1
            __out.AppendLine(); //48:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //50:1
            __out.AppendLine(); //50:149
            __out.Append("        {"); //51:1
            __out.AppendLine(); //51:10
            __out.Append("            span = new TextSpan();"); //52:1
            __out.AppendLine(); //52:35
            __out.Append("            return null;"); //53:1
            __out.AppendLine(); //53:25
            __out.Append("        }"); //54:1
            __out.AppendLine(); //54:10
            __out.Append("    }"); //55:1
            __out.AppendLine(); //55:6
            string __tmp7Prefix = "	public class "; //57:1
            string __tmp8Suffix = "LanguageColorizer : Colorizer"; //57:45
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(Properties.LanguageClassName);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_first = true;
                while(__tmp9_first || !__tmp9Reader.EndOfStream)
                {
                    __tmp9_first = false;
                    string __tmp9Line = __tmp9Reader.ReadLine();
                    if (__tmp9Line == null)
                    {
                        __tmp9Line = "";
                    }
                    __out.Append(__tmp7Prefix);
                    __out.Append(__tmp9Line);
                    __out.Append(__tmp8Suffix);
                    __out.AppendLine(); //57:74
                }
            }
            __out.Append("    {"); //58:1
            __out.AppendLine(); //58:6
            string __tmp10Prefix = "        public "; //59:1
            string __tmp11Suffix = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //59:46
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(Properties.LanguageClassName);
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_first = true;
                while(__tmp12_first || !__tmp12Reader.EndOfStream)
                {
                    __tmp12_first = false;
                    string __tmp12Line = __tmp12Reader.ReadLine();
                    if (__tmp12Line == null)
                    {
                        __tmp12Line = "";
                    }
                    __out.Append(__tmp10Prefix);
                    __out.Append(__tmp12Line);
                    __out.Append(__tmp11Suffix);
                    __out.AppendLine(); //59:123
                }
            }
            __out.Append("            : base(svc, buffer, scanner)"); //60:1
            __out.AppendLine(); //60:41
            __out.Append("        {"); //61:1
            __out.AppendLine(); //61:10
            __out.Append("        }"); //62:1
            __out.AppendLine(); //62:10
            __out.Append("        #region IVsColorizer Members"); //64:1
            __out.AppendLine(); //64:37
            string __tmp13Prefix = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //66:1
            string __tmp14Suffix = " attrs)"; //66:97
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append("[]");
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_first = true;
                while(__tmp15_first || !__tmp15Reader.EndOfStream)
                {
                    __tmp15_first = false;
                    string __tmp15Line = __tmp15Reader.ReadLine();
                    if (__tmp15Line == null)
                    {
                        __tmp15Line = "";
                    }
                    __out.Append(__tmp13Prefix);
                    __out.Append(__tmp15Line);
                    __out.Append(__tmp14Suffix);
                    __out.AppendLine(); //66:104
                }
            }
            __out.Append("        {"); //67:1
            __out.AppendLine(); //67:10
            __out.Append("            if (attrs == null) return state;"); //68:1
            __out.AppendLine(); //68:45
            __out.Append("            int linepos = 0;"); //69:1
            __out.AppendLine(); //69:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //70:1
            __out.AppendLine(); //70:75
            __out.Append("            // random color junk on the screen."); //71:1
            __out.AppendLine(); //71:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //72:1
            __out.AppendLine(); //72:65
            string __tmp16Prefix = "                attrs"; //73:1
            string __tmp17Suffix = " = (uint)TokenColor.Text;"; //73:35
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append("[linepos]");
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_first = true;
                while(__tmp18_first || !__tmp18Reader.EndOfStream)
                {
                    __tmp18_first = false;
                    string __tmp18Line = __tmp18Reader.ReadLine();
                    if (__tmp18Line == null)
                    {
                        __tmp18Line = "";
                    }
                    __out.Append(__tmp16Prefix);
                    __out.Append(__tmp18Line);
                    __out.Append(__tmp17Suffix);
                    __out.AppendLine(); //73:60
                }
            }
            __out.Append("            if (this.Scanner != null)"); //74:1
            __out.AppendLine(); //74:38
            __out.Append("            {"); //75:1
            __out.AppendLine(); //75:14
            __out.Append("                try"); //76:1
            __out.AppendLine(); //76:20
            __out.Append("                {"); //77:1
            __out.AppendLine(); //77:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //78:1
            __out.AppendLine(); //78:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //80:1
            __out.AppendLine(); //80:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //82:1
            __out.AppendLine(); //82:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //84:1
            __out.AppendLine(); //84:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //86:1
            __out.AppendLine(); //86:94
            __out.Append("                    {"); //87:1
            __out.AppendLine(); //87:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //88:1
            __out.AppendLine(); //88:103
            __out.Append("                        {"); //89:1
            __out.AppendLine(); //89:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //90:1
            __out.AppendLine(); //90:72
            __out.Append("                            {"); //91:1
            __out.AppendLine(); //91:30
            string __tmp19Prefix = "                                attrs"; //92:1
            string __tmp20Suffix = " = (uint)tokenInfo.Color;"; //92:51
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append("[linepos]");
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_first = true;
                while(__tmp21_first || !__tmp21Reader.EndOfStream)
                {
                    __tmp21_first = false;
                    string __tmp21Line = __tmp21Reader.ReadLine();
                    if (__tmp21Line == null)
                    {
                        __tmp21Line = "";
                    }
                    __out.Append(__tmp19Prefix);
                    __out.Append(__tmp21Line);
                    __out.Append(__tmp20Suffix);
                    __out.AppendLine(); //92:76
                }
            }
            __out.Append("                            }"); //93:1
            __out.AppendLine(); //93:30
            __out.Append("                        }"); //94:1
            __out.AppendLine(); //94:26
            __out.Append("                    }"); //95:1
            __out.AppendLine(); //95:22
            __out.Append("                }"); //96:1
            __out.AppendLine(); //96:18
            __out.Append("                catch (Exception)"); //97:1
            __out.AppendLine(); //97:34
            __out.Append("                {"); //98:1
            __out.AppendLine(); //98:18
            __out.Append("                    // Ignore exceptions"); //99:1
            __out.AppendLine(); //99:41
            __out.Append("                }"); //100:1
            __out.AppendLine(); //100:18
            __out.Append("            }"); //101:1
            __out.AppendLine(); //101:14
            __out.Append("            return state;"); //102:1
            __out.AppendLine(); //102:26
            __out.Append("        }"); //103:1
            __out.AppendLine(); //103:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //105:1
            __out.AppendLine(); //105:64
            __out.Append("        {"); //106:1
            __out.AppendLine(); //106:10
            __out.Append("            piStartState = 0;"); //107:1
            __out.AppendLine(); //107:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //108:1
            __out.AppendLine(); //108:60
            __out.Append("        }"); //109:1
            __out.AppendLine(); //109:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //111:1
            __out.AppendLine(); //111:98
            __out.Append("        {"); //112:1
            __out.AppendLine(); //112:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //113:1
            __out.AppendLine(); //113:66
            __out.Append("            if (text != null)"); //114:1
            __out.AppendLine(); //114:30
            __out.Append("            {"); //115:1
            __out.AppendLine(); //115:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //116:1
            __out.AppendLine(); //116:49
            string __tmp22Prefix = "                (("; //117:1
            string __tmp23Suffix = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //117:49
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(Properties.LanguageClassName);
            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
            {
                bool __tmp24_first = true;
                while(__tmp24_first || !__tmp24Reader.EndOfStream)
                {
                    __tmp24_first = false;
                    string __tmp24Line = __tmp24Reader.ReadLine();
                    if (__tmp24Line == null)
                    {
                        __tmp24Line = "";
                    }
                    __out.Append(__tmp22Prefix);
                    __out.Append(__tmp24Line);
                    __out.Append(__tmp23Suffix);
                    __out.AppendLine(); //117:100
                }
            }
            __out.Append("            }"); //118:1
            __out.AppendLine(); //118:14
            __out.Append("            return iState;"); //119:1
            __out.AppendLine(); //119:27
            __out.Append("        }"); //120:1
            __out.AppendLine(); //120:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //122:1
            __out.AppendLine(); //122:68
            __out.Append("        {"); //123:1
            __out.AppendLine(); //123:10
            __out.Append("            pfFlag = 1;"); //124:1
            __out.AppendLine(); //124:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //125:1
            __out.AppendLine(); //125:60
            __out.Append("        }"); //126:1
            __out.AppendLine(); //126:10
            __out.Append("        #endregion"); //128:1
            __out.AppendLine(); //128:19
            __out.Append("    }"); //129:1
            __out.AppendLine(); //129:6
            string __tmp25Prefix = "    public abstract class "; //131:1
            string __tmp26Suffix = "LanguageConfigBase"; //131:57
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(Properties.LanguageClassName);
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_first = true;
                while(__tmp27_first || !__tmp27Reader.EndOfStream)
                {
                    __tmp27_first = false;
                    string __tmp27Line = __tmp27Reader.ReadLine();
                    if (__tmp27Line == null)
                    {
                        __tmp27Line = "";
                    }
                    __out.Append(__tmp25Prefix);
                    __out.Append(__tmp27Line);
                    __out.Append(__tmp26Suffix);
                    __out.AppendLine(); //131:75
                }
            }
            __out.Append("    {"); //132:1
            __out.AppendLine(); //132:6
            string __tmp28Prefix = "        private static "; //133:1
            string __tmp29Suffix = "LanguageConfig instance = null;"; //133:54
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(Properties.LanguageClassName);
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_first = true;
                while(__tmp30_first || !__tmp30Reader.EndOfStream)
                {
                    __tmp30_first = false;
                    string __tmp30Line = __tmp30Reader.ReadLine();
                    if (__tmp30Line == null)
                    {
                        __tmp30Line = "";
                    }
                    __out.Append(__tmp28Prefix);
                    __out.Append(__tmp30Line);
                    __out.Append(__tmp29Suffix);
                    __out.AppendLine(); //133:85
                }
            }
            string __tmp31Prefix = "        public static "; //135:1
            string __tmp32Suffix = "LanguageConfig Instance"; //135:53
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(Properties.LanguageClassName);
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_first = true;
                while(__tmp33_first || !__tmp33Reader.EndOfStream)
                {
                    __tmp33_first = false;
                    string __tmp33Line = __tmp33Reader.ReadLine();
                    if (__tmp33Line == null)
                    {
                        __tmp33Line = "";
                    }
                    __out.Append(__tmp31Prefix);
                    __out.Append(__tmp33Line);
                    __out.Append(__tmp32Suffix);
                    __out.AppendLine(); //135:76
                }
            }
            __out.Append("        {"); //136:1
            __out.AppendLine(); //136:10
            __out.Append("            get "); //137:1
            __out.AppendLine(); //137:17
            __out.Append("            {"); //138:1
            __out.AppendLine(); //138:14
            __out.Append("                if (instance == null)"); //139:1
            __out.AppendLine(); //139:38
            __out.Append("                {"); //140:1
            __out.AppendLine(); //140:18
            string __tmp34Prefix = "					// If there is a compile error in the following line, create a class "; //141:1
            string __tmp35Suffix = "LanguageConfig"; //141:105
            StringBuilder __tmp36 = new StringBuilder();
            __tmp36.Append(Properties.LanguageClassName);
            using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
            {
                bool __tmp36_first = true;
                while(__tmp36_first || !__tmp36Reader.EndOfStream)
                {
                    __tmp36_first = false;
                    string __tmp36Line = __tmp36Reader.ReadLine();
                    if (__tmp36Line == null)
                    {
                        __tmp36Line = "";
                    }
                    __out.Append(__tmp34Prefix);
                    __out.Append(__tmp36Line);
                    __out.Append(__tmp35Suffix);
                    __out.AppendLine(); //141:119
                }
            }
            string __tmp37Prefix = "					// which is a subclass of "; //142:1
            string __tmp38Suffix = "LanguageConfigBase"; //142:62
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(Properties.LanguageClassName);
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_first = true;
                while(__tmp39_first || !__tmp39Reader.EndOfStream)
                {
                    __tmp39_first = false;
                    string __tmp39Line = __tmp39Reader.ReadLine();
                    if (__tmp39Line == null)
                    {
                        __tmp39Line = "";
                    }
                    __out.Append(__tmp37Prefix);
                    __out.Append(__tmp39Line);
                    __out.Append(__tmp38Suffix);
                    __out.AppendLine(); //142:80
                }
            }
            string __tmp40Prefix = "                    instance = new "; //143:1
            string __tmp41Suffix = "LanguageConfig();"; //143:66
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(Properties.LanguageClassName);
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_first = true;
                while(__tmp42_first || !__tmp42Reader.EndOfStream)
                {
                    __tmp42_first = false;
                    string __tmp42Line = __tmp42Reader.ReadLine();
                    if (__tmp42Line == null)
                    {
                        __tmp42Line = "";
                    }
                    __out.Append(__tmp40Prefix);
                    __out.Append(__tmp42Line);
                    __out.Append(__tmp41Suffix);
                    __out.AppendLine(); //143:83
                }
            }
            __out.Append("                }"); //144:1
            __out.AppendLine(); //144:18
            __out.Append("                return instance;"); //145:1
            __out.AppendLine(); //145:33
            __out.Append("            }"); //146:1
            __out.AppendLine(); //146:14
            __out.Append("        }"); //147:1
            __out.AppendLine(); //147:10
            __out.Append("        private List<IVsColorableItem> colorableItems = new List<IVsColorableItem>();"); //149:1
            __out.AppendLine(); //149:86
            __out.Append("        public IList<IVsColorableItem> ColorableItems"); //150:1
            __out.AppendLine(); //150:54
            __out.Append("        {"); //151:1
            __out.AppendLine(); //151:10
            __out.Append("            get { return colorableItems; }"); //152:1
            __out.AppendLine(); //152:43
            __out.Append("        }"); //153:1
            __out.AppendLine(); //153:10
            __out.Append("        protected TokenColor CreateColor(string name, COLORINDEX foreground, COLORINDEX background)"); //154:1
            __out.AppendLine(); //154:100
            __out.Append("        {"); //155:1
            __out.AppendLine(); //155:10
            __out.Append("            return CreateColor(name, foreground, background, false, false);"); //156:1
            __out.AppendLine(); //156:76
            __out.Append("        }"); //157:1
            __out.AppendLine(); //157:10
            __out.Append("        protected TokenColor CreateColor(string name, COLORINDEX foreground, COLORINDEX background, bool bold, bool strikethrough)"); //158:1
            __out.AppendLine(); //158:131
            __out.Append("        {"); //159:1
            __out.AppendLine(); //159:10
            string __tmp43Prefix = "            colorableItems.Add(new "; //160:1
            string __tmp44Suffix = "LanguageColorableItem(name, foreground, background, bold, strikethrough));"; //160:66
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(Properties.LanguageClassName);
            using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
            {
                bool __tmp45_first = true;
                while(__tmp45_first || !__tmp45Reader.EndOfStream)
                {
                    __tmp45_first = false;
                    string __tmp45Line = __tmp45Reader.ReadLine();
                    if (__tmp45Line == null)
                    {
                        __tmp45Line = "";
                    }
                    __out.Append(__tmp43Prefix);
                    __out.Append(__tmp45Line);
                    __out.Append(__tmp44Suffix);
                    __out.AppendLine(); //160:140
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //161:1
            __out.AppendLine(); //161:53
            __out.Append("        }"); //162:1
            __out.AppendLine(); //162:10
            __out.Append("        protected void ColorToken(string tokenName, TokenType type, TokenColor color, TokenTriggers trigger)"); //163:1
            __out.AppendLine(); //163:109
            __out.Append("        {"); //164:1
            __out.AppendLine(); //164:10
            string __tmp46Prefix = "            definitions"; //165:1
            string __tmp47Suffix = " = new TokenDefinition(type, color, trigger);"; //165:39
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append("[tokenName]");
            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
            {
                bool __tmp48_first = true;
                while(__tmp48_first || !__tmp48Reader.EndOfStream)
                {
                    __tmp48_first = false;
                    string __tmp48Line = __tmp48Reader.ReadLine();
                    if (__tmp48Line == null)
                    {
                        __tmp48Line = "";
                    }
                    __out.Append(__tmp46Prefix);
                    __out.Append(__tmp48Line);
                    __out.Append(__tmp47Suffix);
                    __out.AppendLine(); //165:84
                }
            }
            __out.Append("        }"); //166:1
            __out.AppendLine(); //166:10
            __out.Append("        protected static TokenDefinition GetDefinition(string tokenName)"); //167:1
            __out.AppendLine(); //167:73
            __out.Append("        {"); //168:1
            __out.AppendLine(); //168:10
            __out.Append("            TokenDefinition result;"); //169:1
            __out.AppendLine(); //169:36
            __out.Append("            return definitions.TryGetValue(tokenName, out result) ? result : defaultDefinition;"); //170:1
            __out.AppendLine(); //170:96
            __out.Append("        }"); //171:1
            __out.AppendLine(); //171:10
            __out.Append("        private static TokenDefinition defaultDefinition = new TokenDefinition(TokenType.Text, TokenColor.Text, TokenTriggers.None);"); //172:1
            __out.AppendLine(); //172:133
            __out.Append("        private static Dictionary<string, TokenDefinition> definitions = new Dictionary<string, TokenDefinition>();"); //173:1
            __out.AppendLine(); //173:116
            __out.Append("        protected struct TokenDefinition"); //174:1
            __out.AppendLine(); //174:41
            __out.Append("        {"); //175:1
            __out.AppendLine(); //175:10
            __out.Append("            public TokenDefinition(TokenType type, TokenColor color, TokenTriggers triggers)"); //176:1
            __out.AppendLine(); //176:93
            __out.Append("            {"); //177:1
            __out.AppendLine(); //177:14
            __out.Append("                this.TokenType = type;"); //178:1
            __out.AppendLine(); //178:39
            __out.Append("                this.TokenColor = color;"); //179:1
            __out.AppendLine(); //179:41
            __out.Append("                this.TokenTriggers = triggers;"); //180:1
            __out.AppendLine(); //180:47
            __out.Append("            }"); //181:1
            __out.AppendLine(); //181:14
            __out.Append("            public TokenType TokenType;"); //182:1
            __out.AppendLine(); //182:40
            __out.Append("            public TokenColor TokenColor;"); //183:1
            __out.AppendLine(); //183:42
            __out.Append("            public TokenTriggers TokenTriggers;"); //184:1
            __out.AppendLine(); //184:48
            __out.Append("        }"); //185:1
            __out.AppendLine(); //185:10
            __out.Append("    }"); //186:1
            __out.AppendLine(); //186:6
            string __tmp49Prefix = "    public class "; //188:1
            string __tmp50Suffix = "LanguageColorableItem : Microsoft.VisualStudio.TextManager.Interop.IVsColorableItem"; //188:48
            StringBuilder __tmp51 = new StringBuilder();
            __tmp51.Append(Properties.LanguageClassName);
            using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
            {
                bool __tmp51_first = true;
                while(__tmp51_first || !__tmp51Reader.EndOfStream)
                {
                    __tmp51_first = false;
                    string __tmp51Line = __tmp51Reader.ReadLine();
                    if (__tmp51Line == null)
                    {
                        __tmp51Line = "";
                    }
                    __out.Append(__tmp49Prefix);
                    __out.Append(__tmp51Line);
                    __out.Append(__tmp50Suffix);
                    __out.AppendLine(); //188:131
                }
            }
            __out.Append("    {"); //189:1
            __out.AppendLine(); //189:6
            __out.Append("        private string displayName;"); //190:1
            __out.AppendLine(); //190:36
            __out.Append("        private COLORINDEX background;"); //191:1
            __out.AppendLine(); //191:39
            __out.Append("        private COLORINDEX foreground;"); //192:1
            __out.AppendLine(); //192:39
            __out.Append("        private uint fontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //193:1
            __out.AppendLine(); //193:61
            string __tmp52Prefix = "        public "; //195:1
            string __tmp53Suffix = "LanguageColorableItem(string displayName, COLORINDEX foreground, COLORINDEX background, bool bold, bool strikethrough)"; //195:46
            StringBuilder __tmp54 = new StringBuilder();
            __tmp54.Append(Properties.LanguageClassName);
            using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
            {
                bool __tmp54_first = true;
                while(__tmp54_first || !__tmp54Reader.EndOfStream)
                {
                    __tmp54_first = false;
                    string __tmp54Line = __tmp54Reader.ReadLine();
                    if (__tmp54Line == null)
                    {
                        __tmp54Line = "";
                    }
                    __out.Append(__tmp52Prefix);
                    __out.Append(__tmp54Line);
                    __out.Append(__tmp53Suffix);
                    __out.AppendLine(); //195:164
                }
            }
            __out.Append("        {"); //196:1
            __out.AppendLine(); //196:10
            __out.Append("            this.displayName = displayName;"); //197:1
            __out.AppendLine(); //197:44
            __out.Append("            this.background = background;"); //198:1
            __out.AppendLine(); //198:42
            __out.Append("            this.foreground = foreground;"); //199:1
            __out.AppendLine(); //199:42
            __out.Append("            if (bold)"); //201:1
            __out.AppendLine(); //201:22
            __out.Append("                this.fontFlags = this.fontFlags | (uint)FONTFLAGS.FF_BOLD;"); //202:1
            __out.AppendLine(); //202:75
            __out.Append("            if (strikethrough)"); //203:1
            __out.AppendLine(); //203:31
            __out.Append("                this.fontFlags = this.fontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //204:1
            __out.AppendLine(); //204:84
            __out.Append("        }"); //205:1
            __out.AppendLine(); //205:10
            __out.Append("        #region IVsColorableItem Members"); //207:1
            __out.AppendLine(); //207:41
            string __tmp55Prefix = "        public int GetDefaultColors(COLORINDEX"; //208:1
            string __tmp56Suffix = " piBackground)"; //208:84
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append("[]");
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_first = true;
                while(__tmp57_first || !__tmp57Reader.EndOfStream)
                {
                    __tmp57_first = false;
                    string __tmp57Line = __tmp57Reader.ReadLine();
                    if (__tmp57Line == null)
                    {
                        __tmp57Line = "";
                    }
                    __out.Append(__tmp55Prefix);
                    __out.Append(__tmp57Line);
                }
            }
            string __tmp58Line = " piForeground, COLORINDEX"; //208:53
            __out.Append(__tmp58Line);
            StringBuilder __tmp59 = new StringBuilder();
            __tmp59.Append("[]");
            using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
            {
                bool __tmp59_first = true;
                while(__tmp59_first || !__tmp59Reader.EndOfStream)
                {
                    __tmp59_first = false;
                    string __tmp59Line = __tmp59Reader.ReadLine();
                    if (__tmp59Line == null)
                    {
                        __tmp59Line = "";
                    }
                    __out.Append(__tmp59Line);
                    __out.Append(__tmp56Suffix);
                    __out.AppendLine(); //208:98
                }
            }
            __out.Append("        {"); //209:1
            __out.AppendLine(); //209:10
            __out.Append("            if (null == piForeground)"); //210:1
            __out.AppendLine(); //210:38
            __out.Append("            {"); //211:1
            __out.AppendLine(); //211:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //212:1
            __out.AppendLine(); //212:65
            __out.Append("            }"); //213:1
            __out.AppendLine(); //213:14
            __out.Append("            if (0 == piForeground.Length)"); //214:1
            __out.AppendLine(); //214:42
            __out.Append("            {"); //215:1
            __out.AppendLine(); //215:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //216:1
            __out.AppendLine(); //216:71
            __out.Append("            }"); //217:1
            __out.AppendLine(); //217:14
            string __tmp60Prefix = "            piForeground"; //218:1
            string __tmp61Suffix = " = foreground;"; //218:32
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append("[0]");
            using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
            {
                bool __tmp62_first = true;
                while(__tmp62_first || !__tmp62Reader.EndOfStream)
                {
                    __tmp62_first = false;
                    string __tmp62Line = __tmp62Reader.ReadLine();
                    if (__tmp62Line == null)
                    {
                        __tmp62Line = "";
                    }
                    __out.Append(__tmp60Prefix);
                    __out.Append(__tmp62Line);
                    __out.Append(__tmp61Suffix);
                    __out.AppendLine(); //218:46
                }
            }
            __out.Append("            if (null == piBackground)"); //220:1
            __out.AppendLine(); //220:38
            __out.Append("            {"); //221:1
            __out.AppendLine(); //221:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //222:1
            __out.AppendLine(); //222:65
            __out.Append("            }"); //223:1
            __out.AppendLine(); //223:14
            __out.Append("            if (0 == piBackground.Length)"); //224:1
            __out.AppendLine(); //224:42
            __out.Append("            {"); //225:1
            __out.AppendLine(); //225:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //226:1
            __out.AppendLine(); //226:71
            __out.Append("            }"); //227:1
            __out.AppendLine(); //227:14
            string __tmp63Prefix = "            piBackground"; //228:1
            string __tmp64Suffix = " = background;"; //228:32
            StringBuilder __tmp65 = new StringBuilder();
            __tmp65.Append("[0]");
            using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
            {
                bool __tmp65_first = true;
                while(__tmp65_first || !__tmp65Reader.EndOfStream)
                {
                    __tmp65_first = false;
                    string __tmp65Line = __tmp65Reader.ReadLine();
                    if (__tmp65Line == null)
                    {
                        __tmp65Line = "";
                    }
                    __out.Append(__tmp63Prefix);
                    __out.Append(__tmp65Line);
                    __out.Append(__tmp64Suffix);
                    __out.AppendLine(); //228:46
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //230:1
            __out.AppendLine(); //230:60
            __out.Append("        }"); //231:1
            __out.AppendLine(); //231:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //233:1
            __out.AppendLine(); //233:62
            __out.Append("        {"); //234:1
            __out.AppendLine(); //234:10
            __out.Append("            pdwFontFlags = this.fontFlags;"); //235:1
            __out.AppendLine(); //235:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //236:1
            __out.AppendLine(); //236:60
            __out.Append("        }"); //237:1
            __out.AppendLine(); //237:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //239:1
            __out.AppendLine(); //239:56
            __out.Append("        {"); //240:1
            __out.AppendLine(); //240:10
            __out.Append("            pbstrName = displayName;"); //241:1
            __out.AppendLine(); //241:37
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //242:1
            __out.AppendLine(); //242:60
            __out.Append("        }"); //243:1
            __out.AppendLine(); //243:10
            __out.Append("        #endregion"); //244:1
            __out.AppendLine(); //244:19
            __out.Append("    }"); //245:1
            __out.AppendLine(); //245:6
            string __tmp66Prefix = "    "; //247:1
            string __tmp67Suffix = string.Empty; 
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append("[ComVisible(true)]");
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_first = true;
                while(__tmp68_first || !__tmp68Reader.EndOfStream)
                {
                    __tmp68_first = false;
                    string __tmp68Line = __tmp68Reader.ReadLine();
                    if (__tmp68Line == null)
                    {
                        __tmp68Line = "";
                    }
                    __out.Append(__tmp66Prefix);
                    __out.Append(__tmp68Line);
                    __out.Append(__tmp67Suffix);
                    __out.AppendLine(); //247:27
                }
            }
            string __tmp69Prefix = "    "; //248:1
            string __tmp70Suffix = string.Empty; 
            StringBuilder __tmp71 = new StringBuilder();
            __tmp71.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageGeneratorServiceGuid)]");
            using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
            {
                bool __tmp71_first = true;
                while(__tmp71_first || !__tmp71Reader.EndOfStream)
                {
                    __tmp71_first = false;
                    string __tmp71Line = __tmp71Reader.ReadLine();
                    if (__tmp71Line == null)
                    {
                        __tmp71Line = "";
                    }
                    __out.Append(__tmp69Prefix);
                    __out.Append(__tmp71Line);
                    __out.Append(__tmp70Suffix);
                    __out.AppendLine(); //248:124
                }
            }
            if (Properties.GenerateMultipleFiles) //249:3
            {
                string __tmp72Prefix = "    public class "; //250:1
                string __tmp73Suffix = "LanguageGeneratorService : VsMultipleFileGenerator<object>"; //250:48
                StringBuilder __tmp74 = new StringBuilder();
                __tmp74.Append(Properties.LanguageClassName);
                using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                {
                    bool __tmp74_first = true;
                    while(__tmp74_first || !__tmp74Reader.EndOfStream)
                    {
                        __tmp74_first = false;
                        string __tmp74Line = __tmp74Reader.ReadLine();
                        if (__tmp74Line == null)
                        {
                            __tmp74Line = "";
                        }
                        __out.Append(__tmp72Prefix);
                        __out.Append(__tmp74Line);
                        __out.Append(__tmp73Suffix);
                        __out.AppendLine(); //250:106
                    }
                }
                __out.Append("    {"); //251:1
                __out.AppendLine(); //251:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //252:1
                __out.AppendLine(); //252:146
                __out.Append("		{"); //253:1
                __out.AppendLine(); //253:4
                string __tmp75Prefix = "            // If there is a compile error in the following line, create a class "; //254:1
                string __tmp76Suffix = "Generator"; //254:112
                StringBuilder __tmp77 = new StringBuilder();
                __tmp77.Append(Properties.LanguageClassName);
                using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                {
                    bool __tmp77_first = true;
                    while(__tmp77_first || !__tmp77Reader.EndOfStream)
                    {
                        __tmp77_first = false;
                        string __tmp77Line = __tmp77Reader.ReadLine();
                        if (__tmp77Line == null)
                        {
                            __tmp77Line = "";
                        }
                        __out.Append(__tmp75Prefix);
                        __out.Append(__tmp77Line);
                        __out.Append(__tmp76Suffix);
                        __out.AppendLine(); //254:121
                    }
                }
                __out.Append("            // which is a subclass of MultipleFileGenerator<object>"); //255:1
                __out.AppendLine(); //255:68
                string __tmp78Prefix = "			return new "; //256:1
                string __tmp79Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //256:45
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(Properties.LanguageClassName);
                using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                {
                    bool __tmp80_first = true;
                    while(__tmp80_first || !__tmp80Reader.EndOfStream)
                    {
                        __tmp80_first = false;
                        string __tmp80Line = __tmp80Reader.ReadLine();
                        if (__tmp80Line == null)
                        {
                            __tmp80Line = "";
                        }
                        __out.Append(__tmp78Prefix);
                        __out.Append(__tmp80Line);
                        __out.Append(__tmp79Suffix);
                        __out.AppendLine(); //256:107
                    }
                }
                __out.Append("		}"); //257:1
                __out.AppendLine(); //257:4
                __out.Append("    }"); //258:1
                __out.AppendLine(); //258:6
            }
            else //259:3
            {
                string __tmp81Prefix = "    public class "; //260:1
                string __tmp82Suffix = "LanguageGeneratorService : VsSingleFileGenerator"; //260:48
                StringBuilder __tmp83 = new StringBuilder();
                __tmp83.Append(Properties.LanguageClassName);
                using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                {
                    bool __tmp83_first = true;
                    while(__tmp83_first || !__tmp83Reader.EndOfStream)
                    {
                        __tmp83_first = false;
                        string __tmp83Line = __tmp83Reader.ReadLine();
                        if (__tmp83Line == null)
                        {
                            __tmp83Line = "";
                        }
                        __out.Append(__tmp81Prefix);
                        __out.Append(__tmp83Line);
                        __out.Append(__tmp82Suffix);
                        __out.AppendLine(); //260:96
                    }
                }
                __out.Append("    {"); //261:1
                __out.AppendLine(); //261:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //262:1
                __out.AppendLine(); //262:136
                __out.Append("		{"); //263:1
                __out.AppendLine(); //263:4
                string __tmp84Prefix = "            // If there is a compile error in the following line, create a class "; //264:1
                string __tmp85Suffix = "Generator"; //264:112
                StringBuilder __tmp86 = new StringBuilder();
                __tmp86.Append(Properties.LanguageClassName);
                using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                {
                    bool __tmp86_first = true;
                    while(__tmp86_first || !__tmp86Reader.EndOfStream)
                    {
                        __tmp86_first = false;
                        string __tmp86Line = __tmp86Reader.ReadLine();
                        if (__tmp86Line == null)
                        {
                            __tmp86Line = "";
                        }
                        __out.Append(__tmp84Prefix);
                        __out.Append(__tmp86Line);
                        __out.Append(__tmp85Suffix);
                        __out.AppendLine(); //264:121
                    }
                }
                __out.Append("            // which is a subclass of SingleFileGenerator"); //265:1
                __out.AppendLine(); //265:58
                string __tmp87Prefix = "			return new "; //266:1
                string __tmp88Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //266:45
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(Properties.LanguageClassName);
                using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                {
                    bool __tmp89_first = true;
                    while(__tmp89_first || !__tmp89Reader.EndOfStream)
                    {
                        __tmp89_first = false;
                        string __tmp89Line = __tmp89Reader.ReadLine();
                        if (__tmp89Line == null)
                        {
                            __tmp89Line = "";
                        }
                        __out.Append(__tmp87Prefix);
                        __out.Append(__tmp89Line);
                        __out.Append(__tmp88Suffix);
                        __out.AppendLine(); //266:107
                    }
                }
                __out.Append("		}"); //267:1
                __out.AppendLine(); //267:4
                __out.Append("    }"); //268:1
                __out.AppendLine(); //268:6
            }
            string __tmp90Prefix = "    public class "; //272:1
            string __tmp91Suffix = "LanguageScanner : IScanner"; //272:48
            StringBuilder __tmp92 = new StringBuilder();
            __tmp92.Append(Properties.LanguageClassName);
            using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
            {
                bool __tmp92_first = true;
                while(__tmp92_first || !__tmp92Reader.EndOfStream)
                {
                    __tmp92_first = false;
                    string __tmp92Line = __tmp92Reader.ReadLine();
                    if (__tmp92Line == null)
                    {
                        __tmp92Line = "";
                    }
                    __out.Append(__tmp90Prefix);
                    __out.Append(__tmp92Line);
                    __out.Append(__tmp91Suffix);
                    __out.AppendLine(); //272:74
                }
            }
            __out.Append("    {"); //273:1
            __out.AppendLine(); //273:6
            __out.Append("        private int currentOffset;"); //274:1
            __out.AppendLine(); //274:35
            __out.Append("        private string currentLine;"); //275:1
            __out.AppendLine(); //275:36
            string __tmp93Prefix = "        private "; //276:1
            string __tmp94Suffix = "Lexer lexer;"; //276:46
            StringBuilder __tmp95 = new StringBuilder();
            __tmp95.Append(Properties.LanguageFullName);
            using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
            {
                bool __tmp95_first = true;
                while(__tmp95_first || !__tmp95Reader.EndOfStream)
                {
                    __tmp95_first = false;
                    string __tmp95Line = __tmp95Reader.ReadLine();
                    if (__tmp95Line == null)
                    {
                        __tmp95Line = "";
                    }
                    __out.Append(__tmp93Prefix);
                    __out.Append(__tmp95Line);
                    __out.Append(__tmp94Suffix);
                    __out.AppendLine(); //276:58
                }
            }
            __out.Append("        private IEnumerable<SyntaxAnnotation> modeAnnotations;"); //277:1
            __out.AppendLine(); //277:63
            __out.Append("        private IEnumerable<SyntaxAnnotation> syntaxAnnotations;"); //278:1
            __out.AppendLine(); //278:65
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //279:1
            __out.AppendLine(); //279:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //280:1
            __out.AppendLine(); //280:62
            __out.Append("        private int lastState;"); //281:1
            __out.AppendLine(); //281:31
            string __tmp96Prefix = "        public "; //283:1
            string __tmp97Suffix = "LanguageScanner()"; //283:46
            StringBuilder __tmp98 = new StringBuilder();
            __tmp98.Append(Properties.LanguageClassName);
            using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
            {
                bool __tmp98_first = true;
                while(__tmp98_first || !__tmp98Reader.EndOfStream)
                {
                    __tmp98_first = false;
                    string __tmp98Line = __tmp98Reader.ReadLine();
                    if (__tmp98Line == null)
                    {
                        __tmp98Line = "";
                    }
                    __out.Append(__tmp96Prefix);
                    __out.Append(__tmp98Line);
                    __out.Append(__tmp97Suffix);
                    __out.AppendLine(); //283:63
                }
            }
            __out.Append("        {"); //284:1
            __out.AppendLine(); //284:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //285:1
            __out.AppendLine(); //285:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //286:1
            __out.AppendLine(); //286:71
            __out.Append("            this.lastState = 0;"); //287:1
            __out.AppendLine(); //287:32
            string __tmp99Prefix = "            "; //288:1
            string __tmp100Suffix = "LexerAnnotator();"; //288:102
            StringBuilder __tmp101 = new StringBuilder();
            __tmp101.Append(Properties.LanguageFullName);
            using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
            {
                bool __tmp101_first = true;
                while(__tmp101_first || !__tmp101Reader.EndOfStream)
                {
                    __tmp101_first = false;
                    string __tmp101Line = __tmp101Reader.ReadLine();
                    if (__tmp101Line == null)
                    {
                        __tmp101Line = "";
                    }
                    __out.Append(__tmp99Prefix);
                    __out.Append(__tmp101Line);
                }
            }
            string __tmp102Line = "LexerAnnotator annotator = new "; //288:42
            __out.Append(__tmp102Line);
            StringBuilder __tmp103 = new StringBuilder();
            __tmp103.Append(Properties.LanguageFullName);
            using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
            {
                bool __tmp103_first = true;
                while(__tmp103_first || !__tmp103Reader.EndOfStream)
                {
                    __tmp103_first = false;
                    string __tmp103Line = __tmp103Reader.ReadLine();
                    if (__tmp103Line == null)
                    {
                        __tmp103Line = "";
                    }
                    __out.Append(__tmp103Line);
                    __out.Append(__tmp100Suffix);
                    __out.AppendLine(); //288:119
                }
            }
            __out.Append("            List<SyntaxAnnotation> mal = new List<SyntaxAnnotation>();"); //289:1
            __out.AppendLine(); //289:71
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //290:1
            __out.AppendLine(); //290:72
            __out.Append("            {"); //291:1
            __out.AppendLine(); //291:14
            __out.Append("                foreach (var annot in annotList)"); //292:1
            __out.AppendLine(); //292:49
            __out.Append("                {"); //293:1
            __out.AppendLine(); //293:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //294:1
            __out.AppendLine(); //294:51
            __out.Append("                    {"); //295:1
            __out.AppendLine(); //295:22
            __out.Append("                        mal.Add((SyntaxAnnotation)annot);"); //296:1
            __out.AppendLine(); //296:58
            __out.Append("                    }"); //297:1
            __out.AppendLine(); //297:22
            __out.Append("                }"); //298:1
            __out.AppendLine(); //298:18
            __out.Append("            }"); //299:1
            __out.AppendLine(); //299:14
            __out.Append("            this.modeAnnotations = mal;"); //300:1
            __out.AppendLine(); //300:40
            __out.Append("            List<SyntaxAnnotation> sal = new List<SyntaxAnnotation>();"); //301:1
            __out.AppendLine(); //301:71
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //302:1
            __out.AppendLine(); //302:73
            __out.Append("            {"); //303:1
            __out.AppendLine(); //303:14
            __out.Append("                foreach (var annot in annotList)"); //304:1
            __out.AppendLine(); //304:49
            __out.Append("                {"); //305:1
            __out.AppendLine(); //305:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //306:1
            __out.AppendLine(); //306:51
            __out.Append("                    {"); //307:1
            __out.AppendLine(); //307:22
            __out.Append("                        sal.Add((SyntaxAnnotation)annot);"); //308:1
            __out.AppendLine(); //308:58
            __out.Append("                    }"); //309:1
            __out.AppendLine(); //309:22
            __out.Append("                }"); //310:1
            __out.AppendLine(); //310:18
            __out.Append("            }"); //311:1
            __out.AppendLine(); //311:14
            __out.Append("            this.syntaxAnnotations = sal;"); //312:1
            __out.AppendLine(); //312:42
            __out.Append("        }"); //313:1
            __out.AppendLine(); //313:10
            string __tmp104Prefix = "        private void LoadState(int state, "; //315:1
            string __tmp105Suffix = "Lexer lexer)"; //315:72
            StringBuilder __tmp106 = new StringBuilder();
            __tmp106.Append(Properties.LanguageFullName);
            using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
            {
                bool __tmp106_first = true;
                while(__tmp106_first || !__tmp106Reader.EndOfStream)
                {
                    __tmp106_first = false;
                    string __tmp106Line = __tmp106Reader.ReadLine();
                    if (__tmp106Line == null)
                    {
                        __tmp106Line = "";
                    }
                    __out.Append(__tmp104Prefix);
                    __out.Append(__tmp106Line);
                    __out.Append(__tmp105Suffix);
                    __out.AppendLine(); //315:84
                }
            }
            __out.Append("        {"); //316:1
            __out.AppendLine(); //316:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //317:1
            __out.AppendLine(); //317:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //318:1
            __out.AppendLine(); //318:55
            __out.Append("            value.Restore(lexer);"); //319:1
            __out.AppendLine(); //319:34
            __out.Append("        }"); //320:1
            __out.AppendLine(); //320:10
            string __tmp107Prefix = "        private int SaveState("; //322:1
            string __tmp108Suffix = "Lexer lexer)"; //322:60
            StringBuilder __tmp109 = new StringBuilder();
            __tmp109.Append(Properties.LanguageFullName);
            using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
            {
                bool __tmp109_first = true;
                while(__tmp109_first || !__tmp109Reader.EndOfStream)
                {
                    __tmp109_first = false;
                    string __tmp109Line = __tmp109Reader.ReadLine();
                    if (__tmp109Line == null)
                    {
                        __tmp109Line = "";
                    }
                    __out.Append(__tmp107Prefix);
                    __out.Append(__tmp109Line);
                    __out.Append(__tmp108Suffix);
                    __out.AppendLine(); //322:72
                }
            }
            __out.Append("        {"); //323:1
            __out.AppendLine(); //323:10
            __out.Append("            int result = 0;"); //324:1
            __out.AppendLine(); //324:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //325:1
            __out.AppendLine(); //325:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //326:1
            __out.AppendLine(); //326:68
            __out.Append("            {"); //327:1
            __out.AppendLine(); //327:14
            __out.Append("                result = ++lastState;"); //328:1
            __out.AppendLine(); //328:38
            __out.Append("                this.states.Add(result, state);"); //329:1
            __out.AppendLine(); //329:48
            __out.Append("                this.inverseStates.Add(state, result);"); //330:1
            __out.AppendLine(); //330:55
            __out.Append("            }"); //331:1
            __out.AppendLine(); //331:14
            __out.Append("            return result;"); //332:1
            __out.AppendLine(); //332:27
            __out.Append("        }"); //333:1
            __out.AppendLine(); //333:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //335:1
            __out.AppendLine(); //335:87
            __out.Append("        {"); //336:1
            __out.AppendLine(); //336:10
            __out.Append("            try"); //337:1
            __out.AppendLine(); //337:16
            __out.Append("            {"); //338:1
            __out.AppendLine(); //338:14
            __out.Append("                if (this.lexer == null)"); //339:1
            __out.AppendLine(); //339:40
            __out.Append("                {"); //340:1
            __out.AppendLine(); //340:18
            string __tmp110Prefix = "                    this.lexer = new "; //341:1
            string __tmp111Suffix = "n\"));"; //341:117
            StringBuilder __tmp112 = new StringBuilder();
            __tmp112.Append(Properties.LanguageFullName);
            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
            {
                bool __tmp112_first = true;
                while(__tmp112_first || !__tmp112Reader.EndOfStream)
                {
                    __tmp112_first = false;
                    string __tmp112Line = __tmp112Reader.ReadLine();
                    if (__tmp112Line == null)
                    {
                        __tmp112Line = "";
                    }
                    __out.Append(__tmp110Prefix);
                    __out.Append(__tmp112Line);
                }
            }
            string __tmp113Line = "Lexer(new AntlrInputStream(this.currentLine + \""; //341:67
            __out.Append(__tmp113Line);
            string __tmp114Line = "\\"; //341:114
            __out.Append(__tmp114Line);
            string __tmp115Line = "r"; //341:115
            __out.Append(__tmp115Line);
            string __tmp116Line = "\\"; //341:116
            __out.Append(__tmp116Line);
            __out.Append(__tmp111Suffix);
            __out.AppendLine(); //341:122
            __out.Append("                }"); //342:1
            __out.AppendLine(); //342:18
            __out.Append("                this.LoadState(state, this.lexer);"); //343:1
            __out.AppendLine(); //343:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //344:1
            __out.AppendLine(); //344:55
            __out.Append("                tokenInfo.Token = token.Type;"); //345:1
            __out.AppendLine(); //345:46
            __out.Append("                tokenInfo.Type = TokenType.Text;"); //346:1
            __out.AppendLine(); //346:49
            __out.Append("                tokenInfo.Color = TokenColor.Text;"); //347:1
            __out.AppendLine(); //347:51
            __out.Append("                tokenInfo.Trigger = TokenTriggers.None;"); //348:1
            __out.AppendLine(); //348:56
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //350:1
            __out.AppendLine(); //350:64
            __out.Append("                {"); //351:1
            __out.AppendLine(); //351:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //352:1
            __out.AppendLine(); //352:111
            __out.Append("                    {"); //353:1
            __out.AppendLine(); //353:22
            __out.Append("                        tokenInfo.Type = ToTokenType(modeAnnot.Kind);"); //354:1
            __out.AppendLine(); //354:70
            __out.Append("                        tokenInfo.Color = ToTokenColor(modeAnnot.Kind);"); //355:1
            __out.AppendLine(); //355:72
            __out.Append("                        tokenInfo.Trigger = TokenTriggers.None;"); //356:1
            __out.AppendLine(); //356:64
            __out.Append("                        break;"); //357:1
            __out.AppendLine(); //357:31
            __out.Append("                    }"); //358:1
            __out.AppendLine(); //358:22
            __out.Append("                }"); //359:1
            __out.AppendLine(); //359:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //360:1
            __out.AppendLine(); //360:68
            __out.Append("                {"); //361:1
            __out.AppendLine(); //361:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //362:1
            __out.AppendLine(); //362:91
            __out.Append("                    {"); //363:1
            __out.AppendLine(); //363:22
            __out.Append("                        tokenInfo.Type = ToTokenType(syntaxAnnot.Kind);"); //364:1
            __out.AppendLine(); //364:72
            __out.Append("                        tokenInfo.Color = ToTokenColor(syntaxAnnot.Kind);"); //365:1
            __out.AppendLine(); //365:74
            __out.Append("                        tokenInfo.Trigger = TokenTriggers.None;"); //366:1
            __out.AppendLine(); //366:64
            __out.Append("                        break;"); //367:1
            __out.AppendLine(); //367:31
            __out.Append("                    }"); //368:1
            __out.AppendLine(); //368:22
            __out.Append("                }"); //369:1
            __out.AppendLine(); //369:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //371:1
            __out.AppendLine(); //371:103
            __out.Append("                {"); //372:1
            __out.AppendLine(); //372:18
            __out.Append("                    return false;"); //373:1
            __out.AppendLine(); //373:34
            __out.Append("                }"); //374:1
            __out.AppendLine(); //374:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //375:1
            __out.AppendLine(); //375:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //376:1
            __out.AppendLine(); //376:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //377:1
            __out.AppendLine(); //377:61
            __out.Append("                state = this.SaveState(lexer);"); //378:1
            __out.AppendLine(); //378:47
            __out.Append("                return true;"); //379:1
            __out.AppendLine(); //379:29
            __out.Append("            }"); //380:1
            __out.AppendLine(); //380:14
            __out.Append("            catch (Exception)"); //381:1
            __out.AppendLine(); //381:30
            __out.Append("            {"); //382:1
            __out.AppendLine(); //382:14
            __out.Append("                return false;"); //383:1
            __out.AppendLine(); //383:30
            __out.Append("            }"); //384:1
            __out.AppendLine(); //384:14
            __out.Append("        }"); //385:1
            __out.AppendLine(); //385:10
            __out.Append("        private TokenType ToTokenType(int kind)"); //387:1
            __out.AppendLine(); //387:48
            __out.Append("        {"); //388:1
            __out.AppendLine(); //388:10
            __out.Append("			return (TokenType)kind;"); //389:1
            __out.AppendLine(); //389:27
            __out.Append("        }"); //390:1
            __out.AppendLine(); //390:10
            __out.Append("        private TokenColor ToTokenColor(int kind)"); //392:1
            __out.AppendLine(); //392:50
            __out.Append("        {"); //393:1
            __out.AppendLine(); //393:10
            __out.Append("			return (TokenColor)kind;"); //394:1
            __out.AppendLine(); //394:28
            __out.Append("        }"); //395:1
            __out.AppendLine(); //395:10
            __out.Append("        public void SetSource(string source, int offset)"); //397:1
            __out.AppendLine(); //397:57
            __out.Append("        {"); //398:1
            __out.AppendLine(); //398:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //399:1
            __out.AppendLine(); //399:78
            __out.Append("            {"); //400:1
            __out.AppendLine(); //400:14
            __out.Append("                this.currentOffset = offset;"); //401:1
            __out.AppendLine(); //401:45
            __out.Append("                this.currentLine = source;"); //402:1
            __out.AppendLine(); //402:43
            __out.Append("                this.lexer = null;"); //403:1
            __out.AppendLine(); //403:35
            __out.Append("            }"); //404:1
            __out.AppendLine(); //404:14
            __out.Append("        }"); //405:1
            __out.AppendLine(); //405:10
            __out.Append("        internal void ScanLine(ref int state)"); //406:1
            __out.AppendLine(); //406:46
            __out.Append("        {"); //407:1
            __out.AppendLine(); //407:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //408:1
            __out.AppendLine(); //408:86
            __out.Append("        }"); //409:1
            __out.AppendLine(); //409:10
            __out.Append("        internal struct LanguageScannerState"); //411:1
            __out.AppendLine(); //411:45
            __out.Append("        {"); //412:1
            __out.AppendLine(); //412:10
            string __tmp117Prefix = "            public LanguageScannerState("; //413:1
            string __tmp118Suffix = "Lexer lexer)"; //413:70
            StringBuilder __tmp119 = new StringBuilder();
            __tmp119.Append(Properties.LanguageFullName);
            using(StreamReader __tmp119Reader = new StreamReader(this.__ToStream(__tmp119.ToString())))
            {
                bool __tmp119_first = true;
                while(__tmp119_first || !__tmp119Reader.EndOfStream)
                {
                    __tmp119_first = false;
                    string __tmp119Line = __tmp119Reader.ReadLine();
                    if (__tmp119Line == null)
                    {
                        __tmp119Line = "";
                    }
                    __out.Append(__tmp117Prefix);
                    __out.Append(__tmp119Line);
                    __out.Append(__tmp118Suffix);
                    __out.AppendLine(); //413:82
                }
            }
            __out.Append("            {"); //414:1
            __out.AppendLine(); //414:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //415:1
            __out.AppendLine(); //415:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //416:1
            __out.AppendLine(); //416:101
            __out.Append("                this._type = lexer.Type;"); //417:1
            __out.AppendLine(); //417:41
            __out.Append("                this._channel = lexer.Channel;"); //418:1
            __out.AppendLine(); //418:47
            __out.Append("                this._state = lexer.State;"); //419:1
            __out.AppendLine(); //419:43
            __out.Append("            }"); //420:1
            __out.AppendLine(); //420:14
            __out.Append("            internal int _state;"); //422:1
            __out.AppendLine(); //422:33
            __out.Append("            internal int _mode;"); //423:1
            __out.AppendLine(); //423:32
            __out.Append("            internal List<int> _modeStack;"); //424:1
            __out.AppendLine(); //424:43
            __out.Append("            internal int _type;"); //425:1
            __out.AppendLine(); //425:32
            __out.Append("            internal int _channel;"); //426:1
            __out.AppendLine(); //426:35
            string __tmp120Prefix = "            public void Restore("; //428:1
            string __tmp121Suffix = "Lexer lexer)"; //428:62
            StringBuilder __tmp122 = new StringBuilder();
            __tmp122.Append(Properties.LanguageFullName);
            using(StreamReader __tmp122Reader = new StreamReader(this.__ToStream(__tmp122.ToString())))
            {
                bool __tmp122_first = true;
                while(__tmp122_first || !__tmp122Reader.EndOfStream)
                {
                    __tmp122_first = false;
                    string __tmp122Line = __tmp122Reader.ReadLine();
                    if (__tmp122Line == null)
                    {
                        __tmp122Line = "";
                    }
                    __out.Append(__tmp120Prefix);
                    __out.Append(__tmp122Line);
                    __out.Append(__tmp121Suffix);
                    __out.AppendLine(); //428:74
                }
            }
            __out.Append("            {"); //429:1
            __out.AppendLine(); //429:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //430:1
            __out.AppendLine(); //430:48
            __out.Append("                lexer.ModeStack.Clear();"); //431:1
            __out.AppendLine(); //431:41
            __out.Append("                if (this._modeStack != null)"); //432:1
            __out.AppendLine(); //432:45
            __out.Append("                {"); //433:1
            __out.AppendLine(); //433:18
            __out.Append("                    foreach (var item in this._modeStack)"); //434:1
            __out.AppendLine(); //434:58
            __out.Append("                    {"); //435:1
            __out.AppendLine(); //435:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //436:1
            __out.AppendLine(); //436:52
            __out.Append("                    }"); //437:1
            __out.AppendLine(); //437:22
            __out.Append("                }"); //438:1
            __out.AppendLine(); //438:18
            __out.Append("                lexer.Type = this._type;"); //439:1
            __out.AppendLine(); //439:41
            __out.Append("                lexer.Channel = this._channel;"); //440:1
            __out.AppendLine(); //440:47
            __out.Append("                lexer.State = this._state;"); //441:1
            __out.AppendLine(); //441:43
            __out.Append("            }"); //442:1
            __out.AppendLine(); //442:14
            __out.Append("            public override bool Equals(object obj)"); //444:1
            __out.AppendLine(); //444:52
            __out.Append("            {"); //445:1
            __out.AppendLine(); //445:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //446:1
            __out.AppendLine(); //446:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //447:1
            __out.AppendLine(); //447:59
            __out.Append("                if (rhs._type != this._type) return false;"); //448:1
            __out.AppendLine(); //448:59
            __out.Append("                if (rhs._state != this._state) return false;"); //449:1
            __out.AppendLine(); //449:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //450:1
            __out.AppendLine(); //450:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //451:1
            __out.AppendLine(); //451:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //452:1
            __out.AppendLine(); //452:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //453:1
            __out.AppendLine(); //453:71
            __out.Append("                {"); //454:1
            __out.AppendLine(); //454:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //455:1
            __out.AppendLine(); //455:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //456:1
            __out.AppendLine(); //456:67
            __out.Append("                    {"); //457:1
            __out.AppendLine(); //457:22
            string __tmp123Prefix = "                        if (rhs._modeStack"; //458:1
            string __tmp124Suffix = ") return false;"; //458:76
            StringBuilder __tmp125 = new StringBuilder();
            __tmp125.Append("[i]");
            using(StreamReader __tmp125Reader = new StreamReader(this.__ToStream(__tmp125.ToString())))
            {
                bool __tmp125_first = true;
                while(__tmp125_first || !__tmp125Reader.EndOfStream)
                {
                    __tmp125_first = false;
                    string __tmp125Line = __tmp125Reader.ReadLine();
                    if (__tmp125Line == null)
                    {
                        __tmp125Line = "";
                    }
                    __out.Append(__tmp123Prefix);
                    __out.Append(__tmp125Line);
                }
            }
            string __tmp126Line = " != this._modeStack"; //458:50
            __out.Append(__tmp126Line);
            StringBuilder __tmp127 = new StringBuilder();
            __tmp127.Append("[i]");
            using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
            {
                bool __tmp127_first = true;
                while(__tmp127_first || !__tmp127Reader.EndOfStream)
                {
                    __tmp127_first = false;
                    string __tmp127Line = __tmp127Reader.ReadLine();
                    if (__tmp127Line == null)
                    {
                        __tmp127Line = "";
                    }
                    __out.Append(__tmp127Line);
                    __out.Append(__tmp124Suffix);
                    __out.AppendLine(); //458:91
                }
            }
            __out.Append("                    }"); //459:1
            __out.AppendLine(); //459:22
            __out.Append("                }"); //460:1
            __out.AppendLine(); //460:18
            __out.Append("                return true;"); //461:1
            __out.AppendLine(); //461:29
            __out.Append("            }"); //462:1
            __out.AppendLine(); //462:14
            __out.Append("            public override int GetHashCode()"); //464:1
            __out.AppendLine(); //464:46
            __out.Append("            {"); //465:1
            __out.AppendLine(); //465:14
            __out.Append("                int result = 0;"); //466:1
            __out.AppendLine(); //466:32
            __out.Append("                result "); //467:1
            __out.Append("^"); //467:24
            __out.Append("= this._mode.GetHashCode();"); //467:25
            __out.AppendLine(); //467:52
            __out.Append("                result "); //468:1
            __out.Append("^"); //468:24
            __out.Append("= this._type.GetHashCode();"); //468:25
            __out.AppendLine(); //468:52
            __out.Append("                result "); //469:1
            __out.Append("^"); //469:24
            __out.Append("= this._state.GetHashCode();"); //469:25
            __out.AppendLine(); //469:53
            __out.Append("                result "); //470:1
            __out.Append("^"); //470:24
            __out.Append("= this._channel.GetHashCode();"); //470:25
            __out.AppendLine(); //470:55
            __out.Append("                if (this._modeStack != null)"); //471:1
            __out.AppendLine(); //471:45
            __out.Append("                {"); //472:1
            __out.AppendLine(); //472:18
            __out.Append("                    result "); //473:1
            __out.Append("^"); //473:28
            __out.Append("= this._modeStack.GetHashCode();"); //473:29
            __out.AppendLine(); //473:61
            __out.Append("                }"); //474:1
            __out.AppendLine(); //474:18
            __out.Append("                return result;"); //475:1
            __out.AppendLine(); //475:31
            __out.Append("            }"); //476:1
            __out.AppendLine(); //476:14
            __out.Append("        }"); //477:1
            __out.AppendLine(); //477:10
            __out.Append("    }"); //478:1
            __out.AppendLine(); //478:6
            string __tmp128Prefix = "    "; //480:1
            string __tmp129Suffix = string.Empty; 
            StringBuilder __tmp130 = new StringBuilder();
            __tmp130.Append("[ComVisible(true)]");
            using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
            {
                bool __tmp130_first = true;
                while(__tmp130_first || !__tmp130Reader.EndOfStream)
                {
                    __tmp130_first = false;
                    string __tmp130Line = __tmp130Reader.ReadLine();
                    if (__tmp130Line == null)
                    {
                        __tmp130Line = "";
                    }
                    __out.Append(__tmp128Prefix);
                    __out.Append(__tmp130Line);
                    __out.Append(__tmp129Suffix);
                    __out.AppendLine(); //480:27
                }
            }
            string __tmp131Prefix = "    "; //481:1
            string __tmp132Suffix = string.Empty; 
            StringBuilder __tmp133 = new StringBuilder();
            __tmp133.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
            using(StreamReader __tmp133Reader = new StreamReader(this.__ToStream(__tmp133.ToString())))
            {
                bool __tmp133_first = true;
                while(__tmp133_first || !__tmp133Reader.EndOfStream)
                {
                    __tmp133_first = false;
                    string __tmp133Line = __tmp133Reader.ReadLine();
                    if (__tmp133Line == null)
                    {
                        __tmp133Line = "";
                    }
                    __out.Append(__tmp131Prefix);
                    __out.Append(__tmp133Line);
                    __out.Append(__tmp132Suffix);
                    __out.AppendLine(); //481:115
                }
            }
            string __tmp134Prefix = "    public class "; //482:1
            string __tmp135Suffix = "LanguageService : LanguageService"; //482:48
            StringBuilder __tmp136 = new StringBuilder();
            __tmp136.Append(Properties.LanguageClassName);
            using(StreamReader __tmp136Reader = new StreamReader(this.__ToStream(__tmp136.ToString())))
            {
                bool __tmp136_first = true;
                while(__tmp136_first || !__tmp136Reader.EndOfStream)
                {
                    __tmp136_first = false;
                    string __tmp136Line = __tmp136Reader.ReadLine();
                    if (__tmp136Line == null)
                    {
                        __tmp136Line = "";
                    }
                    __out.Append(__tmp134Prefix);
                    __out.Append(__tmp136Line);
                    __out.Append(__tmp135Suffix);
                    __out.AppendLine(); //482:81
                }
            }
            __out.Append("    {"); //483:1
            __out.AppendLine(); //483:6
            __out.Append("        private LanguagePreferences preferences;"); //484:1
            __out.AppendLine(); //484:49
            string __tmp137Prefix = "        private "; //485:1
            string __tmp138Suffix = "LanguageScanner scanner;"; //485:47
            StringBuilder __tmp139 = new StringBuilder();
            __tmp139.Append(Properties.LanguageClassName);
            using(StreamReader __tmp139Reader = new StreamReader(this.__ToStream(__tmp139.ToString())))
            {
                bool __tmp139_first = true;
                while(__tmp139_first || !__tmp139Reader.EndOfStream)
                {
                    __tmp139_first = false;
                    string __tmp139Line = __tmp139Reader.ReadLine();
                    if (__tmp139Line == null)
                    {
                        __tmp139Line = "";
                    }
                    __out.Append(__tmp137Prefix);
                    __out.Append(__tmp139Line);
                    __out.Append(__tmp138Suffix);
                    __out.AppendLine(); //485:71
                }
            }
            string __tmp140Prefix = "        public "; //487:1
            string __tmp141Suffix = "LanguageService()"; //487:46
            StringBuilder __tmp142 = new StringBuilder();
            __tmp142.Append(Properties.LanguageClassName);
            using(StreamReader __tmp142Reader = new StreamReader(this.__ToStream(__tmp142.ToString())))
            {
                bool __tmp142_first = true;
                while(__tmp142_first || !__tmp142Reader.EndOfStream)
                {
                    __tmp142_first = false;
                    string __tmp142Line = __tmp142Reader.ReadLine();
                    if (__tmp142Line == null)
                    {
                        __tmp142Line = "";
                    }
                    __out.Append(__tmp140Prefix);
                    __out.Append(__tmp142Line);
                    __out.Append(__tmp141Suffix);
                    __out.AppendLine(); //487:63
                }
            }
            __out.Append("        {"); //488:1
            __out.AppendLine(); //488:10
            __out.Append("			// Creating the config instance"); //489:1
            __out.AppendLine(); //489:35
            string __tmp143Prefix = "			"; //490:1
            string __tmp144Suffix = "LanguageConfigBase.Instance.ToString();"; //490:34
            StringBuilder __tmp145 = new StringBuilder();
            __tmp145.Append(Properties.LanguageClassName);
            using(StreamReader __tmp145Reader = new StreamReader(this.__ToStream(__tmp145.ToString())))
            {
                bool __tmp145_first = true;
                while(__tmp145_first || !__tmp145Reader.EndOfStream)
                {
                    __tmp145_first = false;
                    string __tmp145Line = __tmp145Reader.ReadLine();
                    if (__tmp145Line == null)
                    {
                        __tmp145Line = "";
                    }
                    __out.Append(__tmp143Prefix);
                    __out.Append(__tmp145Line);
                    __out.Append(__tmp144Suffix);
                    __out.AppendLine(); //490:73
                }
            }
            __out.Append("        }"); //491:1
            __out.AppendLine(); //491:10
            __out.Append("        public override string GetFormatFilterList()"); //493:1
            __out.AppendLine(); //493:53
            __out.Append("        {"); //494:1
            __out.AppendLine(); //494:10
            string __tmp146Prefix = "            return "; //495:1
            string __tmp147Suffix = "LanguageConfig.FilterList;"; //495:50
            StringBuilder __tmp148 = new StringBuilder();
            __tmp148.Append(Properties.LanguageClassName);
            using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
            {
                bool __tmp148_first = true;
                while(__tmp148_first || !__tmp148Reader.EndOfStream)
                {
                    __tmp148_first = false;
                    string __tmp148Line = __tmp148Reader.ReadLine();
                    if (__tmp148Line == null)
                    {
                        __tmp148Line = "";
                    }
                    __out.Append(__tmp146Prefix);
                    __out.Append(__tmp148Line);
                    __out.Append(__tmp147Suffix);
                    __out.AppendLine(); //495:76
                }
            }
            __out.Append("        }"); //496:1
            __out.AppendLine(); //496:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //498:1
            __out.AppendLine(); //498:69
            __out.Append("        {"); //499:1
            __out.AppendLine(); //499:10
            __out.Append("            if (preferences == null)"); //500:1
            __out.AppendLine(); //500:37
            __out.Append("            {"); //501:1
            __out.AppendLine(); //501:14
            string __tmp149Prefix = "                preferences = new LanguagePreferences(this.Site, typeof("; //502:1
            string __tmp150Suffix = "LanguageService).GUID, this.Name);"; //502:103
            StringBuilder __tmp151 = new StringBuilder();
            __tmp151.Append(Properties.LanguageClassName);
            using(StreamReader __tmp151Reader = new StreamReader(this.__ToStream(__tmp151.ToString())))
            {
                bool __tmp151_first = true;
                while(__tmp151_first || !__tmp151Reader.EndOfStream)
                {
                    __tmp151_first = false;
                    string __tmp151Line = __tmp151Reader.ReadLine();
                    if (__tmp151Line == null)
                    {
                        __tmp151Line = "";
                    }
                    __out.Append(__tmp149Prefix);
                    __out.Append(__tmp151Line);
                    __out.Append(__tmp150Suffix);
                    __out.AppendLine(); //502:137
                }
            }
            __out.Append("                preferences.Init();"); //503:1
            __out.AppendLine(); //503:36
            __out.Append("            }"); //504:1
            __out.AppendLine(); //504:14
            __out.Append("            return preferences;"); //505:1
            __out.AppendLine(); //505:32
            __out.Append("        }"); //506:1
            __out.AppendLine(); //506:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //508:1
            __out.AppendLine(); //508:65
            __out.Append("        {"); //509:1
            __out.AppendLine(); //509:10
            __out.Append("            if (scanner == null)"); //510:1
            __out.AppendLine(); //510:33
            __out.Append("            {"); //511:1
            __out.AppendLine(); //511:14
            string __tmp152Prefix = "                scanner = new "; //512:1
            string __tmp153Suffix = "LanguageScanner();"; //512:61
            StringBuilder __tmp154 = new StringBuilder();
            __tmp154.Append(Properties.LanguageClassName);
            using(StreamReader __tmp154Reader = new StreamReader(this.__ToStream(__tmp154.ToString())))
            {
                bool __tmp154_first = true;
                while(__tmp154_first || !__tmp154Reader.EndOfStream)
                {
                    __tmp154_first = false;
                    string __tmp154Line = __tmp154Reader.ReadLine();
                    if (__tmp154Line == null)
                    {
                        __tmp154Line = "";
                    }
                    __out.Append(__tmp152Prefix);
                    __out.Append(__tmp154Line);
                    __out.Append(__tmp153Suffix);
                    __out.AppendLine(); //512:79
                }
            }
            __out.Append("            }"); //513:1
            __out.AppendLine(); //513:14
            __out.Append("            return scanner;"); //514:1
            __out.AppendLine(); //514:28
            __out.Append("        }"); //515:1
            __out.AppendLine(); //515:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //517:1
            __out.AppendLine(); //517:96
            __out.Append("        {"); //518:1
            __out.AppendLine(); //518:10
            string __tmp155Prefix = "            return new "; //519:1
            string __tmp156Suffix = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //519:54
            StringBuilder __tmp157 = new StringBuilder();
            __tmp157.Append(Properties.LanguageClassName);
            using(StreamReader __tmp157Reader = new StreamReader(this.__ToStream(__tmp157.ToString())))
            {
                bool __tmp157_first = true;
                while(__tmp157_first || !__tmp157Reader.EndOfStream)
                {
                    __tmp157_first = false;
                    string __tmp157Line = __tmp157Reader.ReadLine();
                    if (__tmp157Line == null)
                    {
                        __tmp157Line = "";
                    }
                    __out.Append(__tmp155Prefix);
                    __out.Append(__tmp157Line);
                    __out.Append(__tmp156Suffix);
                    __out.AppendLine(); //519:110
                }
            }
            __out.Append("        }"); //520:1
            __out.AppendLine(); //520:10
            __out.Append("        #region Custom Colors"); //522:1
            __out.AppendLine(); //522:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //523:1
            __out.AppendLine(); //523:83
            __out.Append("        {"); //524:1
            __out.AppendLine(); //524:10
            string __tmp158Prefix = "            if (index >= 1 && index <= "; //525:1
            string __tmp159Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //525:70
            StringBuilder __tmp160 = new StringBuilder();
            __tmp160.Append(Properties.LanguageClassName);
            using(StreamReader __tmp160Reader = new StreamReader(this.__ToStream(__tmp160.ToString())))
            {
                bool __tmp160_first = true;
                while(__tmp160_first || !__tmp160Reader.EndOfStream)
                {
                    __tmp160_first = false;
                    string __tmp160Line = __tmp160Reader.ReadLine();
                    if (__tmp160Line == null)
                    {
                        __tmp160Line = "";
                    }
                    __out.Append(__tmp158Prefix);
                    __out.Append(__tmp160Line);
                    __out.Append(__tmp159Suffix);
                    __out.AppendLine(); //525:115
                }
            }
            __out.Append("            {"); //526:1
            __out.AppendLine(); //526:14
            string __tmp161Prefix = "                item = "; //527:1
            string __tmp162Suffix = ";"; //527:107
            StringBuilder __tmp163 = new StringBuilder();
            __tmp163.Append(Properties.LanguageClassName);
            using(StreamReader __tmp163Reader = new StreamReader(this.__ToStream(__tmp163.ToString())))
            {
                bool __tmp163_first = true;
                while(__tmp163_first || !__tmp163Reader.EndOfStream)
                {
                    __tmp163_first = false;
                    string __tmp163Line = __tmp163Reader.ReadLine();
                    if (__tmp163Line == null)
                    {
                        __tmp163Line = "";
                    }
                    __out.Append(__tmp161Prefix);
                    __out.Append(__tmp163Line);
                }
            }
            string __tmp164Line = "LanguageConfig.Instance.ColorableItems"; //527:54
            __out.Append(__tmp164Line);
            StringBuilder __tmp165 = new StringBuilder();
            __tmp165.Append("[index - 1]");
            using(StreamReader __tmp165Reader = new StreamReader(this.__ToStream(__tmp165.ToString())))
            {
                bool __tmp165_first = true;
                while(__tmp165_first || !__tmp165Reader.EndOfStream)
                {
                    __tmp165_first = false;
                    string __tmp165Line = __tmp165Reader.ReadLine();
                    if (__tmp165Line == null)
                    {
                        __tmp165Line = "";
                    }
                    __out.Append(__tmp165Line);
                    __out.Append(__tmp162Suffix);
                    __out.AppendLine(); //527:108
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //528:1
            __out.AppendLine(); //528:64
            __out.Append("            }"); //529:1
            __out.AppendLine(); //529:14
            __out.Append("            else"); //530:1
            __out.AppendLine(); //530:17
            __out.Append("            {"); //531:1
            __out.AppendLine(); //531:14
            string __tmp166Prefix = "                item = "; //532:1
            string __tmp167Suffix = ";"; //532:99
            StringBuilder __tmp168 = new StringBuilder();
            __tmp168.Append(Properties.LanguageClassName);
            using(StreamReader __tmp168Reader = new StreamReader(this.__ToStream(__tmp168.ToString())))
            {
                bool __tmp168_first = true;
                while(__tmp168_first || !__tmp168Reader.EndOfStream)
                {
                    __tmp168_first = false;
                    string __tmp168Line = __tmp168Reader.ReadLine();
                    if (__tmp168Line == null)
                    {
                        __tmp168Line = "";
                    }
                    __out.Append(__tmp166Prefix);
                    __out.Append(__tmp168Line);
                }
            }
            string __tmp169Line = "LanguageConfig.Instance.ColorableItems"; //532:54
            __out.Append(__tmp169Line);
            StringBuilder __tmp170 = new StringBuilder();
            __tmp170.Append("[0]");
            using(StreamReader __tmp170Reader = new StreamReader(this.__ToStream(__tmp170.ToString())))
            {
                bool __tmp170_first = true;
                while(__tmp170_first || !__tmp170Reader.EndOfStream)
                {
                    __tmp170_first = false;
                    string __tmp170Line = __tmp170Reader.ReadLine();
                    if (__tmp170Line == null)
                    {
                        __tmp170Line = "";
                    }
                    __out.Append(__tmp170Line);
                    __out.Append(__tmp167Suffix);
                    __out.AppendLine(); //532:100
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //533:1
            __out.AppendLine(); //533:64
            __out.Append("            }"); //534:1
            __out.AppendLine(); //534:14
            __out.Append("        }"); //535:1
            __out.AppendLine(); //535:10
            __out.Append("        public override int GetItemCount(out int count)"); //537:1
            __out.AppendLine(); //537:56
            __out.Append("        {"); //538:1
            __out.AppendLine(); //538:10
            __out.Append("            count = AnnotatedAntlr4LanguageConfig.Instance.ColorableItems.Count;"); //539:1
            __out.AppendLine(); //539:81
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //540:1
            __out.AppendLine(); //540:60
            __out.Append("        }"); //541:1
            __out.AppendLine(); //541:10
            __out.Append("        #endregion"); //542:1
            __out.AppendLine(); //542:19
            __out.Append("        public override void OnIdle(bool periodic)"); //544:1
            __out.AppendLine(); //544:51
            __out.Append("        {"); //545:1
            __out.AppendLine(); //545:10
            __out.Append("            // from IronPythonLanguage sample"); //546:1
            __out.AppendLine(); //546:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //547:1
            __out.AppendLine(); //547:93
            string __tmp171Prefix = "            "; //548:1
            string __tmp172Suffix = "LanguageSource)GetSource(this.LastActiveTextView);"; //548:95
            StringBuilder __tmp173 = new StringBuilder();
            __tmp173.Append(Properties.LanguageClassName);
            using(StreamReader __tmp173Reader = new StreamReader(this.__ToStream(__tmp173.ToString())))
            {
                bool __tmp173_first = true;
                while(__tmp173_first || !__tmp173Reader.EndOfStream)
                {
                    __tmp173_first = false;
                    string __tmp173Line = __tmp173Reader.ReadLine();
                    if (__tmp173Line == null)
                    {
                        __tmp173Line = "";
                    }
                    __out.Append(__tmp171Prefix);
                    __out.Append(__tmp173Line);
                }
            }
            string __tmp174Line = "LanguageSource src = ("; //548:43
            __out.Append(__tmp174Line);
            StringBuilder __tmp175 = new StringBuilder();
            __tmp175.Append(Properties.LanguageClassName);
            using(StreamReader __tmp175Reader = new StreamReader(this.__ToStream(__tmp175.ToString())))
            {
                bool __tmp175_first = true;
                while(__tmp175_first || !__tmp175Reader.EndOfStream)
                {
                    __tmp175_first = false;
                    string __tmp175Line = __tmp175Reader.ReadLine();
                    if (__tmp175Line == null)
                    {
                        __tmp175Line = "";
                    }
                    __out.Append(__tmp175Line);
                    __out.Append(__tmp172Suffix);
                    __out.AppendLine(); //548:145
                }
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //549:1
            __out.AppendLine(); //549:74
            __out.Append("            {"); //550:1
            __out.AppendLine(); //550:14
            __out.Append("                src.LastParseTime = 0;"); //551:1
            __out.AppendLine(); //551:39
            __out.Append("            }"); //552:1
            __out.AppendLine(); //552:14
            __out.Append("            base.OnIdle(periodic);"); //553:1
            __out.AppendLine(); //553:35
            __out.Append("        }"); //554:1
            __out.AppendLine(); //554:10
            __out.Append("        public override string Name"); //556:1
            __out.AppendLine(); //556:36
            __out.Append("        {"); //557:1
            __out.AppendLine(); //557:10
            string __tmp176Prefix = "            get { return "; //558:1
            string __tmp177Suffix = "LanguageConfig.LanguageName; }"; //558:56
            StringBuilder __tmp178 = new StringBuilder();
            __tmp178.Append(Properties.LanguageClassName);
            using(StreamReader __tmp178Reader = new StreamReader(this.__ToStream(__tmp178.ToString())))
            {
                bool __tmp178_first = true;
                while(__tmp178_first || !__tmp178Reader.EndOfStream)
                {
                    __tmp178_first = false;
                    string __tmp178Line = __tmp178Reader.ReadLine();
                    if (__tmp178Line == null)
                    {
                        __tmp178Line = "";
                    }
                    __out.Append(__tmp176Prefix);
                    __out.Append(__tmp178Line);
                    __out.Append(__tmp177Suffix);
                    __out.AppendLine(); //558:86
                }
            }
            __out.Append("        }"); //559:1
            __out.AppendLine(); //559:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //561:1
            __out.AppendLine(); //561:96
            __out.Append("        {"); //562:1
            __out.AppendLine(); //562:10
            string __tmp179Prefix = "            return new "; //563:1
            string __tmp180Suffix = "LanguageViewFilter(mgr, newView);"; //563:54
            StringBuilder __tmp181 = new StringBuilder();
            __tmp181.Append(Properties.LanguageClassName);
            using(StreamReader __tmp181Reader = new StreamReader(this.__ToStream(__tmp181.ToString())))
            {
                bool __tmp181_first = true;
                while(__tmp181_first || !__tmp181Reader.EndOfStream)
                {
                    __tmp181_first = false;
                    string __tmp181Line = __tmp181Reader.ReadLine();
                    if (__tmp181Line == null)
                    {
                        __tmp181Line = "";
                    }
                    __out.Append(__tmp179Prefix);
                    __out.Append(__tmp181Line);
                    __out.Append(__tmp180Suffix);
                    __out.AppendLine(); //563:87
                }
            }
            __out.Append("        }"); //564:1
            __out.AppendLine(); //564:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //566:1
            __out.AppendLine(); //566:68
            __out.Append("        {"); //567:1
            __out.AppendLine(); //567:10
            string __tmp182Prefix = "            return new "; //568:1
            string __tmp183Suffix = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //568:54
            StringBuilder __tmp184 = new StringBuilder();
            __tmp184.Append(Properties.LanguageClassName);
            using(StreamReader __tmp184Reader = new StreamReader(this.__ToStream(__tmp184.ToString())))
            {
                bool __tmp184_first = true;
                while(__tmp184_first || !__tmp184Reader.EndOfStream)
                {
                    __tmp184_first = false;
                    string __tmp184Line = __tmp184Reader.ReadLine();
                    if (__tmp184Line == null)
                    {
                        __tmp184Line = "";
                    }
                    __out.Append(__tmp182Prefix);
                    __out.Append(__tmp184Line);
                    __out.Append(__tmp183Suffix);
                    __out.AppendLine(); //568:111
                }
            }
            __out.Append("        }"); //569:1
            __out.AppendLine(); //569:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //571:1
            __out.AppendLine(); //571:69
            __out.Append("        {"); //572:1
            __out.AppendLine(); //572:10
            __out.Append("            //MetaMofLanguageSource source = (MetaMofLanguageSource)this.GetSource(req.FileName);"); //573:1
            __out.AppendLine(); //573:98
            __out.Append("            /*switch (req.Reason)"); //574:1
            __out.AppendLine(); //574:34
            __out.Append("            {"); //575:1
            __out.AppendLine(); //575:14
            __out.Append("                case ParseReason.Check:"); //576:1
            __out.AppendLine(); //576:40
            __out.Append("                    // This is where you perform your syntax highlighting."); //577:1
            __out.AppendLine(); //577:75
            __out.Append("                    // Parse entire source as given in req.Text."); //578:1
            __out.AppendLine(); //578:65
            __out.Append("                    // Store results in the AuthoringScope object."); //579:1
            __out.AppendLine(); //579:67
            __out.Append("                    OsloErrorReporter errorReporter = new OsloErrorReporter();"); //580:1
            __out.AppendLine(); //580:79
            __out.Append("                    dynamic program = this.codeParser.Parse(new StringReader(req.Text), errorReporter);"); //581:1
            __out.AppendLine(); //581:104
            __out.Append("                    source.ParseResult = program;"); //582:1
            __out.AppendLine(); //582:50
            __out.Append("                    foreach (var error in errorReporter.Errors)"); //583:1
            __out.AppendLine(); //583:64
            __out.Append("                    {"); //584:1
            __out.AppendLine(); //584:22
            __out.Append("                        TextSpan span = new TextSpan();"); //585:1
            __out.AppendLine(); //585:56
            __out.Append("                        span.iStartLine = error.LineNumber - 1;"); //586:1
            __out.AppendLine(); //586:64
            __out.Append("                        span.iEndLine = error.EndLineNumber - 1;"); //587:1
            __out.AppendLine(); //587:65
            __out.Append("                        span.iStartIndex = error.ColumnNumber - 1;"); //588:1
            __out.AppendLine(); //588:67
            __out.Append("                        span.iEndIndex = error.EndColumnNumber - 1;"); //589:1
            __out.AppendLine(); //589:68
            __out.Append("                        Severity severity = Severity.Error;"); //590:1
            __out.AppendLine(); //590:60
            __out.Append("                        switch (error.Level)"); //591:1
            __out.AppendLine(); //591:45
            __out.Append("                        {"); //592:1
            __out.AppendLine(); //592:26
            __out.Append("                            case ErrorLevel.DeprecationWarning:"); //593:1
            __out.AppendLine(); //593:64
            __out.Append("                                severity = Severity.Warning;"); //594:1
            __out.AppendLine(); //594:61
            __out.Append("                                break;"); //595:1
            __out.AppendLine(); //595:39
            __out.Append("                            case ErrorLevel.Error:"); //596:1
            __out.AppendLine(); //596:51
            __out.Append("                                severity = Severity.Error;"); //597:1
            __out.AppendLine(); //597:59
            __out.Append("                                break;"); //598:1
            __out.AppendLine(); //598:39
            __out.Append("                            case ErrorLevel.Message:"); //599:1
            __out.AppendLine(); //599:53
            __out.Append("                                severity = Severity.Hint;"); //600:1
            __out.AppendLine(); //600:58
            __out.Append("                                break;"); //601:1
            __out.AppendLine(); //601:39
            __out.Append("                            case ErrorLevel.Warning:"); //602:1
            __out.AppendLine(); //602:53
            __out.Append("                                severity = Severity.Warning;"); //603:1
            __out.AppendLine(); //603:61
            __out.Append("                                break;"); //604:1
            __out.AppendLine(); //604:39
            __out.Append("                        }"); //605:1
            __out.AppendLine(); //605:26
            __out.Append("                        req.Sink.AddError(req.FileName, error.ToString(), span, severity);"); //606:1
            __out.AppendLine(); //606:91
            __out.Append("                    }"); //607:1
            __out.AppendLine(); //607:22
            __out.Append("                    break;"); //608:1
            __out.AppendLine(); //608:27
            __out.Append("            }*/"); //609:1
            __out.AppendLine(); //609:16
            string __tmp185Prefix = "            return new "; //610:1
            string __tmp186Suffix = "LanguageAuthoringScope();"; //610:54
            StringBuilder __tmp187 = new StringBuilder();
            __tmp187.Append(Properties.LanguageClassName);
            using(StreamReader __tmp187Reader = new StreamReader(this.__ToStream(__tmp187.ToString())))
            {
                bool __tmp187_first = true;
                while(__tmp187_first || !__tmp187Reader.EndOfStream)
                {
                    __tmp187_first = false;
                    string __tmp187Line = __tmp187Reader.ReadLine();
                    if (__tmp187Line == null)
                    {
                        __tmp187Line = "";
                    }
                    __out.Append(__tmp185Prefix);
                    __out.Append(__tmp187Line);
                    __out.Append(__tmp186Suffix);
                    __out.AppendLine(); //610:79
                }
            }
            __out.Append("        }"); //611:1
            __out.AppendLine(); //611:10
            __out.Append("    }"); //612:1
            __out.AppendLine(); //612:6
            string __tmp188Prefix = "	public class "; //614:1
            string __tmp189Suffix = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //614:45
            StringBuilder __tmp190 = new StringBuilder();
            __tmp190.Append(Properties.LanguageClassName);
            using(StreamReader __tmp190Reader = new StreamReader(this.__ToStream(__tmp190.ToString())))
            {
                bool __tmp190_first = true;
                while(__tmp190_first || !__tmp190Reader.EndOfStream)
                {
                    __tmp190_first = false;
                    string __tmp190Line = __tmp190Reader.ReadLine();
                    if (__tmp190Line == null)
                    {
                        __tmp190Line = "";
                    }
                    __out.Append(__tmp188Prefix);
                    __out.Append(__tmp190Line);
                    __out.Append(__tmp189Suffix);
                    __out.AppendLine(); //614:99
                }
            }
            __out.Append("    {"); //615:1
            __out.AppendLine(); //615:6
            string __tmp191Prefix = "        public "; //616:1
            string __tmp192Suffix = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //616:46
            StringBuilder __tmp193 = new StringBuilder();
            __tmp193.Append(Properties.LanguageClassName);
            using(StreamReader __tmp193Reader = new StreamReader(this.__ToStream(__tmp193.ToString())))
            {
                bool __tmp193_first = true;
                while(__tmp193_first || !__tmp193Reader.EndOfStream)
                {
                    __tmp193_first = false;
                    string __tmp193Line = __tmp193Reader.ReadLine();
                    if (__tmp193Line == null)
                    {
                        __tmp193Line = "";
                    }
                    __out.Append(__tmp191Prefix);
                    __out.Append(__tmp193Line);
                    __out.Append(__tmp192Suffix);
                    __out.AppendLine(); //616:130
                }
            }
            __out.Append("            : base(service, textLines, colorizer)"); //617:1
            __out.AppendLine(); //617:50
            __out.Append("        {"); //618:1
            __out.AppendLine(); //618:10
            __out.Append("        }"); //620:1
            __out.AppendLine(); //620:10
            __out.Append("    }"); //621:1
            __out.AppendLine(); //621:6
            string __tmp194Prefix = "    public class "; //623:1
            string __tmp195Suffix = "LanguageViewFilter : ViewFilter"; //623:48
            StringBuilder __tmp196 = new StringBuilder();
            __tmp196.Append(Properties.LanguageClassName);
            using(StreamReader __tmp196Reader = new StreamReader(this.__ToStream(__tmp196.ToString())))
            {
                bool __tmp196_first = true;
                while(__tmp196_first || !__tmp196Reader.EndOfStream)
                {
                    __tmp196_first = false;
                    string __tmp196Line = __tmp196Reader.ReadLine();
                    if (__tmp196Line == null)
                    {
                        __tmp196Line = "";
                    }
                    __out.Append(__tmp194Prefix);
                    __out.Append(__tmp196Line);
                    __out.Append(__tmp195Suffix);
                    __out.AppendLine(); //623:79
                }
            }
            __out.Append("    {"); //624:1
            __out.AppendLine(); //624:6
            string __tmp197Prefix = "        public "; //625:1
            string __tmp198Suffix = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //625:46
            StringBuilder __tmp199 = new StringBuilder();
            __tmp199.Append(Properties.LanguageClassName);
            using(StreamReader __tmp199Reader = new StreamReader(this.__ToStream(__tmp199.ToString())))
            {
                bool __tmp199_first = true;
                while(__tmp199_first || !__tmp199Reader.EndOfStream)
                {
                    __tmp199_first = false;
                    string __tmp199Line = __tmp199Reader.ReadLine();
                    if (__tmp199Line == null)
                    {
                        __tmp199Line = "";
                    }
                    __out.Append(__tmp197Prefix);
                    __out.Append(__tmp199Line);
                    __out.Append(__tmp198Suffix);
                    __out.AppendLine(); //625:105
                }
            }
            __out.Append("            : base(mgr, view)"); //626:1
            __out.AppendLine(); //626:30
            __out.Append("        {"); //627:1
            __out.AppendLine(); //627:10
            __out.Append("        }"); //629:1
            __out.AppendLine(); //629:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //631:1
            __out.AppendLine(); //631:150
            __out.Append("        {"); //632:1
            __out.AppendLine(); //632:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //633:1
            __out.AppendLine(); //633:59
            __out.Append("            {"); //634:1
            __out.AppendLine(); //634:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //635:1
            __out.AppendLine(); //635:57
            __out.Append("                switch (cmd)"); //636:1
            __out.AppendLine(); //636:29
            __out.Append("                {"); //637:1
            __out.AppendLine(); //637:18
            __out.Append("                    case VsCommands2K.UP:"); //638:1
            __out.AppendLine(); //638:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //639:1
            __out.AppendLine(); //639:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //640:1
            __out.AppendLine(); //640:50
            __out.Append("                    case VsCommands2K.DOWN:"); //641:1
            __out.AppendLine(); //641:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //642:1
            __out.AppendLine(); //642:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //643:1
            __out.AppendLine(); //643:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //644:1
            __out.Append("\\"); //644:58
            __out.Append("0');"); //644:59
            __out.AppendLine(); //644:63
            __out.Append("                        return;"); //645:1
            __out.AppendLine(); //645:32
            __out.Append("                }"); //646:1
            __out.AppendLine(); //646:18
            __out.Append("            }"); //647:1
            __out.AppendLine(); //647:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //648:1
            __out.AppendLine(); //648:105
            __out.Append("        }"); //649:1
            __out.AppendLine(); //649:10
            __out.Append("    }"); //650:1
            __out.AppendLine(); //650:6
            __out.Append("}"); //652:1
            __out.AppendLine(); //652:2
            return __out.ToString();
        }

    }
}

