using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace December2023.Utilities
{
    public class WaitUtils
    {
        public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            By by = GetBy(locatorType, locatorValue);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            By by = GetBy(locatorType, locatorValue);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        private static By GetBy(string locatorType, string locatorValue)
        {
            switch (locatorType.ToLower())
            {
                case "xpath":
                    return By.XPath(locatorValue);
                case "id":
                    return By.Id(locatorValue);
                case "cssselector":
                    return By.CssSelector(locatorValue);
                case "name":
                    return By.Name(locatorValue);
                default:
                    throw new ArgumentException($"Unsupported locator type: {locatorType}");
            }
        }
    }
}
