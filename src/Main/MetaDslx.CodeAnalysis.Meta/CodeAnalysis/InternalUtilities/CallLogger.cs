using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.InternalUtilities
{
    public class CallLogger
    {
        public static readonly CallLogger Instance = new CallLogger();

        public static bool Enabled = false;

        private StringBuilder _log;
        private string _indent;

        private CallLogger()
        {
            _log = new StringBuilder();
            _indent = string.Empty;
        }

        [Conditional("TRACE")]
        public void Clear()
        {
            _log.Clear();
        }

        public string GetLog()
        {
            return _log.ToString();
        }

        private string GetMethodName()
        {
            var stackTrace = new StackTrace(2, true);
            StackFrame callerFrame = stackTrace.GetFrame(0);
            var typeName = callerFrame.GetMethod().ReflectedType.FullName;
            var methodName = callerFrame.GetMethod().Name;
            return $"{typeName}.{methodName}()";
        }

        [Conditional("TRACE")]
        public void Enter(object data)
        {
            if (!Enabled) return;
            _log.AppendLine();
            _log.Append(_indent);
            _log.Append("-> ");
            _log.Append(GetMethodName());
            if (data != null)
            {
                _log.Append(": ");
                _log.Append(data);
            }
            _log.AppendLine();
            _indent += "  ";
        }

        [Conditional("TRACE")]
        public void Exit(object data)
        {
            if (!Enabled) return;
            if (_indent.Length >= 2) _indent = _indent.Substring(2);
            else _indent = string.Empty;
            _log.Append(_indent);
            _log.Append("<- ");
            _log.Append(GetMethodName());
            if (data != null)
            {
                _log.Append(": ");
                _log.Append(data);
            }
            _log.AppendLine();
        }

        [Conditional("TRACE")]
        public void Call(object data)
        {
            if (!Enabled) return;
            _log.AppendLine();
            _log.Append(GetMethodName());
            if (data != null)
            {
                _log.Append(": ");
                _log.Append(data);
            }
            _log.AppendLine();
        }

        [Conditional("TRACE")]
        public void Log(object data)
        {
            if (!Enabled) return;
            if (data != null)
            {
                _log.Append(data);
                _log.AppendLine();
            }
        }
    }
}
