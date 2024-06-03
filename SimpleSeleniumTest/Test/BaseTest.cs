using AventStack.ExtentReports;
using SimpleSeleniumTest.Page;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using TestFrameWorkCore.Helper;
using TestFrameWorkCore.Helper.Report;
using WebDriverHelper.Helper;

namespace SimpleSeleniumTest.Test
{
    public class BaseTest
    {
        protected BrowerHelper brower;
        public static ReportHelper reportHelper;
        public TestContext TestContext {  get; set; }
        protected ExtentTest extentTest;
        public virtual void SetUpPage()
        {

        }

        [TestInitialize]
        public void SetUp()

        {

            brower = new BrowerHelper();
            brower.OpenBrower(ConfigurationHelper.GetConfig<string>("url"));
            SetUpPage();

            //create Test

            MethodInfo method = GetType().GetMethod(TestContext.TestName);
            var displayNameAttribute = method.GetCustomAttribute<DisplayNameAttribute>();
            extentTest= reportHelper.CreateTest(TestContext.TestName, displayNameAttribute != null ? displayNameAttribute.DisplayName : TestContext.TestName);

        }
        [TestCleanup]
        public void TearDown()
        {

            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed){
                extentTest.AddImagebase64(brower.TakeScreenShotAsBase64());
            }
            if (extentTest != null) extentTest.AddResult(TestContext.CurrentTestOutcome.ToString());

            brower.QuitDriver();

        }
    }
}
