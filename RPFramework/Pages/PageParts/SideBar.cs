using OpenQA.Selenium;

namespace RPFramework.Pages.PageParts
{
    public class SideBar : PagePart
    {
        private string _projectLocatorBase = ".//div[contains(@class, 'projectSelector__project-selector')]";

        public IWebElement LaunchesIcon =>
            WrappedElement.FindElement(By.XPath(".//aside//a[contains(@href, 'launches')]"));

        public IWebElement UserBlock => WrappedElement.FindElement(By.XPath(".//div[contains(@class, 'userBlock__user-block')]"));

        public IWebElement ProjectsIcon =>
            WrappedElement.FindElement(By.XPath(_projectLocatorBase));

        public IWebElement ProjectByName(string projectName) =>
            WrappedElement.FindElement(By.XPath($"{_projectLocatorBase}//div[contains(@class, 'projects-list')]//a[@href='#{projectName}']"));

        public SideBar(By by) : base(by)
        {
        }
    }
}
