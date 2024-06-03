using SimpleSeleniumTest.Page;
using TestFrameWorkCore.Model;
using WebDriverHelper.Helper;
using SimpleSeleniumTest.Model;
using Newtonsoft.Json;
using FluentAssertions;


namespace SimpleSeleniumTest.Helper
{
    public class KeyWordHelper
    {
        private List<KeyWordData> keyWords;
        private BrowerHelper brower;


        public KeyWordHelper(List<KeyWordData> words)
        {
            this.keyWords = words;
        }
        /// <summary>
        /// Execute keyword in list
        /// </summary>
        public void ExecuteKeyWord()
        {
            foreach (var keyWord in keyWords)
            {
                ExcuteKeyWord(keyWord);
            }
        }

        public void ExcuteKeyWord(KeyWordData keyWord)
        {
            switch (keyWord.Keyword)
            {
                case "Open Browser":
                    brower = new BrowerHelper();
                    brower.OpenBrower(browseType: keyWord.Data);
                    break;
                case "Go to URL":
                    brower.GotoURL(keyWord.Data);
                    break;
                case "Enter userName":
                    EnterUserName(keyWord.Data);
                    break;
                case "Enter password":
                    EnterPassWord(keyWord.Data);
                    break;

                case "Enter username and password":
                    UserModel userModel = JsonConvert.DeserializeObject<UserModel>(keyWord.Data);
                    EnterUerNameAndPassWord(userModel.userName,userModel.password);
                    break;

                case "CLick button login":
                    ClickButtonLogin();
                    break;
                case "verify dashboard display":
                    DashBoardModel dashBoardModel = JsonConvert.DeserializeObject<DashBoardModel>(keyWord.Data);
                    VerifyDashBoardDisplay(dashBoardModel.TimeOut, dashBoardModel.Expected);
                    break;
                case "Close Browser":
                    brower.QuitDriver();
                    break;

                default:
                    throw new Exception("Not Support this keyword");
            }
        }

        private void EnterUerNameAndPassWord(string username, string password)
        {
            LoginPage loginPage = new LoginPage(brower.driver);
            loginPage.EnterLoginUseNameAndPassword(username, password);
        }

        private void EnterUserName(string userName)
        {
            LoginPage loginPage = new LoginPage(brower.driver);
            loginPage.InputUserName(userName);

        }
        private void EnterPassWord(string passWord)
        {
            LoginPage loginPage = new LoginPage(brower.driver);
            loginPage.InputPassWord(passWord);
        }
        private void ClickButtonLogin()
        {
            LoginPage loginPage = new LoginPage(brower.driver);
            loginPage.ClickBtnLogin();
        }
        private void VerifyDashBoardDisplay(int timeout, bool expected)
        {
            DashBoardPage dashBoardPage = new DashBoardPage(brower.driver);

            dashBoardPage.VerifylbDashboardDisplay(timeout).Should().Be(expected);
        }


    }
}
