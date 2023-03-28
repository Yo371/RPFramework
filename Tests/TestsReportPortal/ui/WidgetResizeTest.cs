using NUnit.Framework;
using RPFramework.Core.Attributes;
using RPFramework.Models.ui;
using RPFramework.Pages.PageParts.WidgetRelated;

namespace Tests.TestsReportPortal.ui
{
    public class WidgetResizeTest : BaseTest
    {
        private WidgetContainer _widgetForResizing;
        
        [SetUp]
        public void SetUp()
        {
            LoginService.Login(UserFactory.GetAdminUser());
            NavigationService.ChooseProject(TestProject);
            AllDashboardsPage.DashBoardByName(DemoDashboard).Click();
        }
        
        [Test, Smoke]
        public void CheckResizeWigdet()
        {
            _widgetForResizing = AllDashboardsPage.WidgetContainer(LaunchesDurationChart, DemoFilter);
            var siblingWidget = AllDashboardsPage.WidgetContainer(LaunchesStatisticsChart, LaunchesStatisticsBar);
            var locationOfSiblingWidgetBefore = siblingWidget.Location;
            var sizeBeforeResizing = _widgetForResizing.Size;

            var sizeOfWidgetHeaderBefore = _widgetForResizing.Header.Size;

            DashBoardService.ResizeWidget(_widgetForResizing, 100, 100);

            var sizeAfterResizing = _widgetForResizing.Size;
            var sizeOfWidgetHeaderAfter = _widgetForResizing.Header.Size;
            var locationOfSiblingWidgetAfter = siblingWidget.Location;
            
            Assert.AreNotEqual(sizeBeforeResizing, sizeAfterResizing);
            Assert.AreNotEqual(sizeOfWidgetHeaderBefore, sizeOfWidgetHeaderAfter);
            Assert.AreNotEqual(locationOfSiblingWidgetBefore, locationOfSiblingWidgetAfter);
        }
        
        [TearDown]
        public void TearDown()
        {
            DashBoardService.ResizeWidget(_widgetForResizing, -100, -100);
        }
    }
}