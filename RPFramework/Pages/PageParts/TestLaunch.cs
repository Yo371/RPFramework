using OpenQA.Selenium;
using RPFramework.Models;
using RPFramework.Models.ui;

namespace RPFramework.Pages.PageParts
{
    public class TestLaunch : PagePart
    {
        public IWebElement Total => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__total')]//a[contains(@class, 'executionStatistics')]"));

        public IWebElement Passed => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__passed')]//a[contains(@class, 'executionStatistics')]"));

        public IWebElement Failed => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__failed')]//a[contains(@class, 'executionStatistics')]"));

        public IWebElement Skipped => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__skipped')]//a[contains(@class, 'executionStatistics')]"));

        public IWebElement ProductBug => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__pb')]//div[contains(@class, 'donutChart__total')]"));

        public IWebElement AutoBug => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__ab')]//div[contains(@class, 'donutChart__total')]"));

        public IWebElement SystemIssue => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__si')]//div[contains(@class, 'donutChart__total')]"));

        public IWebElement ToInvestigate => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'launchSuiteGrid__ti')]//div[contains(@class, 'donutChart__total')]"));

        public IWebElement Title => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'itemInfo__name')]"));

        public TestLaunch(By by) : base(by)
        {
        }

        public TestLaunchModel ToTestLaunchModel()
        {
            return new TestLaunchModel()
            {
                Title = Title.Text,
                Total = Total.Text,
                Passed = Passed.Text,
                Failed = Failed.Text,
                Skipped = Skipped.Text,
                ProductBug = ProductBug.Text,
                AutoBug = AutoBug.Text,
                SystemIssue = SystemIssue.Text,
                ToInvestigate = ToInvestigate.Text
            };
        }
    }
}
