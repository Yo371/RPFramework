using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace RPFramework.Core.Utils
{
    public static class ActionsHelper
    {
        public static void ScrollToElement(IWebElement element) => (element as IScrollable)?.ScrollToElement();

        public static void ScrollDown() => ((IJavaScriptExecutor)Browser.Instance).ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        
        public static void MoveToElement(IWebElement element) => (element as IScrollable)?.MoveToElement();

        public static void DragAndDrop(IWebElement element, int offsetX, int offsetY) =>
            (element as IMovable)?.DragAndDropToOffset(offsetX, offsetY);
        
        public static void JsClick(IWebElement element) =>
            ((IJavaScriptExecutor)Browser.Instance).ExecuteScript("arguments[0].click();", element);
    }
}
