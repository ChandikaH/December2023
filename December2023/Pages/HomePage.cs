using December2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December2023.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            try
            {
                //Navigate to Time & Material module (Click on Administration -> Time & Material link)
                IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/test/a"));
                administrationDropdown.Click();

                IWebElement tmOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
                tmOption.Click();
            }
            catch (Exception exception)
            {
                Assert.Fail("Turnup portal Home page not displayed " + exception.Message);
            }
        }

        public void verifyLoggedInUser(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"logoutForm\"]/ul/li/a", 5);
            //Check if user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in successfully");
            }
            else
            {
                Console.WriteLine("User hasn't been logged in.");
            }
        }
    }
}
