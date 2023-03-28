using RPFramework.Core.Utils;
using RPFramework.Pages;
using RPFramework.Pages.PageParts;

namespace RPFramework.Services.ui
{
    public class LaunchesService
    {

        private readonly LaunchesPage _launchesPage;
        public LaunchesService()
        {
            _launchesPage = new LaunchesPage();
        }

        public TestLaunch GetTestLaunch(int numberOfSection)
        {
            var testLaunch = _launchesPage.TestLaunch(numberOfSection);
            ActionsHelper.ScrollToElement(testLaunch.Title);
            return testLaunch;
        }

        public TestLaunch GetTestLaunch(string name, int numberOfLaunch)
        {
            var testLaunch = _launchesPage.TestLaunch(name, numberOfLaunch); ;
            ActionsHelper.ScrollToElement(testLaunch.Title);
            return testLaunch;
        }

        public void ExpandTestLauch(string name, int numberOfLaunch) =>
            GetTestLaunch(name, numberOfLaunch).Title.Click();
    }
}
