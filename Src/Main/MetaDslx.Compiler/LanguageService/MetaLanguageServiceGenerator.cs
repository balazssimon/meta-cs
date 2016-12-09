using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler //1:1
{
    using __Hidden_MetaLanguageServiceGenerator_1487572713;
    namespace __Hidden_MetaLanguageServiceGenerator_1487572713
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
            __out.Append("using System.Drawing;"); //26:1
            __out.AppendLine(false); //26:22
            __out.Append("using Microsoft.VisualStudio;"); //27:1
            __out.AppendLine(false); //27:30
            __out.Append("using Microsoft.VisualStudio.Shell;"); //28:1
            __out.AppendLine(false); //28:36
            __out.AppendLine(true); //29:1
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //30:1
            __out.AppendLine(false); //30:70
            __out.AppendLine(true); //31:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //32:1
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
                __out.AppendLine(false); //32:48
            }
            __out.Append("{"); //33:1
            __out.AppendLine(false); //33:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "    public class "; //34:1
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
            string __tmp9_line = "LanguageAuthoringScope : AuthoringScope"; //34:48
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //34:87
            }
            __out.Append("    {"); //35:1
            __out.AppendLine(false); //35:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //36:1
            __out.AppendLine(false); //36:84
            __out.Append("        {"); //37:1
            __out.AppendLine(false); //37:10
            __out.Append("            span = new TextSpan();"); //38:1
            __out.AppendLine(false); //38:35
            __out.Append("            return null;"); //39:1
            __out.AppendLine(false); //39:25
            __out.Append("        }"); //40:1
            __out.AppendLine(false); //40:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //42:1
            __out.AppendLine(false); //42:126
            __out.Append("        {"); //43:1
            __out.AppendLine(false); //43:10
            __out.Append("            return null;"); //44:1
            __out.AppendLine(false); //44:25
            __out.Append("        }"); //45:1
            __out.AppendLine(false); //45:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //47:1
            __out.AppendLine(false); //47:75
            __out.Append("        {"); //48:1
            __out.AppendLine(false); //48:10
            __out.Append("            return null;"); //49:1
            __out.AppendLine(false); //49:25
            __out.Append("        }"); //50:1
            __out.AppendLine(false); //50:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //52:1
            __out.AppendLine(false); //52:149
            __out.Append("        {"); //53:1
            __out.AppendLine(false); //53:10
            __out.Append("            span = new TextSpan();"); //54:1
            __out.AppendLine(false); //54:35
            __out.Append("            return null;"); //55:1
            __out.AppendLine(false); //55:25
            __out.Append("        }"); //56:1
            __out.AppendLine(false); //56:10
            __out.Append("    }"); //57:1
            __out.AppendLine(false); //57:6
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public class "; //59:1
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
            string __tmp14_line = "LanguageColorizer : Colorizer"; //59:45
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //59:74
            }
            __out.Append("    {"); //60:1
            __out.AppendLine(false); //60:6
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "        public "; //61:1
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
            string __tmp19_line = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //61:46
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //61:123
            }
            __out.Append("            : base(svc, buffer, scanner)"); //62:1
            __out.AppendLine(false); //62:41
            __out.Append("        {"); //63:1
            __out.AppendLine(false); //63:10
            __out.Append("        }"); //64:1
            __out.AppendLine(false); //64:10
            __out.Append("        #region IVsColorizer Members"); //66:1
            __out.AppendLine(false); //66:37
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //68:1
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
            string __tmp24_line = " attrs)"; //68:97
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //68:104
            }
            __out.Append("        {"); //69:1
            __out.AppendLine(false); //69:10
            __out.Append("            if (attrs == null) return state;"); //70:1
            __out.AppendLine(false); //70:45
            __out.Append("            int linepos = 0;"); //71:1
            __out.AppendLine(false); //71:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //72:1
            __out.AppendLine(false); //72:75
            __out.Append("            // random color junk on the screen."); //73:1
            __out.AppendLine(false); //73:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //74:1
            __out.AppendLine(false); //74:65
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "                attrs"; //75:1
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
            string __tmp29_line = " = (uint)TokenColor.Text;"; //75:35
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //75:60
            }
            __out.Append("            if (this.Scanner != null)"); //76:1
            __out.AppendLine(false); //76:38
            __out.Append("            {"); //77:1
            __out.AppendLine(false); //77:14
            __out.Append("                try"); //78:1
            __out.AppendLine(false); //78:20
            __out.Append("                {"); //79:1
            __out.AppendLine(false); //79:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //80:1
            __out.AppendLine(false); //80:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //82:1
            __out.AppendLine(false); //82:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //84:1
            __out.AppendLine(false); //84:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //86:1
            __out.AppendLine(false); //86:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //88:1
            __out.AppendLine(false); //88:94
            __out.Append("                    {"); //89:1
            __out.AppendLine(false); //89:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //90:1
            __out.AppendLine(false); //90:103
            __out.Append("                        {"); //91:1
            __out.AppendLine(false); //91:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //92:1
            __out.AppendLine(false); //92:72
            __out.Append("                            {"); //93:1
            __out.AppendLine(false); //93:30
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "                                attrs"; //94:1
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
            string __tmp34_line = " = (uint)tokenInfo.Color;"; //94:51
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //94:76
            }
            __out.Append("                            }"); //95:1
            __out.AppendLine(false); //95:30
            __out.Append("                        }"); //96:1
            __out.AppendLine(false); //96:26
            __out.Append("                    }"); //97:1
            __out.AppendLine(false); //97:22
            __out.Append("                }"); //98:1
            __out.AppendLine(false); //98:18
            __out.Append("                catch (Exception)"); //99:1
            __out.AppendLine(false); //99:34
            __out.Append("                {"); //100:1
            __out.AppendLine(false); //100:18
            __out.Append("                    // Ignore exceptions"); //101:1
            __out.AppendLine(false); //101:41
            __out.Append("                }"); //102:1
            __out.AppendLine(false); //102:18
            __out.Append("            }"); //103:1
            __out.AppendLine(false); //103:14
            __out.Append("            return state;"); //104:1
            __out.AppendLine(false); //104:26
            __out.Append("        }"); //105:1
            __out.AppendLine(false); //105:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //107:1
            __out.AppendLine(false); //107:64
            __out.Append("        {"); //108:1
            __out.AppendLine(false); //108:10
            __out.Append("            piStartState = 0;"); //109:1
            __out.AppendLine(false); //109:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //110:1
            __out.AppendLine(false); //110:60
            __out.Append("        }"); //111:1
            __out.AppendLine(false); //111:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //113:1
            __out.AppendLine(false); //113:98
            __out.Append("        {"); //114:1
            __out.AppendLine(false); //114:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //115:1
            __out.AppendLine(false); //115:66
            __out.Append("            if (text != null)"); //116:1
            __out.AppendLine(false); //116:30
            __out.Append("            {"); //117:1
            __out.AppendLine(false); //117:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //118:1
            __out.AppendLine(false); //118:49
            bool __tmp36_outputWritten = false;
            string __tmp37_line = "                (("; //119:1
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
            string __tmp39_line = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //119:49
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp36_outputWritten = true;
            }
            if (__tmp36_outputWritten) __out.AppendLine(true);
            if (__tmp36_outputWritten)
            {
                __out.AppendLine(false); //119:100
            }
            __out.Append("            }"); //120:1
            __out.AppendLine(false); //120:14
            __out.Append("            return iState;"); //121:1
            __out.AppendLine(false); //121:27
            __out.Append("        }"); //122:1
            __out.AppendLine(false); //122:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //124:1
            __out.AppendLine(false); //124:68
            __out.Append("        {"); //125:1
            __out.AppendLine(false); //125:10
            __out.Append("            pfFlag = 1;"); //126:1
            __out.AppendLine(false); //126:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //127:1
            __out.AppendLine(false); //127:60
            __out.Append("        }"); //128:1
            __out.AppendLine(false); //128:10
            __out.Append("        #endregion"); //130:1
            __out.AppendLine(false); //130:19
            __out.Append("    }"); //131:1
            __out.AppendLine(false); //131:6
            bool __tmp41_outputWritten = false;
            string __tmp42_line = "    public abstract class "; //134:1
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
            string __tmp44_line = "LanguageConfigBase"; //134:57
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Append(__tmp44_line);
                __tmp41_outputWritten = true;
            }
            if (__tmp41_outputWritten) __out.AppendLine(true);
            if (__tmp41_outputWritten)
            {
                __out.AppendLine(false); //134:75
            }
            __out.Append("    {"); //135:1
            __out.AppendLine(false); //135:6
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "        private static "; //136:1
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
            string __tmp49_line = "LanguageConfig instance = null;"; //136:54
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //136:85
            }
            bool __tmp51_outputWritten = false;
            string __tmp52_line = "        public static "; //137:1
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
            string __tmp54_line = "LanguageConfig Instance"; //137:53
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Append(__tmp54_line);
                __tmp51_outputWritten = true;
            }
            if (__tmp51_outputWritten) __out.AppendLine(true);
            if (__tmp51_outputWritten)
            {
                __out.AppendLine(false); //137:76
            }
            __out.Append("        {"); //138:1
            __out.AppendLine(false); //138:10
            __out.Append("            get "); //139:1
            __out.AppendLine(false); //139:17
            __out.Append("            {"); //140:1
            __out.AppendLine(false); //140:14
            __out.Append("                if (instance == null)"); //141:1
            __out.AppendLine(false); //141:38
            __out.Append("                {"); //142:1
            __out.AppendLine(false); //142:18
            bool __tmp56_outputWritten = false;
            string __tmp57_line = "					// If there is a compile error in the following line, create a class "; //143:1
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
            string __tmp59_line = "LanguageConfig"; //143:105
            if (!string.IsNullOrEmpty(__tmp59_line))
            {
                __out.Append(__tmp59_line);
                __tmp56_outputWritten = true;
            }
            if (__tmp56_outputWritten) __out.AppendLine(true);
            if (__tmp56_outputWritten)
            {
                __out.AppendLine(false); //143:119
            }
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "					// which is a subclass of "; //144:1
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
            string __tmp64_line = "LanguageConfigBase"; //144:62
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Append(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //144:80
            }
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "                    instance = new "; //145:1
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
            string __tmp69_line = "LanguageConfig();"; //145:66
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //145:83
            }
            __out.Append("                }"); //146:1
            __out.AppendLine(false); //146:18
            __out.Append("                return instance;"); //147:1
            __out.AppendLine(false); //147:33
            __out.Append("            }"); //148:1
            __out.AppendLine(false); //148:14
            __out.Append("        }"); //149:1
            __out.AppendLine(false); //149:10
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "        private List<"; //150:1
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
            string __tmp74_line = "LanguageColorableItem> colorableItems = new List<"; //150:52
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
            string __tmp76_line = "LanguageColorableItem>();"; //150:131
            if (!string.IsNullOrEmpty(__tmp76_line))
            {
                __out.Append(__tmp76_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //150:156
            }
            bool __tmp78_outputWritten = false;
            string __tmp79_line = "        public IList<"; //151:1
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
            string __tmp81_line = "LanguageColorableItem> ColorableItems"; //151:52
            if (!string.IsNullOrEmpty(__tmp81_line))
            {
                __out.Append(__tmp81_line);
                __tmp78_outputWritten = true;
            }
            if (__tmp78_outputWritten) __out.AppendLine(true);
            if (__tmp78_outputWritten)
            {
                __out.AppendLine(false); //151:89
            }
            __out.Append("        {"); //152:1
            __out.AppendLine(false); //152:10
            __out.Append("            get { return colorableItems; }"); //153:1
            __out.AppendLine(false); //153:43
            __out.Append("        }"); //154:1
            __out.AppendLine(false); //154:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)"); //155:1
            __out.AppendLine(false); //155:93
            __out.Append("        {"); //156:1
            __out.AppendLine(false); //156:10
            __out.Append("            return CreateColor(name, type, foregroundColor, false, false);"); //157:1
            __out.AppendLine(false); //157:75
            __out.Append("        }"); //158:1
            __out.AppendLine(false); //158:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)"); //159:1
            __out.AppendLine(false); //159:98
            __out.Append("        {"); //160:1
            __out.AppendLine(false); //160:10
            __out.Append("            return CreateColor(name, type, foregroundIndex, false, false);"); //161:1
            __out.AppendLine(false); //161:75
            __out.Append("        }"); //162:1
            __out.AppendLine(false); //162:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)"); //163:1
            __out.AppendLine(false); //163:124
            __out.Append("        {"); //164:1
            __out.AppendLine(false); //164:10
            bool __tmp83_outputWritten = false;
            string __tmp84_line = "            colorableItems.Add(new "; //165:1
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
            string __tmp86_line = "LanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));"; //165:66
            if (!string.IsNullOrEmpty(__tmp86_line))
            {
                __out.Append(__tmp86_line);
                __tmp83_outputWritten = true;
            }
            if (__tmp83_outputWritten) __out.AppendLine(true);
            if (__tmp83_outputWritten)
            {
                __out.AppendLine(false); //165:197
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //166:1
            __out.AppendLine(false); //166:53
            __out.Append("        }"); //167:1
            __out.AppendLine(false); //167:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)"); //168:1
            __out.AppendLine(false); //168:129
            __out.Append("        {"); //169:1
            __out.AppendLine(false); //169:10
            bool __tmp88_outputWritten = false;
            string __tmp89_line = "            colorableItems.Add(new "; //170:1
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
            string __tmp91_line = "LanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));"; //170:66
            if (!string.IsNullOrEmpty(__tmp91_line))
            {
                __out.Append(__tmp91_line);
                __tmp88_outputWritten = true;
            }
            if (__tmp88_outputWritten) __out.AppendLine(true);
            if (__tmp88_outputWritten)
            {
                __out.AppendLine(false); //170:192
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //171:1
            __out.AppendLine(false); //171:53
            __out.Append("        }"); //172:1
            __out.AppendLine(false); //172:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"); //173:1
            __out.AppendLine(false); //173:203
            __out.Append("        {"); //174:1
            __out.AppendLine(false); //174:10
            bool __tmp93_outputWritten = false;
            string __tmp94_line = "            colorableItems.Add(new "; //175:1
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
            string __tmp96_line = "LanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));"; //175:66
            if (!string.IsNullOrEmpty(__tmp96_line))
            {
                __out.Append(__tmp96_line);
                __tmp93_outputWritten = true;
            }
            if (__tmp93_outputWritten) __out.AppendLine(true);
            if (__tmp93_outputWritten)
            {
                __out.AppendLine(false); //175:190
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //176:1
            __out.AppendLine(false); //176:53
            __out.Append("        }"); //177:1
            __out.AppendLine(false); //177:10
            __out.Append("    }"); //178:1
            __out.AppendLine(false); //178:6
            bool __tmp98_outputWritten = false;
            string __tmp99_line = "    public class "; //179:1
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
            string __tmp101_line = "LanguageColorableItem : IVsColorableItem, IVsHiColorItem"; //179:48
            if (!string.IsNullOrEmpty(__tmp101_line))
            {
                __out.Append(__tmp101_line);
                __tmp98_outputWritten = true;
            }
            if (__tmp98_outputWritten) __out.AppendLine(true);
            if (__tmp98_outputWritten)
            {
                __out.AppendLine(false); //179:104
            }
            __out.Append("    {"); //180:1
            __out.AppendLine(false); //180:6
            __out.Append("        // Indicates that the returned RGB value is really an index"); //181:1
            __out.AppendLine(false); //181:68
            __out.Append("        // into a predefined list of colors."); //182:1
            __out.AppendLine(false); //182:45
            __out.Append("        private const uint COLOR_INDEXED = 0x01000000;"); //183:1
            __out.AppendLine(false); //183:55
            __out.Append("        public string DisplayName { get; private set; }"); //185:1
            __out.AppendLine(false); //185:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //186:1
            __out.AppendLine(false); //186:57
            __out.Append("        public COLORINDEX BackgroundIndex { get; private set; }"); //187:1
            __out.AppendLine(false); //187:64
            __out.Append("        public COLORINDEX ForegroundIndex { get; private set; }"); //188:1
            __out.AppendLine(false); //188:64
            __out.Append("        public uint BackgroundColor { get; private set; }"); //189:1
            __out.AppendLine(false); //189:58
            __out.Append("        public uint ForegroundColor { get; private set; }"); //190:1
            __out.AppendLine(false); //190:58
            __out.Append("        public uint FontFlags { get; private set; }"); //191:1
            __out.AppendLine(false); //191:52
            bool __tmp103_outputWritten = false;
            string __tmp104_line = "        public "; //193:1
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
            string __tmp106_line = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"; //193:46
            if (!string.IsNullOrEmpty(__tmp106_line))
            {
                __out.Append(__tmp106_line);
                __tmp103_outputWritten = true;
            }
            if (__tmp103_outputWritten) __out.AppendLine(true);
            if (__tmp103_outputWritten)
            {
                __out.AppendLine(false); //193:241
            }
            __out.Append("        {"); //194:1
            __out.AppendLine(false); //194:10
            __out.Append("            this.DisplayName = displayName;"); //195:1
            __out.AppendLine(false); //195:44
            __out.Append("            this.TokenType = tokenType;"); //196:1
            __out.AppendLine(false); //196:40
            __out.Append("            this.BackgroundIndex = backgroundIndex;"); //197:1
            __out.AppendLine(false); //197:52
            __out.Append("            this.ForegroundIndex = foregroundIndex;"); //198:1
            __out.AppendLine(false); //198:52
            __out.Append("            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);"); //199:1
            __out.AppendLine(false); //199:98
            __out.Append("            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);"); //200:1
            __out.AppendLine(false); //200:98
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //201:1
            __out.AppendLine(false); //201:57
            __out.Append("            if (bold)"); //202:1
            __out.AppendLine(false); //202:22
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;"); //203:1
            __out.AppendLine(false); //203:75
            __out.Append("            if (strikethrough)"); //204:1
            __out.AppendLine(false); //204:31
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //205:1
            __out.AppendLine(false); //205:84
            __out.Append("        }"); //206:1
            __out.AppendLine(false); //206:10
            __out.Append("        #region IVsColorableItem Members"); //208:1
            __out.AppendLine(false); //208:41
            bool __tmp108_outputWritten = false;
            string __tmp109_line = "        public int GetDefaultColors(COLORINDEX"; //209:1
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
            string __tmp111_line = " piForeground, COLORINDEX"; //209:53
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
            string __tmp113_line = " piBackground)"; //209:84
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Append(__tmp113_line);
                __tmp108_outputWritten = true;
            }
            if (__tmp108_outputWritten) __out.AppendLine(true);
            if (__tmp108_outputWritten)
            {
                __out.AppendLine(false); //209:98
            }
            __out.Append("        {"); //210:1
            __out.AppendLine(false); //210:10
            __out.Append("            if (null == piForeground)"); //211:1
            __out.AppendLine(false); //211:38
            __out.Append("            {"); //212:1
            __out.AppendLine(false); //212:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //213:1
            __out.AppendLine(false); //213:65
            __out.Append("            }"); //214:1
            __out.AppendLine(false); //214:14
            __out.Append("            if (0 == piForeground.Length)"); //215:1
            __out.AppendLine(false); //215:42
            __out.Append("            {"); //216:1
            __out.AppendLine(false); //216:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //217:1
            __out.AppendLine(false); //217:71
            __out.Append("            }"); //218:1
            __out.AppendLine(false); //218:14
            bool __tmp115_outputWritten = false;
            string __tmp116_line = "            piForeground"; //219:1
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
            string __tmp118_line = " = this.ForegroundIndex;"; //219:32
            if (!string.IsNullOrEmpty(__tmp118_line))
            {
                __out.Append(__tmp118_line);
                __tmp115_outputWritten = true;
            }
            if (__tmp115_outputWritten) __out.AppendLine(true);
            if (__tmp115_outputWritten)
            {
                __out.AppendLine(false); //219:56
            }
            __out.Append("            if (null == piBackground)"); //220:1
            __out.AppendLine(false); //220:38
            __out.Append("            {"); //221:1
            __out.AppendLine(false); //221:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //222:1
            __out.AppendLine(false); //222:65
            __out.Append("            }"); //223:1
            __out.AppendLine(false); //223:14
            __out.Append("            if (0 == piBackground.Length)"); //224:1
            __out.AppendLine(false); //224:42
            __out.Append("            {"); //225:1
            __out.AppendLine(false); //225:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //226:1
            __out.AppendLine(false); //226:71
            __out.Append("            }"); //227:1
            __out.AppendLine(false); //227:14
            bool __tmp120_outputWritten = false;
            string __tmp121_line = "            piBackground"; //228:1
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
            string __tmp123_line = " = this.BackgroundIndex;"; //228:32
            if (!string.IsNullOrEmpty(__tmp123_line))
            {
                __out.Append(__tmp123_line);
                __tmp120_outputWritten = true;
            }
            if (__tmp120_outputWritten) __out.AppendLine(true);
            if (__tmp120_outputWritten)
            {
                __out.AppendLine(false); //228:56
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //229:1
            __out.AppendLine(false); //229:60
            __out.Append("        }"); //230:1
            __out.AppendLine(false); //230:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //231:1
            __out.AppendLine(false); //231:62
            __out.Append("        {"); //232:1
            __out.AppendLine(false); //232:10
            __out.Append("            pdwFontFlags = this.FontFlags;"); //233:1
            __out.AppendLine(false); //233:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //234:1
            __out.AppendLine(false); //234:60
            __out.Append("        }"); //235:1
            __out.AppendLine(false); //235:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //236:1
            __out.AppendLine(false); //236:56
            __out.Append("        {"); //237:1
            __out.AppendLine(false); //237:10
            __out.Append("            pbstrName = this.DisplayName;"); //238:1
            __out.AppendLine(false); //238:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //239:1
            __out.AppendLine(false); //239:60
            __out.Append("        }"); //240:1
            __out.AppendLine(false); //240:10
            __out.Append("        public int GetColorData(int cdElement, out uint pcrColor)"); //242:1
            __out.AppendLine(false); //242:66
            __out.Append("        {"); //243:1
            __out.AppendLine(false); //243:10
            __out.Append("            int retval = VSConstants.E_NOTIMPL;"); //244:1
            __out.AppendLine(false); //244:48
            __out.Append("            pcrColor = 0;"); //245:1
            __out.AppendLine(false); //245:26
            __out.Append("            switch ((__tagVSCOLORDATA)cdElement)"); //247:1
            __out.AppendLine(false); //247:49
            __out.Append("            {"); //248:1
            __out.AppendLine(false); //248:14
            __out.Append("                case __tagVSCOLORDATA.CD_BACKGROUND:"); //249:1
            __out.AppendLine(false); //249:53
            __out.Append("                    pcrColor = this.BackgroundIndex > 0 ?"); //250:1
            __out.AppendLine(false); //250:58
            __out.Append("                                   (uint)this.BackgroundIndex | COLOR_INDEXED"); //251:1
            __out.AppendLine(false); //251:78
            __out.Append("                                   : this.BackgroundColor;"); //252:1
            __out.AppendLine(false); //252:59
            __out.Append("                    retval = VSConstants.S_OK;"); //253:1
            __out.AppendLine(false); //253:47
            __out.Append("                    break;"); //254:1
            __out.AppendLine(false); //254:27
            __out.Append("                case __tagVSCOLORDATA.CD_FOREGROUND:"); //256:1
            __out.AppendLine(false); //256:53
            __out.Append("                case __tagVSCOLORDATA.CD_LINECOLOR:"); //257:1
            __out.AppendLine(false); //257:52
            __out.Append("                    pcrColor = this.ForegroundIndex > 0 ?"); //258:1
            __out.AppendLine(false); //258:58
            __out.Append("                                   (uint)this.ForegroundIndex | COLOR_INDEXED"); //259:1
            __out.AppendLine(false); //259:78
            __out.Append("                                   : this.ForegroundColor;"); //260:1
            __out.AppendLine(false); //260:59
            __out.Append("                    retval = VSConstants.S_OK;"); //261:1
            __out.AppendLine(false); //261:47
            __out.Append("                    break;"); //262:1
            __out.AppendLine(false); //262:27
            __out.Append("                default:"); //264:1
            __out.AppendLine(false); //264:25
            __out.Append("                    retval = VSConstants.E_INVALIDARG;"); //265:1
            __out.AppendLine(false); //265:55
            __out.Append("                    break;"); //266:1
            __out.AppendLine(false); //266:27
            __out.Append("            }"); //267:1
            __out.AppendLine(false); //267:14
            __out.Append("            return retval;"); //268:1
            __out.AppendLine(false); //268:27
            __out.Append("        }"); //270:1
            __out.AppendLine(false); //270:10
            __out.Append("        #endregion"); //271:1
            __out.AppendLine(false); //271:19
            __out.Append("    }"); //272:1
            __out.AppendLine(false); //272:6
            bool __tmp125_outputWritten = false;
            string __tmp124Prefix = "    "; //275:1
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
                __out.AppendLine(false); //275:27
            }
            bool __tmp128_outputWritten = false;
            string __tmp127Prefix = "    "; //276:1
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
                __out.AppendLine(false); //276:116
            }
            bool __tmp131_outputWritten = false;
            string __tmp130Prefix = "    "; //277:1
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
                __out.AppendLine(false); //277:127
            }
            bool __tmp134_outputWritten = false;
            string __tmp133Prefix = "    "; //278:1
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
                __out.AppendLine(false); //278:284
            }
            bool __tmp137_outputWritten = false;
            string __tmp136Prefix = "    "; //279:1
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
                __out.AppendLine(false); //279:325
            }
            if (Properties.GenerateMultipleFiles) //280:3
            {
                bool __tmp140_outputWritten = false;
                string __tmp141_line = "    public class "; //281:1
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
                string __tmp143_line = "GeneratorService : VsMultipleFileGenerator<object>"; //281:48
                if (!string.IsNullOrEmpty(__tmp143_line))
                {
                    __out.Append(__tmp143_line);
                    __tmp140_outputWritten = true;
                }
                if (__tmp140_outputWritten) __out.AppendLine(true);
                if (__tmp140_outputWritten)
                {
                    __out.AppendLine(false); //281:98
                }
                __out.Append("    {"); //282:1
                __out.AppendLine(false); //282:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //283:1
                __out.AppendLine(false); //283:146
                __out.Append("		{"); //284:1
                __out.AppendLine(false); //284:4
                bool __tmp145_outputWritten = false;
                string __tmp146_line = "			// If there is a compile error in the following line, create a class "; //285:1
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
                string __tmp148_line = "Generator"; //285:103
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Append(__tmp148_line);
                    __tmp145_outputWritten = true;
                }
                if (__tmp145_outputWritten) __out.AppendLine(true);
                if (__tmp145_outputWritten)
                {
                    __out.AppendLine(false); //285:112
                }
                __out.Append("			// which is a subclass of MultipleFileGenerator<object>"); //286:1
                __out.AppendLine(false); //286:59
                bool __tmp150_outputWritten = false;
                string __tmp151_line = "			return new "; //287:1
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
                string __tmp153_line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //287:45
                if (!string.IsNullOrEmpty(__tmp153_line))
                {
                    __out.Append(__tmp153_line);
                    __tmp150_outputWritten = true;
                }
                if (__tmp150_outputWritten) __out.AppendLine(true);
                if (__tmp150_outputWritten)
                {
                    __out.AppendLine(false); //287:107
                }
                __out.Append("		}"); //288:1
                __out.AppendLine(false); //288:4
                __out.AppendLine(true); //289:1
                __out.Append("        public override string GetDefaultFileExtension()"); //290:1
                __out.AppendLine(false); //290:57
                __out.Append("        {"); //291:1
                __out.AppendLine(false); //291:10
                bool __tmp155_outputWritten = false;
                string __tmp156_line = "            return "; //292:1
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
                string __tmp158_line = "Generator.DefaultExtension;"; //292:50
                if (!string.IsNullOrEmpty(__tmp158_line))
                {
                    __out.Append(__tmp158_line);
                    __tmp155_outputWritten = true;
                }
                if (__tmp155_outputWritten) __out.AppendLine(true);
                if (__tmp155_outputWritten)
                {
                    __out.AppendLine(false); //292:77
                }
                __out.Append("        }"); //293:1
                __out.AppendLine(false); //293:10
                __out.Append("    }"); //294:1
                __out.AppendLine(false); //294:6
            }
            else //295:3
            {
                bool __tmp160_outputWritten = false;
                string __tmp161_line = "    public class "; //296:1
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
                string __tmp163_line = "GeneratorService : VsSingleFileGenerator"; //296:48
                if (!string.IsNullOrEmpty(__tmp163_line))
                {
                    __out.Append(__tmp163_line);
                    __tmp160_outputWritten = true;
                }
                if (__tmp160_outputWritten) __out.AppendLine(true);
                if (__tmp160_outputWritten)
                {
                    __out.AppendLine(false); //296:88
                }
                __out.Append("    {"); //297:1
                __out.AppendLine(false); //297:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //298:1
                __out.AppendLine(false); //298:136
                __out.Append("		{"); //299:1
                __out.AppendLine(false); //299:4
                bool __tmp165_outputWritten = false;
                string __tmp166_line = "			// If there is a compile error in the following line, create a class "; //300:1
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
                string __tmp168_line = "Generator"; //300:103
                if (!string.IsNullOrEmpty(__tmp168_line))
                {
                    __out.Append(__tmp168_line);
                    __tmp165_outputWritten = true;
                }
                if (__tmp165_outputWritten) __out.AppendLine(true);
                if (__tmp165_outputWritten)
                {
                    __out.AppendLine(false); //300:112
                }
                __out.Append("			// which is a subclass of SingleFileGenerator"); //301:1
                __out.AppendLine(false); //301:49
                bool __tmp170_outputWritten = false;
                string __tmp171_line = "			return new "; //302:1
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
                string __tmp173_line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //302:45
                if (!string.IsNullOrEmpty(__tmp173_line))
                {
                    __out.Append(__tmp173_line);
                    __tmp170_outputWritten = true;
                }
                if (__tmp170_outputWritten) __out.AppendLine(true);
                if (__tmp170_outputWritten)
                {
                    __out.AppendLine(false); //302:107
                }
                __out.Append("		}"); //303:1
                __out.AppendLine(false); //303:4
                __out.AppendLine(true); //304:1
                __out.Append("        public override string GetDefaultFileExtension()"); //305:1
                __out.AppendLine(false); //305:57
                __out.Append("        {"); //306:1
                __out.AppendLine(false); //306:10
                bool __tmp175_outputWritten = false;
                string __tmp176_line = "            return "; //307:1
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
                string __tmp178_line = "Generator.DefaultExtension;"; //307:50
                if (!string.IsNullOrEmpty(__tmp178_line))
                {
                    __out.Append(__tmp178_line);
                    __tmp175_outputWritten = true;
                }
                if (__tmp175_outputWritten) __out.AppendLine(true);
                if (__tmp175_outputWritten)
                {
                    __out.AppendLine(false); //307:77
                }
                __out.Append("        }"); //308:1
                __out.AppendLine(false); //308:10
                __out.Append("    }"); //309:1
                __out.AppendLine(false); //309:6
            }
            bool __tmp180_outputWritten = false;
            string __tmp181_line = "    public class "; //313:1
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
            string __tmp183_line = "LanguageScanner : IScanner"; //313:48
            if (!string.IsNullOrEmpty(__tmp183_line))
            {
                __out.Append(__tmp183_line);
                __tmp180_outputWritten = true;
            }
            if (__tmp180_outputWritten) __out.AppendLine(true);
            if (__tmp180_outputWritten)
            {
                __out.AppendLine(false); //313:74
            }
            __out.Append("    {"); //314:1
            __out.AppendLine(false); //314:6
            __out.Append("        private int currentOffset;"); //315:1
            __out.AppendLine(false); //315:35
            __out.Append("        private string currentLine;"); //316:1
            __out.AppendLine(false); //316:36
            bool __tmp185_outputWritten = false;
            string __tmp186_line = "        private "; //317:1
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
            string __tmp188_line = "Lexer lexer;"; //317:46
            if (!string.IsNullOrEmpty(__tmp188_line))
            {
                __out.Append(__tmp188_line);
                __tmp185_outputWritten = true;
            }
            if (__tmp185_outputWritten) __out.AppendLine(true);
            if (__tmp185_outputWritten)
            {
                __out.AppendLine(false); //317:58
            }
            __out.Append("        private IEnumerable<MetaDslx.Compiler.SyntaxAnnotation> modeAnnotations;"); //318:1
            __out.AppendLine(false); //318:81
            __out.Append("        private IEnumerable<MetaDslx.Compiler.SyntaxAnnotation> syntaxAnnotations;"); //319:1
            __out.AppendLine(false); //319:83
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //320:1
            __out.AppendLine(false); //320:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //321:1
            __out.AppendLine(false); //321:62
            __out.Append("        private int lastState;"); //322:1
            __out.AppendLine(false); //322:31
            bool __tmp190_outputWritten = false;
            string __tmp191_line = "        public "; //324:1
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
            string __tmp193_line = "LanguageScanner()"; //324:46
            if (!string.IsNullOrEmpty(__tmp193_line))
            {
                __out.Append(__tmp193_line);
                __tmp190_outputWritten = true;
            }
            if (__tmp190_outputWritten) __out.AppendLine(true);
            if (__tmp190_outputWritten)
            {
                __out.AppendLine(false); //324:63
            }
            __out.Append("        {"); //325:1
            __out.AppendLine(false); //325:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //326:1
            __out.AppendLine(false); //326:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //327:1
            __out.AppendLine(false); //327:71
            __out.Append("            this.lastState = 0;"); //328:1
            __out.AppendLine(false); //328:32
            bool __tmp195_outputWritten = false;
            string __tmp194Prefix = "            "; //329:1
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
            string __tmp197_line = "LexerAnnotator annotator = new "; //329:42
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
            string __tmp199_line = "LexerAnnotator();"; //329:102
            if (!string.IsNullOrEmpty(__tmp199_line))
            {
                __out.Append(__tmp199_line);
                __tmp195_outputWritten = true;
            }
            if (__tmp195_outputWritten) __out.AppendLine(true);
            if (__tmp195_outputWritten)
            {
                __out.AppendLine(false); //329:119
            }
            __out.Append("            List<MetaDslx.Compiler.SyntaxAnnotation> mal = new List<MetaDslx.Compiler.SyntaxAnnotation>();"); //330:1
            __out.AppendLine(false); //330:107
            __out.Append("            foreach (var annotList in annotator.ModeAnnotations.Values)"); //331:1
            __out.AppendLine(false); //331:72
            __out.Append("            {"); //332:1
            __out.AppendLine(false); //332:14
            __out.Append("                foreach (var annot in annotList)"); //333:1
            __out.AppendLine(false); //333:49
            __out.Append("                {"); //334:1
            __out.AppendLine(false); //334:18
            __out.Append("                    if (annot is MetaDslx.Compiler.SyntaxAnnotation)"); //335:1
            __out.AppendLine(false); //335:69
            __out.Append("                    {"); //336:1
            __out.AppendLine(false); //336:22
            __out.Append("                        mal.Add((MetaDslx.Compiler.SyntaxAnnotation)annot);"); //337:1
            __out.AppendLine(false); //337:76
            __out.Append("                    }"); //338:1
            __out.AppendLine(false); //338:22
            __out.Append("                }"); //339:1
            __out.AppendLine(false); //339:18
            __out.Append("            }"); //340:1
            __out.AppendLine(false); //340:14
            __out.Append("            this.modeAnnotations = mal;"); //341:1
            __out.AppendLine(false); //341:40
            __out.Append("            List<MetaDslx.Compiler.SyntaxAnnotation> sal = new List<MetaDslx.Compiler.SyntaxAnnotation>();"); //342:1
            __out.AppendLine(false); //342:107
            __out.Append("            foreach (var annotList in annotator.TokenAnnotations.Values)"); //343:1
            __out.AppendLine(false); //343:73
            __out.Append("            {"); //344:1
            __out.AppendLine(false); //344:14
            __out.Append("                foreach (var annot in annotList)"); //345:1
            __out.AppendLine(false); //345:49
            __out.Append("                {"); //346:1
            __out.AppendLine(false); //346:18
            __out.Append("                    if (annot is MetaDslx.Compiler.SyntaxAnnotation)"); //347:1
            __out.AppendLine(false); //347:69
            __out.Append("                    {"); //348:1
            __out.AppendLine(false); //348:22
            __out.Append("                        sal.Add((MetaDslx.Compiler.SyntaxAnnotation)annot);"); //349:1
            __out.AppendLine(false); //349:76
            __out.Append("                    }"); //350:1
            __out.AppendLine(false); //350:22
            __out.Append("                }"); //351:1
            __out.AppendLine(false); //351:18
            __out.Append("            }"); //352:1
            __out.AppendLine(false); //352:14
            __out.Append("            this.syntaxAnnotations = sal;"); //353:1
            __out.AppendLine(false); //353:42
            __out.Append("        }"); //354:1
            __out.AppendLine(false); //354:10
            bool __tmp201_outputWritten = false;
            string __tmp202_line = "        private void LoadState(int state, "; //356:1
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
            string __tmp204_line = "Lexer lexer)"; //356:72
            if (!string.IsNullOrEmpty(__tmp204_line))
            {
                __out.Append(__tmp204_line);
                __tmp201_outputWritten = true;
            }
            if (__tmp201_outputWritten) __out.AppendLine(true);
            if (__tmp201_outputWritten)
            {
                __out.AppendLine(false); //356:84
            }
            __out.Append("        {"); //357:1
            __out.AppendLine(false); //357:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //358:1
            __out.AppendLine(false); //358:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //359:1
            __out.AppendLine(false); //359:55
            __out.Append("            value.Restore(lexer);"); //360:1
            __out.AppendLine(false); //360:34
            __out.Append("        }"); //361:1
            __out.AppendLine(false); //361:10
            bool __tmp206_outputWritten = false;
            string __tmp207_line = "        private int SaveState("; //363:1
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
            string __tmp209_line = "Lexer lexer)"; //363:60
            if (!string.IsNullOrEmpty(__tmp209_line))
            {
                __out.Append(__tmp209_line);
                __tmp206_outputWritten = true;
            }
            if (__tmp206_outputWritten) __out.AppendLine(true);
            if (__tmp206_outputWritten)
            {
                __out.AppendLine(false); //363:72
            }
            __out.Append("        {"); //364:1
            __out.AppendLine(false); //364:10
            __out.Append("            int result = 0;"); //365:1
            __out.AppendLine(false); //365:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //366:1
            __out.AppendLine(false); //366:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //367:1
            __out.AppendLine(false); //367:68
            __out.Append("            {"); //368:1
            __out.AppendLine(false); //368:14
            __out.Append("                result = ++lastState;"); //369:1
            __out.AppendLine(false); //369:38
            __out.Append("                this.states.Add(result, state);"); //370:1
            __out.AppendLine(false); //370:48
            __out.Append("                this.inverseStates.Add(state, result);"); //371:1
            __out.AppendLine(false); //371:55
            __out.Append("            }"); //372:1
            __out.AppendLine(false); //372:14
            __out.Append("            return result;"); //373:1
            __out.AppendLine(false); //373:27
            __out.Append("        }"); //374:1
            __out.AppendLine(false); //374:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //376:1
            __out.AppendLine(false); //376:87
            __out.Append("        {"); //377:1
            __out.AppendLine(false); //377:10
            __out.Append("            try"); //378:1
            __out.AppendLine(false); //378:16
            __out.Append("            {"); //379:1
            __out.AppendLine(false); //379:14
            __out.Append("                if (this.lexer == null)"); //380:1
            __out.AppendLine(false); //380:40
            __out.Append("                {"); //381:1
            __out.AppendLine(false); //381:18
            bool __tmp211_outputWritten = false;
            string __tmp212_line = "                    this.lexer = new "; //382:1
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
            string __tmp214_line = "Lexer(new AntlrInputStream(this.currentLine + \""; //382:67
            if (!string.IsNullOrEmpty(__tmp214_line))
            {
                __out.Append(__tmp214_line);
                __tmp211_outputWritten = true;
            }
            string __tmp215_line = "\\"; //382:114
            if (!string.IsNullOrEmpty(__tmp215_line))
            {
                __out.Append(__tmp215_line);
                __tmp211_outputWritten = true;
            }
            string __tmp216_line = "r"; //382:115
            if (!string.IsNullOrEmpty(__tmp216_line))
            {
                __out.Append(__tmp216_line);
                __tmp211_outputWritten = true;
            }
            string __tmp217_line = "\\"; //382:116
            if (!string.IsNullOrEmpty(__tmp217_line))
            {
                __out.Append(__tmp217_line);
                __tmp211_outputWritten = true;
            }
            string __tmp218_line = "n\"));"; //382:117
            if (!string.IsNullOrEmpty(__tmp218_line))
            {
                __out.Append(__tmp218_line);
                __tmp211_outputWritten = true;
            }
            if (__tmp211_outputWritten) __out.AppendLine(true);
            if (__tmp211_outputWritten)
            {
                __out.AppendLine(false); //382:122
            }
            __out.Append("                }"); //383:1
            __out.AppendLine(false); //383:18
            __out.Append("                this.LoadState(state, this.lexer);"); //384:1
            __out.AppendLine(false); //384:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //385:1
            __out.AppendLine(false); //385:55
            __out.Append("                int tokenType = -1;"); //386:1
            __out.AppendLine(false); //386:36
            __out.Append("                foreach (var modeAnnot in this.modeAnnotations)"); //388:1
            __out.AppendLine(false); //388:64
            __out.Append("                {"); //389:1
            __out.AppendLine(false); //389:18
            __out.Append("                    if (this.lexer.CurrentMode >= modeAnnot.First && this.lexer.CurrentMode <= modeAnnot.Last)"); //390:1
            __out.AppendLine(false); //390:111
            __out.Append("                    {"); //391:1
            __out.AppendLine(false); //391:22
            __out.Append("                        tokenType = modeAnnot.Kind;"); //392:1
            __out.AppendLine(false); //392:52
            __out.Append("                        break;"); //393:1
            __out.AppendLine(false); //393:31
            __out.Append("                    }"); //394:1
            __out.AppendLine(false); //394:22
            __out.Append("                }"); //395:1
            __out.AppendLine(false); //395:18
            __out.Append("                foreach (var syntaxAnnot in this.syntaxAnnotations)"); //396:1
            __out.AppendLine(false); //396:68
            __out.Append("                {"); //397:1
            __out.AppendLine(false); //397:18
            __out.Append("                    if (token.Type >= syntaxAnnot.First && token.Type <= syntaxAnnot.Last)"); //398:1
            __out.AppendLine(false); //398:91
            __out.Append("                    {"); //399:1
            __out.AppendLine(false); //399:22
            __out.Append("                        tokenType = syntaxAnnot.Kind;"); //400:1
            __out.AppendLine(false); //400:54
            __out.Append("                        break;"); //401:1
            __out.AppendLine(false); //401:31
            __out.Append("                    }"); //402:1
            __out.AppendLine(false); //402:22
            __out.Append("                }"); //403:1
            __out.AppendLine(false); //403:18
            bool __tmp220_outputWritten = false;
            string __tmp221_line = "                if (tokenType >= 1 && tokenType <= "; //405:1
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
            string __tmp223_line = "LanguageConfig.Instance.ColorableItems.Count)"; //405:82
            if (!string.IsNullOrEmpty(__tmp223_line))
            {
                __out.Append(__tmp223_line);
                __tmp220_outputWritten = true;
            }
            if (__tmp220_outputWritten) __out.AppendLine(true);
            if (__tmp220_outputWritten)
            {
                __out.AppendLine(false); //405:127
            }
            __out.Append("                {"); //406:1
            __out.AppendLine(false); //406:18
            bool __tmp225_outputWritten = false;
            string __tmp224Prefix = "                    "; //407:1
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
            string __tmp227_line = "LanguageColorableItem colorItem = "; //407:51
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
            string __tmp229_line = "LanguageConfig.Instance.ColorableItems"; //407:115
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
            string __tmp231_line = ";"; //407:172
            if (!string.IsNullOrEmpty(__tmp231_line))
            {
                __out.Append(__tmp231_line);
                __tmp225_outputWritten = true;
            }
            if (__tmp225_outputWritten) __out.AppendLine(true);
            if (__tmp225_outputWritten)
            {
                __out.AppendLine(false); //407:173
            }
            __out.Append("                    tokenInfo.Token = token.Type;"); //408:1
            __out.AppendLine(false); //408:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //409:1
            __out.AppendLine(false); //409:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //410:1
            __out.AppendLine(false); //410:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //411:1
            __out.AppendLine(false); //411:60
            __out.Append("                }"); //412:1
            __out.AppendLine(false); //412:18
            __out.Append("                else"); //413:1
            __out.AppendLine(false); //413:21
            __out.Append("                {"); //414:1
            __out.AppendLine(false); //414:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //415:1
            __out.AppendLine(false); //415:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //416:1
            __out.AppendLine(false); //416:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //417:1
            __out.AppendLine(false); //417:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //418:1
            __out.AppendLine(false); //418:60
            __out.Append("                }"); //419:1
            __out.AppendLine(false); //419:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //421:1
            __out.AppendLine(false); //421:103
            __out.Append("                {"); //422:1
            __out.AppendLine(false); //422:18
            __out.Append("                    return false;"); //423:1
            __out.AppendLine(false); //423:34
            __out.Append("                }"); //424:1
            __out.AppendLine(false); //424:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //425:1
            __out.AppendLine(false); //425:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //426:1
            __out.AppendLine(false); //426:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //427:1
            __out.AppendLine(false); //427:61
            __out.Append("                state = this.SaveState(lexer);"); //428:1
            __out.AppendLine(false); //428:47
            __out.Append("                return true;"); //429:1
            __out.AppendLine(false); //429:29
            __out.Append("            }"); //430:1
            __out.AppendLine(false); //430:14
            __out.Append("            catch (Exception)"); //431:1
            __out.AppendLine(false); //431:30
            __out.Append("            {"); //432:1
            __out.AppendLine(false); //432:14
            __out.Append("                return false;"); //433:1
            __out.AppendLine(false); //433:30
            __out.Append("            }"); //434:1
            __out.AppendLine(false); //434:14
            __out.Append("        }"); //435:1
            __out.AppendLine(false); //435:10
            __out.Append("        public void SetSource(string source, int offset)"); //437:1
            __out.AppendLine(false); //437:57
            __out.Append("        {"); //438:1
            __out.AppendLine(false); //438:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //439:1
            __out.AppendLine(false); //439:78
            __out.Append("            {"); //440:1
            __out.AppendLine(false); //440:14
            __out.Append("                this.currentOffset = offset;"); //441:1
            __out.AppendLine(false); //441:45
            __out.Append("                this.currentLine = source;"); //442:1
            __out.AppendLine(false); //442:43
            __out.Append("                this.lexer = null;"); //443:1
            __out.AppendLine(false); //443:35
            __out.Append("            }"); //444:1
            __out.AppendLine(false); //444:14
            __out.Append("        }"); //445:1
            __out.AppendLine(false); //445:10
            __out.Append("        internal void ScanLine(ref int state)"); //446:1
            __out.AppendLine(false); //446:46
            __out.Append("        {"); //447:1
            __out.AppendLine(false); //447:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //448:1
            __out.AppendLine(false); //448:86
            __out.Append("        }"); //449:1
            __out.AppendLine(false); //449:10
            __out.Append("        internal struct LanguageScannerState"); //451:1
            __out.AppendLine(false); //451:45
            __out.Append("        {"); //452:1
            __out.AppendLine(false); //452:10
            bool __tmp233_outputWritten = false;
            string __tmp234_line = "            public LanguageScannerState("; //453:1
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
            string __tmp236_line = "Lexer lexer)"; //453:70
            if (!string.IsNullOrEmpty(__tmp236_line))
            {
                __out.Append(__tmp236_line);
                __tmp233_outputWritten = true;
            }
            if (__tmp233_outputWritten) __out.AppendLine(true);
            if (__tmp233_outputWritten)
            {
                __out.AppendLine(false); //453:82
            }
            __out.Append("            {"); //454:1
            __out.AppendLine(false); //454:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //455:1
            __out.AppendLine(false); //455:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //456:1
            __out.AppendLine(false); //456:101
            __out.Append("                this._type = lexer.Type;"); //457:1
            __out.AppendLine(false); //457:41
            __out.Append("                this._channel = lexer.Channel;"); //458:1
            __out.AppendLine(false); //458:47
            __out.Append("                this._state = lexer.State;"); //459:1
            __out.AppendLine(false); //459:43
            __out.Append("            }"); //460:1
            __out.AppendLine(false); //460:14
            __out.Append("            internal int _state;"); //462:1
            __out.AppendLine(false); //462:33
            __out.Append("            internal int _mode;"); //463:1
            __out.AppendLine(false); //463:32
            __out.Append("            internal List<int> _modeStack;"); //464:1
            __out.AppendLine(false); //464:43
            __out.Append("            internal int _type;"); //465:1
            __out.AppendLine(false); //465:32
            __out.Append("            internal int _channel;"); //466:1
            __out.AppendLine(false); //466:35
            bool __tmp238_outputWritten = false;
            string __tmp239_line = "            public void Restore("; //468:1
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
            string __tmp241_line = "Lexer lexer)"; //468:62
            if (!string.IsNullOrEmpty(__tmp241_line))
            {
                __out.Append(__tmp241_line);
                __tmp238_outputWritten = true;
            }
            if (__tmp238_outputWritten) __out.AppendLine(true);
            if (__tmp238_outputWritten)
            {
                __out.AppendLine(false); //468:74
            }
            __out.Append("            {"); //469:1
            __out.AppendLine(false); //469:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //470:1
            __out.AppendLine(false); //470:48
            __out.Append("                lexer.ModeStack.Clear();"); //471:1
            __out.AppendLine(false); //471:41
            __out.Append("                if (this._modeStack != null)"); //472:1
            __out.AppendLine(false); //472:45
            __out.Append("                {"); //473:1
            __out.AppendLine(false); //473:18
            __out.Append("                    foreach (var item in this._modeStack)"); //474:1
            __out.AppendLine(false); //474:58
            __out.Append("                    {"); //475:1
            __out.AppendLine(false); //475:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //476:1
            __out.AppendLine(false); //476:52
            __out.Append("                    }"); //477:1
            __out.AppendLine(false); //477:22
            __out.Append("                }"); //478:1
            __out.AppendLine(false); //478:18
            __out.Append("                lexer.Type = this._type;"); //479:1
            __out.AppendLine(false); //479:41
            __out.Append("                lexer.Channel = this._channel;"); //480:1
            __out.AppendLine(false); //480:47
            __out.Append("                lexer.State = this._state;"); //481:1
            __out.AppendLine(false); //481:43
            __out.Append("            }"); //482:1
            __out.AppendLine(false); //482:14
            __out.Append("            public override bool Equals(object obj)"); //484:1
            __out.AppendLine(false); //484:52
            __out.Append("            {"); //485:1
            __out.AppendLine(false); //485:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //486:1
            __out.AppendLine(false); //486:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //487:1
            __out.AppendLine(false); //487:59
            __out.Append("                if (rhs._type != this._type) return false;"); //488:1
            __out.AppendLine(false); //488:59
            __out.Append("                if (rhs._state != this._state) return false;"); //489:1
            __out.AppendLine(false); //489:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //490:1
            __out.AppendLine(false); //490:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //491:1
            __out.AppendLine(false); //491:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //492:1
            __out.AppendLine(false); //492:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //493:1
            __out.AppendLine(false); //493:71
            __out.Append("                {"); //494:1
            __out.AppendLine(false); //494:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //495:1
            __out.AppendLine(false); //495:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //496:1
            __out.AppendLine(false); //496:67
            __out.Append("                    {"); //497:1
            __out.AppendLine(false); //497:22
            bool __tmp243_outputWritten = false;
            string __tmp244_line = "                        if (rhs._modeStack"; //498:1
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
            string __tmp246_line = " != this._modeStack"; //498:50
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
            string __tmp248_line = ") return false;"; //498:76
            if (!string.IsNullOrEmpty(__tmp248_line))
            {
                __out.Append(__tmp248_line);
                __tmp243_outputWritten = true;
            }
            if (__tmp243_outputWritten) __out.AppendLine(true);
            if (__tmp243_outputWritten)
            {
                __out.AppendLine(false); //498:91
            }
            __out.Append("                    }"); //499:1
            __out.AppendLine(false); //499:22
            __out.Append("                }"); //500:1
            __out.AppendLine(false); //500:18
            __out.Append("                return true;"); //501:1
            __out.AppendLine(false); //501:29
            __out.Append("            }"); //502:1
            __out.AppendLine(false); //502:14
            __out.Append("            public override int GetHashCode()"); //504:1
            __out.AppendLine(false); //504:46
            __out.Append("            {"); //505:1
            __out.AppendLine(false); //505:14
            __out.Append("                int result = 0;"); //506:1
            __out.AppendLine(false); //506:32
            __out.Append("                result "); //507:1
            __out.Append("^"); //507:24
            __out.Append("= this._mode.GetHashCode();"); //507:25
            __out.AppendLine(false); //507:52
            __out.Append("                result "); //508:1
            __out.Append("^"); //508:24
            __out.Append("= this._type.GetHashCode();"); //508:25
            __out.AppendLine(false); //508:52
            __out.Append("                result "); //509:1
            __out.Append("^"); //509:24
            __out.Append("= this._state.GetHashCode();"); //509:25
            __out.AppendLine(false); //509:53
            __out.Append("                result "); //510:1
            __out.Append("^"); //510:24
            __out.Append("= this._channel.GetHashCode();"); //510:25
            __out.AppendLine(false); //510:55
            __out.Append("                if (this._modeStack != null)"); //511:1
            __out.AppendLine(false); //511:45
            __out.Append("                {"); //512:1
            __out.AppendLine(false); //512:18
            __out.Append("                    result "); //513:1
            __out.Append("^"); //513:28
            __out.Append("= this._modeStack.GetHashCode();"); //513:29
            __out.AppendLine(false); //513:61
            __out.Append("                }"); //514:1
            __out.AppendLine(false); //514:18
            __out.Append("                return result;"); //515:1
            __out.AppendLine(false); //515:31
            __out.Append("            }"); //516:1
            __out.AppendLine(false); //516:14
            __out.Append("        }"); //517:1
            __out.AppendLine(false); //517:10
            __out.Append("    }"); //518:1
            __out.AppendLine(false); //518:6
            bool __tmp250_outputWritten = false;
            string __tmp249Prefix = "    "; //520:1
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
                __out.AppendLine(false); //520:27
            }
            bool __tmp253_outputWritten = false;
            string __tmp252Prefix = "    "; //521:1
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
                __out.AppendLine(false); //521:115
            }
            bool __tmp256_outputWritten = false;
            string __tmp257_line = "    public class "; //522:1
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
            string __tmp259_line = "LanguageService : LanguageService"; //522:48
            if (!string.IsNullOrEmpty(__tmp259_line))
            {
                __out.Append(__tmp259_line);
                __tmp256_outputWritten = true;
            }
            if (__tmp256_outputWritten) __out.AppendLine(true);
            if (__tmp256_outputWritten)
            {
                __out.AppendLine(false); //522:81
            }
            __out.Append("    {"); //523:1
            __out.AppendLine(false); //523:6
            __out.Append("        private LanguagePreferences preferences;"); //524:1
            __out.AppendLine(false); //524:49
            bool __tmp261_outputWritten = false;
            string __tmp262_line = "        private "; //525:1
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
            string __tmp264_line = "LanguageScanner scanner;"; //525:47
            if (!string.IsNullOrEmpty(__tmp264_line))
            {
                __out.Append(__tmp264_line);
                __tmp261_outputWritten = true;
            }
            if (__tmp261_outputWritten) __out.AppendLine(true);
            if (__tmp261_outputWritten)
            {
                __out.AppendLine(false); //525:71
            }
            bool __tmp266_outputWritten = false;
            string __tmp267_line = "        public "; //527:1
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
            string __tmp269_line = "LanguageService()"; //527:46
            if (!string.IsNullOrEmpty(__tmp269_line))
            {
                __out.Append(__tmp269_line);
                __tmp266_outputWritten = true;
            }
            if (__tmp266_outputWritten) __out.AppendLine(true);
            if (__tmp266_outputWritten)
            {
                __out.AppendLine(false); //527:63
            }
            __out.Append("        {"); //528:1
            __out.AppendLine(false); //528:10
            __out.Append("			// Creating the config instance"); //529:1
            __out.AppendLine(false); //529:35
            bool __tmp271_outputWritten = false;
            string __tmp270Prefix = "			"; //530:1
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
            string __tmp273_line = "LanguageConfigBase.Instance.ToString();"; //530:34
            if (!string.IsNullOrEmpty(__tmp273_line))
            {
                __out.Append(__tmp273_line);
                __tmp271_outputWritten = true;
            }
            if (__tmp271_outputWritten) __out.AppendLine(true);
            if (__tmp271_outputWritten)
            {
                __out.AppendLine(false); //530:73
            }
            __out.Append("        }"); //531:1
            __out.AppendLine(false); //531:10
            __out.Append("        public override string GetFormatFilterList()"); //533:1
            __out.AppendLine(false); //533:53
            __out.Append("        {"); //534:1
            __out.AppendLine(false); //534:10
            bool __tmp275_outputWritten = false;
            string __tmp276_line = "            return "; //535:1
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
            string __tmp278_line = "LanguageConfig.FilterList;"; //535:50
            if (!string.IsNullOrEmpty(__tmp278_line))
            {
                __out.Append(__tmp278_line);
                __tmp275_outputWritten = true;
            }
            if (__tmp275_outputWritten) __out.AppendLine(true);
            if (__tmp275_outputWritten)
            {
                __out.AppendLine(false); //535:76
            }
            __out.Append("        }"); //536:1
            __out.AppendLine(false); //536:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //538:1
            __out.AppendLine(false); //538:69
            __out.Append("        {"); //539:1
            __out.AppendLine(false); //539:10
            __out.Append("            if (preferences == null)"); //540:1
            __out.AppendLine(false); //540:37
            __out.Append("            {"); //541:1
            __out.AppendLine(false); //541:14
            bool __tmp280_outputWritten = false;
            string __tmp281_line = "                preferences = new LanguagePreferences(this.Site, typeof("; //542:1
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
            string __tmp283_line = "LanguageService).GUID, this.Name);"; //542:103
            if (!string.IsNullOrEmpty(__tmp283_line))
            {
                __out.Append(__tmp283_line);
                __tmp280_outputWritten = true;
            }
            if (__tmp280_outputWritten) __out.AppendLine(true);
            if (__tmp280_outputWritten)
            {
                __out.AppendLine(false); //542:137
            }
            __out.Append("                preferences.Init();"); //543:1
            __out.AppendLine(false); //543:36
            __out.Append("            }"); //544:1
            __out.AppendLine(false); //544:14
            __out.Append("            return preferences;"); //545:1
            __out.AppendLine(false); //545:32
            __out.Append("        }"); //546:1
            __out.AppendLine(false); //546:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //548:1
            __out.AppendLine(false); //548:65
            __out.Append("        {"); //549:1
            __out.AppendLine(false); //549:10
            __out.Append("            if (scanner == null)"); //550:1
            __out.AppendLine(false); //550:33
            __out.Append("            {"); //551:1
            __out.AppendLine(false); //551:14
            bool __tmp285_outputWritten = false;
            string __tmp286_line = "                scanner = new "; //552:1
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
            string __tmp288_line = "LanguageScanner();"; //552:61
            if (!string.IsNullOrEmpty(__tmp288_line))
            {
                __out.Append(__tmp288_line);
                __tmp285_outputWritten = true;
            }
            if (__tmp285_outputWritten) __out.AppendLine(true);
            if (__tmp285_outputWritten)
            {
                __out.AppendLine(false); //552:79
            }
            __out.Append("            }"); //553:1
            __out.AppendLine(false); //553:14
            __out.Append("            return scanner;"); //554:1
            __out.AppendLine(false); //554:28
            __out.Append("        }"); //555:1
            __out.AppendLine(false); //555:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //557:1
            __out.AppendLine(false); //557:96
            __out.Append("        {"); //558:1
            __out.AppendLine(false); //558:10
            bool __tmp290_outputWritten = false;
            string __tmp291_line = "            return new "; //559:1
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
            string __tmp293_line = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //559:54
            if (!string.IsNullOrEmpty(__tmp293_line))
            {
                __out.Append(__tmp293_line);
                __tmp290_outputWritten = true;
            }
            if (__tmp290_outputWritten) __out.AppendLine(true);
            if (__tmp290_outputWritten)
            {
                __out.AppendLine(false); //559:110
            }
            __out.Append("        }"); //560:1
            __out.AppendLine(false); //560:10
            __out.Append("        #region Custom Colors"); //562:1
            __out.AppendLine(false); //562:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //563:1
            __out.AppendLine(false); //563:83
            __out.Append("        {"); //564:1
            __out.AppendLine(false); //564:10
            bool __tmp295_outputWritten = false;
            string __tmp296_line = "            if (index >= 1 && index <= "; //565:1
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
            string __tmp298_line = "LanguageConfig.Instance.ColorableItems.Count)"; //565:70
            if (!string.IsNullOrEmpty(__tmp298_line))
            {
                __out.Append(__tmp298_line);
                __tmp295_outputWritten = true;
            }
            if (__tmp295_outputWritten) __out.AppendLine(true);
            if (__tmp295_outputWritten)
            {
                __out.AppendLine(false); //565:115
            }
            __out.Append("            {"); //566:1
            __out.AppendLine(false); //566:14
            bool __tmp300_outputWritten = false;
            string __tmp301_line = "                item = "; //567:1
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
            string __tmp303_line = "LanguageConfig.Instance.ColorableItems"; //567:54
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
            string __tmp305_line = ";"; //567:107
            if (!string.IsNullOrEmpty(__tmp305_line))
            {
                __out.Append(__tmp305_line);
                __tmp300_outputWritten = true;
            }
            if (__tmp300_outputWritten) __out.AppendLine(true);
            if (__tmp300_outputWritten)
            {
                __out.AppendLine(false); //567:108
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //568:1
            __out.AppendLine(false); //568:64
            __out.Append("            }"); //569:1
            __out.AppendLine(false); //569:14
            __out.Append("            else"); //570:1
            __out.AppendLine(false); //570:17
            __out.Append("            {"); //571:1
            __out.AppendLine(false); //571:14
            bool __tmp307_outputWritten = false;
            string __tmp308_line = "                item = "; //572:1
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
            string __tmp310_line = "LanguageConfig.Instance.ColorableItems"; //572:54
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
            string __tmp312_line = ";"; //572:99
            if (!string.IsNullOrEmpty(__tmp312_line))
            {
                __out.Append(__tmp312_line);
                __tmp307_outputWritten = true;
            }
            if (__tmp307_outputWritten) __out.AppendLine(true);
            if (__tmp307_outputWritten)
            {
                __out.AppendLine(false); //572:100
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //573:1
            __out.AppendLine(false); //573:64
            __out.Append("            }"); //574:1
            __out.AppendLine(false); //574:14
            __out.Append("        }"); //575:1
            __out.AppendLine(false); //575:10
            __out.Append("        public override int GetItemCount(out int count)"); //577:1
            __out.AppendLine(false); //577:56
            __out.Append("        {"); //578:1
            __out.AppendLine(false); //578:10
            bool __tmp314_outputWritten = false;
            string __tmp315_line = "            count = "; //579:1
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
            string __tmp317_line = "LanguageConfig.Instance.ColorableItems.Count;"; //579:51
            if (!string.IsNullOrEmpty(__tmp317_line))
            {
                __out.Append(__tmp317_line);
                __tmp314_outputWritten = true;
            }
            if (__tmp314_outputWritten) __out.AppendLine(true);
            if (__tmp314_outputWritten)
            {
                __out.AppendLine(false); //579:96
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //580:1
            __out.AppendLine(false); //580:60
            __out.Append("        }"); //581:1
            __out.AppendLine(false); //581:10
            __out.Append("        #endregion"); //582:1
            __out.AppendLine(false); //582:19
            __out.Append("        public override void OnIdle(bool periodic)"); //584:1
            __out.AppendLine(false); //584:51
            __out.Append("        {"); //585:1
            __out.AppendLine(false); //585:10
            __out.Append("            // from IronPythonLanguage sample"); //586:1
            __out.AppendLine(false); //586:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //587:1
            __out.AppendLine(false); //587:93
            bool __tmp319_outputWritten = false;
            string __tmp318Prefix = "            "; //588:1
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
            string __tmp321_line = "LanguageSource src = ("; //588:43
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
            string __tmp323_line = "LanguageSource)GetSource(this.LastActiveTextView);"; //588:95
            if (!string.IsNullOrEmpty(__tmp323_line))
            {
                __out.Append(__tmp323_line);
                __tmp319_outputWritten = true;
            }
            if (__tmp319_outputWritten) __out.AppendLine(true);
            if (__tmp319_outputWritten)
            {
                __out.AppendLine(false); //588:145
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //589:1
            __out.AppendLine(false); //589:74
            __out.Append("            {"); //590:1
            __out.AppendLine(false); //590:14
            __out.Append("                src.LastParseTime = 0;"); //591:1
            __out.AppendLine(false); //591:39
            __out.Append("            }"); //592:1
            __out.AppendLine(false); //592:14
            __out.Append("            base.OnIdle(periodic);"); //593:1
            __out.AppendLine(false); //593:35
            __out.Append("        }"); //594:1
            __out.AppendLine(false); //594:10
            __out.Append("        public override string Name"); //596:1
            __out.AppendLine(false); //596:36
            __out.Append("        {"); //597:1
            __out.AppendLine(false); //597:10
            bool __tmp325_outputWritten = false;
            string __tmp326_line = "            get { return "; //598:1
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
            string __tmp328_line = "LanguageConfig.LanguageName; }"; //598:56
            if (!string.IsNullOrEmpty(__tmp328_line))
            {
                __out.Append(__tmp328_line);
                __tmp325_outputWritten = true;
            }
            if (__tmp325_outputWritten) __out.AppendLine(true);
            if (__tmp325_outputWritten)
            {
                __out.AppendLine(false); //598:86
            }
            __out.Append("        }"); //599:1
            __out.AppendLine(false); //599:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //601:1
            __out.AppendLine(false); //601:96
            __out.Append("        {"); //602:1
            __out.AppendLine(false); //602:10
            bool __tmp330_outputWritten = false;
            string __tmp331_line = "            return new "; //603:1
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
            string __tmp333_line = "LanguageViewFilter(mgr, newView);"; //603:54
            if (!string.IsNullOrEmpty(__tmp333_line))
            {
                __out.Append(__tmp333_line);
                __tmp330_outputWritten = true;
            }
            if (__tmp330_outputWritten) __out.AppendLine(true);
            if (__tmp330_outputWritten)
            {
                __out.AppendLine(false); //603:87
            }
            __out.Append("        }"); //604:1
            __out.AppendLine(false); //604:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //606:1
            __out.AppendLine(false); //606:68
            __out.Append("        {"); //607:1
            __out.AppendLine(false); //607:10
            bool __tmp335_outputWritten = false;
            string __tmp336_line = "            return new "; //608:1
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
            string __tmp338_line = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //608:54
            if (!string.IsNullOrEmpty(__tmp338_line))
            {
                __out.Append(__tmp338_line);
                __tmp335_outputWritten = true;
            }
            if (__tmp335_outputWritten) __out.AppendLine(true);
            if (__tmp335_outputWritten)
            {
                __out.AppendLine(false); //608:111
            }
            __out.Append("        }"); //609:1
            __out.AppendLine(false); //609:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //611:1
            __out.AppendLine(false); //611:69
            __out.Append("        {"); //612:1
            __out.AppendLine(false); //612:10
            __out.Append("			try"); //613:1
            __out.AppendLine(false); //613:7
            __out.Append("			{"); //614:1
            __out.AppendLine(false); //614:5
            bool __tmp340_outputWritten = false;
            string __tmp339Prefix = "				"; //615:1
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
            string __tmp342_line = "LanguageSource source = ("; //615:35
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
            string __tmp344_line = "LanguageSource)this.GetSource(req.FileName);"; //615:90
            if (!string.IsNullOrEmpty(__tmp344_line))
            {
                __out.Append(__tmp344_line);
                __tmp340_outputWritten = true;
            }
            if (__tmp340_outputWritten) __out.AppendLine(true);
            if (__tmp340_outputWritten)
            {
                __out.AppendLine(false); //615:134
            }
            __out.Append("				switch (req.Reason)"); //616:1
            __out.AppendLine(false); //616:24
            __out.Append("				{"); //617:1
            __out.AppendLine(false); //617:6
            __out.Append("					case ParseReason.Check:"); //618:1
            __out.AppendLine(false); //618:29
            __out.Append("						// This is where you perform your syntax highlighting."); //619:1
            __out.AppendLine(false); //619:61
            __out.Append("						// Parse entire source as given in req.Text."); //620:1
            __out.AppendLine(false); //620:51
            __out.Append("						// Store results in the AuthoringScope object."); //621:1
            __out.AppendLine(false); //621:53
            __out.Append("						string fileName = Path.GetFileName(req.FileName);"); //622:1
            __out.AppendLine(false); //622:56
            __out.Append("						string outputDir = Path.GetDirectoryName(req.FileName);"); //623:1
            __out.AppendLine(false); //623:62
            if (Properties.GenerateMultipleFiles) //624:8
            {
                bool __tmp346_outputWritten = false;
                string __tmp345Prefix = "						"; //625:1
                StringBuilder __tmp347 = new StringBuilder();
                __tmp347.Append(Properties.LanguageFullName);
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
                string __tmp348_line = "Compiler compiler = new "; //625:36
                if (!string.IsNullOrEmpty(__tmp348_line))
                {
                    __out.Append(__tmp348_line);
                    __tmp346_outputWritten = true;
                }
                StringBuilder __tmp349 = new StringBuilder();
                __tmp349.Append(Properties.LanguageFullName);
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
                string __tmp350_line = "Compiler(req.Text, outputDir, fileName);"; //625:89
                if (!string.IsNullOrEmpty(__tmp350_line))
                {
                    __out.Append(__tmp350_line);
                    __tmp346_outputWritten = true;
                }
                if (__tmp346_outputWritten) __out.AppendLine(true);
                if (__tmp346_outputWritten)
                {
                    __out.AppendLine(false); //625:129
                }
            }
            else //626:8
            {
                bool __tmp352_outputWritten = false;
                string __tmp351Prefix = "						"; //627:1
                StringBuilder __tmp353 = new StringBuilder();
                __tmp353.Append(Properties.LanguageFullName);
                using(StreamReader __tmp353Reader = new StreamReader(this.__ToStream(__tmp353.ToString())))
                {
                    bool __tmp353_last = __tmp353Reader.EndOfStream;
                    while(!__tmp353_last)
                    {
                        string __tmp353_line = __tmp353Reader.ReadLine();
                        __tmp353_last = __tmp353Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp351Prefix))
                        {
                            __out.Append(__tmp351Prefix);
                            __tmp352_outputWritten = true;
                        }
                        if ((__tmp353_last && !string.IsNullOrEmpty(__tmp353_line)) || (!__tmp353_last && __tmp353_line != null))
                        {
                            __out.Append(__tmp353_line);
                            __tmp352_outputWritten = true;
                        }
                        if (!__tmp353_last) __out.AppendLine(true);
                    }
                }
                string __tmp354_line = "Compiler compiler = new "; //627:36
                if (!string.IsNullOrEmpty(__tmp354_line))
                {
                    __out.Append(__tmp354_line);
                    __tmp352_outputWritten = true;
                }
                StringBuilder __tmp355 = new StringBuilder();
                __tmp355.Append(Properties.LanguageFullName);
                using(StreamReader __tmp355Reader = new StreamReader(this.__ToStream(__tmp355.ToString())))
                {
                    bool __tmp355_last = __tmp355Reader.EndOfStream;
                    while(!__tmp355_last)
                    {
                        string __tmp355_line = __tmp355Reader.ReadLine();
                        __tmp355_last = __tmp355Reader.EndOfStream;
                        if ((__tmp355_last && !string.IsNullOrEmpty(__tmp355_line)) || (!__tmp355_last && __tmp355_line != null))
                        {
                            __out.Append(__tmp355_line);
                            __tmp352_outputWritten = true;
                        }
                        if (!__tmp355_last) __out.AppendLine(true);
                    }
                }
                string __tmp356_line = "Compiler(req.Text, fileName);"; //627:89
                if (!string.IsNullOrEmpty(__tmp356_line))
                {
                    __out.Append(__tmp356_line);
                    __tmp352_outputWritten = true;
                }
                if (__tmp352_outputWritten) __out.AppendLine(true);
                if (__tmp352_outputWritten)
                {
                    __out.AppendLine(false); //627:118
                }
            }
            __out.Append("						compiler.GenerateOutput = false;"); //629:1
            __out.AppendLine(false); //629:39
            __out.Append("						compiler.Compile();"); //630:1
            __out.AppendLine(false); //630:26
            __out.Append("						foreach (var msg in compiler.Diagnostics.GetMessages())"); //631:1
            __out.AppendLine(false); //631:62
            __out.Append("						{"); //632:1
            __out.AppendLine(false); //632:8
            __out.Append("							TextSpan span = new TextSpan();"); //633:1
            __out.AppendLine(false); //633:39
            __out.Append("							span.iStartLine = msg.TextSpan.StartLine - 1;"); //634:1
            __out.AppendLine(false); //634:53
            __out.Append("							span.iEndLine = msg.TextSpan.EndLine - 1;"); //635:1
            __out.AppendLine(false); //635:49
            __out.Append("							span.iStartIndex = msg.TextSpan.StartPosition - 1;"); //636:1
            __out.AppendLine(false); //636:58
            __out.Append("							span.iEndIndex = msg.TextSpan.EndPosition - 1;"); //637:1
            __out.AppendLine(false); //637:54
            __out.Append("							Severity severity = Severity.Error;"); //638:1
            __out.AppendLine(false); //638:43
            __out.Append("							switch (msg.Severity)"); //639:1
            __out.AppendLine(false); //639:29
            __out.Append("							{"); //640:1
            __out.AppendLine(false); //640:9
            __out.Append("								case MetaDslx.Compiler.Severity.Error:"); //641:1
            __out.AppendLine(false); //641:47
            __out.Append("									severity = Severity.Error;"); //642:1
            __out.AppendLine(false); //642:36
            __out.Append("									break;"); //643:1
            __out.AppendLine(false); //643:16
            __out.Append("								case MetaDslx.Compiler.Severity.Warning:"); //644:1
            __out.AppendLine(false); //644:49
            __out.Append("									severity = Severity.Warning;"); //645:1
            __out.AppendLine(false); //645:38
            __out.Append("									break;"); //646:1
            __out.AppendLine(false); //646:16
            __out.Append("								case MetaDslx.Compiler.Severity.Info:"); //647:1
            __out.AppendLine(false); //647:46
            __out.Append("									severity = Severity.Hint;"); //648:1
            __out.AppendLine(false); //648:35
            __out.Append("									break;"); //649:1
            __out.AppendLine(false); //649:16
            __out.Append("							}"); //650:1
            __out.AppendLine(false); //650:9
            __out.Append("							req.Sink.AddError(req.FileName, msg.Message, span, severity);"); //651:1
            __out.AppendLine(false); //651:69
            __out.Append("						}"); //652:1
            __out.AppendLine(false); //652:8
            __out.Append("						break;"); //653:1
            __out.AppendLine(false); //653:13
            __out.Append("				}"); //654:1
            __out.AppendLine(false); //654:6
            __out.Append("			}"); //655:1
            __out.AppendLine(false); //655:5
            __out.Append("			catch(Exception ex)"); //656:1
            __out.AppendLine(false); //656:23
            __out.Append("			{"); //657:1
            __out.AppendLine(false); //657:5
            __out.Append("				req.Sink.AddError(req.FileName, \"Error while parsing source: \"+ex.ToString(), new TextSpan(), Severity.Error);"); //658:1
            __out.AppendLine(false); //658:115
            __out.Append("			}"); //659:1
            __out.AppendLine(false); //659:5
            bool __tmp358_outputWritten = false;
            string __tmp359_line = "            return new "; //660:1
            if (!string.IsNullOrEmpty(__tmp359_line))
            {
                __out.Append(__tmp359_line);
                __tmp358_outputWritten = true;
            }
            StringBuilder __tmp360 = new StringBuilder();
            __tmp360.Append(Properties.LanguageClassName);
            using(StreamReader __tmp360Reader = new StreamReader(this.__ToStream(__tmp360.ToString())))
            {
                bool __tmp360_last = __tmp360Reader.EndOfStream;
                while(!__tmp360_last)
                {
                    string __tmp360_line = __tmp360Reader.ReadLine();
                    __tmp360_last = __tmp360Reader.EndOfStream;
                    if ((__tmp360_last && !string.IsNullOrEmpty(__tmp360_line)) || (!__tmp360_last && __tmp360_line != null))
                    {
                        __out.Append(__tmp360_line);
                        __tmp358_outputWritten = true;
                    }
                    if (!__tmp360_last) __out.AppendLine(true);
                }
            }
            string __tmp361_line = "LanguageAuthoringScope();"; //660:54
            if (!string.IsNullOrEmpty(__tmp361_line))
            {
                __out.Append(__tmp361_line);
                __tmp358_outputWritten = true;
            }
            if (__tmp358_outputWritten) __out.AppendLine(true);
            if (__tmp358_outputWritten)
            {
                __out.AppendLine(false); //660:79
            }
            __out.Append("        }"); //661:1
            __out.AppendLine(false); //661:10
            __out.Append("    }"); //662:1
            __out.AppendLine(false); //662:6
            bool __tmp363_outputWritten = false;
            string __tmp364_line = "	public class "; //664:1
            if (!string.IsNullOrEmpty(__tmp364_line))
            {
                __out.Append(__tmp364_line);
                __tmp363_outputWritten = true;
            }
            StringBuilder __tmp365 = new StringBuilder();
            __tmp365.Append(Properties.LanguageClassName);
            using(StreamReader __tmp365Reader = new StreamReader(this.__ToStream(__tmp365.ToString())))
            {
                bool __tmp365_last = __tmp365Reader.EndOfStream;
                while(!__tmp365_last)
                {
                    string __tmp365_line = __tmp365Reader.ReadLine();
                    __tmp365_last = __tmp365Reader.EndOfStream;
                    if ((__tmp365_last && !string.IsNullOrEmpty(__tmp365_line)) || (!__tmp365_last && __tmp365_line != null))
                    {
                        __out.Append(__tmp365_line);
                        __tmp363_outputWritten = true;
                    }
                    if (!__tmp365_last) __out.AppendLine(true);
                }
            }
            string __tmp366_line = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //664:45
            if (!string.IsNullOrEmpty(__tmp366_line))
            {
                __out.Append(__tmp366_line);
                __tmp363_outputWritten = true;
            }
            if (__tmp363_outputWritten) __out.AppendLine(true);
            if (__tmp363_outputWritten)
            {
                __out.AppendLine(false); //664:99
            }
            __out.Append("    {"); //665:1
            __out.AppendLine(false); //665:6
            bool __tmp368_outputWritten = false;
            string __tmp369_line = "        public "; //666:1
            if (!string.IsNullOrEmpty(__tmp369_line))
            {
                __out.Append(__tmp369_line);
                __tmp368_outputWritten = true;
            }
            StringBuilder __tmp370 = new StringBuilder();
            __tmp370.Append(Properties.LanguageClassName);
            using(StreamReader __tmp370Reader = new StreamReader(this.__ToStream(__tmp370.ToString())))
            {
                bool __tmp370_last = __tmp370Reader.EndOfStream;
                while(!__tmp370_last)
                {
                    string __tmp370_line = __tmp370Reader.ReadLine();
                    __tmp370_last = __tmp370Reader.EndOfStream;
                    if ((__tmp370_last && !string.IsNullOrEmpty(__tmp370_line)) || (!__tmp370_last && __tmp370_line != null))
                    {
                        __out.Append(__tmp370_line);
                        __tmp368_outputWritten = true;
                    }
                    if (!__tmp370_last) __out.AppendLine(true);
                }
            }
            string __tmp371_line = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //666:46
            if (!string.IsNullOrEmpty(__tmp371_line))
            {
                __out.Append(__tmp371_line);
                __tmp368_outputWritten = true;
            }
            if (__tmp368_outputWritten) __out.AppendLine(true);
            if (__tmp368_outputWritten)
            {
                __out.AppendLine(false); //666:130
            }
            __out.Append("            : base(service, textLines, colorizer)"); //667:1
            __out.AppendLine(false); //667:50
            __out.Append("        {"); //668:1
            __out.AppendLine(false); //668:10
            __out.Append("        }"); //670:1
            __out.AppendLine(false); //670:10
            __out.Append("    }"); //671:1
            __out.AppendLine(false); //671:6
            bool __tmp373_outputWritten = false;
            string __tmp374_line = "    public class "; //673:1
            if (!string.IsNullOrEmpty(__tmp374_line))
            {
                __out.Append(__tmp374_line);
                __tmp373_outputWritten = true;
            }
            StringBuilder __tmp375 = new StringBuilder();
            __tmp375.Append(Properties.LanguageClassName);
            using(StreamReader __tmp375Reader = new StreamReader(this.__ToStream(__tmp375.ToString())))
            {
                bool __tmp375_last = __tmp375Reader.EndOfStream;
                while(!__tmp375_last)
                {
                    string __tmp375_line = __tmp375Reader.ReadLine();
                    __tmp375_last = __tmp375Reader.EndOfStream;
                    if ((__tmp375_last && !string.IsNullOrEmpty(__tmp375_line)) || (!__tmp375_last && __tmp375_line != null))
                    {
                        __out.Append(__tmp375_line);
                        __tmp373_outputWritten = true;
                    }
                    if (!__tmp375_last) __out.AppendLine(true);
                }
            }
            string __tmp376_line = "LanguageViewFilter : ViewFilter"; //673:48
            if (!string.IsNullOrEmpty(__tmp376_line))
            {
                __out.Append(__tmp376_line);
                __tmp373_outputWritten = true;
            }
            if (__tmp373_outputWritten) __out.AppendLine(true);
            if (__tmp373_outputWritten)
            {
                __out.AppendLine(false); //673:79
            }
            __out.Append("    {"); //674:1
            __out.AppendLine(false); //674:6
            bool __tmp378_outputWritten = false;
            string __tmp379_line = "        public "; //675:1
            if (!string.IsNullOrEmpty(__tmp379_line))
            {
                __out.Append(__tmp379_line);
                __tmp378_outputWritten = true;
            }
            StringBuilder __tmp380 = new StringBuilder();
            __tmp380.Append(Properties.LanguageClassName);
            using(StreamReader __tmp380Reader = new StreamReader(this.__ToStream(__tmp380.ToString())))
            {
                bool __tmp380_last = __tmp380Reader.EndOfStream;
                while(!__tmp380_last)
                {
                    string __tmp380_line = __tmp380Reader.ReadLine();
                    __tmp380_last = __tmp380Reader.EndOfStream;
                    if ((__tmp380_last && !string.IsNullOrEmpty(__tmp380_line)) || (!__tmp380_last && __tmp380_line != null))
                    {
                        __out.Append(__tmp380_line);
                        __tmp378_outputWritten = true;
                    }
                    if (!__tmp380_last) __out.AppendLine(true);
                }
            }
            string __tmp381_line = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //675:46
            if (!string.IsNullOrEmpty(__tmp381_line))
            {
                __out.Append(__tmp381_line);
                __tmp378_outputWritten = true;
            }
            if (__tmp378_outputWritten) __out.AppendLine(true);
            if (__tmp378_outputWritten)
            {
                __out.AppendLine(false); //675:105
            }
            __out.Append("            : base(mgr, view)"); //676:1
            __out.AppendLine(false); //676:30
            __out.Append("        {"); //677:1
            __out.AppendLine(false); //677:10
            __out.Append("        }"); //679:1
            __out.AppendLine(false); //679:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //681:1
            __out.AppendLine(false); //681:150
            __out.Append("        {"); //682:1
            __out.AppendLine(false); //682:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //683:1
            __out.AppendLine(false); //683:59
            __out.Append("            {"); //684:1
            __out.AppendLine(false); //684:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //685:1
            __out.AppendLine(false); //685:57
            __out.Append("                switch (cmd)"); //686:1
            __out.AppendLine(false); //686:29
            __out.Append("                {"); //687:1
            __out.AppendLine(false); //687:18
            __out.Append("                    case VsCommands2K.UP:"); //688:1
            __out.AppendLine(false); //688:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //689:1
            __out.AppendLine(false); //689:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //690:1
            __out.AppendLine(false); //690:50
            __out.Append("                    case VsCommands2K.DOWN:"); //691:1
            __out.AppendLine(false); //691:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //692:1
            __out.AppendLine(false); //692:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //693:1
            __out.AppendLine(false); //693:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //694:1
            __out.Append("\\"); //694:58
            __out.Append("0');"); //694:59
            __out.AppendLine(false); //694:63
            __out.Append("                        return;"); //695:1
            __out.AppendLine(false); //695:32
            __out.Append("                }"); //696:1
            __out.AppendLine(false); //696:18
            __out.Append("            }"); //697:1
            __out.AppendLine(false); //697:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //698:1
            __out.AppendLine(false); //698:105
            __out.Append("        }"); //699:1
            __out.AppendLine(false); //699:10
            __out.Append("    }"); //700:1
            __out.AppendLine(false); //700:6
            __out.Append("}"); //702:1
            __out.AppendLine(false); //702:2
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
