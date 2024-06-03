

using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertIframe.Test
{
    [TestClass]
    public class IframeTest
    {
        private By xpathInput = By.XPath("//input[@type='text']");//  //input[@type='text'][ancestor-or-self::div[child::h5]]
        private By xpathFrame = By.XPath("//iframe[@id='singleframe']");
        private By xpathButtonMultipleFrame = By.XPath("");

        [TestInitialize]
        public void SetUp()
        {
            BrowerHelper.GetBrowerHellper().OpenBrower("https://demo.automationtesting.in/Frames.html");

        }
        [TestCleanup]
        public void TearDown()
        {
            BrowerHelper.GetBrowerHellper().QuitDriver();

        }

        [TestMethod]
        public void VerifyIframe()
        {
            //  Switch to Frame
            //  Send Key
            // SwitchToDefault 

        }
    }
        }
    }
}
