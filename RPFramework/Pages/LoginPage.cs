using OpenQA.Selenium;
using RPFramework.Core;

namespace RPFramework.Pages
{
    public class LoginPage : BasePage
    {
        public IWebElement LoginInput => new Element(By.XPath("//input[@name='login']"));

        public IWebElement PasswordInput => new Element(By.XPath("//input[@name='password']"));

        public IWebElement LoginButton => new Element(By.XPath("//button[@type='submit']"));
    }
}
