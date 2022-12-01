using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02.Pages
{
    public class WebHostingPage
    {
        public void AddSingleWebHostingPlanToCart(IWebDriver driver)
        {



            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";


            /* Explicit Wait */
            /* IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath))); */

            By by = By.XPath("//div[@switcher-value='Web Hosting']" +
                "//button[contains(@data-click-id,'add_to_cart-hosting_hostinger_starter')]");
            IWebElement addToCartButton = driver.FindElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(addToCartButton);
            try
            {
                actions.Perform();
            }
            catch (Exception ex) { }

            Thread.Sleep(500);

            //ClickElementByBy(by);


            //IWebElement addToCartButton = fluentWait.Until(x => x.FindElement(element));
            addToCartButton.Click();
        }
    }
}
