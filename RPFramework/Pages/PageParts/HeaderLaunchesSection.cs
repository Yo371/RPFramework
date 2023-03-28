using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts
{
    public class HeaderLaunchesSection : PagePart
    {
        public IWebElement Total => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'total']"));

        public IWebElement Passed => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'passed']"));

        public IWebElement Failed => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'failed']"));

        public IWebElement Skipped => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'skipped']"));

        public IWebElement ProductBug => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'product bug']"));

        public IWebElement AutoBug => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'auto bug']"));

        public IWebElement SystemIssue => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'system issue']"));

        public IWebElement ToInvestigate => WrappedElement.FindElement(By.XPath(".//*[contains(@class, 'headerCell__title-full') and text() = 'to investigate']"));

        public HeaderLaunchesSection(By by) : base(by)
        {
        }
    }
}
