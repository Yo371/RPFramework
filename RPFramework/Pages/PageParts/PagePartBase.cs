using OpenQA.Selenium;
using RPFramework.Core;

namespace RPFramework.Pages.PageParts
{
    public class PagePart
    {
        protected IWebElement WrappedElement;

        public PagePart(By by)
        {
            WrappedElement = new Element(by);
        }
        
        public PagePart(IWebElement webElement, By by)
        {
            WrappedElement = new Element(webElement, by);
        }
    }
}
