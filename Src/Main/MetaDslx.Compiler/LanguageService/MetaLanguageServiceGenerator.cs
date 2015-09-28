using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_59558274;
    namespace __Hidden_MetaLanguageServiceGenerator_59558274
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
            string __tmp31Prefix = "        public static "; //134:1
            string __tmp32Suffix = "LanguageConfig Instance"; //134:53
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
                    __out.AppendLine(); //134:76
                }
            }
            __out.Append("        {"); //135:1
            __out.AppendLine(); //135:10
            __out.Append("            get "); //136:1
            __out.AppendLine(); //136:17
            __out.Append("            {"); //137:1
            __out.AppendLine(); //137:14
            __out.Append("                if (instance == null)"); //138:1
            __out.AppendLine(); //138:38
            __out.Append("                {"); //139:1
            __out.AppendLine(); //139:18
            string __tmp34Prefix = "					// If there is a compile error in the following line, create a class "; //140:1
            string __tmp35Suffix = "LanguageConfig"; //140:105
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
                    __out.AppendLine(); //140:119
                }
            }
            string __tmp37Prefix = "					// which is a subclass of "; //141:1
            string __tmp38Suffix = "LanguageConfigBase"; //141:62
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
                    __out.AppendLine(); //141:80
                }
            }
            string __tmp40Prefix = "                    instance = new "; //142:1
            string __tmp41Suffix = "LanguageConfig();"; //142:66
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
                    __out.AppendLine(); //142:83
                }
            }
            __out.Append("                }"); //143:1
            __out.AppendLine(); //143:18
            __out.Append("                return instance;"); //144:1
            __out.AppendLine(); //144:33
            __out.Append("            }"); //145:1
            __out.AppendLine(); //145:14
            __out.Append("        }"); //146:1
            __out.AppendLine(); //146:10
            string __tmp43Prefix = "        private List<"; //147:1
            string __tmp44Suffix = "LanguageColorableItem>();"; //147:131
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
                }
            }
            string __tmp46Line = "LanguageColorableItem> colorableItems = new List<"; //147:52
            __out.Append(__tmp46Line);
            StringBuilder __tmp47 = new StringBuilder();
            __tmp47.Append(Properties.LanguageClassName);
            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
            {
                bool __tmp47_first = true;
                while(__tmp47_first || !__tmp47Reader.EndOfStream)
                {
                    __tmp47_first = false;
                    string __tmp47Line = __tmp47Reader.ReadLine();
                    if (__tmp47Line == null)
                    {
                        __tmp47Line = "";
                    }
                    __out.Append(__tmp47Line);
                    __out.Append(__tmp44Suffix);
                    __out.AppendLine(); //147:156
                }
            }
            string __tmp48Prefix = "        public IList<"; //148:1
            string __tmp49Suffix = "LanguageColorableItem> ColorableItems"; //148:52
            StringBuilder __tmp50 = new StringBuilder();
            __tmp50.Append(Properties.LanguageClassName);
            using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
            {
                bool __tmp50_first = true;
                while(__tmp50_first || !__tmp50Reader.EndOfStream)
                {
                    __tmp50_first = false;
                    string __tmp50Line = __tmp50Reader.ReadLine();
                    if (__tmp50Line == null)
                    {
                        __tmp50Line = "";
                    }
                    __out.Append(__tmp48Prefix);
                    __out.Append(__tmp50Line);
                    __out.Append(__tmp49Suffix);
                    __out.AppendLine(); //148:89
                }
            }
            __out.Append("        {"); //149:1
            __out.AppendLine(); //149:10
            __out.Append("            get { return colorableItems; }"); //150:1
            __out.AppendLine(); //150:43
            __out.Append("        }"); //151:1
            __out.AppendLine(); //151:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foreground, COLORINDEX background)"); //152:1
            __out.AppendLine(); //152:116
            __out.Append("        {"); //153:1
            __out.AppendLine(); //153:10
            __out.Append("            return CreateColor(name, type, foreground, background, false, false);"); //154:1
            __out.AppendLine(); //154:82
            __out.Append("        }"); //155:1
            __out.AppendLine(); //155:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foreground, COLORINDEX background, bool bold, bool strikethrough)"); //156:1
            __out.AppendLine(); //156:147
            __out.Append("        {"); //157:1
            __out.AppendLine(); //157:10
            string __tmp51Prefix = "            colorableItems.Add(new "; //158:1
            string __tmp52Suffix = "LanguageColorableItem(name, type, foreground, background, bold, strikethrough));"; //158:66
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(Properties.LanguageClassName);
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_first = true;
                while(__tmp53_first || !__tmp53Reader.EndOfStream)
                {
                    __tmp53_first = false;
                    string __tmp53Line = __tmp53Reader.ReadLine();
                    if (__tmp53Line == null)
                    {
                        __tmp53Line = "";
                    }
                    __out.Append(__tmp51Prefix);
                    __out.Append(__tmp53Line);
                    __out.Append(__tmp52Suffix);
                    __out.AppendLine(); //158:146
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //159:1
            __out.AppendLine(); //159:53
            __out.Append("        }"); //160:1
            __out.AppendLine(); //160:10
            __out.Append("    }"); //161:1
            __out.AppendLine(); //161:6
            string __tmp54Prefix = "    public class "; //162:1
            string __tmp55Suffix = "LanguageColorableItem : Microsoft.VisualStudio.TextManager.Interop.IVsColorableItem"; //162:48
            StringBuilder __tmp56 = new StringBuilder();
            __tmp56.Append(Properties.LanguageClassName);
            using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
            {
                bool __tmp56_first = true;
                while(__tmp56_first || !__tmp56Reader.EndOfStream)
                {
                    __tmp56_first = false;
                    string __tmp56Line = __tmp56Reader.ReadLine();
                    if (__tmp56Line == null)
                    {
                        __tmp56Line = "";
                    }
                    __out.Append(__tmp54Prefix);
                    __out.Append(__tmp56Line);
                    __out.Append(__tmp55Suffix);
                    __out.AppendLine(); //162:131
                }
            }
            __out.Append("    {"); //163:1
            __out.AppendLine(); //163:6
            __out.Append("        private uint fontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //164:1
            __out.AppendLine(); //164:61
            __out.Append("        public string DisplayName { get; private set; }"); //166:1
            __out.AppendLine(); //166:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //167:1
            __out.AppendLine(); //167:57
            __out.Append("        public COLORINDEX Background { get; private set; }"); //168:1
            __out.AppendLine(); //168:59
            __out.Append("        public COLORINDEX Foreground { get; private set; }"); //169:1
            __out.AppendLine(); //169:59
            __out.Append("        public uint FontFlags { get; private set; }"); //170:1
            __out.AppendLine(); //170:52
            string __tmp57Prefix = "        public "; //172:1
            string __tmp58Suffix = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foreground, COLORINDEX background, bool bold, bool strikethrough)"; //172:46
            StringBuilder __tmp59 = new StringBuilder();
            __tmp59.Append(Properties.LanguageClassName);
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
                    __out.Append(__tmp57Prefix);
                    __out.Append(__tmp59Line);
                    __out.Append(__tmp58Suffix);
                    __out.AppendLine(); //172:185
                }
            }
            __out.Append("        {"); //173:1
            __out.AppendLine(); //173:10
            __out.Append("            this.DisplayName = displayName;"); //174:1
            __out.AppendLine(); //174:44
            __out.Append("            this.TokenType = tokenType;"); //175:1
            __out.AppendLine(); //175:40
            __out.Append("            this.Background = background;"); //176:1
            __out.AppendLine(); //176:42
            __out.Append("            this.Foreground = foreground;"); //177:1
            __out.AppendLine(); //177:42
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //178:1
            __out.AppendLine(); //178:57
            __out.Append("            if (bold)"); //179:1
            __out.AppendLine(); //179:22
            __out.Append("                this.fontFlags = this.fontFlags | (uint)FONTFLAGS.FF_BOLD;"); //180:1
            __out.AppendLine(); //180:75
            __out.Append("            if (strikethrough)"); //181:1
            __out.AppendLine(); //181:31
            __out.Append("                this.fontFlags = this.fontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //182:1
            __out.AppendLine(); //182:84
            __out.Append("        }"); //183:1
            __out.AppendLine(); //183:10
            __out.Append("        #region IVsColorableItem Members"); //184:1
            __out.AppendLine(); //184:41
            string __tmp60Prefix = "        public int GetDefaultColors(COLORINDEX"; //185:1
            string __tmp61Suffix = " piBackground)"; //185:84
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append("[]");
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
                }
            }
            string __tmp63Line = " piForeground, COLORINDEX"; //185:53
            __out.Append(__tmp63Line);
            StringBuilder __tmp64 = new StringBuilder();
            __tmp64.Append("[]");
            using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
            {
                bool __tmp64_first = true;
                while(__tmp64_first || !__tmp64Reader.EndOfStream)
                {
                    __tmp64_first = false;
                    string __tmp64Line = __tmp64Reader.ReadLine();
                    if (__tmp64Line == null)
                    {
                        __tmp64Line = "";
                    }
                    __out.Append(__tmp64Line);
                    __out.Append(__tmp61Suffix);
                    __out.AppendLine(); //185:98
                }
            }
            __out.Append("        {"); //186:1
            __out.AppendLine(); //186:10
            __out.Append("            if (null == piForeground)"); //187:1
            __out.AppendLine(); //187:38
            __out.Append("            {"); //188:1
            __out.AppendLine(); //188:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //189:1
            __out.AppendLine(); //189:65
            __out.Append("            }"); //190:1
            __out.AppendLine(); //190:14
            __out.Append("            if (0 == piForeground.Length)"); //191:1
            __out.AppendLine(); //191:42
            __out.Append("            {"); //192:1
            __out.AppendLine(); //192:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //193:1
            __out.AppendLine(); //193:71
            __out.Append("            }"); //194:1
            __out.AppendLine(); //194:14
            string __tmp65Prefix = "            piForeground"; //195:1
            string __tmp66Suffix = " = this.Foreground;"; //195:32
            StringBuilder __tmp67 = new StringBuilder();
            __tmp67.Append("[0]");
            using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
            {
                bool __tmp67_first = true;
                while(__tmp67_first || !__tmp67Reader.EndOfStream)
                {
                    __tmp67_first = false;
                    string __tmp67Line = __tmp67Reader.ReadLine();
                    if (__tmp67Line == null)
                    {
                        __tmp67Line = "";
                    }
                    __out.Append(__tmp65Prefix);
                    __out.Append(__tmp67Line);
                    __out.Append(__tmp66Suffix);
                    __out.AppendLine(); //195:51
                }
            }
            __out.Append("            if (null == piBackground)"); //196:1
            __out.AppendLine(); //196:38
            __out.Append("            {"); //197:1
            __out.AppendLine(); //197:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //198:1
            __out.AppendLine(); //198:65
            __out.Append("            }"); //199:1
            __out.AppendLine(); //199:14
            __out.Append("            if (0 == piBackground.Length)"); //200:1
            __out.AppendLine(); //200:42
            __out.Append("            {"); //201:1
            __out.AppendLine(); //201:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //202:1
            __out.AppendLine(); //202:71
            __out.Append("            }"); //203:1
            __out.AppendLine(); //203:14
            string __tmp68Prefix = "            piBackground"; //204:1
            string __tmp69Suffix = " = this.Background;"; //204:32
            StringBuilder __tmp70 = new StringBuilder();
            __tmp70.Append("[0]");
            using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
            {
                bool __tmp70_first = true;
                while(__tmp70_first || !__tmp70Reader.EndOfStream)
                {
                    __tmp70_first = false;
                    string __tmp70Line = __tmp70Reader.ReadLine();
                    if (__tmp70Line == null)
                    {
                        __tmp70Line = "";
                    }
                    __out.Append(__tmp68Prefix);
                    __out.Append(__tmp70Line);
                    __out.Append(__tmp69Suffix);
                    __out.AppendLine(); //204:51
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //205:1
            __out.AppendLine(); //205:60
            __out.Append("        }"); //206:1
            __out.AppendLine(); //206:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //207:1
            __out.AppendLine(); //207:62
            __out.Append("        {"); //208:1
            __out.AppendLine(); //208:10
            __out.Append("            pdwFontFlags = this.fontFlags;"); //209:1
            __out.AppendLine(); //209:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //210:1
            __out.AppendLine(); //210:60
            __out.Append("        }"); //211:1
            __out.AppendLine(); //211:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //212:1
            __out.AppendLine(); //212:56
            __out.Append("        {"); //213:1
            __out.AppendLine(); //213:10
            __out.Append("            pbstrName = this.DisplayName;"); //214:1
            __out.AppendLine(); //214:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //215:1
            __out.AppendLine(); //215:60
            __out.Append("        }"); //216:1
            __out.AppendLine(); //216:10
            __out.Append("        #endregion"); //217:1
            __out.AppendLine(); //217:19
            __out.Append("    }"); //218:1
            __out.AppendLine(); //218:6
            string __tmp71Prefix = "    "; //220:1
            string __tmp72Suffix = string.Empty; 
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append("[ComVisible(true)]");
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_first = true;
                while(__tmp73_first || !__tmp73Reader.EndOfStream)
                {
                    __tmp73_first = false;
                    string __tmp73Line = __tmp73Reader.ReadLine();
                    if (__tmp73Line == null)
                    {
                        __tmp73Line = "";
                    }
                    __out.Append(__tmp71Prefix);
                    __out.Append(__tmp73Line);
                    __out.Append(__tmp72Suffix);
                    __out.AppendLine(); //220:27
                }
            }
            string __tmp74Prefix = "    "; //221:1
            string __tmp75Suffix = string.Empty; 
            StringBuilder __tmp76 = new StringBuilder();
            __tmp76.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageGeneratorServiceGuid)]");
            using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
            {
                bool __tmp76_first = true;
                while(__tmp76_first || !__tmp76Reader.EndOfStream)
                {
                    __tmp76_first = false;
                    string __tmp76Line = __tmp76Reader.ReadLine();
                    if (__tmp76Line == null)
                    {
                        __tmp76Line = "";
                    }
                    __out.Append(__tmp74Prefix);
                    __out.Append(__tmp76Line);
                    __out.Append(__tmp75Suffix);
                    __out.AppendLine(); //221:124
                }
            }
            if (Properties.GenerateMultipleFiles) //222:3
            {
                string __tmp77Prefix = "    public class "; //223:1
                string __tmp78Suffix = "LanguageGeneratorService : VsMultipleFileGenerator<object>"; //223:48
                StringBuilder __tmp79 = new StringBuilder();
                __tmp79.Append(Properties.LanguageClassName);
                using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
                {
                    bool __tmp79_first = true;
                    while(__tmp79_first || !__tmp79Reader.EndOfStream)
                    {
                        __tmp79_first = false;
                        string __tmp79Line = __tmp79Reader.ReadLine();
                        if (__tmp79Line == null)
                        {
                            __tmp79Line = "";
                        }
                        __out.Append(__tmp77Prefix);
                        __out.Append(__tmp79Line);
                        __out.Append(__tmp78Suffix);
                        __out.AppendLine(); //223:106
                    }
                }
                __out.Append("    {"); //224:1
                __out.AppendLine(); //224:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //225:1
                __out.AppendLine(); //225:146
                __out.Append("		{"); //226:1
                __out.AppendLine(); //226:4
                string __tmp80Prefix = "            // If there is a compile error in the following line, create a class "; //227:1
                string __tmp81Suffix = "Generator"; //227:112
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(Properties.LanguageClassName);
                using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                {
                    bool __tmp82_first = true;
                    while(__tmp82_first || !__tmp82Reader.EndOfStream)
                    {
                        __tmp82_first = false;
                        string __tmp82Line = __tmp82Reader.ReadLine();
                        if (__tmp82Line == null)
                        {
                            __tmp82Line = "";
                        }
                        __out.Append(__tmp80Prefix);
                        __out.Append(__tmp82Line);
                        __out.Append(__tmp81Suffix);
                        __out.AppendLine(); //227:121
                    }
                }
                __out.Append("            // which is a subclass of MultipleFileGenerator<object>"); //228:1
                __out.AppendLine(); //228:68
                string __tmp83Prefix = "			return new "; //229:1
                string __tmp84Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //229:45
                StringBuilder __tmp85 = new StringBuilder();
                __tmp85.Append(Properties.LanguageClassName);
                using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                {
                    bool __tmp85_first = true;
                    while(__tmp85_first || !__tmp85Reader.EndOfStream)
                    {
                        __tmp85_first = false;
                        string __tmp85Line = __tmp85Reader.ReadLine();
                        if (__tmp85Line == null)
                        {
                            __tmp85Line = "";
                        }
                        __out.Append(__tmp83Prefix);
                        __out.Append(__tmp85Line);
                        __out.Append(__tmp84Suffix);
                        __out.AppendLine(); //229:107
                    }
                }
                __out.Append("		}"); //230:1
                __out.AppendLine(); //230:4
                __out.Append("    }"); //231:1
                __out.AppendLine(); //231:6
            }
            else //232:3
            {
                string __tmp86Prefix = "    public class "; //233:1
                string __tmp87Suffix = "LanguageGeneratorService : VsSingleFileGenerator"; //233:48
                StringBuilder __tmp88 = new StringBuilder();
                __tmp88.Append(Properties.LanguageClassName);
                using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                {
                    bool __tmp88_first = true;
                    while(__tmp88_first || !__tmp88Reader.EndOfStream)
                    {
                        __tmp88_first = false;
                        string __tmp88Line = __tmp88Reader.ReadLine();
                        if (__tmp88Line == null)
                        {
                            __tmp88Line = "";
                        }
                        __out.Append(__tmp86Prefix);
                        __out.Append(__tmp88Line);
                        __out.Append(__tmp87Suffix);
                        __out.AppendLine(); //233:96
                    }
                }
                __out.Append("    {"); //234:1
                __out.AppendLine(); //234:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //235:1
                __out.AppendLine(); //235:136
                __out.Append("		{"); //236:1
                __out.AppendLine(); //236:4
                string __tmp89Prefix = "            // If there is a compile error in the following line, create a class "; //237:1
                string __tmp90Suffix = "Generator"; //237:112
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(Properties.LanguageClassName);
                using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                {
                    bool __tmp91_first = true;
                    while(__tmp91_first || !__tmp91Reader.EndOfStream)
                    {
                        __tmp91_first = false;
                        string __tmp91Line = __tmp91Reader.ReadLine();
                        if (__tmp91Line == null)
                        {
                            __tmp91Line = "";
                        }
                        __out.Append(__tmp89Prefix);
                        __out.Append(__tmp91Line);
                        __out.Append(__tmp90Suffix);
                        __out.AppendLine(); //237:121
                    }
                }
                __out.Append("            // which is a subclass of SingleFileGenerator"); //238:1
                __out.AppendLine(); //238:58
                string __tmp92Prefix = "			return new "; //239:1
                string __tmp93Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //239:45
                StringBuilder __tmp94 = new StringBuilder();
                __tmp94.Append(Properties.LanguageClassName);
                using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                {
                    bool __tmp94_first = true;
                    while(__tmp94_first || !__tmp94Reader.EndOfStream)
                    {
                        __tmp94_first = false;
                        string __tmp94Line = __tmp94Reader.ReadLine();
                        if (__tmp94Line == null)
                        {
                            __tmp94Line = "";
                        }
                        __out.Append(__tmp92Prefix);
                        __out.Append(__tmp94Line);
                        __out.Append(__tmp93Suffix);
                        __out.AppendLine(); //239:107
                    }
                }
                __out.Append("		}"); //240:1
                __out.AppendLine(); //240:4
                __out.Append("    }"); //241:1
                __out.AppendLine(); //241:6
            }
            string __tmp95Prefix = "    public class "; //245:1
            string __tmp96Suffix = "LanguageScanner : IScanner"; //245:48
            StringBuilder __tmp97 = new StringBuilder();
            __tmp97.Append(Properties.LanguageClassName);
            using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
            {
                bool __tmp97_first = true;
                while(__tmp97_first || !__tmp97Reader.EndOfStream)
                {
                    __tmp97_first = false;
                    string __tmp97Line = __tmp97Reader.ReadLine();
                    if (__tmp97Line == null)
                    {
                        __tmp97Line = "";
                    }
                    __out.Append(__tmp95Prefix);
                    __out.Append(__tmp97Line);
                    __out.Append(__tmp96Suffix);
                    __out.AppendLine(); //245:74
                }
            }
            __out.Append("    {"); //246:1
            __out.AppendLine(); //246:6
            __out.Append("        private int currentOffset;"); //247:1
            __out.AppendLine(); //247:35
            __out.Append("        private string currentLine;"); //248:1
            __out.AppendLine(); //248:36
            string __tmp98Prefix = "        private "; //249:1
            string __tmp99Suffix = "Lexer lexer;"; //249:46
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(Properties.LanguageFullName);
            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
            {
                bool __tmp100_first = true;
                while(__tmp100_first || !__tmp100Reader.EndOfStream)
                {
                    __tmp100_first = false;
                    string __tmp100Line = __tmp100Reader.ReadLine();
                    if (__tmp100Line == null)
                    {
                        __tmp100Line = "";
                    }
                    __out.Append(__tmp98Prefix);
                    __out.Append(__tmp100Line);
                    __out.Append(__tmp99Suffix);
                    __out.AppendLine(); //249:58
                }
            }
            __out.Append("        private IEnumerable<SyntaxAnnotation> modeAnnotations;"); //250:1
            __out.AppendLine(); //250:63
            __out.Append("        private IEnumerable<SyntaxAnnotation> syntaxAnnotations;"); //251:1
            __out.AppendLine(); //251:65
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //252:1
            __out.AppendLine(); //252:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //253:1
            __out.AppendLine(); //253:62
            __out.Append("        private int lastState;"); //254:1
            __out.AppendLine(); //254:31
            string __tmp101Prefix = "        public "; //256:1
            string __tmp102Suffix = "LanguageScanner()"; //256:46
            StringBuilder __tmp103 = new StringBuilder();
            __tmp103.Append(Properties.LanguageClassName);
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
                    __out.Append(__tmp101Prefix);
                    __out.Append(__tmp103Line);
                    __out.Append(__tmp102Suffix);
                    __out.AppendLine(); //256:63
                }
            }
            __out.Append("        {"); //257:1
            __out.AppendLine(); //257:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //258:1
            __out.AppendLine(); //258:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //259:1
            __out.AppendLine(); //259:71
            __out.Append("            this.lastState = 0;"); //260:1
            __out.AppendLine(); //260:32
            string __tmp104Prefix = "            "; //261:1
            string __tmp105Suffix = "LexerAnnotator();"; //261:102
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
                }
            }
            string __tmp107Line = "LexerAnnotator annotator = new "; //261:42
            __out.Append(__tmp107Line);
            StringBuilder __tmp108 = new StringBuilder();
            __tmp108.Append(Properties.LanguageFullName);
            using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
            {
                bool __tmp108_first = true;
                while(__tmp108_first || !__tmp108Reader.EndOfStream)
                {
                    __tmp108_first = false;
                    string __tmp108Line = __tmp108Reader.ReadLine();
                    if (__tmp108Line == null)
                    {
                        __tmp108Line = "";
                    }
                    __out.Append(__tmp108Line);
                    __out.Append(__tmp105Suffix);
                    __out.AppendLine(); //261:119
                }
            }
            __out.Append("            List<SyntaxAnnotation> mal = new List<SyntaxAnnotation>();"); //262:1
            __out.AppendLine(); //262:71
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //263:1
            __out.AppendLine(); //263:72
            __out.Append("            {"); //264:1
            __out.AppendLine(); //264:14
            __out.Append("                foreach (var annot in annotList)"); //265:1
            __out.AppendLine(); //265:49
            __out.Append("                {"); //266:1
            __out.AppendLine(); //266:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //267:1
            __out.AppendLine(); //267:51
            __out.Append("                    {"); //268:1
            __out.AppendLine(); //268:22
            __out.Append("                        mal.Add((SyntaxAnnotation)annot);"); //269:1
            __out.AppendLine(); //269:58
            __out.Append("                    }"); //270:1
            __out.AppendLine(); //270:22
            __out.Append("                }"); //271:1
            __out.AppendLine(); //271:18
            __out.Append("            }"); //272:1
            __out.AppendLine(); //272:14
            __out.Append("            this.modeAnnotations = mal;"); //273:1
            __out.AppendLine(); //273:40
            __out.Append("            List<SyntaxAnnotation> sal = new List<SyntaxAnnotation>();"); //274:1
            __out.AppendLine(); //274:71
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //275:1
            __out.AppendLine(); //275:73
            __out.Append("            {"); //276:1
            __out.AppendLine(); //276:14
            __out.Append("                foreach (var annot in annotList)"); //277:1
            __out.AppendLine(); //277:49
            __out.Append("                {"); //278:1
            __out.AppendLine(); //278:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //279:1
            __out.AppendLine(); //279:51
            __out.Append("                    {"); //280:1
            __out.AppendLine(); //280:22
            __out.Append("                        sal.Add((SyntaxAnnotation)annot);"); //281:1
            __out.AppendLine(); //281:58
            __out.Append("                    }"); //282:1
            __out.AppendLine(); //282:22
            __out.Append("                }"); //283:1
            __out.AppendLine(); //283:18
            __out.Append("            }"); //284:1
            __out.AppendLine(); //284:14
            __out.Append("            this.syntaxAnnotations = sal;"); //285:1
            __out.AppendLine(); //285:42
            __out.Append("        }"); //286:1
            __out.AppendLine(); //286:10
            string __tmp109Prefix = "        private void LoadState(int state, "; //288:1
            string __tmp110Suffix = "Lexer lexer)"; //288:72
            StringBuilder __tmp111 = new StringBuilder();
            __tmp111.Append(Properties.LanguageFullName);
            using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
            {
                bool __tmp111_first = true;
                while(__tmp111_first || !__tmp111Reader.EndOfStream)
                {
                    __tmp111_first = false;
                    string __tmp111Line = __tmp111Reader.ReadLine();
                    if (__tmp111Line == null)
                    {
                        __tmp111Line = "";
                    }
                    __out.Append(__tmp109Prefix);
                    __out.Append(__tmp111Line);
                    __out.Append(__tmp110Suffix);
                    __out.AppendLine(); //288:84
                }
            }
            __out.Append("        {"); //289:1
            __out.AppendLine(); //289:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //290:1
            __out.AppendLine(); //290:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //291:1
            __out.AppendLine(); //291:55
            __out.Append("            value.Restore(lexer);"); //292:1
            __out.AppendLine(); //292:34
            __out.Append("        }"); //293:1
            __out.AppendLine(); //293:10
            string __tmp112Prefix = "        private int SaveState("; //295:1
            string __tmp113Suffix = "Lexer lexer)"; //295:60
            StringBuilder __tmp114 = new StringBuilder();
            __tmp114.Append(Properties.LanguageFullName);
            using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
            {
                bool __tmp114_first = true;
                while(__tmp114_first || !__tmp114Reader.EndOfStream)
                {
                    __tmp114_first = false;
                    string __tmp114Line = __tmp114Reader.ReadLine();
                    if (__tmp114Line == null)
                    {
                        __tmp114Line = "";
                    }
                    __out.Append(__tmp112Prefix);
                    __out.Append(__tmp114Line);
                    __out.Append(__tmp113Suffix);
                    __out.AppendLine(); //295:72
                }
            }
            __out.Append("        {"); //296:1
            __out.AppendLine(); //296:10
            __out.Append("            int result = 0;"); //297:1
            __out.AppendLine(); //297:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //298:1
            __out.AppendLine(); //298:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //299:1
            __out.AppendLine(); //299:68
            __out.Append("            {"); //300:1
            __out.AppendLine(); //300:14
            __out.Append("                result = ++lastState;"); //301:1
            __out.AppendLine(); //301:38
            __out.Append("                this.states.Add(result, state);"); //302:1
            __out.AppendLine(); //302:48
            __out.Append("                this.inverseStates.Add(state, result);"); //303:1
            __out.AppendLine(); //303:55
            __out.Append("            }"); //304:1
            __out.AppendLine(); //304:14
            __out.Append("            return result;"); //305:1
            __out.AppendLine(); //305:27
            __out.Append("        }"); //306:1
            __out.AppendLine(); //306:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //308:1
            __out.AppendLine(); //308:87
            __out.Append("        {"); //309:1
            __out.AppendLine(); //309:10
            __out.Append("            try"); //310:1
            __out.AppendLine(); //310:16
            __out.Append("            {"); //311:1
            __out.AppendLine(); //311:14
            __out.Append("                if (this.lexer == null)"); //312:1
            __out.AppendLine(); //312:40
            __out.Append("                {"); //313:1
            __out.AppendLine(); //313:18
            string __tmp115Prefix = "                    this.lexer = new "; //314:1
            string __tmp116Suffix = "n\"));"; //314:117
            StringBuilder __tmp117 = new StringBuilder();
            __tmp117.Append(Properties.LanguageFullName);
            using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
            {
                bool __tmp117_first = true;
                while(__tmp117_first || !__tmp117Reader.EndOfStream)
                {
                    __tmp117_first = false;
                    string __tmp117Line = __tmp117Reader.ReadLine();
                    if (__tmp117Line == null)
                    {
                        __tmp117Line = "";
                    }
                    __out.Append(__tmp115Prefix);
                    __out.Append(__tmp117Line);
                }
            }
            string __tmp118Line = "Lexer(new AntlrInputStream(this.currentLine + \""; //314:67
            __out.Append(__tmp118Line);
            string __tmp119Line = "\\"; //314:114
            __out.Append(__tmp119Line);
            string __tmp120Line = "r"; //314:115
            __out.Append(__tmp120Line);
            string __tmp121Line = "\\"; //314:116
            __out.Append(__tmp121Line);
            __out.Append(__tmp116Suffix);
            __out.AppendLine(); //314:122
            __out.Append("                }"); //315:1
            __out.AppendLine(); //315:18
            __out.Append("                this.LoadState(state, this.lexer);"); //316:1
            __out.AppendLine(); //316:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //317:1
            __out.AppendLine(); //317:55
            __out.Append("                int tokenType = -1;"); //318:1
            __out.AppendLine(); //318:36
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //320:1
            __out.AppendLine(); //320:64
            __out.Append("                {"); //321:1
            __out.AppendLine(); //321:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //322:1
            __out.AppendLine(); //322:111
            __out.Append("                    {"); //323:1
            __out.AppendLine(); //323:22
            __out.Append("                        tokenType = modeAnnot.Kind;"); //324:1
            __out.AppendLine(); //324:52
            __out.Append("                        break;"); //325:1
            __out.AppendLine(); //325:31
            __out.Append("                    }"); //326:1
            __out.AppendLine(); //326:22
            __out.Append("                }"); //327:1
            __out.AppendLine(); //327:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //328:1
            __out.AppendLine(); //328:68
            __out.Append("                {"); //329:1
            __out.AppendLine(); //329:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //330:1
            __out.AppendLine(); //330:91
            __out.Append("                    {"); //331:1
            __out.AppendLine(); //331:22
            __out.Append("                        tokenType = syntaxAnnot.Kind;"); //332:1
            __out.AppendLine(); //332:54
            __out.Append("                        break;"); //333:1
            __out.AppendLine(); //333:31
            __out.Append("                    }"); //334:1
            __out.AppendLine(); //334:22
            __out.Append("                }"); //335:1
            __out.AppendLine(); //335:18
            string __tmp122Prefix = "                if (tokenType >= 1 && tokenType <= "; //337:1
            string __tmp123Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //337:82
            StringBuilder __tmp124 = new StringBuilder();
            __tmp124.Append(Properties.LanguageClassName);
            using(StreamReader __tmp124Reader = new StreamReader(this.__ToStream(__tmp124.ToString())))
            {
                bool __tmp124_first = true;
                while(__tmp124_first || !__tmp124Reader.EndOfStream)
                {
                    __tmp124_first = false;
                    string __tmp124Line = __tmp124Reader.ReadLine();
                    if (__tmp124Line == null)
                    {
                        __tmp124Line = "";
                    }
                    __out.Append(__tmp122Prefix);
                    __out.Append(__tmp124Line);
                    __out.Append(__tmp123Suffix);
                    __out.AppendLine(); //337:127
                }
            }
            __out.Append("                {"); //338:1
            __out.AppendLine(); //338:18
            string __tmp125Prefix = "                    "; //339:1
            string __tmp126Suffix = ";"; //339:172
            StringBuilder __tmp127 = new StringBuilder();
            __tmp127.Append(Properties.LanguageClassName);
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
                    __out.Append(__tmp125Prefix);
                    __out.Append(__tmp127Line);
                }
            }
            string __tmp128Line = "LanguageColorableItem colorItem = "; //339:51
            __out.Append(__tmp128Line);
            StringBuilder __tmp129 = new StringBuilder();
            __tmp129.Append(Properties.LanguageClassName);
            using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
            {
                bool __tmp129_first = true;
                while(__tmp129_first || !__tmp129Reader.EndOfStream)
                {
                    __tmp129_first = false;
                    string __tmp129Line = __tmp129Reader.ReadLine();
                    if (__tmp129Line == null)
                    {
                        __tmp129Line = "";
                    }
                    __out.Append(__tmp129Line);
                }
            }
            string __tmp130Line = "LanguageConfig.Instance.ColorableItems"; //339:115
            __out.Append(__tmp130Line);
            StringBuilder __tmp131 = new StringBuilder();
            __tmp131.Append("[tokenType - 1]");
            using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
            {
                bool __tmp131_first = true;
                while(__tmp131_first || !__tmp131Reader.EndOfStream)
                {
                    __tmp131_first = false;
                    string __tmp131Line = __tmp131Reader.ReadLine();
                    if (__tmp131Line == null)
                    {
                        __tmp131Line = "";
                    }
                    __out.Append(__tmp131Line);
                    __out.Append(__tmp126Suffix);
                    __out.AppendLine(); //339:173
                }
            }
            __out.Append("                    tokenInfo.Token = token.Type;"); //340:1
            __out.AppendLine(); //340:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //341:1
            __out.AppendLine(); //341:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //342:1
            __out.AppendLine(); //342:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //343:1
            __out.AppendLine(); //343:60
            __out.Append("                }"); //344:1
            __out.AppendLine(); //344:18
            __out.Append("                else"); //345:1
            __out.AppendLine(); //345:21
            __out.Append("                {"); //346:1
            __out.AppendLine(); //346:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //347:1
            __out.AppendLine(); //347:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //348:1
            __out.AppendLine(); //348:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //349:1
            __out.AppendLine(); //349:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //350:1
            __out.AppendLine(); //350:60
            __out.Append("                }"); //351:1
            __out.AppendLine(); //351:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //353:1
            __out.AppendLine(); //353:103
            __out.Append("                {"); //354:1
            __out.AppendLine(); //354:18
            __out.Append("                    return false;"); //355:1
            __out.AppendLine(); //355:34
            __out.Append("                }"); //356:1
            __out.AppendLine(); //356:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //357:1
            __out.AppendLine(); //357:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //358:1
            __out.AppendLine(); //358:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //359:1
            __out.AppendLine(); //359:61
            __out.Append("                state = this.SaveState(lexer);"); //360:1
            __out.AppendLine(); //360:47
            __out.Append("                return true;"); //361:1
            __out.AppendLine(); //361:29
            __out.Append("            }"); //362:1
            __out.AppendLine(); //362:14
            __out.Append("            catch (Exception)"); //363:1
            __out.AppendLine(); //363:30
            __out.Append("            {"); //364:1
            __out.AppendLine(); //364:14
            __out.Append("                return false;"); //365:1
            __out.AppendLine(); //365:30
            __out.Append("            }"); //366:1
            __out.AppendLine(); //366:14
            __out.Append("        }"); //367:1
            __out.AppendLine(); //367:10
            __out.Append("        public void SetSource(string source, int offset)"); //369:1
            __out.AppendLine(); //369:57
            __out.Append("        {"); //370:1
            __out.AppendLine(); //370:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //371:1
            __out.AppendLine(); //371:78
            __out.Append("            {"); //372:1
            __out.AppendLine(); //372:14
            __out.Append("                this.currentOffset = offset;"); //373:1
            __out.AppendLine(); //373:45
            __out.Append("                this.currentLine = source;"); //374:1
            __out.AppendLine(); //374:43
            __out.Append("                this.lexer = null;"); //375:1
            __out.AppendLine(); //375:35
            __out.Append("            }"); //376:1
            __out.AppendLine(); //376:14
            __out.Append("        }"); //377:1
            __out.AppendLine(); //377:10
            __out.Append("        internal void ScanLine(ref int state)"); //378:1
            __out.AppendLine(); //378:46
            __out.Append("        {"); //379:1
            __out.AppendLine(); //379:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //380:1
            __out.AppendLine(); //380:86
            __out.Append("        }"); //381:1
            __out.AppendLine(); //381:10
            __out.Append("        internal struct LanguageScannerState"); //383:1
            __out.AppendLine(); //383:45
            __out.Append("        {"); //384:1
            __out.AppendLine(); //384:10
            string __tmp132Prefix = "            public LanguageScannerState("; //385:1
            string __tmp133Suffix = "Lexer lexer)"; //385:70
            StringBuilder __tmp134 = new StringBuilder();
            __tmp134.Append(Properties.LanguageFullName);
            using(StreamReader __tmp134Reader = new StreamReader(this.__ToStream(__tmp134.ToString())))
            {
                bool __tmp134_first = true;
                while(__tmp134_first || !__tmp134Reader.EndOfStream)
                {
                    __tmp134_first = false;
                    string __tmp134Line = __tmp134Reader.ReadLine();
                    if (__tmp134Line == null)
                    {
                        __tmp134Line = "";
                    }
                    __out.Append(__tmp132Prefix);
                    __out.Append(__tmp134Line);
                    __out.Append(__tmp133Suffix);
                    __out.AppendLine(); //385:82
                }
            }
            __out.Append("            {"); //386:1
            __out.AppendLine(); //386:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //387:1
            __out.AppendLine(); //387:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //388:1
            __out.AppendLine(); //388:101
            __out.Append("                this._type = lexer.Type;"); //389:1
            __out.AppendLine(); //389:41
            __out.Append("                this._channel = lexer.Channel;"); //390:1
            __out.AppendLine(); //390:47
            __out.Append("                this._state = lexer.State;"); //391:1
            __out.AppendLine(); //391:43
            __out.Append("            }"); //392:1
            __out.AppendLine(); //392:14
            __out.Append("            internal int _state;"); //394:1
            __out.AppendLine(); //394:33
            __out.Append("            internal int _mode;"); //395:1
            __out.AppendLine(); //395:32
            __out.Append("            internal List<int> _modeStack;"); //396:1
            __out.AppendLine(); //396:43
            __out.Append("            internal int _type;"); //397:1
            __out.AppendLine(); //397:32
            __out.Append("            internal int _channel;"); //398:1
            __out.AppendLine(); //398:35
            string __tmp135Prefix = "            public void Restore("; //400:1
            string __tmp136Suffix = "Lexer lexer)"; //400:62
            StringBuilder __tmp137 = new StringBuilder();
            __tmp137.Append(Properties.LanguageFullName);
            using(StreamReader __tmp137Reader = new StreamReader(this.__ToStream(__tmp137.ToString())))
            {
                bool __tmp137_first = true;
                while(__tmp137_first || !__tmp137Reader.EndOfStream)
                {
                    __tmp137_first = false;
                    string __tmp137Line = __tmp137Reader.ReadLine();
                    if (__tmp137Line == null)
                    {
                        __tmp137Line = "";
                    }
                    __out.Append(__tmp135Prefix);
                    __out.Append(__tmp137Line);
                    __out.Append(__tmp136Suffix);
                    __out.AppendLine(); //400:74
                }
            }
            __out.Append("            {"); //401:1
            __out.AppendLine(); //401:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //402:1
            __out.AppendLine(); //402:48
            __out.Append("                lexer.ModeStack.Clear();"); //403:1
            __out.AppendLine(); //403:41
            __out.Append("                if (this._modeStack != null)"); //404:1
            __out.AppendLine(); //404:45
            __out.Append("                {"); //405:1
            __out.AppendLine(); //405:18
            __out.Append("                    foreach (var item in this._modeStack)"); //406:1
            __out.AppendLine(); //406:58
            __out.Append("                    {"); //407:1
            __out.AppendLine(); //407:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //408:1
            __out.AppendLine(); //408:52
            __out.Append("                    }"); //409:1
            __out.AppendLine(); //409:22
            __out.Append("                }"); //410:1
            __out.AppendLine(); //410:18
            __out.Append("                lexer.Type = this._type;"); //411:1
            __out.AppendLine(); //411:41
            __out.Append("                lexer.Channel = this._channel;"); //412:1
            __out.AppendLine(); //412:47
            __out.Append("                lexer.State = this._state;"); //413:1
            __out.AppendLine(); //413:43
            __out.Append("            }"); //414:1
            __out.AppendLine(); //414:14
            __out.Append("            public override bool Equals(object obj)"); //416:1
            __out.AppendLine(); //416:52
            __out.Append("            {"); //417:1
            __out.AppendLine(); //417:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //418:1
            __out.AppendLine(); //418:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //419:1
            __out.AppendLine(); //419:59
            __out.Append("                if (rhs._type != this._type) return false;"); //420:1
            __out.AppendLine(); //420:59
            __out.Append("                if (rhs._state != this._state) return false;"); //421:1
            __out.AppendLine(); //421:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //422:1
            __out.AppendLine(); //422:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //423:1
            __out.AppendLine(); //423:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //424:1
            __out.AppendLine(); //424:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //425:1
            __out.AppendLine(); //425:71
            __out.Append("                {"); //426:1
            __out.AppendLine(); //426:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //427:1
            __out.AppendLine(); //427:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //428:1
            __out.AppendLine(); //428:67
            __out.Append("                    {"); //429:1
            __out.AppendLine(); //429:22
            string __tmp138Prefix = "                        if (rhs._modeStack"; //430:1
            string __tmp139Suffix = ") return false;"; //430:76
            StringBuilder __tmp140 = new StringBuilder();
            __tmp140.Append("[i]");
            using(StreamReader __tmp140Reader = new StreamReader(this.__ToStream(__tmp140.ToString())))
            {
                bool __tmp140_first = true;
                while(__tmp140_first || !__tmp140Reader.EndOfStream)
                {
                    __tmp140_first = false;
                    string __tmp140Line = __tmp140Reader.ReadLine();
                    if (__tmp140Line == null)
                    {
                        __tmp140Line = "";
                    }
                    __out.Append(__tmp138Prefix);
                    __out.Append(__tmp140Line);
                }
            }
            string __tmp141Line = " != this._modeStack"; //430:50
            __out.Append(__tmp141Line);
            StringBuilder __tmp142 = new StringBuilder();
            __tmp142.Append("[i]");
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
                    __out.Append(__tmp142Line);
                    __out.Append(__tmp139Suffix);
                    __out.AppendLine(); //430:91
                }
            }
            __out.Append("                    }"); //431:1
            __out.AppendLine(); //431:22
            __out.Append("                }"); //432:1
            __out.AppendLine(); //432:18
            __out.Append("                return true;"); //433:1
            __out.AppendLine(); //433:29
            __out.Append("            }"); //434:1
            __out.AppendLine(); //434:14
            __out.Append("            public override int GetHashCode()"); //436:1
            __out.AppendLine(); //436:46
            __out.Append("            {"); //437:1
            __out.AppendLine(); //437:14
            __out.Append("                int result = 0;"); //438:1
            __out.AppendLine(); //438:32
            __out.Append("                result "); //439:1
            __out.Append("^"); //439:24
            __out.Append("= this._mode.GetHashCode();"); //439:25
            __out.AppendLine(); //439:52
            __out.Append("                result "); //440:1
            __out.Append("^"); //440:24
            __out.Append("= this._type.GetHashCode();"); //440:25
            __out.AppendLine(); //440:52
            __out.Append("                result "); //441:1
            __out.Append("^"); //441:24
            __out.Append("= this._state.GetHashCode();"); //441:25
            __out.AppendLine(); //441:53
            __out.Append("                result "); //442:1
            __out.Append("^"); //442:24
            __out.Append("= this._channel.GetHashCode();"); //442:25
            __out.AppendLine(); //442:55
            __out.Append("                if (this._modeStack != null)"); //443:1
            __out.AppendLine(); //443:45
            __out.Append("                {"); //444:1
            __out.AppendLine(); //444:18
            __out.Append("                    result "); //445:1
            __out.Append("^"); //445:28
            __out.Append("= this._modeStack.GetHashCode();"); //445:29
            __out.AppendLine(); //445:61
            __out.Append("                }"); //446:1
            __out.AppendLine(); //446:18
            __out.Append("                return result;"); //447:1
            __out.AppendLine(); //447:31
            __out.Append("            }"); //448:1
            __out.AppendLine(); //448:14
            __out.Append("        }"); //449:1
            __out.AppendLine(); //449:10
            __out.Append("    }"); //450:1
            __out.AppendLine(); //450:6
            string __tmp143Prefix = "    "; //452:1
            string __tmp144Suffix = string.Empty; 
            StringBuilder __tmp145 = new StringBuilder();
            __tmp145.Append("[ComVisible(true)]");
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
                    __out.AppendLine(); //452:27
                }
            }
            string __tmp146Prefix = "    "; //453:1
            string __tmp147Suffix = string.Empty; 
            StringBuilder __tmp148 = new StringBuilder();
            __tmp148.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
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
                    __out.AppendLine(); //453:115
                }
            }
            string __tmp149Prefix = "    public class "; //454:1
            string __tmp150Suffix = "LanguageService : LanguageService"; //454:48
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
                    __out.AppendLine(); //454:81
                }
            }
            __out.Append("    {"); //455:1
            __out.AppendLine(); //455:6
            __out.Append("        private LanguagePreferences preferences;"); //456:1
            __out.AppendLine(); //456:49
            string __tmp152Prefix = "        private "; //457:1
            string __tmp153Suffix = "LanguageScanner scanner;"; //457:47
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
                    __out.AppendLine(); //457:71
                }
            }
            string __tmp155Prefix = "        public "; //459:1
            string __tmp156Suffix = "LanguageService()"; //459:46
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
                    __out.AppendLine(); //459:63
                }
            }
            __out.Append("        {"); //460:1
            __out.AppendLine(); //460:10
            __out.Append("			// Creating the config instance"); //461:1
            __out.AppendLine(); //461:35
            string __tmp158Prefix = "			"; //462:1
            string __tmp159Suffix = "LanguageConfigBase.Instance.ToString();"; //462:34
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
                    __out.AppendLine(); //462:73
                }
            }
            __out.Append("        }"); //463:1
            __out.AppendLine(); //463:10
            __out.Append("        public override string GetFormatFilterList()"); //465:1
            __out.AppendLine(); //465:53
            __out.Append("        {"); //466:1
            __out.AppendLine(); //466:10
            string __tmp161Prefix = "            return "; //467:1
            string __tmp162Suffix = "LanguageConfig.FilterList;"; //467:50
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
                    __out.Append(__tmp162Suffix);
                    __out.AppendLine(); //467:76
                }
            }
            __out.Append("        }"); //468:1
            __out.AppendLine(); //468:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //470:1
            __out.AppendLine(); //470:69
            __out.Append("        {"); //471:1
            __out.AppendLine(); //471:10
            __out.Append("            if (preferences == null)"); //472:1
            __out.AppendLine(); //472:37
            __out.Append("            {"); //473:1
            __out.AppendLine(); //473:14
            string __tmp164Prefix = "                preferences = new LanguagePreferences(this.Site, typeof("; //474:1
            string __tmp165Suffix = "LanguageService).GUID, this.Name);"; //474:103
            StringBuilder __tmp166 = new StringBuilder();
            __tmp166.Append(Properties.LanguageClassName);
            using(StreamReader __tmp166Reader = new StreamReader(this.__ToStream(__tmp166.ToString())))
            {
                bool __tmp166_first = true;
                while(__tmp166_first || !__tmp166Reader.EndOfStream)
                {
                    __tmp166_first = false;
                    string __tmp166Line = __tmp166Reader.ReadLine();
                    if (__tmp166Line == null)
                    {
                        __tmp166Line = "";
                    }
                    __out.Append(__tmp164Prefix);
                    __out.Append(__tmp166Line);
                    __out.Append(__tmp165Suffix);
                    __out.AppendLine(); //474:137
                }
            }
            __out.Append("                preferences.Init();"); //475:1
            __out.AppendLine(); //475:36
            __out.Append("            }"); //476:1
            __out.AppendLine(); //476:14
            __out.Append("            return preferences;"); //477:1
            __out.AppendLine(); //477:32
            __out.Append("        }"); //478:1
            __out.AppendLine(); //478:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //480:1
            __out.AppendLine(); //480:65
            __out.Append("        {"); //481:1
            __out.AppendLine(); //481:10
            __out.Append("            if (scanner == null)"); //482:1
            __out.AppendLine(); //482:33
            __out.Append("            {"); //483:1
            __out.AppendLine(); //483:14
            string __tmp167Prefix = "                scanner = new "; //484:1
            string __tmp168Suffix = "LanguageScanner();"; //484:61
            StringBuilder __tmp169 = new StringBuilder();
            __tmp169.Append(Properties.LanguageClassName);
            using(StreamReader __tmp169Reader = new StreamReader(this.__ToStream(__tmp169.ToString())))
            {
                bool __tmp169_first = true;
                while(__tmp169_first || !__tmp169Reader.EndOfStream)
                {
                    __tmp169_first = false;
                    string __tmp169Line = __tmp169Reader.ReadLine();
                    if (__tmp169Line == null)
                    {
                        __tmp169Line = "";
                    }
                    __out.Append(__tmp167Prefix);
                    __out.Append(__tmp169Line);
                    __out.Append(__tmp168Suffix);
                    __out.AppendLine(); //484:79
                }
            }
            __out.Append("            }"); //485:1
            __out.AppendLine(); //485:14
            __out.Append("            return scanner;"); //486:1
            __out.AppendLine(); //486:28
            __out.Append("        }"); //487:1
            __out.AppendLine(); //487:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //489:1
            __out.AppendLine(); //489:96
            __out.Append("        {"); //490:1
            __out.AppendLine(); //490:10
            string __tmp170Prefix = "            return new "; //491:1
            string __tmp171Suffix = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //491:54
            StringBuilder __tmp172 = new StringBuilder();
            __tmp172.Append(Properties.LanguageClassName);
            using(StreamReader __tmp172Reader = new StreamReader(this.__ToStream(__tmp172.ToString())))
            {
                bool __tmp172_first = true;
                while(__tmp172_first || !__tmp172Reader.EndOfStream)
                {
                    __tmp172_first = false;
                    string __tmp172Line = __tmp172Reader.ReadLine();
                    if (__tmp172Line == null)
                    {
                        __tmp172Line = "";
                    }
                    __out.Append(__tmp170Prefix);
                    __out.Append(__tmp172Line);
                    __out.Append(__tmp171Suffix);
                    __out.AppendLine(); //491:110
                }
            }
            __out.Append("        }"); //492:1
            __out.AppendLine(); //492:10
            __out.Append("        #region Custom Colors"); //494:1
            __out.AppendLine(); //494:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //495:1
            __out.AppendLine(); //495:83
            __out.Append("        {"); //496:1
            __out.AppendLine(); //496:10
            string __tmp173Prefix = "            if (index >= 1 && index <= "; //497:1
            string __tmp174Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //497:70
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
                    __out.Append(__tmp173Prefix);
                    __out.Append(__tmp175Line);
                    __out.Append(__tmp174Suffix);
                    __out.AppendLine(); //497:115
                }
            }
            __out.Append("            {"); //498:1
            __out.AppendLine(); //498:14
            string __tmp176Prefix = "                item = "; //499:1
            string __tmp177Suffix = ";"; //499:107
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
                }
            }
            string __tmp179Line = "LanguageConfig.Instance.ColorableItems"; //499:54
            __out.Append(__tmp179Line);
            StringBuilder __tmp180 = new StringBuilder();
            __tmp180.Append("[index - 1]");
            using(StreamReader __tmp180Reader = new StreamReader(this.__ToStream(__tmp180.ToString())))
            {
                bool __tmp180_first = true;
                while(__tmp180_first || !__tmp180Reader.EndOfStream)
                {
                    __tmp180_first = false;
                    string __tmp180Line = __tmp180Reader.ReadLine();
                    if (__tmp180Line == null)
                    {
                        __tmp180Line = "";
                    }
                    __out.Append(__tmp180Line);
                    __out.Append(__tmp177Suffix);
                    __out.AppendLine(); //499:108
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //500:1
            __out.AppendLine(); //500:64
            __out.Append("            }"); //501:1
            __out.AppendLine(); //501:14
            __out.Append("            else"); //502:1
            __out.AppendLine(); //502:17
            __out.Append("            {"); //503:1
            __out.AppendLine(); //503:14
            string __tmp181Prefix = "                item = "; //504:1
            string __tmp182Suffix = ";"; //504:99
            StringBuilder __tmp183 = new StringBuilder();
            __tmp183.Append(Properties.LanguageClassName);
            using(StreamReader __tmp183Reader = new StreamReader(this.__ToStream(__tmp183.ToString())))
            {
                bool __tmp183_first = true;
                while(__tmp183_first || !__tmp183Reader.EndOfStream)
                {
                    __tmp183_first = false;
                    string __tmp183Line = __tmp183Reader.ReadLine();
                    if (__tmp183Line == null)
                    {
                        __tmp183Line = "";
                    }
                    __out.Append(__tmp181Prefix);
                    __out.Append(__tmp183Line);
                }
            }
            string __tmp184Line = "LanguageConfig.Instance.ColorableItems"; //504:54
            __out.Append(__tmp184Line);
            StringBuilder __tmp185 = new StringBuilder();
            __tmp185.Append("[0]");
            using(StreamReader __tmp185Reader = new StreamReader(this.__ToStream(__tmp185.ToString())))
            {
                bool __tmp185_first = true;
                while(__tmp185_first || !__tmp185Reader.EndOfStream)
                {
                    __tmp185_first = false;
                    string __tmp185Line = __tmp185Reader.ReadLine();
                    if (__tmp185Line == null)
                    {
                        __tmp185Line = "";
                    }
                    __out.Append(__tmp185Line);
                    __out.Append(__tmp182Suffix);
                    __out.AppendLine(); //504:100
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //505:1
            __out.AppendLine(); //505:64
            __out.Append("            }"); //506:1
            __out.AppendLine(); //506:14
            __out.Append("        }"); //507:1
            __out.AppendLine(); //507:10
            __out.Append("        public override int GetItemCount(out int count)"); //509:1
            __out.AppendLine(); //509:56
            __out.Append("        {"); //510:1
            __out.AppendLine(); //510:10
            string __tmp186Prefix = "            count = "; //511:1
            string __tmp187Suffix = "LanguageConfig.Instance.ColorableItems.Count;"; //511:51
            StringBuilder __tmp188 = new StringBuilder();
            __tmp188.Append(Properties.LanguageClassName);
            using(StreamReader __tmp188Reader = new StreamReader(this.__ToStream(__tmp188.ToString())))
            {
                bool __tmp188_first = true;
                while(__tmp188_first || !__tmp188Reader.EndOfStream)
                {
                    __tmp188_first = false;
                    string __tmp188Line = __tmp188Reader.ReadLine();
                    if (__tmp188Line == null)
                    {
                        __tmp188Line = "";
                    }
                    __out.Append(__tmp186Prefix);
                    __out.Append(__tmp188Line);
                    __out.Append(__tmp187Suffix);
                    __out.AppendLine(); //511:96
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //512:1
            __out.AppendLine(); //512:60
            __out.Append("        }"); //513:1
            __out.AppendLine(); //513:10
            __out.Append("        #endregion"); //514:1
            __out.AppendLine(); //514:19
            __out.Append("        public override void OnIdle(bool periodic)"); //516:1
            __out.AppendLine(); //516:51
            __out.Append("        {"); //517:1
            __out.AppendLine(); //517:10
            __out.Append("            // from IronPythonLanguage sample"); //518:1
            __out.AppendLine(); //518:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //519:1
            __out.AppendLine(); //519:93
            string __tmp189Prefix = "            "; //520:1
            string __tmp190Suffix = "LanguageSource)GetSource(this.LastActiveTextView);"; //520:95
            StringBuilder __tmp191 = new StringBuilder();
            __tmp191.Append(Properties.LanguageClassName);
            using(StreamReader __tmp191Reader = new StreamReader(this.__ToStream(__tmp191.ToString())))
            {
                bool __tmp191_first = true;
                while(__tmp191_first || !__tmp191Reader.EndOfStream)
                {
                    __tmp191_first = false;
                    string __tmp191Line = __tmp191Reader.ReadLine();
                    if (__tmp191Line == null)
                    {
                        __tmp191Line = "";
                    }
                    __out.Append(__tmp189Prefix);
                    __out.Append(__tmp191Line);
                }
            }
            string __tmp192Line = "LanguageSource src = ("; //520:43
            __out.Append(__tmp192Line);
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
                    __out.Append(__tmp193Line);
                    __out.Append(__tmp190Suffix);
                    __out.AppendLine(); //520:145
                }
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //521:1
            __out.AppendLine(); //521:74
            __out.Append("            {"); //522:1
            __out.AppendLine(); //522:14
            __out.Append("                src.LastParseTime = 0;"); //523:1
            __out.AppendLine(); //523:39
            __out.Append("            }"); //524:1
            __out.AppendLine(); //524:14
            __out.Append("            base.OnIdle(periodic);"); //525:1
            __out.AppendLine(); //525:35
            __out.Append("        }"); //526:1
            __out.AppendLine(); //526:10
            __out.Append("        public override string Name"); //528:1
            __out.AppendLine(); //528:36
            __out.Append("        {"); //529:1
            __out.AppendLine(); //529:10
            string __tmp194Prefix = "            get { return "; //530:1
            string __tmp195Suffix = "LanguageConfig.LanguageName; }"; //530:56
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
                    __out.AppendLine(); //530:86
                }
            }
            __out.Append("        }"); //531:1
            __out.AppendLine(); //531:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //533:1
            __out.AppendLine(); //533:96
            __out.Append("        {"); //534:1
            __out.AppendLine(); //534:10
            string __tmp197Prefix = "            return new "; //535:1
            string __tmp198Suffix = "LanguageViewFilter(mgr, newView);"; //535:54
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
                    __out.AppendLine(); //535:87
                }
            }
            __out.Append("        }"); //536:1
            __out.AppendLine(); //536:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //538:1
            __out.AppendLine(); //538:68
            __out.Append("        {"); //539:1
            __out.AppendLine(); //539:10
            string __tmp200Prefix = "            return new "; //540:1
            string __tmp201Suffix = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //540:54
            StringBuilder __tmp202 = new StringBuilder();
            __tmp202.Append(Properties.LanguageClassName);
            using(StreamReader __tmp202Reader = new StreamReader(this.__ToStream(__tmp202.ToString())))
            {
                bool __tmp202_first = true;
                while(__tmp202_first || !__tmp202Reader.EndOfStream)
                {
                    __tmp202_first = false;
                    string __tmp202Line = __tmp202Reader.ReadLine();
                    if (__tmp202Line == null)
                    {
                        __tmp202Line = "";
                    }
                    __out.Append(__tmp200Prefix);
                    __out.Append(__tmp202Line);
                    __out.Append(__tmp201Suffix);
                    __out.AppendLine(); //540:111
                }
            }
            __out.Append("        }"); //541:1
            __out.AppendLine(); //541:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //543:1
            __out.AppendLine(); //543:69
            __out.Append("        {"); //544:1
            __out.AppendLine(); //544:10
            string __tmp203Prefix = "            "; //545:1
            string __tmp204Suffix = "LanguageSource)this.GetSource(req.FileName);"; //545:98
            StringBuilder __tmp205 = new StringBuilder();
            __tmp205.Append(Properties.LanguageClassName);
            using(StreamReader __tmp205Reader = new StreamReader(this.__ToStream(__tmp205.ToString())))
            {
                bool __tmp205_first = true;
                while(__tmp205_first || !__tmp205Reader.EndOfStream)
                {
                    __tmp205_first = false;
                    string __tmp205Line = __tmp205Reader.ReadLine();
                    if (__tmp205Line == null)
                    {
                        __tmp205Line = "";
                    }
                    __out.Append(__tmp203Prefix);
                    __out.Append(__tmp205Line);
                }
            }
            string __tmp206Line = "LanguageSource source = ("; //545:43
            __out.Append(__tmp206Line);
            StringBuilder __tmp207 = new StringBuilder();
            __tmp207.Append(Properties.LanguageClassName);
            using(StreamReader __tmp207Reader = new StreamReader(this.__ToStream(__tmp207.ToString())))
            {
                bool __tmp207_first = true;
                while(__tmp207_first || !__tmp207Reader.EndOfStream)
                {
                    __tmp207_first = false;
                    string __tmp207Line = __tmp207Reader.ReadLine();
                    if (__tmp207Line == null)
                    {
                        __tmp207Line = "";
                    }
                    __out.Append(__tmp207Line);
                    __out.Append(__tmp204Suffix);
                    __out.AppendLine(); //545:142
                }
            }
            __out.Append("            switch (req.Reason)"); //546:1
            __out.AppendLine(); //546:32
            __out.Append("            {"); //547:1
            __out.AppendLine(); //547:14
            __out.Append("                case ParseReason.Check:"); //548:1
            __out.AppendLine(); //548:40
            __out.Append("                    // This is where you perform your syntax highlighting."); //549:1
            __out.AppendLine(); //549:75
            __out.Append("                    // Parse entire source as given in req.Text."); //550:1
            __out.AppendLine(); //550:65
            __out.Append("                    // Store results in the AuthoringScope object."); //551:1
            __out.AppendLine(); //551:67
            string __tmp208Prefix = "                    "; //552:1
            string __tmp209Suffix = "Compiler(req.Text);"; //552:105
            StringBuilder __tmp210 = new StringBuilder();
            __tmp210.Append(Properties.LanguageClassName);
            using(StreamReader __tmp210Reader = new StreamReader(this.__ToStream(__tmp210.ToString())))
            {
                bool __tmp210_first = true;
                while(__tmp210_first || !__tmp210Reader.EndOfStream)
                {
                    __tmp210_first = false;
                    string __tmp210Line = __tmp210Reader.ReadLine();
                    if (__tmp210Line == null)
                    {
                        __tmp210Line = "";
                    }
                    __out.Append(__tmp208Prefix);
                    __out.Append(__tmp210Line);
                }
            }
            string __tmp211Line = "Compiler compiler = new "; //552:51
            __out.Append(__tmp211Line);
            StringBuilder __tmp212 = new StringBuilder();
            __tmp212.Append(Properties.LanguageClassName);
            using(StreamReader __tmp212Reader = new StreamReader(this.__ToStream(__tmp212.ToString())))
            {
                bool __tmp212_first = true;
                while(__tmp212_first || !__tmp212Reader.EndOfStream)
                {
                    __tmp212_first = false;
                    string __tmp212Line = __tmp212Reader.ReadLine();
                    if (__tmp212Line == null)
                    {
                        __tmp212Line = "";
                    }
                    __out.Append(__tmp212Line);
                    __out.Append(__tmp209Suffix);
                    __out.AppendLine(); //552:124
                }
            }
            __out.Append("                    compiler.Compile();"); //553:1
            __out.AppendLine(); //553:40
            __out.Append("                    foreach (var msg in compiler.Diagnostics.GetMessages())"); //554:1
            __out.AppendLine(); //554:76
            __out.Append("                    {"); //555:1
            __out.AppendLine(); //555:22
            __out.Append("                        TextSpan span = new TextSpan();"); //556:1
            __out.AppendLine(); //556:56
            __out.Append("                        span.iStartLine = msg.TextSpan.StartLine - 1;"); //557:1
            __out.AppendLine(); //557:70
            __out.Append("                        span.iEndLine = msg.TextSpan.EndLine - 1;"); //558:1
            __out.AppendLine(); //558:66
            __out.Append("                        span.iStartIndex = msg.TextSpan.StartPosition - 1;"); //559:1
            __out.AppendLine(); //559:75
            __out.Append("                        span.iEndIndex = msg.TextSpan.EndPosition - 1;"); //560:1
            __out.AppendLine(); //560:71
            __out.Append("                        Severity severity = Severity.Error;"); //561:1
            __out.AppendLine(); //561:60
            __out.Append("                        switch (msg.Severity)"); //562:1
            __out.AppendLine(); //562:46
            __out.Append("                        {"); //563:1
            __out.AppendLine(); //563:26
            __out.Append("                            case MetaDslx.Core.Severity.Error:"); //564:1
            __out.AppendLine(); //564:63
            __out.Append("                                severity = Severity.Error;"); //565:1
            __out.AppendLine(); //565:59
            __out.Append("                                break;"); //566:1
            __out.AppendLine(); //566:39
            __out.Append("                            case MetaDslx.Core.Severity.Warning:"); //567:1
            __out.AppendLine(); //567:65
            __out.Append("                                severity = Severity.Warning;"); //568:1
            __out.AppendLine(); //568:61
            __out.Append("                                break;"); //569:1
            __out.AppendLine(); //569:39
            __out.Append("                            case MetaDslx.Core.Severity.Info:"); //570:1
            __out.AppendLine(); //570:62
            __out.Append("                                severity = Severity.Hint;"); //571:1
            __out.AppendLine(); //571:58
            __out.Append("                                break;"); //572:1
            __out.AppendLine(); //572:39
            __out.Append("                        }"); //573:1
            __out.AppendLine(); //573:26
            __out.Append("                        req.Sink.AddError(req.FileName, msg.Message, span, severity);"); //574:1
            __out.AppendLine(); //574:86
            __out.Append("                    }"); //575:1
            __out.AppendLine(); //575:22
            __out.Append("                    break;"); //576:1
            __out.AppendLine(); //576:27
            __out.Append("            }"); //577:1
            __out.AppendLine(); //577:14
            string __tmp213Prefix = "            return new "; //578:1
            string __tmp214Suffix = "LanguageAuthoringScope();"; //578:54
            StringBuilder __tmp215 = new StringBuilder();
            __tmp215.Append(Properties.LanguageClassName);
            using(StreamReader __tmp215Reader = new StreamReader(this.__ToStream(__tmp215.ToString())))
            {
                bool __tmp215_first = true;
                while(__tmp215_first || !__tmp215Reader.EndOfStream)
                {
                    __tmp215_first = false;
                    string __tmp215Line = __tmp215Reader.ReadLine();
                    if (__tmp215Line == null)
                    {
                        __tmp215Line = "";
                    }
                    __out.Append(__tmp213Prefix);
                    __out.Append(__tmp215Line);
                    __out.Append(__tmp214Suffix);
                    __out.AppendLine(); //578:79
                }
            }
            __out.Append("        }"); //579:1
            __out.AppendLine(); //579:10
            __out.Append("    }"); //580:1
            __out.AppendLine(); //580:6
            string __tmp216Prefix = "	public class "; //582:1
            string __tmp217Suffix = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //582:45
            StringBuilder __tmp218 = new StringBuilder();
            __tmp218.Append(Properties.LanguageClassName);
            using(StreamReader __tmp218Reader = new StreamReader(this.__ToStream(__tmp218.ToString())))
            {
                bool __tmp218_first = true;
                while(__tmp218_first || !__tmp218Reader.EndOfStream)
                {
                    __tmp218_first = false;
                    string __tmp218Line = __tmp218Reader.ReadLine();
                    if (__tmp218Line == null)
                    {
                        __tmp218Line = "";
                    }
                    __out.Append(__tmp216Prefix);
                    __out.Append(__tmp218Line);
                    __out.Append(__tmp217Suffix);
                    __out.AppendLine(); //582:99
                }
            }
            __out.Append("    {"); //583:1
            __out.AppendLine(); //583:6
            string __tmp219Prefix = "        public "; //584:1
            string __tmp220Suffix = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //584:46
            StringBuilder __tmp221 = new StringBuilder();
            __tmp221.Append(Properties.LanguageClassName);
            using(StreamReader __tmp221Reader = new StreamReader(this.__ToStream(__tmp221.ToString())))
            {
                bool __tmp221_first = true;
                while(__tmp221_first || !__tmp221Reader.EndOfStream)
                {
                    __tmp221_first = false;
                    string __tmp221Line = __tmp221Reader.ReadLine();
                    if (__tmp221Line == null)
                    {
                        __tmp221Line = "";
                    }
                    __out.Append(__tmp219Prefix);
                    __out.Append(__tmp221Line);
                    __out.Append(__tmp220Suffix);
                    __out.AppendLine(); //584:130
                }
            }
            __out.Append("            : base(service, textLines, colorizer)"); //585:1
            __out.AppendLine(); //585:50
            __out.Append("        {"); //586:1
            __out.AppendLine(); //586:10
            __out.Append("        }"); //588:1
            __out.AppendLine(); //588:10
            __out.Append("    }"); //589:1
            __out.AppendLine(); //589:6
            string __tmp222Prefix = "    public class "; //591:1
            string __tmp223Suffix = "LanguageViewFilter : ViewFilter"; //591:48
            StringBuilder __tmp224 = new StringBuilder();
            __tmp224.Append(Properties.LanguageClassName);
            using(StreamReader __tmp224Reader = new StreamReader(this.__ToStream(__tmp224.ToString())))
            {
                bool __tmp224_first = true;
                while(__tmp224_first || !__tmp224Reader.EndOfStream)
                {
                    __tmp224_first = false;
                    string __tmp224Line = __tmp224Reader.ReadLine();
                    if (__tmp224Line == null)
                    {
                        __tmp224Line = "";
                    }
                    __out.Append(__tmp222Prefix);
                    __out.Append(__tmp224Line);
                    __out.Append(__tmp223Suffix);
                    __out.AppendLine(); //591:79
                }
            }
            __out.Append("    {"); //592:1
            __out.AppendLine(); //592:6
            string __tmp225Prefix = "        public "; //593:1
            string __tmp226Suffix = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //593:46
            StringBuilder __tmp227 = new StringBuilder();
            __tmp227.Append(Properties.LanguageClassName);
            using(StreamReader __tmp227Reader = new StreamReader(this.__ToStream(__tmp227.ToString())))
            {
                bool __tmp227_first = true;
                while(__tmp227_first || !__tmp227Reader.EndOfStream)
                {
                    __tmp227_first = false;
                    string __tmp227Line = __tmp227Reader.ReadLine();
                    if (__tmp227Line == null)
                    {
                        __tmp227Line = "";
                    }
                    __out.Append(__tmp225Prefix);
                    __out.Append(__tmp227Line);
                    __out.Append(__tmp226Suffix);
                    __out.AppendLine(); //593:105
                }
            }
            __out.Append("            : base(mgr, view)"); //594:1
            __out.AppendLine(); //594:30
            __out.Append("        {"); //595:1
            __out.AppendLine(); //595:10
            __out.Append("        }"); //597:1
            __out.AppendLine(); //597:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //599:1
            __out.AppendLine(); //599:150
            __out.Append("        {"); //600:1
            __out.AppendLine(); //600:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //601:1
            __out.AppendLine(); //601:59
            __out.Append("            {"); //602:1
            __out.AppendLine(); //602:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //603:1
            __out.AppendLine(); //603:57
            __out.Append("                switch (cmd)"); //604:1
            __out.AppendLine(); //604:29
            __out.Append("                {"); //605:1
            __out.AppendLine(); //605:18
            __out.Append("                    case VsCommands2K.UP:"); //606:1
            __out.AppendLine(); //606:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //607:1
            __out.AppendLine(); //607:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //608:1
            __out.AppendLine(); //608:50
            __out.Append("                    case VsCommands2K.DOWN:"); //609:1
            __out.AppendLine(); //609:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //610:1
            __out.AppendLine(); //610:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //611:1
            __out.AppendLine(); //611:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //612:1
            __out.Append("\\"); //612:58
            __out.Append("0');"); //612:59
            __out.AppendLine(); //612:63
            __out.Append("                        return;"); //613:1
            __out.AppendLine(); //613:32
            __out.Append("                }"); //614:1
            __out.AppendLine(); //614:18
            __out.Append("            }"); //615:1
            __out.AppendLine(); //615:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //616:1
            __out.AppendLine(); //616:105
            __out.Append("        }"); //617:1
            __out.AppendLine(); //617:10
            __out.Append("    }"); //618:1
            __out.AppendLine(); //618:6
            __out.Append("}"); //620:1
            __out.AppendLine(); //620:2
            return __out.ToString();
        }

    }
}

