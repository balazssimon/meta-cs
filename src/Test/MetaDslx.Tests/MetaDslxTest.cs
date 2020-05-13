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

        public DebugAssertUnitTest()
        {
            _debugAssertListener = new DebugAssertUnitTestTraceListener();
            _debugAssertListener.AssertUiEnabled = false;
        }

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
