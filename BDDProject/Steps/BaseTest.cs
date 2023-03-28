using RPFramework.Pages;
using RPFramework.Services;
using RPFramework.Services.ui;

namespace BDDProject.Steps
{
    public class BaseTest
    {
        protected const string ExpectedDashBoardText = "ALL DASHBOARDS";

        protected const string KeyFilter = "Filter";
        protected LoginService LoginService => new LoginService();
        
        protected LaunchesService LaunchesService => new LaunchesService();
        
        protected DashBoardService DashBoardService => new DashBoardService();
        
        protected NavigationService NavigationService => new NavigationService();

        protected RpPage RpPage => new RpPage();
        
        protected AllDashboardsPage AllDashboardsPage => new AllDashboardsPage();
    }
}