using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RPFramework.Core;
using RPFramework.Core.Utils;
using RPFramework.Pages;
using RPFramework.Services;
using RPFramework.Services.ui;

namespace Tests.TestsReportPortal.ui
{
    public partial class BaseTest
    {
        protected RpPage RpPage => new RpPage();

        protected LoginService LoginService => new LoginService();

        protected NavigationService NavigationService => new NavigationService();

        protected LoginPage LoginPage => new LoginPage();

        protected AllDashboardsPage AllDashboardsPage => new AllDashboardsPage();

        protected LaunchesPage LaunchesPage => new LaunchesPage();

        protected LaunchesService LaunchesService => new LaunchesService();
        
        protected DashBoardService DashBoardService => new DashBoardService();

        public void CheckValueOfSection(Sections section, int numberOfSection, string value)
        {
            var testLaunch = LaunchesService.GetTestLaunch(numberOfSection);

            var result = section switch
            {
                Sections.Total => testLaunch.Total.Text.Equals(value),
                Sections.Passed => testLaunch.Passed.Text.Equals(value),
                Sections.Failed => testLaunch.Failed.Text.Equals(value),
                Sections.Skipped => testLaunch.Skipped.Text.Equals(value),
                Sections.AutoBug => testLaunch.AutoBug.Text.Equals(value),
                Sections.ProductBug => testLaunch.ProductBug.Text.Equals(value),
                Sections.SystemIssue => testLaunch.SystemIssue.Text.Equals(value),
                Sections.ToInvestigate => testLaunch.ToInvestigate.Text.Equals(value),
                _ => false
            };
            Assert.True(result, $"Section {section} doesn't have correct value {value}");
        }

        [SetUp]
        public void RunBeforeAnyTest()
        {
            RpPage.Open();
        }

        [TearDown]
        public void RunAfterAnyTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                TestContext.AddTestAttachment(ScreeshotHelper.TakeScreenshot());
            
            Browser.CloseBrowser();
        }
    }
}
