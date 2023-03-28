using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts
{
    public class SaveSection : PagePart
    {
        public IWebElement AddButton => WrappedElement.FindElement(By.XPath(".//button[text() = 'Add']"));
        public SaveSection(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}