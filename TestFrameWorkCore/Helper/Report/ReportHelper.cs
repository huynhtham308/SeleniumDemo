using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestFrameWorkCore.Helper.Report
{
    public class ReportHelper
    {
        private ExtentReports extent;

        public ReportHelper()
        {
            InitReport();
        }

        public void InitReport()
        {
            extent = new ExtentReports();
            //random name report

            //create folder save all report
            var reportName = $"Report_{DateTime.Now.ToFileTimeUtc()}.html";

            // Create a folder to save all reports
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", reportName);
            var spark = new ExtentSparkReporter(reportPath);
            extent.AttachReporter(spark);

        }
        // Day toan bo report dang luu trong Ram ra 
        public void ExportReport()
        {
            extent.Flush();
        }
        public ExtentTest CreateTest(string testName, string description)
        {
            return extent.CreateTest(testName, description);

        }
        

    }
}
