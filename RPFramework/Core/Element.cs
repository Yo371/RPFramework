using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RPFramework.Core.Utils;
using SeleniumExtras.WaitHelpers;

namespace RPFramework.Core
{
    public interface IScrollable
    {
        void ScrollToElement();
        void MoveToElement();
    }
    
    public interface IMovable
    {
        void DragAndDropToOffset(int offsetX, int offsetY);
    }

    public class Element : IWebElement, IScrollable, IMovable
    {
        protected const double DefaultTimeOutMs = 20000;

        private readonly Lazy<IWebElement> _lazy;

        protected IWebElement WrappedElement => _lazy.Value;

        private readonly By _by;

        public Element(By by)
        {
            _lazy = new Lazy<IWebElement>(FindFuncInitialize(by));
            _by = by;
        }
        
        public Element(IWebElement element, By by)
        {
            _lazy = new Lazy<IWebElement>(FindFuncChainInitializeExternalElement(element, by));
            _by = by;
        }

        private Element(Func<IWebElement> findFunction, By by)
        {
            _lazy = new Lazy<IWebElement>(findFunction);
            _by = by;
        }

        public IWebElement FindElement(By by)
        {
            return new Element(FindFuncChainInitialize(by), by);
        }

        private Func<IWebElement> FindFuncInitialize(By by) => () =>
        {
            Wait.For(() => Browser.Instance.FindElement(by).Displayed, DefaultTimeOutMs);
            return Browser.Instance.FindElement(by);
        };

        private Func<IWebElement> FindFuncChainInitialize(By by) => () =>
        {
            Wait.ForPresence(WrappedElement.FindElement(by), DefaultTimeOutMs);
            return WrappedElement.FindElement(by);
        };
        
        private Func<IWebElement> FindFuncChainInitializeExternalElement(IWebElement element, By by) => () =>
        {
            Wait.ForPresence(element.FindElement(by), DefaultTimeOutMs);
            return element.FindElement(by);
        };

        public ReadOnlyCollection<IWebElement> FindElements(By by) => WrappedElement.FindElements(by);

        private void WaitForPresence(double timeOut = DefaultTimeOutMs)
        {
            Wait.Explicit().Until(ExpectedConditions.ElementExists(_by));
            Wait.Explicit().Until(ExpectedConditions.ElementIsVisible(_by));
        }

        public void Clear()
        {
            WaitForPresence();
            Reporter.Log($"==> Clear input {WrappedElement.GetAttribute("name")}");
            WrappedElement.Clear();
        }

        public void SendKeys(string text)
        {
            WaitForPresence();
            Reporter.Log($"==> Send {text} to input {WrappedElement.GetAttribute("name")}");
            WrappedElement.SendKeys(text);
        }

        public void Submit() => WrappedElement.Submit();

        public void Click()
        {
            WaitForPresence();
            Wait.Explicit().Until(ExpectedConditions.ElementToBeClickable(_by));
            Reporter.Log($"==> Click on {_by}");
            WrappedElement.Click();
        }

        public void ScrollToElement() =>
            ((IJavaScriptExecutor)Browser.Instance).ExecuteScript("arguments[0].scrollIntoView(true);",
               WrappedElement );

        public void MoveToElement() => new Actions(Browser.Instance).MoveToElement(WrappedElement).Build().Perform();

        public string GetAttribute(string attributeName) => WrappedElement.GetAttribute(attributeName);

        public string GetDomAttribute(string attributeName) => WrappedElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => WrappedElement.GetDomProperty(propertyName);

        public string GetCssValue(string propertyName) => WrappedElement.GetCssValue(propertyName);
        public ISearchContext GetShadowRoot() => WrappedElement.GetShadowRoot();

        public string TagName => WrappedElement.TagName;
        public string Text => WrappedElement.Text;
        public bool Enabled => WrappedElement.Enabled;
        public bool Selected => WrappedElement.Selected;    
        public Point Location => WrappedElement.Location;
        public Size Size => WrappedElement.Size;
        public bool Displayed => WrappedElement.Displayed;

        public void DragAndDropToOffset(int offsetX, int offsetY) => new Actions(Browser.Instance)
            .DragAndDropToOffset(WrappedElement, offsetX, offsetY).Build().Perform();
    }
}
