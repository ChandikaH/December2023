using OpenQA.Selenium;

namespace December2023.Pages
{
    public class LoginPage
    {
        private readonly By usernameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextBox;
        private readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement passwordTextBox;
        private readonly By loginButtonLocator = By.XPath("//*[@id='loginForm']/form/div[3]/input[1]");
        IWebElement loginButton;

        public void LoginActions(IWebDriver driver)
        {
            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Launch TurnUp portal and navigate to website login page
            string baseURL = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Identify username textbox and enter valid username
            usernameTextBox = driver.FindElement(usernameTextboxLocator);
            usernameTextBox.SendKeys("hari");
            
            //Identify password textbox and enter valid password
            passwordTextBox = driver.FindElement(passwordTextboxLocator);
            passwordTextBox.SendKeys("123123");

            //Identify the login button and click on the button
            loginButton = driver.FindElement(loginButtonLocator);
            loginButton.Click();
        }
    }
}
