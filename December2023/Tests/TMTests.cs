using December2023.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using December2023.Utilities;
using NUnit.Framework.Interfaces;

namespace December2023.Tests
{
    [TestFixture]
    public class TMTests : CommonDriver
    {
        [SetUp]
        public void SetUpTM()
        {
            //Open the Chrome browser
            driver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.verifyLoggedInUser(driver);
            homePageObj.GoToTMPage(driver);
        }

        //Test 01
        [Test, Order(1), Description("This test create a new Time record with valid data")]
        public void TestCreateTimeRecord()
        {
            //TMPage object initialization and definition
            TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.CreateTimeRecord(driver);
        }

        //Test 02
        [Test, Order(2), Description("This test edit the Time record with valid data")]
        public void TestEditTimeRecord()
        {
            TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.EditTimeRecord(driver);
        }

        //Test 03
        [Test, Order(3), Description("This test delete the Time record")]
        public void TestDeleteTimeRecord()
        {
            TimeMaterialPage tmPageObj = new TimeMaterialPage();
            tmPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                // Capture screenshot using utility class on test failure
                ScreenshotUtility.CaptureAndSaveScreenshot(driver, TestContext.CurrentContext.Test.Name);
            }
            driver.Quit();
        }
    }
}
