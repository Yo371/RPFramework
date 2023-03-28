using NUnit.Framework;
using RPFramework.Core;
using RPFramework.Models.ui;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BDDProject.Steps
{
    [Binding]
    public class ReportPortalSteps : BaseTest
    {
        private ScenarioContext _scenarioContext;

        public ReportPortalSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [Given(@"Report portal page is opened")]
        public void GivenReportPortalPageIsOpened()
        {
            RpPage.Open();
        }

        [Given(@"User is logged in Report portal")]
        public void GivenUserIsLoggedInReportPortal()
        {
            LoginService.Login(UserFactory.GetAdminUser());
        }
        
        [Given(@"Project '(.*)' is chosen")]
        public void GivenProjectIsChosen(string testproject)
        {
            NavigationService.ChooseProject(testproject);
        }

        [Then(@"All Dashboards page is opened")]
        public void ThenAllDashboardsPageIsOpened()
        {
            Assert.AreEqual(ExpectedDashBoardText, AllDashboardsPage.Title, "Dashboard page is not opened!");
        }

        [Then(@"Choose '(.*)' dashboard")]
        public void ThenChooseDashboard(string dashBoard)
        {
           AllDashboardsPage.DashBoardByName(dashBoard).Click();
        }
        
        [Then(@"Create new widget with (.*) type and '(.*)' filter")]
        public void ThenCreateNewWidgetWithTypeAndFilter(string type, string filter)
        {
            DashBoardService.CreateWidget(type, filter);
            _scenarioContext.Add(KeyFilter, filter);
        }
        
        [Then(@"The new widget is created with (.*) type on All Dashboards page")]
        public void ThenTheNewWidgetIsCreatedWithTypeOnAllDashboardsPage(string type)
        {
            Assert.IsTrue(AllDashboardsPage.WidgetContainer(type, _scenarioContext.Get<string>(KeyFilter)).Header.Displayed);
        }

        [Given(@"Launches page of project '(.*)' is opened")]
        public void LaunchesPageOfProjectIsOpened(string testproject)
        {
            NavigationService.GoToLaunchesPageByProjectName(testproject);
        }

        [Then(@"Launch with name '(.*)' number (.*) consists data")]
        public void LaunchWithNameNumberConsistsData(string lauchName, int numberOfLaunch, Table table)
        {
            var actualTestLaunch = LaunchesService.GetTestLaunch(lauchName, numberOfLaunch).ToTestLaunchModel();
            var expectedTestLauch = table.CreateInstance<TestLaunchModel>();
            
            Assert.AreEqual(expectedTestLauch, actualTestLaunch, "Launch doesn't have expected data!");
        }
        
        [AfterScenario]
        public static void AfterScenario()
        {
            Browser.CloseBrowser();
        }
    }
}