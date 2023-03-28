using RPFramework.Core.Utils;
using SeleniumExtras.WaitHelpers;

namespace RPFramework.Pages
{
    public class RpPage : BasePage
    {
        protected static string Url = "http://host.docker.internal:8080/";

        public RpPage Open()
        {
            browser.Navigate().GoToUrl(Url);
            Wait.Explicit().Until(ExpectedConditions.UrlContains(Url));
            return this;   
        }
    }
}

