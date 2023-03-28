using RPFramework.Pages;

namespace Tests.TestsReportPortal.ui
{
    public partial class BaseTest
    {
        protected const string ExpectedDashBoardText = "ALL DASHBOARDS";
        protected const string DemoDashboard = "DEMO DASHBOARD";

        protected const string TestProject = "testproject";

        protected const string DemoApiTestLaunch = "Demo Api Tests";
        
        protected const string LaunchesDurationChart = "Launches duration chart";
        protected const string LaunchesStatisticsChart = "Launch statistics chart";
        protected const string DemoFilter = "DEMO_FILTER_820";
        protected const string LaunchesStatisticsBar = "LAUNCH STATISTICS BAR";

        protected const int NumberOfLaunch = 2;

        protected const int NumberOfSection = 5;

        protected static readonly object[] TestDataCheckLaunchSection =
        {
            new object[] { Sections.Total, "15",},
            new object[] { Sections.Passed, "5",},
            new object[] { Sections.Failed, "9",},
            new object[] { Sections.Skipped, "1",},
            new object[] { Sections.ProductBug, "1",},
            new object[] { Sections.AutoBug, "5",},
            new object[] { Sections.SystemIssue, "4",},
            new object[] { Sections.ToInvestigate, "8",},
        };

        protected static readonly object[] TestDataCheckSuite =
        {
            new object[] { Sections.Total, "8", 4},
            new object[] { Sections.Passed, "5", 4},
            new object[] { Sections.Failed, "3", 4},
            new object[] { Sections.Skipped, "1", 6},
            new object[] { Sections.ProductBug, "1", 6},
            new object[] { Sections.AutoBug, "4", 6},
            new object[] { Sections.SystemIssue, "1", 1},
            new object[] { Sections.ToInvestigate, "3", 4},
        };
    }
}
