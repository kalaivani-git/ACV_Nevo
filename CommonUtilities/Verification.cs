using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Nevo.HelperUtilities;
using Nevo.Base;
using SeleniumExtras.WaitHelpers;

namespace Nevo
{
    [TestFixture]
    public class Verification : BaseClass
    {
        public void validatePageTitle(IWebDriver driver, String titleText, string stepDescription = "")
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                // Wait until the page title is available
                wait.Until(ExpectedConditions.TitleIs(titleText));
                Assert.AreEqual(driver.Title, titleText);
                if (stepDescription != "")
                    _test.Pass("Passed : " + stepDescription);
                _test.Pass("Passed : " + stepDescription, captureScreenshot(driver, filename));
                Console.WriteLine("The Page Title is " + driver.Title);
            }
            catch (Exception e)
            {
                captureScreenshotForCI(driver);
                _test.Fail("Failed : " + stepDescription + e.Message + e.StackTrace, captureScreenshot(driver, filename));
                throw new InvalidOperationException("Error in validatePageTitle." + Environment.NewLine + e.ToString());
            }
        }

        public void validateTwoStringsAreEqual(string firstString, String elemText, string stepDescription)
        {
            try
            {
                Assert.AreEqual(firstString, elemText);
                if (stepDescription != "")
                    _test.Pass("Passed : " + stepDescription);
            }
            catch (Exception e)
            {
                captureScreenshotForCI(driver);
                _test.Fail("Failed : " + stepDescription + e.Message + e.StackTrace, captureScreenshot(driver, filename));
                throw new InvalidOperationException("Error in validateText." + Environment.NewLine + e.ToString());
            }
        }      
        
        public void validateElementExistsInBrowser(IWebDriver driver, By element, string stepDescription = "")
        {
            try
            {
               
                WaitUtils.FindElement(driver, element, 40);
                Assert.IsTrue(driver.FindElement(element) != null);
                if (stepDescription != "")
                    if (_test != null)
                    {
                        _test.Pass("Passed : " + stepDescription);
                    }
            }
            catch (Exception e)
            {
                captureScreenshotForCI(driver);
                _test.Fail("Failed : " + stepDescription + e.Message + e.StackTrace, captureScreenshot(driver, filename));
                throw new InvalidOperationException("Error in validateElementExists." + Environment.NewLine + e.ToString());
            }
        }
    }
}
