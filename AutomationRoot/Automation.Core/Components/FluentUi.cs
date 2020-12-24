﻿using System;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Core.Components
{
    public abstract class FluentUi : FluentBase
    {
        public FluentUi(IWebDriver driver, ILogger logger) : base(logger)
        {
            Driver = driver;
        }

        public FluentUi(IWebDriver driver)
            : this(driver, new TraceLogger())
        {
        }

        public IWebDriver Driver { get; }

        public override T ChangeContext<T>(string application)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(null);
        }

        public override T ChangeContext<T>(string application, ILogger logger)
        {
            Driver.Navigate().GoToUrl(application);
            Driver.Manage().Window.Maximize();
            return Create<T>(logger);
        }

        internal override T Create<T>(ILogger logger)
        {
            return logger == null
                ? (T) Activator.CreateInstance(typeof(T), new object[] { Driver })
                : (T) Activator.CreateInstance(typeof(T), new object[] { Driver, logger } );
        }
    }
}