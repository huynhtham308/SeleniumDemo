using OpenQA.Selenium;

namespace SimpleSeleniumTest.Page
{
    public class DashBoardPage : BasePage
    {
        // Define xpath 
        private By xpathDashboardlb = By.XPath("//h6[text() = 'Dashboard'] | //a[contains(text(),'Logout')]");
        private By xpathTimeatWorkWidget = By.XPath("//p[contains(.,'Time at Work')]");
        private By xpathMyActionWidget = By.XPath("//p[contains(.,'My Actions')]");
        private By xpathQuickLaunchWidget = By.XPath("//p[contains(.,'Quick Launch')]");
        private By xpathBuzzLatestPostsWidget = By.XPath("//p[contains(.,'Buzz Latest Posts')]");
        private By xpathEmployeesonLeaveTodayWidget = By.XPath("//p[contains(.,'Employees on Leave Today')]");
        private By xpathEmployeeDistributionbySubUnitWidget = By.XPath("//p[contains(.,'Employee Distribution by Sub Unit')]");

        public DashBoardPage(IWebDriver _driver) : base(_driver)
        {
        }
        public bool VerifylbDashboardDisplay(int timouts = 1)
        {

            var defaultWait = driver.Manage().Timeouts().ImplicitWait;

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timouts);

                return driver.FindElement(xpathDashboardlb).Displayed;
            }
            catch
            {
                return false;
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = defaultWait;

            }


        }

        // Veriry one widget display in dashboard
        public bool VerifyWidgetDisplay(By xpath)
        {
            try
            {
                IWebElement element = driver.FindElement(xpath);
                IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
                je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        // Verify all widget in dashboard is display
        public bool VerifyAllWidgeDisplay()
        {
            return
              VerifyWidgetDisplay(xpathTimeatWorkWidget) &&
              VerifyWidgetDisplay(xpathQuickLaunchWidget) &&
              VerifyWidgetDisplay(xpathMyActionWidget) &&
              VerifyWidgetDisplay(xpathBuzzLatestPostsWidget) &&
              VerifyWidgetDisplay(xpathEmployeesonLeaveTodayWidget) &&
              VerifyWidgetDisplay(xpathEmployeeDistributionbySubUnitWidget);


        }
    }
}
