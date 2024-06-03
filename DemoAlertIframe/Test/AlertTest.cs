using OpenQA.Selenium;
using WebDriverHelper.Helper;

namespace DemoAlertIframe.Test
{
    [TestClass]
    public class AlertTest
    {

        private By xpathAlertBtn (String text)=> By.XPath($"//button[text()='{text}']");


        [TestMethod]
        public void VerifyAlert()
        {
            BrowerHelper.GetBrowerHellper().OpenBrower("https://the-internet.herokuapp.com/javascript_alerts");
            BrowerHelper.GetBrowerHellper().driver.FindElement(xpathAlertBtn("Click for JS Alert")).Click();
            BrowerHelper.GetBrowerHellper().driver.SwitchTo().Alert().Accept();
            BrowerHelper.GetBrowerHellper().driver.Quit();
        }
        [TestMethod]
        public void VerifyAlertComfirm()
        {
            BrowerHelper.GetBrowerHellper().OpenBrower("https://the-internet.herokuapp.com/javascript_alerts");
            BrowerHelper.GetBrowerHellper().driver.FindElement(xpathAlertBtn("Click for JS Confirm")).Click();
            BrowerHelper.GetBrowerHellper().driver.SwitchTo().Alert().Dismiss();
            BrowerHelper.GetBrowerHellper().driver.Quit();

        }
        public void VerifyAlertPromt()
        {
            
            BrowerHelper.GetBrowerHellper().OpenBrower("https://the-internet.herokuapp.com/javascript_alerts");
            BrowerHelper.GetBrowerHellper().driver.FindElement(xpathAlertBtn("Click for JS Prompt")).Click();
            BrowerHelper.GetBrowerHellper().driver.SwitchTo().Alert().SendKeys("Tham" + DateTime.Now.ToFileTimeUtc());
            BrowerHelper.GetBrowerHellper().driver.SwitchTo().Alert().Accept();
            BrowerHelper.GetBrowerHellper().driver.Quit();


        }
    }
}
