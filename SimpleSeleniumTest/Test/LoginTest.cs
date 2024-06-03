using FluentAssertions;
using SimpleSeleniumTest.Page;
using System.Diagnostics;
using TestFrameWorkCore.Helper;
using TestFrameWorkCore.Helper.Report;
using WebDriverHelper.Helper;

namespace SimpleSeleniumTest.Test
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;
        private DashBoardPage dashBoardPage;

     
        //[TestInitialize]
        //public void SetUp()

        //{
        //    loginPage = new LoginPage(brower.driver);
        //    dashBoardPage = new DashBoardPage(brower.driver);
        //}
        private string userName = ConfigurationHelper.GetConfig<string>("username");

        public override void SetUpPage()
        {
            Trace.WriteLine("OVERIDE CONS");
            loginPage = new LoginPage(brower.driver);
            dashBoardPage = new DashBoardPage(brower.driver);
        }
        [TestMethod("T01: Login with valid username and password")]
        public void ValidationValidUser()
        {
            Trace.WriteLine("ValidationValidUser");

            string password = ConfigurationHelper.GetConfig<string>("password");
            // Entering username and password
            loginPage.EnterLoginUseNameAndPassword(userName, password);
            extentTest.LogMessage($"Logging in with username '{userName}' and password '{password}'");

            // Verifying Dashboard display
            dashBoardPage.VerifylbDashboardDisplay(10).Should().BeTrue();
            extentTest.LogMessage("Dashboard display verified successfully");
        }

        [TestMethod("T02: Login with invalid username or password")]
        public void ValidationInValidUser()
        {
            // Entering username and invalid password
            loginPage.EnterLoginUseNameAndPassword(userName, "admin123111");
            extentTest.LogMessage($"Logging in with username '{userName}' and an invalid password");

            loginPage.ClickBtnLogin();
            // Verifying error message
            loginPage.VerifyErrorMessageDisplay().Should().Contain("Invalid");
            extentTest.LogMessage("Error message verified successfully");

            // Verifying Dashboard display
            dashBoardPage.VerifylbDashboardDisplay().Should().BeFalse();
        }

        //[DataTestMethod]
        //[DynamicData(nameof(MyDataCreator), DynamicDataSourceType.Method)]
        //public void VerifyAdd2VilidValue(string Username, string Password, bool IsLabelDashboardIsDisplay)
        //{

        //    loginPage.EnterLoginUseNameAndPassword(Username,Password);
        //    dashBoardPage.VerifylbDashboardDisplay().Should().Be(IsLabelDashboardIsDisplay);

        //}


        //public static IEnumerable<object[]> MyDataCreator()
        //{
        //    return new ExcelHelper(Path.Combine("Resource", "VerifyLoginUser.xlsx")).GetLoginUserData();
        //}

    }
}
