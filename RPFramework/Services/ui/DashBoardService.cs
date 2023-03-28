using RPFramework.Core.Utils;
using RPFramework.Pages;
using RPFramework.Pages.PageParts.WidgetRelated;

namespace RPFramework.Services.ui
{
    public class DashBoardService
    {
        private AllDashboardsPage _allDashboardsPage;

        public DashBoardService()
        {
            _allDashboardsPage = new AllDashboardsPage();
        }

        public void CreateWidget(string type, string filter)
        {
            _allDashboardsPage.AddNewWidgetButton.Click();
            _allDashboardsPage.AddNewWidgetModal.SelectWidgetTypeSection.RadioButtonByName(type).Click();
            _allDashboardsPage.AddNewWidgetModal.SelectWidgetTypeSection.NextStepButton.Click();
            _allDashboardsPage.AddNewWidgetModal.ConfigureWidgetSection.Filter(filter).Click();
            _allDashboardsPage.AddNewWidgetModal.ConfigureWidgetSection.NextStepButton.Click();
            _allDashboardsPage.AddNewWidgetModal.SaveSection.AddButton.Click();
            Wait.ForPresence(_allDashboardsPage.WidgetContainer(type,filter).Header);
            ActionsHelper.ScrollToElement(_allDashboardsPage.WidgetContainer(type,filter).Header);
        }
        
        public void ResizeWidget(WidgetContainer widget, int offsetX, int offsetY)
        {
            ActionsHelper.MoveToElement(widget.ResizeButton);
            ActionsHelper.DragAndDrop(widget.ResizeButton, offsetX,offsetY);
        }
    }
}