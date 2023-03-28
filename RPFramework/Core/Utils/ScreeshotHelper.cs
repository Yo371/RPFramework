using System;
using System.IO;
using OpenQA.Selenium;

namespace RPFramework.Core.Utils
{
    public static class ScreeshotHelper
    {
        public static string TakeScreenshot()
        {
            //var path = ConfigProvider.GetAssemblyFile(PathConstants.screeshotsPath);
            var path = Constants.ScreeshotsPath;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var screenshotFileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".png";

            var fullPath = Path.Combine(path, screenshotFileName);

            ((ITakesScreenshot)Browser.Instance).GetScreenshot().SaveAsFile(fullPath, ScreenshotImageFormat.Png);

            return fullPath;
        }
    }
}
