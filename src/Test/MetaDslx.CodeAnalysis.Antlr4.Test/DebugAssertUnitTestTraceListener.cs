using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    /// <summary>
    /// TraceListener used for trapping assertion failures during unit tests.
    /// </summary>
    public class DebugAssertUnitTestTraceListener : DefaultTraceListener
    {
        /// <summary>
        /// Defines an assertion by the method it failed in and the messages it
        /// provided.
        /// </summary>
        public class Assertion
        {
            /// <summary>
            /// Gets the message provided by the assertion.
            /// </summary>
            public String Message { get; private set; }

            /// <summary>
            /// Gets the detailed message provided by the assertion.
            /// </summary>
            public String DetailedMessage { get; private set; }

            /// <summary>
            /// Gets the name of the method the assertion failed in.
            /// </summary>
            public String MethodName { get; private set; }

            /// <summary>
            /// Creates a new Assertion definition.
            /// </summary>
            /// <param name="message"></param>
            /// <param name="detailedMessage"></param>
            /// <param name="methodName"></param>
            public Assertion(String message, String detailedMessage, String methodName)
            {
                if (methodName == null)
                {
                    throw new ArgumentNullException("methodName");
                }

                Message = message;
                DetailedMessage = detailedMessage;
                MethodName = methodName;
            }

            /// <summary>
            /// Gets a string representation of this instance.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return String.Format("Message: {0}{1}Detail: {2}{1}Method: {3}{1}",
                    Message ?? "<No Message>",
                    Environment.NewLine,
                    DetailedMessage ?? "<No Detail>",
                    MethodName);
            }

            /// <summary>
            /// Tests this object and another object for equality.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                var other = obj as Assertion;

                if (other == null)
                {
                    return false;
                }

                return
                    this.Message == other.Message &&
                    this.DetailedMessage == other.DetailedMessage &&
                    this.MethodName == other.MethodName;
            }

            /// <summary>
            /// Gets a hash code for this instance.
            /// Calculated as recommended at http://msdn.microsoft.com/en-us/library/system.object.gethashcode.aspx
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return
                    MethodName.GetHashCode() ^
                    (DetailedMessage == null ? 0 : DetailedMessage.GetHashCode()) ^
                    (Message == null ? 0 : Message.GetHashCode());
            }
        }

        /// <summary>
        /// Records the assertions that failed.
        /// </summary>
        private readonly List<Assertion> assertionFailures;

        /// <summary>
        /// Gets the assertions that failed since the last call to Clear().
        /// </summary>
        public ReadOnlyCollection<Assertion> AssertionFailures { get { return new ReadOnlyCollection<Assertion>(assertionFailures); } }

        /// <summary>
        /// Gets the assertions that are allowed to fail.
        /// </summary>
        public List<Assertion> AllowedFailures { get; private set; }

        /// <summary>
        /// Creates a new instance of this trace listener with the default name
        /// DebugAssertUnitTestTraceListener.
        /// </summary>
        public DebugAssertUnitTestTraceListener() : this("DebugAssertUnitTestListener") { }

        /// <summary>
        /// Creates a new instance of this trace listener with the specified name.
        /// </summary>
        /// <param name="name"></param>
        public DebugAssertUnitTestTraceListener(String name) : base()
        {
            AssertUiEnabled = false;
            Name = name;
            AllowedFailures = new List<Assertion>();
            assertionFailures = new List<Assertion>();
        }

        /// <summary>
        /// Records assertion failures.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="detailMessage"></param>
        public override void Fail(string message, string detailMessage)
        {
            var failure = new Assertion(message, detailMessage, GetAssertionMethodName());

            if (!AllowedFailures.Contains(failure))
            {
                assertionFailures.Add(failure);
            }
        }

        /// <summary>
        /// Records assertion failures.
        /// </summary>
        /// <param name="message"></param>
        public override void Fail(string message)
        {
            Fail(message, null);
        }

        /// <summary>
        /// Gets rid of any assertions that have been recorded.
        /// </summary>
        public void ClearAssertions()
        {
            assertionFailures.Clear();
        }

        /// <summary>
        /// Gets the full name of the method that causes the assertion failure.
        /// 
        /// Credit goes to John Robbins of Wintellect for the code in this method,
        /// which was taken from his excellent SuperAssertTraceListener.
        /// </summary>
        /// <returns></returns>
        private String GetAssertionMethodName()
        {
            StackTrace stk = new StackTrace();
            int i = 0;
            for (; i < stk.FrameCount; i++)
            {
                StackFrame frame = stk.GetFrame(i);
                MethodBase method = frame.GetMethod();
                if (null != method)
                {
                    if (method.ReflectedType.ToString().Equals("System.Diagnostics.Debug"))
                    {
                        if (method.Name.Equals("Assert") || method.Name.Equals("Fail"))
                        {
                            i++;
                            break;
                        }
                    }
                }
            }

            // Now walk the stack but only get the real parts.
            stk = new StackTrace(i, true);

            // Get the fully qualified name of the method that made the assertion.
            StackFrame hitFrame = stk.GetFrame(0);
            StringBuilder sbKey = new StringBuilder();
            sbKey.AppendFormat("{0}.{1}",
                                 hitFrame.GetMethod().ReflectedType.FullName,
                                 hitFrame.GetMethod().Name);
            return sbKey.ToString();
        }
    }
}
