using OpenQA.Selenium;
using System.Diagnostics;
using TestFrameWorkCore.Helper;
namespace WebDriverHelper.Helper
{

    public class BrowerHelper
    {
        public IWebDriver driver;

        //private static readonly BrowerHelper browerHelper = new BrowerHelper();

        //public static BrowerHelper GetBrowerHellper()
        //{
        //    return browerHelper;
        //}
        public void OpenBrower(string url = null, String browseType = null)
        {

            // neu ko truyen browsertype tu config 
            //nguoc lai su dung cai truyen vao
            if (string.IsNullOrEmpty(browseType))
            {
                browseType = ConfigurationHelper.GetConfig<string>("browser");

            }

            driver = DriverFactoryHelper.InitBrowser(browseType);
            driver.Manage().Window.Maximize();

            int timeout = ConfigurationHelper.GetConfig<int>("timeout");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            if (!string.IsNullOrEmpty(url))
            {
                GotoURL(url);

            }
        }
        public void QuitDriver()
        {
            if (driver is null) return;
            driver.Quit();
        }
        public void GotoURL(string url)
        {
            driver.Navigate().GoToUrl(url);

        }
        public string TakeScreenShotAsBase64()
        {
            // Convert WebDriver object to ITakesScreenshot
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;

            // Take the screenshot
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            return screenshot.AsBase64EncodedString;
        }
    }
}
