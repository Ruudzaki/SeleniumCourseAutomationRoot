using System;
using Automation.Extensions.Contracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Automation.Extensions.Components
{
    public class WebDriverFactory
    {
        private readonly DriverParams _driverParams;

        public WebDriverFactory(string driverParamsJson)
            : this(LoadParams(driverParamsJson))
        {
        }

        public WebDriverFactory(DriverParams driverParams)
        {
            _driverParams = driverParams;
            if (string.IsNullOrEmpty(driverParams.Binaries) || driverParams.Binaries == ".")
                driverParams.Binaries = Environment.CurrentDirectory;
        }


        /// <summary>
        ///     generates web-driver based on input params
        /// </summary>
        /// <returns>web-driver instance</returns>
        public IWebDriver Get()
        {
            if (!string.Equals(_driverParams.Source, "REMOTE", StringComparison.OrdinalIgnoreCase)) return GetDriver();

            return GetRemoteDriver();
        }

        // local web-drivers
        private IWebDriver GetChrome()
        {
            return new ChromeDriver(_driverParams.Binaries);
        }

        private IWebDriver GetFireFox()
        {
            return new FirefoxDriver(_driverParams.Binaries);
        }

        private IWebDriver GetInternetExplorer()
        {
            return new InternetExplorerDriver(_driverParams.Binaries);
        }

        private IWebDriver GetEdge()
        {
            return new EdgeDriver(_driverParams.Binaries);
        }


        private IWebDriver GetDriver()
        {
            switch (_driverParams.Driver.ToUpper())
            {
                case "EDGE": return GetEdge();
                case "IE": return GetInternetExplorer();
                case "FIREFOX": return GetFireFox();
                case "CHROME":
                default: return GetChrome();
            }
        }

        // remote web-drivers
        private IWebDriver GetRemoteChrome()
        {
            return new RemoteWebDriver(new Uri(_driverParams.Binaries), new ChromeOptions());
        }

        private IWebDriver GetRemoteFireFox()
        {
            return new RemoteWebDriver(new Uri(_driverParams.Binaries), new FirefoxOptions());
        }

        private IWebDriver GetRemoteInternetExplorer()
        {
            return new RemoteWebDriver(new Uri(_driverParams.Binaries), new InternetExplorerOptions());
        }

        private IWebDriver GetRemoteEdge()
        {
            return new RemoteWebDriver(new Uri(_driverParams.Binaries), new EdgeOptions());
        }

        private IWebDriver GetRemoteDriver()
        {
            switch (_driverParams.Driver.ToUpper())
            {
                case "EDGE": return GetRemoteEdge();
                case "IE": return GetRemoteInternetExplorer();
                case "FIREFOX": return GetRemoteFireFox();
                case "CHROME":
                default: return GetRemoteChrome();
            }
        }

        // load json into driver-params object
        private static DriverParams LoadParams(string driverParamsJson)
        {
            // default
            if (string.IsNullOrEmpty(driverParamsJson))
                return new DriverParams {Source = "Local", Driver = "Chrome", Binaries = "."};

            return JsonConvert.DeserializeObject<DriverParams>(driverParamsJson);
        }
    }
}