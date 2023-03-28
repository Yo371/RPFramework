using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts.WidgetRelated
{
    public class ConfigureWidgetSection : PagePart
    {
        
        public IWebElement NextStepButton =>
            WrappedElement.FindElement(
                By.XPath(".//span[contains(@class, 'ghostButton__text') and text() = 'Next step']/.."));

        public IWebElement Filter(string name) => WrappedElement.FindElement(By.XPath(
            $".//span[contains(@class, 'filterName__name') and text() = '{name}']/ancestor::span[contains(@class, 'inputRadio')]"));
        
        public ConfigureWidgetSection(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}