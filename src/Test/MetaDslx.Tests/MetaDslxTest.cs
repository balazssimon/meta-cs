using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.Tests
{
    public class DebugAssertUnitTest : IDisposable
    {
        protected DebugAssertUnitTestTraceListener _debugAssertListener;

        public DebugAssertUnitTest(bool throwAfterTestFinished = false)
        {
            _debugAssertListener = new DebugAssertUnitTestTraceListener(this.GetType().Name, throwAfterTestFinished);
            _debugAssertListener.AssertUiEnabled = false;
            ThrowAfterTestFinished = throwAfterTestFinished;
        }

        public bool ThrowAfterTestFinished { get; private set; }

        public void Dispose()
        {
            if (_debugAssertListener.AssertionFailures.Count > 0)
            {
                var assertion = _debugAssertListener.AssertionFailures.FirstOrDefault();
                _debugAssertListener.ClearAssertions();
                _debugAssertListener.AllowedFailures.Clear();
                if (assertion != null)
                {
                    Assert.True(false, assertion.DetailedMessage);
                }
            }
            _debugAssertListener.Dispose();
        }
    }
}
