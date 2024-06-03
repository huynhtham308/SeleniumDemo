using AventStack.ExtentReports;

namespace TestFrameWorkCore.Helper.Report
{
    public static class ReportHelperExtention
    {
      public static  void LogMessage(this ExtentTest test, string messge)
        {
            test.Log(Status.Info, messge);
        }
        /// <summary>
        /// Passed/Fail
        /// </summary>
        /// <param name="test"></param>
        /// <param name="result"></param>
        public static void AddResult(this ExtentTest test, string result)
        {
            if (result.Equals("Passed")) test.Pass("Test case Passed");
            else test.Fail("Test case Fail");

        }
        public static void AddImagebase64(this ExtentTest test, string imagebase64)
        {
            test.AddScreenCaptureFromBase64String(imagebase64, "screenshot");
        }
    }
}
