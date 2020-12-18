using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public abstract class FluentUi : IFluent
    {
        private readonly IWebDriver _driver;
        private readonly ILogger _logger;

        protected FluentUi(IWebDriver driver, ILogger logger)
        {
            _driver = driver;
            _logger = logger;
        }

        protected FluentUi(IWebDriver driver) 
            : this(driver, new TraceLogger()) { }

        public T ChangeContext<T>() 
        {
            var instance = Create<T>(null);
            _logger.Debug($"instance of [{GetType().FullName}] created");
            return instance;
        }

        public T ChangeContext<T>(ILogger logger)
        {
            return Create<T>(logger);
        }

        public T ChangeContext<T>(string application)
        {
            _driver.Navigate().GoToUrl(application);
            _driver.Manage().Window.Maximize();
            return Create<T>(null);
        }

        public T ChangeContext<T>(string application, ILogger logger) {
            _driver.Navigate().GoToUrl(application);
            _driver.Manage().Window.Maximize();
            return Create<T>(logger);
        }

        private T Create<T>(ILogger logger)
        {
            return logger == null ? (T) Activator.CreateInstance(typeof(T), new object[] { _driver }) 
                                  : (T) Activator.CreateInstance(typeof(T), new object[] { _driver, logger});
        }
    }
}
