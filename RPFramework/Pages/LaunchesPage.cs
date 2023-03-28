using OpenQA.Selenium;
using RPFramework.Pages.PageParts;

namespace RPFramework.Pages
{
    public enum Sections
    {
        Total, Passed, Failed, Skipped, AutoBug, ProductBug, SystemIssue, ToInvestigate
    }

    public class LaunchesPage : BasePage
    {
        public HeaderLaunchesSection HeaderLaunchesSection  => new HeaderLaunchesSection(By.XPath("//div[contains(@class, 'gridHeader')]"));

        public TestLaunch TestLaunch(int sectionNumber) =>
            new TestLaunch(By.XPath($"(.//div[contains(@class, 'gridRow__grid-row-wrapper')])[{sectionNumber}]"));

        /*public TestLaunch TestLaunch(string name, int numberOfLaunch) => new TestLaunch(By.XPath(
            $"//span[contains(text(), '{name}')]/ancestor::div[contains(@class, 'itemInfo__item-info')]" +
            $"//span[contains(@class, 'itemInfo__number')]/parent::a[contains(@href, 'launches/all/{numberOfLaunch}')]" +
            "/ancestor::div[contains(@class, 'gridRow__grid-row-wrapper')]"
        ));*/
        
        public TestLaunch TestLaunch(string name, int numberOfLaunch) => new TestLaunch(By.XPath(
            $"//span[text()='{name}']//following::span[contains(text(),'#')]" +
            $"//following-sibling::text()[.='{numberOfLaunch}']//ancestor::div[contains(@class, 'gridRow__grid-row-wrapper')]"
        ));
    }
}
