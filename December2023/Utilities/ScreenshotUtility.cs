using OpenQA.Selenium;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace December2023.Utilities
{
    public static class ScreenshotUtility
    {
        private static string ScreenshotsFolder = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "..", "Screenshots");

        public static void CaptureAndSaveScreenshot(IWebDriver driver, string screenshotFileName = "")
        {
            try
            {
                if (!Directory.Exists(ScreenshotsFolder))
                {
                    Console.WriteLine($"Creating Screenshots folder: {ScreenshotsFolder}");
                    Directory.CreateDirectory(ScreenshotsFolder);
                }

                // Convert the Screenshot to a Bitmap
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                // Include custom name or use timestamp if no custom name is provided
                string fileName = string.IsNullOrEmpty(screenshotFileName)
                    ? $"{DateTime.Now:yyyyMMdd_HHmmss}.png"
                    : $"{screenshotFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                using (MemoryStream stream = new MemoryStream(screenshot.AsByteArray))
                {
                    using (Bitmap bitmap = new Bitmap(stream))
                    {
                        // Save the Bitmap in the desired format (e.g., PNG)
                        string filePath = Path.Combine(ScreenshotsFolder, fileName);
                        bitmap.Save(filePath, ImageFormat.Png);
                        Console.WriteLine($"Screenshot saved: {filePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing or saving screenshot: {ex.Message}");
            }
        }
    }
}
