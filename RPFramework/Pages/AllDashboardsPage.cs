using OpenQA.Selenium;
using RPFramework.Core;
using RPFramework.Pages.PageParts.WidgetRelated;

namespace RPFramework.Pages
{
    public class AllDashboardsPage : BasePage
    {
        public string Title => new Element(By.XPath("//span[@title='All Dashboards']")).Text;

        public IWebElement DashBoardByName(string name) =>
            new Element(By.XPath($"//a[contains(@class, 'dashboardTable__name') and text() = '{name}']"));

        public IWebElement AddNewWidgetButton =>
            new Element(By.XPath("//span[contains(@class, 'ghostButton') and text() ='Add new widget']/.."));

        public AddNewWidgetModal AddNewWidgetModal =>
            new AddNewWidgetModal(By.XPath("//div[contains(@class, 'modal-window')]"));
        
        public WidgetContainer WidgetContainer(string type, string filter) => new WidgetContainer(
            By.XPath(
                $"//span[text() = '{type}']/../preceding-sibling::div/" +
                $"div[contains(text(), '{filter}')]/ancestor::div[contains(@class, 'widget__widget-container')]/parent::div"));
    }
}
