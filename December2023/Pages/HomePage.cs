﻿using December2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace December2023.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            try
            {
                //Navigate to Time & Material module (Click on Administration -> Time & Material link)
                IWebElement administrationDropdown = driver.FindElement(By.XPath("//a[contains(text(),'Administration')]"));
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
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@id=\"logoutForm\"]/ul/li/a", 5);
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
