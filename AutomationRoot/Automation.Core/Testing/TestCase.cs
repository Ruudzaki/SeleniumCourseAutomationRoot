using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Logging;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        // fields
        private IDictionary<string, object> _testParams;
        private int _attempts;
        private ILogger _logger;

        // components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);

        public TestCase Execute()
        {
            return this;
        }

        // configuration
        public TestCase WithTestParams(IDictionary<string, object> testParams)
        {
            _testParams = testParams;
            return this;
        }

        public TestCase WithNumberOfAttempts(int numberOfAttempts)
        {
            _attempts = numberOfAttempts;
            return this;
        }

        public TestCase WithLogger(ILogger logger)
        {
            _logger = logger;
            return this;
        }
    }
}

