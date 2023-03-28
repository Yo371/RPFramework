using OpenQA.Selenium;
using RPFramework.Core;
using RPFramework.Core.Utils;
using RPFramework.Pages.PageParts;

namespace RPFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver browser;
        public static int LoadTimeout = 3000;

        public SideBar SideBar => new SideBar(By.XPath("//div[contains(@class, 'layout__sidebar-container')]"));

        public IWebElement NitificationContainer =>
            new Element(By.XPath("//div[contains(@class, 'notificationItem__message-container')]"));

        public BasePage()
        {
            browser = Browser.Instance;
        }

        public void SwitchToFrame(IWebElement framWebElement)
        {
            Wait.For(() => framWebElement.Displayed, LoadTimeout);
            browser.SwitchTo().Frame(framWebElement);
        }
    }
}
