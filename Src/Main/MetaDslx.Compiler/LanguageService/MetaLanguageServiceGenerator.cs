using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_1131747271;
    namespace __Hidden_MetaLanguageServiceGenerator_1131747271
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
            __out.Append("using System.Drawing;"); //27:1
            __out.AppendLine(); //27:22
            __out.Append("using Microsoft.VisualStudio;"); //28:1
            __out.AppendLine(); //28:30
            __out.Append("using Microsoft.VisualStudio.Shell;"); //29:1
            __out.AppendLine(); //29:36
            __out.AppendLine(); //30:1
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //31:1
            __out.AppendLine(); //31:70
            __out.AppendLine(); //32:1
            string __tmp1Prefix = "namespace "; //33:1
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
                    __out.AppendLine(); //33:48
                }
            }
            __out.Append("{"); //34:1
            __out.AppendLine(); //34:2
            string __tmp4Prefix = "    public class "; //35:1
            string __tmp5Suffix = "LanguageAuthoringScope : AuthoringScope"; //35:48
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
                    __out.AppendLine(); //35:87
                }
            }
            __out.Append("    {"); //36:1
            __out.AppendLine(); //36:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //37:1
            __out.AppendLine(); //37:84
            __out.Append("        {"); //38:1
            __out.AppendLine(); //38:10
            __out.Append("            span = new TextSpan();"); //39:1
            __out.AppendLine(); //39:35
            __out.Append("            return null;"); //40:1
            __out.AppendLine(); //40:25
            __out.Append("        }"); //41:1
            __out.AppendLine(); //41:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //43:1
            __out.AppendLine(); //43:126
            __out.Append("        {"); //44:1
            __out.AppendLine(); //44:10
            __out.Append("            return null;"); //45:1
            __out.AppendLine(); //45:25
            __out.Append("        }"); //46:1
            __out.AppendLine(); //46:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //48:1
            __out.AppendLine(); //48:75
            __out.Append("        {"); //49:1
            __out.AppendLine(); //49:10
            __out.Append("            return null;"); //50:1
            __out.AppendLine(); //50:25
            __out.Append("        }"); //51:1
            __out.AppendLine(); //51:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //53:1
            __out.AppendLine(); //53:149
            __out.Append("        {"); //54:1
            __out.AppendLine(); //54:10
            __out.Append("            span = new TextSpan();"); //55:1
            __out.AppendLine(); //55:35
            __out.Append("            return null;"); //56:1
            __out.AppendLine(); //56:25
            __out.Append("        }"); //57:1
            __out.AppendLine(); //57:10
            __out.Append("    }"); //58:1
            __out.AppendLine(); //58:6
            string __tmp7Prefix = "	public class "; //60:1
            string __tmp8Suffix = "LanguageColorizer : Colorizer"; //60:45
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
                    __out.AppendLine(); //60:74
                }
            }
            __out.Append("    {"); //61:1
            __out.AppendLine(); //61:6
            string __tmp10Prefix = "        public "; //62:1
            string __tmp11Suffix = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //62:46
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
                    __out.AppendLine(); //62:123
                }
            }
            __out.Append("            : base(svc, buffer, scanner)"); //63:1
            __out.AppendLine(); //63:41
            __out.Append("        {"); //64:1
            __out.AppendLine(); //64:10
            __out.Append("        }"); //65:1
            __out.AppendLine(); //65:10
            __out.Append("        #region IVsColorizer Members"); //67:1
            __out.AppendLine(); //67:37
            string __tmp13Prefix = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //69:1
            string __tmp14Suffix = " attrs)"; //69:97
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
                    __out.AppendLine(); //69:104
                }
            }
            __out.Append("        {"); //70:1
            __out.AppendLine(); //70:10
            __out.Append("            if (attrs == null) return state;"); //71:1
            __out.AppendLine(); //71:45
            __out.Append("            int linepos = 0;"); //72:1
            __out.AppendLine(); //72:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //73:1
            __out.AppendLine(); //73:75
            __out.Append("            // random color junk on the screen."); //74:1
            __out.AppendLine(); //74:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //75:1
            __out.AppendLine(); //75:65
            string __tmp16Prefix = "                attrs"; //76:1
            string __tmp17Suffix = " = (uint)TokenColor.Text;"; //76:35
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
                    __out.AppendLine(); //76:60
                }
            }
            __out.Append("            if (this.Scanner != null)"); //77:1
            __out.AppendLine(); //77:38
            __out.Append("            {"); //78:1
            __out.AppendLine(); //78:14
            __out.Append("                try"); //79:1
            __out.AppendLine(); //79:20
            __out.Append("                {"); //80:1
            __out.AppendLine(); //80:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //81:1
            __out.AppendLine(); //81:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //83:1
            __out.AppendLine(); //83:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //85:1
            __out.AppendLine(); //85:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //87:1
            __out.AppendLine(); //87:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //89:1
            __out.AppendLine(); //89:94
            __out.Append("                    {"); //90:1
            __out.AppendLine(); //90:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //91:1
            __out.AppendLine(); //91:103
            __out.Append("                        {"); //92:1
            __out.AppendLine(); //92:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //93:1
            __out.AppendLine(); //93:72
            __out.Append("                            {"); //94:1
            __out.AppendLine(); //94:30
            string __tmp19Prefix = "                                attrs"; //95:1
            string __tmp20Suffix = " = (uint)tokenInfo.Color;"; //95:51
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
                    __out.AppendLine(); //95:76
                }
            }
            __out.Append("                            }"); //96:1
            __out.AppendLine(); //96:30
            __out.Append("                        }"); //97:1
            __out.AppendLine(); //97:26
            __out.Append("                    }"); //98:1
            __out.AppendLine(); //98:22
            __out.Append("                }"); //99:1
            __out.AppendLine(); //99:18
            __out.Append("                catch (Exception)"); //100:1
            __out.AppendLine(); //100:34
            __out.Append("                {"); //101:1
            __out.AppendLine(); //101:18
            __out.Append("                    // Ignore exceptions"); //102:1
            __out.AppendLine(); //102:41
            __out.Append("                }"); //103:1
            __out.AppendLine(); //103:18
            __out.Append("            }"); //104:1
            __out.AppendLine(); //104:14
            __out.Append("            return state;"); //105:1
            __out.AppendLine(); //105:26
            __out.Append("        }"); //106:1
            __out.AppendLine(); //106:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //108:1
            __out.AppendLine(); //108:64
            __out.Append("        {"); //109:1
            __out.AppendLine(); //109:10
            __out.Append("            piStartState = 0;"); //110:1
            __out.AppendLine(); //110:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //111:1
            __out.AppendLine(); //111:60
            __out.Append("        }"); //112:1
            __out.AppendLine(); //112:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //114:1
            __out.AppendLine(); //114:98
            __out.Append("        {"); //115:1
            __out.AppendLine(); //115:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //116:1
            __out.AppendLine(); //116:66
            __out.Append("            if (text != null)"); //117:1
            __out.AppendLine(); //117:30
            __out.Append("            {"); //118:1
            __out.AppendLine(); //118:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //119:1
            __out.AppendLine(); //119:49
            string __tmp22Prefix = "                (("; //120:1
            string __tmp23Suffix = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //120:49
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
                    __out.AppendLine(); //120:100
                }
            }
            __out.Append("            }"); //121:1
            __out.AppendLine(); //121:14
            __out.Append("            return iState;"); //122:1
            __out.AppendLine(); //122:27
            __out.Append("        }"); //123:1
            __out.AppendLine(); //123:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //125:1
            __out.AppendLine(); //125:68
            __out.Append("        {"); //126:1
            __out.AppendLine(); //126:10
            __out.Append("            pfFlag = 1;"); //127:1
            __out.AppendLine(); //127:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //128:1
            __out.AppendLine(); //128:60
            __out.Append("        }"); //129:1
            __out.AppendLine(); //129:10
            __out.Append("        #endregion"); //131:1
            __out.AppendLine(); //131:19
            __out.Append("    }"); //132:1
            __out.AppendLine(); //132:6
            string __tmp25Prefix = "    public abstract class "; //135:1
            string __tmp26Suffix = "LanguageConfigBase"; //135:57
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
                    __out.AppendLine(); //135:75
                }
            }
            __out.Append("    {"); //136:1
            __out.AppendLine(); //136:6
            string __tmp28Prefix = "        private static "; //137:1
            string __tmp29Suffix = "LanguageConfig instance = null;"; //137:54
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
                    __out.AppendLine(); //137:85
                }
            }
            string __tmp31Prefix = "        public static "; //138:1
            string __tmp32Suffix = "LanguageConfig Instance"; //138:53
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
                    __out.AppendLine(); //138:76
                }
            }
            __out.Append("        {"); //139:1
            __out.AppendLine(); //139:10
            __out.Append("            get "); //140:1
            __out.AppendLine(); //140:17
            __out.Append("            {"); //141:1
            __out.AppendLine(); //141:14
            __out.Append("                if (instance == null)"); //142:1
            __out.AppendLine(); //142:38
            __out.Append("                {"); //143:1
            __out.AppendLine(); //143:18
            string __tmp34Prefix = "					// If there is a compile error in the following line, create a class "; //144:1
            string __tmp35Suffix = "LanguageConfig"; //144:105
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
                    __out.AppendLine(); //144:119
                }
            }
            string __tmp37Prefix = "					// which is a subclass of "; //145:1
            string __tmp38Suffix = "LanguageConfigBase"; //145:62
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
                    __out.AppendLine(); //145:80
                }
            }
            string __tmp40Prefix = "                    instance = new "; //146:1
            string __tmp41Suffix = "LanguageConfig();"; //146:66
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
                    __out.AppendLine(); //146:83
                }
            }
            __out.Append("                }"); //147:1
            __out.AppendLine(); //147:18
            __out.Append("                return instance;"); //148:1
            __out.AppendLine(); //148:33
            __out.Append("            }"); //149:1
            __out.AppendLine(); //149:14
            __out.Append("        }"); //150:1
            __out.AppendLine(); //150:10
            string __tmp43Prefix = "        private List<"; //151:1
            string __tmp44Suffix = "LanguageColorableItem>();"; //151:131
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
            string __tmp46Line = "LanguageColorableItem> colorableItems = new List<"; //151:52
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
                    __out.AppendLine(); //151:156
                }
            }
            string __tmp48Prefix = "        public IList<"; //152:1
            string __tmp49Suffix = "LanguageColorableItem> ColorableItems"; //152:52
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
                    __out.AppendLine(); //152:89
                }
            }
            __out.Append("        {"); //153:1
            __out.AppendLine(); //153:10
            __out.Append("            get { return colorableItems; }"); //154:1
            __out.AppendLine(); //154:43
            __out.Append("        }"); //155:1
            __out.AppendLine(); //155:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)"); //156:1
            __out.AppendLine(); //156:93
            __out.Append("        {"); //157:1
            __out.AppendLine(); //157:10
            __out.Append("            return CreateColor(name, type, foregroundColor, false, false);"); //158:1
            __out.AppendLine(); //158:75
            __out.Append("        }"); //159:1
            __out.AppendLine(); //159:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)"); //160:1
            __out.AppendLine(); //160:98
            __out.Append("        {"); //161:1
            __out.AppendLine(); //161:10
            __out.Append("            return CreateColor(name, type, foregroundIndex, false, false);"); //162:1
            __out.AppendLine(); //162:75
            __out.Append("        }"); //163:1
            __out.AppendLine(); //163:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)"); //164:1
            __out.AppendLine(); //164:124
            __out.Append("        {"); //165:1
            __out.AppendLine(); //165:10
            string __tmp51Prefix = "            colorableItems.Add(new "; //166:1
            string __tmp52Suffix = "LanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));"; //166:66
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
                    __out.AppendLine(); //166:197
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //167:1
            __out.AppendLine(); //167:53
            __out.Append("        }"); //168:1
            __out.AppendLine(); //168:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)"); //169:1
            __out.AppendLine(); //169:129
            __out.Append("        {"); //170:1
            __out.AppendLine(); //170:10
            string __tmp54Prefix = "            colorableItems.Add(new "; //171:1
            string __tmp55Suffix = "LanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));"; //171:66
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
                    __out.AppendLine(); //171:192
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //172:1
            __out.AppendLine(); //172:53
            __out.Append("        }"); //173:1
            __out.AppendLine(); //173:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"); //174:1
            __out.AppendLine(); //174:203
            __out.Append("        {"); //175:1
            __out.AppendLine(); //175:10
            string __tmp57Prefix = "            colorableItems.Add(new "; //176:1
            string __tmp58Suffix = "LanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));"; //176:66
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
                    __out.AppendLine(); //176:190
                }
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //177:1
            __out.AppendLine(); //177:53
            __out.Append("        }"); //178:1
            __out.AppendLine(); //178:10
            __out.Append("    }"); //179:1
            __out.AppendLine(); //179:6
            string __tmp60Prefix = "    public class "; //180:1
            string __tmp61Suffix = "LanguageColorableItem : IVsColorableItem, IVsHiColorItem"; //180:48
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append(Properties.LanguageClassName);
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
                    __out.AppendLine(); //180:104
                }
            }
            __out.Append("    {"); //181:1
            __out.AppendLine(); //181:6
            __out.Append("        // Indicates that the returned RGB value is really an index"); //182:1
            __out.AppendLine(); //182:68
            __out.Append("        // into a predefined list of colors."); //183:1
            __out.AppendLine(); //183:45
            __out.Append("        private const uint COLOR_INDEXED = 0x01000000;"); //184:1
            __out.AppendLine(); //184:55
            __out.Append("        public string DisplayName { get; private set; }"); //186:1
            __out.AppendLine(); //186:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //187:1
            __out.AppendLine(); //187:57
            __out.Append("        public COLORINDEX BackgroundIndex { get; private set; }"); //188:1
            __out.AppendLine(); //188:64
            __out.Append("        public COLORINDEX ForegroundIndex { get; private set; }"); //189:1
            __out.AppendLine(); //189:64
            __out.Append("        public uint BackgroundColor { get; private set; }"); //190:1
            __out.AppendLine(); //190:58
            __out.Append("        public uint ForegroundColor { get; private set; }"); //191:1
            __out.AppendLine(); //191:58
            __out.Append("        public uint FontFlags { get; private set; }"); //192:1
            __out.AppendLine(); //192:52
            string __tmp63Prefix = "        public "; //194:1
            string __tmp64Suffix = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"; //194:46
            StringBuilder __tmp65 = new StringBuilder();
            __tmp65.Append(Properties.LanguageClassName);
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
                    __out.AppendLine(); //194:241
                }
            }
            __out.Append("        {"); //195:1
            __out.AppendLine(); //195:10
            __out.Append("            this.DisplayName = displayName;"); //196:1
            __out.AppendLine(); //196:44
            __out.Append("            this.TokenType = tokenType;"); //197:1
            __out.AppendLine(); //197:40
            __out.Append("            this.BackgroundIndex = backgroundIndex;"); //198:1
            __out.AppendLine(); //198:52
            __out.Append("            this.ForegroundIndex = foregroundIndex;"); //199:1
            __out.AppendLine(); //199:52
            __out.Append("            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);"); //200:1
            __out.AppendLine(); //200:98
            __out.Append("            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);"); //201:1
            __out.AppendLine(); //201:98
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //202:1
            __out.AppendLine(); //202:57
            __out.Append("            if (bold)"); //203:1
            __out.AppendLine(); //203:22
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;"); //204:1
            __out.AppendLine(); //204:75
            __out.Append("            if (strikethrough)"); //205:1
            __out.AppendLine(); //205:31
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //206:1
            __out.AppendLine(); //206:84
            __out.Append("        }"); //207:1
            __out.AppendLine(); //207:10
            __out.Append("        #region IVsColorableItem Members"); //209:1
            __out.AppendLine(); //209:41
            string __tmp66Prefix = "        public int GetDefaultColors(COLORINDEX"; //210:1
            string __tmp67Suffix = " piBackground)"; //210:84
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append("[]");
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
                }
            }
            string __tmp69Line = " piForeground, COLORINDEX"; //210:53
            __out.Append(__tmp69Line);
            StringBuilder __tmp70 = new StringBuilder();
            __tmp70.Append("[]");
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
                    __out.Append(__tmp70Line);
                    __out.Append(__tmp67Suffix);
                    __out.AppendLine(); //210:98
                }
            }
            __out.Append("        {"); //211:1
            __out.AppendLine(); //211:10
            __out.Append("            if (null == piForeground)"); //212:1
            __out.AppendLine(); //212:38
            __out.Append("            {"); //213:1
            __out.AppendLine(); //213:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //214:1
            __out.AppendLine(); //214:65
            __out.Append("            }"); //215:1
            __out.AppendLine(); //215:14
            __out.Append("            if (0 == piForeground.Length)"); //216:1
            __out.AppendLine(); //216:42
            __out.Append("            {"); //217:1
            __out.AppendLine(); //217:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //218:1
            __out.AppendLine(); //218:71
            __out.Append("            }"); //219:1
            __out.AppendLine(); //219:14
            string __tmp71Prefix = "            piForeground"; //220:1
            string __tmp72Suffix = " = this.ForegroundIndex;"; //220:32
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append("[0]");
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
                    __out.AppendLine(); //220:56
                }
            }
            __out.Append("            if (null == piBackground)"); //221:1
            __out.AppendLine(); //221:38
            __out.Append("            {"); //222:1
            __out.AppendLine(); //222:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //223:1
            __out.AppendLine(); //223:65
            __out.Append("            }"); //224:1
            __out.AppendLine(); //224:14
            __out.Append("            if (0 == piBackground.Length)"); //225:1
            __out.AppendLine(); //225:42
            __out.Append("            {"); //226:1
            __out.AppendLine(); //226:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //227:1
            __out.AppendLine(); //227:71
            __out.Append("            }"); //228:1
            __out.AppendLine(); //228:14
            string __tmp74Prefix = "            piBackground"; //229:1
            string __tmp75Suffix = " = this.BackgroundIndex;"; //229:32
            StringBuilder __tmp76 = new StringBuilder();
            __tmp76.Append("[0]");
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
                    __out.AppendLine(); //229:56
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //230:1
            __out.AppendLine(); //230:60
            __out.Append("        }"); //231:1
            __out.AppendLine(); //231:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //232:1
            __out.AppendLine(); //232:62
            __out.Append("        {"); //233:1
            __out.AppendLine(); //233:10
            __out.Append("            pdwFontFlags = this.FontFlags;"); //234:1
            __out.AppendLine(); //234:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //235:1
            __out.AppendLine(); //235:60
            __out.Append("        }"); //236:1
            __out.AppendLine(); //236:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //237:1
            __out.AppendLine(); //237:56
            __out.Append("        {"); //238:1
            __out.AppendLine(); //238:10
            __out.Append("            pbstrName = this.DisplayName;"); //239:1
            __out.AppendLine(); //239:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //240:1
            __out.AppendLine(); //240:60
            __out.Append("        }"); //241:1
            __out.AppendLine(); //241:10
            __out.Append("        public int GetColorData(int cdElement, out uint pcrColor)"); //243:1
            __out.AppendLine(); //243:66
            __out.Append("        {"); //244:1
            __out.AppendLine(); //244:10
            __out.Append("            int retval = VSConstants.E_NOTIMPL;"); //245:1
            __out.AppendLine(); //245:48
            __out.Append("            pcrColor = 0;"); //246:1
            __out.AppendLine(); //246:26
            __out.Append("            switch ((__tagVSCOLORDATA)cdElement)"); //248:1
            __out.AppendLine(); //248:49
            __out.Append("            {"); //249:1
            __out.AppendLine(); //249:14
            __out.Append("                case __tagVSCOLORDATA.CD_BACKGROUND:"); //250:1
            __out.AppendLine(); //250:53
            __out.Append("                    pcrColor = this.BackgroundIndex > 0 ?"); //251:1
            __out.AppendLine(); //251:58
            __out.Append("                                   (uint)this.BackgroundIndex | COLOR_INDEXED"); //252:1
            __out.AppendLine(); //252:78
            __out.Append("                                   : this.BackgroundColor;"); //253:1
            __out.AppendLine(); //253:59
            __out.Append("                    retval = VSConstants.S_OK;"); //254:1
            __out.AppendLine(); //254:47
            __out.Append("                    break;"); //255:1
            __out.AppendLine(); //255:27
            __out.Append("                case __tagVSCOLORDATA.CD_FOREGROUND:"); //257:1
            __out.AppendLine(); //257:53
            __out.Append("                case __tagVSCOLORDATA.CD_LINECOLOR:"); //258:1
            __out.AppendLine(); //258:52
            __out.Append("                    pcrColor = this.ForegroundIndex > 0 ?"); //259:1
            __out.AppendLine(); //259:58
            __out.Append("                                   (uint)this.ForegroundIndex | COLOR_INDEXED"); //260:1
            __out.AppendLine(); //260:78
            __out.Append("                                   : this.ForegroundColor;"); //261:1
            __out.AppendLine(); //261:59
            __out.Append("                    retval = VSConstants.S_OK;"); //262:1
            __out.AppendLine(); //262:47
            __out.Append("                    break;"); //263:1
            __out.AppendLine(); //263:27
            __out.Append("                default:"); //265:1
            __out.AppendLine(); //265:25
            __out.Append("                    retval = VSConstants.E_INVALIDARG;"); //266:1
            __out.AppendLine(); //266:55
            __out.Append("                    break;"); //267:1
            __out.AppendLine(); //267:27
            __out.Append("            }"); //268:1
            __out.AppendLine(); //268:14
            __out.Append("            return retval;"); //269:1
            __out.AppendLine(); //269:27
            __out.Append("        }"); //271:1
            __out.AppendLine(); //271:10
            __out.Append("        #endregion"); //272:1
            __out.AppendLine(); //272:19
            __out.Append("    }"); //273:1
            __out.AppendLine(); //273:6
            string __tmp77Prefix = "    "; //276:1
            string __tmp78Suffix = string.Empty; 
            StringBuilder __tmp79 = new StringBuilder();
            __tmp79.Append("[ComVisible(true)]");
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
                    __out.AppendLine(); //276:27
                }
            }
            string __tmp80Prefix = "    "; //277:1
            string __tmp81Suffix = string.Empty; 
            StringBuilder __tmp82 = new StringBuilder();
            __tmp82.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "GeneratorServiceGuid)]");
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
                    __out.AppendLine(); //277:116
                }
            }
            string __tmp83Prefix = "    "; //278:1
            string __tmp84Suffix = string.Empty; 
            StringBuilder __tmp85 = new StringBuilder();
            __tmp85.Append("[ProvideObject(typeof(" + Properties.LanguageClassName + "GeneratorService), RegisterUsing = RegistrationMethod.CodeBase)]");
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
                    __out.AppendLine(); //278:127
                }
            }
            string __tmp86Prefix = "    "; //279:1
            string __tmp87Suffix = string.Empty; 
            StringBuilder __tmp88 = new StringBuilder();
            __tmp88.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.FileExtension)]");
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
                    __out.AppendLine(); //279:284
                }
            }
            string __tmp89Prefix = "    "; //280:1
            string __tmp90Suffix = string.Empty; 
            StringBuilder __tmp91 = new StringBuilder();
            __tmp91.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorServiceName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, GeneratesDesignTimeSource = true)]");
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
                    __out.AppendLine(); //280:325
                }
            }
            if (Properties.GenerateMultipleFiles) //281:3
            {
                string __tmp92Prefix = "    public class "; //282:1
                string __tmp93Suffix = "GeneratorService : VsMultipleFileGenerator<object>"; //282:48
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
                        __out.AppendLine(); //282:98
                    }
                }
                __out.Append("    {"); //283:1
                __out.AppendLine(); //283:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //284:1
                __out.AppendLine(); //284:146
                __out.Append("		{"); //285:1
                __out.AppendLine(); //285:4
                string __tmp95Prefix = "            // If there is a compile error in the following line, create a class "; //286:1
                string __tmp96Suffix = "Generator"; //286:112
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
                        __out.AppendLine(); //286:121
                    }
                }
                __out.Append("            // which is a subclass of MultipleFileGenerator<object>"); //287:1
                __out.AppendLine(); //287:68
                string __tmp98Prefix = "			return new "; //288:1
                string __tmp99Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //288:45
                StringBuilder __tmp100 = new StringBuilder();
                __tmp100.Append(Properties.LanguageClassName);
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
                        __out.AppendLine(); //288:107
                    }
                }
                __out.Append("		}"); //289:1
                __out.AppendLine(); //289:4
                __out.AppendLine(); //290:1
                __out.Append("        public override string GetDefaultFileExtension()"); //291:1
                __out.AppendLine(); //291:57
                __out.Append("        {"); //292:1
                __out.AppendLine(); //292:10
                string __tmp101Prefix = "            return "; //293:1
                string __tmp102Suffix = "Generator.DefaultExtension;"; //293:50
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
                        __out.AppendLine(); //293:77
                    }
                }
                __out.Append("        }"); //294:1
                __out.AppendLine(); //294:10
                __out.Append("    }"); //295:1
                __out.AppendLine(); //295:6
            }
            else //296:3
            {
                string __tmp104Prefix = "    public class "; //297:1
                string __tmp105Suffix = "GeneratorService : VsSingleFileGenerator"; //297:48
                StringBuilder __tmp106 = new StringBuilder();
                __tmp106.Append(Properties.LanguageClassName);
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
                        __out.AppendLine(); //297:88
                    }
                }
                __out.Append("    {"); //298:1
                __out.AppendLine(); //298:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //299:1
                __out.AppendLine(); //299:136
                __out.Append("		{"); //300:1
                __out.AppendLine(); //300:4
                string __tmp107Prefix = "            // If there is a compile error in the following line, create a class "; //301:1
                string __tmp108Suffix = "Generator"; //301:112
                StringBuilder __tmp109 = new StringBuilder();
                __tmp109.Append(Properties.LanguageClassName);
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
                        __out.AppendLine(); //301:121
                    }
                }
                __out.Append("            // which is a subclass of SingleFileGenerator"); //302:1
                __out.AppendLine(); //302:58
                string __tmp110Prefix = "			return new "; //303:1
                string __tmp111Suffix = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //303:45
                StringBuilder __tmp112 = new StringBuilder();
                __tmp112.Append(Properties.LanguageClassName);
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
                        __out.Append(__tmp111Suffix);
                        __out.AppendLine(); //303:107
                    }
                }
                __out.Append("		}"); //304:1
                __out.AppendLine(); //304:4
                __out.AppendLine(); //305:1
                __out.Append("        public override string GetDefaultFileExtension()"); //306:1
                __out.AppendLine(); //306:57
                __out.Append("        {"); //307:1
                __out.AppendLine(); //307:10
                string __tmp113Prefix = "            return "; //308:1
                string __tmp114Suffix = "Generator.DefaultExtension;"; //308:50
                StringBuilder __tmp115 = new StringBuilder();
                __tmp115.Append(Properties.LanguageClassName);
                using(StreamReader __tmp115Reader = new StreamReader(this.__ToStream(__tmp115.ToString())))
                {
                    bool __tmp115_first = true;
                    while(__tmp115_first || !__tmp115Reader.EndOfStream)
                    {
                        __tmp115_first = false;
                        string __tmp115Line = __tmp115Reader.ReadLine();
                        if (__tmp115Line == null)
                        {
                            __tmp115Line = "";
                        }
                        __out.Append(__tmp113Prefix);
                        __out.Append(__tmp115Line);
                        __out.Append(__tmp114Suffix);
                        __out.AppendLine(); //308:77
                    }
                }
                __out.Append("        }"); //309:1
                __out.AppendLine(); //309:10
                __out.Append("    }"); //310:1
                __out.AppendLine(); //310:6
            }
            string __tmp116Prefix = "    public class "; //314:1
            string __tmp117Suffix = "LanguageScanner : IScanner"; //314:48
            StringBuilder __tmp118 = new StringBuilder();
            __tmp118.Append(Properties.LanguageClassName);
            using(StreamReader __tmp118Reader = new StreamReader(this.__ToStream(__tmp118.ToString())))
            {
                bool __tmp118_first = true;
                while(__tmp118_first || !__tmp118Reader.EndOfStream)
                {
                    __tmp118_first = false;
                    string __tmp118Line = __tmp118Reader.ReadLine();
                    if (__tmp118Line == null)
                    {
                        __tmp118Line = "";
                    }
                    __out.Append(__tmp116Prefix);
                    __out.Append(__tmp118Line);
                    __out.Append(__tmp117Suffix);
                    __out.AppendLine(); //314:74
                }
            }
            __out.Append("    {"); //315:1
            __out.AppendLine(); //315:6
            __out.Append("        private int currentOffset;"); //316:1
            __out.AppendLine(); //316:35
            __out.Append("        private string currentLine;"); //317:1
            __out.AppendLine(); //317:36
            string __tmp119Prefix = "        private "; //318:1
            string __tmp120Suffix = "Lexer lexer;"; //318:46
            StringBuilder __tmp121 = new StringBuilder();
            __tmp121.Append(Properties.LanguageFullName);
            using(StreamReader __tmp121Reader = new StreamReader(this.__ToStream(__tmp121.ToString())))
            {
                bool __tmp121_first = true;
                while(__tmp121_first || !__tmp121Reader.EndOfStream)
                {
                    __tmp121_first = false;
                    string __tmp121Line = __tmp121Reader.ReadLine();
                    if (__tmp121Line == null)
                    {
                        __tmp121Line = "";
                    }
                    __out.Append(__tmp119Prefix);
                    __out.Append(__tmp121Line);
                    __out.Append(__tmp120Suffix);
                    __out.AppendLine(); //318:58
                }
            }
            __out.Append("        private IEnumerable<SyntaxAnnotation> modeAnnotations;"); //319:1
            __out.AppendLine(); //319:63
            __out.Append("        private IEnumerable<SyntaxAnnotation> syntaxAnnotations;"); //320:1
            __out.AppendLine(); //320:65
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //321:1
            __out.AppendLine(); //321:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //322:1
            __out.AppendLine(); //322:62
            __out.Append("        private int lastState;"); //323:1
            __out.AppendLine(); //323:31
            string __tmp122Prefix = "        public "; //325:1
            string __tmp123Suffix = "LanguageScanner()"; //325:46
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
                    __out.AppendLine(); //325:63
                }
            }
            __out.Append("        {"); //326:1
            __out.AppendLine(); //326:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //327:1
            __out.AppendLine(); //327:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //328:1
            __out.AppendLine(); //328:71
            __out.Append("            this.lastState = 0;"); //329:1
            __out.AppendLine(); //329:32
            string __tmp125Prefix = "            "; //330:1
            string __tmp126Suffix = "LexerAnnotator();"; //330:102
            StringBuilder __tmp127 = new StringBuilder();
            __tmp127.Append(Properties.LanguageFullName);
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
            string __tmp128Line = "LexerAnnotator annotator = new "; //330:42
            __out.Append(__tmp128Line);
            StringBuilder __tmp129 = new StringBuilder();
            __tmp129.Append(Properties.LanguageFullName);
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
                    __out.Append(__tmp126Suffix);
                    __out.AppendLine(); //330:119
                }
            }
            __out.Append("            List<SyntaxAnnotation> mal = new List<SyntaxAnnotation>();"); //331:1
            __out.AppendLine(); //331:71
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //332:1
            __out.AppendLine(); //332:72
            __out.Append("            {"); //333:1
            __out.AppendLine(); //333:14
            __out.Append("                foreach (var annot in annotList)"); //334:1
            __out.AppendLine(); //334:49
            __out.Append("                {"); //335:1
            __out.AppendLine(); //335:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //336:1
            __out.AppendLine(); //336:51
            __out.Append("                    {"); //337:1
            __out.AppendLine(); //337:22
            __out.Append("                        mal.Add((SyntaxAnnotation)annot);"); //338:1
            __out.AppendLine(); //338:58
            __out.Append("                    }"); //339:1
            __out.AppendLine(); //339:22
            __out.Append("                }"); //340:1
            __out.AppendLine(); //340:18
            __out.Append("            }"); //341:1
            __out.AppendLine(); //341:14
            __out.Append("            this.modeAnnotations = mal;"); //342:1
            __out.AppendLine(); //342:40
            __out.Append("            List<SyntaxAnnotation> sal = new List<SyntaxAnnotation>();"); //343:1
            __out.AppendLine(); //343:71
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //344:1
            __out.AppendLine(); //344:73
            __out.Append("            {"); //345:1
            __out.AppendLine(); //345:14
            __out.Append("                foreach (var annot in annotList)"); //346:1
            __out.AppendLine(); //346:49
            __out.Append("                {"); //347:1
            __out.AppendLine(); //347:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //348:1
            __out.AppendLine(); //348:51
            __out.Append("                    {"); //349:1
            __out.AppendLine(); //349:22
            __out.Append("                        sal.Add((SyntaxAnnotation)annot);"); //350:1
            __out.AppendLine(); //350:58
            __out.Append("                    }"); //351:1
            __out.AppendLine(); //351:22
            __out.Append("                }"); //352:1
            __out.AppendLine(); //352:18
            __out.Append("            }"); //353:1
            __out.AppendLine(); //353:14
            __out.Append("            this.syntaxAnnotations = sal;"); //354:1
            __out.AppendLine(); //354:42
            __out.Append("        }"); //355:1
            __out.AppendLine(); //355:10
            string __tmp130Prefix = "        private void LoadState(int state, "; //357:1
            string __tmp131Suffix = "Lexer lexer)"; //357:72
            StringBuilder __tmp132 = new StringBuilder();
            __tmp132.Append(Properties.LanguageFullName);
            using(StreamReader __tmp132Reader = new StreamReader(this.__ToStream(__tmp132.ToString())))
            {
                bool __tmp132_first = true;
                while(__tmp132_first || !__tmp132Reader.EndOfStream)
                {
                    __tmp132_first = false;
                    string __tmp132Line = __tmp132Reader.ReadLine();
                    if (__tmp132Line == null)
                    {
                        __tmp132Line = "";
                    }
                    __out.Append(__tmp130Prefix);
                    __out.Append(__tmp132Line);
                    __out.Append(__tmp131Suffix);
                    __out.AppendLine(); //357:84
                }
            }
            __out.Append("        {"); //358:1
            __out.AppendLine(); //358:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //359:1
            __out.AppendLine(); //359:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //360:1
            __out.AppendLine(); //360:55
            __out.Append("            value.Restore(lexer);"); //361:1
            __out.AppendLine(); //361:34
            __out.Append("        }"); //362:1
            __out.AppendLine(); //362:10
            string __tmp133Prefix = "        private int SaveState("; //364:1
            string __tmp134Suffix = "Lexer lexer)"; //364:60
            StringBuilder __tmp135 = new StringBuilder();
            __tmp135.Append(Properties.LanguageFullName);
            using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
            {
                bool __tmp135_first = true;
                while(__tmp135_first || !__tmp135Reader.EndOfStream)
                {
                    __tmp135_first = false;
                    string __tmp135Line = __tmp135Reader.ReadLine();
                    if (__tmp135Line == null)
                    {
                        __tmp135Line = "";
                    }
                    __out.Append(__tmp133Prefix);
                    __out.Append(__tmp135Line);
                    __out.Append(__tmp134Suffix);
                    __out.AppendLine(); //364:72
                }
            }
            __out.Append("        {"); //365:1
            __out.AppendLine(); //365:10
            __out.Append("            int result = 0;"); //366:1
            __out.AppendLine(); //366:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //367:1
            __out.AppendLine(); //367:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //368:1
            __out.AppendLine(); //368:68
            __out.Append("            {"); //369:1
            __out.AppendLine(); //369:14
            __out.Append("                result = ++lastState;"); //370:1
            __out.AppendLine(); //370:38
            __out.Append("                this.states.Add(result, state);"); //371:1
            __out.AppendLine(); //371:48
            __out.Append("                this.inverseStates.Add(state, result);"); //372:1
            __out.AppendLine(); //372:55
            __out.Append("            }"); //373:1
            __out.AppendLine(); //373:14
            __out.Append("            return result;"); //374:1
            __out.AppendLine(); //374:27
            __out.Append("        }"); //375:1
            __out.AppendLine(); //375:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //377:1
            __out.AppendLine(); //377:87
            __out.Append("        {"); //378:1
            __out.AppendLine(); //378:10
            __out.Append("            try"); //379:1
            __out.AppendLine(); //379:16
            __out.Append("            {"); //380:1
            __out.AppendLine(); //380:14
            __out.Append("                if (this.lexer == null)"); //381:1
            __out.AppendLine(); //381:40
            __out.Append("                {"); //382:1
            __out.AppendLine(); //382:18
            string __tmp136Prefix = "                    this.lexer = new "; //383:1
            string __tmp137Suffix = "n\"));"; //383:117
            StringBuilder __tmp138 = new StringBuilder();
            __tmp138.Append(Properties.LanguageFullName);
            using(StreamReader __tmp138Reader = new StreamReader(this.__ToStream(__tmp138.ToString())))
            {
                bool __tmp138_first = true;
                while(__tmp138_first || !__tmp138Reader.EndOfStream)
                {
                    __tmp138_first = false;
                    string __tmp138Line = __tmp138Reader.ReadLine();
                    if (__tmp138Line == null)
                    {
                        __tmp138Line = "";
                    }
                    __out.Append(__tmp136Prefix);
                    __out.Append(__tmp138Line);
                }
            }
            string __tmp139Line = "Lexer(new AntlrInputStream(this.currentLine + \""; //383:67
            __out.Append(__tmp139Line);
            string __tmp140Line = "\\"; //383:114
            __out.Append(__tmp140Line);
            string __tmp141Line = "r"; //383:115
            __out.Append(__tmp141Line);
            string __tmp142Line = "\\"; //383:116
            __out.Append(__tmp142Line);
            __out.Append(__tmp137Suffix);
            __out.AppendLine(); //383:122
            __out.Append("                }"); //384:1
            __out.AppendLine(); //384:18
            __out.Append("                this.LoadState(state, this.lexer);"); //385:1
            __out.AppendLine(); //385:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //386:1
            __out.AppendLine(); //386:55
            __out.Append("                int tokenType = -1;"); //387:1
            __out.AppendLine(); //387:36
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //389:1
            __out.AppendLine(); //389:64
            __out.Append("                {"); //390:1
            __out.AppendLine(); //390:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //391:1
            __out.AppendLine(); //391:111
            __out.Append("                    {"); //392:1
            __out.AppendLine(); //392:22
            __out.Append("                        tokenType = modeAnnot.Kind;"); //393:1
            __out.AppendLine(); //393:52
            __out.Append("                        break;"); //394:1
            __out.AppendLine(); //394:31
            __out.Append("                    }"); //395:1
            __out.AppendLine(); //395:22
            __out.Append("                }"); //396:1
            __out.AppendLine(); //396:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //397:1
            __out.AppendLine(); //397:68
            __out.Append("                {"); //398:1
            __out.AppendLine(); //398:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //399:1
            __out.AppendLine(); //399:91
            __out.Append("                    {"); //400:1
            __out.AppendLine(); //400:22
            __out.Append("                        tokenType = syntaxAnnot.Kind;"); //401:1
            __out.AppendLine(); //401:54
            __out.Append("                        break;"); //402:1
            __out.AppendLine(); //402:31
            __out.Append("                    }"); //403:1
            __out.AppendLine(); //403:22
            __out.Append("                }"); //404:1
            __out.AppendLine(); //404:18
            string __tmp143Prefix = "                if (tokenType >= 1 && tokenType <= "; //406:1
            string __tmp144Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //406:82
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
                    __out.AppendLine(); //406:127
                }
            }
            __out.Append("                {"); //407:1
            __out.AppendLine(); //407:18
            string __tmp146Prefix = "                    "; //408:1
            string __tmp147Suffix = ";"; //408:172
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
                }
            }
            string __tmp149Line = "LanguageColorableItem colorItem = "; //408:51
            __out.Append(__tmp149Line);
            StringBuilder __tmp150 = new StringBuilder();
            __tmp150.Append(Properties.LanguageClassName);
            using(StreamReader __tmp150Reader = new StreamReader(this.__ToStream(__tmp150.ToString())))
            {
                bool __tmp150_first = true;
                while(__tmp150_first || !__tmp150Reader.EndOfStream)
                {
                    __tmp150_first = false;
                    string __tmp150Line = __tmp150Reader.ReadLine();
                    if (__tmp150Line == null)
                    {
                        __tmp150Line = "";
                    }
                    __out.Append(__tmp150Line);
                }
            }
            string __tmp151Line = "LanguageConfig.Instance.ColorableItems"; //408:115
            __out.Append(__tmp151Line);
            StringBuilder __tmp152 = new StringBuilder();
            __tmp152.Append("[tokenType - 1]");
            using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
            {
                bool __tmp152_first = true;
                while(__tmp152_first || !__tmp152Reader.EndOfStream)
                {
                    __tmp152_first = false;
                    string __tmp152Line = __tmp152Reader.ReadLine();
                    if (__tmp152Line == null)
                    {
                        __tmp152Line = "";
                    }
                    __out.Append(__tmp152Line);
                    __out.Append(__tmp147Suffix);
                    __out.AppendLine(); //408:173
                }
            }
            __out.Append("                    tokenInfo.Token = token.Type;"); //409:1
            __out.AppendLine(); //409:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //410:1
            __out.AppendLine(); //410:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //411:1
            __out.AppendLine(); //411:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //412:1
            __out.AppendLine(); //412:60
            __out.Append("                }"); //413:1
            __out.AppendLine(); //413:18
            __out.Append("                else"); //414:1
            __out.AppendLine(); //414:21
            __out.Append("                {"); //415:1
            __out.AppendLine(); //415:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //416:1
            __out.AppendLine(); //416:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //417:1
            __out.AppendLine(); //417:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //418:1
            __out.AppendLine(); //418:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //419:1
            __out.AppendLine(); //419:60
            __out.Append("                }"); //420:1
            __out.AppendLine(); //420:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //422:1
            __out.AppendLine(); //422:103
            __out.Append("                {"); //423:1
            __out.AppendLine(); //423:18
            __out.Append("                    return false;"); //424:1
            __out.AppendLine(); //424:34
            __out.Append("                }"); //425:1
            __out.AppendLine(); //425:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //426:1
            __out.AppendLine(); //426:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //427:1
            __out.AppendLine(); //427:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //428:1
            __out.AppendLine(); //428:61
            __out.Append("                state = this.SaveState(lexer);"); //429:1
            __out.AppendLine(); //429:47
            __out.Append("                return true;"); //430:1
            __out.AppendLine(); //430:29
            __out.Append("            }"); //431:1
            __out.AppendLine(); //431:14
            __out.Append("            catch (Exception)"); //432:1
            __out.AppendLine(); //432:30
            __out.Append("            {"); //433:1
            __out.AppendLine(); //433:14
            __out.Append("                return false;"); //434:1
            __out.AppendLine(); //434:30
            __out.Append("            }"); //435:1
            __out.AppendLine(); //435:14
            __out.Append("        }"); //436:1
            __out.AppendLine(); //436:10
            __out.Append("        public void SetSource(string source, int offset)"); //438:1
            __out.AppendLine(); //438:57
            __out.Append("        {"); //439:1
            __out.AppendLine(); //439:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //440:1
            __out.AppendLine(); //440:78
            __out.Append("            {"); //441:1
            __out.AppendLine(); //441:14
            __out.Append("                this.currentOffset = offset;"); //442:1
            __out.AppendLine(); //442:45
            __out.Append("                this.currentLine = source;"); //443:1
            __out.AppendLine(); //443:43
            __out.Append("                this.lexer = null;"); //444:1
            __out.AppendLine(); //444:35
            __out.Append("            }"); //445:1
            __out.AppendLine(); //445:14
            __out.Append("        }"); //446:1
            __out.AppendLine(); //446:10
            __out.Append("        internal void ScanLine(ref int state)"); //447:1
            __out.AppendLine(); //447:46
            __out.Append("        {"); //448:1
            __out.AppendLine(); //448:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //449:1
            __out.AppendLine(); //449:86
            __out.Append("        }"); //450:1
            __out.AppendLine(); //450:10
            __out.Append("        internal struct LanguageScannerState"); //452:1
            __out.AppendLine(); //452:45
            __out.Append("        {"); //453:1
            __out.AppendLine(); //453:10
            string __tmp153Prefix = "            public LanguageScannerState("; //454:1
            string __tmp154Suffix = "Lexer lexer)"; //454:70
            StringBuilder __tmp155 = new StringBuilder();
            __tmp155.Append(Properties.LanguageFullName);
            using(StreamReader __tmp155Reader = new StreamReader(this.__ToStream(__tmp155.ToString())))
            {
                bool __tmp155_first = true;
                while(__tmp155_first || !__tmp155Reader.EndOfStream)
                {
                    __tmp155_first = false;
                    string __tmp155Line = __tmp155Reader.ReadLine();
                    if (__tmp155Line == null)
                    {
                        __tmp155Line = "";
                    }
                    __out.Append(__tmp153Prefix);
                    __out.Append(__tmp155Line);
                    __out.Append(__tmp154Suffix);
                    __out.AppendLine(); //454:82
                }
            }
            __out.Append("            {"); //455:1
            __out.AppendLine(); //455:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //456:1
            __out.AppendLine(); //456:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //457:1
            __out.AppendLine(); //457:101
            __out.Append("                this._type = lexer.Type;"); //458:1
            __out.AppendLine(); //458:41
            __out.Append("                this._channel = lexer.Channel;"); //459:1
            __out.AppendLine(); //459:47
            __out.Append("                this._state = lexer.State;"); //460:1
            __out.AppendLine(); //460:43
            __out.Append("            }"); //461:1
            __out.AppendLine(); //461:14
            __out.Append("            internal int _state;"); //463:1
            __out.AppendLine(); //463:33
            __out.Append("            internal int _mode;"); //464:1
            __out.AppendLine(); //464:32
            __out.Append("            internal List<int> _modeStack;"); //465:1
            __out.AppendLine(); //465:43
            __out.Append("            internal int _type;"); //466:1
            __out.AppendLine(); //466:32
            __out.Append("            internal int _channel;"); //467:1
            __out.AppendLine(); //467:35
            string __tmp156Prefix = "            public void Restore("; //469:1
            string __tmp157Suffix = "Lexer lexer)"; //469:62
            StringBuilder __tmp158 = new StringBuilder();
            __tmp158.Append(Properties.LanguageFullName);
            using(StreamReader __tmp158Reader = new StreamReader(this.__ToStream(__tmp158.ToString())))
            {
                bool __tmp158_first = true;
                while(__tmp158_first || !__tmp158Reader.EndOfStream)
                {
                    __tmp158_first = false;
                    string __tmp158Line = __tmp158Reader.ReadLine();
                    if (__tmp158Line == null)
                    {
                        __tmp158Line = "";
                    }
                    __out.Append(__tmp156Prefix);
                    __out.Append(__tmp158Line);
                    __out.Append(__tmp157Suffix);
                    __out.AppendLine(); //469:74
                }
            }
            __out.Append("            {"); //470:1
            __out.AppendLine(); //470:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //471:1
            __out.AppendLine(); //471:48
            __out.Append("                lexer.ModeStack.Clear();"); //472:1
            __out.AppendLine(); //472:41
            __out.Append("                if (this._modeStack != null)"); //473:1
            __out.AppendLine(); //473:45
            __out.Append("                {"); //474:1
            __out.AppendLine(); //474:18
            __out.Append("                    foreach (var item in this._modeStack)"); //475:1
            __out.AppendLine(); //475:58
            __out.Append("                    {"); //476:1
            __out.AppendLine(); //476:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //477:1
            __out.AppendLine(); //477:52
            __out.Append("                    }"); //478:1
            __out.AppendLine(); //478:22
            __out.Append("                }"); //479:1
            __out.AppendLine(); //479:18
            __out.Append("                lexer.Type = this._type;"); //480:1
            __out.AppendLine(); //480:41
            __out.Append("                lexer.Channel = this._channel;"); //481:1
            __out.AppendLine(); //481:47
            __out.Append("                lexer.State = this._state;"); //482:1
            __out.AppendLine(); //482:43
            __out.Append("            }"); //483:1
            __out.AppendLine(); //483:14
            __out.Append("            public override bool Equals(object obj)"); //485:1
            __out.AppendLine(); //485:52
            __out.Append("            {"); //486:1
            __out.AppendLine(); //486:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //487:1
            __out.AppendLine(); //487:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //488:1
            __out.AppendLine(); //488:59
            __out.Append("                if (rhs._type != this._type) return false;"); //489:1
            __out.AppendLine(); //489:59
            __out.Append("                if (rhs._state != this._state) return false;"); //490:1
            __out.AppendLine(); //490:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //491:1
            __out.AppendLine(); //491:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //492:1
            __out.AppendLine(); //492:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //493:1
            __out.AppendLine(); //493:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //494:1
            __out.AppendLine(); //494:71
            __out.Append("                {"); //495:1
            __out.AppendLine(); //495:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //496:1
            __out.AppendLine(); //496:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //497:1
            __out.AppendLine(); //497:67
            __out.Append("                    {"); //498:1
            __out.AppendLine(); //498:22
            string __tmp159Prefix = "                        if (rhs._modeStack"; //499:1
            string __tmp160Suffix = ") return false;"; //499:76
            StringBuilder __tmp161 = new StringBuilder();
            __tmp161.Append("[i]");
            using(StreamReader __tmp161Reader = new StreamReader(this.__ToStream(__tmp161.ToString())))
            {
                bool __tmp161_first = true;
                while(__tmp161_first || !__tmp161Reader.EndOfStream)
                {
                    __tmp161_first = false;
                    string __tmp161Line = __tmp161Reader.ReadLine();
                    if (__tmp161Line == null)
                    {
                        __tmp161Line = "";
                    }
                    __out.Append(__tmp159Prefix);
                    __out.Append(__tmp161Line);
                }
            }
            string __tmp162Line = " != this._modeStack"; //499:50
            __out.Append(__tmp162Line);
            StringBuilder __tmp163 = new StringBuilder();
            __tmp163.Append("[i]");
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
                    __out.Append(__tmp163Line);
                    __out.Append(__tmp160Suffix);
                    __out.AppendLine(); //499:91
                }
            }
            __out.Append("                    }"); //500:1
            __out.AppendLine(); //500:22
            __out.Append("                }"); //501:1
            __out.AppendLine(); //501:18
            __out.Append("                return true;"); //502:1
            __out.AppendLine(); //502:29
            __out.Append("            }"); //503:1
            __out.AppendLine(); //503:14
            __out.Append("            public override int GetHashCode()"); //505:1
            __out.AppendLine(); //505:46
            __out.Append("            {"); //506:1
            __out.AppendLine(); //506:14
            __out.Append("                int result = 0;"); //507:1
            __out.AppendLine(); //507:32
            __out.Append("                result "); //508:1
            __out.Append("^"); //508:24
            __out.Append("= this._mode.GetHashCode();"); //508:25
            __out.AppendLine(); //508:52
            __out.Append("                result "); //509:1
            __out.Append("^"); //509:24
            __out.Append("= this._type.GetHashCode();"); //509:25
            __out.AppendLine(); //509:52
            __out.Append("                result "); //510:1
            __out.Append("^"); //510:24
            __out.Append("= this._state.GetHashCode();"); //510:25
            __out.AppendLine(); //510:53
            __out.Append("                result "); //511:1
            __out.Append("^"); //511:24
            __out.Append("= this._channel.GetHashCode();"); //511:25
            __out.AppendLine(); //511:55
            __out.Append("                if (this._modeStack != null)"); //512:1
            __out.AppendLine(); //512:45
            __out.Append("                {"); //513:1
            __out.AppendLine(); //513:18
            __out.Append("                    result "); //514:1
            __out.Append("^"); //514:28
            __out.Append("= this._modeStack.GetHashCode();"); //514:29
            __out.AppendLine(); //514:61
            __out.Append("                }"); //515:1
            __out.AppendLine(); //515:18
            __out.Append("                return result;"); //516:1
            __out.AppendLine(); //516:31
            __out.Append("            }"); //517:1
            __out.AppendLine(); //517:14
            __out.Append("        }"); //518:1
            __out.AppendLine(); //518:10
            __out.Append("    }"); //519:1
            __out.AppendLine(); //519:6
            string __tmp164Prefix = "    "; //521:1
            string __tmp165Suffix = string.Empty; 
            StringBuilder __tmp166 = new StringBuilder();
            __tmp166.Append("[ComVisible(true)]");
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
                    __out.AppendLine(); //521:27
                }
            }
            string __tmp167Prefix = "    "; //522:1
            string __tmp168Suffix = string.Empty; 
            StringBuilder __tmp169 = new StringBuilder();
            __tmp169.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
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
                    __out.AppendLine(); //522:115
                }
            }
            string __tmp170Prefix = "    public class "; //523:1
            string __tmp171Suffix = "LanguageService : LanguageService"; //523:48
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
                    __out.AppendLine(); //523:81
                }
            }
            __out.Append("    {"); //524:1
            __out.AppendLine(); //524:6
            __out.Append("        private LanguagePreferences preferences;"); //525:1
            __out.AppendLine(); //525:49
            string __tmp173Prefix = "        private "; //526:1
            string __tmp174Suffix = "LanguageScanner scanner;"; //526:47
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
                    __out.AppendLine(); //526:71
                }
            }
            string __tmp176Prefix = "        public "; //528:1
            string __tmp177Suffix = "LanguageService()"; //528:46
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
                    __out.AppendLine(); //528:63
                }
            }
            __out.Append("        {"); //529:1
            __out.AppendLine(); //529:10
            __out.Append("			// Creating the config instance"); //530:1
            __out.AppendLine(); //530:35
            string __tmp179Prefix = "			"; //531:1
            string __tmp180Suffix = "LanguageConfigBase.Instance.ToString();"; //531:34
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
                    __out.AppendLine(); //531:73
                }
            }
            __out.Append("        }"); //532:1
            __out.AppendLine(); //532:10
            __out.Append("        public override string GetFormatFilterList()"); //534:1
            __out.AppendLine(); //534:53
            __out.Append("        {"); //535:1
            __out.AppendLine(); //535:10
            string __tmp182Prefix = "            return "; //536:1
            string __tmp183Suffix = "LanguageConfig.FilterList;"; //536:50
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
                    __out.AppendLine(); //536:76
                }
            }
            __out.Append("        }"); //537:1
            __out.AppendLine(); //537:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //539:1
            __out.AppendLine(); //539:69
            __out.Append("        {"); //540:1
            __out.AppendLine(); //540:10
            __out.Append("            if (preferences == null)"); //541:1
            __out.AppendLine(); //541:37
            __out.Append("            {"); //542:1
            __out.AppendLine(); //542:14
            string __tmp185Prefix = "                preferences = new LanguagePreferences(this.Site, typeof("; //543:1
            string __tmp186Suffix = "LanguageService).GUID, this.Name);"; //543:103
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
                    __out.AppendLine(); //543:137
                }
            }
            __out.Append("                preferences.Init();"); //544:1
            __out.AppendLine(); //544:36
            __out.Append("            }"); //545:1
            __out.AppendLine(); //545:14
            __out.Append("            return preferences;"); //546:1
            __out.AppendLine(); //546:32
            __out.Append("        }"); //547:1
            __out.AppendLine(); //547:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //549:1
            __out.AppendLine(); //549:65
            __out.Append("        {"); //550:1
            __out.AppendLine(); //550:10
            __out.Append("            if (scanner == null)"); //551:1
            __out.AppendLine(); //551:33
            __out.Append("            {"); //552:1
            __out.AppendLine(); //552:14
            string __tmp188Prefix = "                scanner = new "; //553:1
            string __tmp189Suffix = "LanguageScanner();"; //553:61
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
                    __out.AppendLine(); //553:79
                }
            }
            __out.Append("            }"); //554:1
            __out.AppendLine(); //554:14
            __out.Append("            return scanner;"); //555:1
            __out.AppendLine(); //555:28
            __out.Append("        }"); //556:1
            __out.AppendLine(); //556:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //558:1
            __out.AppendLine(); //558:96
            __out.Append("        {"); //559:1
            __out.AppendLine(); //559:10
            string __tmp191Prefix = "            return new "; //560:1
            string __tmp192Suffix = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //560:54
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
                    __out.AppendLine(); //560:110
                }
            }
            __out.Append("        }"); //561:1
            __out.AppendLine(); //561:10
            __out.Append("        #region Custom Colors"); //563:1
            __out.AppendLine(); //563:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //564:1
            __out.AppendLine(); //564:83
            __out.Append("        {"); //565:1
            __out.AppendLine(); //565:10
            string __tmp194Prefix = "            if (index >= 1 && index <= "; //566:1
            string __tmp195Suffix = "LanguageConfig.Instance.ColorableItems.Count)"; //566:70
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
                    __out.AppendLine(); //566:115
                }
            }
            __out.Append("            {"); //567:1
            __out.AppendLine(); //567:14
            string __tmp197Prefix = "                item = "; //568:1
            string __tmp198Suffix = ";"; //568:107
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
                }
            }
            string __tmp200Line = "LanguageConfig.Instance.ColorableItems"; //568:54
            __out.Append(__tmp200Line);
            StringBuilder __tmp201 = new StringBuilder();
            __tmp201.Append("[index - 1]");
            using(StreamReader __tmp201Reader = new StreamReader(this.__ToStream(__tmp201.ToString())))
            {
                bool __tmp201_first = true;
                while(__tmp201_first || !__tmp201Reader.EndOfStream)
                {
                    __tmp201_first = false;
                    string __tmp201Line = __tmp201Reader.ReadLine();
                    if (__tmp201Line == null)
                    {
                        __tmp201Line = "";
                    }
                    __out.Append(__tmp201Line);
                    __out.Append(__tmp198Suffix);
                    __out.AppendLine(); //568:108
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //569:1
            __out.AppendLine(); //569:64
            __out.Append("            }"); //570:1
            __out.AppendLine(); //570:14
            __out.Append("            else"); //571:1
            __out.AppendLine(); //571:17
            __out.Append("            {"); //572:1
            __out.AppendLine(); //572:14
            string __tmp202Prefix = "                item = "; //573:1
            string __tmp203Suffix = ";"; //573:99
            StringBuilder __tmp204 = new StringBuilder();
            __tmp204.Append(Properties.LanguageClassName);
            using(StreamReader __tmp204Reader = new StreamReader(this.__ToStream(__tmp204.ToString())))
            {
                bool __tmp204_first = true;
                while(__tmp204_first || !__tmp204Reader.EndOfStream)
                {
                    __tmp204_first = false;
                    string __tmp204Line = __tmp204Reader.ReadLine();
                    if (__tmp204Line == null)
                    {
                        __tmp204Line = "";
                    }
                    __out.Append(__tmp202Prefix);
                    __out.Append(__tmp204Line);
                }
            }
            string __tmp205Line = "LanguageConfig.Instance.ColorableItems"; //573:54
            __out.Append(__tmp205Line);
            StringBuilder __tmp206 = new StringBuilder();
            __tmp206.Append("[0]");
            using(StreamReader __tmp206Reader = new StreamReader(this.__ToStream(__tmp206.ToString())))
            {
                bool __tmp206_first = true;
                while(__tmp206_first || !__tmp206Reader.EndOfStream)
                {
                    __tmp206_first = false;
                    string __tmp206Line = __tmp206Reader.ReadLine();
                    if (__tmp206Line == null)
                    {
                        __tmp206Line = "";
                    }
                    __out.Append(__tmp206Line);
                    __out.Append(__tmp203Suffix);
                    __out.AppendLine(); //573:100
                }
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //574:1
            __out.AppendLine(); //574:64
            __out.Append("            }"); //575:1
            __out.AppendLine(); //575:14
            __out.Append("        }"); //576:1
            __out.AppendLine(); //576:10
            __out.Append("        public override int GetItemCount(out int count)"); //578:1
            __out.AppendLine(); //578:56
            __out.Append("        {"); //579:1
            __out.AppendLine(); //579:10
            string __tmp207Prefix = "            count = "; //580:1
            string __tmp208Suffix = "LanguageConfig.Instance.ColorableItems.Count;"; //580:51
            StringBuilder __tmp209 = new StringBuilder();
            __tmp209.Append(Properties.LanguageClassName);
            using(StreamReader __tmp209Reader = new StreamReader(this.__ToStream(__tmp209.ToString())))
            {
                bool __tmp209_first = true;
                while(__tmp209_first || !__tmp209Reader.EndOfStream)
                {
                    __tmp209_first = false;
                    string __tmp209Line = __tmp209Reader.ReadLine();
                    if (__tmp209Line == null)
                    {
                        __tmp209Line = "";
                    }
                    __out.Append(__tmp207Prefix);
                    __out.Append(__tmp209Line);
                    __out.Append(__tmp208Suffix);
                    __out.AppendLine(); //580:96
                }
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //581:1
            __out.AppendLine(); //581:60
            __out.Append("        }"); //582:1
            __out.AppendLine(); //582:10
            __out.Append("        #endregion"); //583:1
            __out.AppendLine(); //583:19
            __out.Append("        public override void OnIdle(bool periodic)"); //585:1
            __out.AppendLine(); //585:51
            __out.Append("        {"); //586:1
            __out.AppendLine(); //586:10
            __out.Append("            // from IronPythonLanguage sample"); //587:1
            __out.AppendLine(); //587:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //588:1
            __out.AppendLine(); //588:93
            string __tmp210Prefix = "            "; //589:1
            string __tmp211Suffix = "LanguageSource)GetSource(this.LastActiveTextView);"; //589:95
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
                    __out.Append(__tmp210Prefix);
                    __out.Append(__tmp212Line);
                }
            }
            string __tmp213Line = "LanguageSource src = ("; //589:43
            __out.Append(__tmp213Line);
            StringBuilder __tmp214 = new StringBuilder();
            __tmp214.Append(Properties.LanguageClassName);
            using(StreamReader __tmp214Reader = new StreamReader(this.__ToStream(__tmp214.ToString())))
            {
                bool __tmp214_first = true;
                while(__tmp214_first || !__tmp214Reader.EndOfStream)
                {
                    __tmp214_first = false;
                    string __tmp214Line = __tmp214Reader.ReadLine();
                    if (__tmp214Line == null)
                    {
                        __tmp214Line = "";
                    }
                    __out.Append(__tmp214Line);
                    __out.Append(__tmp211Suffix);
                    __out.AppendLine(); //589:145
                }
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //590:1
            __out.AppendLine(); //590:74
            __out.Append("            {"); //591:1
            __out.AppendLine(); //591:14
            __out.Append("                src.LastParseTime = 0;"); //592:1
            __out.AppendLine(); //592:39
            __out.Append("            }"); //593:1
            __out.AppendLine(); //593:14
            __out.Append("            base.OnIdle(periodic);"); //594:1
            __out.AppendLine(); //594:35
            __out.Append("        }"); //595:1
            __out.AppendLine(); //595:10
            __out.Append("        public override string Name"); //597:1
            __out.AppendLine(); //597:36
            __out.Append("        {"); //598:1
            __out.AppendLine(); //598:10
            string __tmp215Prefix = "            get { return "; //599:1
            string __tmp216Suffix = "LanguageConfig.LanguageName; }"; //599:56
            StringBuilder __tmp217 = new StringBuilder();
            __tmp217.Append(Properties.LanguageClassName);
            using(StreamReader __tmp217Reader = new StreamReader(this.__ToStream(__tmp217.ToString())))
            {
                bool __tmp217_first = true;
                while(__tmp217_first || !__tmp217Reader.EndOfStream)
                {
                    __tmp217_first = false;
                    string __tmp217Line = __tmp217Reader.ReadLine();
                    if (__tmp217Line == null)
                    {
                        __tmp217Line = "";
                    }
                    __out.Append(__tmp215Prefix);
                    __out.Append(__tmp217Line);
                    __out.Append(__tmp216Suffix);
                    __out.AppendLine(); //599:86
                }
            }
            __out.Append("        }"); //600:1
            __out.AppendLine(); //600:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //602:1
            __out.AppendLine(); //602:96
            __out.Append("        {"); //603:1
            __out.AppendLine(); //603:10
            string __tmp218Prefix = "            return new "; //604:1
            string __tmp219Suffix = "LanguageViewFilter(mgr, newView);"; //604:54
            StringBuilder __tmp220 = new StringBuilder();
            __tmp220.Append(Properties.LanguageClassName);
            using(StreamReader __tmp220Reader = new StreamReader(this.__ToStream(__tmp220.ToString())))
            {
                bool __tmp220_first = true;
                while(__tmp220_first || !__tmp220Reader.EndOfStream)
                {
                    __tmp220_first = false;
                    string __tmp220Line = __tmp220Reader.ReadLine();
                    if (__tmp220Line == null)
                    {
                        __tmp220Line = "";
                    }
                    __out.Append(__tmp218Prefix);
                    __out.Append(__tmp220Line);
                    __out.Append(__tmp219Suffix);
                    __out.AppendLine(); //604:87
                }
            }
            __out.Append("        }"); //605:1
            __out.AppendLine(); //605:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //607:1
            __out.AppendLine(); //607:68
            __out.Append("        {"); //608:1
            __out.AppendLine(); //608:10
            string __tmp221Prefix = "            return new "; //609:1
            string __tmp222Suffix = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //609:54
            StringBuilder __tmp223 = new StringBuilder();
            __tmp223.Append(Properties.LanguageClassName);
            using(StreamReader __tmp223Reader = new StreamReader(this.__ToStream(__tmp223.ToString())))
            {
                bool __tmp223_first = true;
                while(__tmp223_first || !__tmp223Reader.EndOfStream)
                {
                    __tmp223_first = false;
                    string __tmp223Line = __tmp223Reader.ReadLine();
                    if (__tmp223Line == null)
                    {
                        __tmp223Line = "";
                    }
                    __out.Append(__tmp221Prefix);
                    __out.Append(__tmp223Line);
                    __out.Append(__tmp222Suffix);
                    __out.AppendLine(); //609:111
                }
            }
            __out.Append("        }"); //610:1
            __out.AppendLine(); //610:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //612:1
            __out.AppendLine(); //612:69
            __out.Append("        {"); //613:1
            __out.AppendLine(); //613:10
            string __tmp224Prefix = "            "; //614:1
            string __tmp225Suffix = "LanguageSource)this.GetSource(req.FileName);"; //614:98
            StringBuilder __tmp226 = new StringBuilder();
            __tmp226.Append(Properties.LanguageClassName);
            using(StreamReader __tmp226Reader = new StreamReader(this.__ToStream(__tmp226.ToString())))
            {
                bool __tmp226_first = true;
                while(__tmp226_first || !__tmp226Reader.EndOfStream)
                {
                    __tmp226_first = false;
                    string __tmp226Line = __tmp226Reader.ReadLine();
                    if (__tmp226Line == null)
                    {
                        __tmp226Line = "";
                    }
                    __out.Append(__tmp224Prefix);
                    __out.Append(__tmp226Line);
                }
            }
            string __tmp227Line = "LanguageSource source = ("; //614:43
            __out.Append(__tmp227Line);
            StringBuilder __tmp228 = new StringBuilder();
            __tmp228.Append(Properties.LanguageClassName);
            using(StreamReader __tmp228Reader = new StreamReader(this.__ToStream(__tmp228.ToString())))
            {
                bool __tmp228_first = true;
                while(__tmp228_first || !__tmp228Reader.EndOfStream)
                {
                    __tmp228_first = false;
                    string __tmp228Line = __tmp228Reader.ReadLine();
                    if (__tmp228Line == null)
                    {
                        __tmp228Line = "";
                    }
                    __out.Append(__tmp228Line);
                    __out.Append(__tmp225Suffix);
                    __out.AppendLine(); //614:142
                }
            }
            __out.Append("            switch (req.Reason)"); //615:1
            __out.AppendLine(); //615:32
            __out.Append("            {"); //616:1
            __out.AppendLine(); //616:14
            __out.Append("                case ParseReason.Check:"); //617:1
            __out.AppendLine(); //617:40
            __out.Append("                    // This is where you perform your syntax highlighting."); //618:1
            __out.AppendLine(); //618:75
            __out.Append("                    // Parse entire source as given in req.Text."); //619:1
            __out.AppendLine(); //619:65
            __out.Append("                    // Store results in the AuthoringScope object."); //620:1
            __out.AppendLine(); //620:67
            __out.Append("                    string fileName = Path.GetFileName(req.FileName);"); //621:1
            __out.AppendLine(); //621:70
            __out.Append("                    string outputDir = Path.GetDirectoryName(req.FileName);"); //622:1
            __out.AppendLine(); //622:76
            string __tmp229Prefix = "                    "; //623:1
            string __tmp230Suffix = "Compiler(req.Text, outputDir, fileName);"; //623:105
            StringBuilder __tmp231 = new StringBuilder();
            __tmp231.Append(Properties.LanguageClassName);
            using(StreamReader __tmp231Reader = new StreamReader(this.__ToStream(__tmp231.ToString())))
            {
                bool __tmp231_first = true;
                while(__tmp231_first || !__tmp231Reader.EndOfStream)
                {
                    __tmp231_first = false;
                    string __tmp231Line = __tmp231Reader.ReadLine();
                    if (__tmp231Line == null)
                    {
                        __tmp231Line = "";
                    }
                    __out.Append(__tmp229Prefix);
                    __out.Append(__tmp231Line);
                }
            }
            string __tmp232Line = "Compiler compiler = new "; //623:51
            __out.Append(__tmp232Line);
            StringBuilder __tmp233 = new StringBuilder();
            __tmp233.Append(Properties.LanguageClassName);
            using(StreamReader __tmp233Reader = new StreamReader(this.__ToStream(__tmp233.ToString())))
            {
                bool __tmp233_first = true;
                while(__tmp233_first || !__tmp233Reader.EndOfStream)
                {
                    __tmp233_first = false;
                    string __tmp233Line = __tmp233Reader.ReadLine();
                    if (__tmp233Line == null)
                    {
                        __tmp233Line = "";
                    }
                    __out.Append(__tmp233Line);
                    __out.Append(__tmp230Suffix);
                    __out.AppendLine(); //623:145
                }
            }
            __out.Append("                    compiler.GenerateOutput = false;"); //624:1
            __out.AppendLine(); //624:53
            __out.Append("                    compiler.Compile();"); //625:1
            __out.AppendLine(); //625:40
            __out.Append("                    foreach (var msg in compiler.Diagnostics.GetMessages())"); //626:1
            __out.AppendLine(); //626:76
            __out.Append("                    {"); //627:1
            __out.AppendLine(); //627:22
            __out.Append("                        TextSpan span = new TextSpan();"); //628:1
            __out.AppendLine(); //628:56
            __out.Append("                        span.iStartLine = msg.TextSpan.StartLine - 1;"); //629:1
            __out.AppendLine(); //629:70
            __out.Append("                        span.iEndLine = msg.TextSpan.EndLine - 1;"); //630:1
            __out.AppendLine(); //630:66
            __out.Append("                        span.iStartIndex = msg.TextSpan.StartPosition - 1;"); //631:1
            __out.AppendLine(); //631:75
            __out.Append("                        span.iEndIndex = msg.TextSpan.EndPosition - 1;"); //632:1
            __out.AppendLine(); //632:71
            __out.Append("                        Severity severity = Severity.Error;"); //633:1
            __out.AppendLine(); //633:60
            __out.Append("                        switch (msg.Severity)"); //634:1
            __out.AppendLine(); //634:46
            __out.Append("                        {"); //635:1
            __out.AppendLine(); //635:26
            __out.Append("                            case MetaDslx.Core.Severity.Error:"); //636:1
            __out.AppendLine(); //636:63
            __out.Append("                                severity = Severity.Error;"); //637:1
            __out.AppendLine(); //637:59
            __out.Append("                                break;"); //638:1
            __out.AppendLine(); //638:39
            __out.Append("                            case MetaDslx.Core.Severity.Warning:"); //639:1
            __out.AppendLine(); //639:65
            __out.Append("                                severity = Severity.Warning;"); //640:1
            __out.AppendLine(); //640:61
            __out.Append("                                break;"); //641:1
            __out.AppendLine(); //641:39
            __out.Append("                            case MetaDslx.Core.Severity.Info:"); //642:1
            __out.AppendLine(); //642:62
            __out.Append("                                severity = Severity.Hint;"); //643:1
            __out.AppendLine(); //643:58
            __out.Append("                                break;"); //644:1
            __out.AppendLine(); //644:39
            __out.Append("                        }"); //645:1
            __out.AppendLine(); //645:26
            __out.Append("                        req.Sink.AddError(req.FileName, msg.Message, span, severity);"); //646:1
            __out.AppendLine(); //646:86
            __out.Append("                    }"); //647:1
            __out.AppendLine(); //647:22
            __out.Append("                    break;"); //648:1
            __out.AppendLine(); //648:27
            __out.Append("            }"); //649:1
            __out.AppendLine(); //649:14
            string __tmp234Prefix = "            return new "; //650:1
            string __tmp235Suffix = "LanguageAuthoringScope();"; //650:54
            StringBuilder __tmp236 = new StringBuilder();
            __tmp236.Append(Properties.LanguageClassName);
            using(StreamReader __tmp236Reader = new StreamReader(this.__ToStream(__tmp236.ToString())))
            {
                bool __tmp236_first = true;
                while(__tmp236_first || !__tmp236Reader.EndOfStream)
                {
                    __tmp236_first = false;
                    string __tmp236Line = __tmp236Reader.ReadLine();
                    if (__tmp236Line == null)
                    {
                        __tmp236Line = "";
                    }
                    __out.Append(__tmp234Prefix);
                    __out.Append(__tmp236Line);
                    __out.Append(__tmp235Suffix);
                    __out.AppendLine(); //650:79
                }
            }
            __out.Append("        }"); //651:1
            __out.AppendLine(); //651:10
            __out.Append("    }"); //652:1
            __out.AppendLine(); //652:6
            string __tmp237Prefix = "	public class "; //654:1
            string __tmp238Suffix = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //654:45
            StringBuilder __tmp239 = new StringBuilder();
            __tmp239.Append(Properties.LanguageClassName);
            using(StreamReader __tmp239Reader = new StreamReader(this.__ToStream(__tmp239.ToString())))
            {
                bool __tmp239_first = true;
                while(__tmp239_first || !__tmp239Reader.EndOfStream)
                {
                    __tmp239_first = false;
                    string __tmp239Line = __tmp239Reader.ReadLine();
                    if (__tmp239Line == null)
                    {
                        __tmp239Line = "";
                    }
                    __out.Append(__tmp237Prefix);
                    __out.Append(__tmp239Line);
                    __out.Append(__tmp238Suffix);
                    __out.AppendLine(); //654:99
                }
            }
            __out.Append("    {"); //655:1
            __out.AppendLine(); //655:6
            string __tmp240Prefix = "        public "; //656:1
            string __tmp241Suffix = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //656:46
            StringBuilder __tmp242 = new StringBuilder();
            __tmp242.Append(Properties.LanguageClassName);
            using(StreamReader __tmp242Reader = new StreamReader(this.__ToStream(__tmp242.ToString())))
            {
                bool __tmp242_first = true;
                while(__tmp242_first || !__tmp242Reader.EndOfStream)
                {
                    __tmp242_first = false;
                    string __tmp242Line = __tmp242Reader.ReadLine();
                    if (__tmp242Line == null)
                    {
                        __tmp242Line = "";
                    }
                    __out.Append(__tmp240Prefix);
                    __out.Append(__tmp242Line);
                    __out.Append(__tmp241Suffix);
                    __out.AppendLine(); //656:130
                }
            }
            __out.Append("            : base(service, textLines, colorizer)"); //657:1
            __out.AppendLine(); //657:50
            __out.Append("        {"); //658:1
            __out.AppendLine(); //658:10
            __out.Append("        }"); //660:1
            __out.AppendLine(); //660:10
            __out.Append("    }"); //661:1
            __out.AppendLine(); //661:6
            string __tmp243Prefix = "    public class "; //663:1
            string __tmp244Suffix = "LanguageViewFilter : ViewFilter"; //663:48
            StringBuilder __tmp245 = new StringBuilder();
            __tmp245.Append(Properties.LanguageClassName);
            using(StreamReader __tmp245Reader = new StreamReader(this.__ToStream(__tmp245.ToString())))
            {
                bool __tmp245_first = true;
                while(__tmp245_first || !__tmp245Reader.EndOfStream)
                {
                    __tmp245_first = false;
                    string __tmp245Line = __tmp245Reader.ReadLine();
                    if (__tmp245Line == null)
                    {
                        __tmp245Line = "";
                    }
                    __out.Append(__tmp243Prefix);
                    __out.Append(__tmp245Line);
                    __out.Append(__tmp244Suffix);
                    __out.AppendLine(); //663:79
                }
            }
            __out.Append("    {"); //664:1
            __out.AppendLine(); //664:6
            string __tmp246Prefix = "        public "; //665:1
            string __tmp247Suffix = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //665:46
            StringBuilder __tmp248 = new StringBuilder();
            __tmp248.Append(Properties.LanguageClassName);
            using(StreamReader __tmp248Reader = new StreamReader(this.__ToStream(__tmp248.ToString())))
            {
                bool __tmp248_first = true;
                while(__tmp248_first || !__tmp248Reader.EndOfStream)
                {
                    __tmp248_first = false;
                    string __tmp248Line = __tmp248Reader.ReadLine();
                    if (__tmp248Line == null)
                    {
                        __tmp248Line = "";
                    }
                    __out.Append(__tmp246Prefix);
                    __out.Append(__tmp248Line);
                    __out.Append(__tmp247Suffix);
                    __out.AppendLine(); //665:105
                }
            }
            __out.Append("            : base(mgr, view)"); //666:1
            __out.AppendLine(); //666:30
            __out.Append("        {"); //667:1
            __out.AppendLine(); //667:10
            __out.Append("        }"); //669:1
            __out.AppendLine(); //669:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //671:1
            __out.AppendLine(); //671:150
            __out.Append("        {"); //672:1
            __out.AppendLine(); //672:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //673:1
            __out.AppendLine(); //673:59
            __out.Append("            {"); //674:1
            __out.AppendLine(); //674:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //675:1
            __out.AppendLine(); //675:57
            __out.Append("                switch (cmd)"); //676:1
            __out.AppendLine(); //676:29
            __out.Append("                {"); //677:1
            __out.AppendLine(); //677:18
            __out.Append("                    case VsCommands2K.UP:"); //678:1
            __out.AppendLine(); //678:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //679:1
            __out.AppendLine(); //679:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //680:1
            __out.AppendLine(); //680:50
            __out.Append("                    case VsCommands2K.DOWN:"); //681:1
            __out.AppendLine(); //681:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //682:1
            __out.AppendLine(); //682:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //683:1
            __out.AppendLine(); //683:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //684:1
            __out.Append("\\"); //684:58
            __out.Append("0');"); //684:59
            __out.AppendLine(); //684:63
            __out.Append("                        return;"); //685:1
            __out.AppendLine(); //685:32
            __out.Append("                }"); //686:1
            __out.AppendLine(); //686:18
            __out.Append("            }"); //687:1
            __out.AppendLine(); //687:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //688:1
            __out.AppendLine(); //688:105
            __out.Append("        }"); //689:1
            __out.AppendLine(); //689:10
            __out.Append("    }"); //690:1
            __out.AppendLine(); //690:6
            __out.Append("}"); //692:1
            __out.AppendLine(); //692:2
            return __out.ToString();
        }

    }
}
