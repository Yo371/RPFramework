using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using RPFramework.Core.Configuration;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace RPFramework.Core
{
    internal class BrowserFactory
    {
        public static IWebDriver GetChromeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(),
                VersionResolveStrategy.MatchingBrowser);
            return new ChromeDriver();
        }

        public static IWebDriver GetFirefoxDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public static IWebDriver GetEdgeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            return new EdgeDriver();
        }

        public static IWebDriver GetRemoteChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(),
                VersionResolveStrategy.MatchingBrowser);
            
            return new RemoteWebDriver(new Uri(ConfigManager.BrowserOptions.SeleniumGridAddress), chromeOptions);
        }
        
        public static IWebDriver GetBrowserStackChromeDriver()
        {
            ChromeOptions capabilities = new ChromeOptions();
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("browserVersion", "latest");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("seleniumVersion", "3.14.0");
            browserstackOptions.Add("userName", "testprotestpro_S7p1Nj");
            browserstackOptions.Add("accessKey", "yqMBmSBYBJ9ycmcZjzhz");
            browserstackOptions.Add("browserName", "Chrome");

            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);
            
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(),
                VersionResolveStrategy.MatchingBrowser);
            
            return new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), capabilities);
        }
    }
}