using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_136429272;
    namespace __Hidden_MetaLanguageServiceGenerator_136429272
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

        public MetaLanguageServiceGenerator() //2:1
        {
            this.Properties = new __Properties();
        }

        public MetaLanguageServiceGenerator(object instances) : this() //2:1
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
            __out.AppendLine(false); //12:14
            __out.Append("using System.Collections.Generic;"); //13:1
            __out.AppendLine(false); //13:34
            __out.Append("using System.ComponentModel;"); //14:1
            __out.AppendLine(false); //14:29
            __out.Append("using System.Diagnostics;"); //15:1
            __out.AppendLine(false); //15:26
            __out.Append("using System.IO;"); //16:1
            __out.AppendLine(false); //16:17
            __out.Append("using System.Linq;"); //17:1
            __out.AppendLine(false); //17:19
            __out.Append("using System.Runtime.InteropServices;"); //18:1
            __out.AppendLine(false); //18:38
            __out.Append("using System.Text;"); //19:1
            __out.AppendLine(false); //19:19
            __out.Append("using System.Threading.Tasks;"); //20:1
            __out.AppendLine(false); //20:30
            __out.Append("using Microsoft.VisualStudio.OLE.Interop;"); //21:1
            __out.AppendLine(false); //21:42
            __out.Append("using Microsoft.VisualStudio.Package;"); //22:1
            __out.AppendLine(false); //22:38
            __out.Append("using Microsoft.VisualStudio.Shell.Interop;"); //23:1
            __out.AppendLine(false); //23:44
            __out.Append("using Microsoft.VisualStudio.TextManager.Interop;"); //24:1
            __out.AppendLine(false); //24:50
            __out.Append("using Antlr4.Runtime;"); //25:1
            __out.AppendLine(false); //25:22
            __out.Append("using MetaDslx.Compiler;"); //26:1
            __out.AppendLine(false); //26:25
            __out.Append("using System.Drawing;"); //27:1
            __out.AppendLine(false); //27:22
            __out.Append("using Microsoft.VisualStudio;"); //28:1
            __out.AppendLine(false); //28:30
            __out.Append("using Microsoft.VisualStudio.Shell;"); //29:1
            __out.AppendLine(false); //29:36
            __out.AppendLine(true); //30:1
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //31:1
            __out.AppendLine(false); //31:70
            __out.AppendLine(true); //32:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //33:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(Properties.LanguageServiceNamespace);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //33:48
            }
            __out.Append("{"); //34:1
            __out.AppendLine(false); //34:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "    public class "; //35:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(Properties.LanguageClassName);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = "LanguageAuthoringScope : AuthoringScope"; //35:48
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //35:87
            }
            __out.Append("    {"); //36:1
            __out.AppendLine(false); //36:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //37:1
            __out.AppendLine(false); //37:84
            __out.Append("        {"); //38:1
            __out.AppendLine(false); //38:10
            __out.Append("            span = new TextSpan();"); //39:1
            __out.AppendLine(false); //39:35
            __out.Append("            return null;"); //40:1
            __out.AppendLine(false); //40:25
            __out.Append("        }"); //41:1
            __out.AppendLine(false); //41:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //43:1
            __out.AppendLine(false); //43:126
            __out.Append("        {"); //44:1
            __out.AppendLine(false); //44:10
            __out.Append("            return null;"); //45:1
            __out.AppendLine(false); //45:25
            __out.Append("        }"); //46:1
            __out.AppendLine(false); //46:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //48:1
            __out.AppendLine(false); //48:75
            __out.Append("        {"); //49:1
            __out.AppendLine(false); //49:10
            __out.Append("            return null;"); //50:1
            __out.AppendLine(false); //50:25
            __out.Append("        }"); //51:1
            __out.AppendLine(false); //51:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //53:1
            __out.AppendLine(false); //53:149
            __out.Append("        {"); //54:1
            __out.AppendLine(false); //54:10
            __out.Append("            span = new TextSpan();"); //55:1
            __out.AppendLine(false); //55:35
            __out.Append("            return null;"); //56:1
            __out.AppendLine(false); //56:25
            __out.Append("        }"); //57:1
            __out.AppendLine(false); //57:10
            __out.Append("    }"); //58:1
            __out.AppendLine(false); //58:6
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public class "; //60:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(Properties.LanguageClassName);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = "LanguageColorizer : Colorizer"; //60:45
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //60:74
            }
            __out.Append("    {"); //61:1
            __out.AppendLine(false); //61:6
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "        public "; //62:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.LanguageClassName);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //62:46
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //62:123
            }
            __out.Append("            : base(svc, buffer, scanner)"); //63:1
            __out.AppendLine(false); //63:41
            __out.Append("        {"); //64:1
            __out.AppendLine(false); //64:10
            __out.Append("        }"); //65:1
            __out.AppendLine(false); //65:10
            __out.Append("        #region IVsColorizer Members"); //67:1
            __out.AppendLine(false); //67:37
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //69:1
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp21_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append("[]");
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24_line = " attrs)"; //69:97
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //69:104
            }
            __out.Append("        {"); //70:1
            __out.AppendLine(false); //70:10
            __out.Append("            if (attrs == null) return state;"); //71:1
            __out.AppendLine(false); //71:45
            __out.Append("            int linepos = 0;"); //72:1
            __out.AppendLine(false); //72:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //73:1
            __out.AppendLine(false); //73:75
            __out.Append("            // random color junk on the screen."); //74:1
            __out.AppendLine(false); //74:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //75:1
            __out.AppendLine(false); //75:65
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "                attrs"; //76:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append("[linepos]");
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    string __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                    {
                        __out.Append(__tmp28_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = " = (uint)TokenColor.Text;"; //76:35
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //76:60
            }
            __out.Append("            if (this.Scanner != null)"); //77:1
            __out.AppendLine(false); //77:38
            __out.Append("            {"); //78:1
            __out.AppendLine(false); //78:14
            __out.Append("                try"); //79:1
            __out.AppendLine(false); //79:20
            __out.Append("                {"); //80:1
            __out.AppendLine(false); //80:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //81:1
            __out.AppendLine(false); //81:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //83:1
            __out.AppendLine(false); //83:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //85:1
            __out.AppendLine(false); //85:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //87:1
            __out.AppendLine(false); //87:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //89:1
            __out.AppendLine(false); //89:94
            __out.Append("                    {"); //90:1
            __out.AppendLine(false); //90:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //91:1
            __out.AppendLine(false); //91:103
            __out.Append("                        {"); //92:1
            __out.AppendLine(false); //92:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //93:1
            __out.AppendLine(false); //93:72
            __out.Append("                            {"); //94:1
            __out.AppendLine(false); //94:30
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "                                attrs"; //95:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append("[linepos]");
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                    {
                        __out.Append(__tmp33_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp34_line = " = (uint)tokenInfo.Color;"; //95:51
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //95:76
            }
            __out.Append("                            }"); //96:1
            __out.AppendLine(false); //96:30
            __out.Append("                        }"); //97:1
            __out.AppendLine(false); //97:26
            __out.Append("                    }"); //98:1
            __out.AppendLine(false); //98:22
            __out.Append("                }"); //99:1
            __out.AppendLine(false); //99:18
            __out.Append("                catch (Exception)"); //100:1
            __out.AppendLine(false); //100:34
            __out.Append("                {"); //101:1
            __out.AppendLine(false); //101:18
            __out.Append("                    // Ignore exceptions"); //102:1
            __out.AppendLine(false); //102:41
            __out.Append("                }"); //103:1
            __out.AppendLine(false); //103:18
            __out.Append("            }"); //104:1
            __out.AppendLine(false); //104:14
            __out.Append("            return state;"); //105:1
            __out.AppendLine(false); //105:26
            __out.Append("        }"); //106:1
            __out.AppendLine(false); //106:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //108:1
            __out.AppendLine(false); //108:64
            __out.Append("        {"); //109:1
            __out.AppendLine(false); //109:10
            __out.Append("            piStartState = 0;"); //110:1
            __out.AppendLine(false); //110:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //111:1
            __out.AppendLine(false); //111:60
            __out.Append("        }"); //112:1
            __out.AppendLine(false); //112:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //114:1
            __out.AppendLine(false); //114:98
            __out.Append("        {"); //115:1
            __out.AppendLine(false); //115:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //116:1
            __out.AppendLine(false); //116:66
            __out.Append("            if (text != null)"); //117:1
            __out.AppendLine(false); //117:30
            __out.Append("            {"); //118:1
            __out.AppendLine(false); //118:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //119:1
            __out.AppendLine(false); //119:49
            bool __tmp36_outputWritten = false;
            string __tmp37_line = "                (("; //120:1
            if (!string.IsNullOrEmpty(__tmp37_line))
            {
                __out.Append(__tmp37_line);
                __tmp36_outputWritten = true;
            }
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(Properties.LanguageClassName);
            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
            {
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(!__tmp38_last)
                {
                    string __tmp38_line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                    {
                        __out.Append(__tmp38_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp38_last) __out.AppendLine(true);
                }
            }
            string __tmp39_line = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //120:49
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp36_outputWritten = true;
            }
            if (__tmp36_outputWritten) __out.AppendLine(true);
            if (__tmp36_outputWritten)
            {
                __out.AppendLine(false); //120:100
            }
            __out.Append("            }"); //121:1
            __out.AppendLine(false); //121:14
            __out.Append("            return iState;"); //122:1
            __out.AppendLine(false); //122:27
            __out.Append("        }"); //123:1
            __out.AppendLine(false); //123:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //125:1
            __out.AppendLine(false); //125:68
            __out.Append("        {"); //126:1
            __out.AppendLine(false); //126:10
            __out.Append("            pfFlag = 1;"); //127:1
            __out.AppendLine(false); //127:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //128:1
            __out.AppendLine(false); //128:60
            __out.Append("        }"); //129:1
            __out.AppendLine(false); //129:10
            __out.Append("        #endregion"); //131:1
            __out.AppendLine(false); //131:19
            __out.Append("    }"); //132:1
            __out.AppendLine(false); //132:6
            bool __tmp41_outputWritten = false;
            string __tmp42_line = "    public abstract class "; //135:1
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Append(__tmp42_line);
                __tmp41_outputWritten = true;
            }
            StringBuilder __tmp43 = new StringBuilder();
            __tmp43.Append(Properties.LanguageClassName);
            using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
            {
                bool __tmp43_last = __tmp43Reader.EndOfStream;
                while(!__tmp43_last)
                {
                    string __tmp43_line = __tmp43Reader.ReadLine();
                    __tmp43_last = __tmp43Reader.EndOfStream;
                    if ((__tmp43_last && !string.IsNullOrEmpty(__tmp43_line)) || (!__tmp43_last && __tmp43_line != null))
                    {
                        __out.Append(__tmp43_line);
                        __tmp41_outputWritten = true;
                    }
                    if (!__tmp43_last) __out.AppendLine(true);
                }
            }
            string __tmp44_line = "LanguageConfigBase"; //135:57
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Append(__tmp44_line);
                __tmp41_outputWritten = true;
            }
            if (__tmp41_outputWritten) __out.AppendLine(true);
            if (__tmp41_outputWritten)
            {
                __out.AppendLine(false); //135:75
            }
            __out.Append("    {"); //136:1
            __out.AppendLine(false); //136:6
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "        private static "; //137:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append(Properties.LanguageClassName);
            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
            {
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    string __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                    {
                        __out.Append(__tmp48_line);
                        __tmp46_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
            }
            string __tmp49_line = "LanguageConfig instance = null;"; //137:54
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //137:85
            }
            bool __tmp51_outputWritten = false;
            string __tmp52_line = "        public static "; //138:1
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Append(__tmp52_line);
                __tmp51_outputWritten = true;
            }
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(Properties.LanguageClassName);
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_last = __tmp53Reader.EndOfStream;
                while(!__tmp53_last)
                {
                    string __tmp53_line = __tmp53Reader.ReadLine();
                    __tmp53_last = __tmp53Reader.EndOfStream;
                    if ((__tmp53_last && !string.IsNullOrEmpty(__tmp53_line)) || (!__tmp53_last && __tmp53_line != null))
                    {
                        __out.Append(__tmp53_line);
                        __tmp51_outputWritten = true;
                    }
                    if (!__tmp53_last) __out.AppendLine(true);
                }
            }
            string __tmp54_line = "LanguageConfig Instance"; //138:53
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Append(__tmp54_line);
                __tmp51_outputWritten = true;
            }
            if (__tmp51_outputWritten) __out.AppendLine(true);
            if (__tmp51_outputWritten)
            {
                __out.AppendLine(false); //138:76
            }
            __out.Append("        {"); //139:1
            __out.AppendLine(false); //139:10
            __out.Append("            get "); //140:1
            __out.AppendLine(false); //140:17
            __out.Append("            {"); //141:1
            __out.AppendLine(false); //141:14
            __out.Append("                if (instance == null)"); //142:1
            __out.AppendLine(false); //142:38
            __out.Append("                {"); //143:1
            __out.AppendLine(false); //143:18
            bool __tmp56_outputWritten = false;
            string __tmp57_line = "					// If there is a compile error in the following line, create a class "; //144:1
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Append(__tmp57_line);
                __tmp56_outputWritten = true;
            }
            StringBuilder __tmp58 = new StringBuilder();
            __tmp58.Append(Properties.LanguageClassName);
            using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
            {
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    string __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if ((__tmp58_last && !string.IsNullOrEmpty(__tmp58_line)) || (!__tmp58_last && __tmp58_line != null))
                    {
                        __out.Append(__tmp58_line);
                        __tmp56_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
            }
            string __tmp59_line = "LanguageConfig"; //144:105
            if (!string.IsNullOrEmpty(__tmp59_line))
            {
                __out.Append(__tmp59_line);
                __tmp56_outputWritten = true;
            }
            if (__tmp56_outputWritten) __out.AppendLine(true);
            if (__tmp56_outputWritten)
            {
                __out.AppendLine(false); //144:119
            }
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "					// which is a subclass of "; //145:1
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Append(__tmp62_line);
                __tmp61_outputWritten = true;
            }
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(Properties.LanguageClassName);
            using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
            {
                bool __tmp63_last = __tmp63Reader.EndOfStream;
                while(!__tmp63_last)
                {
                    string __tmp63_line = __tmp63Reader.ReadLine();
                    __tmp63_last = __tmp63Reader.EndOfStream;
                    if ((__tmp63_last && !string.IsNullOrEmpty(__tmp63_line)) || (!__tmp63_last && __tmp63_line != null))
                    {
                        __out.Append(__tmp63_line);
                        __tmp61_outputWritten = true;
                    }
                    if (!__tmp63_last) __out.AppendLine(true);
                }
            }
            string __tmp64_line = "LanguageConfigBase"; //145:62
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Append(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //145:80
            }
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "                    instance = new "; //146:1
            if (!string.IsNullOrEmpty(__tmp67_line))
            {
                __out.Append(__tmp67_line);
                __tmp66_outputWritten = true;
            }
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(Properties.LanguageClassName);
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    string __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                    {
                        __out.Append(__tmp68_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
            }
            string __tmp69_line = "LanguageConfig();"; //146:66
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //146:83
            }
            __out.Append("                }"); //147:1
            __out.AppendLine(false); //147:18
            __out.Append("                return instance;"); //148:1
            __out.AppendLine(false); //148:33
            __out.Append("            }"); //149:1
            __out.AppendLine(false); //149:14
            __out.Append("        }"); //150:1
            __out.AppendLine(false); //150:10
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "        private List<"; //151:1
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Append(__tmp72_line);
                __tmp71_outputWritten = true;
            }
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(Properties.LanguageClassName);
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    string __tmp73_line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if ((__tmp73_last && !string.IsNullOrEmpty(__tmp73_line)) || (!__tmp73_last && __tmp73_line != null))
                    {
                        __out.Append(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
            }
            string __tmp74_line = "LanguageColorableItem> colorableItems = new List<"; //151:52
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            StringBuilder __tmp75 = new StringBuilder();
            __tmp75.Append(Properties.LanguageClassName);
            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
            {
                bool __tmp75_last = __tmp75Reader.EndOfStream;
                while(!__tmp75_last)
                {
                    string __tmp75_line = __tmp75Reader.ReadLine();
                    __tmp75_last = __tmp75Reader.EndOfStream;
                    if ((__tmp75_last && !string.IsNullOrEmpty(__tmp75_line)) || (!__tmp75_last && __tmp75_line != null))
                    {
                        __out.Append(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    if (!__tmp75_last) __out.AppendLine(true);
                }
            }
            string __tmp76_line = "LanguageColorableItem>();"; //151:131
            if (!string.IsNullOrEmpty(__tmp76_line))
            {
                __out.Append(__tmp76_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //151:156
            }
            bool __tmp78_outputWritten = false;
            string __tmp79_line = "        public IList<"; //152:1
            if (!string.IsNullOrEmpty(__tmp79_line))
            {
                __out.Append(__tmp79_line);
                __tmp78_outputWritten = true;
            }
            StringBuilder __tmp80 = new StringBuilder();
            __tmp80.Append(Properties.LanguageClassName);
            using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
            {
                bool __tmp80_last = __tmp80Reader.EndOfStream;
                while(!__tmp80_last)
                {
                    string __tmp80_line = __tmp80Reader.ReadLine();
                    __tmp80_last = __tmp80Reader.EndOfStream;
                    if ((__tmp80_last && !string.IsNullOrEmpty(__tmp80_line)) || (!__tmp80_last && __tmp80_line != null))
                    {
                        __out.Append(__tmp80_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp80_last) __out.AppendLine(true);
                }
            }
            string __tmp81_line = "LanguageColorableItem> ColorableItems"; //152:52
            if (!string.IsNullOrEmpty(__tmp81_line))
            {
                __out.Append(__tmp81_line);
                __tmp78_outputWritten = true;
            }
            if (__tmp78_outputWritten) __out.AppendLine(true);
            if (__tmp78_outputWritten)
            {
                __out.AppendLine(false); //152:89
            }
            __out.Append("        {"); //153:1
            __out.AppendLine(false); //153:10
            __out.Append("            get { return colorableItems; }"); //154:1
            __out.AppendLine(false); //154:43
            __out.Append("        }"); //155:1
            __out.AppendLine(false); //155:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)"); //156:1
            __out.AppendLine(false); //156:93
            __out.Append("        {"); //157:1
            __out.AppendLine(false); //157:10
            __out.Append("            return CreateColor(name, type, foregroundColor, false, false);"); //158:1
            __out.AppendLine(false); //158:75
            __out.Append("        }"); //159:1
            __out.AppendLine(false); //159:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)"); //160:1
            __out.AppendLine(false); //160:98
            __out.Append("        {"); //161:1
            __out.AppendLine(false); //161:10
            __out.Append("            return CreateColor(name, type, foregroundIndex, false, false);"); //162:1
            __out.AppendLine(false); //162:75
            __out.Append("        }"); //163:1
            __out.AppendLine(false); //163:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)"); //164:1
            __out.AppendLine(false); //164:124
            __out.Append("        {"); //165:1
            __out.AppendLine(false); //165:10
            bool __tmp83_outputWritten = false;
            string __tmp84_line = "            colorableItems.Add(new "; //166:1
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp83_outputWritten = true;
            }
            StringBuilder __tmp85 = new StringBuilder();
            __tmp85.Append(Properties.LanguageClassName);
            using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
            {
                bool __tmp85_last = __tmp85Reader.EndOfStream;
                while(!__tmp85_last)
                {
                    string __tmp85_line = __tmp85Reader.ReadLine();
                    __tmp85_last = __tmp85Reader.EndOfStream;
                    if ((__tmp85_last && !string.IsNullOrEmpty(__tmp85_line)) || (!__tmp85_last && __tmp85_line != null))
                    {
                        __out.Append(__tmp85_line);
                        __tmp83_outputWritten = true;
                    }
                    if (!__tmp85_last) __out.AppendLine(true);
                }
            }
            string __tmp86_line = "LanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));"; //166:66
            if (!string.IsNullOrEmpty(__tmp86_line))
            {
                __out.Append(__tmp86_line);
                __tmp83_outputWritten = true;
            }
            if (__tmp83_outputWritten) __out.AppendLine(true);
            if (__tmp83_outputWritten)
            {
                __out.AppendLine(false); //166:197
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //167:1
            __out.AppendLine(false); //167:53
            __out.Append("        }"); //168:1
            __out.AppendLine(false); //168:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)"); //169:1
            __out.AppendLine(false); //169:129
            __out.Append("        {"); //170:1
            __out.AppendLine(false); //170:10
            bool __tmp88_outputWritten = false;
            string __tmp89_line = "            colorableItems.Add(new "; //171:1
            if (!string.IsNullOrEmpty(__tmp89_line))
            {
                __out.Append(__tmp89_line);
                __tmp88_outputWritten = true;
            }
            StringBuilder __tmp90 = new StringBuilder();
            __tmp90.Append(Properties.LanguageClassName);
            using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
            {
                bool __tmp90_last = __tmp90Reader.EndOfStream;
                while(!__tmp90_last)
                {
                    string __tmp90_line = __tmp90Reader.ReadLine();
                    __tmp90_last = __tmp90Reader.EndOfStream;
                    if ((__tmp90_last && !string.IsNullOrEmpty(__tmp90_line)) || (!__tmp90_last && __tmp90_line != null))
                    {
                        __out.Append(__tmp90_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp90_last) __out.AppendLine(true);
                }
            }
            string __tmp91_line = "LanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));"; //171:66
            if (!string.IsNullOrEmpty(__tmp91_line))
            {
                __out.Append(__tmp91_line);
                __tmp88_outputWritten = true;
            }
            if (__tmp88_outputWritten) __out.AppendLine(true);
            if (__tmp88_outputWritten)
            {
                __out.AppendLine(false); //171:192
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //172:1
            __out.AppendLine(false); //172:53
            __out.Append("        }"); //173:1
            __out.AppendLine(false); //173:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"); //174:1
            __out.AppendLine(false); //174:203
            __out.Append("        {"); //175:1
            __out.AppendLine(false); //175:10
            bool __tmp93_outputWritten = false;
            string __tmp94_line = "            colorableItems.Add(new "; //176:1
            if (!string.IsNullOrEmpty(__tmp94_line))
            {
                __out.Append(__tmp94_line);
                __tmp93_outputWritten = true;
            }
            StringBuilder __tmp95 = new StringBuilder();
            __tmp95.Append(Properties.LanguageClassName);
            using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
            {
                bool __tmp95_last = __tmp95Reader.EndOfStream;
                while(!__tmp95_last)
                {
                    string __tmp95_line = __tmp95Reader.ReadLine();
                    __tmp95_last = __tmp95Reader.EndOfStream;
                    if ((__tmp95_last && !string.IsNullOrEmpty(__tmp95_line)) || (!__tmp95_last && __tmp95_line != null))
                    {
                        __out.Append(__tmp95_line);
                        __tmp93_outputWritten = true;
                    }
                    if (!__tmp95_last) __out.AppendLine(true);
                }
            }
            string __tmp96_line = "LanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));"; //176:66
            if (!string.IsNullOrEmpty(__tmp96_line))
            {
                __out.Append(__tmp96_line);
                __tmp93_outputWritten = true;
            }
            if (__tmp93_outputWritten) __out.AppendLine(true);
            if (__tmp93_outputWritten)
            {
                __out.AppendLine(false); //176:190
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //177:1
            __out.AppendLine(false); //177:53
            __out.Append("        }"); //178:1
            __out.AppendLine(false); //178:10
            __out.Append("    }"); //179:1
            __out.AppendLine(false); //179:6
            bool __tmp98_outputWritten = false;
            string __tmp99_line = "    public class "; //180:1
            if (!string.IsNullOrEmpty(__tmp99_line))
            {
                __out.Append(__tmp99_line);
                __tmp98_outputWritten = true;
            }
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(Properties.LanguageClassName);
            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
            {
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(!__tmp100_last)
                {
                    string __tmp100_line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    if ((__tmp100_last && !string.IsNullOrEmpty(__tmp100_line)) || (!__tmp100_last && __tmp100_line != null))
                    {
                        __out.Append(__tmp100_line);
                        __tmp98_outputWritten = true;
                    }
                    if (!__tmp100_last) __out.AppendLine(true);
                }
            }
            string __tmp101_line = "LanguageColorableItem : IVsColorableItem, IVsHiColorItem"; //180:48
            if (!string.IsNullOrEmpty(__tmp101_line))
            {
                __out.Append(__tmp101_line);
                __tmp98_outputWritten = true;
            }
            if (__tmp98_outputWritten) __out.AppendLine(true);
            if (__tmp98_outputWritten)
            {
                __out.AppendLine(false); //180:104
            }
            __out.Append("    {"); //181:1
            __out.AppendLine(false); //181:6
            __out.Append("        // Indicates that the returned RGB value is really an index"); //182:1
            __out.AppendLine(false); //182:68
            __out.Append("        // into a predefined list of colors."); //183:1
            __out.AppendLine(false); //183:45
            __out.Append("        private const uint COLOR_INDEXED = 0x01000000;"); //184:1
            __out.AppendLine(false); //184:55
            __out.Append("        public string DisplayName { get; private set; }"); //186:1
            __out.AppendLine(false); //186:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //187:1
            __out.AppendLine(false); //187:57
            __out.Append("        public COLORINDEX BackgroundIndex { get; private set; }"); //188:1
            __out.AppendLine(false); //188:64
            __out.Append("        public COLORINDEX ForegroundIndex { get; private set; }"); //189:1
            __out.AppendLine(false); //189:64
            __out.Append("        public uint BackgroundColor { get; private set; }"); //190:1
            __out.AppendLine(false); //190:58
            __out.Append("        public uint ForegroundColor { get; private set; }"); //191:1
            __out.AppendLine(false); //191:58
            __out.Append("        public uint FontFlags { get; private set; }"); //192:1
            __out.AppendLine(false); //192:52
            bool __tmp103_outputWritten = false;
            string __tmp104_line = "        public "; //194:1
            if (!string.IsNullOrEmpty(__tmp104_line))
            {
                __out.Append(__tmp104_line);
                __tmp103_outputWritten = true;
            }
            StringBuilder __tmp105 = new StringBuilder();
            __tmp105.Append(Properties.LanguageClassName);
            using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
            {
                bool __tmp105_last = __tmp105Reader.EndOfStream;
                while(!__tmp105_last)
                {
                    string __tmp105_line = __tmp105Reader.ReadLine();
                    __tmp105_last = __tmp105Reader.EndOfStream;
                    if ((__tmp105_last && !string.IsNullOrEmpty(__tmp105_line)) || (!__tmp105_last && __tmp105_line != null))
                    {
                        __out.Append(__tmp105_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp105_last) __out.AppendLine(true);
                }
            }
            string __tmp106_line = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"; //194:46
            if (!string.IsNullOrEmpty(__tmp106_line))
            {
                __out.Append(__tmp106_line);
                __tmp103_outputWritten = true;
            }
            if (__tmp103_outputWritten) __out.AppendLine(true);
            if (__tmp103_outputWritten)
            {
                __out.AppendLine(false); //194:241
            }
            __out.Append("        {"); //195:1
            __out.AppendLine(false); //195:10
            __out.Append("            this.DisplayName = displayName;"); //196:1
            __out.AppendLine(false); //196:44
            __out.Append("            this.TokenType = tokenType;"); //197:1
            __out.AppendLine(false); //197:40
            __out.Append("            this.BackgroundIndex = backgroundIndex;"); //198:1
            __out.AppendLine(false); //198:52
            __out.Append("            this.ForegroundIndex = foregroundIndex;"); //199:1
            __out.AppendLine(false); //199:52
            __out.Append("            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);"); //200:1
            __out.AppendLine(false); //200:98
            __out.Append("            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);"); //201:1
            __out.AppendLine(false); //201:98
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //202:1
            __out.AppendLine(false); //202:57
            __out.Append("            if (bold)"); //203:1
            __out.AppendLine(false); //203:22
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;"); //204:1
            __out.AppendLine(false); //204:75
            __out.Append("            if (strikethrough)"); //205:1
            __out.AppendLine(false); //205:31
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //206:1
            __out.AppendLine(false); //206:84
            __out.Append("        }"); //207:1
            __out.AppendLine(false); //207:10
            __out.Append("        #region IVsColorableItem Members"); //209:1
            __out.AppendLine(false); //209:41
            bool __tmp108_outputWritten = false;
            string __tmp109_line = "        public int GetDefaultColors(COLORINDEX"; //210:1
            if (!string.IsNullOrEmpty(__tmp109_line))
            {
                __out.Append(__tmp109_line);
                __tmp108_outputWritten = true;
            }
            StringBuilder __tmp110 = new StringBuilder();
            __tmp110.Append("[]");
            using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
            {
                bool __tmp110_last = __tmp110Reader.EndOfStream;
                while(!__tmp110_last)
                {
                    string __tmp110_line = __tmp110Reader.ReadLine();
                    __tmp110_last = __tmp110Reader.EndOfStream;
                    if ((__tmp110_last && !string.IsNullOrEmpty(__tmp110_line)) || (!__tmp110_last && __tmp110_line != null))
                    {
                        __out.Append(__tmp110_line);
                        __tmp108_outputWritten = true;
                    }
                    if (!__tmp110_last) __out.AppendLine(true);
                }
            }
            string __tmp111_line = " piForeground, COLORINDEX"; //210:53
            if (!string.IsNullOrEmpty(__tmp111_line))
            {
                __out.Append(__tmp111_line);
                __tmp108_outputWritten = true;
            }
            StringBuilder __tmp112 = new StringBuilder();
            __tmp112.Append("[]");
            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
            {
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    string __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if ((__tmp112_last && !string.IsNullOrEmpty(__tmp112_line)) || (!__tmp112_last && __tmp112_line != null))
                    {
                        __out.Append(__tmp112_line);
                        __tmp108_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
            }
            string __tmp113_line = " piBackground)"; //210:84
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Append(__tmp113_line);
                __tmp108_outputWritten = true;
            }
            if (__tmp108_outputWritten) __out.AppendLine(true);
            if (__tmp108_outputWritten)
            {
                __out.AppendLine(false); //210:98
            }
            __out.Append("        {"); //211:1
            __out.AppendLine(false); //211:10
            __out.Append("            if (null == piForeground)"); //212:1
            __out.AppendLine(false); //212:38
            __out.Append("            {"); //213:1
            __out.AppendLine(false); //213:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //214:1
            __out.AppendLine(false); //214:65
            __out.Append("            }"); //215:1
            __out.AppendLine(false); //215:14
            __out.Append("            if (0 == piForeground.Length)"); //216:1
            __out.AppendLine(false); //216:42
            __out.Append("            {"); //217:1
            __out.AppendLine(false); //217:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //218:1
            __out.AppendLine(false); //218:71
            __out.Append("            }"); //219:1
            __out.AppendLine(false); //219:14
            bool __tmp115_outputWritten = false;
            string __tmp116_line = "            piForeground"; //220:1
            if (!string.IsNullOrEmpty(__tmp116_line))
            {
                __out.Append(__tmp116_line);
                __tmp115_outputWritten = true;
            }
            StringBuilder __tmp117 = new StringBuilder();
            __tmp117.Append("[0]");
            using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
            {
                bool __tmp117_last = __tmp117Reader.EndOfStream;
                while(!__tmp117_last)
                {
                    string __tmp117_line = __tmp117Reader.ReadLine();
                    __tmp117_last = __tmp117Reader.EndOfStream;
                    if ((__tmp117_last && !string.IsNullOrEmpty(__tmp117_line)) || (!__tmp117_last && __tmp117_line != null))
                    {
                        __out.Append(__tmp117_line);
                        __tmp115_outputWritten = true;
                    }
                    if (!__tmp117_last) __out.AppendLine(true);
                }
            }
            string __tmp118_line = " = this.ForegroundIndex;"; //220:32
            if (!string.IsNullOrEmpty(__tmp118_line))
            {
                __out.Append(__tmp118_line);
                __tmp115_outputWritten = true;
            }
            if (__tmp115_outputWritten) __out.AppendLine(true);
            if (__tmp115_outputWritten)
            {
                __out.AppendLine(false); //220:56
            }
            __out.Append("            if (null == piBackground)"); //221:1
            __out.AppendLine(false); //221:38
            __out.Append("            {"); //222:1
            __out.AppendLine(false); //222:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //223:1
            __out.AppendLine(false); //223:65
            __out.Append("            }"); //224:1
            __out.AppendLine(false); //224:14
            __out.Append("            if (0 == piBackground.Length)"); //225:1
            __out.AppendLine(false); //225:42
            __out.Append("            {"); //226:1
            __out.AppendLine(false); //226:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //227:1
            __out.AppendLine(false); //227:71
            __out.Append("            }"); //228:1
            __out.AppendLine(false); //228:14
            bool __tmp120_outputWritten = false;
            string __tmp121_line = "            piBackground"; //229:1
            if (!string.IsNullOrEmpty(__tmp121_line))
            {
                __out.Append(__tmp121_line);
                __tmp120_outputWritten = true;
            }
            StringBuilder __tmp122 = new StringBuilder();
            __tmp122.Append("[0]");
            using(StreamReader __tmp122Reader = new StreamReader(this.__ToStream(__tmp122.ToString())))
            {
                bool __tmp122_last = __tmp122Reader.EndOfStream;
                while(!__tmp122_last)
                {
                    string __tmp122_line = __tmp122Reader.ReadLine();
                    __tmp122_last = __tmp122Reader.EndOfStream;
                    if ((__tmp122_last && !string.IsNullOrEmpty(__tmp122_line)) || (!__tmp122_last && __tmp122_line != null))
                    {
                        __out.Append(__tmp122_line);
                        __tmp120_outputWritten = true;
                    }
                    if (!__tmp122_last) __out.AppendLine(true);
                }
            }
            string __tmp123_line = " = this.BackgroundIndex;"; //229:32
            if (!string.IsNullOrEmpty(__tmp123_line))
            {
                __out.Append(__tmp123_line);
                __tmp120_outputWritten = true;
            }
            if (__tmp120_outputWritten) __out.AppendLine(true);
            if (__tmp120_outputWritten)
            {
                __out.AppendLine(false); //229:56
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //230:1
            __out.AppendLine(false); //230:60
            __out.Append("        }"); //231:1
            __out.AppendLine(false); //231:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //232:1
            __out.AppendLine(false); //232:62
            __out.Append("        {"); //233:1
            __out.AppendLine(false); //233:10
            __out.Append("            pdwFontFlags = this.FontFlags;"); //234:1
            __out.AppendLine(false); //234:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //235:1
            __out.AppendLine(false); //235:60
            __out.Append("        }"); //236:1
            __out.AppendLine(false); //236:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //237:1
            __out.AppendLine(false); //237:56
            __out.Append("        {"); //238:1
            __out.AppendLine(false); //238:10
            __out.Append("            pbstrName = this.DisplayName;"); //239:1
            __out.AppendLine(false); //239:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //240:1
            __out.AppendLine(false); //240:60
            __out.Append("        }"); //241:1
            __out.AppendLine(false); //241:10
            __out.Append("        public int GetColorData(int cdElement, out uint pcrColor)"); //243:1
            __out.AppendLine(false); //243:66
            __out.Append("        {"); //244:1
            __out.AppendLine(false); //244:10
            __out.Append("            int retval = VSConstants.E_NOTIMPL;"); //245:1
            __out.AppendLine(false); //245:48
            __out.Append("            pcrColor = 0;"); //246:1
            __out.AppendLine(false); //246:26
            __out.Append("            switch ((__tagVSCOLORDATA)cdElement)"); //248:1
            __out.AppendLine(false); //248:49
            __out.Append("            {"); //249:1
            __out.AppendLine(false); //249:14
            __out.Append("                case __tagVSCOLORDATA.CD_BACKGROUND:"); //250:1
            __out.AppendLine(false); //250:53
            __out.Append("                    pcrColor = this.BackgroundIndex > 0 ?"); //251:1
            __out.AppendLine(false); //251:58
            __out.Append("                                   (uint)this.BackgroundIndex | COLOR_INDEXED"); //252:1
            __out.AppendLine(false); //252:78
            __out.Append("                                   : this.BackgroundColor;"); //253:1
            __out.AppendLine(false); //253:59
            __out.Append("                    retval = VSConstants.S_OK;"); //254:1
            __out.AppendLine(false); //254:47
            __out.Append("                    break;"); //255:1
            __out.AppendLine(false); //255:27
            __out.Append("                case __tagVSCOLORDATA.CD_FOREGROUND:"); //257:1
            __out.AppendLine(false); //257:53
            __out.Append("                case __tagVSCOLORDATA.CD_LINECOLOR:"); //258:1
            __out.AppendLine(false); //258:52
            __out.Append("                    pcrColor = this.ForegroundIndex > 0 ?"); //259:1
            __out.AppendLine(false); //259:58
            __out.Append("                                   (uint)this.ForegroundIndex | COLOR_INDEXED"); //260:1
            __out.AppendLine(false); //260:78
            __out.Append("                                   : this.ForegroundColor;"); //261:1
            __out.AppendLine(false); //261:59
            __out.Append("                    retval = VSConstants.S_OK;"); //262:1
            __out.AppendLine(false); //262:47
            __out.Append("                    break;"); //263:1
            __out.AppendLine(false); //263:27
            __out.Append("                default:"); //265:1
            __out.AppendLine(false); //265:25
            __out.Append("                    retval = VSConstants.E_INVALIDARG;"); //266:1
            __out.AppendLine(false); //266:55
            __out.Append("                    break;"); //267:1
            __out.AppendLine(false); //267:27
            __out.Append("            }"); //268:1
            __out.AppendLine(false); //268:14
            __out.Append("            return retval;"); //269:1
            __out.AppendLine(false); //269:27
            __out.Append("        }"); //271:1
            __out.AppendLine(false); //271:10
            __out.Append("        #endregion"); //272:1
            __out.AppendLine(false); //272:19
            __out.Append("    }"); //273:1
            __out.AppendLine(false); //273:6
            bool __tmp125_outputWritten = false;
            string __tmp124Prefix = "    "; //276:1
            StringBuilder __tmp126 = new StringBuilder();
            __tmp126.Append("[ComVisible(true)]");
            using(StreamReader __tmp126Reader = new StreamReader(this.__ToStream(__tmp126.ToString())))
            {
                bool __tmp126_last = __tmp126Reader.EndOfStream;
                while(!__tmp126_last)
                {
                    string __tmp126_line = __tmp126Reader.ReadLine();
                    __tmp126_last = __tmp126Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp124Prefix))
                    {
                        __out.Append(__tmp124Prefix);
                        __tmp125_outputWritten = true;
                    }
                    if ((__tmp126_last && !string.IsNullOrEmpty(__tmp126_line)) || (!__tmp126_last && __tmp126_line != null))
                    {
                        __out.Append(__tmp126_line);
                        __tmp125_outputWritten = true;
                    }
                    if (!__tmp126_last || __tmp125_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp125_outputWritten)
            {
                __out.AppendLine(false); //276:27
            }
            bool __tmp128_outputWritten = false;
            string __tmp127Prefix = "    "; //277:1
            StringBuilder __tmp129 = new StringBuilder();
            __tmp129.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "GeneratorServiceGuid)]");
            using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
            {
                bool __tmp129_last = __tmp129Reader.EndOfStream;
                while(!__tmp129_last)
                {
                    string __tmp129_line = __tmp129Reader.ReadLine();
                    __tmp129_last = __tmp129Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp127Prefix))
                    {
                        __out.Append(__tmp127Prefix);
                        __tmp128_outputWritten = true;
                    }
                    if ((__tmp129_last && !string.IsNullOrEmpty(__tmp129_line)) || (!__tmp129_last && __tmp129_line != null))
                    {
                        __out.Append(__tmp129_line);
                        __tmp128_outputWritten = true;
                    }
                    if (!__tmp129_last || __tmp128_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp128_outputWritten)
            {
                __out.AppendLine(false); //277:116
            }
            bool __tmp131_outputWritten = false;
            string __tmp130Prefix = "    "; //278:1
            StringBuilder __tmp132 = new StringBuilder();
            __tmp132.Append("[ProvideObject(typeof(" + Properties.LanguageClassName + "GeneratorService), RegisterUsing = RegistrationMethod.CodeBase)]");
            using(StreamReader __tmp132Reader = new StreamReader(this.__ToStream(__tmp132.ToString())))
            {
                bool __tmp132_last = __tmp132Reader.EndOfStream;
                while(!__tmp132_last)
                {
                    string __tmp132_line = __tmp132Reader.ReadLine();
                    __tmp132_last = __tmp132Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp130Prefix))
                    {
                        __out.Append(__tmp130Prefix);
                        __tmp131_outputWritten = true;
                    }
                    if ((__tmp132_last && !string.IsNullOrEmpty(__tmp132_line)) || (!__tmp132_last && __tmp132_line != null))
                    {
                        __out.Append(__tmp132_line);
                        __tmp131_outputWritten = true;
                    }
                    if (!__tmp132_last || __tmp131_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp131_outputWritten)
            {
                __out.AppendLine(false); //278:127
            }
            bool __tmp134_outputWritten = false;
            string __tmp133Prefix = "    "; //279:1
            StringBuilder __tmp135 = new StringBuilder();
            __tmp135.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.FileExtension)]");
            using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
            {
                bool __tmp135_last = __tmp135Reader.EndOfStream;
                while(!__tmp135_last)
                {
                    string __tmp135_line = __tmp135Reader.ReadLine();
                    __tmp135_last = __tmp135Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp133Prefix))
                    {
                        __out.Append(__tmp133Prefix);
                        __tmp134_outputWritten = true;
                    }
                    if ((__tmp135_last && !string.IsNullOrEmpty(__tmp135_line)) || (!__tmp135_last && __tmp135_line != null))
                    {
                        __out.Append(__tmp135_line);
                        __tmp134_outputWritten = true;
                    }
                    if (!__tmp135_last || __tmp134_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp134_outputWritten)
            {
                __out.AppendLine(false); //279:284
            }
            bool __tmp137_outputWritten = false;
            string __tmp136Prefix = "    "; //280:1
            StringBuilder __tmp138 = new StringBuilder();
            __tmp138.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorServiceName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, GeneratesDesignTimeSource = true)]");
            using(StreamReader __tmp138Reader = new StreamReader(this.__ToStream(__tmp138.ToString())))
            {
                bool __tmp138_last = __tmp138Reader.EndOfStream;
                while(!__tmp138_last)
                {
                    string __tmp138_line = __tmp138Reader.ReadLine();
                    __tmp138_last = __tmp138Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp136Prefix))
                    {
                        __out.Append(__tmp136Prefix);
                        __tmp137_outputWritten = true;
                    }
                    if ((__tmp138_last && !string.IsNullOrEmpty(__tmp138_line)) || (!__tmp138_last && __tmp138_line != null))
                    {
                        __out.Append(__tmp138_line);
                        __tmp137_outputWritten = true;
                    }
                    if (!__tmp138_last || __tmp137_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp137_outputWritten)
            {
                __out.AppendLine(false); //280:325
            }
            if (Properties.GenerateMultipleFiles) //281:3
            {
                bool __tmp140_outputWritten = false;
                string __tmp141_line = "    public class "; //282:1
                if (!string.IsNullOrEmpty(__tmp141_line))
                {
                    __out.Append(__tmp141_line);
                    __tmp140_outputWritten = true;
                }
                StringBuilder __tmp142 = new StringBuilder();
                __tmp142.Append(Properties.LanguageClassName);
                using(StreamReader __tmp142Reader = new StreamReader(this.__ToStream(__tmp142.ToString())))
                {
                    bool __tmp142_last = __tmp142Reader.EndOfStream;
                    while(!__tmp142_last)
                    {
                        string __tmp142_line = __tmp142Reader.ReadLine();
                        __tmp142_last = __tmp142Reader.EndOfStream;
                        if ((__tmp142_last && !string.IsNullOrEmpty(__tmp142_line)) || (!__tmp142_last && __tmp142_line != null))
                        {
                            __out.Append(__tmp142_line);
                            __tmp140_outputWritten = true;
                        }
                        if (!__tmp142_last) __out.AppendLine(true);
                    }
                }
                string __tmp143_line = "GeneratorService : VsMultipleFileGenerator<object>"; //282:48
                if (!string.IsNullOrEmpty(__tmp143_line))
                {
                    __out.Append(__tmp143_line);
                    __tmp140_outputWritten = true;
                }
                if (__tmp140_outputWritten) __out.AppendLine(true);
                if (__tmp140_outputWritten)
                {
                    __out.AppendLine(false); //282:98
                }
                __out.Append("    {"); //283:1
                __out.AppendLine(false); //283:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //284:1
                __out.AppendLine(false); //284:146
                __out.Append("		{"); //285:1
                __out.AppendLine(false); //285:4
                bool __tmp145_outputWritten = false;
                string __tmp146_line = "            // If there is a compile error in the following line, create a class "; //286:1
                if (!string.IsNullOrEmpty(__tmp146_line))
                {
                    __out.Append(__tmp146_line);
                    __tmp145_outputWritten = true;
                }
                StringBuilder __tmp147 = new StringBuilder();
                __tmp147.Append(Properties.LanguageClassName);
                using(StreamReader __tmp147Reader = new StreamReader(this.__ToStream(__tmp147.ToString())))
                {
                    bool __tmp147_last = __tmp147Reader.EndOfStream;
                    while(!__tmp147_last)
                    {
                        string __tmp147_line = __tmp147Reader.ReadLine();
                        __tmp147_last = __tmp147Reader.EndOfStream;
                        if ((__tmp147_last && !string.IsNullOrEmpty(__tmp147_line)) || (!__tmp147_last && __tmp147_line != null))
                        {
                            __out.Append(__tmp147_line);
                            __tmp145_outputWritten = true;
                        }
                        if (!__tmp147_last) __out.AppendLine(true);
                    }
                }
                string __tmp148_line = "Generator"; //286:112
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Append(__tmp148_line);
                    __tmp145_outputWritten = true;
                }
                if (__tmp145_outputWritten) __out.AppendLine(true);
                if (__tmp145_outputWritten)
                {
                    __out.AppendLine(false); //286:121
                }
                __out.Append("            // which is a subclass of MultipleFileGenerator<object>"); //287:1
                __out.AppendLine(false); //287:68
                bool __tmp150_outputWritten = false;
                string __tmp151_line = "			return new "; //288:1
                if (!string.IsNullOrEmpty(__tmp151_line))
                {
                    __out.Append(__tmp151_line);
                    __tmp150_outputWritten = true;
                }
                StringBuilder __tmp152 = new StringBuilder();
                __tmp152.Append(Properties.LanguageClassName);
                using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
                {
                    bool __tmp152_last = __tmp152Reader.EndOfStream;
                    while(!__tmp152_last)
                    {
                        string __tmp152_line = __tmp152Reader.ReadLine();
                        __tmp152_last = __tmp152Reader.EndOfStream;
                        if ((__tmp152_last && !string.IsNullOrEmpty(__tmp152_line)) || (!__tmp152_last && __tmp152_line != null))
                        {
                            __out.Append(__tmp152_line);
                            __tmp150_outputWritten = true;
                        }
                        if (!__tmp152_last) __out.AppendLine(true);
                    }
                }
                string __tmp153_line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //288:45
                if (!string.IsNullOrEmpty(__tmp153_line))
                {
                    __out.Append(__tmp153_line);
                    __tmp150_outputWritten = true;
                }
                if (__tmp150_outputWritten) __out.AppendLine(true);
                if (__tmp150_outputWritten)
                {
                    __out.AppendLine(false); //288:107
                }
                __out.Append("		}"); //289:1
                __out.AppendLine(false); //289:4
                __out.AppendLine(true); //290:1
                __out.Append("        public override string GetDefaultFileExtension()"); //291:1
                __out.AppendLine(false); //291:57
                __out.Append("        {"); //292:1
                __out.AppendLine(false); //292:10
                bool __tmp155_outputWritten = false;
                string __tmp156_line = "            return "; //293:1
                if (!string.IsNullOrEmpty(__tmp156_line))
                {
                    __out.Append(__tmp156_line);
                    __tmp155_outputWritten = true;
                }
                StringBuilder __tmp157 = new StringBuilder();
                __tmp157.Append(Properties.LanguageClassName);
                using(StreamReader __tmp157Reader = new StreamReader(this.__ToStream(__tmp157.ToString())))
                {
                    bool __tmp157_last = __tmp157Reader.EndOfStream;
                    while(!__tmp157_last)
                    {
                        string __tmp157_line = __tmp157Reader.ReadLine();
                        __tmp157_last = __tmp157Reader.EndOfStream;
                        if ((__tmp157_last && !string.IsNullOrEmpty(__tmp157_line)) || (!__tmp157_last && __tmp157_line != null))
                        {
                            __out.Append(__tmp157_line);
                            __tmp155_outputWritten = true;
                        }
                        if (!__tmp157_last) __out.AppendLine(true);
                    }
                }
                string __tmp158_line = "Generator.DefaultExtension;"; //293:50
                if (!string.IsNullOrEmpty(__tmp158_line))
                {
                    __out.Append(__tmp158_line);
                    __tmp155_outputWritten = true;
                }
                if (__tmp155_outputWritten) __out.AppendLine(true);
                if (__tmp155_outputWritten)
                {
                    __out.AppendLine(false); //293:77
                }
                __out.Append("        }"); //294:1
                __out.AppendLine(false); //294:10
                __out.Append("    }"); //295:1
                __out.AppendLine(false); //295:6
            }
            else //296:3
            {
                bool __tmp160_outputWritten = false;
                string __tmp161_line = "    public class "; //297:1
                if (!string.IsNullOrEmpty(__tmp161_line))
                {
                    __out.Append(__tmp161_line);
                    __tmp160_outputWritten = true;
                }
                StringBuilder __tmp162 = new StringBuilder();
                __tmp162.Append(Properties.LanguageClassName);
                using(StreamReader __tmp162Reader = new StreamReader(this.__ToStream(__tmp162.ToString())))
                {
                    bool __tmp162_last = __tmp162Reader.EndOfStream;
                    while(!__tmp162_last)
                    {
                        string __tmp162_line = __tmp162Reader.ReadLine();
                        __tmp162_last = __tmp162Reader.EndOfStream;
                        if ((__tmp162_last && !string.IsNullOrEmpty(__tmp162_line)) || (!__tmp162_last && __tmp162_line != null))
                        {
                            __out.Append(__tmp162_line);
                            __tmp160_outputWritten = true;
                        }
                        if (!__tmp162_last) __out.AppendLine(true);
                    }
                }
                string __tmp163_line = "GeneratorService : VsSingleFileGenerator"; //297:48
                if (!string.IsNullOrEmpty(__tmp163_line))
                {
                    __out.Append(__tmp163_line);
                    __tmp160_outputWritten = true;
                }
                if (__tmp160_outputWritten) __out.AppendLine(true);
                if (__tmp160_outputWritten)
                {
                    __out.AppendLine(false); //297:88
                }
                __out.Append("    {"); //298:1
                __out.AppendLine(false); //298:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //299:1
                __out.AppendLine(false); //299:136
                __out.Append("		{"); //300:1
                __out.AppendLine(false); //300:4
                bool __tmp165_outputWritten = false;
                string __tmp166_line = "            // If there is a compile error in the following line, create a class "; //301:1
                if (!string.IsNullOrEmpty(__tmp166_line))
                {
                    __out.Append(__tmp166_line);
                    __tmp165_outputWritten = true;
                }
                StringBuilder __tmp167 = new StringBuilder();
                __tmp167.Append(Properties.LanguageClassName);
                using(StreamReader __tmp167Reader = new StreamReader(this.__ToStream(__tmp167.ToString())))
                {
                    bool __tmp167_last = __tmp167Reader.EndOfStream;
                    while(!__tmp167_last)
                    {
                        string __tmp167_line = __tmp167Reader.ReadLine();
                        __tmp167_last = __tmp167Reader.EndOfStream;
                        if ((__tmp167_last && !string.IsNullOrEmpty(__tmp167_line)) || (!__tmp167_last && __tmp167_line != null))
                        {
                            __out.Append(__tmp167_line);
                            __tmp165_outputWritten = true;
                        }
                        if (!__tmp167_last) __out.AppendLine(true);
                    }
                }
                string __tmp168_line = "Generator"; //301:112
                if (!string.IsNullOrEmpty(__tmp168_line))
                {
                    __out.Append(__tmp168_line);
                    __tmp165_outputWritten = true;
                }
                if (__tmp165_outputWritten) __out.AppendLine(true);
                if (__tmp165_outputWritten)
                {
                    __out.AppendLine(false); //301:121
                }
                __out.Append("            // which is a subclass of SingleFileGenerator"); //302:1
                __out.AppendLine(false); //302:58
                bool __tmp170_outputWritten = false;
                string __tmp171_line = "			return new "; //303:1
                if (!string.IsNullOrEmpty(__tmp171_line))
                {
                    __out.Append(__tmp171_line);
                    __tmp170_outputWritten = true;
                }
                StringBuilder __tmp172 = new StringBuilder();
                __tmp172.Append(Properties.LanguageClassName);
                using(StreamReader __tmp172Reader = new StreamReader(this.__ToStream(__tmp172.ToString())))
                {
                    bool __tmp172_last = __tmp172Reader.EndOfStream;
                    while(!__tmp172_last)
                    {
                        string __tmp172_line = __tmp172Reader.ReadLine();
                        __tmp172_last = __tmp172Reader.EndOfStream;
                        if ((__tmp172_last && !string.IsNullOrEmpty(__tmp172_line)) || (!__tmp172_last && __tmp172_line != null))
                        {
                            __out.Append(__tmp172_line);
                            __tmp170_outputWritten = true;
                        }
                        if (!__tmp172_last) __out.AppendLine(true);
                    }
                }
                string __tmp173_line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //303:45
                if (!string.IsNullOrEmpty(__tmp173_line))
                {
                    __out.Append(__tmp173_line);
                    __tmp170_outputWritten = true;
                }
                if (__tmp170_outputWritten) __out.AppendLine(true);
                if (__tmp170_outputWritten)
                {
                    __out.AppendLine(false); //303:107
                }
                __out.Append("		}"); //304:1
                __out.AppendLine(false); //304:4
                __out.AppendLine(true); //305:1
                __out.Append("        public override string GetDefaultFileExtension()"); //306:1
                __out.AppendLine(false); //306:57
                __out.Append("        {"); //307:1
                __out.AppendLine(false); //307:10
                bool __tmp175_outputWritten = false;
                string __tmp176_line = "            return "; //308:1
                if (!string.IsNullOrEmpty(__tmp176_line))
                {
                    __out.Append(__tmp176_line);
                    __tmp175_outputWritten = true;
                }
                StringBuilder __tmp177 = new StringBuilder();
                __tmp177.Append(Properties.LanguageClassName);
                using(StreamReader __tmp177Reader = new StreamReader(this.__ToStream(__tmp177.ToString())))
                {
                    bool __tmp177_last = __tmp177Reader.EndOfStream;
                    while(!__tmp177_last)
                    {
                        string __tmp177_line = __tmp177Reader.ReadLine();
                        __tmp177_last = __tmp177Reader.EndOfStream;
                        if ((__tmp177_last && !string.IsNullOrEmpty(__tmp177_line)) || (!__tmp177_last && __tmp177_line != null))
                        {
                            __out.Append(__tmp177_line);
                            __tmp175_outputWritten = true;
                        }
                        if (!__tmp177_last) __out.AppendLine(true);
                    }
                }
                string __tmp178_line = "Generator.DefaultExtension;"; //308:50
                if (!string.IsNullOrEmpty(__tmp178_line))
                {
                    __out.Append(__tmp178_line);
                    __tmp175_outputWritten = true;
                }
                if (__tmp175_outputWritten) __out.AppendLine(true);
                if (__tmp175_outputWritten)
                {
                    __out.AppendLine(false); //308:77
                }
                __out.Append("        }"); //309:1
                __out.AppendLine(false); //309:10
                __out.Append("    }"); //310:1
                __out.AppendLine(false); //310:6
            }
            bool __tmp180_outputWritten = false;
            string __tmp181_line = "    public class "; //314:1
            if (!string.IsNullOrEmpty(__tmp181_line))
            {
                __out.Append(__tmp181_line);
                __tmp180_outputWritten = true;
            }
            StringBuilder __tmp182 = new StringBuilder();
            __tmp182.Append(Properties.LanguageClassName);
            using(StreamReader __tmp182Reader = new StreamReader(this.__ToStream(__tmp182.ToString())))
            {
                bool __tmp182_last = __tmp182Reader.EndOfStream;
                while(!__tmp182_last)
                {
                    string __tmp182_line = __tmp182Reader.ReadLine();
                    __tmp182_last = __tmp182Reader.EndOfStream;
                    if ((__tmp182_last && !string.IsNullOrEmpty(__tmp182_line)) || (!__tmp182_last && __tmp182_line != null))
                    {
                        __out.Append(__tmp182_line);
                        __tmp180_outputWritten = true;
                    }
                    if (!__tmp182_last) __out.AppendLine(true);
                }
            }
            string __tmp183_line = "LanguageScanner : IScanner"; //314:48
            if (!string.IsNullOrEmpty(__tmp183_line))
            {
                __out.Append(__tmp183_line);
                __tmp180_outputWritten = true;
            }
            if (__tmp180_outputWritten) __out.AppendLine(true);
            if (__tmp180_outputWritten)
            {
                __out.AppendLine(false); //314:74
            }
            __out.Append("    {"); //315:1
            __out.AppendLine(false); //315:6
            __out.Append("        private int currentOffset;"); //316:1
            __out.AppendLine(false); //316:35
            __out.Append("        private string currentLine;"); //317:1
            __out.AppendLine(false); //317:36
            bool __tmp185_outputWritten = false;
            string __tmp186_line = "        private "; //318:1
            if (!string.IsNullOrEmpty(__tmp186_line))
            {
                __out.Append(__tmp186_line);
                __tmp185_outputWritten = true;
            }
            StringBuilder __tmp187 = new StringBuilder();
            __tmp187.Append(Properties.LanguageFullName);
            using(StreamReader __tmp187Reader = new StreamReader(this.__ToStream(__tmp187.ToString())))
            {
                bool __tmp187_last = __tmp187Reader.EndOfStream;
                while(!__tmp187_last)
                {
                    string __tmp187_line = __tmp187Reader.ReadLine();
                    __tmp187_last = __tmp187Reader.EndOfStream;
                    if ((__tmp187_last && !string.IsNullOrEmpty(__tmp187_line)) || (!__tmp187_last && __tmp187_line != null))
                    {
                        __out.Append(__tmp187_line);
                        __tmp185_outputWritten = true;
                    }
                    if (!__tmp187_last) __out.AppendLine(true);
                }
            }
            string __tmp188_line = "Lexer lexer;"; //318:46
            if (!string.IsNullOrEmpty(__tmp188_line))
            {
                __out.Append(__tmp188_line);
                __tmp185_outputWritten = true;
            }
            if (__tmp185_outputWritten) __out.AppendLine(true);
            if (__tmp185_outputWritten)
            {
                __out.AppendLine(false); //318:58
            }
            __out.Append("        private IEnumerable<SyntaxAnnotation> modeAnnotations;"); //319:1
            __out.AppendLine(false); //319:63
            __out.Append("        private IEnumerable<SyntaxAnnotation> syntaxAnnotations;"); //320:1
            __out.AppendLine(false); //320:65
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //321:1
            __out.AppendLine(false); //321:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //322:1
            __out.AppendLine(false); //322:62
            __out.Append("        private int lastState;"); //323:1
            __out.AppendLine(false); //323:31
            bool __tmp190_outputWritten = false;
            string __tmp191_line = "        public "; //325:1
            if (!string.IsNullOrEmpty(__tmp191_line))
            {
                __out.Append(__tmp191_line);
                __tmp190_outputWritten = true;
            }
            StringBuilder __tmp192 = new StringBuilder();
            __tmp192.Append(Properties.LanguageClassName);
            using(StreamReader __tmp192Reader = new StreamReader(this.__ToStream(__tmp192.ToString())))
            {
                bool __tmp192_last = __tmp192Reader.EndOfStream;
                while(!__tmp192_last)
                {
                    string __tmp192_line = __tmp192Reader.ReadLine();
                    __tmp192_last = __tmp192Reader.EndOfStream;
                    if ((__tmp192_last && !string.IsNullOrEmpty(__tmp192_line)) || (!__tmp192_last && __tmp192_line != null))
                    {
                        __out.Append(__tmp192_line);
                        __tmp190_outputWritten = true;
                    }
                    if (!__tmp192_last) __out.AppendLine(true);
                }
            }
            string __tmp193_line = "LanguageScanner()"; //325:46
            if (!string.IsNullOrEmpty(__tmp193_line))
            {
                __out.Append(__tmp193_line);
                __tmp190_outputWritten = true;
            }
            if (__tmp190_outputWritten) __out.AppendLine(true);
            if (__tmp190_outputWritten)
            {
                __out.AppendLine(false); //325:63
            }
            __out.Append("        {"); //326:1
            __out.AppendLine(false); //326:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //327:1
            __out.AppendLine(false); //327:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //328:1
            __out.AppendLine(false); //328:71
            __out.Append("            this.lastState = 0;"); //329:1
            __out.AppendLine(false); //329:32
            bool __tmp195_outputWritten = false;
            string __tmp194Prefix = "            "; //330:1
            StringBuilder __tmp196 = new StringBuilder();
            __tmp196.Append(Properties.LanguageFullName);
            using(StreamReader __tmp196Reader = new StreamReader(this.__ToStream(__tmp196.ToString())))
            {
                bool __tmp196_last = __tmp196Reader.EndOfStream;
                while(!__tmp196_last)
                {
                    string __tmp196_line = __tmp196Reader.ReadLine();
                    __tmp196_last = __tmp196Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp194Prefix))
                    {
                        __out.Append(__tmp194Prefix);
                        __tmp195_outputWritten = true;
                    }
                    if ((__tmp196_last && !string.IsNullOrEmpty(__tmp196_line)) || (!__tmp196_last && __tmp196_line != null))
                    {
                        __out.Append(__tmp196_line);
                        __tmp195_outputWritten = true;
                    }
                    if (!__tmp196_last) __out.AppendLine(true);
                }
            }
            string __tmp197_line = "LexerAnnotator annotator = new "; //330:42
            if (!string.IsNullOrEmpty(__tmp197_line))
            {
                __out.Append(__tmp197_line);
                __tmp195_outputWritten = true;
            }
            StringBuilder __tmp198 = new StringBuilder();
            __tmp198.Append(Properties.LanguageFullName);
            using(StreamReader __tmp198Reader = new StreamReader(this.__ToStream(__tmp198.ToString())))
            {
                bool __tmp198_last = __tmp198Reader.EndOfStream;
                while(!__tmp198_last)
                {
                    string __tmp198_line = __tmp198Reader.ReadLine();
                    __tmp198_last = __tmp198Reader.EndOfStream;
                    if ((__tmp198_last && !string.IsNullOrEmpty(__tmp198_line)) || (!__tmp198_last && __tmp198_line != null))
                    {
                        __out.Append(__tmp198_line);
                        __tmp195_outputWritten = true;
                    }
                    if (!__tmp198_last) __out.AppendLine(true);
                }
            }
            string __tmp199_line = "LexerAnnotator();"; //330:102
            if (!string.IsNullOrEmpty(__tmp199_line))
            {
                __out.Append(__tmp199_line);
                __tmp195_outputWritten = true;
            }
            if (__tmp195_outputWritten) __out.AppendLine(true);
            if (__tmp195_outputWritten)
            {
                __out.AppendLine(false); //330:119
            }
            __out.Append("            List<SyntaxAnnotation> mal = new List<SyntaxAnnotation>();"); //331:1
            __out.AppendLine(false); //331:71
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //332:1
            __out.AppendLine(false); //332:72
            __out.Append("            {"); //333:1
            __out.AppendLine(false); //333:14
            __out.Append("                foreach (var annot in annotList)"); //334:1
            __out.AppendLine(false); //334:49
            __out.Append("                {"); //335:1
            __out.AppendLine(false); //335:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //336:1
            __out.AppendLine(false); //336:51
            __out.Append("                    {"); //337:1
            __out.AppendLine(false); //337:22
            __out.Append("                        mal.Add((SyntaxAnnotation)annot);"); //338:1
            __out.AppendLine(false); //338:58
            __out.Append("                    }"); //339:1
            __out.AppendLine(false); //339:22
            __out.Append("                }"); //340:1
            __out.AppendLine(false); //340:18
            __out.Append("            }"); //341:1
            __out.AppendLine(false); //341:14
            __out.Append("            this.modeAnnotations = mal;"); //342:1
            __out.AppendLine(false); //342:40
            __out.Append("            List<SyntaxAnnotation> sal = new List<SyntaxAnnotation>();"); //343:1
            __out.AppendLine(false); //343:71
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //344:1
            __out.AppendLine(false); //344:73
            __out.Append("            {"); //345:1
            __out.AppendLine(false); //345:14
            __out.Append("                foreach (var annot in annotList)"); //346:1
            __out.AppendLine(false); //346:49
            __out.Append("                {"); //347:1
            __out.AppendLine(false); //347:18
            __out.Append("                    if (annot is SyntaxAnnotation)"); //348:1
            __out.AppendLine(false); //348:51
            __out.Append("                    {"); //349:1
            __out.AppendLine(false); //349:22
            __out.Append("                        sal.Add((SyntaxAnnotation)annot);"); //350:1
            __out.AppendLine(false); //350:58
            __out.Append("                    }"); //351:1
            __out.AppendLine(false); //351:22
            __out.Append("                }"); //352:1
            __out.AppendLine(false); //352:18
            __out.Append("            }"); //353:1
            __out.AppendLine(false); //353:14
            __out.Append("            this.syntaxAnnotations = sal;"); //354:1
            __out.AppendLine(false); //354:42
            __out.Append("        }"); //355:1
            __out.AppendLine(false); //355:10
            bool __tmp201_outputWritten = false;
            string __tmp202_line = "        private void LoadState(int state, "; //357:1
            if (!string.IsNullOrEmpty(__tmp202_line))
            {
                __out.Append(__tmp202_line);
                __tmp201_outputWritten = true;
            }
            StringBuilder __tmp203 = new StringBuilder();
            __tmp203.Append(Properties.LanguageFullName);
            using(StreamReader __tmp203Reader = new StreamReader(this.__ToStream(__tmp203.ToString())))
            {
                bool __tmp203_last = __tmp203Reader.EndOfStream;
                while(!__tmp203_last)
                {
                    string __tmp203_line = __tmp203Reader.ReadLine();
                    __tmp203_last = __tmp203Reader.EndOfStream;
                    if ((__tmp203_last && !string.IsNullOrEmpty(__tmp203_line)) || (!__tmp203_last && __tmp203_line != null))
                    {
                        __out.Append(__tmp203_line);
                        __tmp201_outputWritten = true;
                    }
                    if (!__tmp203_last) __out.AppendLine(true);
                }
            }
            string __tmp204_line = "Lexer lexer)"; //357:72
            if (!string.IsNullOrEmpty(__tmp204_line))
            {
                __out.Append(__tmp204_line);
                __tmp201_outputWritten = true;
            }
            if (__tmp201_outputWritten) __out.AppendLine(true);
            if (__tmp201_outputWritten)
            {
                __out.AppendLine(false); //357:84
            }
            __out.Append("        {"); //358:1
            __out.AppendLine(false); //358:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //359:1
            __out.AppendLine(false); //359:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //360:1
            __out.AppendLine(false); //360:55
            __out.Append("            value.Restore(lexer);"); //361:1
            __out.AppendLine(false); //361:34
            __out.Append("        }"); //362:1
            __out.AppendLine(false); //362:10
            bool __tmp206_outputWritten = false;
            string __tmp207_line = "        private int SaveState("; //364:1
            if (!string.IsNullOrEmpty(__tmp207_line))
            {
                __out.Append(__tmp207_line);
                __tmp206_outputWritten = true;
            }
            StringBuilder __tmp208 = new StringBuilder();
            __tmp208.Append(Properties.LanguageFullName);
            using(StreamReader __tmp208Reader = new StreamReader(this.__ToStream(__tmp208.ToString())))
            {
                bool __tmp208_last = __tmp208Reader.EndOfStream;
                while(!__tmp208_last)
                {
                    string __tmp208_line = __tmp208Reader.ReadLine();
                    __tmp208_last = __tmp208Reader.EndOfStream;
                    if ((__tmp208_last && !string.IsNullOrEmpty(__tmp208_line)) || (!__tmp208_last && __tmp208_line != null))
                    {
                        __out.Append(__tmp208_line);
                        __tmp206_outputWritten = true;
                    }
                    if (!__tmp208_last) __out.AppendLine(true);
                }
            }
            string __tmp209_line = "Lexer lexer)"; //364:60
            if (!string.IsNullOrEmpty(__tmp209_line))
            {
                __out.Append(__tmp209_line);
                __tmp206_outputWritten = true;
            }
            if (__tmp206_outputWritten) __out.AppendLine(true);
            if (__tmp206_outputWritten)
            {
                __out.AppendLine(false); //364:72
            }
            __out.Append("        {"); //365:1
            __out.AppendLine(false); //365:10
            __out.Append("            int result = 0;"); //366:1
            __out.AppendLine(false); //366:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //367:1
            __out.AppendLine(false); //367:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //368:1
            __out.AppendLine(false); //368:68
            __out.Append("            {"); //369:1
            __out.AppendLine(false); //369:14
            __out.Append("                result = ++lastState;"); //370:1
            __out.AppendLine(false); //370:38
            __out.Append("                this.states.Add(result, state);"); //371:1
            __out.AppendLine(false); //371:48
            __out.Append("                this.inverseStates.Add(state, result);"); //372:1
            __out.AppendLine(false); //372:55
            __out.Append("            }"); //373:1
            __out.AppendLine(false); //373:14
            __out.Append("            return result;"); //374:1
            __out.AppendLine(false); //374:27
            __out.Append("        }"); //375:1
            __out.AppendLine(false); //375:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //377:1
            __out.AppendLine(false); //377:87
            __out.Append("        {"); //378:1
            __out.AppendLine(false); //378:10
            __out.Append("            try"); //379:1
            __out.AppendLine(false); //379:16
            __out.Append("            {"); //380:1
            __out.AppendLine(false); //380:14
            __out.Append("                if (this.lexer == null)"); //381:1
            __out.AppendLine(false); //381:40
            __out.Append("                {"); //382:1
            __out.AppendLine(false); //382:18
            bool __tmp211_outputWritten = false;
            string __tmp212_line = "                    this.lexer = new "; //383:1
            if (!string.IsNullOrEmpty(__tmp212_line))
            {
                __out.Append(__tmp212_line);
                __tmp211_outputWritten = true;
            }
            StringBuilder __tmp213 = new StringBuilder();
            __tmp213.Append(Properties.LanguageFullName);
            using(StreamReader __tmp213Reader = new StreamReader(this.__ToStream(__tmp213.ToString())))
            {
                bool __tmp213_last = __tmp213Reader.EndOfStream;
                while(!__tmp213_last)
                {
                    string __tmp213_line = __tmp213Reader.ReadLine();
                    __tmp213_last = __tmp213Reader.EndOfStream;
                    if ((__tmp213_last && !string.IsNullOrEmpty(__tmp213_line)) || (!__tmp213_last && __tmp213_line != null))
                    {
                        __out.Append(__tmp213_line);
                        __tmp211_outputWritten = true;
                    }
                    if (!__tmp213_last) __out.AppendLine(true);
                }
            }
            string __tmp214_line = "Lexer(new AntlrInputStream(this.currentLine + \""; //383:67
            if (!string.IsNullOrEmpty(__tmp214_line))
            {
                __out.Append(__tmp214_line);
                __tmp211_outputWritten = true;
            }
            string __tmp215_line = "\\"; //383:114
            if (!string.IsNullOrEmpty(__tmp215_line))
            {
                __out.Append(__tmp215_line);
                __tmp211_outputWritten = true;
            }
            string __tmp216_line = "r"; //383:115
            if (!string.IsNullOrEmpty(__tmp216_line))
            {
                __out.Append(__tmp216_line);
                __tmp211_outputWritten = true;
            }
            string __tmp217_line = "\\"; //383:116
            if (!string.IsNullOrEmpty(__tmp217_line))
            {
                __out.Append(__tmp217_line);
                __tmp211_outputWritten = true;
            }
            string __tmp218_line = "n\"));"; //383:117
            if (!string.IsNullOrEmpty(__tmp218_line))
            {
                __out.Append(__tmp218_line);
                __tmp211_outputWritten = true;
            }
            if (__tmp211_outputWritten) __out.AppendLine(true);
            if (__tmp211_outputWritten)
            {
                __out.AppendLine(false); //383:122
            }
            __out.Append("                }"); //384:1
            __out.AppendLine(false); //384:18
            __out.Append("                this.LoadState(state, this.lexer);"); //385:1
            __out.AppendLine(false); //385:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //386:1
            __out.AppendLine(false); //386:55
            __out.Append("                int tokenType = -1;"); //387:1
            __out.AppendLine(false); //387:36
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //389:1
            __out.AppendLine(false); //389:64
            __out.Append("                {"); //390:1
            __out.AppendLine(false); //390:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //391:1
            __out.AppendLine(false); //391:111
            __out.Append("                    {"); //392:1
            __out.AppendLine(false); //392:22
            __out.Append("                        tokenType = modeAnnot.Kind;"); //393:1
            __out.AppendLine(false); //393:52
            __out.Append("                        break;"); //394:1
            __out.AppendLine(false); //394:31
            __out.Append("                    }"); //395:1
            __out.AppendLine(false); //395:22
            __out.Append("                }"); //396:1
            __out.AppendLine(false); //396:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //397:1
            __out.AppendLine(false); //397:68
            __out.Append("                {"); //398:1
            __out.AppendLine(false); //398:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //399:1
            __out.AppendLine(false); //399:91
            __out.Append("                    {"); //400:1
            __out.AppendLine(false); //400:22
            __out.Append("                        tokenType = syntaxAnnot.Kind;"); //401:1
            __out.AppendLine(false); //401:54
            __out.Append("                        break;"); //402:1
            __out.AppendLine(false); //402:31
            __out.Append("                    }"); //403:1
            __out.AppendLine(false); //403:22
            __out.Append("                }"); //404:1
            __out.AppendLine(false); //404:18
            bool __tmp220_outputWritten = false;
            string __tmp221_line = "                if (tokenType >= 1 && tokenType <= "; //406:1
            if (!string.IsNullOrEmpty(__tmp221_line))
            {
                __out.Append(__tmp221_line);
                __tmp220_outputWritten = true;
            }
            StringBuilder __tmp222 = new StringBuilder();
            __tmp222.Append(Properties.LanguageClassName);
            using(StreamReader __tmp222Reader = new StreamReader(this.__ToStream(__tmp222.ToString())))
            {
                bool __tmp222_last = __tmp222Reader.EndOfStream;
                while(!__tmp222_last)
                {
                    string __tmp222_line = __tmp222Reader.ReadLine();
                    __tmp222_last = __tmp222Reader.EndOfStream;
                    if ((__tmp222_last && !string.IsNullOrEmpty(__tmp222_line)) || (!__tmp222_last && __tmp222_line != null))
                    {
                        __out.Append(__tmp222_line);
                        __tmp220_outputWritten = true;
                    }
                    if (!__tmp222_last) __out.AppendLine(true);
                }
            }
            string __tmp223_line = "LanguageConfig.Instance.ColorableItems.Count)"; //406:82
            if (!string.IsNullOrEmpty(__tmp223_line))
            {
                __out.Append(__tmp223_line);
                __tmp220_outputWritten = true;
            }
            if (__tmp220_outputWritten) __out.AppendLine(true);
            if (__tmp220_outputWritten)
            {
                __out.AppendLine(false); //406:127
            }
            __out.Append("                {"); //407:1
            __out.AppendLine(false); //407:18
            bool __tmp225_outputWritten = false;
            string __tmp224Prefix = "                    "; //408:1
            StringBuilder __tmp226 = new StringBuilder();
            __tmp226.Append(Properties.LanguageClassName);
            using(StreamReader __tmp226Reader = new StreamReader(this.__ToStream(__tmp226.ToString())))
            {
                bool __tmp226_last = __tmp226Reader.EndOfStream;
                while(!__tmp226_last)
                {
                    string __tmp226_line = __tmp226Reader.ReadLine();
                    __tmp226_last = __tmp226Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp224Prefix))
                    {
                        __out.Append(__tmp224Prefix);
                        __tmp225_outputWritten = true;
                    }
                    if ((__tmp226_last && !string.IsNullOrEmpty(__tmp226_line)) || (!__tmp226_last && __tmp226_line != null))
                    {
                        __out.Append(__tmp226_line);
                        __tmp225_outputWritten = true;
                    }
                    if (!__tmp226_last) __out.AppendLine(true);
                }
            }
            string __tmp227_line = "LanguageColorableItem colorItem = "; //408:51
            if (!string.IsNullOrEmpty(__tmp227_line))
            {
                __out.Append(__tmp227_line);
                __tmp225_outputWritten = true;
            }
            StringBuilder __tmp228 = new StringBuilder();
            __tmp228.Append(Properties.LanguageClassName);
            using(StreamReader __tmp228Reader = new StreamReader(this.__ToStream(__tmp228.ToString())))
            {
                bool __tmp228_last = __tmp228Reader.EndOfStream;
                while(!__tmp228_last)
                {
                    string __tmp228_line = __tmp228Reader.ReadLine();
                    __tmp228_last = __tmp228Reader.EndOfStream;
                    if ((__tmp228_last && !string.IsNullOrEmpty(__tmp228_line)) || (!__tmp228_last && __tmp228_line != null))
                    {
                        __out.Append(__tmp228_line);
                        __tmp225_outputWritten = true;
                    }
                    if (!__tmp228_last) __out.AppendLine(true);
                }
            }
            string __tmp229_line = "LanguageConfig.Instance.ColorableItems"; //408:115
            if (!string.IsNullOrEmpty(__tmp229_line))
            {
                __out.Append(__tmp229_line);
                __tmp225_outputWritten = true;
            }
            StringBuilder __tmp230 = new StringBuilder();
            __tmp230.Append("[tokenType - 1]");
            using(StreamReader __tmp230Reader = new StreamReader(this.__ToStream(__tmp230.ToString())))
            {
                bool __tmp230_last = __tmp230Reader.EndOfStream;
                while(!__tmp230_last)
                {
                    string __tmp230_line = __tmp230Reader.ReadLine();
                    __tmp230_last = __tmp230Reader.EndOfStream;
                    if ((__tmp230_last && !string.IsNullOrEmpty(__tmp230_line)) || (!__tmp230_last && __tmp230_line != null))
                    {
                        __out.Append(__tmp230_line);
                        __tmp225_outputWritten = true;
                    }
                    if (!__tmp230_last) __out.AppendLine(true);
                }
            }
            string __tmp231_line = ";"; //408:172
            if (!string.IsNullOrEmpty(__tmp231_line))
            {
                __out.Append(__tmp231_line);
                __tmp225_outputWritten = true;
            }
            if (__tmp225_outputWritten) __out.AppendLine(true);
            if (__tmp225_outputWritten)
            {
                __out.AppendLine(false); //408:173
            }
            __out.Append("                    tokenInfo.Token = token.Type;"); //409:1
            __out.AppendLine(false); //409:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //410:1
            __out.AppendLine(false); //410:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //411:1
            __out.AppendLine(false); //411:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //412:1
            __out.AppendLine(false); //412:60
            __out.Append("                }"); //413:1
            __out.AppendLine(false); //413:18
            __out.Append("                else"); //414:1
            __out.AppendLine(false); //414:21
            __out.Append("                {"); //415:1
            __out.AppendLine(false); //415:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //416:1
            __out.AppendLine(false); //416:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //417:1
            __out.AppendLine(false); //417:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //418:1
            __out.AppendLine(false); //418:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //419:1
            __out.AppendLine(false); //419:60
            __out.Append("                }"); //420:1
            __out.AppendLine(false); //420:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //422:1
            __out.AppendLine(false); //422:103
            __out.Append("                {"); //423:1
            __out.AppendLine(false); //423:18
            __out.Append("                    return false;"); //424:1
            __out.AppendLine(false); //424:34
            __out.Append("                }"); //425:1
            __out.AppendLine(false); //425:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //426:1
            __out.AppendLine(false); //426:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //427:1
            __out.AppendLine(false); //427:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //428:1
            __out.AppendLine(false); //428:61
            __out.Append("                state = this.SaveState(lexer);"); //429:1
            __out.AppendLine(false); //429:47
            __out.Append("                return true;"); //430:1
            __out.AppendLine(false); //430:29
            __out.Append("            }"); //431:1
            __out.AppendLine(false); //431:14
            __out.Append("            catch (Exception)"); //432:1
            __out.AppendLine(false); //432:30
            __out.Append("            {"); //433:1
            __out.AppendLine(false); //433:14
            __out.Append("                return false;"); //434:1
            __out.AppendLine(false); //434:30
            __out.Append("            }"); //435:1
            __out.AppendLine(false); //435:14
            __out.Append("        }"); //436:1
            __out.AppendLine(false); //436:10
            __out.Append("        public void SetSource(string source, int offset)"); //438:1
            __out.AppendLine(false); //438:57
            __out.Append("        {"); //439:1
            __out.AppendLine(false); //439:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //440:1
            __out.AppendLine(false); //440:78
            __out.Append("            {"); //441:1
            __out.AppendLine(false); //441:14
            __out.Append("                this.currentOffset = offset;"); //442:1
            __out.AppendLine(false); //442:45
            __out.Append("                this.currentLine = source;"); //443:1
            __out.AppendLine(false); //443:43
            __out.Append("                this.lexer = null;"); //444:1
            __out.AppendLine(false); //444:35
            __out.Append("            }"); //445:1
            __out.AppendLine(false); //445:14
            __out.Append("        }"); //446:1
            __out.AppendLine(false); //446:10
            __out.Append("        internal void ScanLine(ref int state)"); //447:1
            __out.AppendLine(false); //447:46
            __out.Append("        {"); //448:1
            __out.AppendLine(false); //448:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //449:1
            __out.AppendLine(false); //449:86
            __out.Append("        }"); //450:1
            __out.AppendLine(false); //450:10
            __out.Append("        internal struct LanguageScannerState"); //452:1
            __out.AppendLine(false); //452:45
            __out.Append("        {"); //453:1
            __out.AppendLine(false); //453:10
            bool __tmp233_outputWritten = false;
            string __tmp234_line = "            public LanguageScannerState("; //454:1
            if (!string.IsNullOrEmpty(__tmp234_line))
            {
                __out.Append(__tmp234_line);
                __tmp233_outputWritten = true;
            }
            StringBuilder __tmp235 = new StringBuilder();
            __tmp235.Append(Properties.LanguageFullName);
            using(StreamReader __tmp235Reader = new StreamReader(this.__ToStream(__tmp235.ToString())))
            {
                bool __tmp235_last = __tmp235Reader.EndOfStream;
                while(!__tmp235_last)
                {
                    string __tmp235_line = __tmp235Reader.ReadLine();
                    __tmp235_last = __tmp235Reader.EndOfStream;
                    if ((__tmp235_last && !string.IsNullOrEmpty(__tmp235_line)) || (!__tmp235_last && __tmp235_line != null))
                    {
                        __out.Append(__tmp235_line);
                        __tmp233_outputWritten = true;
                    }
                    if (!__tmp235_last) __out.AppendLine(true);
                }
            }
            string __tmp236_line = "Lexer lexer)"; //454:70
            if (!string.IsNullOrEmpty(__tmp236_line))
            {
                __out.Append(__tmp236_line);
                __tmp233_outputWritten = true;
            }
            if (__tmp233_outputWritten) __out.AppendLine(true);
            if (__tmp233_outputWritten)
            {
                __out.AppendLine(false); //454:82
            }
            __out.Append("            {"); //455:1
            __out.AppendLine(false); //455:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //456:1
            __out.AppendLine(false); //456:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //457:1
            __out.AppendLine(false); //457:101
            __out.Append("                this._type = lexer.Type;"); //458:1
            __out.AppendLine(false); //458:41
            __out.Append("                this._channel = lexer.Channel;"); //459:1
            __out.AppendLine(false); //459:47
            __out.Append("                this._state = lexer.State;"); //460:1
            __out.AppendLine(false); //460:43
            __out.Append("            }"); //461:1
            __out.AppendLine(false); //461:14
            __out.Append("            internal int _state;"); //463:1
            __out.AppendLine(false); //463:33
            __out.Append("            internal int _mode;"); //464:1
            __out.AppendLine(false); //464:32
            __out.Append("            internal List<int> _modeStack;"); //465:1
            __out.AppendLine(false); //465:43
            __out.Append("            internal int _type;"); //466:1
            __out.AppendLine(false); //466:32
            __out.Append("            internal int _channel;"); //467:1
            __out.AppendLine(false); //467:35
            bool __tmp238_outputWritten = false;
            string __tmp239_line = "            public void Restore("; //469:1
            if (!string.IsNullOrEmpty(__tmp239_line))
            {
                __out.Append(__tmp239_line);
                __tmp238_outputWritten = true;
            }
            StringBuilder __tmp240 = new StringBuilder();
            __tmp240.Append(Properties.LanguageFullName);
            using(StreamReader __tmp240Reader = new StreamReader(this.__ToStream(__tmp240.ToString())))
            {
                bool __tmp240_last = __tmp240Reader.EndOfStream;
                while(!__tmp240_last)
                {
                    string __tmp240_line = __tmp240Reader.ReadLine();
                    __tmp240_last = __tmp240Reader.EndOfStream;
                    if ((__tmp240_last && !string.IsNullOrEmpty(__tmp240_line)) || (!__tmp240_last && __tmp240_line != null))
                    {
                        __out.Append(__tmp240_line);
                        __tmp238_outputWritten = true;
                    }
                    if (!__tmp240_last) __out.AppendLine(true);
                }
            }
            string __tmp241_line = "Lexer lexer)"; //469:62
            if (!string.IsNullOrEmpty(__tmp241_line))
            {
                __out.Append(__tmp241_line);
                __tmp238_outputWritten = true;
            }
            if (__tmp238_outputWritten) __out.AppendLine(true);
            if (__tmp238_outputWritten)
            {
                __out.AppendLine(false); //469:74
            }
            __out.Append("            {"); //470:1
            __out.AppendLine(false); //470:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //471:1
            __out.AppendLine(false); //471:48
            __out.Append("                lexer.ModeStack.Clear();"); //472:1
            __out.AppendLine(false); //472:41
            __out.Append("                if (this._modeStack != null)"); //473:1
            __out.AppendLine(false); //473:45
            __out.Append("                {"); //474:1
            __out.AppendLine(false); //474:18
            __out.Append("                    foreach (var item in this._modeStack)"); //475:1
            __out.AppendLine(false); //475:58
            __out.Append("                    {"); //476:1
            __out.AppendLine(false); //476:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //477:1
            __out.AppendLine(false); //477:52
            __out.Append("                    }"); //478:1
            __out.AppendLine(false); //478:22
            __out.Append("                }"); //479:1
            __out.AppendLine(false); //479:18
            __out.Append("                lexer.Type = this._type;"); //480:1
            __out.AppendLine(false); //480:41
            __out.Append("                lexer.Channel = this._channel;"); //481:1
            __out.AppendLine(false); //481:47
            __out.Append("                lexer.State = this._state;"); //482:1
            __out.AppendLine(false); //482:43
            __out.Append("            }"); //483:1
            __out.AppendLine(false); //483:14
            __out.Append("            public override bool Equals(object obj)"); //485:1
            __out.AppendLine(false); //485:52
            __out.Append("            {"); //486:1
            __out.AppendLine(false); //486:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //487:1
            __out.AppendLine(false); //487:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //488:1
            __out.AppendLine(false); //488:59
            __out.Append("                if (rhs._type != this._type) return false;"); //489:1
            __out.AppendLine(false); //489:59
            __out.Append("                if (rhs._state != this._state) return false;"); //490:1
            __out.AppendLine(false); //490:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //491:1
            __out.AppendLine(false); //491:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //492:1
            __out.AppendLine(false); //492:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //493:1
            __out.AppendLine(false); //493:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //494:1
            __out.AppendLine(false); //494:71
            __out.Append("                {"); //495:1
            __out.AppendLine(false); //495:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //496:1
            __out.AppendLine(false); //496:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //497:1
            __out.AppendLine(false); //497:67
            __out.Append("                    {"); //498:1
            __out.AppendLine(false); //498:22
            bool __tmp243_outputWritten = false;
            string __tmp244_line = "                        if (rhs._modeStack"; //499:1
            if (!string.IsNullOrEmpty(__tmp244_line))
            {
                __out.Append(__tmp244_line);
                __tmp243_outputWritten = true;
            }
            StringBuilder __tmp245 = new StringBuilder();
            __tmp245.Append("[i]");
            using(StreamReader __tmp245Reader = new StreamReader(this.__ToStream(__tmp245.ToString())))
            {
                bool __tmp245_last = __tmp245Reader.EndOfStream;
                while(!__tmp245_last)
                {
                    string __tmp245_line = __tmp245Reader.ReadLine();
                    __tmp245_last = __tmp245Reader.EndOfStream;
                    if ((__tmp245_last && !string.IsNullOrEmpty(__tmp245_line)) || (!__tmp245_last && __tmp245_line != null))
                    {
                        __out.Append(__tmp245_line);
                        __tmp243_outputWritten = true;
                    }
                    if (!__tmp245_last) __out.AppendLine(true);
                }
            }
            string __tmp246_line = " != this._modeStack"; //499:50
            if (!string.IsNullOrEmpty(__tmp246_line))
            {
                __out.Append(__tmp246_line);
                __tmp243_outputWritten = true;
            }
            StringBuilder __tmp247 = new StringBuilder();
            __tmp247.Append("[i]");
            using(StreamReader __tmp247Reader = new StreamReader(this.__ToStream(__tmp247.ToString())))
            {
                bool __tmp247_last = __tmp247Reader.EndOfStream;
                while(!__tmp247_last)
                {
                    string __tmp247_line = __tmp247Reader.ReadLine();
                    __tmp247_last = __tmp247Reader.EndOfStream;
                    if ((__tmp247_last && !string.IsNullOrEmpty(__tmp247_line)) || (!__tmp247_last && __tmp247_line != null))
                    {
                        __out.Append(__tmp247_line);
                        __tmp243_outputWritten = true;
                    }
                    if (!__tmp247_last) __out.AppendLine(true);
                }
            }
            string __tmp248_line = ") return false;"; //499:76
            if (!string.IsNullOrEmpty(__tmp248_line))
            {
                __out.Append(__tmp248_line);
                __tmp243_outputWritten = true;
            }
            if (__tmp243_outputWritten) __out.AppendLine(true);
            if (__tmp243_outputWritten)
            {
                __out.AppendLine(false); //499:91
            }
            __out.Append("                    }"); //500:1
            __out.AppendLine(false); //500:22
            __out.Append("                }"); //501:1
            __out.AppendLine(false); //501:18
            __out.Append("                return true;"); //502:1
            __out.AppendLine(false); //502:29
            __out.Append("            }"); //503:1
            __out.AppendLine(false); //503:14
            __out.Append("            public override int GetHashCode()"); //505:1
            __out.AppendLine(false); //505:46
            __out.Append("            {"); //506:1
            __out.AppendLine(false); //506:14
            __out.Append("                int result = 0;"); //507:1
            __out.AppendLine(false); //507:32
            __out.Append("                result "); //508:1
            __out.Append("^"); //508:24
            __out.Append("= this._mode.GetHashCode();"); //508:25
            __out.AppendLine(false); //508:52
            __out.Append("                result "); //509:1
            __out.Append("^"); //509:24
            __out.Append("= this._type.GetHashCode();"); //509:25
            __out.AppendLine(false); //509:52
            __out.Append("                result "); //510:1
            __out.Append("^"); //510:24
            __out.Append("= this._state.GetHashCode();"); //510:25
            __out.AppendLine(false); //510:53
            __out.Append("                result "); //511:1
            __out.Append("^"); //511:24
            __out.Append("= this._channel.GetHashCode();"); //511:25
            __out.AppendLine(false); //511:55
            __out.Append("                if (this._modeStack != null)"); //512:1
            __out.AppendLine(false); //512:45
            __out.Append("                {"); //513:1
            __out.AppendLine(false); //513:18
            __out.Append("                    result "); //514:1
            __out.Append("^"); //514:28
            __out.Append("= this._modeStack.GetHashCode();"); //514:29
            __out.AppendLine(false); //514:61
            __out.Append("                }"); //515:1
            __out.AppendLine(false); //515:18
            __out.Append("                return result;"); //516:1
            __out.AppendLine(false); //516:31
            __out.Append("            }"); //517:1
            __out.AppendLine(false); //517:14
            __out.Append("        }"); //518:1
            __out.AppendLine(false); //518:10
            __out.Append("    }"); //519:1
            __out.AppendLine(false); //519:6
            bool __tmp250_outputWritten = false;
            string __tmp249Prefix = "    "; //521:1
            StringBuilder __tmp251 = new StringBuilder();
            __tmp251.Append("[ComVisible(true)]");
            using(StreamReader __tmp251Reader = new StreamReader(this.__ToStream(__tmp251.ToString())))
            {
                bool __tmp251_last = __tmp251Reader.EndOfStream;
                while(!__tmp251_last)
                {
                    string __tmp251_line = __tmp251Reader.ReadLine();
                    __tmp251_last = __tmp251Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp249Prefix))
                    {
                        __out.Append(__tmp249Prefix);
                        __tmp250_outputWritten = true;
                    }
                    if ((__tmp251_last && !string.IsNullOrEmpty(__tmp251_line)) || (!__tmp251_last && __tmp251_line != null))
                    {
                        __out.Append(__tmp251_line);
                        __tmp250_outputWritten = true;
                    }
                    if (!__tmp251_last || __tmp250_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp250_outputWritten)
            {
                __out.AppendLine(false); //521:27
            }
            bool __tmp253_outputWritten = false;
            string __tmp252Prefix = "    "; //522:1
            StringBuilder __tmp254 = new StringBuilder();
            __tmp254.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
            using(StreamReader __tmp254Reader = new StreamReader(this.__ToStream(__tmp254.ToString())))
            {
                bool __tmp254_last = __tmp254Reader.EndOfStream;
                while(!__tmp254_last)
                {
                    string __tmp254_line = __tmp254Reader.ReadLine();
                    __tmp254_last = __tmp254Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp252Prefix))
                    {
                        __out.Append(__tmp252Prefix);
                        __tmp253_outputWritten = true;
                    }
                    if ((__tmp254_last && !string.IsNullOrEmpty(__tmp254_line)) || (!__tmp254_last && __tmp254_line != null))
                    {
                        __out.Append(__tmp254_line);
                        __tmp253_outputWritten = true;
                    }
                    if (!__tmp254_last || __tmp253_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp253_outputWritten)
            {
                __out.AppendLine(false); //522:115
            }
            bool __tmp256_outputWritten = false;
            string __tmp257_line = "    public class "; //523:1
            if (!string.IsNullOrEmpty(__tmp257_line))
            {
                __out.Append(__tmp257_line);
                __tmp256_outputWritten = true;
            }
            StringBuilder __tmp258 = new StringBuilder();
            __tmp258.Append(Properties.LanguageClassName);
            using(StreamReader __tmp258Reader = new StreamReader(this.__ToStream(__tmp258.ToString())))
            {
                bool __tmp258_last = __tmp258Reader.EndOfStream;
                while(!__tmp258_last)
                {
                    string __tmp258_line = __tmp258Reader.ReadLine();
                    __tmp258_last = __tmp258Reader.EndOfStream;
                    if ((__tmp258_last && !string.IsNullOrEmpty(__tmp258_line)) || (!__tmp258_last && __tmp258_line != null))
                    {
                        __out.Append(__tmp258_line);
                        __tmp256_outputWritten = true;
                    }
                    if (!__tmp258_last) __out.AppendLine(true);
                }
            }
            string __tmp259_line = "LanguageService : LanguageService"; //523:48
            if (!string.IsNullOrEmpty(__tmp259_line))
            {
                __out.Append(__tmp259_line);
                __tmp256_outputWritten = true;
            }
            if (__tmp256_outputWritten) __out.AppendLine(true);
            if (__tmp256_outputWritten)
            {
                __out.AppendLine(false); //523:81
            }
            __out.Append("    {"); //524:1
            __out.AppendLine(false); //524:6
            __out.Append("        private LanguagePreferences preferences;"); //525:1
            __out.AppendLine(false); //525:49
            bool __tmp261_outputWritten = false;
            string __tmp262_line = "        private "; //526:1
            if (!string.IsNullOrEmpty(__tmp262_line))
            {
                __out.Append(__tmp262_line);
                __tmp261_outputWritten = true;
            }
            StringBuilder __tmp263 = new StringBuilder();
            __tmp263.Append(Properties.LanguageClassName);
            using(StreamReader __tmp263Reader = new StreamReader(this.__ToStream(__tmp263.ToString())))
            {
                bool __tmp263_last = __tmp263Reader.EndOfStream;
                while(!__tmp263_last)
                {
                    string __tmp263_line = __tmp263Reader.ReadLine();
                    __tmp263_last = __tmp263Reader.EndOfStream;
                    if ((__tmp263_last && !string.IsNullOrEmpty(__tmp263_line)) || (!__tmp263_last && __tmp263_line != null))
                    {
                        __out.Append(__tmp263_line);
                        __tmp261_outputWritten = true;
                    }
                    if (!__tmp263_last) __out.AppendLine(true);
                }
            }
            string __tmp264_line = "LanguageScanner scanner;"; //526:47
            if (!string.IsNullOrEmpty(__tmp264_line))
            {
                __out.Append(__tmp264_line);
                __tmp261_outputWritten = true;
            }
            if (__tmp261_outputWritten) __out.AppendLine(true);
            if (__tmp261_outputWritten)
            {
                __out.AppendLine(false); //526:71
            }
            bool __tmp266_outputWritten = false;
            string __tmp267_line = "        public "; //528:1
            if (!string.IsNullOrEmpty(__tmp267_line))
            {
                __out.Append(__tmp267_line);
                __tmp266_outputWritten = true;
            }
            StringBuilder __tmp268 = new StringBuilder();
            __tmp268.Append(Properties.LanguageClassName);
            using(StreamReader __tmp268Reader = new StreamReader(this.__ToStream(__tmp268.ToString())))
            {
                bool __tmp268_last = __tmp268Reader.EndOfStream;
                while(!__tmp268_last)
                {
                    string __tmp268_line = __tmp268Reader.ReadLine();
                    __tmp268_last = __tmp268Reader.EndOfStream;
                    if ((__tmp268_last && !string.IsNullOrEmpty(__tmp268_line)) || (!__tmp268_last && __tmp268_line != null))
                    {
                        __out.Append(__tmp268_line);
                        __tmp266_outputWritten = true;
                    }
                    if (!__tmp268_last) __out.AppendLine(true);
                }
            }
            string __tmp269_line = "LanguageService()"; //528:46
            if (!string.IsNullOrEmpty(__tmp269_line))
            {
                __out.Append(__tmp269_line);
                __tmp266_outputWritten = true;
            }
            if (__tmp266_outputWritten) __out.AppendLine(true);
            if (__tmp266_outputWritten)
            {
                __out.AppendLine(false); //528:63
            }
            __out.Append("        {"); //529:1
            __out.AppendLine(false); //529:10
            __out.Append("			// Creating the config instance"); //530:1
            __out.AppendLine(false); //530:35
            bool __tmp271_outputWritten = false;
            string __tmp270Prefix = "			"; //531:1
            StringBuilder __tmp272 = new StringBuilder();
            __tmp272.Append(Properties.LanguageClassName);
            using(StreamReader __tmp272Reader = new StreamReader(this.__ToStream(__tmp272.ToString())))
            {
                bool __tmp272_last = __tmp272Reader.EndOfStream;
                while(!__tmp272_last)
                {
                    string __tmp272_line = __tmp272Reader.ReadLine();
                    __tmp272_last = __tmp272Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp270Prefix))
                    {
                        __out.Append(__tmp270Prefix);
                        __tmp271_outputWritten = true;
                    }
                    if ((__tmp272_last && !string.IsNullOrEmpty(__tmp272_line)) || (!__tmp272_last && __tmp272_line != null))
                    {
                        __out.Append(__tmp272_line);
                        __tmp271_outputWritten = true;
                    }
                    if (!__tmp272_last) __out.AppendLine(true);
                }
            }
            string __tmp273_line = "LanguageConfigBase.Instance.ToString();"; //531:34
            if (!string.IsNullOrEmpty(__tmp273_line))
            {
                __out.Append(__tmp273_line);
                __tmp271_outputWritten = true;
            }
            if (__tmp271_outputWritten) __out.AppendLine(true);
            if (__tmp271_outputWritten)
            {
                __out.AppendLine(false); //531:73
            }
            __out.Append("        }"); //532:1
            __out.AppendLine(false); //532:10
            __out.Append("        public override string GetFormatFilterList()"); //534:1
            __out.AppendLine(false); //534:53
            __out.Append("        {"); //535:1
            __out.AppendLine(false); //535:10
            bool __tmp275_outputWritten = false;
            string __tmp276_line = "            return "; //536:1
            if (!string.IsNullOrEmpty(__tmp276_line))
            {
                __out.Append(__tmp276_line);
                __tmp275_outputWritten = true;
            }
            StringBuilder __tmp277 = new StringBuilder();
            __tmp277.Append(Properties.LanguageClassName);
            using(StreamReader __tmp277Reader = new StreamReader(this.__ToStream(__tmp277.ToString())))
            {
                bool __tmp277_last = __tmp277Reader.EndOfStream;
                while(!__tmp277_last)
                {
                    string __tmp277_line = __tmp277Reader.ReadLine();
                    __tmp277_last = __tmp277Reader.EndOfStream;
                    if ((__tmp277_last && !string.IsNullOrEmpty(__tmp277_line)) || (!__tmp277_last && __tmp277_line != null))
                    {
                        __out.Append(__tmp277_line);
                        __tmp275_outputWritten = true;
                    }
                    if (!__tmp277_last) __out.AppendLine(true);
                }
            }
            string __tmp278_line = "LanguageConfig.FilterList;"; //536:50
            if (!string.IsNullOrEmpty(__tmp278_line))
            {
                __out.Append(__tmp278_line);
                __tmp275_outputWritten = true;
            }
            if (__tmp275_outputWritten) __out.AppendLine(true);
            if (__tmp275_outputWritten)
            {
                __out.AppendLine(false); //536:76
            }
            __out.Append("        }"); //537:1
            __out.AppendLine(false); //537:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //539:1
            __out.AppendLine(false); //539:69
            __out.Append("        {"); //540:1
            __out.AppendLine(false); //540:10
            __out.Append("            if (preferences == null)"); //541:1
            __out.AppendLine(false); //541:37
            __out.Append("            {"); //542:1
            __out.AppendLine(false); //542:14
            bool __tmp280_outputWritten = false;
            string __tmp281_line = "                preferences = new LanguagePreferences(this.Site, typeof("; //543:1
            if (!string.IsNullOrEmpty(__tmp281_line))
            {
                __out.Append(__tmp281_line);
                __tmp280_outputWritten = true;
            }
            StringBuilder __tmp282 = new StringBuilder();
            __tmp282.Append(Properties.LanguageClassName);
            using(StreamReader __tmp282Reader = new StreamReader(this.__ToStream(__tmp282.ToString())))
            {
                bool __tmp282_last = __tmp282Reader.EndOfStream;
                while(!__tmp282_last)
                {
                    string __tmp282_line = __tmp282Reader.ReadLine();
                    __tmp282_last = __tmp282Reader.EndOfStream;
                    if ((__tmp282_last && !string.IsNullOrEmpty(__tmp282_line)) || (!__tmp282_last && __tmp282_line != null))
                    {
                        __out.Append(__tmp282_line);
                        __tmp280_outputWritten = true;
                    }
                    if (!__tmp282_last) __out.AppendLine(true);
                }
            }
            string __tmp283_line = "LanguageService).GUID, this.Name);"; //543:103
            if (!string.IsNullOrEmpty(__tmp283_line))
            {
                __out.Append(__tmp283_line);
                __tmp280_outputWritten = true;
            }
            if (__tmp280_outputWritten) __out.AppendLine(true);
            if (__tmp280_outputWritten)
            {
                __out.AppendLine(false); //543:137
            }
            __out.Append("                preferences.Init();"); //544:1
            __out.AppendLine(false); //544:36
            __out.Append("            }"); //545:1
            __out.AppendLine(false); //545:14
            __out.Append("            return preferences;"); //546:1
            __out.AppendLine(false); //546:32
            __out.Append("        }"); //547:1
            __out.AppendLine(false); //547:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //549:1
            __out.AppendLine(false); //549:65
            __out.Append("        {"); //550:1
            __out.AppendLine(false); //550:10
            __out.Append("            if (scanner == null)"); //551:1
            __out.AppendLine(false); //551:33
            __out.Append("            {"); //552:1
            __out.AppendLine(false); //552:14
            bool __tmp285_outputWritten = false;
            string __tmp286_line = "                scanner = new "; //553:1
            if (!string.IsNullOrEmpty(__tmp286_line))
            {
                __out.Append(__tmp286_line);
                __tmp285_outputWritten = true;
            }
            StringBuilder __tmp287 = new StringBuilder();
            __tmp287.Append(Properties.LanguageClassName);
            using(StreamReader __tmp287Reader = new StreamReader(this.__ToStream(__tmp287.ToString())))
            {
                bool __tmp287_last = __tmp287Reader.EndOfStream;
                while(!__tmp287_last)
                {
                    string __tmp287_line = __tmp287Reader.ReadLine();
                    __tmp287_last = __tmp287Reader.EndOfStream;
                    if ((__tmp287_last && !string.IsNullOrEmpty(__tmp287_line)) || (!__tmp287_last && __tmp287_line != null))
                    {
                        __out.Append(__tmp287_line);
                        __tmp285_outputWritten = true;
                    }
                    if (!__tmp287_last) __out.AppendLine(true);
                }
            }
            string __tmp288_line = "LanguageScanner();"; //553:61
            if (!string.IsNullOrEmpty(__tmp288_line))
            {
                __out.Append(__tmp288_line);
                __tmp285_outputWritten = true;
            }
            if (__tmp285_outputWritten) __out.AppendLine(true);
            if (__tmp285_outputWritten)
            {
                __out.AppendLine(false); //553:79
            }
            __out.Append("            }"); //554:1
            __out.AppendLine(false); //554:14
            __out.Append("            return scanner;"); //555:1
            __out.AppendLine(false); //555:28
            __out.Append("        }"); //556:1
            __out.AppendLine(false); //556:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //558:1
            __out.AppendLine(false); //558:96
            __out.Append("        {"); //559:1
            __out.AppendLine(false); //559:10
            bool __tmp290_outputWritten = false;
            string __tmp291_line = "            return new "; //560:1
            if (!string.IsNullOrEmpty(__tmp291_line))
            {
                __out.Append(__tmp291_line);
                __tmp290_outputWritten = true;
            }
            StringBuilder __tmp292 = new StringBuilder();
            __tmp292.Append(Properties.LanguageClassName);
            using(StreamReader __tmp292Reader = new StreamReader(this.__ToStream(__tmp292.ToString())))
            {
                bool __tmp292_last = __tmp292Reader.EndOfStream;
                while(!__tmp292_last)
                {
                    string __tmp292_line = __tmp292Reader.ReadLine();
                    __tmp292_last = __tmp292Reader.EndOfStream;
                    if ((__tmp292_last && !string.IsNullOrEmpty(__tmp292_line)) || (!__tmp292_last && __tmp292_line != null))
                    {
                        __out.Append(__tmp292_line);
                        __tmp290_outputWritten = true;
                    }
                    if (!__tmp292_last) __out.AppendLine(true);
                }
            }
            string __tmp293_line = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //560:54
            if (!string.IsNullOrEmpty(__tmp293_line))
            {
                __out.Append(__tmp293_line);
                __tmp290_outputWritten = true;
            }
            if (__tmp290_outputWritten) __out.AppendLine(true);
            if (__tmp290_outputWritten)
            {
                __out.AppendLine(false); //560:110
            }
            __out.Append("        }"); //561:1
            __out.AppendLine(false); //561:10
            __out.Append("        #region Custom Colors"); //563:1
            __out.AppendLine(false); //563:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //564:1
            __out.AppendLine(false); //564:83
            __out.Append("        {"); //565:1
            __out.AppendLine(false); //565:10
            bool __tmp295_outputWritten = false;
            string __tmp296_line = "            if (index >= 1 && index <= "; //566:1
            if (!string.IsNullOrEmpty(__tmp296_line))
            {
                __out.Append(__tmp296_line);
                __tmp295_outputWritten = true;
            }
            StringBuilder __tmp297 = new StringBuilder();
            __tmp297.Append(Properties.LanguageClassName);
            using(StreamReader __tmp297Reader = new StreamReader(this.__ToStream(__tmp297.ToString())))
            {
                bool __tmp297_last = __tmp297Reader.EndOfStream;
                while(!__tmp297_last)
                {
                    string __tmp297_line = __tmp297Reader.ReadLine();
                    __tmp297_last = __tmp297Reader.EndOfStream;
                    if ((__tmp297_last && !string.IsNullOrEmpty(__tmp297_line)) || (!__tmp297_last && __tmp297_line != null))
                    {
                        __out.Append(__tmp297_line);
                        __tmp295_outputWritten = true;
                    }
                    if (!__tmp297_last) __out.AppendLine(true);
                }
            }
            string __tmp298_line = "LanguageConfig.Instance.ColorableItems.Count)"; //566:70
            if (!string.IsNullOrEmpty(__tmp298_line))
            {
                __out.Append(__tmp298_line);
                __tmp295_outputWritten = true;
            }
            if (__tmp295_outputWritten) __out.AppendLine(true);
            if (__tmp295_outputWritten)
            {
                __out.AppendLine(false); //566:115
            }
            __out.Append("            {"); //567:1
            __out.AppendLine(false); //567:14
            bool __tmp300_outputWritten = false;
            string __tmp301_line = "                item = "; //568:1
            if (!string.IsNullOrEmpty(__tmp301_line))
            {
                __out.Append(__tmp301_line);
                __tmp300_outputWritten = true;
            }
            StringBuilder __tmp302 = new StringBuilder();
            __tmp302.Append(Properties.LanguageClassName);
            using(StreamReader __tmp302Reader = new StreamReader(this.__ToStream(__tmp302.ToString())))
            {
                bool __tmp302_last = __tmp302Reader.EndOfStream;
                while(!__tmp302_last)
                {
                    string __tmp302_line = __tmp302Reader.ReadLine();
                    __tmp302_last = __tmp302Reader.EndOfStream;
                    if ((__tmp302_last && !string.IsNullOrEmpty(__tmp302_line)) || (!__tmp302_last && __tmp302_line != null))
                    {
                        __out.Append(__tmp302_line);
                        __tmp300_outputWritten = true;
                    }
                    if (!__tmp302_last) __out.AppendLine(true);
                }
            }
            string __tmp303_line = "LanguageConfig.Instance.ColorableItems"; //568:54
            if (!string.IsNullOrEmpty(__tmp303_line))
            {
                __out.Append(__tmp303_line);
                __tmp300_outputWritten = true;
            }
            StringBuilder __tmp304 = new StringBuilder();
            __tmp304.Append("[index - 1]");
            using(StreamReader __tmp304Reader = new StreamReader(this.__ToStream(__tmp304.ToString())))
            {
                bool __tmp304_last = __tmp304Reader.EndOfStream;
                while(!__tmp304_last)
                {
                    string __tmp304_line = __tmp304Reader.ReadLine();
                    __tmp304_last = __tmp304Reader.EndOfStream;
                    if ((__tmp304_last && !string.IsNullOrEmpty(__tmp304_line)) || (!__tmp304_last && __tmp304_line != null))
                    {
                        __out.Append(__tmp304_line);
                        __tmp300_outputWritten = true;
                    }
                    if (!__tmp304_last) __out.AppendLine(true);
                }
            }
            string __tmp305_line = ";"; //568:107
            if (!string.IsNullOrEmpty(__tmp305_line))
            {
                __out.Append(__tmp305_line);
                __tmp300_outputWritten = true;
            }
            if (__tmp300_outputWritten) __out.AppendLine(true);
            if (__tmp300_outputWritten)
            {
                __out.AppendLine(false); //568:108
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //569:1
            __out.AppendLine(false); //569:64
            __out.Append("            }"); //570:1
            __out.AppendLine(false); //570:14
            __out.Append("            else"); //571:1
            __out.AppendLine(false); //571:17
            __out.Append("            {"); //572:1
            __out.AppendLine(false); //572:14
            bool __tmp307_outputWritten = false;
            string __tmp308_line = "                item = "; //573:1
            if (!string.IsNullOrEmpty(__tmp308_line))
            {
                __out.Append(__tmp308_line);
                __tmp307_outputWritten = true;
            }
            StringBuilder __tmp309 = new StringBuilder();
            __tmp309.Append(Properties.LanguageClassName);
            using(StreamReader __tmp309Reader = new StreamReader(this.__ToStream(__tmp309.ToString())))
            {
                bool __tmp309_last = __tmp309Reader.EndOfStream;
                while(!__tmp309_last)
                {
                    string __tmp309_line = __tmp309Reader.ReadLine();
                    __tmp309_last = __tmp309Reader.EndOfStream;
                    if ((__tmp309_last && !string.IsNullOrEmpty(__tmp309_line)) || (!__tmp309_last && __tmp309_line != null))
                    {
                        __out.Append(__tmp309_line);
                        __tmp307_outputWritten = true;
                    }
                    if (!__tmp309_last) __out.AppendLine(true);
                }
            }
            string __tmp310_line = "LanguageConfig.Instance.ColorableItems"; //573:54
            if (!string.IsNullOrEmpty(__tmp310_line))
            {
                __out.Append(__tmp310_line);
                __tmp307_outputWritten = true;
            }
            StringBuilder __tmp311 = new StringBuilder();
            __tmp311.Append("[0]");
            using(StreamReader __tmp311Reader = new StreamReader(this.__ToStream(__tmp311.ToString())))
            {
                bool __tmp311_last = __tmp311Reader.EndOfStream;
                while(!__tmp311_last)
                {
                    string __tmp311_line = __tmp311Reader.ReadLine();
                    __tmp311_last = __tmp311Reader.EndOfStream;
                    if ((__tmp311_last && !string.IsNullOrEmpty(__tmp311_line)) || (!__tmp311_last && __tmp311_line != null))
                    {
                        __out.Append(__tmp311_line);
                        __tmp307_outputWritten = true;
                    }
                    if (!__tmp311_last) __out.AppendLine(true);
                }
            }
            string __tmp312_line = ";"; //573:99
            if (!string.IsNullOrEmpty(__tmp312_line))
            {
                __out.Append(__tmp312_line);
                __tmp307_outputWritten = true;
            }
            if (__tmp307_outputWritten) __out.AppendLine(true);
            if (__tmp307_outputWritten)
            {
                __out.AppendLine(false); //573:100
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //574:1
            __out.AppendLine(false); //574:64
            __out.Append("            }"); //575:1
            __out.AppendLine(false); //575:14
            __out.Append("        }"); //576:1
            __out.AppendLine(false); //576:10
            __out.Append("        public override int GetItemCount(out int count)"); //578:1
            __out.AppendLine(false); //578:56
            __out.Append("        {"); //579:1
            __out.AppendLine(false); //579:10
            bool __tmp314_outputWritten = false;
            string __tmp315_line = "            count = "; //580:1
            if (!string.IsNullOrEmpty(__tmp315_line))
            {
                __out.Append(__tmp315_line);
                __tmp314_outputWritten = true;
            }
            StringBuilder __tmp316 = new StringBuilder();
            __tmp316.Append(Properties.LanguageClassName);
            using(StreamReader __tmp316Reader = new StreamReader(this.__ToStream(__tmp316.ToString())))
            {
                bool __tmp316_last = __tmp316Reader.EndOfStream;
                while(!__tmp316_last)
                {
                    string __tmp316_line = __tmp316Reader.ReadLine();
                    __tmp316_last = __tmp316Reader.EndOfStream;
                    if ((__tmp316_last && !string.IsNullOrEmpty(__tmp316_line)) || (!__tmp316_last && __tmp316_line != null))
                    {
                        __out.Append(__tmp316_line);
                        __tmp314_outputWritten = true;
                    }
                    if (!__tmp316_last) __out.AppendLine(true);
                }
            }
            string __tmp317_line = "LanguageConfig.Instance.ColorableItems.Count;"; //580:51
            if (!string.IsNullOrEmpty(__tmp317_line))
            {
                __out.Append(__tmp317_line);
                __tmp314_outputWritten = true;
            }
            if (__tmp314_outputWritten) __out.AppendLine(true);
            if (__tmp314_outputWritten)
            {
                __out.AppendLine(false); //580:96
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //581:1
            __out.AppendLine(false); //581:60
            __out.Append("        }"); //582:1
            __out.AppendLine(false); //582:10
            __out.Append("        #endregion"); //583:1
            __out.AppendLine(false); //583:19
            __out.Append("        public override void OnIdle(bool periodic)"); //585:1
            __out.AppendLine(false); //585:51
            __out.Append("        {"); //586:1
            __out.AppendLine(false); //586:10
            __out.Append("            // from IronPythonLanguage sample"); //587:1
            __out.AppendLine(false); //587:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //588:1
            __out.AppendLine(false); //588:93
            bool __tmp319_outputWritten = false;
            string __tmp318Prefix = "            "; //589:1
            StringBuilder __tmp320 = new StringBuilder();
            __tmp320.Append(Properties.LanguageClassName);
            using(StreamReader __tmp320Reader = new StreamReader(this.__ToStream(__tmp320.ToString())))
            {
                bool __tmp320_last = __tmp320Reader.EndOfStream;
                while(!__tmp320_last)
                {
                    string __tmp320_line = __tmp320Reader.ReadLine();
                    __tmp320_last = __tmp320Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp318Prefix))
                    {
                        __out.Append(__tmp318Prefix);
                        __tmp319_outputWritten = true;
                    }
                    if ((__tmp320_last && !string.IsNullOrEmpty(__tmp320_line)) || (!__tmp320_last && __tmp320_line != null))
                    {
                        __out.Append(__tmp320_line);
                        __tmp319_outputWritten = true;
                    }
                    if (!__tmp320_last) __out.AppendLine(true);
                }
            }
            string __tmp321_line = "LanguageSource src = ("; //589:43
            if (!string.IsNullOrEmpty(__tmp321_line))
            {
                __out.Append(__tmp321_line);
                __tmp319_outputWritten = true;
            }
            StringBuilder __tmp322 = new StringBuilder();
            __tmp322.Append(Properties.LanguageClassName);
            using(StreamReader __tmp322Reader = new StreamReader(this.__ToStream(__tmp322.ToString())))
            {
                bool __tmp322_last = __tmp322Reader.EndOfStream;
                while(!__tmp322_last)
                {
                    string __tmp322_line = __tmp322Reader.ReadLine();
                    __tmp322_last = __tmp322Reader.EndOfStream;
                    if ((__tmp322_last && !string.IsNullOrEmpty(__tmp322_line)) || (!__tmp322_last && __tmp322_line != null))
                    {
                        __out.Append(__tmp322_line);
                        __tmp319_outputWritten = true;
                    }
                    if (!__tmp322_last) __out.AppendLine(true);
                }
            }
            string __tmp323_line = "LanguageSource)GetSource(this.LastActiveTextView);"; //589:95
            if (!string.IsNullOrEmpty(__tmp323_line))
            {
                __out.Append(__tmp323_line);
                __tmp319_outputWritten = true;
            }
            if (__tmp319_outputWritten) __out.AppendLine(true);
            if (__tmp319_outputWritten)
            {
                __out.AppendLine(false); //589:145
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //590:1
            __out.AppendLine(false); //590:74
            __out.Append("            {"); //591:1
            __out.AppendLine(false); //591:14
            __out.Append("                src.LastParseTime = 0;"); //592:1
            __out.AppendLine(false); //592:39
            __out.Append("            }"); //593:1
            __out.AppendLine(false); //593:14
            __out.Append("            base.OnIdle(periodic);"); //594:1
            __out.AppendLine(false); //594:35
            __out.Append("        }"); //595:1
            __out.AppendLine(false); //595:10
            __out.Append("        public override string Name"); //597:1
            __out.AppendLine(false); //597:36
            __out.Append("        {"); //598:1
            __out.AppendLine(false); //598:10
            bool __tmp325_outputWritten = false;
            string __tmp326_line = "            get { return "; //599:1
            if (!string.IsNullOrEmpty(__tmp326_line))
            {
                __out.Append(__tmp326_line);
                __tmp325_outputWritten = true;
            }
            StringBuilder __tmp327 = new StringBuilder();
            __tmp327.Append(Properties.LanguageClassName);
            using(StreamReader __tmp327Reader = new StreamReader(this.__ToStream(__tmp327.ToString())))
            {
                bool __tmp327_last = __tmp327Reader.EndOfStream;
                while(!__tmp327_last)
                {
                    string __tmp327_line = __tmp327Reader.ReadLine();
                    __tmp327_last = __tmp327Reader.EndOfStream;
                    if ((__tmp327_last && !string.IsNullOrEmpty(__tmp327_line)) || (!__tmp327_last && __tmp327_line != null))
                    {
                        __out.Append(__tmp327_line);
                        __tmp325_outputWritten = true;
                    }
                    if (!__tmp327_last) __out.AppendLine(true);
                }
            }
            string __tmp328_line = "LanguageConfig.LanguageName; }"; //599:56
            if (!string.IsNullOrEmpty(__tmp328_line))
            {
                __out.Append(__tmp328_line);
                __tmp325_outputWritten = true;
            }
            if (__tmp325_outputWritten) __out.AppendLine(true);
            if (__tmp325_outputWritten)
            {
                __out.AppendLine(false); //599:86
            }
            __out.Append("        }"); //600:1
            __out.AppendLine(false); //600:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //602:1
            __out.AppendLine(false); //602:96
            __out.Append("        {"); //603:1
            __out.AppendLine(false); //603:10
            bool __tmp330_outputWritten = false;
            string __tmp331_line = "            return new "; //604:1
            if (!string.IsNullOrEmpty(__tmp331_line))
            {
                __out.Append(__tmp331_line);
                __tmp330_outputWritten = true;
            }
            StringBuilder __tmp332 = new StringBuilder();
            __tmp332.Append(Properties.LanguageClassName);
            using(StreamReader __tmp332Reader = new StreamReader(this.__ToStream(__tmp332.ToString())))
            {
                bool __tmp332_last = __tmp332Reader.EndOfStream;
                while(!__tmp332_last)
                {
                    string __tmp332_line = __tmp332Reader.ReadLine();
                    __tmp332_last = __tmp332Reader.EndOfStream;
                    if ((__tmp332_last && !string.IsNullOrEmpty(__tmp332_line)) || (!__tmp332_last && __tmp332_line != null))
                    {
                        __out.Append(__tmp332_line);
                        __tmp330_outputWritten = true;
                    }
                    if (!__tmp332_last) __out.AppendLine(true);
                }
            }
            string __tmp333_line = "LanguageViewFilter(mgr, newView);"; //604:54
            if (!string.IsNullOrEmpty(__tmp333_line))
            {
                __out.Append(__tmp333_line);
                __tmp330_outputWritten = true;
            }
            if (__tmp330_outputWritten) __out.AppendLine(true);
            if (__tmp330_outputWritten)
            {
                __out.AppendLine(false); //604:87
            }
            __out.Append("        }"); //605:1
            __out.AppendLine(false); //605:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //607:1
            __out.AppendLine(false); //607:68
            __out.Append("        {"); //608:1
            __out.AppendLine(false); //608:10
            bool __tmp335_outputWritten = false;
            string __tmp336_line = "            return new "; //609:1
            if (!string.IsNullOrEmpty(__tmp336_line))
            {
                __out.Append(__tmp336_line);
                __tmp335_outputWritten = true;
            }
            StringBuilder __tmp337 = new StringBuilder();
            __tmp337.Append(Properties.LanguageClassName);
            using(StreamReader __tmp337Reader = new StreamReader(this.__ToStream(__tmp337.ToString())))
            {
                bool __tmp337_last = __tmp337Reader.EndOfStream;
                while(!__tmp337_last)
                {
                    string __tmp337_line = __tmp337Reader.ReadLine();
                    __tmp337_last = __tmp337Reader.EndOfStream;
                    if ((__tmp337_last && !string.IsNullOrEmpty(__tmp337_line)) || (!__tmp337_last && __tmp337_line != null))
                    {
                        __out.Append(__tmp337_line);
                        __tmp335_outputWritten = true;
                    }
                    if (!__tmp337_last) __out.AppendLine(true);
                }
            }
            string __tmp338_line = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //609:54
            if (!string.IsNullOrEmpty(__tmp338_line))
            {
                __out.Append(__tmp338_line);
                __tmp335_outputWritten = true;
            }
            if (__tmp335_outputWritten) __out.AppendLine(true);
            if (__tmp335_outputWritten)
            {
                __out.AppendLine(false); //609:111
            }
            __out.Append("        }"); //610:1
            __out.AppendLine(false); //610:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //612:1
            __out.AppendLine(false); //612:69
            __out.Append("        {"); //613:1
            __out.AppendLine(false); //613:10
            bool __tmp340_outputWritten = false;
            string __tmp339Prefix = "            "; //614:1
            StringBuilder __tmp341 = new StringBuilder();
            __tmp341.Append(Properties.LanguageClassName);
            using(StreamReader __tmp341Reader = new StreamReader(this.__ToStream(__tmp341.ToString())))
            {
                bool __tmp341_last = __tmp341Reader.EndOfStream;
                while(!__tmp341_last)
                {
                    string __tmp341_line = __tmp341Reader.ReadLine();
                    __tmp341_last = __tmp341Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp339Prefix))
                    {
                        __out.Append(__tmp339Prefix);
                        __tmp340_outputWritten = true;
                    }
                    if ((__tmp341_last && !string.IsNullOrEmpty(__tmp341_line)) || (!__tmp341_last && __tmp341_line != null))
                    {
                        __out.Append(__tmp341_line);
                        __tmp340_outputWritten = true;
                    }
                    if (!__tmp341_last) __out.AppendLine(true);
                }
            }
            string __tmp342_line = "LanguageSource source = ("; //614:43
            if (!string.IsNullOrEmpty(__tmp342_line))
            {
                __out.Append(__tmp342_line);
                __tmp340_outputWritten = true;
            }
            StringBuilder __tmp343 = new StringBuilder();
            __tmp343.Append(Properties.LanguageClassName);
            using(StreamReader __tmp343Reader = new StreamReader(this.__ToStream(__tmp343.ToString())))
            {
                bool __tmp343_last = __tmp343Reader.EndOfStream;
                while(!__tmp343_last)
                {
                    string __tmp343_line = __tmp343Reader.ReadLine();
                    __tmp343_last = __tmp343Reader.EndOfStream;
                    if ((__tmp343_last && !string.IsNullOrEmpty(__tmp343_line)) || (!__tmp343_last && __tmp343_line != null))
                    {
                        __out.Append(__tmp343_line);
                        __tmp340_outputWritten = true;
                    }
                    if (!__tmp343_last) __out.AppendLine(true);
                }
            }
            string __tmp344_line = "LanguageSource)this.GetSource(req.FileName);"; //614:98
            if (!string.IsNullOrEmpty(__tmp344_line))
            {
                __out.Append(__tmp344_line);
                __tmp340_outputWritten = true;
            }
            if (__tmp340_outputWritten) __out.AppendLine(true);
            if (__tmp340_outputWritten)
            {
                __out.AppendLine(false); //614:142
            }
            __out.Append("            switch (req.Reason)"); //615:1
            __out.AppendLine(false); //615:32
            __out.Append("            {"); //616:1
            __out.AppendLine(false); //616:14
            __out.Append("                case ParseReason.Check:"); //617:1
            __out.AppendLine(false); //617:40
            __out.Append("                    // This is where you perform your syntax highlighting."); //618:1
            __out.AppendLine(false); //618:75
            __out.Append("                    // Parse entire source as given in req.Text."); //619:1
            __out.AppendLine(false); //619:65
            __out.Append("                    // Store results in the AuthoringScope object."); //620:1
            __out.AppendLine(false); //620:67
            __out.Append("                    string fileName = Path.GetFileName(req.FileName);"); //621:1
            __out.AppendLine(false); //621:70
            __out.Append("                    string outputDir = Path.GetDirectoryName(req.FileName);"); //622:1
            __out.AppendLine(false); //622:76
            bool __tmp346_outputWritten = false;
            string __tmp345Prefix = "                    "; //623:1
            StringBuilder __tmp347 = new StringBuilder();
            __tmp347.Append(Properties.LanguageClassName);
            using(StreamReader __tmp347Reader = new StreamReader(this.__ToStream(__tmp347.ToString())))
            {
                bool __tmp347_last = __tmp347Reader.EndOfStream;
                while(!__tmp347_last)
                {
                    string __tmp347_line = __tmp347Reader.ReadLine();
                    __tmp347_last = __tmp347Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp345Prefix))
                    {
                        __out.Append(__tmp345Prefix);
                        __tmp346_outputWritten = true;
                    }
                    if ((__tmp347_last && !string.IsNullOrEmpty(__tmp347_line)) || (!__tmp347_last && __tmp347_line != null))
                    {
                        __out.Append(__tmp347_line);
                        __tmp346_outputWritten = true;
                    }
                    if (!__tmp347_last) __out.AppendLine(true);
                }
            }
            string __tmp348_line = "Compiler compiler = new "; //623:51
            if (!string.IsNullOrEmpty(__tmp348_line))
            {
                __out.Append(__tmp348_line);
                __tmp346_outputWritten = true;
            }
            StringBuilder __tmp349 = new StringBuilder();
            __tmp349.Append(Properties.LanguageClassName);
            using(StreamReader __tmp349Reader = new StreamReader(this.__ToStream(__tmp349.ToString())))
            {
                bool __tmp349_last = __tmp349Reader.EndOfStream;
                while(!__tmp349_last)
                {
                    string __tmp349_line = __tmp349Reader.ReadLine();
                    __tmp349_last = __tmp349Reader.EndOfStream;
                    if ((__tmp349_last && !string.IsNullOrEmpty(__tmp349_line)) || (!__tmp349_last && __tmp349_line != null))
                    {
                        __out.Append(__tmp349_line);
                        __tmp346_outputWritten = true;
                    }
                    if (!__tmp349_last) __out.AppendLine(true);
                }
            }
            string __tmp350_line = "Compiler(req.Text, fileName);"; //623:105
            if (!string.IsNullOrEmpty(__tmp350_line))
            {
                __out.Append(__tmp350_line);
                __tmp346_outputWritten = true;
            }
            if (__tmp346_outputWritten) __out.AppendLine(true);
            if (__tmp346_outputWritten)
            {
                __out.AppendLine(false); //623:134
            }
            __out.Append("                    compiler.Compile();"); //624:1
            __out.AppendLine(false); //624:40
            __out.Append("                    foreach (var msg in compiler.Diagnostics.GetMessages())"); //625:1
            __out.AppendLine(false); //625:76
            __out.Append("                    {"); //626:1
            __out.AppendLine(false); //626:22
            __out.Append("                        TextSpan span = new TextSpan();"); //627:1
            __out.AppendLine(false); //627:56
            __out.Append("                        span.iStartLine = msg.TextSpan.StartLine - 1;"); //628:1
            __out.AppendLine(false); //628:70
            __out.Append("                        span.iEndLine = msg.TextSpan.EndLine - 1;"); //629:1
            __out.AppendLine(false); //629:66
            __out.Append("                        span.iStartIndex = msg.TextSpan.StartPosition - 1;"); //630:1
            __out.AppendLine(false); //630:75
            __out.Append("                        span.iEndIndex = msg.TextSpan.EndPosition - 1;"); //631:1
            __out.AppendLine(false); //631:71
            __out.Append("                        Severity severity = Severity.Error;"); //632:1
            __out.AppendLine(false); //632:60
            __out.Append("                        switch (msg.Severity)"); //633:1
            __out.AppendLine(false); //633:46
            __out.Append("                        {"); //634:1
            __out.AppendLine(false); //634:26
            __out.Append("                            case MetaDslx.Core.Immutable.Severity.Error:"); //635:1
            __out.AppendLine(false); //635:73
            __out.Append("                                severity = Severity.Error;"); //636:1
            __out.AppendLine(false); //636:59
            __out.Append("                                break;"); //637:1
            __out.AppendLine(false); //637:39
            __out.Append("                            case MetaDslx.Core.Immutable.Severity.Warning:"); //638:1
            __out.AppendLine(false); //638:75
            __out.Append("                                severity = Severity.Warning;"); //639:1
            __out.AppendLine(false); //639:61
            __out.Append("                                break;"); //640:1
            __out.AppendLine(false); //640:39
            __out.Append("                            case MetaDslx.Core.Immutable.Severity.Info:"); //641:1
            __out.AppendLine(false); //641:72
            __out.Append("                                severity = Severity.Hint;"); //642:1
            __out.AppendLine(false); //642:58
            __out.Append("                                break;"); //643:1
            __out.AppendLine(false); //643:39
            __out.Append("                        }"); //644:1
            __out.AppendLine(false); //644:26
            __out.Append("                        req.Sink.AddError(req.FileName, msg.Message, span, severity);"); //645:1
            __out.AppendLine(false); //645:86
            __out.Append("                    }"); //646:1
            __out.AppendLine(false); //646:22
            __out.Append("                    break;"); //647:1
            __out.AppendLine(false); //647:27
            __out.Append("            }"); //648:1
            __out.AppendLine(false); //648:14
            bool __tmp352_outputWritten = false;
            string __tmp353_line = "            return new "; //649:1
            if (!string.IsNullOrEmpty(__tmp353_line))
            {
                __out.Append(__tmp353_line);
                __tmp352_outputWritten = true;
            }
            StringBuilder __tmp354 = new StringBuilder();
            __tmp354.Append(Properties.LanguageClassName);
            using(StreamReader __tmp354Reader = new StreamReader(this.__ToStream(__tmp354.ToString())))
            {
                bool __tmp354_last = __tmp354Reader.EndOfStream;
                while(!__tmp354_last)
                {
                    string __tmp354_line = __tmp354Reader.ReadLine();
                    __tmp354_last = __tmp354Reader.EndOfStream;
                    if ((__tmp354_last && !string.IsNullOrEmpty(__tmp354_line)) || (!__tmp354_last && __tmp354_line != null))
                    {
                        __out.Append(__tmp354_line);
                        __tmp352_outputWritten = true;
                    }
                    if (!__tmp354_last) __out.AppendLine(true);
                }
            }
            string __tmp355_line = "LanguageAuthoringScope();"; //649:54
            if (!string.IsNullOrEmpty(__tmp355_line))
            {
                __out.Append(__tmp355_line);
                __tmp352_outputWritten = true;
            }
            if (__tmp352_outputWritten) __out.AppendLine(true);
            if (__tmp352_outputWritten)
            {
                __out.AppendLine(false); //649:79
            }
            __out.Append("        }"); //650:1
            __out.AppendLine(false); //650:10
            __out.Append("    }"); //651:1
            __out.AppendLine(false); //651:6
            bool __tmp357_outputWritten = false;
            string __tmp358_line = "	public class "; //653:1
            if (!string.IsNullOrEmpty(__tmp358_line))
            {
                __out.Append(__tmp358_line);
                __tmp357_outputWritten = true;
            }
            StringBuilder __tmp359 = new StringBuilder();
            __tmp359.Append(Properties.LanguageClassName);
            using(StreamReader __tmp359Reader = new StreamReader(this.__ToStream(__tmp359.ToString())))
            {
                bool __tmp359_last = __tmp359Reader.EndOfStream;
                while(!__tmp359_last)
                {
                    string __tmp359_line = __tmp359Reader.ReadLine();
                    __tmp359_last = __tmp359Reader.EndOfStream;
                    if ((__tmp359_last && !string.IsNullOrEmpty(__tmp359_line)) || (!__tmp359_last && __tmp359_line != null))
                    {
                        __out.Append(__tmp359_line);
                        __tmp357_outputWritten = true;
                    }
                    if (!__tmp359_last) __out.AppendLine(true);
                }
            }
            string __tmp360_line = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //653:45
            if (!string.IsNullOrEmpty(__tmp360_line))
            {
                __out.Append(__tmp360_line);
                __tmp357_outputWritten = true;
            }
            if (__tmp357_outputWritten) __out.AppendLine(true);
            if (__tmp357_outputWritten)
            {
                __out.AppendLine(false); //653:99
            }
            __out.Append("    {"); //654:1
            __out.AppendLine(false); //654:6
            bool __tmp362_outputWritten = false;
            string __tmp363_line = "        public "; //655:1
            if (!string.IsNullOrEmpty(__tmp363_line))
            {
                __out.Append(__tmp363_line);
                __tmp362_outputWritten = true;
            }
            StringBuilder __tmp364 = new StringBuilder();
            __tmp364.Append(Properties.LanguageClassName);
            using(StreamReader __tmp364Reader = new StreamReader(this.__ToStream(__tmp364.ToString())))
            {
                bool __tmp364_last = __tmp364Reader.EndOfStream;
                while(!__tmp364_last)
                {
                    string __tmp364_line = __tmp364Reader.ReadLine();
                    __tmp364_last = __tmp364Reader.EndOfStream;
                    if ((__tmp364_last && !string.IsNullOrEmpty(__tmp364_line)) || (!__tmp364_last && __tmp364_line != null))
                    {
                        __out.Append(__tmp364_line);
                        __tmp362_outputWritten = true;
                    }
                    if (!__tmp364_last) __out.AppendLine(true);
                }
            }
            string __tmp365_line = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //655:46
            if (!string.IsNullOrEmpty(__tmp365_line))
            {
                __out.Append(__tmp365_line);
                __tmp362_outputWritten = true;
            }
            if (__tmp362_outputWritten) __out.AppendLine(true);
            if (__tmp362_outputWritten)
            {
                __out.AppendLine(false); //655:130
            }
            __out.Append("            : base(service, textLines, colorizer)"); //656:1
            __out.AppendLine(false); //656:50
            __out.Append("        {"); //657:1
            __out.AppendLine(false); //657:10
            __out.Append("        }"); //659:1
            __out.AppendLine(false); //659:10
            __out.Append("    }"); //660:1
            __out.AppendLine(false); //660:6
            bool __tmp367_outputWritten = false;
            string __tmp368_line = "    public class "; //662:1
            if (!string.IsNullOrEmpty(__tmp368_line))
            {
                __out.Append(__tmp368_line);
                __tmp367_outputWritten = true;
            }
            StringBuilder __tmp369 = new StringBuilder();
            __tmp369.Append(Properties.LanguageClassName);
            using(StreamReader __tmp369Reader = new StreamReader(this.__ToStream(__tmp369.ToString())))
            {
                bool __tmp369_last = __tmp369Reader.EndOfStream;
                while(!__tmp369_last)
                {
                    string __tmp369_line = __tmp369Reader.ReadLine();
                    __tmp369_last = __tmp369Reader.EndOfStream;
                    if ((__tmp369_last && !string.IsNullOrEmpty(__tmp369_line)) || (!__tmp369_last && __tmp369_line != null))
                    {
                        __out.Append(__tmp369_line);
                        __tmp367_outputWritten = true;
                    }
                    if (!__tmp369_last) __out.AppendLine(true);
                }
            }
            string __tmp370_line = "LanguageViewFilter : ViewFilter"; //662:48
            if (!string.IsNullOrEmpty(__tmp370_line))
            {
                __out.Append(__tmp370_line);
                __tmp367_outputWritten = true;
            }
            if (__tmp367_outputWritten) __out.AppendLine(true);
            if (__tmp367_outputWritten)
            {
                __out.AppendLine(false); //662:79
            }
            __out.Append("    {"); //663:1
            __out.AppendLine(false); //663:6
            bool __tmp372_outputWritten = false;
            string __tmp373_line = "        public "; //664:1
            if (!string.IsNullOrEmpty(__tmp373_line))
            {
                __out.Append(__tmp373_line);
                __tmp372_outputWritten = true;
            }
            StringBuilder __tmp374 = new StringBuilder();
            __tmp374.Append(Properties.LanguageClassName);
            using(StreamReader __tmp374Reader = new StreamReader(this.__ToStream(__tmp374.ToString())))
            {
                bool __tmp374_last = __tmp374Reader.EndOfStream;
                while(!__tmp374_last)
                {
                    string __tmp374_line = __tmp374Reader.ReadLine();
                    __tmp374_last = __tmp374Reader.EndOfStream;
                    if ((__tmp374_last && !string.IsNullOrEmpty(__tmp374_line)) || (!__tmp374_last && __tmp374_line != null))
                    {
                        __out.Append(__tmp374_line);
                        __tmp372_outputWritten = true;
                    }
                    if (!__tmp374_last) __out.AppendLine(true);
                }
            }
            string __tmp375_line = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //664:46
            if (!string.IsNullOrEmpty(__tmp375_line))
            {
                __out.Append(__tmp375_line);
                __tmp372_outputWritten = true;
            }
            if (__tmp372_outputWritten) __out.AppendLine(true);
            if (__tmp372_outputWritten)
            {
                __out.AppendLine(false); //664:105
            }
            __out.Append("            : base(mgr, view)"); //665:1
            __out.AppendLine(false); //665:30
            __out.Append("        {"); //666:1
            __out.AppendLine(false); //666:10
            __out.Append("        }"); //668:1
            __out.AppendLine(false); //668:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //670:1
            __out.AppendLine(false); //670:150
            __out.Append("        {"); //671:1
            __out.AppendLine(false); //671:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //672:1
            __out.AppendLine(false); //672:59
            __out.Append("            {"); //673:1
            __out.AppendLine(false); //673:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //674:1
            __out.AppendLine(false); //674:57
            __out.Append("                switch (cmd)"); //675:1
            __out.AppendLine(false); //675:29
            __out.Append("                {"); //676:1
            __out.AppendLine(false); //676:18
            __out.Append("                    case VsCommands2K.UP:"); //677:1
            __out.AppendLine(false); //677:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //678:1
            __out.AppendLine(false); //678:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //679:1
            __out.AppendLine(false); //679:50
            __out.Append("                    case VsCommands2K.DOWN:"); //680:1
            __out.AppendLine(false); //680:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //681:1
            __out.AppendLine(false); //681:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //682:1
            __out.AppendLine(false); //682:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //683:1
            __out.Append("\\"); //683:58
            __out.Append("0');"); //683:59
            __out.AppendLine(false); //683:63
            __out.Append("                        return;"); //684:1
            __out.AppendLine(false); //684:32
            __out.Append("                }"); //685:1
            __out.AppendLine(false); //685:18
            __out.Append("            }"); //686:1
            __out.AppendLine(false); //686:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //687:1
            __out.AppendLine(false); //687:105
            __out.Append("        }"); //688:1
            __out.AppendLine(false); //688:10
            __out.Append("    }"); //689:1
            __out.AppendLine(false); //689:6
            __out.Append("}"); //691:1
            __out.AppendLine(false); //691:2
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
