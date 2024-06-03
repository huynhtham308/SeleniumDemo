using FluentAssertions;
using SimpleSeleniumTest.Page;
using TestFrameWorkCore.Helper;
using WebDriverHelper.Helper;
using TestFrameWorkCore.Helper.Report;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class DashBoardTest : BaseTest
    {
        private DashBoardPage dashBoardPage;
        private LoginPage loginpage;
        public override void SetUpPage()
        {
            dashBoardPage = new DashBoardPage(brower.driver);
            loginpage = new LoginPage(brower.driver);
        }

        [TestMethod]
        public void VerifyAllWidgetDashboardDisplay()
        {
            string password = ConfigurationHelper.GetConfig<string>("password");
            string userName = ConfigurationHelper.GetConfig<string>("username");
            extentTest.LogMessage($"Log config -username{userName} va {password}");

            loginpage.EnterLoginUseNameAndPassword(userName, password);
            extentTest.LogMessage($"Verify Dashboard Display");

            dashBoardPage.VerifylbDashboardDisplay().Should().BeTrue();

            //dashBoardPage.VerifyAllWidgeDisplay().Should().BeTrue();
        }
    }
}
