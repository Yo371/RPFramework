using System.Drawing;
using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts.WidgetRelated
{
    public class WidgetContainer : PagePart
    {
        public IWebElement Header =>
            WrappedElement.FindElement(
                By.XPath(".//div[contains(@class, 'widget-header')]"));

        public IWebElement ResizeButton => WrappedElement.FindElement(By.XPath("./span[contains(@class, 'resizable')]"));

        public (string height, string width) GetSize()
        {
            return (WrappedElement.GetCssValue("height"), WrappedElement.GetCssValue("width"));
        }
        
        public WidgetContainer(By by) : base(by)
        {
        }

        public Size Size => WrappedElement.Size;
        
        public Point Location => WrappedElement.Location;
    }
}