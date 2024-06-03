
using TestFrameWorkCore.Helper.Report;

namespace SimpleSeleniumTest.Test

{

    [TestClass]
    [assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

    public class AssemblyTest
    {
        [AssemblyInitialize]
        public static  void AssemblyInitalize(TestContext context)
        {
            BaseTest.reportHelper = new ReportHelper();
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if(BaseTest.reportHelper != null)
            {
                BaseTest.reportHelper.ExportReport();
            }
        }
    }
}
