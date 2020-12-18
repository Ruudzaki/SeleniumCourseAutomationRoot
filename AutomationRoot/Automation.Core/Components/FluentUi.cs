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
        public IWebDriver Driver { get; }
        public ILogger Logger { get; }

        protected FluentUi(IWebDriver driver, ILogger logger)
        {
            Driver = driver;
            Logger = logger;
        }

        protected FluentUi(IWebDriver driver) 
            : this(driver, new TraceLogger()) { }

        public T ChangeContext<T>() 
        {
            var instance = Create<T>(null);
            Logger.Debug($"instance of [{GetType().FullName}] created");
            return instance;
        }

        public T ChangeContext<T>(ILogger logger)
        {
            return Create<T>(logger);
        }

        public T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null);
        }

        public T ChangeContext<T>(string application, ILogger logger) {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(logger);
        }

        private T Create<T>(ILogger logger)
        {
            return logger == null ? (T) Activator.CreateInstance(typeof(T), new object[] { Driver }) 
                                  : (T) Activator.CreateInstance(typeof(T), new object[] { Driver, logger});
        }
    }
}
