using December2023.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace December2023.Pages
{
    public class TimeMaterialPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Test Case - Create a new Time record
            //Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.LinkText("Create New"));
            createNewButton.Click();

            //Select Time from dropdown
            IWebElement typeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeMainDropdown.Click();

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            typeCodeDropdown.Click();

            //Enter Code
            Wait.WaitToBeClickable(driver, "Id", "Code", 1);
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("January2024");

            // Enter Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Desc January 2024");

            //Enter price
            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("123123.34");

            //Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);
            Thread.Sleep(1000);
            //Check if a new time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);

            Thread.Sleep(1000);
            IWebElement newRecordData = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newRecordData.Text.Equals("January2024"), "Time record has not been created");
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            //Code for Edit Time Record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on Edit Button
            IWebElement editButton = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(3000);

            //Edit Code in Code Textbox
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("IC2023Edited");

            //Edit Description in Description Textbox
            IWebElement editDescriptionTextBox = driver.FindElement(By.Id("Description"));
            editDescriptionTextBox.Clear();
            editDescriptionTextBox.SendKeys("IC2023Edited");

            //Edit Price in Price Textbox
            IWebElement editPriceOverlappingTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPriceTextBox = driver.FindElement(By.Id("Price"));
            editPriceOverlappingTag.Click();
            editPriceTextBox.Clear();
            editPriceOverlappingTag.Click();
            editPriceTextBox.SendKeys("500");

            //Click on save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(7000);

            // Clock on goToLastPage Button
            IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editGoToLastPageButton.Click();

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement EditedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            if (editedCode.Text == "IC2023Edited" && EditedDescription.Text == "IC2023Edited")
            {
                Console.WriteLine("Time Record has been updated successfully");
            }
            else
            {
                Console.WriteLine("Time Record has not been updated");
            }
        }

        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Code for Delete Time Record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();

            IWebElement lastCodeInTable = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastCodeInTable.Text == "IC2023Edited")
            {
                Console.WriteLine("Time Record has not been deleted");
            }
            else
            {
                Console.WriteLine("Time Record has been deleted successfully");
            }
        }
    }
}
