using RPFramework.Core;
using RPFramework.Pages;
using RPFramework.Services.api;
using RPFramework.Services.ui;

namespace TestsApi.TestsReportPortal.api
{
    public class BaseTest
    {
        protected const string ExpectedDashBoardText = "ALL DASHBOARDS";

        public DashBoardApiService DashBoardApiService =>
            new DashBoardApiService(RestSharpClientFactory.RestSharpReportPortalClient);
        
        public WidgetApiService WidgetApiService =>
            new WidgetApiService(RestSharpClientFactory.RestSharpReportPortalClient);

        protected RpPage RpPage => new RpPage();
        
        protected LoginPage LoginPage => new LoginPage();
        
        protected AllDashboardsPage AllDashboardsPage => new AllDashboardsPage();

        protected LoginService LoginService => new LoginService();
    }
}