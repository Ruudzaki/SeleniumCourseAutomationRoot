using System;
using System.Collections.Generic;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        // fields
        private IDictionary<string, object> _testParams;
        private int _attempts;
        private ILogger _logger;

        // properties
        public bool Actual { get; private set; }
        public IWebDriver Driver { get; private set; }

        protected TestCase()
        {
            _testParams = new Dictionary<string, object>();
            _attempts = 1;
            _logger = new TraceLogger();
        }

        // components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);

        public TestCase Execute()
        {
            Driver = Get();

            for (int i = 0; i < _attempts; i++)
            {
                try
                {
                    Actual = AutomationTest(_testParams);
                    if (Actual)
                    {
                        break;
                    }

                    _logger.Debug($"{GetType()?.FullName} failed on attempt [{i + 1}]");
                }
                catch (NotImplementedException ex)
                {
                    _logger.Debug(ex, ex.Message);
                    break;
                }
                catch (AssertInconclusiveException ex)
                {
                    _logger.Debug(ex, ex.Message);
                    break;
                }
                catch (Exception ex)
                {
                    _logger.Debug(ex, ex.Message);
                }
                finally
                {
                    Driver?.Close();
                    Driver?.Dispose();
                }
            }
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

        // setup
        private IWebDriver Get()
        {
            // constants
            const string DRIVER = "driver";

            // default
            var driverParams = new DriverParams {Binaries = ".", Driver = "CHROME"};

            //change driver if exist
            if (_testParams?.ContainsKey(DRIVER) == true)
            {
                driverParams.Driver = $"{_testParams[DRIVER]}";
            }

            // create driver
            return new WebDriverFactory(driverParams).Get();
        }
    }
}

