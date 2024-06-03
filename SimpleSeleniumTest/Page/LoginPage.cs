using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSeleniumTest.Page
{
    public class LoginPage : BasePage
    {
        private By xpathInputUserName = By.XPath("//input[contains(@name,'username')]");
        private By xpathInputPassWord = By.XPath("//input[contains(@name,'password')]");
        private By xpathButtonLogin = By.XPath("//button[contains(.,'Login')]");
        private By xpathMessage = By.XPath("//p[contains(.,'Invalid credentials')] | //div[contains(@class,'toast-error')]");

        public LoginPage(IWebDriver _driver) : base(_driver)
        {
        }

        public void InputUserName(string userName)
        {
            driver.FindElement(xpathInputUserName).SendKeys(userName);
        }
        public void InputPassWord(string passWord)
        {
            driver.FindElement(xpathInputPassWord).SendKeys(passWord);
        }
        public void ClickBtnLogin()
        {
            driver.FindElement(xpathButtonLogin).Click();

        }
        public void EnterLoginUseNameAndPassword(string userName,string password)
        {
            InputUserName(userName);
            InputPassWord(password);
            ClickBtnLogin();
          
        }
        public string VerifyErrorMessageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(xpathMessage));

            return element.Text;
        
        }
  

    }
}
