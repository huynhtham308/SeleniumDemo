using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ICSharpCode.test
{
    [TestClass]
    public class BaseTest
    {
        private string userNameInput = "//input[@id='user-name122']";
        private string passwordInput = "//input[@id='password']";
        private string loginbtn = "//input[@id='login-button']";
        private string item = "//div[contains(text(),'Sauce Labs Onesie')]";
        private string addToCartBtn = "//button[contains(text(),'ADD TO CART')]";
        private string cartIcon = "//*[@class='shopping_cart_container']";
        private string productIncart = "//div[text()='Sauce Labs Onesie']";
        private IWebDriver Driver;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(),VersionResolveStrategy.MatchingBrowser);

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Implicit wait
        }

        [TestCleanup]
        public void Teardown()
        {
            Driver.Quit();
        }
        //To prove that it only waits up to the set time

        

        [TestMethod]
        public void VerifyCheckout()
        {

            // 1. Navigate to the URL of the Sauce Demo website
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");



            // 1. Create a Stopwatch instance to measure the execution time
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                // 2. Start the stopwatch to measure the time taken for the action
                stopwatch.Start();
                // 3. Attempt to send the key 'standard_user' to the input field with the specified XPath
                SendKeyOnInput(userNameInput, "standard_user");
            }
            catch (NoSuchElementException)
            {
                // 4. stop the stopwatch to record the elapsed time
                stopwatch.Stop();

                // 5. Calculate the elapsed time
                TimeSpan elapsedTime = stopwatch.Elapsed;

                // 6. Write the elapsed time to the Trace output
                Trace.WriteLine("Thời gian trôi qua: " + elapsedTime.Seconds.ToString());
            }







            //// 2. Enter the username 'standard_user' into the corresponding input field
            //SendKeyOnInput(userNameInput, "standard_user");

            //// 3. Enter the password 'secret_sauce' into the corresponding input field
            //SendKeyOnInput(passwordInput, "secret_sauce");

            //// 4. Click on the login button to authenticate
            //ClickOnElement(loginbtn);

            //// 5. Click on the product 'Sauce Labs Onesie' to view details
            //ClickOnElement(item);

            //// 6. Click on the 'ADD TO CART' button to add the product to the shopping cart
            //ClickOnElement(addToCartBtn);

            //// 7. Click on the shopping cart icon to view the cart
            //ClickOnElement(cartIcon);
            //// 8. Verify that the product added is displayed on the cart.
            //Assert.IsTrue(Driver.FindElement(By.XPath(productIncart)).Displayed);
        }



        public void ClickOnElement(string xpath)
        {
            IWebElement element = Driver.FindElement(By.XPath(xpath));
            element.Click();
        }
        public void SendKeyOnInput(string xpath,string value)
        {
            IWebElement element = Driver.FindElement(By.XPath(xpath));
            element.SendKeys(value);
        }
    }
}
