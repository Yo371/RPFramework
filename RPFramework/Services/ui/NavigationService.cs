
using RPFramework.Pages;

namespace RPFramework.Services.ui
{
    public class NavigationService
    {
        private readonly LaunchesPage _launchesPage;

        private readonly AllDashboardsPage _allDashboardsPage;

        public NavigationService()
        {
            _launchesPage = new LaunchesPage();
            _allDashboardsPage = new AllDashboardsPage();
        }

        public LaunchesPage GoToLaunchesPageByProjectName(string projectName)
        {
            ChooseProject(projectName);
            _allDashboardsPage.SideBar.LaunchesIcon.Click();
            return _launchesPage;
        }

        public void ChooseProject(string projectName)
        {
            _allDashboardsPage.SideBar.ProjectsIcon.Click();
            _allDashboardsPage.SideBar.ProjectByName(projectName).Click();
        }
    }
}
