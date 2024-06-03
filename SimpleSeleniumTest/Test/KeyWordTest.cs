using SimpleSeleniumTest.Helper;
using TestFrameWorkCore.Helper;

namespace KeyWorDrivenTest.Test
{
    [TestClass]
    public class KeyWordTest
    {
        [TestMethod("TC01: Verify login using keyword driven")]
        public void VerifyLogin()
        {
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resource", "keyword_driven.xlsx"));
            var keyWords = excelHelper.GetKeyWordData();
            // Execute 
            var keyWordhelpers = new KeyWordHelper(keyWords);
            keyWordhelpers.ExecuteKeyWord();
        }
        [TestMethod("TC02: Verify dlogin with valid user")]
        public void VerifyLogin1()
        {
            ExcelHelper excelHelper = new ExcelHelper(Path.Combine("Resource", "keywordDriven2.xlsx"));
            var keyWords = excelHelper.GetKeyWordData();
            // Execute 
            var keyWordhelpers = new KeyWordHelper(keyWords);
            keyWordhelpers.ExecuteKeyWord();
        }

    }
}