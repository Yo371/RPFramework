using System;
using System.Threading;
using OpenQA.Selenium;
using RPFramework.Core.Configuration;

namespace RPFramework.Core
{
    public class Browser
    {
        private static readonly ThreadLocal<IWebDriver> WebDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver Instance => WebDriver.Value ?? SetUpBrowser();

        private static IWebDriver SetUpBrowser()
        {
            var browserType = ConfigManager.BrowserOptions.BrowserType;
            var driver = browserType switch
            {
                "Chrome" => BrowserFactory.GetChromeDriver(),
                "FireFox" => BrowserFactory.GetFirefoxDriver(),
                "IE" => BrowserFactory.GetEdgeDriver(),
                "Chrome remote" => BrowserFactory.GetRemoteChromeDriver(),
                "Chrome browserstack" => BrowserFactory.GetBrowserStackChromeDriver(),
                _ => throw new ArgumentException()
            };

            var pageLoadTimeout = ConfigManager.BrowserOptions.PageLoadTimeOutMs;
            var jsTimeout = ConfigManager.BrowserOptions.AsyncJsTimeoutMs;
            var implicitTimeout = ConfigManager.BrowserOptions.ImplicitWaitTimeOutMs;

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(pageLoadTimeout);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMilliseconds(jsTimeout);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitTimeout); ;
            WebDriver.Value = driver;
            return driver;
        }

        public static void CloseBrowser()
        {
            WebDriver.Value?.Quit();
            WebDriver.Value = null;
        }
    }
}