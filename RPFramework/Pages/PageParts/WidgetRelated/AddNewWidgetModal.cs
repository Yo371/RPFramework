using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts.WidgetRelated
{
    public class AddNewWidgetModal : PagePart
    {
        public SelectWidgetTypeSection SelectWidgetTypeSection =>
            new SelectWidgetTypeSection(WrappedElement, By.XPath(".//div[contains(@class, 'controls-section')]"));

        public ConfigureWidgetSection ConfigureWidgetSection => new ConfigureWidgetSection(WrappedElement,
            By.XPath(".//div[contains(@class, 'controls-section')]"));

        public SaveSection SaveSection =>
            new SaveSection(WrappedElement, By.XPath(".//div[contains(@class, 'controls-section')]"));
        public AddNewWidgetModal(By by) : base(by)
        {
        }
    }
}