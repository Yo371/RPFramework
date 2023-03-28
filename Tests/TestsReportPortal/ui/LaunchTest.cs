using NUnit.Framework;
using RPFramework.Core.Attributes;
using RPFramework.Models.ui;
using RPFramework.Pages;

namespace Tests.TestsReportPortal.ui
{
    [Parallelizable(ParallelScope.Children)]
    internal class LaunchTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginService.Login(UserFactory.GetAdminUser());
            NavigationService.GoToLaunchesPageByProjectName(BaseTest.TestProject);
        }

        [Test, Smoke]
        [TestCaseSource(nameof(TestDataCheckLaunchSection))]
        public void CheckLaunchSection(Sections section, string value)
        {
            CheckValueOfSection(section, NumberOfSection, value);
        }

        [Test, Smoke]
        [TestCaseSource(nameof(TestDataCheckSuite))]
        public void CheckSuiteSection(Sections section, string value, int numberOfSection)
        {
            LaunchesService.ExpandTestLauch(DemoApiTestLaunch, NumberOfLaunch);

            CheckValueOfSection(section, numberOfSection, value);
        }
    }
}
