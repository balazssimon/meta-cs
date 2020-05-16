using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;

namespace MetaDslx.Tests
{
    public class WrappedXunitException : XunitException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="WrappedXunitException"/> class.
        /// </summary>
        public WrappedXunitException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrappedXunitException"/> class.
        /// </summary>
        /// <param name="userMessage">The user message to be displayed</param>
        public WrappedXunitException(string userMessage)
            : this(userMessage, (Exception)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrappedXunitException"/> class.
        /// </summary>
        /// <param name="userMessage">The user message to be displayed</param>
        /// <param name="innerException">The inner exception</param>
        public WrappedXunitException(string userMessage, Exception innerException)
            : base($"{userMessage}\r\n{innerException.Message}", innerException?.StackTrace)
        {
            UserMessage = userMessage;
        }

    }
}
