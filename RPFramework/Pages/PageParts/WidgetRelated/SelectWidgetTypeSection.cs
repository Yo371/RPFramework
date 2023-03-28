using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts.WidgetRelated
{
    public class SelectWidgetTypeSection : PagePart
    {
        public IWebElement RadioButtonByName(string name) =>
            WrappedElement.FindElement(By.XPath($".//div[contains(@class, 'widget-type-item-name') and text() = '{name}']"));

        public IWebElement NextStepButton =>
            WrappedElement.FindElement(
                By.XPath(".//span[contains(@class, 'ghostButton__text') and text() = 'Next step']/.."));

        public SelectWidgetTypeSection(IWebElement webElement, By by) : base(webElement, by)
        {
            
        }
    }
}