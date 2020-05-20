using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.InternalUtilities
{
    public class CallLogger
    {
        public static readonly CallLogger Instance = new CallLogger();

        private StringBuilder _log;
        private string _indent;

        private CallLogger()
        {
            _log = new StringBuilder();
            _indent = string.Empty;
        }

        [Conditional("DEBUG")]
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

        [Conditional("DEBUG")]
        public void Enter(object data)
        {
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

        [Conditional("DEBUG")]
        public void Exit(object data)
        {
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

        [Conditional("DEBUG")]
        public void Call(object data)
        {
            _log.AppendLine();
            _log.Append(GetMethodName());
            if (data != null)
            {
                _log.Append(": ");
                _log.Append(data);
            }
            _log.AppendLine();
        }

        [Conditional("DEBUG")]
        public void Log(object data)
        {
            if (data != null)
            {
                _log.Append(data);
                _log.AppendLine();
            }
        }
    }
}
