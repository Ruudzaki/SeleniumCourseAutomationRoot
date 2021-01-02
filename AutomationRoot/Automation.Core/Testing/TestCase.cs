using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Extensions.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation.Core.Testing
{
    public abstract class TestCase
    {
        private int _attempts;

        private ILogger _logger;

        // fields
        private IDictionary<string, object> _testParams;

        protected TestCase()
        {
            _testParams = new Dictionary<string, object>();
            _attempts = 1;
            _logger = new TraceLogger();
        }

        // properties
        public bool Actual { get; private set; }
        public IWebDriver Driver { get; private set; }
        public HttpClient HttpClient { get; private set; }

        // components
        public abstract bool AutomationTest(IDictionary<string, object> testParams);

        public TestCase Execute()
        {
            for (var i = 0; i < _attempts; i++)
            {
                Setup();
                try
                {
                    Actual = AutomationTest(_testParams);
                    if (Actual) break;

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

        // factory
        public IFluent CreateFluentApi(string type)
        {
            // extract type
            var t = Utilities.GetTypeByName(type);

            // extract constructors
            var ctr = t.GetConstructors();

            // setup conditions
            var isFluent = typeof(FluentBase).IsAssignableFrom(t);
            var isRest = isFluent && ctr.Any(i => i.GetParameters().Any(p => p.ParameterType == typeof(HttpClient)));
            var isFront = isFluent && ctr.Any(i => i.GetParameters().Any(p => p.ParameterType == typeof(IWebDriver)));

            // factoring
            if (isRest)
            {
                return (IFluent)Activator.CreateInstance(t, new object[] { HttpClient, _logger });
            }
            else if (isFront)
            {
                return (IFluent)Activator.CreateInstance(t, new object[] { Driver, _logger });
            }
            throw new NotFoundException($"implementation of {type} was not found");
        }

        // setup
        private void Setup()
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
            else
            {
                _testParams[DRIVER] = string.Empty;
            }
            if ($"{_testParams[DRIVER]}".Equals("HTTP", StringComparison.OrdinalIgnoreCase))
            {
                HttpClient = new HttpClient();
                return;
            }

            // create driver
            Driver = new WebDriverFactory(driverParams).Get();
        }
    }
}